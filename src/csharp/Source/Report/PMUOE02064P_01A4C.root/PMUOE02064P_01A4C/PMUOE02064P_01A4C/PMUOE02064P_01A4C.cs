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
    /// 入庫予定表印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 入庫予定表のフォームクラスです。</br>
    /// <br>Programmer	: 30413 犬飼</br>
    /// <br>Date		: 2008.12.03</br>
    /// <br>Note        : ハンディターミナル二次開発の対応</br>
    /// <br>Programmer  : 譚洪</br>
    /// <br>Date	    : 2017/09/14</br>
    /// </remarks>
    public class PMUOE02064P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
		/// <summary>
        /// 入庫予定表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 入庫予定表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.03</br>
        /// </remarks>
        public PMUOE02064P_01A4C()
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
        private EnterSchOrderCndtn _enterSchOrderCndtn;		        // 抽出条件クラス
        
        private DataSet _outputDs;						            // 印刷用DataSet

        private const string ct_CollectTable = EnterSchResult.Col_Tbl_Result_EnterSch;    // 入庫予定表テーブル名称

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
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
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
        private GroupHeader WarehouseHeader;
        private GroupFooter WarehouseFooter;
        private GroupHeader SupplierHeader;
        private GroupFooter SupplierFooter;
        private Detail Detail;
        private Label SupplierCd_Title;
        private Label AnswerListPrice_Title;
        private Label AnswerSalesUnitCost_Title;
        private Label SlipNo_Print_Title;
        private Label WarehouseShelfNo_Title;
        private Label GoodsNo_Title;
        private TextBox SumTitle;
        private Label GoodsMakerCd_Title;
        private Label UOESectOutGoodsCnt_Title;
        private Label BO_Print_Title;
        private Label UoeRemark1_Title;
        private Label UoeRemark2_Title;
        private Label ReceiveDate_Title;
        private TextBox SectionCode;
        private TextBox SectionGuideSnm;
        private TextBox WarehouseShelfNo;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox SupplierCd;
        private TextBox GoodsMakerCd;
        private TextBox UOESectOutGoodsCnt;
        private TextBox BO_Print;
        private TextBox AnswerListPrice;
        private TextBox AnswerSalesUnitCost;
        private TextBox SlipNo_Print;
        private TextBox UoeRemark1;
        private TextBox UoeRemark2;
        private TextBox ReceiveDate;
        private Label GoodsName_Title;
        private TextBox WarehouseCode;
        private TextBox WarehouseName;
        private TextBox textBox10;
        private TextBox textBox17;
        private Line line2;
        private Line line3;
        private TextBox textBox11;
        private Line line4;
        private TextBox s_UOESectOutGoodsCnt;
        private TextBox textBox13;
        private SubReport Footer_SubReport;
        private TextBox g_UOESectOutGoodsCnt;
        private TextBox textBox6;
        private TextBox w_UOESectOutGoodsCnt;
        private TextBox textBox4;
        private TextBox textBox1;
        private TextBox sec_UOESectOutGoodsCnt;
        private TextBox textBox2;
        private Line line8;
        private Line line7;
        private Line line6;
        private Line line5;
        private Barcode BC_SupplierSeqNo;
        private TextBox textBox_Space;


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
                this._enterSchOrderCndtn = (EnterSchOrderCndtn)this._printInfo.jyoken;
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
        /// <br>Date		: 2008.12.03</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderSubtitle;		   // サブタイトル
            tb_SortOrderName.Text = this._pageHeaderSortOderTitle;   // ソート条件
            
            // 改頁制御
            if (this._enterSchOrderCndtn.NewPageDiv == 1)
            {
                // しない
                WarehouseHeader.NewPage = NewPage.None;
                SupplierHeader.NewPage = NewPage.None;
            }
            else
            {
                // 倉庫
                SupplierHeader.NewPage = NewPage.None;
            }
            
            switch (this._enterSchOrderCndtn.SortOrderDiv)
            {
                case 0:         // 倉庫・棚番順
                    {
                        // ヘッダー・フッター表示制御
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;

                        break;
                    }
                case 1:         // 倉庫・品番順
                    {
                        // 明細タイトル
                        GoodsNo_Title.Left = 0.0F;                  // 品番
                        GoodsMakerCd_Title.Left = 1.438F;           // ﾒｰｶｰ
                        GoodsName_Title.Left = 1.813F;              // 品名
                        UOESectOutGoodsCnt_Title.Left = 3.063F;     // 入庫数
                        BO_Print_Title.Left = 3.563F;               // BO数
                        AnswerListPrice_Title.Left = 4.063F;        // 標準価格
                        AnswerSalesUnitCost_Title.Left = 5.0F;      // 原単価
                        SupplierCd_Title.Left = 6.063F;             // 仕入先
                        WarehouseShelfNo_Title.Left = 6.5F;         // 棚番

                        // 明細行
                        GoodsNo.Left = 0.0F;                        // 品番
                        GoodsMakerCd.Left = 1.438F;                 // ﾒｰｶｰ
                        GoodsName.Left = 1.813F;                    // 品名
                        UOESectOutGoodsCnt.Left = 3.063F;           // 入庫数
                        BO_Print.Left = 3.563F;                     // BO数
                        AnswerListPrice.Left = 4.063F;              // 標準価格
                        AnswerSalesUnitCost.Left = 5.0F;            // 原単価
                        SupplierCd.Left = 6.063F;                   // 仕入先
                        WarehouseShelfNo.Left = 6.5F;               // 棚番

                        // 仕入先計
                        textBox17.Left = 2.125F;
                        s_UOESectOutGoodsCnt.Left = 3.063F;
                        textBox13.Left = 3.563F;

                        // 倉庫計
                        textBox10.Left = 2.125F;
                        w_UOESectOutGoodsCnt.Left = 3.063F;
                        textBox4.Left = 3.563F;

                        // 拠点計
                        textBox1.Left = 2.125F;
                        sec_UOESectOutGoodsCnt.Left = 3.063F;
                        textBox2.Left = 3.563F;

                        // 総合計
                        textBox11.Left = 2.125F;
                        g_UOESectOutGoodsCnt.Left = 3.063F;
                        textBox6.Left = 3.563F;

                        // ヘッダー・フッター表示制御
                        SupplierHeader.Visible = false;
                        SupplierFooter.Visible = false;

                        break;
                    }
                case 2:         // 倉庫・仕入先・品番順
                    {
                        // 明細タイトル
                        SupplierCd_Title.Left = 0.0F;               // 仕入先
                        GoodsNo_Title.Left = 0.438F;                // 品番
                        GoodsMakerCd_Title.Left = 1.875F;           // ﾒｰｶｰ
                        GoodsName_Title.Left = 2.25F;               // 品名
                        UOESectOutGoodsCnt_Title.Left = 3.5F;       // 入庫数
                        BO_Print_Title.Left = 4.0F;                 // BO数
                        AnswerListPrice_Title.Left = 4.5F;          // 標準価格
                        AnswerSalesUnitCost_Title.Left = 5.438F;    // 原単価
                        WarehouseShelfNo_Title.Left = 6.5F;         // 棚番

                        // 明細行
                        SupplierCd.Left = 0.0F;                     // 仕入先
                        GoodsNo.Left = 0.438F;                      // 品番
                        GoodsMakerCd.Left = 1.875F;                 // ﾒｰｶｰ
                        GoodsName.Left = 2.25F;                     // 品名
                        UOESectOutGoodsCnt.Left = 3.5F;             // 入庫数
                        BO_Print.Left = 4.0F;                       // BO数
                        AnswerListPrice.Left = 4.5F;                // 標準価格
                        AnswerSalesUnitCost.Left = 5.438F;          // 原単価
                        WarehouseShelfNo.Left = 6.5F;               // 棚番

                        // 仕入先計
                        textBox17.Left = 2.563F;
                        s_UOESectOutGoodsCnt.Left = 3.5F;
                        textBox13.Left = 4.0F;

                        // 倉庫計
                        textBox10.Left = 2.563F;
                        w_UOESectOutGoodsCnt.Left = 3.5F;
                        textBox4.Left = 4.0F;

                        // 拠点計
                        textBox1.Left = 2.563F;
                        sec_UOESectOutGoodsCnt.Left = 3.5F;
                        textBox2.Left = 4.0F;

                        // 総合計
                        textBox11.Left = 2.563F;
                        g_UOESectOutGoodsCnt.Left = 3.5F;
                        textBox6.Left = 4.0F;

                        break;
                    }
                case 3:         // 倉庫・仕入先・仕入伝票番号順
                    {
                        // 明細タイトル
                        SupplierCd_Title.Left = 0.0F;               // 仕入先
                        SlipNo_Print_Title.Left = 0.438F;           // 仕入伝票番号
                        GoodsNo_Title.Left = 1.25F;                 // 品番
                        GoodsMakerCd_Title.Left = 2.688F;           // ﾒｰｶｰ
                        GoodsName_Title.Left = 3.063F;              // 品名
                        UOESectOutGoodsCnt_Title.Left = 4.313F;     // 入庫数
                        BO_Print_Title.Left = 4.813F;               // BO数
                        AnswerListPrice_Title.Left = 5.313F;        // 標準価格
                        AnswerSalesUnitCost_Title.Left = 6.25F;     // 原単価
                        WarehouseShelfNo_Title.Left = 7.313F;       // 棚番

                        // 明細行
                        SupplierCd.Left = 0.0F;                     // 仕入先
                        SlipNo_Print.Left = 0.438F;                 // 仕入伝票番号
                        GoodsNo.Left = 1.25F;                       // 品番
                        GoodsMakerCd.Left = 2.688F;                 // ﾒｰｶｰ
                        GoodsName.Left = 3.063F;                    // 品名
                        UOESectOutGoodsCnt.Left = 4.313F;           // 入庫数
                        BO_Print.Left = 4.813F;                     // BO数
                        AnswerListPrice.Left = 5.313F;              // 標準価格
                        AnswerSalesUnitCost.Left = 6.25F;           // 原単価
                        WarehouseShelfNo.Left = 7.313F;             // 棚番

                        // 仕入先計
                        textBox17.Left = 3.375F;
                        s_UOESectOutGoodsCnt.Left = 4.313F;
                        textBox13.Left = 4.813F;

                        // 倉庫計
                        textBox10.Left = 3.375F;
                        w_UOESectOutGoodsCnt.Left = 4.313F;
                        textBox4.Left = 4.813F;

                        // 拠点計
                        textBox1.Left = 3.375F;
                        sec_UOESectOutGoodsCnt.Left = 4.313F;
                        textBox2.Left = 4.813F;

                        // 総合計
                        textBox11.Left = 3.375F;
                        g_UOESectOutGoodsCnt.Left = 4.313F;
                        textBox6.Left = 4.813F;

                        break;
                    }
            }            
        }
        #endregion ◆ レポート要素出力設定

        #endregion

        #region ■ Control Event

        #region ◎ PMUOE02064P_01A4C_ReportStart Event
        /// <summary>
        /// PMUOE02064P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.12.03</br>
        /// </remarks>
        private void PMUOE02064P_01A4C_ReportStart(object sender, EventArgs e)
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
        /// <br>Date		: 2008.12.03</br>
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
        /// <br>Date		: 2008.12.03</br>
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
        /// <br>Date		: 2008.12.03</br>
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
        /// <br>Date		: 2008.12.03</br>
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
        /// <br>Date		: 2008.12.03</br>
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMUOE02064P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.BO_Print = new DataDynamics.ActiveReports.TextBox();
            this.AnswerListPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnswerSalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.SlipNo_Print = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark1 = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark2 = new DataDynamics.ActiveReports.TextBox();
            this.ReceiveDate = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.BC_SupplierSeqNo = new DataDynamics.ActiveReports.Barcode();
            this.textBox_Space = new DataDynamics.ActiveReports.TextBox();
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
            this.SlipNo_Print_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd_Title = new DataDynamics.ActiveReports.Label();
            this.UOESectOutGoodsCnt_Title = new DataDynamics.ActiveReports.Label();
            this.BO_Print_Title = new DataDynamics.ActiveReports.Label();
            this.UoeRemark1_Title = new DataDynamics.ActiveReports.Label();
            this.UoeRemark2_Title = new DataDynamics.ActiveReports.Label();
            this.ReceiveDate_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.g_UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.sec_UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.w_UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.s_UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BO_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Space)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo_Print_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BO_Print_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sec_UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseShelfNo,
            this.GoodsNo,
            this.GoodsName,
            this.SupplierCd,
            this.GoodsMakerCd,
            this.UOESectOutGoodsCnt,
            this.BO_Print,
            this.AnswerListPrice,
            this.AnswerSalesUnitCost,
            this.SlipNo_Print,
            this.UoeRemark1,
            this.UoeRemark2,
            this.ReceiveDate,
            this.line2,
            this.BC_SupplierSeqNo,
            this.textBox_Space});
            this.Detail.Height = 0.5625F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // WarehouseShelfNo
            // 
            this.WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo.Height = 0.125F;
            this.WarehouseShelfNo.Left = 0F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0F;
            this.WarehouseShelfNo.Width = 0.5F;
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
            this.GoodsNo.Left = 0.5625F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.375F;
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
            this.GoodsName.Left = 2.375F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.1875F;
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
            this.SupplierCd.DataField = "SupplierCd";
            this.SupplierCd.Height = 0.125F;
            this.SupplierCd.Left = 6.625F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0F;
            this.SupplierCd.Width = 0.375F;
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
            this.GoodsMakerCd.Left = 2F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.3125F;
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
            this.UOESectOutGoodsCnt.DataField = "OutGoodsCnt_Print";
            this.UOESectOutGoodsCnt.Height = 0.125F;
            this.UOESectOutGoodsCnt.Left = 3.625F;
            this.UOESectOutGoodsCnt.MultiLine = false;
            this.UOESectOutGoodsCnt.Name = "UOESectOutGoodsCnt";
            this.UOESectOutGoodsCnt.OutputFormat = resources.GetString("UOESectOutGoodsCnt.OutputFormat");
            this.UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.UOESectOutGoodsCnt.Text = "12,345";
            this.UOESectOutGoodsCnt.Top = 0F;
            this.UOESectOutGoodsCnt.Width = 0.4375F;
            // 
            // BO_Print
            // 
            this.BO_Print.Border.BottomColor = System.Drawing.Color.Black;
            this.BO_Print.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print.Border.LeftColor = System.Drawing.Color.Black;
            this.BO_Print.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print.Border.RightColor = System.Drawing.Color.Black;
            this.BO_Print.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print.Border.TopColor = System.Drawing.Color.Black;
            this.BO_Print.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BO_Print.DataField = "BOCnt_Print";
            this.BO_Print.Height = 0.125F;
            this.BO_Print.Left = 4.125F;
            this.BO_Print.MultiLine = false;
            this.BO_Print.Name = "BO_Print";
            this.BO_Print.OutputFormat = resources.GetString("BO_Print.OutputFormat");
            this.BO_Print.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.BO_Print.Text = "12,345";
            this.BO_Print.Top = 0F;
            this.BO_Print.Width = 0.4375F;
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
            this.AnswerListPrice.Height = 0.125F;
            this.AnswerListPrice.Left = 4.625F;
            this.AnswerListPrice.MultiLine = false;
            this.AnswerListPrice.Name = "AnswerListPrice";
            this.AnswerListPrice.OutputFormat = resources.GetString("AnswerListPrice.OutputFormat");
            this.AnswerListPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnswerListPrice.Text = "1,234,567,890";
            this.AnswerListPrice.Top = 0F;
            this.AnswerListPrice.Width = 0.875F;
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
            this.AnswerSalesUnitCost.Height = 0.125F;
            this.AnswerSalesUnitCost.Left = 5.5625F;
            this.AnswerSalesUnitCost.MultiLine = false;
            this.AnswerSalesUnitCost.Name = "AnswerSalesUnitCost";
            this.AnswerSalesUnitCost.OutputFormat = resources.GetString("AnswerSalesUnitCost.OutputFormat");
            this.AnswerSalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AnswerSalesUnitCost.Text = "1,234,567,890.00";
            this.AnswerSalesUnitCost.Top = 0F;
            this.AnswerSalesUnitCost.Width = 1F;
            // 
            // SlipNo_Print
            // 
            this.SlipNo_Print.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNo_Print.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNo_Print.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNo_Print.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNo_Print.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print.DataField = "SlipNo_Print";
            this.SlipNo_Print.Height = 0.125F;
            this.SlipNo_Print.Left = 7.0625F;
            this.SlipNo_Print.MultiLine = false;
            this.SlipNo_Print.Name = "SlipNo_Print";
            this.SlipNo_Print.OutputFormat = resources.GetString("SlipNo_Print.OutputFormat");
            this.SlipNo_Print.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SlipNo_Print.Text = "1234567";
            this.SlipNo_Print.Top = 0F;
            this.SlipNo_Print.Width = 0.75F;
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
            this.UoeRemark1.Left = 7.875F;
            this.UoeRemark1.MultiLine = false;
            this.UoeRemark1.Name = "UoeRemark1";
            this.UoeRemark1.OutputFormat = resources.GetString("UoeRemark1.OutputFormat");
            this.UoeRemark1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UoeRemark1.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.UoeRemark1.Top = 0F;
            this.UoeRemark1.Width = 1.1875F;
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
            this.UoeRemark2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UoeRemark2.Text = "ｱｲｳｴｵｶｷｸｹｺ";
            this.UoeRemark2.Top = 0F;
            this.UoeRemark2.Width = 0.625F;
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
            this.ReceiveDate.DataField = "ReceiveDate";
            this.ReceiveDate.Height = 0.125F;
            this.ReceiveDate.Left = 9.8125F;
            this.ReceiveDate.MultiLine = false;
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.OutputFormat = resources.GetString("ReceiveDate.OutputFormat");
            this.ReceiveDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ReceiveDate.Text = "9999/99/99";
            this.ReceiveDate.Top = 0F;
            this.ReceiveDate.Width = 0.625F;
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
            // BC_SupplierSeqNo
            // 
            this.BC_SupplierSeqNo.Border.BottomColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.Border.LeftColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.Border.RightColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.Border.TopColor = System.Drawing.Color.Black;
            this.BC_SupplierSeqNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BC_SupplierSeqNo.CheckSumEnabled = false;
            this.BC_SupplierSeqNo.DataField = "SupplierSeqNoForBarCode";
            this.BC_SupplierSeqNo.Font = new System.Drawing.Font("ＭＳ 明朝", 16F);
            this.BC_SupplierSeqNo.Height = 0.2F;
            this.BC_SupplierSeqNo.Left = 7.063F;
            this.BC_SupplierSeqNo.Name = "BC_SupplierSeqNo";
            this.BC_SupplierSeqNo.Style = DataDynamics.ActiveReports.BarCodeStyle.Code39;
            this.BC_SupplierSeqNo.Text = "barcode";
            this.BC_SupplierSeqNo.Top = 0.125F;
            this.BC_SupplierSeqNo.Width = 2.9F;
            // 
            // textBox_Space
            // 
            this.textBox_Space.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Border.RightColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Border.TopColor = System.Drawing.Color.Black;
            this.textBox_Space.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox_Space.Height = 0.375F;
            this.textBox_Space.Left = 6.5F;
            this.textBox_Space.MultiLine = false;
            this.textBox_Space.Name = "textBox_Space";
            this.textBox_Space.OutputFormat = resources.GetString("textBox_Space.OutputFormat");
            this.textBox_Space.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.textBox_Space.Top = 0.125F;
            this.textBox_Space.Width = 0.438F;
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
            this.tb_ReportTitle.Text = "入庫予定表";
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
            this.SlipNo_Print_Title,
            this.WarehouseShelfNo_Title,
            this.GoodsNo_Title,
            this.SumTitle,
            this.GoodsMakerCd_Title,
            this.UOESectOutGoodsCnt_Title,
            this.BO_Print_Title,
            this.UoeRemark1_Title,
            this.UoeRemark2_Title,
            this.ReceiveDate_Title,
            this.GoodsName_Title,
            this.line3});
            this.TitleHeader.Height = 0.4583333F;
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
            this.SupplierCd_Title.Height = 0.1875F;
            this.SupplierCd_Title.HyperLink = "";
            this.SupplierCd_Title.Left = 6.625F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.SupplierCd_Title.Text = "仕入先";
            this.SupplierCd_Title.Top = 0.1875F;
            this.SupplierCd_Title.Width = 0.375F;
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
            this.AnswerListPrice_Title.Height = 0.1875F;
            this.AnswerListPrice_Title.HyperLink = "";
            this.AnswerListPrice_Title.Left = 4.625F;
            this.AnswerListPrice_Title.MultiLine = false;
            this.AnswerListPrice_Title.Name = "AnswerListPrice_Title";
            this.AnswerListPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.AnswerListPrice_Title.Text = "標準価格";
            this.AnswerListPrice_Title.Top = 0.1875F;
            this.AnswerListPrice_Title.Width = 0.875F;
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
            this.AnswerSalesUnitCost_Title.Height = 0.1875F;
            this.AnswerSalesUnitCost_Title.HyperLink = "";
            this.AnswerSalesUnitCost_Title.Left = 5.5625F;
            this.AnswerSalesUnitCost_Title.MultiLine = false;
            this.AnswerSalesUnitCost_Title.Name = "AnswerSalesUnitCost_Title";
            this.AnswerSalesUnitCost_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.AnswerSalesUnitCost_Title.Text = "原単価";
            this.AnswerSalesUnitCost_Title.Top = 0.1875F;
            this.AnswerSalesUnitCost_Title.Width = 1F;
            // 
            // SlipNo_Print_Title
            // 
            this.SlipNo_Print_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNo_Print_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNo_Print_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNo_Print_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNo_Print_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo_Print_Title.Height = 0.1875F;
            this.SlipNo_Print_Title.HyperLink = "";
            this.SlipNo_Print_Title.Left = 7.0625F;
            this.SlipNo_Print_Title.MultiLine = false;
            this.SlipNo_Print_Title.Name = "SlipNo_Print_Title";
            this.SlipNo_Print_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.SlipNo_Print_Title.Text = "仕入伝票番号";
            this.SlipNo_Print_Title.Top = 0.1875F;
            this.SlipNo_Print_Title.Width = 0.75F;
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
            this.WarehouseShelfNo_Title.Height = 0.1875F;
            this.WarehouseShelfNo_Title.HyperLink = "";
            this.WarehouseShelfNo_Title.Left = 0F;
            this.WarehouseShelfNo_Title.MultiLine = false;
            this.WarehouseShelfNo_Title.Name = "WarehouseShelfNo_Title";
            this.WarehouseShelfNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.WarehouseShelfNo_Title.Text = "棚番";
            this.WarehouseShelfNo_Title.Top = 0.1875F;
            this.WarehouseShelfNo_Title.Width = 0.5F;
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
            this.GoodsNo_Title.Height = 0.1875F;
            this.GoodsNo_Title.HyperLink = "";
            this.GoodsNo_Title.Left = 0.5625F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsNo_Title.Text = "品番";
            this.GoodsNo_Title.Top = 0.1875F;
            this.GoodsNo_Title.Width = 0.4375F;
            // 
            // SumTitle
            // 
            this.SumTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SumTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SumTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SumTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SumTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumTitle.Height = 0.1875F;
            this.SumTitle.Left = 0F;
            this.SumTitle.MultiLine = false;
            this.SumTitle.Name = "SumTitle";
            this.SumTitle.OutputFormat = resources.GetString("SumTitle.OutputFormat");
            this.SumTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.SumTitle.Text = "倉庫";
            this.SumTitle.Top = 0F;
            this.SumTitle.Width = 0.5F;
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
            this.GoodsMakerCd_Title.Height = 0.1875F;
            this.GoodsMakerCd_Title.HyperLink = "";
            this.GoodsMakerCd_Title.Left = 2F;
            this.GoodsMakerCd_Title.MultiLine = false;
            this.GoodsMakerCd_Title.Name = "GoodsMakerCd_Title";
            this.GoodsMakerCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsMakerCd_Title.Text = "ﾒｰｶｰ";
            this.GoodsMakerCd_Title.Top = 0.1875F;
            this.GoodsMakerCd_Title.Width = 0.3125F;
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
            this.UOESectOutGoodsCnt_Title.Height = 0.1875F;
            this.UOESectOutGoodsCnt_Title.HyperLink = "";
            this.UOESectOutGoodsCnt_Title.Left = 3.625F;
            this.UOESectOutGoodsCnt_Title.MultiLine = false;
            this.UOESectOutGoodsCnt_Title.Name = "UOESectOutGoodsCnt_Title";
            this.UOESectOutGoodsCnt_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.UOESectOutGoodsCnt_Title.Text = "入庫数";
            this.UOESectOutGoodsCnt_Title.Top = 0.1875F;
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
            this.BO_Print_Title.Height = 0.1875F;
            this.BO_Print_Title.HyperLink = "";
            this.BO_Print_Title.Left = 4.125F;
            this.BO_Print_Title.MultiLine = false;
            this.BO_Print_Title.Name = "BO_Print_Title";
            this.BO_Print_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.BO_Print_Title.Text = "BO数";
            this.BO_Print_Title.Top = 0.1875F;
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
            this.UoeRemark1_Title.Height = 0.1875F;
            this.UoeRemark1_Title.HyperLink = "";
            this.UoeRemark1_Title.Left = 7.875F;
            this.UoeRemark1_Title.MultiLine = false;
            this.UoeRemark1_Title.Name = "UoeRemark1_Title";
            this.UoeRemark1_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.UoeRemark1_Title.Text = "リマーク１";
            this.UoeRemark1_Title.Top = 0.1875F;
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
            this.UoeRemark2_Title.Height = 0.1875F;
            this.UoeRemark2_Title.HyperLink = "";
            this.UoeRemark2_Title.Left = 9.125F;
            this.UoeRemark2_Title.MultiLine = false;
            this.UoeRemark2_Title.Name = "UoeRemark2_Title";
            this.UoeRemark2_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.UoeRemark2_Title.Text = "リマーク２";
            this.UoeRemark2_Title.Top = 0.1875F;
            this.UoeRemark2_Title.Width = 0.625F;
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
            this.ReceiveDate_Title.Height = 0.1875F;
            this.ReceiveDate_Title.HyperLink = "";
            this.ReceiveDate_Title.Left = 9.8125F;
            this.ReceiveDate_Title.MultiLine = false;
            this.ReceiveDate_Title.Name = "ReceiveDate_Title";
            this.ReceiveDate_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.ReceiveDate_Title.Text = "発注日";
            this.ReceiveDate_Title.Top = 0.1875F;
            this.ReceiveDate_Title.Width = 0.625F;
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
            this.GoodsName_Title.Height = 0.1875F;
            this.GoodsName_Title.HyperLink = "";
            this.GoodsName_Title.Left = 2.375F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.GoodsName_Title.Text = "品名";
            this.GoodsName_Title.Top = 0.1875F;
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
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11,
            this.g_UOESectOutGoodsCnt,
            this.textBox6,
            this.line8});
            this.GrandTotalFooter.Height = 0.25F;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 2.6875F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.textBox11.Text = "総合計";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.7F;
            // 
            // g_UOESectOutGoodsCnt
            // 
            this.g_UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.g_UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.g_UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.g_UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.g_UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_UOESectOutGoodsCnt.DataField = "OutGoodsCnt_Print";
            this.g_UOESectOutGoodsCnt.Height = 0.1875F;
            this.g_UOESectOutGoodsCnt.Left = 3.625F;
            this.g_UOESectOutGoodsCnt.MultiLine = false;
            this.g_UOESectOutGoodsCnt.Name = "g_UOESectOutGoodsCnt";
            this.g_UOESectOutGoodsCnt.OutputFormat = resources.GetString("g_UOESectOutGoodsCnt.OutputFormat");
            this.g_UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.g_UOESectOutGoodsCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_UOESectOutGoodsCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_UOESectOutGoodsCnt.Text = "123,456";
            this.g_UOESectOutGoodsCnt.Top = 0F;
            this.g_UOESectOutGoodsCnt.Width = 0.4375F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DataField = "BOCnt_Print";
            this.textBox6.Height = 0.1875F;
            this.textBox6.Left = 4.125F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox6.Text = "123,456";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.4375F;
            // 
            // line8
            // 
            this.line8.Border.BottomColor = System.Drawing.Color.Black;
            this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.LeftColor = System.Drawing.Color.Black;
            this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.RightColor = System.Drawing.Color.Black;
            this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.TopColor = System.Drawing.Color.Black;
            this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Height = 0F;
            this.line8.Left = 0F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 0F;
            this.line8.Width = 10.8F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
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
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.sec_UOESectOutGoodsCnt,
            this.textBox2,
            this.line7});
            this.SectionFooter.Height = 0.2604167F;
            this.SectionFooter.Name = "SectionFooter";
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
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 2.6875F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.textBox1.Text = "拠点計";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.7F;
            // 
            // sec_UOESectOutGoodsCnt
            // 
            this.sec_UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.sec_UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sec_UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.sec_UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sec_UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.sec_UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sec_UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.sec_UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sec_UOESectOutGoodsCnt.DataField = "OutGoodsCnt_Print";
            this.sec_UOESectOutGoodsCnt.Height = 0.1875F;
            this.sec_UOESectOutGoodsCnt.Left = 3.625F;
            this.sec_UOESectOutGoodsCnt.MultiLine = false;
            this.sec_UOESectOutGoodsCnt.Name = "sec_UOESectOutGoodsCnt";
            this.sec_UOESectOutGoodsCnt.OutputFormat = resources.GetString("sec_UOESectOutGoodsCnt.OutputFormat");
            this.sec_UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.sec_UOESectOutGoodsCnt.SummaryGroup = "SectionHeader";
            this.sec_UOESectOutGoodsCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.sec_UOESectOutGoodsCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.sec_UOESectOutGoodsCnt.Text = "123,456";
            this.sec_UOESectOutGoodsCnt.Top = 0F;
            this.sec_UOESectOutGoodsCnt.Width = 0.4375F;
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
            this.textBox2.DataField = "BOCnt_Print";
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 4.125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox2.SummaryGroup = "SectionHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "123,456";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.4375F;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0F;
            this.line7.Left = 0F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseCode,
            this.WarehouseName,
            this.line4});
            this.WarehouseHeader.DataField = "WarehouseCode";
            this.WarehouseHeader.Height = 0.25F;
            this.WarehouseHeader.KeepTogether = true;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // WarehouseCode
            // 
            this.WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.DataField = "WarehouseCode";
            this.WarehouseCode.Height = 0.125F;
            this.WarehouseCode.Left = 0F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.WarehouseCode.Text = "1234";
            this.WarehouseCode.Top = 0F;
            this.WarehouseCode.Width = 0.3125F;
            // 
            // WarehouseName
            // 
            this.WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.DataField = "WarehouseName";
            this.WarehouseName.Height = 0.125F;
            this.WarehouseName.Left = 0.375F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseName.Text = "倉庫名称５６７８９０";
            this.WarehouseName.Top = 0F;
            this.WarehouseName.Width = 1.1875F;
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
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox10,
            this.w_UOESectOutGoodsCnt,
            this.textBox4,
            this.line6});
            this.WarehouseFooter.Height = 0.25F;
            this.WarehouseFooter.Name = "WarehouseFooter";
            // 
            // textBox10
            // 
            this.textBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.RightColor = System.Drawing.Color.Black;
            this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.TopColor = System.Drawing.Color.Black;
            this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 2.6875F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.textBox10.Text = "倉庫計";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.7F;
            // 
            // w_UOESectOutGoodsCnt
            // 
            this.w_UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.w_UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.w_UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.w_UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.w_UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_UOESectOutGoodsCnt.DataField = "OutGoodsCnt_Print";
            this.w_UOESectOutGoodsCnt.Height = 0.1875F;
            this.w_UOESectOutGoodsCnt.Left = 3.625F;
            this.w_UOESectOutGoodsCnt.MultiLine = false;
            this.w_UOESectOutGoodsCnt.Name = "w_UOESectOutGoodsCnt";
            this.w_UOESectOutGoodsCnt.OutputFormat = resources.GetString("w_UOESectOutGoodsCnt.OutputFormat");
            this.w_UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.w_UOESectOutGoodsCnt.SummaryGroup = "WarehouseHeader";
            this.w_UOESectOutGoodsCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_UOESectOutGoodsCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_UOESectOutGoodsCnt.Text = "123,456";
            this.w_UOESectOutGoodsCnt.Top = 0F;
            this.w_UOESectOutGoodsCnt.Width = 0.4375F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "BOCnt_Print";
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 4.125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox4.SummaryGroup = "WarehouseHeader";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "123,456";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.4375F;
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
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.CanShrink = true;
            this.SupplierHeader.DataField = "SupplierCd";
            this.SupplierHeader.Height = 0F;
            this.SupplierHeader.Name = "SupplierHeader";
            this.SupplierHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SupplierHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox17,
            this.s_UOESectOutGoodsCnt,
            this.textBox13,
            this.line5});
            this.SupplierFooter.Height = 0.25F;
            this.SupplierFooter.Name = "SupplierFooter";
            // 
            // textBox17
            // 
            this.textBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.RightColor = System.Drawing.Color.Black;
            this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.TopColor = System.Drawing.Color.Black;
            this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Height = 0.1875F;
            this.textBox17.Left = 2.6875F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.textBox17.Text = "仕入先計";
            this.textBox17.Top = 0F;
            this.textBox17.Width = 0.7F;
            // 
            // s_UOESectOutGoodsCnt
            // 
            this.s_UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.s_UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.s_UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.s_UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.s_UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_UOESectOutGoodsCnt.DataField = "OutGoodsCnt_Print";
            this.s_UOESectOutGoodsCnt.Height = 0.1875F;
            this.s_UOESectOutGoodsCnt.Left = 3.625F;
            this.s_UOESectOutGoodsCnt.MultiLine = false;
            this.s_UOESectOutGoodsCnt.Name = "s_UOESectOutGoodsCnt";
            this.s_UOESectOutGoodsCnt.OutputFormat = resources.GetString("s_UOESectOutGoodsCnt.OutputFormat");
            this.s_UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.s_UOESectOutGoodsCnt.SummaryGroup = "SupplierHeader";
            this.s_UOESectOutGoodsCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_UOESectOutGoodsCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_UOESectOutGoodsCnt.Text = "123,456";
            this.s_UOESectOutGoodsCnt.Top = 0F;
            this.s_UOESectOutGoodsCnt.Width = 0.4375F;
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
            this.textBox13.DataField = "BOCnt_Print";
            this.textBox13.Height = 0.1875F;
            this.textBox13.Left = 4.125F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox13.SummaryGroup = "SupplierHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "123,456";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.4375F;
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
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // PMUOE02064P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SupplierFooter);
            this.Sections.Add(this.WarehouseFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMUOE02064P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BO_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Space)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo_Print_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BO_Print_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sec_UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 明細セクションがページに描画される前に発生する。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date	    : 2017/09/14</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // バーコードデータがある場合、空行を追加します。
            if (string.IsNullOrEmpty(this.BC_SupplierSeqNo.Text))
            {
                this.textBox_Space.Visible = false;
                this.BC_SupplierSeqNo.Visible = false;
            }
            else
            {
                this.textBox_Space.Visible = true;
                this.BC_SupplierSeqNo.Visible = true;
            }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<
    }
}
