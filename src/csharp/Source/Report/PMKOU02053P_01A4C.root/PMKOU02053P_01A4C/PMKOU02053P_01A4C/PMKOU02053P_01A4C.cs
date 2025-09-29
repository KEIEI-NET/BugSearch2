//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/06/18  修正内容 : 重複データの場合、仕入先側の仕入額が必要ないの対応
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMKOU02053P_01A4C帳票クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 特になし</br>
    /// <br>Programmer	: 張莉莉</br>
    /// <br>Date		: 2009.05.10</br>
    /// </remarks>
    public partial class PMKOU02053P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {
        #region Private Members
        // 印刷件数
        private int _printCount = 0;

        // 背景透かしモード(無し)
        private int _watermarkMode = 0;

        // 抽出条件ヘッダ出力区分
        private int _extraCondHeadOutDiv;

        // 関連データオブジェクト
        private ArrayList _otherDataList;

        // 抽出条件印字項目
        private StringCollection _extraConditions;

        // 拠点表示有無
        private bool _isSection;

        // フッター出力有無
        private int _pageFooterOutCode;

        // フッタメッセージ1
        private StringCollection _pageFooters;

        // ソート順タイトル
        private string _pageHeaderSortOderTitle;

        // Extra SubReport
        ListCommon_ExtraHeader _rptExtraHeader = new ListCommon_ExtraHeader();

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 表示条件クラス
        private StockSlipCndtn _extrInfo;

        private bool flg = false;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// MABTR02213P_01A4C帳票コンストラクタ
        /// </summary>
        public PMKOU02053P_01A4C()
        {
            InitializeComponent();
        }

 
        /// <summary>
        /// 明細アフタープリントイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
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
        /// レポートスタートイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private void PMKOU02053P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // レポート要素出力設定	
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// ページヘッダフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs eArgs)
        {
            // 作成日付
            DateTime now = DateTime.Now;
            this.tb_PrintDate.Text = now.ToString("yyyy/MM/dd");
            this.tb_PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// 抽出データフォーマット処理
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
        /// <remarks>
        /// <br>Note		: 抽出データフォーマットを処理します。</br>
        /// <br>Programmer	: 張莉莉</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
         private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 抽出条件設定
            // ヘッダ出力制御
            if ( this._extraCondHeadOutDiv == 0 )
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
            if ( this._rptExtraHeader == null )
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

        #region IPrintActiveReportTypeCommon メンバ

        /// <summary>背景透かしモード</summary>
        /// <value>0：背景透かし無し, 1:背景透かし有り</value>
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }

        #endregion

        #region IPrintActiveReportTypeList メンバ

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
        /// 
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                _extrInfo = (StockSlipCndtn)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            if (_extrInfo.CheckSectionDiv.ToString().Equals("PMSupplier"))
            {
                if (_extrInfo.PrintDiv.ToString().Equals("All"))
                {
                    this.SameHeader.Visible = false;
                }
                this.SameZeroFooter.Visible = false;
                this.DiffZeroFooter.Visible = false;
                if (_extrInfo.PrintDiv.ToString().Equals("All") && _extrInfo.SameFlg && _extrInfo.DiffFlg)
                {
                    this.SameFooter.Visible = false;
                }
            }
            else
            {
                this.SameHeader.Visible = false;
                this.SameFooter.Visible = false;
                this.SameZeroFooter.Visible = false;
                this.DiffZeroFooter.Visible = false;
                this.tb_Csv_StockTotalPrice.Visible = false;
                this.tb_TotalCsvPrice.Visible = false;
            }
            
        }

        /// <summary>
        /// SameHeader_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SameHeader_Format(object sender, EventArgs e)
        {
            if (_extrInfo.PrintDiv.ToString().Equals("Different"))
            {
                this.lb_sameTitle.Text = "一致分合計";
                this.tb_PmPrice.Text = _extrInfo.SamePmPrice.ToString("###,###,##0");
                this.tb_CsvPrice.Text = _extrInfo.SameCsvPrice.ToString("###,###,##0");
            }

            if (_extrInfo.PrintDiv.ToString().Equals("Same"))
            {
                this.lb_sameTitle.Text = "不一致分合計";
                this.tb_PmPrice.Text = _extrInfo.DiffPmPrice.ToString("###,###,##0");
                this.tb_CsvPrice.Text = _extrInfo.DiffCsvPrice.ToString("###,###,##0");
            }
        }

        /// <summary>
        /// SameFooter_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SameFooter_BeforePrint(object sender, EventArgs e)
        {
            if (_extrInfo.PrintDiv.ToString().Equals("Same") && _extrInfo.SameFlg)
            {
                this.tt_diffFlg.Text = "一致小計";
            }

            if (_extrInfo.PrintDiv.ToString().Equals("Different") && _extrInfo.DiffFlg)
            {
                this.tt_diffFlg.Text = "不一致小計";
            }

            if (!flg && !string.IsNullOrEmpty(this.tb_sameDiv.Text))
            {
                if (this.tb_sameDiv.Text.Equals("Different"))
                {
                    this.tt_diffFlg.Text = "不一致小計";
                }
                if (this.tb_sameDiv.Text.Equals("Same"))
                {
                    this.tt_diffFlg.Text = "一致小計";
                }
            }
           // flg = true;
        }

        /// <summary>
        /// TotalFooter_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TotalFooter_Format(object sender, EventArgs e)
        {
            this.tb_TotalPmPrice.Text = _extrInfo.TotalPmPrice.ToString("###,###,##0");
            this.tb_TotalCsvPrice.Text = _extrInfo.TotalCsvPrice.ToString("###,###,##0");
        }

        /// <summary>
        /// SameZeroFooter_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SameZeroFooter_Format(object sender, EventArgs e)
        {
            if (_extrInfo.PrintDiv.ToString().Equals("All"))
            {
                if (_extrInfo.SameFlg)
                {
                    this.SameZeroFooter.Visible = true;
                }
            }
            
        }

        /// <summary>
        /// DiffZeroFooter_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiffZeroFooter_Format(object sender, EventArgs e)
        {
            if (_extrInfo.PrintDiv.ToString().Equals("All"))
            {
                if (_extrInfo.DiffFlg)
                {
                    this.DiffZeroFooter.Visible = true;
                }
            }
            
        }

        /// <summary>
        /// detail_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_Format(object sender, EventArgs e)
        {
            string isNotShow = this.tb_IsNotShow.Text;
            if (!string.IsNullOrEmpty(isNotShow))
            {
                if (isNotShow.Equals("CSV"))
                {
                    this.tb_Csv_StockTotalPrice.Text = "";
                }
                if (isNotShow.Equals("PM"))
                {
                    this.tb_SupplierSlipNo.Text = "";
                    this.tb_StockTotalPrice.Text = "";
                }
            }
            
        }
    }
}
