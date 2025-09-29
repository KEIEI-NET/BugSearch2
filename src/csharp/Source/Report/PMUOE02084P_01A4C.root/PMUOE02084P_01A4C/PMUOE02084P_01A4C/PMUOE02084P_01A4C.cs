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
    /// 発注送信エラーリスト印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 発注送信エラーリストのフォームクラスです。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.12.10</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE02084P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
		/// <summary>
        /// 発注送信エラーリストフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 発注送信エラーリストフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
        /// </remarks>
        public PMUOE02084P_01A4C()
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
        private SupplierSendErOrderCndtn _supplierSendErOrderCndtn;		        // 抽出条件クラス
        
        private DataSet _outputDs;						            // 印刷用DataSet

        private const string ct_CollectTable = SupplierSendErResult.Col_Tbl_Result_SupplierSendEr;    // 発注送信エラーリストテーブル名称

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
        private TextBox tb_SortOrderName;
        private SubReport Header_SubReport;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Detail Detail;
        private Label SupplierCd_Title;
        private Label AnswerListPrice_Title;
        private Label AnswerSalesUnitCost_Title;
        private Label BOSlipNo_Print_Title;
        private Label WarehouseShelfNo_Title;
        private Label GoodsNo_Title;
        private Label GoodsMakerCd_Title;
        private Label UOESectOutGoodsCnt_Title;
        private Label BO_Print_Title;
        private Label UoeRemark1_Title;
        private Label UoeRemark2_Title;
        private Label ReceiveDate_Title;
        private TextBox SectionCode;
        private TextBox SectionGuideSnm;
        private Label GoodsName_Title;
        private Line line2;
        private Line line3;
        private SubReport Footer_SubReport;
        private TextBox UOESupplierCd;
        private TextBox UOESupplierName;
        private TextBox ReceiveDate_Print;
        private TextBox OnlineNo;
        private TextBox SystemDivCd_Print;
        private TextBox EmployeeCode;
        private TextBox CustomerCode;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox GoodsMakerCd;
        private TextBox AcceptAnOrderCnt;
        private TextBox UoeRemark1;
        private TextBox UoeRemark2;
        private TextBox BoCode;
        private TextBox UOEDeliGoodsDiv;
        private TextBox FollowDeliGoodsDiv;
        private TextBox UOEResvdSection;
        private Label label1;
        private Label label4;
        private Label label5;


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
                this._supplierSendErOrderCndtn = (SupplierSendErOrderCndtn)this._printInfo.jyoken;
                this._outputDs = (DataSet)this._printInfo.rdData;
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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderSubtitle;		   // サブタイトル
            tb_SortOrderName.Text = this._pageHeaderSortOderTitle;   // ソート条件
            
        }
        #endregion ◆ レポート要素出力設定

        #endregion

        #region ■ Control Event

        #region ◎ PMUOE02084P_01A4C_ReportStart Event
        /// <summary>
        /// PMUOE02084P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
        /// </remarks>
        private void PMUOE02084P_01A4C_ReportStart(object sender, EventArgs e)
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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
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

            // 拠点の印字
            this._rptExtraHeader.SectionCondition.Text = "拠点：" + this.SectionCode.Value + " " + this.SectionGuideSnm.Text;            

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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
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
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.10</br>
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMUOE02084P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.UOESupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierName = new DataDynamics.ActiveReports.TextBox();
            this.ReceiveDate_Print = new DataDynamics.ActiveReports.TextBox();
            this.OnlineNo = new DataDynamics.ActiveReports.TextBox();
            this.SystemDivCd_Print = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCnt = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark1 = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark2 = new DataDynamics.ActiveReports.TextBox();
            this.BoCode = new DataDynamics.ActiveReports.TextBox();
            this.UOEDeliGoodsDiv = new DataDynamics.ActiveReports.TextBox();
            this.FollowDeliGoodsDiv = new DataDynamics.ActiveReports.TextBox();
            this.UOEResvdSection = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupplierCd_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerListPrice_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerSalesUnitCost_Title = new DataDynamics.ActiveReports.Label();
            this.BOSlipNo_Print_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsMakerCd_Title = new DataDynamics.ActiveReports.Label();
            this.UOESectOutGoodsCnt_Title = new DataDynamics.ActiveReports.Label();
            this.BO_Print_Title = new DataDynamics.ActiveReports.Label();
            this.UoeRemark1_Title = new DataDynamics.ActiveReports.Label();
            this.UoeRemark2_Title = new DataDynamics.ActiveReports.Label();
            this.ReceiveDate_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivCd_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEDeliGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowDeliGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEResvdSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo_Print_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BO_Print_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.UOESupplierCd,
            this.UOESupplierName,
            this.ReceiveDate_Print,
            this.OnlineNo,
            this.SystemDivCd_Print,
            this.EmployeeCode,
            this.CustomerCode,
            this.GoodsNo,
            this.GoodsName,
            this.GoodsMakerCd,
            this.AcceptAnOrderCnt,
            this.UoeRemark1,
            this.UoeRemark2,
            this.BoCode,
            this.UOEDeliGoodsDiv,
            this.FollowDeliGoodsDiv,
            this.UOEResvdSection});
            this.Detail.Height = 0.21875F;
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
            this.line2.Top = 0F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.UOESupplierCd.Height = 0.125F;
            this.UOESupplierCd.Left = 0F;
            this.UOESupplierCd.MultiLine = false;
            this.UOESupplierCd.Name = "UOESupplierCd";
            this.UOESupplierCd.OutputFormat = resources.GetString("UOESupplierCd.OutputFormat");
            this.UOESupplierCd.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.UOESupplierCd.Text = "123456";
            this.UOESupplierCd.Top = 0F;
            this.UOESupplierCd.Width = 0.3125F;
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
            this.UOESupplierName.Height = 0.125F;
            this.UOESupplierName.Left = 0.375F;
            this.UOESupplierName.MultiLine = false;
            this.UOESupplierName.Name = "UOESupplierName";
            this.UOESupplierName.OutputFormat = resources.GetString("UOESupplierName.OutputFormat");
            this.UOESupplierName.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.UOESupplierName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.UOESupplierName.Top = 0F;
            this.UOESupplierName.Width = 1.875F;
            // 
            // ReceiveDate_Print
            // 
            this.ReceiveDate_Print.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDate_Print.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Print.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDate_Print.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Print.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDate_Print.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Print.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDate_Print.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Print.DataField = "ReceiveDate_Print";
            this.ReceiveDate_Print.Height = 0.125F;
            this.ReceiveDate_Print.Left = 2.3125F;
            this.ReceiveDate_Print.MultiLine = false;
            this.ReceiveDate_Print.Name = "ReceiveDate_Print";
            this.ReceiveDate_Print.OutputFormat = resources.GetString("ReceiveDate_Print.OutputFormat");
            this.ReceiveDate_Print.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.ReceiveDate_Print.Text = "9999/99/99";
            this.ReceiveDate_Print.Top = 0F;
            this.ReceiveDate_Print.Width = 0.5F;
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
            this.OnlineNo.Height = 0.125F;
            this.OnlineNo.Left = 2.875F;
            this.OnlineNo.MultiLine = false;
            this.OnlineNo.Name = "OnlineNo";
            this.OnlineNo.OutputFormat = resources.GetString("OnlineNo.OutputFormat");
            this.OnlineNo.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.OnlineNo.Text = "123456789";
            this.OnlineNo.Top = 0F;
            this.OnlineNo.Width = 0.4375F;
            // 
            // SystemDivCd_Print
            // 
            this.SystemDivCd_Print.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.DataField = "SystemDivCd_Print";
            this.SystemDivCd_Print.Height = 0.125F;
            this.SystemDivCd_Print.Left = 3.375F;
            this.SystemDivCd_Print.MultiLine = false;
            this.SystemDivCd_Print.Name = "SystemDivCd_Print";
            this.SystemDivCd_Print.OutputFormat = resources.GetString("SystemDivCd_Print.OutputFormat");
            this.SystemDivCd_Print.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.SystemDivCd_Print.Text = "ＮＮＮＮ";
            this.SystemDivCd_Print.Top = 0F;
            this.SystemDivCd_Print.Width = 0.4375F;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.DataField = "EmployeeCode";
            this.EmployeeCode.Height = 0.125F;
            this.EmployeeCode.Left = 3.875F;
            this.EmployeeCode.MultiLine = false;
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.OutputFormat = resources.GetString("EmployeeCode.OutputFormat");
            this.EmployeeCode.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.EmployeeCode.Text = "1234";
            this.EmployeeCode.Top = 0F;
            this.EmployeeCode.Width = 0.375F;
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
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 4.3125F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.CustomerCode.Text = "12345678";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Width = 0.4375F;
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
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 4.8125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.1875F;
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
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 6.0625F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.GoodsName.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1F;
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
            this.GoodsMakerCd.Height = 0.125F;
            this.GoodsMakerCd.Left = 7.125F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.25F;
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
            this.AcceptAnOrderCnt.Height = 0.125F;
            this.AcceptAnOrderCnt.Left = 7.4375F;
            this.AcceptAnOrderCnt.MultiLine = false;
            this.AcceptAnOrderCnt.Name = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.OutputFormat = resources.GetString("AcceptAnOrderCnt.OutputFormat");
            this.AcceptAnOrderCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 6.5pt; font-family: ＭＳ ゴシック; ver" +
                "tical-align: top; ";
            this.AcceptAnOrderCnt.Text = "1,234";
            this.AcceptAnOrderCnt.Top = 0F;
            this.AcceptAnOrderCnt.Width = 0.3125F;
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
            this.UoeRemark1.Height = 0.125F;
            this.UoeRemark1.Left = 8.0625F;
            this.UoeRemark1.MultiLine = false;
            this.UoeRemark1.Name = "UoeRemark1";
            this.UoeRemark1.OutputFormat = resources.GetString("UoeRemark1.OutputFormat");
            this.UoeRemark1.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.UoeRemark1.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.UoeRemark1.Top = 0F;
            this.UoeRemark1.Width = 1F;
            // 
            // UoeRemark2
            // 
            this.UoeRemark2.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2.DataField = "UoeRemark2";
            this.UoeRemark2.Height = 0.125F;
            this.UoeRemark2.Left = 9.125F;
            this.UoeRemark2.MultiLine = false;
            this.UoeRemark2.Name = "UoeRemark2";
            this.UoeRemark2.OutputFormat = resources.GetString("UoeRemark2.OutputFormat");
            this.UoeRemark2.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.UoeRemark2.Text = "ｱｲｳｴｵｶｷｸｹｺ";
            this.UoeRemark2.Top = 0F;
            this.UoeRemark2.Width = 0.5625F;
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
            this.BoCode.Height = 0.125F;
            this.BoCode.Left = 7.8125F;
            this.BoCode.MultiLine = false;
            this.BoCode.Name = "BoCode";
            this.BoCode.OutputFormat = resources.GetString("BoCode.OutputFormat");
            this.BoCode.Style = "ddo-char-set: 128; text-align: right; font-size: 6.5pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.BoCode.Text = "X";
            this.BoCode.Top = 0F;
            this.BoCode.Width = 0.1875F;
            // 
            // UOEDeliGoodsDiv
            // 
            this.UOEDeliGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.DataField = "UOEDeliGoodsDiv";
            this.UOEDeliGoodsDiv.Height = 0.125F;
            this.UOEDeliGoodsDiv.Left = 9.75F;
            this.UOEDeliGoodsDiv.MultiLine = false;
            this.UOEDeliGoodsDiv.Name = "UOEDeliGoodsDiv";
            this.UOEDeliGoodsDiv.OutputFormat = resources.GetString("UOEDeliGoodsDiv.OutputFormat");
            this.UOEDeliGoodsDiv.Style = "ddo-char-set: 128; text-align: right; font-size: 6.5pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.UOEDeliGoodsDiv.Text = "X";
            this.UOEDeliGoodsDiv.Top = 0F;
            this.UOEDeliGoodsDiv.Width = 0.1875F;
            // 
            // FollowDeliGoodsDiv
            // 
            this.FollowDeliGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.DataField = "FollowDeliGoodsDiv";
            this.FollowDeliGoodsDiv.Height = 0.125F;
            this.FollowDeliGoodsDiv.Left = 10F;
            this.FollowDeliGoodsDiv.MultiLine = false;
            this.FollowDeliGoodsDiv.Name = "FollowDeliGoodsDiv";
            this.FollowDeliGoodsDiv.OutputFormat = resources.GetString("FollowDeliGoodsDiv.OutputFormat");
            this.FollowDeliGoodsDiv.Style = "ddo-char-set: 128; text-align: right; font-size: 6.5pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.FollowDeliGoodsDiv.Text = "X";
            this.FollowDeliGoodsDiv.Top = 0F;
            this.FollowDeliGoodsDiv.Width = 0.25F;
            // 
            // UOEResvdSection
            // 
            this.UOEResvdSection.Border.BottomColor = System.Drawing.Color.Black;
            this.UOEResvdSection.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEResvdSection.Border.LeftColor = System.Drawing.Color.Black;
            this.UOEResvdSection.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEResvdSection.Border.RightColor = System.Drawing.Color.Black;
            this.UOEResvdSection.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEResvdSection.Border.TopColor = System.Drawing.Color.Black;
            this.UOEResvdSection.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEResvdSection.DataField = "UOEResvdSection";
            this.UOEResvdSection.Height = 0.125F;
            this.UOEResvdSection.Left = 10.3125F;
            this.UOEResvdSection.MultiLine = false;
            this.UOEResvdSection.Name = "UOEResvdSection";
            this.UOEResvdSection.OutputFormat = resources.GetString("UOEResvdSection.OutputFormat");
            this.UOEResvdSection.Style = "ddo-char-set: 128; text-align: left; font-size: 6.5pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.UOEResvdSection.Text = "999";
            this.UOEResvdSection.Top = 0F;
            this.UOEResvdSection.Width = 0.25F;
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
            this.tb_PrintTime,
            this.tb_SortOrderName});
            this.PageHeader.Height = 0.2916667F;
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
            this.tb_ReportTitle.Text = "発注送信エラーリスト";
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
            this.Label3.Left = 7.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
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
            this.tb_PrintDate.Left = 8.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
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
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
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
            this.tb_PrintPage.Left = 10.4375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
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
            this.tb_PrintTime.Left = 9.4375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // tb_SortOrderName
            // 
            this.tb_SortOrderName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.CanShrink = true;
            this.tb_SortOrderName.Height = 0.1875F;
            this.tb_SortOrderName.Left = 3.0625F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.0625F;
            this.tb_SortOrderName.Width = 2.4375F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2395833F;
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
            this.ExtraHeader.Height = 0.1979167F;
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
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8125F;
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
            this.SupplierCd_Title,
            this.AnswerListPrice_Title,
            this.AnswerSalesUnitCost_Title,
            this.BOSlipNo_Print_Title,
            this.WarehouseShelfNo_Title,
            this.GoodsNo_Title,
            this.GoodsMakerCd_Title,
            this.UOESectOutGoodsCnt_Title,
            this.BO_Print_Title,
            this.UoeRemark1_Title,
            this.UoeRemark2_Title,
            this.ReceiveDate_Title,
            this.GoodsName_Title,
            this.line3,
            this.label1,
            this.label4,
            this.label5});
            this.TitleHeader.Height = 0.21875F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // SupplierCd_Title
            // 
            this.SupplierCd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Height = 0.125F;
            this.SupplierCd_Title.HyperLink = "";
            this.SupplierCd_Title.Left = 4.3125F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.SupplierCd_Title.Text = "得意先";
            this.SupplierCd_Title.Top = 0F;
            this.SupplierCd_Title.Width = 0.4375F;
            // 
            // AnswerListPrice_Title
            // 
            this.AnswerListPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Height = 0.125F;
            this.AnswerListPrice_Title.HyperLink = "";
            this.AnswerListPrice_Title.Left = 3.875F;
            this.AnswerListPrice_Title.MultiLine = false;
            this.AnswerListPrice_Title.Name = "AnswerListPrice_Title";
            this.AnswerListPrice_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.AnswerListPrice_Title.Text = "依頼者";
            this.AnswerListPrice_Title.Top = 0F;
            this.AnswerListPrice_Title.Width = 0.375F;
            // 
            // AnswerSalesUnitCost_Title
            // 
            this.AnswerSalesUnitCost_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Height = 0.125F;
            this.AnswerSalesUnitCost_Title.HyperLink = "";
            this.AnswerSalesUnitCost_Title.Left = 7.8125F;
            this.AnswerSalesUnitCost_Title.MultiLine = false;
            this.AnswerSalesUnitCost_Title.Name = "AnswerSalesUnitCost_Title";
            this.AnswerSalesUnitCost_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: middle; ";
            this.AnswerSalesUnitCost_Title.Text = "BO";
            this.AnswerSalesUnitCost_Title.Top = 0F;
            this.AnswerSalesUnitCost_Title.Width = 0.1875F;
            // 
            // BOSlipNo_Print_Title
            // 
            this.BOSlipNo_Print_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo_Print_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo_Print_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo_Print_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo_Print_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo_Print_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo_Print_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo_Print_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo_Print_Title.Height = 0.125F;
            this.BOSlipNo_Print_Title.HyperLink = "";
            this.BOSlipNo_Print_Title.Left = 10.3125F;
            this.BOSlipNo_Print_Title.MultiLine = false;
            this.BOSlipNo_Print_Title.Name = "BOSlipNo_Print_Title";
            this.BOSlipNo_Print_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.BOSlipNo_Print_Title.Text = "拠点";
            this.BOSlipNo_Print_Title.Top = 0F;
            this.BOSlipNo_Print_Title.Width = 0.3125F;
            // 
            // WarehouseShelfNo_Title
            // 
            this.WarehouseShelfNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Height = 0.125F;
            this.WarehouseShelfNo_Title.HyperLink = "";
            this.WarehouseShelfNo_Title.Left = 0F;
            this.WarehouseShelfNo_Title.MultiLine = false;
            this.WarehouseShelfNo_Title.Name = "WarehouseShelfNo_Title";
            this.WarehouseShelfNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.WarehouseShelfNo_Title.Text = "発注先";
            this.WarehouseShelfNo_Title.Top = 0F;
            this.WarehouseShelfNo_Title.Width = 0.3125F;
            // 
            // GoodsNo_Title
            // 
            this.GoodsNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Height = 0.125F;
            this.GoodsNo_Title.HyperLink = "";
            this.GoodsNo_Title.Left = 4.8125F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsNo_Title.Text = "品番";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 0.4375F;
            // 
            // GoodsMakerCd_Title
            // 
            this.GoodsMakerCd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd_Title.Height = 0.125F;
            this.GoodsMakerCd_Title.HyperLink = "";
            this.GoodsMakerCd_Title.Left = 7.125F;
            this.GoodsMakerCd_Title.MultiLine = false;
            this.GoodsMakerCd_Title.Name = "GoodsMakerCd_Title";
            this.GoodsMakerCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsMakerCd_Title.Text = "ﾒｰｶｰ";
            this.GoodsMakerCd_Title.Top = 0F;
            this.GoodsMakerCd_Title.Width = 0.25F;
            // 
            // UOESectOutGoodsCnt_Title
            // 
            this.UOESectOutGoodsCnt_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Height = 0.125F;
            this.UOESectOutGoodsCnt_Title.HyperLink = "";
            this.UOESectOutGoodsCnt_Title.Left = 2.875F;
            this.UOESectOutGoodsCnt_Title.MultiLine = false;
            this.UOESectOutGoodsCnt_Title.Name = "UOESectOutGoodsCnt_Title";
            this.UOESectOutGoodsCnt_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.UOESectOutGoodsCnt_Title.Text = "呼出番号";
            this.UOESectOutGoodsCnt_Title.Top = 0F;
            this.UOESectOutGoodsCnt_Title.Width = 0.4375F;
            // 
            // BO_Print_Title
            // 
            this.BO_Print_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BO_Print_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BO_Print_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BO_Print_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BO_Print_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print_Title.Height = 0.125F;
            this.BO_Print_Title.HyperLink = "";
            this.BO_Print_Title.Left = 3.375F;
            this.BO_Print_Title.MultiLine = false;
            this.BO_Print_Title.Name = "BO_Print_Title";
            this.BO_Print_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.BO_Print_Title.Text = "ｼｽﾃﾑ区分";
            this.BO_Print_Title.Top = 0F;
            this.BO_Print_Title.Width = 0.4375F;
            // 
            // UoeRemark1_Title
            // 
            this.UoeRemark1_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Height = 0.125F;
            this.UoeRemark1_Title.HyperLink = "";
            this.UoeRemark1_Title.Left = 8.0625F;
            this.UoeRemark1_Title.MultiLine = false;
            this.UoeRemark1_Title.Name = "UoeRemark1_Title";
            this.UoeRemark1_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.UoeRemark1_Title.Text = "リマーク１";
            this.UoeRemark1_Title.Top = 0F;
            this.UoeRemark1_Title.Width = 0.6875F;
            // 
            // UoeRemark2_Title
            // 
            this.UoeRemark2_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Height = 0.125F;
            this.UoeRemark2_Title.HyperLink = "";
            this.UoeRemark2_Title.Left = 9.125F;
            this.UoeRemark2_Title.MultiLine = false;
            this.UoeRemark2_Title.Name = "UoeRemark2_Title";
            this.UoeRemark2_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.UoeRemark2_Title.Text = "リマーク２";
            this.UoeRemark2_Title.Top = 0F;
            this.UoeRemark2_Title.Width = 0.5625F;
            // 
            // ReceiveDate_Title
            // 
            this.ReceiveDate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Height = 0.125F;
            this.ReceiveDate_Title.HyperLink = "";
            this.ReceiveDate_Title.Left = 2.3125F;
            this.ReceiveDate_Title.MultiLine = false;
            this.ReceiveDate_Title.Name = "ReceiveDate_Title";
            this.ReceiveDate_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.ReceiveDate_Title.Text = "発注日";
            this.ReceiveDate_Title.Top = 0F;
            this.ReceiveDate_Title.Width = 0.5F;
            // 
            // GoodsName_Title
            // 
            this.GoodsName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Height = 0.125F;
            this.GoodsName_Title.HyperLink = "";
            this.GoodsName_Title.Left = 6.0625F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 6.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsName_Title.Text = "品名";
            this.GoodsName_Title.Top = 0F;
            this.GoodsName_Title.Width = 0.4375F;
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
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
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
            this.label1.Left = 7.4375F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: middle; ";
            this.label1.Text = "数量";
            this.label1.Top = 0F;
            this.label1.Width = 0.3125F;
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
            this.label4.Left = 9.75F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: middle; ";
            this.label4.Text = "納";
            this.label4.Top = 0F;
            this.label4.Width = 0.1875F;
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
            this.label5.Left = 10F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: middle; ";
            this.label5.Text = "H納";
            this.label5.Top = 0F;
            this.label5.Width = 0.25F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionCode,
            this.SectionGuideSnm});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.15625F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.125F;
            this.SectionCode.Left = 0F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SectionCode.Text = "00";
            this.SectionCode.Top = 0F;
            this.SectionCode.Visible = false;
            this.SectionCode.Width = 0.1875F;
            // 
            // SectionGuideSnm
            // 
            this.SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.DataField = "SectionGuideSnm";
            this.SectionGuideSnm.Height = 0.125F;
            this.SectionGuideSnm.Left = 0.25F;
            this.SectionGuideSnm.MultiLine = false;
            this.SectionGuideSnm.Name = "SectionGuideSnm";
            this.SectionGuideSnm.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SectionGuideSnm.Text = "拠点３４５６７８９０";
            this.SectionGuideSnm.Top = 0F;
            this.SectionGuideSnm.Visible = false;
            this.SectionGuideSnm.Width = 1.1875F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // PMUOE02084P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 10.8F;
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
            this.ReportStart += new System.EventHandler(this.PMUOE02084P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivCd_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEDeliGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowDeliGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOEResvdSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo_Print_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BO_Print_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}
