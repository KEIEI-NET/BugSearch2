//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先電子元帳
// プログラム概要   : 得意先電子元帳 印刷フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2008/11/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/18  修正内容 : 不具合対応[13312]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野
// 作 成 日  2009/05/18  修正内容 : 不具合対応[13264]
//----------------------------------------------------------------------------//
// 管理番号  　　　　　　作成担当 : yangmj
// 作 成 日  2011/10/27  修正内容 : redmine#26291 原価印字の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : liusy
// 作 成 日  2012/08/08  修正内容 : Redmine#31530 得意先注番の項目名修正
//----------------------------------------------------------------------------//
// 管理番号  10900691-00 作成担当 : 孫東響
// 作 成 日  2013/02/20  修正内容 : 2013/03/13配信分の緊急対応
//                                  Redmine#34718 年式が和暦場合年しか印刷されない
//                                  ①年式、車台Noの位置を調整
//                                  ②年式のWidthを調整
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/25  修正内容 : SPK車台番号文字列対応に伴う車台番号(VINコード)による抽出を可能にする
//----------------------------------------------------------------------------//
// 管理番号  11570208-00    作成担当：陳艶丹
// 修正日    2020/04/13     修正内容：PMKOBETSU-2912 軽減税率の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Drawing;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{

    /// <summary>
    /// 得意先電子元帳印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 得意先電子元帳の印刷フォームクラスです。</br>
    /// <br>Programmer   : </br>
    /// <br>Date         : </br>
    /// <br>UpdateNote   :</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMKAU04005P_02A4C : DataDynamics.ActiveReports.ActiveReport3,
                                     IPrintActiveReportTypeList,
                                     IPrintActiveReportTypeCommon
    {
        #region ■定数、変数、構造体
        // 変数
        private int _printCount;					// 印刷件数用カウンタ
        private SFCMN06002C _printInfo;				// 印刷情報クラス
        bool _disposed = false;                     // Disposeチェック用フラグ

        // IPrintActiveReportTypeListインターフェイス用変数
        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private string _pageHeaderSubTitle;			// 帳票サブタイトル
        private string _pageHeaderSortOderTitle;	// ソート順
        private StringCollection _extraConditions;	// 抽出条件
        private StringCollection _pageFooters;
        private GroupHeader DetailTitleHeader;
        private Label lb_AddUpADate;
        private Label lb_SalesSlipNum;
        private GroupFooter groupFooter1;
        private Label lb_SalesSlipCdName;
        private Label lb_SalesEmployeeNm;
        private Label lb_FrontEmployeeNm;
        private Label lb_SalesInputName;
        private Label lb_CategoryNo;
        private Label lb_ModelFullName;
        private Label lb_FullModel;
        private Label lb_CustSlipNo;
        private Label lb_CarMngCode;
        private Label lb_FirstEntryDate;
        private Label lb_SearchFrameNo;
        private Label lb_GoodsNo;
        private TextBox GoodsNo;
        private GroupHeader DetailHeader;
        private GroupFooter groupFooter2;
        private TextBox GoodsName;
        private Label lb_GoodsName;
        private TextBox ListPriceTaxExcFl;
        private TextBox ShipmentCnt;
        private Label lb_ListPriceTaxExcFl;
        private Label lb_ShipmentCnt;
        private Label lb_SalesUnitCost;
        private TextBox SalesUnitCost;
        private TextBox SalesUnPrcTaxExcFl;
        private TextBox SalesMoneyTaxExc;
        private Label lb_SalesUnPrcTaxExcFl;
        private TextBox ConsumeTax;
        private Label lb_SalesMoneyTaxExc;
        private Label lb_ConsumeTax;
        private Label lb_SlipNote;
        private Label lb_SectionCd;
        private TextBox SectionCd;
        private TextBox SectionName;
        private Line line2;
        private Label lb_Date;
        private TextBox StartDt;
        private Label lb_DateTo;
        private TextBox EndDt;
        private GroupHeader DetailHeader2;
        private TextBox SalesDate;
        private TextBox SalesSlipNum;
        private TextBox SalesSlipCdName;
        private TextBox SalesEmployeeNm;
        private TextBox FrontEmployeeNm;
        private TextBox SalesInputName;
        private TextBox CategoryNo;
        private TextBox ModelFullName;
        private TextBox FullModel;
        private TextBox CustSlipNo;
        private TextBox CarMngCode;
        private TextBox FirstEntryDate;
        private TextBox FrameNo;
        private GroupFooter groupFooter3;
        private GroupHeader DetailTitleHeader2;
        private GroupFooter groupFooter4;
        private Label lb_Section2;
        private TextBox SectionCd2;
        private TextBox SectionName2;
        private Label lb_CustomerCd;
        private TextBox CustomerCd2;
        private TextBox CustomerName2;
        private Line line3;
        private Line line5;		// フッターメッセージ
        private Label label1;
        private TextBox ConsTaxRate;
        private int _pageFooterOutCode;             // フッター出力区分
        #endregion

        #region プロパティ

        #region IPrintActiveReportTypeListインターフェイス用プロパティ

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ] </summary>
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }
        /// <summary> 帳票サブタイトル </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderSubTitle = value; }
        }
        /// <summary> ページヘッダソート順タイトル項目 </summary>
        public string PageHeaderSortOderTitle
        {
            set { this._pageHeaderSortOderTitle = value; }
        }
        /// <summary> 抽出条件ヘッダー項目 </summary>
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }
        /// <summary> フッター出力区分 </summary>
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }
        /// <summary> フッタ出力文 </summary>
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }
        /// <summary> 印刷情報 </summary>
        public SFCMN06002C PrintInfo
        {
            set { this._printInfo = value; }
        }
        /// <summary> その他データ </summary>
        public ArrayList OtherDataList
        {
            set { }
        }
        #endregion IPrintActiveReportTypeListインターフェイス用プロパティ

        #region IPrintActiveReportTypeCommonインターフェイス用プロパティ

        /// <summary> 背景透過設定値プロパティ </summary>
        public int WatermarkMode
        {
            get { return 0; }
            set { }
        }

        #endregion // IPrintActiveReportTypeCommonインターフェイス用プロパティ

        #region 印刷件数カウントアップイベント

        /// <summary> 印刷件数カウントアップイベント </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        #endregion // 印刷件数カウントアップイベント

        #endregion // プロパティ

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKAU04005P_02A4C()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region オーバーライド

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!this._disposed)
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

                    this._disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion オーバーライド

        #region イベント

        #region 処理開始時(PMKAU04005P_01A4C_ReportStart)

        /// <summary>
        /// 処理開始時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: </br>
        /// <br>Date		: </br>
        /// </remarks>
        private void PMKAU04005P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        #endregion // 処理開始時(PMKAU04005P_01A4C_ReportStart)

        #region ページ処理終了時(PMKAU04005P_01A4C_PageEnd)

        /// <summary>
        /// ページ処理終了時
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ページ終了時のイベントです。</br>
        /// <br>Programmer	: </br>
        /// <br>Date		: </br>
        /// </remarks>
        private void PMKAU04005P_01A4C_PageEnd(object sender, EventArgs e)
        {
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
        }

        #endregion // ページ処理終了時(PMKAU04005P_01A4C_PageEnd)

        #region ヘッダーデータ連結後、描画前(PageHeader_Format)

        /// <summary>
        /// ヘッダーデータ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer	: </br>
        /// <br>Date		: </br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            this.tb_PrintDate.Text = DateTime.Now.ToString("yyyy/MM/dd");       // 作成日付
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");            // 作成時間
        }

        #endregion // ヘッダーデータ連結後、描画前(PageHeader_Format)

        #region 明細描画直前(Detail_BeforePrint)

        /// <summary>
        /// 明細描画直前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される直前に発生する。</br>
        /// <br>Programmer	: </br>
        /// <br>Date		: </br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
        {
            // グループサプレスの判断
            this.CheckGroupSuppression();

            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }

        #endregion // 明細描画直前(Detail_BeforePrint)

        #region 明細描画後(Detail_AfterPrint)

        /// <summary>
        /// 明細描画後
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : </br>
        /// <br>Date		: </br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // 印刷件数カウントアップ
            this._printCount++;
#if DEBUG
            return;
#endif
            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }

        }

        #endregion // 明細描画後(Detail_AfterPrint)

        #region フッターデータ連結後、描画前(PageFooter_Format)

        /// <summary>
        /// フッターデータ連結後、描画前
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後、描画前に発生します。</br>
        /// <br>Programmer	: </br>
        /// <br>Date		: </br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
        {
            if (this._pageFooters == null)
            {
                return;
            }

            // フッター出力
            if ( this._pageFooterOutCode == 0 ) {
                if (_rptPageFooter == null)
                {
                    // インスタンスが作成されていなければ作成
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else {
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
        #endregion // フッターデータ連結後、描画前(PageFooter_Format)

        #endregion // イベント

        #region プライベートメソッド

        #region レポート要素出力設定(SetOfReportMembersOutput)

        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        private void SetOfReportMembersOutput ()
        {
            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            PrintCndtn printCondition = this._printInfo.jyoken as PrintCndtn;

            // レイアウト変更
            switch (printCondition.LayoutType)
            {

                #region レイアウト３
                // 拠点 あり, 得意先 なし
                case 3:
                    {
                        this.SectionCd.OutputFormat = "00";
                        this.SectionCd.Text = printCondition.SectionCd;
                        this.SectionName.Text = printCondition.SectionName;
                        //this.StartDt.Text = printCondition.StartDt.ToString("yyyy年MM月dd日"); // DEL 2009/05/18
                        //this.EndDt.Text = printCondition.EndDt.ToString("yyyy年MM月dd日"); // DEL 2009/05/18

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
                        // 拠点固定になるので明細部の拠点は非印字にする
                        DetailHeader.Visible = false;
                        DetailTitleHeader2.Visible = false;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD

                        break;
                    }
                #endregion // レイアウト３

                #region レイアウト６
                // 拠点 なし, 得意先 なし
                case 6:
                    {
                        // 拠点非表示
                        this.lb_SectionCd.Visible = false;
                        this.SectionCd.Visible = false;
                        this.SectionName.Visible = false;

                        // 日付の位置をずらす
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 DEL
                        //this.lb_Date.Location = this.lb_SectionCd.Location;
                        //this.StartDt.Location = this.SectionCd.Location;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
                        float adjustX = this.lb_Date.Location.X;
                        this.lb_Date.Location = new PointF( lb_Date.Location.X - adjustX, lb_Date.Location.Y );
                        this.StartDt.Location = new PointF( StartDt.Location.X - adjustX, StartDt.Location.Y );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD
                        PointF p = new PointF(this.StartDt.Location.X + this.StartDt.Width, this.StartDt.Location.Y);
                        this.lb_DateTo.Location = p;
                        p.X = lb_DateTo.Location.X + lb_DateTo.Width;
                        p.Y = lb_DateTo.Location.Y;
                        this.EndDt.Location = p;

                        //this.StartDt.Text = printCondition.StartDt.ToString("yyyy年MM月dd日"); // DEL 2009/05/18
                        //this.EndDt.Text = printCondition.EndDt.ToString("yyyy年MM月dd日"); // DEL 2009/05/18
                        break;
                    }
                #endregion // レイアウト６

                default: break;

            }

            // --- ADD 2009/05/18 -------------------------------->>>>>
            if (printCondition.StartDt != DateTime.MinValue || printCondition.EndDt != DateTime.MinValue)
            {
                string startDtStr = "最初から";
                string endDtStr = "最後まで";

                if (printCondition.StartDt != DateTime.MinValue)
                {
                    startDtStr = printCondition.StartDt.ToString("yyyy年MM月dd日");
                }

                if (printCondition.EndDt != DateTime.MinValue)
                {
                    endDtStr = printCondition.EndDt.ToString("yyyy年MM月dd日");
                }

                this.StartDt.Text = startDtStr;
                this.EndDt.Text = endDtStr;
            }
            else
            {
                // 日付を表示しない
                this.lb_Date.Text = string.Empty;
                this.lb_DateTo.Text = string.Empty;
                this.StartDt.Text = string.Empty;
                this.EndDt.Text = string.Empty;
            }
            // --- ADD 2009/05/18 --------------------------------<<<<<

            //this.SectionCd.OutputFormat = "00";
            //this.SectionCd.Text = printCondition.SectionCd;
            //this.SectionName.Text = printCondition.SectionName;
            //this.CustomerCd.OutputFormat = "00000000";
            //this.CustomerCd.Text = printCondition.CustomerCd;
            //this.CustomerName.Text = printCondition.CustomerName;
            //this.StartDt.Text = printCondition.StartDt.ToString("yyyy年MM月dd日");
            //this.EndDt.Text = printCondition.EndDt.ToString("yyyy年MM月dd日");
            //this.TotalDay.Text = printCondition.TotalDt.ToString("dd");
            //this.LastTimeDemand.Value = (object)printCondition.LastTimeDemand;
            //this.ThisTimeDmdNrml.Value = (object)printCondition.ThisTimeDmdNrml;
            //this.ForwardedAmount.Value = (object)printCondition.ForwardedAmount;
            //this.ThisSalesPriceTotal.Value = (object)printCondition.ThisSalesPriceTotal;
            //this.OfsThisSalesTax.Value = (object)printCondition.OfsThisSalesTax;
            //this.TotalAmount.Value = (object)printCondition.TotalAmount;
            //this.AfCalBlc.Value = (object)printCondition.AfCalBlc;
            //this.SlipCount.Value = (object)printCondition.SlipCount;
            
            // 改ページ
            //this.SectionHeader.NewPage = NewPage.Before;
            //this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;

            //this.BalanceChartHeader.NewPage = NewPage.Before;
            //this.BalanceChartHeader.RepeatStyle = RepeatStyle.OnPage;

            //// ゼロ埋め
            //this.SectionCd.OutputFormat = "000000";         // 発注先コード
            //this.TotalDay.OutputFormat = "000000000";    // 発注番号
            //this.SalesSlipCdName.OutputFormat = "0000";            // メーカーコード

            //-----ADD 2011/10/27----->>>>>
            if (printCondition.GenKaDispDiv == 1)
            {
                this.lb_SalesUnitCost.Visible = false;
                this.SalesUnitCost.Visible = false;
            }
            else
            {
                this.lb_SalesUnitCost.Visible = true;
                this.SalesUnitCost.Visible = true;
            }
            //-----ADD 2011/10/27-----<<<<<

            // 件数初期化
            this._printCount = 0;
        }
        #endregion // レポート要素出力設定(SetOfReportMembersOutput)

        #region グループサプレス判断(CheckGroupSuppression)

        /// <summary>
        /// グループサプレス判断
        /// </summary>
        /// <remarks>
        /// <br>Note		: グループサプレス処理の判定を行う。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/08/13</br>
        /// </remarks>
        private void CheckGroupSuppression()
        {
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
        }

        #endregion // グループサプレス判断(CheckGroupSuppression)

        #endregion // プライベートメソッド

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;

        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private TextBox SlipNote;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private SubReport Footer_SubReport;

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKAU04005P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SlipNote = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.ListPriceTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.ConsumeTax = new DataDynamics.ActiveReports.TextBox();
            this.ConsTaxRate = new DataDynamics.ActiveReports.TextBox();
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
            this.lb_SectionCd = new DataDynamics.ActiveReports.Label();
            this.SectionCd = new DataDynamics.ActiveReports.TextBox();
            this.SectionName = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.lb_Date = new DataDynamics.ActiveReports.Label();
            this.StartDt = new DataDynamics.ActiveReports.TextBox();
            this.lb_DateTo = new DataDynamics.ActiveReports.Label();
            this.EndDt = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.DetailTitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.lb_AddUpADate = new DataDynamics.ActiveReports.Label();
            this.lb_SalesSlipNum = new DataDynamics.ActiveReports.Label();
            this.lb_SalesSlipCdName = new DataDynamics.ActiveReports.Label();
            this.lb_SalesEmployeeNm = new DataDynamics.ActiveReports.Label();
            this.lb_FrontEmployeeNm = new DataDynamics.ActiveReports.Label();
            this.lb_SalesInputName = new DataDynamics.ActiveReports.Label();
            this.lb_CategoryNo = new DataDynamics.ActiveReports.Label();
            this.lb_ModelFullName = new DataDynamics.ActiveReports.Label();
            this.lb_FullModel = new DataDynamics.ActiveReports.Label();
            this.lb_CustSlipNo = new DataDynamics.ActiveReports.Label();
            this.lb_CarMngCode = new DataDynamics.ActiveReports.Label();
            this.lb_FirstEntryDate = new DataDynamics.ActiveReports.Label();
            this.lb_SearchFrameNo = new DataDynamics.ActiveReports.Label();
            this.lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.lb_ListPriceTaxExcFl = new DataDynamics.ActiveReports.Label();
            this.lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.lb_SalesUnitCost = new DataDynamics.ActiveReports.Label();
            this.lb_SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.Label();
            this.lb_SalesMoneyTaxExc = new DataDynamics.ActiveReports.Label();
            this.lb_ConsumeTax = new DataDynamics.ActiveReports.Label();
            this.lb_SlipNote = new DataDynamics.ActiveReports.Label();
            this.lb_CustomerCd = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.DetailHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionCd2 = new DataDynamics.ActiveReports.TextBox();
            this.SectionName2 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.DetailHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.SalesDate = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipCdName = new DataDynamics.ActiveReports.TextBox();
            this.SalesEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.FrontEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SalesInputName = new DataDynamics.ActiveReports.TextBox();
            this.CategoryNo = new DataDynamics.ActiveReports.TextBox();
            this.ModelFullName = new DataDynamics.ActiveReports.TextBox();
            this.FullModel = new DataDynamics.ActiveReports.TextBox();
            this.CustSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.CarMngCode = new DataDynamics.ActiveReports.TextBox();
            this.FirstEntryDate = new DataDynamics.ActiveReports.TextBox();
            this.FrameNo = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCd2 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName2 = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.groupFooter3 = new DataDynamics.ActiveReports.GroupFooter();
            this.DetailTitleHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.lb_Section2 = new DataDynamics.ActiveReports.Label();
            this.groupFooter4 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumeTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SectionCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_DateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_AddUpADate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesSlipCdName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_FrontEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesInputName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CategoryNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ModelFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_FullModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CustSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CarMngCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_FirstEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SearchFrameNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ListPriceTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ConsumeTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SlipNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CustomerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCdName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInputName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarMngCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Section2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SlipNote,
            this.GoodsNo,
            this.GoodsName,
            this.ListPriceTaxExcFl,
            this.ShipmentCnt,
            this.SalesUnitCost,
            this.SalesUnPrcTaxExcFl,
            this.SalesMoneyTaxExc,
            this.ConsumeTax,
            this.ConsTaxRate});
            this.Detail.Height = 0.125F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // SlipNote
            // 
            this.SlipNote.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNote.DataField = "SlipNote";
            this.SlipNote.Height = 0.125F;
            this.SlipNote.Left = 8.5F;
            this.SlipNote.MultiLine = false;
            this.SlipNote.Name = "SlipNote";
            this.SlipNote.OutputFormat = resources.GetString("SlipNote.OutputFormat");
            this.SlipNote.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SlipNote.Text = "1234567890123456789012345678901234567890";
            this.SlipNote.Top = 0F;
            this.SlipNote.Width = 2.3125F;
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
            this.GoodsNo.Left = 1.6875F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "XXXXXXXXXXXXXXXXXX";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.0625F;
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
            this.GoodsName.Left = 2.8125F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.1875F;
            // 
            // ListPriceTaxExcFl
            // 
            this.ListPriceTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.DataField = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.Height = 0.125F;
            this.ListPriceTaxExcFl.Left = 4.0625F;
            this.ListPriceTaxExcFl.MultiLine = false;
            this.ListPriceTaxExcFl.Name = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.OutputFormat = resources.GetString("ListPriceTaxExcFl.OutputFormat");
            this.ListPriceTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ListPriceTaxExcFl.Text = "99,999,999";
            this.ListPriceTaxExcFl.Top = 0F;
            this.ListPriceTaxExcFl.Width = 0.625F;
            // 
            // ShipmentCnt
            // 
            this.ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.DataField = "ShipmentCnt";
            this.ShipmentCnt.Height = 0.125F;
            this.ShipmentCnt.Left = 4.75F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt.Text = "99,999,999";
            this.ShipmentCnt.Top = 0F;
            this.ShipmentCnt.Width = 0.625F;
            // 
            // SalesUnitCost
            // 
            this.SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.DataField = "SalesUnitCost";
            this.SalesUnitCost.Height = 0.125F;
            this.SalesUnitCost.Left = 5.4375F;
            this.SalesUnitCost.MultiLine = false;
            this.SalesUnitCost.Name = "SalesUnitCost";
            this.SalesUnitCost.OutputFormat = resources.GetString("SalesUnitCost.OutputFormat");
            this.SalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesUnitCost.Text = "99,999,999";
            this.SalesUnitCost.Top = 0F;
            this.SalesUnitCost.Width = 0.625F;
            // 
            // SalesUnPrcTaxExcFl
            // 
            this.SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.DataField = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.Height = 0.125F;
            this.SalesUnPrcTaxExcFl.Left = 6.125F;
            this.SalesUnPrcTaxExcFl.MultiLine = false;
            this.SalesUnPrcTaxExcFl.Name = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.OutputFormat = resources.GetString("SalesUnPrcTaxExcFl.OutputFormat");
            this.SalesUnPrcTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesUnPrcTaxExcFl.Text = "99,999,999";
            this.SalesUnPrcTaxExcFl.Top = 0F;
            this.SalesUnPrcTaxExcFl.Width = 0.625F;
            // 
            // SalesMoneyTaxExc
            // 
            this.SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.Height = 0.125F;
            this.SalesMoneyTaxExc.Left = 6.8125F;
            this.SalesMoneyTaxExc.MultiLine = false;
            this.SalesMoneyTaxExc.Name = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.OutputFormat = resources.GetString("SalesMoneyTaxExc.OutputFormat");
            this.SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyTaxExc.Text = "99,999,999";
            this.SalesMoneyTaxExc.Top = 0F;
            this.SalesMoneyTaxExc.Width = 0.625F;
            // 
            // ConsumeTax
            // 
            this.ConsumeTax.Border.BottomColor = System.Drawing.Color.Black;
            this.ConsumeTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsumeTax.Border.LeftColor = System.Drawing.Color.Black;
            this.ConsumeTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsumeTax.Border.RightColor = System.Drawing.Color.Black;
            this.ConsumeTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsumeTax.Border.TopColor = System.Drawing.Color.Black;
            this.ConsumeTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsumeTax.DataField = "ConsumeTax";
            this.ConsumeTax.Height = 0.125F;
            this.ConsumeTax.Left = 7.5F;
            this.ConsumeTax.MultiLine = false;
            this.ConsumeTax.Name = "ConsumeTax";
            this.ConsumeTax.OutputFormat = resources.GetString("ConsumeTax.OutputFormat");
            this.ConsumeTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ConsumeTax.Text = "99,999,999";
            this.ConsumeTax.Top = 0F;
            this.ConsumeTax.Width = 0.625F;
            // 
            // ConsTaxRate
            // 
            this.ConsTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.ConsTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.ConsTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.ConsTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.ConsTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTaxRate.DataField = "ConsTaxRate";
            this.ConsTaxRate.Height = 0.125F;
            this.ConsTaxRate.Left = 8.125F;
            this.ConsTaxRate.MultiLine = false;
            this.ConsTaxRate.Name = "ConsTaxRate";
            this.ConsTaxRate.OutputFormat = resources.GetString("ConsTaxRate.OutputFormat");
            this.ConsTaxRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ConsTaxRate.Text = "100%";
            this.ConsTaxRate.Top = 0F;
            this.ConsTaxRate.Width = 0.32F;
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
            this.PageHeader.Height = 0.28125F;
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
            this.Label3.Left = 8.2875F;
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
            this.tb_PrintDate.Height = 0.1875F;
            this.tb_PrintDate.Left = 8.85F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "2008/01/01";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.625F;
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
            this.Label2.Left = 10.0375F;
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
            this.tb_PrintPage.Left = 10.5375F;
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
            this.Line1.Top = 0.25F;
            this.Line1.Width = 10.9125F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.9125F;
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
            this.tb_PrintTime.Left = 9.475F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "01:01";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.375F;
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
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "得意先電子元帳";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.90625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2291667F;
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
            this.Footer_SubReport.Width = 10.9F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lb_SectionCd,
            this.SectionCd,
            this.SectionName,
            this.line2,
            this.lb_Date,
            this.StartDt,
            this.lb_DateTo,
            this.EndDt});
            this.ExtraHeader.Height = 0.1493056F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // lb_SectionCd
            // 
            this.lb_SectionCd.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SectionCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SectionCd.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SectionCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SectionCd.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SectionCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SectionCd.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SectionCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SectionCd.Height = 0.125F;
            this.lb_SectionCd.HyperLink = "";
            this.lb_SectionCd.Left = 0F;
            this.lb_SectionCd.MultiLine = false;
            this.lb_SectionCd.Name = "lb_SectionCd";
            this.lb_SectionCd.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SectionCd.Text = "拠点";
            this.lb_SectionCd.Top = 0F;
            this.lb_SectionCd.Width = 0.4375F;
            // 
            // SectionCd
            // 
            this.SectionCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd.DataField = "SectionCd";
            this.SectionCd.Height = 0.125F;
            this.SectionCd.Left = 0.5F;
            this.SectionCd.MultiLine = false;
            this.SectionCd.Name = "SectionCd";
            this.SectionCd.OutputFormat = resources.GetString("SectionCd.OutputFormat");
            this.SectionCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SectionCd.Text = "99";
            this.SectionCd.Top = 0F;
            this.SectionCd.Width = 0.1458333F;
            // 
            // SectionName
            // 
            this.SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.DataField = "SectionName";
            this.SectionName.Height = 0.125F;
            this.SectionName.Left = 0.6666667F;
            this.SectionName.MultiLine = false;
            this.SectionName.Name = "SectionName";
            this.SectionName.OutputFormat = resources.GetString("SectionName.OutputFormat");
            this.SectionName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionName.Text = "12345678901234567890";
            this.SectionName.Top = 0F;
            this.SectionName.Width = 1.25F;
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
            this.line2.Top = 0.1354167F;
            this.line2.Width = 10.85F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.85F;
            this.line2.Y1 = 0.1354167F;
            this.line2.Y2 = 0.1354167F;
            // 
            // lb_Date
            // 
            this.lb_Date.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_Date.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Date.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_Date.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Date.Border.RightColor = System.Drawing.Color.Black;
            this.lb_Date.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Date.Border.TopColor = System.Drawing.Color.Black;
            this.lb_Date.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Date.Height = 0.125F;
            this.lb_Date.HyperLink = "";
            this.lb_Date.Left = 2.375F;
            this.lb_Date.MultiLine = false;
            this.lb_Date.Name = "lb_Date";
            this.lb_Date.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_Date.Text = "日付";
            this.lb_Date.Top = 0F;
            this.lb_Date.Width = 0.4375F;
            // 
            // StartDt
            // 
            this.StartDt.Border.BottomColor = System.Drawing.Color.Black;
            this.StartDt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartDt.Border.LeftColor = System.Drawing.Color.Black;
            this.StartDt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartDt.Border.RightColor = System.Drawing.Color.Black;
            this.StartDt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartDt.Border.TopColor = System.Drawing.Color.Black;
            this.StartDt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartDt.Height = 0.125F;
            this.StartDt.Left = 2.875F;
            this.StartDt.MultiLine = false;
            this.StartDt.Name = "StartDt";
            this.StartDt.OutputFormat = resources.GetString("StartDt.OutputFormat");
            this.StartDt.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.StartDt.Text = "9999年99月99日";
            this.StartDt.Top = 0F;
            this.StartDt.Width = 0.8125F;
            // 
            // lb_DateTo
            // 
            this.lb_DateTo.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_DateTo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_DateTo.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_DateTo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_DateTo.Border.RightColor = System.Drawing.Color.Black;
            this.lb_DateTo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_DateTo.Border.TopColor = System.Drawing.Color.Black;
            this.lb_DateTo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_DateTo.Height = 0.125F;
            this.lb_DateTo.HyperLink = "";
            this.lb_DateTo.Left = 3.6875F;
            this.lb_DateTo.MultiLine = false;
            this.lb_DateTo.Name = "lb_DateTo";
            this.lb_DateTo.Style = "ddo-char-set: 128; text-align: center; font-weight: normal; font-size: 8pt; font-" +
                "family: ＭＳ 明朝; vertical-align: top; ";
            this.lb_DateTo.Text = "～";
            this.lb_DateTo.Top = 0F;
            this.lb_DateTo.Width = 0.1875F;
            // 
            // EndDt
            // 
            this.EndDt.Border.BottomColor = System.Drawing.Color.Black;
            this.EndDt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EndDt.Border.LeftColor = System.Drawing.Color.Black;
            this.EndDt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EndDt.Border.RightColor = System.Drawing.Color.Black;
            this.EndDt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EndDt.Border.TopColor = System.Drawing.Color.Black;
            this.EndDt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EndDt.Height = 0.125F;
            this.EndDt.Left = 3.875F;
            this.EndDt.MultiLine = false;
            this.EndDt.Name = "EndDt";
            this.EndDt.OutputFormat = resources.GetString("EndDt.OutputFormat");
            this.EndDt.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.EndDt.Text = "9999年99月99日";
            this.EndDt.Top = 0F;
            this.EndDt.Width = 0.8125F;
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
            this.TitleHeader.Height = 0F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
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
            this.GrandTotalFooter.Height = 0F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // DetailTitleHeader
            // 
            this.DetailTitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lb_AddUpADate,
            this.lb_SalesSlipNum,
            this.lb_SalesSlipCdName,
            this.lb_SalesEmployeeNm,
            this.lb_FrontEmployeeNm,
            this.lb_SalesInputName,
            this.lb_CategoryNo,
            this.lb_ModelFullName,
            this.lb_FullModel,
            this.lb_CustSlipNo,
            this.lb_CarMngCode,
            this.lb_FirstEntryDate,
            this.lb_SearchFrameNo,
            this.lb_GoodsNo,
            this.lb_GoodsName,
            this.lb_ListPriceTaxExcFl,
            this.lb_ShipmentCnt,
            this.lb_SalesUnitCost,
            this.lb_SalesUnPrcTaxExcFl,
            this.lb_SalesMoneyTaxExc,
            this.lb_ConsumeTax,
            this.lb_SlipNote,
            this.lb_CustomerCd,
            this.label1});
            this.DetailTitleHeader.Height = 0.375F;
            this.DetailTitleHeader.Name = "DetailTitleHeader";
            this.DetailTitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // lb_AddUpADate
            // 
            this.lb_AddUpADate.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_AddUpADate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AddUpADate.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_AddUpADate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AddUpADate.Border.RightColor = System.Drawing.Color.Black;
            this.lb_AddUpADate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AddUpADate.Border.TopColor = System.Drawing.Color.Black;
            this.lb_AddUpADate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_AddUpADate.Height = 0.125F;
            this.lb_AddUpADate.HyperLink = "";
            this.lb_AddUpADate.Left = 0F;
            this.lb_AddUpADate.MultiLine = false;
            this.lb_AddUpADate.Name = "lb_AddUpADate";
            this.lb_AddUpADate.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_AddUpADate.Text = "日付";
            this.lb_AddUpADate.Top = 0F;
            this.lb_AddUpADate.Width = 0.625F;
            // 
            // lb_SalesSlipNum
            // 
            this.lb_SalesSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipNum.Height = 0.125F;
            this.lb_SalesSlipNum.HyperLink = "";
            this.lb_SalesSlipNum.Left = 0.6875F;
            this.lb_SalesSlipNum.MultiLine = false;
            this.lb_SalesSlipNum.Name = "lb_SalesSlipNum";
            this.lb_SalesSlipNum.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesSlipNum.Text = "伝票番号";
            this.lb_SalesSlipNum.Top = 0F;
            this.lb_SalesSlipNum.Width = 0.5625F;
            // 
            // lb_SalesSlipCdName
            // 
            this.lb_SalesSlipCdName.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesSlipCdName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipCdName.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesSlipCdName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipCdName.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesSlipCdName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipCdName.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesSlipCdName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesSlipCdName.Height = 0.125F;
            this.lb_SalesSlipCdName.HyperLink = "";
            this.lb_SalesSlipCdName.Left = 1.3125F;
            this.lb_SalesSlipCdName.MultiLine = false;
            this.lb_SalesSlipCdName.Name = "lb_SalesSlipCdName";
            this.lb_SalesSlipCdName.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesSlipCdName.Text = "区分";
            this.lb_SalesSlipCdName.Top = 0F;
            this.lb_SalesSlipCdName.Width = 0.3125F;
            // 
            // lb_SalesEmployeeNm
            // 
            this.lb_SalesEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesEmployeeNm.Height = 0.125F;
            this.lb_SalesEmployeeNm.HyperLink = "";
            this.lb_SalesEmployeeNm.Left = 3.5625F;
            this.lb_SalesEmployeeNm.MultiLine = false;
            this.lb_SalesEmployeeNm.Name = "lb_SalesEmployeeNm";
            this.lb_SalesEmployeeNm.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesEmployeeNm.Text = "担当者";
            this.lb_SalesEmployeeNm.Top = 0F;
            this.lb_SalesEmployeeNm.Width = 0.625F;
            // 
            // lb_FrontEmployeeNm
            // 
            this.lb_FrontEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_FrontEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FrontEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_FrontEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FrontEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.lb_FrontEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FrontEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.lb_FrontEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FrontEmployeeNm.Height = 0.125F;
            this.lb_FrontEmployeeNm.HyperLink = "";
            this.lb_FrontEmployeeNm.Left = 4.25F;
            this.lb_FrontEmployeeNm.MultiLine = false;
            this.lb_FrontEmployeeNm.Name = "lb_FrontEmployeeNm";
            this.lb_FrontEmployeeNm.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_FrontEmployeeNm.Text = "受注者";
            this.lb_FrontEmployeeNm.Top = 0F;
            this.lb_FrontEmployeeNm.Width = 0.625F;
            // 
            // lb_SalesInputName
            // 
            this.lb_SalesInputName.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesInputName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesInputName.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesInputName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesInputName.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesInputName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesInputName.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesInputName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesInputName.Height = 0.125F;
            this.lb_SalesInputName.HyperLink = "";
            this.lb_SalesInputName.Left = 4.9375F;
            this.lb_SalesInputName.MultiLine = false;
            this.lb_SalesInputName.Name = "lb_SalesInputName";
            this.lb_SalesInputName.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesInputName.Text = "発行者";
            this.lb_SalesInputName.Top = 0F;
            this.lb_SalesInputName.Width = 0.625F;
            // 
            // lb_CategoryNo
            // 
            this.lb_CategoryNo.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_CategoryNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CategoryNo.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_CategoryNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CategoryNo.Border.RightColor = System.Drawing.Color.Black;
            this.lb_CategoryNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CategoryNo.Border.TopColor = System.Drawing.Color.Black;
            this.lb_CategoryNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CategoryNo.Height = 0.125F;
            this.lb_CategoryNo.HyperLink = "";
            this.lb_CategoryNo.Left = 1.6875F;
            this.lb_CategoryNo.MultiLine = false;
            this.lb_CategoryNo.Name = "lb_CategoryNo";
            this.lb_CategoryNo.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_CategoryNo.Text = "類別番号";
            this.lb_CategoryNo.Top = 0.125F;
            this.lb_CategoryNo.Width = 0.625F;
            // 
            // lb_ModelFullName
            // 
            this.lb_ModelFullName.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_ModelFullName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ModelFullName.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_ModelFullName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ModelFullName.Border.RightColor = System.Drawing.Color.Black;
            this.lb_ModelFullName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ModelFullName.Border.TopColor = System.Drawing.Color.Black;
            this.lb_ModelFullName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ModelFullName.Height = 0.125F;
            this.lb_ModelFullName.HyperLink = "";
            this.lb_ModelFullName.Left = 2.375F;
            this.lb_ModelFullName.MultiLine = false;
            this.lb_ModelFullName.Name = "lb_ModelFullName";
            this.lb_ModelFullName.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_ModelFullName.Text = "車種";
            this.lb_ModelFullName.Top = 0.125F;
            this.lb_ModelFullName.Width = 1.1875F;
            // 
            // lb_FullModel
            // 
            this.lb_FullModel.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_FullModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FullModel.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_FullModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FullModel.Border.RightColor = System.Drawing.Color.Black;
            this.lb_FullModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FullModel.Border.TopColor = System.Drawing.Color.Black;
            this.lb_FullModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FullModel.Height = 0.125F;
            this.lb_FullModel.HyperLink = "";
            this.lb_FullModel.Left = 3.5625F;
            this.lb_FullModel.MultiLine = false;
            this.lb_FullModel.Name = "lb_FullModel";
            this.lb_FullModel.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_FullModel.Text = "型式";
            this.lb_FullModel.Top = 0.125F;
            this.lb_FullModel.Width = 2F;
            // 
            // lb_CustSlipNo
            // 
            this.lb_CustSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_CustSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_CustSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.lb_CustSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.lb_CustSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustSlipNo.Height = 0.125F;
            this.lb_CustSlipNo.HyperLink = "";
            this.lb_CustSlipNo.Left = 5.625F;
            this.lb_CustSlipNo.MultiLine = false;
            this.lb_CustSlipNo.Name = "lb_CustSlipNo";
            this.lb_CustSlipNo.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_CustSlipNo.Text = "指示書(仮伝)番号";
            this.lb_CustSlipNo.Top = 0.125F;
            this.lb_CustSlipNo.Width = 0.95F;
            // 
            // lb_CarMngCode
            // 
            this.lb_CarMngCode.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_CarMngCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CarMngCode.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_CarMngCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CarMngCode.Border.RightColor = System.Drawing.Color.Black;
            this.lb_CarMngCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CarMngCode.Border.TopColor = System.Drawing.Color.Black;
            this.lb_CarMngCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CarMngCode.Height = 0.125F;
            this.lb_CarMngCode.HyperLink = "";
            this.lb_CarMngCode.Left = 6.8125F;
            this.lb_CarMngCode.MultiLine = false;
            this.lb_CarMngCode.Name = "lb_CarMngCode";
            this.lb_CarMngCode.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_CarMngCode.Text = "管理No";
            this.lb_CarMngCode.Top = 0.125F;
            this.lb_CarMngCode.Width = 1.1875F;
            // 
            // lb_FirstEntryDate
            // 
            this.lb_FirstEntryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_FirstEntryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FirstEntryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_FirstEntryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FirstEntryDate.Border.RightColor = System.Drawing.Color.Black;
            this.lb_FirstEntryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FirstEntryDate.Border.TopColor = System.Drawing.Color.Black;
            this.lb_FirstEntryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_FirstEntryDate.Height = 0.125F;
            this.lb_FirstEntryDate.HyperLink = "";
            this.lb_FirstEntryDate.Left = 8F;
            this.lb_FirstEntryDate.MultiLine = false;
            this.lb_FirstEntryDate.Name = "lb_FirstEntryDate";
            this.lb_FirstEntryDate.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_FirstEntryDate.Text = "年式";
            this.lb_FirstEntryDate.Top = 0.125F;
            this.lb_FirstEntryDate.Width = 0.4375F;
            // 
            // lb_SearchFrameNo
            // 
            this.lb_SearchFrameNo.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SearchFrameNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SearchFrameNo.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SearchFrameNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SearchFrameNo.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SearchFrameNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SearchFrameNo.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SearchFrameNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SearchFrameNo.Height = 0.125F;
            this.lb_SearchFrameNo.HyperLink = "";
            this.lb_SearchFrameNo.Left = 8.762F;
            this.lb_SearchFrameNo.MultiLine = false;
            this.lb_SearchFrameNo.Name = "lb_SearchFrameNo";
            this.lb_SearchFrameNo.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SearchFrameNo.Text = "車台No";
            this.lb_SearchFrameNo.Top = 0.125F;
            this.lb_SearchFrameNo.Width = 0.5F;
            // 
            // lb_GoodsNo
            // 
            this.lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsNo.Height = 0.125F;
            this.lb_GoodsNo.HyperLink = "";
            this.lb_GoodsNo.Left = 1.6875F;
            this.lb_GoodsNo.MultiLine = false;
            this.lb_GoodsNo.Name = "lb_GoodsNo";
            this.lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_GoodsNo.Text = "品番";
            this.lb_GoodsNo.Top = 0.25F;
            this.lb_GoodsNo.Width = 1.0625F;
            // 
            // lb_GoodsName
            // 
            this.lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_GoodsName.Height = 0.125F;
            this.lb_GoodsName.HyperLink = "";
            this.lb_GoodsName.Left = 2.8125F;
            this.lb_GoodsName.MultiLine = false;
            this.lb_GoodsName.Name = "lb_GoodsName";
            this.lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_GoodsName.Text = "品名";
            this.lb_GoodsName.Top = 0.25F;
            this.lb_GoodsName.Width = 1.1875F;
            // 
            // lb_ListPriceTaxExcFl
            // 
            this.lb_ListPriceTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_ListPriceTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ListPriceTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_ListPriceTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ListPriceTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.lb_ListPriceTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ListPriceTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.lb_ListPriceTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ListPriceTaxExcFl.Height = 0.125F;
            this.lb_ListPriceTaxExcFl.HyperLink = "";
            this.lb_ListPriceTaxExcFl.Left = 4.0625F;
            this.lb_ListPriceTaxExcFl.MultiLine = false;
            this.lb_ListPriceTaxExcFl.Name = "lb_ListPriceTaxExcFl";
            this.lb_ListPriceTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_ListPriceTaxExcFl.Text = "標準価格";
            this.lb_ListPriceTaxExcFl.Top = 0.25F;
            this.lb_ListPriceTaxExcFl.Width = 0.625F;
            // 
            // lb_ShipmentCnt
            // 
            this.lb_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.lb_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.lb_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ShipmentCnt.Height = 0.125F;
            this.lb_ShipmentCnt.HyperLink = "";
            this.lb_ShipmentCnt.Left = 4.75F;
            this.lb_ShipmentCnt.MultiLine = false;
            this.lb_ShipmentCnt.Name = "lb_ShipmentCnt";
            this.lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_ShipmentCnt.Text = "数量";
            this.lb_ShipmentCnt.Top = 0.25F;
            this.lb_ShipmentCnt.Width = 0.625F;
            // 
            // lb_SalesUnitCost
            // 
            this.lb_SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnitCost.Height = 0.125F;
            this.lb_SalesUnitCost.HyperLink = "";
            this.lb_SalesUnitCost.Left = 5.4375F;
            this.lb_SalesUnitCost.MultiLine = false;
            this.lb_SalesUnitCost.Name = "lb_SalesUnitCost";
            this.lb_SalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesUnitCost.Text = "原価";
            this.lb_SalesUnitCost.Top = 0.25F;
            this.lb_SalesUnitCost.Width = 0.625F;
            // 
            // lb_SalesUnPrcTaxExcFl
            // 
            this.lb_SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesUnPrcTaxExcFl.Height = 0.125F;
            this.lb_SalesUnPrcTaxExcFl.HyperLink = "";
            this.lb_SalesUnPrcTaxExcFl.Left = 6.125F;
            this.lb_SalesUnPrcTaxExcFl.MultiLine = false;
            this.lb_SalesUnPrcTaxExcFl.Name = "lb_SalesUnPrcTaxExcFl";
            this.lb_SalesUnPrcTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesUnPrcTaxExcFl.Text = "単価";
            this.lb_SalesUnPrcTaxExcFl.Top = 0.25F;
            this.lb_SalesUnPrcTaxExcFl.Width = 0.625F;
            // 
            // lb_SalesMoneyTaxExc
            // 
            this.lb_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SalesMoneyTaxExc.Height = 0.125F;
            this.lb_SalesMoneyTaxExc.HyperLink = "";
            this.lb_SalesMoneyTaxExc.Left = 6.8125F;
            this.lb_SalesMoneyTaxExc.MultiLine = false;
            this.lb_SalesMoneyTaxExc.Name = "lb_SalesMoneyTaxExc";
            this.lb_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SalesMoneyTaxExc.Text = "金額";
            this.lb_SalesMoneyTaxExc.Top = 0.25F;
            this.lb_SalesMoneyTaxExc.Width = 0.625F;
            // 
            // lb_ConsumeTax
            // 
            this.lb_ConsumeTax.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_ConsumeTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ConsumeTax.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_ConsumeTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ConsumeTax.Border.RightColor = System.Drawing.Color.Black;
            this.lb_ConsumeTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ConsumeTax.Border.TopColor = System.Drawing.Color.Black;
            this.lb_ConsumeTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_ConsumeTax.Height = 0.125F;
            this.lb_ConsumeTax.HyperLink = "";
            this.lb_ConsumeTax.Left = 7.5F;
            this.lb_ConsumeTax.MultiLine = false;
            this.lb_ConsumeTax.Name = "lb_ConsumeTax";
            this.lb_ConsumeTax.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_ConsumeTax.Text = "消費税";
            this.lb_ConsumeTax.Top = 0.25F;
            this.lb_ConsumeTax.Width = 0.625F;
            // 
            // lb_SlipNote
            // 
            this.lb_SlipNote.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_SlipNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SlipNote.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_SlipNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SlipNote.Border.RightColor = System.Drawing.Color.Black;
            this.lb_SlipNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SlipNote.Border.TopColor = System.Drawing.Color.Black;
            this.lb_SlipNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_SlipNote.Height = 0.125F;
            this.lb_SlipNote.HyperLink = "";
            this.lb_SlipNote.Left = 8.5F;
            this.lb_SlipNote.MultiLine = false;
            this.lb_SlipNote.Name = "lb_SlipNote";
            this.lb_SlipNote.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_SlipNote.Text = "備考";
            this.lb_SlipNote.Top = 0.25F;
            this.lb_SlipNote.Width = 2.3125F;
            // 
            // lb_CustomerCd
            // 
            this.lb_CustomerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_CustomerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustomerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_CustomerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustomerCd.Border.RightColor = System.Drawing.Color.Black;
            this.lb_CustomerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustomerCd.Border.TopColor = System.Drawing.Color.Black;
            this.lb_CustomerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_CustomerCd.Height = 0.125F;
            this.lb_CustomerCd.HyperLink = "";
            this.lb_CustomerCd.Left = 1.6875F;
            this.lb_CustomerCd.MultiLine = false;
            this.lb_CustomerCd.Name = "lb_CustomerCd";
            this.lb_CustomerCd.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_CustomerCd.Text = "得意先";
            this.lb_CustomerCd.Top = 0F;
            this.lb_CustomerCd.Width = 1.8125F;
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
            this.label1.Left = 8.125F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "税率";
            this.label1.Top = 0.25F;
            this.label1.Width = 0.32F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // DetailHeader
            // 
            this.DetailHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionCd2,
            this.SectionName2,
            this.line3});
            this.DetailHeader.DataField = "SectionCd2";
            this.DetailHeader.Height = 0.125F;
            this.DetailHeader.Name = "DetailHeader";
            this.DetailHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // SectionCd2
            // 
            this.SectionCd2.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd2.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd2.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd2.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCd2.DataField = "SectionCd2";
            this.SectionCd2.Height = 0.125F;
            this.SectionCd2.Left = 0F;
            this.SectionCd2.MultiLine = false;
            this.SectionCd2.Name = "SectionCd2";
            this.SectionCd2.OutputFormat = resources.GetString("SectionCd2.OutputFormat");
            this.SectionCd2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionCd2.Text = "99";
            this.SectionCd2.Top = 0F;
            this.SectionCd2.Width = 0.1666667F;
            // 
            // SectionName2
            // 
            this.SectionName2.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName2.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName2.Border.RightColor = System.Drawing.Color.Black;
            this.SectionName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName2.Border.TopColor = System.Drawing.Color.Black;
            this.SectionName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName2.DataField = "SectionName2";
            this.SectionName2.Height = 0.125F;
            this.SectionName2.Left = 0.1979167F;
            this.SectionName2.MultiLine = false;
            this.SectionName2.Name = "SectionName2";
            this.SectionName2.OutputFormat = resources.GetString("SectionName2.OutputFormat");
            this.SectionName2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionName2.Text = "12345678901234567890";
            this.SectionName2.Top = 0F;
            this.SectionName2.Width = 1.25F;
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
            this.line3.Width = 10.85F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.85F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // DetailHeader2
            // 
            this.DetailHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SalesDate,
            this.SalesSlipNum,
            this.SalesSlipCdName,
            this.SalesEmployeeNm,
            this.FrontEmployeeNm,
            this.SalesInputName,
            this.CategoryNo,
            this.ModelFullName,
            this.FullModel,
            this.CustSlipNo,
            this.CarMngCode,
            this.FirstEntryDate,
            this.FrameNo,
            this.CustomerCd2,
            this.CustomerName2,
            this.line5});
            this.DetailHeader2.DataField = "SalesSlipNum";
            this.DetailHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.DetailHeader2.Height = 0.25F;
            this.DetailHeader2.Name = "DetailHeader2";
            // 
            // SalesDate
            // 
            this.SalesDate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.DataField = "SalesDate";
            this.SalesDate.Height = 0.125F;
            this.SalesDate.Left = 0F;
            this.SalesDate.MultiLine = false;
            this.SalesDate.Name = "SalesDate";
            this.SalesDate.OutputFormat = resources.GetString("SalesDate.OutputFormat");
            this.SalesDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SalesDate.Text = "X99/99/99";
            this.SalesDate.Top = 0F;
            this.SalesDate.Width = 0.625F;
            // 
            // SalesSlipNum
            // 
            this.SalesSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.DataField = "SalesSlipNum";
            this.SalesSlipNum.Height = 0.125F;
            this.SalesSlipNum.Left = 0.6875F;
            this.SalesSlipNum.MultiLine = false;
            this.SalesSlipNum.Name = "SalesSlipNum";
            this.SalesSlipNum.OutputFormat = resources.GetString("SalesSlipNum.OutputFormat");
            this.SalesSlipNum.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SalesSlipNum.Text = "12345678";
            this.SalesSlipNum.Top = 0F;
            this.SalesSlipNum.Width = 0.5625F;
            // 
            // SalesSlipCdName
            // 
            this.SalesSlipCdName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipCdName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipCdName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipCdName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipCdName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipCdName.DataField = "SalesSlipCdName";
            this.SalesSlipCdName.Height = 0.125F;
            this.SalesSlipCdName.Left = 1.3125F;
            this.SalesSlipCdName.MultiLine = false;
            this.SalesSlipCdName.Name = "SalesSlipCdName";
            this.SalesSlipCdName.OutputFormat = resources.GetString("SalesSlipCdName.OutputFormat");
            this.SalesSlipCdName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SalesSlipCdName.Text = "XXXX";
            this.SalesSlipCdName.Top = 0F;
            this.SalesSlipCdName.Width = 0.3125F;
            // 
            // SalesEmployeeNm
            // 
            this.SalesEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.DataField = "SalesEmployeeNm";
            this.SalesEmployeeNm.Height = 0.125F;
            this.SalesEmployeeNm.Left = 3.5625F;
            this.SalesEmployeeNm.MultiLine = false;
            this.SalesEmployeeNm.Name = "SalesEmployeeNm";
            this.SalesEmployeeNm.OutputFormat = resources.GetString("SalesEmployeeNm.OutputFormat");
            this.SalesEmployeeNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SalesEmployeeNm.Text = "XXXXXXXXXX";
            this.SalesEmployeeNm.Top = 0F;
            this.SalesEmployeeNm.Width = 0.625F;
            // 
            // FrontEmployeeNm
            // 
            this.FrontEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.DataField = "FrontEmployeeNm";
            this.FrontEmployeeNm.Height = 0.125F;
            this.FrontEmployeeNm.Left = 4.25F;
            this.FrontEmployeeNm.MultiLine = false;
            this.FrontEmployeeNm.Name = "FrontEmployeeNm";
            this.FrontEmployeeNm.OutputFormat = resources.GetString("FrontEmployeeNm.OutputFormat");
            this.FrontEmployeeNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.FrontEmployeeNm.Text = "XXXXXXXXXX";
            this.FrontEmployeeNm.Top = 0F;
            this.FrontEmployeeNm.Width = 0.625F;
            // 
            // SalesInputName
            // 
            this.SalesInputName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.DataField = "SalesInputName";
            this.SalesInputName.Height = 0.125F;
            this.SalesInputName.Left = 4.9375F;
            this.SalesInputName.MultiLine = false;
            this.SalesInputName.Name = "SalesInputName";
            this.SalesInputName.OutputFormat = resources.GetString("SalesInputName.OutputFormat");
            this.SalesInputName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SalesInputName.Text = "XXXXXXXXXX";
            this.SalesInputName.Top = 0F;
            this.SalesInputName.Width = 0.625F;
            // 
            // CategoryNo
            // 
            this.CategoryNo.Border.BottomColor = System.Drawing.Color.Black;
            this.CategoryNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryNo.Border.LeftColor = System.Drawing.Color.Black;
            this.CategoryNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryNo.Border.RightColor = System.Drawing.Color.Black;
            this.CategoryNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryNo.Border.TopColor = System.Drawing.Color.Black;
            this.CategoryNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CategoryNo.DataField = "CategoryNo";
            this.CategoryNo.Height = 0.125F;
            this.CategoryNo.Left = 1.6875F;
            this.CategoryNo.MultiLine = false;
            this.CategoryNo.Name = "CategoryNo";
            this.CategoryNo.OutputFormat = resources.GetString("CategoryNo.OutputFormat");
            this.CategoryNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CategoryNo.Text = "99999-9999";
            this.CategoryNo.Top = 0.125F;
            this.CategoryNo.Width = 0.625F;
            // 
            // ModelFullName
            // 
            this.ModelFullName.Border.BottomColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.LeftColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.RightColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.Border.TopColor = System.Drawing.Color.Black;
            this.ModelFullName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ModelFullName.DataField = "ModelFullName";
            this.ModelFullName.Height = 0.125F;
            this.ModelFullName.Left = 2.375F;
            this.ModelFullName.MultiLine = false;
            this.ModelFullName.Name = "ModelFullName";
            this.ModelFullName.OutputFormat = resources.GetString("ModelFullName.OutputFormat");
            this.ModelFullName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.ModelFullName.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.ModelFullName.Top = 0.125F;
            this.ModelFullName.Width = 1.1875F;
            // 
            // FullModel
            // 
            this.FullModel.Border.BottomColor = System.Drawing.Color.Black;
            this.FullModel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.LeftColor = System.Drawing.Color.Black;
            this.FullModel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.RightColor = System.Drawing.Color.Black;
            this.FullModel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.Border.TopColor = System.Drawing.Color.Black;
            this.FullModel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FullModel.DataField = "FullModel";
            this.FullModel.Height = 0.125F;
            this.FullModel.Left = 3.5625F;
            this.FullModel.MultiLine = false;
            this.FullModel.Name = "FullModel";
            this.FullModel.OutputFormat = resources.GetString("FullModel.OutputFormat");
            this.FullModel.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.FullModel.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            this.FullModel.Top = 0.125F;
            this.FullModel.Width = 2F;
            // 
            // CustSlipNo
            // 
            this.CustSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.CustSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.CustSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.CustSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.CustSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustSlipNo.DataField = "PartySaleSlipNum";
            this.CustSlipNo.Height = 0.125F;
            this.CustSlipNo.Left = 5.625F;
            this.CustSlipNo.MultiLine = false;
            this.CustSlipNo.Name = "CustSlipNo";
            this.CustSlipNo.OutputFormat = resources.GetString("CustSlipNo.OutputFormat");
            this.CustSlipNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustSlipNo.Text = "XXXXXXXXXXXXXXXXXXX";
            this.CustSlipNo.Top = 0.125F;
            this.CustSlipNo.Width = 1.135F;
            // 
            // CarMngCode
            // 
            this.CarMngCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.RightColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.Border.TopColor = System.Drawing.Color.Black;
            this.CarMngCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CarMngCode.DataField = "CarMngCode";
            this.CarMngCode.Height = 0.125F;
            this.CarMngCode.Left = 6.8125F;
            this.CarMngCode.MultiLine = false;
            this.CarMngCode.Name = "CarMngCode";
            this.CarMngCode.OutputFormat = resources.GetString("CarMngCode.OutputFormat");
            this.CarMngCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CarMngCode.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.CarMngCode.Top = 0.125F;
            this.CarMngCode.Width = 1.1875F;
            // 
            // FirstEntryDate
            // 
            this.FirstEntryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.RightColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.Border.TopColor = System.Drawing.Color.Black;
            this.FirstEntryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FirstEntryDate.DataField = "FirstEntryDate";
            this.FirstEntryDate.Height = 0.125F;
            this.FirstEntryDate.Left = 8F;
            this.FirstEntryDate.MultiLine = false;
            this.FirstEntryDate.Name = "FirstEntryDate";
            this.FirstEntryDate.OutputFormat = resources.GetString("FirstEntryDate.OutputFormat");
            this.FirstEntryDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.FirstEntryDate.Text = "X99/99";
            this.FirstEntryDate.Top = 0.125F;
            this.FirstEntryDate.Width = 0.7F;
            // 
            // FrameNo
            // 
            this.FrameNo.Border.BottomColor = System.Drawing.Color.Black;
            this.FrameNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrameNo.Border.LeftColor = System.Drawing.Color.Black;
            this.FrameNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrameNo.Border.RightColor = System.Drawing.Color.Black;
            this.FrameNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrameNo.Border.TopColor = System.Drawing.Color.Black;
            this.FrameNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrameNo.DataField = "FrameNo";
            this.FrameNo.Height = 0.125F;
            this.FrameNo.Left = 8.762F;
            this.FrameNo.MultiLine = false;
            this.FrameNo.Name = "FrameNo";
            this.FrameNo.OutputFormat = resources.GetString("FrameNo.OutputFormat");
            this.FrameNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.FrameNo.Text = "99999999999999999";
            this.FrameNo.Top = 0.125F;
            this.FrameNo.Width = 1F;
            // 
            // CustomerCd2
            // 
            this.CustomerCd2.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCd2.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCd2.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCd2.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCd2.DataField = "CustomerCd2";
            this.CustomerCd2.Height = 0.125F;
            this.CustomerCd2.Left = 1.6875F;
            this.CustomerCd2.MultiLine = false;
            this.CustomerCd2.Name = "CustomerCd2";
            this.CustomerCd2.OutputFormat = resources.GetString("CustomerCd2.OutputFormat");
            this.CustomerCd2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CustomerCd2.Text = "12345678";
            this.CustomerCd2.Top = 0F;
            this.CustomerCd2.Width = 0.5625F;
            // 
            // CustomerName2
            // 
            this.CustomerName2.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName2.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName2.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName2.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName2.DataField = "CustomerName2";
            this.CustomerName2.Height = 0.125F;
            this.CustomerName2.Left = 2.375F;
            this.CustomerName2.MultiLine = false;
            this.CustomerName2.Name = "CustomerName2";
            this.CustomerName2.OutputFormat = resources.GetString("CustomerName2.OutputFormat");
            this.CustomerName2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerName2.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.CustomerName2.Top = 0F;
            this.CustomerName2.Width = 1.1875F;
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
            this.line5.Width = 10.85F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.85F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // groupFooter3
            // 
            this.groupFooter3.Height = 0F;
            this.groupFooter3.Name = "groupFooter3";
            // 
            // DetailTitleHeader2
            // 
            this.DetailTitleHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lb_Section2});
            this.DetailTitleHeader2.Height = 0.125F;
            this.DetailTitleHeader2.Name = "DetailTitleHeader2";
            this.DetailTitleHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // lb_Section2
            // 
            this.lb_Section2.Border.BottomColor = System.Drawing.Color.Black;
            this.lb_Section2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Section2.Border.LeftColor = System.Drawing.Color.Black;
            this.lb_Section2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Section2.Border.RightColor = System.Drawing.Color.Black;
            this.lb_Section2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Section2.Border.TopColor = System.Drawing.Color.Black;
            this.lb_Section2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lb_Section2.Height = 0.125F;
            this.lb_Section2.HyperLink = "";
            this.lb_Section2.Left = 0F;
            this.lb_Section2.MultiLine = false;
            this.lb_Section2.Name = "lb_Section2";
            this.lb_Section2.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.lb_Section2.Text = "拠点";
            this.lb_Section2.Top = 0F;
            this.lb_Section2.Width = 0.625F;
            // 
            // groupFooter4
            // 
            this.groupFooter4.Height = 0F;
            this.groupFooter4.Name = "groupFooter4";
            // 
            // PMKAU04005P_02A4C
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
            this.PrintWidth = 10.9125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.DetailTitleHeader2);
            this.Sections.Add(this.DetailTitleHeader);
            this.Sections.Add(this.DetailHeader);
            this.Sections.Add(this.DetailHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter3);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.groupFooter4);
            this.Sections.Add(this.GrandTotalFooter);
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
            this.PageEnd += new System.EventHandler(this.PMKAU04005P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKAU04005P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.SlipNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsumeTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SectionCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartDt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_DateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndDt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_AddUpADate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesSlipCdName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_FrontEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesInputName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CategoryNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ModelFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_FullModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CustSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CarMngCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_FirstEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SearchFrameNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ListPriceTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_ConsumeTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_SlipNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_CustomerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipCdName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInputName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarMngCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lb_Section2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

     }
}
