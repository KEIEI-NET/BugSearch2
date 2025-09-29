//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   未入金一覧表 テンプレートクラス                   //
//                  :   PMKAU02003P_01A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   22018 鈴木正臣                                            //
// Date             :   2010/07/01                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 作 成 日  2010/12/20  修正内容 : 印字項目「ソート順」の内容を変更する
//----------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.                 //
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
using System.Data;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 未入金一覧表テンプレートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 未入金一覧表テンプレートクラス。</br>
    /// <br>Programmer  : 22018 鈴木正臣</br>
    /// <br>Date        : 2010/07/01</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKAU02003P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 未入金一覧表テンプレートクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 未入金一覧表テンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public PMKAU02003P_01A4C()
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
        private NoDepSalListCdtn _tegataConfirmReport;
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
                this._tegataConfirmReport = (NoDepSalListCdtn)this._printInfo.jyoken;
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
        /// <br>Note        : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
        /// <br>Update Note : 2010/12/20 liyp</br>
        /// <br>             印字項目「ソート順」の内容を変更する</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // -----------ADD 2010/12/20 --------------->>>>>
            if (_tegataConfirmReport.TargetDateDiv == 0)
            {
                Lb_SortOrder.Text = "売上日-伝票番号 順";
            }
            else
            {
                Lb_SortOrder.Text = "入力日-伝票番号 順";
            }
            // -----------ADD 2010/12/20 ---------------<<<<<
            // 印字設定 --------------------------------------------------------------------------------------
        }
        #endregion ◆ レポート要素出力設定
        #endregion

        #region ■ Control Event

        #region ◎ PMKAU02003P_01A4C_ReportStart Event
        /// <summary>
        /// PMKAU02003P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
        /// </remarks>
        private void PMKAU02003P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Note        : セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
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
        /// <br>Note        : ExtraHeaderグループのフォーマットイベント。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
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
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // 印刷件数カウントアップ
            this._printCount++;

# if DEBUG
# else
            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
# endif
        }
        #endregion

        #region ◆ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画される前に発生します。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion ◆ Detail_BeforePrint Event
        #endregion ■ Control Event

        /// <summary>
        /// TitleHeader_Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : タイトルヘッダセクションのフォーマットイベントです。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
        /// </remarks>
        private void TitleHeader_Format(object sender, System.EventArgs eArgs)
        {
        }

        /// <summary>
        /// Detail_Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : 明細セクションのフォーマットイベントです。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2010/07/01</br>
        /// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
        }

    }
}
