using System;
using System.Drawing;
using System.Collections;
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
    /// 出荷商品優良対応表2帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 出荷商品優良対応表2帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.25</br>
    /// <br>Update Note  : 2009.01.08 30452 上野 俊治</br>
    /// <br>               障害対応9666(合計部は検索先が無い場合でも表示するよう修正)</br>
    /// <br>Update Note  : 2009.02.17 30452 上野 俊治</br>
    /// <br>               障害対応11531(改頁された際、1行目の印字が非表示になる場合があったのを修正)</br>
    /// </remarks>
    public class PMHNB02153P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02153P_01A4C()
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

        private ShipGdsPrimeListCndtn2 _shipGdsPrimeListCndtn2;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        // 同明細1行目フラグ(true:1行目)
        bool _sameDetailFlg; // ADD 2009/02/17

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
        private Line Line2;
        private Label Lb_SectionTitle;
        private Label label4;
        private Label label1;
        private Line line3;
        private TextBox SecHd_SectionCode;
        private TextBox SecHd_SectionName;
        private SubReport Footer_SubReport;
        private TextBox Main_GoodsNo;
        private TextBox Main_WarehouseShelfNo;
        private TextBox Main_St_SalesTimes;
        private TextBox Main_Or_SalesTimes;
        private TextBox Main_Sum_SalesTimes;
        private TextBox Sub_DisplayOrder;
        private TextBox Sub_MakerCode;
        private TextBox Sub_SuplierCode;
        private TextBox Sub_GoodsNo;
        private TextBox Sub_WarehouseShelfNo;
        private TextBox Sub_St_SalesTimes;
        private TextBox Sub_Or_SalesTimes;
        private TextBox Sub_Sum_SalesTimes;
        private TextBox SubTotal_St_SalesTimes;
        private TextBox SubTotal_Or_SalesTimes;
        private TextBox SubTotal_Sum_SalesTimes;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Line line5;
        private Line line6;
        private Line line7;
        private Line line8;
        private TextBox SubInfoCount;
        private GroupHeader GroupHeader;
        private TextBox Main_BLGroupCode;
        private TextBox Main_GoodsName;
        private Line line4;
        private Line line9;
        private Line line10;
        private GroupFooter GroupFooter;
        private TextBox SubTotal_Separator1;
        private TextBox SubTotal_Separator2;
        private TextBox Sub_Separator2;
        private TextBox Sub_Separator1;
        private TextBox Main_Separator2;
        private TextBox Main_Separator1;
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
                this._shipGdsPrimeListCndtn2 = (ShipGdsPrimeListCndtn2)this._printInfo.jyoken;
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
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //-------------------------------------------------------
            // 改頁設定
            // 0:拠点毎 1:しない
            //-------------------------------------------------------
            #region [改頁設定]
            switch (_shipGdsPrimeListCndtn2.NewPageDiv)
            {
                case ShipGdsPrimeListCndtn2.NewPageDivState.Section:
                    {
                        SectionHeader.NewPage = NewPage.Before;
                        break;
                    }
            }
            #endregion
        }

        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMHNB02153P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02153P_01A4C_ReportStart(object sender, EventArgs e)
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
            // 拠点コードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.SecHd_SectionCode.Text)
                || this.SecHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SecHd_SectionCode.Text = string.Empty;
                this.SecHd_SectionName.Text = string.Empty;
            }

            this._sameDetailFlg = true; // ADD 2009/02/17
        }

        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値の場合表示しない
            // 順位
            if (string.IsNullOrEmpty(this.Sub_DisplayOrder.Text)
                || Convert.ToInt32(this.Sub_DisplayOrder.Text) == 0)
            {
                this.Sub_DisplayOrder.Text = string.Empty;
            }

            // 仕入先
            if (string.IsNullOrEmpty(this.Sub_SuplierCode.Text)
                || this.Sub_SuplierCode.Text.PadLeft(6, '0') == "000000")
            {
                this.Sub_SuplierCode.Text = string.Empty;
            }

            // メーカー
            if (string.IsNullOrEmpty(this.Sub_MakerCode.Text)
                || this.Sub_MakerCode.Text.PadLeft(4, '0') == "0000")
            {
                this.Sub_MakerCode.Text = string.Empty;
            }

            #region 検索先情報表示制御
            // 検索先情報（帳票右側）の表示・非表示の制御
            if (this.SubInfoCount.Text == "0")
            {
                // 表示しない
                this.Sub_DisplayOrder.Visible = false;
                this.Sub_SuplierCode.Visible = false;
                this.Sub_MakerCode.Visible = false;
                this.Sub_GoodsNo.Visible = false;
                this.Sub_WarehouseShelfNo.Visible = false;
                this.Sub_St_SalesTimes.Visible = false;
                this.Sub_Separator1.Visible = false;
                this.Sub_Or_SalesTimes.Visible = false;
                this.Sub_Separator2.Visible = false;
                this.Sub_Sum_SalesTimes.Visible = false;

                // --- DEL 2009/01/08 -------------------------------->>>>>
                //this.SubTotal_St_SalesTimes.Visible = false;
                //this.SubTotal_Separator1.Visible = false;
                //this.SubTotal_Or_SalesTimes.Visible = false;
                //this.SubTotal_Separator2.Visible = false;
                //this.SubTotal_Sum_SalesTimes.Visible = false;
                // --- DEL 2009/01/08 --------------------------------<<<<<
            }
            else
            {
                // 表示する
                this.Sub_DisplayOrder.Visible = true;
                this.Sub_SuplierCode.Visible = true;
                this.Sub_MakerCode.Visible = true;
                this.Sub_GoodsNo.Visible = true;
                this.Sub_WarehouseShelfNo.Visible = true;
                this.Sub_St_SalesTimes.Visible = true;
                this.Sub_Separator1.Visible = true;
                this.Sub_Or_SalesTimes.Visible = true;
                this.Sub_Separator2.Visible = true;
                this.Sub_Sum_SalesTimes.Visible = true;

                // 計部の表示制御はAfterPrintで制御
            }
            #endregion

            // --- ADD 2009/02/17 -------------------------------->>>>>
            if (this._sameDetailFlg)
            {
                // 同明細１行目のみ表示する項目を表示にする
                // 検索元情報
                this.Main_GoodsNo.Visible = true;
                this.Main_WarehouseShelfNo.Visible = true;
                this.Main_St_SalesTimes.Visible = true;
                this.Main_Separator1.Visible = true;
                this.Main_Or_SalesTimes.Visible = true;
                this.Main_Separator2.Visible = true;
                this.Main_Sum_SalesTimes.Visible = true;

                // 計部
                this.SubTotal_St_SalesTimes.Visible = true;
                this.SubTotal_Separator1.Visible = true;
                this.SubTotal_Or_SalesTimes.Visible = true;
                this.SubTotal_Separator2.Visible = true;
                this.SubTotal_Sum_SalesTimes.Visible = true;
            }
            // --- ADD 2009/02/17 --------------------------------<<<<<
        }

        /// <summary>
        /// detail_AfterPrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            // 同明細１行目のみ表示する項目を非表示にする
            // 検索元情報
            this.Main_GoodsNo.Visible = false;
            this.Main_WarehouseShelfNo.Visible = false;
            this.Main_St_SalesTimes.Visible = false;
            this.Main_Separator1.Visible = false;
            this.Main_Or_SalesTimes.Visible = false;
            this.Main_Separator2.Visible = false;
            this.Main_Sum_SalesTimes.Visible = false;

            // 計部
            this.SubTotal_St_SalesTimes.Visible = false;
            this.SubTotal_Separator1.Visible = false;
            this.SubTotal_Or_SalesTimes.Visible = false;
            this.SubTotal_Separator2.Visible = false;
            this.SubTotal_Sum_SalesTimes.Visible = false;

            this._sameDetailFlg = false; // ADD 2009/02/17

            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// GroupHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupHeader_BeforePrint(object sender, EventArgs e)
        {
            // --- DEL 2009/02/17 -------------------------------->>>>>
            //// 同明細１行目のみ表示する項目を表示にする
            //// 検索元情報
            //this.Main_GoodsNo.Visible = true;
            //this.Main_WarehouseShelfNo.Visible = true;
            //this.Main_St_SalesTimes.Visible = true;
            //this.Main_Separator1.Visible = true;
            //this.Main_Or_SalesTimes.Visible = true;
            //this.Main_Separator2.Visible = true;
            //this.Main_Sum_SalesTimes.Visible = true;

            //// 計部
            //this.SubTotal_St_SalesTimes.Visible = true;
            //this.SubTotal_Separator1.Visible = true;
            //this.SubTotal_Or_SalesTimes.Visible = true;
            //this.SubTotal_Separator2.Visible = true;
            //this.SubTotal_Sum_SalesTimes.Visible = true;
            // --- DEL 2009/02/17 --------------------------------<<<<<
            this._sameDetailFlg = true; // ADD 2009/02/17

            // グループコードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.Main_BLGroupCode.Text)
                || this.Main_BLGroupCode.Text.PadLeft(5, '0') == "00000")
            {
                this.Main_BLGroupCode.Text = string.Empty;
            }
        }

        /// <summary>
        /// PageFooter_AfterPrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
            // --- DEL 2009/02/17 -------------------------------->>>>>
            //// 同明細１行目のみ表示する項目を表示にする
            //// 検索元情報
            //this.Main_GoodsNo.Visible = true;
            //this.Main_WarehouseShelfNo.Visible = true;
            //this.Main_St_SalesTimes.Visible = true;
            //this.Main_Separator1.Visible = true;
            //this.Main_Or_SalesTimes.Visible = true;
            //this.Main_Separator2.Visible = true;
            //this.Main_Sum_SalesTimes.Visible = true;

            //// 計部
            //this.SubTotal_St_SalesTimes.Visible = true;
            //this.SubTotal_Separator1.Visible = true;
            //this.SubTotal_Or_SalesTimes.Visible = true;
            //this.SubTotal_Separator2.Visible = true;
            //this.SubTotal_Sum_SalesTimes.Visible = true;
            // --- DEL 2009/02/17 --------------------------------<<<<<
        }

        // --- ADD 2009/02/17 -------------------------------->>>>>
        /// <summary>
        /// PMHNB02153P_01A4C_PageEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02153P_01A4C_PageEnd(object sender, EventArgs e)
        {
            this._sameDetailFlg = true;
        }
        // --- ADD 2009/02/17 --------------------------------<<<<<

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMHNB02153P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Main_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Main_WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.Main_St_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.Main_Or_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.Main_Sum_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.Sub_DisplayOrder = new DataDynamics.ActiveReports.TextBox();
            this.Sub_MakerCode = new DataDynamics.ActiveReports.TextBox();
            this.Sub_SuplierCode = new DataDynamics.ActiveReports.TextBox();
            this.Sub_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Sub_WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.Sub_St_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.Sub_Or_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.Sub_Sum_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.SubTotal_St_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.SubTotal_Or_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.SubTotal_Sum_SalesTimes = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.SubInfoCount = new DataDynamics.ActiveReports.TextBox();
            this.SubTotal_Separator1 = new DataDynamics.ActiveReports.TextBox();
            this.SubTotal_Separator2 = new DataDynamics.ActiveReports.TextBox();
            this.Sub_Separator2 = new DataDynamics.ActiveReports.TextBox();
            this.Sub_Separator1 = new DataDynamics.ActiveReports.TextBox();
            this.Main_Separator2 = new DataDynamics.ActiveReports.TextBox();
            this.Main_Separator1 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Main_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Main_GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.GroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_St_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Or_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Sum_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_DisplayOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_MakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_SuplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_St_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Or_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Sum_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_St_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Or_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Sum_SalesTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfoCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Separator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Separator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Separator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Separator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Separator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Separator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GoodsName)).BeginInit();
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
            this.tb_ReportTitle.Text = "出荷商品優良対応表";
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
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
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
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
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
            this.Main_GoodsNo,
            this.Main_WarehouseShelfNo,
            this.Main_St_SalesTimes,
            this.Main_Or_SalesTimes,
            this.Main_Sum_SalesTimes,
            this.Sub_DisplayOrder,
            this.Sub_MakerCode,
            this.Sub_SuplierCode,
            this.Sub_GoodsNo,
            this.Sub_WarehouseShelfNo,
            this.Sub_St_SalesTimes,
            this.Sub_Or_SalesTimes,
            this.Sub_Sum_SalesTimes,
            this.SubTotal_St_SalesTimes,
            this.SubTotal_Or_SalesTimes,
            this.SubTotal_Sum_SalesTimes,
            this.line5,
            this.line6,
            this.SubInfoCount,
            this.SubTotal_Separator1,
            this.SubTotal_Separator2,
            this.Sub_Separator2,
            this.Sub_Separator1,
            this.Main_Separator2,
            this.Main_Separator1});
            this.Detail.Height = 0.5F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // Main_GoodsNo
            // 
            this.Main_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Main_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Main_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsNo.DataField = "Main_GoodsNo";
            this.Main_GoodsNo.Height = 0.156F;
            this.Main_GoodsNo.Left = 0.0625F;
            this.Main_GoodsNo.MultiLine = false;
            this.Main_GoodsNo.Name = "Main_GoodsNo";
            this.Main_GoodsNo.OutputFormat = resources.GetString("Main_GoodsNo.OutputFormat");
            this.Main_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Main_GoodsNo.Text = "123456789012345678901234";
            this.Main_GoodsNo.Top = 0F;
            this.Main_GoodsNo.Width = 1.4F;
            // 
            // Main_WarehouseShelfNo
            // 
            this.Main_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Main_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Main_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_WarehouseShelfNo.DataField = "Main_WarehouseShelfNo";
            this.Main_WarehouseShelfNo.Height = 0.16F;
            this.Main_WarehouseShelfNo.Left = 1.4625F;
            this.Main_WarehouseShelfNo.MultiLine = false;
            this.Main_WarehouseShelfNo.Name = "Main_WarehouseShelfNo";
            this.Main_WarehouseShelfNo.OutputFormat = resources.GetString("Main_WarehouseShelfNo.OutputFormat");
            this.Main_WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.Main_WarehouseShelfNo.Text = "12345678";
            this.Main_WarehouseShelfNo.Top = 0F;
            this.Main_WarehouseShelfNo.Width = 0.48F;
            // 
            // Main_St_SalesTimes
            // 
            this.Main_St_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_St_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_St_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_St_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_St_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.Main_St_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_St_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.Main_St_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_St_SalesTimes.DataField = "Main_St_SalesTimes";
            this.Main_St_SalesTimes.Height = 0.156F;
            this.Main_St_SalesTimes.Left = 1.9425F;
            this.Main_St_SalesTimes.MultiLine = false;
            this.Main_St_SalesTimes.Name = "Main_St_SalesTimes";
            this.Main_St_SalesTimes.OutputFormat = resources.GetString("Main_St_SalesTimes.OutputFormat");
            this.Main_St_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Main_St_SalesTimes.Text = "12,345,678";
            this.Main_St_SalesTimes.Top = 0F;
            this.Main_St_SalesTimes.Width = 0.6F;
            // 
            // Main_Or_SalesTimes
            // 
            this.Main_Or_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_Or_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Or_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_Or_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Or_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.Main_Or_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Or_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.Main_Or_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Or_SalesTimes.DataField = "Main_Or_SalesTimes";
            this.Main_Or_SalesTimes.Height = 0.156F;
            this.Main_Or_SalesTimes.Left = 2.6425F;
            this.Main_Or_SalesTimes.MultiLine = false;
            this.Main_Or_SalesTimes.Name = "Main_Or_SalesTimes";
            this.Main_Or_SalesTimes.OutputFormat = resources.GetString("Main_Or_SalesTimes.OutputFormat");
            this.Main_Or_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Main_Or_SalesTimes.Text = "12,345,678";
            this.Main_Or_SalesTimes.Top = 0F;
            this.Main_Or_SalesTimes.Width = 0.6F;
            // 
            // Main_Sum_SalesTimes
            // 
            this.Main_Sum_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_Sum_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Sum_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_Sum_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Sum_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.Main_Sum_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Sum_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.Main_Sum_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Sum_SalesTimes.DataField = "Main_Sum_SalesTimes";
            this.Main_Sum_SalesTimes.Height = 0.156F;
            this.Main_Sum_SalesTimes.Left = 3.3425F;
            this.Main_Sum_SalesTimes.MultiLine = false;
            this.Main_Sum_SalesTimes.Name = "Main_Sum_SalesTimes";
            this.Main_Sum_SalesTimes.OutputFormat = resources.GetString("Main_Sum_SalesTimes.OutputFormat");
            this.Main_Sum_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Main_Sum_SalesTimes.Text = "12,345,678";
            this.Main_Sum_SalesTimes.Top = 0F;
            this.Main_Sum_SalesTimes.Width = 0.6F;
            // 
            // Sub_DisplayOrder
            // 
            this.Sub_DisplayOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_DisplayOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_DisplayOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_DisplayOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_DisplayOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_DisplayOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_DisplayOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_DisplayOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_DisplayOrder.DataField = "Sub_DisplayOrder";
            this.Sub_DisplayOrder.Height = 0.16F;
            this.Sub_DisplayOrder.Left = 4.0375F;
            this.Sub_DisplayOrder.MultiLine = false;
            this.Sub_DisplayOrder.Name = "Sub_DisplayOrder";
            this.Sub_DisplayOrder.OutputFormat = resources.GetString("Sub_DisplayOrder.OutputFormat");
            this.Sub_DisplayOrder.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.Sub_DisplayOrder.Text = "12";
            this.Sub_DisplayOrder.Top = 0F;
            this.Sub_DisplayOrder.Width = 0.15F;
            // 
            // Sub_MakerCode
            // 
            this.Sub_MakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_MakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_MakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_MakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_MakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_MakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_MakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_MakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_MakerCode.DataField = "Sub_MakerCode";
            this.Sub_MakerCode.Height = 0.16F;
            this.Sub_MakerCode.Left = 4.5675F;
            this.Sub_MakerCode.MultiLine = false;
            this.Sub_MakerCode.Name = "Sub_MakerCode";
            this.Sub_MakerCode.OutputFormat = resources.GetString("Sub_MakerCode.OutputFormat");
            this.Sub_MakerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Sub_MakerCode.Text = "1234";
            this.Sub_MakerCode.Top = 0F;
            this.Sub_MakerCode.Width = 0.26F;
            // 
            // Sub_SuplierCode
            // 
            this.Sub_SuplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_SuplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_SuplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_SuplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_SuplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_SuplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_SuplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_SuplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_SuplierCode.DataField = "Sub_SuplierCode";
            this.Sub_SuplierCode.Height = 0.16F;
            this.Sub_SuplierCode.Left = 4.1875F;
            this.Sub_SuplierCode.MultiLine = false;
            this.Sub_SuplierCode.Name = "Sub_SuplierCode";
            this.Sub_SuplierCode.OutputFormat = resources.GetString("Sub_SuplierCode.OutputFormat");
            this.Sub_SuplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Sub_SuplierCode.Text = "123456";
            this.Sub_SuplierCode.Top = 0F;
            this.Sub_SuplierCode.Width = 0.38F;
            // 
            // Sub_GoodsNo
            // 
            this.Sub_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_GoodsNo.DataField = "Sub_GoodsNo";
            this.Sub_GoodsNo.Height = 0.156F;
            this.Sub_GoodsNo.Left = 4.845F;
            this.Sub_GoodsNo.MultiLine = false;
            this.Sub_GoodsNo.Name = "Sub_GoodsNo";
            this.Sub_GoodsNo.OutputFormat = resources.GetString("Sub_GoodsNo.OutputFormat");
            this.Sub_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Sub_GoodsNo.Text = "123456789012345678901234";
            this.Sub_GoodsNo.Top = 0F;
            this.Sub_GoodsNo.Width = 1.4F;
            // 
            // Sub_WarehouseShelfNo
            // 
            this.Sub_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_WarehouseShelfNo.DataField = "Sub_WarehouseShelfNo";
            this.Sub_WarehouseShelfNo.Height = 0.16F;
            this.Sub_WarehouseShelfNo.Left = 6.245F;
            this.Sub_WarehouseShelfNo.MultiLine = false;
            this.Sub_WarehouseShelfNo.Name = "Sub_WarehouseShelfNo";
            this.Sub_WarehouseShelfNo.OutputFormat = resources.GetString("Sub_WarehouseShelfNo.OutputFormat");
            this.Sub_WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.Sub_WarehouseShelfNo.Text = "12345678";
            this.Sub_WarehouseShelfNo.Top = 0F;
            this.Sub_WarehouseShelfNo.Width = 0.48F;
            // 
            // Sub_St_SalesTimes
            // 
            this.Sub_St_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_St_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_St_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_St_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_St_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_St_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_St_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_St_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_St_SalesTimes.DataField = "Sub_St_SalesTimes";
            this.Sub_St_SalesTimes.Height = 0.156F;
            this.Sub_St_SalesTimes.Left = 6.725F;
            this.Sub_St_SalesTimes.MultiLine = false;
            this.Sub_St_SalesTimes.Name = "Sub_St_SalesTimes";
            this.Sub_St_SalesTimes.OutputFormat = resources.GetString("Sub_St_SalesTimes.OutputFormat");
            this.Sub_St_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sub_St_SalesTimes.Text = "12,345,678";
            this.Sub_St_SalesTimes.Top = 0F;
            this.Sub_St_SalesTimes.Width = 0.6F;
            // 
            // Sub_Or_SalesTimes
            // 
            this.Sub_Or_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_Or_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Or_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_Or_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Or_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_Or_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Or_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_Or_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Or_SalesTimes.DataField = "Sub_Or_SalesTimes";
            this.Sub_Or_SalesTimes.Height = 0.156F;
            this.Sub_Or_SalesTimes.Left = 7.425F;
            this.Sub_Or_SalesTimes.MultiLine = false;
            this.Sub_Or_SalesTimes.Name = "Sub_Or_SalesTimes";
            this.Sub_Or_SalesTimes.OutputFormat = resources.GetString("Sub_Or_SalesTimes.OutputFormat");
            this.Sub_Or_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sub_Or_SalesTimes.Text = "12,345,678";
            this.Sub_Or_SalesTimes.Top = 0F;
            this.Sub_Or_SalesTimes.Width = 0.6F;
            // 
            // Sub_Sum_SalesTimes
            // 
            this.Sub_Sum_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_Sum_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Sum_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_Sum_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Sum_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_Sum_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Sum_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_Sum_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Sum_SalesTimes.DataField = "Sub_Sum_SalesTimes";
            this.Sub_Sum_SalesTimes.Height = 0.156F;
            this.Sub_Sum_SalesTimes.Left = 8.125F;
            this.Sub_Sum_SalesTimes.MultiLine = false;
            this.Sub_Sum_SalesTimes.Name = "Sub_Sum_SalesTimes";
            this.Sub_Sum_SalesTimes.OutputFormat = resources.GetString("Sub_Sum_SalesTimes.OutputFormat");
            this.Sub_Sum_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sub_Sum_SalesTimes.Text = "12,345,678";
            this.Sub_Sum_SalesTimes.Top = 0F;
            this.Sub_Sum_SalesTimes.Width = 0.6F;
            // 
            // SubTotal_St_SalesTimes
            // 
            this.SubTotal_St_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_St_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_St_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_St_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_St_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_St_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_St_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_St_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_St_SalesTimes.DataField = "SubTotal_St_SalesTimes";
            this.SubTotal_St_SalesTimes.Height = 0.156F;
            this.SubTotal_St_SalesTimes.Left = 8.789998F;
            this.SubTotal_St_SalesTimes.MultiLine = false;
            this.SubTotal_St_SalesTimes.Name = "SubTotal_St_SalesTimes";
            this.SubTotal_St_SalesTimes.OutputFormat = resources.GetString("SubTotal_St_SalesTimes.OutputFormat");
            this.SubTotal_St_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SubTotal_St_SalesTimes.Text = "12,345,678";
            this.SubTotal_St_SalesTimes.Top = 0F;
            this.SubTotal_St_SalesTimes.Width = 0.6F;
            // 
            // SubTotal_Or_SalesTimes
            // 
            this.SubTotal_Or_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_Or_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Or_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_Or_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Or_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_Or_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Or_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_Or_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Or_SalesTimes.DataField = "SubTotal_Or_SalesTimes";
            this.SubTotal_Or_SalesTimes.Height = 0.156F;
            this.SubTotal_Or_SalesTimes.Left = 9.489999F;
            this.SubTotal_Or_SalesTimes.MultiLine = false;
            this.SubTotal_Or_SalesTimes.Name = "SubTotal_Or_SalesTimes";
            this.SubTotal_Or_SalesTimes.OutputFormat = resources.GetString("SubTotal_Or_SalesTimes.OutputFormat");
            this.SubTotal_Or_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SubTotal_Or_SalesTimes.Text = "12,345,678";
            this.SubTotal_Or_SalesTimes.Top = 0F;
            this.SubTotal_Or_SalesTimes.Width = 0.6F;
            // 
            // SubTotal_Sum_SalesTimes
            // 
            this.SubTotal_Sum_SalesTimes.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_Sum_SalesTimes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Sum_SalesTimes.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_Sum_SalesTimes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Sum_SalesTimes.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_Sum_SalesTimes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Sum_SalesTimes.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_Sum_SalesTimes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Sum_SalesTimes.DataField = "SubTotal_Sum_SalesTimes";
            this.SubTotal_Sum_SalesTimes.Height = 0.156F;
            this.SubTotal_Sum_SalesTimes.Left = 10.19F;
            this.SubTotal_Sum_SalesTimes.MultiLine = false;
            this.SubTotal_Sum_SalesTimes.Name = "SubTotal_Sum_SalesTimes";
            this.SubTotal_Sum_SalesTimes.OutputFormat = resources.GetString("SubTotal_Sum_SalesTimes.OutputFormat");
            this.SubTotal_Sum_SalesTimes.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SubTotal_Sum_SalesTimes.Text = "12,345,678";
            this.SubTotal_Sum_SalesTimes.Top = 0F;
            this.SubTotal_Sum_SalesTimes.Width = 0.6F;
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
            this.line5.Height = 0.1875F;
            this.line5.Left = 3.95F;
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 0F;
            this.line5.X1 = 3.95F;
            this.line5.X2 = 3.95F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0.1875F;
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
            this.line6.Height = 0.1875F;
            this.line6.Left = 8.75F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 0F;
            this.line6.X1 = 8.75F;
            this.line6.X2 = 8.75F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0.1875F;
            // 
            // SubInfoCount
            // 
            this.SubInfoCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SubInfoCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubInfoCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SubInfoCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubInfoCount.Border.RightColor = System.Drawing.Color.Black;
            this.SubInfoCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubInfoCount.Border.TopColor = System.Drawing.Color.Black;
            this.SubInfoCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubInfoCount.DataField = "SubInfoCount";
            this.SubInfoCount.Height = 0.156F;
            this.SubInfoCount.Left = 5.5625F;
            this.SubInfoCount.MultiLine = false;
            this.SubInfoCount.Name = "SubInfoCount";
            this.SubInfoCount.OutputFormat = resources.GetString("SubInfoCount.OutputFormat");
            this.SubInfoCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SubInfoCount.Text = "1234567";
            this.SubInfoCount.Top = 0.1875F;
            this.SubInfoCount.Visible = false;
            this.SubInfoCount.Width = 0.65F;
            // 
            // SubTotal_Separator1
            // 
            this.SubTotal_Separator1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_Separator1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_Separator1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator1.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_Separator1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator1.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_Separator1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator1.Height = 0.16F;
            this.SubTotal_Separator1.Left = 9.389998F;
            this.SubTotal_Separator1.MultiLine = false;
            this.SubTotal_Separator1.Name = "SubTotal_Separator1";
            this.SubTotal_Separator1.OutputFormat = resources.GetString("SubTotal_Separator1.OutputFormat");
            this.SubTotal_Separator1.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SubTotal_Separator1.Text = "/";
            this.SubTotal_Separator1.Top = 0F;
            this.SubTotal_Separator1.Width = 0.1F;
            // 
            // SubTotal_Separator2
            // 
            this.SubTotal_Separator2.Border.BottomColor = System.Drawing.Color.Black;
            this.SubTotal_Separator2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator2.Border.LeftColor = System.Drawing.Color.Black;
            this.SubTotal_Separator2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator2.Border.RightColor = System.Drawing.Color.Black;
            this.SubTotal_Separator2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator2.Border.TopColor = System.Drawing.Color.Black;
            this.SubTotal_Separator2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubTotal_Separator2.Height = 0.16F;
            this.SubTotal_Separator2.Left = 10.09F;
            this.SubTotal_Separator2.MultiLine = false;
            this.SubTotal_Separator2.Name = "SubTotal_Separator2";
            this.SubTotal_Separator2.OutputFormat = resources.GetString("SubTotal_Separator2.OutputFormat");
            this.SubTotal_Separator2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SubTotal_Separator2.Text = "/";
            this.SubTotal_Separator2.Top = 0F;
            this.SubTotal_Separator2.Width = 0.1F;
            // 
            // Sub_Separator2
            // 
            this.Sub_Separator2.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_Separator2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator2.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_Separator2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator2.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_Separator2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator2.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_Separator2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator2.Height = 0.16F;
            this.Sub_Separator2.Left = 8.025F;
            this.Sub_Separator2.MultiLine = false;
            this.Sub_Separator2.Name = "Sub_Separator2";
            this.Sub_Separator2.OutputFormat = resources.GetString("Sub_Separator2.OutputFormat");
            this.Sub_Separator2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Sub_Separator2.Text = "/";
            this.Sub_Separator2.Top = 0F;
            this.Sub_Separator2.Width = 0.1F;
            // 
            // Sub_Separator1
            // 
            this.Sub_Separator1.Border.BottomColor = System.Drawing.Color.Black;
            this.Sub_Separator1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator1.Border.LeftColor = System.Drawing.Color.Black;
            this.Sub_Separator1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator1.Border.RightColor = System.Drawing.Color.Black;
            this.Sub_Separator1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator1.Border.TopColor = System.Drawing.Color.Black;
            this.Sub_Separator1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sub_Separator1.Height = 0.16F;
            this.Sub_Separator1.Left = 7.325F;
            this.Sub_Separator1.MultiLine = false;
            this.Sub_Separator1.Name = "Sub_Separator1";
            this.Sub_Separator1.OutputFormat = resources.GetString("Sub_Separator1.OutputFormat");
            this.Sub_Separator1.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Sub_Separator1.Text = "/";
            this.Sub_Separator1.Top = 0F;
            this.Sub_Separator1.Width = 0.1F;
            // 
            // Main_Separator2
            // 
            this.Main_Separator2.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_Separator2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator2.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_Separator2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator2.Border.RightColor = System.Drawing.Color.Black;
            this.Main_Separator2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator2.Border.TopColor = System.Drawing.Color.Black;
            this.Main_Separator2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator2.Height = 0.16F;
            this.Main_Separator2.Left = 3.2425F;
            this.Main_Separator2.MultiLine = false;
            this.Main_Separator2.Name = "Main_Separator2";
            this.Main_Separator2.OutputFormat = resources.GetString("Main_Separator2.OutputFormat");
            this.Main_Separator2.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Main_Separator2.Text = "/";
            this.Main_Separator2.Top = 0F;
            this.Main_Separator2.Width = 0.1F;
            // 
            // Main_Separator1
            // 
            this.Main_Separator1.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_Separator1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator1.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_Separator1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator1.Border.RightColor = System.Drawing.Color.Black;
            this.Main_Separator1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator1.Border.TopColor = System.Drawing.Color.Black;
            this.Main_Separator1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_Separator1.Height = 0.16F;
            this.Main_Separator1.Left = 2.5425F;
            this.Main_Separator1.MultiLine = false;
            this.Main_Separator1.Name = "Main_Separator1";
            this.Main_Separator1.OutputFormat = resources.GetString("Main_Separator1.OutputFormat");
            this.Main_Separator1.Style = "ddo-char-set: 1; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Main_Separator1.Text = "/";
            this.Main_Separator1.Top = 0F;
            this.Main_Separator1.Width = 0.1F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2916667F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.PageFooter.AfterPrint += new System.EventHandler(this.PageFooter_AfterPrint);
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
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line2,
            this.Lb_SectionTitle,
            this.label4,
            this.label1,
            this.line3,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label14,
            this.label15,
            this.label16,
            this.label17,
            this.label18,
            this.label19,
            this.label20,
            this.label21});
            this.TitleHeader.Height = 0.7495F;
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
            // Lb_SectionTitle
            // 
            this.Lb_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Height = 0.156F;
            this.Lb_SectionTitle.HyperLink = "";
            this.Lb_SectionTitle.Left = 0.063F;
            this.Lb_SectionTitle.MultiLine = false;
            this.Lb_SectionTitle.Name = "Lb_SectionTitle";
            this.Lb_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SectionTitle.Text = "拠点";
            this.Lb_SectionTitle.Top = 0.01F;
            this.Lb_SectionTitle.Width = 0.4375F;
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
            this.label4.Left = 0.0625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "ｸﾞﾙｰﾌﾟ";
            this.label4.Top = 0.1875F;
            this.label4.Width = 0.4F;
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
            this.label1.Left = 0.0625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "品番";
            this.label1.Top = 0.375F;
            this.label1.Width = 0.4F;
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
            this.line3.Top = 0.56F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.56F;
            this.line3.Y2 = 0.56F;
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
            this.label5.Left = 0.4375F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "品名";
            this.label5.Top = 0.1875F;
            this.label5.Width = 0.4F;
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
            this.label6.Left = 1.4625F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "棚番";
            this.label6.Top = 0.375F;
            this.label6.Width = 0.3F;
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
            this.label7.Left = 2.2425F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "在庫";
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
            this.label8.Left = 2.9425F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "取寄";
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
            this.label9.Left = 3.6425F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "合計";
            this.label9.Top = 0.375F;
            this.label9.Width = 0.3F;
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
            this.label10.Left = 3.9375F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "順位";
            this.label10.Top = 0.375F;
            this.label10.Width = 0.3F;
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
            this.label11.Left = 4.1875F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "仕入先";
            this.label11.Top = 0.375F;
            this.label11.Width = 0.38F;
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
            this.label12.Left = 4.5675F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "ﾒｰｶｰ";
            this.label12.Top = 0.375F;
            this.label12.Width = 0.3F;
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
            this.label14.Left = 4.845F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "対応品番";
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
            this.label15.Left = 6.245F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "棚番";
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
            this.label16.Left = 7.025F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "在庫";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.3F;
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
            this.label17.Left = 7.725F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "取寄";
            this.label17.Top = 0.375F;
            this.label17.Width = 0.3F;
            // 
            // label18
            // 
            this.label18.Border.BottomColor = System.Drawing.Color.Black;
            this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.LeftColor = System.Drawing.Color.Black;
            this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.RightColor = System.Drawing.Color.Black;
            this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.TopColor = System.Drawing.Color.Black;
            this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Height = 0.156F;
            this.label18.HyperLink = "";
            this.label18.Left = 8.425F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "合計";
            this.label18.Top = 0.375F;
            this.label18.Width = 0.3F;
            // 
            // label19
            // 
            this.label19.Border.BottomColor = System.Drawing.Color.Black;
            this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.LeftColor = System.Drawing.Color.Black;
            this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.RightColor = System.Drawing.Color.Black;
            this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.TopColor = System.Drawing.Color.Black;
            this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Height = 0.156F;
            this.label19.HyperLink = "";
            this.label19.Left = 9.089998F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "在庫";
            this.label19.Top = 0.375F;
            this.label19.Width = 0.3F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Height = 0.156F;
            this.label20.HyperLink = "";
            this.label20.Left = 9.789999F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label20.Text = "取寄";
            this.label20.Top = 0.375F;
            this.label20.Width = 0.3F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Height = 0.156F;
            this.label21.HyperLink = "";
            this.label21.Left = 10.49F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label21.Text = "合計";
            this.label21.Top = 0.375F;
            this.label21.Width = 0.3F;
            // 
            // TitleFooter
            // 
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
            this.GrandTotalFooter.Height = 0F;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Visible = false;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_SectionCode,
            this.SecHd_SectionName,
            this.line7,
            this.line8});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.1770833F;
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
            this.SecHd_SectionCode.DataField = "AddUpSecCode";
            this.SecHd_SectionCode.Height = 0.16F;
            this.SecHd_SectionCode.Left = 0.063F;
            this.SecHd_SectionCode.MultiLine = false;
            this.SecHd_SectionCode.Name = "SecHd_SectionCode";
            this.SecHd_SectionCode.OutputFormat = resources.GetString("SecHd_SectionCode.OutputFormat");
            this.SecHd_SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SecHd_SectionCode.Text = "12";
            this.SecHd_SectionCode.Top = 0F;
            this.SecHd_SectionCode.Width = 0.2F;
            // 
            // SecHd_SectionName
            // 
            this.SecHd_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.DataField = "SectionGuideSnm";
            this.SecHd_SectionName.Height = 0.16F;
            this.SecHd_SectionName.Left = 0.313F;
            this.SecHd_SectionName.MultiLine = false;
            this.SecHd_SectionName.Name = "SecHd_SectionName";
            this.SecHd_SectionName.OutputFormat = resources.GetString("SecHd_SectionName.OutputFormat");
            this.SecHd_SectionName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SecHd_SectionName.Text = "あいうえおかきくけこ";
            this.SecHd_SectionName.Top = 0F;
            this.SecHd_SectionName.Width = 1.2F;
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
            this.line7.Height = 0.1875F;
            this.line7.Left = 3.95F;
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 0F;
            this.line7.X1 = 3.95F;
            this.line7.X2 = 3.95F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0.1875F;
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
            this.line8.Height = 0.1875F;
            this.line8.Left = 8.75F;
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0F;
            this.line8.Width = 0F;
            this.line8.X1 = 8.75F;
            this.line8.X2 = 8.75F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0.1875F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
            // 
            // GroupHeader
            // 
            this.GroupHeader.CanShrink = true;
            this.GroupHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Main_BLGroupCode,
            this.Main_GoodsName,
            this.line4,
            this.line9,
            this.line10});
            this.GroupHeader.DataField = "DetailUnitKey";
            this.GroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.GroupHeader.Height = 0.177F;
            this.GroupHeader.KeepTogether = true;
            this.GroupHeader.Name = "GroupHeader";
            this.GroupHeader.BeforePrint += new System.EventHandler(this.GroupHeader_BeforePrint);
            // 
            // Main_BLGroupCode
            // 
            this.Main_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Main_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Main_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_BLGroupCode.DataField = "Main_BLGroupCode";
            this.Main_BLGroupCode.Height = 0.16F;
            this.Main_BLGroupCode.Left = 0.0625F;
            this.Main_BLGroupCode.MultiLine = false;
            this.Main_BLGroupCode.Name = "Main_BLGroupCode";
            this.Main_BLGroupCode.OutputFormat = resources.GetString("Main_BLGroupCode.OutputFormat");
            this.Main_BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Main_BLGroupCode.Text = "12345";
            this.Main_BLGroupCode.Top = 0.000500001F;
            this.Main_BLGroupCode.Width = 0.32F;
            // 
            // Main_GoodsName
            // 
            this.Main_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Main_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Main_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Main_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Main_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Main_GoodsName.DataField = "Main_GoodsName";
            this.Main_GoodsName.Height = 0.156F;
            this.Main_GoodsName.Left = 0.4375F;
            this.Main_GoodsName.MultiLine = false;
            this.Main_GoodsName.Name = "Main_GoodsName";
            this.Main_GoodsName.OutputFormat = resources.GetString("Main_GoodsName.OutputFormat");
            this.Main_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Main_GoodsName.Text = "12345678901234567890";
            this.Main_GoodsName.Top = 0F;
            this.Main_GoodsName.Width = 1.15F;
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
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0.1875F;
            this.line9.Left = 3.95F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0F;
            this.line9.Width = 0F;
            this.line9.X1 = 3.95F;
            this.line9.X2 = 3.95F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0.1875F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0.1875F;
            this.line10.Left = 8.75F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 0F;
            this.line10.X1 = 8.75F;
            this.line10.X2 = 8.75F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0.1875F;
            // 
            // GroupFooter
            // 
            this.GroupFooter.Height = 0F;
            this.GroupFooter.Name = "GroupFooter";
            this.GroupFooter.Visible = false;
            // 
            // PMHNB02153P_01A4C
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
            this.Sections.Add(this.GroupHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter);
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
            this.PageEnd += new System.EventHandler(this.PMHNB02153P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMHNB02153P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_St_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Or_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Sum_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_DisplayOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_MakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_SuplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_St_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Or_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Sum_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_St_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Or_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Sum_SalesTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfoCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Separator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubTotal_Separator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Separator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Separator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Separator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_Separator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

    }
}
