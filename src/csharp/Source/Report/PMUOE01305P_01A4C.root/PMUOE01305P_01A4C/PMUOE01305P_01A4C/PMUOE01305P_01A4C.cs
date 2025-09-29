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

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 仕入回答一覧表 印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 仕入回答一覧表の印刷フォームクラスです。</br>
    /// <br>Programmer   : caohh</br>
    /// <br>Date         : 2011/08/10</br>
    /// <br>UpdateNote   : 2011/08/24 yangmj</br>
    /// <br>             : redmine #23905の対応</br>
    /// </remarks>
    public class PMUOE01305P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 仕入回答一覧表印刷フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : 仕入回答一覧表印刷フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : caohh</br>
        /// <br>Date         : 2011/08/10</br>
        /// </remarks>
        public PMUOE01305P_01A4C ()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        private int _printCount;				    // 印刷件数用カウンタ
        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;	// 抽出条件
        private int _pageFooterOutCode;				// フッター出力区分
        private StringCollection _pageFooters;		// フッターメッセージ
        private SFCMN06002C _printInfo;				// 印刷情報クラス
        private string _pageHeaderTitle;			// フォームタイトル
        private string _pageHeaderSortOderTitle;	// ソート順

        private UOEAnswerLedgerOrderCndtn _uOEAnswerLedgerOrderCndtn;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        #region ActiveReport項目

        private TextBox UOECheckCode;
        private TextBox NonShipmentCnt;
        private Label Lb_UOECheckCode;
        private Label Lb_UOESectionSlipNo;
        private Label Lb_NonShipmentCnt;
        private TextBox MakerName;

        // Disposeチェック用フラグ
        bool disposed = false;

        // フォーマット文字列
        private const string ct_DateFomat = "YYYY/MM/DD";
        private Label Lb_GoodsNo;
        private Label Lb_UOESalesOrderNo;
        private Label Lb_UoeRemark;
        private Label Lb_DeliGoodsDiv;
        private Label Lb_AnswerSalesUnitCost;
        private Label Lb_AnswerListPrice;
        private Label Lb_AcceptAnOrderCnt;
        private Label Lb_UOESectOutGoodsCnt;
        private Label Lb_LineErrorMessage;
        private TextBox GoodsNo;
        private TextBox UOESalesOrderNo;
        private TextBox UoeRemark1;
        private TextBox DeliGoodsDivName;
        private TextBox AnswerSalesUnitCost;
        private TextBox AnswerListPrice;
        private TextBox AcceptAnOrderCnt;
        private TextBox UOESectOutGoodsCnt;
        private TextBox UOESectionSlipNo;
        private TextBox LineErrorMessage;
        private TextBox textBox1;
        private TextBox ReceiveDate;
        private TextBox textBox3;
        private Line line2;
        private TextBox textBox2;
        private TextBox UOESalesOrderRowNo;
        private TextBox DeliveredGoodsDiv;
        private SubReport Header_SubReport;
        #endregion

        #endregion ■ Private Member

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose ( bool disposing )
        {
            if ( !this.disposed )
            {
                try
                {
                    if ( disposing )
                    {
                        // ヘッダ用サブレポート後処理実行
                        if ( this._rptExtraHeader != null )
                        {
                            this._rptExtraHeader.Dispose();
                        }

                        // フッタ用サブレポート後処理実行
                        if ( this._rptPageFooter != null )
                        {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally
                {
                    base.Dispose( disposing );
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
                this._uOEAnswerLedgerOrderCndtn = (UOEAnswerLedgerOrderCndtn)this._printInfo.jyoken;
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
                // TODO:  DCZAI02103P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// <br>Update Note : </br>
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            this._printCount = 0;
        }
        #endregion ◆ レポート要素出力設定
        #endregion

        #region ■ Control Event

        #region ◎ PMUOE01305P_01A4C_ReportStart Event
        /// <summary>
        /// PMUOE01305P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void PMUOE01305P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void PageHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString( ct_DateFomat, DateTime.Now );
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString( "HH:mm" );
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 抽出条件設定
            // ヘッダ出力制御
            if ( this._extraCondHeadOutDiv == 0 )
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
            if ( this._rptExtraHeader == null )
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

        #region ◎ Detail_Format Event
        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Detailグループのフォーマットイベント。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// <br>UpdateNote  : 2011/08/24 yangmj</br>
        /// <br>            : redmine #23905の対応</br>
        /// </remarks>
        private void Detail_Format ( object sender, System.EventArgs eArgs )
        {
            // UOE発注行番号
            if (this.UOESalesOrderRowNo.Text == string.Empty) 
            {
                this.textBox2.Visible = false;
            }
            // ------ADD 2011/08/24----->>>>>
            if (this.ReceiveDate.Text == string.Empty || this.textBox3.Text == string.Empty)
            {
                this.textBox1.Value = null;
                this.ReceiveDate.Value = null;
                this.textBox3.Value = null;
                this.textBox1.Visible = false;
                this.ReceiveDate.Visible = false;
                this.textBox3.Visible = false;
            }
            else
            {
                this.textBox1.Text = "受信日時";
                this.textBox1.Visible = true;
                this.ReceiveDate.Visible = true;
                this.textBox3.Visible = true;
            }
            // ------ADD 2011/08/24-----<<<<<
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString( this.Detail );
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
        /// <br>Programmer  : caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if ( this.ProgressBarUpEvent != null )
            {
                this.ProgressBarUpEvent( this, this._printCount );
            }
        }
        #endregion

        #region ◎ DailyFooter_Format Event
        /// <summary>
        /// DailyFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DailyFooter_Format Event</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void DailyFooter_Format ( object sender, System.EventArgs eArgs )
        {
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
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
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox tb_PrintDate;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Label Lb_AnswerpartsNo;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_AnswerpartsName;
        private DataDynamics.ActiveReports.Label Lb_MakerName;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox AnswerpartsNo;
        private DataDynamics.ActiveReports.TextBox AnswerpartsName;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Line Line41;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
        public void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE01305P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.AnswerpartsNo = new DataDynamics.ActiveReports.TextBox();
            this.AnswerpartsName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.UOECheckCode = new DataDynamics.ActiveReports.TextBox();
            this.NonShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.UOESalesOrderNo = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark1 = new DataDynamics.ActiveReports.TextBox();
            this.DeliGoodsDivName = new DataDynamics.ActiveReports.TextBox();
            this.AnswerSalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.AnswerListPrice = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCnt = new DataDynamics.ActiveReports.TextBox();
            this.UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.UOESectionSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.LineErrorMessage = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.ReceiveDate = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.UOESalesOrderRowNo = new DataDynamics.ActiveReports.TextBox();
            this.DeliveredGoodsDiv = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_AnswerpartsName = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Lb_AnswerpartsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_UOECheckCode = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESectionSlipNo = new DataDynamics.ActiveReports.Label();
            this.Lb_NonShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESalesOrderNo = new DataDynamics.ActiveReports.Label();
            this.Lb_UoeRemark = new DataDynamics.ActiveReports.Label();
            this.Lb_DeliGoodsDiv = new DataDynamics.ActiveReports.Label();
            this.Lb_AnswerSalesUnitCost = new DataDynamics.ActiveReports.Label();
            this.Lb_AnswerListPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_AcceptAnOrderCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESectOutGoodsCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_LineErrorMessage = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerpartsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerpartsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOECheckCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliGoodsDivName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineErrorMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderRowNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerpartsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerpartsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOECheckCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectionSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_NonShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UoeRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DeliGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerSalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LineErrorMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.AnswerpartsNo,
            this.AnswerpartsName,
            this.GoodsMakerCd,
            this.UOECheckCode,
            this.NonShipmentCnt,
            this.MakerName,
            this.GoodsNo,
            this.UOESalesOrderNo,
            this.UoeRemark1,
            this.DeliGoodsDivName,
            this.AnswerSalesUnitCost,
            this.AnswerListPrice,
            this.AcceptAnOrderCnt,
            this.UOESectOutGoodsCnt,
            this.UOESectionSlipNo,
            this.LineErrorMessage,
            this.textBox1,
            this.ReceiveDate,
            this.textBox3,
            this.textBox2,
            this.UOESalesOrderRowNo,
            this.DeliveredGoodsDiv});
            this.Detail.Height = 0.6979167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // AnswerpartsNo
            // 
            this.AnswerpartsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerpartsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerpartsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsNo.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerpartsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsNo.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerpartsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsNo.DataField = "AnswerpartsNo";
            this.AnswerpartsNo.Height = 0.157F;
            this.AnswerpartsNo.Left = 0.0738189F;
            this.AnswerpartsNo.MultiLine = false;
            this.AnswerpartsNo.Name = "AnswerpartsNo";
            this.AnswerpartsNo.OutputFormat = resources.GetString("AnswerpartsNo.OutputFormat");
            this.AnswerpartsNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.AnswerpartsNo.Text = "123456789012345678901234";
            this.AnswerpartsNo.Top = 0.4895833F;
            this.AnswerpartsNo.Width = 1.4F;
            // 
            // AnswerpartsName
            // 
            this.AnswerpartsName.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerpartsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsName.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerpartsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsName.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerpartsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsName.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerpartsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerpartsName.DataField = "AnswerpartsName";
            this.AnswerpartsName.Height = 0.1574803F;
            this.AnswerpartsName.Left = 1.75F;
            this.AnswerpartsName.MultiLine = false;
            this.AnswerpartsName.Name = "AnswerpartsName";
            this.AnswerpartsName.OutputFormat = resources.GetString("AnswerpartsName.OutputFormat");
            this.AnswerpartsName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.AnswerpartsName.Text = "1234567890123456789012345678901234567899";
            this.AnswerpartsName.Top = 0.33775F;
            this.AnswerpartsName.Width = 4F;
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
            this.GoodsMakerCd.Height = 0.156F;
            this.GoodsMakerCd.Left = 1.75F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.4895833F;
            this.GoodsMakerCd.Width = 0.27F;
            // 
            // UOECheckCode
            // 
            this.UOECheckCode.Border.BottomColor = System.Drawing.Color.Black;
            this.UOECheckCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOECheckCode.Border.LeftColor = System.Drawing.Color.Black;
            this.UOECheckCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOECheckCode.Border.RightColor = System.Drawing.Color.Black;
            this.UOECheckCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOECheckCode.Border.TopColor = System.Drawing.Color.Black;
            this.UOECheckCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOECheckCode.DataField = "UOECheckCode";
            this.UOECheckCode.Height = 0.156F;
            this.UOECheckCode.Left = 8.177083F;
            this.UOECheckCode.MultiLine = false;
            this.UOECheckCode.Name = "UOECheckCode";
            this.UOECheckCode.OutputFormat = resources.GetString("UOECheckCode.OutputFormat");
            this.UOECheckCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.UOECheckCode.Text = "12345678";
            this.UOECheckCode.Top = 0.4895833F;
            this.UOECheckCode.Width = 0.5F;
            // 
            // NonShipmentCnt
            // 
            this.NonShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.NonShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NonShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.NonShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NonShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.NonShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NonShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.NonShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NonShipmentCnt.DataField = "NonShipmentCnt";
            this.NonShipmentCnt.Height = 0.156F;
            this.NonShipmentCnt.Left = 8.78125F;
            this.NonShipmentCnt.MultiLine = false;
            this.NonShipmentCnt.Name = "NonShipmentCnt";
            this.NonShipmentCnt.OutputFormat = resources.GetString("NonShipmentCnt.OutputFormat");
            this.NonShipmentCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.NonShipmentCnt.Text = "123,456,789";
            this.NonShipmentCnt.Top = 0.4895833F;
            this.NonShipmentCnt.Width = 0.64F;
            // 
            // MakerName
            // 
            this.MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.DataField = "MakerName";
            this.MakerName.Height = 0.156F;
            this.MakerName.Left = 2.020833F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.MakerName.Text = "あいうえおかきくけこあいうえお";
            this.MakerName.Top = 0.4895833F;
            this.MakerName.Width = 2.3F;
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
            this.GoodsNo.Height = 0.157F;
            this.GoodsNo.Left = 0.0738189F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.GoodsNo.Text = "1234567890123456789012345678901234567890";
            this.GoodsNo.Top = 0.33775F;
            this.GoodsNo.Width = 1.4F;
            // 
            // UOESalesOrderNo
            // 
            this.UOESalesOrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.DataField = "UOESalesOrderNo";
            this.UOESalesOrderNo.Height = 0.157F;
            this.UOESalesOrderNo.Left = 1.75F;
            this.UOESalesOrderNo.MultiLine = false;
            this.UOESalesOrderNo.Name = "UOESalesOrderNo";
            this.UOESalesOrderNo.OutputFormat = resources.GetString("UOESalesOrderNo.OutputFormat");
            this.UOESalesOrderNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.UOESalesOrderNo.Text = "123456789";
            this.UOESalesOrderNo.Top = 0.1770833F;
            this.UOESalesOrderNo.Width = 0.55F;
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
            this.UoeRemark1.Left = 2.84375F;
            this.UoeRemark1.MultiLine = false;
            this.UoeRemark1.Name = "UoeRemark1";
            this.UoeRemark1.OutputFormat = resources.GetString("UoeRemark1.OutputFormat");
            this.UoeRemark1.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.UoeRemark1.Text = "あいうえおかきく";
            this.UoeRemark1.Top = 0.1770833F;
            this.UoeRemark1.Width = 0.95F;
            // 
            // DeliGoodsDivName
            // 
            this.DeliGoodsDivName.Border.BottomColor = System.Drawing.Color.Black;
            this.DeliGoodsDivName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliGoodsDivName.Border.LeftColor = System.Drawing.Color.Black;
            this.DeliGoodsDivName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliGoodsDivName.Border.RightColor = System.Drawing.Color.Black;
            this.DeliGoodsDivName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliGoodsDivName.Border.TopColor = System.Drawing.Color.Black;
            this.DeliGoodsDivName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliGoodsDivName.DataField = "DeliGoodsDiv";
            this.DeliGoodsDivName.Height = 0.156F;
            this.DeliGoodsDivName.Left = 4.1875F;
            this.DeliGoodsDivName.MultiLine = false;
            this.DeliGoodsDivName.Name = "DeliGoodsDivName";
            this.DeliGoodsDivName.OutputFormat = resources.GetString("DeliGoodsDivName.OutputFormat");
            this.DeliGoodsDivName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.DeliGoodsDivName.Text = "あいうえおかきくけこ";
            this.DeliGoodsDivName.Top = 0.1770833F;
            this.DeliGoodsDivName.Width = 1.17F;
            // 
            // AnswerSalesUnitCost
            // 
            this.AnswerSalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.DataField = "AnswerSalesUnitCost";
            this.AnswerSalesUnitCost.Height = 0.156F;
            this.AnswerSalesUnitCost.Left = 5.75F;
            this.AnswerSalesUnitCost.MultiLine = false;
            this.AnswerSalesUnitCost.Name = "AnswerSalesUnitCost";
            this.AnswerSalesUnitCost.OutputFormat = resources.GetString("AnswerSalesUnitCost.OutputFormat");
            this.AnswerSalesUnitCost.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.AnswerSalesUnitCost.Text = "123,456,789";
            this.AnswerSalesUnitCost.Top = 0.33775F;
            this.AnswerSalesUnitCost.Width = 0.64F;
            // 
            // AnswerListPrice
            // 
            this.AnswerListPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.DataField = "AnswerListPrice";
            this.AnswerListPrice.Height = 0.156F;
            this.AnswerListPrice.Left = 5.75F;
            this.AnswerListPrice.MultiLine = false;
            this.AnswerListPrice.Name = "AnswerListPrice";
            this.AnswerListPrice.OutputFormat = resources.GetString("AnswerListPrice.OutputFormat");
            this.AnswerListPrice.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.AnswerListPrice.Text = "123,456,789";
            this.AnswerListPrice.Top = 0.4895833F;
            this.AnswerListPrice.Width = 0.64F;
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
            this.AcceptAnOrderCnt.Height = 0.156F;
            this.AcceptAnOrderCnt.Left = 6.416667F;
            this.AcceptAnOrderCnt.MultiLine = false;
            this.AcceptAnOrderCnt.Name = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.OutputFormat = resources.GetString("AcceptAnOrderCnt.OutputFormat");
            this.AcceptAnOrderCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.AcceptAnOrderCnt.Text = "123,456,789";
            this.AcceptAnOrderCnt.Top = 0.33775F;
            this.AcceptAnOrderCnt.Width = 0.64F;
            // 
            // UOESectOutGoodsCnt
            // 
            this.UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.DataField = "UOESectOutGoodsCnt";
            this.UOESectOutGoodsCnt.Height = 0.1476378F;
            this.UOESectOutGoodsCnt.Left = 7.083333F;
            this.UOESectOutGoodsCnt.MultiLine = false;
            this.UOESectOutGoodsCnt.Name = "UOESectOutGoodsCnt";
            this.UOESectOutGoodsCnt.OutputFormat = resources.GetString("UOESectOutGoodsCnt.OutputFormat");
            this.UOESectOutGoodsCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.UOESectOutGoodsCnt.Text = "12,345";
            this.UOESectOutGoodsCnt.Top = 0.33775F;
            this.UOESectOutGoodsCnt.Width = 0.4F;
            // 
            // UOESectionSlipNo
            // 
            this.UOESectionSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.DataField = "UOESectionSlipNo";
            this.UOESectionSlipNo.Height = 0.1476378F;
            this.UOESectionSlipNo.Left = 7.51304F;
            this.UOESectionSlipNo.MultiLine = false;
            this.UOESectionSlipNo.Name = "UOESectionSlipNo";
            this.UOESectionSlipNo.OutputFormat = resources.GetString("UOESectionSlipNo.OutputFormat");
            this.UOESectionSlipNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.UOESectionSlipNo.Text = "1234567";
            this.UOESectionSlipNo.Top = 0.33775F;
            this.UOESectionSlipNo.Width = 0.45F;
            // 
            // LineErrorMessage
            // 
            this.LineErrorMessage.Border.BottomColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.Border.LeftColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.Border.RightColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.Border.TopColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.DataField = "LineErrorMessage";
            this.LineErrorMessage.Height = 0.156F;
            this.LineErrorMessage.Left = 8.492717F;
            this.LineErrorMessage.MultiLine = false;
            this.LineErrorMessage.Name = "LineErrorMessage";
            this.LineErrorMessage.OutputFormat = resources.GetString("LineErrorMessage.OutputFormat");
            this.LineErrorMessage.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.LineErrorMessage.Text = "ああああああああああいいいいいいいいいう";
            this.LineErrorMessage.Top = 0.33775F;
            this.LineErrorMessage.Width = 2.28F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.CanShrink = true;
            this.textBox1.Height = 0.156F;
            this.textBox1.Left = 0F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox1.Text = "受信日時";
            this.textBox1.Top = 0.0246063F;
            this.textBox1.Width = 0.6F;
            // 
            // ReceiveDate
            // 
            this.ReceiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.CanShrink = true;
            this.ReceiveDate.DataField = "ReceiveDateYmd";
            this.ReceiveDate.Height = 0.156F;
            this.ReceiveDate.Left = 0.71875F;
            this.ReceiveDate.MultiLine = false;
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.OutputFormat = resources.GetString("ReceiveDate.OutputFormat");
            this.ReceiveDate.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.ReceiveDate.Text = "11/07/18";
            this.ReceiveDate.Top = 0.0246063F;
            this.ReceiveDate.Width = 0.5F;
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
            this.textBox3.CanShrink = true;
            this.textBox3.DataField = "ReceiveTime";
            this.textBox3.Height = 0.156F;
            this.textBox3.Left = 1.3125F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox3.Text = "15:43:14";
            this.textBox3.Top = 0.0246063F;
            this.textBox3.Width = 0.5F;
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
            this.textBox2.Height = 0.156F;
            this.textBox2.Left = 2.3125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox2.Text = "-";
            this.textBox2.Top = 0.1770833F;
            this.textBox2.Width = 0.07F;
            // 
            // UOESalesOrderRowNo
            // 
            this.UOESalesOrderRowNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.DataField = "UOESalesOrderRowNo";
            this.UOESalesOrderRowNo.Height = 0.156F;
            this.UOESalesOrderRowNo.Left = 2.40625F;
            this.UOESalesOrderRowNo.MultiLine = false;
            this.UOESalesOrderRowNo.Name = "UOESalesOrderRowNo";
            this.UOESalesOrderRowNo.OutputFormat = resources.GetString("UOESalesOrderRowNo.OutputFormat");
            this.UOESalesOrderRowNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.UOESalesOrderRowNo.Text = "1234";
            this.UOESalesOrderRowNo.Top = 0.1770833F;
            this.UOESalesOrderRowNo.Width = 0.25F;
            // 
            // DeliveredGoodsDiv
            // 
            this.DeliveredGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliveredGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliveredGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliveredGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DeliveredGoodsDiv.DataField = "DeliveredGoodsDivNm";
            this.DeliveredGoodsDiv.Height = 0.156F;
            this.DeliveredGoodsDiv.Left = 3.9375F;
            this.DeliveredGoodsDiv.MultiLine = false;
            this.DeliveredGoodsDiv.Name = "DeliveredGoodsDiv";
            this.DeliveredGoodsDiv.OutputFormat = resources.GetString("DeliveredGoodsDiv.OutputFormat");
            this.DeliveredGoodsDiv.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.DeliveredGoodsDiv.Text = "1234";
            this.DeliveredGoodsDiv.Top = 0.1770833F;
            this.DeliveredGoodsDiv.Width = 0.25F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_ReportTitle});
            this.PageHeader.Height = 0.2604167F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.Label3.Left = 7.981628F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0738189F;
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
            this.tb_PrintDate.Left = 8.547573F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0738189F;
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
            this.Label2.Left = 9.999347F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0738189F;
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
            this.tb_PrintPage.Left = 10.49147F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0738189F;
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
            this.Line1.Top = 0.2085F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
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
            this.tb_PrintTime.Left = 9.482613F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0738189F;
            this.tb_PrintTime.Width = 0.5F;
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
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "仕入回答一覧表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.40625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2388889F;
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
            this.ExtraHeader.Height = 0.3125F;
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
            this.Header_SubReport.Height = 0.2480315F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0.05F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line42,
            this.Lb_AnswerpartsName,
            this.Lb_MakerName,
            this.Lb_AnswerpartsNo,
            this.Lb_UOECheckCode,
            this.Lb_UOESectionSlipNo,
            this.Lb_NonShipmentCnt,
            this.Lb_GoodsNo,
            this.Lb_UOESalesOrderNo,
            this.Lb_UoeRemark,
            this.Lb_DeliGoodsDiv,
            this.Lb_AnswerSalesUnitCost,
            this.Lb_AnswerListPrice,
            this.Lb_AcceptAnOrderCnt,
            this.Lb_UOESectOutGoodsCnt,
            this.Lb_LineErrorMessage,
            this.line2});
            this.TitleHeader.Height = 0.5416667F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line42
            // 
            this.Line42.Border.BottomColor = System.Drawing.Color.Black;
            this.Line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.LeftColor = System.Drawing.Color.Black;
            this.Line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.RightColor = System.Drawing.Color.Black;
            this.Line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.TopColor = System.Drawing.Color.Black;
            this.Line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Height = 0F;
            this.Line42.Left = 0F;
            this.Line42.LineWeight = 2F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0.5104167F;
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 0.5104167F;
            this.Line42.Y2 = 0.5104167F;
            // 
            // Lb_AnswerpartsName
            // 
            this.Lb_AnswerpartsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsName.Height = 0.15625F;
            this.Lb_AnswerpartsName.HyperLink = "";
            this.Lb_AnswerpartsName.Left = 1.75F;
            this.Lb_AnswerpartsName.MultiLine = false;
            this.Lb_AnswerpartsName.Name = "Lb_AnswerpartsName";
            this.Lb_AnswerpartsName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnswerpartsName.Text = "品    名";
            this.Lb_AnswerpartsName.Top = 0.18975F;
            this.Lb_AnswerpartsName.Width = 0.75F;
            // 
            // Lb_MakerName
            // 
            this.Lb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Height = 0.156F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 1.75F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MakerName.Text = "メーカー";
            this.Lb_MakerName.Top = 0.34375F;
            this.Lb_MakerName.Width = 0.8F;
            // 
            // Lb_AnswerpartsNo
            // 
            this.Lb_AnswerpartsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnswerpartsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerpartsNo.Height = 0.15625F;
            this.Lb_AnswerpartsNo.HyperLink = "";
            this.Lb_AnswerpartsNo.Left = 0.0738189F;
            this.Lb_AnswerpartsNo.MultiLine = false;
            this.Lb_AnswerpartsNo.Name = "Lb_AnswerpartsNo";
            this.Lb_AnswerpartsNo.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnswerpartsNo.Text = "回答品番";
            this.Lb_AnswerpartsNo.Top = 0.34375F;
            this.Lb_AnswerpartsNo.Width = 0.75F;
            // 
            // Lb_UOECheckCode
            // 
            this.Lb_UOECheckCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOECheckCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOECheckCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOECheckCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOECheckCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOECheckCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOECheckCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOECheckCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOECheckCode.Height = 0.1476378F;
            this.Lb_UOECheckCode.HyperLink = "";
            this.Lb_UOECheckCode.Left = 8.177083F;
            this.Lb_UOECheckCode.MultiLine = false;
            this.Lb_UOECheckCode.Name = "Lb_UOECheckCode";
            this.Lb_UOECheckCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOECheckCode.Text = "倉庫・棚番";
            this.Lb_UOECheckCode.Top = 0.34375F;
            this.Lb_UOECheckCode.Width = 0.6F;
            // 
            // Lb_UOESectionSlipNo
            // 
            this.Lb_UOESectionSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Height = 0.156F;
            this.Lb_UOESectionSlipNo.HyperLink = "";
            this.Lb_UOESectionSlipNo.Left = 7.51304F;
            this.Lb_UOESectionSlipNo.MultiLine = false;
            this.Lb_UOESectionSlipNo.Name = "Lb_UOESectionSlipNo";
            this.Lb_UOESectionSlipNo.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESectionSlipNo.Text = "出庫伝票No.";
            this.Lb_UOESectionSlipNo.Top = 0.18975F;
            this.Lb_UOESectionSlipNo.Width = 0.65F;
            // 
            // Lb_NonShipmentCnt
            // 
            this.Lb_NonShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_NonShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_NonShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_NonShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_NonShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_NonShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_NonShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_NonShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_NonShipmentCnt.Height = 0.156F;
            this.Lb_NonShipmentCnt.HyperLink = "";
            this.Lb_NonShipmentCnt.Left = 8.78125F;
            this.Lb_NonShipmentCnt.MultiLine = false;
            this.Lb_NonShipmentCnt.Name = "Lb_NonShipmentCnt";
            this.Lb_NonShipmentCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_NonShipmentCnt.Text = "発注残";
            this.Lb_NonShipmentCnt.Top = 0.34375F;
            this.Lb_NonShipmentCnt.Width = 0.64F;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 0.074F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "発注品番";
            this.Lb_GoodsNo.Top = 0.18975F;
            this.Lb_GoodsNo.Width = 0.75F;
            // 
            // Lb_UOESalesOrderNo
            // 
            this.Lb_UOESalesOrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Height = 0.15625F;
            this.Lb_UOESalesOrderNo.HyperLink = "";
            this.Lb_UOESalesOrderNo.Left = 1.75F;
            this.Lb_UOESalesOrderNo.MultiLine = false;
            this.Lb_UOESalesOrderNo.Name = "Lb_UOESalesOrderNo";
            this.Lb_UOESalesOrderNo.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESalesOrderNo.Text = "発注番号";
            this.Lb_UOESalesOrderNo.Top = 0.03125F;
            this.Lb_UOESalesOrderNo.Width = 0.75F;
            // 
            // Lb_UoeRemark
            // 
            this.Lb_UoeRemark.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UoeRemark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UoeRemark.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UoeRemark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UoeRemark.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UoeRemark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UoeRemark.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UoeRemark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UoeRemark.Height = 0.156F;
            this.Lb_UoeRemark.HyperLink = "";
            this.Lb_UoeRemark.Left = 2.84375F;
            this.Lb_UoeRemark.MultiLine = false;
            this.Lb_UoeRemark.Name = "Lb_UoeRemark";
            this.Lb_UoeRemark.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UoeRemark.Text = "リマーク";
            this.Lb_UoeRemark.Top = 0.0625F;
            this.Lb_UoeRemark.Width = 0.7F;
            // 
            // Lb_DeliGoodsDiv
            // 
            this.Lb_DeliGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DeliGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DeliGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DeliGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DeliGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliGoodsDiv.Height = 0.156F;
            this.Lb_DeliGoodsDiv.HyperLink = "";
            this.Lb_DeliGoodsDiv.Left = 3.9375F;
            this.Lb_DeliGoodsDiv.MultiLine = false;
            this.Lb_DeliGoodsDiv.Name = "Lb_DeliGoodsDiv";
            this.Lb_DeliGoodsDiv.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DeliGoodsDiv.Text = "納品区分";
            this.Lb_DeliGoodsDiv.Top = 0.0625F;
            this.Lb_DeliGoodsDiv.Width = 0.7F;
            // 
            // Lb_AnswerSalesUnitCost
            // 
            this.Lb_AnswerSalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnswerSalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerSalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnswerSalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerSalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnswerSalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerSalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnswerSalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerSalesUnitCost.Height = 0.156F;
            this.Lb_AnswerSalesUnitCost.HyperLink = "";
            this.Lb_AnswerSalesUnitCost.Left = 5.75F;
            this.Lb_AnswerSalesUnitCost.MultiLine = false;
            this.Lb_AnswerSalesUnitCost.Name = "Lb_AnswerSalesUnitCost";
            this.Lb_AnswerSalesUnitCost.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnswerSalesUnitCost.Text = "単価";
            this.Lb_AnswerSalesUnitCost.Top = 0.18975F;
            this.Lb_AnswerSalesUnitCost.Width = 0.64F;
            // 
            // Lb_AnswerListPrice
            // 
            this.Lb_AnswerListPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AnswerListPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerListPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AnswerListPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerListPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AnswerListPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerListPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AnswerListPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AnswerListPrice.Height = 0.156F;
            this.Lb_AnswerListPrice.HyperLink = "";
            this.Lb_AnswerListPrice.Left = 5.75F;
            this.Lb_AnswerListPrice.MultiLine = false;
            this.Lb_AnswerListPrice.Name = "Lb_AnswerListPrice";
            this.Lb_AnswerListPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AnswerListPrice.Text = "定価";
            this.Lb_AnswerListPrice.Top = 0.34375F;
            this.Lb_AnswerListPrice.Width = 0.64F;
            // 
            // Lb_AcceptAnOrderCnt
            // 
            this.Lb_AcceptAnOrderCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Height = 0.156F;
            this.Lb_AcceptAnOrderCnt.HyperLink = "";
            this.Lb_AcceptAnOrderCnt.Left = 6.416667F;
            this.Lb_AcceptAnOrderCnt.MultiLine = false;
            this.Lb_AcceptAnOrderCnt.Name = "Lb_AcceptAnOrderCnt";
            this.Lb_AcceptAnOrderCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AcceptAnOrderCnt.Text = "発注数";
            this.Lb_AcceptAnOrderCnt.Top = 0.18975F;
            this.Lb_AcceptAnOrderCnt.Width = 0.64F;
            // 
            // Lb_UOESectOutGoodsCnt
            // 
            this.Lb_UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Height = 0.156F;
            this.Lb_UOESectOutGoodsCnt.HyperLink = "";
            this.Lb_UOESectOutGoodsCnt.Left = 7.083333F;
            this.Lb_UOESectOutGoodsCnt.MultiLine = false;
            this.Lb_UOESectOutGoodsCnt.Name = "Lb_UOESectOutGoodsCnt";
            this.Lb_UOESectOutGoodsCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESectOutGoodsCnt.Text = "出庫数";
            this.Lb_UOESectOutGoodsCnt.Top = 0.18975F;
            this.Lb_UOESectOutGoodsCnt.Width = 0.4F;
            // 
            // Lb_LineErrorMessage
            // 
            this.Lb_LineErrorMessage.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Height = 0.156F;
            this.Lb_LineErrorMessage.HyperLink = "";
            this.Lb_LineErrorMessage.Left = 8.492717F;
            this.Lb_LineErrorMessage.MultiLine = false;
            this.Lb_LineErrorMessage.Name = "Lb_LineErrorMessage";
            this.Lb_LineErrorMessage.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.Lb_LineErrorMessage.Text = "ラインメッセージ";
            this.Lb_LineErrorMessage.Top = 0.18975F;
            this.Lb_LineErrorMessage.Width = 1.476378F;
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
            this.line2.Top = 0F;
            this.line2.Width = 11.25F;
            this.line2.X1 = 0F;
            this.line2.X2 = 11.25F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // Line41
            // 
            this.Line41.Border.BottomColor = System.Drawing.Color.Black;
            this.Line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.LeftColor = System.Drawing.Color.Black;
            this.Line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.RightColor = System.Drawing.Color.Black;
            this.Line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.TopColor = System.Drawing.Color.Black;
            this.Line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Height = 0F;
            this.Line41.Left = 0F;
            this.Line41.LineWeight = 2F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 11.25984F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 11.25984F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
            // 
            // PMUOE01305P_01A4C
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
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMUOE01305P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.AnswerpartsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerpartsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOECheckCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NonShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliGoodsDivName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineErrorMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderRowNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerpartsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerpartsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOECheckCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectionSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_NonShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UoeRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DeliGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerSalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AnswerListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LineErrorMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion


        
    }
}
