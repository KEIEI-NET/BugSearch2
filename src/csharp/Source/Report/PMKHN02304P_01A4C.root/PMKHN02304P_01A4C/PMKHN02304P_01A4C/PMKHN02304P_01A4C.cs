//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

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
    /// PMKHN02304P_01A4C の概要の説明です。
    /// </summary>
    public partial class PMKHN02304P_01A4C : ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
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
        //private int _prevMakerCode;
        //private string _prevAfWarehouseCode;
        private GoodsInfoCndtn _goodsInfoCndtn;     // 抽出条件クラス
        ListCommon_ExtraHeader _rptExtraHeader = null;          // ヘッダーサブレポート宣言
        //ListCommon_PageFooter _rptPageFooter = null;            // フッターレポート宣言

        #endregion ■ Private Member


        #region ■ Constructor
        /// <summary>
        /// 卸商商品価格改正印刷クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 卸商商品価格改正印刷クラスのインスタンスの作成を行う。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02304P_01A4C()
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
                this._goodsInfoCndtn = (GoodsInfoCndtn)this._printInfo.jyoken;
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            //// 改頁
            //if (this._goodsInfoCndtn.NewPage == 0)
            //{
            //    this.MakerHeader.NewPage = NewPage.None;
            //    this.MakerHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //}
            //else
            //{
            //    this.MakerHeader.NewPage = NewPage.Before;
            //    this.MakerHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //}

            //// 補充元商品無し時
            //if (this._goodsInfoCndtn.ReplenishNoneGoods == 0)
            //{
            //    this.SupplierCd.Visible = false;
            //}
            //else
            //{
            //    this.SupplierCd.Visible = true;
            //}
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
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
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
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
        /// <br>Note		: PageFooterセクション読込時に発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void PageFooter_Format(object sender, EventArgs e)
        {
            //// フッター出力する？
            //if (this._pageFooterOutCode == 0)
            //{
            //    this.line6.Visible = true;
            //    this.Footer1_TextBox.Visible = true;
            //    this.Footer2_TextBox.Visible = true;

            //    // フッターレポート作成
            //    if (this._rptPageFooter == null)
            //    {
            //        this._rptPageFooter = new ListCommon_PageFooter();
            //    }

            //    // フッター印字項目設定
            //    if (this._pageFooters[0] != null)
            //    {
            //        this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
            //    }
            //    if (this._pageFooters[1] != null)
            //    {
            //        this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
            //    }

            //    // サブレポートを使うと、強制的に罫線が10.8になるので使用しない
            //    this.Footer1_TextBox.Text = this._pageFooters[0];
            //    this.Footer2_TextBox.Text = this._pageFooters[1];
            //}
            //else
            //{
            //    this.line6.Visible = false;
            //    this.Footer1_TextBox.Visible = false;
            //    this.Footer2_TextBox.Visible = false;
            //}
        }

        /// <summary>
        /// AfterPrint イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: Detailセクション読込後に発生します。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
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

        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }

        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            ////仕入先
            //string suppliercd = this.SupplierCd.Text;
            //try
            //{
            //    int newSuppliercd = Convert.ToInt32(suppliercd);
            //    if (newSuppliercd >= 0)
            //    {
            //        this.SupplierCd.Text = newSuppliercd.ToString("d06");
            //    }
            //    else
            //    {
            //        this.SupplierCd.Text = "-" + Math.Abs(newSuppliercd).ToString("d05");
            //    }
            //}
            //catch
            //{

            //}

            ////ﾒｰｶｰ
            //string goodsMakerCd = this.GoodsMakerCd.Text;
            //try
            //{
            //    int newGoodsMakerCd = Convert.ToInt32(goodsMakerCd);
            //    if (newGoodsMakerCd >= 0)
            //    {
            //        this.GoodsMakerCd.Text = newGoodsMakerCd.ToString("d04");
            //    }
            //    else
            //    {
            //        this.GoodsMakerCd.Text = "-" + Math.Abs(newGoodsMakerCd).ToString("d03");
            //    }
            //}
            //catch
            //{

            //}


            ////BLｺｰﾄﾞ
            //string bLGoodsCode = this.BLGoodsCode.Text;
            //try
            //{
            //    int newBLGoodsCode = Convert.ToInt32(bLGoodsCode);
            //    if (newBLGoodsCode >= 0)
            //    {
            //        this.BLGoodsCode.Text = newBLGoodsCode.ToString("d05");
            //    }
            //    else
            //    {
            //        this.BLGoodsCode.Text = "-" + Math.Abs(newBLGoodsCode).ToString("d04");
            //    }
            //}
            //catch
            //{

            //}


            ////定価
            //string price = this.Price.Text;
            //try
            //{
            //    double newPrice = Math.Truncate(Convert.ToDouble(price));

            //    this.Price.Text = NumberFormat(newPrice);

            //}
            //catch
            //{

            //}


            ////仕入率
            //string saleRate = this.SaleRate.Text;
            //try
            //{
            //    double newSaleRate = Convert.ToDouble(saleRate);

            //    this.SaleRate.Text = newSaleRate.ToString("0.00");

            //}
            //catch
            //{

            //}


            ////原価
            //string salesUnitCost = this.SalesUnitCost.Text;
            //try
            //{
            //    double newSalesUnitCost = Math.Truncate(Convert.ToDouble(salesUnitCost));

            //    this.SalesUnitCost.Text = NumberFormat(newSalesUnitCost);

            //}
            //catch
            //{

            //}
        }


        /// <summary>
        /// 数字のフォーマット
        /// </summary>
        /// <param name="number">数字</param>
        /// <remarks>
        /// <br>Note		: 数字のフォーマット(999,999,999)を変換する</br>
        /// <br>Programmer	: 汪千来</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(double number)
        {
            string ret;
            if (Math.Abs(number) > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }

        #endregion ■ Control Events

    }
}
