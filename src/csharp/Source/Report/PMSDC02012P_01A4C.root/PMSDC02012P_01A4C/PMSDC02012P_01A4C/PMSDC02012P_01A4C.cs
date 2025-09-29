//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 田建委
// 作 成 日  2019/12/02      修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Drawing.Printing;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSDC02012P_01A4C帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2019/12/02</br>
    /// </remarks> 
    public partial class PMSDC02012P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■Constructor
        /// <summary>
        /// SE売上データテキスト印刷帳票ActiveReportクラス
        /// </summary>
        /// <remarks>
        /// <br>Note        : SE売上データテキスト印刷帳票ActiveReportクラスのインスタンスの作成を行う。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        public PMSDC02012P_01A4C()
        {
            //
            // ActiveReport デザイナ サポートに必要です。
            //
            InitializeComponent();
        }
        #endregion　■Constructor

        #region  ■Private Members
        private int _printCount;						// 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;		// 抽出条件
        private int _pageFooterOutCode;				    // フッター出力区分
        private StringCollection _pageFooters;			// フッターメッセージ
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        // ヘッダーサブレポート作成
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        // ライン５表示フラグ
        private bool _isLine5ShowFlg = true;
        // ライン７表示フラグ
        private bool _isLine7ShowFlg = true; 
        #endregion　■Private Members

        #region ■ IPrintActiveReportTypeList メンバ
        #region ◆ Public Property

        /// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]セットプロパティ </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary> 抽出条件ヘッダー項目</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>抽出条件ヘッダー項目セットプロパティ </remarks> 
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary>その他データ</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>その他データセットプロパティ </remarks> 
        public ArrayList OtherDataList
        {
            set
            {
            }
        }

        /// <summary> フッター出力区分</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>フッター出力区分セットプロパティ </remarks> 
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary> フッタ出力文</summary>
        /// <value>PageFooters</value>               
        /// <remarks>フッタ出力文セットプロパティ </remarks> 
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary> ページヘッダソート順タイトル項目</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>ページヘッダソート順タイトル項目セットプロパティ </remarks> 
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary>サブヘッダタイトル</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>サブヘッダタイトルセットプロパティ </remarks> 
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
        }

        /// <summary>印刷条件</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>印刷条件セットプロパティ </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
            }
        }

        /// <summary>プログレスバーカウントアップイベント
        /// <value>ProgressBarUpEventHandler</value>               
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region ■ IPrintActiveReportTypeCommon メンバ
        #region ◆ Public Property
        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            set { }
            get { return 0; }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ◆ PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>                                       
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs e)
        {
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            // 作成日付
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);

            if (this._extraConditions.Count == 0)
            {
                this.PageHeader.Height = float.Parse("0.25");
            }
            else
            {
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

                this.Extra_SubReport.Report = _rptExtraHeader;

            }
        }
        #endregion　◆ PageHeader_Format Event

        #region ◎ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion

        #region ◎ Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される後発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
            if ((this._printCount % 34) != 0)
            {
                _isLine5ShowFlg = true;
            }
        }
        #endregion

        #region ◎ PMSDC02012P_01A4C_ReportStart Event
        /// <summary>
        /// PMSDC02012P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void PMSDC02012P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void PageFooter_Format(object sender, EventArgs e)
        {
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

        #region ■ Private Method
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            //tb_ReportTitle.Text = this._pageHeaderTitle;				// サブタイトル
        }

        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void PageFooter_Format_1(object sender, EventArgs e)
        {
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

        #region ◎ SectionCodeHeader_Format Event
        /// <summary>
        /// SectionCodeHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される時に発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void SectionCodeHeader_Format(object sender, EventArgs e)
        {
            _isLine5ShowFlg = false;            
        }
        #endregion

        #region ◎ SectionCodeFooter_BeforePrint Event
        /// <summary>
        /// SectionCodeFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void SectionCodeFooter_BeforePrint(object sender, EventArgs e)
        {
            if (_isLine5ShowFlg)
            {
                line5.Visible = true;
            }
            else
            {
                line5.Visible = false;
            }             
        }
        #endregion

        #region ◎ TitleHeader_Format Event
        /// <summary>
        /// TitleHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される時に発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            _isLine7ShowFlg = false;
        }
        #endregion

        #region ◎ SectionCodeHeader_AfterPrint Event
        /// <summary>
        /// SectionCodeHeader_AfterPrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される後に発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>      
        /// </remarks>
        private void SectionCodeHeader_AfterPrint(object sender, EventArgs e)
        {
            _isLine7ShowFlg = true;
        }
        #endregion

        #region ◎ GrandFooter_BeforePrint Event
        /// <summary>
        /// GrandFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer  : 田建委</br>                                   
        /// <br>Date        : 2019/12/02</br>         
        /// </remarks>
        private void GrandFooter_BeforePrint(object sender, EventArgs e)
        {
            if (_isLine7ShowFlg)
            {
                line7.Visible = true;
            }
            else
            {
                line7.Visible = false;
            }
        }
        #endregion

    }
}
