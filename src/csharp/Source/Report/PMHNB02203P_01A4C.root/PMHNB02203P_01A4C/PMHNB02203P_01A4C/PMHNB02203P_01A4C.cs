//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価原価アンマッチリスト
// プログラム概要   : 売価原価アンマッチリスト印刷フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 売価原価アンマッチリスト印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 仕入ｱﾝﾏｯﾁﾘｽﾄのフォームクラスです。</br>
    /// <br>Programmer	: 劉学智</br>
    /// <br>Date		: 2009.04.07</br>
    /// <br></br>
    /// </remarks>
    public class PMHNB02203P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
		/// <summary>
        /// 売価原価アンマッチリストフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 売価原価アンマッチリストフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
        public PMHNB02203P_01A4C()
		{
            InitializeComponent();
		}
		#endregion ■ Constructor
                
        #region ■ Private Member
        private int _printCount;									// 印刷件数用カウンタ

        private string _pageHeaderSortOderTitle;		            // ソート順
        private int _extraCondHeadOutDiv;			                // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;				    // 抽出条件
        private int _pageFooterOutCode;				                // フッター出力区分
        private StringCollection _pageFooters;					    // フッターメッセージ
        private SFCMN06002C _printInfo;						        // 印刷情報クラス
        private string _pageHeaderSubtitle;			                // フォームサブタイトル
        private ArrayList _otherDataList;					        // その他データ
        private RateUnMatchCndtn _rateUnMatchCndtn;		            // 抽出条件クラス

        private DataView _outputDv;						            // 印刷用DataView

        private const string ct_CollectTable = RateUnMatchResult.Tbl_Result_RateUnMatch;    // 売価原価アンマッチリストテーブル名称

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private PageHeader PageHeader;
        private PageFooter PageFooter;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private Label tb_ReportTitle;
        private Label Label3;
        private TextBox tb_PrintDate;
        private Label Label2;
        private TextBox tb_PrintPage;
        private Line Line1;
        private TextBox tb_PrintTime;
        private SubReport Header_SubReport;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Detail Detail;
        private TextBox ProcessKbn;
        private Line line2;
        private Line line3;
        private SubReport Footer_SubReport;
        private Label ProcessKbn_Title;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox PriceKind;
        private TextBox LogicalDelete;
        private TextBox CustRateGrpCode;
        private TextBox CustomerCode;
        private TextBox SupplierCd;
        private TextBox MakerCd;
        private TextBox MakerNm;
        private TextBox GoodsRateRank;
        private TextBox GoodsRateGrpCode;
        private TextBox BLGoodsCode;
        private TextBox GoodsNo;
        private TextBox GoodsNm;
        private TextBox Content;
        private Line line4;
        private TextBox BLGroupCode;
        private Label label15;
        private Label label10;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label16;


        // Disposeチェック用フラグ
        bool disposed = false;
        #endregion ■ Private Member

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
                this._rateUnMatchCndtn = (RateUnMatchCndtn)this._printInfo.jyoken;
                this._outputDv = (DataView)this._printInfo.rdData;
            }
        }

        /// <summary>
        /// その他データ
        /// </summary>
        public ArrayList OtherDataList
        {
            set
            {
                this._otherDataList = value;
                if (this._otherDataList != null)
                {
                    ;
                }
            }
        }

        /// <summary>
        /// 帳票サブタイトル
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderSubtitle = value; }
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
                return 0;
            }
            set
            {
                
            }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■ Private Method
        #region ◆ レポート要素出力設定
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderSubtitle;		   // サブタイトル
            
        }
        #endregion ◆ レポート要素出力設定

        #endregion

        #region ■ Control Event

        #region ◎ PMUOE02074P_01A4C_ReportStart Event
        /// <summary>
        /// PMUOE02074P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
        private void PMUOE02074P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");
        }
        #endregion

        #region ◎ ExtraHeader_Format Event
        /// <summary>
        /// ExtraHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderグループのフォーマットイベント。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
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
        #endregion

        #region ◎ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion

        #region ◎ Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }

        }
        #endregion

        #region ◎ PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.07</br>
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

        
        #endregion ■ Control Event

        #region ActiveReports Designer generated code
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMHNB02203P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.PriceKind = new DataDynamics.ActiveReports.TextBox();
            this.LogicalDelete = new DataDynamics.ActiveReports.TextBox();
            this.CustRateGrpCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerNm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsRateRank = new DataDynamics.ActiveReports.TextBox();
            this.GoodsRateGrpCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNm = new DataDynamics.ActiveReports.TextBox();
            this.Content = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ProcessKbn = new DataDynamics.ActiveReports.TextBox();
            this.ProcessKbn_Title = new DataDynamics.ActiveReports.Label();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.PriceKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogicalDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Content)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessKbn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessKbn_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.PriceKind,
            this.LogicalDelete,
            this.CustRateGrpCode,
            this.CustomerCode,
            this.SupplierCd,
            this.MakerCd,
            this.MakerNm,
            this.GoodsRateRank,
            this.GoodsRateGrpCode,
            this.BLGoodsCode,
            this.GoodsNo,
            this.GoodsNm,
            this.Content,
            this.BLGroupCode,
            this.textBox2,
            this.textBox3});
            this.Detail.Height = 0.15625F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.14F;
            this.line2.Width = 14.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 14.8F;
            this.line2.Y1 = 0.14F;
            this.line2.Y2 = 0.14F;
            // 
            // PriceKind
            // 
            this.PriceKind.Border.BottomColor = System.Drawing.Color.Black;
            this.PriceKind.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriceKind.Border.LeftColor = System.Drawing.Color.Black;
            this.PriceKind.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriceKind.Border.RightColor = System.Drawing.Color.Black;
            this.PriceKind.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriceKind.Border.TopColor = System.Drawing.Color.Black;
            this.PriceKind.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PriceKind.DataField = "UnitPriceKindNm";
            this.PriceKind.Height = 0.125F;
            this.PriceKind.Left = 0.875F;
            this.PriceKind.MultiLine = false;
            this.PriceKind.Name = "PriceKind";
            this.PriceKind.OutputFormat = resources.GetString("PriceKind.OutputFormat");
            this.PriceKind.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.PriceKind.Text = "ああああ";
            this.PriceKind.Top = 0F;
            this.PriceKind.Width = 0.4375F;
            // 
            // LogicalDelete
            // 
            this.LogicalDelete.Border.BottomColor = System.Drawing.Color.Black;
            this.LogicalDelete.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDelete.Border.LeftColor = System.Drawing.Color.Black;
            this.LogicalDelete.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDelete.Border.RightColor = System.Drawing.Color.Black;
            this.LogicalDelete.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDelete.Border.TopColor = System.Drawing.Color.Black;
            this.LogicalDelete.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LogicalDelete.DataField = "LogicalDeleteName";
            this.LogicalDelete.Height = 0.125F;
            this.LogicalDelete.Left = 1.3125F;
            this.LogicalDelete.MultiLine = false;
            this.LogicalDelete.Name = "LogicalDelete";
            this.LogicalDelete.OutputFormat = resources.GetString("LogicalDelete.OutputFormat");
            this.LogicalDelete.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.LogicalDelete.Text = "ああああ";
            this.LogicalDelete.Top = 0F;
            this.LogicalDelete.Width = 0.4375F;
            // 
            // CustRateGrpCode
            // 
            this.CustRateGrpCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustRateGrpCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustRateGrpCode.DataField = "CustRateGrpCodeForPrint";
            this.CustRateGrpCode.Height = 0.125F;
            this.CustRateGrpCode.Left = 1.75F;
            this.CustRateGrpCode.MultiLine = false;
            this.CustRateGrpCode.Name = "CustRateGrpCode";
            this.CustRateGrpCode.OutputFormat = resources.GetString("CustRateGrpCode.OutputFormat");
            this.CustRateGrpCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CustRateGrpCode.Text = "1234";
            this.CustRateGrpCode.Top = 0F;
            this.CustRateGrpCode.Width = 0.25F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.DataField = "CustomerCodeForPrint";
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 2F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.CustomerCode.Text = "12345678";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Width = 0.4375F;
            // 
            // SupplierCd
            // 
            this.SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.DataField = "SupplierCdForPrint";
            this.SupplierCd.Height = 0.125F;
            this.SupplierCd.Left = 2.4375F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0F;
            this.SupplierCd.Width = 0.375F;
            // 
            // MakerCd
            // 
            this.MakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.MakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.MakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerCd.DataField = "GoodsMakerCdForPrint";
            this.MakerCd.Height = 0.125F;
            this.MakerCd.Left = 2.8125F;
            this.MakerCd.MultiLine = false;
            this.MakerCd.Name = "MakerCd";
            this.MakerCd.OutputFormat = resources.GetString("MakerCd.OutputFormat");
            this.MakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.MakerCd.Text = "1234";
            this.MakerCd.Top = 0F;
            this.MakerCd.Width = 0.25F;
            // 
            // MakerNm
            // 
            this.MakerNm.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerNm.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerNm.Border.RightColor = System.Drawing.Color.Black;
            this.MakerNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerNm.Border.TopColor = System.Drawing.Color.Black;
            this.MakerNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerNm.DataField = "GoodsMakerNm";
            this.MakerNm.Height = 0.125F;
            this.MakerNm.Left = 3.0625F;
            this.MakerNm.MultiLine = false;
            this.MakerNm.Name = "MakerNm";
            this.MakerNm.OutputFormat = resources.GetString("MakerNm.OutputFormat");
            this.MakerNm.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.MakerNm.Text = "123456789012345678901234567890";
            this.MakerNm.Top = 0F;
            this.MakerNm.Width = 1.5F;
            // 
            // GoodsRateRank
            // 
            this.GoodsRateRank.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsRateRank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateRank.DataField = "GoodsRateRankForPrint";
            this.GoodsRateRank.Height = 0.125F;
            this.GoodsRateRank.Left = 4.5625F;
            this.GoodsRateRank.MultiLine = false;
            this.GoodsRateRank.Name = "GoodsRateRank";
            this.GoodsRateRank.OutputFormat = resources.GetString("GoodsRateRank.OutputFormat");
            this.GoodsRateRank.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsRateRank.Text = "12345678";
            this.GoodsRateRank.Top = 0F;
            this.GoodsRateRank.Width = 0.4375F;
            // 
            // GoodsRateGrpCode
            // 
            this.GoodsRateGrpCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsRateGrpCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsRateGrpCode.DataField = "GoodsRateGrpCodeForPrint";
            this.GoodsRateGrpCode.Height = 0.125F;
            this.GoodsRateGrpCode.Left = 5F;
            this.GoodsRateGrpCode.MultiLine = false;
            this.GoodsRateGrpCode.Name = "GoodsRateGrpCode";
            this.GoodsRateGrpCode.OutputFormat = resources.GetString("GoodsRateGrpCode.OutputFormat");
            this.GoodsRateGrpCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsRateGrpCode.Text = "1234";
            this.GoodsRateGrpCode.Top = 0F;
            this.GoodsRateGrpCode.Width = 0.375F;
            // 
            // BLGoodsCode
            // 
            this.BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.DataField = "BLGoodsCodeForPrint";
            this.BLGoodsCode.Height = 0.125F;
            this.BLGoodsCode.Left = 5.8125F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0F;
            this.BLGoodsCode.Width = 0.3125F;
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
            this.GoodsNo.DataField = "GoodsNoForPrint";
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 6.135F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.25F;
            // 
            // GoodsNm
            // 
            this.GoodsNm.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNm.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNm.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNm.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNm.DataField = "GoodsNm";
            this.GoodsNm.Height = 0.125F;
            this.GoodsNm.Left = 7.375F;
            this.GoodsNm.MultiLine = false;
            this.GoodsNm.Name = "GoodsNm";
            this.GoodsNm.OutputFormat = resources.GetString("GoodsNm.OutputFormat");
            this.GoodsNm.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.GoodsNm.Text = "12345678901234567890";
            this.GoodsNm.Top = 0F;
            this.GoodsNm.Width = 1F;
            // 
            // Content
            // 
            this.Content.Border.BottomColor = System.Drawing.Color.Black;
            this.Content.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Content.Border.LeftColor = System.Drawing.Color.Black;
            this.Content.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Content.Border.RightColor = System.Drawing.Color.Black;
            this.Content.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Content.Border.TopColor = System.Drawing.Color.Black;
            this.Content.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Content.DataField = "Content";
            this.Content.Height = 0.125F;
            this.Content.Left = 8.375F;
            this.Content.MultiLine = false;
            this.Content.Name = "Content";
            this.Content.OutputFormat = resources.GetString("Content.OutputFormat");
            this.Content.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.Content.Text = "掛率優先順位に該当無し、商品マスタ未登録、設定値が全てゼロ";
            this.Content.Top = 0F;
            this.Content.Width = 2.8125F;
            // 
            // BLGroupCode
            // 
            this.BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.DataField = "BLGroupCodeForPrint";
            this.BLGroupCode.Height = 0.125F;
            this.BLGroupCode.Left = 5.4375F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0F;
            this.BLGroupCode.Width = 0.375F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "SectionCodeForPrint";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 0F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox2.Text = "99";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.3125F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "SectionName";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 0.1875F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.textBox3.Text = "ああああああ";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.6875F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime});
            this.PageHeader.Height = 0.3125F;
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "売価原価アンマッチリスト";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.75F;
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
            this.Label3.Left = 8.375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
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
            this.tb_PrintDate.Left = 9F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.9375F;
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
            this.Label2.Left = 10.375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
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
            this.tb_PrintPage.Left = 10.875F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
            this.tb_PrintPage.Width = 0.28125F;
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
            this.Line1.Top = 0.25F;
            this.Line1.Width = 14.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 14.8F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
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
            this.tb_PrintTime.Left = 9.875F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2083333F;
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
            this.Footer_SubReport.Height = 0.25F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Visible = false;
            this.Footer_SubReport.Width = 12.0625F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport,
            this.ProcessKbn,
            this.ProcessKbn_Title});
            this.ExtraHeader.Height = 0.1770833F;
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
            this.Header_SubReport.Height = 0.1875F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0.033F;
            this.Header_SubReport.Width = 10.8125F;
            // 
            // ProcessKbn
            // 
            this.ProcessKbn.Border.BottomColor = System.Drawing.Color.Black;
            this.ProcessKbn.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn.Border.LeftColor = System.Drawing.Color.Black;
            this.ProcessKbn.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn.Border.RightColor = System.Drawing.Color.Black;
            this.ProcessKbn.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn.Border.TopColor = System.Drawing.Color.Black;
            this.ProcessKbn.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn.DataField = "ProcessKbn";
            this.ProcessKbn.Height = 0.125F;
            this.ProcessKbn.Left = 0.588F;
            this.ProcessKbn.MultiLine = false;
            this.ProcessKbn.Name = "ProcessKbn";
            this.ProcessKbn.OutputFormat = resources.GetString("ProcessKbn.OutputFormat");
            this.ProcessKbn.Style = "ddo-char-set: 128; text-align: left; font-size: 8.25pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.ProcessKbn.Text = "NNNN";
            this.ProcessKbn.Top = 0.033F;
            this.ProcessKbn.Width = 0.9375F;
            // 
            // ProcessKbn_Title
            // 
            this.ProcessKbn_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ProcessKbn_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ProcessKbn_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ProcessKbn_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ProcessKbn_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessKbn_Title.Height = 0.125F;
            this.ProcessKbn_Title.HyperLink = "";
            this.ProcessKbn_Title.Left = 0F;
            this.ProcessKbn_Title.MultiLine = false;
            this.ProcessKbn_Title.Name = "ProcessKbn_Title";
            this.ProcessKbn_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.ProcessKbn_Title.Text = "処理区分：";
            this.ProcessKbn_Title.Top = 0.033F;
            this.ProcessKbn_Title.Width = 0.5625F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label16,
            this.label10,
            this.line3,
            this.label1,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.line4});
            this.TitleHeader.Height = 0.1979167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.label16.Height = 0.125F;
            this.label16.HyperLink = "";
            this.label16.Left = 0F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "拠点";
            this.label16.Top = 0.0625F;
            this.label16.Width = 0.5F;
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
            this.label10.Height = 0.125F;
            this.label10.HyperLink = "";
            this.label10.Left = 5.4375F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "ｸﾞﾙｰﾌﾟ";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.375F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 14.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 14.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
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
            this.label1.Height = 0.125F;
            this.label1.HyperLink = "";
            this.label1.Left = 0.875F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "作成区分";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.5F;
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
            this.label4.Height = 0.125F;
            this.label4.HyperLink = "";
            this.label4.Left = 1.3125F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "有効区分";
            this.label4.Top = 0.0625F;
            this.label4.Width = 0.5F;
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
            this.label5.Height = 0.125F;
            this.label5.HyperLink = "";
            this.label5.Left = 1.75F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "得G";
            this.label5.Top = 0.063F;
            this.label5.Width = 0.25F;
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
            this.label6.Height = 0.125F;
            this.label6.HyperLink = "";
            this.label6.Left = 2F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "得意先";
            this.label6.Top = 0.0625F;
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
            this.label7.Height = 0.125F;
            this.label7.HyperLink = "";
            this.label7.Left = 2.4375F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "仕入先";
            this.label7.Top = 0.0625F;
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
            this.label8.Height = 0.125F;
            this.label8.HyperLink = "";
            this.label8.Left = 2.8125F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "ﾒｰｶｰ";
            this.label8.Top = 0.0625F;
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
            this.label9.Height = 0.125F;
            this.label9.HyperLink = "";
            this.label9.Left = 4.5625F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "層別";
            this.label9.Top = 0.0625F;
            this.label9.Width = 0.4375F;
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
            this.label11.Height = 0.125F;
            this.label11.HyperLink = "";
            this.label11.Left = 5.8125F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "BLｺｰﾄﾞ";
            this.label11.Top = 0.0625F;
            this.label11.Width = 0.375F;
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
            this.label12.Height = 0.125F;
            this.label12.HyperLink = "";
            this.label12.Left = 6.135F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "品番";
            this.label12.Top = 0.063F;
            this.label12.Width = 0.3125F;
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
            this.label13.Height = 0.125F;
            this.label13.HyperLink = "";
            this.label13.Left = 7.375F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "品名";
            this.label13.Top = 0.0625F;
            this.label13.Width = 0.5625F;
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
            this.label14.Height = 0.125F;
            this.label14.HyperLink = "";
            this.label14.Left = 8.375F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "内容";
            this.label14.Top = 0.0625F;
            this.label14.Width = 0.5625F;
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
            this.label15.Height = 0.125F;
            this.label15.HyperLink = "";
            this.label15.Left = 5F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "商品掛率";
            this.label15.Top = 0.0625F;
            this.label15.Width = 0.4375F;
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
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.1875F;
            this.line4.Width = 14.375F;
            this.line4.X1 = 0F;
            this.line4.X2 = 14.375F;
            this.line4.Y1 = 0.1875F;
            this.line4.Y2 = 0.1875F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0.01041667F;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Height = 0.01041667F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Visible = false;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // PMHNB02203P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 11.18983F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMUOE02074P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.PriceKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogicalDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Content)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessKbn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessKbn_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}
