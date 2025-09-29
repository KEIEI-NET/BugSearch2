//***************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 帳票クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 仕入返品予定一覧表印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 仕入返品予定一覧表のフォームクラスです。</br>
    /// <br>Programmer  : FSI高橋 文彰</br>
    /// <br>Date	    :  2013/01/28</br>
    /// </remarks>
    public class PMKAK02033P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        /// <summary>
        /// 仕入返品予定一覧表フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 仕入返品予定一覧表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date	    :  2013/01/28</br>
        /// </remarks>
        public PMKAK02033P_01A4C()
        {
            InitializeComponent();
        }

        //================================================================================
        //  内部変数
        //================================================================================
        #region Private Member
        private string _pageHeaderSortOderTitle;	// ソート順
        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;	// 抽出条件印字項目
        private int _pageFooterOutCode;			    // フッター出力区分
        private StringCollection _pageFooters;		// フッターメッセージ
        private SFCMN06002C _printInfo;				// 印刷情報クラス
        private string _pageHeaderSubtitle;			// フォームサブタイトル
        private ArrayList _otherDataList;			// その他データ
        private ExtrInfo_PMKAK02034E _extrInfo;	    // 抽出条件クラス
	
        // ページ数カウント用
        private int _printCount;					
        // 伝票枚数　拠点計
        private int scSlipNum = 0;
        // 伝票枚数　仕入先計				
        private int spSlipNum = 0;
        // 伝票枚数　総合計
        private int alSlipNum = 0;								
        //仕入先消費税合計
        private double spSubTotalTax = 0;
        //拠点消費税合計
        private double scSubTotalTax = 0;
        //総消費税合計
        private double alTotalTax = 0;
        //伝票金額合計
        private double slipTotal = 0;
        //仕入先合計
        private double spTotal = 0;
        //拠点合計
        private double scTotal = 0;
        //総合計
        private double alTotal = 0;
        //伝票消費税合計
        private double slipTotalTax = 0;
        // フッターレポート作成
        ListCommon_PageFooter _rptPageFooter = null;

        private Label label5;
        private Label label7;
        private Label label16;
        private Label label22;
        private Label label24;
        private Label label14;
        private Label label18;
        private Label label20;
        private Line line7;
        private TextBox textBox28;
        private TextBox textBox27;
        private Line line8;
        private TextBox textBox23;
        private TextBox CustomerName;
        private TextBox textBox34;
        private TextBox ReturnedGoodsTypeRF;
        private TextBox textBox33;
        private TextBox textBox24;
        private TextBox textBox9;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox20;
        private Label label26;
        private TextBox textBox8;
        private TextBox txtSort1_Title;
        private TextBox textBox46;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Line Line45;
        private TextBox textBox39;
        private TextBox textBox64;
        private Label label46;
        private Line line10;
        private TextBox textBox3;
        private TextBox txtSlipNumTotal;
        private Label label60;
        private TextBox textBox25;
        private Line line2;
        private Line line6;
        private Label label1;
        private Line line4;
        private Label label6;
        private TextBox textBox10;
        private Label label13;
        private TextBox textBox14;
        private TextBox textBox18;
        private Label label19;
        private Label label10;
        private TextBox textBox29;
        private TextBox textBox37;
        private Label label30;
        private TextBox textBox6;
        private TextBox textBox40;
        private TextBox textBox44;
        private Label label4;
        private Label label9;
        private TextBox textBox2;
        private Label label8;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox txt_DtlConsTax;
        private TextBox txt_SlpConsTax;
        private TextBox Detail_SuppCTaxLayCd;
        private TextBox Detail_TaxationCode;
        private TextBox Title_SuppCTaxLayCd;
        private TextBox Title_TaxationCode;
        private ReportHeader reportHeader1;
        private ReportFooter reportFooter1;
        private PageHeader PageHeader;
        private Label ListTitle_Title;
        private Label Label3;
        private TextBox PrintDate;
        private Label Label2;
        private TextBox PRINTPAGE;
        private Line Line1;
        private TextBox PrintTime;
        private PageFooter PageFooter;
        private Line line17;
        private SubReport Footer_SubReport;
        private TextBox textBox5;
        private TextBox textBox7;
        private Line line3;
        private SubReport subReport1;
        #endregion PrivateMembers

        //================================================================================
        //  プロパティ
        //================================================================================
        #region Public Property
        #region IPrintActiveReportTypeList メンバ
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
                this._extrInfo = (ExtrInfo_PMKAK02034E)this._printInfo.jyoken;
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
        ///	印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion
        #region IPrintActiveReportTypeCommon メンバ

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            get { return 0; }
            set { }
        }

        #endregion
        #endregion

        //================================================================================
        //  イベント
        //================================================================================
        #region event
        /// <summary>
        /// PMKAK02033P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : PMKAK02033P_01A4C_ReportStartの初期化イベントです。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void PMKAK02033P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // 改頁制御
            if (this._extrInfo.NewPageDiv == 0)
            {
                // 拠点毎
                this.SectionHeader.NewPage = NewPage.Before;
            }
            else if (this._extrInfo.NewPageDiv == 1)
            {
                this.SortDiv1Header.NewPage = NewPage.Before;
            }
            else if (this._extrInfo.NewPageDiv == 2)
            {
                this.reportHeader1.NewPage = NewPage.None;
            }
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 作成日付           
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            //作成日(西暦で表示)
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// ExtraHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
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
            ListCommon_ExtraHeader rptExtraHeader = new ListCommon_ExtraHeader();
            rptExtraHeader.ExtraConditions = this._extraConditions;
            this.subReport1.Report = rptExtraHeader;
        }

        /// <summary>
        /// TitleHeader_Formatイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 合計伝票枚数を計算します。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            if(this.textBox23.Value.ToString() == "仕入" || this.textBox23.Value.ToString() == "返品")
            {
                    this.scSlipNum  += 1;     //拠点の伝票枚数
                    this.spSlipNum  += 1;     //仕入先の伝票枚数
                    this.alSlipNum += 1;     //総計の伝票枚数
            }
        }

        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }

        /// <summary>
        /// PageFooter_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date	   :  2013/01/28</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // インスタンスが作成されていなければ作成
                if (this._rptPageFooter == null)
                {
                    this._rptPageFooter = new ListCommon_PageFooter();
                }
                else
                {
                    // インスタンスが作成されていれば、データソースを初期化する
                    // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                    this._rptPageFooter.DataSource = null;
                }

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = this._rptPageFooter;
            }
        }

        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date	    :  2013/01/28</br>
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

        /// <summary>
        /// Detail_Formatイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 消費税転嫁方式　0:伝票
            if (this.Detail_SuppCTaxLayCd.Value.ToString() == "0")
            {
                this.txt_DtlConsTax.Visible = false;
                this.txt_SlpConsTax.Visible = false;

                //伝票の金額を計算
                this.slipTotal += Convert.ToDouble(this.textBox9.Value);
                //仕入先合計を計算
                this.spTotal += Convert.ToDouble(this.textBox9.Value);
                //拠点合計を計算
                this.scTotal += Convert.ToDouble(this.textBox9.Value);
                //総合計を計算
                this.alTotal += Convert.ToDouble(this.textBox9.Value);
            }
            // 消費税転嫁方式　1:明細単位
            else if (this.Detail_SuppCTaxLayCd.Value.ToString() == "1")
            {
                // 課税区分　0：課税、2：内税
                if ((this.Detail_TaxationCode.Value.ToString() == "0") ||
                    (this.Detail_TaxationCode.Value.ToString() == "2"))
                {
                    this.txt_DtlConsTax.Visible = true;
                    this.txt_SlpConsTax.Visible = true;

                    //各合計の消費税を計算
                    this.spSubTotalTax += Convert.ToDouble(this.txt_DtlConsTax.Value);
                    this.scSubTotalTax += Convert.ToDouble(this.txt_DtlConsTax.Value);
                    this.alTotalTax += Convert.ToDouble(this.txt_DtlConsTax.Value);
                    this.slipTotalTax += Convert.ToDouble(this.txt_DtlConsTax.Value);

                    //伝票の金額を計算
                    this.slipTotal    += Convert.ToDouble(this.textBox9.Value);
                    //仕入先合計を計算
                    this.spTotal += Convert.ToDouble(this.textBox9.Value);
                    //拠点合計を計算
                    this.scTotal += Convert.ToDouble(this.textBox9.Value);
                    //総合計を計算
                    this.alTotal += Convert.ToDouble(this.textBox9.Value);
                }
                else
                {
                    // 課税区分　1：非課税
                    this.txt_DtlConsTax.Visible = false;
                    this.txt_SlpConsTax.Visible = false;

                    //伝票の金額を計算
                    this.slipTotal += Convert.ToDouble(this.textBox9.Value);
                    //仕入先合計を計算
                    this.spTotal += Convert.ToDouble(this.textBox9.Value);
                    //拠点合計を計算
                    this.scTotal += Convert.ToDouble(this.textBox9.Value);
                    //総合計を計算
                    this.alTotal += Convert.ToDouble(this.textBox9.Value);
                }
            }
            else
            {
                // 消費税転嫁方式　2：請求親、3：請求子、9：非課税
                this.txt_DtlConsTax.Visible = false;
                this.txt_SlpConsTax.Visible = false;

                //伝票の金額を計算
                this.slipTotal += Convert.ToDouble(this.textBox9.Value);
                //仕入先合計を計算
                this.spTotal += Convert.ToDouble(this.textBox9.Value);
                //拠点合計を計算
                this.scTotal += Convert.ToDouble(this.textBox9.Value);
                //総合計を計算
                this.alTotal += Convert.ToDouble(this.textBox9.Value);
            }
        }

        /// <summary>
        /// TitleFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleFooter_BeforePrint(object sender, EventArgs e)
        {
            // 消費税の印字制御
            if (this.Title_SuppCTaxLayCd.Value.ToString() != "0"
                && this.Title_SuppCTaxLayCd.Value.ToString() != "1")
            {
                this.txt_SlpConsTax.Text = "";
            }

            //伝票金額印字用
            this.textBox8.Value = this.slipTotal;
            this.txt_SlpConsTax.Value = this.slipTotalTax;

            //伝票金額初期化
            this.slipTotal = 0;
            this.slipTotalTax = 0;
        }



        /// <summary>
        /// SectionFooter_Formatイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 合計伝票枚数を計算します。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {

            this.textBox1.Value = this.scSlipNum;
            this.textBox40.Value = this.scSubTotalTax;
            this.textBox64.Value = this.scTotal;

            //伝票枚数初期化
            this.scSlipNum = 0;
            //拠点合計金額初期化
            this.scSubTotalTax = 0;
            this.scTotal = 0;
        }

        /// <summary>
        /// SectionFooter_Formatイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 合計伝票枚数を計算します。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void SortDiv1Footer_Format(object sender, EventArgs e)
        {

            this.textBox2.Value = this.spSlipNum;
            this.textBox6.Value = this.spSubTotalTax;
            this.textBox46.Value = this.spTotal;

            //伝票枚数初期化
            this.spSlipNum = 0;
            //仕入先合計金額初期化
            this.spSubTotalTax = 0;
            this.spTotal = 0;
        }

        /// <summary>
        /// GrandTotalFooter_Formatイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 合計伝票枚数を計算します。</br>
        /// <br>Programmer  : FSI高橋 文彰</br>
        /// <br>Date		:  2013/01/28</br>
        /// </remarks>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            this.txtSlipNumTotal.Value = this.alSlipNum;
            this.textBox44.Value = this.alTotalTax;
            this.textBox25.Value = this.alTotal;
        }

        #endregion

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.GroupHeader SortDiv1Header;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter SortDiv1Footer;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKAK02033P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.ReturnedGoodsTypeRF = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.txt_DtlConsTax = new DataDynamics.ActiveReports.TextBox();
            this.Detail_SuppCTaxLayCd = new DataDynamics.ActiveReports.TextBox();
            this.Detail_TaxationCode = new DataDynamics.ActiveReports.TextBox();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSlipNumTotal = new DataDynamics.ActiveReports.TextBox();
            this.label60 = new DataDynamics.ActiveReports.Label();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.txt_SlpConsTax = new DataDynamics.ActiveReports.TextBox();
            this.Title_SuppCTaxLayCd = new DataDynamics.ActiveReports.TextBox();
            this.Title_TaxationCode = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.SortDiv1Header = new DataDynamics.ActiveReports.GroupHeader();
            this.SortDiv1Footer = new DataDynamics.ActiveReports.GroupFooter();
            this.txtSort1_Title = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.label46 = new DataDynamics.ActiveReports.Label();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.ListTitle_Title = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PRINTPAGE = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnedGoodsTypeRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DtlConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_SuppCTaxLayCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_TaxationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipNumTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SlpConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title_SuppCTaxLayCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title_TaxationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTitle_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox9,
            this.textBox16,
            this.textBox17,
            this.textBox20,
            this.textBox18,
            this.textBox29,
            this.textBox37,
            this.ReturnedGoodsTypeRF,
            this.textBox4,
            this.txt_DtlConsTax,
            this.Detail_SuppCTaxLayCd,
            this.Detail_TaxationCode});
            this.Detail.Height = 0.7F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.DataField = "StockPriceTaxExc";
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 8.625F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.textBox9.Text = "123,456,789";
            this.textBox9.Top = 0.0625F;
            this.textBox9.Width = 1F;
            // 
            // textBox16
            // 
            this.textBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.RightColor = System.Drawing.Color.Black;
            this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.TopColor = System.Drawing.Color.Black;
            this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.DataField = "StockCount";
            this.textBox16.Height = 0.1875F;
            this.textBox16.Left = 5.5F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.textBox16.Text = "123,456";
            this.textBox16.Top = 0.0625F;
            this.textBox16.Width = 0.75F;
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
            this.textBox17.DataField = "StockUnitPriceFl";
            this.textBox17.Height = 0.188F;
            this.textBox17.Left = 7.875F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox17.Text = "123,456,789";
            this.textBox17.Top = 0.0625F;
            this.textBox17.Width = 0.7F;
            // 
            // textBox20
            // 
            this.textBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.RightColor = System.Drawing.Color.Black;
            this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.TopColor = System.Drawing.Color.Black;
            this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.DataField = "GoodsNo";
            this.textBox20.Height = 0.188F;
            this.textBox20.Left = 0.5625F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.textBox20.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.textBox20.Top = 0.0625F;
            this.textBox20.Width = 2F;
            // 
            // textBox18
            // 
            this.textBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.RightColor = System.Drawing.Color.Black;
            this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.TopColor = System.Drawing.Color.Black;
            this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.DataField = "BLGoodsCode";
            this.textBox18.Height = 0.188F;
            this.textBox18.Left = 3.125F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox18.Text = "00000";
            this.textBox18.Top = 0.0625F;
            this.textBox18.Width = 0.3F;
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
            this.textBox29.DataField = "GoodsMakerCd";
            this.textBox29.Height = 0.1875F;
            this.textBox29.Left = 2.5625F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.textBox29.Text = "0000";
            this.textBox29.Top = 0.0625F;
            this.textBox29.Width = 0.5F;
            // 
            // textBox37
            // 
            this.textBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.RightColor = System.Drawing.Color.Black;
            this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.TopColor = System.Drawing.Color.Black;
            this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.DataField = "ListPriceTaxExc";
            this.textBox37.Height = 0.188F;
            this.textBox37.Left = 6.6875F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox37.Text = "123,456,789";
            this.textBox37.Top = 0.0625F;
            this.textBox37.Width = 0.8F;
            // 
            // ReturnedGoodsTypeRF
            // 
            this.ReturnedGoodsTypeRF.Border.BottomColor = System.Drawing.Color.Black;
            this.ReturnedGoodsTypeRF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReturnedGoodsTypeRF.Border.LeftColor = System.Drawing.Color.Black;
            this.ReturnedGoodsTypeRF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReturnedGoodsTypeRF.Border.RightColor = System.Drawing.Color.Black;
            this.ReturnedGoodsTypeRF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReturnedGoodsTypeRF.Border.TopColor = System.Drawing.Color.Black;
            this.ReturnedGoodsTypeRF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReturnedGoodsTypeRF.DataField = "ReturnedGoodsType";
            this.ReturnedGoodsTypeRF.Height = 0.188F;
            this.ReturnedGoodsTypeRF.Left = 0F;
            this.ReturnedGoodsTypeRF.MultiLine = false;
            this.ReturnedGoodsTypeRF.Name = "ReturnedGoodsTypeRF";
            this.ReturnedGoodsTypeRF.OutputFormat = resources.GetString("ReturnedGoodsTypeRF.OutputFormat");
            this.ReturnedGoodsTypeRF.Style = "ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.ReturnedGoodsTypeRF.Text = "ＮＮＮＮ";
            this.ReturnedGoodsTypeRF.Top = 0.0625F;
            this.ReturnedGoodsTypeRF.Width = 0.5F;
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
            this.textBox4.DataField = "GoodsName";
            this.textBox4.Height = 0.1875F;
            this.textBox4.Left = 3.5F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; vertical-align: top; ";
            this.textBox4.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.textBox4.Top = 0.0625F;
            this.textBox4.Width = 2F;
            // 
            // txt_DtlConsTax
            // 
            this.txt_DtlConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.txt_DtlConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_DtlConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.txt_DtlConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_DtlConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.txt_DtlConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_DtlConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.txt_DtlConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_DtlConsTax.DataField = "DtlConsTax";
            this.txt_DtlConsTax.Height = 0.188F;
            this.txt_DtlConsTax.Left = 9.75F;
            this.txt_DtlConsTax.MultiLine = false;
            this.txt_DtlConsTax.Name = "txt_DtlConsTax";
            this.txt_DtlConsTax.OutputFormat = resources.GetString("txt_DtlConsTax.OutputFormat");
            this.txt_DtlConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txt_DtlConsTax.Text = "123,456,789";
            this.txt_DtlConsTax.Top = 0.0625F;
            this.txt_DtlConsTax.Width = 0.8F;
            // 
            // Detail_SuppCTaxLayCd
            // 
            this.Detail_SuppCTaxLayCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.Border.RightColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.Border.TopColor = System.Drawing.Color.Black;
            this.Detail_SuppCTaxLayCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SuppCTaxLayCd.DataField = "SuppCTaxLayCd";
            this.Detail_SuppCTaxLayCd.Height = 0.1875F;
            this.Detail_SuppCTaxLayCd.Left = 6.375F;
            this.Detail_SuppCTaxLayCd.MultiLine = false;
            this.Detail_SuppCTaxLayCd.Name = "Detail_SuppCTaxLayCd";
            this.Detail_SuppCTaxLayCd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Detail_SuppCTaxLayCd.Text = null;
            this.Detail_SuppCTaxLayCd.Top = 0.0625F;
            this.Detail_SuppCTaxLayCd.Visible = false;
            this.Detail_SuppCTaxLayCd.Width = 0.25F;
            // 
            // Detail_TaxationCode
            // 
            this.Detail_TaxationCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.Border.RightColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.Border.TopColor = System.Drawing.Color.Black;
            this.Detail_TaxationCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_TaxationCode.DataField = "TaxationCode";
            this.Detail_TaxationCode.Height = 0.1875F;
            this.Detail_TaxationCode.Left = 7.5625F;
            this.Detail_TaxationCode.MultiLine = false;
            this.Detail_TaxationCode.Name = "Detail_TaxationCode";
            this.Detail_TaxationCode.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Detail_TaxationCode.Text = null;
            this.Detail_TaxationCode.Top = 0.0625F;
            this.Detail_TaxationCode.Visible = false;
            this.Detail_TaxationCode.Width = 0.25F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1,
            this.label5,
            this.label7,
            this.label16,
            this.label22,
            this.label14,
            this.label18,
            this.label20,
            this.line7,
            this.line8,
            this.label24,
            this.label6,
            this.label13,
            this.label19,
            this.label10,
            this.label30,
            this.label4,
            this.label9});
            this.ExtraHeader.Height = 0.8854167F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // subReport1
            // 
            this.subReport1.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.RightColor = System.Drawing.Color.Black;
            this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.TopColor = System.Drawing.Color.Black;
            this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 0.375F;
            this.subReport1.Left = 0F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0F;
            this.subReport1.Width = 10.8125F;
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
            this.label5.Height = 0.1875F;
            this.label5.HyperLink = null;
            this.label5.Left = 0F;
            this.label5.Name = "label5";
            this.label5.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label5.Text = "仕入先";
            this.label5.Top = 0.4375F;
            this.label5.Width = 0.5625F;
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
            this.label7.Height = 0.1875F;
            this.label7.HyperLink = null;
            this.label7.Left = 2.5625F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label7.Text = "入力日付";
            this.label7.Top = 0.4375F;
            this.label7.Width = 0.5625F;
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
            this.label16.Height = 0.1875F;
            this.label16.HyperLink = null;
            this.label16.Left = 0F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label16.Text = "区分";
            this.label16.Top = 0.625F;
            this.label16.Width = 0.5F;
            // 
            // label22
            // 
            this.label22.Border.BottomColor = System.Drawing.Color.Black;
            this.label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.LeftColor = System.Drawing.Color.Black;
            this.label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.RightColor = System.Drawing.Color.Black;
            this.label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.TopColor = System.Drawing.Color.Black;
            this.label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Height = 0.188F;
            this.label22.HyperLink = null;
            this.label22.Left = 8.625F;
            this.label22.Name = "label22";
            this.label22.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label22.Text = "金額";
            this.label22.Top = 0.625F;
            this.label22.Width = 1F;
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
            this.label14.Height = 0.1875F;
            this.label14.HyperLink = null;
            this.label14.Left = 0.5625F;
            this.label14.Name = "label14";
            this.label14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label14.Text = "品番";
            this.label14.Top = 0.625F;
            this.label14.Width = 0.875F;
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
            this.label18.Height = 0.188F;
            this.label18.HyperLink = null;
            this.label18.Left = 6.75F;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label18.Text = "標準価格";
            this.label18.Top = 0.625F;
            this.label18.Width = 0.75F;
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
            this.label20.Height = 0.188F;
            this.label20.HyperLink = null;
            this.label20.Left = 7.875F;
            this.label20.Name = "label20";
            this.label20.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label20.Text = "原単価";
            this.label20.Top = 0.625F;
            this.label20.Width = 0.7F;
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
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0.375F;
            this.line7.Width = 10.8125F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8125F;
            this.line7.Y1 = 0.375F;
            this.line7.Y2 = 0.375F;
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
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0.375F;
            this.line8.Width = 10.8125F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8125F;
            this.line8.Y1 = 0.375F;
            this.line8.Y2 = 0.375F;
            // 
            // label24
            // 
            this.label24.Border.BottomColor = System.Drawing.Color.Black;
            this.label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.LeftColor = System.Drawing.Color.Black;
            this.label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.RightColor = System.Drawing.Color.Black;
            this.label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.TopColor = System.Drawing.Color.Black;
            this.label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Height = 0.1875F;
            this.label24.HyperLink = null;
            this.label24.Left = 3.6875F;
            this.label24.Name = "label24";
            this.label24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label24.Text = "仕入日付";
            this.label24.Top = 0.4375F;
            this.label24.Width = 0.5625F;
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
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = null;
            this.label6.Left = 4.42F;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label6.Text = "返品伝票番号";
            this.label6.Top = 0.438F;
            this.label6.Width = 0.625F;
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
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = null;
            this.label13.Left = 7.3F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label13.Text = "備考";
            this.label13.Top = 0.438F;
            this.label13.Width = 0.6875F;
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
            this.label19.Height = 0.188F;
            this.label19.HyperLink = null;
            this.label19.Left = 3.125F;
            this.label19.Name = "label19";
            this.label19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label19.Text = "BLコード";
            this.label19.Top = 0.625F;
            this.label19.Width = 0.5F;
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
            this.label10.Height = 0.1875F;
            this.label10.HyperLink = null;
            this.label10.Left = 2.5625F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; text-align: left; font-weight: bold; font-size: 7pt; vertical-align" +
                ": top; ";
            this.label10.Text = "メーカー";
            this.label10.Top = 0.625F;
            this.label10.Width = 0.5F;
            // 
            // label30
            // 
            this.label30.Border.BottomColor = System.Drawing.Color.Black;
            this.label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.LeftColor = System.Drawing.Color.Black;
            this.label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.RightColor = System.Drawing.Color.Black;
            this.label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.TopColor = System.Drawing.Color.Black;
            this.label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Height = 0.188F;
            this.label30.HyperLink = null;
            this.label30.Left = 9.75F;
            this.label30.Name = "label30";
            this.label30.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label30.Text = "消費税";
            this.label30.Top = 0.625F;
            this.label30.Width = 0.8F;
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
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = null;
            this.label4.Left = 6.04F;
            this.label4.Name = "label4";
            this.label4.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label4.Text = "伝票区分";
            this.label4.Top = 0.438F;
            this.label4.Width = 0.5F;
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
            this.label9.Height = 0.188F;
            this.label9.HyperLink = null;
            this.label9.Left = 5.5625F;
            this.label9.Name = "label9";
            this.label9.Style = "color: Black; text-align: right; font-weight: bold; font-size: 7pt; vertical-alig" +
                "n: top; ";
            this.label9.Text = "数量";
            this.label9.Top = 0.625F;
            this.label9.Width = 0.75F;
            // 
            // textBox28
            // 
            this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.RightColor = System.Drawing.Color.Black;
            this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.TopColor = System.Drawing.Color.Black;
            this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.DataField = "SectionGuideNm";
            this.textBox28.Height = 0.188F;
            this.textBox28.Left = 0.5F;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "font-size: 8pt; vertical-align: top; ";
            this.textBox28.Text = "あいうえおかきくけこ";
            this.textBox28.Top = 0.0625F;
            this.textBox28.Width = 1.5F;
            // 
            // textBox27
            // 
            this.textBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.RightColor = System.Drawing.Color.Black;
            this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.TopColor = System.Drawing.Color.Black;
            this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.DataField = "SectionCode";
            this.textBox27.Height = 0.188F;
            this.textBox27.Left = 0.3125F;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "text-align: left; font-size: 8pt; vertical-align: top; ";
            this.textBox27.Text = "99";
            this.textBox27.Top = 0.0625F;
            this.textBox27.Width = 0.2F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox3,
            this.txtSlipNumTotal,
            this.label60,
            this.textBox25,
            this.line2,
            this.textBox44});
            this.ExtraFooter.Height = 0.325F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
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
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 6.6875F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.textBox3.Text = "総合計";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.6875F;
            // 
            // txtSlipNumTotal
            // 
            this.txtSlipNumTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSlipNumTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSlipNumTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSlipNumTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSlipNumTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtSlipNumTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSlipNumTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtSlipNumTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSlipNumTotal.Height = 0.1875F;
            this.txtSlipNumTotal.Left = 7.9375F;
            this.txtSlipNumTotal.MultiLine = false;
            this.txtSlipNumTotal.Name = "txtSlipNumTotal";
            this.txtSlipNumTotal.OutputFormat = resources.GetString("txtSlipNumTotal.OutputFormat");
            this.txtSlipNumTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txtSlipNumTotal.SummaryGroup = "TitleHeader";
            this.txtSlipNumTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtSlipNumTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtSlipNumTotal.Text = "1,234";
            this.txtSlipNumTotal.Top = 0.0625F;
            this.txtSlipNumTotal.Width = 0.4375F;
            // 
            // label60
            // 
            this.label60.Border.BottomColor = System.Drawing.Color.Black;
            this.label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.LeftColor = System.Drawing.Color.Black;
            this.label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.RightColor = System.Drawing.Color.Black;
            this.label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.TopColor = System.Drawing.Color.Black;
            this.label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Height = 0.1875F;
            this.label60.HyperLink = null;
            this.label60.Left = 8.3125F;
            this.label60.MultiLine = false;
            this.label60.Name = "label60";
            this.label60.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label60.Text = "枚";
            this.label60.Top = 0.0625F;
            this.label60.Width = 0.25F;
            // 
            // textBox25
            // 
            this.textBox25.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.RightColor = System.Drawing.Color.Black;
            this.textBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.TopColor = System.Drawing.Color.Black;
            this.textBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Height = 0.188F;
            this.textBox25.Left = 8.625F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox25.SummaryGroup = "ExtraHeader";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox25.Text = "12,123,456,789";
            this.textBox25.Top = 0.0625F;
            this.textBox25.Width = 1F;
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
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.textBox44.Height = 0.188F;
            this.textBox44.Left = 9.75F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.SummaryGroup = "ExtraHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox44.Text = "123,456,789";
            this.textBox44.Top = 0.0625F;
            this.textBox44.Width = 0.8F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox23,
            this.CustomerName,
            this.textBox34,
            this.textBox33,
            this.textBox24,
            this.line6,
            this.textBox10,
            this.textBox14});
            this.TitleHeader.DataField = "SupplierSlipNo";
            this.TitleHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.TitleHeader.Height = 0.375F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
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
            this.textBox23.DataField = "SupplierSlipCd";
            this.textBox23.Height = 0.1875F;
            this.textBox23.Left = 6.0625F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "ゴシック; vertical-align: top; ";
            this.textBox23.Text = "ＮＮ";
            this.textBox23.Top = 0.0625F;
            this.textBox23.Width = 0.6875F;
            // 
            // CustomerName
            // 
            this.CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.DataField = "SupplierSnm";
            this.CustomerName.Height = 0.188F;
            this.CustomerName.Left = 0.5625F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Style = "color: Black; ddo-char-set: 1; font-size: 7pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.CustomerName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.CustomerName.Top = 0.0625F;
            this.CustomerName.Width = 2F;
            // 
            // textBox34
            // 
            this.textBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.RightColor = System.Drawing.Color.Black;
            this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.TopColor = System.Drawing.Color.Black;
            this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.DataField = "StockDate";
            this.textBox34.Height = 0.188F;
            this.textBox34.Left = 3.6875F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox34.Text = "2008/01/01";
            this.textBox34.Top = 0.0625F;
            this.textBox34.Width = 0.563F;
            // 
            // textBox33
            // 
            this.textBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.RightColor = System.Drawing.Color.Black;
            this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.TopColor = System.Drawing.Color.Black;
            this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.DataField = "InputDay";
            this.textBox33.Height = 0.188F;
            this.textBox33.Left = 2.5625F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox33.Text = "2008/11/05";
            this.textBox33.Top = 0.0625F;
            this.textBox33.Width = 0.563F;
            // 
            // textBox24
            // 
            this.textBox24.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.RightColor = System.Drawing.Color.Black;
            this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.TopColor = System.Drawing.Color.Black;
            this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.DataField = "SupplierCd";
            this.textBox24.Height = 0.188F;
            this.textBox24.Left = 0F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "ゴシック; vertical-align: top; ";
            this.textBox24.Text = "123456";
            this.textBox24.Top = 0.0625F;
            this.textBox24.Width = 0.56F;
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
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
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
            this.textBox10.DataField = "SupplierSlipNo";
            this.textBox10.Height = 0.1875F;
            this.textBox10.Left = 4.4375F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox10.Text = "123456789";
            this.textBox10.Top = 0.0625F;
            this.textBox10.Width = 0.625F;
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightColor = System.Drawing.Color.Black;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopColor = System.Drawing.Color.Black;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DataField = "SupplierSlipNote1";
            this.textBox14.Height = 0.1875F;
            this.textBox14.Left = 7.3125F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: ＭＳ " +
                "明朝; vertical-align: top; ";
            this.textBox14.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.textBox14.Top = 0.0625F;
            this.textBox14.Width = 2F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label26,
            this.txt_SlpConsTax,
            this.Title_SuppCTaxLayCd,
            this.Title_TaxationCode,
            this.textBox8,
            this.textBox5,
            this.textBox7});
            this.TitleFooter.Height = 0.7F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.BeforePrint += new System.EventHandler(this.TitleFooter_BeforePrint);
            // 
            // label26
            // 
            this.label26.Border.BottomColor = System.Drawing.Color.Black;
            this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.LeftColor = System.Drawing.Color.Black;
            this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.RightColor = System.Drawing.Color.Black;
            this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.TopColor = System.Drawing.Color.Black;
            this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Height = 0.1875F;
            this.label26.HyperLink = null;
            this.label26.Left = 7.9375F;
            this.label26.Name = "label26";
            this.label26.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label26.Text = "伝票計";
            this.label26.Top = 0.0625F;
            this.label26.Width = 0.5625F;
            // 
            // txt_SlpConsTax
            // 
            this.txt_SlpConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.txt_SlpConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_SlpConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.txt_SlpConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_SlpConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.txt_SlpConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_SlpConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.txt_SlpConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt_SlpConsTax.Height = 0.188F;
            this.txt_SlpConsTax.Left = 9.75F;
            this.txt_SlpConsTax.MultiLine = false;
            this.txt_SlpConsTax.Name = "txt_SlpConsTax";
            this.txt_SlpConsTax.OutputFormat = resources.GetString("txt_SlpConsTax.OutputFormat");
            this.txt_SlpConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.txt_SlpConsTax.Text = "123,456,789";
            this.txt_SlpConsTax.Top = 0.0625F;
            this.txt_SlpConsTax.Width = 0.8F;
            // 
            // Title_SuppCTaxLayCd
            // 
            this.Title_SuppCTaxLayCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Title_SuppCTaxLayCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_SuppCTaxLayCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Title_SuppCTaxLayCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_SuppCTaxLayCd.Border.RightColor = System.Drawing.Color.Black;
            this.Title_SuppCTaxLayCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_SuppCTaxLayCd.Border.TopColor = System.Drawing.Color.Black;
            this.Title_SuppCTaxLayCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_SuppCTaxLayCd.DataField = "SuppCTaxLayCd";
            this.Title_SuppCTaxLayCd.Height = 0.1875F;
            this.Title_SuppCTaxLayCd.Left = 0F;
            this.Title_SuppCTaxLayCd.MultiLine = false;
            this.Title_SuppCTaxLayCd.Name = "Title_SuppCTaxLayCd";
            this.Title_SuppCTaxLayCd.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Title_SuppCTaxLayCd.Text = null;
            this.Title_SuppCTaxLayCd.Top = 0.0625F;
            this.Title_SuppCTaxLayCd.Visible = false;
            this.Title_SuppCTaxLayCd.Width = 0.25F;
            // 
            // Title_TaxationCode
            // 
            this.Title_TaxationCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Title_TaxationCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_TaxationCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Title_TaxationCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_TaxationCode.Border.RightColor = System.Drawing.Color.Black;
            this.Title_TaxationCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_TaxationCode.Border.TopColor = System.Drawing.Color.Black;
            this.Title_TaxationCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Title_TaxationCode.DataField = "TaxationCode";
            this.Title_TaxationCode.Height = 0.1875F;
            this.Title_TaxationCode.Left = 0.3125F;
            this.Title_TaxationCode.MultiLine = false;
            this.Title_TaxationCode.Name = "Title_TaxationCode";
            this.Title_TaxationCode.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.Title_TaxationCode.Text = null;
            this.Title_TaxationCode.Top = 0.0625F;
            this.Title_TaxationCode.Visible = false;
            this.Title_TaxationCode.Width = 0.25F;
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
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 8.625F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "123,456,789";
            this.textBox8.Top = 0.0625F;
            this.textBox8.Width = 1F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "TaxationCode";
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 0.3125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox5.Text = null;
            this.textBox5.Top = 0.0625F;
            this.textBox5.Visible = false;
            this.textBox5.Width = 0.25F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.DataField = "SuppCTaxLayCd";
            this.textBox7.Height = 0.1875F;
            this.textBox7.Left = 0F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox7.Text = null;
            this.textBox7.Top = 0.0625F;
            this.textBox7.Visible = false;
            this.textBox7.Width = 0.25F;
            // 
            // SortDiv1Header
            // 
            this.SortDiv1Header.CanShrink = true;
            this.SortDiv1Header.DataField = "SupplierCd";
            this.SortDiv1Header.Height = 0F;
            this.SortDiv1Header.Name = "SortDiv1Header";
            // 
            // SortDiv1Footer
            // 
            this.SortDiv1Footer.CanShrink = true;
            this.SortDiv1Footer.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSort1_Title,
            this.line10,
            this.textBox46,
            this.textBox6,
            this.textBox2,
            this.label8,
            this.line3});
            this.SortDiv1Footer.Height = 0.325F;
            this.SortDiv1Footer.KeepTogether = true;
            this.SortDiv1Footer.Name = "SortDiv1Footer";
            this.SortDiv1Footer.Format += new System.EventHandler(this.SortDiv1Footer_Format);
            // 
            // txtSort1_Title
            // 
            this.txtSort1_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Border.RightColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Border.TopColor = System.Drawing.Color.Black;
            this.txtSort1_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSort1_Title.Height = 0.188F;
            this.txtSort1_Title.Left = 6.6875F;
            this.txtSort1_Title.MultiLine = false;
            this.txtSort1_Title.Name = "txtSort1_Title";
            this.txtSort1_Title.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.txtSort1_Title.Text = "仕入先計";
            this.txtSort1_Title.Top = 0.0625F;
            this.txtSort1_Title.Width = 0.7F;
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
            this.line10.Height = 0F;
            this.line10.Left = 0F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 10.8125F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.8125F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
            // 
            // textBox46
            // 
            this.textBox46.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.RightColor = System.Drawing.Color.Black;
            this.textBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.TopColor = System.Drawing.Color.Black;
            this.textBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Height = 0.188F;
            this.textBox46.Left = 8.625F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryGroup = "SortDiv1Header";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "12,123,456,789";
            this.textBox46.Top = 0.0625F;
            this.textBox46.Width = 1F;
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
            this.textBox6.Height = 0.188F;
            this.textBox6.Left = 9.75F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.SummaryGroup = "SortDiv1Header";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "123,456,789";
            this.textBox6.Top = 0.0625F;
            this.textBox6.Width = 0.8F;
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
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 7.9375F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryGroup = "SortDiv1Header";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "9,999";
            this.textBox2.Top = 0.0625F;
            this.textBox2.Width = 0.4375F;
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
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = null;
            this.label8.Left = 8.3125F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label8.Text = "枚";
            this.label8.Top = 0.0625F;
            this.label8.Width = 0.25F;
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
            this.line3.Width = 10.75F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.75F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox27,
            this.textBox28,
            this.label1,
            this.line4});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.31F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.label1.Height = 0.188F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label1.Text = "拠点";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.3F;
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
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.textBox39,
            this.label46,
            this.textBox64,
            this.textBox40,
            this.textBox1});
            this.SectionFooter.Height = 0.325F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            // 
            // Line45
            // 
            this.Line45.Border.BottomColor = System.Drawing.Color.Black;
            this.Line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.LeftColor = System.Drawing.Color.Black;
            this.Line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.RightColor = System.Drawing.Color.Black;
            this.Line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.TopColor = System.Drawing.Color.Black;
            this.Line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Height = 0F;
            this.Line45.Left = 0F;
            this.Line45.LineWeight = 2F;
            this.Line45.Name = "Line45";
            this.Line45.Top = 0F;
            this.Line45.Width = 10.8125F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8125F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // textBox39
            // 
            this.textBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.RightColor = System.Drawing.Color.Black;
            this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.TopColor = System.Drawing.Color.Black;
            this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Height = 0.188F;
            this.textBox39.Left = 6.6875F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; vertical-align: top; ";
            this.textBox39.Text = "拠点計";
            this.textBox39.Top = 0.0625F;
            this.textBox39.Width = 0.7F;
            // 
            // label46
            // 
            this.label46.Border.BottomColor = System.Drawing.Color.Black;
            this.label46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.LeftColor = System.Drawing.Color.Black;
            this.label46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.RightColor = System.Drawing.Color.Black;
            this.label46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Border.TopColor = System.Drawing.Color.Black;
            this.label46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label46.Height = 0.19F;
            this.label46.HyperLink = null;
            this.label46.Left = 8.3125F;
            this.label46.MultiLine = false;
            this.label46.Name = "label46";
            this.label46.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: top; ";
            this.label46.Text = "枚";
            this.label46.Top = 0.0625F;
            this.label46.Width = 0.25F;
            // 
            // textBox64
            // 
            this.textBox64.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.RightColor = System.Drawing.Color.Black;
            this.textBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.TopColor = System.Drawing.Color.Black;
            this.textBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Height = 0.188F;
            this.textBox64.Left = 8.625F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.SummaryGroup = "SectionHeader";
            this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox64.Text = "12,123,456,789";
            this.textBox64.Top = 0.0625F;
            this.textBox64.Width = 1F;
            // 
            // textBox40
            // 
            this.textBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.RightColor = System.Drawing.Color.Black;
            this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.TopColor = System.Drawing.Color.Black;
            this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Height = 0.188F;
            this.textBox40.Left = 9.75F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.SummaryGroup = "SectionHeader";
            this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox40.Text = "123,456,789";
            this.textBox40.Top = 0.0625F;
            this.textBox40.Width = 0.8F;
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
            this.textBox1.Left = 7.9375F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox1.SummaryGroup = "SectionHeader";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox1.Text = "1,234";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.4375F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Visible = false;
            // 
            // reportFooter1
            // 
            this.reportFooter1.CanShrink = true;
            this.reportFooter1.Height = 0F;
            this.reportFooter1.KeepTogether = true;
            this.reportFooter1.Name = "reportFooter1";
            this.reportFooter1.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ListTitle_Title,
            this.Label3,
            this.PrintDate,
            this.Label2,
            this.PRINTPAGE,
            this.Line1,
            this.PrintTime});
            this.PageHeader.Height = 0.2604167F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // ListTitle_Title
            // 
            this.ListTitle_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ListTitle_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListTitle_Title.DataField = "ListTitle";
            this.ListTitle_Title.Height = 0.21875F;
            this.ListTitle_Title.HyperLink = "";
            this.ListTitle_Title.Left = 0.25F;
            this.ListTitle_Title.MultiLine = false;
            this.ListTitle_Title.Name = "ListTitle_Title";
            this.ListTitle_Title.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.ListTitle_Title.Text = "仕入返品予定一覧表";
            this.ListTitle_Title.Top = 0F;
            this.ListTitle_Title.Width = 2.09375F;
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
            // PrintDate
            // 
            this.PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.CanShrink = true;
            this.PrintDate.Height = 0.15625F;
            this.PrintDate.Left = 8.5F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate.Text = "平成17年11月 5日";
            this.PrintDate.Top = 0.0625F;
            this.PrintDate.Width = 0.9375F;
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
            // PRINTPAGE
            // 
            this.PRINTPAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PRINTPAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PRINTPAGE.CanShrink = true;
            this.PRINTPAGE.Height = 0.15625F;
            this.PRINTPAGE.Left = 10.4375F;
            this.PRINTPAGE.MultiLine = false;
            this.PRINTPAGE.Name = "PRINTPAGE";
            this.PRINTPAGE.OutputFormat = resources.GetString("PRINTPAGE.OutputFormat");
            this.PRINTPAGE.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PRINTPAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PRINTPAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PRINTPAGE.Text = "123";
            this.PRINTPAGE.Top = 0.0625F;
            this.PRINTPAGE.Width = 0.28125F;
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
            this.Line1.Top = 0.22F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.22F;
            this.Line1.Y2 = 0.22F;
            // 
            // PrintTime
            // 
            this.PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Height = 0.125F;
            this.PrintTime.Left = 9.4375F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11時20分";
            this.PrintTime.Top = 0.0625F;
            this.PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line17,
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // line17
            // 
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0F;
            this.line17.Left = 0F;
            this.line17.LineWeight = 2F;
            this.line17.Name = "line17";
            this.line17.Top = 0F;
            this.line17.Visible = false;
            this.line17.Width = 10.8125F;
            this.line17.X1 = 0F;
            this.line17.X2 = 10.8125F;
            this.line17.Y1 = 0F;
            this.line17.Y2 = 0F;
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
            this.Footer_SubReport.Width = 11.3125F;
            // 
            // PMKAK02033P_01A4C
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
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SortDiv1Header);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.SortDiv1Footer);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMKAK02033P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnedGoodsTypeRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DtlConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_SuppCTaxLayCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_TaxationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipNumTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SlpConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title_SuppCTaxLayCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title_TaxationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSort1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTitle_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRINTPAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

    }
}
