//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先別取引分布表
// プログラム概要   : 得意先別取引分布表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/11/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13152
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 河原林 一生
// 修 正 日  2014/06/10  修正内容 : PMNS仕掛一覧No.2441(順位の桁数不正対応)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 河原林 一生
// 修 正 日  2014/06/24  修正内容 : PMNS仕掛一覧No.2441(金額の桁数拡張対応)
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 得意先別取引分布表帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 得意先別取引分布表帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.21</br>
    /// <br>Update Note  : 2009/04/07 30452 上野 俊治</br>
    /// <br>              ・障害対応13152</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMHNB02183P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02183P_01A4C()
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

        private CustSalesDistributionReportParam _custSalesDistributionReportParam;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        #region ActiveReport生成
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Label tb_ReportTitle;
        private Line Line1;
        private Label Label3;
        private TextBox tb_PrintDate;
        private TextBox tb_PrintTime;
        private Label Label2;
        private TextBox tb_PrintPage;
        private SubReport Header_SubReport;
        private Line line3;
        private Label Lb_Title;
        private Line Line2;
        private TextBox SecHd_SectionCode;
        private TextBox SecHd_SectionGuideNm;
        private TextBox CodeName;
        private TextBox Code;
        private TextBox Order;
        private Label label1;
        private Label lbl_CodeTitle;
        private Label lbl_Month8;
        private Label lbl_Month9;
        private Label lbl_Month10;
        private Label lbl_Month11;
        private Label lbl_Month12;
        private Label lbl_Month13;
        private Label lbl_Month14;
        private Label lbl_Month15;
        private Label lbl_Month16;
        private Label lbl_Month17;
        private Label lbl_Month18;
        private Label lbl_Month19;
        private Label lbl_Month20;
        private Label lbl_Month21;
        private Label lbl_Month22;
        private Label lbl_Month23;
        private Label lbl_Month24;
        private Label lbl_Month25;
        private Label lbl_Month26;
        private Label lbl_Month27;
        private Label lbl_Month28;
        private Label lbl_Month29;
        private Label lbl_Month30;
        private Label lbl_Month31;
        private Label lbl_Month1;
        private Label lbl_Month2;
        private Label lbl_Month3;
        private Label lbl_Month4;
        private Label lbl_Month5;
        private Label lbl_Month6;
        private Label lbl_Month7;
        private Label lbl_Day1;
        private Label lbl_Day9;
        private Label lbl_Day10;
        private Label lbl_Day11;
        private Label lbl_Day12;
        private Label lbl_Day13;
        private Label lbl_Day14;
        private Label lbl_Day15;
        private Label lbl_Day16;
        private Label lbl_Day17;
        private Label lbl_Day18;
        private Label lbl_Day19;
        private Label lbl_Day20;
        private Label lbl_Day21;
        private Label lbl_Day22;
        private Label lbl_Day23;
        private Label lbl_Day24;
        private Label lbl_Day25;
        private Label lbl_Day26;
        private Label lbl_Day27;
        private Label lbl_Day28;
        private Label lbl_Day29;
        private Label lbl_Day30;
        private Label lbl_Day31;
        private Label lbl_Day8;
        private Label lbl_Day2;
        private Label lbl_Day3;
        private Label lbl_Day4;
        private Label lbl_Day5;
        private Label lbl_Day6;
        private Label lbl_Day7;
        private Label lbl_Dow1;
        private Label lbl_Dow9;
        private Label lbl_Dow10;
        private Label lbl_Dow11;
        private Label lbl_Dow12;
        private Label lbl_Dow13;
        private Label lbl_Dow14;
        private Label lbl_Dow15;
        private Label lbl_Dow16;
        private Label lbl_Dow17;
        private Label lbl_Dow18;
        private Label lbl_Dow19;
        private Label lbl_Dow20;
        private Label lbl_Dow21;
        private Label lbl_Dow22;
        private Label lbl_Dow23;
        private Label lbl_Dow24;
        private Label lbl_Dow25;
        private Label lbl_Dow26;
        private Label lbl_Dow27;
        private Label lbl_Dow28;
        private Label lbl_Dow29;
        private Label lbl_Dow30;
        private Label lbl_Dow31;
        private Label lbl_Dow8;
        private Label lbl_Dow2;
        private Label lbl_Dow3;
        private Label lbl_Dow4;
        private Label lbl_Dow5;
        private Label lbl_Dow6;
        private Label lbl_Dow7;
        private TextBox Asterisk2;
        private TextBox Asterisk1;
        private TextBox Asterisk4;
        private TextBox Asterisk3;
        private TextBox Asterisk10;
        private TextBox Asterisk11;
        private TextBox Asterisk9;
        private TextBox Asterisk6;
        private TextBox Asterisk5;
        private TextBox Asterisk7;
        private TextBox Asterisk8;
        private TextBox Asterisk13;
        private TextBox Asterisk12;
        private TextBox Asterisk16;
        private TextBox Asterisk15;
        private TextBox Asterisk20;
        private TextBox Asterisk22;
        private TextBox Asterisk21;
        private TextBox Asterisk14;
        private TextBox Asterisk18;
        private TextBox Asterisk17;
        private TextBox Asterisk19;
        private TextBox GrossProfitAverage;
        private TextBox GrossProfitRate;
        private Label label98;
        private Label label99;
        private Label label100;
        private TextBox GrossProfit;
        private TextBox SalesAverage;
        private TextBox SalesTotalTaxExc;
        private TextBox SalesCount;
        private TextBox Asterisk23;
        private TextBox Asterisk27;
        private TextBox Asterisk28;
        private TextBox Asterisk30;
        private TextBox Asterisk29;
        private TextBox Asterisk25;
        private TextBox Asterisk24;
        private TextBox Asterisk26;
        private TextBox Asterisk31;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label5;
        private SubReport Footer_SubReport;
        private Label GrandTotalTitle;
        private TextBox SectionTitle;
        private TextBox SecFt_SalesCount;
        private TextBox SecFt_SalesTotalTaxExc;
        private TextBox SecFt_SalesAverage;
        private TextBox SecFt_GrossProfit;
        private TextBox SecFt_GrossProfitAverage;
        private TextBox SecFt_GrossProfitRate;
        private TextBox GraFt_SalesCount;
        private TextBox GraFt_SalesTotalTaxExc;
        private TextBox GraFt_SalesAverage;
        private TextBox GraFt_GrossProfit;
        private TextBox GraFt_GrossProfitAverage;
        private TextBox GraFt_GrossProfitRate;
        private TextBox BusinessDays;
        private TextBox SecFt_BusinessDays;
        private Line line5;
        private Line line4;
        private Line line6;
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
                this._custSalesDistributionReportParam = (CustSalesDistributionReportParam)this._printInfo.jyoken;
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

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //-------------------------------------------------------
            // TitleHeader設定
            //-------------------------------------------------------
            #region [TitleHeader設定]
            if (_custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                this.lbl_CodeTitle.Text = "得意先";
            }
            else if (_custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                this.lbl_CodeTitle.Text = "担当者";
            }
            else // 地区
            {
                this.lbl_CodeTitle.Text = "地区";
            }

            // 売上日付情報の設定
            // 作業用リスト
            // 月
            List<Label> monthList = new List<Label>();
            monthList.AddRange(new Label[] { lbl_Month1,  lbl_Month2,  lbl_Month3,  lbl_Month4,  lbl_Month5,  lbl_Month6,  lbl_Month7,  lbl_Month8,  lbl_Month9,  lbl_Month10, 
                                             lbl_Month11, lbl_Month12, lbl_Month13, lbl_Month14, lbl_Month15, lbl_Month16, lbl_Month17, lbl_Month18, lbl_Month19, lbl_Month20,
                                             lbl_Month21, lbl_Month22, lbl_Month23, lbl_Month24, lbl_Month25, lbl_Month26, lbl_Month27, lbl_Month28, lbl_Month29, lbl_Month30,
                                             lbl_Month31});
            // 日
            List<Label> dayList = new List<Label>();
            dayList.AddRange(new Label[] { lbl_Day1,  lbl_Day2,  lbl_Day3,  lbl_Day4,  lbl_Day5,  lbl_Day6,  lbl_Day7,  lbl_Day8,  lbl_Day9,  lbl_Day10, 
                                             lbl_Day11, lbl_Day12, lbl_Day13, lbl_Day14, lbl_Day15, lbl_Day16, lbl_Day17, lbl_Day18, lbl_Day19, lbl_Day20,
                                             lbl_Day21, lbl_Day22, lbl_Day23, lbl_Day24, lbl_Day25, lbl_Day26, lbl_Day27, lbl_Day28, lbl_Day29, lbl_Day30,
                                             lbl_Day31});
            // 曜日
            List<Label> dowList = new List<Label>();
            dowList.AddRange(new Label[] { lbl_Dow1,  lbl_Dow2,  lbl_Dow3,  lbl_Dow4,  lbl_Dow5,  lbl_Dow6,  lbl_Dow7,  lbl_Dow8,  lbl_Dow9,  lbl_Dow10, 
                                             lbl_Dow11, lbl_Dow12, lbl_Dow13, lbl_Dow14, lbl_Dow15, lbl_Dow16, lbl_Dow17, lbl_Dow18, lbl_Dow19, lbl_Dow20,
                                             lbl_Dow21, lbl_Dow22, lbl_Dow23, lbl_Dow24, lbl_Dow25, lbl_Dow26, lbl_Dow27, lbl_Dow28, lbl_Dow29, lbl_Dow30,
                                             lbl_Dow31});

            // 期首日
            DateTime startday = this._custSalesDistributionReportParam.StartDate;
            // 1か月後まで
            DateTime endday = startday.AddMonths(1);

            DateTime workDate = startday;
            for (int i = 0; endday.CompareTo(workDate) > 0; i++)
            {
                if (i == 0 || workDate.Day == 1)
                {
                    // １日の場合、月を表示
                    monthList[i].Visible = true;
                    monthList[i].Text = workDate.Month.ToString();
                }

                // 日
                dayList[i].Visible = true;
                dayList[i].Text = workDate.Day.ToString();

                // 曜日（略称）
                dowList[i].Visible = true;
                dowList[i].Text = workDate.ToString("ddd");

                workDate = workDate.AddDays(1);
            }

            #endregion

            //-------------------------------------------------------
            // 改頁設定
            // 0:する（拠点毎） 1:しない
            //-------------------------------------------------------
            #region [改頁設定]
            if (this._custSalesDistributionReportParam.NewPageDiv == CustSalesDistributionReportParam.NewPageDivState.Section)
            {
                SectionHeader.NewPage = NewPage.Before;
            }

            #endregion

            //-------------------------------------------------------
            // 明細設定
            //-------------------------------------------------------
            #region [明細設定]
            if (_custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Customer)
            {
                this.Code.DataField = PMHNB02185EB.ct_Col_CustomerCode;
                this.Code.OutputFormat = "00000000";

                this.CodeName.DataField = PMHNB02185EB.ct_Col_CustomerSnm;
            }
            else if (_custSalesDistributionReportParam.PrintType == CustSalesDistributionReportParam.PrintTypeState.Employee)
            {
                this.Code.DataField = PMHNB02185EB.ct_Col_SalesEmployeeCd;
                this.Code.OutputFormat = "0000";

                this.CodeName.DataField = PMHNB02185EB.ct_Col_SalesEmployeeNm;
            }
            else
            {
                this.Code.DataField = PMHNB02185EB.ct_Col_SalesAreaCode;
                this.Code.OutputFormat = "0000";

                this.CodeName.DataField = PMHNB02185EB.ct_Col_SalesAreaName;
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
            double denominator = Convert.ToDouble(denominatorBox.Text);

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
            if (workRate < 0) workRate = workRate * -1;

            return workRate;
        }

        /// <summary>
        /// 平均計算処理
        /// </summary>
        /// <param name="numeratorBox">分子</param>
        /// <param name="denominatorBox">分母</param>
        private double GetAverage(TextBox numeratorBox, TextBox denominatorBox)
        {
            double numerator = Convert.ToDouble(numeratorBox.Text);
            double denominator = Convert.ToDouble(denominatorBox.Text);

            double ratio = this.GetAverage(numerator, denominator);

            return ratio;
        }

        /// <summary>
        /// 平均取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetAverage(double numerator, double denominator)
        {
            double workRate;

            if (denominator == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numerator / denominator);
            }

            return workRate;
        }
        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMHNB02183P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02183P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageHeader_Format(object sender, EventArgs e)
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
        /// <param name="e"></param>
        private void ExtraHeader_Format(object sender, EventArgs e)
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
        /// Detail_AfterPrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値は表示しない
            if (string.IsNullOrEmpty(this.Code.Text)
                || Convert.ToInt32(this.Code.Text) == 0)
            {
                this.Code.Text = "";
                this.CodeName.Text = "";
            }

            // 平均計算
            this.SalesAverage.Value = GetAverage(this.SalesTotalTaxExc, this.BusinessDays); // 売上平均
            this.GrossProfitAverage.Value = GetAverage(this.GrossProfit, this.BusinessDays); // 粗利平均

            // 率計算
            this.GrossProfitRate.Value = GetRatio(this.GrossProfit, this.SalesTotalTaxExc); // 粗利率
        }

        /// <summary>
        /// SectionFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 平均計算
            this.SecFt_SalesAverage.Value = GetAverage(this.SecFt_SalesTotalTaxExc, this.SecFt_BusinessDays); // 売上平均
            this.SecFt_GrossProfitAverage.Value = GetAverage(this.SecFt_GrossProfit, this.SecFt_BusinessDays); // 粗利平均

            // 率計算
            this.SecFt_GrossProfitRate.Value = GetRatio(this.SecFt_GrossProfit, this.SecFt_SalesTotalTaxExc); // 粗利率
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 率計算
            this.GraFt_GrossProfitRate.Value = GetRatio(this.GraFt_GrossProfit, this.GraFt_SalesTotalTaxExc); // 粗利率
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMHNB02183P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.CodeName = new DataDynamics.ActiveReports.TextBox();
            this.Code = new DataDynamics.ActiveReports.TextBox();
            this.Order = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk2 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk1 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk4 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk3 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk10 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk11 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk9 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk6 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk5 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk7 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk8 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk13 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk12 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk16 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk15 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk20 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk22 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk21 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk14 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk18 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk17 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk19 = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitAverage = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SalesAverage = new DataDynamics.ActiveReports.TextBox();
            this.SalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk23 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk27 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk28 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk30 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk29 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk25 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk24 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk26 = new DataDynamics.ActiveReports.TextBox();
            this.Asterisk31 = new DataDynamics.ActiveReports.TextBox();
            this.BusinessDays = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_Title = new DataDynamics.ActiveReports.Label();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.lbl_CodeTitle = new DataDynamics.ActiveReports.Label();
            this.lbl_Month8 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month9 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month10 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month11 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month12 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month13 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month14 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month15 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month16 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month17 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month18 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month19 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month20 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month21 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month22 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month23 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month24 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month25 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month26 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month27 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month28 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month29 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month30 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month31 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month1 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month2 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month3 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month4 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month5 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month6 = new DataDynamics.ActiveReports.Label();
            this.lbl_Month7 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day1 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day9 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day10 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day11 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day12 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day13 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day14 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day15 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day16 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day17 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day18 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day19 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day20 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day21 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day22 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day23 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day24 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day25 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day26 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day27 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day28 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day29 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day30 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day31 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day8 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day2 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day3 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day4 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day5 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day6 = new DataDynamics.ActiveReports.Label();
            this.lbl_Day7 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow1 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow9 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow10 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow11 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow12 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow13 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow14 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow15 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow16 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow17 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow18 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow19 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow20 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow21 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow22 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow23 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow24 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow25 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow26 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow27 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow28 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow29 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow30 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow31 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow8 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow2 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow3 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow4 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow5 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow6 = new DataDynamics.ActiveReports.Label();
            this.lbl_Dow7 = new DataDynamics.ActiveReports.Label();
            this.label98 = new DataDynamics.ActiveReports.Label();
            this.label99 = new DataDynamics.ActiveReports.Label();
            this.label100 = new DataDynamics.ActiveReports.Label();
            this.label101 = new DataDynamics.ActiveReports.Label();
            this.label102 = new DataDynamics.ActiveReports.Label();
            this.label103 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.GraFt_SalesCount = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_SalesAverage = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitAverage = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SecHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesCount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_SalesAverage = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitAverage = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_BusinessDays = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_CodeTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label99)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label103)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_BusinessDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.Label3,
            this.tb_PrintDate,
            this.tb_PrintTime,
            this.Label2,
            this.tb_PrintPage});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.tb_ReportTitle.Text = "取引分布表(得意先別)";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
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
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CodeName,
            this.Code,
            this.Order,
            this.Asterisk2,
            this.Asterisk1,
            this.Asterisk4,
            this.Asterisk3,
            this.Asterisk10,
            this.Asterisk11,
            this.Asterisk9,
            this.Asterisk6,
            this.Asterisk5,
            this.Asterisk7,
            this.Asterisk8,
            this.Asterisk13,
            this.Asterisk12,
            this.Asterisk16,
            this.Asterisk15,
            this.Asterisk20,
            this.Asterisk22,
            this.Asterisk21,
            this.Asterisk14,
            this.Asterisk18,
            this.Asterisk17,
            this.Asterisk19,
            this.GrossProfitAverage,
            this.GrossProfitRate,
            this.GrossProfit,
            this.SalesAverage,
            this.SalesTotalTaxExc,
            this.SalesCount,
            this.Asterisk23,
            this.Asterisk27,
            this.Asterisk28,
            this.Asterisk30,
            this.Asterisk29,
            this.Asterisk25,
            this.Asterisk24,
            this.Asterisk26,
            this.Asterisk31,
            this.BusinessDays,
            this.line6});
            this.Detail.Height = 0.6145833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.CodeName.Left = 0.8125F;
            this.CodeName.MultiLine = false;
            this.CodeName.Name = "CodeName";
            this.CodeName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CodeName.Text = "あいうえおかきくけこさしすせそ";
            this.CodeName.Top = 0.0625F;
            this.CodeName.Width = 1.7F;
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
            this.Code.Left = 0.3125F;
            this.Code.MultiLine = false;
            this.Code.Name = "Code";
            this.Code.OutputFormat = resources.GetString("Code.OutputFormat");
            this.Code.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Code.Text = "12345678";
            this.Code.Top = 0.0625F;
            this.Code.Width = 0.5F;
            // 
            // Order
            // 
            this.Order.Border.BottomColor = System.Drawing.Color.Black;
            this.Order.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order.Border.LeftColor = System.Drawing.Color.Black;
            this.Order.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order.Border.RightColor = System.Drawing.Color.Black;
            this.Order.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order.Border.TopColor = System.Drawing.Color.Black;
            this.Order.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Order.DataField = "Order";
            this.Order.Height = 0.16F;
            this.Order.Left = 0.02133334F;
            this.Order.MultiLine = false;
            this.Order.Name = "Order";
            this.Order.OutputFormat = resources.GetString("Order.OutputFormat");
            this.Order.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.Order.Text = "9999";
            this.Order.Top = 0.063F;
            this.Order.Width = 0.2958334F;
            // 
            // Asterisk2
            // 
            this.Asterisk2.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk2.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk2.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk2.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk2.DataField = "SalesDate2";
            this.Asterisk2.Height = 0.16F;
            this.Asterisk2.Left = 2.649997F;
            this.Asterisk2.MultiLine = false;
            this.Asterisk2.Name = "Asterisk2";
            this.Asterisk2.OutputFormat = resources.GetString("Asterisk2.OutputFormat");
            this.Asterisk2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk2.Text = "*";
            this.Asterisk2.Top = 0.0625F;
            this.Asterisk2.Width = 0.15F;
            // 
            // Asterisk1
            // 
            this.Asterisk1.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk1.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk1.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk1.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk1.DataField = "SalesDate1";
            this.Asterisk1.Height = 0.16F;
            this.Asterisk1.Left = 2.5F;
            this.Asterisk1.MultiLine = false;
            this.Asterisk1.Name = "Asterisk1";
            this.Asterisk1.OutputFormat = resources.GetString("Asterisk1.OutputFormat");
            this.Asterisk1.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk1.Text = "*";
            this.Asterisk1.Top = 0.0625F;
            this.Asterisk1.Width = 0.15F;
            // 
            // Asterisk4
            // 
            this.Asterisk4.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk4.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk4.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk4.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk4.DataField = "SalesDate4";
            this.Asterisk4.Height = 0.16F;
            this.Asterisk4.Left = 2.949997F;
            this.Asterisk4.MultiLine = false;
            this.Asterisk4.Name = "Asterisk4";
            this.Asterisk4.OutputFormat = resources.GetString("Asterisk4.OutputFormat");
            this.Asterisk4.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk4.Text = "*";
            this.Asterisk4.Top = 0.0625F;
            this.Asterisk4.Width = 0.15F;
            // 
            // Asterisk3
            // 
            this.Asterisk3.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk3.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk3.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk3.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk3.DataField = "SalesDate3";
            this.Asterisk3.Height = 0.16F;
            this.Asterisk3.Left = 2.799997F;
            this.Asterisk3.MultiLine = false;
            this.Asterisk3.Name = "Asterisk3";
            this.Asterisk3.OutputFormat = resources.GetString("Asterisk3.OutputFormat");
            this.Asterisk3.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk3.Text = "*";
            this.Asterisk3.Top = 0.0625F;
            this.Asterisk3.Width = 0.15F;
            // 
            // Asterisk10
            // 
            this.Asterisk10.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk10.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk10.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk10.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk10.DataField = "SalesDate10";
            this.Asterisk10.Height = 0.16F;
            this.Asterisk10.Left = 3.849998F;
            this.Asterisk10.MultiLine = false;
            this.Asterisk10.Name = "Asterisk10";
            this.Asterisk10.OutputFormat = resources.GetString("Asterisk10.OutputFormat");
            this.Asterisk10.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk10.Text = "*";
            this.Asterisk10.Top = 0.0625F;
            this.Asterisk10.Width = 0.15F;
            // 
            // Asterisk11
            // 
            this.Asterisk11.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk11.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk11.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk11.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk11.DataField = "SalesDate11";
            this.Asterisk11.Height = 0.16F;
            this.Asterisk11.Left = 3.999998F;
            this.Asterisk11.MultiLine = false;
            this.Asterisk11.Name = "Asterisk11";
            this.Asterisk11.OutputFormat = resources.GetString("Asterisk11.OutputFormat");
            this.Asterisk11.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk11.Text = "*";
            this.Asterisk11.Top = 0.0625F;
            this.Asterisk11.Width = 0.15F;
            // 
            // Asterisk9
            // 
            this.Asterisk9.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk9.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk9.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk9.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk9.DataField = "SalesDate9";
            this.Asterisk9.Height = 0.16F;
            this.Asterisk9.Left = 3.699998F;
            this.Asterisk9.MultiLine = false;
            this.Asterisk9.Name = "Asterisk9";
            this.Asterisk9.OutputFormat = resources.GetString("Asterisk9.OutputFormat");
            this.Asterisk9.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk9.Text = "*";
            this.Asterisk9.Top = 0.0625F;
            this.Asterisk9.Width = 0.15F;
            // 
            // Asterisk6
            // 
            this.Asterisk6.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk6.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk6.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk6.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk6.DataField = "SalesDate6";
            this.Asterisk6.Height = 0.16F;
            this.Asterisk6.Left = 3.249998F;
            this.Asterisk6.MultiLine = false;
            this.Asterisk6.Name = "Asterisk6";
            this.Asterisk6.OutputFormat = resources.GetString("Asterisk6.OutputFormat");
            this.Asterisk6.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk6.Text = "*";
            this.Asterisk6.Top = 0.0625F;
            this.Asterisk6.Width = 0.15F;
            // 
            // Asterisk5
            // 
            this.Asterisk5.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk5.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk5.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk5.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk5.DataField = "SalesDate5";
            this.Asterisk5.Height = 0.16F;
            this.Asterisk5.Left = 3.099998F;
            this.Asterisk5.MultiLine = false;
            this.Asterisk5.Name = "Asterisk5";
            this.Asterisk5.OutputFormat = resources.GetString("Asterisk5.OutputFormat");
            this.Asterisk5.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk5.Text = "*";
            this.Asterisk5.Top = 0.0625F;
            this.Asterisk5.Width = 0.15F;
            // 
            // Asterisk7
            // 
            this.Asterisk7.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk7.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk7.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk7.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk7.DataField = "SalesDate7";
            this.Asterisk7.Height = 0.16F;
            this.Asterisk7.Left = 3.399998F;
            this.Asterisk7.MultiLine = false;
            this.Asterisk7.Name = "Asterisk7";
            this.Asterisk7.OutputFormat = resources.GetString("Asterisk7.OutputFormat");
            this.Asterisk7.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk7.Text = "*";
            this.Asterisk7.Top = 0.0625F;
            this.Asterisk7.Width = 0.15F;
            // 
            // Asterisk8
            // 
            this.Asterisk8.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk8.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk8.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk8.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk8.DataField = "SalesDate8";
            this.Asterisk8.Height = 0.16F;
            this.Asterisk8.Left = 3.549998F;
            this.Asterisk8.MultiLine = false;
            this.Asterisk8.Name = "Asterisk8";
            this.Asterisk8.OutputFormat = resources.GetString("Asterisk8.OutputFormat");
            this.Asterisk8.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk8.Text = "*";
            this.Asterisk8.Top = 0.0625F;
            this.Asterisk8.Width = 0.15F;
            // 
            // Asterisk13
            // 
            this.Asterisk13.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk13.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk13.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk13.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk13.DataField = "SalesDate13";
            this.Asterisk13.Height = 0.16F;
            this.Asterisk13.Left = 4.299998F;
            this.Asterisk13.MultiLine = false;
            this.Asterisk13.Name = "Asterisk13";
            this.Asterisk13.OutputFormat = resources.GetString("Asterisk13.OutputFormat");
            this.Asterisk13.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk13.Text = "*";
            this.Asterisk13.Top = 0.0625F;
            this.Asterisk13.Width = 0.15F;
            // 
            // Asterisk12
            // 
            this.Asterisk12.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk12.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk12.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk12.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk12.DataField = "SalesDate12";
            this.Asterisk12.Height = 0.16F;
            this.Asterisk12.Left = 4.149998F;
            this.Asterisk12.MultiLine = false;
            this.Asterisk12.Name = "Asterisk12";
            this.Asterisk12.OutputFormat = resources.GetString("Asterisk12.OutputFormat");
            this.Asterisk12.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk12.Text = "*";
            this.Asterisk12.Top = 0.0625F;
            this.Asterisk12.Width = 0.15F;
            // 
            // Asterisk16
            // 
            this.Asterisk16.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk16.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk16.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk16.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk16.DataField = "SalesDate16";
            this.Asterisk16.Height = 0.16F;
            this.Asterisk16.Left = 4.749999F;
            this.Asterisk16.MultiLine = false;
            this.Asterisk16.Name = "Asterisk16";
            this.Asterisk16.OutputFormat = resources.GetString("Asterisk16.OutputFormat");
            this.Asterisk16.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk16.Text = "*";
            this.Asterisk16.Top = 0.0625F;
            this.Asterisk16.Width = 0.15F;
            // 
            // Asterisk15
            // 
            this.Asterisk15.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk15.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk15.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk15.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk15.DataField = "SalesDate15";
            this.Asterisk15.Height = 0.16F;
            this.Asterisk15.Left = 4.599998F;
            this.Asterisk15.MultiLine = false;
            this.Asterisk15.Name = "Asterisk15";
            this.Asterisk15.OutputFormat = resources.GetString("Asterisk15.OutputFormat");
            this.Asterisk15.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk15.Text = "*";
            this.Asterisk15.Top = 0.0625F;
            this.Asterisk15.Width = 0.15F;
            // 
            // Asterisk20
            // 
            this.Asterisk20.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk20.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk20.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk20.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk20.DataField = "SalesDate20";
            this.Asterisk20.Height = 0.16F;
            this.Asterisk20.Left = 5.349999F;
            this.Asterisk20.MultiLine = false;
            this.Asterisk20.Name = "Asterisk20";
            this.Asterisk20.OutputFormat = resources.GetString("Asterisk20.OutputFormat");
            this.Asterisk20.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk20.Text = "*";
            this.Asterisk20.Top = 0.0625F;
            this.Asterisk20.Width = 0.15F;
            // 
            // Asterisk22
            // 
            this.Asterisk22.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk22.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk22.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk22.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk22.DataField = "SalesDate22";
            this.Asterisk22.Height = 0.16F;
            this.Asterisk22.Left = 5.649999F;
            this.Asterisk22.MultiLine = false;
            this.Asterisk22.Name = "Asterisk22";
            this.Asterisk22.OutputFormat = resources.GetString("Asterisk22.OutputFormat");
            this.Asterisk22.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk22.Text = "*";
            this.Asterisk22.Top = 0.0625F;
            this.Asterisk22.Width = 0.15F;
            // 
            // Asterisk21
            // 
            this.Asterisk21.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk21.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk21.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk21.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk21.DataField = "SalesDate21";
            this.Asterisk21.Height = 0.16F;
            this.Asterisk21.Left = 5.499999F;
            this.Asterisk21.MultiLine = false;
            this.Asterisk21.Name = "Asterisk21";
            this.Asterisk21.OutputFormat = resources.GetString("Asterisk21.OutputFormat");
            this.Asterisk21.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk21.Text = "*";
            this.Asterisk21.Top = 0.0625F;
            this.Asterisk21.Width = 0.15F;
            // 
            // Asterisk14
            // 
            this.Asterisk14.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk14.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk14.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk14.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk14.DataField = "SalesDate14";
            this.Asterisk14.Height = 0.16F;
            this.Asterisk14.Left = 4.449998F;
            this.Asterisk14.MultiLine = false;
            this.Asterisk14.Name = "Asterisk14";
            this.Asterisk14.OutputFormat = resources.GetString("Asterisk14.OutputFormat");
            this.Asterisk14.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk14.Text = "*";
            this.Asterisk14.Top = 0.0625F;
            this.Asterisk14.Width = 0.15F;
            // 
            // Asterisk18
            // 
            this.Asterisk18.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk18.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk18.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk18.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk18.DataField = "SalesDate18";
            this.Asterisk18.Height = 0.16F;
            this.Asterisk18.Left = 5.049999F;
            this.Asterisk18.MultiLine = false;
            this.Asterisk18.Name = "Asterisk18";
            this.Asterisk18.OutputFormat = resources.GetString("Asterisk18.OutputFormat");
            this.Asterisk18.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk18.Text = "*";
            this.Asterisk18.Top = 0.0625F;
            this.Asterisk18.Width = 0.15F;
            // 
            // Asterisk17
            // 
            this.Asterisk17.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk17.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk17.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk17.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk17.DataField = "SalesDate17";
            this.Asterisk17.Height = 0.16F;
            this.Asterisk17.Left = 4.899999F;
            this.Asterisk17.MultiLine = false;
            this.Asterisk17.Name = "Asterisk17";
            this.Asterisk17.OutputFormat = resources.GetString("Asterisk17.OutputFormat");
            this.Asterisk17.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk17.Text = "*";
            this.Asterisk17.Top = 0.0625F;
            this.Asterisk17.Width = 0.15F;
            // 
            // Asterisk19
            // 
            this.Asterisk19.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk19.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk19.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk19.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk19.DataField = "SalesDate19";
            this.Asterisk19.Height = 0.16F;
            this.Asterisk19.Left = 5.199999F;
            this.Asterisk19.MultiLine = false;
            this.Asterisk19.Name = "Asterisk19";
            this.Asterisk19.OutputFormat = resources.GetString("Asterisk19.OutputFormat");
            this.Asterisk19.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk19.Text = "*";
            this.Asterisk19.Top = 0.0625F;
            this.Asterisk19.Width = 0.15F;
            // 
            // GrossProfitAverage
            // 
            this.GrossProfitAverage.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitAverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitAverage.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitAverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitAverage.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitAverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitAverage.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitAverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitAverage.Height = 0.156F;
            this.GrossProfitAverage.Left = 10.085F;
            this.GrossProfitAverage.MultiLine = false;
            this.GrossProfitAverage.Name = "GrossProfitAverage";
            this.GrossProfitAverage.OutputFormat = resources.GetString("GrossProfitAverage.OutputFormat");
            this.GrossProfitAverage.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitAverage.Text = "1,234,567,890";
            this.GrossProfitAverage.Top = 0.063F;
            this.GrossProfitAverage.Width = 0.75F;
            // 
            // GrossProfitRate
            // 
            this.GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Height = 0.156F;
            this.GrossProfitRate.Left = 9.697917F;
            this.GrossProfitRate.MultiLine = false;
            this.GrossProfitRate.Name = "GrossProfitRate";
            this.GrossProfitRate.OutputFormat = resources.GetString("GrossProfitRate.OutputFormat");
            this.GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitRate.Text = "100.00";
            this.GrossProfitRate.Top = 0.0625F;
            this.GrossProfitRate.Width = 0.4F;
            // 
            // GrossProfit
            // 
            this.GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.DataField = "GrossProfit";
            this.GrossProfit.Height = 0.156F;
            this.GrossProfit.Left = 9F;
            this.GrossProfit.MultiLine = false;
            this.GrossProfit.Name = "GrossProfit";
            this.GrossProfit.OutputFormat = resources.GetString("GrossProfit.OutputFormat");
            this.GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfit.Text = "1,234,567,890";
            this.GrossProfit.Top = 0.0625F;
            this.GrossProfit.Width = 0.75F;
            // 
            // SalesAverage
            // 
            this.SalesAverage.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesAverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAverage.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesAverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAverage.Border.RightColor = System.Drawing.Color.Black;
            this.SalesAverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAverage.Border.TopColor = System.Drawing.Color.Black;
            this.SalesAverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesAverage.Height = 0.156F;
            this.SalesAverage.Left = 8.254166F;
            this.SalesAverage.MultiLine = false;
            this.SalesAverage.Name = "SalesAverage";
            this.SalesAverage.OutputFormat = resources.GetString("SalesAverage.OutputFormat");
            this.SalesAverage.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesAverage.Text = "1,234,567,890";
            this.SalesAverage.Top = 0.0625F;
            this.SalesAverage.Width = 0.75F;
            // 
            // SalesTotalTaxExc
            // 
            this.SalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.DataField = "SalesTotalTaxExc";
            this.SalesTotalTaxExc.Height = 0.156F;
            this.SalesTotalTaxExc.Left = 7.50625F;
            this.SalesTotalTaxExc.MultiLine = false;
            this.SalesTotalTaxExc.Name = "SalesTotalTaxExc";
            this.SalesTotalTaxExc.OutputFormat = resources.GetString("SalesTotalTaxExc.OutputFormat");
            this.SalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesTotalTaxExc.Text = "1,234,567,890";
            this.SalesTotalTaxExc.Top = 0.063F;
            this.SalesTotalTaxExc.Width = 0.75F;
            // 
            // SalesCount
            // 
            this.SalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.DataField = "SalesCount";
            this.SalesCount.Height = 0.156F;
            this.SalesCount.Left = 7.013751F;
            this.SalesCount.MultiLine = false;
            this.SalesCount.Name = "SalesCount";
            this.SalesCount.OutputFormat = resources.GetString("SalesCount.OutputFormat");
            this.SalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesCount.Text = "123,456";
            this.SalesCount.Top = 0.063F;
            this.SalesCount.Width = 0.5F;
            // 
            // Asterisk23
            // 
            this.Asterisk23.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk23.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk23.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk23.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk23.DataField = "SalesDate23";
            this.Asterisk23.Height = 0.16F;
            this.Asterisk23.Left = 5.799999F;
            this.Asterisk23.MultiLine = false;
            this.Asterisk23.Name = "Asterisk23";
            this.Asterisk23.OutputFormat = resources.GetString("Asterisk23.OutputFormat");
            this.Asterisk23.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk23.Text = "*";
            this.Asterisk23.Top = 0.0625F;
            this.Asterisk23.Width = 0.15F;
            // 
            // Asterisk27
            // 
            this.Asterisk27.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk27.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk27.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk27.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk27.DataField = "SalesDate27";
            this.Asterisk27.Height = 0.16F;
            this.Asterisk27.Left = 6.4F;
            this.Asterisk27.MultiLine = false;
            this.Asterisk27.Name = "Asterisk27";
            this.Asterisk27.OutputFormat = resources.GetString("Asterisk27.OutputFormat");
            this.Asterisk27.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk27.Text = "*";
            this.Asterisk27.Top = 0.0625F;
            this.Asterisk27.Width = 0.15F;
            // 
            // Asterisk28
            // 
            this.Asterisk28.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk28.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk28.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk28.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk28.DataField = "SalesDate28";
            this.Asterisk28.Height = 0.16F;
            this.Asterisk28.Left = 6.55F;
            this.Asterisk28.MultiLine = false;
            this.Asterisk28.Name = "Asterisk28";
            this.Asterisk28.OutputFormat = resources.GetString("Asterisk28.OutputFormat");
            this.Asterisk28.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk28.Text = "*";
            this.Asterisk28.Top = 0.0625F;
            this.Asterisk28.Width = 0.15F;
            // 
            // Asterisk30
            // 
            this.Asterisk30.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk30.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk30.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk30.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk30.DataField = "SalesDate30";
            this.Asterisk30.Height = 0.16F;
            this.Asterisk30.Left = 6.85F;
            this.Asterisk30.MultiLine = false;
            this.Asterisk30.Name = "Asterisk30";
            this.Asterisk30.OutputFormat = resources.GetString("Asterisk30.OutputFormat");
            this.Asterisk30.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk30.Text = "*";
            this.Asterisk30.Top = 0.0625F;
            this.Asterisk30.Width = 0.15F;
            // 
            // Asterisk29
            // 
            this.Asterisk29.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk29.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk29.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk29.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk29.DataField = "SalesDate29";
            this.Asterisk29.Height = 0.16F;
            this.Asterisk29.Left = 6.7F;
            this.Asterisk29.MultiLine = false;
            this.Asterisk29.Name = "Asterisk29";
            this.Asterisk29.OutputFormat = resources.GetString("Asterisk29.OutputFormat");
            this.Asterisk29.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk29.Text = "*";
            this.Asterisk29.Top = 0.0625F;
            this.Asterisk29.Width = 0.15F;
            // 
            // Asterisk25
            // 
            this.Asterisk25.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk25.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk25.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk25.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk25.DataField = "SalesDate25";
            this.Asterisk25.Height = 0.16F;
            this.Asterisk25.Left = 6.099999F;
            this.Asterisk25.MultiLine = false;
            this.Asterisk25.Name = "Asterisk25";
            this.Asterisk25.OutputFormat = resources.GetString("Asterisk25.OutputFormat");
            this.Asterisk25.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk25.Text = "*";
            this.Asterisk25.Top = 0.0625F;
            this.Asterisk25.Width = 0.15F;
            // 
            // Asterisk24
            // 
            this.Asterisk24.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk24.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk24.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk24.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk24.DataField = "SalesDate24";
            this.Asterisk24.Height = 0.16F;
            this.Asterisk24.Left = 5.949999F;
            this.Asterisk24.MultiLine = false;
            this.Asterisk24.Name = "Asterisk24";
            this.Asterisk24.OutputFormat = resources.GetString("Asterisk24.OutputFormat");
            this.Asterisk24.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk24.Text = "*";
            this.Asterisk24.Top = 0.0625F;
            this.Asterisk24.Width = 0.15F;
            // 
            // Asterisk26
            // 
            this.Asterisk26.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk26.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk26.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk26.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk26.DataField = "SalesDate26";
            this.Asterisk26.Height = 0.16F;
            this.Asterisk26.Left = 6.25F;
            this.Asterisk26.MultiLine = false;
            this.Asterisk26.Name = "Asterisk26";
            this.Asterisk26.OutputFormat = resources.GetString("Asterisk26.OutputFormat");
            this.Asterisk26.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk26.Text = "*";
            this.Asterisk26.Top = 0.0625F;
            this.Asterisk26.Width = 0.15F;
            // 
            // Asterisk31
            // 
            this.Asterisk31.Border.BottomColor = System.Drawing.Color.Black;
            this.Asterisk31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk31.Border.LeftColor = System.Drawing.Color.Black;
            this.Asterisk31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk31.Border.RightColor = System.Drawing.Color.Black;
            this.Asterisk31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk31.Border.TopColor = System.Drawing.Color.Black;
            this.Asterisk31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Asterisk31.DataField = "SalesDate31";
            this.Asterisk31.Height = 0.16F;
            this.Asterisk31.Left = 7F;
            this.Asterisk31.MultiLine = false;
            this.Asterisk31.Name = "Asterisk31";
            this.Asterisk31.OutputFormat = resources.GetString("Asterisk31.OutputFormat");
            this.Asterisk31.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Asterisk31.Text = "*";
            this.Asterisk31.Top = 0.0625F;
            this.Asterisk31.Width = 0.15F;
            // 
            // BusinessDays
            // 
            this.BusinessDays.Border.BottomColor = System.Drawing.Color.Black;
            this.BusinessDays.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessDays.Border.LeftColor = System.Drawing.Color.Black;
            this.BusinessDays.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessDays.Border.RightColor = System.Drawing.Color.Black;
            this.BusinessDays.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessDays.Border.TopColor = System.Drawing.Color.Black;
            this.BusinessDays.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BusinessDays.DataField = "BusinessDays";
            this.BusinessDays.Height = 0.156F;
            this.BusinessDays.Left = 8.254166F;
            this.BusinessDays.MultiLine = false;
            this.BusinessDays.Name = "BusinessDays";
            this.BusinessDays.OutputFormat = resources.GetString("BusinessDays.OutputFormat");
            this.BusinessDays.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.BusinessDays.Text = "1,234,567,890";
            this.BusinessDays.Top = 0.281F;
            this.BusinessDays.Visible = false;
            this.BusinessDays.Width = 0.75F;
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
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3333333F;
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
            this.Lb_Title,
            this.Line2,
            this.label1,
            this.lbl_CodeTitle,
            this.lbl_Month8,
            this.lbl_Month9,
            this.lbl_Month10,
            this.lbl_Month11,
            this.lbl_Month12,
            this.lbl_Month13,
            this.lbl_Month14,
            this.lbl_Month15,
            this.lbl_Month16,
            this.lbl_Month17,
            this.lbl_Month18,
            this.lbl_Month19,
            this.lbl_Month20,
            this.lbl_Month21,
            this.lbl_Month22,
            this.lbl_Month23,
            this.lbl_Month24,
            this.lbl_Month25,
            this.lbl_Month26,
            this.lbl_Month27,
            this.lbl_Month28,
            this.lbl_Month29,
            this.lbl_Month30,
            this.lbl_Month31,
            this.lbl_Month1,
            this.lbl_Month2,
            this.lbl_Month3,
            this.lbl_Month4,
            this.lbl_Month5,
            this.lbl_Month6,
            this.lbl_Month7,
            this.lbl_Day1,
            this.lbl_Day9,
            this.lbl_Day10,
            this.lbl_Day11,
            this.lbl_Day12,
            this.lbl_Day13,
            this.lbl_Day14,
            this.lbl_Day15,
            this.lbl_Day16,
            this.lbl_Day17,
            this.lbl_Day18,
            this.lbl_Day19,
            this.lbl_Day20,
            this.lbl_Day21,
            this.lbl_Day22,
            this.lbl_Day23,
            this.lbl_Day24,
            this.lbl_Day25,
            this.lbl_Day26,
            this.lbl_Day27,
            this.lbl_Day28,
            this.lbl_Day29,
            this.lbl_Day30,
            this.lbl_Day31,
            this.lbl_Day8,
            this.lbl_Day2,
            this.lbl_Day3,
            this.lbl_Day4,
            this.lbl_Day5,
            this.lbl_Day6,
            this.lbl_Day7,
            this.lbl_Dow1,
            this.lbl_Dow9,
            this.lbl_Dow10,
            this.lbl_Dow11,
            this.lbl_Dow12,
            this.lbl_Dow13,
            this.lbl_Dow14,
            this.lbl_Dow15,
            this.lbl_Dow16,
            this.lbl_Dow17,
            this.lbl_Dow18,
            this.lbl_Dow19,
            this.lbl_Dow20,
            this.lbl_Dow21,
            this.lbl_Dow22,
            this.lbl_Dow23,
            this.lbl_Dow24,
            this.lbl_Dow25,
            this.lbl_Dow26,
            this.lbl_Dow27,
            this.lbl_Dow28,
            this.lbl_Dow29,
            this.lbl_Dow30,
            this.lbl_Dow31,
            this.lbl_Dow8,
            this.lbl_Dow2,
            this.lbl_Dow3,
            this.lbl_Dow4,
            this.lbl_Dow5,
            this.lbl_Dow6,
            this.lbl_Dow7,
            this.label98,
            this.label99,
            this.label100,
            this.label101,
            this.label102,
            this.label103,
            this.label5});
            this.TitleHeader.Height = 0.6666667F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Lb_Title.Text = "拠点";
            this.Lb_Title.Top = 0.25F;
            this.Lb_Title.Width = 0.3F;
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
            this.label1.Left = 0.063F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "順位";
            this.label1.Top = 0.438F;
            this.label1.Width = 0.3F;
            // 
            // lbl_CodeTitle
            // 
            this.lbl_CodeTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_CodeTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_CodeTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_CodeTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_CodeTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_CodeTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_CodeTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_CodeTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_CodeTitle.Height = 0.156F;
            this.lbl_CodeTitle.HyperLink = "";
            this.lbl_CodeTitle.Left = 0.3125F;
            this.lbl_CodeTitle.MultiLine = false;
            this.lbl_CodeTitle.Name = "lbl_CodeTitle";
            this.lbl_CodeTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_CodeTitle.Text = "得意先";
            this.lbl_CodeTitle.Top = 0.4375F;
            this.lbl_CodeTitle.Width = 0.4F;
            // 
            // lbl_Month8
            // 
            this.lbl_Month8.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month8.Height = 0.156F;
            this.lbl_Month8.HyperLink = "";
            this.lbl_Month8.Left = 3.549998F;
            this.lbl_Month8.MultiLine = false;
            this.lbl_Month8.Name = "lbl_Month8";
            this.lbl_Month8.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month8.Text = "8";
            this.lbl_Month8.Top = 0.0625F;
            this.lbl_Month8.Visible = false;
            this.lbl_Month8.Width = 0.15F;
            // 
            // lbl_Month9
            // 
            this.lbl_Month9.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month9.Height = 0.156F;
            this.lbl_Month9.HyperLink = "";
            this.lbl_Month9.Left = 3.699998F;
            this.lbl_Month9.MultiLine = false;
            this.lbl_Month9.Name = "lbl_Month9";
            this.lbl_Month9.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month9.Text = "9";
            this.lbl_Month9.Top = 0.0625F;
            this.lbl_Month9.Visible = false;
            this.lbl_Month9.Width = 0.15F;
            // 
            // lbl_Month10
            // 
            this.lbl_Month10.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month10.Height = 0.156F;
            this.lbl_Month10.HyperLink = "";
            this.lbl_Month10.Left = 3.849998F;
            this.lbl_Month10.MultiLine = false;
            this.lbl_Month10.Name = "lbl_Month10";
            this.lbl_Month10.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month10.Text = "10";
            this.lbl_Month10.Top = 0.0625F;
            this.lbl_Month10.Visible = false;
            this.lbl_Month10.Width = 0.15F;
            // 
            // lbl_Month11
            // 
            this.lbl_Month11.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month11.Height = 0.156F;
            this.lbl_Month11.HyperLink = "";
            this.lbl_Month11.Left = 3.999998F;
            this.lbl_Month11.MultiLine = false;
            this.lbl_Month11.Name = "lbl_Month11";
            this.lbl_Month11.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month11.Text = "11";
            this.lbl_Month11.Top = 0.0625F;
            this.lbl_Month11.Visible = false;
            this.lbl_Month11.Width = 0.15F;
            // 
            // lbl_Month12
            // 
            this.lbl_Month12.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month12.Height = 0.156F;
            this.lbl_Month12.HyperLink = "";
            this.lbl_Month12.Left = 4.149998F;
            this.lbl_Month12.MultiLine = false;
            this.lbl_Month12.Name = "lbl_Month12";
            this.lbl_Month12.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month12.Text = "12";
            this.lbl_Month12.Top = 0.0625F;
            this.lbl_Month12.Visible = false;
            this.lbl_Month12.Width = 0.15F;
            // 
            // lbl_Month13
            // 
            this.lbl_Month13.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month13.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month13.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month13.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month13.Height = 0.156F;
            this.lbl_Month13.HyperLink = "";
            this.lbl_Month13.Left = 4.299998F;
            this.lbl_Month13.MultiLine = false;
            this.lbl_Month13.Name = "lbl_Month13";
            this.lbl_Month13.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month13.Text = "13";
            this.lbl_Month13.Top = 0.0625F;
            this.lbl_Month13.Visible = false;
            this.lbl_Month13.Width = 0.15F;
            // 
            // lbl_Month14
            // 
            this.lbl_Month14.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month14.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month14.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month14.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month14.Height = 0.156F;
            this.lbl_Month14.HyperLink = "";
            this.lbl_Month14.Left = 4.449998F;
            this.lbl_Month14.MultiLine = false;
            this.lbl_Month14.Name = "lbl_Month14";
            this.lbl_Month14.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month14.Text = "14";
            this.lbl_Month14.Top = 0.0625F;
            this.lbl_Month14.Visible = false;
            this.lbl_Month14.Width = 0.15F;
            // 
            // lbl_Month15
            // 
            this.lbl_Month15.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month15.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month15.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month15.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month15.Height = 0.156F;
            this.lbl_Month15.HyperLink = "";
            this.lbl_Month15.Left = 4.599998F;
            this.lbl_Month15.MultiLine = false;
            this.lbl_Month15.Name = "lbl_Month15";
            this.lbl_Month15.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month15.Text = "15";
            this.lbl_Month15.Top = 0.0625F;
            this.lbl_Month15.Visible = false;
            this.lbl_Month15.Width = 0.15F;
            // 
            // lbl_Month16
            // 
            this.lbl_Month16.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month16.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month16.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month16.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month16.Height = 0.156F;
            this.lbl_Month16.HyperLink = "";
            this.lbl_Month16.Left = 4.749999F;
            this.lbl_Month16.MultiLine = false;
            this.lbl_Month16.Name = "lbl_Month16";
            this.lbl_Month16.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month16.Text = "16";
            this.lbl_Month16.Top = 0.0625F;
            this.lbl_Month16.Visible = false;
            this.lbl_Month16.Width = 0.15F;
            // 
            // lbl_Month17
            // 
            this.lbl_Month17.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month17.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month17.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month17.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month17.Height = 0.156F;
            this.lbl_Month17.HyperLink = "";
            this.lbl_Month17.Left = 4.899999F;
            this.lbl_Month17.MultiLine = false;
            this.lbl_Month17.Name = "lbl_Month17";
            this.lbl_Month17.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month17.Text = "17";
            this.lbl_Month17.Top = 0.0625F;
            this.lbl_Month17.Visible = false;
            this.lbl_Month17.Width = 0.15F;
            // 
            // lbl_Month18
            // 
            this.lbl_Month18.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month18.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month18.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month18.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month18.Height = 0.156F;
            this.lbl_Month18.HyperLink = "";
            this.lbl_Month18.Left = 5.049999F;
            this.lbl_Month18.MultiLine = false;
            this.lbl_Month18.Name = "lbl_Month18";
            this.lbl_Month18.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month18.Text = "18";
            this.lbl_Month18.Top = 0.0625F;
            this.lbl_Month18.Visible = false;
            this.lbl_Month18.Width = 0.15F;
            // 
            // lbl_Month19
            // 
            this.lbl_Month19.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month19.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month19.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month19.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month19.Height = 0.156F;
            this.lbl_Month19.HyperLink = "";
            this.lbl_Month19.Left = 5.199999F;
            this.lbl_Month19.MultiLine = false;
            this.lbl_Month19.Name = "lbl_Month19";
            this.lbl_Month19.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month19.Text = "19";
            this.lbl_Month19.Top = 0.0625F;
            this.lbl_Month19.Visible = false;
            this.lbl_Month19.Width = 0.15F;
            // 
            // lbl_Month20
            // 
            this.lbl_Month20.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month20.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month20.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month20.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month20.Height = 0.156F;
            this.lbl_Month20.HyperLink = "";
            this.lbl_Month20.Left = 5.349999F;
            this.lbl_Month20.MultiLine = false;
            this.lbl_Month20.Name = "lbl_Month20";
            this.lbl_Month20.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month20.Text = "20";
            this.lbl_Month20.Top = 0.0625F;
            this.lbl_Month20.Visible = false;
            this.lbl_Month20.Width = 0.15F;
            // 
            // lbl_Month21
            // 
            this.lbl_Month21.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month21.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month21.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month21.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month21.Height = 0.156F;
            this.lbl_Month21.HyperLink = "";
            this.lbl_Month21.Left = 5.499999F;
            this.lbl_Month21.MultiLine = false;
            this.lbl_Month21.Name = "lbl_Month21";
            this.lbl_Month21.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month21.Text = "21";
            this.lbl_Month21.Top = 0.0625F;
            this.lbl_Month21.Visible = false;
            this.lbl_Month21.Width = 0.15F;
            // 
            // lbl_Month22
            // 
            this.lbl_Month22.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month22.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month22.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month22.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month22.Height = 0.156F;
            this.lbl_Month22.HyperLink = "";
            this.lbl_Month22.Left = 5.649999F;
            this.lbl_Month22.MultiLine = false;
            this.lbl_Month22.Name = "lbl_Month22";
            this.lbl_Month22.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month22.Text = "22";
            this.lbl_Month22.Top = 0.0625F;
            this.lbl_Month22.Visible = false;
            this.lbl_Month22.Width = 0.15F;
            // 
            // lbl_Month23
            // 
            this.lbl_Month23.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month23.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month23.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month23.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month23.Height = 0.156F;
            this.lbl_Month23.HyperLink = "";
            this.lbl_Month23.Left = 5.799999F;
            this.lbl_Month23.MultiLine = false;
            this.lbl_Month23.Name = "lbl_Month23";
            this.lbl_Month23.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month23.Text = "23";
            this.lbl_Month23.Top = 0.0625F;
            this.lbl_Month23.Visible = false;
            this.lbl_Month23.Width = 0.15F;
            // 
            // lbl_Month24
            // 
            this.lbl_Month24.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month24.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month24.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month24.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month24.Height = 0.156F;
            this.lbl_Month24.HyperLink = "";
            this.lbl_Month24.Left = 5.949999F;
            this.lbl_Month24.MultiLine = false;
            this.lbl_Month24.Name = "lbl_Month24";
            this.lbl_Month24.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month24.Text = "24";
            this.lbl_Month24.Top = 0.0625F;
            this.lbl_Month24.Visible = false;
            this.lbl_Month24.Width = 0.15F;
            // 
            // lbl_Month25
            // 
            this.lbl_Month25.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month25.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month25.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month25.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month25.Height = 0.156F;
            this.lbl_Month25.HyperLink = "";
            this.lbl_Month25.Left = 6.099999F;
            this.lbl_Month25.MultiLine = false;
            this.lbl_Month25.Name = "lbl_Month25";
            this.lbl_Month25.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month25.Text = "25";
            this.lbl_Month25.Top = 0.0625F;
            this.lbl_Month25.Visible = false;
            this.lbl_Month25.Width = 0.15F;
            // 
            // lbl_Month26
            // 
            this.lbl_Month26.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month26.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month26.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month26.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month26.Height = 0.156F;
            this.lbl_Month26.HyperLink = "";
            this.lbl_Month26.Left = 6.25F;
            this.lbl_Month26.MultiLine = false;
            this.lbl_Month26.Name = "lbl_Month26";
            this.lbl_Month26.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month26.Text = "26";
            this.lbl_Month26.Top = 0.0625F;
            this.lbl_Month26.Visible = false;
            this.lbl_Month26.Width = 0.15F;
            // 
            // lbl_Month27
            // 
            this.lbl_Month27.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month27.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month27.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month27.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month27.Height = 0.156F;
            this.lbl_Month27.HyperLink = "";
            this.lbl_Month27.Left = 6.4F;
            this.lbl_Month27.MultiLine = false;
            this.lbl_Month27.Name = "lbl_Month27";
            this.lbl_Month27.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month27.Text = "27";
            this.lbl_Month27.Top = 0.0625F;
            this.lbl_Month27.Visible = false;
            this.lbl_Month27.Width = 0.15F;
            // 
            // lbl_Month28
            // 
            this.lbl_Month28.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month28.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month28.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month28.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month28.Height = 0.156F;
            this.lbl_Month28.HyperLink = "";
            this.lbl_Month28.Left = 6.55F;
            this.lbl_Month28.MultiLine = false;
            this.lbl_Month28.Name = "lbl_Month28";
            this.lbl_Month28.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month28.Text = "28";
            this.lbl_Month28.Top = 0.0625F;
            this.lbl_Month28.Visible = false;
            this.lbl_Month28.Width = 0.15F;
            // 
            // lbl_Month29
            // 
            this.lbl_Month29.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month29.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month29.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month29.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month29.Height = 0.156F;
            this.lbl_Month29.HyperLink = "";
            this.lbl_Month29.Left = 6.7F;
            this.lbl_Month29.MultiLine = false;
            this.lbl_Month29.Name = "lbl_Month29";
            this.lbl_Month29.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month29.Text = "29";
            this.lbl_Month29.Top = 0.0625F;
            this.lbl_Month29.Visible = false;
            this.lbl_Month29.Width = 0.15F;
            // 
            // lbl_Month30
            // 
            this.lbl_Month30.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month30.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month30.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month30.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month30.Height = 0.156F;
            this.lbl_Month30.HyperLink = "";
            this.lbl_Month30.Left = 6.85F;
            this.lbl_Month30.MultiLine = false;
            this.lbl_Month30.Name = "lbl_Month30";
            this.lbl_Month30.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month30.Text = "30";
            this.lbl_Month30.Top = 0.0625F;
            this.lbl_Month30.Visible = false;
            this.lbl_Month30.Width = 0.15F;
            // 
            // lbl_Month31
            // 
            this.lbl_Month31.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month31.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month31.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month31.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month31.Height = 0.156F;
            this.lbl_Month31.HyperLink = "";
            this.lbl_Month31.Left = 7F;
            this.lbl_Month31.MultiLine = false;
            this.lbl_Month31.Name = "lbl_Month31";
            this.lbl_Month31.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month31.Text = "31";
            this.lbl_Month31.Top = 0.0625F;
            this.lbl_Month31.Visible = false;
            this.lbl_Month31.Width = 0.15F;
            // 
            // lbl_Month1
            // 
            this.lbl_Month1.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month1.Height = 0.156F;
            this.lbl_Month1.HyperLink = "";
            this.lbl_Month1.Left = 2.499997F;
            this.lbl_Month1.MultiLine = false;
            this.lbl_Month1.Name = "lbl_Month1";
            this.lbl_Month1.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month1.Text = "1";
            this.lbl_Month1.Top = 0.0625F;
            this.lbl_Month1.Visible = false;
            this.lbl_Month1.Width = 0.15F;
            // 
            // lbl_Month2
            // 
            this.lbl_Month2.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month2.Height = 0.156F;
            this.lbl_Month2.HyperLink = "";
            this.lbl_Month2.Left = 2.649997F;
            this.lbl_Month2.MultiLine = false;
            this.lbl_Month2.Name = "lbl_Month2";
            this.lbl_Month2.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month2.Text = "2";
            this.lbl_Month2.Top = 0.0625F;
            this.lbl_Month2.Visible = false;
            this.lbl_Month2.Width = 0.15F;
            // 
            // lbl_Month3
            // 
            this.lbl_Month3.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month3.Height = 0.156F;
            this.lbl_Month3.HyperLink = "";
            this.lbl_Month3.Left = 2.799997F;
            this.lbl_Month3.MultiLine = false;
            this.lbl_Month3.Name = "lbl_Month3";
            this.lbl_Month3.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month3.Text = "3";
            this.lbl_Month3.Top = 0.0625F;
            this.lbl_Month3.Visible = false;
            this.lbl_Month3.Width = 0.15F;
            // 
            // lbl_Month4
            // 
            this.lbl_Month4.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month4.Height = 0.156F;
            this.lbl_Month4.HyperLink = "";
            this.lbl_Month4.Left = 2.949997F;
            this.lbl_Month4.MultiLine = false;
            this.lbl_Month4.Name = "lbl_Month4";
            this.lbl_Month4.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month4.Text = "4";
            this.lbl_Month4.Top = 0.0625F;
            this.lbl_Month4.Visible = false;
            this.lbl_Month4.Width = 0.15F;
            // 
            // lbl_Month5
            // 
            this.lbl_Month5.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month5.Height = 0.156F;
            this.lbl_Month5.HyperLink = "";
            this.lbl_Month5.Left = 3.099998F;
            this.lbl_Month5.MultiLine = false;
            this.lbl_Month5.Name = "lbl_Month5";
            this.lbl_Month5.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month5.Text = "5";
            this.lbl_Month5.Top = 0.0625F;
            this.lbl_Month5.Visible = false;
            this.lbl_Month5.Width = 0.15F;
            // 
            // lbl_Month6
            // 
            this.lbl_Month6.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month6.Height = 0.156F;
            this.lbl_Month6.HyperLink = "";
            this.lbl_Month6.Left = 3.249998F;
            this.lbl_Month6.MultiLine = false;
            this.lbl_Month6.Name = "lbl_Month6";
            this.lbl_Month6.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month6.Text = "6";
            this.lbl_Month6.Top = 0.0625F;
            this.lbl_Month6.Visible = false;
            this.lbl_Month6.Width = 0.15F;
            // 
            // lbl_Month7
            // 
            this.lbl_Month7.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Month7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Month7.Height = 0.156F;
            this.lbl_Month7.HyperLink = "";
            this.lbl_Month7.Left = 3.399998F;
            this.lbl_Month7.MultiLine = false;
            this.lbl_Month7.Name = "lbl_Month7";
            this.lbl_Month7.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Month7.Text = "7";
            this.lbl_Month7.Top = 0.0625F;
            this.lbl_Month7.Visible = false;
            this.lbl_Month7.Width = 0.15F;
            // 
            // lbl_Day1
            // 
            this.lbl_Day1.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day1.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day1.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day1.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day1.Height = 0.156F;
            this.lbl_Day1.HyperLink = "";
            this.lbl_Day1.Left = 2.499997F;
            this.lbl_Day1.MultiLine = false;
            this.lbl_Day1.Name = "lbl_Day1";
            this.lbl_Day1.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day1.Text = "1";
            this.lbl_Day1.Top = 0.25F;
            this.lbl_Day1.Visible = false;
            this.lbl_Day1.Width = 0.15F;
            // 
            // lbl_Day9
            // 
            this.lbl_Day9.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day9.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day9.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day9.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day9.Height = 0.156F;
            this.lbl_Day9.HyperLink = "";
            this.lbl_Day9.Left = 3.699998F;
            this.lbl_Day9.MultiLine = false;
            this.lbl_Day9.Name = "lbl_Day9";
            this.lbl_Day9.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day9.Text = "9";
            this.lbl_Day9.Top = 0.25F;
            this.lbl_Day9.Visible = false;
            this.lbl_Day9.Width = 0.15F;
            // 
            // lbl_Day10
            // 
            this.lbl_Day10.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day10.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day10.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day10.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day10.Height = 0.156F;
            this.lbl_Day10.HyperLink = "";
            this.lbl_Day10.Left = 3.849998F;
            this.lbl_Day10.MultiLine = false;
            this.lbl_Day10.Name = "lbl_Day10";
            this.lbl_Day10.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day10.Text = "10";
            this.lbl_Day10.Top = 0.25F;
            this.lbl_Day10.Visible = false;
            this.lbl_Day10.Width = 0.15F;
            // 
            // lbl_Day11
            // 
            this.lbl_Day11.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day11.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day11.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day11.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day11.Height = 0.156F;
            this.lbl_Day11.HyperLink = "";
            this.lbl_Day11.Left = 3.999998F;
            this.lbl_Day11.MultiLine = false;
            this.lbl_Day11.Name = "lbl_Day11";
            this.lbl_Day11.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day11.Text = "11";
            this.lbl_Day11.Top = 0.25F;
            this.lbl_Day11.Visible = false;
            this.lbl_Day11.Width = 0.15F;
            // 
            // lbl_Day12
            // 
            this.lbl_Day12.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day12.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day12.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day12.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day12.Height = 0.156F;
            this.lbl_Day12.HyperLink = "";
            this.lbl_Day12.Left = 4.149998F;
            this.lbl_Day12.MultiLine = false;
            this.lbl_Day12.Name = "lbl_Day12";
            this.lbl_Day12.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day12.Text = "12";
            this.lbl_Day12.Top = 0.25F;
            this.lbl_Day12.Visible = false;
            this.lbl_Day12.Width = 0.15F;
            // 
            // lbl_Day13
            // 
            this.lbl_Day13.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day13.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day13.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day13.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day13.Height = 0.156F;
            this.lbl_Day13.HyperLink = "";
            this.lbl_Day13.Left = 4.299998F;
            this.lbl_Day13.MultiLine = false;
            this.lbl_Day13.Name = "lbl_Day13";
            this.lbl_Day13.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day13.Text = "13";
            this.lbl_Day13.Top = 0.25F;
            this.lbl_Day13.Visible = false;
            this.lbl_Day13.Width = 0.15F;
            // 
            // lbl_Day14
            // 
            this.lbl_Day14.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day14.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day14.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day14.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day14.Height = 0.156F;
            this.lbl_Day14.HyperLink = "";
            this.lbl_Day14.Left = 4.449998F;
            this.lbl_Day14.MultiLine = false;
            this.lbl_Day14.Name = "lbl_Day14";
            this.lbl_Day14.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day14.Text = "14";
            this.lbl_Day14.Top = 0.25F;
            this.lbl_Day14.Visible = false;
            this.lbl_Day14.Width = 0.15F;
            // 
            // lbl_Day15
            // 
            this.lbl_Day15.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day15.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day15.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day15.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day15.Height = 0.156F;
            this.lbl_Day15.HyperLink = "";
            this.lbl_Day15.Left = 4.599998F;
            this.lbl_Day15.MultiLine = false;
            this.lbl_Day15.Name = "lbl_Day15";
            this.lbl_Day15.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day15.Text = "15";
            this.lbl_Day15.Top = 0.25F;
            this.lbl_Day15.Visible = false;
            this.lbl_Day15.Width = 0.15F;
            // 
            // lbl_Day16
            // 
            this.lbl_Day16.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day16.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day16.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day16.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day16.Height = 0.156F;
            this.lbl_Day16.HyperLink = "";
            this.lbl_Day16.Left = 4.749999F;
            this.lbl_Day16.MultiLine = false;
            this.lbl_Day16.Name = "lbl_Day16";
            this.lbl_Day16.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day16.Text = "16";
            this.lbl_Day16.Top = 0.25F;
            this.lbl_Day16.Visible = false;
            this.lbl_Day16.Width = 0.15F;
            // 
            // lbl_Day17
            // 
            this.lbl_Day17.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day17.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day17.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day17.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day17.Height = 0.156F;
            this.lbl_Day17.HyperLink = "";
            this.lbl_Day17.Left = 4.899999F;
            this.lbl_Day17.MultiLine = false;
            this.lbl_Day17.Name = "lbl_Day17";
            this.lbl_Day17.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day17.Text = "17";
            this.lbl_Day17.Top = 0.25F;
            this.lbl_Day17.Visible = false;
            this.lbl_Day17.Width = 0.15F;
            // 
            // lbl_Day18
            // 
            this.lbl_Day18.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day18.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day18.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day18.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day18.Height = 0.156F;
            this.lbl_Day18.HyperLink = "";
            this.lbl_Day18.Left = 5.049999F;
            this.lbl_Day18.MultiLine = false;
            this.lbl_Day18.Name = "lbl_Day18";
            this.lbl_Day18.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day18.Text = "18";
            this.lbl_Day18.Top = 0.25F;
            this.lbl_Day18.Visible = false;
            this.lbl_Day18.Width = 0.15F;
            // 
            // lbl_Day19
            // 
            this.lbl_Day19.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day19.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day19.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day19.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day19.Height = 0.156F;
            this.lbl_Day19.HyperLink = "";
            this.lbl_Day19.Left = 5.199999F;
            this.lbl_Day19.MultiLine = false;
            this.lbl_Day19.Name = "lbl_Day19";
            this.lbl_Day19.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day19.Text = "19";
            this.lbl_Day19.Top = 0.25F;
            this.lbl_Day19.Visible = false;
            this.lbl_Day19.Width = 0.15F;
            // 
            // lbl_Day20
            // 
            this.lbl_Day20.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day20.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day20.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day20.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day20.Height = 0.156F;
            this.lbl_Day20.HyperLink = "";
            this.lbl_Day20.Left = 5.349999F;
            this.lbl_Day20.MultiLine = false;
            this.lbl_Day20.Name = "lbl_Day20";
            this.lbl_Day20.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day20.Text = "20";
            this.lbl_Day20.Top = 0.25F;
            this.lbl_Day20.Visible = false;
            this.lbl_Day20.Width = 0.15F;
            // 
            // lbl_Day21
            // 
            this.lbl_Day21.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day21.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day21.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day21.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day21.Height = 0.156F;
            this.lbl_Day21.HyperLink = "";
            this.lbl_Day21.Left = 5.499999F;
            this.lbl_Day21.MultiLine = false;
            this.lbl_Day21.Name = "lbl_Day21";
            this.lbl_Day21.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day21.Text = "21";
            this.lbl_Day21.Top = 0.25F;
            this.lbl_Day21.Visible = false;
            this.lbl_Day21.Width = 0.15F;
            // 
            // lbl_Day22
            // 
            this.lbl_Day22.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day22.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day22.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day22.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day22.Height = 0.156F;
            this.lbl_Day22.HyperLink = "";
            this.lbl_Day22.Left = 5.649999F;
            this.lbl_Day22.MultiLine = false;
            this.lbl_Day22.Name = "lbl_Day22";
            this.lbl_Day22.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day22.Text = "22";
            this.lbl_Day22.Top = 0.25F;
            this.lbl_Day22.Visible = false;
            this.lbl_Day22.Width = 0.15F;
            // 
            // lbl_Day23
            // 
            this.lbl_Day23.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day23.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day23.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day23.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day23.Height = 0.156F;
            this.lbl_Day23.HyperLink = "";
            this.lbl_Day23.Left = 5.799999F;
            this.lbl_Day23.MultiLine = false;
            this.lbl_Day23.Name = "lbl_Day23";
            this.lbl_Day23.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day23.Text = "23";
            this.lbl_Day23.Top = 0.25F;
            this.lbl_Day23.Visible = false;
            this.lbl_Day23.Width = 0.15F;
            // 
            // lbl_Day24
            // 
            this.lbl_Day24.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day24.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day24.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day24.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day24.Height = 0.156F;
            this.lbl_Day24.HyperLink = "";
            this.lbl_Day24.Left = 5.949999F;
            this.lbl_Day24.MultiLine = false;
            this.lbl_Day24.Name = "lbl_Day24";
            this.lbl_Day24.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day24.Text = "24";
            this.lbl_Day24.Top = 0.25F;
            this.lbl_Day24.Visible = false;
            this.lbl_Day24.Width = 0.15F;
            // 
            // lbl_Day25
            // 
            this.lbl_Day25.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day25.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day25.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day25.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day25.Height = 0.156F;
            this.lbl_Day25.HyperLink = "";
            this.lbl_Day25.Left = 6.099999F;
            this.lbl_Day25.MultiLine = false;
            this.lbl_Day25.Name = "lbl_Day25";
            this.lbl_Day25.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day25.Text = "25";
            this.lbl_Day25.Top = 0.25F;
            this.lbl_Day25.Visible = false;
            this.lbl_Day25.Width = 0.15F;
            // 
            // lbl_Day26
            // 
            this.lbl_Day26.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day26.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day26.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day26.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day26.Height = 0.156F;
            this.lbl_Day26.HyperLink = "";
            this.lbl_Day26.Left = 6.25F;
            this.lbl_Day26.MultiLine = false;
            this.lbl_Day26.Name = "lbl_Day26";
            this.lbl_Day26.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day26.Text = "26";
            this.lbl_Day26.Top = 0.25F;
            this.lbl_Day26.Visible = false;
            this.lbl_Day26.Width = 0.15F;
            // 
            // lbl_Day27
            // 
            this.lbl_Day27.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day27.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day27.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day27.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day27.Height = 0.156F;
            this.lbl_Day27.HyperLink = "";
            this.lbl_Day27.Left = 6.4F;
            this.lbl_Day27.MultiLine = false;
            this.lbl_Day27.Name = "lbl_Day27";
            this.lbl_Day27.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day27.Text = "27";
            this.lbl_Day27.Top = 0.25F;
            this.lbl_Day27.Visible = false;
            this.lbl_Day27.Width = 0.15F;
            // 
            // lbl_Day28
            // 
            this.lbl_Day28.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day28.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day28.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day28.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day28.Height = 0.156F;
            this.lbl_Day28.HyperLink = "";
            this.lbl_Day28.Left = 6.55F;
            this.lbl_Day28.MultiLine = false;
            this.lbl_Day28.Name = "lbl_Day28";
            this.lbl_Day28.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day28.Text = "28";
            this.lbl_Day28.Top = 0.25F;
            this.lbl_Day28.Visible = false;
            this.lbl_Day28.Width = 0.15F;
            // 
            // lbl_Day29
            // 
            this.lbl_Day29.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day29.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day29.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day29.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day29.Height = 0.156F;
            this.lbl_Day29.HyperLink = "";
            this.lbl_Day29.Left = 6.7F;
            this.lbl_Day29.MultiLine = false;
            this.lbl_Day29.Name = "lbl_Day29";
            this.lbl_Day29.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day29.Text = "29";
            this.lbl_Day29.Top = 0.25F;
            this.lbl_Day29.Visible = false;
            this.lbl_Day29.Width = 0.15F;
            // 
            // lbl_Day30
            // 
            this.lbl_Day30.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day30.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day30.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day30.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day30.Height = 0.156F;
            this.lbl_Day30.HyperLink = "";
            this.lbl_Day30.Left = 6.85F;
            this.lbl_Day30.MultiLine = false;
            this.lbl_Day30.Name = "lbl_Day30";
            this.lbl_Day30.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day30.Text = "30";
            this.lbl_Day30.Top = 0.25F;
            this.lbl_Day30.Visible = false;
            this.lbl_Day30.Width = 0.15F;
            // 
            // lbl_Day31
            // 
            this.lbl_Day31.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day31.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day31.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day31.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day31.Height = 0.156F;
            this.lbl_Day31.HyperLink = "";
            this.lbl_Day31.Left = 7F;
            this.lbl_Day31.MultiLine = false;
            this.lbl_Day31.Name = "lbl_Day31";
            this.lbl_Day31.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day31.Text = "31";
            this.lbl_Day31.Top = 0.25F;
            this.lbl_Day31.Visible = false;
            this.lbl_Day31.Width = 0.15F;
            // 
            // lbl_Day8
            // 
            this.lbl_Day8.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day8.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day8.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day8.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day8.Height = 0.156F;
            this.lbl_Day8.HyperLink = "";
            this.lbl_Day8.Left = 3.549998F;
            this.lbl_Day8.MultiLine = false;
            this.lbl_Day8.Name = "lbl_Day8";
            this.lbl_Day8.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day8.Text = "8";
            this.lbl_Day8.Top = 0.25F;
            this.lbl_Day8.Visible = false;
            this.lbl_Day8.Width = 0.15F;
            // 
            // lbl_Day2
            // 
            this.lbl_Day2.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day2.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day2.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day2.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day2.Height = 0.156F;
            this.lbl_Day2.HyperLink = "";
            this.lbl_Day2.Left = 2.649997F;
            this.lbl_Day2.MultiLine = false;
            this.lbl_Day2.Name = "lbl_Day2";
            this.lbl_Day2.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day2.Text = "2";
            this.lbl_Day2.Top = 0.25F;
            this.lbl_Day2.Visible = false;
            this.lbl_Day2.Width = 0.15F;
            // 
            // lbl_Day3
            // 
            this.lbl_Day3.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day3.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day3.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day3.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day3.Height = 0.156F;
            this.lbl_Day3.HyperLink = "";
            this.lbl_Day3.Left = 2.799997F;
            this.lbl_Day3.MultiLine = false;
            this.lbl_Day3.Name = "lbl_Day3";
            this.lbl_Day3.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day3.Text = "3";
            this.lbl_Day3.Top = 0.25F;
            this.lbl_Day3.Visible = false;
            this.lbl_Day3.Width = 0.15F;
            // 
            // lbl_Day4
            // 
            this.lbl_Day4.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day4.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day4.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day4.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day4.Height = 0.156F;
            this.lbl_Day4.HyperLink = "";
            this.lbl_Day4.Left = 2.949997F;
            this.lbl_Day4.MultiLine = false;
            this.lbl_Day4.Name = "lbl_Day4";
            this.lbl_Day4.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day4.Text = "4";
            this.lbl_Day4.Top = 0.25F;
            this.lbl_Day4.Visible = false;
            this.lbl_Day4.Width = 0.15F;
            // 
            // lbl_Day5
            // 
            this.lbl_Day5.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day5.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day5.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day5.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day5.Height = 0.156F;
            this.lbl_Day5.HyperLink = "";
            this.lbl_Day5.Left = 3.099998F;
            this.lbl_Day5.MultiLine = false;
            this.lbl_Day5.Name = "lbl_Day5";
            this.lbl_Day5.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day5.Text = "5";
            this.lbl_Day5.Top = 0.25F;
            this.lbl_Day5.Visible = false;
            this.lbl_Day5.Width = 0.15F;
            // 
            // lbl_Day6
            // 
            this.lbl_Day6.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day6.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day6.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day6.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day6.Height = 0.156F;
            this.lbl_Day6.HyperLink = "";
            this.lbl_Day6.Left = 3.249998F;
            this.lbl_Day6.MultiLine = false;
            this.lbl_Day6.Name = "lbl_Day6";
            this.lbl_Day6.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day6.Text = "6";
            this.lbl_Day6.Top = 0.25F;
            this.lbl_Day6.Visible = false;
            this.lbl_Day6.Width = 0.15F;
            // 
            // lbl_Day7
            // 
            this.lbl_Day7.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Day7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day7.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Day7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day7.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Day7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day7.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Day7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Day7.Height = 0.156F;
            this.lbl_Day7.HyperLink = "";
            this.lbl_Day7.Left = 3.399998F;
            this.lbl_Day7.MultiLine = false;
            this.lbl_Day7.Name = "lbl_Day7";
            this.lbl_Day7.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ ゴシック; vertical-align: top; ";
            this.lbl_Day7.Text = "7";
            this.lbl_Day7.Top = 0.25F;
            this.lbl_Day7.Visible = false;
            this.lbl_Day7.Width = 0.15F;
            // 
            // lbl_Dow1
            // 
            this.lbl_Dow1.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow1.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow1.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow1.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow1.Height = 0.156F;
            this.lbl_Dow1.HyperLink = "";
            this.lbl_Dow1.Left = 2.499997F;
            this.lbl_Dow1.MultiLine = false;
            this.lbl_Dow1.Name = "lbl_Dow1";
            this.lbl_Dow1.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow1.Text = "1";
            this.lbl_Dow1.Top = 0.4375F;
            this.lbl_Dow1.Visible = false;
            this.lbl_Dow1.Width = 0.15F;
            // 
            // lbl_Dow9
            // 
            this.lbl_Dow9.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow9.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow9.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow9.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow9.Height = 0.156F;
            this.lbl_Dow9.HyperLink = "";
            this.lbl_Dow9.Left = 3.699998F;
            this.lbl_Dow9.MultiLine = false;
            this.lbl_Dow9.Name = "lbl_Dow9";
            this.lbl_Dow9.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow9.Text = "9";
            this.lbl_Dow9.Top = 0.4375F;
            this.lbl_Dow9.Visible = false;
            this.lbl_Dow9.Width = 0.15F;
            // 
            // lbl_Dow10
            // 
            this.lbl_Dow10.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow10.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow10.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow10.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow10.Height = 0.156F;
            this.lbl_Dow10.HyperLink = "";
            this.lbl_Dow10.Left = 3.849998F;
            this.lbl_Dow10.MultiLine = false;
            this.lbl_Dow10.Name = "lbl_Dow10";
            this.lbl_Dow10.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow10.Text = "10";
            this.lbl_Dow10.Top = 0.4375F;
            this.lbl_Dow10.Visible = false;
            this.lbl_Dow10.Width = 0.15F;
            // 
            // lbl_Dow11
            // 
            this.lbl_Dow11.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow11.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow11.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow11.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow11.Height = 0.156F;
            this.lbl_Dow11.HyperLink = "";
            this.lbl_Dow11.Left = 3.999998F;
            this.lbl_Dow11.MultiLine = false;
            this.lbl_Dow11.Name = "lbl_Dow11";
            this.lbl_Dow11.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow11.Text = "11";
            this.lbl_Dow11.Top = 0.4375F;
            this.lbl_Dow11.Visible = false;
            this.lbl_Dow11.Width = 0.15F;
            // 
            // lbl_Dow12
            // 
            this.lbl_Dow12.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow12.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow12.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow12.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow12.Height = 0.156F;
            this.lbl_Dow12.HyperLink = "";
            this.lbl_Dow12.Left = 4.149998F;
            this.lbl_Dow12.MultiLine = false;
            this.lbl_Dow12.Name = "lbl_Dow12";
            this.lbl_Dow12.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow12.Text = "12";
            this.lbl_Dow12.Top = 0.4375F;
            this.lbl_Dow12.Visible = false;
            this.lbl_Dow12.Width = 0.15F;
            // 
            // lbl_Dow13
            // 
            this.lbl_Dow13.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow13.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow13.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow13.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow13.Height = 0.156F;
            this.lbl_Dow13.HyperLink = "";
            this.lbl_Dow13.Left = 4.299998F;
            this.lbl_Dow13.MultiLine = false;
            this.lbl_Dow13.Name = "lbl_Dow13";
            this.lbl_Dow13.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow13.Text = "13";
            this.lbl_Dow13.Top = 0.4375F;
            this.lbl_Dow13.Visible = false;
            this.lbl_Dow13.Width = 0.15F;
            // 
            // lbl_Dow14
            // 
            this.lbl_Dow14.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow14.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow14.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow14.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow14.Height = 0.156F;
            this.lbl_Dow14.HyperLink = "";
            this.lbl_Dow14.Left = 4.449998F;
            this.lbl_Dow14.MultiLine = false;
            this.lbl_Dow14.Name = "lbl_Dow14";
            this.lbl_Dow14.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow14.Text = "14";
            this.lbl_Dow14.Top = 0.4375F;
            this.lbl_Dow14.Visible = false;
            this.lbl_Dow14.Width = 0.15F;
            // 
            // lbl_Dow15
            // 
            this.lbl_Dow15.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow15.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow15.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow15.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow15.Height = 0.156F;
            this.lbl_Dow15.HyperLink = "";
            this.lbl_Dow15.Left = 4.599998F;
            this.lbl_Dow15.MultiLine = false;
            this.lbl_Dow15.Name = "lbl_Dow15";
            this.lbl_Dow15.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow15.Text = "15";
            this.lbl_Dow15.Top = 0.4375F;
            this.lbl_Dow15.Visible = false;
            this.lbl_Dow15.Width = 0.15F;
            // 
            // lbl_Dow16
            // 
            this.lbl_Dow16.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow16.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow16.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow16.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow16.Height = 0.156F;
            this.lbl_Dow16.HyperLink = "";
            this.lbl_Dow16.Left = 4.749999F;
            this.lbl_Dow16.MultiLine = false;
            this.lbl_Dow16.Name = "lbl_Dow16";
            this.lbl_Dow16.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow16.Text = "16";
            this.lbl_Dow16.Top = 0.4375F;
            this.lbl_Dow16.Visible = false;
            this.lbl_Dow16.Width = 0.15F;
            // 
            // lbl_Dow17
            // 
            this.lbl_Dow17.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow17.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow17.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow17.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow17.Height = 0.156F;
            this.lbl_Dow17.HyperLink = "";
            this.lbl_Dow17.Left = 4.899999F;
            this.lbl_Dow17.MultiLine = false;
            this.lbl_Dow17.Name = "lbl_Dow17";
            this.lbl_Dow17.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow17.Text = "17";
            this.lbl_Dow17.Top = 0.4375F;
            this.lbl_Dow17.Visible = false;
            this.lbl_Dow17.Width = 0.15F;
            // 
            // lbl_Dow18
            // 
            this.lbl_Dow18.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow18.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow18.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow18.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow18.Height = 0.156F;
            this.lbl_Dow18.HyperLink = "";
            this.lbl_Dow18.Left = 5.049999F;
            this.lbl_Dow18.MultiLine = false;
            this.lbl_Dow18.Name = "lbl_Dow18";
            this.lbl_Dow18.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow18.Text = "18";
            this.lbl_Dow18.Top = 0.4375F;
            this.lbl_Dow18.Visible = false;
            this.lbl_Dow18.Width = 0.15F;
            // 
            // lbl_Dow19
            // 
            this.lbl_Dow19.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow19.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow19.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow19.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow19.Height = 0.156F;
            this.lbl_Dow19.HyperLink = "";
            this.lbl_Dow19.Left = 5.199999F;
            this.lbl_Dow19.MultiLine = false;
            this.lbl_Dow19.Name = "lbl_Dow19";
            this.lbl_Dow19.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow19.Text = "19";
            this.lbl_Dow19.Top = 0.4375F;
            this.lbl_Dow19.Visible = false;
            this.lbl_Dow19.Width = 0.15F;
            // 
            // lbl_Dow20
            // 
            this.lbl_Dow20.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow20.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow20.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow20.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow20.Height = 0.156F;
            this.lbl_Dow20.HyperLink = "";
            this.lbl_Dow20.Left = 5.349999F;
            this.lbl_Dow20.MultiLine = false;
            this.lbl_Dow20.Name = "lbl_Dow20";
            this.lbl_Dow20.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow20.Text = "20";
            this.lbl_Dow20.Top = 0.4375F;
            this.lbl_Dow20.Visible = false;
            this.lbl_Dow20.Width = 0.15F;
            // 
            // lbl_Dow21
            // 
            this.lbl_Dow21.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow21.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow21.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow21.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow21.Height = 0.156F;
            this.lbl_Dow21.HyperLink = "";
            this.lbl_Dow21.Left = 5.499999F;
            this.lbl_Dow21.MultiLine = false;
            this.lbl_Dow21.Name = "lbl_Dow21";
            this.lbl_Dow21.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow21.Text = "21";
            this.lbl_Dow21.Top = 0.4375F;
            this.lbl_Dow21.Visible = false;
            this.lbl_Dow21.Width = 0.15F;
            // 
            // lbl_Dow22
            // 
            this.lbl_Dow22.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow22.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow22.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow22.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow22.Height = 0.156F;
            this.lbl_Dow22.HyperLink = "";
            this.lbl_Dow22.Left = 5.649999F;
            this.lbl_Dow22.MultiLine = false;
            this.lbl_Dow22.Name = "lbl_Dow22";
            this.lbl_Dow22.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow22.Text = "22";
            this.lbl_Dow22.Top = 0.4375F;
            this.lbl_Dow22.Visible = false;
            this.lbl_Dow22.Width = 0.15F;
            // 
            // lbl_Dow23
            // 
            this.lbl_Dow23.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow23.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow23.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow23.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow23.Height = 0.156F;
            this.lbl_Dow23.HyperLink = "";
            this.lbl_Dow23.Left = 5.799999F;
            this.lbl_Dow23.MultiLine = false;
            this.lbl_Dow23.Name = "lbl_Dow23";
            this.lbl_Dow23.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow23.Text = "23";
            this.lbl_Dow23.Top = 0.4375F;
            this.lbl_Dow23.Visible = false;
            this.lbl_Dow23.Width = 0.15F;
            // 
            // lbl_Dow24
            // 
            this.lbl_Dow24.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow24.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow24.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow24.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow24.Height = 0.156F;
            this.lbl_Dow24.HyperLink = "";
            this.lbl_Dow24.Left = 5.949999F;
            this.lbl_Dow24.MultiLine = false;
            this.lbl_Dow24.Name = "lbl_Dow24";
            this.lbl_Dow24.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow24.Text = "24";
            this.lbl_Dow24.Top = 0.4375F;
            this.lbl_Dow24.Visible = false;
            this.lbl_Dow24.Width = 0.15F;
            // 
            // lbl_Dow25
            // 
            this.lbl_Dow25.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow25.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow25.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow25.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow25.Height = 0.156F;
            this.lbl_Dow25.HyperLink = "";
            this.lbl_Dow25.Left = 6.099999F;
            this.lbl_Dow25.MultiLine = false;
            this.lbl_Dow25.Name = "lbl_Dow25";
            this.lbl_Dow25.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow25.Text = "25";
            this.lbl_Dow25.Top = 0.4375F;
            this.lbl_Dow25.Visible = false;
            this.lbl_Dow25.Width = 0.15F;
            // 
            // lbl_Dow26
            // 
            this.lbl_Dow26.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow26.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow26.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow26.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow26.Height = 0.156F;
            this.lbl_Dow26.HyperLink = "";
            this.lbl_Dow26.Left = 6.25F;
            this.lbl_Dow26.MultiLine = false;
            this.lbl_Dow26.Name = "lbl_Dow26";
            this.lbl_Dow26.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow26.Text = "26";
            this.lbl_Dow26.Top = 0.4375F;
            this.lbl_Dow26.Visible = false;
            this.lbl_Dow26.Width = 0.15F;
            // 
            // lbl_Dow27
            // 
            this.lbl_Dow27.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow27.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow27.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow27.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow27.Height = 0.156F;
            this.lbl_Dow27.HyperLink = "";
            this.lbl_Dow27.Left = 6.4F;
            this.lbl_Dow27.MultiLine = false;
            this.lbl_Dow27.Name = "lbl_Dow27";
            this.lbl_Dow27.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow27.Text = "27";
            this.lbl_Dow27.Top = 0.4375F;
            this.lbl_Dow27.Visible = false;
            this.lbl_Dow27.Width = 0.15F;
            // 
            // lbl_Dow28
            // 
            this.lbl_Dow28.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow28.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow28.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow28.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow28.Height = 0.156F;
            this.lbl_Dow28.HyperLink = "";
            this.lbl_Dow28.Left = 6.55F;
            this.lbl_Dow28.MultiLine = false;
            this.lbl_Dow28.Name = "lbl_Dow28";
            this.lbl_Dow28.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow28.Text = "28";
            this.lbl_Dow28.Top = 0.4375F;
            this.lbl_Dow28.Visible = false;
            this.lbl_Dow28.Width = 0.15F;
            // 
            // lbl_Dow29
            // 
            this.lbl_Dow29.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow29.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow29.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow29.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow29.Height = 0.156F;
            this.lbl_Dow29.HyperLink = "";
            this.lbl_Dow29.Left = 6.7F;
            this.lbl_Dow29.MultiLine = false;
            this.lbl_Dow29.Name = "lbl_Dow29";
            this.lbl_Dow29.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow29.Text = "29";
            this.lbl_Dow29.Top = 0.4375F;
            this.lbl_Dow29.Visible = false;
            this.lbl_Dow29.Width = 0.15F;
            // 
            // lbl_Dow30
            // 
            this.lbl_Dow30.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow30.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow30.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow30.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow30.Height = 0.156F;
            this.lbl_Dow30.HyperLink = "";
            this.lbl_Dow30.Left = 6.85F;
            this.lbl_Dow30.MultiLine = false;
            this.lbl_Dow30.Name = "lbl_Dow30";
            this.lbl_Dow30.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow30.Text = "30";
            this.lbl_Dow30.Top = 0.4375F;
            this.lbl_Dow30.Visible = false;
            this.lbl_Dow30.Width = 0.15F;
            // 
            // lbl_Dow31
            // 
            this.lbl_Dow31.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow31.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow31.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow31.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow31.Height = 0.156F;
            this.lbl_Dow31.HyperLink = "";
            this.lbl_Dow31.Left = 7F;
            this.lbl_Dow31.MultiLine = false;
            this.lbl_Dow31.Name = "lbl_Dow31";
            this.lbl_Dow31.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow31.Text = "31";
            this.lbl_Dow31.Top = 0.4375F;
            this.lbl_Dow31.Visible = false;
            this.lbl_Dow31.Width = 0.15F;
            // 
            // lbl_Dow8
            // 
            this.lbl_Dow8.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow8.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow8.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow8.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow8.Height = 0.156F;
            this.lbl_Dow8.HyperLink = "";
            this.lbl_Dow8.Left = 3.549998F;
            this.lbl_Dow8.MultiLine = false;
            this.lbl_Dow8.Name = "lbl_Dow8";
            this.lbl_Dow8.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow8.Text = "8";
            this.lbl_Dow8.Top = 0.4375F;
            this.lbl_Dow8.Visible = false;
            this.lbl_Dow8.Width = 0.15F;
            // 
            // lbl_Dow2
            // 
            this.lbl_Dow2.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow2.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow2.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow2.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow2.Height = 0.156F;
            this.lbl_Dow2.HyperLink = "";
            this.lbl_Dow2.Left = 2.649997F;
            this.lbl_Dow2.MultiLine = false;
            this.lbl_Dow2.Name = "lbl_Dow2";
            this.lbl_Dow2.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow2.Text = "2";
            this.lbl_Dow2.Top = 0.4375F;
            this.lbl_Dow2.Visible = false;
            this.lbl_Dow2.Width = 0.15F;
            // 
            // lbl_Dow3
            // 
            this.lbl_Dow3.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow3.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow3.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow3.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow3.Height = 0.156F;
            this.lbl_Dow3.HyperLink = "";
            this.lbl_Dow3.Left = 2.799997F;
            this.lbl_Dow3.MultiLine = false;
            this.lbl_Dow3.Name = "lbl_Dow3";
            this.lbl_Dow3.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow3.Text = "3";
            this.lbl_Dow3.Top = 0.4375F;
            this.lbl_Dow3.Visible = false;
            this.lbl_Dow3.Width = 0.15F;
            // 
            // lbl_Dow4
            // 
            this.lbl_Dow4.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow4.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow4.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow4.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow4.Height = 0.156F;
            this.lbl_Dow4.HyperLink = "";
            this.lbl_Dow4.Left = 2.949997F;
            this.lbl_Dow4.MultiLine = false;
            this.lbl_Dow4.Name = "lbl_Dow4";
            this.lbl_Dow4.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow4.Text = "4";
            this.lbl_Dow4.Top = 0.4375F;
            this.lbl_Dow4.Visible = false;
            this.lbl_Dow4.Width = 0.15F;
            // 
            // lbl_Dow5
            // 
            this.lbl_Dow5.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow5.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow5.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow5.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow5.Height = 0.156F;
            this.lbl_Dow5.HyperLink = "";
            this.lbl_Dow5.Left = 3.099998F;
            this.lbl_Dow5.MultiLine = false;
            this.lbl_Dow5.Name = "lbl_Dow5";
            this.lbl_Dow5.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow5.Text = "5";
            this.lbl_Dow5.Top = 0.4375F;
            this.lbl_Dow5.Visible = false;
            this.lbl_Dow5.Width = 0.15F;
            // 
            // lbl_Dow6
            // 
            this.lbl_Dow6.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow6.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow6.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow6.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow6.Height = 0.156F;
            this.lbl_Dow6.HyperLink = "";
            this.lbl_Dow6.Left = 3.249998F;
            this.lbl_Dow6.MultiLine = false;
            this.lbl_Dow6.Name = "lbl_Dow6";
            this.lbl_Dow6.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow6.Text = "6";
            this.lbl_Dow6.Top = 0.4375F;
            this.lbl_Dow6.Visible = false;
            this.lbl_Dow6.Width = 0.15F;
            // 
            // lbl_Dow7
            // 
            this.lbl_Dow7.Border.BottomColor = System.Drawing.Color.Black;
            this.lbl_Dow7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow7.Border.LeftColor = System.Drawing.Color.Black;
            this.lbl_Dow7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow7.Border.RightColor = System.Drawing.Color.Black;
            this.lbl_Dow7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow7.Border.TopColor = System.Drawing.Color.Black;
            this.lbl_Dow7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbl_Dow7.Height = 0.156F;
            this.lbl_Dow7.HyperLink = "";
            this.lbl_Dow7.Left = 3.399998F;
            this.lbl_Dow7.MultiLine = false;
            this.lbl_Dow7.Name = "lbl_Dow7";
            this.lbl_Dow7.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lbl_Dow7.Text = "7";
            this.lbl_Dow7.Top = 0.4375F;
            this.lbl_Dow7.Visible = false;
            this.lbl_Dow7.Width = 0.15F;
            // 
            // label98
            // 
            this.label98.Border.BottomColor = System.Drawing.Color.Black;
            this.label98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label98.Border.LeftColor = System.Drawing.Color.Black;
            this.label98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label98.Border.RightColor = System.Drawing.Color.Black;
            this.label98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label98.Border.TopColor = System.Drawing.Color.Black;
            this.label98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label98.Height = 0.156F;
            this.label98.HyperLink = "";
            this.label98.Left = 10.275F;
            this.label98.MultiLine = false;
            this.label98.Name = "label98";
            this.label98.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label98.Text = "粗利平均";
            this.label98.Top = 0.4375F;
            this.label98.Width = 0.5F;
            // 
            // label99
            // 
            this.label99.Border.BottomColor = System.Drawing.Color.Black;
            this.label99.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label99.Border.LeftColor = System.Drawing.Color.Black;
            this.label99.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label99.Border.RightColor = System.Drawing.Color.Black;
            this.label99.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label99.Border.TopColor = System.Drawing.Color.Black;
            this.label99.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label99.Height = 0.156F;
            this.label99.HyperLink = "";
            this.label99.Left = 9.729167F;
            this.label99.MultiLine = false;
            this.label99.Name = "label99";
            this.label99.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label99.Text = "粗利率";
            this.label99.Top = 0.4375F;
            this.label99.Width = 0.4F;
            // 
            // label100
            // 
            this.label100.Border.BottomColor = System.Drawing.Color.Black;
            this.label100.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label100.Border.LeftColor = System.Drawing.Color.Black;
            this.label100.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label100.Border.RightColor = System.Drawing.Color.Black;
            this.label100.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label100.Border.TopColor = System.Drawing.Color.Black;
            this.label100.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label100.Height = 0.156F;
            this.label100.HyperLink = "";
            this.label100.Left = 9.454167F;
            this.label100.MultiLine = false;
            this.label100.Name = "label100";
            this.label100.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label100.Text = "粗利";
            this.label100.Top = 0.4375F;
            this.label100.Width = 0.3F;
            // 
            // label101
            // 
            this.label101.Border.BottomColor = System.Drawing.Color.Black;
            this.label101.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label101.Border.LeftColor = System.Drawing.Color.Black;
            this.label101.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label101.Border.RightColor = System.Drawing.Color.Black;
            this.label101.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label101.Border.TopColor = System.Drawing.Color.Black;
            this.label101.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label101.Height = 0.156F;
            this.label101.HyperLink = "";
            this.label101.Left = 7.203333F;
            this.label101.MultiLine = false;
            this.label101.Name = "label101";
            this.label101.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label101.Text = "伝票";
            this.label101.Top = 0.4375F;
            this.label101.Width = 0.3F;
            // 
            // label102
            // 
            this.label102.Border.BottomColor = System.Drawing.Color.Black;
            this.label102.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label102.Border.LeftColor = System.Drawing.Color.Black;
            this.label102.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label102.Border.RightColor = System.Drawing.Color.Black;
            this.label102.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label102.Border.TopColor = System.Drawing.Color.Black;
            this.label102.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label102.Height = 0.156F;
            this.label102.HyperLink = "";
            this.label102.Left = 7.875F;
            this.label102.MultiLine = false;
            this.label102.Name = "label102";
            this.label102.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label102.Text = "純売上";
            this.label102.Top = 0.4375F;
            this.label102.Width = 0.4F;
            // 
            // label103
            // 
            this.label103.Border.BottomColor = System.Drawing.Color.Black;
            this.label103.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label103.Border.LeftColor = System.Drawing.Color.Black;
            this.label103.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label103.Border.RightColor = System.Drawing.Color.Black;
            this.label103.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label103.Border.TopColor = System.Drawing.Color.Black;
            this.label103.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label103.Height = 0.156F;
            this.label103.HyperLink = "";
            this.label103.Left = 8.518749F;
            this.label103.MultiLine = false;
            this.label103.Name = "label103";
            this.label103.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label103.Text = "売上平均";
            this.label103.Top = 0.4375F;
            this.label103.Width = 0.5F;
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
            this.label5.Left = 9.775F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "平均(金額/営業日)";
            this.label5.Top = 0.25F;
            this.label5.Width = 1F;
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
            this.GrandTotalTitle,
            this.GraFt_SalesCount,
            this.GraFt_SalesTotalTaxExc,
            this.GraFt_SalesAverage,
            this.GraFt_GrossProfit,
            this.GraFt_GrossProfitAverage,
            this.GraFt_GrossProfitRate,
            this.line5});
            this.GrandTotalFooter.Height = 0.3854167F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.GrandTotalTitle.Left = 6.5625F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.0625F;
            this.GrandTotalTitle.Width = 0.5625F;
            // 
            // GraFt_SalesCount
            // 
            this.GraFt_SalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesCount.DataField = "SalesCount";
            this.GraFt_SalesCount.Height = 0.156F;
            this.GraFt_SalesCount.Left = 7.013751F;
            this.GraFt_SalesCount.MultiLine = false;
            this.GraFt_SalesCount.Name = "GraFt_SalesCount";
            this.GraFt_SalesCount.OutputFormat = resources.GetString("GraFt_SalesCount.OutputFormat");
            this.GraFt_SalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesCount.Text = "123,456";
            this.GraFt_SalesCount.Top = 0.0625F;
            this.GraFt_SalesCount.Width = 0.5F;
            // 
            // GraFt_SalesTotalTaxExc
            // 
            this.GraFt_SalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesTotalTaxExc.DataField = "SalesTotalTaxExc";
            this.GraFt_SalesTotalTaxExc.Height = 0.156F;
            this.GraFt_SalesTotalTaxExc.Left = 7.495833F;
            this.GraFt_SalesTotalTaxExc.MultiLine = false;
            this.GraFt_SalesTotalTaxExc.Name = "GraFt_SalesTotalTaxExc";
            this.GraFt_SalesTotalTaxExc.OutputFormat = resources.GetString("GraFt_SalesTotalTaxExc.OutputFormat");
            this.GraFt_SalesTotalTaxExc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_SalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_SalesTotalTaxExc.Text = "1,234,567,890";
            this.GraFt_SalesTotalTaxExc.Top = 0.063F;
            this.GraFt_SalesTotalTaxExc.Width = 0.78F;
            // 
            // GraFt_SalesAverage
            // 
            this.GraFt_SalesAverage.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_SalesAverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesAverage.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_SalesAverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesAverage.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_SalesAverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesAverage.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_SalesAverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_SalesAverage.Height = 0.156F;
            this.GraFt_SalesAverage.Left = 8.243749F;
            this.GraFt_SalesAverage.MultiLine = false;
            this.GraFt_SalesAverage.Name = "GraFt_SalesAverage";
            this.GraFt_SalesAverage.OutputFormat = resources.GetString("GraFt_SalesAverage.OutputFormat");
            this.GraFt_SalesAverage.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_SalesAverage.Text = "1,234,567,890";
            this.GraFt_SalesAverage.Top = 0.0625F;
            this.GraFt_SalesAverage.Visible = false;
            this.GraFt_SalesAverage.Width = 0.78F;
            // 
            // GraFt_GrossProfit
            // 
            this.GraFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfit.DataField = "GrossProfit";
            this.GraFt_GrossProfit.Height = 0.156F;
            this.GraFt_GrossProfit.Left = 8.989583F;
            this.GraFt_GrossProfit.MultiLine = false;
            this.GraFt_GrossProfit.Name = "GraFt_GrossProfit";
            this.GraFt_GrossProfit.OutputFormat = resources.GetString("GraFt_GrossProfit.OutputFormat");
            this.GraFt_GrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_GrossProfit.Text = "1,234,567,890";
            this.GraFt_GrossProfit.Top = 0.0625F;
            this.GraFt_GrossProfit.Width = 0.78F;
            // 
            // GraFt_GrossProfitAverage
            // 
            this.GraFt_GrossProfitAverage.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitAverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitAverage.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitAverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitAverage.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitAverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitAverage.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitAverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitAverage.Height = 0.156F;
            this.GraFt_GrossProfitAverage.Left = 10.085F;
            this.GraFt_GrossProfitAverage.MultiLine = false;
            this.GraFt_GrossProfitAverage.Name = "GraFt_GrossProfitAverage";
            this.GraFt_GrossProfitAverage.OutputFormat = resources.GetString("GraFt_GrossProfitAverage.OutputFormat");
            this.GraFt_GrossProfitAverage.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitAverage.Text = "1,234,567,890";
            this.GraFt_GrossProfitAverage.Top = 0.063F;
            this.GraFt_GrossProfitAverage.Visible = false;
            this.GraFt_GrossProfitAverage.Width = 0.78F;
            // 
            // GraFt_GrossProfitRate
            // 
            this.GraFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_GrossProfitRate.Height = 0.156F;
            this.GraFt_GrossProfitRate.Left = 9.708333F;
            this.GraFt_GrossProfitRate.MultiLine = false;
            this.GraFt_GrossProfitRate.Name = "GraFt_GrossProfitRate";
            this.GraFt_GrossProfitRate.OutputFormat = resources.GetString("GraFt_GrossProfitRate.OutputFormat");
            this.GraFt_GrossProfitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_GrossProfitRate.Text = "100.00";
            this.GraFt_GrossProfitRate.Top = 0.0625F;
            this.GraFt_GrossProfitRate.Width = 0.4F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.SecHd_SectionCode,
            this.SecHd_SectionGuideNm});
            this.SectionHeader.DataField = "SecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.25F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
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
            this.SecHd_SectionCode.Left = 0.063F;
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
            this.SecHd_SectionGuideNm.Left = 0.25F;
            this.SecHd_SectionGuideNm.MultiLine = false;
            this.SecHd_SectionGuideNm.Name = "SecHd_SectionGuideNm";
            this.SecHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SecHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SecHd_SectionGuideNm.Top = 0.01F;
            this.SecHd_SectionGuideNm.Width = 1.1875F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionTitle,
            this.SecFt_SalesCount,
            this.SecFt_SalesTotalTaxExc,
            this.SecFt_SalesAverage,
            this.SecFt_GrossProfit,
            this.SecFt_GrossProfitAverage,
            this.SecFt_GrossProfitRate,
            this.SecFt_BusinessDays,
            this.line4});
            this.SectionFooter.Height = 0.6458333F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
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
            this.SectionTitle.Left = 6.5625F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0.0625F;
            this.SectionTitle.Width = 0.5625F;
            // 
            // SecFt_SalesCount
            // 
            this.SecFt_SalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesCount.DataField = "SalesCount";
            this.SecFt_SalesCount.Height = 0.156F;
            this.SecFt_SalesCount.Left = 7.013751F;
            this.SecFt_SalesCount.MultiLine = false;
            this.SecFt_SalesCount.Name = "SecFt_SalesCount";
            this.SecFt_SalesCount.OutputFormat = resources.GetString("SecFt_SalesCount.OutputFormat");
            this.SecFt_SalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesCount.SummaryGroup = "SectionHeader";
            this.SecFt_SalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesCount.Text = "123,456";
            this.SecFt_SalesCount.Top = 0.0625F;
            this.SecFt_SalesCount.Width = 0.5F;
            // 
            // SecFt_SalesTotalTaxExc
            // 
            this.SecFt_SalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesTotalTaxExc.DataField = "SalesTotalTaxExc";
            this.SecFt_SalesTotalTaxExc.Height = 0.156F;
            this.SecFt_SalesTotalTaxExc.Left = 7.495833F;
            this.SecFt_SalesTotalTaxExc.MultiLine = false;
            this.SecFt_SalesTotalTaxExc.Name = "SecFt_SalesTotalTaxExc";
            this.SecFt_SalesTotalTaxExc.OutputFormat = resources.GetString("SecFt_SalesTotalTaxExc.OutputFormat");
            this.SecFt_SalesTotalTaxExc.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesTotalTaxExc.SummaryGroup = "SectionHeader";
            this.SecFt_SalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_SalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_SalesTotalTaxExc.Text = "1,234,567,890";
            this.SecFt_SalesTotalTaxExc.Top = 0.063F;
            this.SecFt_SalesTotalTaxExc.Width = 0.78F;
            // 
            // SecFt_SalesAverage
            // 
            this.SecFt_SalesAverage.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_SalesAverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesAverage.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_SalesAverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesAverage.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_SalesAverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesAverage.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_SalesAverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_SalesAverage.Height = 0.156F;
            this.SecFt_SalesAverage.Left = 8.243749F;
            this.SecFt_SalesAverage.MultiLine = false;
            this.SecFt_SalesAverage.Name = "SecFt_SalesAverage";
            this.SecFt_SalesAverage.OutputFormat = resources.GetString("SecFt_SalesAverage.OutputFormat");
            this.SecFt_SalesAverage.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_SalesAverage.Text = "1,234,567,890";
            this.SecFt_SalesAverage.Top = 0.0625F;
            this.SecFt_SalesAverage.Width = 0.78F;
            // 
            // SecFt_GrossProfit
            // 
            this.SecFt_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfit.DataField = "GrossProfit";
            this.SecFt_GrossProfit.Height = 0.156F;
            this.SecFt_GrossProfit.Left = 8.989583F;
            this.SecFt_GrossProfit.MultiLine = false;
            this.SecFt_GrossProfit.Name = "SecFt_GrossProfit";
            this.SecFt_GrossProfit.OutputFormat = resources.GetString("SecFt_GrossProfit.OutputFormat");
            this.SecFt_GrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfit.SummaryGroup = "SectionHeader";
            this.SecFt_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossProfit.Text = "1,234,567,890";
            this.SecFt_GrossProfit.Top = 0.0625F;
            this.SecFt_GrossProfit.Width = 0.78F;
            // 
            // SecFt_GrossProfitAverage
            // 
            this.SecFt_GrossProfitAverage.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitAverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitAverage.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitAverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitAverage.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitAverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitAverage.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitAverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitAverage.Height = 0.156F;
            this.SecFt_GrossProfitAverage.Left = 10.085F;
            this.SecFt_GrossProfitAverage.MultiLine = false;
            this.SecFt_GrossProfitAverage.Name = "SecFt_GrossProfitAverage";
            this.SecFt_GrossProfitAverage.OutputFormat = resources.GetString("SecFt_GrossProfitAverage.OutputFormat");
            this.SecFt_GrossProfitAverage.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitAverage.Text = "1,234,567,890";
            this.SecFt_GrossProfitAverage.Top = 0.063F;
            this.SecFt_GrossProfitAverage.Width = 0.78F;
            // 
            // SecFt_GrossProfitRate
            // 
            this.SecFt_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossProfitRate.Height = 0.156F;
            this.SecFt_GrossProfitRate.Left = 9.708583F;
            this.SecFt_GrossProfitRate.MultiLine = false;
            this.SecFt_GrossProfitRate.Name = "SecFt_GrossProfitRate";
            this.SecFt_GrossProfitRate.OutputFormat = resources.GetString("SecFt_GrossProfitRate.OutputFormat");
            this.SecFt_GrossProfitRate.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossProfitRate.Text = "100.00";
            this.SecFt_GrossProfitRate.Top = 0.063F;
            this.SecFt_GrossProfitRate.Width = 0.4F;
            // 
            // SecFt_BusinessDays
            // 
            this.SecFt_BusinessDays.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_BusinessDays.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_BusinessDays.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_BusinessDays.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_BusinessDays.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_BusinessDays.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_BusinessDays.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_BusinessDays.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_BusinessDays.DataField = "BusinessDays";
            this.SecFt_BusinessDays.Height = 0.156F;
            this.SecFt_BusinessDays.Left = 8.243749F;
            this.SecFt_BusinessDays.MultiLine = false;
            this.SecFt_BusinessDays.Name = "SecFt_BusinessDays";
            this.SecFt_BusinessDays.OutputFormat = resources.GetString("SecFt_BusinessDays.OutputFormat");
            this.SecFt_BusinessDays.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_BusinessDays.Text = "1,234,567,890";
            this.SecFt_BusinessDays.Top = 0.281F;
            this.SecFt_BusinessDays.Visible = false;
            this.SecFt_BusinessDays.Width = 0.78F;
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
            // PMHNB02183P_01A4C
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
            this.Sections.Add(this.Detail);
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
            this.ReportStart += new System.EventHandler(this.PMHNB02183P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Asterisk31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_CodeTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Month7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Day7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Dow7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label99)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label103)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_SalesAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_SalesAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_BusinessDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

    }
}
