//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// キャンペーン目標設定マスタ（印刷）フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : キャンペーン目標設定マスタ（印刷）のフォームクラスです。</br>
    /// <br>Programmer   : 楊明俊</br>
    /// <br>Date         : 2011/04/25</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN08713P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
		/// <summary>
        /// キャンペーン目標設定マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : キャンペーン目標設定マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 楊明俊</br>
        /// <br>Date         : 2011/04/25</br>
		/// </remarks>
        public PMKHN08713P_01A4C()
		{
            //
            // ActiveReport デザイナ サポートに必要です。
            //
			InitializeComponent();
		}
		#endregion ■ Constructor

        #region ■ Private Member
        private int _printCount;									          // 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			                          // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;				              // 抽出条件
        private int _pageFooterOutCode;				                          // フッター出力区分
        private StringCollection _pageFooters;					              // フッターメッセージ
        private SFCMN06002C _printInfo;						                  // 印刷情報クラス
        private string _pageHeaderTitle;				                      // フォームタイトル
        private string _pageHeaderSortOderTitle;		                      // ソート順

        private CampaignTargetPrintWork _campaignTargetPrintWork;             // 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        # endregion

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
                this._campaignTargetPrintWork = (CampaignTargetPrintWork)this._printInfo.jyoken;
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
        /// <br>Programmer   : 楊明俊</br>
        /// <br>Date         : 2011/04/25</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle; // サブタイトル

            #region サブ名称設定
            switch ((int)this._campaignTargetPrintWork.PrintType)
            {
                case 0: //拠点 
                    this.label_PrintType.Visible = false;
                    this.line5.Visible = false;
                    this.label_PrintType.Text = "";
                    this.PrintTypeHeader.Height = 0;
                    this.customercode.Text = "";
                    this.customersnm.Text = "";
                    this.salesemployeecd.Text = "";
                    this.salesemployeenm.Text = "";
                    this.frontemployeecd.Text = "";
                    this.frontemployeenm.Text = "";
                    this.salesinputcode.Text = "";
                    this.salesinputname.Text = "";
                    this.salesareacode.Text = "";
                    this.salesareacodename.Text = "";
                    this.blgroupcode.Text = "";
                    this.blgroupcodename.Text = "";
                    this.blgoodscode.Text = "";
                    this.blgoodscodename.Text = "";
                    this.salescode.Text = "";
                    this.salescodename.Text = "";
                    break;
                case 1: //拠点-得意先
                    this.label_PrintType.Text = "得意先";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = true;
                    this.customersnm.Visible = true;
                    this.customercode.Top = blgroupcode.Top;
                    this.customersnm.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.customercode.DataField; 
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    break;
                case 2: //拠点-担当者 
                    this.label_PrintType.Text = "担当者";
                    this.label_PrintType.Visible = true;
                    this.salesemployeecd.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = true;
                    this.salesemployeenm.Visible = true;
                    this.salesemployeecd.Top = blgroupcode.Top;
                    this.salesemployeenm.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.salesemployeecd.DataField; 
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    break;
                case 3: //拠点-受注者 
                    this.label_PrintType.Text = "受注者";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = true;
                    this.frontemployeenm.Visible = true;
                    this.frontemployeecd.Top = blgroupcode.Top;
                    this.frontemployeenm.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.frontemployeecd.DataField; 
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    break;
                case 4: //拠点-発行者 
                    this.label_PrintType.Text = "発行者";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = true;
                    this.salesinputname.Visible = true;
                    this.salesinputcode.Top = blgroupcode.Top;
                    this.salesinputname.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.salesinputcode.DataField; 
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    break;
                case 5: //拠点-地区 
                    this.label_PrintType.Text = "地区";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = true;
                    this.salesareacodename.Visible = true;
                    this.salesareacode.Top = blgroupcode.Top;
                    this.salesareacodename.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.salesareacode.DataField; 
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;

                    break;
                case 6: //拠点-ｸﾞﾙｰﾌﾟｺｰﾄﾞ 
                    this.label_PrintType.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = true;
                    this.blgroupcodename.Visible = true;
                    this.PrintTypeHeader.DataField = this.blgroupcode.DataField; 
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    break;
                case 7: //拠点-BLｺｰﾄﾞ
                    this.label_PrintType.Text = "BLｺｰﾄﾞ";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = true;
                    this.blgoodscodename.Visible = true;
                    this.blgoodscode.Top = blgroupcode.Top;
                    this.blgoodscodename.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.blgoodscode.DataField; 
                    this.salescode.Visible = false;
                    this.salescodename.Visible = false;
                    break;
                case 8: //拠点-販売区分  
                    this.label_PrintType.Text = "販売区分";
                    this.label_PrintType.Visible = true;
                    this.PrintTypeHeader.Visible = true;
                    this.customercode.Visible = false;
                    this.customersnm.Visible = false;
                    this.salesemployeecd.Visible = false;
                    this.salesemployeenm.Visible = false;
                    this.frontemployeecd.Visible = false;
                    this.frontemployeenm.Visible = false;
                    this.salesinputcode.Visible = false;
                    this.salesinputname.Visible = false;
                    this.salesareacode.Visible = false;
                    this.salesareacodename.Visible = false;
                    this.blgroupcode.Visible = false;
                    this.blgroupcodename.Visible = false;
                    this.blgoodscode.Visible = false;
                    this.blgoodscodename.Visible = false;
                    this.salescode.Visible = true;
                    this.salescodename.Visible = true;
                    this.salescode.Top = blgroupcode.Top;
                    this.salescodename.Top = blgroupcodename.Top;
                    this.PrintTypeHeader.DataField = this.salescode.DataField; 
                    break;
            }
            #endregion

            #region 年月設定
            DateTime startMonth = this._campaignTargetPrintWork.StartMonth;

            this.lbl_Month1.Text = startMonth.Month + "月";

            this.lbl_Month2.Text = startMonth.AddMonths(1).Month + "月";
            this.lbl_Month3.Text = startMonth.AddMonths(2).Month + "月";
            this.lbl_Month4.Text = startMonth.AddMonths(3).Month + "月";
            this.lbl_Month5.Text = startMonth.AddMonths(4).Month + "月";
            this.lbl_Month6.Text = startMonth.AddMonths(5).Month + "月";
            this.lbl_Month7.Text = startMonth.AddMonths(6).Month + "月";
            this.lbl_Month8.Text = startMonth.AddMonths(7).Month + "月";
            this.lbl_Month9.Text = startMonth.AddMonths(8).Month + "月";
            this.lbl_Month10.Text = startMonth.AddMonths(9).Month + "月";
            this.lbl_Month11.Text = startMonth.AddMonths(10).Month + "月";
            this.lbl_Month12.Text = startMonth.AddMonths(11).Month + "月";
        #endregion
        }
        #endregion
        #endregion

        #region ■ Control Event

        #region ◎ PMKHN08713P_01A4C_ReportStart Event
        /// <summary>
        /// PMKHN08713P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer   : 楊明俊</br>
        /// <br>Date         : 2011/04/25</br>
        /// </remarks>
        private void PMKHN08713P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer   : 楊明俊</br>
        /// <br>Date         : 2011/04/25</br>
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
        /// <br>Programmer   : 楊明俊</br>
        /// <br>Date         : 2011/04/25</br>
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

        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.detail);
        }

        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void pageFooter_Format(object sender, EventArgs e)
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

        private void detail_Format(object sender, EventArgs e)
        {

        }
    }
}
