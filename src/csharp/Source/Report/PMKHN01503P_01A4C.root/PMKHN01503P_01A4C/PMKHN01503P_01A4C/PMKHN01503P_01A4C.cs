//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : caohh
// 作 成 日  2011/07/21  修正内容 : 連番No.2 新規作成                      
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
//****************************************************************************//
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// 優良データ削除処理 印刷フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 優良データ削除処理のフォームクラスです。</br>
    /// <br>Programmer   : caohh</br>
    /// <br>Date         : 2011/07/21</br>
    /// <br>Update Note  : </br>
    /// <br>             : </br>
    /// </remarks>
    public class PMKHN01503P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// 優良データ削除処理フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : 優良データ削除処理フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : caohh</br>
        /// <br>Date         : 2011/07/21</br>
        /// </remarks>
        public PMKHN01503P_01A4C ()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        private int _printCount;				    // 印刷件数用カウンタ
        private int _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;	// 抽出条件
        private int _pageFooterOutCode;				// フッター出力区分
        private StringCollection _pageFooters;		// フッターメッセージ
        private SFCMN06002C _printInfo;				// 印刷情報クラス
        private string _pageHeaderTitle;			// フォームタイトル
        private string _pageHeaderSortOderTitle;	// ソート順

        private DeleteCondition _deleteCondition;	// 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        #region ActiveReport項目

        private TextBox WarehouseName;
        private TextBox BLGoodsCode;
        private TextBox WarehouseShelfNo;
        private TextBox ShipmentPosCnt;
        private TextBox SalesOrderCount;
        private Label Lb_WarehouseShelfNo;
        private Label Lb_ShipmentPosCnt;
        private Label Lb_SalesOrderCount;
        private TextBox MakerName;

        // Disposeチェック用フラグ
        bool disposed = false;

        // フォーマット文字列
        private const string ct_DateFomat = "YYYY/MM/DD";
        private SubReport Header_SubReport;
        #endregion

        #endregion ■ Private Member

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose ( bool disposing )
        {
            if ( !this.disposed )
            {
                try
                {
                    if ( disposing )
                    {
                        // ヘッダ用サブレポート後処理実行
                        if ( this._rptExtraHeader != null )
                        {
                            this._rptExtraHeader.Dispose();
                        }

                        // フッタ用サブレポート後処理実行
                        if ( this._rptPageFooter != null )
                        {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally
                {
                    base.Dispose( disposing );
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
                this._deleteCondition = (DeleteCondition)this._printInfo.jyoken;
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
                // TODO:  DCZAI02103P_01A4C.WatermarkMode getter 実装を追加します。
                return 0;
            }
            set
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// <br>Update Note : </br>
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            this._printCount = 0;
        }
        #endregion ◆ レポート要素出力設定
        #endregion

        #region ■ Control Event

        #region ◎ PMKHN01503P_01A4C_ReportStart Event
        /// <summary>
        /// PMKHN01503P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void PMKHN01503P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void PageHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString( ct_DateFomat, DateTime.Now );
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString( "HH:mm" );
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
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
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
        #endregion

        #region ◎ Detail_Format Event
        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Detailグループのフォーマットイベント。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void Detail_Format ( object sender, System.EventArgs eArgs )
        {
        }
        #endregion

        #region ◎ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString( this.Detail );
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
        /// <br>Programmer  : caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if ( this.ProgressBarUpEvent != null )
            {
                this.ProgressBarUpEvent( this, this._printCount );
            }
        }
        #endregion

        #region ◎ DailyFooter_Format Event
        /// <summary>
        /// DailyFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DailyFooter_Format Event</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void DailyFooter_Format ( object sender, System.EventArgs eArgs )
        {
        }
        #endregion

        #region ◎ PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/07/21</br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
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

        #endregion ■ Control Event

        #region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.TextBox tb_PrintDate;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Label Lb_GoodsNo;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_MakerName;
        private DataDynamics.ActiveReports.Label Lb_Warehouse;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox GoodsNameKana;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
        private DataDynamics.ActiveReports.TextBox WarehouseCode;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        private DataDynamics.ActiveReports.Line Line41;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
        public void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN01503P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNameKana = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesOrderCount = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Lb_Warehouse = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesOrderCount = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.GoodsNameKana,
            this.GoodsMakerCd,
            this.WarehouseCode,
            this.WarehouseName,
            this.BLGoodsCode,
            this.WarehouseShelfNo,
            this.ShipmentPosCnt,
            this.SalesOrderCount,
            this.MakerName});
            this.Detail.Height = 0.1979167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.1574803F;
            this.GoodsNo.Left = 1.818898F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.850394F;
            // 
            // GoodsNameKana
            // 
            this.GoodsNameKana.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameKana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameKana.DataField = "GoodsName";
            this.GoodsNameKana.Height = 0.1574803F;
            this.GoodsNameKana.Left = 4.043307F;
            this.GoodsNameKana.MultiLine = false;
            this.GoodsNameKana.Name = "GoodsNameKana";
            this.GoodsNameKana.OutputFormat = resources.GetString("GoodsNameKana.OutputFormat");
            this.GoodsNameKana.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.GoodsNameKana.Text = "1234567890123456789012345678901234567899";
            this.GoodsNameKana.Top = 0F;
            this.GoodsNameKana.Width = 3.07874F;
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.156F;
            this.GoodsMakerCd.Left = 0F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.33F;
            // 
            // WarehouseCode
            // 
            this.WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode.DataField = "WarehouseCode";
            this.WarehouseCode.Height = 0.156F;
            this.WarehouseCode.Left = 7.062993F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.WarehouseCode.Text = "12345";
            this.WarehouseCode.Top = 0F;
            this.WarehouseCode.Width = 0.34F;
            // 
            // WarehouseName
            // 
            this.WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseName.DataField = "WarehouseName";
            this.WarehouseName.Height = 0.156F;
            this.WarehouseName.Left = 7.393701F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OutputFormat = resources.GetString("WarehouseName.OutputFormat");
            this.WarehouseName.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.WarehouseName.Text = "12345678901234567890";
            this.WarehouseName.Top = 0F;
            this.WarehouseName.Width = 1.53F;
            // 
            // BLGoodsCode
            // 
            this.BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsCode.DataField = "BLGoodsCode";
            this.BLGoodsCode.Height = 0.156F;
            this.BLGoodsCode.Left = 3.653543F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0F;
            this.BLGoodsCode.Width = 0.41F;
            // 
            // WarehouseShelfNo
            // 
            this.WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo.Height = 0.156F;
            this.WarehouseShelfNo.Left = 8.929134F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.WarehouseShelfNo.Text = "123456789";
            this.WarehouseShelfNo.Top = 0F;
            this.WarehouseShelfNo.Width = 0.65F;
            // 
            // ShipmentPosCnt
            // 
            this.ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentPosCnt.DataField = "ShipmentPosCnt";
            this.ShipmentPosCnt.Height = 0.156F;
            this.ShipmentPosCnt.Left = 9.543307F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 1; text-align: right; font-size: 10.8pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.ShipmentPosCnt.Text = "123,456,789";
            this.ShipmentPosCnt.Top = 0F;
            this.ShipmentPosCnt.Width = 0.87F;
            // 
            // SalesOrderCount
            // 
            this.SalesOrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.SalesOrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesOrderCount.DataField = "SalesOrderCount";
            this.SalesOrderCount.Height = 0.156F;
            this.SalesOrderCount.Left = 10.38976F;
            this.SalesOrderCount.MultiLine = false;
            this.SalesOrderCount.Name = "SalesOrderCount";
            this.SalesOrderCount.OutputFormat = resources.GetString("SalesOrderCount.OutputFormat");
            this.SalesOrderCount.Style = "ddo-char-set: 1; text-align: right; font-size: 10.8pt; font-family: ＭＳ ゴシック; vert" +
                "ical-align: top; ";
            this.SalesOrderCount.Text = "123,456,789";
            this.SalesOrderCount.Top = 0F;
            this.SalesOrderCount.Width = 0.87F;
            // 
            // MakerName
            // 
            this.MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerName.DataField = "MakerName";
            this.MakerName.Height = 0.156F;
            this.MakerName.Left = 0.3149606F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 1; text-align: left; font-size: 10.8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこ";
            this.MakerName.Top = 0F;
            this.MakerName.Width = 1.588F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_ReportTitle});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.Label3.Left = 8.439961F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0738189F;
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
            this.tb_PrintDate.Left = 9.005906F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0738189F;
            this.tb_PrintDate.Width = 0.9375F;
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
            this.Label2.Left = 10.45768F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0738189F;
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
            this.tb_PrintPage.Left = 10.9498F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0738189F;
            this.tb_PrintPage.Width = 0.28125F;
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
            this.Line1.Top = 0.2085F;
            this.Line1.Width = 11.25984F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 11.25984F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
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
            this.tb_PrintTime.Left = 9.940946F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0738189F;
            this.tb_PrintTime.Width = 0.5F;
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
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "優良データ削除チェックリスト(削除)";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.40625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2388889F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
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
            this.ExtraHeader.Height = 0.2604167F;
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
            this.Header_SubReport.Height = 0.2480315F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 11.02362F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line42,
            this.Lb_GoodsName,
            this.Lb_MakerName,
            this.Lb_Warehouse,
            this.Lb_GoodsNo,
            this.Lb_WarehouseShelfNo,
            this.Lb_ShipmentPosCnt,
            this.Lb_SalesOrderCount});
            this.TitleHeader.Height = 0.3854167F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line42
            // 
            this.Line42.Border.BottomColor = System.Drawing.Color.Black;
            this.Line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.LeftColor = System.Drawing.Color.Black;
            this.Line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.RightColor = System.Drawing.Color.Black;
            this.Line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.TopColor = System.Drawing.Color.Black;
            this.Line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Height = 0F;
            this.Line42.Left = 0F;
            this.Line42.LineWeight = 2F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0.375F;
            this.Line42.Width = 11.25984F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 11.25984F;
            this.Line42.Y1 = 0.375F;
            this.Line42.Y2 = 0.375F;
            // 
            // Lb_GoodsName
            // 
            this.Lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Height = 0.15625F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 3.653543F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.1889764F;
            this.Lb_GoodsName.Width = 0.75F;
            // 
            // Lb_MakerName
            // 
            this.Lb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Height = 0.156F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 0F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MakerName.Text = "メーカー";
            this.Lb_MakerName.Top = 0.1875F;
            this.Lb_MakerName.Width = 0.8F;
            // 
            // Lb_Warehouse
            // 
            this.Lb_Warehouse.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Warehouse.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Warehouse.Height = 0.156F;
            this.Lb_Warehouse.HyperLink = "";
            this.Lb_Warehouse.Left = 7.062993F;
            this.Lb_Warehouse.MultiLine = false;
            this.Lb_Warehouse.Name = "Lb_Warehouse";
            this.Lb_Warehouse.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Warehouse.Text = "倉庫";
            this.Lb_Warehouse.Top = 0.1889764F;
            this.Lb_Warehouse.Width = 0.7F;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 1.818898F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.1889764F;
            this.Lb_GoodsNo.Width = 0.75F;
            // 
            // Lb_WarehouseShelfNo
            // 
            this.Lb_WarehouseShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseShelfNo.Height = 0.156F;
            this.Lb_WarehouseShelfNo.HyperLink = "";
            this.Lb_WarehouseShelfNo.Left = 8.929134F;
            this.Lb_WarehouseShelfNo.MultiLine = false;
            this.Lb_WarehouseShelfNo.Name = "Lb_WarehouseShelfNo";
            this.Lb_WarehouseShelfNo.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo.Text = "棚番";
            this.Lb_WarehouseShelfNo.Top = 0.1889764F;
            this.Lb_WarehouseShelfNo.Width = 0.5F;
            // 
            // Lb_ShipmentPosCnt
            // 
            this.Lb_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentPosCnt.Height = 0.156F;
            this.Lb_ShipmentPosCnt.HyperLink = "";
            this.Lb_ShipmentPosCnt.Left = 9.527559F;
            this.Lb_ShipmentPosCnt.MultiLine = false;
            this.Lb_ShipmentPosCnt.Name = "Lb_ShipmentPosCnt";
            this.Lb_ShipmentPosCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentPosCnt.Text = "現在庫数";
            this.Lb_ShipmentPosCnt.Top = 0.1889764F;
            this.Lb_ShipmentPosCnt.Width = 0.87F;
            // 
            // Lb_SalesOrderCount
            // 
            this.Lb_SalesOrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesOrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesOrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesOrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesOrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesOrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesOrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesOrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesOrderCount.Height = 0.156F;
            this.Lb_SalesOrderCount.HyperLink = "";
            this.Lb_SalesOrderCount.Left = 10.38189F;
            this.Lb_SalesOrderCount.MultiLine = false;
            this.Lb_SalesOrderCount.Name = "Lb_SalesOrderCount";
            this.Lb_SalesOrderCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 10.8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesOrderCount.Text = "発注残";
            this.Lb_SalesOrderCount.Top = 0.1889764F;
            this.Lb_SalesOrderCount.Width = 0.87F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // Line41
            // 
            this.Line41.Border.BottomColor = System.Drawing.Color.Black;
            this.Line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.LeftColor = System.Drawing.Color.Black;
            this.Line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.RightColor = System.Drawing.Color.Black;
            this.Line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.TopColor = System.Drawing.Color.Black;
            this.Line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Height = 0F;
            this.Line41.Left = 0F;
            this.Line41.LineWeight = 2F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 11.25984F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 11.25984F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
            // 
            // PMKHN01503P_01A4C
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
            this.PrintWidth = 11.27083F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMKHN01503P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameKana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion


        
    }
}
