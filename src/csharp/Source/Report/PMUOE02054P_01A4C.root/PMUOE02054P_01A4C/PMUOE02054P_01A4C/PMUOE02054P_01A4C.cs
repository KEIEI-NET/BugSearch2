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
    /// 復旧データ一覧表帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 復旧データ一覧表帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.12.02</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMUOE02054P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMUOE02054P_01A4C()
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

        private RecoveryDataOrderCndtn _recoveryDataOrderCndtn;	// 抽出条件クラス

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
        private GroupHeader SystemDivHeader;
        private GroupFooter SystemDivFooter;
        private Label tb_ReportTitle;
        private Line Line1;
        private Label Label3;
        private TextBox tb_PrintDate;
        private TextBox tb_PrintTime;
        private Label Label2;
        private TextBox tb_PrintPage;
        private SubReport Header_SubReport;
        private TextBox SystemDivName;
        private TextBox UOESupplierCd;
        private TextBox UOESupplierName;
        private TextBox OnlineNo;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox GoodsMakerCd;
        private TextBox AcceptAnOrderCnt;
        private TextBox BoCode;
        private TextBox DataSendName;
        private TextBox UoeRemark1;
        private SubReport Footer_SubReport;
        private Line line5;
        private TextBox SysHd_SectionCode;
        private TextBox SysHd_SectionGuideSnm;
        private Label SysHd_SectionTitle;
        private TextBox SysHd_ExtractCondition;
        private Line line2;
        private Label Lb_Title;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
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
                this._recoveryDataOrderCndtn = (RecoveryDataOrderCndtn)this._printInfo.jyoken;
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
            // 改頁設定
            // 0:する（システム区分毎） 1:しない
            //-------------------------------------------------------
            #region [改頁設定]
            if (_recoveryDataOrderCndtn.NewPageDiv == RecoveryDataOrderCndtn.NewPageDivState.System)
            {
                SystemDivHeader.DataField = PMUOE02059EA.ct_Col_SystemDivCd;
                SystemDivHeader.NewPage = NewPage.Before;
            }

            #endregion
        }

        #endregion

        #region ■コントロールイベント
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
        /// PMUOE02054P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMUOE02054P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
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
            if (string.IsNullOrEmpty(this.GoodsMakerCd.Text)
                || this.GoodsMakerCd.Text.PadLeft(4, '0') == "0000")
            {
                this.GoodsMakerCd.Text = "";
            }
        }

        /// <summary>
        /// SystemDivHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemDivHeader_BeforePrint(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SysHd_SectionCode.Text)
                || this.SysHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SysHd_SectionCode.Text = "";
                this.SysHd_SectionGuideSnm.Text = "";
            }
        }

        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009.03.18</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // インスタンスが作成されていなければ作成
                if (_rptPageFooter == null)
                {
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else
                {
                    // インスタンスが作成されていれば、データソースを初期化する
                    // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                    _rptPageFooter.DataSource = null;
                }

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMUOE02054P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SystemDivName = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierName = new DataDynamics.ActiveReports.TextBox();
            this.OnlineNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCnt = new DataDynamics.ActiveReports.TextBox();
            this.BoCode = new DataDynamics.ActiveReports.TextBox();
            this.DataSendName = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark1 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SystemDivHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SysHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SysHd_SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.SysHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.SysHd_ExtractCondition = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
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
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.SystemDivFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSendName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_ExtractCondition)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
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
            this.tb_ReportTitle.Text = "復旧データ一覧表";
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
            this.SystemDivName,
            this.UOESupplierCd,
            this.UOESupplierName,
            this.OnlineNo,
            this.GoodsNo,
            this.GoodsName,
            this.GoodsMakerCd,
            this.AcceptAnOrderCnt,
            this.BoCode,
            this.DataSendName,
            this.UoeRemark1,
            this.line5});
            this.Detail.Height = 0.3958333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // SystemDivName
            // 
            this.SystemDivName.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName.DataField = "SystemDivName";
            this.SystemDivName.Height = 0.156F;
            this.SystemDivName.Left = 0.0625F;
            this.SystemDivName.MultiLine = false;
            this.SystemDivName.Name = "SystemDivName";
            this.SystemDivName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SystemDivName.Text = "あいうえ";
            this.SystemDivName.Top = 0.0625F;
            this.SystemDivName.Width = 0.5F;
            // 
            // UOESupplierCd
            // 
            this.UOESupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.DataField = "UOESupplierCd";
            this.UOESupplierCd.Height = 0.16F;
            this.UOESupplierCd.Left = 0.5625F;
            this.UOESupplierCd.MultiLine = false;
            this.UOESupplierCd.Name = "UOESupplierCd";
            this.UOESupplierCd.OutputFormat = resources.GetString("UOESupplierCd.OutputFormat");
            this.UOESupplierCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.UOESupplierCd.Text = "123456";
            this.UOESupplierCd.Top = 0.0625F;
            this.UOESupplierCd.Width = 0.4F;
            // 
            // UOESupplierName
            // 
            this.UOESupplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.DataField = "UOESupplierName";
            this.UOESupplierName.Height = 0.156F;
            this.UOESupplierName.Left = 0.9625F;
            this.UOESupplierName.MultiLine = false;
            this.UOESupplierName.Name = "UOESupplierName";
            this.UOESupplierName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOESupplierName.Text = "あいうえおかきくけこさしすせそ";
            this.UOESupplierName.Top = 0.0625F;
            this.UOESupplierName.Width = 1.7F;
            // 
            // OnlineNo
            // 
            this.OnlineNo.Border.BottomColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.Border.LeftColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.Border.RightColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.Border.TopColor = System.Drawing.Color.Black;
            this.OnlineNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo.DataField = "OnlineNo";
            this.OnlineNo.Height = 0.16F;
            this.OnlineNo.Left = 2.6625F;
            this.OnlineNo.MultiLine = false;
            this.OnlineNo.Name = "OnlineNo";
            this.OnlineNo.OutputFormat = resources.GetString("OnlineNo.OutputFormat");
            this.OnlineNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.OnlineNo.Text = "123456789";
            this.OnlineNo.Top = 0.0625F;
            this.OnlineNo.Width = 0.55F;
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.156F;
            this.GoodsNo.Left = 3.2125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.4F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.156F;
            this.GoodsName.Left = 4.6125F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.15F;
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.16F;
            this.GoodsMakerCd.Left = 5.7625F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.0625F;
            this.GoodsMakerCd.Width = 0.3F;
            // 
            // AcceptAnOrderCnt
            // 
            this.AcceptAnOrderCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.DataField = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.Height = 0.16F;
            this.AcceptAnOrderCnt.Left = 6.0625F;
            this.AcceptAnOrderCnt.MultiLine = false;
            this.AcceptAnOrderCnt.Name = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.OutputFormat = resources.GetString("AcceptAnOrderCnt.OutputFormat");
            this.AcceptAnOrderCnt.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.AcceptAnOrderCnt.Text = "1234";
            this.AcceptAnOrderCnt.Top = 0.0625F;
            this.AcceptAnOrderCnt.Width = 0.3F;
            // 
            // BoCode
            // 
            this.BoCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BoCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BoCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.Border.RightColor = System.Drawing.Color.Black;
            this.BoCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.Border.TopColor = System.Drawing.Color.Black;
            this.BoCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.DataField = "BoCode";
            this.BoCode.Height = 0.156F;
            this.BoCode.Left = 6.3625F;
            this.BoCode.MultiLine = false;
            this.BoCode.Name = "BoCode";
            this.BoCode.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.BoCode.Text = "1";
            this.BoCode.Top = 0.0625F;
            this.BoCode.Width = 0.15F;
            // 
            // DataSendName
            // 
            this.DataSendName.Border.BottomColor = System.Drawing.Color.Black;
            this.DataSendName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataSendName.Border.LeftColor = System.Drawing.Color.Black;
            this.DataSendName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataSendName.Border.RightColor = System.Drawing.Color.Black;
            this.DataSendName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataSendName.Border.TopColor = System.Drawing.Color.Black;
            this.DataSendName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataSendName.DataField = "DataSendName";
            this.DataSendName.Height = 0.156F;
            this.DataSendName.Left = 7.6625F;
            this.DataSendName.MultiLine = false;
            this.DataSendName.Name = "DataSendName";
            this.DataSendName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.DataSendName.Text = "異常終了";
            this.DataSendName.Top = 0.0625F;
            this.DataSendName.Width = 0.5F;
            // 
            // UoeRemark1
            // 
            this.UoeRemark1.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1.DataField = "UoeRemark1";
            this.UoeRemark1.Height = 0.156F;
            this.UoeRemark1.Left = 6.5125F;
            this.UoeRemark1.MultiLine = false;
            this.UoeRemark1.Name = "UoeRemark1";
            this.UoeRemark1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UoeRemark1.Text = "12345678901234567890";
            this.UoeRemark1.Top = 0.0625F;
            this.UoeRemark1.Width = 1.15F;
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
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2916667F;
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
            this.ExtraHeader.Height = 0F;
            this.ExtraHeader.KeepTogether = true;
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
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Height = 0F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.Visible = false;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
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
            this.GrandTotalFooter.Height = 0F;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // SectionFooter
            // 
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // SystemDivHeader
            // 
            this.SystemDivHeader.CanShrink = true;
            this.SystemDivHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SysHd_SectionCode,
            this.SysHd_SectionGuideSnm,
            this.SysHd_SectionTitle,
            this.SysHd_ExtractCondition,
            this.line2,
            this.Lb_Title,
            this.label1,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.label16,
            this.label17});
            this.SystemDivHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SystemDivHeader.Height = 0.6354167F;
            this.SystemDivHeader.KeepTogether = true;
            this.SystemDivHeader.Name = "SystemDivHeader";
            this.SystemDivHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SystemDivHeader.BeforePrint += new System.EventHandler(this.SystemDivHeader_BeforePrint);
            // 
            // SysHd_SectionCode
            // 
            this.SysHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SysHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SysHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SysHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SysHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionCode.DataField = "SectionCode";
            this.SysHd_SectionCode.Height = 0.156F;
            this.SysHd_SectionCode.Left = 0.4375F;
            this.SysHd_SectionCode.MultiLine = false;
            this.SysHd_SectionCode.Name = "SysHd_SectionCode";
            this.SysHd_SectionCode.OutputFormat = resources.GetString("SysHd_SectionCode.OutputFormat");
            this.SysHd_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SysHd_SectionCode.Text = "12";
            this.SysHd_SectionCode.Top = 0F;
            this.SysHd_SectionCode.Width = 0.2F;
            // 
            // SysHd_SectionGuideSnm
            // 
            this.SysHd_SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SysHd_SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SysHd_SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SysHd_SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SysHd_SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionGuideSnm.DataField = "SectionGuideSnm";
            this.SysHd_SectionGuideSnm.Height = 0.15625F;
            this.SysHd_SectionGuideSnm.Left = 0.625F;
            this.SysHd_SectionGuideSnm.MultiLine = false;
            this.SysHd_SectionGuideSnm.Name = "SysHd_SectionGuideSnm";
            this.SysHd_SectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SysHd_SectionGuideSnm.Text = "あいうえおかきくけこ";
            this.SysHd_SectionGuideSnm.Top = 0F;
            this.SysHd_SectionGuideSnm.Width = 1.1875F;
            // 
            // SysHd_SectionTitle
            // 
            this.SysHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SysHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SysHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SysHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SysHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_SectionTitle.Height = 0.156F;
            this.SysHd_SectionTitle.HyperLink = "";
            this.SysHd_SectionTitle.Left = 0.0625F;
            this.SysHd_SectionTitle.MultiLine = false;
            this.SysHd_SectionTitle.Name = "SysHd_SectionTitle";
            this.SysHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SysHd_SectionTitle.Text = "拠点：";
            this.SysHd_SectionTitle.Top = 0F;
            this.SysHd_SectionTitle.Width = 0.38F;
            // 
            // SysHd_ExtractCondition
            // 
            this.SysHd_ExtractCondition.Border.BottomColor = System.Drawing.Color.Black;
            this.SysHd_ExtractCondition.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_ExtractCondition.Border.LeftColor = System.Drawing.Color.Black;
            this.SysHd_ExtractCondition.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_ExtractCondition.Border.RightColor = System.Drawing.Color.Black;
            this.SysHd_ExtractCondition.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_ExtractCondition.Border.TopColor = System.Drawing.Color.Black;
            this.SysHd_ExtractCondition.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SysHd_ExtractCondition.DataField = "ExtractCondition";
            this.SysHd_ExtractCondition.Height = 0.156F;
            this.SysHd_ExtractCondition.Left = 0.0625F;
            this.SysHd_ExtractCondition.MultiLine = false;
            this.SysHd_ExtractCondition.Name = "SysHd_ExtractCondition";
            this.SysHd_ExtractCondition.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SysHd_ExtractCondition.Text = "抽出条件";
            this.SysHd_ExtractCondition.Top = 0.1875F;
            this.SysHd_ExtractCondition.Width = 5F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0.36F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.36F;
            this.line2.Y2 = 0.36F;
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
            this.Lb_Title.Left = 0.0625F;
            this.Lb_Title.MultiLine = false;
            this.Lb_Title.Name = "Lb_Title";
            this.Lb_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Title.Text = "ｼｽﾃﾑ区分";
            this.Lb_Title.Top = 0.375F;
            this.Lb_Title.Width = 0.5F;
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
            this.label1.Left = 0.5625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "発注先";
            this.label1.Top = 0.375F;
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
            this.label4.Left = 2.6625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "呼出番号";
            this.label4.Top = 0.375F;
            this.label4.Width = 0.55F;
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
            this.label5.Left = 3.2125F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "品番";
            this.label5.Top = 0.375F;
            this.label5.Width = 0.55F;
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
            this.label6.Left = 4.6125F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "品名";
            this.label6.Top = 0.375F;
            this.label6.Width = 0.55F;
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
            this.label7.Left = 5.7625F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "ﾒｰｶｰ";
            this.label7.Top = 0.375F;
            this.label7.Width = 0.3F;
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
            this.label8.Left = 6.0625F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "数量";
            this.label8.Top = 0.375F;
            this.label8.Width = 0.3F;
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
            this.label9.Left = 6.3625F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "BO";
            this.label9.Top = 0.375F;
            this.label9.Width = 0.15F;
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
            this.label10.Left = 6.5125F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "ﾘﾏｰｸ1";
            this.label10.Top = 0.375F;
            this.label10.Width = 0.55F;
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
            this.label11.Left = 7.6625F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "ｴﾗｰ内容";
            this.label11.Top = 0.375F;
            this.label11.Width = 0.5F;
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.156F;
            this.label12.HyperLink = "";
            this.label12.Left = 8.25F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "伝票番号";
            this.label12.Top = 0.375F;
            this.label12.Width = 0.5F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.156F;
            this.label13.HyperLink = "";
            this.label13.Left = 8.75F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "数量";
            this.label13.Top = 0.375F;
            this.label13.Width = 0.3F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.156F;
            this.label14.HyperLink = "";
            this.label14.Left = 9.125F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "伝票番号";
            this.label14.Top = 0.375F;
            this.label14.Width = 0.5F;
            // 
            // label15
            // 
            this.label15.Border.BottomColor = System.Drawing.Color.Black;
            this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.LeftColor = System.Drawing.Color.Black;
            this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.RightColor = System.Drawing.Color.Black;
            this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.TopColor = System.Drawing.Color.Black;
            this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Height = 0.156F;
            this.label15.HyperLink = "";
            this.label15.Left = 9.625F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "数量";
            this.label15.Top = 0.375F;
            this.label15.Width = 0.3F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.156F;
            this.label16.HyperLink = "";
            this.label16.Left = 10F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "伝票番号";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.5F;
            // 
            // label17
            // 
            this.label17.Border.BottomColor = System.Drawing.Color.Black;
            this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.LeftColor = System.Drawing.Color.Black;
            this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.RightColor = System.Drawing.Color.Black;
            this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.TopColor = System.Drawing.Color.Black;
            this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Height = 0.156F;
            this.label17.HyperLink = "";
            this.label17.Left = 10.5F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "数量";
            this.label17.Top = 0.375F;
            this.label17.Width = 0.3F;
            // 
            // SystemDivFooter
            // 
            this.SystemDivFooter.Height = 0F;
            this.SystemDivFooter.Name = "SystemDivFooter";
            // 
            // PMUOE02054P_01A4C
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
            this.Sections.Add(this.SystemDivHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SystemDivFooter);
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
            this.ReportStart += new System.EventHandler(this.PMUOE02054P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSendName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SysHd_ExtractCondition)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

    }
}
