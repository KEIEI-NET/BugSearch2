using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 在庫看板印刷 ３×９（レーザー）帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫看板印刷 ３×９（レーザー）帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.12.12</br>
    /// <br>Update Note  : 2009.01.06 30452 上野 俊治</br>
    /// <br>              ・障害対応9615 </br>
    /// <br>             :</br>
    /// </remarks>
    public class PMZAI02053P_03A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMZAI02053P_03A4C()
        {
            InitializeComponent();
        }
        #endregion

        #region ■ private変数
        private int _printCount;						// 印刷件数用カウンタ // ADD 2009/01/06

        private int _extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;		// 抽出条件
        private int _pageFooterOutCode;				    // フッター出力区分
        private StringCollection _pageFooters;			// フッターメッセージ
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        private StockSignOrderCndtn _stockSignOrderCndtn;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        #region ActiveReport生成
        private DataDynamics.ActiveReports.Detail detail;
        private TextBox WareHouseTitle1;
        private TextBox WarehouseCode1;
        private TextBox ShelfTitle1;
        private TextBox WarehouseShelfNo1;
        private TextBox GoodsNo1;
        private TextBox GoodsNameKana1;
        private TextBox MinimumStockCnt1;
        private TextBox MaximumStockCnt1;
        private TextBox StockCreateDate1;
        private TextBox ListPrice1;
        private TextBox WareHouseTitle2;
        private TextBox WarehouseCode2;
        private TextBox ShelfTitle2;
        private TextBox WarehouseShelfNo2;
        private TextBox GoodsNo2;
        private TextBox GoodsNameKana2;
        private TextBox MinimumStockCnt2;
        private TextBox MaximumStockCnt2;
        private TextBox StockCreateDate2;
        private TextBox ListPrice2;
        private TextBox WareHouseTitle3;
        private TextBox WarehouseCode3;
        private TextBox ShelfTitle3;
        private TextBox WarehouseShelfNo3;
        private TextBox GoodsNo3;
        private TextBox GoodsNameKana3;
        private TextBox MinimumStockCnt3;
        private TextBox MaximumStockCnt3;
        private TextBox StockCreateDate3;
        private TextBox InvisibleRow;
        private TextBox DataNum;
        private ReportHeader reportHeader1;
        private ReportFooter reportFooter1;
        private PageHeader pageHeader1;
        private PageFooter pageFooter1;
        private TextBox ListPrice3;
        #endregion
        #endregion

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
                this._stockSignOrderCndtn = (StockSignOrderCndtn)this._printInfo.jyoken;
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
                // TODO:  MAZAI02032P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  MAZAI02032P_01A4C.WatermarkMode setter 実装を追加します。
            }
        }

        // --- ADD 2009/01/06 -------------------------------->>>>>
        /// <summary>
        /// 印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        // --- ADD 2009/01/06 --------------------------------<<<<<
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■コントロールイベント
        /// <summary>
        /// detail_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_Format(object sender, EventArgs e)
        {
            // 開始行の制御
            if ((int)this.InvisibleRow.Value == 0)
            {
                // 空行
                WareHouseTitle1.Text = "";
                WarehouseCode1.Text = "";
                ShelfTitle1.Text = "";
                WarehouseShelfNo1.Text = "";
                GoodsNo1.Text = "";
                GoodsNameKana1.Text = "";
                MinimumStockCnt1.Text = "";
                MaximumStockCnt1.Text = "";
                ListPrice1.Text = "";
                StockCreateDate1.Text = "";

                WareHouseTitle2.Text = "";
                WarehouseCode2.Text = "";
                ShelfTitle2.Text = "";
                WarehouseShelfNo2.Text = "";
                GoodsNo2.Text = "";
                GoodsNameKana2.Text = "";
                MinimumStockCnt2.Text = "";
                MaximumStockCnt2.Text = "";
                ListPrice2.Text = "";
                StockCreateDate2.Text = "";

                WareHouseTitle3.Text = "";
                WarehouseCode3.Text = "";
                ShelfTitle3.Text = "";
                WarehouseShelfNo3.Text = "";
                GoodsNo3.Text = "";
                GoodsNameKana3.Text = "";
                MinimumStockCnt3.Text = "";
                MaximumStockCnt3.Text = "";
                ListPrice3.Text = "";
                StockCreateDate3.Text = "";
            }
            else
            {
                WareHouseTitle1.Text = "倉庫";
                ShelfTitle1.Text = "棚番";

                WareHouseTitle2.Text = "倉庫";
                ShelfTitle2.Text = "棚番";

                WareHouseTitle3.Text = "倉庫";
                ShelfTitle3.Text = "棚番";
            }

            // 1行に含まれるデータ数による制御
            if ((int)this.DataNum.Value == 1)
            {
                // 2列目、3列目を非表示
                WareHouseTitle2.Text = "";
                WarehouseCode2.Text = "";
                ShelfTitle2.Text = "";
                WarehouseShelfNo2.Text = "";
                GoodsNo2.Text = "";
                GoodsNameKana2.Text = "";
                MinimumStockCnt2.Text = "";
                MaximumStockCnt2.Text = "";
                ListPrice2.Text = "";
                StockCreateDate2.Text = "";

                WareHouseTitle3.Text = "";
                WarehouseCode3.Text = "";
                ShelfTitle3.Text = "";
                WarehouseShelfNo3.Text = "";
                GoodsNo3.Text = "";
                GoodsNameKana3.Text = "";
                MinimumStockCnt3.Text = "";
                MaximumStockCnt3.Text = "";
                ListPrice3.Text = "";
                StockCreateDate3.Text = "";
            }
            else if ((int)this.DataNum.Value == 2)
            {
                // 3列目を非表示
                WareHouseTitle3.Text = "";
                WarehouseCode3.Text = "";
                ShelfTitle3.Text = "";
                WarehouseShelfNo3.Text = "";
                GoodsNo3.Text = "";
                GoodsNameKana3.Text = "";
                MinimumStockCnt3.Text = "";
                MaximumStockCnt3.Text = "";
                ListPrice3.Text = "";
                StockCreateDate3.Text = "";
            }
        }

        /// <summary>
        /// detail_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値は印刷しない
            // 倉庫コード
            if (string.IsNullOrEmpty(this.WarehouseCode1.Text)
                || Convert.ToInt32(this.WarehouseCode1.Text) == 0)
            {
                this.WarehouseCode1.Text = "";
            }

            if (string.IsNullOrEmpty(this.WarehouseCode2.Text)
                || Convert.ToInt32(this.WarehouseCode2.Text) == 0)
            {
                this.WarehouseCode2.Text = "";
            }

            if (string.IsNullOrEmpty(this.WarehouseCode3.Text)
                || Convert.ToInt32(this.WarehouseCode3.Text) == 0)
            {
                this.WarehouseCode3.Text = "";
            }

            // 在庫作成日時
            if (string.IsNullOrEmpty(this.StockCreateDate1.Text)
                || this.StockCreateDate1.Text == "01/01/01")
            {
                this.StockCreateDate1.Text = "";
            }

            if (string.IsNullOrEmpty(this.StockCreateDate2.Text)
                || this.StockCreateDate2.Text == "01/01/01")
            {
                this.StockCreateDate2.Text = "";
            }

            if (string.IsNullOrEmpty(this.StockCreateDate3.Text)
                || this.StockCreateDate3.Text == "01/01/01")
            {
                this.StockCreateDate3.Text = "";
            }
        }

        // --- ADD 2009/01/06 -------------------------------->>>>>
        /// <summary>
        /// detail_AfterPrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }
        // --- ADD 2009/01/06 --------------------------------<<<<<
        #endregion

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager( typeof( PMZAI02053P_03A4C ) );
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.WareHouseTitle1 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode1 = new DataDynamics.ActiveReports.TextBox();
            this.ShelfTitle1 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo1 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo1 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana1 = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate1 = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice1 = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseTitle2 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode2 = new DataDynamics.ActiveReports.TextBox();
            this.ShelfTitle2 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo2 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo2 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana2 = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate2 = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice2 = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseTitle3 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode3 = new DataDynamics.ActiveReports.TextBox();
            this.ShelfTitle3 = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo3 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo3 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana3 = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate3 = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice3 = new DataDynamics.ActiveReports.TextBox();
            this.InvisibleRow = new DataDynamics.ActiveReports.TextBox();
            this.DataNum = new DataDynamics.ActiveReports.TextBox();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.pageHeader1 = new DataDynamics.ActiveReports.PageHeader();
            this.pageFooter1 = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfTitle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfTitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfTitle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvisibleRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange( new DataDynamics.ActiveReports.ARControl[] {
            this.WareHouseTitle1,
            this.WarehouseCode1,
            this.ShelfTitle1,
            this.WarehouseShelfNo1,
            this.GoodsNo1,
            this.GoodsNameKana1,
            this.MinimumStockCnt1,
            this.MaximumStockCnt1,
            this.StockCreateDate1,
            this.ListPrice1,
            this.WareHouseTitle2,
            this.WarehouseCode2,
            this.ShelfTitle2,
            this.WarehouseShelfNo2,
            this.GoodsNo2,
            this.GoodsNameKana2,
            this.MinimumStockCnt2,
            this.MaximumStockCnt2,
            this.StockCreateDate2,
            this.ListPrice2,
            this.WareHouseTitle3,
            this.WarehouseCode3,
            this.ShelfTitle3,
            this.WarehouseShelfNo3,
            this.GoodsNo3,
            this.GoodsNameKana3,
            this.MinimumStockCnt3,
            this.MaximumStockCnt3,
            this.StockCreateDate3,
            this.ListPrice3,
            this.InvisibleRow,
            this.DataNum} );
            this.detail.Height = 1.18F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler( this.detail_Format );
            this.detail.AfterPrint += new System.EventHandler( this.detail_AfterPrint );
            this.detail.BeforePrint += new System.EventHandler( this.detail_BeforePrint );
            // 
            // WareHouseTitle1
            // 
            this.WareHouseTitle1.Border.BottomColor = System.Drawing.Color.Black;
            this.WareHouseTitle1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle1.Border.LeftColor = System.Drawing.Color.Black;
            this.WareHouseTitle1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle1.Border.RightColor = System.Drawing.Color.Black;
            this.WareHouseTitle1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle1.Border.TopColor = System.Drawing.Color.Black;
            this.WareHouseTitle1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle1.Height = 0.2F;
            this.WareHouseTitle1.Left = 0.375F;
            this.WareHouseTitle1.MultiLine = false;
            this.WareHouseTitle1.Name = "WareHouseTitle1";
            this.WareHouseTitle1.OutputFormat = resources.GetString( "WareHouseTitle1.OutputFormat" );
            this.WareHouseTitle1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WareHouseTitle1.Text = "倉庫";
            this.WareHouseTitle1.Top = 0F;
            this.WareHouseTitle1.Width = 0.35F;
            // 
            // WarehouseCode1
            // 
            this.WarehouseCode1.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode1.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode1.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode1.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode1.DataField = "WarehouseCode1";
            this.WarehouseCode1.Height = 0.2F;
            this.WarehouseCode1.Left = 0.75F;
            this.WarehouseCode1.MultiLine = false;
            this.WarehouseCode1.Name = "WarehouseCode1";
            this.WarehouseCode1.OutputFormat = resources.GetString( "WarehouseCode1.OutputFormat" );
            this.WarehouseCode1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseCode1.Text = "9999";
            this.WarehouseCode1.Top = 0F;
            this.WarehouseCode1.Width = 0.4F;
            // 
            // ShelfTitle1
            // 
            this.ShelfTitle1.Border.BottomColor = System.Drawing.Color.Black;
            this.ShelfTitle1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle1.Border.LeftColor = System.Drawing.Color.Black;
            this.ShelfTitle1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle1.Border.RightColor = System.Drawing.Color.Black;
            this.ShelfTitle1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle1.Border.TopColor = System.Drawing.Color.Black;
            this.ShelfTitle1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle1.Height = 0.2F;
            this.ShelfTitle1.Left = 1.1875F;
            this.ShelfTitle1.MultiLine = false;
            this.ShelfTitle1.Name = "ShelfTitle1";
            this.ShelfTitle1.OutputFormat = resources.GetString( "ShelfTitle1.OutputFormat" );
            this.ShelfTitle1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ShelfTitle1.Text = "棚番";
            this.ShelfTitle1.Top = 0F;
            this.ShelfTitle1.Width = 0.35F;
            // 
            // WarehouseShelfNo1
            // 
            this.WarehouseShelfNo1.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo1.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo1.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo1.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo1.DataField = "WarehouseShelfNo1";
            this.WarehouseShelfNo1.Height = 0.188F;
            this.WarehouseShelfNo1.Left = 1.5625F;
            this.WarehouseShelfNo1.MultiLine = false;
            this.WarehouseShelfNo1.Name = "WarehouseShelfNo1";
            this.WarehouseShelfNo1.OutputFormat = resources.GetString( "WarehouseShelfNo1.OutputFormat" );
            this.WarehouseShelfNo1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseShelfNo1.Text = "99999999";
            this.WarehouseShelfNo1.Top = 0F;
            this.WarehouseShelfNo1.Width = 0.66F;
            // 
            // GoodsNo1
            // 
            this.GoodsNo1.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo1.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo1.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo1.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo1.DataField = "GoodsNo1";
            this.GoodsNo1.Height = 0.188F;
            this.GoodsNo1.Left = 0.375F;
            this.GoodsNo1.MultiLine = false;
            this.GoodsNo1.Name = "GoodsNo1";
            this.GoodsNo1.OutputFormat = resources.GetString( "GoodsNo1.OutputFormat" );
            this.GoodsNo1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNo1.Text = "12345678901234567890";
            this.GoodsNo1.Top = 0.1875F;
            this.GoodsNo1.Width = 1.85F;
            // 
            // GoodsNameKana1
            // 
            this.GoodsNameKana1.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameKana1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana1.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameKana1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana1.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameKana1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana1.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameKana1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana1.DataField = "GoodsNameKana1";
            this.GoodsNameKana1.Height = 0.188F;
            this.GoodsNameKana1.Left = 0.375F;
            this.GoodsNameKana1.MultiLine = false;
            this.GoodsNameKana1.Name = "GoodsNameKana1";
            this.GoodsNameKana1.OutputFormat = resources.GetString( "GoodsNameKana1.OutputFormat" );
            this.GoodsNameKana1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNameKana1.Text = "123456789012345678901234";
            this.GoodsNameKana1.Top = 0.375F;
            this.GoodsNameKana1.Width = 1.85F;
            // 
            // MinimumStockCnt1
            // 
            this.MinimumStockCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.MinimumStockCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.MinimumStockCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.MinimumStockCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.MinimumStockCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt1.DataField = "MinimumStockCnt1";
            this.MinimumStockCnt1.Height = 0.1875F;
            this.MinimumStockCnt1.Left = 0.375F;
            this.MinimumStockCnt1.MultiLine = false;
            this.MinimumStockCnt1.Name = "MinimumStockCnt1";
            this.MinimumStockCnt1.OutputFormat = resources.GetString( "MinimumStockCnt1.OutputFormat" );
            this.MinimumStockCnt1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.MinimumStockCnt1.Text = "9,999,999";
            this.MinimumStockCnt1.Top = 0.5625F;
            this.MinimumStockCnt1.Width = 0.875F;
            // 
            // MaximumStockCnt1
            // 
            this.MaximumStockCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.MaximumStockCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.MaximumStockCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.MaximumStockCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.MaximumStockCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt1.DataField = "MaximumStockCnt1";
            this.MaximumStockCnt1.Height = 0.1875F;
            this.MaximumStockCnt1.Left = 1.375F;
            this.MaximumStockCnt1.MultiLine = false;
            this.MaximumStockCnt1.Name = "MaximumStockCnt1";
            this.MaximumStockCnt1.OutputFormat = resources.GetString( "MaximumStockCnt1.OutputFormat" );
            this.MaximumStockCnt1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.MaximumStockCnt1.Text = "9,999,999";
            this.MaximumStockCnt1.Top = 0.5625F;
            this.MaximumStockCnt1.Width = 0.875F;
            // 
            // StockCreateDate1
            // 
            this.StockCreateDate1.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCreateDate1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate1.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCreateDate1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate1.Border.RightColor = System.Drawing.Color.Black;
            this.StockCreateDate1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate1.Border.TopColor = System.Drawing.Color.Black;
            this.StockCreateDate1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate1.DataField = "StockCreateDate1";
            this.StockCreateDate1.Height = 0.1875F;
            this.StockCreateDate1.Left = 1.375F;
            this.StockCreateDate1.MultiLine = false;
            this.StockCreateDate1.Name = "StockCreateDate1";
            this.StockCreateDate1.OutputFormat = resources.GetString( "StockCreateDate1.OutputFormat" );
            this.StockCreateDate1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.StockCreateDate1.Text = "08/12/12";
            this.StockCreateDate1.Top = 0.75F;
            this.StockCreateDate1.Width = 0.875F;
            // 
            // ListPrice1
            // 
            this.ListPrice1.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice1.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice1.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice1.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice1.DataField = "ListPrice1";
            this.ListPrice1.Height = 0.1875F;
            this.ListPrice1.Left = 0.375F;
            this.ListPrice1.MultiLine = false;
            this.ListPrice1.Name = "ListPrice1";
            this.ListPrice1.OutputFormat = resources.GetString( "ListPrice1.OutputFormat" );
            this.ListPrice1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.ListPrice1.Text = "999,999,999";
            this.ListPrice1.Top = 0.75F;
            this.ListPrice1.Width = 0.875F;
            // 
            // WareHouseTitle2
            // 
            this.WareHouseTitle2.Border.BottomColor = System.Drawing.Color.Black;
            this.WareHouseTitle2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle2.Border.LeftColor = System.Drawing.Color.Black;
            this.WareHouseTitle2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle2.Border.RightColor = System.Drawing.Color.Black;
            this.WareHouseTitle2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle2.Border.TopColor = System.Drawing.Color.Black;
            this.WareHouseTitle2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle2.Height = 0.2F;
            this.WareHouseTitle2.Left = 2.875F;
            this.WareHouseTitle2.MultiLine = false;
            this.WareHouseTitle2.Name = "WareHouseTitle2";
            this.WareHouseTitle2.OutputFormat = resources.GetString( "WareHouseTitle2.OutputFormat" );
            this.WareHouseTitle2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WareHouseTitle2.Text = "倉庫";
            this.WareHouseTitle2.Top = 0F;
            this.WareHouseTitle2.Width = 0.35F;
            // 
            // WarehouseCode2
            // 
            this.WarehouseCode2.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode2.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode2.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode2.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode2.DataField = "WarehouseCode2";
            this.WarehouseCode2.Height = 0.2F;
            this.WarehouseCode2.Left = 3.25F;
            this.WarehouseCode2.MultiLine = false;
            this.WarehouseCode2.Name = "WarehouseCode2";
            this.WarehouseCode2.OutputFormat = resources.GetString( "WarehouseCode2.OutputFormat" );
            this.WarehouseCode2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseCode2.Text = "9999";
            this.WarehouseCode2.Top = 0F;
            this.WarehouseCode2.Width = 0.4F;
            // 
            // ShelfTitle2
            // 
            this.ShelfTitle2.Border.BottomColor = System.Drawing.Color.Black;
            this.ShelfTitle2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle2.Border.LeftColor = System.Drawing.Color.Black;
            this.ShelfTitle2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle2.Border.RightColor = System.Drawing.Color.Black;
            this.ShelfTitle2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle2.Border.TopColor = System.Drawing.Color.Black;
            this.ShelfTitle2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle2.Height = 0.2F;
            this.ShelfTitle2.Left = 3.6875F;
            this.ShelfTitle2.MultiLine = false;
            this.ShelfTitle2.Name = "ShelfTitle2";
            this.ShelfTitle2.OutputFormat = resources.GetString( "ShelfTitle2.OutputFormat" );
            this.ShelfTitle2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ShelfTitle2.Text = "棚番";
            this.ShelfTitle2.Top = 0F;
            this.ShelfTitle2.Width = 0.35F;
            // 
            // WarehouseShelfNo2
            // 
            this.WarehouseShelfNo2.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo2.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo2.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo2.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo2.DataField = "WarehouseShelfNo2";
            this.WarehouseShelfNo2.Height = 0.188F;
            this.WarehouseShelfNo2.Left = 4.0625F;
            this.WarehouseShelfNo2.MultiLine = false;
            this.WarehouseShelfNo2.Name = "WarehouseShelfNo2";
            this.WarehouseShelfNo2.OutputFormat = resources.GetString( "WarehouseShelfNo2.OutputFormat" );
            this.WarehouseShelfNo2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseShelfNo2.Text = "99999999";
            this.WarehouseShelfNo2.Top = 0F;
            this.WarehouseShelfNo2.Width = 0.66F;
            // 
            // GoodsNo2
            // 
            this.GoodsNo2.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo2.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo2.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo2.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo2.DataField = "GoodsNo2";
            this.GoodsNo2.Height = 0.188F;
            this.GoodsNo2.Left = 2.875F;
            this.GoodsNo2.MultiLine = false;
            this.GoodsNo2.Name = "GoodsNo2";
            this.GoodsNo2.OutputFormat = resources.GetString( "GoodsNo2.OutputFormat" );
            this.GoodsNo2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNo2.Text = "12345678901234567890";
            this.GoodsNo2.Top = 0.1875F;
            this.GoodsNo2.Width = 1.85F;
            // 
            // GoodsNameKana2
            // 
            this.GoodsNameKana2.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameKana2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana2.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameKana2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana2.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameKana2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana2.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameKana2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana2.DataField = "GoodsNameKana2";
            this.GoodsNameKana2.Height = 0.188F;
            this.GoodsNameKana2.Left = 2.875F;
            this.GoodsNameKana2.MultiLine = false;
            this.GoodsNameKana2.Name = "GoodsNameKana2";
            this.GoodsNameKana2.OutputFormat = resources.GetString( "GoodsNameKana2.OutputFormat" );
            this.GoodsNameKana2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNameKana2.Text = "123456789012345678901234";
            this.GoodsNameKana2.Top = 0.375F;
            this.GoodsNameKana2.Width = 1.85F;
            // 
            // MinimumStockCnt2
            // 
            this.MinimumStockCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.MinimumStockCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.MinimumStockCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.MinimumStockCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.MinimumStockCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt2.DataField = "MinimumStockCnt2";
            this.MinimumStockCnt2.Height = 0.1875F;
            this.MinimumStockCnt2.Left = 2.875F;
            this.MinimumStockCnt2.MultiLine = false;
            this.MinimumStockCnt2.Name = "MinimumStockCnt2";
            this.MinimumStockCnt2.OutputFormat = resources.GetString( "MinimumStockCnt2.OutputFormat" );
            this.MinimumStockCnt2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.MinimumStockCnt2.Text = "9,999,999";
            this.MinimumStockCnt2.Top = 0.5625F;
            this.MinimumStockCnt2.Width = 0.875F;
            // 
            // MaximumStockCnt2
            // 
            this.MaximumStockCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.MaximumStockCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.MaximumStockCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.MaximumStockCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.MaximumStockCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt2.DataField = "MaximumStockCnt2";
            this.MaximumStockCnt2.Height = 0.1875F;
            this.MaximumStockCnt2.Left = 3.875F;
            this.MaximumStockCnt2.MultiLine = false;
            this.MaximumStockCnt2.Name = "MaximumStockCnt2";
            this.MaximumStockCnt2.OutputFormat = resources.GetString( "MaximumStockCnt2.OutputFormat" );
            this.MaximumStockCnt2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.MaximumStockCnt2.Text = "9,999,999";
            this.MaximumStockCnt2.Top = 0.5625F;
            this.MaximumStockCnt2.Width = 0.875F;
            // 
            // StockCreateDate2
            // 
            this.StockCreateDate2.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCreateDate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate2.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCreateDate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate2.Border.RightColor = System.Drawing.Color.Black;
            this.StockCreateDate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate2.Border.TopColor = System.Drawing.Color.Black;
            this.StockCreateDate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate2.DataField = "StockCreateDate2";
            this.StockCreateDate2.Height = 0.1875F;
            this.StockCreateDate2.Left = 3.875F;
            this.StockCreateDate2.MultiLine = false;
            this.StockCreateDate2.Name = "StockCreateDate2";
            this.StockCreateDate2.OutputFormat = resources.GetString( "StockCreateDate2.OutputFormat" );
            this.StockCreateDate2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.StockCreateDate2.Text = "08/12/12";
            this.StockCreateDate2.Top = 0.75F;
            this.StockCreateDate2.Width = 0.875F;
            // 
            // ListPrice2
            // 
            this.ListPrice2.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice2.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice2.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice2.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice2.DataField = "ListPrice2";
            this.ListPrice2.Height = 0.1875F;
            this.ListPrice2.Left = 2.875F;
            this.ListPrice2.MultiLine = false;
            this.ListPrice2.Name = "ListPrice2";
            this.ListPrice2.OutputFormat = resources.GetString( "ListPrice2.OutputFormat" );
            this.ListPrice2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.ListPrice2.Text = "999,999,999";
            this.ListPrice2.Top = 0.75F;
            this.ListPrice2.Width = 0.875F;
            // 
            // WareHouseTitle3
            // 
            this.WareHouseTitle3.Border.BottomColor = System.Drawing.Color.Black;
            this.WareHouseTitle3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle3.Border.LeftColor = System.Drawing.Color.Black;
            this.WareHouseTitle3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle3.Border.RightColor = System.Drawing.Color.Black;
            this.WareHouseTitle3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle3.Border.TopColor = System.Drawing.Color.Black;
            this.WareHouseTitle3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle3.Height = 0.2F;
            this.WareHouseTitle3.Left = 5.3125F;
            this.WareHouseTitle3.MultiLine = false;
            this.WareHouseTitle3.Name = "WareHouseTitle3";
            this.WareHouseTitle3.OutputFormat = resources.GetString( "WareHouseTitle3.OutputFormat" );
            this.WareHouseTitle3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WareHouseTitle3.Text = "倉庫";
            this.WareHouseTitle3.Top = 0F;
            this.WareHouseTitle3.Width = 0.35F;
            // 
            // WarehouseCode3
            // 
            this.WarehouseCode3.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode3.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode3.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode3.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode3.DataField = "WarehouseCode3";
            this.WarehouseCode3.Height = 0.2F;
            this.WarehouseCode3.Left = 5.6875F;
            this.WarehouseCode3.MultiLine = false;
            this.WarehouseCode3.Name = "WarehouseCode3";
            this.WarehouseCode3.OutputFormat = resources.GetString( "WarehouseCode3.OutputFormat" );
            this.WarehouseCode3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseCode3.Text = "9999";
            this.WarehouseCode3.Top = 0F;
            this.WarehouseCode3.Width = 0.4F;
            // 
            // ShelfTitle3
            // 
            this.ShelfTitle3.Border.BottomColor = System.Drawing.Color.Black;
            this.ShelfTitle3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle3.Border.LeftColor = System.Drawing.Color.Black;
            this.ShelfTitle3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle3.Border.RightColor = System.Drawing.Color.Black;
            this.ShelfTitle3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle3.Border.TopColor = System.Drawing.Color.Black;
            this.ShelfTitle3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShelfTitle3.Height = 0.2F;
            this.ShelfTitle3.Left = 6.125F;
            this.ShelfTitle3.MultiLine = false;
            this.ShelfTitle3.Name = "ShelfTitle3";
            this.ShelfTitle3.OutputFormat = resources.GetString( "ShelfTitle3.OutputFormat" );
            this.ShelfTitle3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ShelfTitle3.Text = "棚番";
            this.ShelfTitle3.Top = 0F;
            this.ShelfTitle3.Width = 0.35F;
            // 
            // WarehouseShelfNo3
            // 
            this.WarehouseShelfNo3.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo3.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo3.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo3.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo3.DataField = "WarehouseShelfNo3";
            this.WarehouseShelfNo3.Height = 0.188F;
            this.WarehouseShelfNo3.Left = 6.5F;
            this.WarehouseShelfNo3.MultiLine = false;
            this.WarehouseShelfNo3.Name = "WarehouseShelfNo3";
            this.WarehouseShelfNo3.OutputFormat = resources.GetString( "WarehouseShelfNo3.OutputFormat" );
            this.WarehouseShelfNo3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseShelfNo3.Text = "99999999";
            this.WarehouseShelfNo3.Top = 0F;
            this.WarehouseShelfNo3.Width = 0.66F;
            // 
            // GoodsNo3
            // 
            this.GoodsNo3.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo3.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo3.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo3.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo3.DataField = "GoodsNo3";
            this.GoodsNo3.Height = 0.188F;
            this.GoodsNo3.Left = 5.3125F;
            this.GoodsNo3.MultiLine = false;
            this.GoodsNo3.Name = "GoodsNo3";
            this.GoodsNo3.OutputFormat = resources.GetString( "GoodsNo3.OutputFormat" );
            this.GoodsNo3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNo3.Text = "12345678901234567890";
            this.GoodsNo3.Top = 0.1875F;
            this.GoodsNo3.Width = 1.85F;
            // 
            // GoodsNameKana3
            // 
            this.GoodsNameKana3.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameKana3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana3.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameKana3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana3.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameKana3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana3.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameKana3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana3.DataField = "GoodsNameKana3";
            this.GoodsNameKana3.Height = 0.188F;
            this.GoodsNameKana3.Left = 5.3125F;
            this.GoodsNameKana3.MultiLine = false;
            this.GoodsNameKana3.Name = "GoodsNameKana3";
            this.GoodsNameKana3.OutputFormat = resources.GetString( "GoodsNameKana3.OutputFormat" );
            this.GoodsNameKana3.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GoodsNameKana3.Text = "123456789012345678901234";
            this.GoodsNameKana3.Top = 0.375F;
            this.GoodsNameKana3.Width = 1.85F;
            // 
            // MinimumStockCnt3
            // 
            this.MinimumStockCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.MinimumStockCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.MinimumStockCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.MinimumStockCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.MinimumStockCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt3.DataField = "MinimumStockCnt3";
            this.MinimumStockCnt3.Height = 0.1875F;
            this.MinimumStockCnt3.Left = 5.3125F;
            this.MinimumStockCnt3.MultiLine = false;
            this.MinimumStockCnt3.Name = "MinimumStockCnt3";
            this.MinimumStockCnt3.OutputFormat = resources.GetString( "MinimumStockCnt3.OutputFormat" );
            this.MinimumStockCnt3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.MinimumStockCnt3.Text = "9,999,999";
            this.MinimumStockCnt3.Top = 0.5625F;
            this.MinimumStockCnt3.Width = 0.875F;
            // 
            // MaximumStockCnt3
            // 
            this.MaximumStockCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.MaximumStockCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.MaximumStockCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.MaximumStockCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.MaximumStockCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt3.DataField = "MaximumStockCnt3";
            this.MaximumStockCnt3.Height = 0.1875F;
            this.MaximumStockCnt3.Left = 6.3125F;
            this.MaximumStockCnt3.MultiLine = false;
            this.MaximumStockCnt3.Name = "MaximumStockCnt3";
            this.MaximumStockCnt3.OutputFormat = resources.GetString( "MaximumStockCnt3.OutputFormat" );
            this.MaximumStockCnt3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.MaximumStockCnt3.Text = "9,999,999";
            this.MaximumStockCnt3.Top = 0.5625F;
            this.MaximumStockCnt3.Width = 0.875F;
            // 
            // StockCreateDate3
            // 
            this.StockCreateDate3.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCreateDate3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate3.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCreateDate3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate3.Border.RightColor = System.Drawing.Color.Black;
            this.StockCreateDate3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate3.Border.TopColor = System.Drawing.Color.Black;
            this.StockCreateDate3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate3.DataField = "StockCreateDate3";
            this.StockCreateDate3.Height = 0.1875F;
            this.StockCreateDate3.Left = 6.3125F;
            this.StockCreateDate3.MultiLine = false;
            this.StockCreateDate3.Name = "StockCreateDate3";
            this.StockCreateDate3.OutputFormat = resources.GetString( "StockCreateDate3.OutputFormat" );
            this.StockCreateDate3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.StockCreateDate3.Text = "08/12/12";
            this.StockCreateDate3.Top = 0.75F;
            this.StockCreateDate3.Width = 0.875F;
            // 
            // ListPrice3
            // 
            this.ListPrice3.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice3.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice3.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice3.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice3.DataField = "ListPrice3";
            this.ListPrice3.Height = 0.1875F;
            this.ListPrice3.Left = 5.3125F;
            this.ListPrice3.MultiLine = false;
            this.ListPrice3.Name = "ListPrice3";
            this.ListPrice3.OutputFormat = resources.GetString( "ListPrice3.OutputFormat" );
            this.ListPrice3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.ListPrice3.Text = "999,999,999";
            this.ListPrice3.Top = 0.75F;
            this.ListPrice3.Width = 0.875F;
            // 
            // InvisibleRow
            // 
            this.InvisibleRow.Border.BottomColor = System.Drawing.Color.Black;
            this.InvisibleRow.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvisibleRow.Border.LeftColor = System.Drawing.Color.Black;
            this.InvisibleRow.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvisibleRow.Border.RightColor = System.Drawing.Color.Black;
            this.InvisibleRow.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvisibleRow.Border.TopColor = System.Drawing.Color.Black;
            this.InvisibleRow.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.InvisibleRow.DataField = "InvisibleRow";
            this.InvisibleRow.Height = 0.2F;
            this.InvisibleRow.Left = 0.125F;
            this.InvisibleRow.MultiLine = false;
            this.InvisibleRow.Name = "InvisibleRow";
            this.InvisibleRow.OutputFormat = resources.GetString( "InvisibleRow.OutputFormat" );
            this.InvisibleRow.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.InvisibleRow.Text = "1";
            this.InvisibleRow.Top = 0.1875F;
            this.InvisibleRow.Visible = false;
            this.InvisibleRow.Width = 0.15F;
            // 
            // DataNum
            // 
            this.DataNum.Border.BottomColor = System.Drawing.Color.Black;
            this.DataNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataNum.Border.LeftColor = System.Drawing.Color.Black;
            this.DataNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataNum.Border.RightColor = System.Drawing.Color.Black;
            this.DataNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataNum.Border.TopColor = System.Drawing.Color.Black;
            this.DataNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DataNum.DataField = "DataNum";
            this.DataNum.Height = 0.2F;
            this.DataNum.Left = 0.125F;
            this.DataNum.MultiLine = false;
            this.DataNum.Name = "DataNum";
            this.DataNum.OutputFormat = resources.GetString( "DataNum.OutputFormat" );
            this.DataNum.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.DataNum.Text = "1";
            this.DataNum.Top = 0.45F;
            this.DataNum.Visible = false;
            this.DataNum.Width = 0.15F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Visible = false;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            this.reportFooter1.Visible = false;
            // 
            // pageHeader1
            // 
            this.pageHeader1.Height = 0.3F;
            this.pageHeader1.Name = "pageHeader1";
            // 
            // pageFooter1
            // 
            this.pageFooter1.Height = 0F;
            this.pageFooter1.Name = "pageFooter1";
            // 
            // PMZAI02053P_03A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 8.267716F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            this.PageSettings.PaperWidth = 11.69291F;
            this.PrintWidth = 7.675F;
            this.Sections.Add( this.reportHeader1 );
            this.Sections.Add( this.pageHeader1 );
            this.Sections.Add( this.detail );
            this.Sections.Add( this.pageFooter1 );
            this.Sections.Add( this.reportFooter1 );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 16pt; font-weight: bold; ", "Heading1", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 14pt; font-weight: bold; ", "Heading2", "Normal" ) );
            this.StyleSheet.Add( new DDCssLib.StyleSheetRule( "font-size: 13pt; font-weight: bold; ", "Heading3", "Normal" ) );
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfTitle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfTitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfTitle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvisibleRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
 
    }
}
