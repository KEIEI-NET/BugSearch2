using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 売上内容分析表帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 売上内容分析表帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.11</br>
    /// <br>Update Note  : 2008.11.25 30452 上野 俊治</br>
    /// <br>              ・純正の左、外装の左に仕切り線追加</br>
    /// <br>              ・地区コードがゼロ値の場合、名称"未登録"を印字</br>
    /// <br>Update Note  : 2009.01.19 30452 上野 俊治</br>
    /// <br>              ・障害対応10086（率計算時、プラスとするための補正処理を削除）</br>
    /// <br>             :</br>
    /// </remarks>
    public partial class PMHNB02163P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02163P_01A4C()
        {
            InitializeComponent();
        }
        #endregion

        #region ■ private変数

        private int _printCount;						// 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;		// 抽出条件
        private int _pageFooterOutCode;				    // フッター出力区分
        private StringCollection _pageFooters;			// フッターメッセージ
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        private SalesHistAnalyzeCndtn _salesHistAnalyzeCndtn;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        #region ActiveReport生成
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private Line Line1;
        private Label tb_ReportTitle;
        private Label Label3;
        private TextBox tb_PrintDate;
        private TextBox tb_PrintTime;
        private Label Label2;
        private TextBox tb_PrintPage;
        private SubReport Header_SubReport;
        private Line Line2;
        private Label Lb_Title;
        private TextBox SalesMoneyOther;
        private TextBox SalesMoneyOtherCompRate;
        private TextBox SalesMoneyOutsideCompRate;
        private TextBox SalesMoneyOutside;
        private TextBox SalesMoneyPrm;
        private TextBox SalesMoneyGenuine;
        private TextBox SalesMoneyStock;
        private TextBox SalesMoneyOrder;
        private TextBox CodeName;
        private TextBox textBox11;
        private TextBox SalesMoneyPrmCompRate;
        private TextBox SalesMoneyGenuineCompRate;
        private TextBox textBox8;
        private TextBox SalesMoneyStockCompRate;
        private TextBox SalesMoneyOrderCompRate;
        private TextBox textBox13;
        private TextBox dayTotalTitle;
        private TextBox Code;
        private TextBox GrossProfitOther;
        private TextBox GrossProfitOtherCompRate;
        private TextBox GrossProfitOutsideCompRate;
        private TextBox GrossProfitOutside;
        private TextBox GrossProfitPrm;
        private TextBox GrossProfitGenuine;
        private TextBox GrossProfitStock;
        private TextBox GrossProfitOrder;
        private TextBox textBox23;
        private TextBox GrossProfitPrmCompRate;
        private TextBox GrossProfitGenuineCompRate;
        private TextBox textBox26;
        private TextBox GrossProfitStockCompRate;
        private TextBox GrossProfitOrderCompRate;
        private TextBox textBox29;
        private TextBox MonthSalesMoneyOther;
        private TextBox MonthSalesMoneyOtherCompRate;
        private TextBox MonthSalesMoneyOutsideCompRate;
        private TextBox MonthSalesMoneyOutside;
        private TextBox MonthSalesMoneyPrm;
        private TextBox MonthSalesMoneyGenuine;
        private TextBox MonthSalesMoneyStock;
        private TextBox MonthSalesMoneyOrder;
        private TextBox textBox38;
        private TextBox MonthSalesMoneyPrmCompRate;
        private TextBox MonthSalesMoneyGenuineCompRate;
        private TextBox textBox41;
        private TextBox MonthSalesMoneyStockCompRate;
        private TextBox MonthSalesMoneyOrderCompRate;
        private TextBox textBox44;
        private TextBox monthTotalTitle;
        private TextBox MonthGrossProfitOther;
        private TextBox MonthGrossProfitOtherCompRate;
        private TextBox MonthGrossProfitOutsideCompRate;
        private TextBox MonthGrossProfitOutside;
        private TextBox MonthGrossProfitPrm;
        private TextBox MonthGrossProfitGenuine;
        private TextBox MonthGrossProfitStock;
        private TextBox MonthGrossProfitOrder;
        private TextBox textBox54;
        private TextBox MonthGrossProfitPrmCompRate;
        private TextBox MonthGrossProfitGenuineCompRate;
        private TextBox textBox57;
        private TextBox MonthGrossProfitStockCompRate;
        private TextBox MonthGrossProfitOrderCompRate;
        private TextBox textBox60;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox SecHd_SectionCode;
        private TextBox SecHd_SectionGuideNm;
        private Label SecHd_SectionTitle;
        private Line line3;
        private TextBox SecFt_SalesMoneyOther;
        private TextBox SecFt_SalesMoneyOtherCompRate;
        private TextBox SecFt_SalesMoneyOutsideCompRate;
        private TextBox SecFt_SalesMoneyOutside;
        private TextBox SecFt_SalesMoneyPrm;
        private TextBox SecFt_SalesMoneyGenuine;
        private TextBox SecFt_SalesMoneyStock;
        private TextBox SecFt_SalesMoneyOrder;
        private TextBox textBox69;
        private TextBox SecFt_SalesMoneyPrmCompRate;
        private TextBox SecFt_SalesMoneyGenuineCompRate;
        private TextBox textBox72;
        private TextBox SecFt_SalesMoneyStockCompRate;
        private TextBox SecFt_SalesMoneyOrderCompRate;
        private TextBox textBox75;
        private TextBox SecFt_dayTotalTitle;
        private TextBox SecFt_GrossProfitOther;
        private TextBox SecFt_GrossProfitOtherCompRate;
        private TextBox SecFt_GrossProfitOutsideCompRate;
        private TextBox SecFt_GrossProfitOutside;
        private TextBox SecFt_GrossProfitPrm;
        private TextBox SecFt_GrossProfitGenuine;
        private TextBox SecFt_GrossProfitStock;
        private TextBox SecFt_GrossProfitOrder;
        private TextBox textBox85;
        private TextBox SecFt_GrossProfitPrmCompRate;
        private TextBox SecFt_GrossProfitGenuineCompRate;
        private TextBox textBox88;
        private TextBox SecFt_GrossProfitStockCompRate;
        private TextBox SecFt_GrossProfitOrderCompRate;
        private TextBox textBox91;
        private TextBox SecFt_MonthSalesMoneyOther;
        private TextBox SecFt_MonthSalesMoneyOtherCompRate;
        private TextBox SecFt_MonthSalesMoneyOutsideCompRate;
        private TextBox SecFt_MonthSalesMoneyOutside;
        private TextBox SecFt_MonthSalesMoneyPrm;
        private TextBox SecFt_MonthSalesMoneyGenuine;
        private TextBox SecFt_MonthSalesMoneyStock;
        private TextBox SecFt_MonthSalesMoneyOrder;
        private TextBox textBox100;
        private TextBox SecFt_MonthSalesMoneyPrmCompRate;
        private TextBox SecFt_MonthSalesMoneyGenuineCompRate;
        private TextBox textBox103;
        private TextBox SecFt_MonthSalesMoneyStockCompRate;
        private TextBox SecFt_MonthSalesMoneyOrderCompRate;
        private TextBox textBox106;
        private TextBox SecFt_monthTotalTitle;
        private TextBox SecFt_MonthGrossProfitOther;
        private TextBox SecFt_MonthGrossProfitOtherCompRate;
        private TextBox SecFt_MonthGrossProfitOutsideCompRate;
        private TextBox SecFt_MonthGrossProfitOutside;
        private TextBox SecFt_MonthGrossProfitPrm;
        private TextBox SecFt_MonthGrossProfitGenuine;
        private TextBox SecFt_MonthGrossProfitStock;
        private TextBox SecFt_MonthGrossProfitOrder;
        private TextBox textBox116;
        private TextBox SecFt_MonthGrossProfitPrmCompRate;
        private TextBox SecFt_MonthGrossProfitGenuineCompRate;
        private TextBox textBox119;
        private TextBox SecFt_MonthGrossProfitStockCompRate;
        private TextBox SecFt_MonthGrossProfitOrderCompRate;
        private TextBox textBox122;
        private TextBox GraFt_SalesMoneyOther;
        private TextBox GraFt_SalesMoneyOtherCompRate;
        private TextBox GraFt_SalesMoneyOutsideCompRate;
        private TextBox GraFt_SalesMoneyOutside;
        private TextBox GraFt_SalesMoneyPrm;
        private TextBox GraFt_SalesMoneyGenuine;
        private TextBox GraFt_SalesMoneyStock;
        private TextBox GraFt_SalesMoneyOrder;
        private TextBox textBox131;
        private TextBox GraFt_SalesMoneyPrmCompRate;
        private TextBox GraFt_SalesMoneyGenuineCompRate;
        private TextBox textBox134;
        private TextBox GraFt_SalesMoneyStockCompRate;
        private TextBox GraFt_SalesMoneyOrderCompRate;
        private TextBox textBox137;
        private TextBox GraFt_dayTotalTitle;
        private TextBox GraFt_GrossProfitOther;
        private TextBox GraFt_GrossProfitOtherCompRate;
        private TextBox GraFt_GrossProfitOutsideCompRate;
        private TextBox GraFt_GrossProfitOutside;
        private TextBox GraFt_GrossProfitPrm;
        private TextBox GraFt_GrossProfitGenuine;
        private TextBox GraFt_GrossProfitStock;
        private TextBox GraFt_GrossProfitOrder;
        private TextBox textBox147;
        private TextBox GraFt_GrossProfitPrmCompRate;
        private TextBox GraFt_GrossProfitGenuineCompRate;
        private TextBox textBox150;
        private TextBox GraFt_GrossProfitStockCompRate;
        private TextBox GraFt_GrossProfitOrderCompRate;
        private TextBox textBox153;
        private TextBox GraFt_MonthSalesMoneyOther;
        private TextBox GraFt_MonthSalesMoneyOtherCompRate;
        private TextBox GraFt_MonthSalesMoneyOutsideCompRate;
        private TextBox GraFt_MonthSalesMoneyOutside;
        private TextBox GraFt_MonthSalesMoneyPrm;
        private TextBox GraFt_MonthSalesMoneyGenuine;
        private TextBox GraFt_MonthSalesMoneyStock;
        private TextBox GraFt_MonthSalesMoneyOrder;
        private TextBox textBox162;
        private TextBox GraFt_MonthSalesMoneyPrmCompRate;
        private TextBox GraFt_MonthSalesMoneyGenuineCompRate;
        private TextBox textBox165;
        private TextBox GraFt_MonthSalesMoneyStockCompRate;
        private TextBox GraFt_MonthSalesMoneyOrderCompRate;
        private TextBox textBox168;
        private TextBox GraFt_monthTotalTitle;
        private TextBox GraFt_MonthGrossProfitOther;
        private TextBox GraFt_MonthGrossProfitOtherCompRate;
        private TextBox GraFt_MonthGrossProfitOutsideCompRate;
        private TextBox GraFt_MonthGrossProfitOutside;
        private TextBox GraFt_MonthGrossProfitPrm;
        private TextBox GraFt_MonthGrossProfitGenuine;
        private TextBox GraFt_MonthGrossProfitStock;
        private TextBox GraFt_MonthGrossProfitOrder;
        private TextBox textBox178;
        private TextBox GraFt_MonthGrossProfitPrmCompRate;
        private TextBox GraFt_MonthGrossProfitGenuineCompRate;
        private TextBox textBox181;
        private TextBox GraFt_MonthGrossProfitStockCompRate;
        private TextBox GraFt_MonthGrossProfitOrderCompRate;
        private TextBox textBox184;
        private TextBox SectionTitle;
        private Label GrandTotalTitle;
        private SubReport Footer_SubReport;
        private Line line5;
        private Line line4;
        private Line line6;
        private Line DetaliLine1;
        private Line DetaliLine2;
        private Line SecFt_Line1;
        private Line SecFt_Line2;
        private Line GraFt_Line1;
        private Line GraFt_Line2;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        #endregion

        #endregion

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        // ヘッダ用サブレポート後処理実行
                        if (this._rptExtraHeader != null)
                        {
                            this._rptExtraHeader.Dispose();
                        }

                        // フッタ用サブレポート後処理実行
                        if (this._rptPageFooter != null)
                        {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion ■ Dispose(override)

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property
        /// <summary>
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダー項目
        /// </summary>
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary>
        /// フッター出力区分
        /// </summary>
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary>
        /// フッタ出力文
        /// </summary>
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._salesHistAnalyzeCndtn = (SalesHistAnalyzeCndtn)this._printInfo.jyoken;
            }
        }

        /// <summary>
        /// その他データ
        /// </summary>
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>
        /// 帳票サブタイトル
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
        }

        /// <summary>
        /// 印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■ IPrintActiveReportTypeCommon メンバ
        #region ◆ Public Property
        /// <summary>
        /// 背景透過設定値プロパティ
        /// </summary>
        public int WatermarkMode
        {
            get
            {
                // TODO:  MAZAI02032P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  MAZAI02032P_01A4C.WatermarkMode setter 実装を追加します。
            }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■ privateメソッド
        /// <summary>
        /// 帳票出力設定処理
        /// </summary>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //-------------------------------------------------------
            // 累計印刷の適用
            //-------------------------------------------------------
            #region [累計印刷の適用]
            // 0:する 1:しない
            #region [作業用のリストを生成]
            // 上段項目リスト（日計）
            List<TextBox> dayList = new List<TextBox>();
            dayList.AddRange(new TextBox[] { dayTotalTitle, SalesMoneyOrder, SalesMoneyStock, SalesMoneyOrderCompRate, textBox13, SalesMoneyStockCompRate, SalesMoneyGenuine, SalesMoneyPrm, SalesMoneyGenuineCompRate, textBox8, SalesMoneyPrmCompRate, SalesMoneyOutside, SalesMoneyOther, SalesMoneyOutsideCompRate, textBox11, SalesMoneyOtherCompRate,
                                             GrossProfitOrder, GrossProfitStock, GrossProfitOrderCompRate, textBox29, GrossProfitStockCompRate, GrossProfitGenuine, GrossProfitPrm, GrossProfitGenuineCompRate, textBox26, GrossProfitPrmCompRate, GrossProfitOutside, GrossProfitOther, GrossProfitOutsideCompRate, textBox23, GrossProfitOtherCompRate});

            List<TextBox> SecFt_dayList = new List<TextBox>();
            SecFt_dayList.AddRange(new TextBox[] { SecFt_dayTotalTitle, SecFt_SalesMoneyOrder, SecFt_SalesMoneyStock, SecFt_SalesMoneyOrderCompRate, textBox75, SecFt_SalesMoneyStockCompRate, SecFt_SalesMoneyGenuine, SecFt_SalesMoneyPrm, SecFt_SalesMoneyGenuineCompRate, textBox72, SecFt_SalesMoneyPrmCompRate, SecFt_SalesMoneyOutside, SecFt_SalesMoneyOther, SecFt_SalesMoneyOutsideCompRate, textBox69, SecFt_SalesMoneyOtherCompRate,
                                                   SecFt_GrossProfitOrder, SecFt_GrossProfitStock, SecFt_GrossProfitOrderCompRate, textBox91, SecFt_GrossProfitStockCompRate, SecFt_GrossProfitGenuine, SecFt_GrossProfitPrm, SecFt_GrossProfitGenuineCompRate, textBox88, SecFt_GrossProfitPrmCompRate, SecFt_GrossProfitOutside, SecFt_GrossProfitOther, SecFt_GrossProfitOutsideCompRate, textBox85, SecFt_GrossProfitOtherCompRate});

            List<TextBox> GraFt_dayList = new List<TextBox>();
            GraFt_dayList.AddRange(new TextBox[] { GraFt_dayTotalTitle, GraFt_SalesMoneyOrder, GraFt_SalesMoneyStock, GraFt_SalesMoneyOrderCompRate, textBox137, GraFt_SalesMoneyStockCompRate, GraFt_SalesMoneyGenuine, GraFt_SalesMoneyPrm, GraFt_SalesMoneyGenuineCompRate, textBox134, GraFt_SalesMoneyPrmCompRate, GraFt_SalesMoneyOutside, GraFt_SalesMoneyOther, GraFt_SalesMoneyOutsideCompRate, textBox131, GraFt_SalesMoneyOtherCompRate,
                                                   GraFt_GrossProfitOrder, GraFt_GrossProfitStock, GraFt_GrossProfitOrderCompRate, textBox153, GraFt_GrossProfitStockCompRate, GraFt_GrossProfitGenuine, GraFt_GrossProfitPrm, GraFt_GrossProfitGenuineCompRate, textBox150, GraFt_GrossProfitPrmCompRate, GraFt_GrossProfitOutside, GraFt_GrossProfitOther, GraFt_GrossProfitOutsideCompRate, textBox147, GraFt_GrossProfitOtherCompRate});

            // 下段項目リスト（累計）
            List<TextBox> monthList = new List<TextBox>();
            monthList.AddRange(new TextBox[] { monthTotalTitle, MonthSalesMoneyOrder, MonthSalesMoneyStock, MonthSalesMoneyOrderCompRate, textBox44, MonthSalesMoneyStockCompRate, MonthSalesMoneyGenuine, MonthSalesMoneyPrm, MonthSalesMoneyGenuineCompRate, textBox41, MonthSalesMoneyPrmCompRate, MonthSalesMoneyOutside, MonthSalesMoneyOther, MonthSalesMoneyOutsideCompRate, textBox38, MonthSalesMoneyOtherCompRate,
                                             MonthGrossProfitOrder, MonthGrossProfitStock, MonthGrossProfitOrderCompRate, textBox60, MonthGrossProfitStockCompRate, MonthGrossProfitGenuine, MonthGrossProfitPrm, MonthGrossProfitGenuineCompRate, textBox57, MonthGrossProfitPrmCompRate, MonthGrossProfitOutside, MonthGrossProfitOther, MonthGrossProfitOutsideCompRate, textBox54, MonthGrossProfitOtherCompRate});

            List<TextBox> SecFt_monthList = new List<TextBox>();
            SecFt_monthList.AddRange(new TextBox[] { SecFt_monthTotalTitle, SecFt_MonthSalesMoneyOrder, SecFt_MonthSalesMoneyStock, SecFt_MonthSalesMoneyOrderCompRate, textBox106, SecFt_MonthSalesMoneyStockCompRate, SecFt_MonthSalesMoneyGenuine, SecFt_MonthSalesMoneyPrm, SecFt_MonthSalesMoneyGenuineCompRate, textBox103, SecFt_MonthSalesMoneyPrmCompRate, SecFt_MonthSalesMoneyOutside, SecFt_MonthSalesMoneyOther, SecFt_MonthSalesMoneyOutsideCompRate, textBox100, SecFt_MonthSalesMoneyOtherCompRate,
                                             SecFt_MonthGrossProfitOrder, SecFt_MonthGrossProfitStock, SecFt_MonthGrossProfitOrderCompRate, textBox122, SecFt_MonthGrossProfitStockCompRate, SecFt_MonthGrossProfitGenuine, SecFt_MonthGrossProfitPrm, SecFt_MonthGrossProfitGenuineCompRate, textBox119, SecFt_MonthGrossProfitPrmCompRate, SecFt_MonthGrossProfitOutside, SecFt_MonthGrossProfitOther, SecFt_MonthGrossProfitOutsideCompRate, textBox116, SecFt_MonthGrossProfitOtherCompRate});

            List<TextBox> GraFt_monthList = new List<TextBox>();
            GraFt_monthList.AddRange(new TextBox[] { GraFt_monthTotalTitle, GraFt_MonthSalesMoneyOrder, GraFt_MonthSalesMoneyStock, GraFt_MonthSalesMoneyOrderCompRate, textBox168, GraFt_MonthSalesMoneyStockCompRate, GraFt_MonthSalesMoneyGenuine, GraFt_MonthSalesMoneyPrm, GraFt_MonthSalesMoneyGenuineCompRate, textBox165, GraFt_MonthSalesMoneyPrmCompRate, GraFt_MonthSalesMoneyOutside, GraFt_MonthSalesMoneyOther, GraFt_MonthSalesMoneyOutsideCompRate, textBox162, GraFt_MonthSalesMoneyOtherCompRate,
                                             GraFt_MonthGrossProfitOrder, GraFt_MonthGrossProfitStock, GraFt_MonthGrossProfitOrderCompRate, textBox184, GraFt_MonthGrossProfitStockCompRate, GraFt_MonthGrossProfitGenuine, GraFt_MonthGrossProfitPrm, GraFt_MonthGrossProfitGenuineCompRate, textBox181, GraFt_MonthGrossProfitPrmCompRate, GraFt_MonthGrossProfitOutside, GraFt_MonthGrossProfitOther, GraFt_MonthGrossProfitOutsideCompRate, textBox178, GraFt_MonthGrossProfitOtherCompRate});
            #endregion

            // visible設定
            if (this._salesHistAnalyzeCndtn.MonthReportDiv == SalesHistAnalyzeCndtn.MonthReportDivState.None)
            {
                // 累計印刷しない　→　全ての下段を非印字にする
                for (int index = 0; index < monthList.Count; index++)
                {
                    // 数量非印字
                    monthList[index].Visible = false;
                    SecFt_monthList[index].Visible = false;
                    GraFt_monthList[index].Visible = false;
                }

                // --- ADD 2008/11/25 -------------------------------->>>>>
                // 罫線の高さを変更
                this.DetaliLine1.Y2 = 0.42F;
                this.DetaliLine2.Y2 = 0.42F;
                this.SecFt_Line1.Y2 = 0.42F;
                this.SecFt_Line2.Y2 = 0.42F;
                this.GraFt_Line1.Y2 = 0.42F;
                this.GraFt_Line2.Y2 = 0.42F;
                // --- ADD 2008/11/25 --------------------------------<<<<<
            }
            else
            {
            }
            #endregion

            //-------------------------------------------------------
            // TitleHeader設定
            //-------------------------------------------------------
            #region [TitleHeader設定]
            if (_salesHistAnalyzeCndtn.PrintDiv == SalesHistAnalyzeCndtn.PrintDivState.Customer)
            {
                this.Lb_Title.Text = "得意先";
            }
            else if (_salesHistAnalyzeCndtn.PrintDiv == SalesHistAnalyzeCndtn.PrintDivState.Employee)
            {
                this.Lb_Title.Text = "担当者";
            }
            else // 地区
            {
                this.Lb_Title.Text = "地区";
            }
            #endregion

            //-------------------------------------------------------
            // 改頁設定
            // 0:する（拠点毎） 1:しない
            //-------------------------------------------------------
            #region [改頁設定]
            if (_salesHistAnalyzeCndtn.NewPageDiv == SalesHistAnalyzeCndtn.NewPageDivState.Section)
            {
                SectionHeader.NewPage = NewPage.Before;
            }

            #endregion

            //-------------------------------------------------------
            // 明細設定
            //-------------------------------------------------------
            #region [明細設定]
            if (_salesHistAnalyzeCndtn.PrintDiv == SalesHistAnalyzeCndtn.PrintDivState.Customer)
            {
                this.Code.DataField = "CustomerCode";
                this.Code.OutputFormat = "00000000";

                this.CodeName.DataField = "CustomerSnm";
            }
            else if (_salesHistAnalyzeCndtn.PrintDiv == SalesHistAnalyzeCndtn.PrintDivState.Employee)
            {
                this.Code.DataField = "SalesEmployeeCd";
                this.Code.OutputFormat = "0000";

                this.CodeName.DataField = "SalesEmployeeNm";
            }
            else if (_salesHistAnalyzeCndtn.PrintDiv == SalesHistAnalyzeCndtn.PrintDivState.SalesArea)
            {
                this.Code.DataField = "SalesAreaCode";
                this.Code.OutputFormat = "0000";

                this.CodeName.DataField = "SalesAreaName";
            }
            #endregion
        }

        /// <summary>
        /// 率項目計算処理
        /// </summary>
        /// <param name="numeratorBox">分子</param>
        /// <param name="denominatorBox">分母</param>
        private double GetRatio(TextBox numeratorBox, TextBox denominatorBox)
        {
            double numerator = Convert.ToDouble(numeratorBox.Text);
            double denominator = Convert.ToDouble(numeratorBox.Text) + Convert.ToDouble(denominatorBox.Text);

            double ratio = this.GetRatio(numerator, denominator);

            return ratio;
        }

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(double numerator, double denominator)
        {
            double workRate;

            if (denominator == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            //if (workRate < 0) workRate = workRate * -1; // DEL 2009/01/19

            return workRate;
        }

        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMHNB02163P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02163P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.tb_PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// ExtraHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 抽出条件設定
            // ヘッダ出力制御
            if (this._extraCondHeadOutDiv == 0)
            {
                // 毎ページ出力
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                // 先頭ページのみ
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }

            // インスタンスが作成されていなければ作成
            if (this._rptExtraHeader == null)
            {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else
            {
                // インスタンスが作成されていれば、データソースを初期化する
                // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                this._rptExtraHeader.DataSource = null;
            }

            // 抽出条件印字項目設定
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
        }

        /// <summary>
        /// SectionHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_BeforePrint(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SecHd_SectionCode.Text)
                || this.SecHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SecHd_SectionCode.Text = "";
                this.SecHd_SectionGuideNm.Text = "";
            }
        }

        /// <summary>
        /// detail_AfterPrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        private void detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }

        }

        /// <summary>
        /// detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // コード値が0の場合、表示しない
            if (string.IsNullOrEmpty(this.Code.Text)
                 || Convert.ToInt32(this.Code.Text) == 0)
            {
                // --- DEL 2008/11/25 -------------------------------->>>>>
                //this.Code.Text = string.Empty;
                //this.CodeName.Text = string.Empty;
                // --- DEL 2008/11/25 --------------------------------<<<<<
                // --- ADD 2008/11/25 -------------------------------->>>>>
                if (this._salesHistAnalyzeCndtn.PrintDiv != SalesHistAnalyzeCndtn.PrintDivState.SalesArea)
                {
                    this.Code.Text = string.Empty;
                    this.CodeName.Text = string.Empty;
                }
                else
                {
                    // コード値はそのまま表示、名称に"未登録"を印字
                    this.CodeName.Text = "未登録";
                }
                // --- ADD 2008/11/25 --------------------------------<<<<<
            }

            // 率計算
            // 売上金額（日計取寄）
            this.SalesMoneyOrderCompRate.Value = this.GetRatio(this.SalesMoneyOrder, this.SalesMoneyStock);
            this.SalesMoneyOrderCompRate.Text = this.SalesMoneyOrderCompRate.Text + "%";
            // 売上金額（日計在庫）
            this.SalesMoneyStockCompRate.Value = this.GetRatio(this.SalesMoneyStock, this.SalesMoneyOrder);
            this.SalesMoneyStockCompRate.Text = this.SalesMoneyStockCompRate.Text + "%";
            // 売上金額（日計純正）
            this.SalesMoneyGenuineCompRate.Value = this.GetRatio(this.SalesMoneyGenuine, this.SalesMoneyPrm);
            this.SalesMoneyGenuineCompRate.Text = this.SalesMoneyGenuineCompRate.Text + "%";
            // 売上金額（日計優良）
            this.SalesMoneyPrmCompRate.Value = this.GetRatio(this.SalesMoneyPrm, this.SalesMoneyGenuine);
            this.SalesMoneyPrmCompRate.Text = this.SalesMoneyPrmCompRate.Text + "%";
            // 売上金額（日計外装）
            this.SalesMoneyOutsideCompRate.Value = this.GetRatio(this.SalesMoneyOutside, this.SalesMoneyOther);
            this.SalesMoneyOutsideCompRate.Text = this.SalesMoneyOutsideCompRate.Text + "%";
            // 売上金額（日計その他）
            this.SalesMoneyOtherCompRate.Value = this.GetRatio(this.SalesMoneyOther, this.SalesMoneyOutside);
            this.SalesMoneyOtherCompRate.Text = this.SalesMoneyOtherCompRate.Text + "%";

            // 粗利金額（日計取寄）
            this.GrossProfitOrderCompRate.Value = this.GetRatio(this.GrossProfitOrder, this.GrossProfitStock);
            this.GrossProfitOrderCompRate.Text = this.GrossProfitOrderCompRate.Text + "%";
            // 粗利金額（日計在庫）
            this.GrossProfitStockCompRate.Value = this.GetRatio(this.GrossProfitStock, this.GrossProfitOrder);
            this.GrossProfitStockCompRate.Text = this.GrossProfitStockCompRate.Text + "%";
            // 粗利金額（日計純正）
            this.GrossProfitGenuineCompRate.Value = this.GetRatio(this.GrossProfitGenuine, this.GrossProfitPrm);
            this.GrossProfitGenuineCompRate.Text = this.GrossProfitGenuineCompRate.Text + "%";
            // 粗利金額（日計優良）
            this.GrossProfitPrmCompRate.Value = this.GetRatio(this.GrossProfitPrm, this.GrossProfitGenuine);
            this.GrossProfitPrmCompRate.Text = this.GrossProfitPrmCompRate.Text + "%";
            // 粗利金額（日計外装）
            this.GrossProfitOutsideCompRate.Value = this.GetRatio(this.GrossProfitOutside, this.GrossProfitOther);
            this.GrossProfitOutsideCompRate.Text = this.GrossProfitOutsideCompRate.Text + "%";
            // 粗利金額（日計その他）
            this.GrossProfitOtherCompRate.Value = this.GetRatio(this.GrossProfitOther, this.GrossProfitOutside);
            this.GrossProfitOtherCompRate.Text = this.GrossProfitOtherCompRate.Text + "%";

            // 売上金額（累計取寄）
            this.MonthSalesMoneyOrderCompRate.Value = this.GetRatio(this.MonthSalesMoneyOrder, this.MonthSalesMoneyStock);
            this.MonthSalesMoneyOrderCompRate.Text = this.MonthSalesMoneyOrderCompRate.Text + "%";
            // 売上金額（累計在庫）
            this.MonthSalesMoneyStockCompRate.Value = this.GetRatio(this.MonthSalesMoneyStock, this.MonthSalesMoneyOrder);
            this.MonthSalesMoneyStockCompRate.Text = this.MonthSalesMoneyStockCompRate.Text + "%";
            // 売上金額（累計純正）
            this.MonthSalesMoneyGenuineCompRate.Value = this.GetRatio(this.MonthSalesMoneyGenuine, this.MonthSalesMoneyPrm);
            this.MonthSalesMoneyGenuineCompRate.Text = this.MonthSalesMoneyGenuineCompRate.Text + "%";
            // 売上金額（累計優良）
            this.MonthSalesMoneyPrmCompRate.Value = this.GetRatio(this.MonthSalesMoneyPrm, this.MonthSalesMoneyGenuine);
            this.MonthSalesMoneyPrmCompRate.Text = this.MonthSalesMoneyPrmCompRate.Text + "%";
            // 売上金額（累計外装）
            this.MonthSalesMoneyOutsideCompRate.Value = this.GetRatio(this.MonthSalesMoneyOutside, this.MonthSalesMoneyOther);
            this.MonthSalesMoneyOutsideCompRate.Text = this.MonthSalesMoneyOutsideCompRate.Text + "%";
            // 売上金額（累計その他）
            this.MonthSalesMoneyOtherCompRate.Value = this.GetRatio(this.MonthSalesMoneyOther, this.MonthSalesMoneyOutside);
            this.MonthSalesMoneyOtherCompRate.Text = this.MonthSalesMoneyOtherCompRate.Text + "%";

            // 粗利金額（累計取寄）
            this.MonthGrossProfitOrderCompRate.Value = this.GetRatio(this.MonthGrossProfitOrder, this.MonthGrossProfitStock);
            this.MonthGrossProfitOrderCompRate.Text = this.MonthGrossProfitOrderCompRate.Text + "%";
            // 粗利金額（累計在庫）
            this.MonthGrossProfitStockCompRate.Value = this.GetRatio(this.MonthGrossProfitStock, this.MonthGrossProfitOrder);
            this.MonthGrossProfitStockCompRate.Text = this.MonthGrossProfitStockCompRate.Text + "%";
            // 粗利金額（累計純正）
            this.MonthGrossProfitGenuineCompRate.Value = this.GetRatio(this.MonthGrossProfitGenuine, this.MonthGrossProfitPrm);
            this.MonthGrossProfitGenuineCompRate.Text = this.MonthGrossProfitGenuineCompRate.Text + "%";
            // 粗利金額（累計優良）
            this.MonthGrossProfitPrmCompRate.Value = this.GetRatio(this.MonthGrossProfitPrm, this.MonthGrossProfitGenuine);
            this.MonthGrossProfitPrmCompRate.Text = this.MonthGrossProfitPrmCompRate.Text + "%";
            // 粗利金額（累計外装）
            this.MonthGrossProfitOutsideCompRate.Value = this.GetRatio(this.MonthGrossProfitOutside, this.MonthGrossProfitOther);
            this.MonthGrossProfitOutsideCompRate.Text = this.MonthGrossProfitOutsideCompRate.Text + "%";
            // 粗利金額（累計その他）
            this.MonthGrossProfitOtherCompRate.Value = this.GetRatio(this.MonthGrossProfitOther, this.MonthGrossProfitOutside);
            this.MonthGrossProfitOtherCompRate.Text = this.MonthGrossProfitOtherCompRate.Text + "%";
        }

        /// <summary>
        /// SectionFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 率計算
            // 売上金額（日計取寄）
            this.SecFt_SalesMoneyOrderCompRate.Value = this.GetRatio(this.SecFt_SalesMoneyOrder, this.SecFt_SalesMoneyStock);
            this.SecFt_SalesMoneyOrderCompRate.Text = this.SecFt_SalesMoneyOrderCompRate.Text + "%";
            // 売上金額（日計在庫）
            this.SecFt_SalesMoneyStockCompRate.Value = this.GetRatio(this.SecFt_SalesMoneyStock, this.SecFt_SalesMoneyOrder);
            this.SecFt_SalesMoneyStockCompRate.Text = this.SecFt_SalesMoneyStockCompRate.Text + "%";
            // 売上金額（日計純正）
            this.SecFt_SalesMoneyGenuineCompRate.Value = this.GetRatio(this.SecFt_SalesMoneyGenuine, this.SecFt_SalesMoneyPrm);
            this.SecFt_SalesMoneyGenuineCompRate.Text = this.SecFt_SalesMoneyGenuineCompRate.Text + "%";
            // 売上金額（日計優良）
            this.SecFt_SalesMoneyPrmCompRate.Value = this.GetRatio(this.SecFt_SalesMoneyPrm, this.SecFt_SalesMoneyGenuine);
            this.SecFt_SalesMoneyPrmCompRate.Text = this.SecFt_SalesMoneyPrmCompRate.Text + "%";
            // 売上金額（日計外装）
            this.SecFt_SalesMoneyOutsideCompRate.Value = this.GetRatio(this.SecFt_SalesMoneyOutside, this.SecFt_SalesMoneyOther);
            this.SecFt_SalesMoneyOutsideCompRate.Text = this.SecFt_SalesMoneyOutsideCompRate.Text + "%";
            // 売上金額（日計その他）
            this.SecFt_SalesMoneyOtherCompRate.Value = this.GetRatio(this.SecFt_SalesMoneyOther, this.SecFt_SalesMoneyOutside);
            this.SecFt_SalesMoneyOtherCompRate.Text = this.SecFt_SalesMoneyOtherCompRate.Text + "%";

            // 粗利金額（日計取寄）
            this.SecFt_GrossProfitOrderCompRate.Value = this.GetRatio(this.SecFt_GrossProfitOrder, this.SecFt_GrossProfitStock);
            this.SecFt_GrossProfitOrderCompRate.Text = this.SecFt_GrossProfitOrderCompRate.Text + "%";
            // 粗利金額（日計在庫）
            this.SecFt_GrossProfitStockCompRate.Value = this.GetRatio(this.SecFt_GrossProfitStock, this.SecFt_GrossProfitOrder);
            this.SecFt_GrossProfitStockCompRate.Text = this.SecFt_GrossProfitStockCompRate.Text + "%";
            // 粗利金額（日計純正）
            this.SecFt_GrossProfitGenuineCompRate.Value = this.GetRatio(this.SecFt_GrossProfitGenuine, this.SecFt_GrossProfitPrm);
            this.SecFt_GrossProfitGenuineCompRate.Text = this.SecFt_GrossProfitGenuineCompRate.Text + "%";
            // 粗利金額（日計優良）
            this.SecFt_GrossProfitPrmCompRate.Value = this.GetRatio(this.SecFt_GrossProfitPrm, this.SecFt_GrossProfitGenuine);
            this.SecFt_GrossProfitPrmCompRate.Text = this.SecFt_GrossProfitPrmCompRate.Text + "%";
            // 粗利金額（日計外装）
            this.SecFt_GrossProfitOutsideCompRate.Value = this.GetRatio(this.SecFt_GrossProfitOutside, this.SecFt_GrossProfitOther);
            this.SecFt_GrossProfitOutsideCompRate.Text = this.SecFt_GrossProfitOutsideCompRate.Text + "%";
            // 粗利金額（日計その他）
            this.SecFt_GrossProfitOtherCompRate.Value = this.GetRatio(this.SecFt_GrossProfitOther, this.SecFt_GrossProfitOutside);
            this.SecFt_GrossProfitOtherCompRate.Text = this.SecFt_GrossProfitOtherCompRate.Text + "%";

            // 売上金額（累計取寄）
            this.SecFt_MonthSalesMoneyOrderCompRate.Value = this.GetRatio(this.SecFt_MonthSalesMoneyOrder, this.SecFt_MonthSalesMoneyStock);
            this.SecFt_MonthSalesMoneyOrderCompRate.Text = this.SecFt_MonthSalesMoneyOrderCompRate.Text + "%";
            // 売上金額（累計在庫）
            this.SecFt_MonthSalesMoneyStockCompRate.Value = this.GetRatio(this.SecFt_MonthSalesMoneyStock, this.SecFt_MonthSalesMoneyOrder);
            this.SecFt_MonthSalesMoneyStockCompRate.Text = this.SecFt_MonthSalesMoneyStockCompRate.Text + "%";
            // 売上金額（累計純正）
            this.SecFt_MonthSalesMoneyGenuineCompRate.Value = this.GetRatio(this.SecFt_MonthSalesMoneyGenuine, this.SecFt_MonthSalesMoneyPrm);
            this.SecFt_MonthSalesMoneyGenuineCompRate.Text = this.SecFt_MonthSalesMoneyGenuineCompRate.Text + "%";
            // 売上金額（累計優良）
            this.SecFt_MonthSalesMoneyPrmCompRate.Value = this.GetRatio(this.SecFt_MonthSalesMoneyPrm, this.SecFt_MonthSalesMoneyGenuine);
            this.SecFt_MonthSalesMoneyPrmCompRate.Text = this.SecFt_MonthSalesMoneyPrmCompRate.Text + "%";
            // 売上金額（累計外装）
            this.SecFt_MonthSalesMoneyOutsideCompRate.Value = this.GetRatio(this.SecFt_MonthSalesMoneyOutside, this.SecFt_MonthSalesMoneyOther);
            this.SecFt_MonthSalesMoneyOutsideCompRate.Text = this.SecFt_MonthSalesMoneyOutsideCompRate.Text + "%";
            // 売上金額（累計その他）
            this.SecFt_MonthSalesMoneyOtherCompRate.Value = this.GetRatio(this.SecFt_MonthSalesMoneyOther, this.SecFt_MonthSalesMoneyOutside);
            this.SecFt_MonthSalesMoneyOtherCompRate.Text = this.SecFt_MonthSalesMoneyOtherCompRate.Text + "%";

            // 粗利金額（累計取寄）
            this.SecFt_MonthGrossProfitOrderCompRate.Value = this.GetRatio(this.SecFt_MonthGrossProfitOrder, this.SecFt_MonthGrossProfitStock);
            this.SecFt_MonthGrossProfitOrderCompRate.Text = this.SecFt_MonthGrossProfitOrderCompRate.Text + "%";
            // 粗利金額（累計在庫）
            this.SecFt_MonthGrossProfitStockCompRate.Value = this.GetRatio(this.SecFt_MonthGrossProfitStock, this.SecFt_MonthGrossProfitOrder);
            this.SecFt_MonthGrossProfitStockCompRate.Text = this.SecFt_MonthGrossProfitStockCompRate.Text + "%";
            // 粗利金額（累計純正）
            this.SecFt_MonthGrossProfitGenuineCompRate.Value = this.GetRatio(this.SecFt_MonthGrossProfitGenuine, this.SecFt_MonthGrossProfitPrm);
            this.SecFt_MonthGrossProfitGenuineCompRate.Text = this.SecFt_MonthGrossProfitGenuineCompRate.Text + "%";
            // 粗利金額（累計優良）
            this.SecFt_MonthGrossProfitPrmCompRate.Value = this.GetRatio(this.SecFt_MonthGrossProfitPrm, this.SecFt_MonthGrossProfitGenuine);
            this.SecFt_MonthGrossProfitPrmCompRate.Text = this.SecFt_MonthGrossProfitPrmCompRate.Text + "%";
            // 粗利金額（累計外装）
            this.SecFt_MonthGrossProfitOutsideCompRate.Value = this.GetRatio(this.SecFt_MonthGrossProfitOutside, this.SecFt_MonthGrossProfitOther);
            this.SecFt_MonthGrossProfitOutsideCompRate.Text = this.SecFt_MonthGrossProfitOutsideCompRate.Text + "%";
            // 粗利金額（累計その他）
            this.SecFt_MonthGrossProfitOtherCompRate.Value = this.GetRatio(this.SecFt_MonthGrossProfitOther, this.SecFt_MonthGrossProfitOutside);
            this.SecFt_MonthGrossProfitOtherCompRate.Text = this.SecFt_MonthGrossProfitOtherCompRate.Text + "%";
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 率計算
            // 売上金額（日計取寄）
            this.GraFt_SalesMoneyOrderCompRate.Value = this.GetRatio(this.GraFt_SalesMoneyOrder, this.GraFt_SalesMoneyStock);
            this.GraFt_SalesMoneyOrderCompRate.Text = this.GraFt_SalesMoneyOrderCompRate.Text + "%";
            // 売上金額（日計在庫）
            this.GraFt_SalesMoneyStockCompRate.Value = this.GetRatio(this.GraFt_SalesMoneyStock, this.GraFt_SalesMoneyOrder);
            this.GraFt_SalesMoneyStockCompRate.Text = this.GraFt_SalesMoneyStockCompRate.Text + "%";
            // 売上金額（日計純正）
            this.GraFt_SalesMoneyGenuineCompRate.Value = this.GetRatio(this.GraFt_SalesMoneyGenuine, this.GraFt_SalesMoneyPrm);
            this.GraFt_SalesMoneyGenuineCompRate.Text = this.GraFt_SalesMoneyGenuineCompRate.Text + "%";
            // 売上金額（日計優良）
            this.GraFt_SalesMoneyPrmCompRate.Value = this.GetRatio(this.GraFt_SalesMoneyPrm, this.GraFt_SalesMoneyGenuine);
            this.GraFt_SalesMoneyPrmCompRate.Text = this.GraFt_SalesMoneyPrmCompRate.Text + "%";
            // 売上金額（日計外装）
            this.GraFt_SalesMoneyOutsideCompRate.Value = this.GetRatio(this.GraFt_SalesMoneyOutside, this.GraFt_SalesMoneyOther);
            this.GraFt_SalesMoneyOutsideCompRate.Text = this.GraFt_SalesMoneyOutsideCompRate.Text + "%";
            // 売上金額（日計その他）
            this.GraFt_SalesMoneyOtherCompRate.Value = this.GetRatio(this.GraFt_SalesMoneyOther, this.GraFt_SalesMoneyOutside);
            this.GraFt_SalesMoneyOtherCompRate.Text = this.GraFt_SalesMoneyOtherCompRate.Text + "%";

            // 粗利金額（日計取寄）
            this.GraFt_GrossProfitOrderCompRate.Value = this.GetRatio(this.GraFt_GrossProfitOrder, this.GraFt_GrossProfitStock);
            this.GraFt_GrossProfitOrderCompRate.Text = this.GraFt_GrossProfitOrderCompRate.Text + "%";
            // 粗利金額（日計在庫）
            this.GraFt_GrossProfitStockCompRate.Value = this.GetRatio(this.GraFt_GrossProfitStock, this.GraFt_GrossProfitOrder);
            this.GraFt_GrossProfitStockCompRate.Text = this.GraFt_GrossProfitStockCompRate.Text + "%";
            // 粗利金額（日計純正）
            this.GraFt_GrossProfitGenuineCompRate.Value = this.GetRatio(this.GraFt_GrossProfitGenuine, this.GraFt_GrossProfitPrm);
            this.GraFt_GrossProfitGenuineCompRate.Text = this.GraFt_GrossProfitGenuineCompRate.Text + "%";
            // 粗利金額（日計優良）
            this.GraFt_GrossProfitPrmCompRate.Value = this.GetRatio(this.GraFt_GrossProfitPrm, this.GraFt_GrossProfitGenuine);
            this.GraFt_GrossProfitPrmCompRate.Text = this.GraFt_GrossProfitPrmCompRate.Text + "%";
            // 粗利金額（日計外装）
            this.GraFt_GrossProfitOutsideCompRate.Value = this.GetRatio(this.GraFt_GrossProfitOutside, this.GraFt_GrossProfitOther);
            this.GraFt_GrossProfitOutsideCompRate.Text = this.GraFt_GrossProfitOutsideCompRate.Text + "%";
            // 粗利金額（日計その他）
            this.GraFt_GrossProfitOtherCompRate.Value = this.GetRatio(this.GraFt_GrossProfitOther, this.GraFt_GrossProfitOutside);
            this.GraFt_GrossProfitOtherCompRate.Text = this.GraFt_GrossProfitOtherCompRate.Text + "%";

            // 売上金額（累計取寄）
            this.GraFt_MonthSalesMoneyOrderCompRate.Value = this.GetRatio(this.GraFt_MonthSalesMoneyOrder, this.GraFt_MonthSalesMoneyStock);
            this.GraFt_MonthSalesMoneyOrderCompRate.Text = this.GraFt_MonthSalesMoneyOrderCompRate.Text + "%";
            // 売上金額（累計在庫）
            this.GraFt_MonthSalesMoneyStockCompRate.Value = this.GetRatio(this.GraFt_MonthSalesMoneyStock, this.GraFt_MonthSalesMoneyOrder);
            this.GraFt_MonthSalesMoneyStockCompRate.Text = this.GraFt_MonthSalesMoneyStockCompRate.Text + "%";
            // 売上金額（累計純正）
            this.GraFt_MonthSalesMoneyGenuineCompRate.Value = this.GetRatio(this.GraFt_MonthSalesMoneyGenuine, this.GraFt_MonthSalesMoneyPrm);
            this.GraFt_MonthSalesMoneyGenuineCompRate.Text = this.GraFt_MonthSalesMoneyGenuineCompRate.Text + "%";
            // 売上金額（累計優良）
            this.GraFt_MonthSalesMoneyPrmCompRate.Value = this.GetRatio(this.GraFt_MonthSalesMoneyPrm, this.GraFt_MonthSalesMoneyGenuine);
            this.GraFt_MonthSalesMoneyPrmCompRate.Text = this.GraFt_MonthSalesMoneyPrmCompRate.Text + "%";
            // 売上金額（累計外装）
            this.GraFt_MonthSalesMoneyOutsideCompRate.Value = this.GetRatio(this.GraFt_MonthSalesMoneyOutside, this.GraFt_MonthSalesMoneyOther);
            this.GraFt_MonthSalesMoneyOutsideCompRate.Text = this.GraFt_MonthSalesMoneyOutsideCompRate.Text + "%";
            // 売上金額（累計その他）
            this.GraFt_MonthSalesMoneyOtherCompRate.Value = this.GetRatio(this.GraFt_MonthSalesMoneyOther, this.GraFt_MonthSalesMoneyOutside);
            this.GraFt_MonthSalesMoneyOtherCompRate.Text = this.GraFt_MonthSalesMoneyOtherCompRate.Text + "%";

            // 粗利金額（累計取寄）
            this.GraFt_MonthGrossProfitOrderCompRate.Value = this.GetRatio(this.GraFt_MonthGrossProfitOrder, this.GraFt_MonthGrossProfitStock);
            this.GraFt_MonthGrossProfitOrderCompRate.Text = this.GraFt_MonthGrossProfitOrderCompRate.Text + "%";
            // 粗利金額（累計在庫）
            this.GraFt_MonthGrossProfitStockCompRate.Value = this.GetRatio(this.GraFt_MonthGrossProfitStock, this.GraFt_MonthGrossProfitOrder);
            this.GraFt_MonthGrossProfitStockCompRate.Text = this.GraFt_MonthGrossProfitStockCompRate.Text + "%";
            // 粗利金額（累計純正）
            this.GraFt_MonthGrossProfitGenuineCompRate.Value = this.GetRatio(this.GraFt_MonthGrossProfitGenuine, this.GraFt_MonthGrossProfitPrm);
            this.GraFt_MonthGrossProfitGenuineCompRate.Text = this.GraFt_MonthGrossProfitGenuineCompRate.Text + "%";
            // 粗利金額（累計優良）
            this.GraFt_MonthGrossProfitPrmCompRate.Value = this.GetRatio(this.GraFt_MonthGrossProfitPrm, this.GraFt_MonthGrossProfitGenuine);
            this.GraFt_MonthGrossProfitPrmCompRate.Text = this.GraFt_MonthGrossProfitPrmCompRate.Text + "%";
            // 粗利金額（累計外装）
            this.GraFt_MonthGrossProfitOutsideCompRate.Value = this.GetRatio(this.GraFt_MonthGrossProfitOutside, this.GraFt_MonthGrossProfitOther);
            this.GraFt_MonthGrossProfitOutsideCompRate.Text = this.GraFt_MonthGrossProfitOutsideCompRate.Text + "%";
            // 粗利金額（累計その他）
            this.GraFt_MonthGrossProfitOtherCompRate.Value = this.GetRatio(this.GraFt_MonthGrossProfitOther, this.GraFt_MonthGrossProfitOutside);
            this.GraFt_MonthGrossProfitOtherCompRate.Text = this.GraFt_MonthGrossProfitOtherCompRate.Text + "%";
        }

        /// <summary>
        /// ページフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.03.17</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッターレポート作成
                ListCommon_PageFooter rpt = new ListCommon_PageFooter();

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    rpt.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    rpt.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = rpt;
            }
        }
        #endregion

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMHNB02163P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.SalesMoneyOther = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOutside = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyPrm = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyGenuine = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.CodeName = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.dayTotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.Code = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOther = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOutside = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitPrm = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitGenuine = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitStock = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOther = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOutside = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyPrm = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyGenuine = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.monthTotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitOther = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitOutside = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitPrm = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitGenuine = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitStock = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox54 = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox57 = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.DetaliLine1 = new DataDynamics.ActiveReports.Line();
            this.DetaliLine2 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SecFt_SalesMoneyOther = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyOutside = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyPrm = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyGenuine = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesMoneyOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_dayTotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitOther = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitOutside = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitPrm = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitGenuine = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitStock = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox85 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox88 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox91 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyOther = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyOutside = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyPrm = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyGenuine = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox100 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox103 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthSalesMoneyOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox106 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_monthTotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOther = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOutside = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitPrm = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitGenuine = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitStock = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox116 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox119 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_MonthGrossProfitOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox122 = new DataDynamics.ActiveReports.TextBox();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SecFt_Line1 = new DataDynamics.ActiveReports.Line();
            this.SecFt_Line2 = new DataDynamics.ActiveReports.Line();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_Title = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GraFt_SalesMoneyOther = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyOutside = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyPrm = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyGenuine = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox131 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox134 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesMoneyOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox137 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_dayTotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitOther = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitOutside = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitPrm = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitGenuine = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitStock = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox147 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox150 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox153 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyOther = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyOutside = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyPrm = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyGenuine = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox162 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox165 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthSalesMoneyOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox168 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_monthTotalTitle = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitOther = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitOtherCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitOutsideCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitOutside = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitPrm = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitGenuine = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitStock = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox178 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitPrmCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitGenuineCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox181 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitStockCompRate = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_MonthGrossProfitOrderCompRate = new DataDynamics.ActiveReports.TextBox();
            this.textBox184 = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.GraFt_Line1 = new DataDynamics.ActiveReports.Line();
            this.GraFt_Line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_dayTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_monthTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox131)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox134)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_dayTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox147)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox153)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox162)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox165)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox168)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_monthTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOtherCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOutsideCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOutside)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitPrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitGenuine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox178)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitPrmCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitGenuineCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox181)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitStockCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOrderCompRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox184)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line1,
            this.tb_ReportTitle,
            this.Label3,
            this.tb_PrintDate,
            this.tb_PrintTime,
            this.Label2,
            this.tb_PrintPage});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.21F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.21F;
            this.Line1.Y2 = 0.21F;
            // 
            // tb_ReportTitle
            // 
            this.tb_ReportTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.219F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "売上内容分析表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.938F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.063F;
            this.Label3.Width = 0.625F;
            // 
            // tb_PrintDate
            // 
            this.tb_PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.CanShrink = true;
            this.tb_PrintDate.Height = 0.15625F;
            this.tb_PrintDate.Left = 8.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.063F;
            this.tb_PrintDate.Width = 0.9375F;
            // 
            // tb_PrintTime
            // 
            this.tb_PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Height = 0.125F;
            this.tb_PrintTime.Left = 9.438F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.063F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.938F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.063F;
            this.Label2.Width = 0.5F;
            // 
            // tb_PrintPage
            // 
            this.tb_PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.CanShrink = true;
            this.tb_PrintPage.Height = 0.15625F;
            this.tb_PrintPage.Left = 10.438F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.063F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SalesMoneyOther,
            this.SalesMoneyOtherCompRate,
            this.SalesMoneyOutsideCompRate,
            this.SalesMoneyOutside,
            this.SalesMoneyPrm,
            this.SalesMoneyGenuine,
            this.SalesMoneyStock,
            this.SalesMoneyOrder,
            this.CodeName,
            this.textBox11,
            this.SalesMoneyPrmCompRate,
            this.SalesMoneyGenuineCompRate,
            this.textBox8,
            this.SalesMoneyStockCompRate,
            this.SalesMoneyOrderCompRate,
            this.textBox13,
            this.dayTotalTitle,
            this.Code,
            this.GrossProfitOther,
            this.GrossProfitOtherCompRate,
            this.GrossProfitOutsideCompRate,
            this.GrossProfitOutside,
            this.GrossProfitPrm,
            this.GrossProfitGenuine,
            this.GrossProfitStock,
            this.GrossProfitOrder,
            this.textBox23,
            this.GrossProfitPrmCompRate,
            this.GrossProfitGenuineCompRate,
            this.textBox26,
            this.GrossProfitStockCompRate,
            this.GrossProfitOrderCompRate,
            this.textBox29,
            this.MonthSalesMoneyOther,
            this.MonthSalesMoneyOtherCompRate,
            this.MonthSalesMoneyOutsideCompRate,
            this.MonthSalesMoneyOutside,
            this.MonthSalesMoneyPrm,
            this.MonthSalesMoneyGenuine,
            this.MonthSalesMoneyStock,
            this.MonthSalesMoneyOrder,
            this.textBox38,
            this.MonthSalesMoneyPrmCompRate,
            this.MonthSalesMoneyGenuineCompRate,
            this.textBox41,
            this.MonthSalesMoneyStockCompRate,
            this.MonthSalesMoneyOrderCompRate,
            this.textBox44,
            this.monthTotalTitle,
            this.MonthGrossProfitOther,
            this.MonthGrossProfitOtherCompRate,
            this.MonthGrossProfitOutsideCompRate,
            this.MonthGrossProfitOutside,
            this.MonthGrossProfitPrm,
            this.MonthGrossProfitGenuine,
            this.MonthGrossProfitStock,
            this.MonthGrossProfitOrder,
            this.textBox54,
            this.MonthGrossProfitPrmCompRate,
            this.MonthGrossProfitGenuineCompRate,
            this.textBox57,
            this.MonthGrossProfitStockCompRate,
            this.MonthGrossProfitOrderCompRate,
            this.textBox60,
            this.line5,
            this.DetaliLine1,
            this.DetaliLine2});
            this.detail.Height = 0.875F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.AfterPrint += new System.EventHandler(this.detail_AfterPrint);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // SalesMoneyOther
            // 
            this.SalesMoneyOther.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOther.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOther.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOther.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOther.DataField = "SalesMoneyOther";
            this.SalesMoneyOther.Height = 0.156F;
            this.SalesMoneyOther.Left = 8.9375F;
            this.SalesMoneyOther.MultiLine = false;
            this.SalesMoneyOther.Name = "SalesMoneyOther";
            this.SalesMoneyOther.OutputFormat = resources.GetString("SalesMoneyOther.OutputFormat");
            this.SalesMoneyOther.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyOther.Text = "123,456,789";
            this.SalesMoneyOther.Top = 0.0625F;
            this.SalesMoneyOther.Width = 0.85F;
            // 
            // SalesMoneyOtherCompRate
            // 
            this.SalesMoneyOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOtherCompRate.Height = 0.156F;
            this.SalesMoneyOtherCompRate.Left = 10.3075F;
            this.SalesMoneyOtherCompRate.MultiLine = false;
            this.SalesMoneyOtherCompRate.Name = "SalesMoneyOtherCompRate";
            this.SalesMoneyOtherCompRate.OutputFormat = resources.GetString("SalesMoneyOtherCompRate.OutputFormat");
            this.SalesMoneyOtherCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyOtherCompRate.Text = "100.00%";
            this.SalesMoneyOtherCompRate.Top = 0.0625F;
            this.SalesMoneyOtherCompRate.Width = 0.42F;
            // 
            // SalesMoneyOutsideCompRate
            // 
            this.SalesMoneyOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutsideCompRate.Height = 0.156F;
            this.SalesMoneyOutsideCompRate.Left = 9.7875F;
            this.SalesMoneyOutsideCompRate.MultiLine = false;
            this.SalesMoneyOutsideCompRate.Name = "SalesMoneyOutsideCompRate";
            this.SalesMoneyOutsideCompRate.OutputFormat = resources.GetString("SalesMoneyOutsideCompRate.OutputFormat");
            this.SalesMoneyOutsideCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyOutsideCompRate.Text = "100.00%";
            this.SalesMoneyOutsideCompRate.Top = 0.0625F;
            this.SalesMoneyOutsideCompRate.Width = 0.42F;
            // 
            // SalesMoneyOutside
            // 
            this.SalesMoneyOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutside.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutside.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOutside.DataField = "SalesMoneyOutside";
            this.SalesMoneyOutside.Height = 0.156F;
            this.SalesMoneyOutside.Left = 8.0875F;
            this.SalesMoneyOutside.MultiLine = false;
            this.SalesMoneyOutside.Name = "SalesMoneyOutside";
            this.SalesMoneyOutside.OutputFormat = resources.GetString("SalesMoneyOutside.OutputFormat");
            this.SalesMoneyOutside.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyOutside.Text = "123,456,789";
            this.SalesMoneyOutside.Top = 0.0625F;
            this.SalesMoneyOutside.Width = 0.85F;
            // 
            // SalesMoneyPrm
            // 
            this.SalesMoneyPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrm.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrm.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrm.DataField = "SalesMoneyPrm";
            this.SalesMoneyPrm.Height = 0.156F;
            this.SalesMoneyPrm.Left = 6.23F;
            this.SalesMoneyPrm.MultiLine = false;
            this.SalesMoneyPrm.Name = "SalesMoneyPrm";
            this.SalesMoneyPrm.OutputFormat = resources.GetString("SalesMoneyPrm.OutputFormat");
            this.SalesMoneyPrm.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyPrm.Text = "123,456,789";
            this.SalesMoneyPrm.Top = 0.0625F;
            this.SalesMoneyPrm.Width = 0.85F;
            // 
            // SalesMoneyGenuine
            // 
            this.SalesMoneyGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuine.DataField = "SalesMoneyGenuine";
            this.SalesMoneyGenuine.Height = 0.156F;
            this.SalesMoneyGenuine.Left = 5.38F;
            this.SalesMoneyGenuine.MultiLine = false;
            this.SalesMoneyGenuine.Name = "SalesMoneyGenuine";
            this.SalesMoneyGenuine.OutputFormat = resources.GetString("SalesMoneyGenuine.OutputFormat");
            this.SalesMoneyGenuine.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyGenuine.Text = "123,456,789";
            this.SalesMoneyGenuine.Top = 0.0625F;
            this.SalesMoneyGenuine.Width = 0.85F;
            // 
            // SalesMoneyStock
            // 
            this.SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.DataField = "SalesMoneyStock";
            this.SalesMoneyStock.Height = 0.156F;
            this.SalesMoneyStock.Left = 3.5425F;
            this.SalesMoneyStock.MultiLine = false;
            this.SalesMoneyStock.Name = "SalesMoneyStock";
            this.SalesMoneyStock.OutputFormat = resources.GetString("SalesMoneyStock.OutputFormat");
            this.SalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyStock.Text = "123,456,789";
            this.SalesMoneyStock.Top = 0.0625F;
            this.SalesMoneyStock.Width = 0.85F;
            // 
            // SalesMoneyOrder
            // 
            this.SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.SalesMoneyOrder.Height = 0.156F;
            this.SalesMoneyOrder.Left = 2.6925F;
            this.SalesMoneyOrder.MultiLine = false;
            this.SalesMoneyOrder.Name = "SalesMoneyOrder";
            this.SalesMoneyOrder.OutputFormat = resources.GetString("SalesMoneyOrder.OutputFormat");
            this.SalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyOrder.Text = "123,456,789";
            this.SalesMoneyOrder.Top = 0.0625F;
            this.SalesMoneyOrder.Width = 0.85F;
            // 
            // CodeName
            // 
            this.CodeName.Border.BottomColor = System.Drawing.Color.Black;
            this.CodeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Border.LeftColor = System.Drawing.Color.Black;
            this.CodeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Border.RightColor = System.Drawing.Color.Black;
            this.CodeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Border.TopColor = System.Drawing.Color.Black;
            this.CodeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CodeName.Height = 0.156F;
            this.CodeName.Left = 0.5625F;
            this.CodeName.MultiLine = false;
            this.CodeName.Name = "CodeName";
            this.CodeName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CodeName.Text = "あいうえおかきくけこさしすせそ";
            this.CodeName.Top = 0.0625F;
            this.CodeName.Width = 1.7F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Height = 0.156F;
            this.textBox11.Left = 10.2075F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox11.Text = ":";
            this.textBox11.Top = 0.0625F;
            this.textBox11.Width = 0.1F;
            // 
            // SalesMoneyPrmCompRate
            // 
            this.SalesMoneyPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyPrmCompRate.Height = 0.156F;
            this.SalesMoneyPrmCompRate.Left = 7.6F;
            this.SalesMoneyPrmCompRate.MultiLine = false;
            this.SalesMoneyPrmCompRate.Name = "SalesMoneyPrmCompRate";
            this.SalesMoneyPrmCompRate.OutputFormat = resources.GetString("SalesMoneyPrmCompRate.OutputFormat");
            this.SalesMoneyPrmCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyPrmCompRate.Text = "100.00%";
            this.SalesMoneyPrmCompRate.Top = 0.0625F;
            this.SalesMoneyPrmCompRate.Width = 0.42F;
            // 
            // SalesMoneyGenuineCompRate
            // 
            this.SalesMoneyGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyGenuineCompRate.Height = 0.156F;
            this.SalesMoneyGenuineCompRate.Left = 7.08F;
            this.SalesMoneyGenuineCompRate.MultiLine = false;
            this.SalesMoneyGenuineCompRate.Name = "SalesMoneyGenuineCompRate";
            this.SalesMoneyGenuineCompRate.OutputFormat = resources.GetString("SalesMoneyGenuineCompRate.OutputFormat");
            this.SalesMoneyGenuineCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyGenuineCompRate.Text = "100.00%";
            this.SalesMoneyGenuineCompRate.Top = 0.0625F;
            this.SalesMoneyGenuineCompRate.Width = 0.42F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Height = 0.156F;
            this.textBox8.Left = 7.5F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.Text = ":";
            this.textBox8.Top = 0.0625F;
            this.textBox8.Width = 0.1F;
            // 
            // SalesMoneyStockCompRate
            // 
            this.SalesMoneyStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStockCompRate.Height = 0.156F;
            this.SalesMoneyStockCompRate.Left = 4.9125F;
            this.SalesMoneyStockCompRate.MultiLine = false;
            this.SalesMoneyStockCompRate.Name = "SalesMoneyStockCompRate";
            this.SalesMoneyStockCompRate.OutputFormat = resources.GetString("SalesMoneyStockCompRate.OutputFormat");
            this.SalesMoneyStockCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyStockCompRate.Text = "100.00%";
            this.SalesMoneyStockCompRate.Top = 0.0625F;
            this.SalesMoneyStockCompRate.Width = 0.42F;
            // 
            // SalesMoneyOrderCompRate
            // 
            this.SalesMoneyOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrderCompRate.Height = 0.156F;
            this.SalesMoneyOrderCompRate.Left = 4.3925F;
            this.SalesMoneyOrderCompRate.MultiLine = false;
            this.SalesMoneyOrderCompRate.Name = "SalesMoneyOrderCompRate";
            this.SalesMoneyOrderCompRate.OutputFormat = resources.GetString("SalesMoneyOrderCompRate.OutputFormat");
            this.SalesMoneyOrderCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyOrderCompRate.Text = "100.00%";
            this.SalesMoneyOrderCompRate.Top = 0.0625F;
            this.SalesMoneyOrderCompRate.Width = 0.42F;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightColor = System.Drawing.Color.Black;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopColor = System.Drawing.Color.Black;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Height = 0.156F;
            this.textBox13.Left = 4.8125F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.Text = ":";
            this.textBox13.Top = 0.0625F;
            this.textBox13.Width = 0.1F;
            // 
            // dayTotalTitle
            // 
            this.dayTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.dayTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dayTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.dayTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dayTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.dayTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dayTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.dayTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dayTotalTitle.Height = 0.156F;
            this.dayTotalTitle.Left = 2.375F;
            this.dayTotalTitle.MultiLine = false;
            this.dayTotalTitle.Name = "dayTotalTitle";
            this.dayTotalTitle.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.dayTotalTitle.Text = "日計";
            this.dayTotalTitle.Top = 0.0625F;
            this.dayTotalTitle.Width = 0.3F;
            // 
            // Code
            // 
            this.Code.Border.BottomColor = System.Drawing.Color.Black;
            this.Code.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Border.LeftColor = System.Drawing.Color.Black;
            this.Code.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Border.RightColor = System.Drawing.Color.Black;
            this.Code.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Border.TopColor = System.Drawing.Color.Black;
            this.Code.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Code.Height = 0.16F;
            this.Code.Left = 0.063F;
            this.Code.MultiLine = false;
            this.Code.Name = "Code";
            this.Code.OutputFormat = resources.GetString("Code.OutputFormat");
            this.Code.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Code.Text = "12345678";
            this.Code.Top = 0.0625F;
            this.Code.Width = 0.5F;
            // 
            // GrossProfitOther
            // 
            this.GrossProfitOther.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOther.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOther.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOther.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOther.DataField = "GrossProfitOther";
            this.GrossProfitOther.Height = 0.156F;
            this.GrossProfitOther.Left = 8.9375F;
            this.GrossProfitOther.MultiLine = false;
            this.GrossProfitOther.Name = "GrossProfitOther";
            this.GrossProfitOther.OutputFormat = resources.GetString("GrossProfitOther.OutputFormat");
            this.GrossProfitOther.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitOther.Text = "123,456,789";
            this.GrossProfitOther.Top = 0.25F;
            this.GrossProfitOther.Width = 0.85F;
            // 
            // GrossProfitOtherCompRate
            // 
            this.GrossProfitOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOtherCompRate.Height = 0.156F;
            this.GrossProfitOtherCompRate.Left = 10.3075F;
            this.GrossProfitOtherCompRate.MultiLine = false;
            this.GrossProfitOtherCompRate.Name = "GrossProfitOtherCompRate";
            this.GrossProfitOtherCompRate.OutputFormat = resources.GetString("GrossProfitOtherCompRate.OutputFormat");
            this.GrossProfitOtherCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitOtherCompRate.Text = "100.00%";
            this.GrossProfitOtherCompRate.Top = 0.25F;
            this.GrossProfitOtherCompRate.Width = 0.42F;
            // 
            // GrossProfitOutsideCompRate
            // 
            this.GrossProfitOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutsideCompRate.Height = 0.156F;
            this.GrossProfitOutsideCompRate.Left = 9.7875F;
            this.GrossProfitOutsideCompRate.MultiLine = false;
            this.GrossProfitOutsideCompRate.Name = "GrossProfitOutsideCompRate";
            this.GrossProfitOutsideCompRate.OutputFormat = resources.GetString("GrossProfitOutsideCompRate.OutputFormat");
            this.GrossProfitOutsideCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitOutsideCompRate.Text = "100.00%";
            this.GrossProfitOutsideCompRate.Top = 0.25F;
            this.GrossProfitOutsideCompRate.Width = 0.42F;
            // 
            // GrossProfitOutside
            // 
            this.GrossProfitOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutside.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutside.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOutside.DataField = "GrossProfitOutside";
            this.GrossProfitOutside.Height = 0.156F;
            this.GrossProfitOutside.Left = 8.0875F;
            this.GrossProfitOutside.MultiLine = false;
            this.GrossProfitOutside.Name = "GrossProfitOutside";
            this.GrossProfitOutside.OutputFormat = resources.GetString("GrossProfitOutside.OutputFormat");
            this.GrossProfitOutside.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitOutside.Text = "123,456,789";
            this.GrossProfitOutside.Top = 0.25F;
            this.GrossProfitOutside.Width = 0.85F;
            // 
            // GrossProfitPrm
            // 
            this.GrossProfitPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrm.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrm.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrm.DataField = "GrossProfitPrm";
            this.GrossProfitPrm.Height = 0.156F;
            this.GrossProfitPrm.Left = 6.23F;
            this.GrossProfitPrm.MultiLine = false;
            this.GrossProfitPrm.Name = "GrossProfitPrm";
            this.GrossProfitPrm.OutputFormat = resources.GetString("GrossProfitPrm.OutputFormat");
            this.GrossProfitPrm.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitPrm.Text = "123,456,789";
            this.GrossProfitPrm.Top = 0.25F;
            this.GrossProfitPrm.Width = 0.85F;
            // 
            // GrossProfitGenuine
            // 
            this.GrossProfitGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuine.DataField = "GrossProfitGenuine";
            this.GrossProfitGenuine.Height = 0.156F;
            this.GrossProfitGenuine.Left = 5.38F;
            this.GrossProfitGenuine.MultiLine = false;
            this.GrossProfitGenuine.Name = "GrossProfitGenuine";
            this.GrossProfitGenuine.OutputFormat = resources.GetString("GrossProfitGenuine.OutputFormat");
            this.GrossProfitGenuine.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitGenuine.Text = "123,456,789";
            this.GrossProfitGenuine.Top = 0.25F;
            this.GrossProfitGenuine.Width = 0.85F;
            // 
            // GrossProfitStock
            // 
            this.GrossProfitStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStock.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStock.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStock.DataField = "GrossProfitStock";
            this.GrossProfitStock.Height = 0.156F;
            this.GrossProfitStock.Left = 3.5425F;
            this.GrossProfitStock.MultiLine = false;
            this.GrossProfitStock.Name = "GrossProfitStock";
            this.GrossProfitStock.OutputFormat = resources.GetString("GrossProfitStock.OutputFormat");
            this.GrossProfitStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitStock.Text = "123,456,789";
            this.GrossProfitStock.Top = 0.25F;
            this.GrossProfitStock.Width = 0.85F;
            // 
            // GrossProfitOrder
            // 
            this.GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.DataField = "GrossProfitOrder";
            this.GrossProfitOrder.Height = 0.156F;
            this.GrossProfitOrder.Left = 2.6925F;
            this.GrossProfitOrder.MultiLine = false;
            this.GrossProfitOrder.Name = "GrossProfitOrder";
            this.GrossProfitOrder.OutputFormat = resources.GetString("GrossProfitOrder.OutputFormat");
            this.GrossProfitOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitOrder.Text = "123,456,789";
            this.GrossProfitOrder.Top = 0.25F;
            this.GrossProfitOrder.Width = 0.85F;
            // 
            // textBox23
            // 
            this.textBox23.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.RightColor = System.Drawing.Color.Black;
            this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.TopColor = System.Drawing.Color.Black;
            this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Height = 0.156F;
            this.textBox23.Left = 10.2075F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox23.Text = ":";
            this.textBox23.Top = 0.25F;
            this.textBox23.Width = 0.1F;
            // 
            // GrossProfitPrmCompRate
            // 
            this.GrossProfitPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitPrmCompRate.Height = 0.156F;
            this.GrossProfitPrmCompRate.Left = 7.6F;
            this.GrossProfitPrmCompRate.MultiLine = false;
            this.GrossProfitPrmCompRate.Name = "GrossProfitPrmCompRate";
            this.GrossProfitPrmCompRate.OutputFormat = resources.GetString("GrossProfitPrmCompRate.OutputFormat");
            this.GrossProfitPrmCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitPrmCompRate.Text = "100.00%";
            this.GrossProfitPrmCompRate.Top = 0.25F;
            this.GrossProfitPrmCompRate.Width = 0.42F;
            // 
            // GrossProfitGenuineCompRate
            // 
            this.GrossProfitGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitGenuineCompRate.Height = 0.156F;
            this.GrossProfitGenuineCompRate.Left = 7.08F;
            this.GrossProfitGenuineCompRate.MultiLine = false;
            this.GrossProfitGenuineCompRate.Name = "GrossProfitGenuineCompRate";
            this.GrossProfitGenuineCompRate.OutputFormat = resources.GetString("GrossProfitGenuineCompRate.OutputFormat");
            this.GrossProfitGenuineCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitGenuineCompRate.Text = "100.00%";
            this.GrossProfitGenuineCompRate.Top = 0.25F;
            this.GrossProfitGenuineCompRate.Width = 0.42F;
            // 
            // textBox26
            // 
            this.textBox26.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.RightColor = System.Drawing.Color.Black;
            this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.TopColor = System.Drawing.Color.Black;
            this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Height = 0.156F;
            this.textBox26.Left = 7.5F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox26.Text = ":";
            this.textBox26.Top = 0.25F;
            this.textBox26.Width = 0.1F;
            // 
            // GrossProfitStockCompRate
            // 
            this.GrossProfitStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitStockCompRate.Height = 0.156F;
            this.GrossProfitStockCompRate.Left = 4.9125F;
            this.GrossProfitStockCompRate.MultiLine = false;
            this.GrossProfitStockCompRate.Name = "GrossProfitStockCompRate";
            this.GrossProfitStockCompRate.OutputFormat = resources.GetString("GrossProfitStockCompRate.OutputFormat");
            this.GrossProfitStockCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitStockCompRate.Text = "100.00%";
            this.GrossProfitStockCompRate.Top = 0.25F;
            this.GrossProfitStockCompRate.Width = 0.42F;
            // 
            // GrossProfitOrderCompRate
            // 
            this.GrossProfitOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrderCompRate.Height = 0.156F;
            this.GrossProfitOrderCompRate.Left = 4.3925F;
            this.GrossProfitOrderCompRate.MultiLine = false;
            this.GrossProfitOrderCompRate.Name = "GrossProfitOrderCompRate";
            this.GrossProfitOrderCompRate.OutputFormat = resources.GetString("GrossProfitOrderCompRate.OutputFormat");
            this.GrossProfitOrderCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitOrderCompRate.Text = "100.00%";
            this.GrossProfitOrderCompRate.Top = 0.25F;
            this.GrossProfitOrderCompRate.Width = 0.42F;
            // 
            // textBox29
            // 
            this.textBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.RightColor = System.Drawing.Color.Black;
            this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.TopColor = System.Drawing.Color.Black;
            this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Height = 0.156F;
            this.textBox29.Left = 4.8125F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.Text = ":";
            this.textBox29.Top = 0.25F;
            this.textBox29.Width = 0.1F;
            // 
            // MonthSalesMoneyOther
            // 
            this.MonthSalesMoneyOther.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOther.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOther.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOther.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOther.DataField = "MonthSalesMoneyOther";
            this.MonthSalesMoneyOther.Height = 0.156F;
            this.MonthSalesMoneyOther.Left = 8.9375F;
            this.MonthSalesMoneyOther.MultiLine = false;
            this.MonthSalesMoneyOther.Name = "MonthSalesMoneyOther";
            this.MonthSalesMoneyOther.OutputFormat = resources.GetString("MonthSalesMoneyOther.OutputFormat");
            this.MonthSalesMoneyOther.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyOther.Text = "123,456,789";
            this.MonthSalesMoneyOther.Top = 0.4375F;
            this.MonthSalesMoneyOther.Width = 0.85F;
            // 
            // MonthSalesMoneyOtherCompRate
            // 
            this.MonthSalesMoneyOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOtherCompRate.Height = 0.156F;
            this.MonthSalesMoneyOtherCompRate.Left = 10.3075F;
            this.MonthSalesMoneyOtherCompRate.MultiLine = false;
            this.MonthSalesMoneyOtherCompRate.Name = "MonthSalesMoneyOtherCompRate";
            this.MonthSalesMoneyOtherCompRate.OutputFormat = resources.GetString("MonthSalesMoneyOtherCompRate.OutputFormat");
            this.MonthSalesMoneyOtherCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoneyOtherCompRate.Text = "100.00%";
            this.MonthSalesMoneyOtherCompRate.Top = 0.4375F;
            this.MonthSalesMoneyOtherCompRate.Width = 0.42F;
            // 
            // MonthSalesMoneyOutsideCompRate
            // 
            this.MonthSalesMoneyOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutsideCompRate.Height = 0.156F;
            this.MonthSalesMoneyOutsideCompRate.Left = 9.7875F;
            this.MonthSalesMoneyOutsideCompRate.MultiLine = false;
            this.MonthSalesMoneyOutsideCompRate.Name = "MonthSalesMoneyOutsideCompRate";
            this.MonthSalesMoneyOutsideCompRate.OutputFormat = resources.GetString("MonthSalesMoneyOutsideCompRate.OutputFormat");
            this.MonthSalesMoneyOutsideCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoneyOutsideCompRate.Text = "100.00%";
            this.MonthSalesMoneyOutsideCompRate.Top = 0.4375F;
            this.MonthSalesMoneyOutsideCompRate.Width = 0.42F;
            // 
            // MonthSalesMoneyOutside
            // 
            this.MonthSalesMoneyOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutside.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutside.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOutside.DataField = "MonthSalesMoneyOutside";
            this.MonthSalesMoneyOutside.Height = 0.156F;
            this.MonthSalesMoneyOutside.Left = 8.0875F;
            this.MonthSalesMoneyOutside.MultiLine = false;
            this.MonthSalesMoneyOutside.Name = "MonthSalesMoneyOutside";
            this.MonthSalesMoneyOutside.OutputFormat = resources.GetString("MonthSalesMoneyOutside.OutputFormat");
            this.MonthSalesMoneyOutside.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyOutside.Text = "123,456,789";
            this.MonthSalesMoneyOutside.Top = 0.4375F;
            this.MonthSalesMoneyOutside.Width = 0.85F;
            // 
            // MonthSalesMoneyPrm
            // 
            this.MonthSalesMoneyPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrm.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrm.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrm.DataField = "MonthSalesMoneyPrm";
            this.MonthSalesMoneyPrm.Height = 0.156F;
            this.MonthSalesMoneyPrm.Left = 6.23F;
            this.MonthSalesMoneyPrm.MultiLine = false;
            this.MonthSalesMoneyPrm.Name = "MonthSalesMoneyPrm";
            this.MonthSalesMoneyPrm.OutputFormat = resources.GetString("MonthSalesMoneyPrm.OutputFormat");
            this.MonthSalesMoneyPrm.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyPrm.Text = "123,456,789";
            this.MonthSalesMoneyPrm.Top = 0.4375F;
            this.MonthSalesMoneyPrm.Width = 0.85F;
            // 
            // MonthSalesMoneyGenuine
            // 
            this.MonthSalesMoneyGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuine.DataField = "MonthSalesMoneyGenuine";
            this.MonthSalesMoneyGenuine.Height = 0.156F;
            this.MonthSalesMoneyGenuine.Left = 5.38F;
            this.MonthSalesMoneyGenuine.MultiLine = false;
            this.MonthSalesMoneyGenuine.Name = "MonthSalesMoneyGenuine";
            this.MonthSalesMoneyGenuine.OutputFormat = resources.GetString("MonthSalesMoneyGenuine.OutputFormat");
            this.MonthSalesMoneyGenuine.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyGenuine.Text = "123,456,789";
            this.MonthSalesMoneyGenuine.Top = 0.4375F;
            this.MonthSalesMoneyGenuine.Width = 0.85F;
            // 
            // MonthSalesMoneyStock
            // 
            this.MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.MonthSalesMoneyStock.Height = 0.156F;
            this.MonthSalesMoneyStock.Left = 3.5425F;
            this.MonthSalesMoneyStock.MultiLine = false;
            this.MonthSalesMoneyStock.Name = "MonthSalesMoneyStock";
            this.MonthSalesMoneyStock.OutputFormat = resources.GetString("MonthSalesMoneyStock.OutputFormat");
            this.MonthSalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyStock.Text = "123,456,789";
            this.MonthSalesMoneyStock.Top = 0.4375F;
            this.MonthSalesMoneyStock.Width = 0.85F;
            // 
            // MonthSalesMoneyOrder
            // 
            this.MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.MonthSalesMoneyOrder.Height = 0.156F;
            this.MonthSalesMoneyOrder.Left = 2.6925F;
            this.MonthSalesMoneyOrder.MultiLine = false;
            this.MonthSalesMoneyOrder.Name = "MonthSalesMoneyOrder";
            this.MonthSalesMoneyOrder.OutputFormat = resources.GetString("MonthSalesMoneyOrder.OutputFormat");
            this.MonthSalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyOrder.Text = "123,456,789";
            this.MonthSalesMoneyOrder.Top = 0.4375F;
            this.MonthSalesMoneyOrder.Width = 0.85F;
            // 
            // textBox38
            // 
            this.textBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.RightColor = System.Drawing.Color.Black;
            this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.TopColor = System.Drawing.Color.Black;
            this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Height = 0.156F;
            this.textBox38.Left = 10.2075F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox38.Text = ":";
            this.textBox38.Top = 0.4375F;
            this.textBox38.Width = 0.1F;
            // 
            // MonthSalesMoneyPrmCompRate
            // 
            this.MonthSalesMoneyPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyPrmCompRate.Height = 0.156F;
            this.MonthSalesMoneyPrmCompRate.Left = 7.6F;
            this.MonthSalesMoneyPrmCompRate.MultiLine = false;
            this.MonthSalesMoneyPrmCompRate.Name = "MonthSalesMoneyPrmCompRate";
            this.MonthSalesMoneyPrmCompRate.OutputFormat = resources.GetString("MonthSalesMoneyPrmCompRate.OutputFormat");
            this.MonthSalesMoneyPrmCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoneyPrmCompRate.Text = "100.00%";
            this.MonthSalesMoneyPrmCompRate.Top = 0.4375F;
            this.MonthSalesMoneyPrmCompRate.Width = 0.42F;
            // 
            // MonthSalesMoneyGenuineCompRate
            // 
            this.MonthSalesMoneyGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyGenuineCompRate.Height = 0.156F;
            this.MonthSalesMoneyGenuineCompRate.Left = 7.08F;
            this.MonthSalesMoneyGenuineCompRate.MultiLine = false;
            this.MonthSalesMoneyGenuineCompRate.Name = "MonthSalesMoneyGenuineCompRate";
            this.MonthSalesMoneyGenuineCompRate.OutputFormat = resources.GetString("MonthSalesMoneyGenuineCompRate.OutputFormat");
            this.MonthSalesMoneyGenuineCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoneyGenuineCompRate.Text = "100.00%";
            this.MonthSalesMoneyGenuineCompRate.Top = 0.4375F;
            this.MonthSalesMoneyGenuineCompRate.Width = 0.42F;
            // 
            // textBox41
            // 
            this.textBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.RightColor = System.Drawing.Color.Black;
            this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.TopColor = System.Drawing.Color.Black;
            this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Height = 0.156F;
            this.textBox41.Left = 7.5F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox41.Text = ":";
            this.textBox41.Top = 0.4375F;
            this.textBox41.Width = 0.1F;
            // 
            // MonthSalesMoneyStockCompRate
            // 
            this.MonthSalesMoneyStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStockCompRate.Height = 0.156F;
            this.MonthSalesMoneyStockCompRate.Left = 4.9125F;
            this.MonthSalesMoneyStockCompRate.MultiLine = false;
            this.MonthSalesMoneyStockCompRate.Name = "MonthSalesMoneyStockCompRate";
            this.MonthSalesMoneyStockCompRate.OutputFormat = resources.GetString("MonthSalesMoneyStockCompRate.OutputFormat");
            this.MonthSalesMoneyStockCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoneyStockCompRate.Text = "100.00%";
            this.MonthSalesMoneyStockCompRate.Top = 0.4375F;
            this.MonthSalesMoneyStockCompRate.Width = 0.42F;
            // 
            // MonthSalesMoneyOrderCompRate
            // 
            this.MonthSalesMoneyOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrderCompRate.Height = 0.156F;
            this.MonthSalesMoneyOrderCompRate.Left = 4.3925F;
            this.MonthSalesMoneyOrderCompRate.MultiLine = false;
            this.MonthSalesMoneyOrderCompRate.Name = "MonthSalesMoneyOrderCompRate";
            this.MonthSalesMoneyOrderCompRate.OutputFormat = resources.GetString("MonthSalesMoneyOrderCompRate.OutputFormat");
            this.MonthSalesMoneyOrderCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthSalesMoneyOrderCompRate.Text = "100.00%";
            this.MonthSalesMoneyOrderCompRate.Top = 0.4375F;
            this.MonthSalesMoneyOrderCompRate.Width = 0.42F;
            // 
            // textBox44
            // 
            this.textBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.RightColor = System.Drawing.Color.Black;
            this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.TopColor = System.Drawing.Color.Black;
            this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Height = 0.156F;
            this.textBox44.Left = 4.8125F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.Text = ":";
            this.textBox44.Top = 0.4375F;
            this.textBox44.Width = 0.1F;
            // 
            // monthTotalTitle
            // 
            this.monthTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.monthTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.monthTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.monthTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.monthTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.monthTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.monthTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.monthTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.monthTotalTitle.Height = 0.156F;
            this.monthTotalTitle.Left = 2.375F;
            this.monthTotalTitle.MultiLine = false;
            this.monthTotalTitle.Name = "monthTotalTitle";
            this.monthTotalTitle.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.monthTotalTitle.Text = "累計";
            this.monthTotalTitle.Top = 0.4375F;
            this.monthTotalTitle.Width = 0.3F;
            // 
            // MonthGrossProfitOther
            // 
            this.MonthGrossProfitOther.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOther.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOther.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOther.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOther.DataField = "MonthGrossProfitOther";
            this.MonthGrossProfitOther.Height = 0.156F;
            this.MonthGrossProfitOther.Left = 8.9375F;
            this.MonthGrossProfitOther.MultiLine = false;
            this.MonthGrossProfitOther.Name = "MonthGrossProfitOther";
            this.MonthGrossProfitOther.OutputFormat = resources.GetString("MonthGrossProfitOther.OutputFormat");
            this.MonthGrossProfitOther.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitOther.Text = "123,456,789";
            this.MonthGrossProfitOther.Top = 0.625F;
            this.MonthGrossProfitOther.Width = 0.85F;
            // 
            // MonthGrossProfitOtherCompRate
            // 
            this.MonthGrossProfitOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOtherCompRate.Height = 0.156F;
            this.MonthGrossProfitOtherCompRate.Left = 10.3075F;
            this.MonthGrossProfitOtherCompRate.MultiLine = false;
            this.MonthGrossProfitOtherCompRate.Name = "MonthGrossProfitOtherCompRate";
            this.MonthGrossProfitOtherCompRate.OutputFormat = resources.GetString("MonthGrossProfitOtherCompRate.OutputFormat");
            this.MonthGrossProfitOtherCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitOtherCompRate.Text = "100.00%";
            this.MonthGrossProfitOtherCompRate.Top = 0.625F;
            this.MonthGrossProfitOtherCompRate.Width = 0.42F;
            // 
            // MonthGrossProfitOutsideCompRate
            // 
            this.MonthGrossProfitOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutsideCompRate.Height = 0.156F;
            this.MonthGrossProfitOutsideCompRate.Left = 9.7875F;
            this.MonthGrossProfitOutsideCompRate.MultiLine = false;
            this.MonthGrossProfitOutsideCompRate.Name = "MonthGrossProfitOutsideCompRate";
            this.MonthGrossProfitOutsideCompRate.OutputFormat = resources.GetString("MonthGrossProfitOutsideCompRate.OutputFormat");
            this.MonthGrossProfitOutsideCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitOutsideCompRate.Text = "100.00%";
            this.MonthGrossProfitOutsideCompRate.Top = 0.625F;
            this.MonthGrossProfitOutsideCompRate.Width = 0.42F;
            // 
            // MonthGrossProfitOutside
            // 
            this.MonthGrossProfitOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutside.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutside.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOutside.DataField = "MonthGrossProfitOutside";
            this.MonthGrossProfitOutside.Height = 0.156F;
            this.MonthGrossProfitOutside.Left = 8.0875F;
            this.MonthGrossProfitOutside.MultiLine = false;
            this.MonthGrossProfitOutside.Name = "MonthGrossProfitOutside";
            this.MonthGrossProfitOutside.OutputFormat = resources.GetString("MonthGrossProfitOutside.OutputFormat");
            this.MonthGrossProfitOutside.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitOutside.Text = "123,456,789";
            this.MonthGrossProfitOutside.Top = 0.625F;
            this.MonthGrossProfitOutside.Width = 0.85F;
            // 
            // MonthGrossProfitPrm
            // 
            this.MonthGrossProfitPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrm.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrm.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrm.DataField = "MonthGrossProfitPrm";
            this.MonthGrossProfitPrm.Height = 0.156F;
            this.MonthGrossProfitPrm.Left = 6.23F;
            this.MonthGrossProfitPrm.MultiLine = false;
            this.MonthGrossProfitPrm.Name = "MonthGrossProfitPrm";
            this.MonthGrossProfitPrm.OutputFormat = resources.GetString("MonthGrossProfitPrm.OutputFormat");
            this.MonthGrossProfitPrm.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitPrm.Text = "123,456,789";
            this.MonthGrossProfitPrm.Top = 0.625F;
            this.MonthGrossProfitPrm.Width = 0.85F;
            // 
            // MonthGrossProfitGenuine
            // 
            this.MonthGrossProfitGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuine.DataField = "MonthGrossProfitGenuine";
            this.MonthGrossProfitGenuine.Height = 0.156F;
            this.MonthGrossProfitGenuine.Left = 5.38F;
            this.MonthGrossProfitGenuine.MultiLine = false;
            this.MonthGrossProfitGenuine.Name = "MonthGrossProfitGenuine";
            this.MonthGrossProfitGenuine.OutputFormat = resources.GetString("MonthGrossProfitGenuine.OutputFormat");
            this.MonthGrossProfitGenuine.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitGenuine.Text = "123,456,789";
            this.MonthGrossProfitGenuine.Top = 0.625F;
            this.MonthGrossProfitGenuine.Width = 0.85F;
            // 
            // MonthGrossProfitStock
            // 
            this.MonthGrossProfitStock.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStock.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStock.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStock.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStock.DataField = "MonthGrossProfitStock";
            this.MonthGrossProfitStock.Height = 0.156F;
            this.MonthGrossProfitStock.Left = 3.5425F;
            this.MonthGrossProfitStock.MultiLine = false;
            this.MonthGrossProfitStock.Name = "MonthGrossProfitStock";
            this.MonthGrossProfitStock.OutputFormat = resources.GetString("MonthGrossProfitStock.OutputFormat");
            this.MonthGrossProfitStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitStock.Text = "123,456,789";
            this.MonthGrossProfitStock.Top = 0.625F;
            this.MonthGrossProfitStock.Width = 0.85F;
            // 
            // MonthGrossProfitOrder
            // 
            this.MonthGrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrder.DataField = "MonthGrossProfitOrder";
            this.MonthGrossProfitOrder.Height = 0.156F;
            this.MonthGrossProfitOrder.Left = 2.6925F;
            this.MonthGrossProfitOrder.MultiLine = false;
            this.MonthGrossProfitOrder.Name = "MonthGrossProfitOrder";
            this.MonthGrossProfitOrder.OutputFormat = resources.GetString("MonthGrossProfitOrder.OutputFormat");
            this.MonthGrossProfitOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitOrder.Text = "123,456,789";
            this.MonthGrossProfitOrder.Top = 0.625F;
            this.MonthGrossProfitOrder.Width = 0.85F;
            // 
            // textBox54
            // 
            this.textBox54.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.RightColor = System.Drawing.Color.Black;
            this.textBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.TopColor = System.Drawing.Color.Black;
            this.textBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Height = 0.156F;
            this.textBox54.Left = 10.2075F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.Text = ":";
            this.textBox54.Top = 0.625F;
            this.textBox54.Width = 0.1F;
            // 
            // MonthGrossProfitPrmCompRate
            // 
            this.MonthGrossProfitPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitPrmCompRate.Height = 0.156F;
            this.MonthGrossProfitPrmCompRate.Left = 7.6F;
            this.MonthGrossProfitPrmCompRate.MultiLine = false;
            this.MonthGrossProfitPrmCompRate.Name = "MonthGrossProfitPrmCompRate";
            this.MonthGrossProfitPrmCompRate.OutputFormat = resources.GetString("MonthGrossProfitPrmCompRate.OutputFormat");
            this.MonthGrossProfitPrmCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitPrmCompRate.Text = "100.00%";
            this.MonthGrossProfitPrmCompRate.Top = 0.625F;
            this.MonthGrossProfitPrmCompRate.Width = 0.42F;
            // 
            // MonthGrossProfitGenuineCompRate
            // 
            this.MonthGrossProfitGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitGenuineCompRate.Height = 0.156F;
            this.MonthGrossProfitGenuineCompRate.Left = 7.08F;
            this.MonthGrossProfitGenuineCompRate.MultiLine = false;
            this.MonthGrossProfitGenuineCompRate.Name = "MonthGrossProfitGenuineCompRate";
            this.MonthGrossProfitGenuineCompRate.OutputFormat = resources.GetString("MonthGrossProfitGenuineCompRate.OutputFormat");
            this.MonthGrossProfitGenuineCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitGenuineCompRate.Text = "100.00%";
            this.MonthGrossProfitGenuineCompRate.Top = 0.625F;
            this.MonthGrossProfitGenuineCompRate.Width = 0.42F;
            // 
            // textBox57
            // 
            this.textBox57.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.RightColor = System.Drawing.Color.Black;
            this.textBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.TopColor = System.Drawing.Color.Black;
            this.textBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Height = 0.156F;
            this.textBox57.Left = 7.5F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox57.Text = ":";
            this.textBox57.Top = 0.625F;
            this.textBox57.Width = 0.1F;
            // 
            // MonthGrossProfitStockCompRate
            // 
            this.MonthGrossProfitStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitStockCompRate.Height = 0.156F;
            this.MonthGrossProfitStockCompRate.Left = 4.9125F;
            this.MonthGrossProfitStockCompRate.MultiLine = false;
            this.MonthGrossProfitStockCompRate.Name = "MonthGrossProfitStockCompRate";
            this.MonthGrossProfitStockCompRate.OutputFormat = resources.GetString("MonthGrossProfitStockCompRate.OutputFormat");
            this.MonthGrossProfitStockCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitStockCompRate.Text = "100.00%";
            this.MonthGrossProfitStockCompRate.Top = 0.625F;
            this.MonthGrossProfitStockCompRate.Width = 0.42F;
            // 
            // MonthGrossProfitOrderCompRate
            // 
            this.MonthGrossProfitOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitOrderCompRate.Height = 0.156F;
            this.MonthGrossProfitOrderCompRate.Left = 4.3925F;
            this.MonthGrossProfitOrderCompRate.MultiLine = false;
            this.MonthGrossProfitOrderCompRate.Name = "MonthGrossProfitOrderCompRate";
            this.MonthGrossProfitOrderCompRate.OutputFormat = resources.GetString("MonthGrossProfitOrderCompRate.OutputFormat");
            this.MonthGrossProfitOrderCompRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MonthGrossProfitOrderCompRate.Text = "100.00%";
            this.MonthGrossProfitOrderCompRate.Top = 0.625F;
            this.MonthGrossProfitOrderCompRate.Width = 0.42F;
            // 
            // textBox60
            // 
            this.textBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.RightColor = System.Drawing.Color.Black;
            this.textBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.TopColor = System.Drawing.Color.Black;
            this.textBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Height = 0.156F;
            this.textBox60.Left = 4.8125F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox60.Text = ":";
            this.textBox60.Top = 0.625F;
            this.textBox60.Width = 0.1F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // DetaliLine1
            // 
            this.DetaliLine1.Border.BottomColor = System.Drawing.Color.Black;
            this.DetaliLine1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine1.Border.LeftColor = System.Drawing.Color.Black;
            this.DetaliLine1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine1.Border.RightColor = System.Drawing.Color.Black;
            this.DetaliLine1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine1.Border.TopColor = System.Drawing.Color.Black;
            this.DetaliLine1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine1.Height = 0.8F;
            this.DetaliLine1.Left = 5.35F;
            this.DetaliLine1.LineWeight = 1F;
            this.DetaliLine1.Name = "DetaliLine1";
            this.DetaliLine1.Top = 0F;
            this.DetaliLine1.Width = 0F;
            this.DetaliLine1.X1 = 5.35F;
            this.DetaliLine1.X2 = 5.35F;
            this.DetaliLine1.Y1 = 0F;
            this.DetaliLine1.Y2 = 0.8F;
            // 
            // DetaliLine2
            // 
            this.DetaliLine2.Border.BottomColor = System.Drawing.Color.Black;
            this.DetaliLine2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine2.Border.LeftColor = System.Drawing.Color.Black;
            this.DetaliLine2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine2.Border.RightColor = System.Drawing.Color.Black;
            this.DetaliLine2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine2.Border.TopColor = System.Drawing.Color.Black;
            this.DetaliLine2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetaliLine2.Height = 0.8F;
            this.DetaliLine2.Left = 8.05F;
            this.DetaliLine2.LineWeight = 1F;
            this.DetaliLine2.Name = "DetaliLine2";
            this.DetaliLine2.Top = 0F;
            this.DetaliLine2.Width = 0F;
            this.DetaliLine2.X1 = 8.05F;
            this.DetaliLine2.X2 = 8.05F;
            this.DetaliLine2.Y1 = 0F;
            this.DetaliLine2.Y2 = 0.8F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.28125F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Footer_SubReport
            // 
            this.Footer_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.CloseBorder = false;
            this.Footer_SubReport.Height = 0.239F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_SectionCode,
            this.SecHd_SectionGuideNm,
            this.SecHd_SectionTitle,
            this.line3});
            this.SectionHeader.DataField = "SecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.1979167F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
            // 
            // SecHd_SectionCode
            // 
            this.SecHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.DataField = "SecCode";
            this.SecHd_SectionCode.Height = 0.156F;
            this.SecHd_SectionCode.Left = 0.55F;
            this.SecHd_SectionCode.MultiLine = false;
            this.SecHd_SectionCode.Name = "SecHd_SectionCode";
            this.SecHd_SectionCode.OutputFormat = resources.GetString("SecHd_SectionCode.OutputFormat");
            this.SecHd_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SecHd_SectionCode.Text = "12";
            this.SecHd_SectionCode.Top = 0.01F;
            this.SecHd_SectionCode.Width = 0.2F;
            // 
            // SecHd_SectionGuideNm
            // 
            this.SecHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionGuideNm.DataField = "SectionGuideSnm";
            this.SecHd_SectionGuideNm.Height = 0.15625F;
            this.SecHd_SectionGuideNm.Left = 0.75F;
            this.SecHd_SectionGuideNm.MultiLine = false;
            this.SecHd_SectionGuideNm.Name = "SecHd_SectionGuideNm";
            this.SecHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SecHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SecHd_SectionGuideNm.Top = 0.01F;
            this.SecHd_SectionGuideNm.Width = 1.1875F;
            // 
            // SecHd_SectionTitle
            // 
            this.SecHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionTitle.Height = 0.156F;
            this.SecHd_SectionTitle.HyperLink = "";
            this.SecHd_SectionTitle.Left = 0.237F;
            this.SecHd_SectionTitle.MultiLine = false;
            this.SecHd_SectionTitle.Name = "SecHd_SectionTitle";
            this.SecHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SecHd_SectionTitle.Text = "拠点";
            this.SecHd_SectionTitle.Top = 0.01F;
            this.SecHd_SectionTitle.Width = 0.313F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecFt_SalesMoneyOther,
            this.SecFt_SalesMoneyOtherCompRate,
            this.SecFt_SalesMoneyOutsideCompRate,
            this.SecFt_SalesMoneyOutside,
            this.SecFt_SalesMoneyPrm,
            this.SecFt_SalesMoneyGenuine,
            this.SecFt_SalesMoneyStock,
            this.SecFt_SalesMoneyOrder,
            this.textBox69,
            this.SecFt_SalesMoneyPrmCompRate,
            this.SecFt_SalesMoneyGenuineCompRate,
            this.textBox72,
            this.SecFt_SalesMoneyStockCompRate,
            this.SecFt_SalesMoneyOrderCompRate,
            this.textBox75,
            this.SecFt_dayTotalTitle,
            this.SecFt_GrossProfitOther,
            this.SecFt_GrossProfitOtherCompRate,
            this.SecFt_GrossProfitOutsideCompRate,
            this.SecFt_GrossProfitOutside,
            this.SecFt_GrossProfitPrm,
            this.SecFt_GrossProfitGenuine,
            this.SecFt_GrossProfitStock,
            this.SecFt_GrossProfitOrder,
            this.textBox85,
            this.SecFt_GrossProfitPrmCompRate,
            this.SecFt_GrossProfitGenuineCompRate,
            this.textBox88,
            this.SecFt_GrossProfitStockCompRate,
            this.SecFt_GrossProfitOrderCompRate,
            this.textBox91,
            this.SecFt_MonthSalesMoneyOther,
            this.SecFt_MonthSalesMoneyOtherCompRate,
            this.SecFt_MonthSalesMoneyOutsideCompRate,
            this.SecFt_MonthSalesMoneyOutside,
            this.SecFt_MonthSalesMoneyPrm,
            this.SecFt_MonthSalesMoneyGenuine,
            this.SecFt_MonthSalesMoneyStock,
            this.SecFt_MonthSalesMoneyOrder,
            this.textBox100,
            this.SecFt_MonthSalesMoneyPrmCompRate,
            this.SecFt_MonthSalesMoneyGenuineCompRate,
            this.textBox103,
            this.SecFt_MonthSalesMoneyStockCompRate,
            this.SecFt_MonthSalesMoneyOrderCompRate,
            this.textBox106,
            this.SecFt_monthTotalTitle,
            this.SecFt_MonthGrossProfitOther,
            this.SecFt_MonthGrossProfitOtherCompRate,
            this.SecFt_MonthGrossProfitOutsideCompRate,
            this.SecFt_MonthGrossProfitOutside,
            this.SecFt_MonthGrossProfitPrm,
            this.SecFt_MonthGrossProfitGenuine,
            this.SecFt_MonthGrossProfitStock,
            this.SecFt_MonthGrossProfitOrder,
            this.textBox116,
            this.SecFt_MonthGrossProfitPrmCompRate,
            this.SecFt_MonthGrossProfitGenuineCompRate,
            this.textBox119,
            this.SecFt_MonthGrossProfitStockCompRate,
            this.SecFt_MonthGrossProfitOrderCompRate,
            this.textBox122,
            this.SectionTitle,
            this.line4,
            this.SecFt_Line1,
            this.SecFt_Line2});
            this.SectionFooter.Height = 0.8541667F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // SecFt_SalesMoneyOther
            // 
            this.SecFt_SalesMoneyOther.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOther.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOther.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOther.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOther.DataField = "SalesMoneyOther";
            this.SecFt_SalesMoneyOther.Height = 0.156F;
            this.SecFt_SalesMoneyOther.Left = 8.9375F;
            this.SecFt_SalesMoneyOther.MultiLine = false;
            this.SecFt_SalesMoneyOther.Name = "SecFt_SalesMoneyOther";
            this.SecFt_SalesMoneyOther.OutputFormat = resources.GetString("SecFt_SalesMoneyOther.OutputFormat");
            this.SecFt_SalesMoneyOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyOther.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoneyOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoneyOther.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoneyOther.Text = "12,345,678,901";
            this.SecFt_SalesMoneyOther.Top = 0.063F;
            this.SecFt_SalesMoneyOther.Width = 0.85F;
            // 
            // SecFt_SalesMoneyOtherCompRate
            // 
            this.SecFt_SalesMoneyOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOtherCompRate.Height = 0.156F;
            this.SecFt_SalesMoneyOtherCompRate.Left = 10.3075F;
            this.SecFt_SalesMoneyOtherCompRate.MultiLine = false;
            this.SecFt_SalesMoneyOtherCompRate.Name = "SecFt_SalesMoneyOtherCompRate";
            this.SecFt_SalesMoneyOtherCompRate.OutputFormat = resources.GetString("SecFt_SalesMoneyOtherCompRate.OutputFormat");
            this.SecFt_SalesMoneyOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyOtherCompRate.Text = "100.00%";
            this.SecFt_SalesMoneyOtherCompRate.Top = 0.063F;
            this.SecFt_SalesMoneyOtherCompRate.Width = 0.42F;
            // 
            // SecFt_SalesMoneyOutsideCompRate
            // 
            this.SecFt_SalesMoneyOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutsideCompRate.Height = 0.156F;
            this.SecFt_SalesMoneyOutsideCompRate.Left = 9.7875F;
            this.SecFt_SalesMoneyOutsideCompRate.MultiLine = false;
            this.SecFt_SalesMoneyOutsideCompRate.Name = "SecFt_SalesMoneyOutsideCompRate";
            this.SecFt_SalesMoneyOutsideCompRate.OutputFormat = resources.GetString("SecFt_SalesMoneyOutsideCompRate.OutputFormat");
            this.SecFt_SalesMoneyOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyOutsideCompRate.Text = "100.00%";
            this.SecFt_SalesMoneyOutsideCompRate.Top = 0.063F;
            this.SecFt_SalesMoneyOutsideCompRate.Width = 0.42F;
            // 
            // SecFt_SalesMoneyOutside
            // 
            this.SecFt_SalesMoneyOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutside.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutside.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOutside.DataField = "SalesMoneyOutside";
            this.SecFt_SalesMoneyOutside.Height = 0.156F;
            this.SecFt_SalesMoneyOutside.Left = 8.0875F;
            this.SecFt_SalesMoneyOutside.MultiLine = false;
            this.SecFt_SalesMoneyOutside.Name = "SecFt_SalesMoneyOutside";
            this.SecFt_SalesMoneyOutside.OutputFormat = resources.GetString("SecFt_SalesMoneyOutside.OutputFormat");
            this.SecFt_SalesMoneyOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyOutside.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoneyOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoneyOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoneyOutside.Text = "12,345,678,901";
            this.SecFt_SalesMoneyOutside.Top = 0.063F;
            this.SecFt_SalesMoneyOutside.Width = 0.85F;
            // 
            // SecFt_SalesMoneyPrm
            // 
            this.SecFt_SalesMoneyPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrm.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrm.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrm.DataField = "SalesMoneyPrm";
            this.SecFt_SalesMoneyPrm.Height = 0.156F;
            this.SecFt_SalesMoneyPrm.Left = 6.23F;
            this.SecFt_SalesMoneyPrm.MultiLine = false;
            this.SecFt_SalesMoneyPrm.Name = "SecFt_SalesMoneyPrm";
            this.SecFt_SalesMoneyPrm.OutputFormat = resources.GetString("SecFt_SalesMoneyPrm.OutputFormat");
            this.SecFt_SalesMoneyPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyPrm.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoneyPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoneyPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoneyPrm.Text = "12,345,678,901";
            this.SecFt_SalesMoneyPrm.Top = 0.063F;
            this.SecFt_SalesMoneyPrm.Width = 0.85F;
            // 
            // SecFt_SalesMoneyGenuine
            // 
            this.SecFt_SalesMoneyGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuine.DataField = "SalesMoneyGenuine";
            this.SecFt_SalesMoneyGenuine.Height = 0.156F;
            this.SecFt_SalesMoneyGenuine.Left = 5.38F;
            this.SecFt_SalesMoneyGenuine.MultiLine = false;
            this.SecFt_SalesMoneyGenuine.Name = "SecFt_SalesMoneyGenuine";
            this.SecFt_SalesMoneyGenuine.OutputFormat = resources.GetString("SecFt_SalesMoneyGenuine.OutputFormat");
            this.SecFt_SalesMoneyGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyGenuine.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoneyGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoneyGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoneyGenuine.Text = "12,345,678,901";
            this.SecFt_SalesMoneyGenuine.Top = 0.063F;
            this.SecFt_SalesMoneyGenuine.Width = 0.85F;
            // 
            // SecFt_SalesMoneyStock
            // 
            this.SecFt_SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStock.DataField = "SalesMoneyStock";
            this.SecFt_SalesMoneyStock.Height = 0.156F;
            this.SecFt_SalesMoneyStock.Left = 3.5425F;
            this.SecFt_SalesMoneyStock.MultiLine = false;
            this.SecFt_SalesMoneyStock.Name = "SecFt_SalesMoneyStock";
            this.SecFt_SalesMoneyStock.OutputFormat = resources.GetString("SecFt_SalesMoneyStock.OutputFormat");
            this.SecFt_SalesMoneyStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyStock.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoneyStock.Text = "12,345,678,901";
            this.SecFt_SalesMoneyStock.Top = 0.063F;
            this.SecFt_SalesMoneyStock.Width = 0.85F;
            // 
            // SecFt_SalesMoneyOrder
            // 
            this.SecFt_SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.SecFt_SalesMoneyOrder.Height = 0.156F;
            this.SecFt_SalesMoneyOrder.Left = 2.6925F;
            this.SecFt_SalesMoneyOrder.MultiLine = false;
            this.SecFt_SalesMoneyOrder.Name = "SecFt_SalesMoneyOrder";
            this.SecFt_SalesMoneyOrder.OutputFormat = resources.GetString("SecFt_SalesMoneyOrder.OutputFormat");
            this.SecFt_SalesMoneyOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyOrder.SummaryGroup = "SectionHeader";
            this.SecFt_SalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesMoneyOrder.Text = "12,345,678,901";
            this.SecFt_SalesMoneyOrder.Top = 0.063F;
            this.SecFt_SalesMoneyOrder.Width = 0.85F;
            // 
            // textBox69
            // 
            this.textBox69.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.RightColor = System.Drawing.Color.Black;
            this.textBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.TopColor = System.Drawing.Color.Black;
            this.textBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Height = 0.156F;
            this.textBox69.Left = 10.2075F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox69.Text = ":";
            this.textBox69.Top = 0.063F;
            this.textBox69.Width = 0.1F;
            // 
            // SecFt_SalesMoneyPrmCompRate
            // 
            this.SecFt_SalesMoneyPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyPrmCompRate.Height = 0.156F;
            this.SecFt_SalesMoneyPrmCompRate.Left = 7.6F;
            this.SecFt_SalesMoneyPrmCompRate.MultiLine = false;
            this.SecFt_SalesMoneyPrmCompRate.Name = "SecFt_SalesMoneyPrmCompRate";
            this.SecFt_SalesMoneyPrmCompRate.OutputFormat = resources.GetString("SecFt_SalesMoneyPrmCompRate.OutputFormat");
            this.SecFt_SalesMoneyPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyPrmCompRate.Text = "100.00%";
            this.SecFt_SalesMoneyPrmCompRate.Top = 0.063F;
            this.SecFt_SalesMoneyPrmCompRate.Width = 0.42F;
            // 
            // SecFt_SalesMoneyGenuineCompRate
            // 
            this.SecFt_SalesMoneyGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyGenuineCompRate.Height = 0.156F;
            this.SecFt_SalesMoneyGenuineCompRate.Left = 7.08F;
            this.SecFt_SalesMoneyGenuineCompRate.MultiLine = false;
            this.SecFt_SalesMoneyGenuineCompRate.Name = "SecFt_SalesMoneyGenuineCompRate";
            this.SecFt_SalesMoneyGenuineCompRate.OutputFormat = resources.GetString("SecFt_SalesMoneyGenuineCompRate.OutputFormat");
            this.SecFt_SalesMoneyGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyGenuineCompRate.Text = "100.00%";
            this.SecFt_SalesMoneyGenuineCompRate.Top = 0.063F;
            this.SecFt_SalesMoneyGenuineCompRate.Width = 0.42F;
            // 
            // textBox72
            // 
            this.textBox72.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.RightColor = System.Drawing.Color.Black;
            this.textBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.TopColor = System.Drawing.Color.Black;
            this.textBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Height = 0.156F;
            this.textBox72.Left = 7.5F;
            this.textBox72.MultiLine = false;
            this.textBox72.Name = "textBox72";
            this.textBox72.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox72.Text = ":";
            this.textBox72.Top = 0.063F;
            this.textBox72.Width = 0.1F;
            // 
            // SecFt_SalesMoneyStockCompRate
            // 
            this.SecFt_SalesMoneyStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyStockCompRate.Height = 0.156F;
            this.SecFt_SalesMoneyStockCompRate.Left = 4.9125F;
            this.SecFt_SalesMoneyStockCompRate.MultiLine = false;
            this.SecFt_SalesMoneyStockCompRate.Name = "SecFt_SalesMoneyStockCompRate";
            this.SecFt_SalesMoneyStockCompRate.OutputFormat = resources.GetString("SecFt_SalesMoneyStockCompRate.OutputFormat");
            this.SecFt_SalesMoneyStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyStockCompRate.Text = "100.00%";
            this.SecFt_SalesMoneyStockCompRate.Top = 0.063F;
            this.SecFt_SalesMoneyStockCompRate.Width = 0.42F;
            // 
            // SecFt_SalesMoneyOrderCompRate
            // 
            this.SecFt_SalesMoneyOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesMoneyOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesMoneyOrderCompRate.Height = 0.156F;
            this.SecFt_SalesMoneyOrderCompRate.Left = 4.3925F;
            this.SecFt_SalesMoneyOrderCompRate.MultiLine = false;
            this.SecFt_SalesMoneyOrderCompRate.Name = "SecFt_SalesMoneyOrderCompRate";
            this.SecFt_SalesMoneyOrderCompRate.OutputFormat = resources.GetString("SecFt_SalesMoneyOrderCompRate.OutputFormat");
            this.SecFt_SalesMoneyOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesMoneyOrderCompRate.Text = "100.00%";
            this.SecFt_SalesMoneyOrderCompRate.Top = 0.063F;
            this.SecFt_SalesMoneyOrderCompRate.Width = 0.42F;
            // 
            // textBox75
            // 
            this.textBox75.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.RightColor = System.Drawing.Color.Black;
            this.textBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.TopColor = System.Drawing.Color.Black;
            this.textBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Height = 0.156F;
            this.textBox75.Left = 4.8125F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox75.Text = ":";
            this.textBox75.Top = 0.063F;
            this.textBox75.Width = 0.1F;
            // 
            // SecFt_dayTotalTitle
            // 
            this.SecFt_dayTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_dayTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dayTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_dayTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dayTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_dayTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dayTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_dayTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_dayTotalTitle.Height = 0.156F;
            this.SecFt_dayTotalTitle.Left = 2.375F;
            this.SecFt_dayTotalTitle.MultiLine = false;
            this.SecFt_dayTotalTitle.Name = "SecFt_dayTotalTitle";
            this.SecFt_dayTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SecFt_dayTotalTitle.Text = "日計";
            this.SecFt_dayTotalTitle.Top = 0.063F;
            this.SecFt_dayTotalTitle.Width = 0.3F;
            // 
            // SecFt_GrossProfitOther
            // 
            this.SecFt_GrossProfitOther.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOther.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOther.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOther.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOther.DataField = "GrossProfitOther";
            this.SecFt_GrossProfitOther.Height = 0.156F;
            this.SecFt_GrossProfitOther.Left = 8.9375F;
            this.SecFt_GrossProfitOther.MultiLine = false;
            this.SecFt_GrossProfitOther.Name = "SecFt_GrossProfitOther";
            this.SecFt_GrossProfitOther.OutputFormat = resources.GetString("SecFt_GrossProfitOther.OutputFormat");
            this.SecFt_GrossProfitOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitOther.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfitOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfitOther.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfitOther.Text = "12,345,678,901";
            this.SecFt_GrossProfitOther.Top = 0.25F;
            this.SecFt_GrossProfitOther.Width = 0.85F;
            // 
            // SecFt_GrossProfitOtherCompRate
            // 
            this.SecFt_GrossProfitOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOtherCompRate.Height = 0.156F;
            this.SecFt_GrossProfitOtherCompRate.Left = 10.3075F;
            this.SecFt_GrossProfitOtherCompRate.MultiLine = false;
            this.SecFt_GrossProfitOtherCompRate.Name = "SecFt_GrossProfitOtherCompRate";
            this.SecFt_GrossProfitOtherCompRate.OutputFormat = resources.GetString("SecFt_GrossProfitOtherCompRate.OutputFormat");
            this.SecFt_GrossProfitOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitOtherCompRate.Text = "100.00%";
            this.SecFt_GrossProfitOtherCompRate.Top = 0.25F;
            this.SecFt_GrossProfitOtherCompRate.Width = 0.42F;
            // 
            // SecFt_GrossProfitOutsideCompRate
            // 
            this.SecFt_GrossProfitOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutsideCompRate.Height = 0.156F;
            this.SecFt_GrossProfitOutsideCompRate.Left = 9.7875F;
            this.SecFt_GrossProfitOutsideCompRate.MultiLine = false;
            this.SecFt_GrossProfitOutsideCompRate.Name = "SecFt_GrossProfitOutsideCompRate";
            this.SecFt_GrossProfitOutsideCompRate.OutputFormat = resources.GetString("SecFt_GrossProfitOutsideCompRate.OutputFormat");
            this.SecFt_GrossProfitOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitOutsideCompRate.Text = "100.00%";
            this.SecFt_GrossProfitOutsideCompRate.Top = 0.25F;
            this.SecFt_GrossProfitOutsideCompRate.Width = 0.42F;
            // 
            // SecFt_GrossProfitOutside
            // 
            this.SecFt_GrossProfitOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutside.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutside.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOutside.DataField = "GrossProfitOutside";
            this.SecFt_GrossProfitOutside.Height = 0.156F;
            this.SecFt_GrossProfitOutside.Left = 8.0875F;
            this.SecFt_GrossProfitOutside.MultiLine = false;
            this.SecFt_GrossProfitOutside.Name = "SecFt_GrossProfitOutside";
            this.SecFt_GrossProfitOutside.OutputFormat = resources.GetString("SecFt_GrossProfitOutside.OutputFormat");
            this.SecFt_GrossProfitOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitOutside.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfitOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfitOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfitOutside.Text = "12,345,678,901";
            this.SecFt_GrossProfitOutside.Top = 0.25F;
            this.SecFt_GrossProfitOutside.Width = 0.85F;
            // 
            // SecFt_GrossProfitPrm
            // 
            this.SecFt_GrossProfitPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrm.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrm.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrm.DataField = "GrossProfitPrm";
            this.SecFt_GrossProfitPrm.Height = 0.156F;
            this.SecFt_GrossProfitPrm.Left = 6.23F;
            this.SecFt_GrossProfitPrm.MultiLine = false;
            this.SecFt_GrossProfitPrm.Name = "SecFt_GrossProfitPrm";
            this.SecFt_GrossProfitPrm.OutputFormat = resources.GetString("SecFt_GrossProfitPrm.OutputFormat");
            this.SecFt_GrossProfitPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitPrm.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfitPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfitPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfitPrm.Text = "12,345,678,901";
            this.SecFt_GrossProfitPrm.Top = 0.25F;
            this.SecFt_GrossProfitPrm.Width = 0.85F;
            // 
            // SecFt_GrossProfitGenuine
            // 
            this.SecFt_GrossProfitGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuine.DataField = "GrossProfitGenuine";
            this.SecFt_GrossProfitGenuine.Height = 0.156F;
            this.SecFt_GrossProfitGenuine.Left = 5.38F;
            this.SecFt_GrossProfitGenuine.MultiLine = false;
            this.SecFt_GrossProfitGenuine.Name = "SecFt_GrossProfitGenuine";
            this.SecFt_GrossProfitGenuine.OutputFormat = resources.GetString("SecFt_GrossProfitGenuine.OutputFormat");
            this.SecFt_GrossProfitGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitGenuine.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfitGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfitGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfitGenuine.Text = "12,345,678,901";
            this.SecFt_GrossProfitGenuine.Top = 0.25F;
            this.SecFt_GrossProfitGenuine.Width = 0.85F;
            // 
            // SecFt_GrossProfitStock
            // 
            this.SecFt_GrossProfitStock.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStock.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStock.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStock.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStock.DataField = "GrossProfitStock";
            this.SecFt_GrossProfitStock.Height = 0.156F;
            this.SecFt_GrossProfitStock.Left = 3.5425F;
            this.SecFt_GrossProfitStock.MultiLine = false;
            this.SecFt_GrossProfitStock.Name = "SecFt_GrossProfitStock";
            this.SecFt_GrossProfitStock.OutputFormat = resources.GetString("SecFt_GrossProfitStock.OutputFormat");
            this.SecFt_GrossProfitStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitStock.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfitStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfitStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfitStock.Text = "12,345,678,901";
            this.SecFt_GrossProfitStock.Top = 0.25F;
            this.SecFt_GrossProfitStock.Width = 0.85F;
            // 
            // SecFt_GrossProfitOrder
            // 
            this.SecFt_GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrder.DataField = "GrossProfitOrder";
            this.SecFt_GrossProfitOrder.Height = 0.156F;
            this.SecFt_GrossProfitOrder.Left = 2.6925F;
            this.SecFt_GrossProfitOrder.MultiLine = false;
            this.SecFt_GrossProfitOrder.Name = "SecFt_GrossProfitOrder";
            this.SecFt_GrossProfitOrder.OutputFormat = resources.GetString("SecFt_GrossProfitOrder.OutputFormat");
            this.SecFt_GrossProfitOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitOrder.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfitOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfitOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfitOrder.Text = "12,345,678,901";
            this.SecFt_GrossProfitOrder.Top = 0.25F;
            this.SecFt_GrossProfitOrder.Width = 0.85F;
            // 
            // textBox85
            // 
            this.textBox85.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox85.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox85.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.RightColor = System.Drawing.Color.Black;
            this.textBox85.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Border.TopColor = System.Drawing.Color.Black;
            this.textBox85.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox85.Height = 0.156F;
            this.textBox85.Left = 10.2075F;
            this.textBox85.MultiLine = false;
            this.textBox85.Name = "textBox85";
            this.textBox85.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox85.Text = ":";
            this.textBox85.Top = 0.25F;
            this.textBox85.Width = 0.1F;
            // 
            // SecFt_GrossProfitPrmCompRate
            // 
            this.SecFt_GrossProfitPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitPrmCompRate.Height = 0.156F;
            this.SecFt_GrossProfitPrmCompRate.Left = 7.6F;
            this.SecFt_GrossProfitPrmCompRate.MultiLine = false;
            this.SecFt_GrossProfitPrmCompRate.Name = "SecFt_GrossProfitPrmCompRate";
            this.SecFt_GrossProfitPrmCompRate.OutputFormat = resources.GetString("SecFt_GrossProfitPrmCompRate.OutputFormat");
            this.SecFt_GrossProfitPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitPrmCompRate.Text = "100.00%";
            this.SecFt_GrossProfitPrmCompRate.Top = 0.25F;
            this.SecFt_GrossProfitPrmCompRate.Width = 0.42F;
            // 
            // SecFt_GrossProfitGenuineCompRate
            // 
            this.SecFt_GrossProfitGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitGenuineCompRate.Height = 0.156F;
            this.SecFt_GrossProfitGenuineCompRate.Left = 7.08F;
            this.SecFt_GrossProfitGenuineCompRate.MultiLine = false;
            this.SecFt_GrossProfitGenuineCompRate.Name = "SecFt_GrossProfitGenuineCompRate";
            this.SecFt_GrossProfitGenuineCompRate.OutputFormat = resources.GetString("SecFt_GrossProfitGenuineCompRate.OutputFormat");
            this.SecFt_GrossProfitGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitGenuineCompRate.Text = "100.00%";
            this.SecFt_GrossProfitGenuineCompRate.Top = 0.25F;
            this.SecFt_GrossProfitGenuineCompRate.Width = 0.42F;
            // 
            // textBox88
            // 
            this.textBox88.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox88.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox88.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.RightColor = System.Drawing.Color.Black;
            this.textBox88.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Border.TopColor = System.Drawing.Color.Black;
            this.textBox88.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox88.Height = 0.156F;
            this.textBox88.Left = 7.5F;
            this.textBox88.MultiLine = false;
            this.textBox88.Name = "textBox88";
            this.textBox88.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox88.Text = ":";
            this.textBox88.Top = 0.25F;
            this.textBox88.Width = 0.1F;
            // 
            // SecFt_GrossProfitStockCompRate
            // 
            this.SecFt_GrossProfitStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitStockCompRate.Height = 0.156F;
            this.SecFt_GrossProfitStockCompRate.Left = 4.9125F;
            this.SecFt_GrossProfitStockCompRate.MultiLine = false;
            this.SecFt_GrossProfitStockCompRate.Name = "SecFt_GrossProfitStockCompRate";
            this.SecFt_GrossProfitStockCompRate.OutputFormat = resources.GetString("SecFt_GrossProfitStockCompRate.OutputFormat");
            this.SecFt_GrossProfitStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitStockCompRate.Text = "100.00%";
            this.SecFt_GrossProfitStockCompRate.Top = 0.25F;
            this.SecFt_GrossProfitStockCompRate.Width = 0.42F;
            // 
            // SecFt_GrossProfitOrderCompRate
            // 
            this.SecFt_GrossProfitOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitOrderCompRate.Height = 0.156F;
            this.SecFt_GrossProfitOrderCompRate.Left = 4.3925F;
            this.SecFt_GrossProfitOrderCompRate.MultiLine = false;
            this.SecFt_GrossProfitOrderCompRate.Name = "SecFt_GrossProfitOrderCompRate";
            this.SecFt_GrossProfitOrderCompRate.OutputFormat = resources.GetString("SecFt_GrossProfitOrderCompRate.OutputFormat");
            this.SecFt_GrossProfitOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitOrderCompRate.Text = "100.00%";
            this.SecFt_GrossProfitOrderCompRate.Top = 0.25F;
            this.SecFt_GrossProfitOrderCompRate.Width = 0.42F;
            // 
            // textBox91
            // 
            this.textBox91.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox91.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox91.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.RightColor = System.Drawing.Color.Black;
            this.textBox91.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Border.TopColor = System.Drawing.Color.Black;
            this.textBox91.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox91.Height = 0.156F;
            this.textBox91.Left = 4.8125F;
            this.textBox91.MultiLine = false;
            this.textBox91.Name = "textBox91";
            this.textBox91.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox91.Text = ":";
            this.textBox91.Top = 0.25F;
            this.textBox91.Width = 0.1F;
            // 
            // SecFt_MonthSalesMoneyOther
            // 
            this.SecFt_MonthSalesMoneyOther.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOther.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOther.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOther.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOther.DataField = "MonthSalesMoneyOther";
            this.SecFt_MonthSalesMoneyOther.Height = 0.156F;
            this.SecFt_MonthSalesMoneyOther.Left = 8.9375F;
            this.SecFt_MonthSalesMoneyOther.MultiLine = false;
            this.SecFt_MonthSalesMoneyOther.Name = "SecFt_MonthSalesMoneyOther";
            this.SecFt_MonthSalesMoneyOther.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyOther.OutputFormat");
            this.SecFt_MonthSalesMoneyOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyOther.SummaryGroup = "SectionHeader";
            this.SecFt_MonthSalesMoneyOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthSalesMoneyOther.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthSalesMoneyOther.Text = "12,345,678,901";
            this.SecFt_MonthSalesMoneyOther.Top = 0.438F;
            this.SecFt_MonthSalesMoneyOther.Width = 0.85F;
            // 
            // SecFt_MonthSalesMoneyOtherCompRate
            // 
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOtherCompRate.Height = 0.156F;
            this.SecFt_MonthSalesMoneyOtherCompRate.Left = 10.3075F;
            this.SecFt_MonthSalesMoneyOtherCompRate.MultiLine = false;
            this.SecFt_MonthSalesMoneyOtherCompRate.Name = "SecFt_MonthSalesMoneyOtherCompRate";
            this.SecFt_MonthSalesMoneyOtherCompRate.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyOtherCompRate.OutputFormat");
            this.SecFt_MonthSalesMoneyOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyOtherCompRate.Text = "100.00%";
            this.SecFt_MonthSalesMoneyOtherCompRate.Top = 0.438F;
            this.SecFt_MonthSalesMoneyOtherCompRate.Width = 0.42F;
            // 
            // SecFt_MonthSalesMoneyOutsideCompRate
            // 
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Height = 0.156F;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Left = 9.7875F;
            this.SecFt_MonthSalesMoneyOutsideCompRate.MultiLine = false;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Name = "SecFt_MonthSalesMoneyOutsideCompRate";
            this.SecFt_MonthSalesMoneyOutsideCompRate.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyOutsideCompRate.OutputFormat");
            this.SecFt_MonthSalesMoneyOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyOutsideCompRate.Text = "100.00%";
            this.SecFt_MonthSalesMoneyOutsideCompRate.Top = 0.438F;
            this.SecFt_MonthSalesMoneyOutsideCompRate.Width = 0.42F;
            // 
            // SecFt_MonthSalesMoneyOutside
            // 
            this.SecFt_MonthSalesMoneyOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutside.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutside.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOutside.DataField = "MonthSalesMoneyOutside";
            this.SecFt_MonthSalesMoneyOutside.Height = 0.156F;
            this.SecFt_MonthSalesMoneyOutside.Left = 8.0875F;
            this.SecFt_MonthSalesMoneyOutside.MultiLine = false;
            this.SecFt_MonthSalesMoneyOutside.Name = "SecFt_MonthSalesMoneyOutside";
            this.SecFt_MonthSalesMoneyOutside.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyOutside.OutputFormat");
            this.SecFt_MonthSalesMoneyOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyOutside.SummaryGroup = "SectionHeader";
            this.SecFt_MonthSalesMoneyOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthSalesMoneyOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthSalesMoneyOutside.Text = "12,345,678,901";
            this.SecFt_MonthSalesMoneyOutside.Top = 0.438F;
            this.SecFt_MonthSalesMoneyOutside.Width = 0.85F;
            // 
            // SecFt_MonthSalesMoneyPrm
            // 
            this.SecFt_MonthSalesMoneyPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrm.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrm.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrm.DataField = "MonthSalesMoneyPrm";
            this.SecFt_MonthSalesMoneyPrm.Height = 0.156F;
            this.SecFt_MonthSalesMoneyPrm.Left = 6.23F;
            this.SecFt_MonthSalesMoneyPrm.MultiLine = false;
            this.SecFt_MonthSalesMoneyPrm.Name = "SecFt_MonthSalesMoneyPrm";
            this.SecFt_MonthSalesMoneyPrm.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyPrm.OutputFormat");
            this.SecFt_MonthSalesMoneyPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyPrm.SummaryGroup = "SectionHeader";
            this.SecFt_MonthSalesMoneyPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthSalesMoneyPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthSalesMoneyPrm.Text = "12,345,678,901";
            this.SecFt_MonthSalesMoneyPrm.Top = 0.438F;
            this.SecFt_MonthSalesMoneyPrm.Width = 0.85F;
            // 
            // SecFt_MonthSalesMoneyGenuine
            // 
            this.SecFt_MonthSalesMoneyGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuine.DataField = "MonthSalesMoneyGenuine";
            this.SecFt_MonthSalesMoneyGenuine.Height = 0.156F;
            this.SecFt_MonthSalesMoneyGenuine.Left = 5.38F;
            this.SecFt_MonthSalesMoneyGenuine.MultiLine = false;
            this.SecFt_MonthSalesMoneyGenuine.Name = "SecFt_MonthSalesMoneyGenuine";
            this.SecFt_MonthSalesMoneyGenuine.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyGenuine.OutputFormat");
            this.SecFt_MonthSalesMoneyGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyGenuine.SummaryGroup = "SectionHeader";
            this.SecFt_MonthSalesMoneyGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthSalesMoneyGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthSalesMoneyGenuine.Text = "12,345,678,901";
            this.SecFt_MonthSalesMoneyGenuine.Top = 0.438F;
            this.SecFt_MonthSalesMoneyGenuine.Width = 0.85F;
            // 
            // SecFt_MonthSalesMoneyStock
            // 
            this.SecFt_MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.SecFt_MonthSalesMoneyStock.Height = 0.156F;
            this.SecFt_MonthSalesMoneyStock.Left = 3.5425F;
            this.SecFt_MonthSalesMoneyStock.MultiLine = false;
            this.SecFt_MonthSalesMoneyStock.Name = "SecFt_MonthSalesMoneyStock";
            this.SecFt_MonthSalesMoneyStock.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyStock.OutputFormat");
            this.SecFt_MonthSalesMoneyStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyStock.SummaryGroup = "SectionHeader";
            this.SecFt_MonthSalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthSalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthSalesMoneyStock.Text = "12,345,678,901";
            this.SecFt_MonthSalesMoneyStock.Top = 0.438F;
            this.SecFt_MonthSalesMoneyStock.Width = 0.85F;
            // 
            // SecFt_MonthSalesMoneyOrder
            // 
            this.SecFt_MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.SecFt_MonthSalesMoneyOrder.Height = 0.156F;
            this.SecFt_MonthSalesMoneyOrder.Left = 2.6925F;
            this.SecFt_MonthSalesMoneyOrder.MultiLine = false;
            this.SecFt_MonthSalesMoneyOrder.Name = "SecFt_MonthSalesMoneyOrder";
            this.SecFt_MonthSalesMoneyOrder.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyOrder.OutputFormat");
            this.SecFt_MonthSalesMoneyOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyOrder.SummaryGroup = "SectionHeader";
            this.SecFt_MonthSalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthSalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthSalesMoneyOrder.Text = "12,345,678,901";
            this.SecFt_MonthSalesMoneyOrder.Top = 0.438F;
            this.SecFt_MonthSalesMoneyOrder.Width = 0.85F;
            // 
            // textBox100
            // 
            this.textBox100.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.RightColor = System.Drawing.Color.Black;
            this.textBox100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Border.TopColor = System.Drawing.Color.Black;
            this.textBox100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox100.Height = 0.156F;
            this.textBox100.Left = 10.2075F;
            this.textBox100.MultiLine = false;
            this.textBox100.Name = "textBox100";
            this.textBox100.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox100.Text = ":";
            this.textBox100.Top = 0.438F;
            this.textBox100.Width = 0.1F;
            // 
            // SecFt_MonthSalesMoneyPrmCompRate
            // 
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyPrmCompRate.Height = 0.156F;
            this.SecFt_MonthSalesMoneyPrmCompRate.Left = 7.6F;
            this.SecFt_MonthSalesMoneyPrmCompRate.MultiLine = false;
            this.SecFt_MonthSalesMoneyPrmCompRate.Name = "SecFt_MonthSalesMoneyPrmCompRate";
            this.SecFt_MonthSalesMoneyPrmCompRate.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyPrmCompRate.OutputFormat");
            this.SecFt_MonthSalesMoneyPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyPrmCompRate.Text = "100.00%";
            this.SecFt_MonthSalesMoneyPrmCompRate.Top = 0.438F;
            this.SecFt_MonthSalesMoneyPrmCompRate.Width = 0.42F;
            // 
            // SecFt_MonthSalesMoneyGenuineCompRate
            // 
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Height = 0.156F;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Left = 7.08F;
            this.SecFt_MonthSalesMoneyGenuineCompRate.MultiLine = false;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Name = "SecFt_MonthSalesMoneyGenuineCompRate";
            this.SecFt_MonthSalesMoneyGenuineCompRate.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyGenuineCompRate.OutputFormat");
            this.SecFt_MonthSalesMoneyGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyGenuineCompRate.Text = "100.00%";
            this.SecFt_MonthSalesMoneyGenuineCompRate.Top = 0.438F;
            this.SecFt_MonthSalesMoneyGenuineCompRate.Width = 0.42F;
            // 
            // textBox103
            // 
            this.textBox103.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.RightColor = System.Drawing.Color.Black;
            this.textBox103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Border.TopColor = System.Drawing.Color.Black;
            this.textBox103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox103.Height = 0.156F;
            this.textBox103.Left = 7.5F;
            this.textBox103.MultiLine = false;
            this.textBox103.Name = "textBox103";
            this.textBox103.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox103.Text = ":";
            this.textBox103.Top = 0.438F;
            this.textBox103.Width = 0.1F;
            // 
            // SecFt_MonthSalesMoneyStockCompRate
            // 
            this.SecFt_MonthSalesMoneyStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyStockCompRate.Height = 0.156F;
            this.SecFt_MonthSalesMoneyStockCompRate.Left = 4.9125F;
            this.SecFt_MonthSalesMoneyStockCompRate.MultiLine = false;
            this.SecFt_MonthSalesMoneyStockCompRate.Name = "SecFt_MonthSalesMoneyStockCompRate";
            this.SecFt_MonthSalesMoneyStockCompRate.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyStockCompRate.OutputFormat");
            this.SecFt_MonthSalesMoneyStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyStockCompRate.Text = "100.00%";
            this.SecFt_MonthSalesMoneyStockCompRate.Top = 0.438F;
            this.SecFt_MonthSalesMoneyStockCompRate.Width = 0.42F;
            // 
            // SecFt_MonthSalesMoneyOrderCompRate
            // 
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthSalesMoneyOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthSalesMoneyOrderCompRate.Height = 0.156F;
            this.SecFt_MonthSalesMoneyOrderCompRate.Left = 4.3925F;
            this.SecFt_MonthSalesMoneyOrderCompRate.MultiLine = false;
            this.SecFt_MonthSalesMoneyOrderCompRate.Name = "SecFt_MonthSalesMoneyOrderCompRate";
            this.SecFt_MonthSalesMoneyOrderCompRate.OutputFormat = resources.GetString("SecFt_MonthSalesMoneyOrderCompRate.OutputFormat");
            this.SecFt_MonthSalesMoneyOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthSalesMoneyOrderCompRate.Text = "100.00%";
            this.SecFt_MonthSalesMoneyOrderCompRate.Top = 0.438F;
            this.SecFt_MonthSalesMoneyOrderCompRate.Width = 0.42F;
            // 
            // textBox106
            // 
            this.textBox106.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.RightColor = System.Drawing.Color.Black;
            this.textBox106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Border.TopColor = System.Drawing.Color.Black;
            this.textBox106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox106.Height = 0.156F;
            this.textBox106.Left = 4.8125F;
            this.textBox106.MultiLine = false;
            this.textBox106.Name = "textBox106";
            this.textBox106.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox106.Text = ":";
            this.textBox106.Top = 0.438F;
            this.textBox106.Width = 0.1F;
            // 
            // SecFt_monthTotalTitle
            // 
            this.SecFt_monthTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_monthTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_monthTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_monthTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_monthTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_monthTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_monthTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_monthTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_monthTotalTitle.Height = 0.156F;
            this.SecFt_monthTotalTitle.Left = 2.375F;
            this.SecFt_monthTotalTitle.MultiLine = false;
            this.SecFt_monthTotalTitle.Name = "SecFt_monthTotalTitle";
            this.SecFt_monthTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SecFt_monthTotalTitle.Text = "累計";
            this.SecFt_monthTotalTitle.Top = 0.438F;
            this.SecFt_monthTotalTitle.Width = 0.3F;
            // 
            // SecFt_MonthGrossProfitOther
            // 
            this.SecFt_MonthGrossProfitOther.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOther.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOther.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOther.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOther.DataField = "MonthGrossProfitOther";
            this.SecFt_MonthGrossProfitOther.Height = 0.156F;
            this.SecFt_MonthGrossProfitOther.Left = 8.9375F;
            this.SecFt_MonthGrossProfitOther.MultiLine = false;
            this.SecFt_MonthGrossProfitOther.Name = "SecFt_MonthGrossProfitOther";
            this.SecFt_MonthGrossProfitOther.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOther.OutputFormat");
            this.SecFt_MonthGrossProfitOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOther.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitOther.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitOther.Text = "12,345,678,901";
            this.SecFt_MonthGrossProfitOther.Top = 0.625F;
            this.SecFt_MonthGrossProfitOther.Width = 0.85F;
            // 
            // SecFt_MonthGrossProfitOtherCompRate
            // 
            this.SecFt_MonthGrossProfitOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOtherCompRate.Height = 0.156F;
            this.SecFt_MonthGrossProfitOtherCompRate.Left = 10.3075F;
            this.SecFt_MonthGrossProfitOtherCompRate.MultiLine = false;
            this.SecFt_MonthGrossProfitOtherCompRate.Name = "SecFt_MonthGrossProfitOtherCompRate";
            this.SecFt_MonthGrossProfitOtherCompRate.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOtherCompRate.OutputFormat");
            this.SecFt_MonthGrossProfitOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOtherCompRate.Text = "100.00%";
            this.SecFt_MonthGrossProfitOtherCompRate.Top = 0.625F;
            this.SecFt_MonthGrossProfitOtherCompRate.Width = 0.42F;
            // 
            // SecFt_MonthGrossProfitOutsideCompRate
            // 
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutsideCompRate.Height = 0.156F;
            this.SecFt_MonthGrossProfitOutsideCompRate.Left = 9.7875F;
            this.SecFt_MonthGrossProfitOutsideCompRate.MultiLine = false;
            this.SecFt_MonthGrossProfitOutsideCompRate.Name = "SecFt_MonthGrossProfitOutsideCompRate";
            this.SecFt_MonthGrossProfitOutsideCompRate.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOutsideCompRate.OutputFormat");
            this.SecFt_MonthGrossProfitOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOutsideCompRate.Text = "100.00%";
            this.SecFt_MonthGrossProfitOutsideCompRate.Top = 0.625F;
            this.SecFt_MonthGrossProfitOutsideCompRate.Width = 0.42F;
            // 
            // SecFt_MonthGrossProfitOutside
            // 
            this.SecFt_MonthGrossProfitOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutside.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutside.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOutside.DataField = "MonthGrossProfitOutside";
            this.SecFt_MonthGrossProfitOutside.Height = 0.156F;
            this.SecFt_MonthGrossProfitOutside.Left = 8.0875F;
            this.SecFt_MonthGrossProfitOutside.MultiLine = false;
            this.SecFt_MonthGrossProfitOutside.Name = "SecFt_MonthGrossProfitOutside";
            this.SecFt_MonthGrossProfitOutside.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOutside.OutputFormat");
            this.SecFt_MonthGrossProfitOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOutside.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitOutside.Text = "12,345,678,901";
            this.SecFt_MonthGrossProfitOutside.Top = 0.625F;
            this.SecFt_MonthGrossProfitOutside.Width = 0.85F;
            // 
            // SecFt_MonthGrossProfitPrm
            // 
            this.SecFt_MonthGrossProfitPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrm.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrm.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrm.DataField = "MonthGrossProfitPrm";
            this.SecFt_MonthGrossProfitPrm.Height = 0.156F;
            this.SecFt_MonthGrossProfitPrm.Left = 6.23F;
            this.SecFt_MonthGrossProfitPrm.MultiLine = false;
            this.SecFt_MonthGrossProfitPrm.Name = "SecFt_MonthGrossProfitPrm";
            this.SecFt_MonthGrossProfitPrm.OutputFormat = resources.GetString("SecFt_MonthGrossProfitPrm.OutputFormat");
            this.SecFt_MonthGrossProfitPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitPrm.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitPrm.Text = "12,345,678,901";
            this.SecFt_MonthGrossProfitPrm.Top = 0.625F;
            this.SecFt_MonthGrossProfitPrm.Width = 0.85F;
            // 
            // SecFt_MonthGrossProfitGenuine
            // 
            this.SecFt_MonthGrossProfitGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuine.DataField = "MonthGrossProfitGenuine";
            this.SecFt_MonthGrossProfitGenuine.Height = 0.156F;
            this.SecFt_MonthGrossProfitGenuine.Left = 5.38F;
            this.SecFt_MonthGrossProfitGenuine.MultiLine = false;
            this.SecFt_MonthGrossProfitGenuine.Name = "SecFt_MonthGrossProfitGenuine";
            this.SecFt_MonthGrossProfitGenuine.OutputFormat = resources.GetString("SecFt_MonthGrossProfitGenuine.OutputFormat");
            this.SecFt_MonthGrossProfitGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitGenuine.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitGenuine.Text = "12,345,678,901";
            this.SecFt_MonthGrossProfitGenuine.Top = 0.625F;
            this.SecFt_MonthGrossProfitGenuine.Width = 0.85F;
            // 
            // SecFt_MonthGrossProfitStock
            // 
            this.SecFt_MonthGrossProfitStock.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStock.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStock.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStock.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStock.DataField = "MonthGrossProfitStock";
            this.SecFt_MonthGrossProfitStock.Height = 0.156F;
            this.SecFt_MonthGrossProfitStock.Left = 3.5425F;
            this.SecFt_MonthGrossProfitStock.MultiLine = false;
            this.SecFt_MonthGrossProfitStock.Name = "SecFt_MonthGrossProfitStock";
            this.SecFt_MonthGrossProfitStock.OutputFormat = resources.GetString("SecFt_MonthGrossProfitStock.OutputFormat");
            this.SecFt_MonthGrossProfitStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitStock.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitStock.Text = "12,345,678,901";
            this.SecFt_MonthGrossProfitStock.Top = 0.625F;
            this.SecFt_MonthGrossProfitStock.Width = 0.85F;
            // 
            // SecFt_MonthGrossProfitOrder
            // 
            this.SecFt_MonthGrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrder.DataField = "MonthGrossProfitOrder";
            this.SecFt_MonthGrossProfitOrder.Height = 0.156F;
            this.SecFt_MonthGrossProfitOrder.Left = 2.6925F;
            this.SecFt_MonthGrossProfitOrder.MultiLine = false;
            this.SecFt_MonthGrossProfitOrder.Name = "SecFt_MonthGrossProfitOrder";
            this.SecFt_MonthGrossProfitOrder.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOrder.OutputFormat");
            this.SecFt_MonthGrossProfitOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOrder.SummaryGroup = "SectionHeader";
            this.SecFt_MonthGrossProfitOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_MonthGrossProfitOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_MonthGrossProfitOrder.Text = "12,345,678,901";
            this.SecFt_MonthGrossProfitOrder.Top = 0.625F;
            this.SecFt_MonthGrossProfitOrder.Width = 0.85F;
            // 
            // textBox116
            // 
            this.textBox116.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox116.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox116.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.RightColor = System.Drawing.Color.Black;
            this.textBox116.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Border.TopColor = System.Drawing.Color.Black;
            this.textBox116.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox116.Height = 0.156F;
            this.textBox116.Left = 10.2075F;
            this.textBox116.MultiLine = false;
            this.textBox116.Name = "textBox116";
            this.textBox116.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox116.Text = ":";
            this.textBox116.Top = 0.625F;
            this.textBox116.Width = 0.1F;
            // 
            // SecFt_MonthGrossProfitPrmCompRate
            // 
            this.SecFt_MonthGrossProfitPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitPrmCompRate.Height = 0.156F;
            this.SecFt_MonthGrossProfitPrmCompRate.Left = 7.6F;
            this.SecFt_MonthGrossProfitPrmCompRate.MultiLine = false;
            this.SecFt_MonthGrossProfitPrmCompRate.Name = "SecFt_MonthGrossProfitPrmCompRate";
            this.SecFt_MonthGrossProfitPrmCompRate.OutputFormat = resources.GetString("SecFt_MonthGrossProfitPrmCompRate.OutputFormat");
            this.SecFt_MonthGrossProfitPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitPrmCompRate.Text = "100.00%";
            this.SecFt_MonthGrossProfitPrmCompRate.Top = 0.625F;
            this.SecFt_MonthGrossProfitPrmCompRate.Width = 0.42F;
            // 
            // SecFt_MonthGrossProfitGenuineCompRate
            // 
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitGenuineCompRate.Height = 0.156F;
            this.SecFt_MonthGrossProfitGenuineCompRate.Left = 7.08F;
            this.SecFt_MonthGrossProfitGenuineCompRate.MultiLine = false;
            this.SecFt_MonthGrossProfitGenuineCompRate.Name = "SecFt_MonthGrossProfitGenuineCompRate";
            this.SecFt_MonthGrossProfitGenuineCompRate.OutputFormat = resources.GetString("SecFt_MonthGrossProfitGenuineCompRate.OutputFormat");
            this.SecFt_MonthGrossProfitGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitGenuineCompRate.Text = "100.00%";
            this.SecFt_MonthGrossProfitGenuineCompRate.Top = 0.625F;
            this.SecFt_MonthGrossProfitGenuineCompRate.Width = 0.42F;
            // 
            // textBox119
            // 
            this.textBox119.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox119.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox119.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.RightColor = System.Drawing.Color.Black;
            this.textBox119.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Border.TopColor = System.Drawing.Color.Black;
            this.textBox119.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox119.Height = 0.156F;
            this.textBox119.Left = 7.5F;
            this.textBox119.MultiLine = false;
            this.textBox119.Name = "textBox119";
            this.textBox119.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox119.Text = ":";
            this.textBox119.Top = 0.625F;
            this.textBox119.Width = 0.1F;
            // 
            // SecFt_MonthGrossProfitStockCompRate
            // 
            this.SecFt_MonthGrossProfitStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitStockCompRate.Height = 0.156F;
            this.SecFt_MonthGrossProfitStockCompRate.Left = 4.9125F;
            this.SecFt_MonthGrossProfitStockCompRate.MultiLine = false;
            this.SecFt_MonthGrossProfitStockCompRate.Name = "SecFt_MonthGrossProfitStockCompRate";
            this.SecFt_MonthGrossProfitStockCompRate.OutputFormat = resources.GetString("SecFt_MonthGrossProfitStockCompRate.OutputFormat");
            this.SecFt_MonthGrossProfitStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitStockCompRate.Text = "100.00%";
            this.SecFt_MonthGrossProfitStockCompRate.Top = 0.625F;
            this.SecFt_MonthGrossProfitStockCompRate.Width = 0.42F;
            // 
            // SecFt_MonthGrossProfitOrderCompRate
            // 
            this.SecFt_MonthGrossProfitOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_MonthGrossProfitOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_MonthGrossProfitOrderCompRate.Height = 0.156F;
            this.SecFt_MonthGrossProfitOrderCompRate.Left = 4.3925F;
            this.SecFt_MonthGrossProfitOrderCompRate.MultiLine = false;
            this.SecFt_MonthGrossProfitOrderCompRate.Name = "SecFt_MonthGrossProfitOrderCompRate";
            this.SecFt_MonthGrossProfitOrderCompRate.OutputFormat = resources.GetString("SecFt_MonthGrossProfitOrderCompRate.OutputFormat");
            this.SecFt_MonthGrossProfitOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_MonthGrossProfitOrderCompRate.Text = "100.00%";
            this.SecFt_MonthGrossProfitOrderCompRate.Top = 0.625F;
            this.SecFt_MonthGrossProfitOrderCompRate.Width = 0.42F;
            // 
            // textBox122
            // 
            this.textBox122.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox122.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox122.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.RightColor = System.Drawing.Color.Black;
            this.textBox122.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Border.TopColor = System.Drawing.Color.Black;
            this.textBox122.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox122.Height = 0.156F;
            this.textBox122.Left = 4.8125F;
            this.textBox122.MultiLine = false;
            this.textBox122.Name = "textBox122";
            this.textBox122.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox122.Text = ":";
            this.textBox122.Top = 0.625F;
            this.textBox122.Width = 0.1F;
            // 
            // SectionTitle
            // 
            this.SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Height = 0.25F;
            this.SectionTitle.Left = 1.8125F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0.0625F;
            this.SectionTitle.Width = 0.5625F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 2F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // SecFt_Line1
            // 
            this.SecFt_Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line1.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line1.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line1.Height = 0.8F;
            this.SecFt_Line1.Left = 5.35F;
            this.SecFt_Line1.LineWeight = 1F;
            this.SecFt_Line1.Name = "SecFt_Line1";
            this.SecFt_Line1.Top = 0F;
            this.SecFt_Line1.Width = 0F;
            this.SecFt_Line1.X1 = 5.35F;
            this.SecFt_Line1.X2 = 5.35F;
            this.SecFt_Line1.Y1 = 0F;
            this.SecFt_Line1.Y2 = 0.8F;
            // 
            // SecFt_Line2
            // 
            this.SecFt_Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line2.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line2.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Line2.Height = 0.8F;
            this.SecFt_Line2.Left = 8.05F;
            this.SecFt_Line2.LineWeight = 1F;
            this.SecFt_Line2.Name = "SecFt_Line2";
            this.SecFt_Line2.Top = 0F;
            this.SecFt_Line2.Width = 0F;
            this.SecFt_Line2.X1 = 8.05F;
            this.SecFt_Line2.X2 = 8.05F;
            this.SecFt_Line2.Y1 = 0F;
            this.SecFt_Line2.Y2 = 0.8F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line2,
            this.Lb_Title,
            this.label1,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11});
            this.TitleHeader.Height = 0.2083333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 2F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 10.8F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.8F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
            // 
            // Lb_Title
            // 
            this.Lb_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Title.Height = 0.156F;
            this.Lb_Title.HyperLink = "";
            this.Lb_Title.Left = 0.063F;
            this.Lb_Title.MultiLine = false;
            this.Lb_Title.Name = "Lb_Title";
            this.Lb_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Title.Text = "得意先";
            this.Lb_Title.Top = 0.01F;
            this.Lb_Title.Width = 0.4375F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.156F;
            this.label1.HyperLink = "";
            this.label1.Left = 3.105F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "取寄";
            this.label1.Top = 0.01F;
            this.label1.Width = 0.4375F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.156F;
            this.label4.HyperLink = "";
            this.label4.Left = 3.955F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "在庫";
            this.label4.Top = 0.01F;
            this.label4.Width = 0.4375F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.156F;
            this.label5.HyperLink = "";
            this.label5.Left = 4.64375F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "対比率";
            this.label5.Top = 0.01F;
            this.label5.Width = 0.4375F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.156F;
            this.label6.HyperLink = "";
            this.label6.Left = 5.793F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "純正";
            this.label6.Top = 0.01F;
            this.label6.Width = 0.4375F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.156F;
            this.label7.HyperLink = "";
            this.label7.Left = 6.6425F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "優良";
            this.label7.Top = 0.01F;
            this.label7.Width = 0.4375F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.156F;
            this.label8.HyperLink = "";
            this.label8.Left = 7.33125F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "対比率";
            this.label8.Top = 0.01F;
            this.label8.Width = 0.4375F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.156F;
            this.label9.HyperLink = "";
            this.label9.Left = 8.5F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "外装";
            this.label9.Top = 0.01F;
            this.label9.Width = 0.4375F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.156F;
            this.label10.HyperLink = "";
            this.label10.Left = 9.35F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "その他";
            this.label10.Top = 0.01F;
            this.label10.Width = 0.4375F;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.156F;
            this.label11.HyperLink = "";
            this.label11.Left = 10.03875F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "対比率";
            this.label11.Top = 0.01F;
            this.label11.Width = 0.4375F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GraFt_SalesMoneyOther,
            this.GraFt_SalesMoneyOtherCompRate,
            this.GraFt_SalesMoneyOutsideCompRate,
            this.GraFt_SalesMoneyOutside,
            this.GraFt_SalesMoneyPrm,
            this.GraFt_SalesMoneyGenuine,
            this.GraFt_SalesMoneyStock,
            this.GraFt_SalesMoneyOrder,
            this.textBox131,
            this.GraFt_SalesMoneyPrmCompRate,
            this.GraFt_SalesMoneyGenuineCompRate,
            this.textBox134,
            this.GraFt_SalesMoneyStockCompRate,
            this.GraFt_SalesMoneyOrderCompRate,
            this.textBox137,
            this.GraFt_dayTotalTitle,
            this.GraFt_GrossProfitOther,
            this.GraFt_GrossProfitOtherCompRate,
            this.GraFt_GrossProfitOutsideCompRate,
            this.GraFt_GrossProfitOutside,
            this.GraFt_GrossProfitPrm,
            this.GraFt_GrossProfitGenuine,
            this.GraFt_GrossProfitStock,
            this.GraFt_GrossProfitOrder,
            this.textBox147,
            this.GraFt_GrossProfitPrmCompRate,
            this.GraFt_GrossProfitGenuineCompRate,
            this.textBox150,
            this.GraFt_GrossProfitStockCompRate,
            this.GraFt_GrossProfitOrderCompRate,
            this.textBox153,
            this.GraFt_MonthSalesMoneyOther,
            this.GraFt_MonthSalesMoneyOtherCompRate,
            this.GraFt_MonthSalesMoneyOutsideCompRate,
            this.GraFt_MonthSalesMoneyOutside,
            this.GraFt_MonthSalesMoneyPrm,
            this.GraFt_MonthSalesMoneyGenuine,
            this.GraFt_MonthSalesMoneyStock,
            this.GraFt_MonthSalesMoneyOrder,
            this.textBox162,
            this.GraFt_MonthSalesMoneyPrmCompRate,
            this.GraFt_MonthSalesMoneyGenuineCompRate,
            this.textBox165,
            this.GraFt_MonthSalesMoneyStockCompRate,
            this.GraFt_MonthSalesMoneyOrderCompRate,
            this.textBox168,
            this.GraFt_monthTotalTitle,
            this.GraFt_MonthGrossProfitOther,
            this.GraFt_MonthGrossProfitOtherCompRate,
            this.GraFt_MonthGrossProfitOutsideCompRate,
            this.GraFt_MonthGrossProfitOutside,
            this.GraFt_MonthGrossProfitPrm,
            this.GraFt_MonthGrossProfitGenuine,
            this.GraFt_MonthGrossProfitStock,
            this.GraFt_MonthGrossProfitOrder,
            this.textBox178,
            this.GraFt_MonthGrossProfitPrmCompRate,
            this.GraFt_MonthGrossProfitGenuineCompRate,
            this.textBox181,
            this.GraFt_MonthGrossProfitStockCompRate,
            this.GraFt_MonthGrossProfitOrderCompRate,
            this.textBox184,
            this.GrandTotalTitle,
            this.line6,
            this.GraFt_Line1,
            this.GraFt_Line2});
            this.GrandTotalFooter.Height = 0.84375F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GraFt_SalesMoneyOther
            // 
            this.GraFt_SalesMoneyOther.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOther.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOther.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOther.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOther.DataField = "SalesMoneyOther";
            this.GraFt_SalesMoneyOther.Height = 0.156F;
            this.GraFt_SalesMoneyOther.Left = 8.9375F;
            this.GraFt_SalesMoneyOther.MultiLine = false;
            this.GraFt_SalesMoneyOther.Name = "GraFt_SalesMoneyOther";
            this.GraFt_SalesMoneyOther.OutputFormat = resources.GetString("GraFt_SalesMoneyOther.OutputFormat");
            this.GraFt_SalesMoneyOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesMoneyOther.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesMoneyOther.Text = "12,345,678,901";
            this.GraFt_SalesMoneyOther.Top = 0.0625F;
            this.GraFt_SalesMoneyOther.Width = 0.85F;
            // 
            // GraFt_SalesMoneyOtherCompRate
            // 
            this.GraFt_SalesMoneyOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOtherCompRate.Height = 0.156F;
            this.GraFt_SalesMoneyOtherCompRate.Left = 10.3075F;
            this.GraFt_SalesMoneyOtherCompRate.MultiLine = false;
            this.GraFt_SalesMoneyOtherCompRate.Name = "GraFt_SalesMoneyOtherCompRate";
            this.GraFt_SalesMoneyOtherCompRate.OutputFormat = resources.GetString("GraFt_SalesMoneyOtherCompRate.OutputFormat");
            this.GraFt_SalesMoneyOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyOtherCompRate.Text = "100.00%";
            this.GraFt_SalesMoneyOtherCompRate.Top = 0.0625F;
            this.GraFt_SalesMoneyOtherCompRate.Width = 0.42F;
            // 
            // GraFt_SalesMoneyOutsideCompRate
            // 
            this.GraFt_SalesMoneyOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutsideCompRate.Height = 0.156F;
            this.GraFt_SalesMoneyOutsideCompRate.Left = 9.7875F;
            this.GraFt_SalesMoneyOutsideCompRate.MultiLine = false;
            this.GraFt_SalesMoneyOutsideCompRate.Name = "GraFt_SalesMoneyOutsideCompRate";
            this.GraFt_SalesMoneyOutsideCompRate.OutputFormat = resources.GetString("GraFt_SalesMoneyOutsideCompRate.OutputFormat");
            this.GraFt_SalesMoneyOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyOutsideCompRate.Text = "100.00%";
            this.GraFt_SalesMoneyOutsideCompRate.Top = 0.0625F;
            this.GraFt_SalesMoneyOutsideCompRate.Width = 0.42F;
            // 
            // GraFt_SalesMoneyOutside
            // 
            this.GraFt_SalesMoneyOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutside.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutside.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOutside.DataField = "SalesMoneyOutside";
            this.GraFt_SalesMoneyOutside.Height = 0.156F;
            this.GraFt_SalesMoneyOutside.Left = 8.0875F;
            this.GraFt_SalesMoneyOutside.MultiLine = false;
            this.GraFt_SalesMoneyOutside.Name = "GraFt_SalesMoneyOutside";
            this.GraFt_SalesMoneyOutside.OutputFormat = resources.GetString("GraFt_SalesMoneyOutside.OutputFormat");
            this.GraFt_SalesMoneyOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesMoneyOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesMoneyOutside.Text = "12,345,678,901";
            this.GraFt_SalesMoneyOutside.Top = 0.0625F;
            this.GraFt_SalesMoneyOutside.Width = 0.85F;
            // 
            // GraFt_SalesMoneyPrm
            // 
            this.GraFt_SalesMoneyPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrm.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrm.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrm.DataField = "SalesMoneyPrm";
            this.GraFt_SalesMoneyPrm.Height = 0.156F;
            this.GraFt_SalesMoneyPrm.Left = 6.23F;
            this.GraFt_SalesMoneyPrm.MultiLine = false;
            this.GraFt_SalesMoneyPrm.Name = "GraFt_SalesMoneyPrm";
            this.GraFt_SalesMoneyPrm.OutputFormat = resources.GetString("GraFt_SalesMoneyPrm.OutputFormat");
            this.GraFt_SalesMoneyPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesMoneyPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesMoneyPrm.Text = "12,345,678,901";
            this.GraFt_SalesMoneyPrm.Top = 0.0625F;
            this.GraFt_SalesMoneyPrm.Width = 0.85F;
            // 
            // GraFt_SalesMoneyGenuine
            // 
            this.GraFt_SalesMoneyGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuine.DataField = "SalesMoneyGenuine";
            this.GraFt_SalesMoneyGenuine.Height = 0.156F;
            this.GraFt_SalesMoneyGenuine.Left = 5.38F;
            this.GraFt_SalesMoneyGenuine.MultiLine = false;
            this.GraFt_SalesMoneyGenuine.Name = "GraFt_SalesMoneyGenuine";
            this.GraFt_SalesMoneyGenuine.OutputFormat = resources.GetString("GraFt_SalesMoneyGenuine.OutputFormat");
            this.GraFt_SalesMoneyGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesMoneyGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesMoneyGenuine.Text = "12,345,678,901";
            this.GraFt_SalesMoneyGenuine.Top = 0.0625F;
            this.GraFt_SalesMoneyGenuine.Width = 0.85F;
            // 
            // GraFt_SalesMoneyStock
            // 
            this.GraFt_SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStock.DataField = "SalesMoneyStock";
            this.GraFt_SalesMoneyStock.Height = 0.156F;
            this.GraFt_SalesMoneyStock.Left = 3.5425F;
            this.GraFt_SalesMoneyStock.MultiLine = false;
            this.GraFt_SalesMoneyStock.Name = "GraFt_SalesMoneyStock";
            this.GraFt_SalesMoneyStock.OutputFormat = resources.GetString("GraFt_SalesMoneyStock.OutputFormat");
            this.GraFt_SalesMoneyStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesMoneyStock.Text = "12,345,678,901";
            this.GraFt_SalesMoneyStock.Top = 0.0625F;
            this.GraFt_SalesMoneyStock.Width = 0.85F;
            // 
            // GraFt_SalesMoneyOrder
            // 
            this.GraFt_SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.GraFt_SalesMoneyOrder.Height = 0.156F;
            this.GraFt_SalesMoneyOrder.Left = 2.6925F;
            this.GraFt_SalesMoneyOrder.MultiLine = false;
            this.GraFt_SalesMoneyOrder.Name = "GraFt_SalesMoneyOrder";
            this.GraFt_SalesMoneyOrder.OutputFormat = resources.GetString("GraFt_SalesMoneyOrder.OutputFormat");
            this.GraFt_SalesMoneyOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesMoneyOrder.Text = "12,345,678,901";
            this.GraFt_SalesMoneyOrder.Top = 0.0625F;
            this.GraFt_SalesMoneyOrder.Width = 0.85F;
            // 
            // textBox131
            // 
            this.textBox131.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox131.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox131.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.RightColor = System.Drawing.Color.Black;
            this.textBox131.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Border.TopColor = System.Drawing.Color.Black;
            this.textBox131.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox131.Height = 0.156F;
            this.textBox131.Left = 10.2075F;
            this.textBox131.MultiLine = false;
            this.textBox131.Name = "textBox131";
            this.textBox131.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox131.Text = ":";
            this.textBox131.Top = 0.0625F;
            this.textBox131.Width = 0.1F;
            // 
            // GraFt_SalesMoneyPrmCompRate
            // 
            this.GraFt_SalesMoneyPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyPrmCompRate.Height = 0.156F;
            this.GraFt_SalesMoneyPrmCompRate.Left = 7.6F;
            this.GraFt_SalesMoneyPrmCompRate.MultiLine = false;
            this.GraFt_SalesMoneyPrmCompRate.Name = "GraFt_SalesMoneyPrmCompRate";
            this.GraFt_SalesMoneyPrmCompRate.OutputFormat = resources.GetString("GraFt_SalesMoneyPrmCompRate.OutputFormat");
            this.GraFt_SalesMoneyPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyPrmCompRate.Text = "100.00%";
            this.GraFt_SalesMoneyPrmCompRate.Top = 0.0625F;
            this.GraFt_SalesMoneyPrmCompRate.Width = 0.42F;
            // 
            // GraFt_SalesMoneyGenuineCompRate
            // 
            this.GraFt_SalesMoneyGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyGenuineCompRate.Height = 0.156F;
            this.GraFt_SalesMoneyGenuineCompRate.Left = 7.08F;
            this.GraFt_SalesMoneyGenuineCompRate.MultiLine = false;
            this.GraFt_SalesMoneyGenuineCompRate.Name = "GraFt_SalesMoneyGenuineCompRate";
            this.GraFt_SalesMoneyGenuineCompRate.OutputFormat = resources.GetString("GraFt_SalesMoneyGenuineCompRate.OutputFormat");
            this.GraFt_SalesMoneyGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyGenuineCompRate.Text = "100.00%";
            this.GraFt_SalesMoneyGenuineCompRate.Top = 0.0625F;
            this.GraFt_SalesMoneyGenuineCompRate.Width = 0.42F;
            // 
            // textBox134
            // 
            this.textBox134.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox134.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox134.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.RightColor = System.Drawing.Color.Black;
            this.textBox134.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Border.TopColor = System.Drawing.Color.Black;
            this.textBox134.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox134.Height = 0.156F;
            this.textBox134.Left = 7.5F;
            this.textBox134.MultiLine = false;
            this.textBox134.Name = "textBox134";
            this.textBox134.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox134.Text = ":";
            this.textBox134.Top = 0.0625F;
            this.textBox134.Width = 0.1F;
            // 
            // GraFt_SalesMoneyStockCompRate
            // 
            this.GraFt_SalesMoneyStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyStockCompRate.Height = 0.156F;
            this.GraFt_SalesMoneyStockCompRate.Left = 4.9125F;
            this.GraFt_SalesMoneyStockCompRate.MultiLine = false;
            this.GraFt_SalesMoneyStockCompRate.Name = "GraFt_SalesMoneyStockCompRate";
            this.GraFt_SalesMoneyStockCompRate.OutputFormat = resources.GetString("GraFt_SalesMoneyStockCompRate.OutputFormat");
            this.GraFt_SalesMoneyStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyStockCompRate.Text = "100.00%";
            this.GraFt_SalesMoneyStockCompRate.Top = 0.0625F;
            this.GraFt_SalesMoneyStockCompRate.Width = 0.42F;
            // 
            // GraFt_SalesMoneyOrderCompRate
            // 
            this.GraFt_SalesMoneyOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesMoneyOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesMoneyOrderCompRate.Height = 0.156F;
            this.GraFt_SalesMoneyOrderCompRate.Left = 4.3925F;
            this.GraFt_SalesMoneyOrderCompRate.MultiLine = false;
            this.GraFt_SalesMoneyOrderCompRate.Name = "GraFt_SalesMoneyOrderCompRate";
            this.GraFt_SalesMoneyOrderCompRate.OutputFormat = resources.GetString("GraFt_SalesMoneyOrderCompRate.OutputFormat");
            this.GraFt_SalesMoneyOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesMoneyOrderCompRate.Text = "100.00%";
            this.GraFt_SalesMoneyOrderCompRate.Top = 0.0625F;
            this.GraFt_SalesMoneyOrderCompRate.Width = 0.42F;
            // 
            // textBox137
            // 
            this.textBox137.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox137.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox137.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.RightColor = System.Drawing.Color.Black;
            this.textBox137.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Border.TopColor = System.Drawing.Color.Black;
            this.textBox137.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox137.Height = 0.156F;
            this.textBox137.Left = 4.8125F;
            this.textBox137.MultiLine = false;
            this.textBox137.Name = "textBox137";
            this.textBox137.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox137.Text = ":";
            this.textBox137.Top = 0.0625F;
            this.textBox137.Width = 0.1F;
            // 
            // GraFt_dayTotalTitle
            // 
            this.GraFt_dayTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_dayTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dayTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_dayTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dayTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_dayTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dayTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_dayTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_dayTotalTitle.Height = 0.156F;
            this.GraFt_dayTotalTitle.Left = 2.375F;
            this.GraFt_dayTotalTitle.MultiLine = false;
            this.GraFt_dayTotalTitle.Name = "GraFt_dayTotalTitle";
            this.GraFt_dayTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GraFt_dayTotalTitle.Text = "日計";
            this.GraFt_dayTotalTitle.Top = 0.0625F;
            this.GraFt_dayTotalTitle.Width = 0.3F;
            // 
            // GraFt_GrossProfitOther
            // 
            this.GraFt_GrossProfitOther.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOther.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOther.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOther.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOther.DataField = "GrossProfitOther";
            this.GraFt_GrossProfitOther.Height = 0.156F;
            this.GraFt_GrossProfitOther.Left = 8.9375F;
            this.GraFt_GrossProfitOther.MultiLine = false;
            this.GraFt_GrossProfitOther.Name = "GraFt_GrossProfitOther";
            this.GraFt_GrossProfitOther.OutputFormat = resources.GetString("GraFt_GrossProfitOther.OutputFormat");
            this.GraFt_GrossProfitOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfitOther.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfitOther.Text = "12,345,678,901";
            this.GraFt_GrossProfitOther.Top = 0.25F;
            this.GraFt_GrossProfitOther.Width = 0.85F;
            // 
            // GraFt_GrossProfitOtherCompRate
            // 
            this.GraFt_GrossProfitOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOtherCompRate.Height = 0.156F;
            this.GraFt_GrossProfitOtherCompRate.Left = 10.3075F;
            this.GraFt_GrossProfitOtherCompRate.MultiLine = false;
            this.GraFt_GrossProfitOtherCompRate.Name = "GraFt_GrossProfitOtherCompRate";
            this.GraFt_GrossProfitOtherCompRate.OutputFormat = resources.GetString("GraFt_GrossProfitOtherCompRate.OutputFormat");
            this.GraFt_GrossProfitOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitOtherCompRate.Text = "100.00%";
            this.GraFt_GrossProfitOtherCompRate.Top = 0.25F;
            this.GraFt_GrossProfitOtherCompRate.Width = 0.42F;
            // 
            // GraFt_GrossProfitOutsideCompRate
            // 
            this.GraFt_GrossProfitOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutsideCompRate.Height = 0.156F;
            this.GraFt_GrossProfitOutsideCompRate.Left = 9.7875F;
            this.GraFt_GrossProfitOutsideCompRate.MultiLine = false;
            this.GraFt_GrossProfitOutsideCompRate.Name = "GraFt_GrossProfitOutsideCompRate";
            this.GraFt_GrossProfitOutsideCompRate.OutputFormat = resources.GetString("GraFt_GrossProfitOutsideCompRate.OutputFormat");
            this.GraFt_GrossProfitOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitOutsideCompRate.Text = "100.00%";
            this.GraFt_GrossProfitOutsideCompRate.Top = 0.25F;
            this.GraFt_GrossProfitOutsideCompRate.Width = 0.42F;
            // 
            // GraFt_GrossProfitOutside
            // 
            this.GraFt_GrossProfitOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutside.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutside.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOutside.DataField = "GrossProfitOutside";
            this.GraFt_GrossProfitOutside.Height = 0.156F;
            this.GraFt_GrossProfitOutside.Left = 8.0875F;
            this.GraFt_GrossProfitOutside.MultiLine = false;
            this.GraFt_GrossProfitOutside.Name = "GraFt_GrossProfitOutside";
            this.GraFt_GrossProfitOutside.OutputFormat = resources.GetString("GraFt_GrossProfitOutside.OutputFormat");
            this.GraFt_GrossProfitOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfitOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfitOutside.Text = "12,345,678,901";
            this.GraFt_GrossProfitOutside.Top = 0.25F;
            this.GraFt_GrossProfitOutside.Width = 0.85F;
            // 
            // GraFt_GrossProfitPrm
            // 
            this.GraFt_GrossProfitPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrm.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrm.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrm.DataField = "GrossProfitPrm";
            this.GraFt_GrossProfitPrm.Height = 0.156F;
            this.GraFt_GrossProfitPrm.Left = 6.23F;
            this.GraFt_GrossProfitPrm.MultiLine = false;
            this.GraFt_GrossProfitPrm.Name = "GraFt_GrossProfitPrm";
            this.GraFt_GrossProfitPrm.OutputFormat = resources.GetString("GraFt_GrossProfitPrm.OutputFormat");
            this.GraFt_GrossProfitPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfitPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfitPrm.Text = "12,345,678,901";
            this.GraFt_GrossProfitPrm.Top = 0.25F;
            this.GraFt_GrossProfitPrm.Width = 0.85F;
            // 
            // GraFt_GrossProfitGenuine
            // 
            this.GraFt_GrossProfitGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuine.DataField = "GrossProfitGenuine";
            this.GraFt_GrossProfitGenuine.Height = 0.156F;
            this.GraFt_GrossProfitGenuine.Left = 5.38F;
            this.GraFt_GrossProfitGenuine.MultiLine = false;
            this.GraFt_GrossProfitGenuine.Name = "GraFt_GrossProfitGenuine";
            this.GraFt_GrossProfitGenuine.OutputFormat = resources.GetString("GraFt_GrossProfitGenuine.OutputFormat");
            this.GraFt_GrossProfitGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfitGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfitGenuine.Text = "12,345,678,901";
            this.GraFt_GrossProfitGenuine.Top = 0.25F;
            this.GraFt_GrossProfitGenuine.Width = 0.85F;
            // 
            // GraFt_GrossProfitStock
            // 
            this.GraFt_GrossProfitStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStock.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStock.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStock.DataField = "GrossProfitStock";
            this.GraFt_GrossProfitStock.Height = 0.156F;
            this.GraFt_GrossProfitStock.Left = 3.5425F;
            this.GraFt_GrossProfitStock.MultiLine = false;
            this.GraFt_GrossProfitStock.Name = "GraFt_GrossProfitStock";
            this.GraFt_GrossProfitStock.OutputFormat = resources.GetString("GraFt_GrossProfitStock.OutputFormat");
            this.GraFt_GrossProfitStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfitStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfitStock.Text = "12,345,678,901";
            this.GraFt_GrossProfitStock.Top = 0.25F;
            this.GraFt_GrossProfitStock.Width = 0.85F;
            // 
            // GraFt_GrossProfitOrder
            // 
            this.GraFt_GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrder.DataField = "GrossProfitOrder";
            this.GraFt_GrossProfitOrder.Height = 0.156F;
            this.GraFt_GrossProfitOrder.Left = 2.6925F;
            this.GraFt_GrossProfitOrder.MultiLine = false;
            this.GraFt_GrossProfitOrder.Name = "GraFt_GrossProfitOrder";
            this.GraFt_GrossProfitOrder.OutputFormat = resources.GetString("GraFt_GrossProfitOrder.OutputFormat");
            this.GraFt_GrossProfitOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfitOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfitOrder.Text = "12,345,678,901";
            this.GraFt_GrossProfitOrder.Top = 0.25F;
            this.GraFt_GrossProfitOrder.Width = 0.85F;
            // 
            // textBox147
            // 
            this.textBox147.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox147.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox147.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.RightColor = System.Drawing.Color.Black;
            this.textBox147.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Border.TopColor = System.Drawing.Color.Black;
            this.textBox147.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox147.Height = 0.156F;
            this.textBox147.Left = 10.2075F;
            this.textBox147.MultiLine = false;
            this.textBox147.Name = "textBox147";
            this.textBox147.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox147.Text = ":";
            this.textBox147.Top = 0.25F;
            this.textBox147.Width = 0.1F;
            // 
            // GraFt_GrossProfitPrmCompRate
            // 
            this.GraFt_GrossProfitPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitPrmCompRate.Height = 0.156F;
            this.GraFt_GrossProfitPrmCompRate.Left = 7.6F;
            this.GraFt_GrossProfitPrmCompRate.MultiLine = false;
            this.GraFt_GrossProfitPrmCompRate.Name = "GraFt_GrossProfitPrmCompRate";
            this.GraFt_GrossProfitPrmCompRate.OutputFormat = resources.GetString("GraFt_GrossProfitPrmCompRate.OutputFormat");
            this.GraFt_GrossProfitPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitPrmCompRate.Text = "100.00%";
            this.GraFt_GrossProfitPrmCompRate.Top = 0.25F;
            this.GraFt_GrossProfitPrmCompRate.Width = 0.42F;
            // 
            // GraFt_GrossProfitGenuineCompRate
            // 
            this.GraFt_GrossProfitGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitGenuineCompRate.Height = 0.156F;
            this.GraFt_GrossProfitGenuineCompRate.Left = 7.08F;
            this.GraFt_GrossProfitGenuineCompRate.MultiLine = false;
            this.GraFt_GrossProfitGenuineCompRate.Name = "GraFt_GrossProfitGenuineCompRate";
            this.GraFt_GrossProfitGenuineCompRate.OutputFormat = resources.GetString("GraFt_GrossProfitGenuineCompRate.OutputFormat");
            this.GraFt_GrossProfitGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitGenuineCompRate.Text = "100.00%";
            this.GraFt_GrossProfitGenuineCompRate.Top = 0.25F;
            this.GraFt_GrossProfitGenuineCompRate.Width = 0.42F;
            // 
            // textBox150
            // 
            this.textBox150.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox150.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox150.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.RightColor = System.Drawing.Color.Black;
            this.textBox150.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Border.TopColor = System.Drawing.Color.Black;
            this.textBox150.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox150.Height = 0.156F;
            this.textBox150.Left = 7.5F;
            this.textBox150.MultiLine = false;
            this.textBox150.Name = "textBox150";
            this.textBox150.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox150.Text = ":";
            this.textBox150.Top = 0.25F;
            this.textBox150.Width = 0.1F;
            // 
            // GraFt_GrossProfitStockCompRate
            // 
            this.GraFt_GrossProfitStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitStockCompRate.Height = 0.156F;
            this.GraFt_GrossProfitStockCompRate.Left = 4.9125F;
            this.GraFt_GrossProfitStockCompRate.MultiLine = false;
            this.GraFt_GrossProfitStockCompRate.Name = "GraFt_GrossProfitStockCompRate";
            this.GraFt_GrossProfitStockCompRate.OutputFormat = resources.GetString("GraFt_GrossProfitStockCompRate.OutputFormat");
            this.GraFt_GrossProfitStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitStockCompRate.Text = "100.00%";
            this.GraFt_GrossProfitStockCompRate.Top = 0.25F;
            this.GraFt_GrossProfitStockCompRate.Width = 0.42F;
            // 
            // GraFt_GrossProfitOrderCompRate
            // 
            this.GraFt_GrossProfitOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitOrderCompRate.Height = 0.156F;
            this.GraFt_GrossProfitOrderCompRate.Left = 4.3925F;
            this.GraFt_GrossProfitOrderCompRate.MultiLine = false;
            this.GraFt_GrossProfitOrderCompRate.Name = "GraFt_GrossProfitOrderCompRate";
            this.GraFt_GrossProfitOrderCompRate.OutputFormat = resources.GetString("GraFt_GrossProfitOrderCompRate.OutputFormat");
            this.GraFt_GrossProfitOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitOrderCompRate.Text = "100.00%";
            this.GraFt_GrossProfitOrderCompRate.Top = 0.25F;
            this.GraFt_GrossProfitOrderCompRate.Width = 0.42F;
            // 
            // textBox153
            // 
            this.textBox153.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox153.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox153.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.RightColor = System.Drawing.Color.Black;
            this.textBox153.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Border.TopColor = System.Drawing.Color.Black;
            this.textBox153.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox153.Height = 0.156F;
            this.textBox153.Left = 4.8125F;
            this.textBox153.MultiLine = false;
            this.textBox153.Name = "textBox153";
            this.textBox153.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox153.Text = ":";
            this.textBox153.Top = 0.25F;
            this.textBox153.Width = 0.1F;
            // 
            // GraFt_MonthSalesMoneyOther
            // 
            this.GraFt_MonthSalesMoneyOther.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOther.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOther.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOther.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOther.DataField = "MonthSalesMoneyOther";
            this.GraFt_MonthSalesMoneyOther.Height = 0.156F;
            this.GraFt_MonthSalesMoneyOther.Left = 8.9375F;
            this.GraFt_MonthSalesMoneyOther.MultiLine = false;
            this.GraFt_MonthSalesMoneyOther.Name = "GraFt_MonthSalesMoneyOther";
            this.GraFt_MonthSalesMoneyOther.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyOther.OutputFormat");
            this.GraFt_MonthSalesMoneyOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthSalesMoneyOther.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthSalesMoneyOther.Text = "12,345,678,901";
            this.GraFt_MonthSalesMoneyOther.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyOther.Width = 0.85F;
            // 
            // GraFt_MonthSalesMoneyOtherCompRate
            // 
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOtherCompRate.Height = 0.156F;
            this.GraFt_MonthSalesMoneyOtherCompRate.Left = 10.3075F;
            this.GraFt_MonthSalesMoneyOtherCompRate.MultiLine = false;
            this.GraFt_MonthSalesMoneyOtherCompRate.Name = "GraFt_MonthSalesMoneyOtherCompRate";
            this.GraFt_MonthSalesMoneyOtherCompRate.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyOtherCompRate.OutputFormat");
            this.GraFt_MonthSalesMoneyOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyOtherCompRate.Text = "100.00%";
            this.GraFt_MonthSalesMoneyOtherCompRate.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyOtherCompRate.Width = 0.42F;
            // 
            // GraFt_MonthSalesMoneyOutsideCompRate
            // 
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Height = 0.156F;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Left = 9.7875F;
            this.GraFt_MonthSalesMoneyOutsideCompRate.MultiLine = false;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Name = "GraFt_MonthSalesMoneyOutsideCompRate";
            this.GraFt_MonthSalesMoneyOutsideCompRate.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyOutsideCompRate.OutputFormat");
            this.GraFt_MonthSalesMoneyOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyOutsideCompRate.Text = "100.00%";
            this.GraFt_MonthSalesMoneyOutsideCompRate.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyOutsideCompRate.Width = 0.42F;
            // 
            // GraFt_MonthSalesMoneyOutside
            // 
            this.GraFt_MonthSalesMoneyOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutside.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutside.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOutside.DataField = "MonthSalesMoneyOutside";
            this.GraFt_MonthSalesMoneyOutside.Height = 0.156F;
            this.GraFt_MonthSalesMoneyOutside.Left = 8.0875F;
            this.GraFt_MonthSalesMoneyOutside.MultiLine = false;
            this.GraFt_MonthSalesMoneyOutside.Name = "GraFt_MonthSalesMoneyOutside";
            this.GraFt_MonthSalesMoneyOutside.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyOutside.OutputFormat");
            this.GraFt_MonthSalesMoneyOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthSalesMoneyOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthSalesMoneyOutside.Text = "12,345,678,901";
            this.GraFt_MonthSalesMoneyOutside.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyOutside.Width = 0.85F;
            // 
            // GraFt_MonthSalesMoneyPrm
            // 
            this.GraFt_MonthSalesMoneyPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrm.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrm.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrm.DataField = "MonthSalesMoneyPrm";
            this.GraFt_MonthSalesMoneyPrm.Height = 0.156F;
            this.GraFt_MonthSalesMoneyPrm.Left = 6.23F;
            this.GraFt_MonthSalesMoneyPrm.MultiLine = false;
            this.GraFt_MonthSalesMoneyPrm.Name = "GraFt_MonthSalesMoneyPrm";
            this.GraFt_MonthSalesMoneyPrm.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyPrm.OutputFormat");
            this.GraFt_MonthSalesMoneyPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthSalesMoneyPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthSalesMoneyPrm.Text = "12,345,678,901";
            this.GraFt_MonthSalesMoneyPrm.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyPrm.Width = 0.85F;
            // 
            // GraFt_MonthSalesMoneyGenuine
            // 
            this.GraFt_MonthSalesMoneyGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuine.DataField = "MonthSalesMoneyGenuine";
            this.GraFt_MonthSalesMoneyGenuine.Height = 0.156F;
            this.GraFt_MonthSalesMoneyGenuine.Left = 5.38F;
            this.GraFt_MonthSalesMoneyGenuine.MultiLine = false;
            this.GraFt_MonthSalesMoneyGenuine.Name = "GraFt_MonthSalesMoneyGenuine";
            this.GraFt_MonthSalesMoneyGenuine.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyGenuine.OutputFormat");
            this.GraFt_MonthSalesMoneyGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthSalesMoneyGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthSalesMoneyGenuine.Text = "12,345,678,901";
            this.GraFt_MonthSalesMoneyGenuine.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyGenuine.Width = 0.85F;
            // 
            // GraFt_MonthSalesMoneyStock
            // 
            this.GraFt_MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.GraFt_MonthSalesMoneyStock.Height = 0.156F;
            this.GraFt_MonthSalesMoneyStock.Left = 3.5425F;
            this.GraFt_MonthSalesMoneyStock.MultiLine = false;
            this.GraFt_MonthSalesMoneyStock.Name = "GraFt_MonthSalesMoneyStock";
            this.GraFt_MonthSalesMoneyStock.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyStock.OutputFormat");
            this.GraFt_MonthSalesMoneyStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthSalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthSalesMoneyStock.Text = "12,345,678,901";
            this.GraFt_MonthSalesMoneyStock.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyStock.Width = 0.85F;
            // 
            // GraFt_MonthSalesMoneyOrder
            // 
            this.GraFt_MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.GraFt_MonthSalesMoneyOrder.Height = 0.156F;
            this.GraFt_MonthSalesMoneyOrder.Left = 2.6925F;
            this.GraFt_MonthSalesMoneyOrder.MultiLine = false;
            this.GraFt_MonthSalesMoneyOrder.Name = "GraFt_MonthSalesMoneyOrder";
            this.GraFt_MonthSalesMoneyOrder.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyOrder.OutputFormat");
            this.GraFt_MonthSalesMoneyOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthSalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthSalesMoneyOrder.Text = "12,345,678,901";
            this.GraFt_MonthSalesMoneyOrder.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyOrder.Width = 0.85F;
            // 
            // textBox162
            // 
            this.textBox162.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox162.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox162.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Border.RightColor = System.Drawing.Color.Black;
            this.textBox162.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Border.TopColor = System.Drawing.Color.Black;
            this.textBox162.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox162.Height = 0.156F;
            this.textBox162.Left = 10.2075F;
            this.textBox162.MultiLine = false;
            this.textBox162.Name = "textBox162";
            this.textBox162.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox162.Text = ":";
            this.textBox162.Top = 0.4375F;
            this.textBox162.Width = 0.1F;
            // 
            // GraFt_MonthSalesMoneyPrmCompRate
            // 
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyPrmCompRate.Height = 0.156F;
            this.GraFt_MonthSalesMoneyPrmCompRate.Left = 7.6F;
            this.GraFt_MonthSalesMoneyPrmCompRate.MultiLine = false;
            this.GraFt_MonthSalesMoneyPrmCompRate.Name = "GraFt_MonthSalesMoneyPrmCompRate";
            this.GraFt_MonthSalesMoneyPrmCompRate.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyPrmCompRate.OutputFormat");
            this.GraFt_MonthSalesMoneyPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyPrmCompRate.Text = "100.00%";
            this.GraFt_MonthSalesMoneyPrmCompRate.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyPrmCompRate.Width = 0.42F;
            // 
            // GraFt_MonthSalesMoneyGenuineCompRate
            // 
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Height = 0.156F;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Left = 7.08F;
            this.GraFt_MonthSalesMoneyGenuineCompRate.MultiLine = false;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Name = "GraFt_MonthSalesMoneyGenuineCompRate";
            this.GraFt_MonthSalesMoneyGenuineCompRate.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyGenuineCompRate.OutputFormat");
            this.GraFt_MonthSalesMoneyGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyGenuineCompRate.Text = "100.00%";
            this.GraFt_MonthSalesMoneyGenuineCompRate.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyGenuineCompRate.Width = 0.42F;
            // 
            // textBox165
            // 
            this.textBox165.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox165.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox165.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Border.RightColor = System.Drawing.Color.Black;
            this.textBox165.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Border.TopColor = System.Drawing.Color.Black;
            this.textBox165.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox165.Height = 0.156F;
            this.textBox165.Left = 7.5F;
            this.textBox165.MultiLine = false;
            this.textBox165.Name = "textBox165";
            this.textBox165.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox165.Text = ":";
            this.textBox165.Top = 0.4375F;
            this.textBox165.Width = 0.1F;
            // 
            // GraFt_MonthSalesMoneyStockCompRate
            // 
            this.GraFt_MonthSalesMoneyStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyStockCompRate.Height = 0.156F;
            this.GraFt_MonthSalesMoneyStockCompRate.Left = 4.9125F;
            this.GraFt_MonthSalesMoneyStockCompRate.MultiLine = false;
            this.GraFt_MonthSalesMoneyStockCompRate.Name = "GraFt_MonthSalesMoneyStockCompRate";
            this.GraFt_MonthSalesMoneyStockCompRate.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyStockCompRate.OutputFormat");
            this.GraFt_MonthSalesMoneyStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyStockCompRate.Text = "100.00%";
            this.GraFt_MonthSalesMoneyStockCompRate.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyStockCompRate.Width = 0.42F;
            // 
            // GraFt_MonthSalesMoneyOrderCompRate
            // 
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthSalesMoneyOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthSalesMoneyOrderCompRate.Height = 0.156F;
            this.GraFt_MonthSalesMoneyOrderCompRate.Left = 4.3925F;
            this.GraFt_MonthSalesMoneyOrderCompRate.MultiLine = false;
            this.GraFt_MonthSalesMoneyOrderCompRate.Name = "GraFt_MonthSalesMoneyOrderCompRate";
            this.GraFt_MonthSalesMoneyOrderCompRate.OutputFormat = resources.GetString("GraFt_MonthSalesMoneyOrderCompRate.OutputFormat");
            this.GraFt_MonthSalesMoneyOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthSalesMoneyOrderCompRate.Text = "100.00%";
            this.GraFt_MonthSalesMoneyOrderCompRate.Top = 0.4375F;
            this.GraFt_MonthSalesMoneyOrderCompRate.Width = 0.42F;
            // 
            // textBox168
            // 
            this.textBox168.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox168.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox168.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Border.RightColor = System.Drawing.Color.Black;
            this.textBox168.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Border.TopColor = System.Drawing.Color.Black;
            this.textBox168.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox168.Height = 0.156F;
            this.textBox168.Left = 4.8125F;
            this.textBox168.MultiLine = false;
            this.textBox168.Name = "textBox168";
            this.textBox168.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox168.Text = ":";
            this.textBox168.Top = 0.4375F;
            this.textBox168.Width = 0.1F;
            // 
            // GraFt_monthTotalTitle
            // 
            this.GraFt_monthTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_monthTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_monthTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_monthTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_monthTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_monthTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_monthTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_monthTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_monthTotalTitle.Height = 0.156F;
            this.GraFt_monthTotalTitle.Left = 2.375F;
            this.GraFt_monthTotalTitle.MultiLine = false;
            this.GraFt_monthTotalTitle.Name = "GraFt_monthTotalTitle";
            this.GraFt_monthTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GraFt_monthTotalTitle.Text = "累計";
            this.GraFt_monthTotalTitle.Top = 0.4375F;
            this.GraFt_monthTotalTitle.Width = 0.3F;
            // 
            // GraFt_MonthGrossProfitOther
            // 
            this.GraFt_MonthGrossProfitOther.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOther.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOther.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOther.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOther.DataField = "MonthGrossProfitOther";
            this.GraFt_MonthGrossProfitOther.Height = 0.156F;
            this.GraFt_MonthGrossProfitOther.Left = 8.9375F;
            this.GraFt_MonthGrossProfitOther.MultiLine = false;
            this.GraFt_MonthGrossProfitOther.Name = "GraFt_MonthGrossProfitOther";
            this.GraFt_MonthGrossProfitOther.OutputFormat = resources.GetString("GraFt_MonthGrossProfitOther.OutputFormat");
            this.GraFt_MonthGrossProfitOther.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitOther.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthGrossProfitOther.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthGrossProfitOther.Text = "12,345,678,901";
            this.GraFt_MonthGrossProfitOther.Top = 0.625F;
            this.GraFt_MonthGrossProfitOther.Width = 0.85F;
            // 
            // GraFt_MonthGrossProfitOtherCompRate
            // 
            this.GraFt_MonthGrossProfitOtherCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOtherCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOtherCompRate.Height = 0.156F;
            this.GraFt_MonthGrossProfitOtherCompRate.Left = 10.3075F;
            this.GraFt_MonthGrossProfitOtherCompRate.MultiLine = false;
            this.GraFt_MonthGrossProfitOtherCompRate.Name = "GraFt_MonthGrossProfitOtherCompRate";
            this.GraFt_MonthGrossProfitOtherCompRate.OutputFormat = resources.GetString("GraFt_MonthGrossProfitOtherCompRate.OutputFormat");
            this.GraFt_MonthGrossProfitOtherCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitOtherCompRate.Text = "100.00%";
            this.GraFt_MonthGrossProfitOtherCompRate.Top = 0.625F;
            this.GraFt_MonthGrossProfitOtherCompRate.Width = 0.42F;
            // 
            // GraFt_MonthGrossProfitOutsideCompRate
            // 
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutsideCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutsideCompRate.Height = 0.156F;
            this.GraFt_MonthGrossProfitOutsideCompRate.Left = 9.7875F;
            this.GraFt_MonthGrossProfitOutsideCompRate.MultiLine = false;
            this.GraFt_MonthGrossProfitOutsideCompRate.Name = "GraFt_MonthGrossProfitOutsideCompRate";
            this.GraFt_MonthGrossProfitOutsideCompRate.OutputFormat = resources.GetString("GraFt_MonthGrossProfitOutsideCompRate.OutputFormat");
            this.GraFt_MonthGrossProfitOutsideCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitOutsideCompRate.Text = "100.00%";
            this.GraFt_MonthGrossProfitOutsideCompRate.Top = 0.625F;
            this.GraFt_MonthGrossProfitOutsideCompRate.Width = 0.42F;
            // 
            // GraFt_MonthGrossProfitOutside
            // 
            this.GraFt_MonthGrossProfitOutside.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutside.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutside.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutside.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutside.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutside.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutside.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOutside.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOutside.DataField = "MonthGrossProfitOutside";
            this.GraFt_MonthGrossProfitOutside.Height = 0.156F;
            this.GraFt_MonthGrossProfitOutside.Left = 8.0875F;
            this.GraFt_MonthGrossProfitOutside.MultiLine = false;
            this.GraFt_MonthGrossProfitOutside.Name = "GraFt_MonthGrossProfitOutside";
            this.GraFt_MonthGrossProfitOutside.OutputFormat = resources.GetString("GraFt_MonthGrossProfitOutside.OutputFormat");
            this.GraFt_MonthGrossProfitOutside.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitOutside.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthGrossProfitOutside.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthGrossProfitOutside.Text = "12,345,678,901";
            this.GraFt_MonthGrossProfitOutside.Top = 0.625F;
            this.GraFt_MonthGrossProfitOutside.Width = 0.85F;
            // 
            // GraFt_MonthGrossProfitPrm
            // 
            this.GraFt_MonthGrossProfitPrm.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrm.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrm.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrm.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrm.DataField = "MonthGrossProfitPrm";
            this.GraFt_MonthGrossProfitPrm.Height = 0.156F;
            this.GraFt_MonthGrossProfitPrm.Left = 6.23F;
            this.GraFt_MonthGrossProfitPrm.MultiLine = false;
            this.GraFt_MonthGrossProfitPrm.Name = "GraFt_MonthGrossProfitPrm";
            this.GraFt_MonthGrossProfitPrm.OutputFormat = resources.GetString("GraFt_MonthGrossProfitPrm.OutputFormat");
            this.GraFt_MonthGrossProfitPrm.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitPrm.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthGrossProfitPrm.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthGrossProfitPrm.Text = "12,345,678,901";
            this.GraFt_MonthGrossProfitPrm.Top = 0.625F;
            this.GraFt_MonthGrossProfitPrm.Width = 0.85F;
            // 
            // GraFt_MonthGrossProfitGenuine
            // 
            this.GraFt_MonthGrossProfitGenuine.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuine.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuine.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuine.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuine.DataField = "MonthGrossProfitGenuine";
            this.GraFt_MonthGrossProfitGenuine.Height = 0.156F;
            this.GraFt_MonthGrossProfitGenuine.Left = 5.38F;
            this.GraFt_MonthGrossProfitGenuine.MultiLine = false;
            this.GraFt_MonthGrossProfitGenuine.Name = "GraFt_MonthGrossProfitGenuine";
            this.GraFt_MonthGrossProfitGenuine.OutputFormat = resources.GetString("GraFt_MonthGrossProfitGenuine.OutputFormat");
            this.GraFt_MonthGrossProfitGenuine.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitGenuine.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthGrossProfitGenuine.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthGrossProfitGenuine.Text = "12,345,678,901";
            this.GraFt_MonthGrossProfitGenuine.Top = 0.625F;
            this.GraFt_MonthGrossProfitGenuine.Width = 0.85F;
            // 
            // GraFt_MonthGrossProfitStock
            // 
            this.GraFt_MonthGrossProfitStock.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStock.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStock.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStock.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStock.DataField = "MonthGrossProfitStock";
            this.GraFt_MonthGrossProfitStock.Height = 0.156F;
            this.GraFt_MonthGrossProfitStock.Left = 3.5425F;
            this.GraFt_MonthGrossProfitStock.MultiLine = false;
            this.GraFt_MonthGrossProfitStock.Name = "GraFt_MonthGrossProfitStock";
            this.GraFt_MonthGrossProfitStock.OutputFormat = resources.GetString("GraFt_MonthGrossProfitStock.OutputFormat");
            this.GraFt_MonthGrossProfitStock.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthGrossProfitStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthGrossProfitStock.Text = "12,345,678,901";
            this.GraFt_MonthGrossProfitStock.Top = 0.625F;
            this.GraFt_MonthGrossProfitStock.Width = 0.85F;
            // 
            // GraFt_MonthGrossProfitOrder
            // 
            this.GraFt_MonthGrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrder.DataField = "MonthGrossProfitOrder";
            this.GraFt_MonthGrossProfitOrder.Height = 0.156F;
            this.GraFt_MonthGrossProfitOrder.Left = 2.6925F;
            this.GraFt_MonthGrossProfitOrder.MultiLine = false;
            this.GraFt_MonthGrossProfitOrder.Name = "GraFt_MonthGrossProfitOrder";
            this.GraFt_MonthGrossProfitOrder.OutputFormat = resources.GetString("GraFt_MonthGrossProfitOrder.OutputFormat");
            this.GraFt_MonthGrossProfitOrder.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_MonthGrossProfitOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_MonthGrossProfitOrder.Text = "12,345,678,901";
            this.GraFt_MonthGrossProfitOrder.Top = 0.625F;
            this.GraFt_MonthGrossProfitOrder.Width = 0.85F;
            // 
            // textBox178
            // 
            this.textBox178.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox178.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox178.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Border.RightColor = System.Drawing.Color.Black;
            this.textBox178.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Border.TopColor = System.Drawing.Color.Black;
            this.textBox178.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox178.Height = 0.156F;
            this.textBox178.Left = 10.2075F;
            this.textBox178.MultiLine = false;
            this.textBox178.Name = "textBox178";
            this.textBox178.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox178.Text = ":";
            this.textBox178.Top = 0.625F;
            this.textBox178.Width = 0.1F;
            // 
            // GraFt_MonthGrossProfitPrmCompRate
            // 
            this.GraFt_MonthGrossProfitPrmCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitPrmCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitPrmCompRate.Height = 0.156F;
            this.GraFt_MonthGrossProfitPrmCompRate.Left = 7.6F;
            this.GraFt_MonthGrossProfitPrmCompRate.MultiLine = false;
            this.GraFt_MonthGrossProfitPrmCompRate.Name = "GraFt_MonthGrossProfitPrmCompRate";
            this.GraFt_MonthGrossProfitPrmCompRate.OutputFormat = resources.GetString("GraFt_MonthGrossProfitPrmCompRate.OutputFormat");
            this.GraFt_MonthGrossProfitPrmCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitPrmCompRate.Text = "100.00%";
            this.GraFt_MonthGrossProfitPrmCompRate.Top = 0.625F;
            this.GraFt_MonthGrossProfitPrmCompRate.Width = 0.42F;
            // 
            // GraFt_MonthGrossProfitGenuineCompRate
            // 
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitGenuineCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitGenuineCompRate.Height = 0.156F;
            this.GraFt_MonthGrossProfitGenuineCompRate.Left = 7.08F;
            this.GraFt_MonthGrossProfitGenuineCompRate.MultiLine = false;
            this.GraFt_MonthGrossProfitGenuineCompRate.Name = "GraFt_MonthGrossProfitGenuineCompRate";
            this.GraFt_MonthGrossProfitGenuineCompRate.OutputFormat = resources.GetString("GraFt_MonthGrossProfitGenuineCompRate.OutputFormat");
            this.GraFt_MonthGrossProfitGenuineCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitGenuineCompRate.Text = "100.00%";
            this.GraFt_MonthGrossProfitGenuineCompRate.Top = 0.625F;
            this.GraFt_MonthGrossProfitGenuineCompRate.Width = 0.42F;
            // 
            // textBox181
            // 
            this.textBox181.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox181.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox181.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Border.RightColor = System.Drawing.Color.Black;
            this.textBox181.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Border.TopColor = System.Drawing.Color.Black;
            this.textBox181.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox181.Height = 0.156F;
            this.textBox181.Left = 7.5F;
            this.textBox181.MultiLine = false;
            this.textBox181.Name = "textBox181";
            this.textBox181.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox181.Text = ":";
            this.textBox181.Top = 0.625F;
            this.textBox181.Width = 0.1F;
            // 
            // GraFt_MonthGrossProfitStockCompRate
            // 
            this.GraFt_MonthGrossProfitStockCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStockCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStockCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStockCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStockCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStockCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStockCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitStockCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitStockCompRate.Height = 0.156F;
            this.GraFt_MonthGrossProfitStockCompRate.Left = 4.9125F;
            this.GraFt_MonthGrossProfitStockCompRate.MultiLine = false;
            this.GraFt_MonthGrossProfitStockCompRate.Name = "GraFt_MonthGrossProfitStockCompRate";
            this.GraFt_MonthGrossProfitStockCompRate.OutputFormat = resources.GetString("GraFt_MonthGrossProfitStockCompRate.OutputFormat");
            this.GraFt_MonthGrossProfitStockCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitStockCompRate.Text = "100.00%";
            this.GraFt_MonthGrossProfitStockCompRate.Top = 0.625F;
            this.GraFt_MonthGrossProfitStockCompRate.Width = 0.42F;
            // 
            // GraFt_MonthGrossProfitOrderCompRate
            // 
            this.GraFt_MonthGrossProfitOrderCompRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_MonthGrossProfitOrderCompRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_MonthGrossProfitOrderCompRate.Height = 0.156F;
            this.GraFt_MonthGrossProfitOrderCompRate.Left = 4.3925F;
            this.GraFt_MonthGrossProfitOrderCompRate.MultiLine = false;
            this.GraFt_MonthGrossProfitOrderCompRate.Name = "GraFt_MonthGrossProfitOrderCompRate";
            this.GraFt_MonthGrossProfitOrderCompRate.OutputFormat = resources.GetString("GraFt_MonthGrossProfitOrderCompRate.OutputFormat");
            this.GraFt_MonthGrossProfitOrderCompRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_MonthGrossProfitOrderCompRate.Text = "100.00%";
            this.GraFt_MonthGrossProfitOrderCompRate.Top = 0.625F;
            this.GraFt_MonthGrossProfitOrderCompRate.Width = 0.42F;
            // 
            // textBox184
            // 
            this.textBox184.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox184.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox184.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Border.RightColor = System.Drawing.Color.Black;
            this.textBox184.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Border.TopColor = System.Drawing.Color.Black;
            this.textBox184.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox184.Height = 0.156F;
            this.textBox184.Left = 4.8125F;
            this.textBox184.MultiLine = false;
            this.textBox184.Name = "textBox184";
            this.textBox184.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox184.Text = ":";
            this.textBox184.Top = 0.625F;
            this.textBox184.Width = 0.1F;
            // 
            // GrandTotalTitle
            // 
            this.GrandTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Height = 0.25F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 1.8125F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.0625F;
            this.GrandTotalTitle.Width = 0.5625F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // GraFt_Line1
            // 
            this.GraFt_Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line1.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line1.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line1.Height = 0.8F;
            this.GraFt_Line1.Left = 5.35F;
            this.GraFt_Line1.LineWeight = 1F;
            this.GraFt_Line1.Name = "GraFt_Line1";
            this.GraFt_Line1.Top = 0F;
            this.GraFt_Line1.Width = 0F;
            this.GraFt_Line1.X1 = 5.35F;
            this.GraFt_Line1.X2 = 5.35F;
            this.GraFt_Line1.Y1 = 0F;
            this.GraFt_Line1.Y2 = 0.8F;
            // 
            // GraFt_Line2
            // 
            this.GraFt_Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line2.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line2.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Line2.Height = 0.8F;
            this.GraFt_Line2.Left = 8.05F;
            this.GraFt_Line2.LineWeight = 1F;
            this.GraFt_Line2.Name = "GraFt_Line2";
            this.GraFt_Line2.Top = 0F;
            this.GraFt_Line2.Width = 0F;
            this.GraFt_Line2.X1 = 8.05F;
            this.GraFt_Line2.X2 = 8.05F;
            this.GraFt_Line2.Y1 = 0F;
            this.GraFt_Line2.Y2 = 0.8F;
            // 
            // PMHNB02163P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.875F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMHNB02163P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dayTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesMoneyOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_dayTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox85)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox88)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox91)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthSalesMoneyOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_monthTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox119)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_MonthGrossProfitOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox131)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox134)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesMoneyOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox137)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_dayTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox147)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox153)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox162)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox165)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthSalesMoneyOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox168)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_monthTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOtherCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOutsideCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOutside)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitPrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitGenuine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox178)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitPrmCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitGenuineCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox181)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitStockCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_MonthGrossProfitOrderCompRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox184)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        
    }
}
