using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// MAZAI02062P_01A4C の概要の説明です。
    /// </summary>
    public partial class PMZAI02063P_01A4C : ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Private Member

        private int _printCount;								// 印刷件数用カウンタ
        private int _extraCondHeadOutDiv;			            // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;				// 抽出条件
        private int _pageFooterOutCode;				            // フッター出力区分
        private StringCollection _pageFooters;					// フッターメッセージ
        private SFCMN06002C _printInfo;						    // 印刷情報クラス
        private ArrayList _otherDataList;
        private string _pageHeaderSubtitle;
        private string _pageHeaderSortOderTitle;		        // ソート順
        private int _prevMakerCode;
        private string _prevAfWarehouseCode;
        private TrustStockOrderCndtn _trustStockOrderCndtn;     // 抽出条件クラス
        ListCommon_ExtraHeader _rptExtraHeader = null;          // ヘッダーサブレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;            // フッターレポート宣言

        #endregion ■ Private Member


        #region ■ Constructor
        /// <summary>
        /// 委託在庫補充処理表印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 委託在庫補充処理表印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/12</br>
        /// </remarks>
        public PMZAI02063P_01A4C()
        {
            InitializeComponent();
        }

        #endregion ■ Constructor


        # region ■ IPrintActiveReportTypeList インターフェース
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
                this._trustStockOrderCndtn = (TrustStockOrderCndtn)this._printInfo.jyoken;
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
        /// 印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        # endregion ■ IPrintActiveReportTypeList インターフェース


        # region ■ IPrintActiveReportTypeCommon インターフェース
        /// <summary>
        /// 背景透過設定値プロパティ
        /// </summary>
        public int WatermarkMode
        {
            get { return 0; }
            set { }
        }
        # endregion ■ IPrintActiveReportTypeCommon インターフェース


        #region ■ Private Method
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 改頁
            if (this._trustStockOrderCndtn.NewPage == 0)
            {
                this.MakerHeader.NewPage = NewPage.None;
                this.MakerHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                this.MakerHeader.NewPage = NewPage.Before;
                this.MakerHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }

            // 補充元商品無し時
            if (this._trustStockOrderCndtn.ReplenishNoneGoods == 0)
            {
                this.Note_TextBox.Visible = false;
            }
            else
            {
                this.Note_TextBox.Visible = true;
            }
        }
        #endregion ■ Private Method


        #region ■ Control Events
        /// <summary>
        /// ReportStart イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: レポートの開始時に発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private void MAZAI02062P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: PageHeaderセクション読込時に発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs e)
        {
            // 作成日付
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // 作成時間
            this.PrintTime.Text = DateTime.Now.ToString("HH:mm");
        }

        /// <summary>
        /// Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderセクション読込時に発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, EventArgs e)
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
        /// Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: Detailセクション読込時に発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// <br>Update Note : 2012/09/06 李亜博</br>
        /// <br>            : 10801804-00、2012/09/19配信分、PM保守案件Redmine#32179の対応</br>
        /// <br>            : 補充元商品無し時「無視して更新」の区分を選択して実行時、補充元の在庫マスタが新規作成される。</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            if (this.AfWarehouseCode_TextBox.Text.Trim() != this._prevAfWarehouseCode)
            {
                this.MakerCode_TextBox.Visible = true;
                this.MakerName_TextBox.Visible = true;
            }
            else
            {
                if (int.Parse(this.MakerCode_TextBox.Text.Trim()) != this._prevMakerCode)
                {
                    this.MakerCode_TextBox.Visible = true;
                    this.MakerName_TextBox.Visible = true;
                }
                else
                {
                    this.MakerCode_TextBox.Visible = false;
                    this.MakerName_TextBox.Visible = false;
                }
            }

            // ------ ADD 2012/09/06 李亜博 for Redmine#32179 -------->>>>
            if (this.Note_TextBox.Text.Trim().Equals("補充元在庫ﾏｽﾀ未登録"))
            {
                this.BfSupplierStock_TextBox.Visible = false;
                this.BfAfterSupplierStock_TextBox.Visible = false;
            }
            else
            {

                this.BfSupplierStock_TextBox.Visible = true;
                this.BfAfterSupplierStock_TextBox.Visible = true;
            }
            // ------ ADD 2012/09/06 李亜博 for Redmine#32179 --------<<<<

            // メーカーコードをバッファに保持
            this._prevMakerCode = int.Parse(this.MakerCode_TextBox.Text.Trim());
            // 委託倉庫をバッファに保持
            this._prevAfWarehouseCode = this.AfWarehouseCode_TextBox.Text.Trim();
        }

        /// <summary>
        /// Format イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: PageFooterセクション読込時に発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private void PageFooter_Format(object sender, EventArgs e)
        {
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                this.line6.Visible = true;
                this.Footer1_TextBox.Visible = true;
                this.Footer2_TextBox.Visible = true;

                // フッターレポート作成
                if (this._rptPageFooter == null)
                {
                    this._rptPageFooter = new ListCommon_PageFooter();
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

                // サブレポートを使うと、強制的に罫線が10.8になるので使用しない
                this.Footer1_TextBox.Text = this._pageFooters[0];
                this.Footer2_TextBox.Text = this._pageFooters[1];
            }
            else
            {
                this.line6.Visible = false;
                this.Footer1_TextBox.Visible = false;
                this.Footer2_TextBox.Visible = false;
            }
        }

        /// <summary>
        /// AfterPrint イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: Detailセクション読込後に発生します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/11/12</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }
        #endregion ■ Control Events
    }
}
