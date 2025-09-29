//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：前年対比表
// プログラム概要   ：前年対比表を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/11/25     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/16     修正内容：Mantis【13129】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野
// 修正日    2009/05/14     修正内容：Mantis【13281】
// ---------------------------------------------------------------------//
// 管理番号  11170129-00    改修担当 : cheq
// 作 成 日  2015/08/17     修正内容 : 障害対応　RedMine#47029 比率算出不正の対応
//----------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

using System.Collections.Generic;



namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 前年対比表帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note : 2015/08/17 cheq </br>
    /// <br>管理番号    : 11170129-00</br>
    /// <br>            : redmine#47029 比率算出不正の対応</br>
    /// </remarks>
    public class DCTOK02092P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {
        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DCTOK02092P_01A4C()
        {
            InitializeComponent();
        }
        #endregion

        //================================================================================
        //  内部変数
        //================================================================================
        #region private member

        // 拠点表示有無
        private bool _isSection;

        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;

        // ソート順タイトル
        private string _pageHeaderSortOderTitle;

        //SUBTITLE
        private string _pageHeaderSubtitle;

        // 抽出条件印字項目
        private StringCollection _extraConditions;

        // フッター出力有無
        private int _pageFooterOutCode;

        // フッタメッセージ1
        private StringCollection _pageFooters;

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 印刷条件
        private ExtrInfo_DCTOK02093E _extraInfo;

        // 関連データオブジェクト
        private ArrayList _otherDataList;

        // 出力用DataSet
        DataSet outputDs;

        // Detial区切り線出力判定
        bool lineOutput = false;

        #region  背景透かしモード(無し)
        private int _watermarkMode = 0;
        private DataDynamics.ActiveReports.TextBox DATE;
        private DataDynamics.ActiveReports.TextBox TIME;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Label lblPage;
        private DataDynamics.ActiveReports.TextBox txtPageNo;
        private Line line1;
        private GroupHeader TitleHeader1;
        private GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.TextBox ChangeDF_Name1;
        private DataDynamics.ActiveReports.TextBox txtTHCode1;
        private Line line28;
        private ReportHeader reportHeader1;
        private ReportFooter reportFooter1;
        private Line line46;
        private Line line2;
        private DataDynamics.ActiveReports.Label label40;
        #endregion

        #region DataDynamics.ActiveReports...
        private DataDynamics.ActiveReports.Label SUBTITLE;
        private DataDynamics.ActiveReports.TextBox Extraction;
        private DataDynamics.ActiveReports.TextBox SORTTITLE;
        private Line line5;
        private DataDynamics.ActiveReports.TextBox txtTHName1;
        private DataDynamics.ActiveReports.TextBox ChangeDF_Code1;
        private DataDynamics.ActiveReports.TextBox txtTTermSales1;
        private DataDynamics.ActiveReports.TextBox txtTTermSales2;
        private DataDynamics.ActiveReports.TextBox txtTTermSales3;
        private DataDynamics.ActiveReports.TextBox txtTTermSales4;
        private DataDynamics.ActiveReports.TextBox txtTTermSales5;
        private DataDynamics.ActiveReports.TextBox txtTTermSales6;
        private DataDynamics.ActiveReports.TextBox txtTTermSales7;
        private DataDynamics.ActiveReports.TextBox txtTTermSales8;
        private DataDynamics.ActiveReports.TextBox txtTTermSales9;
        private DataDynamics.ActiveReports.TextBox txtTTermSales10;
        private DataDynamics.ActiveReports.TextBox txtTTermSales11;
        private DataDynamics.ActiveReports.TextBox txtTTermSales12;
        private DataDynamics.ActiveReports.TextBox txtTTermTotalSales;
        private DataDynamics.ActiveReports.TextBox txtFTermSales1;
        private DataDynamics.ActiveReports.TextBox txtFTermSales2;
        private DataDynamics.ActiveReports.TextBox txtFTermSales3;
        private DataDynamics.ActiveReports.TextBox txtFTermSales4;
        private DataDynamics.ActiveReports.TextBox txtFTermSales5;
        private DataDynamics.ActiveReports.TextBox txtFTermSales6;
        private DataDynamics.ActiveReports.TextBox txtFTermSales7;
        private DataDynamics.ActiveReports.TextBox txtFTermSales8;
        private DataDynamics.ActiveReports.TextBox txtFTermSales9;
        private DataDynamics.ActiveReports.TextBox txtFTermSales10;
        private DataDynamics.ActiveReports.TextBox txtFTermSales11;
        private DataDynamics.ActiveReports.TextBox txtFTermSales12;
        private DataDynamics.ActiveReports.TextBox txtFTermTotalSales;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio1;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio2;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio3;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio4;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio5;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio6;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio7;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio8;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio9;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio10;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio11;
        private DataDynamics.ActiveReports.TextBox txtSalesRatio12;
        private DataDynamics.ActiveReports.TextBox txtTotalSalesRatio;
        private DataDynamics.ActiveReports.TextBox txtTTermGross1;
        private DataDynamics.ActiveReports.TextBox txtTTermGross2;
        private DataDynamics.ActiveReports.TextBox txtTTermGross3;
        private DataDynamics.ActiveReports.TextBox txtTTermGross4;
        private DataDynamics.ActiveReports.TextBox txtTTermGross5;
        private DataDynamics.ActiveReports.TextBox txtTTermGross6;
        private DataDynamics.ActiveReports.TextBox txtTTermGross7;
        private DataDynamics.ActiveReports.TextBox txtTTermGross8;
        private DataDynamics.ActiveReports.TextBox txtTTermGross9;
        private DataDynamics.ActiveReports.TextBox txtTTermGross10;
        private DataDynamics.ActiveReports.TextBox txtTTermGross11;
        private DataDynamics.ActiveReports.TextBox txtTTermGross12;
        private DataDynamics.ActiveReports.TextBox txtTTermTotalGross;
        private DataDynamics.ActiveReports.TextBox txtFTermGross1;
        private DataDynamics.ActiveReports.TextBox txtFTermGross2;
        private DataDynamics.ActiveReports.TextBox txtFTermGross3;
        private DataDynamics.ActiveReports.TextBox txtFTermGross4;
        private DataDynamics.ActiveReports.TextBox txtFTermGross5;
        private DataDynamics.ActiveReports.TextBox txtFTermGross6;
        private DataDynamics.ActiveReports.TextBox txtFTermGross7;
        private DataDynamics.ActiveReports.TextBox txtFTermGross8;
        private DataDynamics.ActiveReports.TextBox txtFTermGross9;
        private DataDynamics.ActiveReports.TextBox txtFTermGross10;
        private DataDynamics.ActiveReports.TextBox txtFTermGross11;
        private DataDynamics.ActiveReports.TextBox txtFTermGross12;
        private DataDynamics.ActiveReports.TextBox txtFTermTotalGross;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio1;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio2;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio3;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio4;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio5;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio6;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio7;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio8;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio9;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio10;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio11;
        private DataDynamics.ActiveReports.TextBox txtGrossRatio12;
        private DataDynamics.ActiveReports.TextBox txtTotalGrossRatio;
        private DataDynamics.ActiveReports.Label month1;
        private DataDynamics.ActiveReports.Label month2;
        private DataDynamics.ActiveReports.Label month3;
        private DataDynamics.ActiveReports.Label month4;
        private DataDynamics.ActiveReports.Label month5;
        private DataDynamics.ActiveReports.Label month6;
        private DataDynamics.ActiveReports.Label month7;
        private DataDynamics.ActiveReports.Label month8;
        private DataDynamics.ActiveReports.Label month9;
        private DataDynamics.ActiveReports.Label month10;
        private DataDynamics.ActiveReports.Label month11;
        private DataDynamics.ActiveReports.Label month12;
        private DataDynamics.ActiveReports.Label label1;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private Label lbTitleTTermSl;
        private Label lbTitleFTermSl;
        private Label lbTitleSlRatio;
        private Label lbTitleTTermGrs;
        private Label lbTitleFTermGrs;
        private Label lbTitleGrsRatio;
        private Line line_Hight;
        private TextBox txtSubSecTSales1;
        private TextBox txtSubSecTSales2;
        private TextBox txtSubSecTSales3;
        private TextBox txtSubSecTSales4;
        private TextBox txtSubSecTSales5;
        private TextBox txtSubSecTSales6;
        private TextBox txtSubSecTSales7;
        private TextBox txtSubSecTSales8;
        private TextBox txtSubSecTSales9;
        private TextBox txtSubSecTSales10;
        private TextBox txtSubSecTSales11;
        private TextBox txtSubSecTSales12;
        private TextBox txtSubSecTTotalSales;
        private TextBox txtSubSecFSales1;
        private TextBox txtSubSecFSales2;
        private TextBox txtSubSecFSales3;
        private TextBox txtSubSecFSales4;
        private TextBox txtSubSecFSales5;
        private TextBox txtSubSecFSales6;
        private TextBox txtSubSecFSales7;
        private TextBox txtSubSecFSales8;
        private TextBox txtSubSecFSales9;
        private TextBox txtSubSecFSales10;
        private TextBox txtSubSecFSales11;
        private TextBox txtSubSecFSales12;
        private TextBox txtSubSecFTotalSales;
        private TextBox txtSubSecSalesRt1;
        private TextBox txtSubSecSalesRt2;
        private TextBox txtSubSecSalesRt3;
        private TextBox txtSubSecSalesRt4;
        private TextBox txtSubSecSalesRt5;
        private TextBox txtSubSecSalesRt6;
        private TextBox txtSubSecSalesRt7;
        private TextBox txtSubSecSalesRt8;
        private TextBox txtSubSecSalesRt9;
        private TextBox txtSubSecSalesRt10;
        private TextBox txtSubSecSalesRt11;
        private TextBox txtSubSecSalesRt12;
        private TextBox txtSubSecTotalSalesRt;
        private TextBox txtSubSecTGross1;
        private TextBox txtSubSecTGross2;
        private TextBox txtSubSecTGross3;
        private TextBox txtSubSecTGross4;
        private TextBox txtSubSecTGross5;
        private TextBox txtSubSecTGross6;
        private TextBox txtSubSecTGross7;
        private TextBox txtSubSecTGross8;
        private TextBox txtSubSecTGross9;
        private TextBox txtSubSecTGross10;
        private TextBox txtSubSecTGross11;
        private TextBox txtSubSecTGross12;
        private TextBox txtSubSecTTotalGross;
        private TextBox txtSubSecFGross1;
        private TextBox txtSubSecFGross2;
        private TextBox txtSubSecFGross3;
        private TextBox txtSubSecFGross4;
        private TextBox txtSubSecFGross5;
        private TextBox txtSubSecFGross6;
        private TextBox txtSubSecFGross7;
        private TextBox txtSubSecFGross8;
        private TextBox txtSubSecFGross9;
        private TextBox txtSubSecFGross10;
        private TextBox txtSubSecFGross11;
        private TextBox txtSubSecFGross12;
        private TextBox txtSubSecFTotalGross;
        private TextBox txtSubSecGrossRt1;
        private TextBox txtSubSecGrossRt2;
        private TextBox txtSubSecGrossRt3;
        private TextBox txtSubSecGrossRt4;
        private TextBox txtSubSecGrossRt5;
        private TextBox txtSubSecGrossRt6;
        private TextBox txtSubSecGrossRt7;
        private TextBox txtSubSecGrossRt8;
        private TextBox txtSubSecGrossRt9;
        private TextBox txtSubSecGrossRt10;
        private TextBox txtSubSecGrossRt11;
        private TextBox txtSubSecGrossRt12;
        private TextBox txtSubSecTotalGrossRt;
        private TextBox txtSubTitle;
        private Label lbTitleSubSecTSl;
        private Label lbTitleSubSecFSl;
        private Label lbTitleSubSecSlRt;
        private Label lbTitleSubSecTGrs;
        private Label lbTitleSubSecFGrs;
        private Label lbTitleSubSecGrsRt;
        private Line line4;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private TextBox txtSecTSales1;
        private TextBox txtSecTSales2;
        private TextBox txtSecTSales3;
        private TextBox txtSecTSales4;
        private TextBox txtSecTSales5;
        private TextBox txtSecTSales6;
        private TextBox txtSecTSales7;
        private TextBox txtSecTSales8;
        private TextBox txtSecTSales9;
        private TextBox txtSecTSales10;
        private TextBox txtSecTSales11;
        private TextBox txtSecTSales12;
        private TextBox txtSecTTotalSales;
        private TextBox txtSecFSales1;
        private TextBox txtSecFSales2;
        private TextBox txtSecFSales3;
        private TextBox txtSecFSales4;
        private TextBox txtSecFSales5;
        private TextBox txtSecFSales6;
        private TextBox txtSecFSales7;
        private TextBox txtSecFSales8;
        private TextBox txtSecFSales9;
        private TextBox txtSecFSales10;
        private TextBox txtSecFSales11;
        private TextBox txtSecFSales12;
        private TextBox txtSecFTotalSales;
        private TextBox txtSecSalesRt1;
        private TextBox txtSecSalesRt2;
        private TextBox txtSecSalesRt3;
        private TextBox txtSecSalesRt4;
        private TextBox txtSecSalesRt5;
        private TextBox txtSecSalesRt6;
        private TextBox txtSecSalesRt7;
        private TextBox txtSecSalesRt8;
        private TextBox txtSecSalesRt9;
        private TextBox txtSecSalesRt10;
        private TextBox txtSecSalesRt11;
        private TextBox txtSecSalesRt12;
        private TextBox txtSecTotalSalesRt;
        private TextBox txtSecTGross1;
        private TextBox txtSecTGross2;
        private TextBox txtSecTGross3;
        private TextBox txtSecTGross4;
        private TextBox txtSecTGross5;
        private TextBox txtSecTGross6;
        private TextBox txtSecTGross7;
        private TextBox txtSecTGross8;
        private TextBox txtSecTGross9;
        private TextBox txtSecTGross10;
        private TextBox txtSecTGross11;
        private TextBox txtSecTGross12;
        private TextBox txtSecTTotalGross;
        private TextBox txtSecFGross1;
        private TextBox txtSecFGross2;
        private TextBox txtSecFGross3;
        private TextBox txtSecFGross4;
        private TextBox txtSecFGross5;
        private TextBox txtSecFGross6;
        private TextBox txtSecFGross7;
        private TextBox txtSecFGross8;
        private TextBox txtSecFGross9;
        private TextBox txtSecFGross10;
        private TextBox txtSecFGross11;
        private TextBox txtSecFGross12;
        private TextBox txtSecFTotalGross;
        private TextBox txtSecGrossRt1;
        private TextBox txtSecGrossRt2;
        private TextBox txtSecGrossRt3;
        private TextBox txtSecGrossRt4;
        private TextBox txtSecGrossRt5;
        private TextBox txtSecGrossRt6;
        private TextBox txtSecGrossRt7;
        private TextBox txtSecGrossRt8;
        private TextBox txtSecGrossRt9;
        private TextBox txtSecGrossRt10;
        private TextBox txtSecGrossRt11;
        private TextBox txtSecGrossRt12;
        private TextBox txtSecTotalGrossRt;
        private TextBox textBox116;
        private Label lbTitleSecTSl;
        private Label lbTitleSecFSl;
        private Label lbTitleSecSlRt;
        private Label lbTitleSecTGrs;
        private Label lbTitleSecFGrs;
        private Label lbTitleSecGrsRt;
        private Line line6;
        private GroupHeader SubSectionHeader;
        private GroupFooter SubSectionFooter;

        private Label lbTitleSl;
        private Label lbTitleGrs;
        private TextBox txtName;
        private TextBox txtCode;
        private Label lbTitleTSl;
        private Label lbTitleTGrs;
        private Label lbTitleSSl;
        private Label lbTitleSGrs;
        private Line line7;
        private Line line8;
        private Line line9;
        private TextBox txtTHTitle;
        #endregion
        private TextBox txtDFTitle;
        private TextBox txtTTSales1;
        private TextBox txtTTSales2;
        private TextBox txtTTSales3;
        private TextBox txtTTSales4;
        private TextBox txtTTSales5;
        private TextBox txtTTSales6;
        private TextBox txtTTSales7;
        private TextBox txtTTSales8;
        private TextBox txtTTSales9;
        private TextBox txtTTSales10;
        private TextBox txtTTSales11;
        private TextBox txtTTSales12;
        private TextBox txtTTTotalSales;
        private TextBox txtTFSales1;
        private TextBox txtTFSales2;
        private TextBox txtTFSales3;
        private TextBox txtTFSales4;
        private TextBox txtTFSales5;
        private TextBox txtTFSales6;
        private TextBox txtTFSales7;
        private TextBox txtTFSales8;
        private TextBox txtTFSales9;
        private TextBox txtTFSales10;
        private TextBox txtTFSales11;
        private TextBox txtTFSales12;
        private TextBox txtTFTotalSales;
        private TextBox txtTSalesRt1;
        private TextBox txtTSalesRt2;
        private TextBox txtTSalesRt3;
        private TextBox txtTSalesRt4;
        private TextBox txtTSalesRt5;
        private TextBox txtTSalesRt6;
        private TextBox txtTSalesRt7;
        private TextBox txtTSalesRt8;
        private TextBox txtTSalesRt9;
        private TextBox txtTSalesRt10;
        private TextBox txtTSalesRt11;
        private TextBox txtTSalesRt12;
        private TextBox txtTTotalSalesRt;
        private TextBox txtTTGross1;
        private TextBox txtTTGross2;
        private TextBox txtTTGross3;
        private TextBox txtTTGross4;
        private TextBox txtTTGross5;
        private TextBox txtTTGross6;
        private TextBox txtTTGross7;
        private TextBox txtTTGross8;
        private TextBox txtTTGross9;
        private TextBox txtTTGross10;
        private TextBox txtTTGross11;
        private TextBox txtTTGross12;
        private TextBox txtTTTotalGross;
        private TextBox txtTFGross1;
        private TextBox txtTFGross2;
        private TextBox txtTFGross3;
        private TextBox txtTFGross4;
        private TextBox txtTFGross5;
        private TextBox txtTFGross6;
        private TextBox txtTFGross7;
        private TextBox txtTFGross8;
        private TextBox txtTFGross9;
        private TextBox txtTFGross10;
        private TextBox txtTFGross11;
        private TextBox txtTFGross12;
        private TextBox txtTFTotalGross;
        private TextBox txtTGrossRt1;
        private TextBox txtTGrossRt2;
        private TextBox txtTGrossRt3;
        private TextBox txtTGrossRt4;
        private TextBox txtTGrossRt5;
        private TextBox txtTGrossRt6;
        private TextBox txtTGrossRt7;
        private TextBox txtTGrossRt8;
        private TextBox txtTGrossRt9;
        private TextBox txtTGrossRt10;
        private TextBox txtTGrossRt11;
        private TextBox txtTGrossRt12;
        private TextBox txtTTotalGrossRt;
        private TextBox textBox120;
        private Label lbTitleTTSl;
        private Label lbTitleTFSl;
        private Label lbTitleTSlRt;
        private Label lbTitleTTGrs;
        private Label lbTitleTFGrs;
        private Label lbTitleTGrsRt;
        private Line line3;
        private Label lbTitleToTSl;
        private Label lbTitleToTGrs;
        private TextBox textBox1;
        private TextBox textBox2;
        private SubReport Footer_SubReport;

        //TODO 2:TODO1関連
        //印刷件数
        private int _printCount = 1;

        #endregion

        //================================================================================
        //  プロパティ
        //================================================================================
        #region public property
        #region IPrintActiveReportTypeList メンバ
        /// <summary>
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary>
        /// SUBTITLE
        /// </summary>
        public string PageHeaderSubtitle
        {
            set
            {
                this._pageHeaderSubtitle = value;
            }
        }

        /// <summary>
        /// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// 抽出条件ヘッダー項目
        /// </summary>
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }


        /// <summary>
        /// フッター出力区分
        /// </summary>
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary>
        /// フッタ出力文
        /// </summary>
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this.outputDs = (DataSet)this._printInfo.rdData;
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
                    if (this._otherDataList.Count > 0)
                    {
                        this._isSection = (bool)this._otherDataList[0];
                    }
                }
            }
        }

        #endregion

        #region IPrintActiveReportTypeCommon メンバ
        //TODO 4:TODO1関連
        /// <summary>プログレスバーカウントアップイベント</summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }
        #endregion
        #endregion

        //================================================================================
        //  イベント
        //================================================================================
        #region event
        /// <summary>
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
        /// </remarks>
        private void DCTOK02092P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // 条件取得
            this._extraInfo = (ExtrInfo_DCTOK02093E)this._printInfo.jyoken;

            //TODO 3:TODO1関連
            // 印刷件数初期化
            this._printCount = 0;

            // 罫線表示・非表示制御
            foreach (Section section in this.Sections)
            {
                Section targetSection = section;
            }

            //全体設定切替
            this.ChangeofAllReport();

            // 帳票タイプ別切替
            this.ChangeOfGroupHeader1();

        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            //SUBTITLE
            this.SUBTITLE.Text = this._pageHeaderSubtitle;

            // ソート順
            this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

            // 作成日付
            DateTime now = DateTime.Now;
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);

            // 『抽出条件』
            this.Extraction.Text = "";
            for (int i = 0; i < this._extraConditions.Count; i++)
            {
                if (i != 0)
                {
                    this.Extraction.Text += System.Environment.NewLine;
                }
                this.Extraction.Text += this._extraConditions[i];
            }

            // TitleHeader1と重なる部分の区切り線を非表示にする。
            if (lineOutput == false)
            {
                //line_Hight.Visible = false;
            }

            // 月範囲印字設定
            this.SetOfMonthAmbitOutput();

            // 区切り線を表示
            lineOutput = true;
        }

        /// <summary>
        /// ページフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {

            // 明細区切り線を非表示 
            lineOutput = false;

            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッターレポート作成
                ListCommon_PageFooter rpt = new ListCommon_PageFooter();

                // 2009.03.17 30413 犬飼 フッター部の印字変更 >>>>>>START
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
                // 2009.03.17 30413 犬飼 フッター部の印字変更 <<<<<<END
            }
        }

        /// <summary>
        /// 明細フォーマットイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>

        private void Detail_Format(object sender, EventArgs e)
        {
            if (lineOutput == true)
            {
                // Detialの区切り線を表示
                line_Hight.Visible = true;
            }

            this.DetialItem_Event();
            
            if (this.txtName.Text != "全社集計" &&
                this.txtCode.Text.Replace('0', ' ').Trim().Equals(string.Empty))
            {
                this.txtCode.Text = "";
            }
        }

        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2007.12.03</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            //TODO 1：Debugの時だけエラーが出る
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// グループフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
        private void SubSectionFooter_Format(object sender, EventArgs e)
        {
            this.SubSectionItem_Event();
        }

        /// <summary>
        /// セクションフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, System.EventArgs eArgs)
        {
            this.SectionItem_Event();
        }

        /* ---DEL 2009/01/30 不具合対応[9841] レポートフッターからタイトルフッターへ総合計を移動の為---------->>>>>
        /// <summary>
        /// レポートフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private void reportFooter1_Format(object sender, EventArgs e)
        {
            this.TotalItem_Event();
        }
           ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------------------------------<<<<< */
        // ---ADD 2009/01/30 不具合対応[9841] ---------------------------------------------------------------->>>>>
        /// <summary>
        /// タイトルフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : タイトルのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 照田 貴志</br>
        /// <br>Date        : 2009/01/30</br>
        /// </remarks>
        private void TitleFooter_Format(object sender, EventArgs e)
        {
            this.TotalItem_Event();
        }
        // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------------------------------<<<<<
        #endregion	event

        // ===============================================================================
        // ActiveReportsデザイナで生成されたコード
        // ===============================================================================
        #region ActiveReportsデザイナで生成されたコード

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        /// <summary>
        /// 
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02092P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtTTermSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSalesRatio12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTermTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTermTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio1 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio2 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio3 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio4 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio5 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio6 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio7 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio8 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio9 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio10 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio11 = new DataDynamics.ActiveReports.TextBox();
            this.txtGrossRatio12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalGrossRatio = new DataDynamics.ActiveReports.TextBox();
            this.lbTitleTTermSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleFTermSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleSlRatio = new DataDynamics.ActiveReports.Label();
            this.lbTitleTTermGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleFTermGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleGrsRatio = new DataDynamics.ActiveReports.Label();
            this.lbTitleSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleGrs = new DataDynamics.ActiveReports.Label();
            this.txtName = new DataDynamics.ActiveReports.TextBox();
            this.txtCode = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.txtTHCode1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTHName1 = new DataDynamics.ActiveReports.TextBox();
            this.ChangeDF_Code1 = new DataDynamics.ActiveReports.TextBox();
            this.ChangeDF_Name1 = new DataDynamics.ActiveReports.TextBox();
            this.line_Hight = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.lblPage = new DataDynamics.ActiveReports.Label();
            this.txtPageNo = new DataDynamics.ActiveReports.TextBox();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.line28 = new DataDynamics.ActiveReports.Line();
            this.line46 = new DataDynamics.ActiveReports.Line();
            this.SUBTITLE = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Extraction = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.month1 = new DataDynamics.ActiveReports.Label();
            this.month2 = new DataDynamics.ActiveReports.Label();
            this.month3 = new DataDynamics.ActiveReports.Label();
            this.month4 = new DataDynamics.ActiveReports.Label();
            this.month5 = new DataDynamics.ActiveReports.Label();
            this.month6 = new DataDynamics.ActiveReports.Label();
            this.month7 = new DataDynamics.ActiveReports.Label();
            this.month8 = new DataDynamics.ActiveReports.Label();
            this.month9 = new DataDynamics.ActiveReports.Label();
            this.month10 = new DataDynamics.ActiveReports.Label();
            this.month11 = new DataDynamics.ActiveReports.Label();
            this.month12 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.txtTTSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTSalesRt12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTotalSalesRt = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTFTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt1 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt2 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt3 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt4 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt5 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt6 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt7 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt8 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt9 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt10 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt11 = new DataDynamics.ActiveReports.TextBox();
            this.txtTGrossRt12 = new DataDynamics.ActiveReports.TextBox();
            this.txtTTotalGrossRt = new DataDynamics.ActiveReports.TextBox();
            this.textBox120 = new DataDynamics.ActiveReports.TextBox();
            this.lbTitleTTSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleTFSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleTSlRt = new DataDynamics.ActiveReports.Label();
            this.lbTitleTTGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleTFGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleTGrsRt = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.lbTitleToTSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleToTGrs = new DataDynamics.ActiveReports.Label();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.txtTHTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtDFTitle = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.txtSubSecTSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecSalesRt12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTotalSalesRt = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecFTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecGrossRt12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSubSecTotalGrossRt = new DataDynamics.ActiveReports.TextBox();
            this.txtSubTitle = new DataDynamics.ActiveReports.TextBox();
            this.lbTitleSubSecTSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleSubSecFSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleSubSecSlRt = new DataDynamics.ActiveReports.Label();
            this.lbTitleSubSecTGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleSubSecFGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleSubSecGrsRt = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.txtSecTSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFSales12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFTotalSales = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecSalesRt12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTotalSalesRt = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFGross12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecFTotalGross = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt1 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt2 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt3 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt4 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt5 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt6 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt7 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt8 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt9 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt10 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt11 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecGrossRt12 = new DataDynamics.ActiveReports.TextBox();
            this.txtSecTotalGrossRt = new DataDynamics.ActiveReports.TextBox();
            this.textBox116 = new DataDynamics.ActiveReports.TextBox();
            this.lbTitleSecTSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleSecFSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleSecSlRt = new DataDynamics.ActiveReports.Label();
            this.lbTitleSecTGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleSecFGrs = new DataDynamics.ActiveReports.Label();
            this.lbTitleSecGrsRt = new DataDynamics.ActiveReports.Label();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.lbTitleSSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleSGrs = new DataDynamics.ActiveReports.Label();
            this.SubSectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.SubSectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.lbTitleTSl = new DataDynamics.ActiveReports.Label();
            this.lbTitleTGrs = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalGrossRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTermSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleFTermSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSlRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTermGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleFTermGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleGrsRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeDF_Code1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeDF_Name1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SUBTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.month12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTotalSalesRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTotalGrossRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTFSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTSlRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTFGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTGrsRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleToTSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleToTGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTotalSalesRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTotalGrossRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecTSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecFSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecSlRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecTGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecFGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecGrsRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFTotalSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTotalSalesRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFTotalGross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTotalGrossRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecTSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecFSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecSlRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecTGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecFGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecGrsRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTGrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanGrow = false;
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTTermSales1,
            this.txtTTermSales2,
            this.txtTTermSales3,
            this.txtTTermSales4,
            this.txtTTermSales5,
            this.txtTTermSales6,
            this.txtTTermSales7,
            this.txtTTermSales8,
            this.txtTTermSales9,
            this.txtTTermSales10,
            this.txtTTermSales11,
            this.txtTTermSales12,
            this.txtTTermTotalSales,
            this.txtFTermSales1,
            this.txtFTermSales2,
            this.txtFTermSales3,
            this.txtFTermSales4,
            this.txtFTermSales5,
            this.txtFTermSales6,
            this.txtFTermSales7,
            this.txtFTermSales8,
            this.txtFTermSales9,
            this.txtFTermSales10,
            this.txtFTermSales11,
            this.txtFTermSales12,
            this.txtFTermTotalSales,
            this.txtSalesRatio1,
            this.txtSalesRatio2,
            this.txtSalesRatio3,
            this.txtSalesRatio4,
            this.txtSalesRatio5,
            this.txtSalesRatio6,
            this.txtSalesRatio7,
            this.txtSalesRatio8,
            this.txtSalesRatio9,
            this.txtSalesRatio10,
            this.txtSalesRatio11,
            this.txtSalesRatio12,
            this.txtTotalSalesRatio,
            this.txtTTermGross1,
            this.txtTTermGross2,
            this.txtTTermGross3,
            this.txtTTermGross4,
            this.txtTTermGross5,
            this.txtTTermGross6,
            this.txtTTermGross7,
            this.txtTTermGross8,
            this.txtTTermGross9,
            this.txtTTermGross10,
            this.txtTTermGross11,
            this.txtTTermGross12,
            this.txtTTermTotalGross,
            this.txtFTermGross1,
            this.txtFTermGross2,
            this.txtFTermGross3,
            this.txtFTermGross4,
            this.txtFTermGross5,
            this.txtFTermGross6,
            this.txtFTermGross7,
            this.txtFTermGross8,
            this.txtFTermGross9,
            this.txtFTermGross10,
            this.txtFTermGross11,
            this.txtFTermGross12,
            this.txtFTermTotalGross,
            this.txtGrossRatio1,
            this.txtGrossRatio2,
            this.txtGrossRatio3,
            this.txtGrossRatio4,
            this.txtGrossRatio5,
            this.txtGrossRatio6,
            this.txtGrossRatio7,
            this.txtGrossRatio8,
            this.txtGrossRatio9,
            this.txtGrossRatio10,
            this.txtGrossRatio11,
            this.txtGrossRatio12,
            this.txtTotalGrossRatio,
            this.lbTitleTTermSl,
            this.lbTitleFTermSl,
            this.lbTitleSlRatio,
            this.lbTitleTTermGrs,
            this.lbTitleFTermGrs,
            this.lbTitleGrsRatio,
            this.lbTitleSl,
            this.lbTitleGrs,
            this.txtName,
            this.txtCode,
            this.line8,
            this.line9});
            this.Detail.Height = 1.206597F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.NewColumn = DataDynamics.ActiveReports.NewColumn.Before;
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // txtTTermSales1
            // 
            this.txtTTermSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales1.DataField = "ThisTermSales1";
            this.txtTTermSales1.Height = 0.188F;
            this.txtTTermSales1.Left = 2.749998F;
            this.txtTTermSales1.MultiLine = false;
            this.txtTTermSales1.Name = "txtTTermSales1";
            this.txtTTermSales1.OutputFormat = resources.GetString("txtTTermSales1.OutputFormat");
            this.txtTTermSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales1.Text = "999,999,999";
            this.txtTTermSales1.Top = 0F;
            this.txtTTermSales1.Width = 0.6F;
            // 
            // txtTTermSales2
            // 
            this.txtTTermSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales2.DataField = "ThisTermSales2";
            this.txtTTermSales2.Height = 0.188F;
            this.txtTTermSales2.Left = 3.35417F;
            this.txtTTermSales2.MultiLine = false;
            this.txtTTermSales2.Name = "txtTTermSales2";
            this.txtTTermSales2.OutputFormat = resources.GetString("txtTTermSales2.OutputFormat");
            this.txtTTermSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales2.Text = "999,999,999";
            this.txtTTermSales2.Top = 0F;
            this.txtTTermSales2.Width = 0.6F;
            // 
            // txtTTermSales3
            // 
            this.txtTTermSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales3.DataField = "ThisTermSales3";
            this.txtTTermSales3.Height = 0.188F;
            this.txtTTermSales3.Left = 3.958335F;
            this.txtTTermSales3.MultiLine = false;
            this.txtTTermSales3.Name = "txtTTermSales3";
            this.txtTTermSales3.OutputFormat = resources.GetString("txtTTermSales3.OutputFormat");
            this.txtTTermSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales3.Text = "999,999,999";
            this.txtTTermSales3.Top = 0F;
            this.txtTTermSales3.Width = 0.6F;
            // 
            // txtTTermSales4
            // 
            this.txtTTermSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales4.DataField = "ThisTermSales4";
            this.txtTTermSales4.Height = 0.188F;
            this.txtTTermSales4.Left = 4.562502F;
            this.txtTTermSales4.MultiLine = false;
            this.txtTTermSales4.Name = "txtTTermSales4";
            this.txtTTermSales4.OutputFormat = resources.GetString("txtTTermSales4.OutputFormat");
            this.txtTTermSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales4.Text = "999,999,999";
            this.txtTTermSales4.Top = 0F;
            this.txtTTermSales4.Width = 0.6F;
            // 
            // txtTTermSales5
            // 
            this.txtTTermSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales5.DataField = "ThisTermSales5";
            this.txtTTermSales5.Height = 0.188F;
            this.txtTTermSales5.Left = 5.166668F;
            this.txtTTermSales5.MultiLine = false;
            this.txtTTermSales5.Name = "txtTTermSales5";
            this.txtTTermSales5.OutputFormat = resources.GetString("txtTTermSales5.OutputFormat");
            this.txtTTermSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales5.Text = "999,999,999";
            this.txtTTermSales5.Top = 0F;
            this.txtTTermSales5.Width = 0.6F;
            // 
            // txtTTermSales6
            // 
            this.txtTTermSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales6.DataField = "ThisTermSales6";
            this.txtTTermSales6.Height = 0.188F;
            this.txtTTermSales6.Left = 5.770834F;
            this.txtTTermSales6.MultiLine = false;
            this.txtTTermSales6.Name = "txtTTermSales6";
            this.txtTTermSales6.OutputFormat = resources.GetString("txtTTermSales6.OutputFormat");
            this.txtTTermSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales6.Text = "999,999,999";
            this.txtTTermSales6.Top = 0F;
            this.txtTTermSales6.Width = 0.6F;
            // 
            // txtTTermSales7
            // 
            this.txtTTermSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales7.DataField = "ThisTermSales7";
            this.txtTTermSales7.Height = 0.188F;
            this.txtTTermSales7.Left = 6.375001F;
            this.txtTTermSales7.MultiLine = false;
            this.txtTTermSales7.Name = "txtTTermSales7";
            this.txtTTermSales7.OutputFormat = resources.GetString("txtTTermSales7.OutputFormat");
            this.txtTTermSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales7.Text = "999,999,999";
            this.txtTTermSales7.Top = 0F;
            this.txtTTermSales7.Width = 0.6F;
            // 
            // txtTTermSales8
            // 
            this.txtTTermSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales8.DataField = "ThisTermSales8";
            this.txtTTermSales8.Height = 0.188F;
            this.txtTTermSales8.Left = 6.979168F;
            this.txtTTermSales8.MultiLine = false;
            this.txtTTermSales8.Name = "txtTTermSales8";
            this.txtTTermSales8.OutputFormat = resources.GetString("txtTTermSales8.OutputFormat");
            this.txtTTermSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales8.Text = "999,999,999";
            this.txtTTermSales8.Top = 0F;
            this.txtTTermSales8.Width = 0.6F;
            // 
            // txtTTermSales9
            // 
            this.txtTTermSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales9.DataField = "ThisTermSales9";
            this.txtTTermSales9.Height = 0.188F;
            this.txtTTermSales9.Left = 7.583334F;
            this.txtTTermSales9.MultiLine = false;
            this.txtTTermSales9.Name = "txtTTermSales9";
            this.txtTTermSales9.OutputFormat = resources.GetString("txtTTermSales9.OutputFormat");
            this.txtTTermSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales9.Text = "999,999,999";
            this.txtTTermSales9.Top = 0F;
            this.txtTTermSales9.Width = 0.6F;
            // 
            // txtTTermSales10
            // 
            this.txtTTermSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales10.DataField = "ThisTermSales10";
            this.txtTTermSales10.Height = 0.188F;
            this.txtTTermSales10.Left = 8.187502F;
            this.txtTTermSales10.MultiLine = false;
            this.txtTTermSales10.Name = "txtTTermSales10";
            this.txtTTermSales10.OutputFormat = resources.GetString("txtTTermSales10.OutputFormat");
            this.txtTTermSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales10.Text = "999,999,999";
            this.txtTTermSales10.Top = 0F;
            this.txtTTermSales10.Width = 0.6F;
            // 
            // txtTTermSales11
            // 
            this.txtTTermSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales11.DataField = "ThisTermSales11";
            this.txtTTermSales11.Height = 0.188F;
            this.txtTTermSales11.Left = 8.791668F;
            this.txtTTermSales11.MultiLine = false;
            this.txtTTermSales11.Name = "txtTTermSales11";
            this.txtTTermSales11.OutputFormat = resources.GetString("txtTTermSales11.OutputFormat");
            this.txtTTermSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales11.Text = "999,999,999";
            this.txtTTermSales11.Top = 0F;
            this.txtTTermSales11.Width = 0.6F;
            // 
            // txtTTermSales12
            // 
            this.txtTTermSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermSales12.DataField = "ThisTermSales12";
            this.txtTTermSales12.Height = 0.188F;
            this.txtTTermSales12.Left = 9.395831F;
            this.txtTTermSales12.MultiLine = false;
            this.txtTTermSales12.Name = "txtTTermSales12";
            this.txtTTermSales12.OutputFormat = resources.GetString("txtTTermSales12.OutputFormat");
            this.txtTTermSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermSales12.Text = "999,999,999";
            this.txtTTermSales12.Top = 0F;
            this.txtTTermSales12.Width = 0.6F;
            // 
            // txtTTermTotalSales
            // 
            this.txtTTermTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalSales.DataField = "ThisTermTotalSales";
            this.txtTTermTotalSales.Height = 0.188F;
            this.txtTTermTotalSales.Left = 10F;
            this.txtTTermTotalSales.MultiLine = false;
            this.txtTTermTotalSales.Name = "txtTTermTotalSales";
            this.txtTTermTotalSales.OutputFormat = resources.GetString("txtTTermTotalSales.OutputFormat");
            this.txtTTermTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermTotalSales.Text = "99,999,999,999";
            this.txtTTermTotalSales.Top = 0F;
            this.txtTTermTotalSales.Width = 0.7499995F;
            // 
            // txtFTermSales1
            // 
            this.txtFTermSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales1.DataField = "FirstTermSales1";
            this.txtFTermSales1.Height = 0.188F;
            this.txtFTermSales1.Left = 2.749998F;
            this.txtFTermSales1.MultiLine = false;
            this.txtFTermSales1.Name = "txtFTermSales1";
            this.txtFTermSales1.OutputFormat = resources.GetString("txtFTermSales1.OutputFormat");
            this.txtFTermSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales1.Text = "999,999,999";
            this.txtFTermSales1.Top = 0.1875F;
            this.txtFTermSales1.Width = 0.6F;
            // 
            // txtFTermSales2
            // 
            this.txtFTermSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales2.DataField = "FirstTermSales2";
            this.txtFTermSales2.Height = 0.188F;
            this.txtFTermSales2.Left = 3.35417F;
            this.txtFTermSales2.MultiLine = false;
            this.txtFTermSales2.Name = "txtFTermSales2";
            this.txtFTermSales2.OutputFormat = resources.GetString("txtFTermSales2.OutputFormat");
            this.txtFTermSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales2.Text = "999,999,999";
            this.txtFTermSales2.Top = 0.1875F;
            this.txtFTermSales2.Width = 0.6F;
            // 
            // txtFTermSales3
            // 
            this.txtFTermSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales3.DataField = "FirstTermSales3";
            this.txtFTermSales3.Height = 0.188F;
            this.txtFTermSales3.Left = 3.958335F;
            this.txtFTermSales3.MultiLine = false;
            this.txtFTermSales3.Name = "txtFTermSales3";
            this.txtFTermSales3.OutputFormat = resources.GetString("txtFTermSales3.OutputFormat");
            this.txtFTermSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales3.Text = "999,999,999";
            this.txtFTermSales3.Top = 0.1875F;
            this.txtFTermSales3.Width = 0.6F;
            // 
            // txtFTermSales4
            // 
            this.txtFTermSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales4.DataField = "FirstTermSales4";
            this.txtFTermSales4.Height = 0.188F;
            this.txtFTermSales4.Left = 4.562502F;
            this.txtFTermSales4.MultiLine = false;
            this.txtFTermSales4.Name = "txtFTermSales4";
            this.txtFTermSales4.OutputFormat = resources.GetString("txtFTermSales4.OutputFormat");
            this.txtFTermSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales4.Text = "999,999,999";
            this.txtFTermSales4.Top = 0.1875F;
            this.txtFTermSales4.Width = 0.6F;
            // 
            // txtFTermSales5
            // 
            this.txtFTermSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales5.DataField = "FirstTermSales5";
            this.txtFTermSales5.Height = 0.188F;
            this.txtFTermSales5.Left = 5.166668F;
            this.txtFTermSales5.MultiLine = false;
            this.txtFTermSales5.Name = "txtFTermSales5";
            this.txtFTermSales5.OutputFormat = resources.GetString("txtFTermSales5.OutputFormat");
            this.txtFTermSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales5.Text = "999,999,999";
            this.txtFTermSales5.Top = 0.1875F;
            this.txtFTermSales5.Width = 0.6F;
            // 
            // txtFTermSales6
            // 
            this.txtFTermSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales6.DataField = "FirstTermSales6";
            this.txtFTermSales6.Height = 0.188F;
            this.txtFTermSales6.Left = 5.770834F;
            this.txtFTermSales6.MultiLine = false;
            this.txtFTermSales6.Name = "txtFTermSales6";
            this.txtFTermSales6.OutputFormat = resources.GetString("txtFTermSales6.OutputFormat");
            this.txtFTermSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales6.Text = "999,999,999";
            this.txtFTermSales6.Top = 0.1875F;
            this.txtFTermSales6.Width = 0.6F;
            // 
            // txtFTermSales7
            // 
            this.txtFTermSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales7.DataField = "FirstTermSales7";
            this.txtFTermSales7.Height = 0.188F;
            this.txtFTermSales7.Left = 6.375001F;
            this.txtFTermSales7.MultiLine = false;
            this.txtFTermSales7.Name = "txtFTermSales7";
            this.txtFTermSales7.OutputFormat = resources.GetString("txtFTermSales7.OutputFormat");
            this.txtFTermSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales7.Text = "999,999,999";
            this.txtFTermSales7.Top = 0.1875F;
            this.txtFTermSales7.Width = 0.6F;
            // 
            // txtFTermSales8
            // 
            this.txtFTermSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales8.DataField = "FirstTermSales8";
            this.txtFTermSales8.Height = 0.188F;
            this.txtFTermSales8.Left = 6.979168F;
            this.txtFTermSales8.MultiLine = false;
            this.txtFTermSales8.Name = "txtFTermSales8";
            this.txtFTermSales8.OutputFormat = resources.GetString("txtFTermSales8.OutputFormat");
            this.txtFTermSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales8.Text = "999,999,999";
            this.txtFTermSales8.Top = 0.1875F;
            this.txtFTermSales8.Width = 0.6F;
            // 
            // txtFTermSales9
            // 
            this.txtFTermSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales9.DataField = "FirstTermSales9";
            this.txtFTermSales9.Height = 0.188F;
            this.txtFTermSales9.Left = 7.583334F;
            this.txtFTermSales9.MultiLine = false;
            this.txtFTermSales9.Name = "txtFTermSales9";
            this.txtFTermSales9.OutputFormat = resources.GetString("txtFTermSales9.OutputFormat");
            this.txtFTermSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales9.Text = "999,999,999";
            this.txtFTermSales9.Top = 0.1875F;
            this.txtFTermSales9.Width = 0.6F;
            // 
            // txtFTermSales10
            // 
            this.txtFTermSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales10.DataField = "FirstTermSales10";
            this.txtFTermSales10.Height = 0.188F;
            this.txtFTermSales10.Left = 8.187502F;
            this.txtFTermSales10.MultiLine = false;
            this.txtFTermSales10.Name = "txtFTermSales10";
            this.txtFTermSales10.OutputFormat = resources.GetString("txtFTermSales10.OutputFormat");
            this.txtFTermSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales10.Text = "999,999,999";
            this.txtFTermSales10.Top = 0.1875F;
            this.txtFTermSales10.Width = 0.6F;
            // 
            // txtFTermSales11
            // 
            this.txtFTermSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales11.DataField = "FirstTermSales11";
            this.txtFTermSales11.Height = 0.188F;
            this.txtFTermSales11.Left = 8.791668F;
            this.txtFTermSales11.MultiLine = false;
            this.txtFTermSales11.Name = "txtFTermSales11";
            this.txtFTermSales11.OutputFormat = resources.GetString("txtFTermSales11.OutputFormat");
            this.txtFTermSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales11.Text = "999,999,999";
            this.txtFTermSales11.Top = 0.1875F;
            this.txtFTermSales11.Width = 0.6F;
            // 
            // txtFTermSales12
            // 
            this.txtFTermSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermSales12.DataField = "FirstTermSales12";
            this.txtFTermSales12.Height = 0.188F;
            this.txtFTermSales12.Left = 9.395831F;
            this.txtFTermSales12.MultiLine = false;
            this.txtFTermSales12.Name = "txtFTermSales12";
            this.txtFTermSales12.OutputFormat = resources.GetString("txtFTermSales12.OutputFormat");
            this.txtFTermSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermSales12.Text = "999,999,999";
            this.txtFTermSales12.Top = 0.1875F;
            this.txtFTermSales12.Width = 0.6F;
            // 
            // txtFTermTotalSales
            // 
            this.txtFTermTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalSales.DataField = "FirstTermTotalSales";
            this.txtFTermTotalSales.Height = 0.1875F;
            this.txtFTermTotalSales.Left = 10F;
            this.txtFTermTotalSales.MultiLine = false;
            this.txtFTermTotalSales.Name = "txtFTermTotalSales";
            this.txtFTermTotalSales.OutputFormat = resources.GetString("txtFTermTotalSales.OutputFormat");
            this.txtFTermTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermTotalSales.Text = "99,999,999,999";
            this.txtFTermTotalSales.Top = 0.1875F;
            this.txtFTermTotalSales.Width = 0.7499995F;
            // 
            // txtSalesRatio1
            // 
            this.txtSalesRatio1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio1.DataField = "SalesRatio1";
            this.txtSalesRatio1.Height = 0.188F;
            this.txtSalesRatio1.Left = 2.749998F;
            this.txtSalesRatio1.MultiLine = false;
            this.txtSalesRatio1.Name = "txtSalesRatio1";
            this.txtSalesRatio1.OutputFormat = resources.GetString("txtSalesRatio1.OutputFormat");
            this.txtSalesRatio1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio1.Text = "999,999,999";
            this.txtSalesRatio1.Top = 0.375F;
            this.txtSalesRatio1.Width = 0.6F;
            // 
            // txtSalesRatio2
            // 
            this.txtSalesRatio2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio2.DataField = "SalesRatio2";
            this.txtSalesRatio2.Height = 0.188F;
            this.txtSalesRatio2.Left = 3.35417F;
            this.txtSalesRatio2.MultiLine = false;
            this.txtSalesRatio2.Name = "txtSalesRatio2";
            this.txtSalesRatio2.OutputFormat = resources.GetString("txtSalesRatio2.OutputFormat");
            this.txtSalesRatio2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio2.Text = "999,999,999";
            this.txtSalesRatio2.Top = 0.375F;
            this.txtSalesRatio2.Width = 0.6F;
            // 
            // txtSalesRatio3
            // 
            this.txtSalesRatio3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio3.DataField = "SalesRatio3";
            this.txtSalesRatio3.Height = 0.188F;
            this.txtSalesRatio3.Left = 3.958335F;
            this.txtSalesRatio3.MultiLine = false;
            this.txtSalesRatio3.Name = "txtSalesRatio3";
            this.txtSalesRatio3.OutputFormat = resources.GetString("txtSalesRatio3.OutputFormat");
            this.txtSalesRatio3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio3.Text = "999,999,999";
            this.txtSalesRatio3.Top = 0.375F;
            this.txtSalesRatio3.Width = 0.6F;
            // 
            // txtSalesRatio4
            // 
            this.txtSalesRatio4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio4.DataField = "SalesRatio4";
            this.txtSalesRatio4.Height = 0.188F;
            this.txtSalesRatio4.Left = 4.562502F;
            this.txtSalesRatio4.MultiLine = false;
            this.txtSalesRatio4.Name = "txtSalesRatio4";
            this.txtSalesRatio4.OutputFormat = resources.GetString("txtSalesRatio4.OutputFormat");
            this.txtSalesRatio4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio4.Text = "999,999,999";
            this.txtSalesRatio4.Top = 0.375F;
            this.txtSalesRatio4.Width = 0.6F;
            // 
            // txtSalesRatio5
            // 
            this.txtSalesRatio5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio5.DataField = "SalesRatio5";
            this.txtSalesRatio5.Height = 0.188F;
            this.txtSalesRatio5.Left = 5.166668F;
            this.txtSalesRatio5.MultiLine = false;
            this.txtSalesRatio5.Name = "txtSalesRatio5";
            this.txtSalesRatio5.OutputFormat = resources.GetString("txtSalesRatio5.OutputFormat");
            this.txtSalesRatio5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio5.Text = "999,999,999";
            this.txtSalesRatio5.Top = 0.375F;
            this.txtSalesRatio5.Width = 0.6F;
            // 
            // txtSalesRatio6
            // 
            this.txtSalesRatio6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio6.DataField = "SalesRatio6";
            this.txtSalesRatio6.Height = 0.188F;
            this.txtSalesRatio6.Left = 5.770834F;
            this.txtSalesRatio6.MultiLine = false;
            this.txtSalesRatio6.Name = "txtSalesRatio6";
            this.txtSalesRatio6.OutputFormat = resources.GetString("txtSalesRatio6.OutputFormat");
            this.txtSalesRatio6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio6.Text = "999,999,999";
            this.txtSalesRatio6.Top = 0.375F;
            this.txtSalesRatio6.Width = 0.6F;
            // 
            // txtSalesRatio7
            // 
            this.txtSalesRatio7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio7.DataField = "SalesRatio7";
            this.txtSalesRatio7.Height = 0.188F;
            this.txtSalesRatio7.Left = 6.375001F;
            this.txtSalesRatio7.MultiLine = false;
            this.txtSalesRatio7.Name = "txtSalesRatio7";
            this.txtSalesRatio7.OutputFormat = resources.GetString("txtSalesRatio7.OutputFormat");
            this.txtSalesRatio7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio7.Text = "999,999,999";
            this.txtSalesRatio7.Top = 0.375F;
            this.txtSalesRatio7.Width = 0.6F;
            // 
            // txtSalesRatio8
            // 
            this.txtSalesRatio8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio8.DataField = "SalesRatio8";
            this.txtSalesRatio8.Height = 0.188F;
            this.txtSalesRatio8.Left = 6.979168F;
            this.txtSalesRatio8.MultiLine = false;
            this.txtSalesRatio8.Name = "txtSalesRatio8";
            this.txtSalesRatio8.OutputFormat = resources.GetString("txtSalesRatio8.OutputFormat");
            this.txtSalesRatio8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio8.Text = "999,999,999";
            this.txtSalesRatio8.Top = 0.375F;
            this.txtSalesRatio8.Width = 0.6F;
            // 
            // txtSalesRatio9
            // 
            this.txtSalesRatio9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio9.DataField = "SalesRatio9";
            this.txtSalesRatio9.Height = 0.188F;
            this.txtSalesRatio9.Left = 7.583334F;
            this.txtSalesRatio9.MultiLine = false;
            this.txtSalesRatio9.Name = "txtSalesRatio9";
            this.txtSalesRatio9.OutputFormat = resources.GetString("txtSalesRatio9.OutputFormat");
            this.txtSalesRatio9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio9.Text = "999,999,999";
            this.txtSalesRatio9.Top = 0.375F;
            this.txtSalesRatio9.Width = 0.6F;
            // 
            // txtSalesRatio10
            // 
            this.txtSalesRatio10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio10.DataField = "SalesRatio10";
            this.txtSalesRatio10.Height = 0.188F;
            this.txtSalesRatio10.Left = 8.187502F;
            this.txtSalesRatio10.MultiLine = false;
            this.txtSalesRatio10.Name = "txtSalesRatio10";
            this.txtSalesRatio10.OutputFormat = resources.GetString("txtSalesRatio10.OutputFormat");
            this.txtSalesRatio10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio10.Text = "999,999,999";
            this.txtSalesRatio10.Top = 0.375F;
            this.txtSalesRatio10.Width = 0.6F;
            // 
            // txtSalesRatio11
            // 
            this.txtSalesRatio11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio11.DataField = "SalesRatio11";
            this.txtSalesRatio11.Height = 0.188F;
            this.txtSalesRatio11.Left = 8.791668F;
            this.txtSalesRatio11.MultiLine = false;
            this.txtSalesRatio11.Name = "txtSalesRatio11";
            this.txtSalesRatio11.OutputFormat = resources.GetString("txtSalesRatio11.OutputFormat");
            this.txtSalesRatio11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio11.Text = "999,999,999";
            this.txtSalesRatio11.Top = 0.375F;
            this.txtSalesRatio11.Width = 0.6F;
            // 
            // txtSalesRatio12
            // 
            this.txtSalesRatio12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSalesRatio12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSalesRatio12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSalesRatio12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSalesRatio12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSalesRatio12.DataField = "SalesRatio12";
            this.txtSalesRatio12.Height = 0.188F;
            this.txtSalesRatio12.Left = 9.395831F;
            this.txtSalesRatio12.MultiLine = false;
            this.txtSalesRatio12.Name = "txtSalesRatio12";
            this.txtSalesRatio12.OutputFormat = resources.GetString("txtSalesRatio12.OutputFormat");
            this.txtSalesRatio12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtSalesRatio12.Text = "999,999,999";
            this.txtSalesRatio12.Top = 0.375F;
            this.txtSalesRatio12.Width = 0.6F;
            // 
            // txtTotalSalesRatio
            // 
            this.txtTotalSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSalesRatio.DataField = "TotalSalesRatio";
            this.txtTotalSalesRatio.Height = 0.188F;
            this.txtTotalSalesRatio.Left = 10F;
            this.txtTotalSalesRatio.MultiLine = false;
            this.txtTotalSalesRatio.Name = "txtTotalSalesRatio";
            this.txtTotalSalesRatio.OutputFormat = resources.GetString("txtTotalSalesRatio.OutputFormat");
            this.txtTotalSalesRatio.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTotalSalesRatio.Text = "99,999,999,999";
            this.txtTotalSalesRatio.Top = 0.375F;
            this.txtTotalSalesRatio.Width = 0.7499995F;
            // 
            // txtTTermGross1
            // 
            this.txtTTermGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross1.DataField = "ThisTermGross1";
            this.txtTTermGross1.Height = 0.188F;
            this.txtTTermGross1.Left = 2.749998F;
            this.txtTTermGross1.MultiLine = false;
            this.txtTTermGross1.Name = "txtTTermGross1";
            this.txtTTermGross1.OutputFormat = resources.GetString("txtTTermGross1.OutputFormat");
            this.txtTTermGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross1.Text = "999,999,999";
            this.txtTTermGross1.Top = 0.5625F;
            this.txtTTermGross1.Width = 0.6F;
            // 
            // txtTTermGross2
            // 
            this.txtTTermGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross2.DataField = "ThisTermGross2";
            this.txtTTermGross2.Height = 0.188F;
            this.txtTTermGross2.Left = 3.35417F;
            this.txtTTermGross2.MultiLine = false;
            this.txtTTermGross2.Name = "txtTTermGross2";
            this.txtTTermGross2.OutputFormat = resources.GetString("txtTTermGross2.OutputFormat");
            this.txtTTermGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross2.Text = "999,999,999";
            this.txtTTermGross2.Top = 0.5625F;
            this.txtTTermGross2.Width = 0.6F;
            // 
            // txtTTermGross3
            // 
            this.txtTTermGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross3.DataField = "ThisTermGross3";
            this.txtTTermGross3.Height = 0.188F;
            this.txtTTermGross3.Left = 3.958335F;
            this.txtTTermGross3.MultiLine = false;
            this.txtTTermGross3.Name = "txtTTermGross3";
            this.txtTTermGross3.OutputFormat = resources.GetString("txtTTermGross3.OutputFormat");
            this.txtTTermGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross3.Text = "999,999,999";
            this.txtTTermGross3.Top = 0.5625F;
            this.txtTTermGross3.Width = 0.6F;
            // 
            // txtTTermGross4
            // 
            this.txtTTermGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross4.DataField = "ThisTermGross4";
            this.txtTTermGross4.Height = 0.188F;
            this.txtTTermGross4.Left = 4.562502F;
            this.txtTTermGross4.MultiLine = false;
            this.txtTTermGross4.Name = "txtTTermGross4";
            this.txtTTermGross4.OutputFormat = resources.GetString("txtTTermGross4.OutputFormat");
            this.txtTTermGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross4.Text = "999,999,999";
            this.txtTTermGross4.Top = 0.5625F;
            this.txtTTermGross4.Width = 0.6F;
            // 
            // txtTTermGross5
            // 
            this.txtTTermGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross5.DataField = "ThisTermGross5";
            this.txtTTermGross5.Height = 0.188F;
            this.txtTTermGross5.Left = 5.166668F;
            this.txtTTermGross5.MultiLine = false;
            this.txtTTermGross5.Name = "txtTTermGross5";
            this.txtTTermGross5.OutputFormat = resources.GetString("txtTTermGross5.OutputFormat");
            this.txtTTermGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross5.Text = "999,999,999";
            this.txtTTermGross5.Top = 0.5625F;
            this.txtTTermGross5.Width = 0.6F;
            // 
            // txtTTermGross6
            // 
            this.txtTTermGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross6.DataField = "ThisTermGross6";
            this.txtTTermGross6.Height = 0.188F;
            this.txtTTermGross6.Left = 5.770834F;
            this.txtTTermGross6.MultiLine = false;
            this.txtTTermGross6.Name = "txtTTermGross6";
            this.txtTTermGross6.OutputFormat = resources.GetString("txtTTermGross6.OutputFormat");
            this.txtTTermGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross6.Text = "999,999,999";
            this.txtTTermGross6.Top = 0.5625F;
            this.txtTTermGross6.Width = 0.6F;
            // 
            // txtTTermGross7
            // 
            this.txtTTermGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross7.DataField = "ThisTermGross7";
            this.txtTTermGross7.Height = 0.188F;
            this.txtTTermGross7.Left = 6.375001F;
            this.txtTTermGross7.MultiLine = false;
            this.txtTTermGross7.Name = "txtTTermGross7";
            this.txtTTermGross7.OutputFormat = resources.GetString("txtTTermGross7.OutputFormat");
            this.txtTTermGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross7.Text = "999,999,999";
            this.txtTTermGross7.Top = 0.5625F;
            this.txtTTermGross7.Width = 0.6F;
            // 
            // txtTTermGross8
            // 
            this.txtTTermGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross8.DataField = "ThisTermGross8";
            this.txtTTermGross8.Height = 0.188F;
            this.txtTTermGross8.Left = 6.979168F;
            this.txtTTermGross8.MultiLine = false;
            this.txtTTermGross8.Name = "txtTTermGross8";
            this.txtTTermGross8.OutputFormat = resources.GetString("txtTTermGross8.OutputFormat");
            this.txtTTermGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross8.Text = "999,999,999";
            this.txtTTermGross8.Top = 0.5625F;
            this.txtTTermGross8.Width = 0.6F;
            // 
            // txtTTermGross9
            // 
            this.txtTTermGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross9.DataField = "ThisTermGross9";
            this.txtTTermGross9.Height = 0.188F;
            this.txtTTermGross9.Left = 7.583334F;
            this.txtTTermGross9.MultiLine = false;
            this.txtTTermGross9.Name = "txtTTermGross9";
            this.txtTTermGross9.OutputFormat = resources.GetString("txtTTermGross9.OutputFormat");
            this.txtTTermGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross9.Text = "999,999,999";
            this.txtTTermGross9.Top = 0.5625F;
            this.txtTTermGross9.Width = 0.6F;
            // 
            // txtTTermGross10
            // 
            this.txtTTermGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross10.DataField = "ThisTermGross10";
            this.txtTTermGross10.Height = 0.188F;
            this.txtTTermGross10.Left = 8.187502F;
            this.txtTTermGross10.MultiLine = false;
            this.txtTTermGross10.Name = "txtTTermGross10";
            this.txtTTermGross10.OutputFormat = resources.GetString("txtTTermGross10.OutputFormat");
            this.txtTTermGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross10.Text = "999,999,999";
            this.txtTTermGross10.Top = 0.5625F;
            this.txtTTermGross10.Width = 0.6F;
            // 
            // txtTTermGross11
            // 
            this.txtTTermGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross11.DataField = "ThisTermGross11";
            this.txtTTermGross11.Height = 0.188F;
            this.txtTTermGross11.Left = 8.791668F;
            this.txtTTermGross11.MultiLine = false;
            this.txtTTermGross11.Name = "txtTTermGross11";
            this.txtTTermGross11.OutputFormat = resources.GetString("txtTTermGross11.OutputFormat");
            this.txtTTermGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross11.Text = "999,999,999";
            this.txtTTermGross11.Top = 0.5625F;
            this.txtTTermGross11.Width = 0.6F;
            // 
            // txtTTermGross12
            // 
            this.txtTTermGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermGross12.DataField = "ThisTermGross12";
            this.txtTTermGross12.Height = 0.188F;
            this.txtTTermGross12.Left = 9.395831F;
            this.txtTTermGross12.MultiLine = false;
            this.txtTTermGross12.Name = "txtTTermGross12";
            this.txtTTermGross12.OutputFormat = resources.GetString("txtTTermGross12.OutputFormat");
            this.txtTTermGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermGross12.Text = "999,999,999";
            this.txtTTermGross12.Top = 0.5625F;
            this.txtTTermGross12.Width = 0.6F;
            // 
            // txtTTermTotalGross
            // 
            this.txtTTermTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTermTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTermTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTermTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTermTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTermTotalGross.DataField = "ThisTermTotalGross";
            this.txtTTermTotalGross.Height = 0.188F;
            this.txtTTermTotalGross.Left = 10F;
            this.txtTTermTotalGross.MultiLine = false;
            this.txtTTermTotalGross.Name = "txtTTermTotalGross";
            this.txtTTermTotalGross.OutputFormat = resources.GetString("txtTTermTotalGross.OutputFormat");
            this.txtTTermTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTTermTotalGross.Text = "99,999,999,999";
            this.txtTTermTotalGross.Top = 0.5625F;
            this.txtTTermTotalGross.Width = 0.7499995F;
            // 
            // txtFTermGross1
            // 
            this.txtFTermGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross1.DataField = "FirstTermGross1";
            this.txtFTermGross1.Height = 0.188F;
            this.txtFTermGross1.Left = 2.749998F;
            this.txtFTermGross1.MultiLine = false;
            this.txtFTermGross1.Name = "txtFTermGross1";
            this.txtFTermGross1.OutputFormat = resources.GetString("txtFTermGross1.OutputFormat");
            this.txtFTermGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross1.Text = "999,999,999";
            this.txtFTermGross1.Top = 0.75F;
            this.txtFTermGross1.Width = 0.6F;
            // 
            // txtFTermGross2
            // 
            this.txtFTermGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross2.DataField = "FirstTermGross2";
            this.txtFTermGross2.Height = 0.188F;
            this.txtFTermGross2.Left = 3.35417F;
            this.txtFTermGross2.MultiLine = false;
            this.txtFTermGross2.Name = "txtFTermGross2";
            this.txtFTermGross2.OutputFormat = resources.GetString("txtFTermGross2.OutputFormat");
            this.txtFTermGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross2.Text = "999,999,999";
            this.txtFTermGross2.Top = 0.75F;
            this.txtFTermGross2.Width = 0.6F;
            // 
            // txtFTermGross3
            // 
            this.txtFTermGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross3.DataField = "FirstTermGross3";
            this.txtFTermGross3.Height = 0.188F;
            this.txtFTermGross3.Left = 3.958335F;
            this.txtFTermGross3.MultiLine = false;
            this.txtFTermGross3.Name = "txtFTermGross3";
            this.txtFTermGross3.OutputFormat = resources.GetString("txtFTermGross3.OutputFormat");
            this.txtFTermGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross3.Text = "999,999,999";
            this.txtFTermGross3.Top = 0.75F;
            this.txtFTermGross3.Width = 0.6F;
            // 
            // txtFTermGross4
            // 
            this.txtFTermGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross4.DataField = "FirstTermGross4";
            this.txtFTermGross4.Height = 0.188F;
            this.txtFTermGross4.Left = 4.562502F;
            this.txtFTermGross4.MultiLine = false;
            this.txtFTermGross4.Name = "txtFTermGross4";
            this.txtFTermGross4.OutputFormat = resources.GetString("txtFTermGross4.OutputFormat");
            this.txtFTermGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross4.Text = "999,999,999";
            this.txtFTermGross4.Top = 0.75F;
            this.txtFTermGross4.Width = 0.6F;
            // 
            // txtFTermGross5
            // 
            this.txtFTermGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross5.DataField = "FirstTermGross5";
            this.txtFTermGross5.Height = 0.188F;
            this.txtFTermGross5.Left = 5.166668F;
            this.txtFTermGross5.MultiLine = false;
            this.txtFTermGross5.Name = "txtFTermGross5";
            this.txtFTermGross5.OutputFormat = resources.GetString("txtFTermGross5.OutputFormat");
            this.txtFTermGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross5.Text = "999,999,999";
            this.txtFTermGross5.Top = 0.75F;
            this.txtFTermGross5.Width = 0.6F;
            // 
            // txtFTermGross6
            // 
            this.txtFTermGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross6.DataField = "FirstTermGross6";
            this.txtFTermGross6.Height = 0.188F;
            this.txtFTermGross6.Left = 5.770834F;
            this.txtFTermGross6.MultiLine = false;
            this.txtFTermGross6.Name = "txtFTermGross6";
            this.txtFTermGross6.OutputFormat = resources.GetString("txtFTermGross6.OutputFormat");
            this.txtFTermGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross6.Text = "999,999,999";
            this.txtFTermGross6.Top = 0.75F;
            this.txtFTermGross6.Width = 0.6F;
            // 
            // txtFTermGross7
            // 
            this.txtFTermGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross7.DataField = "FirstTermGross7";
            this.txtFTermGross7.Height = 0.188F;
            this.txtFTermGross7.Left = 6.375001F;
            this.txtFTermGross7.MultiLine = false;
            this.txtFTermGross7.Name = "txtFTermGross7";
            this.txtFTermGross7.OutputFormat = resources.GetString("txtFTermGross7.OutputFormat");
            this.txtFTermGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross7.Text = "999,999,999";
            this.txtFTermGross7.Top = 0.75F;
            this.txtFTermGross7.Width = 0.6F;
            // 
            // txtFTermGross8
            // 
            this.txtFTermGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross8.DataField = "FirstTermGross8";
            this.txtFTermGross8.Height = 0.188F;
            this.txtFTermGross8.Left = 6.979168F;
            this.txtFTermGross8.MultiLine = false;
            this.txtFTermGross8.Name = "txtFTermGross8";
            this.txtFTermGross8.OutputFormat = resources.GetString("txtFTermGross8.OutputFormat");
            this.txtFTermGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross8.Text = "999,999,999";
            this.txtFTermGross8.Top = 0.75F;
            this.txtFTermGross8.Width = 0.6F;
            // 
            // txtFTermGross9
            // 
            this.txtFTermGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross9.DataField = "FirstTermGross9";
            this.txtFTermGross9.Height = 0.188F;
            this.txtFTermGross9.Left = 7.583334F;
            this.txtFTermGross9.MultiLine = false;
            this.txtFTermGross9.Name = "txtFTermGross9";
            this.txtFTermGross9.OutputFormat = resources.GetString("txtFTermGross9.OutputFormat");
            this.txtFTermGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross9.Text = "999,999,999";
            this.txtFTermGross9.Top = 0.75F;
            this.txtFTermGross9.Width = 0.6F;
            // 
            // txtFTermGross10
            // 
            this.txtFTermGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross10.DataField = "FirstTermGross10";
            this.txtFTermGross10.Height = 0.188F;
            this.txtFTermGross10.Left = 8.187502F;
            this.txtFTermGross10.MultiLine = false;
            this.txtFTermGross10.Name = "txtFTermGross10";
            this.txtFTermGross10.OutputFormat = resources.GetString("txtFTermGross10.OutputFormat");
            this.txtFTermGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross10.Text = "999,999,999";
            this.txtFTermGross10.Top = 0.75F;
            this.txtFTermGross10.Width = 0.6F;
            // 
            // txtFTermGross11
            // 
            this.txtFTermGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross11.DataField = "FirstTermGross11";
            this.txtFTermGross11.Height = 0.188F;
            this.txtFTermGross11.Left = 8.791668F;
            this.txtFTermGross11.MultiLine = false;
            this.txtFTermGross11.Name = "txtFTermGross11";
            this.txtFTermGross11.OutputFormat = resources.GetString("txtFTermGross11.OutputFormat");
            this.txtFTermGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross11.Text = "999,999,999";
            this.txtFTermGross11.Top = 0.75F;
            this.txtFTermGross11.Width = 0.6F;
            // 
            // txtFTermGross12
            // 
            this.txtFTermGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermGross12.DataField = "FirstTermGross12";
            this.txtFTermGross12.Height = 0.188F;
            this.txtFTermGross12.Left = 9.395831F;
            this.txtFTermGross12.MultiLine = false;
            this.txtFTermGross12.Name = "txtFTermGross12";
            this.txtFTermGross12.OutputFormat = resources.GetString("txtFTermGross12.OutputFormat");
            this.txtFTermGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermGross12.Text = "999,999,999";
            this.txtFTermGross12.Top = 0.75F;
            this.txtFTermGross12.Width = 0.6F;
            // 
            // txtFTermTotalGross
            // 
            this.txtFTermTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTermTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTermTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTermTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTermTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTermTotalGross.DataField = "FirstTermTotalGross";
            this.txtFTermTotalGross.Height = 0.188F;
            this.txtFTermTotalGross.Left = 10F;
            this.txtFTermTotalGross.MultiLine = false;
            this.txtFTermTotalGross.Name = "txtFTermTotalGross";
            this.txtFTermTotalGross.OutputFormat = resources.GetString("txtFTermTotalGross.OutputFormat");
            this.txtFTermTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtFTermTotalGross.Text = "99,999,999,999";
            this.txtFTermTotalGross.Top = 0.75F;
            this.txtFTermTotalGross.Width = 0.7499995F;
            // 
            // txtGrossRatio1
            // 
            this.txtGrossRatio1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio1.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio1.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio1.DataField = "GrossRatio1";
            this.txtGrossRatio1.Height = 0.188F;
            this.txtGrossRatio1.Left = 2.749998F;
            this.txtGrossRatio1.MultiLine = false;
            this.txtGrossRatio1.Name = "txtGrossRatio1";
            this.txtGrossRatio1.OutputFormat = resources.GetString("txtGrossRatio1.OutputFormat");
            this.txtGrossRatio1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio1.Text = "999,999,999";
            this.txtGrossRatio1.Top = 0.9374998F;
            this.txtGrossRatio1.Width = 0.6F;
            // 
            // txtGrossRatio2
            // 
            this.txtGrossRatio2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio2.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio2.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio2.DataField = "GrossRatio2";
            this.txtGrossRatio2.Height = 0.188F;
            this.txtGrossRatio2.Left = 3.35417F;
            this.txtGrossRatio2.MultiLine = false;
            this.txtGrossRatio2.Name = "txtGrossRatio2";
            this.txtGrossRatio2.OutputFormat = resources.GetString("txtGrossRatio2.OutputFormat");
            this.txtGrossRatio2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio2.Text = "999,999,999";
            this.txtGrossRatio2.Top = 0.9374998F;
            this.txtGrossRatio2.Width = 0.6F;
            // 
            // txtGrossRatio3
            // 
            this.txtGrossRatio3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio3.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio3.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio3.DataField = "GrossRatio3";
            this.txtGrossRatio3.Height = 0.188F;
            this.txtGrossRatio3.Left = 3.958335F;
            this.txtGrossRatio3.MultiLine = false;
            this.txtGrossRatio3.Name = "txtGrossRatio3";
            this.txtGrossRatio3.OutputFormat = resources.GetString("txtGrossRatio3.OutputFormat");
            this.txtGrossRatio3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio3.Text = "999,999,999";
            this.txtGrossRatio3.Top = 0.9374998F;
            this.txtGrossRatio3.Width = 0.6F;
            // 
            // txtGrossRatio4
            // 
            this.txtGrossRatio4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio4.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio4.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio4.DataField = "GrossRatio4";
            this.txtGrossRatio4.Height = 0.188F;
            this.txtGrossRatio4.Left = 4.562502F;
            this.txtGrossRatio4.MultiLine = false;
            this.txtGrossRatio4.Name = "txtGrossRatio4";
            this.txtGrossRatio4.OutputFormat = resources.GetString("txtGrossRatio4.OutputFormat");
            this.txtGrossRatio4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio4.Text = "999,999,999";
            this.txtGrossRatio4.Top = 0.9374998F;
            this.txtGrossRatio4.Width = 0.6F;
            // 
            // txtGrossRatio5
            // 
            this.txtGrossRatio5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio5.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio5.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio5.DataField = "GrossRatio5";
            this.txtGrossRatio5.Height = 0.188F;
            this.txtGrossRatio5.Left = 5.166668F;
            this.txtGrossRatio5.MultiLine = false;
            this.txtGrossRatio5.Name = "txtGrossRatio5";
            this.txtGrossRatio5.OutputFormat = resources.GetString("txtGrossRatio5.OutputFormat");
            this.txtGrossRatio5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio5.Text = "999,999,999";
            this.txtGrossRatio5.Top = 0.9374999F;
            this.txtGrossRatio5.Width = 0.6F;
            // 
            // txtGrossRatio6
            // 
            this.txtGrossRatio6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio6.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio6.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio6.DataField = "GrossRatio6";
            this.txtGrossRatio6.Height = 0.188F;
            this.txtGrossRatio6.Left = 5.770834F;
            this.txtGrossRatio6.MultiLine = false;
            this.txtGrossRatio6.Name = "txtGrossRatio6";
            this.txtGrossRatio6.OutputFormat = resources.GetString("txtGrossRatio6.OutputFormat");
            this.txtGrossRatio6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio6.Text = "999,999,999";
            this.txtGrossRatio6.Top = 0.9374999F;
            this.txtGrossRatio6.Width = 0.6F;
            // 
            // txtGrossRatio7
            // 
            this.txtGrossRatio7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio7.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio7.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio7.DataField = "GrossRatio7";
            this.txtGrossRatio7.Height = 0.188F;
            this.txtGrossRatio7.Left = 6.375001F;
            this.txtGrossRatio7.MultiLine = false;
            this.txtGrossRatio7.Name = "txtGrossRatio7";
            this.txtGrossRatio7.OutputFormat = resources.GetString("txtGrossRatio7.OutputFormat");
            this.txtGrossRatio7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio7.Text = "999,999,999";
            this.txtGrossRatio7.Top = 0.9374999F;
            this.txtGrossRatio7.Width = 0.6F;
            // 
            // txtGrossRatio8
            // 
            this.txtGrossRatio8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio8.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio8.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio8.DataField = "GrossRatio8";
            this.txtGrossRatio8.Height = 0.188F;
            this.txtGrossRatio8.Left = 6.979168F;
            this.txtGrossRatio8.MultiLine = false;
            this.txtGrossRatio8.Name = "txtGrossRatio8";
            this.txtGrossRatio8.OutputFormat = resources.GetString("txtGrossRatio8.OutputFormat");
            this.txtGrossRatio8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio8.Text = "999,999,999";
            this.txtGrossRatio8.Top = 0.9374999F;
            this.txtGrossRatio8.Width = 0.6F;
            // 
            // txtGrossRatio9
            // 
            this.txtGrossRatio9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio9.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio9.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio9.DataField = "GrossRatio9";
            this.txtGrossRatio9.Height = 0.188F;
            this.txtGrossRatio9.Left = 7.583334F;
            this.txtGrossRatio9.MultiLine = false;
            this.txtGrossRatio9.Name = "txtGrossRatio9";
            this.txtGrossRatio9.OutputFormat = resources.GetString("txtGrossRatio9.OutputFormat");
            this.txtGrossRatio9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio9.Text = "999,999,999";
            this.txtGrossRatio9.Top = 0.9374999F;
            this.txtGrossRatio9.Width = 0.6F;
            // 
            // txtGrossRatio10
            // 
            this.txtGrossRatio10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio10.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio10.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio10.DataField = "GrossRatio10";
            this.txtGrossRatio10.Height = 0.188F;
            this.txtGrossRatio10.Left = 8.187502F;
            this.txtGrossRatio10.MultiLine = false;
            this.txtGrossRatio10.Name = "txtGrossRatio10";
            this.txtGrossRatio10.OutputFormat = resources.GetString("txtGrossRatio10.OutputFormat");
            this.txtGrossRatio10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio10.Text = "999,999,999";
            this.txtGrossRatio10.Top = 0.9374999F;
            this.txtGrossRatio10.Width = 0.6F;
            // 
            // txtGrossRatio11
            // 
            this.txtGrossRatio11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio11.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio11.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio11.DataField = "GrossRatio11";
            this.txtGrossRatio11.Height = 0.188F;
            this.txtGrossRatio11.Left = 8.791668F;
            this.txtGrossRatio11.MultiLine = false;
            this.txtGrossRatio11.Name = "txtGrossRatio11";
            this.txtGrossRatio11.OutputFormat = resources.GetString("txtGrossRatio11.OutputFormat");
            this.txtGrossRatio11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio11.Text = "999,999,999";
            this.txtGrossRatio11.Top = 0.9374999F;
            this.txtGrossRatio11.Width = 0.6F;
            // 
            // txtGrossRatio12
            // 
            this.txtGrossRatio12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtGrossRatio12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtGrossRatio12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio12.Border.RightColor = System.Drawing.Color.Black;
            this.txtGrossRatio12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio12.Border.TopColor = System.Drawing.Color.Black;
            this.txtGrossRatio12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtGrossRatio12.DataField = "GrossRatio12";
            this.txtGrossRatio12.Height = 0.188F;
            this.txtGrossRatio12.Left = 9.395831F;
            this.txtGrossRatio12.MultiLine = false;
            this.txtGrossRatio12.Name = "txtGrossRatio12";
            this.txtGrossRatio12.OutputFormat = resources.GetString("txtGrossRatio12.OutputFormat");
            this.txtGrossRatio12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtGrossRatio12.Text = "999,999,999";
            this.txtGrossRatio12.Top = 0.9374999F;
            this.txtGrossRatio12.Width = 0.6F;
            // 
            // txtTotalGrossRatio
            // 
            this.txtTotalGrossRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalGrossRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalGrossRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalGrossRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalGrossRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalGrossRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalGrossRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalGrossRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalGrossRatio.DataField = "TotalGrossRatio";
            this.txtTotalGrossRatio.Height = 0.188F;
            this.txtTotalGrossRatio.Left = 10F;
            this.txtTotalGrossRatio.MultiLine = false;
            this.txtTotalGrossRatio.Name = "txtTotalGrossRatio";
            this.txtTotalGrossRatio.OutputFormat = resources.GetString("txtTotalGrossRatio.OutputFormat");
            this.txtTotalGrossRatio.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ" +
                " ゴシック; vertical-align: middle; ";
            this.txtTotalGrossRatio.Text = "99,999,999,999";
            this.txtTotalGrossRatio.Top = 0.9375F;
            this.txtTotalGrossRatio.Width = 0.7499995F;
            // 
            // lbTitleTTermSl
            // 
            this.lbTitleTTermSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTTermSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTTermSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTTermSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTTermSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermSl.Height = 0.188F;
            this.lbTitleTTermSl.HyperLink = null;
            this.lbTitleTTermSl.Left = 2.4375F;
            this.lbTitleTTermSl.Name = "lbTitleTTermSl";
            this.lbTitleTTermSl.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleTTermSl.Text = "当年";
            this.lbTitleTTermSl.Top = 0F;
            this.lbTitleTTermSl.Width = 0.3F;
            // 
            // lbTitleFTermSl
            // 
            this.lbTitleFTermSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleFTermSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleFTermSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleFTermSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleFTermSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermSl.Height = 0.188F;
            this.lbTitleFTermSl.HyperLink = null;
            this.lbTitleFTermSl.Left = 2.4375F;
            this.lbTitleFTermSl.Name = "lbTitleFTermSl";
            this.lbTitleFTermSl.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleFTermSl.Text = "前年";
            this.lbTitleFTermSl.Top = 0.1875F;
            this.lbTitleFTermSl.Width = 0.3F;
            // 
            // lbTitleSlRatio
            // 
            this.lbTitleSlRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSlRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSlRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSlRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSlRatio.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSlRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSlRatio.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSlRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSlRatio.Height = 0.188F;
            this.lbTitleSlRatio.HyperLink = null;
            this.lbTitleSlRatio.Left = 2.4375F;
            this.lbTitleSlRatio.Name = "lbTitleSlRatio";
            this.lbTitleSlRatio.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleSlRatio.Text = "比率";
            this.lbTitleSlRatio.Top = 0.375F;
            this.lbTitleSlRatio.Width = 0.3F;
            // 
            // lbTitleTTermGrs
            // 
            this.lbTitleTTermGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTTermGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTTermGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTTermGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTTermGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTermGrs.Height = 0.188F;
            this.lbTitleTTermGrs.HyperLink = null;
            this.lbTitleTTermGrs.Left = 2.4375F;
            this.lbTitleTTermGrs.Name = "lbTitleTTermGrs";
            this.lbTitleTTermGrs.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleTTermGrs.Text = "当年";
            this.lbTitleTTermGrs.Top = 0.5625F;
            this.lbTitleTTermGrs.Width = 0.3F;
            // 
            // lbTitleFTermGrs
            // 
            this.lbTitleFTermGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleFTermGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleFTermGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleFTermGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleFTermGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleFTermGrs.Height = 0.188F;
            this.lbTitleFTermGrs.HyperLink = null;
            this.lbTitleFTermGrs.Left = 2.4375F;
            this.lbTitleFTermGrs.Name = "lbTitleFTermGrs";
            this.lbTitleFTermGrs.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleFTermGrs.Text = "前年";
            this.lbTitleFTermGrs.Top = 0.75F;
            this.lbTitleFTermGrs.Width = 0.3F;
            // 
            // lbTitleGrsRatio
            // 
            this.lbTitleGrsRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleGrsRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrsRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleGrsRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrsRatio.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleGrsRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrsRatio.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleGrsRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrsRatio.Height = 0.188F;
            this.lbTitleGrsRatio.HyperLink = null;
            this.lbTitleGrsRatio.Left = 2.4375F;
            this.lbTitleGrsRatio.Name = "lbTitleGrsRatio";
            this.lbTitleGrsRatio.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleGrsRatio.Text = "比率";
            this.lbTitleGrsRatio.Top = 0.9374998F;
            this.lbTitleGrsRatio.Width = 0.3F;
            // 
            // lbTitleSl
            // 
            this.lbTitleSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSl.Height = 0.1875F;
            this.lbTitleSl.HyperLink = null;
            this.lbTitleSl.Left = 2.0625F;
            this.lbTitleSl.Name = "lbTitleSl";
            this.lbTitleSl.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleSl.Text = "売上：";
            this.lbTitleSl.Top = 0F;
            this.lbTitleSl.Width = 0.375F;
            // 
            // lbTitleGrs
            // 
            this.lbTitleGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleGrs.Height = 0.1875F;
            this.lbTitleGrs.HyperLink = null;
            this.lbTitleGrs.Left = 2.0625F;
            this.lbTitleGrs.Name = "lbTitleGrs";
            this.lbTitleGrs.Style = "color: Black; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.lbTitleGrs.Text = "粗利：";
            this.lbTitleGrs.Top = 0.5625F;
            this.lbTitleGrs.Width = 0.375F;
            // 
            // txtName
            // 
            this.txtName.Border.BottomColor = System.Drawing.Color.Black;
            this.txtName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.LeftColor = System.Drawing.Color.Black;
            this.txtName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.RightColor = System.Drawing.Color.Black;
            this.txtName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Border.TopColor = System.Drawing.Color.Black;
            this.txtName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtName.Height = 0.188F;
            this.txtName.Left = 0F;
            this.txtName.MultiLine = false;
            this.txtName.Name = "txtName";
            this.txtName.OutputFormat = resources.GetString("txtName.OutputFormat");
            this.txtName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.txtName.Text = null;
            this.txtName.Top = 0.1875F;
            this.txtName.Width = 2.25F;
            // 
            // txtCode
            // 
            this.txtCode.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCode.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCode.Border.RightColor = System.Drawing.Color.Black;
            this.txtCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCode.Border.TopColor = System.Drawing.Color.Black;
            this.txtCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCode.Height = 0.1875F;
            this.txtCode.Left = 0F;
            this.txtCode.Name = "txtCode";
            this.txtCode.OutputFormat = resources.GetString("txtCode.OutputFormat");
            this.txtCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: middle; ";
            this.txtCode.Text = null;
            this.txtCode.Top = 0F;
            this.txtCode.Width = 0.5F;
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
            this.line8.Top = 1.125F;
            this.line8.Visible = false;
            this.line8.Width = 10.8125F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8125F;
            this.line8.Y1 = 1.125F;
            this.line8.Y2 = 1.125F;
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
            this.line9.Height = 0F;
            this.line9.Left = 0F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 0F;
            this.line9.Width = 10.8125F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.8125F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // txtTHCode1
            // 
            this.txtTHCode1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTHCode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHCode1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTHCode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHCode1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTHCode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHCode1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTHCode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHCode1.Height = 0.188F;
            this.txtTHCode1.Left = 0.5312496F;
            this.txtTHCode1.Name = "txtTHCode1";
            this.txtTHCode1.OutputFormat = resources.GetString("txtTHCode1.OutputFormat");
            this.txtTHCode1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: middle; ";
            this.txtTHCode1.Text = null;
            this.txtTHCode1.Top = 0F;
            this.txtTHCode1.Width = 0.5F;
            // 
            // txtTHName1
            // 
            this.txtTHName1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTHName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHName1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTHName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHName1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTHName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHName1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTHName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHName1.Height = 0.188F;
            this.txtTHName1.Left = 1.031251F;
            this.txtTHName1.MultiLine = false;
            this.txtTHName1.Name = "txtTHName1";
            this.txtTHName1.OutputFormat = resources.GetString("txtTHName1.OutputFormat");
            this.txtTHName1.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.txtTHName1.Text = null;
            this.txtTHName1.Top = 0F;
            this.txtTHName1.Width = 2.25F;
            // 
            // ChangeDF_Code1
            // 
            this.ChangeDF_Code1.Border.BottomColor = System.Drawing.Color.Black;
            this.ChangeDF_Code1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Code1.Border.LeftColor = System.Drawing.Color.Black;
            this.ChangeDF_Code1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Code1.Border.RightColor = System.Drawing.Color.Black;
            this.ChangeDF_Code1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Code1.Border.TopColor = System.Drawing.Color.Black;
            this.ChangeDF_Code1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Code1.Height = 0.1875F;
            this.ChangeDF_Code1.Left = 4.104167F;
            this.ChangeDF_Code1.Name = "ChangeDF_Code1";
            this.ChangeDF_Code1.OutputFormat = resources.GetString("ChangeDF_Code1.OutputFormat");
            this.ChangeDF_Code1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: middle; ";
            this.ChangeDF_Code1.Text = null;
            this.ChangeDF_Code1.Top = 0F;
            this.ChangeDF_Code1.Width = 0.5625F;
            // 
            // ChangeDF_Name1
            // 
            this.ChangeDF_Name1.Border.BottomColor = System.Drawing.Color.Black;
            this.ChangeDF_Name1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Name1.Border.LeftColor = System.Drawing.Color.Black;
            this.ChangeDF_Name1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Name1.Border.RightColor = System.Drawing.Color.Black;
            this.ChangeDF_Name1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Name1.Border.TopColor = System.Drawing.Color.Black;
            this.ChangeDF_Name1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ChangeDF_Name1.Height = 0.188F;
            this.ChangeDF_Name1.Left = 4.666667F;
            this.ChangeDF_Name1.MultiLine = false;
            this.ChangeDF_Name1.Name = "ChangeDF_Name1";
            this.ChangeDF_Name1.OutputFormat = resources.GetString("ChangeDF_Name1.OutputFormat");
            this.ChangeDF_Name1.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; vertical-align: middle; ";
            this.ChangeDF_Name1.Text = null;
            this.ChangeDF_Name1.Top = 0F;
            this.ChangeDF_Name1.Width = 2.25F;
            // 
            // line_Hight
            // 
            this.line_Hight.Border.BottomColor = System.Drawing.Color.Black;
            this.line_Hight.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_Hight.Border.LeftColor = System.Drawing.Color.Black;
            this.line_Hight.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_Hight.Border.RightColor = System.Drawing.Color.Black;
            this.line_Hight.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_Hight.Border.TopColor = System.Drawing.Color.Black;
            this.line_Hight.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line_Hight.Height = 0F;
            this.line_Hight.Left = 0F;
            this.line_Hight.LineWeight = 1F;
            this.line_Hight.Name = "line_Hight";
            this.line_Hight.Top = 0F;
            this.line_Hight.Width = 10.8125F;
            this.line_Hight.X1 = 0F;
            this.line_Hight.X2 = 10.8125F;
            this.line_Hight.Y1 = 0F;
            this.line_Hight.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DATE,
            this.TIME,
            this.lblTitle,
            this.lblPage,
            this.txtPageNo,
            this.label40,
            this.line28,
            this.line46,
            this.SUBTITLE});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // DATE
            // 
            this.DATE.Border.BottomColor = System.Drawing.Color.Black;
            this.DATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.LeftColor = System.Drawing.Color.Black;
            this.DATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.RightColor = System.Drawing.Color.Black;
            this.DATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.TopColor = System.Drawing.Color.Black;
            this.DATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Height = 0.156F;
            this.DATE.Left = 8.5F;
            this.DATE.Name = "DATE";
            this.DATE.OutputFormat = resources.GetString("DATE.OutputFormat");
            this.DATE.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.063F;
            this.DATE.Width = 0.938F;
            // 
            // TIME
            // 
            this.TIME.Border.BottomColor = System.Drawing.Color.Black;
            this.TIME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.LeftColor = System.Drawing.Color.Black;
            this.TIME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.RightColor = System.Drawing.Color.Black;
            this.TIME.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.TopColor = System.Drawing.Color.Black;
            this.TIME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Height = 0.125F;
            this.TIME.Left = 9.438F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.063F;
            this.TIME.Width = 0.5F;
            // 
            // lblTitle
            // 
            this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Height = 0.25F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0.25F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: Black; ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: " +
                "14.25pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.lblTitle.Text = "前年対比表";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 1.1F;
            // 
            // lblPage
            // 
            this.lblPage.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.RightColor = System.Drawing.Color.Black;
            this.lblPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.TopColor = System.Drawing.Color.Black;
            this.lblPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Height = 0.156F;
            this.lblPage.HyperLink = null;
            this.lblPage.Left = 9.938F;
            this.lblPage.Name = "lblPage";
            this.lblPage.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.lblPage.Text = "ページ：";
            this.lblPage.Top = 0.063F;
            this.lblPage.Width = 0.5F;
            // 
            // txtPageNo
            // 
            this.txtPageNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Height = 0.156F;
            this.txtPageNo.Left = 10.438F;
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.txtPageNo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtPageNo.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtPageNo.Text = null;
            this.txtPageNo.Top = 0.063F;
            this.txtPageNo.Width = 0.281F;
            // 
            // label40
            // 
            this.label40.Border.BottomColor = System.Drawing.Color.Black;
            this.label40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.LeftColor = System.Drawing.Color.Black;
            this.label40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.RightColor = System.Drawing.Color.Black;
            this.label40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Border.TopColor = System.Drawing.Color.Black;
            this.label40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label40.Height = 0.156F;
            this.label40.HyperLink = null;
            this.label40.Left = 7.938F;
            this.label40.Name = "label40";
            this.label40.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align" +
                ": top; ";
            this.label40.Text = "作成日付：";
            this.label40.Top = 0.063F;
            this.label40.Width = 0.625F;
            // 
            // line28
            // 
            this.line28.Border.BottomColor = System.Drawing.Color.Black;
            this.line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.LeftColor = System.Drawing.Color.Black;
            this.line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.RightColor = System.Drawing.Color.Black;
            this.line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.TopColor = System.Drawing.Color.Black;
            this.line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Height = 0F;
            this.line28.Left = 0F;
            this.line28.LineColor = System.Drawing.Color.LimeGreen;
            this.line28.LineWeight = 2F;
            this.line28.Name = "line28";
            this.line28.Top = 0.3125F;
            this.line28.Width = 11.25F;
            this.line28.X1 = 0F;
            this.line28.X2 = 11.25F;
            this.line28.Y1 = 0.3125F;
            this.line28.Y2 = 0.3125F;
            // 
            // line46
            // 
            this.line46.Border.BottomColor = System.Drawing.Color.Black;
            this.line46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.LeftColor = System.Drawing.Color.Black;
            this.line46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.RightColor = System.Drawing.Color.Black;
            this.line46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.TopColor = System.Drawing.Color.Black;
            this.line46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Height = 0F;
            this.line46.Left = 0F;
            this.line46.LineWeight = 3F;
            this.line46.Name = "line46";
            this.line46.Top = 0.22F;
            this.line46.Width = 10.8F;
            this.line46.X1 = 0F;
            this.line46.X2 = 10.8F;
            this.line46.Y1 = 0.22F;
            this.line46.Y2 = 0.22F;
            // 
            // SUBTITLE
            // 
            this.SUBTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SUBTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUBTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SUBTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUBTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SUBTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUBTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SUBTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUBTITLE.Height = 0.25F;
            this.SUBTITLE.HyperLink = null;
            this.SUBTITLE.Left = 1.3125F;
            this.SUBTITLE.Name = "SUBTITLE";
            this.SUBTITLE.Style = "color: Black; ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: " +
                "14.25pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.SUBTITLE.Text = "";
            this.SUBTITLE.Top = 0F;
            this.SUBTITLE.Width = 2.0625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanGrow = false;
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2708333F;
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
            this.ExtraHeader.CanGrow = false;
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Extraction,
            this.line1});
            this.ExtraHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.ExtraHeader.Height = 0.3365385F;
            this.ExtraHeader.KeepTogether = true;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.NewPage = DataDynamics.ActiveReports.NewPage.After;
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Extraction
            // 
            this.Extraction.Border.BottomColor = System.Drawing.Color.Black;
            this.Extraction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.LeftColor = System.Drawing.Color.Black;
            this.Extraction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.RightColor = System.Drawing.Color.Black;
            this.Extraction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.TopColor = System.Drawing.Color.Black;
            this.Extraction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.CanShrink = true;
            this.Extraction.Height = 0.25F;
            this.Extraction.Left = 0F;
            this.Extraction.Name = "Extraction";
            this.Extraction.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ " +
                "明朝; vertical-align: middle; ";
            this.Extraction.Text = null;
            this.Extraction.Top = 0F;
            this.Extraction.Width = 10.75F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.1875F;
            this.line1.Visible = false;
            this.line1.Width = 10.8F;
            this.line1.X1 = 0F;
            this.line1.X2 = 10.8F;
            this.line1.Y1 = 0.1875F;
            this.line1.Y2 = 0.1875F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanGrow = false;
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader1
            // 
            this.TitleHeader1.CanGrow = false;
            this.TitleHeader1.CanShrink = true;
            this.TitleHeader1.ColumnGroupKeepTogether = true;
            this.TitleHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.SORTTITLE,
            this.line5,
            this.month1,
            this.month2,
            this.month3,
            this.month4,
            this.month5,
            this.month6,
            this.month7,
            this.month8,
            this.month9,
            this.month10,
            this.month11,
            this.month12,
            this.label1});
            this.TitleHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.TitleHeader1.Height = 0.2291667F;
            this.TitleHeader1.KeepTogether = true;
            this.TitleHeader1.Name = "TitleHeader1";
            this.TitleHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.line2.Top = 0.1875F;
            this.line2.Visible = false;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.1875F;
            this.line2.Y2 = 0.1875F;
            // 
            // SORTTITLE
            // 
            this.SORTTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Height = 0.188F;
            this.SORTTITLE.Left = 0F;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.SORTTITLE.Text = "拠点／得意先";
            this.SORTTITLE.Top = 0F;
            this.SORTTITLE.Width = 0.81F;
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
            // month1
            // 
            this.month1.Border.BottomColor = System.Drawing.Color.Black;
            this.month1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month1.Border.LeftColor = System.Drawing.Color.Black;
            this.month1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month1.Border.RightColor = System.Drawing.Color.Black;
            this.month1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month1.Border.TopColor = System.Drawing.Color.Black;
            this.month1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month1.Height = 0.188F;
            this.month1.HyperLink = null;
            this.month1.Left = 2.749998F;
            this.month1.Name = "month1";
            this.month1.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month1.Text = "";
            this.month1.Top = 0F;
            this.month1.Width = 0.6F;
            // 
            // month2
            // 
            this.month2.Border.BottomColor = System.Drawing.Color.Black;
            this.month2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month2.Border.LeftColor = System.Drawing.Color.Black;
            this.month2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month2.Border.RightColor = System.Drawing.Color.Black;
            this.month2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month2.Border.TopColor = System.Drawing.Color.Black;
            this.month2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month2.Height = 0.188F;
            this.month2.HyperLink = null;
            this.month2.Left = 3.35417F;
            this.month2.Name = "month2";
            this.month2.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month2.Text = "";
            this.month2.Top = 0F;
            this.month2.Width = 0.6F;
            // 
            // month3
            // 
            this.month3.Border.BottomColor = System.Drawing.Color.Black;
            this.month3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month3.Border.LeftColor = System.Drawing.Color.Black;
            this.month3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month3.Border.RightColor = System.Drawing.Color.Black;
            this.month3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month3.Border.TopColor = System.Drawing.Color.Black;
            this.month3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month3.Height = 0.188F;
            this.month3.HyperLink = null;
            this.month3.Left = 3.958335F;
            this.month3.Name = "month3";
            this.month3.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month3.Text = "";
            this.month3.Top = 0F;
            this.month3.Width = 0.6F;
            // 
            // month4
            // 
            this.month4.Border.BottomColor = System.Drawing.Color.Black;
            this.month4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month4.Border.LeftColor = System.Drawing.Color.Black;
            this.month4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month4.Border.RightColor = System.Drawing.Color.Black;
            this.month4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month4.Border.TopColor = System.Drawing.Color.Black;
            this.month4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month4.Height = 0.188F;
            this.month4.HyperLink = null;
            this.month4.Left = 4.562502F;
            this.month4.Name = "month4";
            this.month4.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month4.Text = "";
            this.month4.Top = 0F;
            this.month4.Width = 0.6F;
            // 
            // month5
            // 
            this.month5.Border.BottomColor = System.Drawing.Color.Black;
            this.month5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month5.Border.LeftColor = System.Drawing.Color.Black;
            this.month5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month5.Border.RightColor = System.Drawing.Color.Black;
            this.month5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month5.Border.TopColor = System.Drawing.Color.Black;
            this.month5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month5.Height = 0.188F;
            this.month5.HyperLink = null;
            this.month5.Left = 5.166668F;
            this.month5.Name = "month5";
            this.month5.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month5.Text = "";
            this.month5.Top = 0F;
            this.month5.Width = 0.6F;
            // 
            // month6
            // 
            this.month6.Border.BottomColor = System.Drawing.Color.Black;
            this.month6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month6.Border.LeftColor = System.Drawing.Color.Black;
            this.month6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month6.Border.RightColor = System.Drawing.Color.Black;
            this.month6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month6.Border.TopColor = System.Drawing.Color.Black;
            this.month6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month6.Height = 0.188F;
            this.month6.HyperLink = null;
            this.month6.Left = 5.770834F;
            this.month6.Name = "month6";
            this.month6.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month6.Text = "";
            this.month6.Top = 0F;
            this.month6.Width = 0.6F;
            // 
            // month7
            // 
            this.month7.Border.BottomColor = System.Drawing.Color.Black;
            this.month7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month7.Border.LeftColor = System.Drawing.Color.Black;
            this.month7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month7.Border.RightColor = System.Drawing.Color.Black;
            this.month7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month7.Border.TopColor = System.Drawing.Color.Black;
            this.month7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month7.Height = 0.188F;
            this.month7.HyperLink = null;
            this.month7.Left = 6.375001F;
            this.month7.Name = "month7";
            this.month7.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month7.Text = "";
            this.month7.Top = 0F;
            this.month7.Width = 0.6F;
            // 
            // month8
            // 
            this.month8.Border.BottomColor = System.Drawing.Color.Black;
            this.month8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month8.Border.LeftColor = System.Drawing.Color.Black;
            this.month8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month8.Border.RightColor = System.Drawing.Color.Black;
            this.month8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month8.Border.TopColor = System.Drawing.Color.Black;
            this.month8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month8.Height = 0.188F;
            this.month8.HyperLink = null;
            this.month8.Left = 6.979168F;
            this.month8.Name = "month8";
            this.month8.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month8.Text = "";
            this.month8.Top = 0F;
            this.month8.Width = 0.6F;
            // 
            // month9
            // 
            this.month9.Border.BottomColor = System.Drawing.Color.Black;
            this.month9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month9.Border.LeftColor = System.Drawing.Color.Black;
            this.month9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month9.Border.RightColor = System.Drawing.Color.Black;
            this.month9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month9.Border.TopColor = System.Drawing.Color.Black;
            this.month9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month9.Height = 0.188F;
            this.month9.HyperLink = null;
            this.month9.Left = 7.583334F;
            this.month9.Name = "month9";
            this.month9.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month9.Text = "";
            this.month9.Top = 0F;
            this.month9.Width = 0.6F;
            // 
            // month10
            // 
            this.month10.Border.BottomColor = System.Drawing.Color.Black;
            this.month10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month10.Border.LeftColor = System.Drawing.Color.Black;
            this.month10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month10.Border.RightColor = System.Drawing.Color.Black;
            this.month10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month10.Border.TopColor = System.Drawing.Color.Black;
            this.month10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month10.Height = 0.188F;
            this.month10.HyperLink = null;
            this.month10.Left = 8.187502F;
            this.month10.Name = "month10";
            this.month10.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month10.Text = "";
            this.month10.Top = 0F;
            this.month10.Width = 0.6F;
            // 
            // month11
            // 
            this.month11.Border.BottomColor = System.Drawing.Color.Black;
            this.month11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month11.Border.LeftColor = System.Drawing.Color.Black;
            this.month11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month11.Border.RightColor = System.Drawing.Color.Black;
            this.month11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month11.Border.TopColor = System.Drawing.Color.Black;
            this.month11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month11.Height = 0.188F;
            this.month11.HyperLink = null;
            this.month11.Left = 8.791668F;
            this.month11.Name = "month11";
            this.month11.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month11.Text = "";
            this.month11.Top = 0F;
            this.month11.Width = 0.6F;
            // 
            // month12
            // 
            this.month12.Border.BottomColor = System.Drawing.Color.Black;
            this.month12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month12.Border.LeftColor = System.Drawing.Color.Black;
            this.month12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month12.Border.RightColor = System.Drawing.Color.Black;
            this.month12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month12.Border.TopColor = System.Drawing.Color.Black;
            this.month12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.month12.Height = 0.188F;
            this.month12.HyperLink = null;
            this.month12.Left = 9.395831F;
            this.month12.Name = "month12";
            this.month12.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.month12.Text = "";
            this.month12.Top = 0F;
            this.month12.Width = 0.6F;
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
            this.label1.Left = 10F;
            this.label1.Name = "label1";
            this.label1.Style = "color: Black; text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.label1.Text = "合計";
            this.label1.Top = 0F;
            this.label1.Width = 0.7499995F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanGrow = false;
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTTSales1,
            this.txtTTSales2,
            this.txtTTSales3,
            this.txtTTSales4,
            this.txtTTSales5,
            this.txtTTSales6,
            this.txtTTSales7,
            this.txtTTSales8,
            this.txtTTSales9,
            this.txtTTSales10,
            this.txtTTSales11,
            this.txtTTSales12,
            this.txtTTTotalSales,
            this.txtTFSales1,
            this.txtTFSales2,
            this.txtTFSales3,
            this.txtTFSales4,
            this.txtTFSales5,
            this.txtTFSales6,
            this.txtTFSales7,
            this.txtTFSales8,
            this.txtTFSales9,
            this.txtTFSales10,
            this.txtTFSales11,
            this.txtTFSales12,
            this.txtTFTotalSales,
            this.txtTSalesRt1,
            this.txtTSalesRt2,
            this.txtTSalesRt3,
            this.txtTSalesRt4,
            this.txtTSalesRt5,
            this.txtTSalesRt6,
            this.txtTSalesRt7,
            this.txtTSalesRt8,
            this.txtTSalesRt9,
            this.txtTSalesRt10,
            this.txtTSalesRt11,
            this.txtTSalesRt12,
            this.txtTTotalSalesRt,
            this.txtTTGross1,
            this.txtTTGross2,
            this.txtTTGross3,
            this.txtTTGross4,
            this.txtTTGross5,
            this.txtTTGross6,
            this.txtTTGross7,
            this.txtTTGross8,
            this.txtTTGross9,
            this.txtTTGross10,
            this.txtTTGross11,
            this.txtTTGross12,
            this.txtTTTotalGross,
            this.txtTFGross1,
            this.txtTFGross2,
            this.txtTFGross3,
            this.txtTFGross4,
            this.txtTFGross5,
            this.txtTFGross6,
            this.txtTFGross7,
            this.txtTFGross8,
            this.txtTFGross9,
            this.txtTFGross10,
            this.txtTFGross11,
            this.txtTFGross12,
            this.txtTFTotalGross,
            this.txtTGrossRt1,
            this.txtTGrossRt2,
            this.txtTGrossRt3,
            this.txtTGrossRt4,
            this.txtTGrossRt5,
            this.txtTGrossRt6,
            this.txtTGrossRt7,
            this.txtTGrossRt8,
            this.txtTGrossRt9,
            this.txtTGrossRt10,
            this.txtTGrossRt11,
            this.txtTGrossRt12,
            this.txtTTotalGrossRt,
            this.textBox120,
            this.lbTitleTTSl,
            this.lbTitleTFSl,
            this.lbTitleTSlRt,
            this.lbTitleTTGrs,
            this.lbTitleTFGrs,
            this.lbTitleTGrsRt,
            this.line3,
            this.lbTitleToTSl,
            this.lbTitleToTGrs});
            this.TitleFooter.Height = 1.215F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Format += new System.EventHandler(this.TitleFooter_Format);
            this.TitleFooter.BeforePrint += new System.EventHandler(this.TitleFooter_BeforePrint);
            // 
            // txtTTSales1
            // 
            this.txtTTSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales1.DataField = "ThisTermSales1";
            this.txtTTSales1.Height = 0.188F;
            this.txtTTSales1.Left = 2.749998F;
            this.txtTTSales1.MultiLine = false;
            this.txtTTSales1.Name = "txtTTSales1";
            this.txtTTSales1.OutputFormat = resources.GetString("txtTTSales1.OutputFormat");
            this.txtTTSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales1.Text = "999,999,999";
            this.txtTTSales1.Top = 0F;
            this.txtTTSales1.Width = 0.6F;
            // 
            // txtTTSales2
            // 
            this.txtTTSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales2.DataField = "ThisTermSales2";
            this.txtTTSales2.Height = 0.188F;
            this.txtTTSales2.Left = 3.35417F;
            this.txtTTSales2.MultiLine = false;
            this.txtTTSales2.Name = "txtTTSales2";
            this.txtTTSales2.OutputFormat = resources.GetString("txtTTSales2.OutputFormat");
            this.txtTTSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales2.Text = "999,999,999";
            this.txtTTSales2.Top = 0F;
            this.txtTTSales2.Width = 0.6F;
            // 
            // txtTTSales3
            // 
            this.txtTTSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales3.DataField = "ThisTermSales3";
            this.txtTTSales3.Height = 0.188F;
            this.txtTTSales3.Left = 3.958335F;
            this.txtTTSales3.MultiLine = false;
            this.txtTTSales3.Name = "txtTTSales3";
            this.txtTTSales3.OutputFormat = resources.GetString("txtTTSales3.OutputFormat");
            this.txtTTSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales3.Text = "999,999,999";
            this.txtTTSales3.Top = 0F;
            this.txtTTSales3.Width = 0.6F;
            // 
            // txtTTSales4
            // 
            this.txtTTSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales4.DataField = "ThisTermSales4";
            this.txtTTSales4.Height = 0.188F;
            this.txtTTSales4.Left = 4.562502F;
            this.txtTTSales4.MultiLine = false;
            this.txtTTSales4.Name = "txtTTSales4";
            this.txtTTSales4.OutputFormat = resources.GetString("txtTTSales4.OutputFormat");
            this.txtTTSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales4.Text = "999,999,999";
            this.txtTTSales4.Top = 0F;
            this.txtTTSales4.Width = 0.6F;
            // 
            // txtTTSales5
            // 
            this.txtTTSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales5.DataField = "ThisTermSales5";
            this.txtTTSales5.Height = 0.188F;
            this.txtTTSales5.Left = 5.166668F;
            this.txtTTSales5.MultiLine = false;
            this.txtTTSales5.Name = "txtTTSales5";
            this.txtTTSales5.OutputFormat = resources.GetString("txtTTSales5.OutputFormat");
            this.txtTTSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales5.Text = "999,999,999";
            this.txtTTSales5.Top = 0F;
            this.txtTTSales5.Width = 0.6F;
            // 
            // txtTTSales6
            // 
            this.txtTTSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales6.DataField = "ThisTermSales6";
            this.txtTTSales6.Height = 0.188F;
            this.txtTTSales6.Left = 5.770834F;
            this.txtTTSales6.MultiLine = false;
            this.txtTTSales6.Name = "txtTTSales6";
            this.txtTTSales6.OutputFormat = resources.GetString("txtTTSales6.OutputFormat");
            this.txtTTSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales6.Text = "999,999,999";
            this.txtTTSales6.Top = 0F;
            this.txtTTSales6.Width = 0.6F;
            // 
            // txtTTSales7
            // 
            this.txtTTSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales7.DataField = "ThisTermSales7";
            this.txtTTSales7.Height = 0.188F;
            this.txtTTSales7.Left = 6.375001F;
            this.txtTTSales7.MultiLine = false;
            this.txtTTSales7.Name = "txtTTSales7";
            this.txtTTSales7.OutputFormat = resources.GetString("txtTTSales7.OutputFormat");
            this.txtTTSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales7.Text = "999,999,999";
            this.txtTTSales7.Top = 0F;
            this.txtTTSales7.Width = 0.6F;
            // 
            // txtTTSales8
            // 
            this.txtTTSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales8.DataField = "ThisTermSales8";
            this.txtTTSales8.Height = 0.188F;
            this.txtTTSales8.Left = 6.979168F;
            this.txtTTSales8.MultiLine = false;
            this.txtTTSales8.Name = "txtTTSales8";
            this.txtTTSales8.OutputFormat = resources.GetString("txtTTSales8.OutputFormat");
            this.txtTTSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales8.Text = "999,999,999";
            this.txtTTSales8.Top = 0F;
            this.txtTTSales8.Width = 0.6F;
            // 
            // txtTTSales9
            // 
            this.txtTTSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales9.DataField = "ThisTermSales9";
            this.txtTTSales9.Height = 0.188F;
            this.txtTTSales9.Left = 7.583334F;
            this.txtTTSales9.MultiLine = false;
            this.txtTTSales9.Name = "txtTTSales9";
            this.txtTTSales9.OutputFormat = resources.GetString("txtTTSales9.OutputFormat");
            this.txtTTSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales9.Text = "999,999,999";
            this.txtTTSales9.Top = 0F;
            this.txtTTSales9.Width = 0.6F;
            // 
            // txtTTSales10
            // 
            this.txtTTSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales10.DataField = "ThisTermSales10";
            this.txtTTSales10.Height = 0.188F;
            this.txtTTSales10.Left = 8.187502F;
            this.txtTTSales10.MultiLine = false;
            this.txtTTSales10.Name = "txtTTSales10";
            this.txtTTSales10.OutputFormat = resources.GetString("txtTTSales10.OutputFormat");
            this.txtTTSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales10.Text = "999,999,999";
            this.txtTTSales10.Top = 0F;
            this.txtTTSales10.Width = 0.6F;
            // 
            // txtTTSales11
            // 
            this.txtTTSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales11.DataField = "ThisTermSales11";
            this.txtTTSales11.Height = 0.188F;
            this.txtTTSales11.Left = 8.791668F;
            this.txtTTSales11.MultiLine = false;
            this.txtTTSales11.Name = "txtTTSales11";
            this.txtTTSales11.OutputFormat = resources.GetString("txtTTSales11.OutputFormat");
            this.txtTTSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales11.Text = "999,999,999";
            this.txtTTSales11.Top = 0F;
            this.txtTTSales11.Width = 0.6F;
            // 
            // txtTTSales12
            // 
            this.txtTTSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTSales12.DataField = "ThisTermSales12";
            this.txtTTSales12.Height = 0.188F;
            this.txtTTSales12.Left = 9.395831F;
            this.txtTTSales12.MultiLine = false;
            this.txtTTSales12.Name = "txtTTSales12";
            this.txtTTSales12.OutputFormat = resources.GetString("txtTTSales12.OutputFormat");
            this.txtTTSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTSales12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTSales12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTSales12.Text = "999,999,999";
            this.txtTTSales12.Top = 0F;
            this.txtTTSales12.Width = 0.6F;
            // 
            // txtTTTotalSales
            // 
            this.txtTTTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalSales.DataField = "ThisTermTotalSales";
            this.txtTTTotalSales.Height = 0.188F;
            this.txtTTTotalSales.Left = 10F;
            this.txtTTTotalSales.MultiLine = false;
            this.txtTTTotalSales.Name = "txtTTTotalSales";
            this.txtTTTotalSales.OutputFormat = resources.GetString("txtTTTotalSales.OutputFormat");
            this.txtTTTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTTotalSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTTotalSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTTotalSales.Text = "99,999,999,999";
            this.txtTTTotalSales.Top = 0F;
            this.txtTTTotalSales.Width = 0.7499995F;
            // 
            // txtTFSales1
            // 
            this.txtTFSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales1.DataField = "FirstTermSales1";
            this.txtTFSales1.Height = 0.188F;
            this.txtTFSales1.Left = 2.749998F;
            this.txtTFSales1.MultiLine = false;
            this.txtTFSales1.Name = "txtTFSales1";
            this.txtTFSales1.OutputFormat = resources.GetString("txtTFSales1.OutputFormat");
            this.txtTFSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales1.Text = "999,999,999";
            this.txtTFSales1.Top = 0.1875001F;
            this.txtTFSales1.Width = 0.6F;
            // 
            // txtTFSales2
            // 
            this.txtTFSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales2.DataField = "FirstTermSales2";
            this.txtTFSales2.Height = 0.188F;
            this.txtTFSales2.Left = 3.35417F;
            this.txtTFSales2.MultiLine = false;
            this.txtTFSales2.Name = "txtTFSales2";
            this.txtTFSales2.OutputFormat = resources.GetString("txtTFSales2.OutputFormat");
            this.txtTFSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales2.Text = "999,999,999";
            this.txtTFSales2.Top = 0.1875001F;
            this.txtTFSales2.Width = 0.6F;
            // 
            // txtTFSales3
            // 
            this.txtTFSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales3.DataField = "FirstTermSales3";
            this.txtTFSales3.Height = 0.188F;
            this.txtTFSales3.Left = 3.958335F;
            this.txtTFSales3.MultiLine = false;
            this.txtTFSales3.Name = "txtTFSales3";
            this.txtTFSales3.OutputFormat = resources.GetString("txtTFSales3.OutputFormat");
            this.txtTFSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales3.Text = "999,999,999";
            this.txtTFSales3.Top = 0.1875001F;
            this.txtTFSales3.Width = 0.6F;
            // 
            // txtTFSales4
            // 
            this.txtTFSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales4.DataField = "FirstTermSales4";
            this.txtTFSales4.Height = 0.188F;
            this.txtTFSales4.Left = 4.562502F;
            this.txtTFSales4.MultiLine = false;
            this.txtTFSales4.Name = "txtTFSales4";
            this.txtTFSales4.OutputFormat = resources.GetString("txtTFSales4.OutputFormat");
            this.txtTFSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales4.Text = "999,999,999";
            this.txtTFSales4.Top = 0.1875001F;
            this.txtTFSales4.Width = 0.6F;
            // 
            // txtTFSales5
            // 
            this.txtTFSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales5.DataField = "FirstTermSales5";
            this.txtTFSales5.Height = 0.188F;
            this.txtTFSales5.Left = 5.166668F;
            this.txtTFSales5.MultiLine = false;
            this.txtTFSales5.Name = "txtTFSales5";
            this.txtTFSales5.OutputFormat = resources.GetString("txtTFSales5.OutputFormat");
            this.txtTFSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales5.Text = "999,999,999";
            this.txtTFSales5.Top = 0.1875001F;
            this.txtTFSales5.Width = 0.6F;
            // 
            // txtTFSales6
            // 
            this.txtTFSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales6.DataField = "FirstTermSales6";
            this.txtTFSales6.Height = 0.188F;
            this.txtTFSales6.Left = 5.770834F;
            this.txtTFSales6.MultiLine = false;
            this.txtTFSales6.Name = "txtTFSales6";
            this.txtTFSales6.OutputFormat = resources.GetString("txtTFSales6.OutputFormat");
            this.txtTFSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales6.Text = "999,999,999";
            this.txtTFSales6.Top = 0.1875001F;
            this.txtTFSales6.Width = 0.6F;
            // 
            // txtTFSales7
            // 
            this.txtTFSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales7.DataField = "FirstTermSales7";
            this.txtTFSales7.Height = 0.188F;
            this.txtTFSales7.Left = 6.375001F;
            this.txtTFSales7.MultiLine = false;
            this.txtTFSales7.Name = "txtTFSales7";
            this.txtTFSales7.OutputFormat = resources.GetString("txtTFSales7.OutputFormat");
            this.txtTFSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales7.Text = "999,999,999";
            this.txtTFSales7.Top = 0.1875001F;
            this.txtTFSales7.Width = 0.6F;
            // 
            // txtTFSales8
            // 
            this.txtTFSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales8.DataField = "FirstTermSales8";
            this.txtTFSales8.Height = 0.188F;
            this.txtTFSales8.Left = 6.979168F;
            this.txtTFSales8.MultiLine = false;
            this.txtTFSales8.Name = "txtTFSales8";
            this.txtTFSales8.OutputFormat = resources.GetString("txtTFSales8.OutputFormat");
            this.txtTFSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales8.Text = "999,999,999";
            this.txtTFSales8.Top = 0.1875001F;
            this.txtTFSales8.Width = 0.6F;
            // 
            // txtTFSales9
            // 
            this.txtTFSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales9.DataField = "FirstTermSales9";
            this.txtTFSales9.Height = 0.188F;
            this.txtTFSales9.Left = 7.583334F;
            this.txtTFSales9.MultiLine = false;
            this.txtTFSales9.Name = "txtTFSales9";
            this.txtTFSales9.OutputFormat = resources.GetString("txtTFSales9.OutputFormat");
            this.txtTFSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales9.Text = "999,999,999";
            this.txtTFSales9.Top = 0.1875001F;
            this.txtTFSales9.Width = 0.6F;
            // 
            // txtTFSales10
            // 
            this.txtTFSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales10.DataField = "FirstTermSales10";
            this.txtTFSales10.Height = 0.188F;
            this.txtTFSales10.Left = 8.187502F;
            this.txtTFSales10.MultiLine = false;
            this.txtTFSales10.Name = "txtTFSales10";
            this.txtTFSales10.OutputFormat = resources.GetString("txtTFSales10.OutputFormat");
            this.txtTFSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales10.Text = "999,999,999";
            this.txtTFSales10.Top = 0.1875001F;
            this.txtTFSales10.Width = 0.6F;
            // 
            // txtTFSales11
            // 
            this.txtTFSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales11.DataField = "FirstTermSales11";
            this.txtTFSales11.Height = 0.188F;
            this.txtTFSales11.Left = 8.791668F;
            this.txtTFSales11.MultiLine = false;
            this.txtTFSales11.Name = "txtTFSales11";
            this.txtTFSales11.OutputFormat = resources.GetString("txtTFSales11.OutputFormat");
            this.txtTFSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales11.Text = "999,999,999";
            this.txtTFSales11.Top = 0.1875001F;
            this.txtTFSales11.Width = 0.6F;
            // 
            // txtTFSales12
            // 
            this.txtTFSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFSales12.DataField = "FirstTermSales12";
            this.txtTFSales12.Height = 0.188F;
            this.txtTFSales12.Left = 9.395831F;
            this.txtTFSales12.MultiLine = false;
            this.txtTFSales12.Name = "txtTFSales12";
            this.txtTFSales12.OutputFormat = resources.GetString("txtTFSales12.OutputFormat");
            this.txtTFSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFSales12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFSales12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFSales12.Text = "999,999,999";
            this.txtTFSales12.Top = 0.1875001F;
            this.txtTFSales12.Width = 0.6F;
            // 
            // txtTFTotalSales
            // 
            this.txtTFTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalSales.DataField = "FirstTermTotalSales";
            this.txtTFTotalSales.Height = 0.188F;
            this.txtTFTotalSales.Left = 10F;
            this.txtTFTotalSales.MultiLine = false;
            this.txtTFTotalSales.Name = "txtTFTotalSales";
            this.txtTFTotalSales.OutputFormat = resources.GetString("txtTFTotalSales.OutputFormat");
            this.txtTFTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFTotalSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFTotalSales.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFTotalSales.Text = "99,999,999,999";
            this.txtTFTotalSales.Top = 0.1875001F;
            this.txtTFTotalSales.Width = 0.7499995F;
            // 
            // txtTSalesRt1
            // 
            this.txtTSalesRt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt1.Height = 0.188F;
            this.txtTSalesRt1.Left = 2.749998F;
            this.txtTSalesRt1.MultiLine = false;
            this.txtTSalesRt1.Name = "txtTSalesRt1";
            this.txtTSalesRt1.OutputFormat = resources.GetString("txtTSalesRt1.OutputFormat");
            this.txtTSalesRt1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt1.Text = "999,999,999";
            this.txtTSalesRt1.Top = 0.3749996F;
            this.txtTSalesRt1.Width = 0.6F;
            // 
            // txtTSalesRt2
            // 
            this.txtTSalesRt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt2.Height = 0.188F;
            this.txtTSalesRt2.Left = 3.35417F;
            this.txtTSalesRt2.MultiLine = false;
            this.txtTSalesRt2.Name = "txtTSalesRt2";
            this.txtTSalesRt2.OutputFormat = resources.GetString("txtTSalesRt2.OutputFormat");
            this.txtTSalesRt2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt2.Text = "999,999,999";
            this.txtTSalesRt2.Top = 0.3749996F;
            this.txtTSalesRt2.Width = 0.6F;
            // 
            // txtTSalesRt3
            // 
            this.txtTSalesRt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt3.Height = 0.188F;
            this.txtTSalesRt3.Left = 3.958335F;
            this.txtTSalesRt3.MultiLine = false;
            this.txtTSalesRt3.Name = "txtTSalesRt3";
            this.txtTSalesRt3.OutputFormat = resources.GetString("txtTSalesRt3.OutputFormat");
            this.txtTSalesRt3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt3.Text = "999,999,999";
            this.txtTSalesRt3.Top = 0.3749996F;
            this.txtTSalesRt3.Width = 0.6F;
            // 
            // txtTSalesRt4
            // 
            this.txtTSalesRt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt4.Height = 0.188F;
            this.txtTSalesRt4.Left = 4.562502F;
            this.txtTSalesRt4.MultiLine = false;
            this.txtTSalesRt4.Name = "txtTSalesRt4";
            this.txtTSalesRt4.OutputFormat = resources.GetString("txtTSalesRt4.OutputFormat");
            this.txtTSalesRt4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt4.Text = "999,999,999";
            this.txtTSalesRt4.Top = 0.3749996F;
            this.txtTSalesRt4.Width = 0.6F;
            // 
            // txtTSalesRt5
            // 
            this.txtTSalesRt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt5.Height = 0.188F;
            this.txtTSalesRt5.Left = 5.166668F;
            this.txtTSalesRt5.MultiLine = false;
            this.txtTSalesRt5.Name = "txtTSalesRt5";
            this.txtTSalesRt5.OutputFormat = resources.GetString("txtTSalesRt5.OutputFormat");
            this.txtTSalesRt5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt5.Text = "999,999,999";
            this.txtTSalesRt5.Top = 0.3749996F;
            this.txtTSalesRt5.Width = 0.6F;
            // 
            // txtTSalesRt6
            // 
            this.txtTSalesRt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt6.Height = 0.188F;
            this.txtTSalesRt6.Left = 5.770834F;
            this.txtTSalesRt6.MultiLine = false;
            this.txtTSalesRt6.Name = "txtTSalesRt6";
            this.txtTSalesRt6.OutputFormat = resources.GetString("txtTSalesRt6.OutputFormat");
            this.txtTSalesRt6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt6.Text = "999,999,999";
            this.txtTSalesRt6.Top = 0.3749996F;
            this.txtTSalesRt6.Width = 0.6F;
            // 
            // txtTSalesRt7
            // 
            this.txtTSalesRt7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt7.Height = 0.188F;
            this.txtTSalesRt7.Left = 6.375001F;
            this.txtTSalesRt7.MultiLine = false;
            this.txtTSalesRt7.Name = "txtTSalesRt7";
            this.txtTSalesRt7.OutputFormat = resources.GetString("txtTSalesRt7.OutputFormat");
            this.txtTSalesRt7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt7.Text = "999,999,999";
            this.txtTSalesRt7.Top = 0.3749996F;
            this.txtTSalesRt7.Width = 0.6F;
            // 
            // txtTSalesRt8
            // 
            this.txtTSalesRt8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt8.Height = 0.188F;
            this.txtTSalesRt8.Left = 6.979168F;
            this.txtTSalesRt8.MultiLine = false;
            this.txtTSalesRt8.Name = "txtTSalesRt8";
            this.txtTSalesRt8.OutputFormat = resources.GetString("txtTSalesRt8.OutputFormat");
            this.txtTSalesRt8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt8.Text = "999,999,999";
            this.txtTSalesRt8.Top = 0.3749996F;
            this.txtTSalesRt8.Width = 0.6F;
            // 
            // txtTSalesRt9
            // 
            this.txtTSalesRt9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt9.Height = 0.188F;
            this.txtTSalesRt9.Left = 7.583334F;
            this.txtTSalesRt9.MultiLine = false;
            this.txtTSalesRt9.Name = "txtTSalesRt9";
            this.txtTSalesRt9.OutputFormat = resources.GetString("txtTSalesRt9.OutputFormat");
            this.txtTSalesRt9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt9.Text = "999,999,999";
            this.txtTSalesRt9.Top = 0.3749996F;
            this.txtTSalesRt9.Width = 0.6F;
            // 
            // txtTSalesRt10
            // 
            this.txtTSalesRt10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt10.Height = 0.188F;
            this.txtTSalesRt10.Left = 8.187502F;
            this.txtTSalesRt10.MultiLine = false;
            this.txtTSalesRt10.Name = "txtTSalesRt10";
            this.txtTSalesRt10.OutputFormat = resources.GetString("txtTSalesRt10.OutputFormat");
            this.txtTSalesRt10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt10.Text = "999,999,999";
            this.txtTSalesRt10.Top = 0.3749996F;
            this.txtTSalesRt10.Width = 0.6F;
            // 
            // txtTSalesRt11
            // 
            this.txtTSalesRt11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt11.Height = 0.188F;
            this.txtTSalesRt11.Left = 8.791668F;
            this.txtTSalesRt11.MultiLine = false;
            this.txtTSalesRt11.Name = "txtTSalesRt11";
            this.txtTSalesRt11.OutputFormat = resources.GetString("txtTSalesRt11.OutputFormat");
            this.txtTSalesRt11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt11.Text = "999,999,999";
            this.txtTSalesRt11.Top = 0.3749996F;
            this.txtTSalesRt11.Width = 0.6F;
            // 
            // txtTSalesRt12
            // 
            this.txtTSalesRt12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTSalesRt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTSalesRt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTSalesRt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTSalesRt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTSalesRt12.DataField = "SalesRatio12";
            this.txtTSalesRt12.Height = 0.188F;
            this.txtTSalesRt12.Left = 9.395831F;
            this.txtTSalesRt12.MultiLine = false;
            this.txtTSalesRt12.Name = "txtTSalesRt12";
            this.txtTSalesRt12.OutputFormat = resources.GetString("txtTSalesRt12.OutputFormat");
            this.txtTSalesRt12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTSalesRt12.Text = "999,999,999";
            this.txtTSalesRt12.Top = 0.3749996F;
            this.txtTSalesRt12.Width = 0.6F;
            // 
            // txtTTotalSalesRt
            // 
            this.txtTTotalSalesRt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTotalSalesRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalSalesRt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTotalSalesRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalSalesRt.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTotalSalesRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalSalesRt.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTotalSalesRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalSalesRt.Height = 0.188F;
            this.txtTTotalSalesRt.Left = 10F;
            this.txtTTotalSalesRt.MultiLine = false;
            this.txtTTotalSalesRt.Name = "txtTTotalSalesRt";
            this.txtTTotalSalesRt.OutputFormat = resources.GetString("txtTTotalSalesRt.OutputFormat");
            this.txtTTotalSalesRt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTotalSalesRt.Text = "99,999,999,999";
            this.txtTTotalSalesRt.Top = 0.3749996F;
            this.txtTTotalSalesRt.Width = 0.7499995F;
            // 
            // txtTTGross1
            // 
            this.txtTTGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross1.DataField = "ThisTermGross1";
            this.txtTTGross1.Height = 0.188F;
            this.txtTTGross1.Left = 2.749998F;
            this.txtTTGross1.MultiLine = false;
            this.txtTTGross1.Name = "txtTTGross1";
            this.txtTTGross1.OutputFormat = resources.GetString("txtTTGross1.OutputFormat");
            this.txtTTGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross1.Text = "999,999,999";
            this.txtTTGross1.Top = 0.5624997F;
            this.txtTTGross1.Width = 0.6F;
            // 
            // txtTTGross2
            // 
            this.txtTTGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross2.DataField = "ThisTermGross2";
            this.txtTTGross2.Height = 0.188F;
            this.txtTTGross2.Left = 3.35417F;
            this.txtTTGross2.MultiLine = false;
            this.txtTTGross2.Name = "txtTTGross2";
            this.txtTTGross2.OutputFormat = resources.GetString("txtTTGross2.OutputFormat");
            this.txtTTGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross2.Text = "999,999,999";
            this.txtTTGross2.Top = 0.5624997F;
            this.txtTTGross2.Width = 0.6F;
            // 
            // txtTTGross3
            // 
            this.txtTTGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross3.DataField = "ThisTermGross3";
            this.txtTTGross3.Height = 0.188F;
            this.txtTTGross3.Left = 3.958335F;
            this.txtTTGross3.MultiLine = false;
            this.txtTTGross3.Name = "txtTTGross3";
            this.txtTTGross3.OutputFormat = resources.GetString("txtTTGross3.OutputFormat");
            this.txtTTGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross3.Text = "999,999,999";
            this.txtTTGross3.Top = 0.5624997F;
            this.txtTTGross3.Width = 0.6F;
            // 
            // txtTTGross4
            // 
            this.txtTTGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross4.DataField = "ThisTermGross4";
            this.txtTTGross4.Height = 0.188F;
            this.txtTTGross4.Left = 4.562502F;
            this.txtTTGross4.MultiLine = false;
            this.txtTTGross4.Name = "txtTTGross4";
            this.txtTTGross4.OutputFormat = resources.GetString("txtTTGross4.OutputFormat");
            this.txtTTGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross4.Text = "999,999,999";
            this.txtTTGross4.Top = 0.5624997F;
            this.txtTTGross4.Width = 0.6F;
            // 
            // txtTTGross5
            // 
            this.txtTTGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross5.DataField = "ThisTermGross5";
            this.txtTTGross5.Height = 0.188F;
            this.txtTTGross5.Left = 5.166668F;
            this.txtTTGross5.MultiLine = false;
            this.txtTTGross5.Name = "txtTTGross5";
            this.txtTTGross5.OutputFormat = resources.GetString("txtTTGross5.OutputFormat");
            this.txtTTGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross5.Text = "999,999,999";
            this.txtTTGross5.Top = 0.5624997F;
            this.txtTTGross5.Width = 0.6F;
            // 
            // txtTTGross6
            // 
            this.txtTTGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross6.DataField = "ThisTermGross6";
            this.txtTTGross6.Height = 0.188F;
            this.txtTTGross6.Left = 5.770834F;
            this.txtTTGross6.MultiLine = false;
            this.txtTTGross6.Name = "txtTTGross6";
            this.txtTTGross6.OutputFormat = resources.GetString("txtTTGross6.OutputFormat");
            this.txtTTGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross6.Text = "999,999,999";
            this.txtTTGross6.Top = 0.5624997F;
            this.txtTTGross6.Width = 0.6F;
            // 
            // txtTTGross7
            // 
            this.txtTTGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross7.DataField = "ThisTermGross7";
            this.txtTTGross7.Height = 0.188F;
            this.txtTTGross7.Left = 6.375001F;
            this.txtTTGross7.MultiLine = false;
            this.txtTTGross7.Name = "txtTTGross7";
            this.txtTTGross7.OutputFormat = resources.GetString("txtTTGross7.OutputFormat");
            this.txtTTGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross7.Text = "999,999,999";
            this.txtTTGross7.Top = 0.5624997F;
            this.txtTTGross7.Width = 0.6F;
            // 
            // txtTTGross8
            // 
            this.txtTTGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross8.DataField = "ThisTermGross8";
            this.txtTTGross8.Height = 0.188F;
            this.txtTTGross8.Left = 6.979168F;
            this.txtTTGross8.MultiLine = false;
            this.txtTTGross8.Name = "txtTTGross8";
            this.txtTTGross8.OutputFormat = resources.GetString("txtTTGross8.OutputFormat");
            this.txtTTGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross8.Text = "999,999,999";
            this.txtTTGross8.Top = 0.5624997F;
            this.txtTTGross8.Width = 0.6F;
            // 
            // txtTTGross9
            // 
            this.txtTTGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross9.DataField = "ThisTermGross9";
            this.txtTTGross9.Height = 0.188F;
            this.txtTTGross9.Left = 7.583334F;
            this.txtTTGross9.MultiLine = false;
            this.txtTTGross9.Name = "txtTTGross9";
            this.txtTTGross9.OutputFormat = resources.GetString("txtTTGross9.OutputFormat");
            this.txtTTGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross9.Text = "999,999,999";
            this.txtTTGross9.Top = 0.5624997F;
            this.txtTTGross9.Width = 0.6F;
            // 
            // txtTTGross10
            // 
            this.txtTTGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross10.DataField = "ThisTermGross10";
            this.txtTTGross10.Height = 0.188F;
            this.txtTTGross10.Left = 8.187502F;
            this.txtTTGross10.MultiLine = false;
            this.txtTTGross10.Name = "txtTTGross10";
            this.txtTTGross10.OutputFormat = resources.GetString("txtTTGross10.OutputFormat");
            this.txtTTGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross10.Text = "999,999,999";
            this.txtTTGross10.Top = 0.5624997F;
            this.txtTTGross10.Width = 0.6F;
            // 
            // txtTTGross11
            // 
            this.txtTTGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross11.DataField = "ThisTermGross11";
            this.txtTTGross11.Height = 0.188F;
            this.txtTTGross11.Left = 8.791668F;
            this.txtTTGross11.MultiLine = false;
            this.txtTTGross11.Name = "txtTTGross11";
            this.txtTTGross11.OutputFormat = resources.GetString("txtTTGross11.OutputFormat");
            this.txtTTGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross11.Text = "999,999,999";
            this.txtTTGross11.Top = 0.5624997F;
            this.txtTTGross11.Width = 0.6F;
            // 
            // txtTTGross12
            // 
            this.txtTTGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTGross12.DataField = "ThisTermGross12";
            this.txtTTGross12.Height = 0.188F;
            this.txtTTGross12.Left = 9.395831F;
            this.txtTTGross12.MultiLine = false;
            this.txtTTGross12.Name = "txtTTGross12";
            this.txtTTGross12.OutputFormat = resources.GetString("txtTTGross12.OutputFormat");
            this.txtTTGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTGross12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTGross12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTGross12.Text = "999,999,999";
            this.txtTTGross12.Top = 0.5624997F;
            this.txtTTGross12.Width = 0.6F;
            // 
            // txtTTTotalGross
            // 
            this.txtTTTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTTotalGross.DataField = "ThisTermTotalGross";
            this.txtTTTotalGross.Height = 0.188F;
            this.txtTTTotalGross.Left = 10F;
            this.txtTTTotalGross.MultiLine = false;
            this.txtTTTotalGross.Name = "txtTTTotalGross";
            this.txtTTTotalGross.OutputFormat = resources.GetString("txtTTTotalGross.OutputFormat");
            this.txtTTTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTTotalGross.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTTTotalGross.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTTTotalGross.Text = "99,999,999,999";
            this.txtTTTotalGross.Top = 0.5624997F;
            this.txtTTTotalGross.Width = 0.7499995F;
            // 
            // txtTFGross1
            // 
            this.txtTFGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross1.DataField = "FirstTermGross1";
            this.txtTFGross1.Height = 0.188F;
            this.txtTFGross1.Left = 2.749998F;
            this.txtTFGross1.MultiLine = false;
            this.txtTFGross1.Name = "txtTFGross1";
            this.txtTFGross1.OutputFormat = resources.GetString("txtTFGross1.OutputFormat");
            this.txtTFGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross1.Text = "999,999,999";
            this.txtTFGross1.Top = 0.7499996F;
            this.txtTFGross1.Width = 0.6F;
            // 
            // txtTFGross2
            // 
            this.txtTFGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross2.DataField = "FirstTermGross2";
            this.txtTFGross2.Height = 0.188F;
            this.txtTFGross2.Left = 3.35417F;
            this.txtTFGross2.MultiLine = false;
            this.txtTFGross2.Name = "txtTFGross2";
            this.txtTFGross2.OutputFormat = resources.GetString("txtTFGross2.OutputFormat");
            this.txtTFGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross2.Text = "999,999,999";
            this.txtTFGross2.Top = 0.7499996F;
            this.txtTFGross2.Width = 0.6F;
            // 
            // txtTFGross3
            // 
            this.txtTFGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross3.DataField = "FirstTermGross3";
            this.txtTFGross3.Height = 0.188F;
            this.txtTFGross3.Left = 3.958335F;
            this.txtTFGross3.MultiLine = false;
            this.txtTFGross3.Name = "txtTFGross3";
            this.txtTFGross3.OutputFormat = resources.GetString("txtTFGross3.OutputFormat");
            this.txtTFGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross3.Text = "999,999,999";
            this.txtTFGross3.Top = 0.7499996F;
            this.txtTFGross3.Width = 0.6F;
            // 
            // txtTFGross4
            // 
            this.txtTFGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross4.DataField = "FirstTermGross4";
            this.txtTFGross4.Height = 0.188F;
            this.txtTFGross4.Left = 4.562502F;
            this.txtTFGross4.MultiLine = false;
            this.txtTFGross4.Name = "txtTFGross4";
            this.txtTFGross4.OutputFormat = resources.GetString("txtTFGross4.OutputFormat");
            this.txtTFGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross4.Text = "999,999,999";
            this.txtTFGross4.Top = 0.7499996F;
            this.txtTFGross4.Width = 0.6F;
            // 
            // txtTFGross5
            // 
            this.txtTFGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross5.DataField = "FirstTermGross5";
            this.txtTFGross5.Height = 0.188F;
            this.txtTFGross5.Left = 5.166668F;
            this.txtTFGross5.MultiLine = false;
            this.txtTFGross5.Name = "txtTFGross5";
            this.txtTFGross5.OutputFormat = resources.GetString("txtTFGross5.OutputFormat");
            this.txtTFGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross5.Text = "999,999,999";
            this.txtTFGross5.Top = 0.7499996F;
            this.txtTFGross5.Width = 0.6F;
            // 
            // txtTFGross6
            // 
            this.txtTFGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross6.DataField = "FirstTermGross6";
            this.txtTFGross6.Height = 0.188F;
            this.txtTFGross6.Left = 5.770834F;
            this.txtTFGross6.MultiLine = false;
            this.txtTFGross6.Name = "txtTFGross6";
            this.txtTFGross6.OutputFormat = resources.GetString("txtTFGross6.OutputFormat");
            this.txtTFGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross6.Text = "999,999,999";
            this.txtTFGross6.Top = 0.7499996F;
            this.txtTFGross6.Width = 0.6F;
            // 
            // txtTFGross7
            // 
            this.txtTFGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross7.DataField = "FirstTermGross7";
            this.txtTFGross7.Height = 0.188F;
            this.txtTFGross7.Left = 6.375001F;
            this.txtTFGross7.MultiLine = false;
            this.txtTFGross7.Name = "txtTFGross7";
            this.txtTFGross7.OutputFormat = resources.GetString("txtTFGross7.OutputFormat");
            this.txtTFGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross7.Text = "999,999,999";
            this.txtTFGross7.Top = 0.7499996F;
            this.txtTFGross7.Width = 0.6F;
            // 
            // txtTFGross8
            // 
            this.txtTFGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross8.DataField = "FirstTermGross8";
            this.txtTFGross8.Height = 0.188F;
            this.txtTFGross8.Left = 6.979168F;
            this.txtTFGross8.MultiLine = false;
            this.txtTFGross8.Name = "txtTFGross8";
            this.txtTFGross8.OutputFormat = resources.GetString("txtTFGross8.OutputFormat");
            this.txtTFGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross8.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross8.Text = "999,999,999";
            this.txtTFGross8.Top = 0.7499996F;
            this.txtTFGross8.Width = 0.6F;
            // 
            // txtTFGross9
            // 
            this.txtTFGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross9.DataField = "FirstTermGross9";
            this.txtTFGross9.Height = 0.188F;
            this.txtTFGross9.Left = 7.583334F;
            this.txtTFGross9.MultiLine = false;
            this.txtTFGross9.Name = "txtTFGross9";
            this.txtTFGross9.OutputFormat = resources.GetString("txtTFGross9.OutputFormat");
            this.txtTFGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross9.Text = "999,999,999";
            this.txtTFGross9.Top = 0.7499996F;
            this.txtTFGross9.Width = 0.6F;
            // 
            // txtTFGross10
            // 
            this.txtTFGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross10.DataField = "FirstTermGross10";
            this.txtTFGross10.Height = 0.188F;
            this.txtTFGross10.Left = 8.187502F;
            this.txtTFGross10.MultiLine = false;
            this.txtTFGross10.Name = "txtTFGross10";
            this.txtTFGross10.OutputFormat = resources.GetString("txtTFGross10.OutputFormat");
            this.txtTFGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross10.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross10.Text = "999,999,999";
            this.txtTFGross10.Top = 0.7499996F;
            this.txtTFGross10.Width = 0.6F;
            // 
            // txtTFGross11
            // 
            this.txtTFGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross11.DataField = "FirstTermGross11";
            this.txtTFGross11.Height = 0.188F;
            this.txtTFGross11.Left = 8.791668F;
            this.txtTFGross11.MultiLine = false;
            this.txtTFGross11.Name = "txtTFGross11";
            this.txtTFGross11.OutputFormat = resources.GetString("txtTFGross11.OutputFormat");
            this.txtTFGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross11.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross11.Text = "999,999,999";
            this.txtTFGross11.Top = 0.7499996F;
            this.txtTFGross11.Width = 0.6F;
            // 
            // txtTFGross12
            // 
            this.txtTFGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFGross12.DataField = "FirstTermGross12";
            this.txtTFGross12.Height = 0.188F;
            this.txtTFGross12.Left = 9.395831F;
            this.txtTFGross12.MultiLine = false;
            this.txtTFGross12.Name = "txtTFGross12";
            this.txtTFGross12.OutputFormat = resources.GetString("txtTFGross12.OutputFormat");
            this.txtTFGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFGross12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFGross12.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFGross12.Text = "999,999,999";
            this.txtTFGross12.Top = 0.7499996F;
            this.txtTFGross12.Width = 0.6F;
            // 
            // txtTFTotalGross
            // 
            this.txtTFTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTFTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTFTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtTFTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtTFTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTFTotalGross.DataField = "FirstTermTotalGross";
            this.txtTFTotalGross.Height = 0.188F;
            this.txtTFTotalGross.Left = 10F;
            this.txtTFTotalGross.MultiLine = false;
            this.txtTFTotalGross.Name = "txtTFTotalGross";
            this.txtTFTotalGross.OutputFormat = resources.GetString("txtTFTotalGross.OutputFormat");
            this.txtTFTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTFTotalGross.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtTFTotalGross.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtTFTotalGross.Text = "99,999,999,999";
            this.txtTFTotalGross.Top = 0.7499996F;
            this.txtTFTotalGross.Width = 0.7499995F;
            // 
            // txtTGrossRt1
            // 
            this.txtTGrossRt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt1.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt1.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt1.Height = 0.188F;
            this.txtTGrossRt1.Left = 2.749998F;
            this.txtTGrossRt1.MultiLine = false;
            this.txtTGrossRt1.Name = "txtTGrossRt1";
            this.txtTGrossRt1.OutputFormat = resources.GetString("txtTGrossRt1.OutputFormat");
            this.txtTGrossRt1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt1.Text = "999,999,999";
            this.txtTGrossRt1.Top = 0.9374998F;
            this.txtTGrossRt1.Width = 0.6F;
            // 
            // txtTGrossRt2
            // 
            this.txtTGrossRt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt2.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt2.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt2.Height = 0.188F;
            this.txtTGrossRt2.Left = 3.35417F;
            this.txtTGrossRt2.MultiLine = false;
            this.txtTGrossRt2.Name = "txtTGrossRt2";
            this.txtTGrossRt2.OutputFormat = resources.GetString("txtTGrossRt2.OutputFormat");
            this.txtTGrossRt2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt2.Text = "999,999,999";
            this.txtTGrossRt2.Top = 0.9374998F;
            this.txtTGrossRt2.Width = 0.6F;
            // 
            // txtTGrossRt3
            // 
            this.txtTGrossRt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt3.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt3.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt3.Height = 0.188F;
            this.txtTGrossRt3.Left = 3.958335F;
            this.txtTGrossRt3.MultiLine = false;
            this.txtTGrossRt3.Name = "txtTGrossRt3";
            this.txtTGrossRt3.OutputFormat = resources.GetString("txtTGrossRt3.OutputFormat");
            this.txtTGrossRt3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt3.Text = "999,999,999";
            this.txtTGrossRt3.Top = 0.9374998F;
            this.txtTGrossRt3.Width = 0.6F;
            // 
            // txtTGrossRt4
            // 
            this.txtTGrossRt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt4.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt4.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt4.Height = 0.188F;
            this.txtTGrossRt4.Left = 4.562502F;
            this.txtTGrossRt4.MultiLine = false;
            this.txtTGrossRt4.Name = "txtTGrossRt4";
            this.txtTGrossRt4.OutputFormat = resources.GetString("txtTGrossRt4.OutputFormat");
            this.txtTGrossRt4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt4.Text = "999,999,999";
            this.txtTGrossRt4.Top = 0.9374998F;
            this.txtTGrossRt4.Width = 0.6F;
            // 
            // txtTGrossRt5
            // 
            this.txtTGrossRt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt5.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt5.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt5.Height = 0.188F;
            this.txtTGrossRt5.Left = 5.166668F;
            this.txtTGrossRt5.MultiLine = false;
            this.txtTGrossRt5.Name = "txtTGrossRt5";
            this.txtTGrossRt5.OutputFormat = resources.GetString("txtTGrossRt5.OutputFormat");
            this.txtTGrossRt5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt5.Text = "999,999,999";
            this.txtTGrossRt5.Top = 0.9374998F;
            this.txtTGrossRt5.Width = 0.6F;
            // 
            // txtTGrossRt6
            // 
            this.txtTGrossRt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt6.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt6.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt6.Height = 0.188F;
            this.txtTGrossRt6.Left = 5.770834F;
            this.txtTGrossRt6.MultiLine = false;
            this.txtTGrossRt6.Name = "txtTGrossRt6";
            this.txtTGrossRt6.OutputFormat = resources.GetString("txtTGrossRt6.OutputFormat");
            this.txtTGrossRt6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt6.Text = "999,999,999";
            this.txtTGrossRt6.Top = 0.9374998F;
            this.txtTGrossRt6.Width = 0.6F;
            // 
            // txtTGrossRt7
            // 
            this.txtTGrossRt7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt7.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt7.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt7.Height = 0.188F;
            this.txtTGrossRt7.Left = 6.375001F;
            this.txtTGrossRt7.MultiLine = false;
            this.txtTGrossRt7.Name = "txtTGrossRt7";
            this.txtTGrossRt7.OutputFormat = resources.GetString("txtTGrossRt7.OutputFormat");
            this.txtTGrossRt7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt7.Text = "999,999,999";
            this.txtTGrossRt7.Top = 0.9374998F;
            this.txtTGrossRt7.Width = 0.6F;
            // 
            // txtTGrossRt8
            // 
            this.txtTGrossRt8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt8.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt8.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt8.Height = 0.188F;
            this.txtTGrossRt8.Left = 6.979168F;
            this.txtTGrossRt8.MultiLine = false;
            this.txtTGrossRt8.Name = "txtTGrossRt8";
            this.txtTGrossRt8.OutputFormat = resources.GetString("txtTGrossRt8.OutputFormat");
            this.txtTGrossRt8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt8.Text = "999,999,999";
            this.txtTGrossRt8.Top = 0.9374998F;
            this.txtTGrossRt8.Width = 0.6F;
            // 
            // txtTGrossRt9
            // 
            this.txtTGrossRt9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt9.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt9.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt9.Height = 0.188F;
            this.txtTGrossRt9.Left = 7.583334F;
            this.txtTGrossRt9.MultiLine = false;
            this.txtTGrossRt9.Name = "txtTGrossRt9";
            this.txtTGrossRt9.OutputFormat = resources.GetString("txtTGrossRt9.OutputFormat");
            this.txtTGrossRt9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt9.Text = "999,999,999";
            this.txtTGrossRt9.Top = 0.9374998F;
            this.txtTGrossRt9.Width = 0.6F;
            // 
            // txtTGrossRt10
            // 
            this.txtTGrossRt10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt10.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt10.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt10.Height = 0.188F;
            this.txtTGrossRt10.Left = 8.187502F;
            this.txtTGrossRt10.MultiLine = false;
            this.txtTGrossRt10.Name = "txtTGrossRt10";
            this.txtTGrossRt10.OutputFormat = resources.GetString("txtTGrossRt10.OutputFormat");
            this.txtTGrossRt10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt10.Text = "999,999,999";
            this.txtTGrossRt10.Top = 0.9374998F;
            this.txtTGrossRt10.Width = 0.6F;
            // 
            // txtTGrossRt11
            // 
            this.txtTGrossRt11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt11.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt11.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt11.Height = 0.188F;
            this.txtTGrossRt11.Left = 8.791668F;
            this.txtTGrossRt11.MultiLine = false;
            this.txtTGrossRt11.Name = "txtTGrossRt11";
            this.txtTGrossRt11.OutputFormat = resources.GetString("txtTGrossRt11.OutputFormat");
            this.txtTGrossRt11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt11.Text = "999,999,999";
            this.txtTGrossRt11.Top = 0.9374998F;
            this.txtTGrossRt11.Width = 0.6F;
            // 
            // txtTGrossRt12
            // 
            this.txtTGrossRt12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTGrossRt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTGrossRt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt12.Border.RightColor = System.Drawing.Color.Black;
            this.txtTGrossRt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt12.Border.TopColor = System.Drawing.Color.Black;
            this.txtTGrossRt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTGrossRt12.Height = 0.188F;
            this.txtTGrossRt12.Left = 9.395831F;
            this.txtTGrossRt12.MultiLine = false;
            this.txtTGrossRt12.Name = "txtTGrossRt12";
            this.txtTGrossRt12.OutputFormat = resources.GetString("txtTGrossRt12.OutputFormat");
            this.txtTGrossRt12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTGrossRt12.Text = "999,999,999";
            this.txtTGrossRt12.Top = 0.9374998F;
            this.txtTGrossRt12.Width = 0.6F;
            // 
            // txtTTotalGrossRt
            // 
            this.txtTTotalGrossRt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTTotalGrossRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalGrossRt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTTotalGrossRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalGrossRt.Border.RightColor = System.Drawing.Color.Black;
            this.txtTTotalGrossRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalGrossRt.Border.TopColor = System.Drawing.Color.Black;
            this.txtTTotalGrossRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTTotalGrossRt.Height = 0.188F;
            this.txtTTotalGrossRt.Left = 10F;
            this.txtTTotalGrossRt.MultiLine = false;
            this.txtTTotalGrossRt.Name = "txtTTotalGrossRt";
            this.txtTTotalGrossRt.OutputFormat = resources.GetString("txtTTotalGrossRt.OutputFormat");
            this.txtTTotalGrossRt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtTTotalGrossRt.Text = "99,999,999,999";
            this.txtTTotalGrossRt.Top = 0.9374998F;
            this.txtTTotalGrossRt.Width = 0.7499995F;
            // 
            // textBox120
            // 
            this.textBox120.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox120.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox120.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.RightColor = System.Drawing.Color.Black;
            this.textBox120.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Border.TopColor = System.Drawing.Color.Black;
            this.textBox120.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox120.Height = 0.188F;
            this.textBox120.Left = 1.25F;
            this.textBox120.MultiLine = false;
            this.textBox120.Name = "textBox120";
            this.textBox120.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.textBox120.Text = " 総合計";
            this.textBox120.Top = 0F;
            this.textBox120.Width = 0.8F;
            // 
            // lbTitleTTSl
            // 
            this.lbTitleTTSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTTSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTTSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTTSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTTSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTSl.Height = 0.188F;
            this.lbTitleTTSl.HyperLink = null;
            this.lbTitleTTSl.Left = 2.4375F;
            this.lbTitleTTSl.Name = "lbTitleTTSl";
            this.lbTitleTTSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTTSl.Text = "当年";
            this.lbTitleTTSl.Top = 0F;
            this.lbTitleTTSl.Width = 0.3F;
            // 
            // lbTitleTFSl
            // 
            this.lbTitleTFSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTFSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTFSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTFSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTFSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFSl.Height = 0.188F;
            this.lbTitleTFSl.HyperLink = null;
            this.lbTitleTFSl.Left = 2.4375F;
            this.lbTitleTFSl.Name = "lbTitleTFSl";
            this.lbTitleTFSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTFSl.Text = "前年";
            this.lbTitleTFSl.Top = 0.1875001F;
            this.lbTitleTFSl.Width = 0.3F;
            // 
            // lbTitleTSlRt
            // 
            this.lbTitleTSlRt.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTSlRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSlRt.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTSlRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSlRt.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTSlRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSlRt.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTSlRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSlRt.Height = 0.188F;
            this.lbTitleTSlRt.HyperLink = null;
            this.lbTitleTSlRt.Left = 2.4375F;
            this.lbTitleTSlRt.Name = "lbTitleTSlRt";
            this.lbTitleTSlRt.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTSlRt.Text = "比率";
            this.lbTitleTSlRt.Top = 0.3749996F;
            this.lbTitleTSlRt.Width = 0.3F;
            // 
            // lbTitleTTGrs
            // 
            this.lbTitleTTGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTTGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTTGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTTGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTTGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTTGrs.Height = 0.188F;
            this.lbTitleTTGrs.HyperLink = null;
            this.lbTitleTTGrs.Left = 2.4375F;
            this.lbTitleTTGrs.Name = "lbTitleTTGrs";
            this.lbTitleTTGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTTGrs.Text = "当年";
            this.lbTitleTTGrs.Top = 0.5624997F;
            this.lbTitleTTGrs.Width = 0.3F;
            // 
            // lbTitleTFGrs
            // 
            this.lbTitleTFGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTFGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTFGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTFGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTFGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTFGrs.Height = 0.188F;
            this.lbTitleTFGrs.HyperLink = null;
            this.lbTitleTFGrs.Left = 2.4375F;
            this.lbTitleTFGrs.Name = "lbTitleTFGrs";
            this.lbTitleTFGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTFGrs.Text = "前年";
            this.lbTitleTFGrs.Top = 0.7499996F;
            this.lbTitleTFGrs.Width = 0.3F;
            // 
            // lbTitleTGrsRt
            // 
            this.lbTitleTGrsRt.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTGrsRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrsRt.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTGrsRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrsRt.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTGrsRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrsRt.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTGrsRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrsRt.Height = 0.188F;
            this.lbTitleTGrsRt.HyperLink = null;
            this.lbTitleTGrsRt.Left = 2.4375F;
            this.lbTitleTGrsRt.Name = "lbTitleTGrsRt";
            this.lbTitleTGrsRt.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTGrsRt.Text = "比率";
            this.lbTitleTGrsRt.Top = 0.9374998F;
            this.lbTitleTGrsRt.Width = 0.3F;
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
            this.line3.Top = 0.009999985F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.009999985F;
            this.line3.Y2 = 0.009999985F;
            // 
            // lbTitleToTSl
            // 
            this.lbTitleToTSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleToTSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleToTSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleToTSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleToTSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTSl.Height = 0.1875F;
            this.lbTitleToTSl.HyperLink = null;
            this.lbTitleToTSl.Left = 2.0625F;
            this.lbTitleToTSl.Name = "lbTitleToTSl";
            this.lbTitleToTSl.Style = "color: Black; ddo-char-set: 1; text-align: center; font-weight: bold; font-size: " +
                "8pt; vertical-align: middle; ";
            this.lbTitleToTSl.Text = "売上：";
            this.lbTitleToTSl.Top = 0F;
            this.lbTitleToTSl.Width = 0.375F;
            // 
            // lbTitleToTGrs
            // 
            this.lbTitleToTGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleToTGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleToTGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleToTGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleToTGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleToTGrs.Height = 0.1875F;
            this.lbTitleToTGrs.HyperLink = null;
            this.lbTitleToTGrs.Left = 2.0625F;
            this.lbTitleToTGrs.Name = "lbTitleToTGrs";
            this.lbTitleToTGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleToTGrs.Text = "粗利：";
            this.lbTitleToTGrs.Top = 0.5624997F;
            this.lbTitleToTGrs.Width = 0.375F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Visible = false;
            // 
            // reportFooter1
            // 
            this.reportFooter1.CanGrow = false;
            this.reportFooter1.CanShrink = true;
            this.reportFooter1.Height = 0F;
            this.reportFooter1.KeepTogether = true;
            this.reportFooter1.Name = "reportFooter1";
            this.reportFooter1.Visible = false;
            // 
            // groupHeader1
            // 
            this.groupHeader1.CanGrow = false;
            this.groupHeader1.CanShrink = true;
            this.groupHeader1.ColumnGroupKeepTogether = true;
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTHCode1,
            this.txtTHName1,
            this.ChangeDF_Code1,
            this.ChangeDF_Name1,
            this.line_Hight,
            this.line7,
            this.txtTHTitle,
            this.txtDFTitle});
            this.groupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.groupHeader1.Height = 0.28125F;
            this.groupHeader1.KeepTogether = true;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.groupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
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
            this.line7.Top = 0.1760417F;
            this.line7.Visible = false;
            this.line7.Width = 10.8125F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8125F;
            this.line7.Y1 = 0.1760417F;
            this.line7.Y2 = 0.1760417F;
            // 
            // txtTHTitle
            // 
            this.txtTHTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTHTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTHTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtTHTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtTHTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTHTitle.Height = 0.188F;
            this.txtTHTitle.Left = 0F;
            this.txtTHTitle.Name = "txtTHTitle";
            this.txtTHTitle.OutputFormat = resources.GetString("txtTHTitle.OutputFormat");
            this.txtTHTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.txtTHTitle.Text = null;
            this.txtTHTitle.Top = 0F;
            this.txtTHTitle.Width = 0.5F;
            // 
            // txtDFTitle
            // 
            this.txtDFTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFTitle.Height = 0.188F;
            this.txtDFTitle.Left = 3.5F;
            this.txtDFTitle.Name = "txtDFTitle";
            this.txtDFTitle.OutputFormat = resources.GetString("txtDFTitle.OutputFormat");
            this.txtDFTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.txtDFTitle.Text = null;
            this.txtDFTitle.Top = 0F;
            this.txtDFTitle.Width = 0.6F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.CanGrow = false;
            this.groupFooter1.CanShrink = true;
            this.groupFooter1.Height = 0F;
            this.groupFooter1.KeepTogether = true;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.Visible = false;
            // 
            // txtSubSecTSales1
            // 
            this.txtSubSecTSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales1.DataField = "ThisTermSales1";
            this.txtSubSecTSales1.Height = 0.188F;
            this.txtSubSecTSales1.Left = 2.749998F;
            this.txtSubSecTSales1.MultiLine = false;
            this.txtSubSecTSales1.Name = "txtSubSecTSales1";
            this.txtSubSecTSales1.OutputFormat = resources.GetString("txtSubSecTSales1.OutputFormat");
            this.txtSubSecTSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales1.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales1.Text = "999,999,999";
            this.txtSubSecTSales1.Top = 1.337284E-08F;
            this.txtSubSecTSales1.Width = 0.6F;
            // 
            // txtSubSecTSales2
            // 
            this.txtSubSecTSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales2.DataField = "ThisTermSales2";
            this.txtSubSecTSales2.Height = 0.188F;
            this.txtSubSecTSales2.Left = 3.35417F;
            this.txtSubSecTSales2.MultiLine = false;
            this.txtSubSecTSales2.Name = "txtSubSecTSales2";
            this.txtSubSecTSales2.OutputFormat = resources.GetString("txtSubSecTSales2.OutputFormat");
            this.txtSubSecTSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales2.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales2.Text = "999,999,999";
            this.txtSubSecTSales2.Top = 1.490116E-08F;
            this.txtSubSecTSales2.Width = 0.6F;
            // 
            // txtSubSecTSales3
            // 
            this.txtSubSecTSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales3.DataField = "ThisTermSales3";
            this.txtSubSecTSales3.Height = 0.188F;
            this.txtSubSecTSales3.Left = 3.958335F;
            this.txtSubSecTSales3.MultiLine = false;
            this.txtSubSecTSales3.Name = "txtSubSecTSales3";
            this.txtSubSecTSales3.OutputFormat = resources.GetString("txtSubSecTSales3.OutputFormat");
            this.txtSubSecTSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales3.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales3.Text = "999,999,999";
            this.txtSubSecTSales3.Top = 1.490116E-08F;
            this.txtSubSecTSales3.Width = 0.6F;
            // 
            // txtSubSecTSales4
            // 
            this.txtSubSecTSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales4.DataField = "ThisTermSales4";
            this.txtSubSecTSales4.Height = 0.188F;
            this.txtSubSecTSales4.Left = 4.562502F;
            this.txtSubSecTSales4.MultiLine = false;
            this.txtSubSecTSales4.Name = "txtSubSecTSales4";
            this.txtSubSecTSales4.OutputFormat = resources.GetString("txtSubSecTSales4.OutputFormat");
            this.txtSubSecTSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales4.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales4.Text = "999,999,999";
            this.txtSubSecTSales4.Top = 1.490116E-08F;
            this.txtSubSecTSales4.Width = 0.6F;
            // 
            // txtSubSecTSales5
            // 
            this.txtSubSecTSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales5.DataField = "ThisTermSales5";
            this.txtSubSecTSales5.Height = 0.188F;
            this.txtSubSecTSales5.Left = 5.166668F;
            this.txtSubSecTSales5.MultiLine = false;
            this.txtSubSecTSales5.Name = "txtSubSecTSales5";
            this.txtSubSecTSales5.OutputFormat = resources.GetString("txtSubSecTSales5.OutputFormat");
            this.txtSubSecTSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales5.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales5.Text = "999,999,999";
            this.txtSubSecTSales5.Top = 1.490116E-08F;
            this.txtSubSecTSales5.Width = 0.6F;
            // 
            // txtSubSecTSales6
            // 
            this.txtSubSecTSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales6.DataField = "ThisTermSales6";
            this.txtSubSecTSales6.Height = 0.188F;
            this.txtSubSecTSales6.Left = 5.770834F;
            this.txtSubSecTSales6.MultiLine = false;
            this.txtSubSecTSales6.Name = "txtSubSecTSales6";
            this.txtSubSecTSales6.OutputFormat = resources.GetString("txtSubSecTSales6.OutputFormat");
            this.txtSubSecTSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales6.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales6.Text = "999,999,999";
            this.txtSubSecTSales6.Top = 1.490116E-08F;
            this.txtSubSecTSales6.Width = 0.6F;
            // 
            // txtSubSecTSales7
            // 
            this.txtSubSecTSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales7.DataField = "ThisTermSales7";
            this.txtSubSecTSales7.Height = 0.188F;
            this.txtSubSecTSales7.Left = 6.375001F;
            this.txtSubSecTSales7.MultiLine = false;
            this.txtSubSecTSales7.Name = "txtSubSecTSales7";
            this.txtSubSecTSales7.OutputFormat = resources.GetString("txtSubSecTSales7.OutputFormat");
            this.txtSubSecTSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales7.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales7.Text = "999,999,999";
            this.txtSubSecTSales7.Top = 1.490116E-08F;
            this.txtSubSecTSales7.Width = 0.6F;
            // 
            // txtSubSecTSales8
            // 
            this.txtSubSecTSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales8.DataField = "ThisTermSales8";
            this.txtSubSecTSales8.Height = 0.188F;
            this.txtSubSecTSales8.Left = 6.979168F;
            this.txtSubSecTSales8.MultiLine = false;
            this.txtSubSecTSales8.Name = "txtSubSecTSales8";
            this.txtSubSecTSales8.OutputFormat = resources.GetString("txtSubSecTSales8.OutputFormat");
            this.txtSubSecTSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales8.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales8.Text = "999,999,999";
            this.txtSubSecTSales8.Top = 1.490116E-08F;
            this.txtSubSecTSales8.Width = 0.6F;
            // 
            // txtSubSecTSales9
            // 
            this.txtSubSecTSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales9.DataField = "ThisTermSales9";
            this.txtSubSecTSales9.Height = 0.188F;
            this.txtSubSecTSales9.Left = 7.583334F;
            this.txtSubSecTSales9.MultiLine = false;
            this.txtSubSecTSales9.Name = "txtSubSecTSales9";
            this.txtSubSecTSales9.OutputFormat = resources.GetString("txtSubSecTSales9.OutputFormat");
            this.txtSubSecTSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales9.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales9.Text = "999,999,999";
            this.txtSubSecTSales9.Top = 1.490116E-08F;
            this.txtSubSecTSales9.Width = 0.6F;
            // 
            // txtSubSecTSales10
            // 
            this.txtSubSecTSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales10.DataField = "ThisTermSales10";
            this.txtSubSecTSales10.Height = 0.188F;
            this.txtSubSecTSales10.Left = 8.187502F;
            this.txtSubSecTSales10.MultiLine = false;
            this.txtSubSecTSales10.Name = "txtSubSecTSales10";
            this.txtSubSecTSales10.OutputFormat = resources.GetString("txtSubSecTSales10.OutputFormat");
            this.txtSubSecTSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales10.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales10.Text = "999,999,999";
            this.txtSubSecTSales10.Top = 1.490116E-08F;
            this.txtSubSecTSales10.Width = 0.6F;
            // 
            // txtSubSecTSales11
            // 
            this.txtSubSecTSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales11.DataField = "ThisTermSales11";
            this.txtSubSecTSales11.Height = 0.188F;
            this.txtSubSecTSales11.Left = 8.791668F;
            this.txtSubSecTSales11.MultiLine = false;
            this.txtSubSecTSales11.Name = "txtSubSecTSales11";
            this.txtSubSecTSales11.OutputFormat = resources.GetString("txtSubSecTSales11.OutputFormat");
            this.txtSubSecTSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales11.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales11.Text = "999,999,999";
            this.txtSubSecTSales11.Top = 1.490116E-08F;
            this.txtSubSecTSales11.Width = 0.6F;
            // 
            // txtSubSecTSales12
            // 
            this.txtSubSecTSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTSales12.DataField = "ThisTermSales12";
            this.txtSubSecTSales12.Height = 0.188F;
            this.txtSubSecTSales12.Left = 9.395831F;
            this.txtSubSecTSales12.MultiLine = false;
            this.txtSubSecTSales12.Name = "txtSubSecTSales12";
            this.txtSubSecTSales12.OutputFormat = resources.GetString("txtSubSecTSales12.OutputFormat");
            this.txtSubSecTSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTSales12.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTSales12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTSales12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTSales12.Text = "999,999,999";
            this.txtSubSecTSales12.Top = 1.490116E-08F;
            this.txtSubSecTSales12.Width = 0.6F;
            // 
            // txtSubSecTTotalSales
            // 
            this.txtSubSecTTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalSales.DataField = "ThisTermTotalSales";
            this.txtSubSecTTotalSales.Height = 0.188F;
            this.txtSubSecTTotalSales.Left = 10F;
            this.txtSubSecTTotalSales.MultiLine = false;
            this.txtSubSecTTotalSales.Name = "txtSubSecTTotalSales";
            this.txtSubSecTTotalSales.OutputFormat = resources.GetString("txtSubSecTTotalSales.OutputFormat");
            this.txtSubSecTTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTTotalSales.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTTotalSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTTotalSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTTotalSales.Text = "99,999,999,999";
            this.txtSubSecTTotalSales.Top = 1.490116E-08F;
            this.txtSubSecTTotalSales.Width = 0.7499995F;
            // 
            // txtSubSecFSales1
            // 
            this.txtSubSecFSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales1.DataField = "FirstTermSales1";
            this.txtSubSecFSales1.Height = 0.188F;
            this.txtSubSecFSales1.Left = 2.749998F;
            this.txtSubSecFSales1.MultiLine = false;
            this.txtSubSecFSales1.Name = "txtSubSecFSales1";
            this.txtSubSecFSales1.OutputFormat = resources.GetString("txtSubSecFSales1.OutputFormat");
            this.txtSubSecFSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales1.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales1.Text = "999,999,999";
            this.txtSubSecFSales1.Top = 0.1875001F;
            this.txtSubSecFSales1.Width = 0.6F;
            // 
            // txtSubSecFSales2
            // 
            this.txtSubSecFSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales2.DataField = "FirstTermSales2";
            this.txtSubSecFSales2.Height = 0.188F;
            this.txtSubSecFSales2.Left = 3.35417F;
            this.txtSubSecFSales2.MultiLine = false;
            this.txtSubSecFSales2.Name = "txtSubSecFSales2";
            this.txtSubSecFSales2.OutputFormat = resources.GetString("txtSubSecFSales2.OutputFormat");
            this.txtSubSecFSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales2.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales2.Text = "999,999,999";
            this.txtSubSecFSales2.Top = 0.1875001F;
            this.txtSubSecFSales2.Width = 0.6F;
            // 
            // txtSubSecFSales3
            // 
            this.txtSubSecFSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales3.DataField = "FirstTermSales3";
            this.txtSubSecFSales3.Height = 0.188F;
            this.txtSubSecFSales3.Left = 3.958335F;
            this.txtSubSecFSales3.MultiLine = false;
            this.txtSubSecFSales3.Name = "txtSubSecFSales3";
            this.txtSubSecFSales3.OutputFormat = resources.GetString("txtSubSecFSales3.OutputFormat");
            this.txtSubSecFSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales3.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales3.Text = "999,999,999";
            this.txtSubSecFSales3.Top = 0.1875001F;
            this.txtSubSecFSales3.Width = 0.6F;
            // 
            // txtSubSecFSales4
            // 
            this.txtSubSecFSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales4.DataField = "FirstTermSales4";
            this.txtSubSecFSales4.Height = 0.188F;
            this.txtSubSecFSales4.Left = 4.562502F;
            this.txtSubSecFSales4.MultiLine = false;
            this.txtSubSecFSales4.Name = "txtSubSecFSales4";
            this.txtSubSecFSales4.OutputFormat = resources.GetString("txtSubSecFSales4.OutputFormat");
            this.txtSubSecFSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales4.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales4.Text = "999,999,999";
            this.txtSubSecFSales4.Top = 0.1875001F;
            this.txtSubSecFSales4.Width = 0.6F;
            // 
            // txtSubSecFSales5
            // 
            this.txtSubSecFSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales5.DataField = "FirstTermSales5";
            this.txtSubSecFSales5.Height = 0.188F;
            this.txtSubSecFSales5.Left = 5.166668F;
            this.txtSubSecFSales5.MultiLine = false;
            this.txtSubSecFSales5.Name = "txtSubSecFSales5";
            this.txtSubSecFSales5.OutputFormat = resources.GetString("txtSubSecFSales5.OutputFormat");
            this.txtSubSecFSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales5.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales5.Text = "999,999,999";
            this.txtSubSecFSales5.Top = 0.1875001F;
            this.txtSubSecFSales5.Width = 0.6F;
            // 
            // txtSubSecFSales6
            // 
            this.txtSubSecFSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales6.DataField = "FirstTermSales6";
            this.txtSubSecFSales6.Height = 0.188F;
            this.txtSubSecFSales6.Left = 5.770834F;
            this.txtSubSecFSales6.MultiLine = false;
            this.txtSubSecFSales6.Name = "txtSubSecFSales6";
            this.txtSubSecFSales6.OutputFormat = resources.GetString("txtSubSecFSales6.OutputFormat");
            this.txtSubSecFSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales6.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales6.Text = "999,999,999";
            this.txtSubSecFSales6.Top = 0.1875001F;
            this.txtSubSecFSales6.Width = 0.6F;
            // 
            // txtSubSecFSales7
            // 
            this.txtSubSecFSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales7.DataField = "FirstTermSales7";
            this.txtSubSecFSales7.Height = 0.188F;
            this.txtSubSecFSales7.Left = 6.375001F;
            this.txtSubSecFSales7.MultiLine = false;
            this.txtSubSecFSales7.Name = "txtSubSecFSales7";
            this.txtSubSecFSales7.OutputFormat = resources.GetString("txtSubSecFSales7.OutputFormat");
            this.txtSubSecFSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales7.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales7.Text = "999,999,999";
            this.txtSubSecFSales7.Top = 0.1875001F;
            this.txtSubSecFSales7.Width = 0.6F;
            // 
            // txtSubSecFSales8
            // 
            this.txtSubSecFSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales8.DataField = "FirstTermSales8";
            this.txtSubSecFSales8.Height = 0.188F;
            this.txtSubSecFSales8.Left = 6.979168F;
            this.txtSubSecFSales8.MultiLine = false;
            this.txtSubSecFSales8.Name = "txtSubSecFSales8";
            this.txtSubSecFSales8.OutputFormat = resources.GetString("txtSubSecFSales8.OutputFormat");
            this.txtSubSecFSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales8.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales8.Text = "999,999,999";
            this.txtSubSecFSales8.Top = 0.1875001F;
            this.txtSubSecFSales8.Width = 0.6F;
            // 
            // txtSubSecFSales9
            // 
            this.txtSubSecFSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales9.DataField = "FirstTermSales9";
            this.txtSubSecFSales9.Height = 0.188F;
            this.txtSubSecFSales9.Left = 7.583334F;
            this.txtSubSecFSales9.MultiLine = false;
            this.txtSubSecFSales9.Name = "txtSubSecFSales9";
            this.txtSubSecFSales9.OutputFormat = resources.GetString("txtSubSecFSales9.OutputFormat");
            this.txtSubSecFSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales9.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales9.Text = "999,999,999";
            this.txtSubSecFSales9.Top = 0.1875001F;
            this.txtSubSecFSales9.Width = 0.6F;
            // 
            // txtSubSecFSales10
            // 
            this.txtSubSecFSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales10.DataField = "FirstTermSales10";
            this.txtSubSecFSales10.Height = 0.188F;
            this.txtSubSecFSales10.Left = 8.187502F;
            this.txtSubSecFSales10.MultiLine = false;
            this.txtSubSecFSales10.Name = "txtSubSecFSales10";
            this.txtSubSecFSales10.OutputFormat = resources.GetString("txtSubSecFSales10.OutputFormat");
            this.txtSubSecFSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales10.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales10.Text = "999,999,999";
            this.txtSubSecFSales10.Top = 0.1875001F;
            this.txtSubSecFSales10.Width = 0.6F;
            // 
            // txtSubSecFSales11
            // 
            this.txtSubSecFSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales11.DataField = "FirstTermSales11";
            this.txtSubSecFSales11.Height = 0.188F;
            this.txtSubSecFSales11.Left = 8.791668F;
            this.txtSubSecFSales11.MultiLine = false;
            this.txtSubSecFSales11.Name = "txtSubSecFSales11";
            this.txtSubSecFSales11.OutputFormat = resources.GetString("txtSubSecFSales11.OutputFormat");
            this.txtSubSecFSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales11.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales11.Text = "999,999,999";
            this.txtSubSecFSales11.Top = 0.1875001F;
            this.txtSubSecFSales11.Width = 0.6F;
            // 
            // txtSubSecFSales12
            // 
            this.txtSubSecFSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFSales12.DataField = "FirstTermSales12";
            this.txtSubSecFSales12.Height = 0.188F;
            this.txtSubSecFSales12.Left = 9.395831F;
            this.txtSubSecFSales12.MultiLine = false;
            this.txtSubSecFSales12.Name = "txtSubSecFSales12";
            this.txtSubSecFSales12.OutputFormat = resources.GetString("txtSubSecFSales12.OutputFormat");
            this.txtSubSecFSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFSales12.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFSales12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFSales12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFSales12.Text = "999,999,999";
            this.txtSubSecFSales12.Top = 0.1875001F;
            this.txtSubSecFSales12.Width = 0.6F;
            // 
            // txtSubSecFTotalSales
            // 
            this.txtSubSecFTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalSales.DataField = "FirstTermTotalSales";
            this.txtSubSecFTotalSales.Height = 0.188F;
            this.txtSubSecFTotalSales.Left = 10F;
            this.txtSubSecFTotalSales.MultiLine = false;
            this.txtSubSecFTotalSales.Name = "txtSubSecFTotalSales";
            this.txtSubSecFTotalSales.OutputFormat = resources.GetString("txtSubSecFTotalSales.OutputFormat");
            this.txtSubSecFTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFTotalSales.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFTotalSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFTotalSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFTotalSales.Text = "99,999,999,999";
            this.txtSubSecFTotalSales.Top = 0.1875001F;
            this.txtSubSecFTotalSales.Width = 0.7499995F;
            // 
            // txtSubSecSalesRt1
            // 
            this.txtSubSecSalesRt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt1.Height = 0.188F;
            this.txtSubSecSalesRt1.Left = 2.749998F;
            this.txtSubSecSalesRt1.MultiLine = false;
            this.txtSubSecSalesRt1.Name = "txtSubSecSalesRt1";
            this.txtSubSecSalesRt1.OutputFormat = resources.GetString("txtSubSecSalesRt1.OutputFormat");
            this.txtSubSecSalesRt1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt1.Text = "999,999,999";
            this.txtSubSecSalesRt1.Top = 0.3749996F;
            this.txtSubSecSalesRt1.Width = 0.6F;
            // 
            // txtSubSecSalesRt2
            // 
            this.txtSubSecSalesRt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt2.Height = 0.188F;
            this.txtSubSecSalesRt2.Left = 3.35417F;
            this.txtSubSecSalesRt2.MultiLine = false;
            this.txtSubSecSalesRt2.Name = "txtSubSecSalesRt2";
            this.txtSubSecSalesRt2.OutputFormat = resources.GetString("txtSubSecSalesRt2.OutputFormat");
            this.txtSubSecSalesRt2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt2.Text = "999,999,999";
            this.txtSubSecSalesRt2.Top = 0.3749996F;
            this.txtSubSecSalesRt2.Width = 0.6F;
            // 
            // txtSubSecSalesRt3
            // 
            this.txtSubSecSalesRt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt3.Height = 0.188F;
            this.txtSubSecSalesRt3.Left = 3.958335F;
            this.txtSubSecSalesRt3.MultiLine = false;
            this.txtSubSecSalesRt3.Name = "txtSubSecSalesRt3";
            this.txtSubSecSalesRt3.OutputFormat = resources.GetString("txtSubSecSalesRt3.OutputFormat");
            this.txtSubSecSalesRt3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt3.Text = "999,999,999";
            this.txtSubSecSalesRt3.Top = 0.3749996F;
            this.txtSubSecSalesRt3.Width = 0.6F;
            // 
            // txtSubSecSalesRt4
            // 
            this.txtSubSecSalesRt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt4.Height = 0.188F;
            this.txtSubSecSalesRt4.Left = 4.562502F;
            this.txtSubSecSalesRt4.MultiLine = false;
            this.txtSubSecSalesRt4.Name = "txtSubSecSalesRt4";
            this.txtSubSecSalesRt4.OutputFormat = resources.GetString("txtSubSecSalesRt4.OutputFormat");
            this.txtSubSecSalesRt4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt4.Text = "999,999,999";
            this.txtSubSecSalesRt4.Top = 0.3749996F;
            this.txtSubSecSalesRt4.Width = 0.6F;
            // 
            // txtSubSecSalesRt5
            // 
            this.txtSubSecSalesRt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt5.Height = 0.188F;
            this.txtSubSecSalesRt5.Left = 5.166668F;
            this.txtSubSecSalesRt5.MultiLine = false;
            this.txtSubSecSalesRt5.Name = "txtSubSecSalesRt5";
            this.txtSubSecSalesRt5.OutputFormat = resources.GetString("txtSubSecSalesRt5.OutputFormat");
            this.txtSubSecSalesRt5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt5.Text = "999,999,999";
            this.txtSubSecSalesRt5.Top = 0.3749996F;
            this.txtSubSecSalesRt5.Width = 0.6F;
            // 
            // txtSubSecSalesRt6
            // 
            this.txtSubSecSalesRt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt6.Height = 0.188F;
            this.txtSubSecSalesRt6.Left = 5.770834F;
            this.txtSubSecSalesRt6.MultiLine = false;
            this.txtSubSecSalesRt6.Name = "txtSubSecSalesRt6";
            this.txtSubSecSalesRt6.OutputFormat = resources.GetString("txtSubSecSalesRt6.OutputFormat");
            this.txtSubSecSalesRt6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt6.Text = "999,999,999";
            this.txtSubSecSalesRt6.Top = 0.3749996F;
            this.txtSubSecSalesRt6.Width = 0.6F;
            // 
            // txtSubSecSalesRt7
            // 
            this.txtSubSecSalesRt7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt7.Height = 0.188F;
            this.txtSubSecSalesRt7.Left = 6.375001F;
            this.txtSubSecSalesRt7.MultiLine = false;
            this.txtSubSecSalesRt7.Name = "txtSubSecSalesRt7";
            this.txtSubSecSalesRt7.OutputFormat = resources.GetString("txtSubSecSalesRt7.OutputFormat");
            this.txtSubSecSalesRt7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt7.Text = "999,999,999";
            this.txtSubSecSalesRt7.Top = 0.3749996F;
            this.txtSubSecSalesRt7.Width = 0.6F;
            // 
            // txtSubSecSalesRt8
            // 
            this.txtSubSecSalesRt8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt8.Height = 0.188F;
            this.txtSubSecSalesRt8.Left = 6.979168F;
            this.txtSubSecSalesRt8.MultiLine = false;
            this.txtSubSecSalesRt8.Name = "txtSubSecSalesRt8";
            this.txtSubSecSalesRt8.OutputFormat = resources.GetString("txtSubSecSalesRt8.OutputFormat");
            this.txtSubSecSalesRt8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt8.Text = "999,999,999";
            this.txtSubSecSalesRt8.Top = 0.3749996F;
            this.txtSubSecSalesRt8.Width = 0.6F;
            // 
            // txtSubSecSalesRt9
            // 
            this.txtSubSecSalesRt9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt9.Height = 0.188F;
            this.txtSubSecSalesRt9.Left = 7.583334F;
            this.txtSubSecSalesRt9.MultiLine = false;
            this.txtSubSecSalesRt9.Name = "txtSubSecSalesRt9";
            this.txtSubSecSalesRt9.OutputFormat = resources.GetString("txtSubSecSalesRt9.OutputFormat");
            this.txtSubSecSalesRt9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt9.Text = "999,999,999";
            this.txtSubSecSalesRt9.Top = 0.3749996F;
            this.txtSubSecSalesRt9.Width = 0.6F;
            // 
            // txtSubSecSalesRt10
            // 
            this.txtSubSecSalesRt10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt10.Height = 0.188F;
            this.txtSubSecSalesRt10.Left = 8.187502F;
            this.txtSubSecSalesRt10.MultiLine = false;
            this.txtSubSecSalesRt10.Name = "txtSubSecSalesRt10";
            this.txtSubSecSalesRt10.OutputFormat = resources.GetString("txtSubSecSalesRt10.OutputFormat");
            this.txtSubSecSalesRt10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt10.Text = "999,999,999";
            this.txtSubSecSalesRt10.Top = 0.3749996F;
            this.txtSubSecSalesRt10.Width = 0.6F;
            // 
            // txtSubSecSalesRt11
            // 
            this.txtSubSecSalesRt11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt11.Height = 0.188F;
            this.txtSubSecSalesRt11.Left = 8.791668F;
            this.txtSubSecSalesRt11.MultiLine = false;
            this.txtSubSecSalesRt11.Name = "txtSubSecSalesRt11";
            this.txtSubSecSalesRt11.OutputFormat = resources.GetString("txtSubSecSalesRt11.OutputFormat");
            this.txtSubSecSalesRt11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt11.Text = "999,999,999";
            this.txtSubSecSalesRt11.Top = 0.3749996F;
            this.txtSubSecSalesRt11.Width = 0.6F;
            // 
            // txtSubSecSalesRt12
            // 
            this.txtSubSecSalesRt12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecSalesRt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecSalesRt12.Height = 0.188F;
            this.txtSubSecSalesRt12.Left = 9.395831F;
            this.txtSubSecSalesRt12.MultiLine = false;
            this.txtSubSecSalesRt12.Name = "txtSubSecSalesRt12";
            this.txtSubSecSalesRt12.OutputFormat = resources.GetString("txtSubSecSalesRt12.OutputFormat");
            this.txtSubSecSalesRt12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecSalesRt12.Text = "999,999,999";
            this.txtSubSecSalesRt12.Top = 0.3749996F;
            this.txtSubSecSalesRt12.Width = 0.6F;
            // 
            // txtSubSecTotalSalesRt
            // 
            this.txtSubSecTotalSalesRt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTotalSalesRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalSalesRt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTotalSalesRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalSalesRt.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTotalSalesRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalSalesRt.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTotalSalesRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalSalesRt.Height = 0.188F;
            this.txtSubSecTotalSalesRt.Left = 10F;
            this.txtSubSecTotalSalesRt.MultiLine = false;
            this.txtSubSecTotalSalesRt.Name = "txtSubSecTotalSalesRt";
            this.txtSubSecTotalSalesRt.OutputFormat = resources.GetString("txtSubSecTotalSalesRt.OutputFormat");
            this.txtSubSecTotalSalesRt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTotalSalesRt.Text = "99,999,999,999";
            this.txtSubSecTotalSalesRt.Top = 0.3749996F;
            this.txtSubSecTotalSalesRt.Width = 0.7499995F;
            // 
            // txtSubSecTGross1
            // 
            this.txtSubSecTGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross1.DataField = "ThisTermGross1";
            this.txtSubSecTGross1.Height = 0.188F;
            this.txtSubSecTGross1.Left = 2.749998F;
            this.txtSubSecTGross1.MultiLine = false;
            this.txtSubSecTGross1.Name = "txtSubSecTGross1";
            this.txtSubSecTGross1.OutputFormat = resources.GetString("txtSubSecTGross1.OutputFormat");
            this.txtSubSecTGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross1.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross1.Text = "999,999,999";
            this.txtSubSecTGross1.Top = 0.5624997F;
            this.txtSubSecTGross1.Width = 0.6F;
            // 
            // txtSubSecTGross2
            // 
            this.txtSubSecTGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross2.DataField = "ThisTermGross2";
            this.txtSubSecTGross2.Height = 0.188F;
            this.txtSubSecTGross2.Left = 3.35417F;
            this.txtSubSecTGross2.MultiLine = false;
            this.txtSubSecTGross2.Name = "txtSubSecTGross2";
            this.txtSubSecTGross2.OutputFormat = resources.GetString("txtSubSecTGross2.OutputFormat");
            this.txtSubSecTGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross2.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross2.Text = "999,999,999";
            this.txtSubSecTGross2.Top = 0.5624997F;
            this.txtSubSecTGross2.Width = 0.6F;
            // 
            // txtSubSecTGross3
            // 
            this.txtSubSecTGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross3.DataField = "ThisTermGross3";
            this.txtSubSecTGross3.Height = 0.188F;
            this.txtSubSecTGross3.Left = 3.958335F;
            this.txtSubSecTGross3.MultiLine = false;
            this.txtSubSecTGross3.Name = "txtSubSecTGross3";
            this.txtSubSecTGross3.OutputFormat = resources.GetString("txtSubSecTGross3.OutputFormat");
            this.txtSubSecTGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross3.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross3.Text = "999,999,999";
            this.txtSubSecTGross3.Top = 0.5624997F;
            this.txtSubSecTGross3.Width = 0.6F;
            // 
            // txtSubSecTGross4
            // 
            this.txtSubSecTGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross4.DataField = "ThisTermGross4";
            this.txtSubSecTGross4.Height = 0.188F;
            this.txtSubSecTGross4.Left = 4.562502F;
            this.txtSubSecTGross4.MultiLine = false;
            this.txtSubSecTGross4.Name = "txtSubSecTGross4";
            this.txtSubSecTGross4.OutputFormat = resources.GetString("txtSubSecTGross4.OutputFormat");
            this.txtSubSecTGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross4.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross4.Text = "999,999,999";
            this.txtSubSecTGross4.Top = 0.5624997F;
            this.txtSubSecTGross4.Width = 0.6F;
            // 
            // txtSubSecTGross5
            // 
            this.txtSubSecTGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross5.DataField = "ThisTermGross5";
            this.txtSubSecTGross5.Height = 0.188F;
            this.txtSubSecTGross5.Left = 5.166668F;
            this.txtSubSecTGross5.MultiLine = false;
            this.txtSubSecTGross5.Name = "txtSubSecTGross5";
            this.txtSubSecTGross5.OutputFormat = resources.GetString("txtSubSecTGross5.OutputFormat");
            this.txtSubSecTGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross5.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross5.Text = "999,999,999";
            this.txtSubSecTGross5.Top = 0.5624997F;
            this.txtSubSecTGross5.Width = 0.6F;
            // 
            // txtSubSecTGross6
            // 
            this.txtSubSecTGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross6.DataField = "ThisTermGross6";
            this.txtSubSecTGross6.Height = 0.188F;
            this.txtSubSecTGross6.Left = 5.770834F;
            this.txtSubSecTGross6.MultiLine = false;
            this.txtSubSecTGross6.Name = "txtSubSecTGross6";
            this.txtSubSecTGross6.OutputFormat = resources.GetString("txtSubSecTGross6.OutputFormat");
            this.txtSubSecTGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross6.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross6.Text = "999,999,999";
            this.txtSubSecTGross6.Top = 0.5624997F;
            this.txtSubSecTGross6.Width = 0.6F;
            // 
            // txtSubSecTGross7
            // 
            this.txtSubSecTGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross7.DataField = "ThisTermGross7";
            this.txtSubSecTGross7.Height = 0.188F;
            this.txtSubSecTGross7.Left = 6.375001F;
            this.txtSubSecTGross7.MultiLine = false;
            this.txtSubSecTGross7.Name = "txtSubSecTGross7";
            this.txtSubSecTGross7.OutputFormat = resources.GetString("txtSubSecTGross7.OutputFormat");
            this.txtSubSecTGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross7.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross7.Text = "999,999,999";
            this.txtSubSecTGross7.Top = 0.5624997F;
            this.txtSubSecTGross7.Width = 0.6F;
            // 
            // txtSubSecTGross8
            // 
            this.txtSubSecTGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross8.DataField = "ThisTermGross8";
            this.txtSubSecTGross8.Height = 0.188F;
            this.txtSubSecTGross8.Left = 6.979168F;
            this.txtSubSecTGross8.MultiLine = false;
            this.txtSubSecTGross8.Name = "txtSubSecTGross8";
            this.txtSubSecTGross8.OutputFormat = resources.GetString("txtSubSecTGross8.OutputFormat");
            this.txtSubSecTGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross8.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross8.Text = "999,999,999";
            this.txtSubSecTGross8.Top = 0.5624997F;
            this.txtSubSecTGross8.Width = 0.6F;
            // 
            // txtSubSecTGross9
            // 
            this.txtSubSecTGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross9.DataField = "ThisTermGross9";
            this.txtSubSecTGross9.Height = 0.188F;
            this.txtSubSecTGross9.Left = 7.583334F;
            this.txtSubSecTGross9.MultiLine = false;
            this.txtSubSecTGross9.Name = "txtSubSecTGross9";
            this.txtSubSecTGross9.OutputFormat = resources.GetString("txtSubSecTGross9.OutputFormat");
            this.txtSubSecTGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross9.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross9.Text = "999,999,999";
            this.txtSubSecTGross9.Top = 0.5624997F;
            this.txtSubSecTGross9.Width = 0.6F;
            // 
            // txtSubSecTGross10
            // 
            this.txtSubSecTGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross10.DataField = "ThisTermGross10";
            this.txtSubSecTGross10.Height = 0.188F;
            this.txtSubSecTGross10.Left = 8.187502F;
            this.txtSubSecTGross10.MultiLine = false;
            this.txtSubSecTGross10.Name = "txtSubSecTGross10";
            this.txtSubSecTGross10.OutputFormat = resources.GetString("txtSubSecTGross10.OutputFormat");
            this.txtSubSecTGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross10.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross10.Text = "999,999,999";
            this.txtSubSecTGross10.Top = 0.5624997F;
            this.txtSubSecTGross10.Width = 0.6F;
            // 
            // txtSubSecTGross11
            // 
            this.txtSubSecTGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross11.DataField = "ThisTermGross11";
            this.txtSubSecTGross11.Height = 0.188F;
            this.txtSubSecTGross11.Left = 8.791668F;
            this.txtSubSecTGross11.MultiLine = false;
            this.txtSubSecTGross11.Name = "txtSubSecTGross11";
            this.txtSubSecTGross11.OutputFormat = resources.GetString("txtSubSecTGross11.OutputFormat");
            this.txtSubSecTGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross11.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross11.Text = "999,999,999";
            this.txtSubSecTGross11.Top = 0.5624997F;
            this.txtSubSecTGross11.Width = 0.6F;
            // 
            // txtSubSecTGross12
            // 
            this.txtSubSecTGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTGross12.DataField = "ThisTermGross12";
            this.txtSubSecTGross12.Height = 0.188F;
            this.txtSubSecTGross12.Left = 9.395831F;
            this.txtSubSecTGross12.MultiLine = false;
            this.txtSubSecTGross12.Name = "txtSubSecTGross12";
            this.txtSubSecTGross12.OutputFormat = resources.GetString("txtSubSecTGross12.OutputFormat");
            this.txtSubSecTGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTGross12.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTGross12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTGross12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTGross12.Text = "999,999,999";
            this.txtSubSecTGross12.Top = 0.5624997F;
            this.txtSubSecTGross12.Width = 0.6F;
            // 
            // txtSubSecTTotalGross
            // 
            this.txtSubSecTTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTTotalGross.DataField = "ThisTermTotalGross";
            this.txtSubSecTTotalGross.Height = 0.188F;
            this.txtSubSecTTotalGross.Left = 10F;
            this.txtSubSecTTotalGross.MultiLine = false;
            this.txtSubSecTTotalGross.Name = "txtSubSecTTotalGross";
            this.txtSubSecTTotalGross.OutputFormat = resources.GetString("txtSubSecTTotalGross.OutputFormat");
            this.txtSubSecTTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTTotalGross.SummaryGroup = "SubSectionHeader";
            this.txtSubSecTTotalGross.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecTTotalGross.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecTTotalGross.Text = "99,999,999,999";
            this.txtSubSecTTotalGross.Top = 0.5624997F;
            this.txtSubSecTTotalGross.Width = 0.7499995F;
            // 
            // txtSubSecFGross1
            // 
            this.txtSubSecFGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross1.DataField = "FirstTermGross1";
            this.txtSubSecFGross1.Height = 0.188F;
            this.txtSubSecFGross1.Left = 2.749998F;
            this.txtSubSecFGross1.MultiLine = false;
            this.txtSubSecFGross1.Name = "txtSubSecFGross1";
            this.txtSubSecFGross1.OutputFormat = resources.GetString("txtSubSecFGross1.OutputFormat");
            this.txtSubSecFGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross1.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross1.Text = "999,999,999";
            this.txtSubSecFGross1.Top = 0.7499996F;
            this.txtSubSecFGross1.Width = 0.6F;
            // 
            // txtSubSecFGross2
            // 
            this.txtSubSecFGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross2.DataField = "FirstTermGross2";
            this.txtSubSecFGross2.Height = 0.188F;
            this.txtSubSecFGross2.Left = 3.35417F;
            this.txtSubSecFGross2.MultiLine = false;
            this.txtSubSecFGross2.Name = "txtSubSecFGross2";
            this.txtSubSecFGross2.OutputFormat = resources.GetString("txtSubSecFGross2.OutputFormat");
            this.txtSubSecFGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross2.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross2.Text = "999,999,999";
            this.txtSubSecFGross2.Top = 0.7499996F;
            this.txtSubSecFGross2.Width = 0.6F;
            // 
            // txtSubSecFGross3
            // 
            this.txtSubSecFGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross3.DataField = "FirstTermGross3";
            this.txtSubSecFGross3.Height = 0.188F;
            this.txtSubSecFGross3.Left = 3.958335F;
            this.txtSubSecFGross3.MultiLine = false;
            this.txtSubSecFGross3.Name = "txtSubSecFGross3";
            this.txtSubSecFGross3.OutputFormat = resources.GetString("txtSubSecFGross3.OutputFormat");
            this.txtSubSecFGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross3.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross3.Text = "999,999,999";
            this.txtSubSecFGross3.Top = 0.7499996F;
            this.txtSubSecFGross3.Width = 0.6F;
            // 
            // txtSubSecFGross4
            // 
            this.txtSubSecFGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross4.DataField = "FirstTermGross4";
            this.txtSubSecFGross4.Height = 0.188F;
            this.txtSubSecFGross4.Left = 4.562502F;
            this.txtSubSecFGross4.MultiLine = false;
            this.txtSubSecFGross4.Name = "txtSubSecFGross4";
            this.txtSubSecFGross4.OutputFormat = resources.GetString("txtSubSecFGross4.OutputFormat");
            this.txtSubSecFGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross4.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross4.Text = "999,999,999";
            this.txtSubSecFGross4.Top = 0.7499996F;
            this.txtSubSecFGross4.Width = 0.6F;
            // 
            // txtSubSecFGross5
            // 
            this.txtSubSecFGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross5.DataField = "FirstTermGross5";
            this.txtSubSecFGross5.Height = 0.188F;
            this.txtSubSecFGross5.Left = 5.166668F;
            this.txtSubSecFGross5.MultiLine = false;
            this.txtSubSecFGross5.Name = "txtSubSecFGross5";
            this.txtSubSecFGross5.OutputFormat = resources.GetString("txtSubSecFGross5.OutputFormat");
            this.txtSubSecFGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross5.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross5.Text = "999,999,999";
            this.txtSubSecFGross5.Top = 0.7499996F;
            this.txtSubSecFGross5.Width = 0.6F;
            // 
            // txtSubSecFGross6
            // 
            this.txtSubSecFGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross6.DataField = "FirstTermGross6";
            this.txtSubSecFGross6.Height = 0.188F;
            this.txtSubSecFGross6.Left = 5.770834F;
            this.txtSubSecFGross6.MultiLine = false;
            this.txtSubSecFGross6.Name = "txtSubSecFGross6";
            this.txtSubSecFGross6.OutputFormat = resources.GetString("txtSubSecFGross6.OutputFormat");
            this.txtSubSecFGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross6.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross6.Text = "999,999,999";
            this.txtSubSecFGross6.Top = 0.7499996F;
            this.txtSubSecFGross6.Width = 0.6F;
            // 
            // txtSubSecFGross7
            // 
            this.txtSubSecFGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross7.DataField = "FirstTermGross7";
            this.txtSubSecFGross7.Height = 0.188F;
            this.txtSubSecFGross7.Left = 6.375001F;
            this.txtSubSecFGross7.MultiLine = false;
            this.txtSubSecFGross7.Name = "txtSubSecFGross7";
            this.txtSubSecFGross7.OutputFormat = resources.GetString("txtSubSecFGross7.OutputFormat");
            this.txtSubSecFGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross7.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross7.Text = "999,999,999";
            this.txtSubSecFGross7.Top = 0.7499996F;
            this.txtSubSecFGross7.Width = 0.6F;
            // 
            // txtSubSecFGross8
            // 
            this.txtSubSecFGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross8.DataField = "FirstTermGross8";
            this.txtSubSecFGross8.Height = 0.188F;
            this.txtSubSecFGross8.Left = 6.979168F;
            this.txtSubSecFGross8.MultiLine = false;
            this.txtSubSecFGross8.Name = "txtSubSecFGross8";
            this.txtSubSecFGross8.OutputFormat = resources.GetString("txtSubSecFGross8.OutputFormat");
            this.txtSubSecFGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross8.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross8.Text = "999,999,999";
            this.txtSubSecFGross8.Top = 0.7499996F;
            this.txtSubSecFGross8.Width = 0.6F;
            // 
            // txtSubSecFGross9
            // 
            this.txtSubSecFGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross9.DataField = "FirstTermGross9";
            this.txtSubSecFGross9.Height = 0.188F;
            this.txtSubSecFGross9.Left = 7.583334F;
            this.txtSubSecFGross9.MultiLine = false;
            this.txtSubSecFGross9.Name = "txtSubSecFGross9";
            this.txtSubSecFGross9.OutputFormat = resources.GetString("txtSubSecFGross9.OutputFormat");
            this.txtSubSecFGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross9.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross9.Text = "999,999,999";
            this.txtSubSecFGross9.Top = 0.7499996F;
            this.txtSubSecFGross9.Width = 0.6F;
            // 
            // txtSubSecFGross10
            // 
            this.txtSubSecFGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross10.DataField = "FirstTermGross10";
            this.txtSubSecFGross10.Height = 0.188F;
            this.txtSubSecFGross10.Left = 8.187502F;
            this.txtSubSecFGross10.MultiLine = false;
            this.txtSubSecFGross10.Name = "txtSubSecFGross10";
            this.txtSubSecFGross10.OutputFormat = resources.GetString("txtSubSecFGross10.OutputFormat");
            this.txtSubSecFGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross10.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross10.Text = "999,999,999";
            this.txtSubSecFGross10.Top = 0.7499996F;
            this.txtSubSecFGross10.Width = 0.6F;
            // 
            // txtSubSecFGross11
            // 
            this.txtSubSecFGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross11.DataField = "FirstTermGross11";
            this.txtSubSecFGross11.Height = 0.188F;
            this.txtSubSecFGross11.Left = 8.791668F;
            this.txtSubSecFGross11.MultiLine = false;
            this.txtSubSecFGross11.Name = "txtSubSecFGross11";
            this.txtSubSecFGross11.OutputFormat = resources.GetString("txtSubSecFGross11.OutputFormat");
            this.txtSubSecFGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross11.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross11.Text = "999,999,999";
            this.txtSubSecFGross11.Top = 0.7499996F;
            this.txtSubSecFGross11.Width = 0.6F;
            // 
            // txtSubSecFGross12
            // 
            this.txtSubSecFGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFGross12.DataField = "FirstTermGross12";
            this.txtSubSecFGross12.Height = 0.188F;
            this.txtSubSecFGross12.Left = 9.395831F;
            this.txtSubSecFGross12.MultiLine = false;
            this.txtSubSecFGross12.Name = "txtSubSecFGross12";
            this.txtSubSecFGross12.OutputFormat = resources.GetString("txtSubSecFGross12.OutputFormat");
            this.txtSubSecFGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFGross12.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFGross12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFGross12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFGross12.Text = "999,999,999";
            this.txtSubSecFGross12.Top = 0.7499996F;
            this.txtSubSecFGross12.Width = 0.6F;
            // 
            // txtSubSecFTotalGross
            // 
            this.txtSubSecFTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecFTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecFTotalGross.DataField = "FirstTermTotalGross";
            this.txtSubSecFTotalGross.Height = 0.188F;
            this.txtSubSecFTotalGross.Left = 10F;
            this.txtSubSecFTotalGross.MultiLine = false;
            this.txtSubSecFTotalGross.Name = "txtSubSecFTotalGross";
            this.txtSubSecFTotalGross.OutputFormat = resources.GetString("txtSubSecFTotalGross.OutputFormat");
            this.txtSubSecFTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecFTotalGross.SummaryGroup = "SubSectionHeader";
            this.txtSubSecFTotalGross.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSubSecFTotalGross.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSubSecFTotalGross.Text = "99,999,999,999";
            this.txtSubSecFTotalGross.Top = 0.7499996F;
            this.txtSubSecFTotalGross.Width = 0.7499995F;
            // 
            // txtSubSecGrossRt1
            // 
            this.txtSubSecGrossRt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt1.Height = 0.188F;
            this.txtSubSecGrossRt1.Left = 2.749998F;
            this.txtSubSecGrossRt1.MultiLine = false;
            this.txtSubSecGrossRt1.Name = "txtSubSecGrossRt1";
            this.txtSubSecGrossRt1.OutputFormat = resources.GetString("txtSubSecGrossRt1.OutputFormat");
            this.txtSubSecGrossRt1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt1.Text = "999,999,999";
            this.txtSubSecGrossRt1.Top = 0.9374998F;
            this.txtSubSecGrossRt1.Width = 0.6F;
            // 
            // txtSubSecGrossRt2
            // 
            this.txtSubSecGrossRt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt2.Height = 0.188F;
            this.txtSubSecGrossRt2.Left = 3.35417F;
            this.txtSubSecGrossRt2.MultiLine = false;
            this.txtSubSecGrossRt2.Name = "txtSubSecGrossRt2";
            this.txtSubSecGrossRt2.OutputFormat = resources.GetString("txtSubSecGrossRt2.OutputFormat");
            this.txtSubSecGrossRt2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt2.Text = "999,999,999";
            this.txtSubSecGrossRt2.Top = 0.9374998F;
            this.txtSubSecGrossRt2.Width = 0.6F;
            // 
            // txtSubSecGrossRt3
            // 
            this.txtSubSecGrossRt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt3.Height = 0.188F;
            this.txtSubSecGrossRt3.Left = 3.958335F;
            this.txtSubSecGrossRt3.MultiLine = false;
            this.txtSubSecGrossRt3.Name = "txtSubSecGrossRt3";
            this.txtSubSecGrossRt3.OutputFormat = resources.GetString("txtSubSecGrossRt3.OutputFormat");
            this.txtSubSecGrossRt3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt3.Text = "999,999,999";
            this.txtSubSecGrossRt3.Top = 0.9374998F;
            this.txtSubSecGrossRt3.Width = 0.6F;
            // 
            // txtSubSecGrossRt4
            // 
            this.txtSubSecGrossRt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt4.Height = 0.188F;
            this.txtSubSecGrossRt4.Left = 4.562502F;
            this.txtSubSecGrossRt4.MultiLine = false;
            this.txtSubSecGrossRt4.Name = "txtSubSecGrossRt4";
            this.txtSubSecGrossRt4.OutputFormat = resources.GetString("txtSubSecGrossRt4.OutputFormat");
            this.txtSubSecGrossRt4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt4.Text = "999,999,999";
            this.txtSubSecGrossRt4.Top = 0.9374998F;
            this.txtSubSecGrossRt4.Width = 0.6F;
            // 
            // txtSubSecGrossRt5
            // 
            this.txtSubSecGrossRt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt5.Height = 0.188F;
            this.txtSubSecGrossRt5.Left = 5.166668F;
            this.txtSubSecGrossRt5.MultiLine = false;
            this.txtSubSecGrossRt5.Name = "txtSubSecGrossRt5";
            this.txtSubSecGrossRt5.OutputFormat = resources.GetString("txtSubSecGrossRt5.OutputFormat");
            this.txtSubSecGrossRt5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt5.Text = "999,999,999";
            this.txtSubSecGrossRt5.Top = 0.9374998F;
            this.txtSubSecGrossRt5.Width = 0.6F;
            // 
            // txtSubSecGrossRt6
            // 
            this.txtSubSecGrossRt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt6.Height = 0.188F;
            this.txtSubSecGrossRt6.Left = 5.770834F;
            this.txtSubSecGrossRt6.MultiLine = false;
            this.txtSubSecGrossRt6.Name = "txtSubSecGrossRt6";
            this.txtSubSecGrossRt6.OutputFormat = resources.GetString("txtSubSecGrossRt6.OutputFormat");
            this.txtSubSecGrossRt6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt6.Text = "999,999,999";
            this.txtSubSecGrossRt6.Top = 0.9374998F;
            this.txtSubSecGrossRt6.Width = 0.6F;
            // 
            // txtSubSecGrossRt7
            // 
            this.txtSubSecGrossRt7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt7.Height = 0.188F;
            this.txtSubSecGrossRt7.Left = 6.375001F;
            this.txtSubSecGrossRt7.MultiLine = false;
            this.txtSubSecGrossRt7.Name = "txtSubSecGrossRt7";
            this.txtSubSecGrossRt7.OutputFormat = resources.GetString("txtSubSecGrossRt7.OutputFormat");
            this.txtSubSecGrossRt7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt7.Text = "999,999,999";
            this.txtSubSecGrossRt7.Top = 0.9374998F;
            this.txtSubSecGrossRt7.Width = 0.6F;
            // 
            // txtSubSecGrossRt8
            // 
            this.txtSubSecGrossRt8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt8.Height = 0.188F;
            this.txtSubSecGrossRt8.Left = 6.979168F;
            this.txtSubSecGrossRt8.MultiLine = false;
            this.txtSubSecGrossRt8.Name = "txtSubSecGrossRt8";
            this.txtSubSecGrossRt8.OutputFormat = resources.GetString("txtSubSecGrossRt8.OutputFormat");
            this.txtSubSecGrossRt8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt8.Text = "999,999,999";
            this.txtSubSecGrossRt8.Top = 0.9374998F;
            this.txtSubSecGrossRt8.Width = 0.6F;
            // 
            // txtSubSecGrossRt9
            // 
            this.txtSubSecGrossRt9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt9.Height = 0.188F;
            this.txtSubSecGrossRt9.Left = 7.583334F;
            this.txtSubSecGrossRt9.MultiLine = false;
            this.txtSubSecGrossRt9.Name = "txtSubSecGrossRt9";
            this.txtSubSecGrossRt9.OutputFormat = resources.GetString("txtSubSecGrossRt9.OutputFormat");
            this.txtSubSecGrossRt9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt9.Text = "999,999,999";
            this.txtSubSecGrossRt9.Top = 0.9374998F;
            this.txtSubSecGrossRt9.Width = 0.6F;
            // 
            // txtSubSecGrossRt10
            // 
            this.txtSubSecGrossRt10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt10.Height = 0.188F;
            this.txtSubSecGrossRt10.Left = 8.187502F;
            this.txtSubSecGrossRt10.MultiLine = false;
            this.txtSubSecGrossRt10.Name = "txtSubSecGrossRt10";
            this.txtSubSecGrossRt10.OutputFormat = resources.GetString("txtSubSecGrossRt10.OutputFormat");
            this.txtSubSecGrossRt10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt10.Text = "999,999,999";
            this.txtSubSecGrossRt10.Top = 0.9374998F;
            this.txtSubSecGrossRt10.Width = 0.6F;
            // 
            // txtSubSecGrossRt11
            // 
            this.txtSubSecGrossRt11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt11.Height = 0.188F;
            this.txtSubSecGrossRt11.Left = 8.791668F;
            this.txtSubSecGrossRt11.MultiLine = false;
            this.txtSubSecGrossRt11.Name = "txtSubSecGrossRt11";
            this.txtSubSecGrossRt11.OutputFormat = resources.GetString("txtSubSecGrossRt11.OutputFormat");
            this.txtSubSecGrossRt11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt11.Text = "999,999,999";
            this.txtSubSecGrossRt11.Top = 0.9374998F;
            this.txtSubSecGrossRt11.Width = 0.6F;
            // 
            // txtSubSecGrossRt12
            // 
            this.txtSubSecGrossRt12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecGrossRt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecGrossRt12.Height = 0.188F;
            this.txtSubSecGrossRt12.Left = 9.395831F;
            this.txtSubSecGrossRt12.MultiLine = false;
            this.txtSubSecGrossRt12.Name = "txtSubSecGrossRt12";
            this.txtSubSecGrossRt12.OutputFormat = resources.GetString("txtSubSecGrossRt12.OutputFormat");
            this.txtSubSecGrossRt12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecGrossRt12.Text = "999,999,999";
            this.txtSubSecGrossRt12.Top = 0.9374998F;
            this.txtSubSecGrossRt12.Width = 0.6F;
            // 
            // txtSubSecTotalGrossRt
            // 
            this.txtSubSecTotalGrossRt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubSecTotalGrossRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalGrossRt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubSecTotalGrossRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalGrossRt.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubSecTotalGrossRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalGrossRt.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubSecTotalGrossRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubSecTotalGrossRt.Height = 0.188F;
            this.txtSubSecTotalGrossRt.Left = 10F;
            this.txtSubSecTotalGrossRt.MultiLine = false;
            this.txtSubSecTotalGrossRt.Name = "txtSubSecTotalGrossRt";
            this.txtSubSecTotalGrossRt.OutputFormat = resources.GetString("txtSubSecTotalGrossRt.OutputFormat");
            this.txtSubSecTotalGrossRt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSubSecTotalGrossRt.Text = "99,999,999,999";
            this.txtSubSecTotalGrossRt.Top = 0.9374998F;
            this.txtSubSecTotalGrossRt.Width = 0.7499995F;
            // 
            // txtSubTitle
            // 
            this.txtSubTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTitle.Height = 0.188F;
            this.txtSubTitle.Left = 1.25F;
            this.txtSubTitle.MultiLine = false;
            this.txtSubTitle.Name = "txtSubTitle";
            this.txtSubTitle.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.txtSubTitle.Text = " 部門計";
            this.txtSubTitle.Top = 0F;
            this.txtSubTitle.Width = 0.8F;
            // 
            // lbTitleSubSecTSl
            // 
            this.lbTitleSubSecTSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTSl.Height = 0.188F;
            this.lbTitleSubSecTSl.HyperLink = null;
            this.lbTitleSubSecTSl.Left = 2.4375F;
            this.lbTitleSubSecTSl.Name = "lbTitleSubSecTSl";
            this.lbTitleSubSecTSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSubSecTSl.Text = "当年";
            this.lbTitleSubSecTSl.Top = 0F;
            this.lbTitleSubSecTSl.Width = 0.3F;
            // 
            // lbTitleSubSecFSl
            // 
            this.lbTitleSubSecFSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFSl.Height = 0.188F;
            this.lbTitleSubSecFSl.HyperLink = null;
            this.lbTitleSubSecFSl.Left = 2.4375F;
            this.lbTitleSubSecFSl.Name = "lbTitleSubSecFSl";
            this.lbTitleSubSecFSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSubSecFSl.Text = "前年";
            this.lbTitleSubSecFSl.Top = 0.1875001F;
            this.lbTitleSubSecFSl.Width = 0.3F;
            // 
            // lbTitleSubSecSlRt
            // 
            this.lbTitleSubSecSlRt.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSubSecSlRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecSlRt.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSubSecSlRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecSlRt.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSubSecSlRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecSlRt.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSubSecSlRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecSlRt.Height = 0.188F;
            this.lbTitleSubSecSlRt.HyperLink = null;
            this.lbTitleSubSecSlRt.Left = 2.4375F;
            this.lbTitleSubSecSlRt.Name = "lbTitleSubSecSlRt";
            this.lbTitleSubSecSlRt.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSubSecSlRt.Text = "比率";
            this.lbTitleSubSecSlRt.Top = 0.3749996F;
            this.lbTitleSubSecSlRt.Width = 0.3F;
            // 
            // lbTitleSubSecTGrs
            // 
            this.lbTitleSubSecTGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSubSecTGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecTGrs.Height = 0.188F;
            this.lbTitleSubSecTGrs.HyperLink = null;
            this.lbTitleSubSecTGrs.Left = 2.4375F;
            this.lbTitleSubSecTGrs.Name = "lbTitleSubSecTGrs";
            this.lbTitleSubSecTGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSubSecTGrs.Text = "当年";
            this.lbTitleSubSecTGrs.Top = 0.5624997F;
            this.lbTitleSubSecTGrs.Width = 0.3F;
            // 
            // lbTitleSubSecFGrs
            // 
            this.lbTitleSubSecFGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSubSecFGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecFGrs.Height = 0.188F;
            this.lbTitleSubSecFGrs.HyperLink = null;
            this.lbTitleSubSecFGrs.Left = 2.4375F;
            this.lbTitleSubSecFGrs.Name = "lbTitleSubSecFGrs";
            this.lbTitleSubSecFGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSubSecFGrs.Text = "前年";
            this.lbTitleSubSecFGrs.Top = 0.7499996F;
            this.lbTitleSubSecFGrs.Width = 0.3F;
            // 
            // lbTitleSubSecGrsRt
            // 
            this.lbTitleSubSecGrsRt.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSubSecGrsRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecGrsRt.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSubSecGrsRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecGrsRt.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSubSecGrsRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecGrsRt.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSubSecGrsRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSubSecGrsRt.Height = 0.188F;
            this.lbTitleSubSecGrsRt.HyperLink = null;
            this.lbTitleSubSecGrsRt.Left = 2.4375F;
            this.lbTitleSubSecGrsRt.Name = "lbTitleSubSecGrsRt";
            this.lbTitleSubSecGrsRt.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSubSecGrsRt.Text = "比率";
            this.lbTitleSubSecGrsRt.Top = 0.9374998F;
            this.lbTitleSubSecGrsRt.Width = 0.3F;
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
            this.line4.Top = 0.01F;
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0.01F;
            this.line4.Y2 = 0.01F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanGrow = false;
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1});
            this.SectionHeader.Height = 0.2083333F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.textBox1.DataField = "AddUpSecCode";
            this.textBox1.Height = 0.188F;
            this.textBox1.Left = 3F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: middle; ";
            this.textBox1.Text = null;
            this.textBox1.Top = 0F;
            this.textBox1.Visible = false;
            this.textBox1.Width = 0.5F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanGrow = false;
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSecTSales1,
            this.txtSecTSales2,
            this.txtSecTSales3,
            this.txtSecTSales4,
            this.txtSecTSales5,
            this.txtSecTSales6,
            this.txtSecTSales7,
            this.txtSecTSales8,
            this.txtSecTSales9,
            this.txtSecTSales10,
            this.txtSecTSales11,
            this.txtSecTSales12,
            this.txtSecTTotalSales,
            this.txtSecFSales1,
            this.txtSecFSales2,
            this.txtSecFSales3,
            this.txtSecFSales4,
            this.txtSecFSales5,
            this.txtSecFSales6,
            this.txtSecFSales7,
            this.txtSecFSales8,
            this.txtSecFSales9,
            this.txtSecFSales10,
            this.txtSecFSales11,
            this.txtSecFSales12,
            this.txtSecFTotalSales,
            this.txtSecSalesRt1,
            this.txtSecSalesRt2,
            this.txtSecSalesRt3,
            this.txtSecSalesRt4,
            this.txtSecSalesRt5,
            this.txtSecSalesRt6,
            this.txtSecSalesRt7,
            this.txtSecSalesRt8,
            this.txtSecSalesRt9,
            this.txtSecSalesRt10,
            this.txtSecSalesRt11,
            this.txtSecSalesRt12,
            this.txtSecTotalSalesRt,
            this.txtSecTGross1,
            this.txtSecTGross2,
            this.txtSecTGross3,
            this.txtSecTGross4,
            this.txtSecTGross5,
            this.txtSecTGross6,
            this.txtSecTGross7,
            this.txtSecTGross8,
            this.txtSecTGross9,
            this.txtSecTGross10,
            this.txtSecTGross11,
            this.txtSecTGross12,
            this.txtSecTTotalGross,
            this.txtSecFGross1,
            this.txtSecFGross2,
            this.txtSecFGross3,
            this.txtSecFGross4,
            this.txtSecFGross5,
            this.txtSecFGross6,
            this.txtSecFGross7,
            this.txtSecFGross8,
            this.txtSecFGross9,
            this.txtSecFGross10,
            this.txtSecFGross11,
            this.txtSecFGross12,
            this.txtSecFTotalGross,
            this.txtSecGrossRt1,
            this.txtSecGrossRt2,
            this.txtSecGrossRt3,
            this.txtSecGrossRt4,
            this.txtSecGrossRt5,
            this.txtSecGrossRt6,
            this.txtSecGrossRt7,
            this.txtSecGrossRt8,
            this.txtSecGrossRt9,
            this.txtSecGrossRt10,
            this.txtSecGrossRt11,
            this.txtSecGrossRt12,
            this.txtSecTotalGrossRt,
            this.textBox116,
            this.lbTitleSecTSl,
            this.lbTitleSecFSl,
            this.lbTitleSecSlRt,
            this.lbTitleSecTGrs,
            this.lbTitleSecFGrs,
            this.lbTitleSecGrsRt,
            this.line6,
            this.lbTitleSSl,
            this.lbTitleSGrs});
            this.SectionFooter.Height = 1.223958F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // txtSecTSales1
            // 
            this.txtSecTSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales1.DataField = "ThisTermSales1";
            this.txtSecTSales1.Height = 0.188F;
            this.txtSecTSales1.Left = 2.749998F;
            this.txtSecTSales1.MultiLine = false;
            this.txtSecTSales1.Name = "txtSecTSales1";
            this.txtSecTSales1.OutputFormat = resources.GetString("txtSecTSales1.OutputFormat");
            this.txtSecTSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales1.SummaryGroup = "SectionHeader";
            this.txtSecTSales1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales1.Text = "999,999,999";
            this.txtSecTSales1.Top = 1.490116E-08F;
            this.txtSecTSales1.Width = 0.6F;
            // 
            // txtSecTSales2
            // 
            this.txtSecTSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales2.DataField = "ThisTermSales2";
            this.txtSecTSales2.Height = 0.188F;
            this.txtSecTSales2.Left = 3.35417F;
            this.txtSecTSales2.MultiLine = false;
            this.txtSecTSales2.Name = "txtSecTSales2";
            this.txtSecTSales2.OutputFormat = resources.GetString("txtSecTSales2.OutputFormat");
            this.txtSecTSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales2.SummaryGroup = "SectionHeader";
            this.txtSecTSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales2.Text = "999,999,999";
            this.txtSecTSales2.Top = 1.490116E-08F;
            this.txtSecTSales2.Width = 0.6F;
            // 
            // txtSecTSales3
            // 
            this.txtSecTSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales3.DataField = "ThisTermSales3";
            this.txtSecTSales3.Height = 0.188F;
            this.txtSecTSales3.Left = 3.958335F;
            this.txtSecTSales3.MultiLine = false;
            this.txtSecTSales3.Name = "txtSecTSales3";
            this.txtSecTSales3.OutputFormat = resources.GetString("txtSecTSales3.OutputFormat");
            this.txtSecTSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales3.SummaryGroup = "SectionHeader";
            this.txtSecTSales3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales3.Text = "999,999,999";
            this.txtSecTSales3.Top = 1.490116E-08F;
            this.txtSecTSales3.Width = 0.6F;
            // 
            // txtSecTSales4
            // 
            this.txtSecTSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales4.DataField = "ThisTermSales4";
            this.txtSecTSales4.Height = 0.188F;
            this.txtSecTSales4.Left = 4.562502F;
            this.txtSecTSales4.MultiLine = false;
            this.txtSecTSales4.Name = "txtSecTSales4";
            this.txtSecTSales4.OutputFormat = resources.GetString("txtSecTSales4.OutputFormat");
            this.txtSecTSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales4.SummaryGroup = "SectionHeader";
            this.txtSecTSales4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales4.Text = "999,999,999";
            this.txtSecTSales4.Top = 1.490116E-08F;
            this.txtSecTSales4.Width = 0.6F;
            // 
            // txtSecTSales5
            // 
            this.txtSecTSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales5.DataField = "ThisTermSales5";
            this.txtSecTSales5.Height = 0.188F;
            this.txtSecTSales5.Left = 5.166668F;
            this.txtSecTSales5.MultiLine = false;
            this.txtSecTSales5.Name = "txtSecTSales5";
            this.txtSecTSales5.OutputFormat = resources.GetString("txtSecTSales5.OutputFormat");
            this.txtSecTSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales5.SummaryGroup = "SectionHeader";
            this.txtSecTSales5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales5.Text = "999,999,999";
            this.txtSecTSales5.Top = 1.490116E-08F;
            this.txtSecTSales5.Width = 0.6F;
            // 
            // txtSecTSales6
            // 
            this.txtSecTSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales6.DataField = "ThisTermSales6";
            this.txtSecTSales6.Height = 0.188F;
            this.txtSecTSales6.Left = 5.770834F;
            this.txtSecTSales6.MultiLine = false;
            this.txtSecTSales6.Name = "txtSecTSales6";
            this.txtSecTSales6.OutputFormat = resources.GetString("txtSecTSales6.OutputFormat");
            this.txtSecTSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales6.SummaryGroup = "SectionHeader";
            this.txtSecTSales6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales6.Text = "999,999,999";
            this.txtSecTSales6.Top = 1.490116E-08F;
            this.txtSecTSales6.Width = 0.6F;
            // 
            // txtSecTSales7
            // 
            this.txtSecTSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales7.DataField = "ThisTermSales7";
            this.txtSecTSales7.Height = 0.188F;
            this.txtSecTSales7.Left = 6.375001F;
            this.txtSecTSales7.MultiLine = false;
            this.txtSecTSales7.Name = "txtSecTSales7";
            this.txtSecTSales7.OutputFormat = resources.GetString("txtSecTSales7.OutputFormat");
            this.txtSecTSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales7.SummaryGroup = "SectionHeader";
            this.txtSecTSales7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales7.Text = "999,999,999";
            this.txtSecTSales7.Top = 1.490116E-08F;
            this.txtSecTSales7.Width = 0.6F;
            // 
            // txtSecTSales8
            // 
            this.txtSecTSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales8.DataField = "ThisTermSales8";
            this.txtSecTSales8.Height = 0.188F;
            this.txtSecTSales8.Left = 6.979168F;
            this.txtSecTSales8.MultiLine = false;
            this.txtSecTSales8.Name = "txtSecTSales8";
            this.txtSecTSales8.OutputFormat = resources.GetString("txtSecTSales8.OutputFormat");
            this.txtSecTSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales8.SummaryGroup = "SectionHeader";
            this.txtSecTSales8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales8.Text = "999,999,999";
            this.txtSecTSales8.Top = 1.490116E-08F;
            this.txtSecTSales8.Width = 0.6F;
            // 
            // txtSecTSales9
            // 
            this.txtSecTSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales9.DataField = "ThisTermSales9";
            this.txtSecTSales9.Height = 0.188F;
            this.txtSecTSales9.Left = 7.583334F;
            this.txtSecTSales9.MultiLine = false;
            this.txtSecTSales9.Name = "txtSecTSales9";
            this.txtSecTSales9.OutputFormat = resources.GetString("txtSecTSales9.OutputFormat");
            this.txtSecTSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales9.SummaryGroup = "SectionHeader";
            this.txtSecTSales9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales9.Text = "999,999,999";
            this.txtSecTSales9.Top = 1.490116E-08F;
            this.txtSecTSales9.Width = 0.6F;
            // 
            // txtSecTSales10
            // 
            this.txtSecTSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales10.DataField = "ThisTermSales10";
            this.txtSecTSales10.Height = 0.188F;
            this.txtSecTSales10.Left = 8.187502F;
            this.txtSecTSales10.MultiLine = false;
            this.txtSecTSales10.Name = "txtSecTSales10";
            this.txtSecTSales10.OutputFormat = resources.GetString("txtSecTSales10.OutputFormat");
            this.txtSecTSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales10.SummaryGroup = "SectionHeader";
            this.txtSecTSales10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales10.Text = "999,999,999";
            this.txtSecTSales10.Top = 1.490116E-08F;
            this.txtSecTSales10.Width = 0.6F;
            // 
            // txtSecTSales11
            // 
            this.txtSecTSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales11.DataField = "ThisTermSales11";
            this.txtSecTSales11.Height = 0.188F;
            this.txtSecTSales11.Left = 8.791668F;
            this.txtSecTSales11.MultiLine = false;
            this.txtSecTSales11.Name = "txtSecTSales11";
            this.txtSecTSales11.OutputFormat = resources.GetString("txtSecTSales11.OutputFormat");
            this.txtSecTSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales11.SummaryGroup = "SectionHeader";
            this.txtSecTSales11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales11.Text = "999,999,999";
            this.txtSecTSales11.Top = 1.490116E-08F;
            this.txtSecTSales11.Width = 0.6F;
            // 
            // txtSecTSales12
            // 
            this.txtSecTSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTSales12.DataField = "ThisTermSales12";
            this.txtSecTSales12.Height = 0.188F;
            this.txtSecTSales12.Left = 9.395831F;
            this.txtSecTSales12.MultiLine = false;
            this.txtSecTSales12.Name = "txtSecTSales12";
            this.txtSecTSales12.OutputFormat = resources.GetString("txtSecTSales12.OutputFormat");
            this.txtSecTSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTSales12.SummaryGroup = "SectionHeader";
            this.txtSecTSales12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTSales12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTSales12.Text = "999,999,999";
            this.txtSecTSales12.Top = 1.490116E-08F;
            this.txtSecTSales12.Width = 0.6F;
            // 
            // txtSecTTotalSales
            // 
            this.txtSecTTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalSales.DataField = "ThisTermTotalSales";
            this.txtSecTTotalSales.Height = 0.188F;
            this.txtSecTTotalSales.Left = 10F;
            this.txtSecTTotalSales.MultiLine = false;
            this.txtSecTTotalSales.Name = "txtSecTTotalSales";
            this.txtSecTTotalSales.OutputFormat = resources.GetString("txtSecTTotalSales.OutputFormat");
            this.txtSecTTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTTotalSales.SummaryGroup = "SectionHeader";
            this.txtSecTTotalSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTTotalSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTTotalSales.Text = "99,999,999,999";
            this.txtSecTTotalSales.Top = 1.490116E-08F;
            this.txtSecTTotalSales.Width = 0.7499995F;
            // 
            // txtSecFSales1
            // 
            this.txtSecFSales1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales1.DataField = "FirstTermSales1";
            this.txtSecFSales1.Height = 0.188F;
            this.txtSecFSales1.Left = 2.749998F;
            this.txtSecFSales1.MultiLine = false;
            this.txtSecFSales1.Name = "txtSecFSales1";
            this.txtSecFSales1.OutputFormat = resources.GetString("txtSecFSales1.OutputFormat");
            this.txtSecFSales1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales1.SummaryGroup = "SectionHeader";
            this.txtSecFSales1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales1.Text = "999,999,999";
            this.txtSecFSales1.Top = 0.1875001F;
            this.txtSecFSales1.Width = 0.6F;
            // 
            // txtSecFSales2
            // 
            this.txtSecFSales2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales2.DataField = "FirstTermSales2";
            this.txtSecFSales2.Height = 0.188F;
            this.txtSecFSales2.Left = 3.35417F;
            this.txtSecFSales2.MultiLine = false;
            this.txtSecFSales2.Name = "txtSecFSales2";
            this.txtSecFSales2.OutputFormat = resources.GetString("txtSecFSales2.OutputFormat");
            this.txtSecFSales2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales2.SummaryGroup = "SectionHeader";
            this.txtSecFSales2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales2.Text = "999,999,999";
            this.txtSecFSales2.Top = 0.1875001F;
            this.txtSecFSales2.Width = 0.6F;
            // 
            // txtSecFSales3
            // 
            this.txtSecFSales3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales3.DataField = "FirstTermSales3";
            this.txtSecFSales3.Height = 0.188F;
            this.txtSecFSales3.Left = 3.958335F;
            this.txtSecFSales3.MultiLine = false;
            this.txtSecFSales3.Name = "txtSecFSales3";
            this.txtSecFSales3.OutputFormat = resources.GetString("txtSecFSales3.OutputFormat");
            this.txtSecFSales3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales3.SummaryGroup = "SectionHeader";
            this.txtSecFSales3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales3.Text = "999,999,999";
            this.txtSecFSales3.Top = 0.1875001F;
            this.txtSecFSales3.Width = 0.6F;
            // 
            // txtSecFSales4
            // 
            this.txtSecFSales4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales4.DataField = "FirstTermSales4";
            this.txtSecFSales4.Height = 0.188F;
            this.txtSecFSales4.Left = 4.562502F;
            this.txtSecFSales4.MultiLine = false;
            this.txtSecFSales4.Name = "txtSecFSales4";
            this.txtSecFSales4.OutputFormat = resources.GetString("txtSecFSales4.OutputFormat");
            this.txtSecFSales4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales4.SummaryGroup = "SectionHeader";
            this.txtSecFSales4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales4.Text = "999,999,999";
            this.txtSecFSales4.Top = 0.1875001F;
            this.txtSecFSales4.Width = 0.6F;
            // 
            // txtSecFSales5
            // 
            this.txtSecFSales5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales5.DataField = "FirstTermSales5";
            this.txtSecFSales5.Height = 0.188F;
            this.txtSecFSales5.Left = 5.166668F;
            this.txtSecFSales5.MultiLine = false;
            this.txtSecFSales5.Name = "txtSecFSales5";
            this.txtSecFSales5.OutputFormat = resources.GetString("txtSecFSales5.OutputFormat");
            this.txtSecFSales5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales5.SummaryGroup = "SectionHeader";
            this.txtSecFSales5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales5.Text = "999,999,999";
            this.txtSecFSales5.Top = 0.1875001F;
            this.txtSecFSales5.Width = 0.6F;
            // 
            // txtSecFSales6
            // 
            this.txtSecFSales6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales6.DataField = "FirstTermSales6";
            this.txtSecFSales6.Height = 0.188F;
            this.txtSecFSales6.Left = 5.770834F;
            this.txtSecFSales6.MultiLine = false;
            this.txtSecFSales6.Name = "txtSecFSales6";
            this.txtSecFSales6.OutputFormat = resources.GetString("txtSecFSales6.OutputFormat");
            this.txtSecFSales6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales6.SummaryGroup = "SectionHeader";
            this.txtSecFSales6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales6.Text = "999,999,999";
            this.txtSecFSales6.Top = 0.1875001F;
            this.txtSecFSales6.Width = 0.6F;
            // 
            // txtSecFSales7
            // 
            this.txtSecFSales7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales7.DataField = "FirstTermSales7";
            this.txtSecFSales7.Height = 0.188F;
            this.txtSecFSales7.Left = 6.375001F;
            this.txtSecFSales7.MultiLine = false;
            this.txtSecFSales7.Name = "txtSecFSales7";
            this.txtSecFSales7.OutputFormat = resources.GetString("txtSecFSales7.OutputFormat");
            this.txtSecFSales7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales7.SummaryGroup = "SectionHeader";
            this.txtSecFSales7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales7.Text = "999,999,999";
            this.txtSecFSales7.Top = 0.1875001F;
            this.txtSecFSales7.Width = 0.6F;
            // 
            // txtSecFSales8
            // 
            this.txtSecFSales8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales8.DataField = "FirstTermSales8";
            this.txtSecFSales8.Height = 0.188F;
            this.txtSecFSales8.Left = 6.979168F;
            this.txtSecFSales8.MultiLine = false;
            this.txtSecFSales8.Name = "txtSecFSales8";
            this.txtSecFSales8.OutputFormat = resources.GetString("txtSecFSales8.OutputFormat");
            this.txtSecFSales8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales8.SummaryGroup = "SectionHeader";
            this.txtSecFSales8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales8.Text = "999,999,999";
            this.txtSecFSales8.Top = 0.1875001F;
            this.txtSecFSales8.Width = 0.6F;
            // 
            // txtSecFSales9
            // 
            this.txtSecFSales9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales9.DataField = "FirstTermSales9";
            this.txtSecFSales9.Height = 0.188F;
            this.txtSecFSales9.Left = 7.583334F;
            this.txtSecFSales9.MultiLine = false;
            this.txtSecFSales9.Name = "txtSecFSales9";
            this.txtSecFSales9.OutputFormat = resources.GetString("txtSecFSales9.OutputFormat");
            this.txtSecFSales9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales9.SummaryGroup = "SectionHeader";
            this.txtSecFSales9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales9.Text = "999,999,999";
            this.txtSecFSales9.Top = 0.1875001F;
            this.txtSecFSales9.Width = 0.6F;
            // 
            // txtSecFSales10
            // 
            this.txtSecFSales10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales10.DataField = "FirstTermSales10";
            this.txtSecFSales10.Height = 0.188F;
            this.txtSecFSales10.Left = 8.187502F;
            this.txtSecFSales10.MultiLine = false;
            this.txtSecFSales10.Name = "txtSecFSales10";
            this.txtSecFSales10.OutputFormat = resources.GetString("txtSecFSales10.OutputFormat");
            this.txtSecFSales10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales10.SummaryGroup = "SectionHeader";
            this.txtSecFSales10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales10.Text = "999,999,999";
            this.txtSecFSales10.Top = 0.1875001F;
            this.txtSecFSales10.Width = 0.6F;
            // 
            // txtSecFSales11
            // 
            this.txtSecFSales11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales11.DataField = "FirstTermSales11";
            this.txtSecFSales11.Height = 0.188F;
            this.txtSecFSales11.Left = 8.791668F;
            this.txtSecFSales11.MultiLine = false;
            this.txtSecFSales11.Name = "txtSecFSales11";
            this.txtSecFSales11.OutputFormat = resources.GetString("txtSecFSales11.OutputFormat");
            this.txtSecFSales11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales11.SummaryGroup = "SectionHeader";
            this.txtSecFSales11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales11.Text = "999,999,999";
            this.txtSecFSales11.Top = 0.1875001F;
            this.txtSecFSales11.Width = 0.6F;
            // 
            // txtSecFSales12
            // 
            this.txtSecFSales12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFSales12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFSales12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFSales12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFSales12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFSales12.DataField = "FirstTermSales12";
            this.txtSecFSales12.Height = 0.188F;
            this.txtSecFSales12.Left = 9.395831F;
            this.txtSecFSales12.MultiLine = false;
            this.txtSecFSales12.Name = "txtSecFSales12";
            this.txtSecFSales12.OutputFormat = resources.GetString("txtSecFSales12.OutputFormat");
            this.txtSecFSales12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFSales12.SummaryGroup = "SectionHeader";
            this.txtSecFSales12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFSales12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFSales12.Text = "999,999,999";
            this.txtSecFSales12.Top = 0.1875001F;
            this.txtSecFSales12.Width = 0.6F;
            // 
            // txtSecFTotalSales
            // 
            this.txtSecFTotalSales.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFTotalSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalSales.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFTotalSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalSales.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFTotalSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalSales.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFTotalSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalSales.DataField = "FirstTermTotalSales";
            this.txtSecFTotalSales.Height = 0.188F;
            this.txtSecFTotalSales.Left = 10F;
            this.txtSecFTotalSales.MultiLine = false;
            this.txtSecFTotalSales.Name = "txtSecFTotalSales";
            this.txtSecFTotalSales.OutputFormat = resources.GetString("txtSecFTotalSales.OutputFormat");
            this.txtSecFTotalSales.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFTotalSales.SummaryGroup = "SectionHeader";
            this.txtSecFTotalSales.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFTotalSales.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFTotalSales.Text = "99,999,999,999";
            this.txtSecFTotalSales.Top = 0.1875001F;
            this.txtSecFTotalSales.Width = 0.7499995F;
            // 
            // txtSecSalesRt1
            // 
            this.txtSecSalesRt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt1.Height = 0.188F;
            this.txtSecSalesRt1.Left = 2.749998F;
            this.txtSecSalesRt1.MultiLine = false;
            this.txtSecSalesRt1.Name = "txtSecSalesRt1";
            this.txtSecSalesRt1.OutputFormat = resources.GetString("txtSecSalesRt1.OutputFormat");
            this.txtSecSalesRt1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt1.Text = "999,999,999";
            this.txtSecSalesRt1.Top = 0.3749996F;
            this.txtSecSalesRt1.Width = 0.6F;
            // 
            // txtSecSalesRt2
            // 
            this.txtSecSalesRt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt2.Height = 0.188F;
            this.txtSecSalesRt2.Left = 3.35417F;
            this.txtSecSalesRt2.MultiLine = false;
            this.txtSecSalesRt2.Name = "txtSecSalesRt2";
            this.txtSecSalesRt2.OutputFormat = resources.GetString("txtSecSalesRt2.OutputFormat");
            this.txtSecSalesRt2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt2.Text = "999,999,999";
            this.txtSecSalesRt2.Top = 0.3749996F;
            this.txtSecSalesRt2.Width = 0.6F;
            // 
            // txtSecSalesRt3
            // 
            this.txtSecSalesRt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt3.Height = 0.188F;
            this.txtSecSalesRt3.Left = 3.958335F;
            this.txtSecSalesRt3.MultiLine = false;
            this.txtSecSalesRt3.Name = "txtSecSalesRt3";
            this.txtSecSalesRt3.OutputFormat = resources.GetString("txtSecSalesRt3.OutputFormat");
            this.txtSecSalesRt3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt3.Text = "999,999,999";
            this.txtSecSalesRt3.Top = 0.3749996F;
            this.txtSecSalesRt3.Width = 0.6F;
            // 
            // txtSecSalesRt4
            // 
            this.txtSecSalesRt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt4.Height = 0.188F;
            this.txtSecSalesRt4.Left = 4.562502F;
            this.txtSecSalesRt4.MultiLine = false;
            this.txtSecSalesRt4.Name = "txtSecSalesRt4";
            this.txtSecSalesRt4.OutputFormat = resources.GetString("txtSecSalesRt4.OutputFormat");
            this.txtSecSalesRt4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt4.Text = "999,999,999";
            this.txtSecSalesRt4.Top = 0.3749996F;
            this.txtSecSalesRt4.Width = 0.6F;
            // 
            // txtSecSalesRt5
            // 
            this.txtSecSalesRt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt5.Height = 0.188F;
            this.txtSecSalesRt5.Left = 5.166668F;
            this.txtSecSalesRt5.MultiLine = false;
            this.txtSecSalesRt5.Name = "txtSecSalesRt5";
            this.txtSecSalesRt5.OutputFormat = resources.GetString("txtSecSalesRt5.OutputFormat");
            this.txtSecSalesRt5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt5.Text = "999,999,999";
            this.txtSecSalesRt5.Top = 0.3749996F;
            this.txtSecSalesRt5.Width = 0.6F;
            // 
            // txtSecSalesRt6
            // 
            this.txtSecSalesRt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt6.Height = 0.188F;
            this.txtSecSalesRt6.Left = 5.770834F;
            this.txtSecSalesRt6.MultiLine = false;
            this.txtSecSalesRt6.Name = "txtSecSalesRt6";
            this.txtSecSalesRt6.OutputFormat = resources.GetString("txtSecSalesRt6.OutputFormat");
            this.txtSecSalesRt6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt6.Text = "999,999,999";
            this.txtSecSalesRt6.Top = 0.3749996F;
            this.txtSecSalesRt6.Width = 0.6F;
            // 
            // txtSecSalesRt7
            // 
            this.txtSecSalesRt7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt7.Height = 0.188F;
            this.txtSecSalesRt7.Left = 6.375001F;
            this.txtSecSalesRt7.MultiLine = false;
            this.txtSecSalesRt7.Name = "txtSecSalesRt7";
            this.txtSecSalesRt7.OutputFormat = resources.GetString("txtSecSalesRt7.OutputFormat");
            this.txtSecSalesRt7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt7.Text = "999,999,999";
            this.txtSecSalesRt7.Top = 0.3749996F;
            this.txtSecSalesRt7.Width = 0.6F;
            // 
            // txtSecSalesRt8
            // 
            this.txtSecSalesRt8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt8.Height = 0.188F;
            this.txtSecSalesRt8.Left = 6.979168F;
            this.txtSecSalesRt8.MultiLine = false;
            this.txtSecSalesRt8.Name = "txtSecSalesRt8";
            this.txtSecSalesRt8.OutputFormat = resources.GetString("txtSecSalesRt8.OutputFormat");
            this.txtSecSalesRt8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt8.Text = "999,999,999";
            this.txtSecSalesRt8.Top = 0.3749996F;
            this.txtSecSalesRt8.Width = 0.6F;
            // 
            // txtSecSalesRt9
            // 
            this.txtSecSalesRt9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt9.Height = 0.188F;
            this.txtSecSalesRt9.Left = 7.583334F;
            this.txtSecSalesRt9.MultiLine = false;
            this.txtSecSalesRt9.Name = "txtSecSalesRt9";
            this.txtSecSalesRt9.OutputFormat = resources.GetString("txtSecSalesRt9.OutputFormat");
            this.txtSecSalesRt9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt9.Text = "999,999,999";
            this.txtSecSalesRt9.Top = 0.3749996F;
            this.txtSecSalesRt9.Width = 0.6F;
            // 
            // txtSecSalesRt10
            // 
            this.txtSecSalesRt10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt10.Height = 0.188F;
            this.txtSecSalesRt10.Left = 8.187502F;
            this.txtSecSalesRt10.MultiLine = false;
            this.txtSecSalesRt10.Name = "txtSecSalesRt10";
            this.txtSecSalesRt10.OutputFormat = resources.GetString("txtSecSalesRt10.OutputFormat");
            this.txtSecSalesRt10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt10.Text = "999,999,999";
            this.txtSecSalesRt10.Top = 0.3749996F;
            this.txtSecSalesRt10.Width = 0.6F;
            // 
            // txtSecSalesRt11
            // 
            this.txtSecSalesRt11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt11.Height = 0.188F;
            this.txtSecSalesRt11.Left = 8.791668F;
            this.txtSecSalesRt11.MultiLine = false;
            this.txtSecSalesRt11.Name = "txtSecSalesRt11";
            this.txtSecSalesRt11.OutputFormat = resources.GetString("txtSecSalesRt11.OutputFormat");
            this.txtSecSalesRt11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt11.Text = "999,999,999";
            this.txtSecSalesRt11.Top = 0.3749996F;
            this.txtSecSalesRt11.Width = 0.6F;
            // 
            // txtSecSalesRt12
            // 
            this.txtSecSalesRt12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecSalesRt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecSalesRt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecSalesRt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecSalesRt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecSalesRt12.Height = 0.188F;
            this.txtSecSalesRt12.Left = 9.395831F;
            this.txtSecSalesRt12.MultiLine = false;
            this.txtSecSalesRt12.Name = "txtSecSalesRt12";
            this.txtSecSalesRt12.OutputFormat = resources.GetString("txtSecSalesRt12.OutputFormat");
            this.txtSecSalesRt12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecSalesRt12.Text = "999,999,999";
            this.txtSecSalesRt12.Top = 0.3749996F;
            this.txtSecSalesRt12.Width = 0.6F;
            // 
            // txtSecTotalSalesRt
            // 
            this.txtSecTotalSalesRt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTotalSalesRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalSalesRt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTotalSalesRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalSalesRt.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTotalSalesRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalSalesRt.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTotalSalesRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalSalesRt.Height = 0.188F;
            this.txtSecTotalSalesRt.Left = 10F;
            this.txtSecTotalSalesRt.MultiLine = false;
            this.txtSecTotalSalesRt.Name = "txtSecTotalSalesRt";
            this.txtSecTotalSalesRt.OutputFormat = resources.GetString("txtSecTotalSalesRt.OutputFormat");
            this.txtSecTotalSalesRt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTotalSalesRt.Text = "99,999,999,999";
            this.txtSecTotalSalesRt.Top = 0.3749996F;
            this.txtSecTotalSalesRt.Width = 0.7499995F;
            // 
            // txtSecTGross1
            // 
            this.txtSecTGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross1.DataField = "ThisTermGross1";
            this.txtSecTGross1.Height = 0.188F;
            this.txtSecTGross1.Left = 2.749998F;
            this.txtSecTGross1.MultiLine = false;
            this.txtSecTGross1.Name = "txtSecTGross1";
            this.txtSecTGross1.OutputFormat = resources.GetString("txtSecTGross1.OutputFormat");
            this.txtSecTGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross1.SummaryGroup = "SectionHeader";
            this.txtSecTGross1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross1.Text = "999,999,999";
            this.txtSecTGross1.Top = 0.5624997F;
            this.txtSecTGross1.Width = 0.6F;
            // 
            // txtSecTGross2
            // 
            this.txtSecTGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross2.DataField = "ThisTermGross2";
            this.txtSecTGross2.Height = 0.188F;
            this.txtSecTGross2.Left = 3.35417F;
            this.txtSecTGross2.MultiLine = false;
            this.txtSecTGross2.Name = "txtSecTGross2";
            this.txtSecTGross2.OutputFormat = resources.GetString("txtSecTGross2.OutputFormat");
            this.txtSecTGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross2.SummaryGroup = "SectionHeader";
            this.txtSecTGross2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross2.Text = "999,999,999";
            this.txtSecTGross2.Top = 0.5624997F;
            this.txtSecTGross2.Width = 0.6F;
            // 
            // txtSecTGross3
            // 
            this.txtSecTGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross3.DataField = "ThisTermGross3";
            this.txtSecTGross3.Height = 0.188F;
            this.txtSecTGross3.Left = 3.958335F;
            this.txtSecTGross3.MultiLine = false;
            this.txtSecTGross3.Name = "txtSecTGross3";
            this.txtSecTGross3.OutputFormat = resources.GetString("txtSecTGross3.OutputFormat");
            this.txtSecTGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross3.SummaryGroup = "SectionHeader";
            this.txtSecTGross3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross3.Text = "999,999,999";
            this.txtSecTGross3.Top = 0.5624997F;
            this.txtSecTGross3.Width = 0.6F;
            // 
            // txtSecTGross4
            // 
            this.txtSecTGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross4.DataField = "ThisTermGross4";
            this.txtSecTGross4.Height = 0.188F;
            this.txtSecTGross4.Left = 4.562502F;
            this.txtSecTGross4.MultiLine = false;
            this.txtSecTGross4.Name = "txtSecTGross4";
            this.txtSecTGross4.OutputFormat = resources.GetString("txtSecTGross4.OutputFormat");
            this.txtSecTGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross4.SummaryGroup = "SectionHeader";
            this.txtSecTGross4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross4.Text = "999,999,999";
            this.txtSecTGross4.Top = 0.5624997F;
            this.txtSecTGross4.Width = 0.6F;
            // 
            // txtSecTGross5
            // 
            this.txtSecTGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross5.DataField = "ThisTermGross5";
            this.txtSecTGross5.Height = 0.188F;
            this.txtSecTGross5.Left = 5.166668F;
            this.txtSecTGross5.MultiLine = false;
            this.txtSecTGross5.Name = "txtSecTGross5";
            this.txtSecTGross5.OutputFormat = resources.GetString("txtSecTGross5.OutputFormat");
            this.txtSecTGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross5.SummaryGroup = "SectionHeader";
            this.txtSecTGross5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross5.Text = "999,999,999";
            this.txtSecTGross5.Top = 0.5624997F;
            this.txtSecTGross5.Width = 0.6F;
            // 
            // txtSecTGross6
            // 
            this.txtSecTGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross6.DataField = "ThisTermGross6";
            this.txtSecTGross6.Height = 0.188F;
            this.txtSecTGross6.Left = 5.770834F;
            this.txtSecTGross6.MultiLine = false;
            this.txtSecTGross6.Name = "txtSecTGross6";
            this.txtSecTGross6.OutputFormat = resources.GetString("txtSecTGross6.OutputFormat");
            this.txtSecTGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross6.SummaryGroup = "SectionHeader";
            this.txtSecTGross6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross6.Text = "999,999,999";
            this.txtSecTGross6.Top = 0.5624997F;
            this.txtSecTGross6.Width = 0.6F;
            // 
            // txtSecTGross7
            // 
            this.txtSecTGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross7.DataField = "ThisTermGross7";
            this.txtSecTGross7.Height = 0.188F;
            this.txtSecTGross7.Left = 6.375001F;
            this.txtSecTGross7.MultiLine = false;
            this.txtSecTGross7.Name = "txtSecTGross7";
            this.txtSecTGross7.OutputFormat = resources.GetString("txtSecTGross7.OutputFormat");
            this.txtSecTGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross7.SummaryGroup = "SectionHeader";
            this.txtSecTGross7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross7.Text = "999,999,999";
            this.txtSecTGross7.Top = 0.5624997F;
            this.txtSecTGross7.Width = 0.6F;
            // 
            // txtSecTGross8
            // 
            this.txtSecTGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross8.DataField = "ThisTermGross8";
            this.txtSecTGross8.Height = 0.188F;
            this.txtSecTGross8.Left = 6.979168F;
            this.txtSecTGross8.MultiLine = false;
            this.txtSecTGross8.Name = "txtSecTGross8";
            this.txtSecTGross8.OutputFormat = resources.GetString("txtSecTGross8.OutputFormat");
            this.txtSecTGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross8.SummaryGroup = "SectionHeader";
            this.txtSecTGross8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross8.Text = "999,999,999";
            this.txtSecTGross8.Top = 0.5624997F;
            this.txtSecTGross8.Width = 0.6F;
            // 
            // txtSecTGross9
            // 
            this.txtSecTGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross9.DataField = "ThisTermGross9";
            this.txtSecTGross9.Height = 0.188F;
            this.txtSecTGross9.Left = 7.583334F;
            this.txtSecTGross9.MultiLine = false;
            this.txtSecTGross9.Name = "txtSecTGross9";
            this.txtSecTGross9.OutputFormat = resources.GetString("txtSecTGross9.OutputFormat");
            this.txtSecTGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross9.SummaryGroup = "SectionHeader";
            this.txtSecTGross9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross9.Text = "999,999,999";
            this.txtSecTGross9.Top = 0.5624997F;
            this.txtSecTGross9.Width = 0.6F;
            // 
            // txtSecTGross10
            // 
            this.txtSecTGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross10.DataField = "ThisTermGross10";
            this.txtSecTGross10.Height = 0.188F;
            this.txtSecTGross10.Left = 8.187502F;
            this.txtSecTGross10.MultiLine = false;
            this.txtSecTGross10.Name = "txtSecTGross10";
            this.txtSecTGross10.OutputFormat = resources.GetString("txtSecTGross10.OutputFormat");
            this.txtSecTGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross10.SummaryGroup = "SectionHeader";
            this.txtSecTGross10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross10.Text = "999,999,999";
            this.txtSecTGross10.Top = 0.5624997F;
            this.txtSecTGross10.Width = 0.6F;
            // 
            // txtSecTGross11
            // 
            this.txtSecTGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross11.DataField = "ThisTermGross11";
            this.txtSecTGross11.Height = 0.188F;
            this.txtSecTGross11.Left = 8.791668F;
            this.txtSecTGross11.MultiLine = false;
            this.txtSecTGross11.Name = "txtSecTGross11";
            this.txtSecTGross11.OutputFormat = resources.GetString("txtSecTGross11.OutputFormat");
            this.txtSecTGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross11.SummaryGroup = "SectionHeader";
            this.txtSecTGross11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross11.Text = "999,999,999";
            this.txtSecTGross11.Top = 0.5624997F;
            this.txtSecTGross11.Width = 0.6F;
            // 
            // txtSecTGross12
            // 
            this.txtSecTGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTGross12.DataField = "ThisTermGross12";
            this.txtSecTGross12.Height = 0.188F;
            this.txtSecTGross12.Left = 9.395831F;
            this.txtSecTGross12.MultiLine = false;
            this.txtSecTGross12.Name = "txtSecTGross12";
            this.txtSecTGross12.OutputFormat = resources.GetString("txtSecTGross12.OutputFormat");
            this.txtSecTGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTGross12.SummaryGroup = "SectionHeader";
            this.txtSecTGross12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTGross12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTGross12.Text = "999,999,999";
            this.txtSecTGross12.Top = 0.5624997F;
            this.txtSecTGross12.Width = 0.6F;
            // 
            // txtSecTTotalGross
            // 
            this.txtSecTTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTTotalGross.DataField = "ThisTermTotalGross";
            this.txtSecTTotalGross.Height = 0.188F;
            this.txtSecTTotalGross.Left = 10F;
            this.txtSecTTotalGross.MultiLine = false;
            this.txtSecTTotalGross.Name = "txtSecTTotalGross";
            this.txtSecTTotalGross.OutputFormat = resources.GetString("txtSecTTotalGross.OutputFormat");
            this.txtSecTTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTTotalGross.SummaryGroup = "SectionHeader";
            this.txtSecTTotalGross.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecTTotalGross.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecTTotalGross.Text = "99,999,999,999";
            this.txtSecTTotalGross.Top = 0.5624997F;
            this.txtSecTTotalGross.Width = 0.7499995F;
            // 
            // txtSecFGross1
            // 
            this.txtSecFGross1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross1.DataField = "FirstTermGross1";
            this.txtSecFGross1.Height = 0.188F;
            this.txtSecFGross1.Left = 2.749998F;
            this.txtSecFGross1.MultiLine = false;
            this.txtSecFGross1.Name = "txtSecFGross1";
            this.txtSecFGross1.OutputFormat = resources.GetString("txtSecFGross1.OutputFormat");
            this.txtSecFGross1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross1.SummaryGroup = "SectionHeader";
            this.txtSecFGross1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross1.Text = "999,999,999";
            this.txtSecFGross1.Top = 0.7499996F;
            this.txtSecFGross1.Width = 0.6F;
            // 
            // txtSecFGross2
            // 
            this.txtSecFGross2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross2.DataField = "FirstTermGross2";
            this.txtSecFGross2.Height = 0.188F;
            this.txtSecFGross2.Left = 3.35417F;
            this.txtSecFGross2.MultiLine = false;
            this.txtSecFGross2.Name = "txtSecFGross2";
            this.txtSecFGross2.OutputFormat = resources.GetString("txtSecFGross2.OutputFormat");
            this.txtSecFGross2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross2.SummaryGroup = "SectionHeader";
            this.txtSecFGross2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross2.Text = "999,999,999";
            this.txtSecFGross2.Top = 0.7499996F;
            this.txtSecFGross2.Width = 0.6F;
            // 
            // txtSecFGross3
            // 
            this.txtSecFGross3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross3.DataField = "FirstTermGross3";
            this.txtSecFGross3.Height = 0.188F;
            this.txtSecFGross3.Left = 3.958335F;
            this.txtSecFGross3.MultiLine = false;
            this.txtSecFGross3.Name = "txtSecFGross3";
            this.txtSecFGross3.OutputFormat = resources.GetString("txtSecFGross3.OutputFormat");
            this.txtSecFGross3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross3.SummaryGroup = "SectionHeader";
            this.txtSecFGross3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross3.Text = "999,999,999";
            this.txtSecFGross3.Top = 0.7499996F;
            this.txtSecFGross3.Width = 0.6F;
            // 
            // txtSecFGross4
            // 
            this.txtSecFGross4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross4.DataField = "FirstTermGross4";
            this.txtSecFGross4.Height = 0.188F;
            this.txtSecFGross4.Left = 4.562502F;
            this.txtSecFGross4.MultiLine = false;
            this.txtSecFGross4.Name = "txtSecFGross4";
            this.txtSecFGross4.OutputFormat = resources.GetString("txtSecFGross4.OutputFormat");
            this.txtSecFGross4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross4.SummaryGroup = "SectionHeader";
            this.txtSecFGross4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross4.Text = "999,999,999";
            this.txtSecFGross4.Top = 0.7499996F;
            this.txtSecFGross4.Width = 0.6F;
            // 
            // txtSecFGross5
            // 
            this.txtSecFGross5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross5.DataField = "FirstTermGross5";
            this.txtSecFGross5.Height = 0.188F;
            this.txtSecFGross5.Left = 5.166668F;
            this.txtSecFGross5.MultiLine = false;
            this.txtSecFGross5.Name = "txtSecFGross5";
            this.txtSecFGross5.OutputFormat = resources.GetString("txtSecFGross5.OutputFormat");
            this.txtSecFGross5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross5.SummaryGroup = "SectionHeader";
            this.txtSecFGross5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross5.Text = "999,999,999";
            this.txtSecFGross5.Top = 0.7499996F;
            this.txtSecFGross5.Width = 0.6F;
            // 
            // txtSecFGross6
            // 
            this.txtSecFGross6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross6.DataField = "FirstTermGross6";
            this.txtSecFGross6.Height = 0.188F;
            this.txtSecFGross6.Left = 5.770834F;
            this.txtSecFGross6.MultiLine = false;
            this.txtSecFGross6.Name = "txtSecFGross6";
            this.txtSecFGross6.OutputFormat = resources.GetString("txtSecFGross6.OutputFormat");
            this.txtSecFGross6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross6.SummaryGroup = "SectionHeader";
            this.txtSecFGross6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross6.Text = "999,999,999";
            this.txtSecFGross6.Top = 0.7499996F;
            this.txtSecFGross6.Width = 0.6F;
            // 
            // txtSecFGross7
            // 
            this.txtSecFGross7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross7.DataField = "FirstTermGross7";
            this.txtSecFGross7.Height = 0.188F;
            this.txtSecFGross7.Left = 6.375001F;
            this.txtSecFGross7.MultiLine = false;
            this.txtSecFGross7.Name = "txtSecFGross7";
            this.txtSecFGross7.OutputFormat = resources.GetString("txtSecFGross7.OutputFormat");
            this.txtSecFGross7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross7.SummaryGroup = "SectionHeader";
            this.txtSecFGross7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross7.Text = "999,999,999";
            this.txtSecFGross7.Top = 0.7499996F;
            this.txtSecFGross7.Width = 0.6F;
            // 
            // txtSecFGross8
            // 
            this.txtSecFGross8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross8.DataField = "FirstTermGross8";
            this.txtSecFGross8.Height = 0.188F;
            this.txtSecFGross8.Left = 6.979168F;
            this.txtSecFGross8.MultiLine = false;
            this.txtSecFGross8.Name = "txtSecFGross8";
            this.txtSecFGross8.OutputFormat = resources.GetString("txtSecFGross8.OutputFormat");
            this.txtSecFGross8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross8.SummaryGroup = "SectionHeader";
            this.txtSecFGross8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross8.Text = "999,999,999";
            this.txtSecFGross8.Top = 0.7499996F;
            this.txtSecFGross8.Width = 0.6F;
            // 
            // txtSecFGross9
            // 
            this.txtSecFGross9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross9.DataField = "FirstTermGross9";
            this.txtSecFGross9.Height = 0.188F;
            this.txtSecFGross9.Left = 7.583334F;
            this.txtSecFGross9.MultiLine = false;
            this.txtSecFGross9.Name = "txtSecFGross9";
            this.txtSecFGross9.OutputFormat = resources.GetString("txtSecFGross9.OutputFormat");
            this.txtSecFGross9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross9.SummaryGroup = "SectionHeader";
            this.txtSecFGross9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross9.Text = "999,999,999";
            this.txtSecFGross9.Top = 0.7499996F;
            this.txtSecFGross9.Width = 0.6F;
            // 
            // txtSecFGross10
            // 
            this.txtSecFGross10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross10.DataField = "FirstTermGross10";
            this.txtSecFGross10.Height = 0.188F;
            this.txtSecFGross10.Left = 8.187502F;
            this.txtSecFGross10.MultiLine = false;
            this.txtSecFGross10.Name = "txtSecFGross10";
            this.txtSecFGross10.OutputFormat = resources.GetString("txtSecFGross10.OutputFormat");
            this.txtSecFGross10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross10.SummaryGroup = "SectionHeader";
            this.txtSecFGross10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross10.Text = "999,999,999";
            this.txtSecFGross10.Top = 0.7499996F;
            this.txtSecFGross10.Width = 0.6F;
            // 
            // txtSecFGross11
            // 
            this.txtSecFGross11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross11.DataField = "FirstTermGross11";
            this.txtSecFGross11.Height = 0.188F;
            this.txtSecFGross11.Left = 8.791668F;
            this.txtSecFGross11.MultiLine = false;
            this.txtSecFGross11.Name = "txtSecFGross11";
            this.txtSecFGross11.OutputFormat = resources.GetString("txtSecFGross11.OutputFormat");
            this.txtSecFGross11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross11.SummaryGroup = "SectionHeader";
            this.txtSecFGross11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross11.Text = "999,999,999";
            this.txtSecFGross11.Top = 0.7499996F;
            this.txtSecFGross11.Width = 0.6F;
            // 
            // txtSecFGross12
            // 
            this.txtSecFGross12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFGross12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFGross12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFGross12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFGross12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFGross12.DataField = "FirstTermGross12";
            this.txtSecFGross12.Height = 0.188F;
            this.txtSecFGross12.Left = 9.395831F;
            this.txtSecFGross12.MultiLine = false;
            this.txtSecFGross12.Name = "txtSecFGross12";
            this.txtSecFGross12.OutputFormat = resources.GetString("txtSecFGross12.OutputFormat");
            this.txtSecFGross12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFGross12.SummaryGroup = "SectionHeader";
            this.txtSecFGross12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFGross12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFGross12.Text = "999,999,999";
            this.txtSecFGross12.Top = 0.7499996F;
            this.txtSecFGross12.Width = 0.6F;
            // 
            // txtSecFTotalGross
            // 
            this.txtSecFTotalGross.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecFTotalGross.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalGross.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecFTotalGross.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalGross.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecFTotalGross.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalGross.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecFTotalGross.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecFTotalGross.DataField = "FirstTermTotalGross";
            this.txtSecFTotalGross.Height = 0.188F;
            this.txtSecFTotalGross.Left = 10F;
            this.txtSecFTotalGross.MultiLine = false;
            this.txtSecFTotalGross.Name = "txtSecFTotalGross";
            this.txtSecFTotalGross.OutputFormat = resources.GetString("txtSecFTotalGross.OutputFormat");
            this.txtSecFTotalGross.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecFTotalGross.SummaryGroup = "SectionHeader";
            this.txtSecFTotalGross.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtSecFTotalGross.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtSecFTotalGross.Text = "99,999,999,999";
            this.txtSecFTotalGross.Top = 0.7499996F;
            this.txtSecFTotalGross.Width = 0.7499995F;
            // 
            // txtSecGrossRt1
            // 
            this.txtSecGrossRt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt1.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt1.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt1.Height = 0.188F;
            this.txtSecGrossRt1.Left = 2.749998F;
            this.txtSecGrossRt1.MultiLine = false;
            this.txtSecGrossRt1.Name = "txtSecGrossRt1";
            this.txtSecGrossRt1.OutputFormat = resources.GetString("txtSecGrossRt1.OutputFormat");
            this.txtSecGrossRt1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt1.Text = "999,999,999";
            this.txtSecGrossRt1.Top = 0.9374998F;
            this.txtSecGrossRt1.Width = 0.6F;
            // 
            // txtSecGrossRt2
            // 
            this.txtSecGrossRt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt2.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt2.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt2.Height = 0.188F;
            this.txtSecGrossRt2.Left = 3.35417F;
            this.txtSecGrossRt2.MultiLine = false;
            this.txtSecGrossRt2.Name = "txtSecGrossRt2";
            this.txtSecGrossRt2.OutputFormat = resources.GetString("txtSecGrossRt2.OutputFormat");
            this.txtSecGrossRt2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt2.Text = "999,999,999";
            this.txtSecGrossRt2.Top = 0.9374998F;
            this.txtSecGrossRt2.Width = 0.6F;
            // 
            // txtSecGrossRt3
            // 
            this.txtSecGrossRt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt3.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt3.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt3.Height = 0.188F;
            this.txtSecGrossRt3.Left = 3.958335F;
            this.txtSecGrossRt3.MultiLine = false;
            this.txtSecGrossRt3.Name = "txtSecGrossRt3";
            this.txtSecGrossRt3.OutputFormat = resources.GetString("txtSecGrossRt3.OutputFormat");
            this.txtSecGrossRt3.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt3.Text = "999,999,999";
            this.txtSecGrossRt3.Top = 0.9374998F;
            this.txtSecGrossRt3.Width = 0.6F;
            // 
            // txtSecGrossRt4
            // 
            this.txtSecGrossRt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt4.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt4.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt4.Height = 0.188F;
            this.txtSecGrossRt4.Left = 4.562502F;
            this.txtSecGrossRt4.MultiLine = false;
            this.txtSecGrossRt4.Name = "txtSecGrossRt4";
            this.txtSecGrossRt4.OutputFormat = resources.GetString("txtSecGrossRt4.OutputFormat");
            this.txtSecGrossRt4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt4.Text = "999,999,999";
            this.txtSecGrossRt4.Top = 0.9374998F;
            this.txtSecGrossRt4.Width = 0.6F;
            // 
            // txtSecGrossRt5
            // 
            this.txtSecGrossRt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt5.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt5.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt5.Height = 0.188F;
            this.txtSecGrossRt5.Left = 5.166668F;
            this.txtSecGrossRt5.MultiLine = false;
            this.txtSecGrossRt5.Name = "txtSecGrossRt5";
            this.txtSecGrossRt5.OutputFormat = resources.GetString("txtSecGrossRt5.OutputFormat");
            this.txtSecGrossRt5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt5.Text = "999,999,999";
            this.txtSecGrossRt5.Top = 0.9374998F;
            this.txtSecGrossRt5.Width = 0.6F;
            // 
            // txtSecGrossRt6
            // 
            this.txtSecGrossRt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt6.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt6.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt6.Height = 0.188F;
            this.txtSecGrossRt6.Left = 5.770834F;
            this.txtSecGrossRt6.MultiLine = false;
            this.txtSecGrossRt6.Name = "txtSecGrossRt6";
            this.txtSecGrossRt6.OutputFormat = resources.GetString("txtSecGrossRt6.OutputFormat");
            this.txtSecGrossRt6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt6.Text = "999,999,999";
            this.txtSecGrossRt6.Top = 0.9374998F;
            this.txtSecGrossRt6.Width = 0.6F;
            // 
            // txtSecGrossRt7
            // 
            this.txtSecGrossRt7.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt7.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt7.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt7.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt7.Height = 0.188F;
            this.txtSecGrossRt7.Left = 6.375001F;
            this.txtSecGrossRt7.MultiLine = false;
            this.txtSecGrossRt7.Name = "txtSecGrossRt7";
            this.txtSecGrossRt7.OutputFormat = resources.GetString("txtSecGrossRt7.OutputFormat");
            this.txtSecGrossRt7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt7.Text = "999,999,999";
            this.txtSecGrossRt7.Top = 0.9374998F;
            this.txtSecGrossRt7.Width = 0.6F;
            // 
            // txtSecGrossRt8
            // 
            this.txtSecGrossRt8.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt8.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt8.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt8.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt8.Height = 0.188F;
            this.txtSecGrossRt8.Left = 6.979168F;
            this.txtSecGrossRt8.MultiLine = false;
            this.txtSecGrossRt8.Name = "txtSecGrossRt8";
            this.txtSecGrossRt8.OutputFormat = resources.GetString("txtSecGrossRt8.OutputFormat");
            this.txtSecGrossRt8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt8.Text = "999,999,999";
            this.txtSecGrossRt8.Top = 0.9374998F;
            this.txtSecGrossRt8.Width = 0.6F;
            // 
            // txtSecGrossRt9
            // 
            this.txtSecGrossRt9.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt9.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt9.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt9.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt9.Height = 0.188F;
            this.txtSecGrossRt9.Left = 7.583334F;
            this.txtSecGrossRt9.MultiLine = false;
            this.txtSecGrossRt9.Name = "txtSecGrossRt9";
            this.txtSecGrossRt9.OutputFormat = resources.GetString("txtSecGrossRt9.OutputFormat");
            this.txtSecGrossRt9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt9.Text = "999,999,999";
            this.txtSecGrossRt9.Top = 0.9374998F;
            this.txtSecGrossRt9.Width = 0.6F;
            // 
            // txtSecGrossRt10
            // 
            this.txtSecGrossRt10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt10.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt10.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt10.Height = 0.188F;
            this.txtSecGrossRt10.Left = 8.187502F;
            this.txtSecGrossRt10.MultiLine = false;
            this.txtSecGrossRt10.Name = "txtSecGrossRt10";
            this.txtSecGrossRt10.OutputFormat = resources.GetString("txtSecGrossRt10.OutputFormat");
            this.txtSecGrossRt10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt10.Text = "999,999,999";
            this.txtSecGrossRt10.Top = 0.9374998F;
            this.txtSecGrossRt10.Width = 0.6F;
            // 
            // txtSecGrossRt11
            // 
            this.txtSecGrossRt11.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt11.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt11.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt11.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt11.Height = 0.188F;
            this.txtSecGrossRt11.Left = 8.791668F;
            this.txtSecGrossRt11.MultiLine = false;
            this.txtSecGrossRt11.Name = "txtSecGrossRt11";
            this.txtSecGrossRt11.OutputFormat = resources.GetString("txtSecGrossRt11.OutputFormat");
            this.txtSecGrossRt11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt11.Text = "999,999,999";
            this.txtSecGrossRt11.Top = 0.9374998F;
            this.txtSecGrossRt11.Width = 0.6F;
            // 
            // txtSecGrossRt12
            // 
            this.txtSecGrossRt12.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecGrossRt12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt12.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecGrossRt12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt12.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecGrossRt12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt12.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecGrossRt12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecGrossRt12.Height = 0.188F;
            this.txtSecGrossRt12.Left = 9.395831F;
            this.txtSecGrossRt12.MultiLine = false;
            this.txtSecGrossRt12.Name = "txtSecGrossRt12";
            this.txtSecGrossRt12.OutputFormat = resources.GetString("txtSecGrossRt12.OutputFormat");
            this.txtSecGrossRt12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecGrossRt12.Text = "999,999,999";
            this.txtSecGrossRt12.Top = 0.9374998F;
            this.txtSecGrossRt12.Width = 0.6F;
            // 
            // txtSecTotalGrossRt
            // 
            this.txtSecTotalGrossRt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSecTotalGrossRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalGrossRt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSecTotalGrossRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalGrossRt.Border.RightColor = System.Drawing.Color.Black;
            this.txtSecTotalGrossRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalGrossRt.Border.TopColor = System.Drawing.Color.Black;
            this.txtSecTotalGrossRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSecTotalGrossRt.Height = 0.188F;
            this.txtSecTotalGrossRt.Left = 10F;
            this.txtSecTotalGrossRt.MultiLine = false;
            this.txtSecTotalGrossRt.Name = "txtSecTotalGrossRt";
            this.txtSecTotalGrossRt.OutputFormat = resources.GetString("txtSecTotalGrossRt.OutputFormat");
            this.txtSecTotalGrossRt.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7" +
                "pt; font-family: ＭＳ ゴシック; vertical-align: middle; ";
            this.txtSecTotalGrossRt.Text = "99,999,999,999";
            this.txtSecTotalGrossRt.Top = 0.9374998F;
            this.txtSecTotalGrossRt.Width = 0.7499995F;
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
            this.textBox116.Height = 0.188F;
            this.textBox116.Left = 1.25F;
            this.textBox116.MultiLine = false;
            this.textBox116.Name = "textBox116";
            this.textBox116.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.textBox116.Text = " 拠点計";
            this.textBox116.Top = 0F;
            this.textBox116.Width = 0.8F;
            // 
            // lbTitleSecTSl
            // 
            this.lbTitleSecTSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSecTSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSecTSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSecTSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSecTSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTSl.Height = 0.188F;
            this.lbTitleSecTSl.HyperLink = null;
            this.lbTitleSecTSl.Left = 2.4375F;
            this.lbTitleSecTSl.Name = "lbTitleSecTSl";
            this.lbTitleSecTSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSecTSl.Text = "当年";
            this.lbTitleSecTSl.Top = 1.490116E-08F;
            this.lbTitleSecTSl.Width = 0.3F;
            // 
            // lbTitleSecFSl
            // 
            this.lbTitleSecFSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSecFSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSecFSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSecFSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSecFSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFSl.Height = 0.188F;
            this.lbTitleSecFSl.HyperLink = null;
            this.lbTitleSecFSl.Left = 2.4375F;
            this.lbTitleSecFSl.Name = "lbTitleSecFSl";
            this.lbTitleSecFSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSecFSl.Text = "前年";
            this.lbTitleSecFSl.Top = 0.1875001F;
            this.lbTitleSecFSl.Width = 0.3F;
            // 
            // lbTitleSecSlRt
            // 
            this.lbTitleSecSlRt.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSecSlRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecSlRt.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSecSlRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecSlRt.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSecSlRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecSlRt.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSecSlRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecSlRt.Height = 0.188F;
            this.lbTitleSecSlRt.HyperLink = null;
            this.lbTitleSecSlRt.Left = 2.4375F;
            this.lbTitleSecSlRt.Name = "lbTitleSecSlRt";
            this.lbTitleSecSlRt.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSecSlRt.Text = "比率";
            this.lbTitleSecSlRt.Top = 0.3749996F;
            this.lbTitleSecSlRt.Width = 0.3F;
            // 
            // lbTitleSecTGrs
            // 
            this.lbTitleSecTGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSecTGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSecTGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSecTGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSecTGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecTGrs.Height = 0.188F;
            this.lbTitleSecTGrs.HyperLink = null;
            this.lbTitleSecTGrs.Left = 2.4375F;
            this.lbTitleSecTGrs.Name = "lbTitleSecTGrs";
            this.lbTitleSecTGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSecTGrs.Text = "当年";
            this.lbTitleSecTGrs.Top = 0.5624997F;
            this.lbTitleSecTGrs.Width = 0.3F;
            // 
            // lbTitleSecFGrs
            // 
            this.lbTitleSecFGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSecFGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSecFGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSecFGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSecFGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecFGrs.Height = 0.188F;
            this.lbTitleSecFGrs.HyperLink = null;
            this.lbTitleSecFGrs.Left = 2.4375F;
            this.lbTitleSecFGrs.Name = "lbTitleSecFGrs";
            this.lbTitleSecFGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSecFGrs.Text = "前年";
            this.lbTitleSecFGrs.Top = 0.7499996F;
            this.lbTitleSecFGrs.Width = 0.3F;
            // 
            // lbTitleSecGrsRt
            // 
            this.lbTitleSecGrsRt.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSecGrsRt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecGrsRt.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSecGrsRt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecGrsRt.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSecGrsRt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecGrsRt.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSecGrsRt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSecGrsRt.Height = 0.188F;
            this.lbTitleSecGrsRt.HyperLink = null;
            this.lbTitleSecGrsRt.Left = 2.4375F;
            this.lbTitleSecGrsRt.Name = "lbTitleSecGrsRt";
            this.lbTitleSecGrsRt.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSecGrsRt.Text = "比率";
            this.lbTitleSecGrsRt.Top = 0.9374998F;
            this.lbTitleSecGrsRt.Width = 0.3F;
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
            this.line6.Top = 0.01F;
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0.01F;
            this.line6.Y2 = 0.01F;
            // 
            // lbTitleSSl
            // 
            this.lbTitleSSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSSl.Height = 0.1875F;
            this.lbTitleSSl.HyperLink = null;
            this.lbTitleSSl.Left = 2.0625F;
            this.lbTitleSSl.Name = "lbTitleSSl";
            this.lbTitleSSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSSl.Text = "売上：";
            this.lbTitleSSl.Top = 1.490116E-08F;
            this.lbTitleSSl.Width = 0.375F;
            // 
            // lbTitleSGrs
            // 
            this.lbTitleSGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleSGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleSGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleSGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleSGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleSGrs.Height = 0.1875F;
            this.lbTitleSGrs.HyperLink = null;
            this.lbTitleSGrs.Left = 2.0625F;
            this.lbTitleSGrs.Name = "lbTitleSGrs";
            this.lbTitleSGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleSGrs.Text = "粗利：";
            this.lbTitleSGrs.Top = 0.5624997F;
            this.lbTitleSGrs.Width = 0.375F;
            // 
            // SubSectionHeader
            // 
            this.SubSectionHeader.CanGrow = false;
            this.SubSectionHeader.CanShrink = true;
            this.SubSectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2});
            this.SubSectionHeader.Height = 0.2708333F;
            this.SubSectionHeader.Name = "SubSectionHeader";
            this.SubSectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SubSectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.textBox2.DataField = "EmployeeCode";
            this.textBox2.Height = 0.188F;
            this.textBox2.Left = 3F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: middle; ";
            this.textBox2.Text = null;
            this.textBox2.Top = 0F;
            this.textBox2.Visible = false;
            this.textBox2.Width = 0.5F;
            // 
            // SubSectionFooter
            // 
            this.SubSectionFooter.CanGrow = false;
            this.SubSectionFooter.CanShrink = true;
            this.SubSectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lbTitleSubSecFSl,
            this.txtSubSecTSales2,
            this.txtSubSecTSales3,
            this.txtSubSecTSales4,
            this.txtSubSecTSales5,
            this.txtSubSecTSales6,
            this.txtSubSecTSales7,
            this.txtSubSecTSales8,
            this.txtSubSecTSales9,
            this.txtSubSecTSales10,
            this.txtSubSecTSales11,
            this.txtSubSecTSales12,
            this.txtSubSecTTotalSales,
            this.txtSubSecFSales1,
            this.txtSubSecFSales2,
            this.txtSubSecFSales3,
            this.txtSubSecFSales4,
            this.txtSubSecFSales5,
            this.txtSubSecFSales6,
            this.txtSubSecFSales7,
            this.txtSubSecFSales8,
            this.txtSubSecFSales9,
            this.txtSubSecFSales10,
            this.txtSubSecFSales11,
            this.txtSubSecFSales12,
            this.txtSubSecFTotalSales,
            this.txtSubSecSalesRt1,
            this.txtSubSecSalesRt2,
            this.txtSubSecSalesRt3,
            this.txtSubSecSalesRt4,
            this.txtSubSecSalesRt5,
            this.txtSubSecSalesRt6,
            this.txtSubSecSalesRt7,
            this.txtSubSecSalesRt8,
            this.txtSubSecSalesRt9,
            this.txtSubSecSalesRt10,
            this.txtSubSecSalesRt11,
            this.txtSubSecSalesRt12,
            this.txtSubSecTotalSalesRt,
            this.txtSubSecTGross1,
            this.txtSubSecTGross2,
            this.txtSubSecTGross3,
            this.txtSubSecTGross4,
            this.txtSubSecTGross5,
            this.txtSubSecTGross6,
            this.txtSubSecTGross7,
            this.txtSubSecTGross8,
            this.txtSubSecTGross9,
            this.txtSubSecTGross10,
            this.txtSubSecTGross11,
            this.txtSubSecTGross12,
            this.txtSubSecTTotalGross,
            this.txtSubSecFGross1,
            this.txtSubSecFGross2,
            this.txtSubSecFGross3,
            this.txtSubSecFGross4,
            this.txtSubSecFGross5,
            this.txtSubSecFGross6,
            this.txtSubSecFGross7,
            this.txtSubSecFGross8,
            this.txtSubSecFGross9,
            this.txtSubSecFGross10,
            this.txtSubSecFGross11,
            this.txtSubSecFGross12,
            this.txtSubSecFTotalGross,
            this.txtSubSecGrossRt1,
            this.txtSubSecGrossRt2,
            this.txtSubSecGrossRt3,
            this.txtSubSecGrossRt4,
            this.txtSubSecGrossRt5,
            this.txtSubSecGrossRt6,
            this.txtSubSecGrossRt7,
            this.txtSubSecGrossRt8,
            this.txtSubSecGrossRt9,
            this.txtSubSecGrossRt10,
            this.txtSubSecGrossRt11,
            this.txtSubSecGrossRt12,
            this.txtSubSecTotalGrossRt,
            this.txtSubTitle,
            this.lbTitleSubSecTSl,
            this.txtSubSecTSales1,
            this.lbTitleSubSecSlRt,
            this.lbTitleSubSecTGrs,
            this.lbTitleSubSecFGrs,
            this.lbTitleSubSecGrsRt,
            this.line4,
            this.lbTitleTSl,
            this.lbTitleTGrs});
            this.SubSectionFooter.Height = 1.206597F;
            this.SubSectionFooter.KeepTogether = true;
            this.SubSectionFooter.Name = "SubSectionFooter";
            this.SubSectionFooter.Visible = false;
            this.SubSectionFooter.Format += new System.EventHandler(this.SubSectionFooter_Format);
            this.SubSectionFooter.BeforePrint += new System.EventHandler(this.SubSectionFooter_BeforePrint);
            // 
            // lbTitleTSl
            // 
            this.lbTitleTSl.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSl.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSl.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSl.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTSl.Height = 0.1875F;
            this.lbTitleTSl.HyperLink = null;
            this.lbTitleTSl.Left = 2.0625F;
            this.lbTitleTSl.Name = "lbTitleTSl";
            this.lbTitleTSl.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTSl.Text = "売上：";
            this.lbTitleTSl.Top = 0F;
            this.lbTitleTSl.Width = 0.375F;
            // 
            // lbTitleTGrs
            // 
            this.lbTitleTGrs.Border.BottomColor = System.Drawing.Color.Black;
            this.lbTitleTGrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrs.Border.LeftColor = System.Drawing.Color.Black;
            this.lbTitleTGrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrs.Border.RightColor = System.Drawing.Color.Black;
            this.lbTitleTGrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrs.Border.TopColor = System.Drawing.Color.Black;
            this.lbTitleTGrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbTitleTGrs.Height = 0.1875F;
            this.lbTitleTGrs.HyperLink = null;
            this.lbTitleTGrs.Left = 2.0625F;
            this.lbTitleTGrs.Name = "lbTitleTGrs";
            this.lbTitleTGrs.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: middle; ";
            this.lbTitleTGrs.Text = "粗利：";
            this.lbTitleTGrs.Top = 0.5625F;
            this.lbTitleTGrs.Width = 0.375F;
            // 
            // DCTOK02092P_01A4C
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
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.82F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader1);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SubSectionHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.SubSectionFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet1"), "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: italic; font-variant: inherit; font-weight: bold; font-stretch: inher" +
                        "it; font-family: \"ＭＳ Ｐ明朝\"; font-size: 10pt; text-align: right; ddo-char-set: 128" +
                        "; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet2"), "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.DCTOK02092P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesRatio12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTermTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTermTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossRatio12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalGrossRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTermSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleFTermSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSlRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTermGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleFTermGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleGrsRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeDF_Code1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeDF_Name1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SUBTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.month12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSalesRt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTotalSalesRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTFTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTGrossRt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTTotalGrossRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox120)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTFSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTSlRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTTGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTFGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTGrsRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleToTSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleToTGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecSalesRt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTotalSalesRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecFTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecGrossRt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubSecTotalGrossRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecTSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecFSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecSlRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecTGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecFGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSubSecGrsRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFSales12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFTotalSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecSalesRt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTotalSalesRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFGross12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecFTotalGross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecGrossRt12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecTotalGrossRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox116)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecTSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecFSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecSlRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecTGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecFGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSecGrsRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleSGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTitleTGrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        #endregion	ActiveReportsデザイナで生成されたコード

        // ===============================================================================
        // 内部使用関数
        // ===============================================================================
        #region private methods

        /// <summary>
        /// 罫線表示非表示制御処理
        /// </summary>
        /// <param name="sections">対象オブジェクト</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// </remarks>
        private void SetVisibleRuledLine(ref Section sections)
        {
            // 罫線有無判定
            bool isRuledLine = (this._printInfo.frycd == 1);


            for (int i = 0; i < sections.Controls.Count; i++)
            {
                if (sections.Controls[i] is Line)
                {
                    Line line = (Line)sections.Controls[i];

                    // 表示非表示対象の罫線か
                    if (line.Name.IndexOf("RuledLine") != -1)
                    {
                        line.Visible = isRuledLine;
                    }
                }
            }
        }

        #region 全体設定切替
        /// <summary>
        /// 全体設定切り替え
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポート全体に影響のある設定を切替えます。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>

        //-------------------------------------------------------
        // 全社集計・拠点別切り替え
        //-------------------------------------------------------
        private void ChangeofAllReport()
        {
            #region [全社集計・拠点別切替]
            if (_extraInfo.TotalWay == 0)
            {
                // 全社集計
                this.SectionFooter.Visible = false;
                txtTHCode1.Text = "000000";
                txtTHName1.Text = "全社集計";

            }
            else
            {
                // 拠点別
                txtTHCode1.DataField = "AddUpSecCode";
                txtTHName1.DataField = "SectionGuidNm";


            }

            #endregion [全社集計・拠点別切替]

            #region [改ページ設定（拠点毎）適用]
            //-------------------------------------------------------
            // 改ページ設定（拠点毎）適用
            //-------------------------------------------------------

            /* ---DEL 2009/01/30 不具合対応[9841] ------------------------------------->>>>>
            if (this._extraInfo.NewPage == true) //改頁：する
            {
                if (this._extraInfo.ListType == 0 &&
                    this._extraInfo.IssueType == 2)
                {
                    ExtraHeader.DataField = "CustomerCode";
                }
                else
                {
                    ExtraHeader.DataField = "AddUpSecCode";
                }
            }
            else
            {
                SectionHeader.DataField = "AddUpSecCode";
                SectionHeader.NewPage = NewPage.None;
            }
               ---DEL 2009/01/30 不具合対応[9841] -------------------------------------<<<<< */
            // ---ADD 2009/01/30 不具合対応[9841] ------------------------------------->>>>>
            if (this._extraInfo.NewPage == true)
            {
                // 改頁あり
                SectionHeader.NewPage = NewPage.Before;
                SubSectionHeader.NewPage = NewPage.Before;
                groupHeader1.NewPage = NewPage.Before;
            }
            else
            {
                if (this._extraInfo.NewPage2 == true)
                {
                    // 改頁あり
                    SectionHeader.NewPage = NewPage.Before;
                    SubSectionHeader.NewPage = NewPage.Before;
                    groupHeader1.NewPage = NewPage.Before;
                }
                else
                {
                    // 改頁なし
                    SectionHeader.NewPage = NewPage.None;
                    SubSectionHeader.NewPage = NewPage.None;
                    groupHeader1.NewPage = NewPage.None;
                }
            }
            // ---ADD 2009/01/30 不具合対応[9841] -------------------------------------<<<<<
        }
            #endregion [改ページ設定適用]

        #endregion [全体設定切替]


        #region 帳票タイプ別切替
        /// <summary>
        /// 帳票タイプ別切替
        /// </summary>
        /// <remarks>
        /// <br>Note		: 帳票タイプ別にgroupHeader1を切替えます。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private void ChangeOfGroupHeader1()
        {
            switch (this._extraInfo.ListType)
            {
                case 0:     // 前年対比表(得意先別)
                    switch (this._extraInfo.IssueType)
                    {
                        case 0:     //発行タイプ：得意先別
                        case 3:     //発行タイプ：管理拠点別
                        case 4:     //発行タイプ：請求先別
                            groupHeader1.DataField = "AddUpSecCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SubSectionHeader.DataField = "";
                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = false;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }

                            txtCode.DataField = "CustomerCode";
                            txtCode.OutputFormat = "00000000";
                            txtName.DataField = "CustomerSnm";
                            break;
                        case 1:     //発行タイプ：拠点別
                            groupHeader1.Visible = false;
                            line2.Visible = false;

                            txtCode.DataField = "AddUpSecCode";
                            txtCode.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtName.Text = "全社集計";
                            }
                            else
                            {
                                txtName.DataField = "SectionGuidNm";
                            }

                            SectionFooter.Visible = false;
                            break;
                        case 2:     //発行タイプ：得意先別拠点別
                            groupHeader1.DataField = "CustomerCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            SectionHeader.DataField = "";
                            SubSectionHeader.DataField = "CustomerCode";
                            // フッター設定
                            SectionFooter.Visible = false;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 得意先コード・名前
                            txtTHTitle.Text = "得意先";
                            txtTHCode1.DataField = "CustomerCode";
                            txtTHCode1.OutputFormat = "00000000";
                            txtTHName1.DataField = "CustomerSnm";


                            txtCode.DataField = "AddUpSecCode";
                            txtCode.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtName.Text = "全社集計";
                            }
                            else
                            {
                                txtName.DataField = "SectionGuidNm";
                            }
                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "CustomerCode";
                            TitleHeader1.NewPage = NewPage.None;
                            SubSectionHeader.DataField = "CustomerCode";
                            SubSectionFooter.Visible = true;
                            txtSubTitle.Text = " 得意先計";

                            SectionFooter.Visible = false;        
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            txtSubTitle.Text = " 得意先計";         //ADD 2009/01/30 不具合対応[9841]
                            break;
                    }
                    break;
                case 1:     // 前年対比表(担当者別)
                case 2:     // 前年対比表(受注者別)
                    switch (this._extraInfo.IssueType)
                    {
                        case 0:     //発行タイプ：担当者別
                        case 3:     //発行タイプ：管理拠点別
                            groupHeader1.DataField = "AddUpSecCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SubSectionHeader.DataField = "";
                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = false;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }

                            txtCode.DataField = "EmployeeCode";
                            txtCode.OutputFormat = "0000";
                            txtName.DataField = "EmployeeName";
                            break;
                        case 1:     //発行タイプ：得意先別
                            groupHeader1.DataField = "EmployeeCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.DataField = "";
                            }
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SubSectionHeader.DataField = "EmployeeCode";
                            SubSectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }

                            if (this._extraInfo.ListType == 1)
                            {
                                txtDFTitle.Text = "担当者";
                            }
                            else
                            {
                                txtDFTitle.Text = "受注者";
                            }
                            ChangeDF_Code1.DataField = "EmployeeCode";
                            ChangeDF_Code1.OutputFormat = "0000";
                            ChangeDF_Name1.DataField = "EmployeeName";

                            txtCode.DataField = "CustomerCode";
                            txtCode.OutputFormat = "00000000";
                            txtName.DataField = "CustomerSnm";

                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "EmployeeCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "EmployeeCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.NewPage = NewPage.None;
                                SubSectionHeader.NewPage = NewPage.None;
                            }
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<
                            if (this._extraInfo.ListType == 1)
                            {
                                txtSubTitle.Text = " 担当者計";
                            }
                            else
                            {
                                txtSubTitle.Text = " 受注者計";
                            }
                            break;
                        case 2:     //発行タイプ：担当者別拠点別
                            groupHeader1.DataField = "EmployeeCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "";
                            SubSectionHeader.DataField = "EmployeeCode";
                            // フッター設定
                            SectionFooter.Visible = false;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            if (this._extraInfo.ListType == 1)
                            {
                                txtTHTitle.Text = "担当者";
                            }
                            else
                            {
                                txtTHTitle.Text = "受注者";
                            }
                            txtTHCode1.DataField = "EmployeeCode";
                            txtTHCode1.OutputFormat = "0000";
                            txtTHName1.DataField = "EmployeeName";

                            txtCode.DataField = "AddUpSecCode";
                            txtCode.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtName.Text = "全社集計";
                            }
                            else
                            {
                                txtName.DataField = "SectionGuidNm";
                            }

                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "EmployeeCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "EmployeeCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            if (this._extraInfo.ListType == 1)
                            {
                                txtSubTitle.Text = " 担当者計";
                            }
                            else
                            {
                                txtSubTitle.Text = " 受注者計";
                            }

                            //SectionFooter.Visible = false;          //DEL 2009/01/30 不具合対応[9841]
                            break;
                    }
                    break;
                case 3:     // 前年対比表(地区別)
                    switch (this._extraInfo.IssueType)
                    {
                        case 0:     //発行タイプ：地区別
                        case 3:     //発行タイプ：管理拠点別
                            groupHeader1.DataField = "AddUpSecCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SubSectionHeader.DataField = "";
                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = false;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }

                            txtCode.DataField = "SalesAreaCode";
                            txtCode.OutputFormat = "0000";
                            txtName.DataField = "SalesAreaName";
                            break;
                        case 1:     //発行タイプ：得意先別
                            groupHeader1.DataField = "SalesAreaCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.DataField = "";
                            }
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SubSectionHeader.DataField = "SalesAreaCode";
                            SubSectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }

                            txtDFTitle.Text = "地区";
                            ChangeDF_Code1.DataField = "SalesAreaCode";
                            ChangeDF_Code1.OutputFormat = "0000";
                            ChangeDF_Name1.DataField = "SalesAreaName";

                            txtCode.DataField = "CustomerCode";
                            txtCode.OutputFormat = "00000000";
                            txtName.DataField = "CustomerSnm";
                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "SalesAreaCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "SalesAreaCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.NewPage = NewPage.None;
                                SubSectionHeader.NewPage = NewPage.None;
                            }
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            txtSubTitle.Text = " 地区計";

                            break;
                        case 2:     //地区別拠点別
                            groupHeader1.DataField = "SalesAreaCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "";
                            SubSectionHeader.DataField = "SalesAreaCode";
                            // フッター設定
                            SectionFooter.Visible = false;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "地区";
                            txtTHCode1.DataField = "SalesAreaCode";
                            txtTHCode1.OutputFormat = "0000";
                            txtTHName1.DataField = "SalesAreaName";

                            txtCode.DataField = "AddUpSecCode";
                            txtCode.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtName.Text = "全社集計";
                            }
                            else
                            {
                                txtName.DataField = "SectionGuidNm";
                            }

                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "SalesAreaCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "SalesAreaCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            txtSubTitle.Text = " 地区計";

                            //SectionFooter.Visible = false;            //DEL 2009/01/30 不具合対応[9841]
                            break;
                    }
                    break;
                case 4:     // 前年対比表(業種別)
                    switch (this._extraInfo.IssueType)
                    {
                        case 0:     //発行タイプ：業種別
                        case 3:     //発行タイプ：管理拠点別
                            groupHeader1.DataField = "AddUpSecCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SubSectionHeader.DataField = "";
                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = false;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }

                            txtCode.DataField = "BusinessTypeCode";
                            txtCode.OutputFormat = "0000";
                            txtName.DataField = "BusinessTypeName";
                            break;
                        case 1:     //発行タイプ：得意先別
                            groupHeader1.DataField = "BusinessTypeCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.DataField = "";
                            }
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SubSectionHeader.DataField = "BusinessTypeCode";
                            SubSectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "拠点";
                            txtTHCode1.DataField = "AddUpSecCode";
                            txtTHCode1.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtTHName1.Text = "全社集計";
                            }
                            else
                            {
                                txtTHName1.DataField = "SectionGuidNm";
                            }
                            
                            txtDFTitle.Text = "業種";
                            ChangeDF_Code1.DataField = "BusinessTypeCode";
                            ChangeDF_Code1.OutputFormat = "0000";
                            ChangeDF_Name1.DataField = "BusinessTypeName";

                            txtCode.DataField = "CustomerCode";
                            txtCode.OutputFormat = "00000000";
                            txtName.DataField = "CustomerSnm";

                            /* ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "BusinessTypeCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "BusinessTypeCode";
                            SubSectionFooter.Visible = true;
                               ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.NewPage = NewPage.None;
                                SubSectionHeader.NewPage = NewPage.None;
                            }
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<
                            txtSubTitle.Text = " 業種計";
                            break;
                        case 2:     //発行タイプ：業種別拠点別
                            groupHeader1.DataField = "BusinessTypeCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "";
                            SubSectionHeader.DataField = "BusinessTypeCode";
                            // フッター設定
                            SectionFooter.Visible = false;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            // 拠点コード・名前
                            txtTHTitle.Text = "業種";
                            txtTHCode1.DataField = "BusinessTypeCode";
                            txtTHCode1.OutputFormat = "0000";
                            txtTHName1.DataField = "BusinessTypeName";

                            txtCode.DataField = "AddUpSecCode";
                            txtCode.OutputFormat = "00";
                            if (this._extraInfo.TotalWay == 0)
                            {
                                txtName.Text = "全社集計";
                            }
                            else
                            {
                                txtName.DataField = "SectionGuidNm";
                            }

                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "BusinessTypeCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "BusinessTypeCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            txtSubTitle.Text = " 業種計";

                            SectionFooter.Visible = false;
                            break;
                    }
                    break;
                case 5:     // 前年対比表(グループコード別)
                    groupHeader1.DataField = "AddUpSecCode";
                    // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                    // ヘッダー設定
                    groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                    SectionHeader.DataField = "AddUpSecCode";
                    SubSectionHeader.DataField = "";
                    // フッター設定
                    SectionFooter.Visible = true;
                    SubSectionFooter.Visible = false;
                    // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                    // 拠点コード・名前
                    txtTHTitle.Text = "拠点";
                    txtTHCode1.DataField = "AddUpSecCode";
                    txtTHCode1.OutputFormat = "00";
                    if (this._extraInfo.TotalWay == 0)
                    {
                        txtTHName1.Text = "全社集計";
                    }
                    else
                    {
                        txtTHName1.DataField = "SectionGuidNm";
                    }

                    switch (this._extraInfo.IssueType)
                    {
                        case 0:     //発行タイプ：グループコード別
                            txtCode.DataField = "BLGroupCode";
                            txtCode.OutputFormat = "00000";
                            txtName.DataField = "BLGroupKanaName";
                            break;
                        case 1:     //発行タイプ：商品中分類別
                            txtCode.DataField = "GoodsMGroup";
                            txtCode.OutputFormat = "0000";
                            txtName.DataField = "GoodsMGroupName";
                            break;
                        case 2:     //発行タイプ：商品大分類別
                            txtCode.DataField = "GoodsLGroup";
                            txtCode.OutputFormat = "0000";
                            txtName.DataField = "GoodsLGroupName";
                            break;
                    }
                    break;
                case 6:     // 前年対比表(ＢＬコード別)
                    // 拠点コード・名前
                    txtTHTitle.Text = "拠点";
                    txtTHCode1.DataField = "AddUpSecCode";
                    txtTHCode1.OutputFormat = "00";
                    if (this._extraInfo.TotalWay == 0)
                    {
                        txtTHName1.Text = "全社集計";
                    }
                    else
                    {
                        txtTHName1.DataField = "SectionGuidNm";
                    }

                    switch (this._extraInfo.IssueType)
                    {
                        case 0:     //発行タイプ：BLコード別
                            groupHeader1.DataField = "AddUpSecCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SubSectionHeader.DataField = "";
                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = false;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            txtCode.DataField = "BLGoodsCode";
                            txtCode.OutputFormat = "00000";
                            txtName.DataField = "BLGoodsHalfName";
                            break;
                        case 1:     //発行タイプ：BLコード別得意先別
                            groupHeader1.DataField = "BLGoodsCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.DataField = "";
                            }
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SubSectionHeader.DataField = "BLGoodsCode";
                            SubSectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            txtDFTitle.Text = "ＢＬコード";
                            ChangeDF_Code1.DataField = "BLGoodsCode";
                            ChangeDF_Code1.OutputFormat = "00000";
                            ChangeDF_Name1.DataField = "BLGoodsHalfName";

                            txtCode.DataField = "CustomerCode";
                            txtCode.OutputFormat = "00000000";
                            txtName.DataField = "CustomerSnm";
                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "BLGoodsCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "BLGoodsCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.NewPage = NewPage.None;
                                SubSectionHeader.NewPage = NewPage.None;
                            }
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<
                            txtSubTitle.Text = " ＢＬコード計";
                            break;
                        case 2:     //発行タイプ：BLコード別担当者別
                            groupHeader1.DataField = "BLGoodsCode";
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            // ヘッダー設定
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.DataField = "";
                            }
                            groupHeader1.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SectionHeader.DataField = "AddUpSecCode";
                            SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                            SubSectionHeader.DataField = "BLGoodsCode";
                            SubSectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;

                            // フッター設定
                            SectionFooter.Visible = true;
                            SubSectionFooter.Visible = true;
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

                            txtDFTitle.Text = "ＢＬコード";
                            ChangeDF_Code1.DataField = "BLGoodsCode";
                            ChangeDF_Code1.OutputFormat = "00000";
                            ChangeDF_Name1.DataField = "BLGoodsHalfName";

                            txtCode.DataField = "EmployeeCode";
                            txtCode.OutputFormat = "0000";
                            txtName.DataField = "EmployeeName";
                            /* ---DEL 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            TitleHeader1.DataField = "BLGoodsCode";
                            if (this._extraInfo.NewPage2 == false)
                            {
                                TitleHeader1.NewPage = NewPage.None;
                            }
                            SubSectionHeader.DataField = "BLGoodsCode";
                            SubSectionFooter.Visible = true;
                               ---DEL 2009/01/30 不具合対応[9841] -----------------------------------------<<<<< */
                            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
                            if (this._extraInfo.NewPage2 == false)
                            {
                                groupHeader1.NewPage = NewPage.None;
                                SubSectionHeader.NewPage = NewPage.None;
                            }
                            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<
                            txtSubTitle.Text = " ＢＬコード計";
                            break;
                    }
                    break;
            }
            ExtraFooter.Visible = false;
        }
        #endregion 帳票タイプ別切替

        #region　月数取得

        /// <summary>
        /// 対象年月 月数計算処理
        /// </summary>
        /// <param name="i_stMonth">開始対象月</param>
        /// <param name="i_edMonth">終了対象月</param>
        /// <remarks>
        /// <br>Note: 開始対象年月と終了対象年月から対象年月の範囲を求めます。</br>
        /// </remarks>
        private int GetMonthRange(int i_stMonth, int i_edMonth)
        {

            //DateTimeは日に該当するものが無い場合、勝手に1月1日を返してしまうので、yyyymm形の対象年月にddを足してやる
            //開始年月
            string str_st_Month = i_stMonth.ToString() + "01";
            DateTime dt_stDate = DateTime.ParseExact(str_st_Month, "yyyyMMdd", null);

            //終了年月
            string str_ed_Month = i_edMonth.ToString() + "01";
            DateTime dt_edDate = DateTime.ParseExact(str_ed_Month, "yyyyMMdd", null);

            i_stMonth = dt_stDate.Month;
            i_edMonth = dt_edDate.Month;

            if (dt_edDate.Year > dt_stDate.Year)
            {
                i_edMonth += 12;
            }

            return (i_edMonth - i_stMonth + 1);

        }
        #endregion

        #region　月タイトル取得
        /// <summary>
        /// 月タイトル取得
        /// </summary>
        /// <param name="stYearMonth"></param>
        /// <param name="index"></param>
        /// <returns>月タイトル(ex.１月,２月…)</returns>
        private string GetMonthTitle(int stYearMonth, int index)
        {
            string strMonth = stYearMonth.ToString();
            strMonth = strMonth + "01";
            DateTime dt_stMonth = DateTime.ParseExact(strMonth, "yyyyMMdd", null);

            int month = dt_stMonth.Month + index;

            if (month > 12) month -= 12;

            return (month.ToString() + "月");
        }
        #endregion

        #region ◆ 月範囲印字設定
        /// <summary>
        /// 月範囲印字設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 月範囲の要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private void SetOfMonthAmbitOutput()
        {
            #region SetOfMonthAmbitOutput()

            // 印字設定 --------------------------------------------------------------------------------------

            //-------------------------------------------------------
            // 月範囲の適用（抽出された範囲内で処理する）
            //-------------------------------------------------------
            #region [月範囲の適用]

            // 作業用にリスト生成
            #region [作業用リスト生成]
            ArrayList[] ctrlList = new ArrayList[12];

            // 月1
            ctrlList[0] = new ArrayList();
            ctrlList[0].AddRange(new object[] { month1 });													//月
            //Detail
            ctrlList[0].AddRange(new object[] { txtTTermSales1, txtFTermSales1, txtSalesRatio1 });			//売上
            ctrlList[0].AddRange(new object[] { txtTTermGross1, txtFTermGross1, txtGrossRatio1 });			//粗利
            //部門計
            ctrlList[0].AddRange(new object[] { txtSubSecTSales1, txtSubSecFSales1, txtSubSecSalesRt1 });	//売上
            ctrlList[0].AddRange(new object[] { txtSubSecTGross1, txtSubSecFGross1, txtSubSecGrossRt1 });	//粗利
            //拠点計
            ctrlList[0].AddRange(new object[] { txtSecTSales1, txtSecFSales1, txtSecSalesRt1 });			//売上
            ctrlList[0].AddRange(new object[] { txtSecTGross1, txtSecFGross1, txtSecGrossRt1 });			//粗利
            //総合計
            ctrlList[0].AddRange(new object[] { txtTTSales1, txtTFSales1, txtTSalesRt1 });					//売上
            ctrlList[0].AddRange(new object[] { txtTTGross1, txtTFGross1, txtTGrossRt1 });					//粗利

            // 月2
            ctrlList[1] = new ArrayList();
            ctrlList[1].AddRange(new object[] { month2 });
            //Detail
            ctrlList[1].AddRange(new object[] { txtTTermSales2, txtFTermSales2, txtSalesRatio2 });
            ctrlList[1].AddRange(new object[] { txtTTermGross2, txtFTermGross2, txtGrossRatio2 });
            //部門計
            ctrlList[1].AddRange(new object[] { txtSubSecTSales2, txtSubSecFSales2, txtSubSecSalesRt2 });	//売上
            ctrlList[1].AddRange(new object[] { txtSubSecTGross2, txtSubSecFGross2, txtSubSecGrossRt2 });	//粗利
            //拠点計
            ctrlList[1].AddRange(new object[] { txtSecTSales2, txtSecFSales2, txtSecSalesRt2 });			//売上
            ctrlList[1].AddRange(new object[] { txtSecTGross2, txtSecFGross2, txtSecGrossRt2 });			//粗利
            //総合計
            ctrlList[1].AddRange(new object[] { txtTTSales2, txtTFSales2, txtTSalesRt2 });					//売上
            ctrlList[1].AddRange(new object[] { txtTTGross2, txtTFGross2, txtTGrossRt2 });					//粗利

            // 月3
            ctrlList[2] = new ArrayList();
            ctrlList[2].AddRange(new object[] { month3 });
            //Detail
            ctrlList[2].AddRange(new object[] { txtTTermSales3, txtFTermSales3, txtSalesRatio3 });
            ctrlList[2].AddRange(new object[] { txtTTermGross3, txtFTermGross3, txtGrossRatio3 });
            //部門計
            ctrlList[2].AddRange(new object[] { txtSubSecTSales3, txtSubSecFSales3, txtSubSecSalesRt3 });	//売上
            ctrlList[2].AddRange(new object[] { txtSubSecTGross3, txtSubSecFGross3, txtSubSecGrossRt3 });	//粗利
            //拠点計
            ctrlList[2].AddRange(new object[] { txtSecTSales3, txtSecFSales3, txtSecSalesRt3 });			//売上
            ctrlList[2].AddRange(new object[] { txtSecTGross3, txtSecFGross3, txtSecGrossRt3 });			//粗利
            //総合計
            ctrlList[2].AddRange(new object[] { txtTTSales3, txtTFSales3, txtTSalesRt3 });					//売上
            ctrlList[2].AddRange(new object[] { txtTTGross3, txtTFGross3, txtTGrossRt3 });					//粗利

            // 月4
            ctrlList[3] = new ArrayList();
            ctrlList[3].AddRange(new object[] { month4 });
            //Detail
            ctrlList[3].AddRange(new object[] { txtTTermSales4, txtFTermSales4, txtSalesRatio4 });
            ctrlList[3].AddRange(new object[] { txtTTermGross4, txtFTermGross4, txtGrossRatio4 });
            //部門計
            ctrlList[3].AddRange(new object[] { txtSubSecTSales4, txtSubSecFSales4, txtSubSecSalesRt4 });	//売上
            ctrlList[3].AddRange(new object[] { txtSubSecTGross4, txtSubSecFGross4, txtSubSecGrossRt4 });	//粗利
            //拠点計
            ctrlList[3].AddRange(new object[] { txtSecTSales4, txtSecFSales4, txtSecSalesRt4 });			//売上
            ctrlList[3].AddRange(new object[] { txtSecTGross4, txtSecFGross4, txtSecGrossRt4 });			//粗利
            //総合計
            ctrlList[3].AddRange(new object[] { txtTTSales4, txtTFSales4, txtTSalesRt4 });					//売上
            ctrlList[3].AddRange(new object[] { txtTTGross4, txtTFGross4, txtTGrossRt4 });					//粗利

            // 月5
            ctrlList[4] = new ArrayList();
            ctrlList[4].AddRange(new object[] { month5 });
            //Detail
            ctrlList[4].AddRange(new object[] { txtTTermSales5, txtFTermSales5, txtSalesRatio5 });
            ctrlList[4].AddRange(new object[] { txtTTermGross5, txtFTermGross5, txtGrossRatio5 });
            //部門計
            ctrlList[4].AddRange(new object[] { txtSubSecTSales5, txtSubSecFSales5, txtSubSecSalesRt5 });	//売上
            ctrlList[4].AddRange(new object[] { txtSubSecTGross5, txtSubSecFGross5, txtSubSecGrossRt5 });	//粗利
            //拠点計
            ctrlList[4].AddRange(new object[] { txtSecTSales5, txtSecFSales5, txtSecSalesRt5 });			//売上
            ctrlList[4].AddRange(new object[] { txtSecTGross5, txtSecFGross5, txtSecGrossRt5 });			//粗利
            //総合計
            ctrlList[4].AddRange(new object[] { txtTTSales5, txtTFSales5, txtTSalesRt5 });					//売上
            ctrlList[4].AddRange(new object[] { txtTTGross5, txtTFGross5, txtTGrossRt5 });					//粗利

            // 月6
            ctrlList[5] = new ArrayList();
            ctrlList[5].AddRange(new object[] { month6 });
            //Detail
            ctrlList[5].AddRange(new object[] { txtTTermSales6, txtFTermSales6, txtSalesRatio6 });
            ctrlList[5].AddRange(new object[] { txtTTermGross6, txtFTermGross6, txtGrossRatio6 });
            //部門計
            ctrlList[5].AddRange(new object[] { txtSubSecTSales6, txtSubSecFSales6, txtSubSecSalesRt6 });	//売上
            ctrlList[5].AddRange(new object[] { txtSubSecTGross6, txtSubSecFGross6, txtSubSecGrossRt6 });	//粗利
            //拠点計
            ctrlList[5].AddRange(new object[] { txtSecTSales6, txtSecFSales6, txtSecSalesRt6 });			//売上
            ctrlList[5].AddRange(new object[] { txtSecTGross6, txtSecFGross6, txtSecGrossRt6 });			//粗利
            //総合計
            ctrlList[5].AddRange(new object[] { txtTTSales6, txtTFSales6, txtTSalesRt6 });					//売上
            ctrlList[5].AddRange(new object[] { txtTTGross6, txtTFGross6, txtTGrossRt6 });					//粗利

            // 月7
            ctrlList[6] = new ArrayList();
            ctrlList[6].AddRange(new object[] { month7 });
            //Detail
            ctrlList[6].AddRange(new object[] { txtTTermSales7, txtFTermSales7, txtSalesRatio7 });
            ctrlList[6].AddRange(new object[] { txtTTermGross7, txtFTermGross7, txtGrossRatio7 });
            //部門計
            ctrlList[6].AddRange(new object[] { txtSubSecTSales7, txtSubSecFSales7, txtSubSecSalesRt7 });	//売上
            ctrlList[6].AddRange(new object[] { txtSubSecTGross7, txtSubSecFGross7, txtSubSecGrossRt7 });	//粗利
            //拠点計
            ctrlList[6].AddRange(new object[] { txtSecTSales7, txtSecFSales7, txtSecSalesRt7 });			//売上
            ctrlList[6].AddRange(new object[] { txtSecTGross7, txtSecFGross7, txtSecGrossRt7 });			//粗利
            //総合計
            ctrlList[6].AddRange(new object[] { txtTTSales7, txtTFSales7, txtTSalesRt7 });					//売上
            ctrlList[6].AddRange(new object[] { txtTTGross7, txtTFGross7, txtTGrossRt7 });					//粗利

            // 月8
            ctrlList[7] = new ArrayList();
            ctrlList[7].AddRange(new object[] { month8 });
            //Detail
            ctrlList[7].AddRange(new object[] { txtTTermSales8, txtFTermSales8, txtSalesRatio8 });
            ctrlList[7].AddRange(new object[] { txtTTermGross8, txtFTermGross8, txtGrossRatio8 });
            //部門計
            ctrlList[7].AddRange(new object[] { txtSubSecTSales8, txtSubSecFSales8, txtSubSecSalesRt8 });	//売上
            ctrlList[7].AddRange(new object[] { txtSubSecTGross8, txtSubSecFGross8, txtSubSecGrossRt8 });	//粗利
            //拠点計
            ctrlList[7].AddRange(new object[] { txtSecTSales8, txtSecFSales8, txtSecSalesRt8 });			//売上
            ctrlList[7].AddRange(new object[] { txtSecTGross8, txtSecFGross8, txtSecGrossRt8 });			//粗利
            //総合計
            ctrlList[7].AddRange(new object[] { txtTTSales8, txtTFSales8, txtTSalesRt8 });					//売上
            ctrlList[7].AddRange(new object[] { txtTTGross8, txtTFGross8, txtTGrossRt8 });					//粗利

            // 月9
            ctrlList[8] = new ArrayList();
            ctrlList[8].AddRange(new object[] { month9 });
            //Detail
            ctrlList[8].AddRange(new object[] { txtTTermSales9, txtFTermSales9, txtSalesRatio9 });
            ctrlList[8].AddRange(new object[] { txtTTermGross9, txtFTermGross9, txtGrossRatio9 });
            //部門計
            ctrlList[8].AddRange(new object[] { txtSubSecTSales9, txtSubSecFSales9, txtSubSecSalesRt9 });	//売上
            ctrlList[8].AddRange(new object[] { txtSubSecTGross9, txtSubSecFGross9, txtSubSecGrossRt9 });	//粗利
            //拠点計
            ctrlList[8].AddRange(new object[] { txtSecTSales9, txtSecFSales9, txtSecSalesRt9 });			//売上
            ctrlList[8].AddRange(new object[] { txtSecTGross9, txtSecFGross9, txtSecGrossRt9 });			//粗利
            //総合計
            ctrlList[8].AddRange(new object[] { txtTTSales9, txtTFSales9, txtTSalesRt9 });					//売上
            ctrlList[8].AddRange(new object[] { txtTTGross9, txtTFGross9, txtTGrossRt9 });					//粗利

            // 月10
            ctrlList[9] = new ArrayList();
            ctrlList[9].AddRange(new object[] { month10 });
            //Detail
            ctrlList[9].AddRange(new object[] { txtTTermSales10, txtFTermSales10, txtSalesRatio10 });
            ctrlList[9].AddRange(new object[] { txtTTermGross10, txtFTermGross10, txtGrossRatio10 });
            //部門計
            ctrlList[9].AddRange(new object[] { txtSubSecTSales10, txtSubSecFSales10, txtSubSecSalesRt10 });	//売上
            ctrlList[9].AddRange(new object[] { txtSubSecTGross10, txtSubSecFGross10, txtSubSecGrossRt10 });	//粗利
            //拠点計
            ctrlList[9].AddRange(new object[] { txtSecTSales10, txtSecFSales10, txtSecSalesRt10 });				//売上
            ctrlList[9].AddRange(new object[] { txtSecTGross10, txtSecFGross10, txtSecGrossRt10 });				//粗利
            //総合計
            ctrlList[9].AddRange(new object[] { txtTTSales10, txtTFSales10, txtTSalesRt10 });					//売上
            ctrlList[9].AddRange(new object[] { txtTTGross10, txtTFGross10, txtTGrossRt10 });					//粗利

            // 月11
            ctrlList[10] = new ArrayList();
            ctrlList[10].AddRange(new object[] { month11 });
            //Detail
            ctrlList[10].AddRange(new object[] { txtTTermSales11, txtFTermSales11, txtSalesRatio11 });
            ctrlList[10].AddRange(new object[] { txtTTermGross11, txtFTermGross11, txtGrossRatio11 });
            //部門計
            ctrlList[10].AddRange(new object[] { txtSubSecTSales11, txtSubSecFSales11, txtSubSecSalesRt11 });	//売上
            ctrlList[10].AddRange(new object[] { txtSubSecTGross11, txtSubSecFGross11, txtSubSecGrossRt11 });	//粗利
            //拠点計
            ctrlList[10].AddRange(new object[] { txtSecTSales11, txtSecFSales11, txtSecSalesRt11 });			//売上
            ctrlList[10].AddRange(new object[] { txtSecTGross11, txtSecFGross11, txtSecGrossRt11 });			//粗利
            //総合計
            ctrlList[10].AddRange(new object[] { txtTTSales11, txtTFSales11, txtTSalesRt11 });					//売上
            ctrlList[10].AddRange(new object[] { txtTTGross11, txtTFGross11, txtTGrossRt11 });					//粗利

            // 月12
            ctrlList[11] = new ArrayList();
            ctrlList[11].AddRange(new object[] { month12 });
            //Detail
            ctrlList[11].AddRange(new object[] { txtTTermSales12, txtFTermSales12, txtSalesRatio12 });
            ctrlList[11].AddRange(new object[] { txtTTermGross12, txtFTermGross12, txtGrossRatio12 });
            //部門計
            ctrlList[11].AddRange(new object[] { txtSubSecTSales12, txtSubSecFSales12, txtSubSecSalesRt12 });	//売上
            ctrlList[11].AddRange(new object[] { txtSubSecTGross12, txtSubSecFGross12, txtSubSecGrossRt12 });	//粗利
            //拠点計
            ctrlList[11].AddRange(new object[] { txtSecTSales12, txtSecFSales12, txtSecSalesRt12 });			//売上
            ctrlList[11].AddRange(new object[] { txtSecTGross12, txtSecFGross12, txtSecGrossRt12 });			//粗利
            //総合計
            ctrlList[11].AddRange(new object[] { txtTTSales12, txtTFSales12, txtTSalesRt12 });					//売上
            ctrlList[11].AddRange(new object[] { txtTTGross12, txtTFGross12, txtTGrossRt12 });					//粗利


            // 月タイトルリスト
            // (※注意：月タイトルラベルはこのリストにも、上記の月毎コントロールリストにも格納されます)
            List<Label> monthTitleList = new List<Label>();
            monthTitleList.AddRange(new Label[] { month1, month2, month3, month4, month5, month6, month7, month8, month9, month10, month11, month12 });

            #endregion

            // 月数の取得
            int monthRange = GetMonthRange(this._extraInfo.St_AddUpYearMonth, this._extraInfo.Ed_AddUpYearMonth);

            // 印字有無を設定
            for (int index = 0; index < ctrlList.Length; index++)
            {
                // 月タイトル設定
                if (index < monthTitleList.Count)
                {
                    monthTitleList[index].Text = GetMonthTitle(this._extraInfo.St_AddUpYearMonth, index);
                }

                // 印字有無設定
                foreach (object ctrl in ctrlList[index])
                {
                    if (ctrl is TextBox)
                    {
                        (ctrl as TextBox).Visible = (index < monthRange);   // 範囲内のみtrue
                    }
                    else if (ctrl is Label)
                    {
                        (ctrl as Label).Visible = (index < monthRange);     // 範囲内のみtrue
                    }
                }
            }

            #endregion

            #endregion SetOfMonthAmbitOutput()
        }
        #endregion	月範囲印字設定

        #region ◆Detial（明細）に対するイベント
        /// <summary>
        /// Detial（明細）に対するイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: Detial（明細）に対するイベントを行います。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// </remarks>
        private void DetialItem_Event()
        {
            #region [項目リストを生成]

            //売上
            //タイトル
            List<Label> lbTitleDtSlList = new List<Label>();
            lbTitleDtSlList.AddRange(new Label[] { lbTitleSl, lbTitleTTermSl, lbTitleFTermSl, lbTitleSlRatio });
            //値
            List<TextBox> tbDetialSlList = new List<TextBox>();
            tbDetialSlList.AddRange(new TextBox[] { txtTTermSales1, txtTTermSales2, txtTTermSales3, txtTTermSales4, txtTTermSales5, txtTTermSales6, txtTTermSales7, txtTTermSales8, txtTTermSales9, txtTTermSales10, txtTTermSales11, txtTTermSales12, txtTTermTotalSales });
            tbDetialSlList.AddRange(new TextBox[] { txtFTermSales1, txtFTermSales2, txtFTermSales3, txtFTermSales4, txtFTermSales5, txtFTermSales6, txtFTermSales7, txtFTermSales8, txtFTermSales9, txtFTermSales10, txtFTermSales11, txtFTermSales12, txtFTermTotalSales });
            tbDetialSlList.AddRange(new TextBox[] { txtSalesRatio1, txtSalesRatio2, txtSalesRatio3, txtSalesRatio4, txtSalesRatio5, txtSalesRatio6, txtSalesRatio7, txtSalesRatio8, txtSalesRatio9, txtSalesRatio10, txtSalesRatio11, txtSalesRatio12, txtTotalSalesRatio });

            //粗利
            //タイトル																	
            List<Label> lbTitleDtGrsList = new List<Label>();
            lbTitleDtGrsList.AddRange(new Label[] { lbTitleGrs, lbTitleTTermGrs, lbTitleFTermGrs, lbTitleGrsRatio });
            //値
            List<TextBox> tbDetialGrsList = new List<TextBox>();
            tbDetialGrsList.AddRange(new TextBox[] { txtTTermGross1, txtTTermGross2, txtTTermGross3, txtTTermGross4, txtTTermGross5, txtTTermGross6, txtTTermGross7, txtTTermGross8, txtTTermGross9, txtTTermGross10, txtTTermGross11, txtTTermGross12, txtTTermTotalGross });
            tbDetialGrsList.AddRange(new TextBox[] { txtFTermGross1, txtFTermGross2, txtFTermGross3, txtFTermGross4, txtFTermGross5, txtFTermGross6, txtFTermGross7, txtFTermGross8, txtFTermGross9, txtFTermGross10, txtFTermGross11, txtFTermGross12, txtFTermTotalGross });
            tbDetialGrsList.AddRange(new TextBox[] { txtGrossRatio1, txtGrossRatio2, txtGrossRatio3, txtGrossRatio4, txtGrossRatio5, txtGrossRatio6, txtGrossRatio7, txtGrossRatio8, txtGrossRatio9, txtGrossRatio10, txtGrossRatio11, txtGrossRatio12, txtTotalGrossRatio });

            #endregion [項目リストを生成]

            #region [印刷タイプ（売上・粗利・売上＆粗利）の適用]

            switch (this._extraInfo.PrintType)
            {
                case 0: // 売上
                    line8.Y1 = (float)0.56;
                    line8.Y2 = (float)0.56;

                    for (int index = 0; index < lbTitleDtGrsList.Count; index++)
                    {
                        // 粗利タイトルラベル非印字
                        lbTitleDtGrsList[index].Visible = false;
                    }

                    for (int index = 0; index < tbDetialGrsList.Count; index++)
                    {
                        // 粗利値textBox全て非印字
                        tbDetialGrsList[index].Visible = false;
                    }

                    break;

                case 1: // 粗利
                    line8.Y1 = (float)0.56;
                    line8.Y2 = (float)0.56;
                    for (int index = 0; index < lbTitleDtSlList.Count; index++)
                    {
                        // 売上タイトルラベル非印字
                        lbTitleDtSlList[index].Visible = false;
                        // 粗利タイトルラベル位置移動					
                        lbTitleDtGrsList[index].Top = lbTitleDtSlList[index].Top;

                    }
                    for (int index = 0; index < tbDetialSlList.Count; index++)
                    {
                        // 売上値textBox非印字
                        tbDetialSlList[index].Visible = false;
                        // 粗利値textBox位置移動
                        tbDetialGrsList[index].Top = tbDetialSlList[index].Top;
                    }

                    break;

                case 2: //売上＆粗利

                    break;
            }

            #endregion [印刷タイプ（売上・粗利・売上＆粗利）の適用]

        }
        #endregion ◆Detial（明細）に対するイベント:終

        #region ◆サブ計（SubSection）に対するイベント
        /// <summary>
        /// サブ計に対するイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: サブ計の比率計算・値のセット、項目の移動を行います。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 比率算出不正の対応</br>
        /// </remarks>
        private void SubSectionItem_Event()
        {
            #region [項目リストを生成]

            //売上
            //タイトル
            List<Label> lbTitleSubSecSlList = new List<Label>();
            lbTitleSubSecSlList.AddRange(new Label[] { lbTitleTSl, lbTitleSubSecTSl, lbTitleSubSecFSl, lbTitleSubSecSlRt });
            //当年
            List<TextBox> tbSubSecThisSlList = new List<TextBox>();
            tbSubSecThisSlList.AddRange(new TextBox[] { txtSubSecTSales1, txtSubSecTSales2, txtSubSecTSales3, txtSubSecTSales4, txtSubSecTSales5, txtSubSecTSales6, txtSubSecTSales7, txtSubSecTSales8, txtSubSecTSales9, txtSubSecTSales10, txtSubSecTSales11, txtSubSecTSales12, txtSubSecTTotalSales });
            //前年
            List<TextBox> tbSubSecFirstSlList = new List<TextBox>();
            tbSubSecFirstSlList.AddRange(new TextBox[] { txtSubSecFSales1, txtSubSecFSales2, txtSubSecFSales3, txtSubSecFSales4, txtSubSecFSales5, txtSubSecFSales6, txtSubSecFSales7, txtSubSecFSales8, txtSubSecFSales9, txtSubSecFSales10, txtSubSecFSales11, txtSubSecFSales12, txtSubSecFTotalSales });
            //比率
            List<TextBox> tbSubSecSlRatioList = new List<TextBox>();
            tbSubSecSlRatioList.AddRange(new TextBox[] { txtSubSecSalesRt1, txtSubSecSalesRt2, txtSubSecSalesRt3, txtSubSecSalesRt4, txtSubSecSalesRt5, txtSubSecSalesRt6, txtSubSecSalesRt7, txtSubSecSalesRt8, txtSubSecSalesRt9, txtSubSecSalesRt10, txtSubSecSalesRt11, txtSubSecSalesRt12, txtSubSecTotalSalesRt });
            //粗利
            //タイトル
            List<Label> lbTitleSubSecGrsList = new List<Label>();
            lbTitleSubSecGrsList.AddRange(new Label[] { lbTitleTGrs, lbTitleSubSecTGrs, lbTitleSubSecFGrs, lbTitleSubSecGrsRt });
            //当年
            List<TextBox> tbSubSecThisGrsList = new List<TextBox>();
            tbSubSecThisGrsList.AddRange(new TextBox[] { txtSubSecTGross1, txtSubSecTGross2, txtSubSecTGross3, txtSubSecTGross4, txtSubSecTGross5, txtSubSecTGross6, txtSubSecTGross7, txtSubSecTGross8, txtSubSecTGross9, txtSubSecTGross10, txtSubSecTGross11, txtSubSecTGross12, txtSubSecTTotalGross });
            //前年
            List<TextBox> tbSubSecFirstGrsList = new List<TextBox>();
            tbSubSecFirstGrsList.AddRange(new TextBox[] { txtSubSecFGross1, txtSubSecFGross2, txtSubSecFGross3, txtSubSecFGross4, txtSubSecFGross5, txtSubSecFGross6, txtSubSecFGross7, txtSubSecFGross8, txtSubSecFGross9, txtSubSecFGross10, txtSubSecFGross11, txtSubSecFGross12, txtSubSecFTotalGross });
            //比率
            List<TextBox> tbSubSecGrsRatioList = new List<TextBox>();
            tbSubSecGrsRatioList.AddRange(new TextBox[] { txtSubSecGrossRt1, txtSubSecGrossRt2, txtSubSecGrossRt3, txtSubSecGrossRt4, txtSubSecGrossRt5, txtSubSecGrossRt6, txtSubSecGrossRt7, txtSubSecGrossRt8, txtSubSecGrossRt9, txtSubSecGrossRt10, txtSubSecGrossRt11, txtSubSecGrossRt12, txtSubSecTotalGrossRt });

            #endregion [項目リストを生成]

            #region [比率の計算、値のセット]

            // サブ計：売上比
            for (int i = 0; i < tbSubSecThisSlList.Count; i++)
            {
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応---------->>>>>
                //Double i_subSecTSales = 0;
                //Double i_subSecFSales = 0;

                //i_subSecTSales = Convert.ToDouble(tbSubSecThisSlList[i].Value);		//当年売上
                //i_subSecFSales = Convert.ToDouble(tbSubSecFirstSlList[i].Value);	//前年売上

                //if (i_subSecFSales != 0 && tbSubSecFirstSlList[i].Value != null)
                //{
                //    i_subSecTSales = i_subSecTSales * 100;

                //     Double _subSecSalesRt = Math.Round((i_subSecTSales / i_subSecFSales), 4);		//小数点第五位で丸め

                //    _subSecSalesRt = Math.Round(_subSecSalesRt, 2, MidpointRounding.AwayFromZero);	//小数点第三位を四捨五入
                //    tbSubSecSlRatioList[i].Value = _subSecSalesRt;									//比率をtextBoxにセット
                //}
                //else
                //{
                //    tbSubSecSlRatioList[i].Value = 0;
                //}
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応----------<<<<<

                tbSubSecSlRatioList[i].Value = GetRatio(tbSubSecThisSlList[i].Value, tbSubSecFirstSlList[i].Value); //小数点第三位を四捨五入// ADD cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
            }

            // サブ計：粗利比
            for (int i = 0; i < tbSubSecThisGrsList.Count; i++)
            {
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応---------->>>>>
                //Double i_subSecTGross = 0;
                //Double i_subSecFGross = 0;

                //i_subSecTGross = Convert.ToDouble(tbSubSecThisGrsList[i].Value);	//当年粗利
                //i_subSecFGross = Convert.ToDouble(tbSubSecFirstGrsList[i].Value);	//前年粗利

                //if (i_subSecFGross != 0 && tbSubSecFirstGrsList[i].Value != null)
                //{
                    //i_subSecTGross = i_subSecTGross * 100;

                    //Double _subSecGrossRt = Math.Round((i_subSecTGross / i_subSecFGross), 4);

                    //_subSecGrossRt = Math.Round(_subSecGrossRt, 2, MidpointRounding.AwayFromZero);	//小数点第三位を四捨五入
                    //tbSubSecGrsRatioList[i].Value = _subSecGrossRt;									//比率をtextBoxにセット
                //}
                //else
                //{
                //    tbSubSecGrsRatioList[i].Value = 0;
                //}
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応----------<<<<<

                tbSubSecGrsRatioList[i].Value = GetRatio(tbSubSecThisGrsList[i].Value, tbSubSecFirstGrsList[i].Value); //小数点第三位を四捨五入// ADD cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
            }

            #endregion [比率の計算、値のセット]

            #region [印刷タイプ（売上・粗利・売上＆粗利）の適用]

            switch (this._extraInfo.PrintType)
            {
                case 0: //売上
                    for (int i = 0; i < lbTitleSubSecGrsList.Count; i++)
                    {
                        //粗利タイトルラベル非印字
                        lbTitleSubSecGrsList[i].Visible = false;
                    }

                    for (int h = 0; h < tbSubSecThisGrsList.Count; h++)
                    {
                        //粗利値textBox非印字
                        tbSubSecThisGrsList[h].Visible = false;
                        tbSubSecFirstGrsList[h].Visible = false;
                        tbSubSecGrsRatioList[h].Visible = false;
                    }

                    break;

                case 1: //粗利
                    for (int i = 0; i < lbTitleSubSecSlList.Count; i++)
                    {
                        //売上タイトルラベル非印字
                        lbTitleSubSecSlList[i].Visible = false;
                        //粗利タイトルの位置移動
                        lbTitleSubSecGrsList[i].Top = lbTitleSubSecSlList[i].Top;
                    }

                    for (int h = 0; h < tbSubSecThisGrsList.Count; h++)
                    {
                        //売上値textBox非印字
                        tbSubSecThisSlList[h].Visible = false;
                        tbSubSecFirstSlList[h].Visible = false;
                        tbSubSecSlRatioList[h].Visible = false;

                        //粗利値textBoxの位置移動
                        tbSubSecThisGrsList[h].Top = tbSubSecThisSlList[h].Top;
                        tbSubSecFirstGrsList[h].Top = tbSubSecFirstSlList[h].Top;
                        tbSubSecGrsRatioList[h].Top = tbSubSecSlRatioList[h].Top;

                    }

                    break;
            }

            #endregion [印刷タイプ（売上・粗利・売上＆粗利）の適用]
        }

        #endregion サブ計に対するイベント:終

        #region ◆拠点計（ExtraFooter）に対するイベント
        /// <summary>
        /// 拠点計に対するイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 拠点計の比率計算・値のセット、項目の移動を行います。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 比率算出不正の対応</br>
        /// </remarks>
        private void SectionItem_Event()
        {
            #region [項目リストを生成]

            //売上
            //タイトル
            List<Label> lbTitleSecSlList = new List<Label>();
            lbTitleSecSlList.AddRange(new Label[] { lbTitleSSl, lbTitleSecTSl, lbTitleSecFSl, lbTitleSecSlRt });
            //当年
            List<TextBox> tbSecThisSlList = new List<TextBox>();
            tbSecThisSlList.AddRange(new TextBox[] { txtSecTSales1, txtSecTSales2, txtSecTSales3, txtSecTSales4, txtSecTSales5, txtSecTSales6, txtSecTSales7, txtSecTSales8, txtSecTSales9, txtSecTSales10, txtSecTSales11, txtSecTSales12, txtSecTTotalSales });
            //前年
            List<TextBox> tbSecFirstSlList = new List<TextBox>();
            tbSecFirstSlList.AddRange(new TextBox[] { txtSecFSales1, txtSecFSales2, txtSecFSales3, txtSecFSales4, txtSecFSales5, txtSecFSales6, txtSecFSales7, txtSecFSales8, txtSecFSales9, txtSecFSales10, txtSecFSales11, txtSecFSales12, txtSecFTotalSales });
            //比率
            List<TextBox> tbSecSlRatioList = new List<TextBox>();
            tbSecSlRatioList.AddRange(new TextBox[] { txtSecSalesRt1, txtSecSalesRt2, txtSecSalesRt3, txtSecSalesRt4, txtSecSalesRt5, txtSecSalesRt6, txtSecSalesRt7, txtSecSalesRt8, txtSecSalesRt9, txtSecSalesRt10, txtSecSalesRt11, txtSecSalesRt12, txtSecTotalSalesRt });
            //粗利
            //タイトル
            List<Label> lbTitleSecGrsList = new List<Label>();
            lbTitleSecGrsList.AddRange(new Label[] { lbTitleSGrs, lbTitleSecTGrs, lbTitleSecFGrs, lbTitleSecGrsRt });
            //当年
            List<TextBox> tbSecThisGrsList = new List<TextBox>();
            tbSecThisGrsList.AddRange(new TextBox[] { txtSecTGross1, txtSecTGross2, txtSecTGross3, txtSecTGross4, txtSecTGross5, txtSecTGross6, txtSecTGross7, txtSecTGross8, txtSecTGross9, txtSecTGross10, txtSecTGross11, txtSecTGross12, txtSecTTotalGross });
            //前年
            List<TextBox> tbSecFirstGrsList = new List<TextBox>();
            tbSecFirstGrsList.AddRange(new TextBox[] { txtSecFGross1, txtSecFGross2, txtSecFGross3, txtSecFGross4, txtSecFGross5, txtSecFGross6, txtSecFGross7, txtSecFGross8, txtSecFGross9, txtSecFGross10, txtSecFGross11, txtSecFGross12, txtSecFTotalGross });
            //比率
            List<TextBox> tbSecGrsRatioList = new List<TextBox>();
            tbSecGrsRatioList.AddRange(new TextBox[] { txtSecGrossRt1, txtSecGrossRt2, txtSecGrossRt3, txtSecGrossRt4, txtSecGrossRt5, txtSecGrossRt6, txtSecGrossRt7, txtSecGrossRt8, txtSecGrossRt9, txtSecGrossRt10, txtSecGrossRt11, txtSecGrossRt12, txtSecTotalGrossRt });

            #endregion [項目リストを生成]

            #region [比率の計算、値のセット]

            // 拠点計：売上比
            for (int i = 0; i < tbSecThisSlList.Count; i++)
            {
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応---------->>>>>
                //Double i_secTSales = 0;
                //Double i_secFSales = 0;

                //i_secTSales = Convert.ToDouble(tbSecThisSlList[i].Value);	//当年売上
                //i_secFSales = Convert.ToDouble(tbSecFirstSlList[i].Value);	//前年売上

                //if (i_secFSales != 0 && tbSecFirstSlList[i].Value != null)
                //{
                    //i_secTSales = i_secTSales * 100;

                    //Double _secSalesRt = Math.Round((i_secTSales / i_secFSales), 4);

                    //_secSalesRt = Math.Round(_secSalesRt, 2, MidpointRounding.AwayFromZero);	//小数点第三位を四捨五入
                    //tbSecSlRatioList[i].Value = _secSalesRt;									//比率をtextBoxにセット
                //}
                //else
                //{
                //    tbSecSlRatioList[i].Value = 0;
                //}
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応----------<<<<<

                tbSecSlRatioList[i].Value = GetRatio(tbSecThisSlList[i].Value, tbSecFirstSlList[i].Value); //小数点第三位を四捨五入// ADD cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
            }

            // 拠点計：粗利比
            for (int i = 0; i < tbSecThisGrsList.Count; i++)
            {
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応---------->>>>>
                //Double i_secTGross = 0;
                //Double i_secFGross = 0;

                //i_secTGross = Convert.ToDouble(tbSecThisGrsList[i].Value); 	//当年粗利
                //i_secFGross = Convert.ToDouble(tbSecFirstGrsList[i].Value);	//前年粗利

                //if (i_secFGross != 0 && tbSecFirstGrsList[i].Value != null)
                //{
                //    i_secTGross = i_secTGross * 100;

                //    Double _secSalesRt = Math.Round((i_secTGross / i_secFGross), 4);

                //    _secSalesRt = Math.Round(_secSalesRt, 2, MidpointRounding.AwayFromZero);	//小数点第三位を四捨五入
                //    tbSecGrsRatioList[i].Value = _secSalesRt;									//比率をtextBoxにセット
                //}
                //else
                //{
                //    tbSecGrsRatioList[i].Value = 0;
                //}
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応----------<<<<<

                tbSecGrsRatioList[i].Value = GetRatio(tbSecThisGrsList[i].Value, tbSecFirstGrsList[i].Value); //小数点第三位を四捨五入// ADD cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
            }

            #endregion [比率の計算、値のセット]

            #region [印刷タイプ（売上・粗利・売上＆粗利）の適用]

            switch (this._extraInfo.PrintType)
            {
                case 0: //売上
                    for (int i = 0; i < lbTitleSecGrsList.Count; i++)
                    {
                        //粗利タイトルラベル非印字
                        lbTitleSecGrsList[i].Visible = false;
                    }

                    for (int h = 0; h < tbSecThisGrsList.Count; h++)
                    {
                        //粗利値textBox非印字
                        tbSecThisGrsList[h].Visible = false;
                        tbSecFirstGrsList[h].Visible = false;
                        tbSecGrsRatioList[h].Visible = false;
                    }

                    break;

                case 1: //粗利
                    for (int i = 0; i < lbTitleSecSlList.Count; i++)
                    {
                        //売上タイトルラベル非印字
                        lbTitleSecSlList[i].Visible = false;
                        //粗利タイトルの位置移動
                        lbTitleSecGrsList[i].Top = lbTitleSecSlList[i].Top;
                    }

                    for (int h = 0; h < tbSecThisGrsList.Count; h++)
                    {
                        //売上値textBox非印字
                        tbSecThisSlList[h].Visible = false;
                        tbSecFirstSlList[h].Visible = false;
                        tbSecSlRatioList[h].Visible = false;

                        //粗利値textBoxの位置移動
                        tbSecThisGrsList[h].Top = tbSecThisSlList[h].Top;
                        tbSecFirstGrsList[h].Top = tbSecFirstSlList[h].Top;
                        tbSecGrsRatioList[h].Top = tbSecSlRatioList[h].Top;

                    }
                    break;
            }

            #endregion [印刷タイプ（売上・粗利・売上＆粗利）の適用]
        }

        #endregion 拠点計に対するイベント：終

        #region ◆総合計（reportFooter1）に対するイベント
        /// <summary>
        /// 総合計に対するイベント
        /// </summary>
        /// <remarks>
        /// <br>Note		: 総合計の比率計算・値のセット、項目の移動を行います。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.11.25</br>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 比率算出不正の対応</br>
        /// </remarks>
        private void TotalItem_Event()
        {
            #region [項目リストを生成]

            //売上
            //タイトル
            List<Label> lbTitleTSlList = new List<Label>();
            lbTitleTSlList.AddRange(new Label[] { lbTitleToTSl, lbTitleTTSl, lbTitleTFSl, lbTitleTSlRt });
            //当年
            List<TextBox> tbTThisSlList = new List<TextBox>();
            tbTThisSlList.AddRange(new TextBox[] { txtTTSales1, txtTTSales2, txtTTSales3, txtTTSales4, txtTTSales5, txtTTSales6, txtTTSales7, txtTTSales8, txtTTSales9, txtTTSales10, txtTTSales11, txtTTSales12, txtTTTotalSales });
            //前年
            List<TextBox> tbTFirstSlList = new List<TextBox>();
            tbTFirstSlList.AddRange(new TextBox[] { txtTFSales1, txtTFSales2, txtTFSales3, txtTFSales4, txtTFSales5, txtTFSales6, txtTFSales7, txtTFSales8, txtTFSales9, txtTFSales10, txtTFSales11, txtTFSales12, txtTFTotalSales });
            //比率
            List<TextBox> tbTSlRatioList = new List<TextBox>();
            tbTSlRatioList.AddRange(new TextBox[] { txtTSalesRt1, txtTSalesRt2, txtTSalesRt3, txtTSalesRt4, txtTSalesRt5, txtTSalesRt6, txtTSalesRt7, txtTSalesRt8, txtTSalesRt9, txtTSalesRt10, txtTSalesRt11, txtTSalesRt12, txtTTotalSalesRt });
            //粗利
            //タイトル
            List<Label> lbTitleTGrsList = new List<Label>();
            lbTitleTGrsList.AddRange(new Label[] { lbTitleToTGrs, lbTitleTTGrs, lbTitleTFGrs, lbTitleTGrsRt });
            //当年
            List<TextBox> tbTThisGrsList = new List<TextBox>();
            tbTThisGrsList.AddRange(new TextBox[] { txtTTGross1, txtTTGross2, txtTTGross3, txtTTGross4, txtTTGross5, txtTTGross6, txtTTGross7, txtTTGross8, txtTTGross9, txtTTGross10, txtTTGross11, txtTTGross12, txtTTTotalGross });
            //前年
            List<TextBox> tbTFirstGrsList = new List<TextBox>();
            tbTFirstGrsList.AddRange(new TextBox[] { txtTFGross1, txtTFGross2, txtTFGross3, txtTFGross4, txtTFGross5, txtTFGross6, txtTFGross7, txtTFGross8, txtTFGross9, txtTFGross10, txtTFGross11, txtTFGross12, txtTFTotalGross });
            //比率
            List<TextBox> tbTGrsRatioList = new List<TextBox>();
            tbTGrsRatioList.AddRange(new TextBox[] { txtTGrossRt1, txtTGrossRt2, txtTGrossRt3, txtTGrossRt4, txtTGrossRt5, txtTGrossRt6, txtTGrossRt7, txtTGrossRt8, txtTGrossRt9, txtTGrossRt10, txtTGrossRt11, txtTGrossRt12, txtTTotalGrossRt });

            #endregion [項目リストを生成]

            #region [比率の計算、値のセット]

            // 売上比
            for (int i = 0; i < tbTThisSlList.Count; i++)
            {
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応---------->>>>>
                //Double i_ttlTSales = 0;
                //Double i_ttlFSales = 0;

                //i_ttlTSales = Convert.ToDouble(tbTThisSlList[i].Value);		//当年売上
                //i_ttlFSales = Convert.ToDouble(tbTFirstSlList[i].Value);	//前年売上

                //if (i_ttlFSales != 0 && tbTFirstSlList[i].Value != null)
                //{
                //    i_ttlTSales = i_ttlTSales * 100;

                //    Double _secSalesRt = Math.Round((i_ttlTSales / i_ttlFSales), 4);			//小数点第五位を丸め

                //    _secSalesRt = Math.Round(_secSalesRt, 2, MidpointRounding.AwayFromZero);	//小数点第三位を四捨五入
                //    tbTSlRatioList[i].Value = _secSalesRt;										//比率をtextBoxに
                //}
                //else
                //{
                //    tbTSlRatioList[i].Value = 0;
                //}
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応----------<<<<<

                tbTSlRatioList[i].Value = GetRatio(tbTThisSlList[i].Value, tbTFirstSlList[i].Value); //小数点第三位を四捨五入// ADD cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
            }

            // 粗利比
            for (int i = 0; i < tbTThisGrsList.Count; i++)
            {
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応---------->>>>>
                //Double i_ttlTGross = 0;
                //Double i_ttlFGross = 0;

                //i_ttlTGross = Convert.ToDouble(tbTThisGrsList[i].Value);	//当年粗利
                //i_ttlFGross = Convert.ToDouble(tbTFirstGrsList[i].Value);	//前年粗利

                //if (i_ttlFGross != 0 && tbTFirstGrsList[i].Value != null)
                //{
                //    i_ttlTGross = i_ttlTGross * 100;

                //    Double _ttlGrossRt = Math.Round((i_ttlTGross / i_ttlFGross), 4);

                //    _ttlGrossRt = Math.Round(_ttlGrossRt, 2, MidpointRounding.AwayFromZero);	//小数点第三位を四捨五入
                //    tbTGrsRatioList[i].Value = _ttlGrossRt;										//比率をtextBoxにセット
                //}
                //else
                //{
                //    tbTGrsRatioList[i].Value = 0;
                //}
                //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の対応----------<<<<<

                tbTGrsRatioList[i].Value = GetRatio(tbTThisGrsList[i].Value, tbTFirstGrsList[i].Value); //小数点第三位を四捨五入// ADD cheq 2015/08/17 for RedMine#47029 比率算出不正の対応
            }

            #endregion [比率の計算、値のセット]

            #region [印刷タイプ（売上・粗利・売上＆粗利）の適用]

            switch (this._extraInfo.PrintType)
            {
                case 0: //売上
                    for (int i = 0; i < lbTitleTGrsList.Count; i++)
                    {
                        //粗利タイトルラベル非印字
                        lbTitleTGrsList[i].Visible = false;
                    }

                    for (int h = 0; h < tbTThisGrsList.Count; h++)
                    {
                        //粗利値textBox非印字
                        tbTThisGrsList[h].Visible = false;
                        tbTFirstGrsList[h].Visible = false;
                        tbTGrsRatioList[h].Visible = false;
                    }

                    break;

                case 1: //粗利
                    for (int i = 0; i < lbTitleTSlList.Count; i++)
                    {
                        //売上タイトルラベル非印字
                        lbTitleTSlList[i].Visible = false;
                        //粗利タイトルの位置移動
                        lbTitleTGrsList[i].Top = lbTitleTSlList[i].Top;
                    }

                    for (int h = 0; h < tbTThisGrsList.Count; h++)
                    {
                        //売上値textBox非印字
                        tbTThisSlList[h].Visible = false;
                        tbTFirstSlList[h].Visible = false;
                        tbTSlRatioList[h].Visible = false;

                        //粗利値textBoxの位置移動
                        tbTThisGrsList[h].Top = tbTThisSlList[h].Top;
                        tbTFirstGrsList[h].Top = tbTFirstSlList[h].Top;
                        tbTGrsRatioList[h].Top = tbTSlRatioList[h].Top;

                    }
                    break;
            }

            #endregion [印刷タイプ（売上・粗利・売上＆粗利）の適用]
        }

        #endregion 総合計に対するイベント：終

        //---ADD cheq 2015/08/17 RedMine#47029 比率算出不正の対応---------->>>>>
        /// <summary>
        /// 率算出
        /// </summary>
        /// <param name="thisVal"></param>
        /// <param name="firstVal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 比率を算出する。</br>
        /// <br>Programmer : cheq</br>
        /// <br>Date       : 2015/08/17</br>
        /// </remarks>
        private Double GetRatio(object thisVal, object firstVal)
        {
            Double rtnval = 0;

            if (thisVal == null || firstVal == null)
            {
                return rtnval;
            }

            decimal d_ThisVal = Convert.ToDecimal(thisVal);
            decimal d_FirstVal = Convert.ToDecimal(firstVal);

            if (d_FirstVal == 0)
            {
                return rtnval;
            }

            decimal totalSalesRatio = d_ThisVal * 100 / d_FirstVal;
            decimal d_rtnval = Math.Round(totalSalesRatio, 2, MidpointRounding.AwayFromZero);//小数点第三位を四捨五入
            rtnval = Convert.ToDouble(d_rtnval);

            return rtnval;
        }
        //---ADD cheq 2015/08/17 RedMine#47029 比率算出不正の対応----------<<<<<

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            // ---ADD 2009/01/30 不具合対応[9841] ----------------------------------------->>>>>
            if (string.IsNullOrEmpty(this.txtTHName1.Text))
            {
                this.txtTHName1.Text = "";
            }
            if (string.IsNullOrEmpty(this.txtTHCode1.Text))
            {
                this.txtTHCode1.Text = "";
            }
            // ---ADD 2009/01/30 不具合対応[9841] -----------------------------------------<<<<<

            if (this.txtTHName1.Text != "全社集計" &&
                this.txtTHCode1.Text.Replace('0', ' ').Trim().Equals(string.Empty))
            {
                this.txtTHCode1.Text = "";
            }

            if (this.ChangeDF_Code1.Visible)
            {
                if (this.ChangeDF_Code1.Text != null &&
                    this.ChangeDF_Code1.Text.Replace('0', ' ').Trim().Equals(string.Empty))
                {
                    this.ChangeDF_Code1.Text = "";
                }
            }
            
        }

        // ADD 2009/04/16 ------>>>
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // 売上当年の円単位計算
            List<TextBox> tsList = new List<TextBox>();
            tsList.AddRange(new TextBox[] { txtTTermSales1, txtTTermSales2, txtTTermSales3, txtTTermSales4, txtTTermSales5, txtTTermSales6,
                                            txtTTermSales7, txtTTermSales8, txtTTermSales9, txtTTermSales10, txtTTermSales11, txtTTermSales12, txtTTermTotalSales });
            PriceUnitCalc(tsList);
            // 売上前年の円単位計算
            List<TextBox> fsList = new List<TextBox>();
            fsList.AddRange(new TextBox[] { txtFTermSales1, txtFTermSales2, txtFTermSales3, txtFTermSales4, txtFTermSales5, txtFTermSales6,
                                            txtFTermSales7, txtFTermSales8, txtFTermSales9, txtFTermSales10, txtFTermSales11, txtFTermSales12, txtFTermTotalSales });
            PriceUnitCalc(fsList);
            // 粗利当年の円単位計算
            List<TextBox> tgList = new List<TextBox>();
            tgList.AddRange(new TextBox[] { txtTTermGross1, txtTTermGross2, txtTTermGross3, txtTTermGross4, txtTTermGross5, txtTTermGross6,
                                            txtTTermGross7, txtTTermGross8, txtTTermGross9, txtTTermGross10, txtTTermGross11, txtTTermGross12, txtTTermTotalGross });
            PriceUnitCalc(tgList);
            // 粗利前年の円単位計算
            List<TextBox> fgList = new List<TextBox>();
            fgList.AddRange(new TextBox[] { txtFTermGross1, txtFTermGross2, txtFTermGross3, txtFTermGross4, txtFTermGross5, txtFTermGross6,
                                            txtFTermGross7, txtFTermGross8, txtFTermGross9, txtFTermGross10, txtFTermGross11, txtFTermGross12, txtFTermTotalGross });
            PriceUnitCalc(fgList);
        }

        /// <summary>
        /// SubSectionFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void SubSectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 売上当年の円単位計算
            List<TextBox> tsList = new List<TextBox>();
            tsList.AddRange(new TextBox[] { txtSubSecTSales1, txtSubSecTSales2, txtSubSecTSales3, txtSubSecTSales4, txtSubSecTSales5, txtSubSecTSales6,
                                            txtSubSecTSales7, txtSubSecTSales8, txtSubSecTSales9, txtSubSecTSales10, txtSubSecTSales11, txtSubSecTSales12, txtSubSecTTotalSales });
            PriceUnitCalc(tsList);
            // 売上前年の円単位計算
            List<TextBox> fsList = new List<TextBox>();
            fsList.AddRange(new TextBox[] { txtSubSecFSales1, txtSubSecFSales2, txtSubSecFSales3, txtSubSecFSales4, txtSubSecFSales5, txtSubSecFSales6,
                                            txtSubSecFSales7, txtSubSecFSales8, txtSubSecFSales9, txtSubSecFSales10, txtSubSecFSales11, txtSubSecFSales12, txtSubSecFTotalSales });
            PriceUnitCalc(fsList);
            // 粗利当年の円単位計算
            List<TextBox> tgList = new List<TextBox>();
            tgList.AddRange(new TextBox[] { txtSubSecTGross1, txtSubSecTGross2, txtSubSecTGross3, txtSubSecTGross4, txtSubSecTGross5, txtSubSecTGross6,
                                            txtSubSecTGross7, txtSubSecTGross8, txtSubSecTGross9, txtSubSecTGross10, txtSubSecTGross11, txtSubSecTGross12, txtSubSecTTotalGross });
            PriceUnitCalc(tgList);
            // 粗利前年の円単位計算
            List<TextBox> fgList = new List<TextBox>();
            fgList.AddRange(new TextBox[] { txtSubSecFGross1, txtSubSecFGross2, txtSubSecFGross3, txtSubSecFGross4, txtSubSecFGross5, txtSubSecFGross6,
                                            txtSubSecFGross7, txtSubSecFGross8, txtSubSecFGross9, txtSubSecFGross10, txtSubSecFGross11, txtSubSecFGross12, txtSubSecFTotalGross });
            PriceUnitCalc(fgList);
        }

        /// <summary>
        /// SectionFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 売上当年の円単位計算
            List<TextBox> tsList = new List<TextBox>();
            tsList.AddRange(new TextBox[] { txtSecTSales1, txtSecTSales2, txtSecTSales3, txtSecTSales4, txtSecTSales5, txtSecTSales6,
                                            txtSecTSales7, txtSecTSales8, txtSecTSales9, txtSecTSales10, txtSecTSales11, txtSecTSales12, txtSecTTotalSales });
            PriceUnitCalc(tsList);
            // 売上前年の円単位計算
            List<TextBox> fsList = new List<TextBox>();
            fsList.AddRange(new TextBox[] { txtSecFSales1, txtSecFSales2, txtSecFSales3, txtSecFSales4, txtSecFSales5, txtSecFSales6,
                                            txtSecFSales7, txtSecFSales8, txtSecFSales9, txtSecFSales10, txtSecFSales11, txtSecFSales12, txtSecFTotalSales });
            PriceUnitCalc(fsList);
            // 粗利当年の円単位計算
            List<TextBox> tgList = new List<TextBox>();
            tgList.AddRange(new TextBox[] { txtSecTGross1, txtSecTGross2, txtSecTGross3, txtSecTGross4, txtSecTGross5, txtSecTGross6,
                                            txtSecTGross7, txtSecTGross8, txtSecTGross9, txtSecTGross10, txtSecTGross11, txtSecTGross12, txtSecTTotalGross });
            PriceUnitCalc(tgList);
            // 粗利前年の円単位計算
            List<TextBox> fgList = new List<TextBox>();
            fgList.AddRange(new TextBox[] { txtSecFGross1, txtSecFGross2, txtSecFGross3, txtSecFGross4, txtSecFGross5, txtSecFGross6,
                                            txtSecFGross7, txtSecFGross8, txtSecFGross9, txtSecFGross10, txtSecFGross11, txtSecFGross12, txtSecFTotalGross });
            PriceUnitCalc(fgList);
        }

        /// <summary>
        /// TitleFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void TitleFooter_BeforePrint(object sender, EventArgs e)
        {
            // 売上当年の円単位計算
            List<TextBox> tsList = new List<TextBox>();
            tsList.AddRange(new TextBox[] { txtTTSales1, txtTTSales2, txtTTSales3, txtTTSales4, txtTTSales5, txtTTSales6,
                                            txtTTSales7, txtTTSales8, txtTTSales9, txtTTSales10, txtTTSales11, txtTTSales12, txtTTTotalSales });
            PriceUnitCalc(tsList);
            // 売上前年の円単位計算
            List<TextBox> fsList = new List<TextBox>();
            fsList.AddRange(new TextBox[] { txtTFSales1, txtTFSales2, txtTFSales3, txtTFSales4, txtTFSales5, txtTFSales6,
                                            txtTFSales7, txtTFSales8, txtTFSales9, txtTFSales10, txtTFSales11, txtTFSales12, txtTFTotalSales });
            PriceUnitCalc(fsList);
            // 粗利当年の円単位計算
            List<TextBox> tgList = new List<TextBox>();
            tgList.AddRange(new TextBox[] { txtTTGross1, txtTTGross2, txtTTGross3, txtTTGross4, txtTTGross5, txtTTGross6,
                                            txtTTGross7, txtTTGross8, txtTTGross9, txtTTGross10, txtTTGross11, txtTTGross12, txtTTTotalGross });
            PriceUnitCalc(tgList);
            // 粗利前年の円単位計算
            List<TextBox> fgList = new List<TextBox>();
            fgList.AddRange(new TextBox[] { txtTFGross1, txtTFGross2, txtTFGross3, txtTFGross4, txtTFGross5, txtTFGross6,
                                            txtTFGross7, txtTFGross8, txtTFGross9, txtTFGross10, txtTFGross11, txtTFGross12, txtTFTotalGross });
            PriceUnitCalc(fgList);
        }
        
        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._extraInfo.MoneyUnit == 1)
            {
                int priceUnit = 1000;

                for (int index = 0; index < calcList.Count; index++)
                {
                    if (!calcList[index].Visible)
                    {
                        continue;
                    }

                    decimal unitCalc = 0;
                    if (calcList[index].Value is long)
                    {
                        unitCalc = (decimal)((long)calcList[index].Value / (decimal)priceUnit);
                    }
                    else if (calcList[index].Value is double)
                    {
                        unitCalc = (decimal)((double)calcList[index].Value / (double)priceUnit);
                    }
                    else
                    {
                        continue;
                    }
                    calcList[index].Value = unitCalc;
                }
            }
        }
        // ADD 2009/04/16 ------<<<

        #endregion	private methods

    }

}
