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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 出荷商品優良対応表帳票フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 出荷商品優良対応表帳票フォームクラスです。</br>
    /// <br>Programmer   : 30452 上野 俊治</br>
    /// <br>Date         : 2008.11.14</br>
    /// <br>Update Note  : 2008.12.19 30452 上野 俊治</br>
    /// <br>              ・品名の表示桁数を20桁に制限</br>
    /// <br>Update Note  : 2009.02.18 30452 上野 俊治</br>
    /// <br>              ・障害対応11281 棚番の0埋めを削除</br>
    /// <br>             :</br>
    /// </remarks>
    public class PMHNB02143P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {

        #region ■ コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB02143P_01A4C()
        {
            InitializeComponent();
        }
        #endregion

        #region ■ private変数
        private int _printCount;						// 印刷件数用カウンタ

        private int _extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;		// 抽出条件
        private int _pageFooterOutCode;				    // フッター出力区分
        private StringCollection _pageFooters;			// フッターメッセージ
        private SFCMN06002C _printInfo;					// 印刷情報クラス
        private string _pageHeaderTitle;				// フォームタイトル
        private string _pageHeaderSortOderTitle;		// ソート順

        private ShipGdsPrimeListCndtn _shipGdsPrimeListCndtn;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        // Disposeチェック用フラグ
        bool disposed = false;

        #region ■ ActiveReport生成

        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private GroupHeader GoodsMakerHeader;
        private GroupFooter GoodsMakerFooter;
        private GroupHeader GoodsMGroupHeader;
        private GroupFooter GoodsMGroupFooter;
        private GroupHeader BLGroupCodeHeader;
        private GroupFooter BLGroupCodeFooter;
        private Label tb_ReportTitle;
        private Line Line1;
        private Label Label3;
        private TextBox tb_PrintDate;
        private TextBox tb_PrintTime;
        private Label Label2;
        private TextBox tb_PrintPage;
        private SubReport Header_SubReport;
        private Line Line2;
        private Line line3;
        private TextBox Pure_BLGroupCode;
        private TextBox Pure_GoodsName;
        private TextBox Pure_GrossProfitRate;
        private TextBox Pure_StockTotalSalesCount;
        private TextBox Pure_OrderTotalSalesCount;
        private TextBox Pure_Separator1;
        private TextBox Parts1_GoodsNo;
        private TextBox Parts1_BLGroupCode;
        private TextBox Parts1_GrossProfitRate;
        private TextBox Parts1_StockTotalSalesCount;
        private TextBox Parts1_OrderTotalSalesCount;
        private TextBox Parts1_Separator2;
        private TextBox Parts2_GoodsNo;
        private TextBox Parts2_GrossProfitRate;
        private TextBox Parts2_StockTotalSalesCount;
        private TextBox Parts2_OrderTotalSalesCount;
        private TextBox Parts2_Separator2;
        private TextBox SecHd_SectionCode;
        private TextBox SecHd_SectionName;
        private Label Lb_SectionTitle;
        private Label label1;
        private Label label4;
        private TextBox Pure_WarehouseShelfNo;
        private TextBox Pure_GoodsNo;
        private TextBox Pure_GoodsPrice;
        private TextBox Pure_SupplierStock;
        private TextBox Parts1_GoodsPrice;
        private TextBox Parts1_SuplierCode;
        private TextBox Parts1_WarehouseShelfNo;
        private TextBox Parts1_MakerCode;
        private TextBox Parts1_Separator1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox textBox98;
        private TextBox textBox58;
        private TextBox textBox59;
        private TextBox textBox61;
        private TextBox textBox60;
        private TextBox MakFt_Pure_MakerCode;
        private TextBox MakFt_Pure_StockTotalSalesCountSum;
        private TextBox textBox63;
        private TextBox MakFt_Pure_OrderTotalSalesCountSum;
        private TextBox MakFt_Pure_GoodsMakerName;
        private Line line5;
        private Line line4;
        private Line line8;
        private Line line7;
        private Line line6;
        private TextBox MgrFt_Pure_GoodsMGroup;
        private TextBox MgrFt_Pure_StockTotalSalesCountSum;
        private TextBox textBox68;
        private TextBox MgrFt_Pure_OrderTotalSalesCountSum;
        private TextBox MgrFt_Pure_GoodsMGroupName;
        private TextBox GroFt_Pure_StockTotalSalesCountSum;
        private TextBox GroFt_Pure_BLGroupCode;
        private TextBox textBox73;
        private TextBox GroFt_Pure_OrderTotalSalesCountSum;
        private TextBox GroFt_Pure_BLGroupCodeName;
        private TextBox GroFt_Parts_StockTotalSalesCountSum;
        private TextBox textBox77;
        private TextBox GroFt_Parts_OrderTotalSalesCountSum;
        private TextBox MakFt_Parts_StockTotalSalesCountSum;
        private TextBox textBox83;
        private TextBox MakFt_Parts_OrderTotalSalesCountSum;
        private TextBox MgrFt_Parts_StockTotalSalesCountSum;
        private TextBox textBox80;
        private TextBox MgrFt_Parts_OrderTotalSalesCountSum;
        private TextBox GraFt_Pure_StockTotalSalesCountSum;
        private TextBox textBox89;
        private TextBox GraFt_Pure_OrderTotalSalesCountSum;
        private TextBox SecFt_Pure_StockTotalSalesCountSum;
        private TextBox textBox86;
        private TextBox SecFt_Pure_OrderTotalSalesCountSum;
        private SubReport Footer_SubReport;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private TextBox Parts1_SupplierStock;
        private TextBox Parts2_WarehouseShelfNo;
        private TextBox Parts2_SuplierCode;
        private TextBox Parts2_MakerCode;
        private TextBox Parts2_Separator1;
        private TextBox Parts2_GoodsPrice;
        private TextBox Parts2_SupplierStock;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private TextBox Pure_StockTotalSalesCountSum;
        private TextBox Pure_OrderTotalSalesCountSum;
        private TextBox Parts_StockTotalSalesCountSum;
        private TextBox Parts_OrderTotalSalesCountSum;
        private Line SecHd_line;
        private TextBox GraFt_Parts_StockTotalSalesCountSum;
        private TextBox textBox5;
        private TextBox GraFt_Parts_OrderTotalSalesCountSum;
        private TextBox SecFt_Parts_StockTotalSalesCountSum;
        private TextBox textBox2;
        private TextBox SecFt_Parts_OrderTotalSalesCountSum;
        private TextBox Parts2_BLGroupCode;
        private TextBox PartsCount;
        private TextBox RowNumber;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

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
                this._shipGdsPrimeListCndtn = (ShipGdsPrimeListCndtn)this._printInfo.jyoken;
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
                // TODO:  MAZAI02032P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  MAZAI02032P_01A4C.WatermarkMode setter 実装を追加します。
            }
        }
        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeCommon メンバ

        #region ■ privateメソッド
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // 項目の名称をセット

            // タイトル項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;

            //-------------------------------------------------------
            // グループヘッダ表示・DataField設定
            //-------------------------------------------------------
            #region [グループヘッダ設定]
            if (_shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.Maker)
            {
                this.GoodsMakerHeader.Visible = true;
                this.GoodsMakerFooter.Visible = true;
                this.GoodsMakerHeader.DataField = PMHNB02145EB.ct_Col_Pure_MakerCode;
            }
            else if (_shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup)
            {
                this.GoodsMGroupHeader.Visible = true;
                this.GoodsMGroupFooter.Visible = true;
                this.GoodsMGroupHeader.DataField = PMHNB02145EB.ct_Col_Pure_GoodsMGroup;
            }
            else // グループコード別
            {
                this.BLGroupCodeHeader.Visible = true;
                this.BLGroupCodeFooter.Visible = true;
                this.BLGroupCodeHeader.DataField = PMHNB02145EB.ct_Col_Pure_BLGroupCode;
            }
            #endregion

            //-------------------------------------------------------
            // 改頁設定
            // 0:拠点毎 1:順位毎 2:しない
            //-------------------------------------------------------
            #region [改頁設定]
            switch (_shipGdsPrimeListCndtn.NewPageDiv)
            {
                case ShipGdsPrimeListCndtn.NewPageDivState.Section:
                    {
                        SectionHeader.NewPage = NewPage.Before;
                        break;
                    }
                case ShipGdsPrimeListCndtn.NewPageDivState.Order:
                    {
                        if (_shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.Maker)
                        {
                            this.GoodsMakerHeader.NewPage = NewPage.Before;
                        }
                        else if (_shipGdsPrimeListCndtn.RankSection == ShipGdsPrimeListCndtn.RankSectionState.GoodsMGroup)
                        {
                            this.GoodsMGroupHeader.NewPage = NewPage.Before;
                        }
                        else
                        {
                            this.BLGroupCodeHeader.NewPage = NewPage.Before;
                        }
                        break;
                    }
            }
            #endregion
        }

        #endregion

        #region ■ コントロールイベント
        /// <summary>
        /// PMHNB02143P_01A4C_ReportStartイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB02143P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// PageHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageHeader_Format(object sender, EventArgs e)
        {
            //現在の時刻を取得
            DateTime now = DateTime.Now;
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // 作成時間
            this.tb_PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// ExtraHeader_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtraHeader_Format(object sender, EventArgs e)
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

        /// <summary>
        /// SectionHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_BeforePrint(object sender, EventArgs e)
        {
            // 拠点コードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.SecHd_SectionCode.Text)
                || this.SecHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SecHd_SectionCode.Text = string.Empty;
                this.SecHd_SectionName.Text = string.Empty;
            }
        }

        /// <summary>
        /// detail_AfterPrintイベント
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

        /// <summary>
        /// detail_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // グループコードがゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.Pure_BLGroupCode.Text)
                || this.Pure_BLGroupCode.Text.PadLeft(5, '0') == "00000")
            {
                this.Pure_BLGroupCode.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.Parts1_BLGroupCode.Text)
                || this.Parts1_BLGroupCode.Text.PadLeft(5, '0') == "00000")
            {
                this.Parts1_BLGroupCode.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.Parts2_BLGroupCode.Text)
                || this.Parts2_BLGroupCode.Text.PadLeft(5, '0') == "00000")
            {
                this.Parts2_BLGroupCode.Text = string.Empty;
            }

            // --- ADD 2008/12/19 -------------------------------->>>>>
            // 表示桁数の制限
            // 品名
            if (!string.IsNullOrEmpty(this.Pure_GoodsName.Text)
                && this.Pure_GoodsName.Text.Length > 20)
            {
                // 表示は20文字まで
                this.Pure_GoodsName.Text = this.Pure_GoodsName.Text.Substring(0, 20);
            }
            // --- ADD 2008/12/19 --------------------------------<<<<<

            #region 純正品表示制御
            // 同明細1行目の場合のみ純正品を表示
            if (this.RowNumber.Text == "0")
            {
                // 純正品を表示
                this.Pure_WarehouseShelfNo.Visible = true;
                this.Pure_GoodsNo.Visible = true;
                this.Pure_BLGroupCode.Visible = true;
                this.Pure_GoodsName.Visible = true;
                this.Pure_GrossProfitRate.Visible = true;
                this.Pure_GoodsPrice.Visible = true;
                this.Pure_SupplierStock.Visible = true;
                this.Pure_StockTotalSalesCount.Visible = true;
                this.Pure_Separator1.Visible = true;
                this.Pure_OrderTotalSalesCount.Visible = true;
            }
            else
            {
                // 純正品を非表示
                this.Pure_WarehouseShelfNo.Visible = false;
                this.Pure_GoodsNo.Visible = false;
                this.Pure_BLGroupCode.Visible = false;
                this.Pure_GoodsName.Visible = false;
                this.Pure_GrossProfitRate.Visible = false;
                this.Pure_GoodsPrice.Visible = false;
                this.Pure_SupplierStock.Visible = false;
                this.Pure_StockTotalSalesCount.Visible = false;
                this.Pure_Separator1.Visible = false;
                this.Pure_OrderTotalSalesCount.Visible = false;
            }
            #endregion

            #region 優良品表示制御
            // 1行に含まれる優良品数により、表示・非表示の制御
            if (this.PartsCount.Text == "0")
            {
                // 優良品1を非表示
                this.Parts1_WarehouseShelfNo.Visible = false;
                this.Parts1_SuplierCode.Visible = false;
                this.Parts1_Separator1.Visible = false;
                this.Parts1_MakerCode.Visible = false;
                this.Parts1_BLGroupCode.Visible = false;
                this.Parts1_GoodsNo.Visible = false;
                this.Parts1_GoodsPrice.Visible = false;
                this.Parts1_GrossProfitRate.Visible = false;
                this.Parts1_SupplierStock.Visible = false;
                this.Parts1_StockTotalSalesCount.Visible = false;
                this.Parts1_Separator2.Visible = false;
                this.Parts1_OrderTotalSalesCount.Visible = false;

                // 優良品2を非表示
                this.Parts2_WarehouseShelfNo.Visible = false;
                this.Parts2_SuplierCode.Visible = false;
                this.Parts2_Separator1.Visible = false;
                this.Parts2_MakerCode.Visible = false;
                this.Parts2_BLGroupCode.Visible = false;
                this.Parts2_GoodsNo.Visible = false;
                this.Parts2_GoodsPrice.Visible = false;
                this.Parts2_GrossProfitRate.Visible = false;
                this.Parts2_SupplierStock.Visible = false;
                this.Parts2_StockTotalSalesCount.Visible = false;
                this.Parts2_Separator2.Visible = false;
                this.Parts2_OrderTotalSalesCount.Visible = false;
            }
            else if (this.PartsCount.Text == "1")
            {
                // 優良品1を表示
                this.Parts1_WarehouseShelfNo.Visible = true;
                this.Parts1_SuplierCode.Visible = true;
                this.Parts1_Separator1.Visible = true;
                this.Parts1_MakerCode.Visible = true;
                this.Parts1_BLGroupCode.Visible = true;
                this.Parts1_GoodsNo.Visible = true;
                this.Parts1_GoodsPrice.Visible = true;
                this.Parts1_GrossProfitRate.Visible = true;
                this.Parts1_SupplierStock.Visible = true;
                this.Parts1_StockTotalSalesCount.Visible = true;
                this.Parts1_Separator2.Visible = true;
                this.Parts1_OrderTotalSalesCount.Visible = true;

                // 優良品2を非表示
                this.Parts2_WarehouseShelfNo.Visible = false;
                this.Parts2_SuplierCode.Visible = false;
                this.Parts2_Separator1.Visible = false;
                this.Parts2_MakerCode.Visible = false;
                this.Parts2_BLGroupCode.Visible = false;
                this.Parts2_GoodsNo.Visible = false;
                this.Parts2_GoodsPrice.Visible = false;
                this.Parts2_GrossProfitRate.Visible = false;
                this.Parts2_SupplierStock.Visible = false;
                this.Parts2_StockTotalSalesCount.Visible = false;
                this.Parts2_Separator2.Visible = false;
                this.Parts2_OrderTotalSalesCount.Visible = false;
            }
            else if (this.PartsCount.Text == "2")
            {
                // 優良品1を表示
                this.Parts1_WarehouseShelfNo.Visible = true;
                this.Parts1_SuplierCode.Visible = true;
                this.Parts1_Separator1.Visible = true;
                this.Parts1_MakerCode.Visible = true;
                this.Parts1_BLGroupCode.Visible = true;
                this.Parts1_GoodsNo.Visible = true;
                this.Parts1_GoodsPrice.Visible = true;
                this.Parts1_GrossProfitRate.Visible = true;
                this.Parts1_SupplierStock.Visible = true;
                this.Parts1_StockTotalSalesCount.Visible = true;
                this.Parts1_Separator2.Visible = true;
                this.Parts1_OrderTotalSalesCount.Visible = true;

                // 優良品2を表示
                this.Parts2_WarehouseShelfNo.Visible = true;
                this.Parts2_SuplierCode.Visible = true;
                this.Parts2_Separator1.Visible = true;
                this.Parts2_MakerCode.Visible = true;
                this.Parts2_BLGroupCode.Visible = true;
                this.Parts2_GoodsNo.Visible = true;
                this.Parts2_GoodsPrice.Visible = true;
                this.Parts2_GrossProfitRate.Visible = true;
                this.Parts2_SupplierStock.Visible = true;
                this.Parts2_StockTotalSalesCount.Visible = true;
                this.Parts2_Separator2.Visible = true;
                this.Parts2_OrderTotalSalesCount.Visible = true;
            }
            #endregion
        }

        /// <summary>
        /// BLGroupCodeFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupCodeFooter_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.GroFt_Pure_BLGroupCode.Text)
                || this.GroFt_Pure_BLGroupCode.Text.PadLeft(5, '0') == "00000")
            {
                this.GroFt_Pure_BLGroupCode.Text = string.Empty;
                this.GroFt_Pure_BLGroupCodeName.Text = string.Empty;
            }
        }

        /// <summary>
        /// GoodsMGroupFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.MgrFt_Pure_GoodsMGroup.Text)
                || this.MgrFt_Pure_GoodsMGroup.Text.PadLeft(4, '0') == "0000")
            {
                this.MgrFt_Pure_GoodsMGroup.Text = string.Empty;
                this.MgrFt_Pure_GoodsMGroupName.Text = string.Empty;
            }
        }

        /// <summary>
        /// GoodsMakerFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMakerFooter_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.MakFt_Pure_MakerCode.Text)
                || this.MakFt_Pure_MakerCode.Text.PadLeft(2, '0') == "00")
            {
                this.MakFt_Pure_MakerCode.Text = string.Empty;
                this.MakFt_Pure_GoodsMakerName.Text = string.Empty;
            }
        }

        /// <summary>
        /// ページフッタフォーマットイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.03.17</br>
        /// </remarks>
        private void pageFooter_Format(object sender, EventArgs e)
        {
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッターレポート作成
                ListCommon_PageFooter rpt = new ListCommon_PageFooter();

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
            }
        }
        #endregion

        #region ActiveReport デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMHNB02143P_01A4C));
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.Pure_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Pure_GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.Pure_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Pure_StockTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Pure_OrderTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Pure_Separator1 = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_StockTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_OrderTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_Separator2 = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_StockTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_OrderTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_Separator2 = new DataDynamics.ActiveReports.TextBox();
            this.Pure_WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.Pure_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Pure_GoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.Pure_SupplierStock = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_GoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_SuplierCode = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_MakerCode = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_Separator1 = new DataDynamics.ActiveReports.TextBox();
            this.Parts1_SupplierStock = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_SuplierCode = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_MakerCode = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_Separator1 = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_GoodsPrice = new DataDynamics.ActiveReports.TextBox();
            this.Parts2_SupplierStock = new DataDynamics.ActiveReports.TextBox();
            this.Pure_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.Pure_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.Parts_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.Parts_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_line = new DataDynamics.ActiveReports.Line();
            this.PartsCount = new DataDynamics.ActiveReports.TextBox();
            this.RowNumber = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Lb_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.label33 = new DataDynamics.ActiveReports.Label();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.GraFt_Pure_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox89 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_Pure_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_Parts_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.GraFt_Parts_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SecHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SecHd_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.SecFt_Pure_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox86 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_Pure_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_Parts_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_Parts_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox98 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_Pure_MakerCode = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_Pure_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_Pure_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_Pure_GoodsMakerName = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.MakFt_Parts_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox83 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_Parts_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.MgrFt_Pure_GoodsMGroup = new DataDynamics.ActiveReports.TextBox();
            this.MgrFt_Pure_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox68 = new DataDynamics.ActiveReports.TextBox();
            this.MgrFt_Pure_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.MgrFt_Pure_GoodsMGroupName = new DataDynamics.ActiveReports.TextBox();
            this.MgrFt_Parts_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox80 = new DataDynamics.ActiveReports.TextBox();
            this.MgrFt_Parts_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCodeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGroupCodeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.GroFt_Pure_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.GroFt_Pure_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.textBox73 = new DataDynamics.ActiveReports.TextBox();
            this.GroFt_Pure_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.GroFt_Pure_BLGroupCodeName = new DataDynamics.ActiveReports.TextBox();
            this.GroFt_Parts_StockTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            this.textBox77 = new DataDynamics.ActiveReports.TextBox();
            this.GroFt_Parts_OrderTotalSalesCountSum = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_StockTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_OrderTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_Separator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_StockTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_OrderTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_Separator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_StockTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_OrderTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_Separator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_SupplierStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_GoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_SuplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_MakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_Separator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_SupplierStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_SuplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_MakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_Separator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_GoodsPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_SupplierStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Pure_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Pure_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Parts_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Parts_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Pure_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Pure_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Parts_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Parts_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_MakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_GoodsMakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Parts_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox83)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Parts_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_GoodsMGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Parts_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Parts_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_BLGroupCodeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Parts_StockTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Parts_OrderTotalSalesCountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.Label3,
            this.tb_PrintDate,
            this.tb_PrintTime,
            this.Label2,
            this.tb_PrintPage});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // tb_ReportTitle
            // 
            this.tb_ReportTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.219F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "出荷商品優良対応表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.21F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.21F;
            this.Line1.Y2 = 0.21F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.938F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.063F;
            this.Label3.Width = 0.625F;
            // 
            // tb_PrintDate
            // 
            this.tb_PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.CanShrink = true;
            this.tb_PrintDate.Height = 0.15625F;
            this.tb_PrintDate.Left = 8.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.063F;
            this.tb_PrintDate.Width = 0.9375F;
            // 
            // tb_PrintTime
            // 
            this.tb_PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Height = 0.125F;
            this.tb_PrintTime.Left = 9.438F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.063F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.938F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.063F;
            this.Label2.Width = 0.5F;
            // 
            // tb_PrintPage
            // 
            this.tb_PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.CanShrink = true;
            this.tb_PrintPage.Height = 0.15625F;
            this.tb_PrintPage.Left = 10.438F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.063F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Pure_BLGroupCode,
            this.Pure_GoodsName,
            this.Pure_GrossProfitRate,
            this.Pure_StockTotalSalesCount,
            this.Pure_OrderTotalSalesCount,
            this.Pure_Separator1,
            this.Parts1_GoodsNo,
            this.Parts1_BLGroupCode,
            this.Parts1_GrossProfitRate,
            this.Parts1_StockTotalSalesCount,
            this.Parts1_OrderTotalSalesCount,
            this.Parts1_Separator2,
            this.Parts2_GoodsNo,
            this.Parts2_BLGroupCode,
            this.Parts2_GrossProfitRate,
            this.Parts2_StockTotalSalesCount,
            this.Parts2_OrderTotalSalesCount,
            this.Parts2_Separator2,
            this.Pure_WarehouseShelfNo,
            this.Pure_GoodsNo,
            this.Pure_GoodsPrice,
            this.Pure_SupplierStock,
            this.Parts1_GoodsPrice,
            this.Parts1_SuplierCode,
            this.Parts1_WarehouseShelfNo,
            this.Parts1_MakerCode,
            this.Parts1_Separator1,
            this.Parts1_SupplierStock,
            this.Parts2_WarehouseShelfNo,
            this.Parts2_SuplierCode,
            this.Parts2_MakerCode,
            this.Parts2_Separator1,
            this.Parts2_GoodsPrice,
            this.Parts2_SupplierStock,
            this.Pure_StockTotalSalesCountSum,
            this.Pure_OrderTotalSalesCountSum,
            this.Parts_StockTotalSalesCountSum,
            this.Parts_OrderTotalSalesCountSum,
            this.SecHd_line,
            this.PartsCount,
            this.RowNumber});
            this.detail.Height = 0.7083333F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.AfterPrint += new System.EventHandler(this.detail_AfterPrint);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // Pure_BLGroupCode
            // 
            this.Pure_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_BLGroupCode.DataField = "Pure_BLGroupCode";
            this.Pure_BLGroupCode.Height = 0.16F;
            this.Pure_BLGroupCode.Left = 0.0625F;
            this.Pure_BLGroupCode.MultiLine = false;
            this.Pure_BLGroupCode.Name = "Pure_BLGroupCode";
            this.Pure_BLGroupCode.OutputFormat = resources.GetString("Pure_BLGroupCode.OutputFormat");
            this.Pure_BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Pure_BLGroupCode.Text = "12345";
            this.Pure_BLGroupCode.Top = 0.25F;
            this.Pure_BLGroupCode.Width = 0.32F;
            // 
            // Pure_GoodsName
            // 
            this.Pure_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsName.DataField = "Pure_GoodsName";
            this.Pure_GoodsName.Height = 0.156F;
            this.Pure_GoodsName.Left = 0.375F;
            this.Pure_GoodsName.MultiLine = false;
            this.Pure_GoodsName.Name = "Pure_GoodsName";
            this.Pure_GoodsName.OutputFormat = resources.GetString("Pure_GoodsName.OutputFormat");
            this.Pure_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Pure_GoodsName.Text = "12345678901234567890";
            this.Pure_GoodsName.Top = 0.25F;
            this.Pure_GoodsName.Width = 1.15F;
            // 
            // Pure_GrossProfitRate
            // 
            this.Pure_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GrossProfitRate.DataField = "Pure_GrossProfitRate";
            this.Pure_GrossProfitRate.Height = 0.156F;
            this.Pure_GrossProfitRate.Left = 1.5F;
            this.Pure_GrossProfitRate.MultiLine = false;
            this.Pure_GrossProfitRate.Name = "Pure_GrossProfitRate";
            this.Pure_GrossProfitRate.OutputFormat = resources.GetString("Pure_GrossProfitRate.OutputFormat");
            this.Pure_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Pure_GrossProfitRate.Text = "100.00";
            this.Pure_GrossProfitRate.Top = 0.25F;
            this.Pure_GrossProfitRate.Width = 0.4F;
            // 
            // Pure_StockTotalSalesCount
            // 
            this.Pure_StockTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCount.DataField = "Pure_StockTotalSalesCount";
            this.Pure_StockTotalSalesCount.Height = 0.156F;
            this.Pure_StockTotalSalesCount.Left = 1.9375F;
            this.Pure_StockTotalSalesCount.MultiLine = false;
            this.Pure_StockTotalSalesCount.Name = "Pure_StockTotalSalesCount";
            this.Pure_StockTotalSalesCount.OutputFormat = resources.GetString("Pure_StockTotalSalesCount.OutputFormat");
            this.Pure_StockTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Pure_StockTotalSalesCount.Text = "1,234,567.00";
            this.Pure_StockTotalSalesCount.Top = 0.25F;
            this.Pure_StockTotalSalesCount.Width = 0.7F;
            // 
            // Pure_OrderTotalSalesCount
            // 
            this.Pure_OrderTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCount.DataField = "Pure_OrderTotalSalesCount";
            this.Pure_OrderTotalSalesCount.Height = 0.156F;
            this.Pure_OrderTotalSalesCount.Left = 2.75F;
            this.Pure_OrderTotalSalesCount.MultiLine = false;
            this.Pure_OrderTotalSalesCount.Name = "Pure_OrderTotalSalesCount";
            this.Pure_OrderTotalSalesCount.OutputFormat = resources.GetString("Pure_OrderTotalSalesCount.OutputFormat");
            this.Pure_OrderTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Pure_OrderTotalSalesCount.Text = "1,234,567.00";
            this.Pure_OrderTotalSalesCount.Top = 0.25F;
            this.Pure_OrderTotalSalesCount.Width = 0.7F;
            // 
            // Pure_Separator1
            // 
            this.Pure_Separator1.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_Separator1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_Separator1.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_Separator1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_Separator1.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_Separator1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_Separator1.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_Separator1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_Separator1.Height = 0.156F;
            this.Pure_Separator1.Left = 2.625F;
            this.Pure_Separator1.MultiLine = false;
            this.Pure_Separator1.Name = "Pure_Separator1";
            this.Pure_Separator1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.Pure_Separator1.Text = "/";
            this.Pure_Separator1.Top = 0.25F;
            this.Pure_Separator1.Width = 0.1F;
            // 
            // Parts1_GoodsNo
            // 
            this.Parts1_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsNo.DataField = "Parts1_GoodsNo";
            this.Parts1_GoodsNo.Height = 0.156F;
            this.Parts1_GoodsNo.Left = 3.8125F;
            this.Parts1_GoodsNo.MultiLine = false;
            this.Parts1_GoodsNo.Name = "Parts1_GoodsNo";
            this.Parts1_GoodsNo.OutputFormat = resources.GetString("Parts1_GoodsNo.OutputFormat");
            this.Parts1_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Parts1_GoodsNo.Text = "123456789012345678901234";
            this.Parts1_GoodsNo.Top = 0.25F;
            this.Parts1_GoodsNo.Width = 1.4F;
            // 
            // Parts1_BLGroupCode
            // 
            this.Parts1_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_BLGroupCode.DataField = "Parts1_BLGroupCode";
            this.Parts1_BLGroupCode.Height = 0.16F;
            this.Parts1_BLGroupCode.Left = 3.5F;
            this.Parts1_BLGroupCode.MultiLine = false;
            this.Parts1_BLGroupCode.Name = "Parts1_BLGroupCode";
            this.Parts1_BLGroupCode.OutputFormat = resources.GetString("Parts1_BLGroupCode.OutputFormat");
            this.Parts1_BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts1_BLGroupCode.Text = "12345";
            this.Parts1_BLGroupCode.Top = 0.25F;
            this.Parts1_BLGroupCode.Width = 0.32F;
            // 
            // Parts1_GrossProfitRate
            // 
            this.Parts1_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GrossProfitRate.DataField = "Parts1_GrossProfitRate";
            this.Parts1_GrossProfitRate.Height = 0.156F;
            this.Parts1_GrossProfitRate.Left = 5.1875F;
            this.Parts1_GrossProfitRate.MultiLine = false;
            this.Parts1_GrossProfitRate.Name = "Parts1_GrossProfitRate";
            this.Parts1_GrossProfitRate.OutputFormat = resources.GetString("Parts1_GrossProfitRate.OutputFormat");
            this.Parts1_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Parts1_GrossProfitRate.Text = "100.00";
            this.Parts1_GrossProfitRate.Top = 0.25F;
            this.Parts1_GrossProfitRate.Width = 0.4F;
            // 
            // Parts1_StockTotalSalesCount
            // 
            this.Parts1_StockTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_StockTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_StockTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_StockTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_StockTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_StockTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_StockTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_StockTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_StockTotalSalesCount.DataField = "Parts1_StockTotalSalesCount";
            this.Parts1_StockTotalSalesCount.Height = 0.156F;
            this.Parts1_StockTotalSalesCount.Left = 5.625F;
            this.Parts1_StockTotalSalesCount.MultiLine = false;
            this.Parts1_StockTotalSalesCount.Name = "Parts1_StockTotalSalesCount";
            this.Parts1_StockTotalSalesCount.OutputFormat = resources.GetString("Parts1_StockTotalSalesCount.OutputFormat");
            this.Parts1_StockTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts1_StockTotalSalesCount.Text = "1,234,567.00";
            this.Parts1_StockTotalSalesCount.Top = 0.25F;
            this.Parts1_StockTotalSalesCount.Width = 0.7F;
            // 
            // Parts1_OrderTotalSalesCount
            // 
            this.Parts1_OrderTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_OrderTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_OrderTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_OrderTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_OrderTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_OrderTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_OrderTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_OrderTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_OrderTotalSalesCount.DataField = "Parts1_OrderTotalSalesCount";
            this.Parts1_OrderTotalSalesCount.Height = 0.156F;
            this.Parts1_OrderTotalSalesCount.Left = 6.4375F;
            this.Parts1_OrderTotalSalesCount.MultiLine = false;
            this.Parts1_OrderTotalSalesCount.Name = "Parts1_OrderTotalSalesCount";
            this.Parts1_OrderTotalSalesCount.OutputFormat = resources.GetString("Parts1_OrderTotalSalesCount.OutputFormat");
            this.Parts1_OrderTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts1_OrderTotalSalesCount.Text = "1,234,567.00";
            this.Parts1_OrderTotalSalesCount.Top = 0.25F;
            this.Parts1_OrderTotalSalesCount.Width = 0.7F;
            // 
            // Parts1_Separator2
            // 
            this.Parts1_Separator2.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_Separator2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator2.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_Separator2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator2.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_Separator2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator2.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_Separator2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator2.Height = 0.156F;
            this.Parts1_Separator2.Left = 6.3125F;
            this.Parts1_Separator2.MultiLine = false;
            this.Parts1_Separator2.Name = "Parts1_Separator2";
            this.Parts1_Separator2.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts1_Separator2.Text = "/";
            this.Parts1_Separator2.Top = 0.25F;
            this.Parts1_Separator2.Width = 0.1F;
            // 
            // Parts2_GoodsNo
            // 
            this.Parts2_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsNo.DataField = "Parts2_GoodsNo";
            this.Parts2_GoodsNo.Height = 0.156F;
            this.Parts2_GoodsNo.Left = 7.5F;
            this.Parts2_GoodsNo.MultiLine = false;
            this.Parts2_GoodsNo.Name = "Parts2_GoodsNo";
            this.Parts2_GoodsNo.OutputFormat = resources.GetString("Parts2_GoodsNo.OutputFormat");
            this.Parts2_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Parts2_GoodsNo.Text = "123456789012345678901234";
            this.Parts2_GoodsNo.Top = 0.25F;
            this.Parts2_GoodsNo.Width = 1.4F;
            // 
            // Parts2_BLGroupCode
            // 
            this.Parts2_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_BLGroupCode.DataField = "Parts2_BLGroupCode";
            this.Parts2_BLGroupCode.Height = 0.16F;
            this.Parts2_BLGroupCode.Left = 7.1875F;
            this.Parts2_BLGroupCode.MultiLine = false;
            this.Parts2_BLGroupCode.Name = "Parts2_BLGroupCode";
            this.Parts2_BLGroupCode.OutputFormat = resources.GetString("Parts2_BLGroupCode.OutputFormat");
            this.Parts2_BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts2_BLGroupCode.Text = "12345";
            this.Parts2_BLGroupCode.Top = 0.25F;
            this.Parts2_BLGroupCode.Width = 0.32F;
            // 
            // Parts2_GrossProfitRate
            // 
            this.Parts2_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GrossProfitRate.DataField = "Parts2_GrossProfitRate";
            this.Parts2_GrossProfitRate.Height = 0.156F;
            this.Parts2_GrossProfitRate.Left = 8.875F;
            this.Parts2_GrossProfitRate.MultiLine = false;
            this.Parts2_GrossProfitRate.Name = "Parts2_GrossProfitRate";
            this.Parts2_GrossProfitRate.OutputFormat = resources.GetString("Parts2_GrossProfitRate.OutputFormat");
            this.Parts2_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.Parts2_GrossProfitRate.Text = "100.00";
            this.Parts2_GrossProfitRate.Top = 0.25F;
            this.Parts2_GrossProfitRate.Width = 0.4F;
            // 
            // Parts2_StockTotalSalesCount
            // 
            this.Parts2_StockTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_StockTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_StockTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_StockTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_StockTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_StockTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_StockTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_StockTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_StockTotalSalesCount.DataField = "Parts2_StockTotalSalesCount";
            this.Parts2_StockTotalSalesCount.Height = 0.156F;
            this.Parts2_StockTotalSalesCount.Left = 9.3125F;
            this.Parts2_StockTotalSalesCount.MultiLine = false;
            this.Parts2_StockTotalSalesCount.Name = "Parts2_StockTotalSalesCount";
            this.Parts2_StockTotalSalesCount.OutputFormat = resources.GetString("Parts2_StockTotalSalesCount.OutputFormat");
            this.Parts2_StockTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts2_StockTotalSalesCount.Text = "1,234,567.00";
            this.Parts2_StockTotalSalesCount.Top = 0.25F;
            this.Parts2_StockTotalSalesCount.Width = 0.7F;
            // 
            // Parts2_OrderTotalSalesCount
            // 
            this.Parts2_OrderTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_OrderTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_OrderTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_OrderTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_OrderTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_OrderTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_OrderTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_OrderTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_OrderTotalSalesCount.DataField = "Parts2_OrderTotalSalesCount";
            this.Parts2_OrderTotalSalesCount.Height = 0.156F;
            this.Parts2_OrderTotalSalesCount.Left = 10.125F;
            this.Parts2_OrderTotalSalesCount.MultiLine = false;
            this.Parts2_OrderTotalSalesCount.Name = "Parts2_OrderTotalSalesCount";
            this.Parts2_OrderTotalSalesCount.OutputFormat = resources.GetString("Parts2_OrderTotalSalesCount.OutputFormat");
            this.Parts2_OrderTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts2_OrderTotalSalesCount.Text = "1,234,567.00";
            this.Parts2_OrderTotalSalesCount.Top = 0.25F;
            this.Parts2_OrderTotalSalesCount.Width = 0.7F;
            // 
            // Parts2_Separator2
            // 
            this.Parts2_Separator2.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_Separator2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator2.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_Separator2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator2.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_Separator2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator2.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_Separator2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator2.Height = 0.156F;
            this.Parts2_Separator2.Left = 10F;
            this.Parts2_Separator2.MultiLine = false;
            this.Parts2_Separator2.Name = "Parts2_Separator2";
            this.Parts2_Separator2.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts2_Separator2.Text = "/";
            this.Parts2_Separator2.Top = 0.25F;
            this.Parts2_Separator2.Width = 0.1F;
            // 
            // Pure_WarehouseShelfNo
            // 
            this.Pure_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_WarehouseShelfNo.DataField = "Pure_WarehouseShelfNo";
            this.Pure_WarehouseShelfNo.Height = 0.16F;
            this.Pure_WarehouseShelfNo.Left = 0.0625F;
            this.Pure_WarehouseShelfNo.MultiLine = false;
            this.Pure_WarehouseShelfNo.Name = "Pure_WarehouseShelfNo";
            this.Pure_WarehouseShelfNo.OutputFormat = resources.GetString("Pure_WarehouseShelfNo.OutputFormat");
            this.Pure_WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Pure_WarehouseShelfNo.Text = "12345678";
            this.Pure_WarehouseShelfNo.Top = 0.0625F;
            this.Pure_WarehouseShelfNo.Width = 0.5F;
            // 
            // Pure_GoodsNo
            // 
            this.Pure_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsNo.DataField = "Pure_GoodsNo";
            this.Pure_GoodsNo.Height = 0.156F;
            this.Pure_GoodsNo.Left = 0.625F;
            this.Pure_GoodsNo.MultiLine = false;
            this.Pure_GoodsNo.Name = "Pure_GoodsNo";
            this.Pure_GoodsNo.OutputFormat = resources.GetString("Pure_GoodsNo.OutputFormat");
            this.Pure_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Pure_GoodsNo.Text = "123456789012345678901234";
            this.Pure_GoodsNo.Top = 0.0625F;
            this.Pure_GoodsNo.Width = 1.4F;
            // 
            // Pure_GoodsPrice
            // 
            this.Pure_GoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_GoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_GoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_GoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_GoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_GoodsPrice.DataField = "Pure_GoodsPrice";
            this.Pure_GoodsPrice.Height = 0.156F;
            this.Pure_GoodsPrice.Left = 2.0625F;
            this.Pure_GoodsPrice.MultiLine = false;
            this.Pure_GoodsPrice.Name = "Pure_GoodsPrice";
            this.Pure_GoodsPrice.OutputFormat = resources.GetString("Pure_GoodsPrice.OutputFormat");
            this.Pure_GoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Pure_GoodsPrice.Text = "1,234,567";
            this.Pure_GoodsPrice.Top = 0.0625F;
            this.Pure_GoodsPrice.Width = 0.55F;
            // 
            // Pure_SupplierStock
            // 
            this.Pure_SupplierStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_SupplierStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_SupplierStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_SupplierStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_SupplierStock.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_SupplierStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_SupplierStock.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_SupplierStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_SupplierStock.DataField = "Pure_SupplierStock";
            this.Pure_SupplierStock.Height = 0.156F;
            this.Pure_SupplierStock.Left = 2.75F;
            this.Pure_SupplierStock.MultiLine = false;
            this.Pure_SupplierStock.Name = "Pure_SupplierStock";
            this.Pure_SupplierStock.OutputFormat = resources.GetString("Pure_SupplierStock.OutputFormat");
            this.Pure_SupplierStock.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Pure_SupplierStock.Text = "1,234,567.00";
            this.Pure_SupplierStock.Top = 0.0625F;
            this.Pure_SupplierStock.Width = 0.7F;
            // 
            // Parts1_GoodsPrice
            // 
            this.Parts1_GoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_GoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_GoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_GoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_GoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_GoodsPrice.DataField = "Parts1_GoodsPrice";
            this.Parts1_GoodsPrice.Height = 0.156F;
            this.Parts1_GoodsPrice.Left = 5F;
            this.Parts1_GoodsPrice.MultiLine = false;
            this.Parts1_GoodsPrice.Name = "Parts1_GoodsPrice";
            this.Parts1_GoodsPrice.OutputFormat = resources.GetString("Parts1_GoodsPrice.OutputFormat");
            this.Parts1_GoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts1_GoodsPrice.Text = "1,234,567";
            this.Parts1_GoodsPrice.Top = 0.0625F;
            this.Parts1_GoodsPrice.Width = 0.55F;
            // 
            // Parts1_SuplierCode
            // 
            this.Parts1_SuplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_SuplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SuplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_SuplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SuplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_SuplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SuplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_SuplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SuplierCode.DataField = "Parts1_SuplierCode";
            this.Parts1_SuplierCode.Height = 0.16F;
            this.Parts1_SuplierCode.Left = 4.125F;
            this.Parts1_SuplierCode.MultiLine = false;
            this.Parts1_SuplierCode.Name = "Parts1_SuplierCode";
            this.Parts1_SuplierCode.OutputFormat = resources.GetString("Parts1_SuplierCode.OutputFormat");
            this.Parts1_SuplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts1_SuplierCode.Text = "123456";
            this.Parts1_SuplierCode.Top = 0.0625F;
            this.Parts1_SuplierCode.Width = 0.38F;
            // 
            // Parts1_WarehouseShelfNo
            // 
            this.Parts1_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_WarehouseShelfNo.DataField = "Parts1_WarehouseShelfNo";
            this.Parts1_WarehouseShelfNo.Height = 0.16F;
            this.Parts1_WarehouseShelfNo.Left = 3.5F;
            this.Parts1_WarehouseShelfNo.MultiLine = false;
            this.Parts1_WarehouseShelfNo.Name = "Parts1_WarehouseShelfNo";
            this.Parts1_WarehouseShelfNo.OutputFormat = resources.GetString("Parts1_WarehouseShelfNo.OutputFormat");
            this.Parts1_WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts1_WarehouseShelfNo.Text = "12345678";
            this.Parts1_WarehouseShelfNo.Top = 0.0625F;
            this.Parts1_WarehouseShelfNo.Width = 0.5F;
            // 
            // Parts1_MakerCode
            // 
            this.Parts1_MakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_MakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_MakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_MakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_MakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_MakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_MakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_MakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_MakerCode.DataField = "Parts1_MakerCode";
            this.Parts1_MakerCode.Height = 0.16F;
            this.Parts1_MakerCode.Left = 4.6F;
            this.Parts1_MakerCode.MultiLine = false;
            this.Parts1_MakerCode.Name = "Parts1_MakerCode";
            this.Parts1_MakerCode.OutputFormat = resources.GetString("Parts1_MakerCode.OutputFormat");
            this.Parts1_MakerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts1_MakerCode.Text = "1234";
            this.Parts1_MakerCode.Top = 0.0625F;
            this.Parts1_MakerCode.Width = 0.3F;
            // 
            // Parts1_Separator1
            // 
            this.Parts1_Separator1.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_Separator1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator1.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_Separator1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator1.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_Separator1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator1.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_Separator1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_Separator1.Height = 0.156F;
            this.Parts1_Separator1.Left = 4.5F;
            this.Parts1_Separator1.MultiLine = false;
            this.Parts1_Separator1.Name = "Parts1_Separator1";
            this.Parts1_Separator1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts1_Separator1.Text = "/";
            this.Parts1_Separator1.Top = 0.0625F;
            this.Parts1_Separator1.Width = 0.1F;
            // 
            // Parts1_SupplierStock
            // 
            this.Parts1_SupplierStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts1_SupplierStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SupplierStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts1_SupplierStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SupplierStock.Border.RightColor = System.Drawing.Color.Black;
            this.Parts1_SupplierStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SupplierStock.Border.TopColor = System.Drawing.Color.Black;
            this.Parts1_SupplierStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts1_SupplierStock.DataField = "Parts1_SupplierStock";
            this.Parts1_SupplierStock.Height = 0.156F;
            this.Parts1_SupplierStock.Left = 6.4375F;
            this.Parts1_SupplierStock.MultiLine = false;
            this.Parts1_SupplierStock.Name = "Parts1_SupplierStock";
            this.Parts1_SupplierStock.OutputFormat = resources.GetString("Parts1_SupplierStock.OutputFormat");
            this.Parts1_SupplierStock.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts1_SupplierStock.Text = "1,234,567.00";
            this.Parts1_SupplierStock.Top = 0.0625F;
            this.Parts1_SupplierStock.Width = 0.7F;
            // 
            // Parts2_WarehouseShelfNo
            // 
            this.Parts2_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_WarehouseShelfNo.DataField = "Parts2_WarehouseShelfNo";
            this.Parts2_WarehouseShelfNo.Height = 0.16F;
            this.Parts2_WarehouseShelfNo.Left = 7.1875F;
            this.Parts2_WarehouseShelfNo.MultiLine = false;
            this.Parts2_WarehouseShelfNo.Name = "Parts2_WarehouseShelfNo";
            this.Parts2_WarehouseShelfNo.OutputFormat = resources.GetString("Parts2_WarehouseShelfNo.OutputFormat");
            this.Parts2_WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts2_WarehouseShelfNo.Text = "12345678";
            this.Parts2_WarehouseShelfNo.Top = 0.0625F;
            this.Parts2_WarehouseShelfNo.Width = 0.5F;
            // 
            // Parts2_SuplierCode
            // 
            this.Parts2_SuplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_SuplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SuplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_SuplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SuplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_SuplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SuplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_SuplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SuplierCode.DataField = "Parts2_SuplierCode";
            this.Parts2_SuplierCode.Height = 0.16F;
            this.Parts2_SuplierCode.Left = 7.75F;
            this.Parts2_SuplierCode.MultiLine = false;
            this.Parts2_SuplierCode.Name = "Parts2_SuplierCode";
            this.Parts2_SuplierCode.OutputFormat = resources.GetString("Parts2_SuplierCode.OutputFormat");
            this.Parts2_SuplierCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts2_SuplierCode.Text = "123456";
            this.Parts2_SuplierCode.Top = 0.0625F;
            this.Parts2_SuplierCode.Width = 0.38F;
            // 
            // Parts2_MakerCode
            // 
            this.Parts2_MakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_MakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_MakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_MakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_MakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_MakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_MakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_MakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_MakerCode.DataField = "Parts2_MakerCode";
            this.Parts2_MakerCode.Height = 0.16F;
            this.Parts2_MakerCode.Left = 8.25F;
            this.Parts2_MakerCode.MultiLine = false;
            this.Parts2_MakerCode.Name = "Parts2_MakerCode";
            this.Parts2_MakerCode.OutputFormat = resources.GetString("Parts2_MakerCode.OutputFormat");
            this.Parts2_MakerCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.Parts2_MakerCode.Text = "1234";
            this.Parts2_MakerCode.Top = 0.0625F;
            this.Parts2_MakerCode.Width = 0.3F;
            // 
            // Parts2_Separator1
            // 
            this.Parts2_Separator1.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_Separator1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator1.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_Separator1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator1.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_Separator1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator1.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_Separator1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_Separator1.Height = 0.156F;
            this.Parts2_Separator1.Left = 8.125F;
            this.Parts2_Separator1.MultiLine = false;
            this.Parts2_Separator1.Name = "Parts2_Separator1";
            this.Parts2_Separator1.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts2_Separator1.Text = "/";
            this.Parts2_Separator1.Top = 0.0625F;
            this.Parts2_Separator1.Width = 0.1F;
            // 
            // Parts2_GoodsPrice
            // 
            this.Parts2_GoodsPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_GoodsPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_GoodsPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_GoodsPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_GoodsPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_GoodsPrice.DataField = "Parts2_GoodsPrice";
            this.Parts2_GoodsPrice.Height = 0.156F;
            this.Parts2_GoodsPrice.Left = 8.725F;
            this.Parts2_GoodsPrice.MultiLine = false;
            this.Parts2_GoodsPrice.Name = "Parts2_GoodsPrice";
            this.Parts2_GoodsPrice.OutputFormat = resources.GetString("Parts2_GoodsPrice.OutputFormat");
            this.Parts2_GoodsPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts2_GoodsPrice.Text = "1,234,567";
            this.Parts2_GoodsPrice.Top = 0.0625F;
            this.Parts2_GoodsPrice.Width = 0.55F;
            // 
            // Parts2_SupplierStock
            // 
            this.Parts2_SupplierStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts2_SupplierStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SupplierStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts2_SupplierStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SupplierStock.Border.RightColor = System.Drawing.Color.Black;
            this.Parts2_SupplierStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SupplierStock.Border.TopColor = System.Drawing.Color.Black;
            this.Parts2_SupplierStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts2_SupplierStock.DataField = "Parts2_SupplierStock";
            this.Parts2_SupplierStock.Height = 0.156F;
            this.Parts2_SupplierStock.Left = 10.125F;
            this.Parts2_SupplierStock.MultiLine = false;
            this.Parts2_SupplierStock.Name = "Parts2_SupplierStock";
            this.Parts2_SupplierStock.OutputFormat = resources.GetString("Parts2_SupplierStock.OutputFormat");
            this.Parts2_SupplierStock.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Parts2_SupplierStock.Text = "1,234,567.00";
            this.Parts2_SupplierStock.Top = 0.0625F;
            this.Parts2_SupplierStock.Width = 0.7F;
            // 
            // Pure_StockTotalSalesCountSum
            // 
            this.Pure_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_StockTotalSalesCountSum.DataField = "Pure_StockTotalSalesCountSum";
            this.Pure_StockTotalSalesCountSum.Height = 0.156F;
            this.Pure_StockTotalSalesCountSum.Left = 1.9375F;
            this.Pure_StockTotalSalesCountSum.MultiLine = false;
            this.Pure_StockTotalSalesCountSum.Name = "Pure_StockTotalSalesCountSum";
            this.Pure_StockTotalSalesCountSum.OutputFormat = resources.GetString("Pure_StockTotalSalesCountSum.OutputFormat");
            this.Pure_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Pure_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.Pure_StockTotalSalesCountSum.Top = 0.4375F;
            this.Pure_StockTotalSalesCountSum.Visible = false;
            this.Pure_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // Pure_OrderTotalSalesCountSum
            // 
            this.Pure_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.Pure_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Pure_OrderTotalSalesCountSum.DataField = "Pure_OrderTotalSalesCountSum";
            this.Pure_OrderTotalSalesCountSum.Height = 0.156F;
            this.Pure_OrderTotalSalesCountSum.Left = 2.75F;
            this.Pure_OrderTotalSalesCountSum.MultiLine = false;
            this.Pure_OrderTotalSalesCountSum.Name = "Pure_OrderTotalSalesCountSum";
            this.Pure_OrderTotalSalesCountSum.OutputFormat = resources.GetString("Pure_OrderTotalSalesCountSum.OutputFormat");
            this.Pure_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Pure_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.Pure_OrderTotalSalesCountSum.Top = 0.4375F;
            this.Pure_OrderTotalSalesCountSum.Visible = false;
            this.Pure_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // Parts_StockTotalSalesCountSum
            // 
            this.Parts_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.Parts_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.Parts_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_StockTotalSalesCountSum.DataField = "Parts_StockTotalSalesCountSum";
            this.Parts_StockTotalSalesCountSum.Height = 0.156F;
            this.Parts_StockTotalSalesCountSum.Left = 5.625F;
            this.Parts_StockTotalSalesCountSum.MultiLine = false;
            this.Parts_StockTotalSalesCountSum.Name = "Parts_StockTotalSalesCountSum";
            this.Parts_StockTotalSalesCountSum.OutputFormat = resources.GetString("Parts_StockTotalSalesCountSum.OutputFormat");
            this.Parts_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Parts_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.Parts_StockTotalSalesCountSum.Top = 0.4375F;
            this.Parts_StockTotalSalesCountSum.Visible = false;
            this.Parts_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // Parts_OrderTotalSalesCountSum
            // 
            this.Parts_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.Parts_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.Parts_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.Parts_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.Parts_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Parts_OrderTotalSalesCountSum.DataField = "Parts_OrderTotalSalesCountSum";
            this.Parts_OrderTotalSalesCountSum.Height = 0.156F;
            this.Parts_OrderTotalSalesCountSum.Left = 6.4375F;
            this.Parts_OrderTotalSalesCountSum.MultiLine = false;
            this.Parts_OrderTotalSalesCountSum.Name = "Parts_OrderTotalSalesCountSum";
            this.Parts_OrderTotalSalesCountSum.OutputFormat = resources.GetString("Parts_OrderTotalSalesCountSum.OutputFormat");
            this.Parts_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Parts_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.Parts_OrderTotalSalesCountSum.Top = 0.4375F;
            this.Parts_OrderTotalSalesCountSum.Visible = false;
            this.Parts_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // SecHd_line
            // 
            this.SecHd_line.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_line.Height = 0F;
            this.SecHd_line.Left = 0F;
            this.SecHd_line.LineWeight = 2F;
            this.SecHd_line.Name = "SecHd_line";
            this.SecHd_line.Top = 0F;
            this.SecHd_line.Width = 10.8F;
            this.SecHd_line.X1 = 0F;
            this.SecHd_line.X2 = 10.8F;
            this.SecHd_line.Y1 = 0F;
            this.SecHd_line.Y2 = 0F;
            // 
            // PartsCount
            // 
            this.PartsCount.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsCount.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsCount.Border.RightColor = System.Drawing.Color.Black;
            this.PartsCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsCount.Border.TopColor = System.Drawing.Color.Black;
            this.PartsCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsCount.DataField = "PartsCount";
            this.PartsCount.Height = 0.16F;
            this.PartsCount.Left = 0.0625F;
            this.PartsCount.MultiLine = false;
            this.PartsCount.Name = "PartsCount";
            this.PartsCount.OutputFormat = resources.GetString("PartsCount.OutputFormat");
            this.PartsCount.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.PartsCount.Text = "1";
            this.PartsCount.Top = 0.4375F;
            this.PartsCount.Visible = false;
            this.PartsCount.Width = 0.32F;
            // 
            // RowNumber
            // 
            this.RowNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.RowNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RowNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.RowNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RowNumber.Border.RightColor = System.Drawing.Color.Black;
            this.RowNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RowNumber.Border.TopColor = System.Drawing.Color.Black;
            this.RowNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RowNumber.DataField = "RowNumber";
            this.RowNumber.Height = 0.16F;
            this.RowNumber.Left = 0.4375F;
            this.RowNumber.MultiLine = false;
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.OutputFormat = resources.GetString("RowNumber.OutputFormat");
            this.RowNumber.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.RowNumber.Text = "1";
            this.RowNumber.Top = 0.4375F;
            this.RowNumber.Visible = false;
            this.RowNumber.Width = 0.32F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.pageFooter.Height = 0.28125F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
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
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line2,
            this.line3,
            this.Lb_SectionTitle,
            this.label1,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.label16,
            this.label17,
            this.label18,
            this.label19,
            this.label20,
            this.label21,
            this.label22,
            this.label23,
            this.label24,
            this.label25,
            this.label26,
            this.label27,
            this.label28,
            this.label29,
            this.label30,
            this.label31,
            this.label32,
            this.label33,
            this.label34,
            this.label35,
            this.label36});
            this.TitleHeader.Height = 0.6770833F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 2F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 10.8F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.8F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0F;
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
            this.line3.Top = 0.5625F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.5625F;
            this.line3.Y2 = 0.5625F;
            // 
            // Lb_SectionTitle
            // 
            this.Lb_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionTitle.Height = 0.156F;
            this.Lb_SectionTitle.HyperLink = "";
            this.Lb_SectionTitle.Left = 0.0625F;
            this.Lb_SectionTitle.MultiLine = false;
            this.Lb_SectionTitle.Name = "Lb_SectionTitle";
            this.Lb_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SectionTitle.Text = "拠点";
            this.Lb_SectionTitle.Top = 0.01F;
            this.Lb_SectionTitle.Width = 0.4375F;
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
            this.label1.Height = 0.156F;
            this.label1.HyperLink = "";
            this.label1.Left = 0.0625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "棚番";
            this.label1.Top = 0.1875F;
            this.label1.Width = 0.4F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.156F;
            this.label4.HyperLink = "";
            this.label4.Left = 0.0625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "ｸﾞﾙｰﾌﾟ";
            this.label4.Top = 0.375F;
            this.label4.Width = 0.4F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.156F;
            this.label5.HyperLink = "";
            this.label5.Left = 0.4375F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "品名";
            this.label5.Top = 0.375F;
            this.label5.Width = 0.4F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.156F;
            this.label6.HyperLink = "";
            this.label6.Left = 0.625F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "純正品番";
            this.label6.Top = 0.1875F;
            this.label6.Width = 0.5F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.156F;
            this.label7.HyperLink = "";
            this.label7.Left = 1.4F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "粗利率";
            this.label7.Top = 0.375F;
            this.label7.Width = 0.5F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.156F;
            this.label8.HyperLink = "";
            this.label8.Left = 2.2375F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "価格";
            this.label8.Top = 0.1875F;
            this.label8.Width = 0.4F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.156F;
            this.label9.HyperLink = "";
            this.label9.Left = 2.2375F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "在庫";
            this.label9.Top = 0.375F;
            this.label9.Width = 0.4F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.156F;
            this.label10.HyperLink = "";
            this.label10.Left = 2.625F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "/";
            this.label10.Top = 0.375F;
            this.label10.Width = 0.1F;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.156F;
            this.label11.HyperLink = "";
            this.label11.Left = 3.05F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "取寄";
            this.label11.Top = 0.375F;
            this.label11.Width = 0.4F;
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.156F;
            this.label12.HyperLink = "";
            this.label12.Left = 3.05F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "現在庫";
            this.label12.Top = 0.1875F;
            this.label12.Width = 0.4F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.156F;
            this.label13.HyperLink = "";
            this.label13.Left = 3.5F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "棚番";
            this.label13.Top = 0.1875F;
            this.label13.Width = 0.4F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.156F;
            this.label14.HyperLink = "";
            this.label14.Left = 3.5F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "ｸﾞﾙｰﾌﾟ";
            this.label14.Top = 0.375F;
            this.label14.Width = 0.4F;
            // 
            // label15
            // 
            this.label15.Border.BottomColor = System.Drawing.Color.Black;
            this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.LeftColor = System.Drawing.Color.Black;
            this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.RightColor = System.Drawing.Color.Black;
            this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.TopColor = System.Drawing.Color.Black;
            this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Height = 0.156F;
            this.label15.HyperLink = "";
            this.label15.Left = 3.875F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "参考品番";
            this.label15.Top = 0.375F;
            this.label15.Width = 0.5F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.156F;
            this.label16.HyperLink = "";
            this.label16.Left = 4.125F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "仕入先";
            this.label16.Top = 0.1875F;
            this.label16.Width = 0.4F;
            // 
            // label17
            // 
            this.label17.Border.BottomColor = System.Drawing.Color.Black;
            this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.LeftColor = System.Drawing.Color.Black;
            this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.RightColor = System.Drawing.Color.Black;
            this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.TopColor = System.Drawing.Color.Black;
            this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Height = 0.156F;
            this.label17.HyperLink = "";
            this.label17.Left = 4.6F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "ﾒｰｶｰ";
            this.label17.Top = 0.1875F;
            this.label17.Width = 0.4F;
            // 
            // label18
            // 
            this.label18.Border.BottomColor = System.Drawing.Color.Black;
            this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.LeftColor = System.Drawing.Color.Black;
            this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.RightColor = System.Drawing.Color.Black;
            this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.TopColor = System.Drawing.Color.Black;
            this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Height = 0.156F;
            this.label18.HyperLink = "";
            this.label18.Left = 4.5F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "/";
            this.label18.Top = 0.1875F;
            this.label18.Width = 0.1F;
            // 
            // label19
            // 
            this.label19.Border.BottomColor = System.Drawing.Color.Black;
            this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.LeftColor = System.Drawing.Color.Black;
            this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.RightColor = System.Drawing.Color.Black;
            this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.TopColor = System.Drawing.Color.Black;
            this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Height = 0.156F;
            this.label19.HyperLink = "";
            this.label19.Left = 5.0875F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "粗利率";
            this.label19.Top = 0.375F;
            this.label19.Width = 0.5F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Height = 0.156F;
            this.label20.HyperLink = "";
            this.label20.Left = 5.925F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label20.Text = "在庫";
            this.label20.Top = 0.375F;
            this.label20.Width = 0.4F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Height = 0.156F;
            this.label21.HyperLink = "";
            this.label21.Left = 6.3125F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label21.Text = "/";
            this.label21.Top = 0.375F;
            this.label21.Width = 0.1F;
            // 
            // label22
            // 
            this.label22.Border.BottomColor = System.Drawing.Color.Black;
            this.label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.LeftColor = System.Drawing.Color.Black;
            this.label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.RightColor = System.Drawing.Color.Black;
            this.label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.TopColor = System.Drawing.Color.Black;
            this.label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Height = 0.156F;
            this.label22.HyperLink = "";
            this.label22.Left = 6.7375F;
            this.label22.MultiLine = false;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label22.Text = "取寄";
            this.label22.Top = 0.375F;
            this.label22.Width = 0.4F;
            // 
            // label23
            // 
            this.label23.Border.BottomColor = System.Drawing.Color.Black;
            this.label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.LeftColor = System.Drawing.Color.Black;
            this.label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.RightColor = System.Drawing.Color.Black;
            this.label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.TopColor = System.Drawing.Color.Black;
            this.label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Height = 0.156F;
            this.label23.HyperLink = "";
            this.label23.Left = 5.1875F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label23.Text = "価格";
            this.label23.Top = 0.1875F;
            this.label23.Width = 0.4F;
            // 
            // label24
            // 
            this.label24.Border.BottomColor = System.Drawing.Color.Black;
            this.label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.LeftColor = System.Drawing.Color.Black;
            this.label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.RightColor = System.Drawing.Color.Black;
            this.label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.TopColor = System.Drawing.Color.Black;
            this.label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Height = 0.156F;
            this.label24.HyperLink = "";
            this.label24.Left = 6.7375F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label24.Text = "現在庫";
            this.label24.Top = 0.1875F;
            this.label24.Width = 0.4F;
            // 
            // label25
            // 
            this.label25.Border.BottomColor = System.Drawing.Color.Black;
            this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.LeftColor = System.Drawing.Color.Black;
            this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.RightColor = System.Drawing.Color.Black;
            this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.TopColor = System.Drawing.Color.Black;
            this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Height = 0.156F;
            this.label25.HyperLink = "";
            this.label25.Left = 7.1875F;
            this.label25.MultiLine = false;
            this.label25.Name = "label25";
            this.label25.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label25.Text = "棚番";
            this.label25.Top = 0.1875F;
            this.label25.Width = 0.4F;
            // 
            // label26
            // 
            this.label26.Border.BottomColor = System.Drawing.Color.Black;
            this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.LeftColor = System.Drawing.Color.Black;
            this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.RightColor = System.Drawing.Color.Black;
            this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.TopColor = System.Drawing.Color.Black;
            this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Height = 0.156F;
            this.label26.HyperLink = "";
            this.label26.Left = 7.1875F;
            this.label26.MultiLine = false;
            this.label26.Name = "label26";
            this.label26.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label26.Text = "ｸﾞﾙｰﾌﾟ";
            this.label26.Top = 0.375F;
            this.label26.Width = 0.4F;
            // 
            // label27
            // 
            this.label27.Border.BottomColor = System.Drawing.Color.Black;
            this.label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.LeftColor = System.Drawing.Color.Black;
            this.label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.RightColor = System.Drawing.Color.Black;
            this.label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.TopColor = System.Drawing.Color.Black;
            this.label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Height = 0.156F;
            this.label27.HyperLink = "";
            this.label27.Left = 7.55F;
            this.label27.MultiLine = false;
            this.label27.Name = "label27";
            this.label27.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label27.Text = "参考品番";
            this.label27.Top = 0.375F;
            this.label27.Width = 0.5F;
            // 
            // label28
            // 
            this.label28.Border.BottomColor = System.Drawing.Color.Black;
            this.label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.LeftColor = System.Drawing.Color.Black;
            this.label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.RightColor = System.Drawing.Color.Black;
            this.label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.TopColor = System.Drawing.Color.Black;
            this.label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Height = 0.156F;
            this.label28.HyperLink = "";
            this.label28.Left = 7.75F;
            this.label28.MultiLine = false;
            this.label28.Name = "label28";
            this.label28.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label28.Text = "仕入先";
            this.label28.Top = 0.1875F;
            this.label28.Width = 0.4F;
            // 
            // label29
            // 
            this.label29.Border.BottomColor = System.Drawing.Color.Black;
            this.label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.LeftColor = System.Drawing.Color.Black;
            this.label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.RightColor = System.Drawing.Color.Black;
            this.label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.TopColor = System.Drawing.Color.Black;
            this.label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Height = 0.156F;
            this.label29.HyperLink = "";
            this.label29.Left = 8.25F;
            this.label29.MultiLine = false;
            this.label29.Name = "label29";
            this.label29.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label29.Text = "ﾒｰｶｰ";
            this.label29.Top = 0.1875F;
            this.label29.Width = 0.4F;
            // 
            // label30
            // 
            this.label30.Border.BottomColor = System.Drawing.Color.Black;
            this.label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.LeftColor = System.Drawing.Color.Black;
            this.label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.RightColor = System.Drawing.Color.Black;
            this.label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.TopColor = System.Drawing.Color.Black;
            this.label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Height = 0.156F;
            this.label30.HyperLink = "";
            this.label30.Left = 8.125F;
            this.label30.MultiLine = false;
            this.label30.Name = "label30";
            this.label30.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label30.Text = "/";
            this.label30.Top = 0.1875F;
            this.label30.Width = 0.1F;
            // 
            // label31
            // 
            this.label31.Border.BottomColor = System.Drawing.Color.Black;
            this.label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.LeftColor = System.Drawing.Color.Black;
            this.label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.RightColor = System.Drawing.Color.Black;
            this.label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.TopColor = System.Drawing.Color.Black;
            this.label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Height = 0.156F;
            this.label31.HyperLink = "";
            this.label31.Left = 8.775001F;
            this.label31.MultiLine = false;
            this.label31.Name = "label31";
            this.label31.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label31.Text = "粗利率";
            this.label31.Top = 0.375F;
            this.label31.Width = 0.5F;
            // 
            // label32
            // 
            this.label32.Border.BottomColor = System.Drawing.Color.Black;
            this.label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.LeftColor = System.Drawing.Color.Black;
            this.label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.RightColor = System.Drawing.Color.Black;
            this.label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.TopColor = System.Drawing.Color.Black;
            this.label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Height = 0.156F;
            this.label32.HyperLink = "";
            this.label32.Left = 9.625F;
            this.label32.MultiLine = false;
            this.label32.Name = "label32";
            this.label32.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label32.Text = "在庫";
            this.label32.Top = 0.375F;
            this.label32.Width = 0.4F;
            // 
            // label33
            // 
            this.label33.Border.BottomColor = System.Drawing.Color.Black;
            this.label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.LeftColor = System.Drawing.Color.Black;
            this.label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.RightColor = System.Drawing.Color.Black;
            this.label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.TopColor = System.Drawing.Color.Black;
            this.label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Height = 0.156F;
            this.label33.HyperLink = "";
            this.label33.Left = 10F;
            this.label33.MultiLine = false;
            this.label33.Name = "label33";
            this.label33.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label33.Text = "/";
            this.label33.Top = 0.375F;
            this.label33.Width = 0.1F;
            // 
            // label34
            // 
            this.label34.Border.BottomColor = System.Drawing.Color.Black;
            this.label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.LeftColor = System.Drawing.Color.Black;
            this.label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.RightColor = System.Drawing.Color.Black;
            this.label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.TopColor = System.Drawing.Color.Black;
            this.label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Height = 0.156F;
            this.label34.HyperLink = "";
            this.label34.Left = 10.4375F;
            this.label34.MultiLine = false;
            this.label34.Name = "label34";
            this.label34.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label34.Text = "取寄";
            this.label34.Top = 0.375F;
            this.label34.Width = 0.4F;
            // 
            // label35
            // 
            this.label35.Border.BottomColor = System.Drawing.Color.Black;
            this.label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.LeftColor = System.Drawing.Color.Black;
            this.label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.RightColor = System.Drawing.Color.Black;
            this.label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.TopColor = System.Drawing.Color.Black;
            this.label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Height = 0.156F;
            this.label35.HyperLink = "";
            this.label35.Left = 8.875F;
            this.label35.MultiLine = false;
            this.label35.Name = "label35";
            this.label35.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label35.Text = "価格";
            this.label35.Top = 0.1875F;
            this.label35.Width = 0.4F;
            // 
            // label36
            // 
            this.label36.Border.BottomColor = System.Drawing.Color.Black;
            this.label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.LeftColor = System.Drawing.Color.Black;
            this.label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.RightColor = System.Drawing.Color.Black;
            this.label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.TopColor = System.Drawing.Color.Black;
            this.label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Height = 0.156F;
            this.label36.HyperLink = "";
            this.label36.Left = 10.4375F;
            this.label36.MultiLine = false;
            this.label36.Name = "label36";
            this.label36.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label36.Text = "現在庫";
            this.label36.Top = 0.1875F;
            this.label36.Width = 0.4F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox61,
            this.line7,
            this.GraFt_Pure_StockTotalSalesCountSum,
            this.textBox89,
            this.GraFt_Pure_OrderTotalSalesCountSum,
            this.GraFt_Parts_StockTotalSalesCountSum,
            this.textBox5,
            this.GraFt_Parts_OrderTotalSalesCountSum});
            this.GrandTotalFooter.Height = 0.5208333F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // textBox61
            // 
            this.textBox61.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.RightColor = System.Drawing.Color.Black;
            this.textBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.TopColor = System.Drawing.Color.Black;
            this.textBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Height = 0.19F;
            this.textBox61.Left = 0.625F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox61.Text = "総合計";
            this.textBox61.Top = 0.063F;
            this.textBox61.Width = 1.3F;
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
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 10.8125F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8125F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // GraFt_Pure_StockTotalSalesCountSum
            // 
            this.GraFt_Pure_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_Pure_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_StockTotalSalesCountSum.DataField = "Pure_StockTotalSalesCountSum";
            this.GraFt_Pure_StockTotalSalesCountSum.Height = 0.156F;
            this.GraFt_Pure_StockTotalSalesCountSum.Left = 1.938F;
            this.GraFt_Pure_StockTotalSalesCountSum.MultiLine = false;
            this.GraFt_Pure_StockTotalSalesCountSum.Name = "GraFt_Pure_StockTotalSalesCountSum";
            this.GraFt_Pure_StockTotalSalesCountSum.OutputFormat = resources.GetString("GraFt_Pure_StockTotalSalesCountSum.OutputFormat");
            this.GraFt_Pure_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_Pure_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_Pure_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_Pure_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.GraFt_Pure_StockTotalSalesCountSum.Top = 0.25F;
            this.GraFt_Pure_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox89
            // 
            this.textBox89.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox89.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox89.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.RightColor = System.Drawing.Color.Black;
            this.textBox89.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.Border.TopColor = System.Drawing.Color.Black;
            this.textBox89.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox89.DataField = "";
            this.textBox89.Height = 0.156F;
            this.textBox89.Left = 2.625F;
            this.textBox89.MultiLine = false;
            this.textBox89.Name = "textBox89";
            this.textBox89.OutputFormat = resources.GetString("textBox89.OutputFormat");
            this.textBox89.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox89.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox89.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox89.Text = "/";
            this.textBox89.Top = 0.25F;
            this.textBox89.Width = 0.1F;
            // 
            // GraFt_Pure_OrderTotalSalesCountSum
            // 
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_Pure_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Pure_OrderTotalSalesCountSum.DataField = "Pure_OrderTotalSalesCountSum";
            this.GraFt_Pure_OrderTotalSalesCountSum.Height = 0.156F;
            this.GraFt_Pure_OrderTotalSalesCountSum.Left = 2.75F;
            this.GraFt_Pure_OrderTotalSalesCountSum.MultiLine = false;
            this.GraFt_Pure_OrderTotalSalesCountSum.Name = "GraFt_Pure_OrderTotalSalesCountSum";
            this.GraFt_Pure_OrderTotalSalesCountSum.OutputFormat = resources.GetString("GraFt_Pure_OrderTotalSalesCountSum.OutputFormat");
            this.GraFt_Pure_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_Pure_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_Pure_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_Pure_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.GraFt_Pure_OrderTotalSalesCountSum.Top = 0.25F;
            this.GraFt_Pure_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // GraFt_Parts_StockTotalSalesCountSum
            // 
            this.GraFt_Parts_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_Parts_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_StockTotalSalesCountSum.DataField = "Parts_StockTotalSalesCountSum";
            this.GraFt_Parts_StockTotalSalesCountSum.Height = 0.156F;
            this.GraFt_Parts_StockTotalSalesCountSum.Left = 5.625F;
            this.GraFt_Parts_StockTotalSalesCountSum.MultiLine = false;
            this.GraFt_Parts_StockTotalSalesCountSum.Name = "GraFt_Parts_StockTotalSalesCountSum";
            this.GraFt_Parts_StockTotalSalesCountSum.OutputFormat = resources.GetString("GraFt_Parts_StockTotalSalesCountSum.OutputFormat");
            this.GraFt_Parts_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_Parts_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_Parts_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_Parts_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.GraFt_Parts_StockTotalSalesCountSum.Top = 0.25F;
            this.GraFt_Parts_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "";
            this.textBox5.Height = 0.156F;
            this.textBox5.Left = 6.3125F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "/";
            this.textBox5.Top = 0.25F;
            this.textBox5.Width = 0.1F;
            // 
            // GraFt_Parts_OrderTotalSalesCountSum
            // 
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GraFt_Parts_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GraFt_Parts_OrderTotalSalesCountSum.DataField = "Parts_OrderTotalSalesCountSum";
            this.GraFt_Parts_OrderTotalSalesCountSum.Height = 0.156F;
            this.GraFt_Parts_OrderTotalSalesCountSum.Left = 6.4375F;
            this.GraFt_Parts_OrderTotalSalesCountSum.MultiLine = false;
            this.GraFt_Parts_OrderTotalSalesCountSum.Name = "GraFt_Parts_OrderTotalSalesCountSum";
            this.GraFt_Parts_OrderTotalSalesCountSum.OutputFormat = resources.GetString("GraFt_Parts_OrderTotalSalesCountSum.OutputFormat");
            this.GraFt_Parts_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GraFt_Parts_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.GraFt_Parts_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.GraFt_Parts_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.GraFt_Parts_OrderTotalSalesCountSum.Top = 0.25F;
            this.GraFt_Parts_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecHd_SectionCode,
            this.SecHd_SectionName});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.2083333F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
            // 
            // SecHd_SectionCode
            // 
            this.SecHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionCode.DataField = "AddUpSecCode";
            this.SecHd_SectionCode.Height = 0.16F;
            this.SecHd_SectionCode.Left = 0.0625F;
            this.SecHd_SectionCode.MultiLine = false;
            this.SecHd_SectionCode.Name = "SecHd_SectionCode";
            this.SecHd_SectionCode.OutputFormat = resources.GetString("SecHd_SectionCode.OutputFormat");
            this.SecHd_SectionCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SecHd_SectionCode.Text = "12";
            this.SecHd_SectionCode.Top = 0F;
            this.SecHd_SectionCode.Width = 0.2F;
            // 
            // SecHd_SectionName
            // 
            this.SecHd_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.SecHd_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecHd_SectionName.DataField = "SectionGuideSnm";
            this.SecHd_SectionName.Height = 0.16F;
            this.SecHd_SectionName.Left = 0.3125F;
            this.SecHd_SectionName.MultiLine = false;
            this.SecHd_SectionName.Name = "SecHd_SectionName";
            this.SecHd_SectionName.OutputFormat = resources.GetString("SecHd_SectionName.OutputFormat");
            this.SecHd_SectionName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SecHd_SectionName.Text = "あいうえおかきくけこ";
            this.SecHd_SectionName.Top = 0F;
            this.SecHd_SectionName.Width = 1.2F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox60,
            this.line6,
            this.SecFt_Pure_StockTotalSalesCountSum,
            this.textBox86,
            this.SecFt_Pure_OrderTotalSalesCountSum,
            this.SecFt_Parts_StockTotalSalesCountSum,
            this.textBox2,
            this.SecFt_Parts_OrderTotalSalesCountSum});
            this.SectionFooter.Height = 0.4583333F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // textBox60
            // 
            this.textBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.RightColor = System.Drawing.Color.Black;
            this.textBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.TopColor = System.Drawing.Color.Black;
            this.textBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Height = 0.19F;
            this.textBox60.Left = 0.625F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox60.Text = "拠点計";
            this.textBox60.Top = 0.063F;
            this.textBox60.Width = 1.3F;
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
            this.line6.Top = 0F;
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // SecFt_Pure_StockTotalSalesCountSum
            // 
            this.SecFt_Pure_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_Pure_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_StockTotalSalesCountSum.DataField = "Pure_StockTotalSalesCountSum";
            this.SecFt_Pure_StockTotalSalesCountSum.Height = 0.156F;
            this.SecFt_Pure_StockTotalSalesCountSum.Left = 1.938F;
            this.SecFt_Pure_StockTotalSalesCountSum.MultiLine = false;
            this.SecFt_Pure_StockTotalSalesCountSum.Name = "SecFt_Pure_StockTotalSalesCountSum";
            this.SecFt_Pure_StockTotalSalesCountSum.OutputFormat = resources.GetString("SecFt_Pure_StockTotalSalesCountSum.OutputFormat");
            this.SecFt_Pure_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_Pure_StockTotalSalesCountSum.SummaryGroup = "SectionHeader";
            this.SecFt_Pure_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_Pure_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_Pure_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.SecFt_Pure_StockTotalSalesCountSum.Top = 0.25F;
            this.SecFt_Pure_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox86
            // 
            this.textBox86.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.RightColor = System.Drawing.Color.Black;
            this.textBox86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.Border.TopColor = System.Drawing.Color.Black;
            this.textBox86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox86.DataField = "";
            this.textBox86.Height = 0.156F;
            this.textBox86.Left = 2.625F;
            this.textBox86.MultiLine = false;
            this.textBox86.Name = "textBox86";
            this.textBox86.OutputFormat = resources.GetString("textBox86.OutputFormat");
            this.textBox86.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox86.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox86.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox86.Text = "/";
            this.textBox86.Top = 0.25F;
            this.textBox86.Width = 0.1F;
            // 
            // SecFt_Pure_OrderTotalSalesCountSum
            // 
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_Pure_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Pure_OrderTotalSalesCountSum.DataField = "Pure_OrderTotalSalesCountSum";
            this.SecFt_Pure_OrderTotalSalesCountSum.Height = 0.156F;
            this.SecFt_Pure_OrderTotalSalesCountSum.Left = 2.75F;
            this.SecFt_Pure_OrderTotalSalesCountSum.MultiLine = false;
            this.SecFt_Pure_OrderTotalSalesCountSum.Name = "SecFt_Pure_OrderTotalSalesCountSum";
            this.SecFt_Pure_OrderTotalSalesCountSum.OutputFormat = resources.GetString("SecFt_Pure_OrderTotalSalesCountSum.OutputFormat");
            this.SecFt_Pure_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_Pure_OrderTotalSalesCountSum.SummaryGroup = "SectionHeader";
            this.SecFt_Pure_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_Pure_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_Pure_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.SecFt_Pure_OrderTotalSalesCountSum.Top = 0.25F;
            this.SecFt_Pure_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // SecFt_Parts_StockTotalSalesCountSum
            // 
            this.SecFt_Parts_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_Parts_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_StockTotalSalesCountSum.DataField = "Parts_StockTotalSalesCountSum";
            this.SecFt_Parts_StockTotalSalesCountSum.Height = 0.156F;
            this.SecFt_Parts_StockTotalSalesCountSum.Left = 5.625F;
            this.SecFt_Parts_StockTotalSalesCountSum.MultiLine = false;
            this.SecFt_Parts_StockTotalSalesCountSum.Name = "SecFt_Parts_StockTotalSalesCountSum";
            this.SecFt_Parts_StockTotalSalesCountSum.OutputFormat = resources.GetString("SecFt_Parts_StockTotalSalesCountSum.OutputFormat");
            this.SecFt_Parts_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_Parts_StockTotalSalesCountSum.SummaryGroup = "SectionHeader";
            this.SecFt_Parts_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_Parts_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_Parts_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.SecFt_Parts_StockTotalSalesCountSum.Top = 0.25F;
            this.SecFt_Parts_StockTotalSalesCountSum.Width = 0.7F;
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
            this.textBox2.DataField = "";
            this.textBox2.Height = 0.156F;
            this.textBox2.Left = 6.3125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "/";
            this.textBox2.Top = 0.25F;
            this.textBox2.Width = 0.1F;
            // 
            // SecFt_Parts_OrderTotalSalesCountSum
            // 
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_Parts_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_Parts_OrderTotalSalesCountSum.DataField = "Parts_OrderTotalSalesCountSum";
            this.SecFt_Parts_OrderTotalSalesCountSum.Height = 0.156F;
            this.SecFt_Parts_OrderTotalSalesCountSum.Left = 6.4375F;
            this.SecFt_Parts_OrderTotalSalesCountSum.MultiLine = false;
            this.SecFt_Parts_OrderTotalSalesCountSum.Name = "SecFt_Parts_OrderTotalSalesCountSum";
            this.SecFt_Parts_OrderTotalSalesCountSum.OutputFormat = resources.GetString("SecFt_Parts_OrderTotalSalesCountSum.OutputFormat");
            this.SecFt_Parts_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_Parts_OrderTotalSalesCountSum.SummaryGroup = "SectionHeader";
            this.SecFt_Parts_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_Parts_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_Parts_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.SecFt_Parts_OrderTotalSalesCountSum.Top = 0.25F;
            this.SecFt_Parts_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // GoodsMakerHeader
            // 
            this.GoodsMakerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.GoodsMakerHeader.Height = 0F;
            this.GoodsMakerHeader.KeepTogether = true;
            this.GoodsMakerHeader.Name = "GoodsMakerHeader";
            this.GoodsMakerHeader.Visible = false;
            // 
            // GoodsMakerFooter
            // 
            this.GoodsMakerFooter.CanShrink = true;
            this.GoodsMakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox98,
            this.MakFt_Pure_MakerCode,
            this.MakFt_Pure_StockTotalSalesCountSum,
            this.textBox63,
            this.MakFt_Pure_OrderTotalSalesCountSum,
            this.MakFt_Pure_GoodsMakerName,
            this.line5,
            this.MakFt_Parts_StockTotalSalesCountSum,
            this.textBox83,
            this.MakFt_Parts_OrderTotalSalesCountSum});
            this.GoodsMakerFooter.Height = 0.5104167F;
            this.GoodsMakerFooter.KeepTogether = true;
            this.GoodsMakerFooter.Name = "GoodsMakerFooter";
            this.GoodsMakerFooter.Visible = false;
            this.GoodsMakerFooter.BeforePrint += new System.EventHandler(this.GoodsMakerFooter_BeforePrint);
            // 
            // textBox98
            // 
            this.textBox98.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox98.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox98.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.RightColor = System.Drawing.Color.Black;
            this.textBox98.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Border.TopColor = System.Drawing.Color.Black;
            this.textBox98.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox98.Height = 0.19F;
            this.textBox98.Left = 0.625F;
            this.textBox98.MultiLine = false;
            this.textBox98.Name = "textBox98";
            this.textBox98.OutputFormat = resources.GetString("textBox98.OutputFormat");
            this.textBox98.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox98.Text = "純正メーカー計";
            this.textBox98.Top = 0.063F;
            this.textBox98.Width = 1.3F;
            // 
            // MakFt_Pure_MakerCode
            // 
            this.MakFt_Pure_MakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_Pure_MakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_MakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_Pure_MakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_MakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_Pure_MakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_MakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_Pure_MakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_MakerCode.DataField = "Pure_MakerCode";
            this.MakFt_Pure_MakerCode.Height = 0.16F;
            this.MakFt_Pure_MakerCode.Left = 1.9375F;
            this.MakFt_Pure_MakerCode.MultiLine = false;
            this.MakFt_Pure_MakerCode.Name = "MakFt_Pure_MakerCode";
            this.MakFt_Pure_MakerCode.OutputFormat = resources.GetString("MakFt_Pure_MakerCode.OutputFormat");
            this.MakFt_Pure_MakerCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_Pure_MakerCode.Text = "12";
            this.MakFt_Pure_MakerCode.Top = 0.0625F;
            this.MakFt_Pure_MakerCode.Width = 0.32F;
            // 
            // MakFt_Pure_StockTotalSalesCountSum
            // 
            this.MakFt_Pure_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_Pure_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_StockTotalSalesCountSum.DataField = "Pure_StockTotalSalesCountSum";
            this.MakFt_Pure_StockTotalSalesCountSum.Height = 0.156F;
            this.MakFt_Pure_StockTotalSalesCountSum.Left = 1.9375F;
            this.MakFt_Pure_StockTotalSalesCountSum.MultiLine = false;
            this.MakFt_Pure_StockTotalSalesCountSum.Name = "MakFt_Pure_StockTotalSalesCountSum";
            this.MakFt_Pure_StockTotalSalesCountSum.OutputFormat = resources.GetString("MakFt_Pure_StockTotalSalesCountSum.OutputFormat");
            this.MakFt_Pure_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_Pure_StockTotalSalesCountSum.SummaryGroup = "GoodsMakerHeader";
            this.MakFt_Pure_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_Pure_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_Pure_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.MakFt_Pure_StockTotalSalesCountSum.Top = 0.25F;
            this.MakFt_Pure_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox63
            // 
            this.textBox63.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.RightColor = System.Drawing.Color.Black;
            this.textBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.TopColor = System.Drawing.Color.Black;
            this.textBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.DataField = "";
            this.textBox63.Height = 0.156F;
            this.textBox63.Left = 2.625F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox63.Text = "/";
            this.textBox63.Top = 0.25F;
            this.textBox63.Width = 0.1F;
            // 
            // MakFt_Pure_OrderTotalSalesCountSum
            // 
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_Pure_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_OrderTotalSalesCountSum.DataField = "Pure_OrderTotalSalesCountSum";
            this.MakFt_Pure_OrderTotalSalesCountSum.Height = 0.156F;
            this.MakFt_Pure_OrderTotalSalesCountSum.Left = 2.75F;
            this.MakFt_Pure_OrderTotalSalesCountSum.MultiLine = false;
            this.MakFt_Pure_OrderTotalSalesCountSum.Name = "MakFt_Pure_OrderTotalSalesCountSum";
            this.MakFt_Pure_OrderTotalSalesCountSum.OutputFormat = resources.GetString("MakFt_Pure_OrderTotalSalesCountSum.OutputFormat");
            this.MakFt_Pure_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_Pure_OrderTotalSalesCountSum.SummaryGroup = "GoodsMakerHeader";
            this.MakFt_Pure_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_Pure_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_Pure_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.MakFt_Pure_OrderTotalSalesCountSum.Top = 0.25F;
            this.MakFt_Pure_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // MakFt_Pure_GoodsMakerName
            // 
            this.MakFt_Pure_GoodsMakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_Pure_GoodsMakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_GoodsMakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_Pure_GoodsMakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_GoodsMakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_Pure_GoodsMakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_GoodsMakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_Pure_GoodsMakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Pure_GoodsMakerName.DataField = "Pure_GoodsMakerName";
            this.MakFt_Pure_GoodsMakerName.Height = 0.156F;
            this.MakFt_Pure_GoodsMakerName.Left = 2.3125F;
            this.MakFt_Pure_GoodsMakerName.MultiLine = false;
            this.MakFt_Pure_GoodsMakerName.Name = "MakFt_Pure_GoodsMakerName";
            this.MakFt_Pure_GoodsMakerName.OutputFormat = resources.GetString("MakFt_Pure_GoodsMakerName.OutputFormat");
            this.MakFt_Pure_GoodsMakerName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_Pure_GoodsMakerName.Text = "あいうえおかきくけこ";
            this.MakFt_Pure_GoodsMakerName.Top = 0.0625F;
            this.MakFt_Pure_GoodsMakerName.Width = 1.2F;
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
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8125F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8125F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // MakFt_Parts_StockTotalSalesCountSum
            // 
            this.MakFt_Parts_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_Parts_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_StockTotalSalesCountSum.DataField = "Parts_StockTotalSalesCountSum";
            this.MakFt_Parts_StockTotalSalesCountSum.Height = 0.156F;
            this.MakFt_Parts_StockTotalSalesCountSum.Left = 5.625F;
            this.MakFt_Parts_StockTotalSalesCountSum.MultiLine = false;
            this.MakFt_Parts_StockTotalSalesCountSum.Name = "MakFt_Parts_StockTotalSalesCountSum";
            this.MakFt_Parts_StockTotalSalesCountSum.OutputFormat = resources.GetString("MakFt_Parts_StockTotalSalesCountSum.OutputFormat");
            this.MakFt_Parts_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_Parts_StockTotalSalesCountSum.SummaryGroup = "GoodsMakerHeader";
            this.MakFt_Parts_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_Parts_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_Parts_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.MakFt_Parts_StockTotalSalesCountSum.Top = 0.25F;
            this.MakFt_Parts_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox83
            // 
            this.textBox83.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox83.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox83.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.RightColor = System.Drawing.Color.Black;
            this.textBox83.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.Border.TopColor = System.Drawing.Color.Black;
            this.textBox83.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox83.DataField = "";
            this.textBox83.Height = 0.156F;
            this.textBox83.Left = 6.3125F;
            this.textBox83.MultiLine = false;
            this.textBox83.Name = "textBox83";
            this.textBox83.OutputFormat = resources.GetString("textBox83.OutputFormat");
            this.textBox83.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox83.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox83.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox83.Text = "/";
            this.textBox83.Top = 0.25F;
            this.textBox83.Width = 0.1F;
            // 
            // MakFt_Parts_OrderTotalSalesCountSum
            // 
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_Parts_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_Parts_OrderTotalSalesCountSum.DataField = "Parts_OrderTotalSalesCountSum";
            this.MakFt_Parts_OrderTotalSalesCountSum.Height = 0.156F;
            this.MakFt_Parts_OrderTotalSalesCountSum.Left = 6.4375F;
            this.MakFt_Parts_OrderTotalSalesCountSum.MultiLine = false;
            this.MakFt_Parts_OrderTotalSalesCountSum.Name = "MakFt_Parts_OrderTotalSalesCountSum";
            this.MakFt_Parts_OrderTotalSalesCountSum.OutputFormat = resources.GetString("MakFt_Parts_OrderTotalSalesCountSum.OutputFormat");
            this.MakFt_Parts_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_Parts_OrderTotalSalesCountSum.SummaryGroup = "GoodsMakerHeader";
            this.MakFt_Parts_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_Parts_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_Parts_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.MakFt_Parts_OrderTotalSalesCountSum.Top = 0.25F;
            this.MakFt_Parts_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // GoodsMGroupHeader
            // 
            this.GoodsMGroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.GoodsMGroupHeader.Height = 0F;
            this.GoodsMGroupHeader.KeepTogether = true;
            this.GoodsMGroupHeader.Name = "GoodsMGroupHeader";
            this.GoodsMGroupHeader.Visible = false;
            // 
            // GoodsMGroupFooter
            // 
            this.GoodsMGroupFooter.CanShrink = true;
            this.GoodsMGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox58,
            this.line4,
            this.MgrFt_Pure_GoodsMGroup,
            this.MgrFt_Pure_StockTotalSalesCountSum,
            this.textBox68,
            this.MgrFt_Pure_OrderTotalSalesCountSum,
            this.MgrFt_Pure_GoodsMGroupName,
            this.MgrFt_Parts_StockTotalSalesCountSum,
            this.textBox80,
            this.MgrFt_Parts_OrderTotalSalesCountSum});
            this.GoodsMGroupFooter.Height = 0.5F;
            this.GoodsMGroupFooter.KeepTogether = true;
            this.GoodsMGroupFooter.Name = "GoodsMGroupFooter";
            this.GoodsMGroupFooter.Visible = false;
            this.GoodsMGroupFooter.BeforePrint += new System.EventHandler(this.GoodsMGroupFooter_BeforePrint);
            // 
            // textBox58
            // 
            this.textBox58.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.RightColor = System.Drawing.Color.Black;
            this.textBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.TopColor = System.Drawing.Color.Black;
            this.textBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Height = 0.19F;
            this.textBox58.Left = 0.625F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox58.Text = "商品中分類計";
            this.textBox58.Top = 0.063F;
            this.textBox58.Width = 1.3F;
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
            this.line4.Top = 0F;
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // MgrFt_Pure_GoodsMGroup
            // 
            this.MgrFt_Pure_GoodsMGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroup.Border.RightColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroup.Border.TopColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroup.DataField = "Pure_GoodsMGroup";
            this.MgrFt_Pure_GoodsMGroup.Height = 0.16F;
            this.MgrFt_Pure_GoodsMGroup.Left = 1.9375F;
            this.MgrFt_Pure_GoodsMGroup.MultiLine = false;
            this.MgrFt_Pure_GoodsMGroup.Name = "MgrFt_Pure_GoodsMGroup";
            this.MgrFt_Pure_GoodsMGroup.OutputFormat = resources.GetString("MgrFt_Pure_GoodsMGroup.OutputFormat");
            this.MgrFt_Pure_GoodsMGroup.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.MgrFt_Pure_GoodsMGroup.Text = "1234";
            this.MgrFt_Pure_GoodsMGroup.Top = 0.0625F;
            this.MgrFt_Pure_GoodsMGroup.Width = 0.32F;
            // 
            // MgrFt_Pure_StockTotalSalesCountSum
            // 
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_StockTotalSalesCountSum.DataField = "Pure_StockTotalSalesCountSum";
            this.MgrFt_Pure_StockTotalSalesCountSum.Height = 0.156F;
            this.MgrFt_Pure_StockTotalSalesCountSum.Left = 1.9375F;
            this.MgrFt_Pure_StockTotalSalesCountSum.MultiLine = false;
            this.MgrFt_Pure_StockTotalSalesCountSum.Name = "MgrFt_Pure_StockTotalSalesCountSum";
            this.MgrFt_Pure_StockTotalSalesCountSum.OutputFormat = resources.GetString("MgrFt_Pure_StockTotalSalesCountSum.OutputFormat");
            this.MgrFt_Pure_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MgrFt_Pure_StockTotalSalesCountSum.SummaryGroup = "GoodsMGroupHeader";
            this.MgrFt_Pure_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MgrFt_Pure_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MgrFt_Pure_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.MgrFt_Pure_StockTotalSalesCountSum.Top = 0.25F;
            this.MgrFt_Pure_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox68
            // 
            this.textBox68.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.RightColor = System.Drawing.Color.Black;
            this.textBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.TopColor = System.Drawing.Color.Black;
            this.textBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.DataField = "";
            this.textBox68.Height = 0.156F;
            this.textBox68.Left = 2.625F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
            this.textBox68.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox68.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox68.Text = "/";
            this.textBox68.Top = 0.25F;
            this.textBox68.Width = 0.1F;
            // 
            // MgrFt_Pure_OrderTotalSalesCountSum
            // 
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_OrderTotalSalesCountSum.DataField = "Pure_OrderTotalSalesCountSum";
            this.MgrFt_Pure_OrderTotalSalesCountSum.Height = 0.156F;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Left = 2.75F;
            this.MgrFt_Pure_OrderTotalSalesCountSum.MultiLine = false;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Name = "MgrFt_Pure_OrderTotalSalesCountSum";
            this.MgrFt_Pure_OrderTotalSalesCountSum.OutputFormat = resources.GetString("MgrFt_Pure_OrderTotalSalesCountSum.OutputFormat");
            this.MgrFt_Pure_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MgrFt_Pure_OrderTotalSalesCountSum.SummaryGroup = "GoodsMGroupHeader";
            this.MgrFt_Pure_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MgrFt_Pure_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.MgrFt_Pure_OrderTotalSalesCountSum.Top = 0.25F;
            this.MgrFt_Pure_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // MgrFt_Pure_GoodsMGroupName
            // 
            this.MgrFt_Pure_GoodsMGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.MgrFt_Pure_GoodsMGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Pure_GoodsMGroupName.DataField = "Pure_GoodsMGroupName";
            this.MgrFt_Pure_GoodsMGroupName.Height = 0.156F;
            this.MgrFt_Pure_GoodsMGroupName.Left = 2.3125F;
            this.MgrFt_Pure_GoodsMGroupName.MultiLine = false;
            this.MgrFt_Pure_GoodsMGroupName.Name = "MgrFt_Pure_GoodsMGroupName";
            this.MgrFt_Pure_GoodsMGroupName.OutputFormat = resources.GetString("MgrFt_Pure_GoodsMGroupName.OutputFormat");
            this.MgrFt_Pure_GoodsMGroupName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.MgrFt_Pure_GoodsMGroupName.Text = "あいうえおかきくけこ";
            this.MgrFt_Pure_GoodsMGroupName.Top = 0.0625F;
            this.MgrFt_Pure_GoodsMGroupName.Width = 1.2F;
            // 
            // MgrFt_Parts_StockTotalSalesCountSum
            // 
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_StockTotalSalesCountSum.DataField = "Parts_StockTotalSalesCountSum";
            this.MgrFt_Parts_StockTotalSalesCountSum.Height = 0.156F;
            this.MgrFt_Parts_StockTotalSalesCountSum.Left = 5.625F;
            this.MgrFt_Parts_StockTotalSalesCountSum.MultiLine = false;
            this.MgrFt_Parts_StockTotalSalesCountSum.Name = "MgrFt_Parts_StockTotalSalesCountSum";
            this.MgrFt_Parts_StockTotalSalesCountSum.OutputFormat = resources.GetString("MgrFt_Parts_StockTotalSalesCountSum.OutputFormat");
            this.MgrFt_Parts_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MgrFt_Parts_StockTotalSalesCountSum.SummaryGroup = "GoodsMGroupHeader";
            this.MgrFt_Parts_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MgrFt_Parts_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MgrFt_Parts_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.MgrFt_Parts_StockTotalSalesCountSum.Top = 0.25F;
            this.MgrFt_Parts_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox80
            // 
            this.textBox80.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox80.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox80.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.RightColor = System.Drawing.Color.Black;
            this.textBox80.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.Border.TopColor = System.Drawing.Color.Black;
            this.textBox80.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox80.DataField = "";
            this.textBox80.Height = 0.156F;
            this.textBox80.Left = 6.3125F;
            this.textBox80.MultiLine = false;
            this.textBox80.Name = "textBox80";
            this.textBox80.OutputFormat = resources.GetString("textBox80.OutputFormat");
            this.textBox80.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox80.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox80.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox80.Text = "/";
            this.textBox80.Top = 0.25F;
            this.textBox80.Width = 0.1F;
            // 
            // MgrFt_Parts_OrderTotalSalesCountSum
            // 
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MgrFt_Parts_OrderTotalSalesCountSum.DataField = "Parts_OrderTotalSalesCountSum";
            this.MgrFt_Parts_OrderTotalSalesCountSum.Height = 0.156F;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Left = 6.4375F;
            this.MgrFt_Parts_OrderTotalSalesCountSum.MultiLine = false;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Name = "MgrFt_Parts_OrderTotalSalesCountSum";
            this.MgrFt_Parts_OrderTotalSalesCountSum.OutputFormat = resources.GetString("MgrFt_Parts_OrderTotalSalesCountSum.OutputFormat");
            this.MgrFt_Parts_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.MgrFt_Parts_OrderTotalSalesCountSum.SummaryGroup = "GoodsMGroupHeader";
            this.MgrFt_Parts_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MgrFt_Parts_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.MgrFt_Parts_OrderTotalSalesCountSum.Top = 0.25F;
            this.MgrFt_Parts_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // BLGroupCodeHeader
            // 
            this.BLGroupCodeHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.BLGroupCodeHeader.Height = 0F;
            this.BLGroupCodeHeader.KeepTogether = true;
            this.BLGroupCodeHeader.Name = "BLGroupCodeHeader";
            this.BLGroupCodeHeader.Visible = false;
            // 
            // BLGroupCodeFooter
            // 
            this.BLGroupCodeFooter.CanShrink = true;
            this.BLGroupCodeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox59,
            this.line8,
            this.GroFt_Pure_StockTotalSalesCountSum,
            this.GroFt_Pure_BLGroupCode,
            this.textBox73,
            this.GroFt_Pure_OrderTotalSalesCountSum,
            this.GroFt_Pure_BLGroupCodeName,
            this.GroFt_Parts_StockTotalSalesCountSum,
            this.textBox77,
            this.GroFt_Parts_OrderTotalSalesCountSum});
            this.BLGroupCodeFooter.Height = 0.5104167F;
            this.BLGroupCodeFooter.KeepTogether = true;
            this.BLGroupCodeFooter.Name = "BLGroupCodeFooter";
            this.BLGroupCodeFooter.Visible = false;
            this.BLGroupCodeFooter.BeforePrint += new System.EventHandler(this.BLGroupCodeFooter_BeforePrint);
            // 
            // textBox59
            // 
            this.textBox59.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.RightColor = System.Drawing.Color.Black;
            this.textBox59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.TopColor = System.Drawing.Color.Black;
            this.textBox59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Height = 0.19F;
            this.textBox59.Left = 0.625F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox59.Text = "グループコード計";
            this.textBox59.Top = 0.0625F;
            this.textBox59.Width = 1.3F;
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
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0F;
            this.line8.Width = 10.8125F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8125F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // GroFt_Pure_StockTotalSalesCountSum
            // 
            this.GroFt_Pure_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GroFt_Pure_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_StockTotalSalesCountSum.DataField = "Pure_StockTotalSalesCountSum";
            this.GroFt_Pure_StockTotalSalesCountSum.Height = 0.156F;
            this.GroFt_Pure_StockTotalSalesCountSum.Left = 1.9375F;
            this.GroFt_Pure_StockTotalSalesCountSum.MultiLine = false;
            this.GroFt_Pure_StockTotalSalesCountSum.Name = "GroFt_Pure_StockTotalSalesCountSum";
            this.GroFt_Pure_StockTotalSalesCountSum.OutputFormat = resources.GetString("GroFt_Pure_StockTotalSalesCountSum.OutputFormat");
            this.GroFt_Pure_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GroFt_Pure_StockTotalSalesCountSum.SummaryGroup = "BLGroupCodeHeader";
            this.GroFt_Pure_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GroFt_Pure_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GroFt_Pure_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.GroFt_Pure_StockTotalSalesCountSum.Top = 0.25F;
            this.GroFt_Pure_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // GroFt_Pure_BLGroupCode
            // 
            this.GroFt_Pure_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCode.DataField = "Pure_BLGroupCode";
            this.GroFt_Pure_BLGroupCode.Height = 0.16F;
            this.GroFt_Pure_BLGroupCode.Left = 1.9375F;
            this.GroFt_Pure_BLGroupCode.MultiLine = false;
            this.GroFt_Pure_BLGroupCode.Name = "GroFt_Pure_BLGroupCode";
            this.GroFt_Pure_BLGroupCode.OutputFormat = resources.GetString("GroFt_Pure_BLGroupCode.OutputFormat");
            this.GroFt_Pure_BLGroupCode.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GroFt_Pure_BLGroupCode.Text = "12345";
            this.GroFt_Pure_BLGroupCode.Top = 0.0625F;
            this.GroFt_Pure_BLGroupCode.Width = 0.32F;
            // 
            // textBox73
            // 
            this.textBox73.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.RightColor = System.Drawing.Color.Black;
            this.textBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.TopColor = System.Drawing.Color.Black;
            this.textBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.DataField = "";
            this.textBox73.Height = 0.156F;
            this.textBox73.Left = 2.625F;
            this.textBox73.MultiLine = false;
            this.textBox73.Name = "textBox73";
            this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
            this.textBox73.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox73.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox73.Text = "/";
            this.textBox73.Top = 0.25F;
            this.textBox73.Width = 0.1F;
            // 
            // GroFt_Pure_OrderTotalSalesCountSum
            // 
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GroFt_Pure_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_OrderTotalSalesCountSum.DataField = "Pure_OrderTotalSalesCountSum";
            this.GroFt_Pure_OrderTotalSalesCountSum.Height = 0.156F;
            this.GroFt_Pure_OrderTotalSalesCountSum.Left = 2.75F;
            this.GroFt_Pure_OrderTotalSalesCountSum.MultiLine = false;
            this.GroFt_Pure_OrderTotalSalesCountSum.Name = "GroFt_Pure_OrderTotalSalesCountSum";
            this.GroFt_Pure_OrderTotalSalesCountSum.OutputFormat = resources.GetString("GroFt_Pure_OrderTotalSalesCountSum.OutputFormat");
            this.GroFt_Pure_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GroFt_Pure_OrderTotalSalesCountSum.SummaryGroup = "BLGroupCodeHeader";
            this.GroFt_Pure_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GroFt_Pure_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GroFt_Pure_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.GroFt_Pure_OrderTotalSalesCountSum.Top = 0.25F;
            this.GroFt_Pure_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // GroFt_Pure_BLGroupCodeName
            // 
            this.GroFt_Pure_BLGroupCodeName.Border.BottomColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCodeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCodeName.Border.LeftColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCodeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCodeName.Border.RightColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCodeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCodeName.Border.TopColor = System.Drawing.Color.Black;
            this.GroFt_Pure_BLGroupCodeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Pure_BLGroupCodeName.DataField = "Pure_BLGroupCodeName";
            this.GroFt_Pure_BLGroupCodeName.Height = 0.156F;
            this.GroFt_Pure_BLGroupCodeName.Left = 2.3125F;
            this.GroFt_Pure_BLGroupCodeName.MultiLine = false;
            this.GroFt_Pure_BLGroupCodeName.Name = "GroFt_Pure_BLGroupCodeName";
            this.GroFt_Pure_BLGroupCodeName.OutputFormat = resources.GetString("GroFt_Pure_BLGroupCodeName.OutputFormat");
            this.GroFt_Pure_BLGroupCodeName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GroFt_Pure_BLGroupCodeName.Text = "あいうえおかきくけこ";
            this.GroFt_Pure_BLGroupCodeName.Top = 0.0625F;
            this.GroFt_Pure_BLGroupCodeName.Width = 1.2F;
            // 
            // GroFt_Parts_StockTotalSalesCountSum
            // 
            this.GroFt_Parts_StockTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GroFt_Parts_StockTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_StockTotalSalesCountSum.DataField = "Parts_StockTotalSalesCountSum";
            this.GroFt_Parts_StockTotalSalesCountSum.Height = 0.156F;
            this.GroFt_Parts_StockTotalSalesCountSum.Left = 5.625F;
            this.GroFt_Parts_StockTotalSalesCountSum.MultiLine = false;
            this.GroFt_Parts_StockTotalSalesCountSum.Name = "GroFt_Parts_StockTotalSalesCountSum";
            this.GroFt_Parts_StockTotalSalesCountSum.OutputFormat = resources.GetString("GroFt_Parts_StockTotalSalesCountSum.OutputFormat");
            this.GroFt_Parts_StockTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GroFt_Parts_StockTotalSalesCountSum.SummaryGroup = "BLGroupCodeHeader";
            this.GroFt_Parts_StockTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GroFt_Parts_StockTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GroFt_Parts_StockTotalSalesCountSum.Text = "1,234,567.00";
            this.GroFt_Parts_StockTotalSalesCountSum.Top = 0.25F;
            this.GroFt_Parts_StockTotalSalesCountSum.Width = 0.7F;
            // 
            // textBox77
            // 
            this.textBox77.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox77.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox77.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.RightColor = System.Drawing.Color.Black;
            this.textBox77.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.Border.TopColor = System.Drawing.Color.Black;
            this.textBox77.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox77.DataField = "";
            this.textBox77.Height = 0.156F;
            this.textBox77.Left = 6.3125F;
            this.textBox77.MultiLine = false;
            this.textBox77.Name = "textBox77";
            this.textBox77.OutputFormat = resources.GetString("textBox77.OutputFormat");
            this.textBox77.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox77.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox77.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox77.Text = "/";
            this.textBox77.Top = 0.25F;
            this.textBox77.Width = 0.1F;
            // 
            // GroFt_Parts_OrderTotalSalesCountSum
            // 
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.BottomColor = System.Drawing.Color.Black;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.LeftColor = System.Drawing.Color.Black;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.RightColor = System.Drawing.Color.Black;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.TopColor = System.Drawing.Color.Black;
            this.GroFt_Parts_OrderTotalSalesCountSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GroFt_Parts_OrderTotalSalesCountSum.DataField = "Parts_OrderTotalSalesCountSum";
            this.GroFt_Parts_OrderTotalSalesCountSum.Height = 0.156F;
            this.GroFt_Parts_OrderTotalSalesCountSum.Left = 6.4375F;
            this.GroFt_Parts_OrderTotalSalesCountSum.MultiLine = false;
            this.GroFt_Parts_OrderTotalSalesCountSum.Name = "GroFt_Parts_OrderTotalSalesCountSum";
            this.GroFt_Parts_OrderTotalSalesCountSum.OutputFormat = resources.GetString("GroFt_Parts_OrderTotalSalesCountSum.OutputFormat");
            this.GroFt_Parts_OrderTotalSalesCountSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.GroFt_Parts_OrderTotalSalesCountSum.SummaryGroup = "BLGroupCodeHeader";
            this.GroFt_Parts_OrderTotalSalesCountSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.GroFt_Parts_OrderTotalSalesCountSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.GroFt_Parts_OrderTotalSalesCountSum.Text = "1,234,567.00";
            this.GroFt_Parts_OrderTotalSalesCountSum.Top = 0.25F;
            this.GroFt_Parts_OrderTotalSalesCountSum.Width = 0.7F;
            // 
            // PMHNB02143P_01A4C
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
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.875F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.GoodsMakerHeader);
            this.Sections.Add(this.GoodsMGroupHeader);
            this.Sections.Add(this.BLGroupCodeHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.BLGroupCodeFooter);
            this.Sections.Add(this.GoodsMGroupFooter);
            this.Sections.Add(this.GoodsMakerFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMHNB02143P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_StockTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_OrderTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_Separator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_StockTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_OrderTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_Separator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_StockTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_OrderTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_Separator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_GoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_SupplierStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_GoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_SuplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_MakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_Separator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts1_SupplierStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_SuplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_MakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_Separator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_GoodsPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts2_SupplierStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pure_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parts_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Pure_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox89)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Pure_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Parts_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraFt_Parts_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecHd_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Pure_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Pure_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Parts_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_Parts_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox98)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_MakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Pure_GoodsMakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Parts_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox83)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_Parts_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Pure_GoodsMGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Parts_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MgrFt_Parts_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Pure_BLGroupCodeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Parts_StockTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroFt_Parts_OrderTotalSalesCountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

    }
}
