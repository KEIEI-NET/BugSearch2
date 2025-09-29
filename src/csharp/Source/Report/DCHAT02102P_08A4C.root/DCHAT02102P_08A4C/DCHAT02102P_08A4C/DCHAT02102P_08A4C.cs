//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ㈱ダイサブ発注残一覧
// プログラム概要   : ㈱ダイサブ発注残一覧印刷フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11570226-00  作成担当 : 譚洪
// 作 成 日  K2019/11/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
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
	/// 発注残一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 発注残一覧表のフォームクラスです。</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : K2019/11/06</br>
    /// </remarks>
	public class DCHAT02102P_08A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 発注残一覧表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : 発注残一覧表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 譚洪</br>
        /// <br>Date         : K2019/11/06</br>
        /// </remarks>
		public DCHAT02102P_08A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int PrintCount;									    // 印刷件数用カウンタ

		private int					DaExtraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	DaExtraConditions;				// 抽出条件
		private int					DaPageFooterOutCode;			// フッター出力区分
		private StringCollection	DaPageFooters;					// フッターメッセージ
		private	SFCMN06002C			DaPrintInfo;					// 印刷情報クラス
		private string				DaPageHeaderTitle;				// フォームタイトル
		private string				DaPageHeaderSortOderTitle;		// ソート順

        private OrderListCndtn DaOrderListCndtn;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader RptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter RptPageFooter = null;
        private Label Lb_OrderFormPrintDate;
        private GroupFooter Footer1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox ProcessDay;
        private TextBox SectionCode;
        private TextBox SectionGuideSnm;
        private TextBox WarehouseCode;
        private TextBox EnterpriseName1;
        private TextBox EnterpriseName2;
        private Label label16;
        private TextBox EnterpriseTel;
        private Label label17;
        private TextBox EnterpriseFax;
        private Label Lb_MinStockCount;
        private Label Lb_MaxStockCount;
        private Label Lb_ShipmentCnt;
        private TextBox SupplierCodePrint;
        private Line line10;
        private TextBox SupplierName;
        private TextBox ShipmentPosCnt;
        private TextBox MinimumStockCnt;
        private TextBox MaximumStockCnt;
        private TextBox ShipmentCnt;
        private TextBox DetailCount;
        private TextBox f_SalesOrderCount;
        private Label label1;
        private TextBox WarehouseName;
        private Label Lb_GoodsMakerCd;
        private GroupHeader Header1;
        private GroupHeader Header2;
        private TextBox GoodsMakerCd;
        private TextBox MakerName;
        private GroupFooter Footer2;
        private Line line2;
        private Label Lb1_OrderFormPrintDate;
        private Label Lb1_ExpectDeliveryDate;
        private Label Lb1_SalesOrderCount;
        private Label Lb1_ShipmentPosCnt;
        private Label Lb1_MinStockCount;
        private Label Lb1_MaxStockCount;
        private Label Lb1_ShipmentCnt;
        private Label Lb1_MakerName;

		// Disposeチェック用フラグ
		bool DaDisposed = false;

		#endregion ■ Private Member

		#region ■ Dispose(override)
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(!this.DaDisposed)
			{
				try
				{
					if(disposing)
					{
						// ヘッダ用サブレポート後処理実行
						if (this.RptExtraHeader != null)
						{
							this.RptExtraHeader.Dispose();
						}

						// フッタ用サブレポート後処理実行
						if (this.RptPageFooter != null)
						{
							this.RptPageFooter.Dispose();
						}
					}

					this.DaDisposed = true;
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
			set{ DaPageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ DaExtraCondHeadOutDiv = value; }
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set{ this.DaExtraConditions = value; }
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set{ this.DaPageFooterOutCode = value; }
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set{ this.DaPageFooters = value; }
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this.DaPrintInfo			= value;
				this.DaOrderListCndtn	= (OrderListCndtn)this.DaPrintInfo.jyoken;
			}
		}

		/// <summary>
		/// その他データ
		/// </summary>
		public ArrayList OtherDataList
		{
			set	{ }
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this.DaPageHeaderTitle = value;}
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this.PrintCount = 0;
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this.DaPageHeaderTitle;				// サブタイトル

            if (this.DaOrderListCndtn.NewPageDiv == 1)
            {
                // 改頁しない
                Header1.NewPage = NewPage.None;
            }

            // メーカーコード印字しない
            if (this.DaOrderListCndtn.MakerCdDiv == 1)
            {
                Header2.Visible = false;
                line2.Visible = false;
                Lb_GoodsMakerCd.Visible = false;

                Lb1_MakerName.Visible = true;
                Lb1_OrderFormPrintDate.Visible = true;
                Lb1_ExpectDeliveryDate.Visible = true;
                Lb1_SalesOrderCount.Visible = true;
                Lb1_ShipmentPosCnt.Visible = true;
                Lb1_MinStockCount.Visible = true;
                Lb1_MaxStockCount.Visible = true;
                Lb1_ShipmentCnt.Visible = true;

                Lb_MakerName.Visible = false;
                Lb_OrderFormPrintDate.Visible = false;
                Lb_ExpectDeliveryDate.Visible = false;
                Lb_SalesOrderCount.Visible = false;
                Lb_ShipmentPosCnt.Visible = false;
                Lb_MinStockCount.Visible = false;
                Lb_MaxStockCount.Visible = false;
                Lb_ShipmentCnt.Visible = false;
            }

            if (this.DaOrderListCndtn.StockMinMaxPrintDiv == 1)
            {
                // 現在庫・最低・最高を印字しない
                Lb_ShipmentPosCnt.Visible = false;
                Lb_MinStockCount.Visible = false;
                Lb_MaxStockCount.Visible = false;

                Lb1_ShipmentPosCnt.Visible = false;
                Lb1_MinStockCount.Visible = false;
                Lb1_MaxStockCount.Visible = false;

                ShipmentPosCnt.Visible = false;
                MinimumStockCnt.Visible = false;
                MaximumStockCnt.Visible = false;
            }

            if (this.DaOrderListCndtn.LendCntPrintDiv == 1)
            {
                // 貸出数を印字しない
                Lb_ShipmentCnt.Visible = false;
                Lb1_ShipmentCnt.Visible = false;
                ShipmentCnt.Visible = false;
            }
        }
		#endregion ◆ レポート要素出力設定
		#endregion

		#region ■ Control Event

        #region ◎ DCHAT02102P_08A4C_ReportStart Event
        /// <summary>
        /// DCHAT02102P_08A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void DCHAT02102P_08A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( OrderListCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 抽出条件設定
			// ヘッダ出力制御
			if (this.DaExtraCondHeadOutDiv == 0)
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
			if ( this.RptExtraHeader == null)
			{
				this.RptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				// インスタンスが作成されていれば、データソースを初期化する
				// (バインドするデータソースが同じデータであっても、一度初期化しないとうまく印刷されない為。)
				this.RptExtraHeader.DataSource = null;
			}
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);
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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			this.PrintCount++;
			
			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this.PrintCount);
			}

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
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// フッター出力する？
			if (this.DaPageFooterOutCode == 0)
			{
				// インスタンスが作成されていなければ作成
				if ( RptPageFooter == null)
				{
					RptPageFooter = new ListCommon_PageFooter();
				}
				else
				{
					// インスタンスが作成されていれば、データソースを初期化する
					// (バインドするデータソースが同じデータであっても、一度初期化しないとうまく印刷されない為。)
					RptPageFooter.DataSource = null;
				}
		
				// フッター印字項目設定
				if (this.DaPageFooters[0] != null)
				{
					RptPageFooter.PrintFooter1 = this.DaPageFooters[0];
				}
				if (this.DaPageFooters[1] != null)
				{
					RptPageFooter.PrintFooter2 = this.DaPageFooters[1];
				}

                // フッター部の印字変更
                // 最下行の罫線を印字しないようにサブレポートの設定をコメント化
                this.Footer_SubReport.Report = RptPageFooter;
            }
		}
		#endregion

        #region ◎ ExtraHeader_BeforePrint Event
        /// <summary>
        /// ExtraHeader_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderグループのBeforePrintイベント。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
        /// </remarks>
        private void ExtraHeader_BeforePrint(object sender, EventArgs e)
        {
            // 集計グループをExtraHeaderに設定
            this.DetailCount.SummaryGroup = "ExtraHeader";
            this.f_SalesOrderCount.SummaryGroup = "ExtraHeader";
        }
        #endregion

        #region ◎ Header1_BeforePrint Event
        /// <summary>
        /// Header1_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Header1グループのBeforePrintイベント。</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : K2019/11/06</br>
        /// </remarks>
        private void Header1_BeforePrint(object sender, EventArgs e)
        {
            // 集計グループをHeader1に設定
            this.DetailCount.SummaryGroup = "Header1";
            this.f_SalesOrderCount.SummaryGroup = "Header1";
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
        private DataDynamics.ActiveReports.Label Lb_SalesOrderCount;
		private DataDynamics.ActiveReports.Label Lb_ExpectDeliveryDate;
		private DataDynamics.ActiveReports.Label Lb_MakerName;
		private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Label Lb_OrderNumber;
        private DataDynamics.ActiveReports.Label Lb_ShipmentPosCnt;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox WarehouseShelfNo;
		private DataDynamics.ActiveReports.TextBox GoodsName;
        private DataDynamics.ActiveReports.Line Line3;
        private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox SalesOrderCount;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
        private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 帳票コントロール初期化
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHAT02102P_08A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.SalesOrderCount = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
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
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.ProcessDay = new DataDynamics.ActiveReports.TextBox();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.EnterpriseName1 = new DataDynamics.ActiveReports.TextBox();
            this.EnterpriseName2 = new DataDynamics.ActiveReports.TextBox();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.EnterpriseTel = new DataDynamics.ActiveReports.TextBox();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.EnterpriseFax = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_SalesOrderCount = new DataDynamics.ActiveReports.Label();
            this.Lb_OrderFormPrintDate = new DataDynamics.ActiveReports.Label();
            this.Lb_ExpectDeliveryDate = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Lb_OrderNumber = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MinStockCount = new DataDynamics.ActiveReports.Label();
            this.Lb_MaxStockCount = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMakerCd = new DataDynamics.ActiveReports.Label();
            this.Lb1_MakerName = new DataDynamics.ActiveReports.Label();
            this.Lb1_OrderFormPrintDate = new DataDynamics.ActiveReports.Label();
            this.Lb1_ExpectDeliveryDate = new DataDynamics.ActiveReports.Label();
            this.Lb1_SalesOrderCount = new DataDynamics.ActiveReports.Label();
            this.Lb1_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb1_MinStockCount = new DataDynamics.ActiveReports.Label();
            this.Lb1_MaxStockCount = new DataDynamics.ActiveReports.Label();
            this.Lb1_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.DetailCount = new DataDynamics.ActiveReports.TextBox();
            this.f_SalesOrderCount = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Header1 = new DataDynamics.ActiveReports.GroupHeader();
            this.SupplierCodePrint = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.SupplierName = new DataDynamics.ActiveReports.TextBox();
            this.Footer1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Header2 = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Footer2 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderFormPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ExpectDeliveryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinStockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaxStockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_OrderFormPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_ExpectDeliveryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_MinStockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_MaxStockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_SalesOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCodePrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseShelfNo,
            this.GoodsName,
            this.Line3,
            this.GoodsNo,
            this.SalesOrderCount,
            this.ShipmentPosCnt,
            this.MinimumStockCnt,
            this.MaximumStockCnt,
            this.ShipmentCnt});
            this.Detail.Height = 0.1770833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.WarehouseShelfNo.Height = 0.125F;
            this.WarehouseShelfNo.Left = 0F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0F;
            this.WarehouseShelfNo.Width = 0.5625F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 2.239583F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄ";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.25F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0F;
            this.Line3.Left = 0F;
            this.Line3.LineWeight = 2F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 7.8F;
            this.Line3.X1 = 0F;
            this.Line3.X2 = 7.8F;
            this.Line3.Y1 = 0F;
            this.Line3.Y2 = 0F;
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
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 0.6145833F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.4375F;
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
            this.SalesOrderCount.Height = 0.125F;
            this.SalesOrderCount.Left = 3.9375F;
            this.SalesOrderCount.MultiLine = false;
            this.SalesOrderCount.Name = "SalesOrderCount";
            this.SalesOrderCount.OutputFormat = resources.GetString("SalesOrderCount.OutputFormat");
            this.SalesOrderCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesOrderCount.Text = "12,345.00";
            this.SalesOrderCount.Top = 0F;
            this.SalesOrderCount.Width = 0.625F;
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
            this.ShipmentPosCnt.Height = 0.125F;
            this.ShipmentPosCnt.Left = 4.6875F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentPosCnt.Text = "12,345.00";
            this.ShipmentPosCnt.Top = 0F;
            this.ShipmentPosCnt.Width = 0.625F;
            // 
            // MinimumStockCnt
            // 
            this.MinimumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MinimumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MinimumStockCnt.DataField = "MinimumStockCnt";
            this.MinimumStockCnt.Height = 0.125F;
            this.MinimumStockCnt.Left = 5.4375F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MinimumStockCnt.Text = "12,345.00";
            this.MinimumStockCnt.Top = 0F;
            this.MinimumStockCnt.Width = 0.625F;
            // 
            // MaximumStockCnt
            // 
            this.MaximumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MaximumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MaximumStockCnt.DataField = "MaximumStockCnt";
            this.MaximumStockCnt.Height = 0.125F;
            this.MaximumStockCnt.Left = 6.1875F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MaximumStockCnt.Text = "12,345.00";
            this.MaximumStockCnt.Top = 0F;
            this.MaximumStockCnt.Width = 0.625F;
            // 
            // ShipmentCnt
            // 
            this.ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.DataField = "ShipmentCnt";
            this.ShipmentCnt.Height = 0.125F;
            this.ShipmentCnt.Left = 6.9375F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt.Text = "12,345.00";
            this.ShipmentCnt.Top = 0F;
            this.ShipmentCnt.Width = 0.625F;
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
            this.Label3.Left = 4.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
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
            this.tb_PrintDate.Left = 5.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成17年11月 5日";
            this.tb_PrintDate.Top = 0.0625F;
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
            this.Label2.Left = 6.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
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
            this.tb_PrintPage.Left = 7.4375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
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
            this.Line1.Width = 7.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 7.8F;
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
            this.tb_PrintTime.Left = 6.4375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11時20分";
            this.tb_PrintTime.Top = 0.0625F;
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
            this.tb_ReportTitle.Text = "発注残一覧表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.625F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
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
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.ProcessDay,
            this.SectionCode,
            this.SectionGuideSnm,
            this.WarehouseCode,
            this.EnterpriseName1,
            this.EnterpriseName2,
            this.label16,
            this.EnterpriseTel,
            this.label17,
            this.EnterpriseFax,
            this.WarehouseName});
            this.ExtraHeader.DataField = "SectionWareHouse";
            this.ExtraHeader.Height = 0.65625F;
            this.ExtraHeader.KeepTogether = true;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            this.ExtraHeader.BeforePrint += new System.EventHandler(this.ExtraHeader_BeforePrint);
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
            this.label10.Height = 0.1875F;
            this.label10.HyperLink = "";
            this.label10.Left = 0F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label10.Text = "処理日";
            this.label10.Top = 0F;
            this.label10.Width = 0.5625F;
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
            this.label11.Height = 0.1875F;
            this.label11.HyperLink = "";
            this.label11.Left = 0F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label11.Text = "拠点";
            this.label11.Top = 0.1875F;
            this.label11.Width = 0.5625F;
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
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = "";
            this.label12.Left = 0F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label12.Text = "倉庫";
            this.label12.Top = 0.375F;
            this.label12.Width = 0.5625F;
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
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = "";
            this.label13.Left = 0.5625F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label13.Text = "：";
            this.label13.Top = 0.375F;
            this.label13.Width = 0.125F;
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
            this.label14.Height = 0.1875F;
            this.label14.HyperLink = "";
            this.label14.Left = 0.5625F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label14.Text = "：";
            this.label14.Top = 0.1875F;
            this.label14.Width = 0.125F;
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
            this.label15.Height = 0.1875F;
            this.label15.HyperLink = "";
            this.label15.Left = 0.5625F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label15.Text = "：";
            this.label15.Top = 0F;
            this.label15.Width = 0.125F;
            // 
            // ProcessDay
            // 
            this.ProcessDay.Border.BottomColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.Border.LeftColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.Border.RightColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.Border.TopColor = System.Drawing.Color.Black;
            this.ProcessDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProcessDay.DataField = "ProcessDay";
            this.ProcessDay.Height = 0.1875F;
            this.ProcessDay.Left = 0.75F;
            this.ProcessDay.MultiLine = false;
            this.ProcessDay.Name = "ProcessDay";
            this.ProcessDay.OutputFormat = resources.GetString("ProcessDay.OutputFormat");
            this.ProcessDay.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.ProcessDay.Text = "9999/99/99";
            this.ProcessDay.Top = 0F;
            this.ProcessDay.Width = 0.8125F;
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.1875F;
            this.SectionCode.Left = 0.75F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.SectionCode.Text = "12";
            this.SectionCode.Top = 0.1875F;
            this.SectionCode.Width = 0.1875F;
            // 
            // SectionGuideSnm
            // 
            this.SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.DataField = "SectionGuideSnm";
            this.SectionGuideSnm.Height = 0.1875F;
            this.SectionGuideSnm.Left = 1.125F;
            this.SectionGuideSnm.MultiLine = false;
            this.SectionGuideSnm.Name = "SectionGuideSnm";
            this.SectionGuideSnm.OutputFormat = resources.GetString("SectionGuideSnm.OutputFormat");
            this.SectionGuideSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.SectionGuideSnm.Text = "あいうえおかきくけこ";
            this.SectionGuideSnm.Top = 0.1875F;
            this.SectionGuideSnm.Width = 1.1875F;
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
            this.WarehouseCode.Height = 0.1875F;
            this.WarehouseCode.Left = 0.75F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.WarehouseCode.Text = "1234";
            this.WarehouseCode.Top = 0.375F;
            this.WarehouseCode.Width = 0.3125F;
            // 
            // EnterpriseName1
            // 
            this.EnterpriseName1.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName1.DataField = "EnterpriseName1";
            this.EnterpriseName1.Height = 0.1875F;
            this.EnterpriseName1.Left = 5F;
            this.EnterpriseName1.MultiLine = false;
            this.EnterpriseName1.Name = "EnterpriseName1";
            this.EnterpriseName1.OutputFormat = resources.GetString("EnterpriseName1.OutputFormat");
            this.EnterpriseName1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.EnterpriseName1.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.EnterpriseName1.Top = 0F;
            this.EnterpriseName1.Width = 2.3125F;
            // 
            // EnterpriseName2
            // 
            this.EnterpriseName2.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseName2.DataField = "EnterpriseName2";
            this.EnterpriseName2.Height = 0.1875F;
            this.EnterpriseName2.Left = 5F;
            this.EnterpriseName2.MultiLine = false;
            this.EnterpriseName2.Name = "EnterpriseName2";
            this.EnterpriseName2.OutputFormat = resources.GetString("EnterpriseName2.OutputFormat");
            this.EnterpriseName2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.EnterpriseName2.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.EnterpriseName2.Top = 0.1875F;
            this.EnterpriseName2.Width = 2.3125F;
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
            this.label16.Height = 0.1875F;
            this.label16.HyperLink = "";
            this.label16.Left = 5F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label16.Text = "TEL：";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.3125F;
            // 
            // EnterpriseTel
            // 
            this.EnterpriseTel.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseTel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseTel.DataField = "EnterpriseTel";
            this.EnterpriseTel.Height = 0.1875F;
            this.EnterpriseTel.Left = 5.3125F;
            this.EnterpriseTel.MultiLine = false;
            this.EnterpriseTel.Name = "EnterpriseTel";
            this.EnterpriseTel.OutputFormat = resources.GetString("EnterpriseTel.OutputFormat");
            this.EnterpriseTel.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.EnterpriseTel.Text = "1234567890123456";
            this.EnterpriseTel.Top = 0.375F;
            this.EnterpriseTel.Width = 0.9375F;
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
            this.label17.Height = 0.1875F;
            this.label17.HyperLink = "";
            this.label17.Left = 6.4375F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label17.Text = "FAX：";
            this.label17.Top = 0.375F;
            this.label17.Width = 0.3125F;
            // 
            // EnterpriseFax
            // 
            this.EnterpriseFax.Border.BottomColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.Border.LeftColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.Border.RightColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.Border.TopColor = System.Drawing.Color.Black;
            this.EnterpriseFax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EnterpriseFax.DataField = "EnterpriseFax";
            this.EnterpriseFax.Height = 0.1875F;
            this.EnterpriseFax.Left = 6.75F;
            this.EnterpriseFax.MultiLine = false;
            this.EnterpriseFax.Name = "EnterpriseFax";
            this.EnterpriseFax.OutputFormat = resources.GetString("EnterpriseFax.OutputFormat");
            this.EnterpriseFax.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.EnterpriseFax.Text = "1234567890123456";
            this.EnterpriseFax.Top = 0.375F;
            this.EnterpriseFax.Width = 0.9375F;
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
            this.WarehouseName.Height = 0.1875F;
            this.WarehouseName.Left = 1.125F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OutputFormat = resources.GetString("WarehouseName.OutputFormat");
            this.WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.WarehouseName.Text = "あいうえおかきくけこ";
            this.WarehouseName.Top = 0.375F;
            this.WarehouseName.Width = 1.1875F;
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
            this.Lb_SalesOrderCount,
            this.Lb_OrderFormPrintDate,
            this.Lb_ExpectDeliveryDate,
            this.Lb_MakerName,
            this.Line5,
            this.Lb_OrderNumber,
            this.Lb_ShipmentPosCnt,
            this.Lb_MinStockCount,
            this.Lb_MaxStockCount,
            this.Lb_ShipmentCnt,
            this.Lb_GoodsMakerCd,
            this.Lb1_MakerName,
            this.Lb1_OrderFormPrintDate,
            this.Lb1_ExpectDeliveryDate,
            this.Lb1_SalesOrderCount,
            this.Lb1_ShipmentPosCnt,
            this.Lb1_MinStockCount,
            this.Lb1_MaxStockCount,
            this.Lb1_ShipmentCnt});
            this.TitleHeader.Height = 0.5833333F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Lb_SalesOrderCount.Height = 0.1875F;
            this.Lb_SalesOrderCount.HyperLink = "";
            this.Lb_SalesOrderCount.Left = 3.9375F;
            this.Lb_SalesOrderCount.MultiLine = false;
            this.Lb_SalesOrderCount.Name = "Lb_SalesOrderCount";
            this.Lb_SalesOrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_SalesOrderCount.Text = "発注残数";
            this.Lb_SalesOrderCount.Top = 0.375F;
            this.Lb_SalesOrderCount.Width = 0.625F;
            // 
            // Lb_OrderFormPrintDate
            // 
            this.Lb_OrderFormPrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_OrderFormPrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderFormPrintDate.Height = 0.1875F;
            this.Lb_OrderFormPrintDate.HyperLink = "";
            this.Lb_OrderFormPrintDate.Left = 0.6145833F;
            this.Lb_OrderFormPrintDate.MultiLine = false;
            this.Lb_OrderFormPrintDate.Name = "Lb_OrderFormPrintDate";
            this.Lb_OrderFormPrintDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_OrderFormPrintDate.Text = "品番";
            this.Lb_OrderFormPrintDate.Top = 0.375F;
            this.Lb_OrderFormPrintDate.Width = 0.5625F;
            // 
            // Lb_ExpectDeliveryDate
            // 
            this.Lb_ExpectDeliveryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ExpectDeliveryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ExpectDeliveryDate.Height = 0.1875F;
            this.Lb_ExpectDeliveryDate.HyperLink = "";
            this.Lb_ExpectDeliveryDate.Left = 2.239583F;
            this.Lb_ExpectDeliveryDate.MultiLine = false;
            this.Lb_ExpectDeliveryDate.Name = "Lb_ExpectDeliveryDate";
            this.Lb_ExpectDeliveryDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ExpectDeliveryDate.Text = "品名";
            this.Lb_ExpectDeliveryDate.Top = 0.375F;
            this.Lb_ExpectDeliveryDate.Width = 0.5625F;
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
            this.Lb_MakerName.Height = 0.1875F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 0F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_MakerName.Text = "棚番";
            this.Lb_MakerName.Top = 0.375F;
            this.Lb_MakerName.Width = 0.5625F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 2F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 7.8F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 7.8F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // Lb_OrderNumber
            // 
            this.Lb_OrderNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_OrderNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_OrderNumber.Height = 0.1875F;
            this.Lb_OrderNumber.HyperLink = "";
            this.Lb_OrderNumber.Left = 0F;
            this.Lb_OrderNumber.MultiLine = false;
            this.Lb_OrderNumber.Name = "Lb_OrderNumber";
            this.Lb_OrderNumber.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_OrderNumber.Text = "仕入先";
            this.Lb_OrderNumber.Top = 0F;
            this.Lb_OrderNumber.Width = 0.5625F;
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
            this.Lb_ShipmentPosCnt.Height = 0.1875F;
            this.Lb_ShipmentPosCnt.HyperLink = "";
            this.Lb_ShipmentPosCnt.Left = 4.6875F;
            this.Lb_ShipmentPosCnt.MultiLine = false;
            this.Lb_ShipmentPosCnt.Name = "Lb_ShipmentPosCnt";
            this.Lb_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ShipmentPosCnt.Text = "現在庫数";
            this.Lb_ShipmentPosCnt.Top = 0.375F;
            this.Lb_ShipmentPosCnt.Width = 0.625F;
            // 
            // Lb_MinStockCount
            // 
            this.Lb_MinStockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MinStockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinStockCount.Height = 0.1875F;
            this.Lb_MinStockCount.HyperLink = "";
            this.Lb_MinStockCount.Left = 5.4375F;
            this.Lb_MinStockCount.MultiLine = false;
            this.Lb_MinStockCount.Name = "Lb_MinStockCount";
            this.Lb_MinStockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_MinStockCount.Text = "最低在庫数";
            this.Lb_MinStockCount.Top = 0.375F;
            this.Lb_MinStockCount.Width = 0.625F;
            // 
            // Lb_MaxStockCount
            // 
            this.Lb_MaxStockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MaxStockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaxStockCount.Height = 0.1875F;
            this.Lb_MaxStockCount.HyperLink = "";
            this.Lb_MaxStockCount.Left = 6.1875F;
            this.Lb_MaxStockCount.MultiLine = false;
            this.Lb_MaxStockCount.Name = "Lb_MaxStockCount";
            this.Lb_MaxStockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_MaxStockCount.Text = "最高在庫数";
            this.Lb_MaxStockCount.Top = 0.375F;
            this.Lb_MaxStockCount.Width = 0.625F;
            // 
            // Lb_ShipmentCnt
            // 
            this.Lb_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Height = 0.1875F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 6.9375F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ShipmentCnt.Text = "貸出数";
            this.Lb_ShipmentCnt.Top = 0.375F;
            this.Lb_ShipmentCnt.Width = 0.625F;
            // 
            // Lb_GoodsMakerCd
            // 
            this.Lb_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Height = 0.1875F;
            this.Lb_GoodsMakerCd.HyperLink = "";
            this.Lb_GoodsMakerCd.Left = 0F;
            this.Lb_GoodsMakerCd.MultiLine = false;
            this.Lb_GoodsMakerCd.Name = "Lb_GoodsMakerCd";
            this.Lb_GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_GoodsMakerCd.Text = "メーカー";
            this.Lb_GoodsMakerCd.Top = 0.1875F;
            this.Lb_GoodsMakerCd.Width = 0.5625F;
            // 
            // Lb1_MakerName
            // 
            this.Lb1_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MakerName.Height = 0.1875F;
            this.Lb1_MakerName.HyperLink = "";
            this.Lb1_MakerName.Left = 0F;
            this.Lb1_MakerName.MultiLine = false;
            this.Lb1_MakerName.Name = "Lb1_MakerName";
            this.Lb1_MakerName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_MakerName.Text = "棚番";
            this.Lb1_MakerName.Top = 0.1770833F;
            this.Lb1_MakerName.Visible = false;
            this.Lb1_MakerName.Width = 0.5625F;
            // 
            // Lb1_OrderFormPrintDate
            // 
            this.Lb1_OrderFormPrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_OrderFormPrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_OrderFormPrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_OrderFormPrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_OrderFormPrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_OrderFormPrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_OrderFormPrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_OrderFormPrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_OrderFormPrintDate.Height = 0.1875F;
            this.Lb1_OrderFormPrintDate.HyperLink = "";
            this.Lb1_OrderFormPrintDate.Left = 0.625F;
            this.Lb1_OrderFormPrintDate.MultiLine = false;
            this.Lb1_OrderFormPrintDate.Name = "Lb1_OrderFormPrintDate";
            this.Lb1_OrderFormPrintDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_OrderFormPrintDate.Text = "品番";
            this.Lb1_OrderFormPrintDate.Top = 0.1770833F;
            this.Lb1_OrderFormPrintDate.Visible = false;
            this.Lb1_OrderFormPrintDate.Width = 0.5625F;
            // 
            // Lb1_ExpectDeliveryDate
            // 
            this.Lb1_ExpectDeliveryDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_ExpectDeliveryDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ExpectDeliveryDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_ExpectDeliveryDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ExpectDeliveryDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_ExpectDeliveryDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ExpectDeliveryDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_ExpectDeliveryDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ExpectDeliveryDate.Height = 0.1875F;
            this.Lb1_ExpectDeliveryDate.HyperLink = "";
            this.Lb1_ExpectDeliveryDate.Left = 2.239583F;
            this.Lb1_ExpectDeliveryDate.MultiLine = false;
            this.Lb1_ExpectDeliveryDate.Name = "Lb1_ExpectDeliveryDate";
            this.Lb1_ExpectDeliveryDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_ExpectDeliveryDate.Text = "品名";
            this.Lb1_ExpectDeliveryDate.Top = 0.1770833F;
            this.Lb1_ExpectDeliveryDate.Visible = false;
            this.Lb1_ExpectDeliveryDate.Width = 0.5625F;
            // 
            // Lb1_SalesOrderCount
            // 
            this.Lb1_SalesOrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_SalesOrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_SalesOrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_SalesOrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_SalesOrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_SalesOrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_SalesOrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_SalesOrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_SalesOrderCount.Height = 0.1875F;
            this.Lb1_SalesOrderCount.HyperLink = "";
            this.Lb1_SalesOrderCount.Left = 3.9375F;
            this.Lb1_SalesOrderCount.MultiLine = false;
            this.Lb1_SalesOrderCount.Name = "Lb1_SalesOrderCount";
            this.Lb1_SalesOrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_SalesOrderCount.Text = "発注残数";
            this.Lb1_SalesOrderCount.Top = 0.1770833F;
            this.Lb1_SalesOrderCount.Visible = false;
            this.Lb1_SalesOrderCount.Width = 0.625F;
            // 
            // Lb1_ShipmentPosCnt
            // 
            this.Lb1_ShipmentPosCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentPosCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentPosCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentPosCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentPosCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentPosCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentPosCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentPosCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentPosCnt.Height = 0.1875F;
            this.Lb1_ShipmentPosCnt.HyperLink = "";
            this.Lb1_ShipmentPosCnt.Left = 4.6875F;
            this.Lb1_ShipmentPosCnt.MultiLine = false;
            this.Lb1_ShipmentPosCnt.Name = "Lb1_ShipmentPosCnt";
            this.Lb1_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_ShipmentPosCnt.Text = "現在庫数";
            this.Lb1_ShipmentPosCnt.Top = 0.1770833F;
            this.Lb1_ShipmentPosCnt.Visible = false;
            this.Lb1_ShipmentPosCnt.Width = 0.625F;
            // 
            // Lb1_MinStockCount
            // 
            this.Lb1_MinStockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_MinStockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MinStockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_MinStockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MinStockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_MinStockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MinStockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_MinStockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MinStockCount.Height = 0.1875F;
            this.Lb1_MinStockCount.HyperLink = "";
            this.Lb1_MinStockCount.Left = 5.4375F;
            this.Lb1_MinStockCount.MultiLine = false;
            this.Lb1_MinStockCount.Name = "Lb1_MinStockCount";
            this.Lb1_MinStockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_MinStockCount.Text = "最低在庫数";
            this.Lb1_MinStockCount.Top = 0.1770833F;
            this.Lb1_MinStockCount.Visible = false;
            this.Lb1_MinStockCount.Width = 0.625F;
            // 
            // Lb1_MaxStockCount
            // 
            this.Lb1_MaxStockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_MaxStockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MaxStockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_MaxStockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MaxStockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_MaxStockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MaxStockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_MaxStockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_MaxStockCount.Height = 0.1875F;
            this.Lb1_MaxStockCount.HyperLink = "";
            this.Lb1_MaxStockCount.Left = 6.1875F;
            this.Lb1_MaxStockCount.MultiLine = false;
            this.Lb1_MaxStockCount.Name = "Lb1_MaxStockCount";
            this.Lb1_MaxStockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_MaxStockCount.Text = "最高在庫数";
            this.Lb1_MaxStockCount.Top = 0.1770833F;
            this.Lb1_MaxStockCount.Visible = false;
            this.Lb1_MaxStockCount.Width = 0.625F;
            // 
            // Lb1_ShipmentCnt
            // 
            this.Lb1_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb1_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb1_ShipmentCnt.Height = 0.1875F;
            this.Lb1_ShipmentCnt.HyperLink = "";
            this.Lb1_ShipmentCnt.Left = 6.9375F;
            this.Lb1_ShipmentCnt.MultiLine = false;
            this.Lb1_ShipmentCnt.Name = "Lb1_ShipmentCnt";
            this.Lb1_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb1_ShipmentCnt.Text = "貸出数";
            this.Lb1_ShipmentCnt.Top = 0.1770833F;
            this.Lb1_ShipmentCnt.Visible = false;
            this.Lb1_ShipmentCnt.Width = 0.625F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
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
            this.GrandTotalFooter.Height = 0F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // ALLTOTALTITLE
            // 
            this.ALLTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.ALLTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ALLTOTALTITLE.Height = 0.1875F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 1.6875F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "仕入先計";
            this.ALLTOTALTITLE.Top = 0F;
            this.ALLTOTALTITLE.Width = 0.75F;
            // 
            // Line43
            // 
            this.Line43.Border.BottomColor = System.Drawing.Color.Black;
            this.Line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.LeftColor = System.Drawing.Color.Black;
            this.Line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.RightColor = System.Drawing.Color.Black;
            this.Line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.TopColor = System.Drawing.Color.Black;
            this.Line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Height = 0F;
            this.Line43.Left = 0F;
            this.Line43.LineWeight = 2F;
            this.Line43.Name = "Line43";
            this.Line43.Top = 0F;
            this.Line43.Width = 7.8F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 7.8F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // DetailCount
            // 
            this.DetailCount.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Border.RightColor = System.Drawing.Color.Black;
            this.DetailCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Border.TopColor = System.Drawing.Color.Black;
            this.DetailCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailCount.Height = 0.1875F;
            this.DetailCount.Left = 2.6875F;
            this.DetailCount.MultiLine = false;
            this.DetailCount.Name = "DetailCount";
            this.DetailCount.OutputFormat = resources.GetString("DetailCount.OutputFormat");
            this.DetailCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.DetailCount.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.DetailCount.SummaryGroup = "Header1";
            this.DetailCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.DetailCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DetailCount.Text = "123,456";
            this.DetailCount.Top = 0F;
            this.DetailCount.Width = 0.5F;
            // 
            // f_SalesOrderCount
            // 
            this.f_SalesOrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.f_SalesOrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.f_SalesOrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.f_SalesOrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.f_SalesOrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.f_SalesOrderCount.DataField = "SalesOrderCount";
            this.f_SalesOrderCount.Height = 0.1875F;
            this.f_SalesOrderCount.Left = 3.875F;
            this.f_SalesOrderCount.MultiLine = false;
            this.f_SalesOrderCount.Name = "f_SalesOrderCount";
            this.f_SalesOrderCount.OutputFormat = resources.GetString("f_SalesOrderCount.OutputFormat");
            this.f_SalesOrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.f_SalesOrderCount.SummaryGroup = "Header1";
            this.f_SalesOrderCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.f_SalesOrderCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.f_SalesOrderCount.Text = "123,456.00";
            this.f_SalesOrderCount.Top = 0F;
            this.f_SalesOrderCount.Width = 0.6875F;
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
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = "";
            this.label1.Left = 3.1875F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label1.Text = "件";
            this.label1.Top = 0F;
            this.label1.Width = 0.1875F;
            // 
            // Header1
            // 
            this.Header1.CanShrink = true;
            this.Header1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupplierCodePrint,
            this.line10,
            this.SupplierName});
            this.Header1.DataField = "SupplierCodePrint";
            this.Header1.Height = 0.1979167F;
            this.Header1.KeepTogether = true;
            this.Header1.Name = "Header1";
            this.Header1.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.Header1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.Header1.BeforePrint += new System.EventHandler(this.Header1_BeforePrint);
            // 
            // SupplierCodePrint
            // 
            this.SupplierCodePrint.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCodePrint.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCodePrint.DataField = "SupplierCodePrint";
            this.SupplierCodePrint.Height = 0.125F;
            this.SupplierCodePrint.Left = 0F;
            this.SupplierCodePrint.MultiLine = false;
            this.SupplierCodePrint.Name = "SupplierCodePrint";
            this.SupplierCodePrint.OutputFormat = resources.GetString("SupplierCodePrint.OutputFormat");
            this.SupplierCodePrint.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SupplierCodePrint.Text = "123456";
            this.SupplierCodePrint.Top = 0F;
            this.SupplierCodePrint.Width = 0.375F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0F;
            this.line10.Left = 0F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 7.8F;
            this.line10.X1 = 0F;
            this.line10.X2 = 7.8F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
            // 
            // SupplierName
            // 
            this.SupplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierName.DataField = "SupplierName";
            this.SupplierName.Height = 0.125F;
            this.SupplierName.Left = 0.4375F;
            this.SupplierName.MultiLine = false;
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.OutputFormat = resources.GetString("SupplierName.OutputFormat");
            this.SupplierName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SupplierName.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupplierName.Top = 0F;
            this.SupplierName.Width = 2.3125F;
            // 
            // Footer1
            // 
            this.Footer1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line43,
            this.ALLTOTALTITLE,
            this.DetailCount,
            this.f_SalesOrderCount,
            this.label1});
            this.Footer1.Height = 0.3541667F;
            this.Footer1.KeepTogether = true;
            this.Footer1.Name = "Footer1";
            // 
            // Header2
            // 
            this.Header2.CanShrink = true;
            this.Header2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsMakerCd,
            this.MakerName,
            this.line2});
            this.Header2.DataField = "GoodsMakerCd";
            this.Header2.Height = 0.1666667F;
            this.Header2.KeepTogether = true;
            this.Header2.Name = "Header2";
            this.Header2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.GoodsMakerCd.CanShrink = true;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.125F;
            this.GoodsMakerCd.Left = 0F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.375F;
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
            this.MakerName.CanShrink = true;
            this.MakerName.DataField = "MakerName";
            this.MakerName.Height = 0.125F;
            this.MakerName.Left = 0.4375F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこ";
            this.MakerName.Top = 0F;
            this.MakerName.Width = 2.313F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 7.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 7.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // Footer2
            // 
            this.Footer2.CanShrink = true;
            this.Footer2.Height = 0F;
            this.Footer2.Name = "Footer2";
            // 
            // DCHAT02102P_08A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 7.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.Header1);
            this.Sections.Add(this.Header2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.Footer2);
            this.Sections.Add(this.Footer1);
            this.Sections.Add(this.GrandTotalFooter);
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
            this.ReportStart += new System.EventHandler(this.DCHAT02102P_08A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterpriseFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderFormPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ExpectDeliveryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_OrderNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinStockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaxStockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_OrderFormPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_ExpectDeliveryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_MinStockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_MaxStockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb1_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f_SalesOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCodePrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
