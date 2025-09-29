//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   当月車検車両一覧表 テンプレートクラス           //
//                  :   PMSYA02103P_01A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   薛祺                                            //
// Date             :   2010.04.21                                      //
//----------------------------------------------------------------------//
// Update Note      : 2010/05/08 王海立 redmine #7156の対応             //
//                  :                   車種と得意先コードの帳票の印字  //
// Update Note      : 2010.05.18 zhangsf Redmine #7784の対応            //
//                  : ・帳票レイアウト修正                              //
// Update Note      : 2013.04.11 FSI斎藤 和宏 10900269-00               //
//                  :                   SPK車台番号文字列対応           //
//                  : ・車台No.にVINコードとして17桁表示にする対応      //
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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 当月車検車両一覧表テンプレートクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 当月車検車両一覧表テンプレートクラス。</br>
    /// <br>Programmer	: 薛祺</br>
    /// <br>Date		: 2010.04.21</br>
    /// <br></br>
    /// </remarks>
    public partial class PMSYA02103P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 当月車検車両一覧表テンプレートクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 当月車検車両一覧表テンプレートクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        public PMSYA02103P_01A4C()
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
        private MonthCarInspectListPara _monthCarInspectListPara;
        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // 背景透かしモード(無し)
        private int _watermarkMode = 0;
        // 車検日-得意先
        private string _isptDateCstCode = string.Empty;
        // 改頁 = べた打ちの場合、一つページは30件は表示します。
        private int pageRow1 = 30;
        // 改頁 = 1行空行の場合、一つページは15件は表示します。
        private int pageRow2 = 15;
        // 行のインデックス
        private int _pageRowNum = 0;


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
                this._monthCarInspectListPara = (MonthCarInspectListPara)this._printInfo.jyoken;
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
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------
            #region [位置調整用]
            // 改頁 = 1行空行の場合
            if ((int)this._monthCarInspectListPara.ChangeRowDiv == 1)
            {
                this.Detail.Height = this.Detail.Height * 2;
                //line6.Y1 = line6.Y1 + this.CustomerCodeFooter.Height;// DEL 2010.05.18 zhangsf FOR Redmine #7784
                //line6.Y2 = line6.Y2 + this.CustomerCodeFooter.Height;// DEL 2010.05.18 zhangsf FOR Redmine #7784
                this.CustomerCodeFooter.Height = this.CustomerCodeFooter.Height * 2;
            }
            // ソート順
            this.SortTitle.Text = _pageHeaderSortOderTitle;
            #endregion

            #region [改ページ設定適用]
            this.CustomerCodeHeader.NewPage = NewPage.None;
            // 改頁：小計(得意先)
            if ((int)this._monthCarInspectListPara.ChangePageDiv == 1)
            {
                this.CustomerCodeHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
                this.CustomerCodeHeader.NewPage = NewPage.Before;
            }
            #endregion [改ページ設定適用]          

        }
        #endregion ◆ レポート要素出力設定
        #endregion

        #region ■ Control Event

        #region ◎ PMSYA02103P_01A4C_ReportStart Event
        /// <summary>
        /// PMSYA02103P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private void PMSYA02103P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
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
        /// <br>Programmer  : 薛祺</br>                                   
        /// <br>Date        : 2010.04.21</br>                                       
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {   
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion ◆ Detail_BeforePrint Event

        #region ◎ Detail_Format Event
        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Detailグループのフォーマットイベント。</br>
        /// <br>Programmer	: 薛祺</br>
        /// <br>Date		: 2010.04.21</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            string isptDateCstCodeTemp = this.InspectMaturityDate.Value.ToString() + this.CustomerCode.Value.ToString();

            // 改頁 = しないの場合
            if ((int)this._monthCarInspectListPara.ChangePageDiv == 0)
            {
                // 車検日、得意先の表示処理
                // 行のインデックス + 1
                _pageRowNum++;
                // GROUP印刷フラグ
                Boolean groupPrintFlg = false;
                if (this._isptDateCstCode == isptDateCstCodeTemp)
                {
                    this.InspectMaturityDate.Visible = false;
                    this.CustomerCode.Visible = false;
                    this.CustomerSnm.Visible = false;

                }
                else
                {
                    if (!string.IsNullOrEmpty(this._isptDateCstCode))
                    {
                        groupPrintFlg = true;
                    }
                    this.InspectMaturityDate.Visible = true;
                    this.CustomerCode.Visible = true;
                    this.CustomerSnm.Visible = true;
                    this._isptDateCstCode = isptDateCstCodeTemp;

                }

                // 一つページは30件は表示します。
                int pageRow = pageRow1;
                if ((int)this._monthCarInspectListPara.ChangeRowDiv == 1)
                {
                    // 改頁 = 1行空行の場合、一つページは15件は表示します。
                    pageRow = pageRow2;
                }
                // 改ページの場合、車検日と得意先を表示します。
                if ((_pageRowNum % pageRow) == 1)
                {
                    this.InspectMaturityDate.Visible = true;
                    this.CustomerCode.Visible = true;
                    this.CustomerSnm.Visible = true;
                }
                if (groupPrintFlg)
                {
                    // 得意先計の場合、行のインデックス + 1
                    _pageRowNum++;
                }
            }
            else
            {
                // 改頁 = 小計(得意先)
                // 車検日、得意先の表示処理
                if (this._isptDateCstCode == isptDateCstCodeTemp)
                {
                    this.InspectMaturityDate.Visible = false;
                    this.CustomerCode.Visible = false;
                    this.CustomerSnm.Visible = false;
                    // 行のインデックス + 1
                    _pageRowNum++;
                }
                else
                {
                    _pageRowNum = 1;
                    this.InspectMaturityDate.Visible = true;
                    this.CustomerCode.Visible = true;
                    this.CustomerSnm.Visible = true;
                    this._isptDateCstCode = isptDateCstCodeTemp;
                }

                // 一つページは30件は表示します。
                int pageRow = pageRow1;
                if ((int)this._monthCarInspectListPara.ChangeRowDiv == 1)
                {
                    // 改頁 = 1行空行の場合、一つページは15件は表示します。
                    pageRow = pageRow2;
                }
                // 改ページの場合、車検日と得意先を表示します。
                if ((_pageRowNum % pageRow) == 1)
                {
                    this.InspectMaturityDate.Visible = true;
                    this.CustomerCode.Visible = true;
                    this.CustomerSnm.Visible = true;
                }
            }
        }
        #endregion

    #endregion ■ Control Event
    }
}
