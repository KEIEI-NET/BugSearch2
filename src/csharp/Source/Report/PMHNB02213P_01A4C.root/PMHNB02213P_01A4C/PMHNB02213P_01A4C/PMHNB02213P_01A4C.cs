//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   返品理由一覧表 テンプレートクラス               //
//                  :   PMHNB02213P_01A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   呉元嘯                                          //
// Date             :   2009.05.11                                      //
//----------------------------------------------------------------------//
// Update Note      :   2013/01/25 cheq                                 //
// 管理番号  		:	10806793-00 2013/03/13配信分                    //
//                      Redmine#34098 罫線印字制御の追加対応            //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using System.Collections.Specialized;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 返品理由一覧表テンプレートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 返品理由一覧表テンプレートクラス。</br>
    /// <br>Programmer	: 呉元嘯</br>
    /// <br>Date		: 2009.05.11</br>
    /// <br>Update Note : 2013/01/25 cheq</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>              Redmine#34098 罫線印字制御の追加対応</br>
    /// <br></br>
    /// </remarks>
    public partial class PMHNB02213P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 返品理由一覧表テンプレートクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 返品理由一覧表テンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        public PMHNB02213P_01A4C()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        // 印刷件数用カウンタ
        private int _printCount;
        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;
        // 抽出条件	
        private StringCollection _extraConditions;
        // フッター出力区分	
        private int _pageFooterOutCode;
        // フッターメッセージ	
        private StringCollection _pageFooters;
        // 印刷情報クラス			
        private SFCMN06002C _printInfo;
        // ソート順			
        private string _pageHeaderSortOderTitle;
        // 抽出条件クラス
        private HenbiRiyuListReport _henbiRiyuListReport;
        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        #endregion ■ Private Member

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property
        /// <summary> ページヘッダソート順タイトル項目</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>ページヘッダソート順タイトル項目セットプロパティ </remarks> 
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]セットプロパティ </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary> 抽出条件ヘッダー項目</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>抽出条件ヘッダー項目セットプロパティ </remarks> 
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary> フッター出力区分</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>フッター出力区分セットプロパティ </remarks> 
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary> フッタ出力文</summary>
        /// <value>PageFooters</value>               
        /// <remarks>フッタ出力文セットプロパティ </remarks> 
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._henbiRiyuListReport = (HenbiRiyuListReport)this._printInfo.jyoken;
            }
        }

        /// <summary>その他データ</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>その他データセットプロパティ </remarks> 
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }

        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■IPrintActiveReportTypeCommon メンバ
        /// <summary>プログレスバーカウントアップイベント</summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        /// <remarks>背景透かしモードセット又は取得プロパティ </remarks> 
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }
        #endregion ■IPrintActiveReportTypeCommon メンバ

        #region ■ Private Method
        #region ◆ レポート要素出力設定
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
        /// <br>Update Note : 2013/01/25 cheq</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>              Redmine#34098 罫線印字制御の追加対応</br> 
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = GetReportTitle(this._henbiRiyuListReport.PrintType);

            #region [位置調整用]
            switch(this._henbiRiyuListReport.PrintType)
            {
                case (0): // 返品理由
                    { 
                        this.Lb_DetailCode.Visible = false;
                        this.Lb_DetailName.Visible = false;
                        this.DetailCode.Visible = false;
                        this.DetailNm.Visible = false;

                        // 位置調整用
                        this.Lb_RetGoodsReasonDiv.Top = 0F;
                        this.Lb_RetGoodsReasonDiv.Left = 0.063F;
                        this.Lb_RetGoodsReason.Top = 0F;
                        this.Lb_RetGoodsReason.Left = 0.63F;
                        this.Lb_SlipKind.Top = 0F;
                        this.Lb_SlipKind.Left = 4.19F;
                        this.Lb_SalesCount.Top = 0F;
                        this.Lb_SalesCount.Left = 4.51F;
                        this.Lb_Money.Top = 0F;
                        this.Lb_Money.Left = 5.2F;
                        this.Lb_Rate.Top = 0F;
                        this.Lb_Rate.Left = 6.15F;

                        this.RetGoodsReasonDiv.Top = 0F;
                        this.RetGoodsReasonDiv.Left = 0.063F;
                        this.RetGoodsReason.Top = 0F;
                        this.RetGoodsReason.Left = 0.63F;
                        this.SlipKind.Top = 0F;
                        this.SlipKind.Left = 4.19F;
                        this.Count.Top = 0F;
                        this.Count.Left = 4.51F;
                        this.MoneySum.Top = 0F;
                        this.MoneySum.Left = 5.2F;
                        this.Rate.Top = 0F;
                        this.Rate.Left = 6.2F;
                        this.Percent.Top = 0F;
                        this.Percent.Left = 6.638F;

                        this.Sec_Title.Top = 0F;
                        this.Sec_Title.Left = 3.00F;
                        this.SecFt_Count.Top = 0F;
                        this.SecFt_Count.Left = 4.51F;
                        this.SecFt_MoneySum.Top = 0F;
                        this.SecFt_MoneySum.Left = 5.2F;
                        this.SecFt_Rate.Top = 0F;
                        this.SecFt_Rate.Left = 6.2F;
                        this.SecFt_Percent.Top = 0F;
                        this.SecFt_Percent.Left = 6.638F;

                        this.Ttl_Title.Top = 0F;
                        this.Ttl_Title.Left = 3.00F;
                        this.Ttl_Count.Top = 0F;
                        this.Ttl_Count.Left = 4.51F;
                        this.Ttl_MoneySum.Top = 0F;
                        this.Ttl_MoneySum.Left = 5.2F;

                        // 返品理由
                        this.SectionHeader.Visible = true;
                        this.SectionFooter.Visible = true;
                    }
                    break;
                case (1):// 得意先
                    {
                        this.Lb_DetailCode.Text = "得意先";

                        //改頁は拠点の場合
                        if (0 == this._henbiRiyuListReport.ChangePageDiv || 2 == this._henbiRiyuListReport.ChangePageDiv)
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                            this.CustomerCodeFooter.Visible = true;
                        }
                        // 改頁は[小計]と[しない]の場合
                        if (1 == this._henbiRiyuListReport.ChangePageDiv)
                        {
                            // 得意先
                            this.CustomerCodeHeader.Visible = true;
                            this.CustomerCodeFooter.Visible = true;
                        }

                    }
                    break;
                case (2):// 担当者
                    {
                        this.Lb_DetailCode.Text = "担当者";

                        // 改頁は拠点の場合
                        if (0 == this._henbiRiyuListReport.ChangePageDiv || 2 == this._henbiRiyuListReport.ChangePageDiv)
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                            this.SalesEmployeeCdFooter.Visible = true;
                        }
                        // 改頁は[小計]と[しない]の場合
                        if (1 == this._henbiRiyuListReport.ChangePageDiv )
                        {
                            // 担当者
                            this.SalesEmployeeCdHeader.Visible = true;
                            this.SalesEmployeeCdFooter.Visible = true;

                        }

                    }
                    break;
                case (3):// 受注者
                    {
                        this.Lb_DetailCode.Text = "受注者";

                        //改頁は拠点の場合
                        if (0 == this._henbiRiyuListReport.ChangePageDiv || 2 == this._henbiRiyuListReport.ChangePageDiv)
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                            this.FrontEmployeeCdFooter.Visible = true;
                        }
                        // 改頁は[小計]と[しない]の場合
                        if (1 == this._henbiRiyuListReport.ChangePageDiv )
                        {
                            // 受注者
                            this.FrontEmployeeCdHeader.Visible = true;
                            this.FrontEmployeeCdFooter.Visible = true;

                        }

                    }
                    break;
                case (4):// 発行者
                    {
                        this.Lb_DetailCode.Text = "発行者";

                        //改頁は拠点の場合
                        if (0 == this._henbiRiyuListReport.ChangePageDiv || 2 == this._henbiRiyuListReport.ChangePageDiv)
                        {
                            this.SectionHeader.Visible = true;
                            this.SectionFooter.Visible = true;
                            this.SalesInputCodeFooter.Visible = true;
                        }
                        // 改頁は[小計]と[しない]の場合
                        if (1 == this._henbiRiyuListReport.ChangePageDiv )
                        {
                            // 発行者
                            this.SalesInputCodeHeader.Visible = true;
                            this.SalesInputCodeFooter.Visible = true;

                        }
                    }
                    break;

            }
            //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
            //罫線印字『印字する』の場合
            if (_henbiRiyuListReport.LinePrintDiv == 0)
            {
                this.line3.Visible = true;
                this.line5.Visible = true;
                this.line6.Visible = true;
                this.line7.Visible = true;
                this.line8.Visible = true;
                this.line4.Visible = true;
                this.line9.Visible = true;
                this.line10.Visible = true;
                this.line11.Visible = true;
                this.line12.Visible = true;
                this.line13.Visible = true;
                this.line14.Visible = true;
            }
            //罫線印字『印字しない』の場合
            else
            {
                this.line3.Visible = false;
                this.line5.Visible = false;
                this.line6.Visible = false;
                this.line7.Visible = false;
                this.line8.Visible = false;
                this.line4.Visible = false;
                this.line9.Visible = false;
                this.line10.Visible = false;
                this.line11.Visible = false;
                this.line12.Visible = false;
                this.line13.Visible = false;
                this.line14.Visible = false;
            }
            //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<
            #endregion

            #region [改ページ設定適用]
            this.CustomerCodeHeader.NewPage = NewPage.None;
            this.SalesEmployeeCdHeader.NewPage = NewPage.None;
            this.FrontEmployeeCdHeader.NewPage = NewPage.None;
            this.SalesInputCodeHeader.NewPage = NewPage.None;
            this.SectionHeader.NewPage = NewPage.None;
            // 改頁：拠点
            if (0 == this._henbiRiyuListReport.ChangePageDiv)
            {
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            // 改頁：小計(返品理由)
            else if (1 == this._henbiRiyuListReport.ChangePageDiv && 0 == this._henbiRiyuListReport.PrintType)
            {
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            // 改頁：小計(得意先)
            else if (1 == this._henbiRiyuListReport.ChangePageDiv && 1 == this._henbiRiyuListReport.PrintType)
            {
                this.CustomerCodeHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.CustomerCodeHeader.NewPage = NewPage.Before;
            }
            // 改頁：小計(担当者)
            else if (1 == this._henbiRiyuListReport.ChangePageDiv && 2 == this._henbiRiyuListReport.PrintType)
            {
                this.SalesEmployeeCdHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.SalesEmployeeCdHeader.NewPage = NewPage.Before;           
            }
            // 改頁：小計(受注者)
            else if (1 == this._henbiRiyuListReport.ChangePageDiv && 3 == this._henbiRiyuListReport.PrintType)
            {
                this.FrontEmployeeCdHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.FrontEmployeeCdHeader.NewPage = NewPage.Before;
            }
            // 改頁：小計(発行者)
            else if (1 == this._henbiRiyuListReport.ChangePageDiv && 4 == this._henbiRiyuListReport.PrintType)
            {
                this.SalesInputCodeHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.SalesInputCodeHeader.NewPage = NewPage.Before;
            }
            #endregion [改ページ設定適用]          

        }
        /// <summary>
        /// 項目の名称設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 項目の名称をセット</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
        /// <br></br>
        /// </remarks>
        private String GetReportTitle(int printType)
            {
                string printName = string.Empty;
                switch (printType)
                {
                    case (0): //返品理由
                        {
                            printName = "  返品理由一覧表";　　
                        }
                        break;
                    case (1)://得意先
                        {
                            printName = "  返品理由一覧表(得意先捌)";
                        }
                        break;
                    case (2)://担当者
                        {
                            printName = "  返品理由一覧表(担当者捌)";　　
                        }
                        break;
                    case (3)://受注者
                        {
                            printName = "  返品理由一覧表(受注者捌)";
                        }
                        break;
                    case (4)://発行者
                        {
                            printName = "  返品理由一覧表(発行者捌)";
                        }
                        break;
                }
                return printName;
     
            }
        #endregion ◆ レポート要素出力設定
        #endregion

        #region ■ Control Event

        #region ◎ PMHNB02213P_01A4C_ReportStart Event
        /// <summary>
        /// PMHNB02213P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void PMHNB02213P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // 作成日付
            DateTime now = DateTime.Now;
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.tb_PrintTime.Text = TDateTime.DateTimeToString("HH:MM", now);
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
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
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

        #region ◎ Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 呉元嘯</br>
        /// <br>Date		: 2009.05.11</br>
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

        #region ◆ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 呉元嘯</br>                                   
        /// <br>Date        : 2009.05.06</br>                                       
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion ◆ Detail_BeforePrint Event
     #endregion ■ Control Event

       
    }
}
