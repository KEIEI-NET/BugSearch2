//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上仕入対比表(月報年報)
// プログラム概要   : 売上仕入対比表(月報年報)の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/12/09  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13137】残案件No.19 端数処理
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;       // ADD 2009/04/13
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 売上仕入対比表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 売上仕入対比表のフォームクラスです。</br>
	/// <br>Programmer	: 96186 立花 裕輔</br>
	/// <br>Date		: 2007.09.03</br>
    /// <br>Update Note : 2008.12.09 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
	/// <br></br>
	/// </remarks>
	public class DCTOK02152P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 売上仕入対比表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 売上仕入対比表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 96186　立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		public DCTOK02152P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									// 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderTitle;				// フォームタイトル
		private string				_pageHeaderSortOderTitle;		// ソート順

		private SalStcCompMonthYearReport _salStcCompMonthYearReport;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        #region サプレスバッファ
        private Label label1;
		private Label label6;
		private Label label9;
		private Label label10;
		private TextBox SalesMoney;
		private TextBox TotalSalesMoney;
		private TextBox g_SalesMoney;
		private TextBox g_TotalSalesMoney;
		private TextBox s_TotalOrderSalesMoney;
		private TextBox StockMoney;
		private TextBox TotalCostMoney;
		private TextBox s_StockMoney;
		private TextBox s_TotalStockMoney;
		private TextBox g_StockMoney;
		private TextBox g_TotalStockMoney;
		private TextBox TotalStockMoney;
		private TextBox g_TotalOrderStockMoney;
		private TextBox s_TotalOrderStockMoney;
		private TextBox TotalDifference;
		private TextBox g_YearStockComp;
		private TextBox s_SalesMoney;
		private TextBox DailyTitle;
        private TextBox d_TermSalesComp;
		private TextBox d_StockSalesMoney;
		private TextBox d_TotalStockSalesMoney;
		private TextBox d_GrossMoney;
		private TextBox d_GrossMarginRate;
		private TextBox d_CostMoney;
		private TextBox d_TotalGrossMoney;
		private TextBox d_TotalGrossMarginRate;
		private TextBox d_TotalCostMoney;
		private TextBox d_YearSalesComp;
		private TextBox d_SalesMoney;
		private TextBox d_TotalOrderSalesMoney;
		private TextBox d_StockMoney;
		private TextBox d_TotalStockMoney;
		private TextBox d_TotalOrderStockMoney;
		private TextBox d_YearStockComp;
		private Label label5;
		private Label label11;
		private Label label12;
		private Label Lb_TitleHeaderSub;
		private TextBox CostMoney;
		private TextBox OrderStockMoney;
		private TextBox StockStockMoney;
		private TextBox TermStockComp;
		private TextBox Difference;
		private TextBox TotalStockStockMoney;
		private TextBox YearSalesComp;
		private TextBox YearStockComp;
		private TextBox d_OrderStockMoney;
		private TextBox d_OrderSalesMoney;
		private TextBox d_TotalSalesMoney;
		private TextBox g_Difference;
		private TextBox g_OrderSalesMoney;
		private TextBox g_TotalOrderSalesMoney;
		private TextBox g_OrderStockMoney;
		private TextBox g_StockStockMoney;
		private TextBox g_TotalStockStockMoney;
		private TextBox g_TermStockComp;
		private TextBox s_OrderSalesMoney;
		private TextBox s_TotalSalesMoney;
		private TextBox s_OrderStockMoney;
		private TextBox s_StockStockMoney;
		private TextBox s_TotalStockStockMoney;
		private TextBox s_TermStockComp;
		private TextBox s_YearStockComp;
		private TextBox s_Difference;
		private TextBox s_TotalDifference;
		private TextBox d_StockStockMoney;
		private TextBox d_TotalStockStockMoney;
		private TextBox d_TermStockComp;
		private TextBox d_Difference;
		private TextBox d_TotalDifference;
		private TextBox g_TotalDifference;
		private Label label14;
		private Label label15;
		private Line upline_SectionHeader;
		private Line line4;
        private Line bottomline_TitleHeader;
		private TextBox SectionHeaderLine;
		private TextBox SectionHeaderLineName;
		private TextBox DetailLine;
		private TextBox DetailLineName;
        private Line line2;
        private TextBox MoveShipmentPrice;
        private TextBox TotalMoveShipmentPrice;
        private TextBox g_MoveShipmentPrice;
        private TextBox g_TotalMoveShipmentPrice;
        private TextBox s_MoveShipmentPrice;
        private TextBox s_TotalMoveShipmentPrice;
        private TextBox d_MoveShipmentPrice;
        private TextBox d_TotalMoveShipmentPrice;
        private Label label13;
        private Label label17;
        private TextBox MoveArrivalPric;
        private TextBox TotalMoveArrivalPric;
        private TextBox g_MoveArrivalPric;
        private TextBox g_TotalMoveArrivalPric;
        private TextBox s_MoveArrivalPric;
        private TextBox s_TotalMoveArrivalPric;
        private TextBox d_MoveArrivalPric;
        private TextBox d_TotalMoveArrivalPric;
        private TextBox d_SalesMoneyOrg;
        private TextBox d_GrossMoneyOrg;
        private TextBox d_TotalSalesMoneyOrg;
        private TextBox d_TotalGrossMoneyOrg;
        private TextBox SalesMoneyOrg;
        private TextBox TotalSalesMoneyOrg;
        private TextBox GrossMoneyOrg;
        private TextBox TotalGrossMoneyOrg;
        private TextBox s_SalesMoneyOrg;
        private TextBox s_TotalSalesMoneyOrg;
        private TextBox s_GrossMoneyOrg;
        private TextBox s_TotalGrossMoneyOrg;
        private TextBox g_SalesMoneyOrg;
        private TextBox g_TotalSalesMoneyOrg;
        private TextBox g_GrossMoneyOrg;
        private TextBox g_TotalGrossMoneyOrg;
        private Line line3;
        private Line line5;
        private Line line6;
        private Line line7;
        private Line line8;
        private Line line9;
        private Line line10;
        private Line line11;
        private Line line12;
        private Line line13;
        private Line line14;
        private Line line15;
        private Line line16;
        private Line line17;
        private Line line18;
        private Line line19;
        private Line line20;
        private Line line21;
        private Line line22;
        private Line line23;
        private Line line24;
		private Label label16;
        #endregion

        #endregion ■ Private Member

        #region ■ Dispose(override)
        /// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
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
			set{ _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ _extraCondHeadOutDiv = value; }
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set{ this._extraConditions = value; }
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set{ this._pageFooterOutCode = value; }
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set{ this._pageFooters = value; }
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo			= value;
				this._salStcCompMonthYearReport	= (SalStcCompMonthYearReport)this._printInfo.jyoken;
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
			set{ this._pageHeaderTitle = value;}
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
		
		#region ■ Private Method
		#region ◆ レポート要素出力設定
		/// <summary>
		/// レポート要素出力設定
		/// </summary>
		/// <remarks>
		/// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			// 拠点計を出力するかしないかを選択する
			// 拠点有無を判断
			//if ( this._salStcCompMonthYearReport.IsOptSection )
			//{
			//	// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
			//	if ((this._salStcCompMonthYearReport.SectionCode.Length < 2) || 
			//		this._salStcCompMonthYearReport.IsSelectAllSection )
			//	{
			//		SectionHeader.DataField = "";
			//		SectionHeader.Visible = false;
			//		SectionFooter.Visible = false;
			//	}
			//	else
			//	{
			//		// 移動先と移動元を変える
			//		SectionHeader.DataField = DCKOU02105EA.ct_Col_MainSectionCode;
			//		SectionHeader.Visible = true;
			//		SectionFooter.Visible = true;
			//	}
			//}
			//else
			//{
			//	// 拠点無
			//	SectionHeader.DataField = "";
			//	SectionHeader.Visible = false;
			//	SectionFooter.Visible = false;
			//}		

			// 項目の名称をセット
			// ソート条件     
            //SortTitle.Text = this._pageHeaderSortOderTitle; // DEL 2008/12/09

			// タイトル項目の名称をセット
			tb_ReportTitle.Text = this._pageHeaderTitle;

			//全社 拠点単位の判定
			//bool TtlTypeBool = true;

			//帳票種別 0:拠点別 1:仕入先別
			//帳票種別 0:拠点別
			if (this._salStcCompMonthYearReport.PrintType == 0)
			{
				//Daily
				DailyHeader.DataField = "";
				DailyHeader.Visible = false;
				DailyFooter.Visible = false;
				DailyTitle.Visible = false;
				DailyTitle.Text = "";

				//WareHouse
				WareHouseHeader.DataField = "";
				WareHouseHeader.Visible = false;
				WareHouseFooter.Visible = false;

				//Section
				SectionHeader.NewPage = (NewPage)_salStcCompMonthYearReport.CrMode;
				SectionHeader.DataField = "SectionHeaderField";
				SectionHeader.Visible = true;
				SectionFooter.Visible = true;
				SectionTitle.Visible = true;
				SectionTitle.Text = "拠点計";
				SectionHeaderLine.DataField = "SectionHeaderLine";
				SectionHeaderLine.Visible = true;

				//Title
				Lb_TitleHeader.Text = "拠点";
				Lb_TitleHeader.Visible = true;
				Lb_TitleHeaderSub.Text = "仕入先";
				Lb_TitleHeader.Visible = true;
				upline_SectionHeader.Visible = true;
				bottomline_TitleHeader.Visible = true;
			}
			//帳票種別 1:仕入先別
			else if (this._salStcCompMonthYearReport.PrintType == 1)
			{
				//Daily
				DailyHeader.DataField = "";
				DailyHeader.Visible = false;
				DailyFooter.Visible = false;
				DailyTitle.Visible = false;
				DailyTitle.Text = "";

				//WareHouse
				WareHouseHeader.DataField = "";
				WareHouseHeader.Visible = false;
				WareHouseFooter.Visible = false;

				//Section
				SectionHeader.NewPage = (NewPage)_salStcCompMonthYearReport.CrMode;
				SectionHeader.DataField = "SectionHeaderField";
				SectionHeader.Visible = true;
				SectionFooter.Visible = true;
				SectionTitle.Visible = true;
				SectionTitle.Text = "仕入先計";
				SectionHeaderLine.DataField = "SectionHeaderLine";
				SectionHeaderLine.Visible = true;

				//Title
				Lb_TitleHeader.Text = "仕入先";
				Lb_TitleHeader.Visible = true;
				Lb_TitleHeaderSub.Text = "拠点";
				Lb_TitleHeader.Visible = true;
				upline_SectionHeader.Visible = true;
				bottomline_TitleHeader.Visible = true;
			}
		}
		#endregion ◆ レポート要素出力設定

		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{

#if False
			this._sectionCodeSuppresBuf = this.SectionCode.Text.Trim();
			this._stockAgentCodeSuppresBuf = this.DetailLine.Text.Trim();
			this._customerCodeSuppresBuf = this.CustomerCode.Text.Trim();
#endif

#if False
			// 前回出力した拠点コードが同じ場合は出力しない
			if (this.SectionCode.Text.Trim().CompareTo(this._sectionCodeSuppresBuf) == 0)
			{
				SectionCode.Visible = false;

				// 前回出力した担当者コードが同じ場合は出力しない
				if (this.StockAgentCode.Text.Trim().CompareTo(this._stockAgentCodeSuppresBuf) == 0)
				{
					StockAgentCode.Visible = false;

					// 前回出力した仕入コードが同じ場合は出力しない
					if (this.CustomerCode.Text.Trim().CompareTo(this._customerCodeSuppresBuf) == 0)
					{
						CustomerCode.Visible = false;
					}
					else
					{
					}
				}
				else
				{
				}
			}
			else
			{
				SectionCode.Visible = true;
			}
#endif

#if False
			//グループサプレス項目値の保存
			this._sectionCodeSuppresBuf = this.SectionCode.Text.Trim();
			this._stockAgentCodeSuppresBuf = this.DetailLine.Text.Trim();
			this._customerCodeSuppresBuf = this.CustomerCode.Text.Trim();
#endif


#if False
			#region // 2007.09.03 立花 裕輔 del
			// 主拠点、主倉庫、抽出日付、絞込み拠点、絞込み倉庫は1つの伝票で同じなのでサプレスのキーは伝票番号のみとし、
			// 伝票番号の変更により表示を切り替える

			// 前回出力した伝票ヘッダ情報とバッファの値が同じなら出力しない。
			if ( this.StockMoveSlipNo.Text.Trim().CompareTo(this._slipSuppresBuf) == 0 )
			{
			    // 非表示
			    StockMoveSlipNo.Visible = false;		// 移動伝票番号
			    MainSectionName.Visible = false;		// 主拠点名称
			    MainWhareHouseName.Visible = false;		// 主倉庫名称
			    ExtractDate.Visible = false;			// 抽出日付
			    ExtractSectionName.Visible = false;		// 抽出拠点名称(在庫移動でも倉庫移動でもとにかくfalse)
			    ExtractWhareHouseName.Visible = false;	// 抽出倉庫名称

			#region // 2007.09.03 立花 裕輔 del
				//if ( this.StockMoveRowNo.Text.Trim().CompareTo(this._stockMoveRowNo) == 0 )
				//{
				//    MakerName.Visible = false;			// メーカー名称	
				//    GoodsCode.Visible = false;			// 商品コード
				//    GoodsName.Visible = false;			// 商品名称
				//}
				//else
				//{
				//    MakerName.Visible = true;			// メーカー名称	
				//    GoodsCode.Visible = true;			// 商品コード
				//    GoodsName.Visible = true;			// 商品名称
				//}
				#endregion
				// 2007.09.03 立花 裕輔 add ---------------->
				// メーカー、商品のサプレス判断(メーカー、商品が同じときだけサプレス) 
				if ( ( this.MakerCode.Text.Trim().CompareTo( this._makerSuppresBuf ) == 0 ) &&
					( this.GoodsCode.Text.Trim().CompareTo( this._goodsSuppresBuf ) == 0 ) )
				{
					// 製番が無かったら有無を言わさず出力
					if ( this.ProductNumber.Text.Trim().CompareTo("") == 0 )
					{
						MakerName.Visible = true;			// メーカー名称	
						GoodsCode.Visible = true;			// 商品コード
						GoodsName.Visible = true;			// 商品名称
					}
					else
					{
						MakerName.Visible = false;			// メーカー名称	
						GoodsCode.Visible = false;			// 商品コード
						GoodsName.Visible = false;			// 商品名称
					}
				}
				else
				{
					MakerName.Visible = true;			// メーカー名称	
					GoodsCode.Visible = true;			// 商品コード
					GoodsName.Visible = true;			// 商品名称
				}
				// 2007.09.03 立花 裕輔 add <----------------

			}
			else
			{
			    // 表示 伝票が変わったら全ての情報を表示
			    StockMoveSlipNo.Visible = true;		// 移動伝票番号
			    MainSectionName.Visible = true;		// 主拠点名称
			    MainWhareHouseName.Visible = true;	// 主倉庫名称
			    ExtractDate.Visible = true;			// 抽出日付
			    if ( this._salStcCompMonthYearReport.StockMoveFormalDiv == SalStcCompMonthYearReport.StockMoveFormalDivState.StockMove )
			    {
			        ExtractSectionName.Visible = true;		// 抽出拠点名称(在庫移動のときだけtrueに。)
			    }
			    ExtractWhareHouseName.Visible = true;	// 抽出倉庫名称
			    MakerName.Visible = true;				// メーカー名称	
			    GoodsCode.Visible = true;				// 商品コード
			    GoodsName.Visible = true;				// 商品名称

			}





			this._slipSuppresBuf = this.StockMoveSlipNo.Text.Trim();
			// 2007.09.03 立花 裕輔 add ------------------------------------->
			this._makerSuppresBuf	= this.MakerCode.Text.Trim();
			this._goodsSuppresBuf	= this.GoodsCode.Text.Trim();
			// 2007.09.03 立花 裕輔 add <-------------------------------------
 
			#endregion
#endif
		}
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

		#region ◎ MAZAI02032P_01A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ MAZAI02032P_01A4C_PageEnd Event
		/// <summary>
		/// MAZAI02032P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: MAZAI02032P_01A4C_PageEnd Event</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			//現在の時刻を取得
			DateTime now = DateTime.Now;
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
			// 作成時間
			this.tb_PrintTime.Text   = now.ToString("HH:mm");
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
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
			if ( this._rptExtraHeader == null)
			{
				this._rptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				// インスタンスが作成されていれば、データソースを初期化する
				// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
				this._rptExtraHeader.DataSource = null;
			}

#if False
			// 拠点オプション有無判定
			string sectionTitle = "";
			//string sectionTitle = string.Format("{0}拠点：", this._salStcCompMonthYearReport.MainExtractTitle);
			//if ( this._salStcCompMonthYearReport.IsOptSection )
			//{
				if ( this._salStcCompMonthYearReport.IsSelectAllSection )
				{
					this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
				}
				else
				{
					this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
				}

			//} 
			//else 
			//{
			//	this._rptExtraHeader.SectionCondition.Text = "";
			//}
#endif
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
		}
		#endregion

        #region ◎ SectionHeader_BeforePrint Event
        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary>
        /// SectionHeader_BeforePrint Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionHeader_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.SectionHeaderLine.Text) ||
                Convert.ToInt32(this.SectionHeaderLine.Text) == 0)
            {
                this.SectionHeaderLine.Text = string.Empty;
                this.SectionHeaderLineName.Text = string.Empty;
            }
        }
        // --- ADD 2008/12/09 --------------------------------<<<<<
        #endregion

        #region ◎ Detail_BeforePrint Event
        /// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションがページに描画される前に発生する。</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
            // ADD 2009/04/13 ------>>>
            // 当月の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { SalesMoney, OrderSalesMoney, StockSalesMoney, GrossMoney, MoveShipmentPrice, CostMoney,
                                           StockMoney, OrderStockMoney, StockStockMoney, MoveArrivalPric,
                                           TermSalesComp, TermStockComp, Difference });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> tList = new List<TextBox>();
            tList.AddRange(new TextBox[] { TotalSalesMoney, TotalOrderSalesMoney, TotalStockSalesMoney, TotalGrossMoney, TotalMoveShipmentPrice, TotalCostMoney,
                                           TotalStockMoney, TotalOrderStockMoney, TotalStockStockMoney, TotalMoveArrivalPric,
                                           YearSalesComp, YearStockComp, TotalDifference });
            PriceUnitCalc(tList);
            // ADD 2009/04/13 ------<<<

			// グループサプレスの判断
			this.CheckGroupSuppression();
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);

            // --- ADD 2008/12/09 -------------------------------->>>>>
            // ゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.DetailLine.Text) ||
                Convert.ToInt32(this.DetailLine.Text) == 0)
            {
                this.DetailLine.Text = string.Empty;
                this.DetailLineName.Text = string.Empty;
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<
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
		/// <br>Programmer  : 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
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

		#region ◎ DailyFooter_Format Event
		/// <summary>
		/// DailyFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DailyFooter_Format Event</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
		{
			//月間粗利率
			if (double.Parse(this.d_SalesMoneyOrg.Value.ToString()) == 0
                || double.Parse(this.d_GrossMoneyOrg.Value.ToString()) == 0)
			{
				d_GrossMarginRate.Value = 0;
			}
			else
			{
				d_GrossMarginRate.Value = double.Parse(this.d_GrossMoneyOrg.Value.ToString()) * 100 / double.Parse(this.d_SalesMoneyOrg.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.d_TotalSalesMoneyOrg.Value.ToString()) == 0
                || double.Parse(this.d_TotalGrossMoneyOrg.Value.ToString()) == 0)
			{
				d_TotalGrossMarginRate.Value = 0;
			}
			else
			{
				d_TotalGrossMarginRate.Value = double.Parse(this.d_TotalGrossMoneyOrg.Value.ToString()) * 100 / double.Parse(this.d_TotalSalesMoneyOrg.Value.ToString());
			}
		}

        /// <summary>
        /// SectionFooter_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
			//月間粗利率
			if (double.Parse(this.s_SalesMoneyOrg.Value.ToString()) == 0
                || double.Parse(this.s_GrossMoneyOrg.Value.ToString()) == 0)
			{
				s_GrossMarginRate.Value = 0;
			}
			else
			{
				s_GrossMarginRate.Value = double.Parse(this.s_GrossMoneyOrg.Value.ToString()) * 100 / double.Parse(this.s_SalesMoneyOrg.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.s_TotalSalesMoneyOrg.Value.ToString()) == 0
                || double.Parse(this.s_TotalGrossMoneyOrg.Value.ToString()) == 0)
			{
				s_TotalGrossMarginRate.Value = 0;
			}
			else
			{
				s_TotalGrossMarginRate.Value = double.Parse(this.s_TotalGrossMoneyOrg.Value.ToString()) * 100 / double.Parse(this.s_TotalSalesMoneyOrg.Value.ToString());
			}
		}

        /// <summary>
        /// GrandTotalFooter_Formatイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
			//月間粗利率
			if (double.Parse(this.g_SalesMoneyOrg.Value.ToString()) == 0
                || double.Parse(this.g_GrossMoneyOrg.Value.ToString()) == 0)
			{
				g_GrossMarginRate.Value = 0;
			}
			else
			{
                g_GrossMarginRate.Value = double.Parse(this.g_GrossMoneyOrg.Value.ToString()) * 100 / double.Parse(this.g_SalesMoneyOrg.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.g_TotalSalesMoneyOrg.Value.ToString()) == 0
                || double.Parse(this.g_TotalGrossMoneyOrg.Value.ToString()) == 0)
			{
				g_TotalGrossMarginRate.Value = 0;
			}
			else
			{
                g_TotalGrossMarginRate.Value = double.Parse(this.g_TotalGrossMoneyOrg.Value.ToString()) * 100 / double.Parse(this.g_TotalSalesMoneyOrg.Value.ToString());
			}
		}

		//private void WareHouseFooter_Format(object sender, System.EventArgs eArgs)
		//{
		//}
		#endregion

		#region ◎ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PageFooterグループのフォーマットイベント。</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// インスタンスが作成されていなければ作成
				if ( _rptPageFooter == null)
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

        // ADD 2009/04/13 ------>>>
        /// <summary>
        /// DailyFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: DailyFooterグループの描画前イベント。</br>
        /// </remarks>
        private void DailyFooter_BeforePrint(object sender, EventArgs e)
        {
            // 当月の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { d_SalesMoney, d_OrderSalesMoney, d_StockSalesMoney, d_GrossMoney, d_MoveShipmentPrice, d_CostMoney,
                                           d_StockMoney, d_OrderStockMoney, d_StockStockMoney, d_MoveArrivalPric,
                                           d_TermSalesComp, d_TermStockComp, d_Difference });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> tList = new List<TextBox>();
            tList.AddRange(new TextBox[] { d_TotalSalesMoney, d_TotalOrderSalesMoney, d_TotalStockSalesMoney, d_TotalGrossMoney, d_TotalMoveShipmentPrice, d_TotalCostMoney,
                                           d_TotalStockMoney, d_TotalOrderStockMoney, d_TotalStockStockMoney, d_TotalMoveArrivalPric,
                                           d_YearSalesComp, d_YearStockComp, d_TotalDifference });
            PriceUnitCalc(tList);            
        }

        /// <summary>
        /// SectionFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: SectionFooterグループの描画前イベント。</br>
        /// </remarks>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 当月の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { s_SalesMoney, s_OrderSalesMoney, s_StockSalesMoney, s_GrossMoney, s_MoveShipmentPrice, s_CostMoney,
                                           s_StockMoney, s_OrderStockMoney, s_StockStockMoney, s_MoveArrivalPric,
                                           s_TermSalesComp, s_TermStockComp, s_Difference });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> tList = new List<TextBox>();
            tList.AddRange(new TextBox[] { s_TotalSalesMoney, s_TotalOrderSalesMoney, s_TotalStockSalesMoney, s_TotalGrossMoney, s_TotalMoveShipmentPrice, s_TotalCostMoney,
                                           s_TotalStockMoney, s_TotalOrderStockMoney, s_TotalStockStockMoney, s_TotalMoveArrivalPric,
                                           s_YearSalesComp, s_YearStockComp, s_TotalDifference });
            PriceUnitCalc(tList);
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: GrandTotalFooterグループの描画前イベント。</br>
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 当月の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { g_SalesMoney, g_OrderSalesMoney, g_StockSalesMoney, g_GrossMoney, g_MoveShipmentPrice, g_CostMoney,
                                           g_StockMoney, g_OrderStockMoney, g_StockStockMoney, g_MoveArrivalPric,
                                           g_TermSalesComp, g_TermStockComp, g_Difference });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> tList = new List<TextBox>();
            tList.AddRange(new TextBox[] { g_TotalSalesMoney, g_TotalOrderSalesMoney, g_TotalStockSalesMoney, g_TotalGrossMoney, g_TotalMoveShipmentPrice, g_TotalCostMoney,
                                           g_TotalStockMoney, g_TotalOrderStockMoney, g_TotalStockStockMoney, g_TotalMoveArrivalPric,
                                           g_YearSalesComp, g_YearStockComp, g_TotalDifference });
            PriceUnitCalc(tList);
        }
        // ADD 2009/04/13 ------<<<

		#endregion ■ Control Event

        // ADD 2009/04/13 ------>>>
        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._salStcCompMonthYearReport.MoneyUnit == 1)
            {
                int priceUnit = 1000;

                for (int index = 0; index < calcList.Count; index++)
                {
                    if (!calcList[index].Visible)
                    {
                        continue;
                    }

                    decimal unitCalc = 0;
                    if (calcList[index].Value is long)
                    {
                        unitCalc = (decimal)((long)calcList[index].Value / (decimal)priceUnit);
                    }
                    else if (calcList[index].Value is double)
                    {
                        unitCalc = (decimal)((double)calcList[index].Value / (double)priceUnit);
                    }
                    else
                    {
                        continue;
                    }
                    calcList[index].Value = unitCalc;
                }
            }
        }
        // ADD 2009/04/13 ------<<<

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
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label Lb_TitleHeader;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Lb_StockUnitPrice;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.Label Lb_ProDuctNumber;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.GroupHeader WareHouseHeader;
		private DataDynamics.ActiveReports.GroupHeader DailyHeader;
		private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox TermSalesComp;
		private DataDynamics.ActiveReports.TextBox OrderSalesMoney;
		private DataDynamics.ActiveReports.TextBox StockSalesMoney;
		private DataDynamics.ActiveReports.TextBox GrossMarginRate;
		private DataDynamics.ActiveReports.TextBox GrossMoney;
		private DataDynamics.ActiveReports.TextBox TotalOrderSalesMoney;
		private DataDynamics.ActiveReports.TextBox TotalStockSalesMoney;
		private DataDynamics.ActiveReports.TextBox TotalGrossMarginRate;
		private DataDynamics.ActiveReports.TextBox TotalGrossMoney;
		private DataDynamics.ActiveReports.TextBox TotalOrderStockMoney;
		private DataDynamics.ActiveReports.GroupFooter DailyFooter;
		private DataDynamics.ActiveReports.GroupFooter WareHouseFooter;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SectionTitle;
        private DataDynamics.ActiveReports.TextBox s_TermSalesComp;
		private DataDynamics.ActiveReports.TextBox s_StockSalesMoney;
		private DataDynamics.ActiveReports.TextBox s_GrossMoney;
		private DataDynamics.ActiveReports.TextBox s_TotalStockSalesMoney;
		private DataDynamics.ActiveReports.TextBox s_TotalGrossMoney;
		private DataDynamics.ActiveReports.TextBox s_GrossMarginRate;
		private DataDynamics.ActiveReports.TextBox s_TotalGrossMarginRate;
		private DataDynamics.ActiveReports.TextBox s_CostMoney;
		private DataDynamics.ActiveReports.TextBox s_TotalCostMoney;
		private DataDynamics.ActiveReports.TextBox s_YearSalesComp;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotalTitle;
		private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.TextBox g_TermSalesComp;
		private DataDynamics.ActiveReports.TextBox g_StockSalesMoney;
		private DataDynamics.ActiveReports.TextBox g_TotalStockSalesMoney;
		private DataDynamics.ActiveReports.TextBox g_GrossMoney;
		private DataDynamics.ActiveReports.TextBox g_TotalGrossMoney;
		private DataDynamics.ActiveReports.TextBox g_GrossMarginRate;
		private DataDynamics.ActiveReports.TextBox g_TotalGrossMarginRate;
		private DataDynamics.ActiveReports.TextBox g_CostMoney;
		private DataDynamics.ActiveReports.TextBox g_TotalCostMoney;
		private DataDynamics.ActiveReports.TextBox g_YearSalesComp;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02152P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.OrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.StockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.GrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalOrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalStockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.TotalGrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalOrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.StockMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalCostMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.TotalDifference = new DataDynamics.ActiveReports.TextBox();
            this.CostMoney = new DataDynamics.ActiveReports.TextBox();
            this.OrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.StockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.Difference = new DataDynamics.ActiveReports.TextBox();
            this.TotalStockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.YearSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.YearStockComp = new DataDynamics.ActiveReports.TextBox();
            this.DetailLine = new DataDynamics.ActiveReports.TextBox();
            this.DetailLineName = new DataDynamics.ActiveReports.TextBox();
            this.MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.TotalMoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.MoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.TotalMoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.TotalGrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
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
            this.Lb_TitleHeader = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Lb_StockUnitPrice = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Lb_ProDuctNumber = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.Lb_TitleHeaderSub = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.bottomline_TitleHeader = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.g_TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.g_StockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalStockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalGrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_GrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.g_CostMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalCostMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_YearSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.g_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_StockMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalOrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_YearStockComp = new DataDynamics.ActiveReports.TextBox();
            this.g_OrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalOrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_OrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_StockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalStockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.g_Difference = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalDifference = new DataDynamics.ActiveReports.TextBox();
            this.g_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalMoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.g_MoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalMoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.g_SalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.g_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalGrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.line20 = new DataDynamics.ActiveReports.Line();
            this.line21 = new DataDynamics.ActiveReports.Line();
            this.line22 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.upline_SectionHeader = new DataDynamics.ActiveReports.Line();
            this.SectionHeaderLine = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeaderLineName = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.s_TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.s_StockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalStockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalGrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_GrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.s_CostMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalCostMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_YearSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalOrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_StockMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalOrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_OrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_OrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_StockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalStockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.s_YearStockComp = new DataDynamics.ActiveReports.TextBox();
            this.s_Difference = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalDifference = new DataDynamics.ActiveReports.TextBox();
            this.s_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalMoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.s_MoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalMoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.s_SalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.s_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalGrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.line18 = new DataDynamics.ActiveReports.Line();
            this.line23 = new DataDynamics.ActiveReports.Line();
            this.line24 = new DataDynamics.ActiveReports.Line();
            this.WareHouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WareHouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.DailyHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DailyFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.DailyTitle = new DataDynamics.ActiveReports.TextBox();
            this.d_TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.d_StockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalStockSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_GrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.d_CostMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalGrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalCostMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_YearSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.d_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalOrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_StockMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalOrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_YearStockComp = new DataDynamics.ActiveReports.TextBox();
            this.d_OrderSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_OrderStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_StockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalStockStockMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.d_Difference = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalDifference = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.d_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalMoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.d_MoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalMoveArrivalPric = new DataDynamics.ActiveReports.TextBox();
            this.d_SalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.d_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalGrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.line12 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalOrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalGrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalOrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Difference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalGrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ProDuctNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeaderSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalStockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalGrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalCostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_YearSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalOrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_YearStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalOrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalStockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Difference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalMoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalMoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalGrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalStockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalGrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalCostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_YearSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalOrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalOrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalStockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_YearStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_Difference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalMoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalMoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalGrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalStockSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_CostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalGrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalCostMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_YearSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalOrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalOrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_YearStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_OrderSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_OrderStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalStockStockMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_Difference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalMoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalMoveArrivalPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalGrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TermSalesComp,
            this.OrderSalesMoney,
            this.StockSalesMoney,
            this.GrossMarginRate,
            this.GrossMoney,
            this.TotalOrderSalesMoney,
            this.TotalStockSalesMoney,
            this.TotalGrossMarginRate,
            this.TotalGrossMoney,
            this.TotalOrderStockMoney,
            this.SalesMoney,
            this.TotalSalesMoney,
            this.StockMoney,
            this.TotalCostMoney,
            this.TotalStockMoney,
            this.TotalDifference,
            this.CostMoney,
            this.OrderStockMoney,
            this.StockStockMoney,
            this.TermStockComp,
            this.Difference,
            this.TotalStockStockMoney,
            this.YearSalesComp,
            this.YearStockComp,
            this.DetailLine,
            this.DetailLineName,
            this.MoveShipmentPrice,
            this.TotalMoveShipmentPrice,
            this.MoveArrivalPric,
            this.TotalMoveArrivalPric,
            this.SalesMoneyOrg,
            this.TotalSalesMoneyOrg,
            this.GrossMoneyOrg,
            this.TotalGrossMoneyOrg,
            this.line3,
            this.line5,
            this.line6,
            this.line7,
            this.line8});
            this.Detail.Height = 0.8145F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // TermSalesComp
            // 
            this.TermSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.TermSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.TermSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.TermSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.TermSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermSalesComp.DataField = "TermSalesComp";
            this.TermSalesComp.Height = 0.156F;
            this.TermSalesComp.Left = 8.76F;
            this.TermSalesComp.MultiLine = false;
            this.TermSalesComp.Name = "TermSalesComp";
            this.TermSalesComp.OutputFormat = resources.GetString("TermSalesComp.OutputFormat");
            this.TermSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TermSalesComp.Text = "123,546,789";
            this.TermSalesComp.Top = 0.06F;
            this.TermSalesComp.Width = 0.66F;
            // 
            // OrderSalesMoney
            // 
            this.OrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.OrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.OrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderSalesMoney.DataField = "OrderSalesMoney";
            this.OrderSalesMoney.Height = 0.156F;
            this.OrderSalesMoney.Left = 2.41F;
            this.OrderSalesMoney.MultiLine = false;
            this.OrderSalesMoney.Name = "OrderSalesMoney";
            this.OrderSalesMoney.OutputFormat = resources.GetString("OrderSalesMoney.OutputFormat");
            this.OrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.OrderSalesMoney.Text = "123,546,789";
            this.OrderSalesMoney.Top = 0.06F;
            this.OrderSalesMoney.Width = 0.66F;
            // 
            // StockSalesMoney
            // 
            this.StockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.StockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.StockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSalesMoney.DataField = "StockSalesMoney";
            this.StockSalesMoney.Height = 0.156F;
            this.StockSalesMoney.Left = 3.07F;
            this.StockSalesMoney.MultiLine = false;
            this.StockSalesMoney.Name = "StockSalesMoney";
            this.StockSalesMoney.OutputFormat = resources.GetString("StockSalesMoney.OutputFormat");
            this.StockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockSalesMoney.Text = "123,546,789";
            this.StockSalesMoney.Top = 0.06F;
            this.StockSalesMoney.Width = 0.66F;
            // 
            // GrossMarginRate
            // 
            this.GrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.DataField = "GrossMarginRate";
            this.GrossMarginRate.Height = 0.16F;
            this.GrossMarginRate.Left = 4.39F;
            this.GrossMarginRate.MultiLine = false;
            this.GrossMarginRate.Name = "GrossMarginRate";
            this.GrossMarginRate.OutputFormat = resources.GetString("GrossMarginRate.OutputFormat");
            this.GrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossMarginRate.Text = "123,45";
            this.GrossMarginRate.Top = 0.06F;
            this.GrossMarginRate.Width = 0.375F;
            // 
            // GrossMoney
            // 
            this.GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoney.DataField = "GrossMoney";
            this.GrossMoney.Height = 0.156F;
            this.GrossMoney.Left = 3.73F;
            this.GrossMoney.MultiLine = false;
            this.GrossMoney.Name = "GrossMoney";
            this.GrossMoney.OutputFormat = resources.GetString("GrossMoney.OutputFormat");
            this.GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossMoney.Text = "123,546,789";
            this.GrossMoney.Top = 0.06F;
            this.GrossMoney.Width = 0.66F;
            // 
            // TotalOrderSalesMoney
            // 
            this.TotalOrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalOrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalOrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalOrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalOrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderSalesMoney.DataField = "TotalOrderSalesMoney";
            this.TotalOrderSalesMoney.Height = 0.156F;
            this.TotalOrderSalesMoney.Left = 2.41F;
            this.TotalOrderSalesMoney.MultiLine = false;
            this.TotalOrderSalesMoney.Name = "TotalOrderSalesMoney";
            this.TotalOrderSalesMoney.OutputFormat = resources.GetString("TotalOrderSalesMoney.OutputFormat");
            this.TotalOrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalOrderSalesMoney.Text = "123,546,789";
            this.TotalOrderSalesMoney.Top = 0.25F;
            this.TotalOrderSalesMoney.Width = 0.66F;
            // 
            // TotalStockSalesMoney
            // 
            this.TotalStockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockSalesMoney.DataField = "TotalStockSalesMoney";
            this.TotalStockSalesMoney.Height = 0.156F;
            this.TotalStockSalesMoney.Left = 3.07F;
            this.TotalStockSalesMoney.MultiLine = false;
            this.TotalStockSalesMoney.Name = "TotalStockSalesMoney";
            this.TotalStockSalesMoney.OutputFormat = resources.GetString("TotalStockSalesMoney.OutputFormat");
            this.TotalStockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalStockSalesMoney.Text = "123,546,789";
            this.TotalStockSalesMoney.Top = 0.25F;
            this.TotalStockSalesMoney.Width = 0.66F;
            // 
            // TotalGrossMarginRate
            // 
            this.TotalGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.TotalGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.TotalGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMarginRate.DataField = "TotalGrossMarginRate";
            this.TotalGrossMarginRate.Height = 0.16F;
            this.TotalGrossMarginRate.Left = 4.39F;
            this.TotalGrossMarginRate.MultiLine = false;
            this.TotalGrossMarginRate.Name = "TotalGrossMarginRate";
            this.TotalGrossMarginRate.OutputFormat = resources.GetString("TotalGrossMarginRate.OutputFormat");
            this.TotalGrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalGrossMarginRate.Text = "123,45";
            this.TotalGrossMarginRate.Top = 0.25F;
            this.TotalGrossMarginRate.Width = 0.375F;
            // 
            // TotalGrossMoney
            // 
            this.TotalGrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalGrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalGrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalGrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalGrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoney.DataField = "TotalGrossMoney";
            this.TotalGrossMoney.Height = 0.156F;
            this.TotalGrossMoney.Left = 3.73F;
            this.TotalGrossMoney.MultiLine = false;
            this.TotalGrossMoney.Name = "TotalGrossMoney";
            this.TotalGrossMoney.OutputFormat = resources.GetString("TotalGrossMoney.OutputFormat");
            this.TotalGrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalGrossMoney.Text = "123,546,789";
            this.TotalGrossMoney.Top = 0.25F;
            this.TotalGrossMoney.Width = 0.66F;
            // 
            // TotalOrderStockMoney
            // 
            this.TotalOrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalOrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalOrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalOrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalOrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalOrderStockMoney.DataField = "TotalOrderStockMoney";
            this.TotalOrderStockMoney.Height = 0.156F;
            this.TotalOrderStockMoney.Left = 6.76F;
            this.TotalOrderStockMoney.MultiLine = false;
            this.TotalOrderStockMoney.Name = "TotalOrderStockMoney";
            this.TotalOrderStockMoney.OutputFormat = resources.GetString("TotalOrderStockMoney.OutputFormat");
            this.TotalOrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalOrderStockMoney.Text = "123,546,789";
            this.TotalOrderStockMoney.Top = 0.25F;
            this.TotalOrderStockMoney.Width = 0.66F;
            // 
            // SalesMoney
            // 
            this.SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.DataField = "SalesMoney";
            this.SalesMoney.Height = 0.156F;
            this.SalesMoney.Left = 1.75F;
            this.SalesMoney.MultiLine = false;
            this.SalesMoney.Name = "SalesMoney";
            this.SalesMoney.OutputFormat = resources.GetString("SalesMoney.OutputFormat");
            this.SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoney.Text = "123,546,789";
            this.SalesMoney.Top = 0.0625F;
            this.SalesMoney.Width = 0.66F;
            // 
            // TotalSalesMoney
            // 
            this.TotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoney.DataField = "TotalSalesMoney";
            this.TotalSalesMoney.Height = 0.156F;
            this.TotalSalesMoney.Left = 1.75F;
            this.TotalSalesMoney.MultiLine = false;
            this.TotalSalesMoney.Name = "TotalSalesMoney";
            this.TotalSalesMoney.OutputFormat = resources.GetString("TotalSalesMoney.OutputFormat");
            this.TotalSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalSalesMoney.Text = "123,546,789";
            this.TotalSalesMoney.Top = 0.25F;
            this.TotalSalesMoney.Width = 0.66F;
            // 
            // StockMoney
            // 
            this.StockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.StockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.StockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.StockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.StockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoney.DataField = "StockMoney";
            this.StockMoney.Height = 0.156F;
            this.StockMoney.Left = 6.1F;
            this.StockMoney.MultiLine = false;
            this.StockMoney.Name = "StockMoney";
            this.StockMoney.OutputFormat = resources.GetString("StockMoney.OutputFormat");
            this.StockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockMoney.Text = "123,546,789";
            this.StockMoney.Top = 0.063F;
            this.StockMoney.Width = 0.66F;
            // 
            // TotalCostMoney
            // 
            this.TotalCostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalCostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalCostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalCostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalCostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCostMoney.DataField = "TotalCostMoney";
            this.TotalCostMoney.Height = 0.156F;
            this.TotalCostMoney.Left = 5.425F;
            this.TotalCostMoney.MultiLine = false;
            this.TotalCostMoney.Name = "TotalCostMoney";
            this.TotalCostMoney.OutputFormat = resources.GetString("TotalCostMoney.OutputFormat");
            this.TotalCostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalCostMoney.Text = "123,546,789";
            this.TotalCostMoney.Top = 0.25F;
            this.TotalCostMoney.Width = 0.66F;
            // 
            // TotalStockMoney
            // 
            this.TotalStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockMoney.DataField = "TotalStockMoney";
            this.TotalStockMoney.Height = 0.156F;
            this.TotalStockMoney.Left = 6.1F;
            this.TotalStockMoney.MultiLine = false;
            this.TotalStockMoney.Name = "TotalStockMoney";
            this.TotalStockMoney.OutputFormat = resources.GetString("TotalStockMoney.OutputFormat");
            this.TotalStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalStockMoney.Text = "123,546,789";
            this.TotalStockMoney.Top = 0.25F;
            this.TotalStockMoney.Width = 0.66F;
            // 
            // TotalDifference
            // 
            this.TotalDifference.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalDifference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDifference.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalDifference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDifference.Border.RightColor = System.Drawing.Color.Black;
            this.TotalDifference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDifference.Border.TopColor = System.Drawing.Color.Black;
            this.TotalDifference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalDifference.DataField = "TotalDifference";
            this.TotalDifference.Height = 0.156F;
            this.TotalDifference.Left = 10.08F;
            this.TotalDifference.MultiLine = false;
            this.TotalDifference.Name = "TotalDifference";
            this.TotalDifference.OutputFormat = resources.GetString("TotalDifference.OutputFormat");
            this.TotalDifference.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalDifference.Text = "123,546,789";
            this.TotalDifference.Top = 0.25F;
            this.TotalDifference.Width = 0.66F;
            // 
            // CostMoney
            // 
            this.CostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.CostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.CostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.CostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.CostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CostMoney.DataField = "CostMoney";
            this.CostMoney.Height = 0.156F;
            this.CostMoney.Left = 5.425F;
            this.CostMoney.MultiLine = false;
            this.CostMoney.Name = "CostMoney";
            this.CostMoney.OutputFormat = resources.GetString("CostMoney.OutputFormat");
            this.CostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.CostMoney.Text = "123,546,789";
            this.CostMoney.Top = 0.06F;
            this.CostMoney.Width = 0.66F;
            // 
            // OrderStockMoney
            // 
            this.OrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.OrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.OrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderStockMoney.DataField = "OrderStockMoney";
            this.OrderStockMoney.Height = 0.156F;
            this.OrderStockMoney.Left = 6.76F;
            this.OrderStockMoney.MultiLine = false;
            this.OrderStockMoney.Name = "OrderStockMoney";
            this.OrderStockMoney.OutputFormat = resources.GetString("OrderStockMoney.OutputFormat");
            this.OrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.OrderStockMoney.Text = "123,546,789";
            this.OrderStockMoney.Top = 0.06F;
            this.OrderStockMoney.Width = 0.66F;
            // 
            // StockStockMoney
            // 
            this.StockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.StockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.StockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.StockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.StockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockStockMoney.DataField = "StockStockMoney";
            this.StockStockMoney.Height = 0.156F;
            this.StockStockMoney.Left = 7.42F;
            this.StockStockMoney.MultiLine = false;
            this.StockStockMoney.Name = "StockStockMoney";
            this.StockStockMoney.OutputFormat = resources.GetString("StockStockMoney.OutputFormat");
            this.StockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockStockMoney.Text = "123,546,789";
            this.StockStockMoney.Top = 0.06F;
            this.StockStockMoney.Width = 0.66F;
            // 
            // TermStockComp
            // 
            this.TermStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.TermStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.TermStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.TermStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.TermStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermStockComp.DataField = "TermStockComp";
            this.TermStockComp.Height = 0.156F;
            this.TermStockComp.Left = 9.42F;
            this.TermStockComp.MultiLine = false;
            this.TermStockComp.Name = "TermStockComp";
            this.TermStockComp.OutputFormat = resources.GetString("TermStockComp.OutputFormat");
            this.TermStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TermStockComp.Text = "123,546,789";
            this.TermStockComp.Top = 0.0625F;
            this.TermStockComp.Width = 0.66F;
            // 
            // Difference
            // 
            this.Difference.Border.BottomColor = System.Drawing.Color.Black;
            this.Difference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Difference.Border.LeftColor = System.Drawing.Color.Black;
            this.Difference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Difference.Border.RightColor = System.Drawing.Color.Black;
            this.Difference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Difference.Border.TopColor = System.Drawing.Color.Black;
            this.Difference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Difference.DataField = "Difference";
            this.Difference.Height = 0.156F;
            this.Difference.Left = 10.08F;
            this.Difference.MultiLine = false;
            this.Difference.Name = "Difference";
            this.Difference.OutputFormat = resources.GetString("Difference.OutputFormat");
            this.Difference.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.Difference.Text = "123,546,789";
            this.Difference.Top = 0.0625F;
            this.Difference.Width = 0.66F;
            // 
            // TotalStockStockMoney
            // 
            this.TotalStockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockStockMoney.DataField = "TotalStockStockMoney";
            this.TotalStockStockMoney.Height = 0.156F;
            this.TotalStockStockMoney.Left = 7.42F;
            this.TotalStockStockMoney.MultiLine = false;
            this.TotalStockStockMoney.Name = "TotalStockStockMoney";
            this.TotalStockStockMoney.OutputFormat = resources.GetString("TotalStockStockMoney.OutputFormat");
            this.TotalStockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalStockStockMoney.Text = "123,546,789";
            this.TotalStockStockMoney.Top = 0.25F;
            this.TotalStockStockMoney.Width = 0.66F;
            // 
            // YearSalesComp
            // 
            this.YearSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.YearSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.YearSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.YearSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.YearSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearSalesComp.DataField = "YearSalesComp";
            this.YearSalesComp.Height = 0.156F;
            this.YearSalesComp.Left = 8.76F;
            this.YearSalesComp.MultiLine = false;
            this.YearSalesComp.Name = "YearSalesComp";
            this.YearSalesComp.OutputFormat = resources.GetString("YearSalesComp.OutputFormat");
            this.YearSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.YearSalesComp.Text = "123,546,789";
            this.YearSalesComp.Top = 0.25F;
            this.YearSalesComp.Width = 0.66F;
            // 
            // YearStockComp
            // 
            this.YearStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.YearStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.YearStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.YearStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.YearStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.YearStockComp.DataField = "YearStockComp";
            this.YearStockComp.Height = 0.156F;
            this.YearStockComp.Left = 9.42F;
            this.YearStockComp.MultiLine = false;
            this.YearStockComp.Name = "YearStockComp";
            this.YearStockComp.OutputFormat = resources.GetString("YearStockComp.OutputFormat");
            this.YearStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.YearStockComp.Text = "123,546,789";
            this.YearStockComp.Top = 0.25F;
            this.YearStockComp.Width = 0.66F;
            // 
            // DetailLine
            // 
            this.DetailLine.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailLine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailLine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.Border.RightColor = System.Drawing.Color.Black;
            this.DetailLine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.Border.TopColor = System.Drawing.Color.Black;
            this.DetailLine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLine.DataField = "DetailLine";
            this.DetailLine.Height = 0.16F;
            this.DetailLine.Left = 0.125F;
            this.DetailLine.MultiLine = false;
            this.DetailLine.Name = "DetailLine";
            this.DetailLine.OutputFormat = resources.GetString("DetailLine.OutputFormat");
            this.DetailLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.DetailLine.Text = "123456";
            this.DetailLine.Top = 0.0625F;
            this.DetailLine.Width = 0.4F;
            // 
            // DetailLineName
            // 
            this.DetailLineName.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.Border.RightColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.Border.TopColor = System.Drawing.Color.Black;
            this.DetailLineName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailLineName.DataField = "DetailLineName";
            this.DetailLineName.Height = 0.16F;
            this.DetailLineName.Left = 0.525F;
            this.DetailLineName.MultiLine = false;
            this.DetailLineName.Name = "DetailLineName";
            this.DetailLineName.OutputFormat = resources.GetString("DetailLineName.OutputFormat");
            this.DetailLineName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.DetailLineName.Text = "あいうえおかきくけこ";
            this.DetailLineName.Top = 0.063F;
            this.DetailLineName.Width = 1.2F;
            // 
            // MoveShipmentPrice
            // 
            this.MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.MoveShipmentPrice.Height = 0.156F;
            this.MoveShipmentPrice.Left = 4.765F;
            this.MoveShipmentPrice.MultiLine = false;
            this.MoveShipmentPrice.Name = "MoveShipmentPrice";
            this.MoveShipmentPrice.OutputFormat = resources.GetString("MoveShipmentPrice.OutputFormat");
            this.MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MoveShipmentPrice.Text = "123,546,789";
            this.MoveShipmentPrice.Top = 0.0625F;
            this.MoveShipmentPrice.Width = 0.66F;
            // 
            // TotalMoveShipmentPrice
            // 
            this.TotalMoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalMoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalMoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.TotalMoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.TotalMoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveShipmentPrice.DataField = "TotalMoveShipmentPrice";
            this.TotalMoveShipmentPrice.Height = 0.156F;
            this.TotalMoveShipmentPrice.Left = 4.765F;
            this.TotalMoveShipmentPrice.MultiLine = false;
            this.TotalMoveShipmentPrice.Name = "TotalMoveShipmentPrice";
            this.TotalMoveShipmentPrice.OutputFormat = resources.GetString("TotalMoveShipmentPrice.OutputFormat");
            this.TotalMoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalMoveShipmentPrice.Text = "123,546,789";
            this.TotalMoveShipmentPrice.Top = 0.25F;
            this.TotalMoveShipmentPrice.Width = 0.66F;
            // 
            // MoveArrivalPric
            // 
            this.MoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.MoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.MoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPric.DataField = "MoveArrivalPric";
            this.MoveArrivalPric.Height = 0.156F;
            this.MoveArrivalPric.Left = 8.08F;
            this.MoveArrivalPric.MultiLine = false;
            this.MoveArrivalPric.Name = "MoveArrivalPric";
            this.MoveArrivalPric.OutputFormat = resources.GetString("MoveArrivalPric.OutputFormat");
            this.MoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MoveArrivalPric.Text = "123,546,789";
            this.MoveArrivalPric.Top = 0.0625F;
            this.MoveArrivalPric.Width = 0.66F;
            // 
            // TotalMoveArrivalPric
            // 
            this.TotalMoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalMoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalMoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.TotalMoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.TotalMoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalMoveArrivalPric.DataField = "TotalMoveArrivalPric";
            this.TotalMoveArrivalPric.Height = 0.156F;
            this.TotalMoveArrivalPric.Left = 8.08F;
            this.TotalMoveArrivalPric.MultiLine = false;
            this.TotalMoveArrivalPric.Name = "TotalMoveArrivalPric";
            this.TotalMoveArrivalPric.OutputFormat = resources.GetString("TotalMoveArrivalPric.OutputFormat");
            this.TotalMoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalMoveArrivalPric.Text = "123,546,789";
            this.TotalMoveArrivalPric.Top = 0.25F;
            this.TotalMoveArrivalPric.Width = 0.66F;
            // 
            // SalesMoneyOrg
            // 
            this.SalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrg.DataField = "SalesMoneyOrg";
            this.SalesMoneyOrg.Height = 0.156F;
            this.SalesMoneyOrg.Left = 1.75F;
            this.SalesMoneyOrg.MultiLine = false;
            this.SalesMoneyOrg.Name = "SalesMoneyOrg";
            this.SalesMoneyOrg.OutputFormat = resources.GetString("SalesMoneyOrg.OutputFormat");
            this.SalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyOrg.Text = "123,546,789";
            this.SalesMoneyOrg.Top = 0.4375F;
            this.SalesMoneyOrg.Visible = false;
            this.SalesMoneyOrg.Width = 0.66F;
            // 
            // TotalSalesMoneyOrg
            // 
            this.TotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.TotalSalesMoneyOrg.Height = 0.156F;
            this.TotalSalesMoneyOrg.Left = 1.75F;
            this.TotalSalesMoneyOrg.MultiLine = false;
            this.TotalSalesMoneyOrg.Name = "TotalSalesMoneyOrg";
            this.TotalSalesMoneyOrg.OutputFormat = resources.GetString("TotalSalesMoneyOrg.OutputFormat");
            this.TotalSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalSalesMoneyOrg.Text = "123,546,789";
            this.TotalSalesMoneyOrg.Top = 0.625F;
            this.TotalSalesMoneyOrg.Visible = false;
            this.TotalSalesMoneyOrg.Width = 0.66F;
            // 
            // GrossMoneyOrg
            // 
            this.GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.GrossMoneyOrg.Height = 0.156F;
            this.GrossMoneyOrg.Left = 3.75F;
            this.GrossMoneyOrg.MultiLine = false;
            this.GrossMoneyOrg.Name = "GrossMoneyOrg";
            this.GrossMoneyOrg.OutputFormat = resources.GetString("GrossMoneyOrg.OutputFormat");
            this.GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossMoneyOrg.Text = "123,546,789";
            this.GrossMoneyOrg.Top = 0.4375F;
            this.GrossMoneyOrg.Visible = false;
            this.GrossMoneyOrg.Width = 0.66F;
            // 
            // TotalGrossMoneyOrg
            // 
            this.TotalGrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalGrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalGrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.TotalGrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.TotalGrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalGrossMoneyOrg.DataField = "TotalGrossMoneyOrg";
            this.TotalGrossMoneyOrg.Height = 0.156F;
            this.TotalGrossMoneyOrg.Left = 3.75F;
            this.TotalGrossMoneyOrg.MultiLine = false;
            this.TotalGrossMoneyOrg.Name = "TotalGrossMoneyOrg";
            this.TotalGrossMoneyOrg.OutputFormat = resources.GetString("TotalGrossMoneyOrg.OutputFormat");
            this.TotalGrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalGrossMoneyOrg.Text = "123,546,789";
            this.TotalGrossMoneyOrg.Top = 0.625F;
            this.TotalGrossMoneyOrg.Visible = false;
            this.TotalGrossMoneyOrg.Width = 0.66F;
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
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
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
            this.line5.Height = 0.1175F;
            this.line5.Left = 6.09F;
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0.0625F;
            this.line5.Width = 0F;
            this.line5.X1 = 6.09F;
            this.line5.X2 = 6.09F;
            this.line5.Y1 = 0.0625F;
            this.line5.Y2 = 0.18F;
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
            this.line6.Height = 0.12F;
            this.line6.Left = 6.09F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0.25F;
            this.line6.Width = 0F;
            this.line6.X1 = 6.09F;
            this.line6.X2 = 6.09F;
            this.line6.Y1 = 0.25F;
            this.line6.Y2 = 0.37F;
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
            this.line7.Height = 0.12F;
            this.line7.Left = 8.75F;
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0.25F;
            this.line7.Width = 0F;
            this.line7.X1 = 8.75F;
            this.line7.X2 = 8.75F;
            this.line7.Y1 = 0.25F;
            this.line7.Y2 = 0.37F;
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
            this.line8.Height = 0.1175F;
            this.line8.Left = 8.75F;
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0.0625F;
            this.line8.Width = 0F;
            this.line8.X1 = 8.75F;
            this.line8.X2 = 8.75F;
            this.line8.Y1 = 0.0625F;
            this.line8.Y2 = 0.18F;
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
            this.Label3.Left = 7.9375F;
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
            this.tb_PrintDate.Left = 8.5F;
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
            this.Label2.Left = 9.9375F;
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
            this.tb_PrintPage.Left = 10.4375F;
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
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
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
            this.tb_PrintTime.Left = 9.4375F;
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
            this.tb_ReportTitle.Text = "売上仕入対比表(月報年報)";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.28125F;
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
            this.Lb_TitleHeader,
            this.Label4,
            this.Lb_StockUnitPrice,
            this.Label7,
            this.Label8,
            this.Lb_ProDuctNumber,
            this.label1,
            this.label6,
            this.label9,
            this.label10,
            this.label5,
            this.label11,
            this.label12,
            this.Lb_TitleHeaderSub,
            this.label14,
            this.label15,
            this.label16,
            this.bottomline_TitleHeader,
            this.line2,
            this.label13,
            this.label17,
            this.line13,
            this.line14,
            this.line15,
            this.line16});
            this.TitleHeader.Height = 0.5104167F;
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
            this.Line42.Top = 0F;
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // Lb_TitleHeader
            // 
            this.Lb_TitleHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Height = 0.156F;
            this.Lb_TitleHeader.HyperLink = "";
            this.Lb_TitleHeader.Left = 0F;
            this.Lb_TitleHeader.MultiLine = false;
            this.Lb_TitleHeader.Name = "Lb_TitleHeader";
            this.Lb_TitleHeader.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TitleHeader.Text = "拠点";
            this.Lb_TitleHeader.Top = 0.0625F;
            this.Lb_TitleHeader.Width = 1.5F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.156F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 7.42F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label4.Text = "在庫";
            this.Label4.Top = 0.25F;
            this.Label4.Width = 0.66F;
            // 
            // Lb_StockUnitPrice
            // 
            this.Lb_StockUnitPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockUnitPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockUnitPrice.Height = 0.156F;
            this.Lb_StockUnitPrice.HyperLink = "";
            this.Lb_StockUnitPrice.Left = 3.73F;
            this.Lb_StockUnitPrice.MultiLine = false;
            this.Lb_StockUnitPrice.Name = "Lb_StockUnitPrice";
            this.Lb_StockUnitPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockUnitPrice.Text = "粗利";
            this.Lb_StockUnitPrice.Top = 0.25F;
            this.Lb_StockUnitPrice.Width = 0.66F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.156F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 2.41F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label7.Text = "取寄";
            this.Label7.Top = 0.25F;
            this.Label7.Width = 0.66F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.156F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 3.07F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label8.Text = "在庫";
            this.Label8.Top = 0.25F;
            this.Label8.Width = 0.66F;
            // 
            // Lb_ProDuctNumber
            // 
            this.Lb_ProDuctNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ProDuctNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ProDuctNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ProDuctNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ProDuctNumber.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ProDuctNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ProDuctNumber.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ProDuctNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ProDuctNumber.Height = 0.16F;
            this.Lb_ProDuctNumber.HyperLink = "";
            this.Lb_ProDuctNumber.Left = 4.39F;
            this.Lb_ProDuctNumber.MultiLine = false;
            this.Lb_ProDuctNumber.Name = "Lb_ProDuctNumber";
            this.Lb_ProDuctNumber.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ProDuctNumber.Text = "粗利率";
            this.Lb_ProDuctNumber.Top = 0.25F;
            this.Lb_ProDuctNumber.Width = 0.375F;
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
            this.label1.Left = 1.75F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "売上合計";
            this.label1.Top = 0.25F;
            this.label1.Width = 0.66F;
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
            this.label6.Left = 5.425F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "売上原価";
            this.label6.Top = 0.25F;
            this.label6.Width = 0.66F;
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
            this.label9.Left = 6.1F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "仕入合計";
            this.label9.Top = 0.25F;
            this.label9.Width = 0.66F;
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
            this.label10.Left = 6.76F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "取寄";
            this.label10.Top = 0.25F;
            this.label10.Width = 0.66F;
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
            this.label5.Left = 8.76F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "売上";
            this.label5.Top = 0.25F;
            this.label5.Width = 0.66F;
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
            this.label11.Left = 9.42F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "仕入";
            this.label11.Top = 0.25F;
            this.label11.Width = 0.66F;
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
            this.label12.Left = 10.08F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "差額";
            this.label12.Top = 0.25F;
            this.label12.Width = 0.66F;
            // 
            // Lb_TitleHeaderSub
            // 
            this.Lb_TitleHeaderSub.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TitleHeaderSub.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeaderSub.Height = 0.16F;
            this.Lb_TitleHeaderSub.HyperLink = "";
            this.Lb_TitleHeaderSub.Left = 0.125F;
            this.Lb_TitleHeaderSub.MultiLine = false;
            this.Lb_TitleHeaderSub.Name = "Lb_TitleHeaderSub";
            this.Lb_TitleHeaderSub.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TitleHeaderSub.Text = "仕入先";
            this.Lb_TitleHeaderSub.Top = 0.25F;
            this.Lb_TitleHeaderSub.Width = 1.4F;
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
            this.label14.Height = 0.16F;
            this.label14.HyperLink = "";
            this.label14.Left = 1.6875F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "＜＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝ 売　　上 ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＞";
            this.label14.Top = 0.0625F;
            this.label14.Width = 4.4F;
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
            this.label15.Height = 0.16F;
            this.label15.HyperLink = "";
            this.label15.Left = 6.1F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "＜＝＝＝＝＝＝＝＝ 仕　　入 ＝＝＝＝＝＝＝＝＞";
            this.label15.Top = 0.0625F;
            this.label15.Width = 2.65F;
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
            this.label16.Height = 0.16F;
            this.label16.HyperLink = "";
            this.label16.Left = 8.76F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "＜＝＝＝＝＝ 対　　比 ＝＝＝＝＝＞";
            this.label16.Top = 0.0625F;
            this.label16.Width = 1.97F;
            // 
            // bottomline_TitleHeader
            // 
            this.bottomline_TitleHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Border.RightColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Border.TopColor = System.Drawing.Color.Black;
            this.bottomline_TitleHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.bottomline_TitleHeader.Height = 0F;
            this.bottomline_TitleHeader.Left = 0F;
            this.bottomline_TitleHeader.LineWeight = 2F;
            this.bottomline_TitleHeader.Name = "bottomline_TitleHeader";
            this.bottomline_TitleHeader.Top = 0.4375F;
            this.bottomline_TitleHeader.Width = 10.8F;
            this.bottomline_TitleHeader.X1 = 0F;
            this.bottomline_TitleHeader.X2 = 10.8F;
            this.bottomline_TitleHeader.Y1 = 0.4375F;
            this.bottomline_TitleHeader.Y2 = 0.4375F;
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
            this.line2.Width = 1.949583F;
            this.line2.X1 = 0F;
            this.line2.X2 = 1.949583F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.label13.Left = 4.765F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "移動出庫";
            this.label13.Top = 0.25F;
            this.label13.Width = 0.66F;
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
            this.label17.Left = 8.08F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "移動入庫";
            this.label17.Top = 0.25F;
            this.label17.Width = 0.66F;
            // 
            // line13
            // 
            this.line13.Border.BottomColor = System.Drawing.Color.Black;
            this.line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.LeftColor = System.Drawing.Color.Black;
            this.line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.RightColor = System.Drawing.Color.Black;
            this.line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.TopColor = System.Drawing.Color.Black;
            this.line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Height = 0.12F;
            this.line13.Left = 6.09F;
            this.line13.LineWeight = 2F;
            this.line13.Name = "line13";
            this.line13.Top = 0.25F;
            this.line13.Width = 0F;
            this.line13.X1 = 6.09F;
            this.line13.X2 = 6.09F;
            this.line13.Y1 = 0.25F;
            this.line13.Y2 = 0.37F;
            // 
            // line14
            // 
            this.line14.Border.BottomColor = System.Drawing.Color.Black;
            this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.LeftColor = System.Drawing.Color.Black;
            this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.RightColor = System.Drawing.Color.Black;
            this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.TopColor = System.Drawing.Color.Black;
            this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Height = 0.1175F;
            this.line14.Left = 6.09F;
            this.line14.LineWeight = 2F;
            this.line14.Name = "line14";
            this.line14.Top = 0.0625F;
            this.line14.Width = 0F;
            this.line14.X1 = 6.09F;
            this.line14.X2 = 6.09F;
            this.line14.Y1 = 0.0625F;
            this.line14.Y2 = 0.18F;
            // 
            // line15
            // 
            this.line15.Border.BottomColor = System.Drawing.Color.Black;
            this.line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.LeftColor = System.Drawing.Color.Black;
            this.line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.RightColor = System.Drawing.Color.Black;
            this.line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.TopColor = System.Drawing.Color.Black;
            this.line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Height = 0.12F;
            this.line15.Left = 8.75F;
            this.line15.LineWeight = 2F;
            this.line15.Name = "line15";
            this.line15.Top = 0.25F;
            this.line15.Width = 0F;
            this.line15.X1 = 8.75F;
            this.line15.X2 = 8.75F;
            this.line15.Y1 = 0.25F;
            this.line15.Y2 = 0.37F;
            // 
            // line16
            // 
            this.line16.Border.BottomColor = System.Drawing.Color.Black;
            this.line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.LeftColor = System.Drawing.Color.Black;
            this.line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.RightColor = System.Drawing.Color.Black;
            this.line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.TopColor = System.Drawing.Color.Black;
            this.line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Height = 0.1175F;
            this.line16.Left = 8.75F;
            this.line16.LineWeight = 2F;
            this.line16.Name = "line16";
            this.line16.Top = 0.0625F;
            this.line16.Width = 0F;
            this.line16.X1 = 8.75F;
            this.line16.X2 = 8.75F;
            this.line16.Y1 = 0.0625F;
            this.line16.Y2 = 0.18F;
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
            this.Line41.Width = 10.8F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 10.8F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
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
            this.GrandTotalTitle,
            this.Line43,
            this.g_TermSalesComp,
            this.g_StockSalesMoney,
            this.g_TotalStockSalesMoney,
            this.g_GrossMoney,
            this.g_TotalGrossMoney,
            this.g_GrossMarginRate,
            this.g_TotalGrossMarginRate,
            this.g_CostMoney,
            this.g_TotalCostMoney,
            this.g_YearSalesComp,
            this.g_SalesMoney,
            this.g_TotalSalesMoney,
            this.g_StockMoney,
            this.g_TotalStockMoney,
            this.g_TotalOrderStockMoney,
            this.g_YearStockComp,
            this.g_OrderSalesMoney,
            this.g_TotalOrderSalesMoney,
            this.g_OrderStockMoney,
            this.g_StockStockMoney,
            this.g_TotalStockStockMoney,
            this.g_TermStockComp,
            this.g_Difference,
            this.g_TotalDifference,
            this.g_MoveShipmentPrice,
            this.g_TotalMoveShipmentPrice,
            this.g_MoveArrivalPric,
            this.g_TotalMoveArrivalPric,
            this.g_SalesMoneyOrg,
            this.g_TotalSalesMoneyOrg,
            this.g_GrossMoneyOrg,
            this.g_TotalGrossMoneyOrg,
            this.line19,
            this.line20,
            this.line21,
            this.line22});
            this.GrandTotalFooter.Height = 0.8229167F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
            // 
            // GrandTotalTitle
            // 
            this.GrandTotalTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.RightColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Border.TopColor = System.Drawing.Color.Black;
            this.GrandTotalTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrandTotalTitle.Height = 0.25F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 1.225F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.0625F;
            this.GrandTotalTitle.Width = 0.5F;
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
            this.Line43.Width = 10.8F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.8F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // g_TermSalesComp
            // 
            this.g_TermSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesComp.DataField = "TermSalesComp";
            this.g_TermSalesComp.Height = 0.156F;
            this.g_TermSalesComp.Left = 8.76F;
            this.g_TermSalesComp.MultiLine = false;
            this.g_TermSalesComp.Name = "g_TermSalesComp";
            this.g_TermSalesComp.OutputFormat = resources.GetString("g_TermSalesComp.OutputFormat");
            this.g_TermSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TermSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermSalesComp.Text = "123,546,789";
            this.g_TermSalesComp.Top = 0.0625F;
            this.g_TermSalesComp.Width = 0.66F;
            // 
            // g_StockSalesMoney
            // 
            this.g_StockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockSalesMoney.DataField = "StockSalesMoney";
            this.g_StockSalesMoney.Height = 0.156F;
            this.g_StockSalesMoney.Left = 3.07F;
            this.g_StockSalesMoney.MultiLine = false;
            this.g_StockSalesMoney.Name = "g_StockSalesMoney";
            this.g_StockSalesMoney.OutputFormat = resources.GetString("g_StockSalesMoney.OutputFormat");
            this.g_StockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockSalesMoney.Text = "123,546,789";
            this.g_StockSalesMoney.Top = 0.0625F;
            this.g_StockSalesMoney.Width = 0.66F;
            // 
            // g_TotalStockSalesMoney
            // 
            this.g_TotalStockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalStockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalStockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalStockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalStockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockSalesMoney.DataField = "TotalStockSalesMoney";
            this.g_TotalStockSalesMoney.Height = 0.156F;
            this.g_TotalStockSalesMoney.Left = 3.07F;
            this.g_TotalStockSalesMoney.MultiLine = false;
            this.g_TotalStockSalesMoney.Name = "g_TotalStockSalesMoney";
            this.g_TotalStockSalesMoney.OutputFormat = resources.GetString("g_TotalStockSalesMoney.OutputFormat");
            this.g_TotalStockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalStockSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalStockSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalStockSalesMoney.Text = "123,546,789";
            this.g_TotalStockSalesMoney.Top = 0.25F;
            this.g_TotalStockSalesMoney.Width = 0.66F;
            // 
            // g_GrossMoney
            // 
            this.g_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoney.DataField = "GrossMoney";
            this.g_GrossMoney.Height = 0.156F;
            this.g_GrossMoney.Left = 3.73F;
            this.g_GrossMoney.MultiLine = false;
            this.g_GrossMoney.Name = "g_GrossMoney";
            this.g_GrossMoney.OutputFormat = resources.GetString("g_GrossMoney.OutputFormat");
            this.g_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_GrossMoney.Text = "123,546,789";
            this.g_GrossMoney.Top = 0.0625F;
            this.g_GrossMoney.Width = 0.66F;
            // 
            // g_TotalGrossMoney
            // 
            this.g_TotalGrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoney.DataField = "TotalGrossMoney";
            this.g_TotalGrossMoney.Height = 0.156F;
            this.g_TotalGrossMoney.Left = 3.73F;
            this.g_TotalGrossMoney.MultiLine = false;
            this.g_TotalGrossMoney.Name = "g_TotalGrossMoney";
            this.g_TotalGrossMoney.OutputFormat = resources.GetString("g_TotalGrossMoney.OutputFormat");
            this.g_TotalGrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalGrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalGrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalGrossMoney.Text = "123,546,789";
            this.g_TotalGrossMoney.Top = 0.25F;
            this.g_TotalGrossMoney.Width = 0.66F;
            // 
            // g_GrossMarginRate
            // 
            this.g_GrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_GrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_GrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_GrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_GrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMarginRate.Height = 0.16F;
            this.g_GrossMarginRate.Left = 4.39F;
            this.g_GrossMarginRate.MultiLine = false;
            this.g_GrossMarginRate.Name = "g_GrossMarginRate";
            this.g_GrossMarginRate.OutputFormat = resources.GetString("g_GrossMarginRate.OutputFormat");
            this.g_GrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_GrossMarginRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_GrossMarginRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_GrossMarginRate.Text = "123,45";
            this.g_GrossMarginRate.Top = 0.06F;
            this.g_GrossMarginRate.Width = 0.375F;
            // 
            // g_TotalGrossMarginRate
            // 
            this.g_TotalGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMarginRate.Height = 0.16F;
            this.g_TotalGrossMarginRate.Left = 4.39F;
            this.g_TotalGrossMarginRate.MultiLine = false;
            this.g_TotalGrossMarginRate.Name = "g_TotalGrossMarginRate";
            this.g_TotalGrossMarginRate.OutputFormat = resources.GetString("g_TotalGrossMarginRate.OutputFormat");
            this.g_TotalGrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalGrossMarginRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalGrossMarginRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalGrossMarginRate.Text = "123,45";
            this.g_TotalGrossMarginRate.Top = 0.25F;
            this.g_TotalGrossMarginRate.Width = 0.375F;
            // 
            // g_CostMoney
            // 
            this.g_CostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_CostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_CostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CostMoney.DataField = "CostMoney";
            this.g_CostMoney.Height = 0.156F;
            this.g_CostMoney.Left = 5.425F;
            this.g_CostMoney.MultiLine = false;
            this.g_CostMoney.Name = "g_CostMoney";
            this.g_CostMoney.OutputFormat = resources.GetString("g_CostMoney.OutputFormat");
            this.g_CostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CostMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CostMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CostMoney.Text = "123,546,789";
            this.g_CostMoney.Top = 0.0625F;
            this.g_CostMoney.Width = 0.66F;
            // 
            // g_TotalCostMoney
            // 
            this.g_TotalCostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalCostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalCostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalCostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalCostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCostMoney.DataField = "TotalCostMoney";
            this.g_TotalCostMoney.Height = 0.156F;
            this.g_TotalCostMoney.Left = 5.425F;
            this.g_TotalCostMoney.MultiLine = false;
            this.g_TotalCostMoney.Name = "g_TotalCostMoney";
            this.g_TotalCostMoney.OutputFormat = resources.GetString("g_TotalCostMoney.OutputFormat");
            this.g_TotalCostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalCostMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalCostMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalCostMoney.Text = "123,546,789";
            this.g_TotalCostMoney.Top = 0.25F;
            this.g_TotalCostMoney.Width = 0.66F;
            // 
            // g_YearSalesComp
            // 
            this.g_YearSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.g_YearSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.g_YearSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.g_YearSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.g_YearSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearSalesComp.DataField = "YearSalesComp";
            this.g_YearSalesComp.Height = 0.156F;
            this.g_YearSalesComp.Left = 8.76F;
            this.g_YearSalesComp.MultiLine = false;
            this.g_YearSalesComp.Name = "g_YearSalesComp";
            this.g_YearSalesComp.OutputFormat = resources.GetString("g_YearSalesComp.OutputFormat");
            this.g_YearSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_YearSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_YearSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_YearSalesComp.Text = "123,546,789";
            this.g_YearSalesComp.Top = 0.25F;
            this.g_YearSalesComp.Width = 0.66F;
            // 
            // g_SalesMoney
            // 
            this.g_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoney.DataField = "SalesMoney";
            this.g_SalesMoney.Height = 0.156F;
            this.g_SalesMoney.Left = 1.75F;
            this.g_SalesMoney.MultiLine = false;
            this.g_SalesMoney.Name = "g_SalesMoney";
            this.g_SalesMoney.OutputFormat = resources.GetString("g_SalesMoney.OutputFormat");
            this.g_SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_SalesMoney.Text = "123,546,789";
            this.g_SalesMoney.Top = 0.0625F;
            this.g_SalesMoney.Width = 0.66F;
            // 
            // g_TotalSalesMoney
            // 
            this.g_TotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoney.DataField = "TotalSalesMoney";
            this.g_TotalSalesMoney.Height = 0.156F;
            this.g_TotalSalesMoney.Left = 1.75F;
            this.g_TotalSalesMoney.MultiLine = false;
            this.g_TotalSalesMoney.Name = "g_TotalSalesMoney";
            this.g_TotalSalesMoney.OutputFormat = resources.GetString("g_TotalSalesMoney.OutputFormat");
            this.g_TotalSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalSalesMoney.Text = "123,546,789";
            this.g_TotalSalesMoney.Top = 0.25F;
            this.g_TotalSalesMoney.Width = 0.66F;
            // 
            // g_StockMoney
            // 
            this.g_StockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoney.DataField = "StockMoney";
            this.g_StockMoney.Height = 0.156F;
            this.g_StockMoney.Left = 6.1F;
            this.g_StockMoney.MultiLine = false;
            this.g_StockMoney.Name = "g_StockMoney";
            this.g_StockMoney.OutputFormat = resources.GetString("g_StockMoney.OutputFormat");
            this.g_StockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockMoney.Text = "123,546,789";
            this.g_StockMoney.Top = 0.0625F;
            this.g_StockMoney.Width = 0.66F;
            // 
            // g_TotalStockMoney
            // 
            this.g_TotalStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockMoney.DataField = "TotalStockMoney";
            this.g_TotalStockMoney.Height = 0.156F;
            this.g_TotalStockMoney.Left = 6.1F;
            this.g_TotalStockMoney.MultiLine = false;
            this.g_TotalStockMoney.Name = "g_TotalStockMoney";
            this.g_TotalStockMoney.OutputFormat = resources.GetString("g_TotalStockMoney.OutputFormat");
            this.g_TotalStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalStockMoney.Text = "123,546,789";
            this.g_TotalStockMoney.Top = 0.25F;
            this.g_TotalStockMoney.Width = 0.66F;
            // 
            // g_TotalOrderStockMoney
            // 
            this.g_TotalOrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalOrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalOrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalOrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalOrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderStockMoney.DataField = "TotalOrderStockMoney";
            this.g_TotalOrderStockMoney.Height = 0.156F;
            this.g_TotalOrderStockMoney.Left = 6.76F;
            this.g_TotalOrderStockMoney.MultiLine = false;
            this.g_TotalOrderStockMoney.Name = "g_TotalOrderStockMoney";
            this.g_TotalOrderStockMoney.OutputFormat = resources.GetString("g_TotalOrderStockMoney.OutputFormat");
            this.g_TotalOrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalOrderStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalOrderStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalOrderStockMoney.Text = "123,546,789";
            this.g_TotalOrderStockMoney.Top = 0.25F;
            this.g_TotalOrderStockMoney.Width = 0.66F;
            // 
            // g_YearStockComp
            // 
            this.g_YearStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.g_YearStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.g_YearStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.g_YearStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.g_YearStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_YearStockComp.DataField = "YearStockComp";
            this.g_YearStockComp.Height = 0.156F;
            this.g_YearStockComp.Left = 9.42F;
            this.g_YearStockComp.MultiLine = false;
            this.g_YearStockComp.Name = "g_YearStockComp";
            this.g_YearStockComp.OutputFormat = resources.GetString("g_YearStockComp.OutputFormat");
            this.g_YearStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_YearStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_YearStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_YearStockComp.Text = "123,546,789";
            this.g_YearStockComp.Top = 0.25F;
            this.g_YearStockComp.Width = 0.66F;
            // 
            // g_OrderSalesMoney
            // 
            this.g_OrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_OrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_OrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderSalesMoney.DataField = "OrderSalesMoney";
            this.g_OrderSalesMoney.Height = 0.156F;
            this.g_OrderSalesMoney.Left = 2.41F;
            this.g_OrderSalesMoney.MultiLine = false;
            this.g_OrderSalesMoney.Name = "g_OrderSalesMoney";
            this.g_OrderSalesMoney.OutputFormat = resources.GetString("g_OrderSalesMoney.OutputFormat");
            this.g_OrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OrderSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OrderSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OrderSalesMoney.Text = "123,546,789";
            this.g_OrderSalesMoney.Top = 0.0625F;
            this.g_OrderSalesMoney.Width = 0.66F;
            // 
            // g_TotalOrderSalesMoney
            // 
            this.g_TotalOrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalOrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalOrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalOrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalOrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalOrderSalesMoney.DataField = "TotalOrderSalesMoney";
            this.g_TotalOrderSalesMoney.Height = 0.156F;
            this.g_TotalOrderSalesMoney.Left = 2.41F;
            this.g_TotalOrderSalesMoney.MultiLine = false;
            this.g_TotalOrderSalesMoney.Name = "g_TotalOrderSalesMoney";
            this.g_TotalOrderSalesMoney.OutputFormat = resources.GetString("g_TotalOrderSalesMoney.OutputFormat");
            this.g_TotalOrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalOrderSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalOrderSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalOrderSalesMoney.Text = "123,546,789";
            this.g_TotalOrderSalesMoney.Top = 0.25F;
            this.g_TotalOrderSalesMoney.Width = 0.66F;
            // 
            // g_OrderStockMoney
            // 
            this.g_OrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_OrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_OrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OrderStockMoney.DataField = "OrderStockMoney";
            this.g_OrderStockMoney.Height = 0.156F;
            this.g_OrderStockMoney.Left = 6.76F;
            this.g_OrderStockMoney.MultiLine = false;
            this.g_OrderStockMoney.Name = "g_OrderStockMoney";
            this.g_OrderStockMoney.OutputFormat = resources.GetString("g_OrderStockMoney.OutputFormat");
            this.g_OrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OrderStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OrderStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OrderStockMoney.Text = "123,546,789";
            this.g_OrderStockMoney.Top = 0.0625F;
            this.g_OrderStockMoney.Width = 0.66F;
            // 
            // g_StockStockMoney
            // 
            this.g_StockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockStockMoney.DataField = "StockStockMoney";
            this.g_StockStockMoney.Height = 0.156F;
            this.g_StockStockMoney.Left = 7.42F;
            this.g_StockStockMoney.MultiLine = false;
            this.g_StockStockMoney.Name = "g_StockStockMoney";
            this.g_StockStockMoney.OutputFormat = resources.GetString("g_StockStockMoney.OutputFormat");
            this.g_StockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockStockMoney.Text = "123,546,789";
            this.g_StockStockMoney.Top = 0.0625F;
            this.g_StockStockMoney.Width = 0.66F;
            // 
            // g_TotalStockStockMoney
            // 
            this.g_TotalStockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalStockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalStockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalStockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalStockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalStockStockMoney.DataField = "TotalStockStockMoney";
            this.g_TotalStockStockMoney.Height = 0.156F;
            this.g_TotalStockStockMoney.Left = 7.42F;
            this.g_TotalStockStockMoney.MultiLine = false;
            this.g_TotalStockStockMoney.Name = "g_TotalStockStockMoney";
            this.g_TotalStockStockMoney.OutputFormat = resources.GetString("g_TotalStockStockMoney.OutputFormat");
            this.g_TotalStockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalStockStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalStockStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalStockStockMoney.Text = "123,546,789";
            this.g_TotalStockStockMoney.Top = 0.25F;
            this.g_TotalStockStockMoney.Width = 0.66F;
            // 
            // g_TermStockComp
            // 
            this.g_TermStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermStockComp.DataField = "TermStockComp";
            this.g_TermStockComp.Height = 0.156F;
            this.g_TermStockComp.Left = 9.42F;
            this.g_TermStockComp.MultiLine = false;
            this.g_TermStockComp.Name = "g_TermStockComp";
            this.g_TermStockComp.OutputFormat = resources.GetString("g_TermStockComp.OutputFormat");
            this.g_TermStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TermStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermStockComp.Text = "123,546,789";
            this.g_TermStockComp.Top = 0.0625F;
            this.g_TermStockComp.Width = 0.66F;
            // 
            // g_Difference
            // 
            this.g_Difference.Border.BottomColor = System.Drawing.Color.Black;
            this.g_Difference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Difference.Border.LeftColor = System.Drawing.Color.Black;
            this.g_Difference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Difference.Border.RightColor = System.Drawing.Color.Black;
            this.g_Difference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Difference.Border.TopColor = System.Drawing.Color.Black;
            this.g_Difference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_Difference.DataField = "Difference";
            this.g_Difference.Height = 0.156F;
            this.g_Difference.Left = 10.08F;
            this.g_Difference.MultiLine = false;
            this.g_Difference.Name = "g_Difference";
            this.g_Difference.OutputFormat = resources.GetString("g_Difference.OutputFormat");
            this.g_Difference.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_Difference.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_Difference.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_Difference.Text = "123,546,789";
            this.g_Difference.Top = 0.063F;
            this.g_Difference.Width = 0.66F;
            // 
            // g_TotalDifference
            // 
            this.g_TotalDifference.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalDifference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalDifference.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalDifference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalDifference.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalDifference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalDifference.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalDifference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalDifference.DataField = "TotalDifference";
            this.g_TotalDifference.Height = 0.156F;
            this.g_TotalDifference.Left = 10.08F;
            this.g_TotalDifference.MultiLine = false;
            this.g_TotalDifference.Name = "g_TotalDifference";
            this.g_TotalDifference.OutputFormat = resources.GetString("g_TotalDifference.OutputFormat");
            this.g_TotalDifference.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalDifference.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalDifference.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalDifference.Text = "123,546,789";
            this.g_TotalDifference.Top = 0.25F;
            this.g_TotalDifference.Width = 0.66F;
            // 
            // g_MoveShipmentPrice
            // 
            this.g_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.g_MoveShipmentPrice.Height = 0.156F;
            this.g_MoveShipmentPrice.Left = 4.765F;
            this.g_MoveShipmentPrice.MultiLine = false;
            this.g_MoveShipmentPrice.Name = "g_MoveShipmentPrice";
            this.g_MoveShipmentPrice.OutputFormat = resources.GetString("g_MoveShipmentPrice.OutputFormat");
            this.g_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoveShipmentPrice.Text = "123,546,789";
            this.g_MoveShipmentPrice.Top = 0.0625F;
            this.g_MoveShipmentPrice.Width = 0.66F;
            // 
            // g_TotalMoveShipmentPrice
            // 
            this.g_TotalMoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalMoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalMoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalMoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalMoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveShipmentPrice.DataField = "TotalMoveShipmentPrice";
            this.g_TotalMoveShipmentPrice.Height = 0.156F;
            this.g_TotalMoveShipmentPrice.Left = 4.765F;
            this.g_TotalMoveShipmentPrice.MultiLine = false;
            this.g_TotalMoveShipmentPrice.Name = "g_TotalMoveShipmentPrice";
            this.g_TotalMoveShipmentPrice.OutputFormat = resources.GetString("g_TotalMoveShipmentPrice.OutputFormat");
            this.g_TotalMoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalMoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalMoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalMoveShipmentPrice.Text = "123,546,789";
            this.g_TotalMoveShipmentPrice.Top = 0.25F;
            this.g_TotalMoveShipmentPrice.Width = 0.66F;
            // 
            // g_MoveArrivalPric
            // 
            this.g_MoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveArrivalPric.DataField = "MoveArrivalPric";
            this.g_MoveArrivalPric.Height = 0.156F;
            this.g_MoveArrivalPric.Left = 8.08F;
            this.g_MoveArrivalPric.MultiLine = false;
            this.g_MoveArrivalPric.Name = "g_MoveArrivalPric";
            this.g_MoveArrivalPric.OutputFormat = resources.GetString("g_MoveArrivalPric.OutputFormat");
            this.g_MoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MoveArrivalPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoveArrivalPric.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoveArrivalPric.Text = "123,546,789";
            this.g_MoveArrivalPric.Top = 0.0625F;
            this.g_MoveArrivalPric.Width = 0.66F;
            // 
            // g_TotalMoveArrivalPric
            // 
            this.g_TotalMoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalMoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalMoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalMoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalMoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalMoveArrivalPric.DataField = "TotalMoveArrivalPric";
            this.g_TotalMoveArrivalPric.Height = 0.156F;
            this.g_TotalMoveArrivalPric.Left = 8.08F;
            this.g_TotalMoveArrivalPric.MultiLine = false;
            this.g_TotalMoveArrivalPric.Name = "g_TotalMoveArrivalPric";
            this.g_TotalMoveArrivalPric.OutputFormat = resources.GetString("g_TotalMoveArrivalPric.OutputFormat");
            this.g_TotalMoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalMoveArrivalPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalMoveArrivalPric.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalMoveArrivalPric.Text = "123,546,789";
            this.g_TotalMoveArrivalPric.Top = 0.25F;
            this.g_TotalMoveArrivalPric.Width = 0.66F;
            // 
            // g_SalesMoneyOrg
            // 
            this.g_SalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrg.DataField = "SalesMoneyOrg";
            this.g_SalesMoneyOrg.Height = 0.156F;
            this.g_SalesMoneyOrg.Left = 1.75F;
            this.g_SalesMoneyOrg.MultiLine = false;
            this.g_SalesMoneyOrg.Name = "g_SalesMoneyOrg";
            this.g_SalesMoneyOrg.OutputFormat = resources.GetString("g_SalesMoneyOrg.OutputFormat");
            this.g_SalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_SalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_SalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_SalesMoneyOrg.Text = "123,546,789";
            this.g_SalesMoneyOrg.Top = 0.4375F;
            this.g_SalesMoneyOrg.Visible = false;
            this.g_SalesMoneyOrg.Width = 0.66F;
            // 
            // g_TotalSalesMoneyOrg
            // 
            this.g_TotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.g_TotalSalesMoneyOrg.Height = 0.156F;
            this.g_TotalSalesMoneyOrg.Left = 1.75F;
            this.g_TotalSalesMoneyOrg.MultiLine = false;
            this.g_TotalSalesMoneyOrg.Name = "g_TotalSalesMoneyOrg";
            this.g_TotalSalesMoneyOrg.OutputFormat = resources.GetString("g_TotalSalesMoneyOrg.OutputFormat");
            this.g_TotalSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalSalesMoneyOrg.Text = "123,546,789";
            this.g_TotalSalesMoneyOrg.Top = 0.625F;
            this.g_TotalSalesMoneyOrg.Visible = false;
            this.g_TotalSalesMoneyOrg.Width = 0.66F;
            // 
            // g_GrossMoneyOrg
            // 
            this.g_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.g_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.g_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.g_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.g_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.g_GrossMoneyOrg.Height = 0.156F;
            this.g_GrossMoneyOrg.Left = 3.75F;
            this.g_GrossMoneyOrg.MultiLine = false;
            this.g_GrossMoneyOrg.Name = "g_GrossMoneyOrg";
            this.g_GrossMoneyOrg.OutputFormat = resources.GetString("g_GrossMoneyOrg.OutputFormat");
            this.g_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_GrossMoneyOrg.Text = "123,546,789";
            this.g_GrossMoneyOrg.Top = 0.4375F;
            this.g_GrossMoneyOrg.Visible = false;
            this.g_GrossMoneyOrg.Width = 0.66F;
            // 
            // g_TotalGrossMoneyOrg
            // 
            this.g_TotalGrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalGrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalGrossMoneyOrg.DataField = "TotalGrossMoneyOrg";
            this.g_TotalGrossMoneyOrg.Height = 0.156F;
            this.g_TotalGrossMoneyOrg.Left = 3.75F;
            this.g_TotalGrossMoneyOrg.MultiLine = false;
            this.g_TotalGrossMoneyOrg.Name = "g_TotalGrossMoneyOrg";
            this.g_TotalGrossMoneyOrg.OutputFormat = resources.GetString("g_TotalGrossMoneyOrg.OutputFormat");
            this.g_TotalGrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalGrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalGrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalGrossMoneyOrg.Text = "123,546,789";
            this.g_TotalGrossMoneyOrg.Top = 0.625F;
            this.g_TotalGrossMoneyOrg.Visible = false;
            this.g_TotalGrossMoneyOrg.Width = 0.66F;
            // 
            // line19
            // 
            this.line19.Border.BottomColor = System.Drawing.Color.Black;
            this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.LeftColor = System.Drawing.Color.Black;
            this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.RightColor = System.Drawing.Color.Black;
            this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.TopColor = System.Drawing.Color.Black;
            this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Height = 0.12F;
            this.line19.Left = 6.09F;
            this.line19.LineWeight = 2F;
            this.line19.Name = "line19";
            this.line19.Top = 0.25F;
            this.line19.Width = 0F;
            this.line19.X1 = 6.09F;
            this.line19.X2 = 6.09F;
            this.line19.Y1 = 0.25F;
            this.line19.Y2 = 0.37F;
            // 
            // line20
            // 
            this.line20.Border.BottomColor = System.Drawing.Color.Black;
            this.line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.LeftColor = System.Drawing.Color.Black;
            this.line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.RightColor = System.Drawing.Color.Black;
            this.line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.TopColor = System.Drawing.Color.Black;
            this.line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Height = 0.1175F;
            this.line20.Left = 6.09F;
            this.line20.LineWeight = 2F;
            this.line20.Name = "line20";
            this.line20.Top = 0.0625F;
            this.line20.Width = 0F;
            this.line20.X1 = 6.09F;
            this.line20.X2 = 6.09F;
            this.line20.Y1 = 0.0625F;
            this.line20.Y2 = 0.18F;
            // 
            // line21
            // 
            this.line21.Border.BottomColor = System.Drawing.Color.Black;
            this.line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.LeftColor = System.Drawing.Color.Black;
            this.line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.RightColor = System.Drawing.Color.Black;
            this.line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.TopColor = System.Drawing.Color.Black;
            this.line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Height = 0.12F;
            this.line21.Left = 8.75F;
            this.line21.LineWeight = 2F;
            this.line21.Name = "line21";
            this.line21.Top = 0.25F;
            this.line21.Width = 0F;
            this.line21.X1 = 8.75F;
            this.line21.X2 = 8.75F;
            this.line21.Y1 = 0.25F;
            this.line21.Y2 = 0.37F;
            // 
            // line22
            // 
            this.line22.Border.BottomColor = System.Drawing.Color.Black;
            this.line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.LeftColor = System.Drawing.Color.Black;
            this.line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.RightColor = System.Drawing.Color.Black;
            this.line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.TopColor = System.Drawing.Color.Black;
            this.line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Height = 0.1175F;
            this.line22.Left = 8.75F;
            this.line22.LineWeight = 2F;
            this.line22.Name = "line22";
            this.line22.Top = 0.0625F;
            this.line22.Width = 0F;
            this.line22.X1 = 8.75F;
            this.line22.X2 = 8.75F;
            this.line22.Y1 = 0.0625F;
            this.line22.Y2 = 0.18F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.upline_SectionHeader,
            this.SectionHeaderLine,
            this.SectionHeaderLineName});
            this.SectionHeader.DataField = "SectionHeaderField";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.1979167F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
            // 
            // upline_SectionHeader
            // 
            this.upline_SectionHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Border.RightColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Border.TopColor = System.Drawing.Color.Black;
            this.upline_SectionHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_SectionHeader.Height = 0F;
            this.upline_SectionHeader.Left = 0F;
            this.upline_SectionHeader.LineWeight = 2F;
            this.upline_SectionHeader.Name = "upline_SectionHeader";
            this.upline_SectionHeader.Top = 0F;
            this.upline_SectionHeader.Width = 10.8F;
            this.upline_SectionHeader.X1 = 0F;
            this.upline_SectionHeader.X2 = 10.8F;
            this.upline_SectionHeader.Y1 = 0F;
            this.upline_SectionHeader.Y2 = 0F;
            // 
            // SectionHeaderLine
            // 
            this.SectionHeaderLine.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.Border.RightColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.Border.TopColor = System.Drawing.Color.Black;
            this.SectionHeaderLine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLine.DataField = "SectionHeaderLine";
            this.SectionHeaderLine.Height = 0.16F;
            this.SectionHeaderLine.Left = 0F;
            this.SectionHeaderLine.MultiLine = false;
            this.SectionHeaderLine.Name = "SectionHeaderLine";
            this.SectionHeaderLine.OutputFormat = resources.GetString("SectionHeaderLine.OutputFormat");
            this.SectionHeaderLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SectionHeaderLine.Text = "123456";
            this.SectionHeaderLine.Top = 0.01041667F;
            this.SectionHeaderLine.Width = 0.4F;
            // 
            // SectionHeaderLineName
            // 
            this.SectionHeaderLineName.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionHeaderLineName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineName.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionHeaderLineName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineName.Border.RightColor = System.Drawing.Color.Black;
            this.SectionHeaderLineName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineName.Border.TopColor = System.Drawing.Color.Black;
            this.SectionHeaderLineName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineName.DataField = "SectionHeaderLineName";
            this.SectionHeaderLineName.Height = 0.16F;
            this.SectionHeaderLineName.Left = 0.4F;
            this.SectionHeaderLineName.MultiLine = false;
            this.SectionHeaderLineName.Name = "SectionHeaderLineName";
            this.SectionHeaderLineName.OutputFormat = resources.GetString("SectionHeaderLineName.OutputFormat");
            this.SectionHeaderLineName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SectionHeaderLineName.Text = "123456789";
            this.SectionHeaderLineName.Top = 0.01041667F;
            this.SectionHeaderLineName.Width = 3F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SectionTitle,
            this.s_TermSalesComp,
            this.s_StockSalesMoney,
            this.s_GrossMoney,
            this.s_TotalStockSalesMoney,
            this.s_TotalGrossMoney,
            this.s_GrossMarginRate,
            this.s_TotalGrossMarginRate,
            this.s_CostMoney,
            this.s_TotalCostMoney,
            this.s_YearSalesComp,
            this.s_TotalOrderSalesMoney,
            this.s_StockMoney,
            this.s_TotalStockMoney,
            this.s_TotalOrderStockMoney,
            this.s_SalesMoney,
            this.s_OrderSalesMoney,
            this.s_TotalSalesMoney,
            this.s_OrderStockMoney,
            this.s_StockStockMoney,
            this.s_TotalStockStockMoney,
            this.s_TermStockComp,
            this.s_YearStockComp,
            this.s_Difference,
            this.s_TotalDifference,
            this.s_MoveShipmentPrice,
            this.s_TotalMoveShipmentPrice,
            this.s_MoveArrivalPric,
            this.s_TotalMoveArrivalPric,
            this.s_SalesMoneyOrg,
            this.s_TotalSalesMoneyOrg,
            this.s_GrossMoneyOrg,
            this.s_TotalGrossMoneyOrg,
            this.line17,
            this.line18,
            this.line23,
            this.line24});
            this.SectionFooter.Height = 0.8541667F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
            // 
            // Line45
            // 
            this.Line45.Border.BottomColor = System.Drawing.Color.Black;
            this.Line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.LeftColor = System.Drawing.Color.Black;
            this.Line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.RightColor = System.Drawing.Color.Black;
            this.Line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.TopColor = System.Drawing.Color.Black;
            this.Line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Height = 0F;
            this.Line45.Left = 0F;
            this.Line45.LineWeight = 2F;
            this.Line45.Name = "Line45";
            this.Line45.Top = 0F;
            this.Line45.Width = 10.8F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // SectionTitle
            // 
            this.SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionTitle.Height = 0.25F;
            this.SectionTitle.Left = 1.225F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0.0625F;
            this.SectionTitle.Width = 0.5F;
            // 
            // s_TermSalesComp
            // 
            this.s_TermSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesComp.DataField = "TermSalesComp";
            this.s_TermSalesComp.Height = 0.156F;
            this.s_TermSalesComp.Left = 8.76F;
            this.s_TermSalesComp.MultiLine = false;
            this.s_TermSalesComp.Name = "s_TermSalesComp";
            this.s_TermSalesComp.OutputFormat = resources.GetString("s_TermSalesComp.OutputFormat");
            this.s_TermSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TermSalesComp.SummaryGroup = "SectionHeader";
            this.s_TermSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermSalesComp.Text = "123,546,789";
            this.s_TermSalesComp.Top = 0.0625F;
            this.s_TermSalesComp.Width = 0.66F;
            // 
            // s_StockSalesMoney
            // 
            this.s_StockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockSalesMoney.DataField = "StockSalesMoney";
            this.s_StockSalesMoney.Height = 0.156F;
            this.s_StockSalesMoney.Left = 3.07F;
            this.s_StockSalesMoney.MultiLine = false;
            this.s_StockSalesMoney.Name = "s_StockSalesMoney";
            this.s_StockSalesMoney.OutputFormat = resources.GetString("s_StockSalesMoney.OutputFormat");
            this.s_StockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockSalesMoney.SummaryGroup = "SectionHeader";
            this.s_StockSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockSalesMoney.Text = "123,546,789";
            this.s_StockSalesMoney.Top = 0.0625F;
            this.s_StockSalesMoney.Width = 0.66F;
            // 
            // s_GrossMoney
            // 
            this.s_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoney.DataField = "GrossMoney";
            this.s_GrossMoney.Height = 0.156F;
            this.s_GrossMoney.Left = 3.73F;
            this.s_GrossMoney.MultiLine = false;
            this.s_GrossMoney.Name = "s_GrossMoney";
            this.s_GrossMoney.OutputFormat = resources.GetString("s_GrossMoney.OutputFormat");
            this.s_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_GrossMoney.SummaryGroup = "SectionHeader";
            this.s_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_GrossMoney.Text = "123,546,789";
            this.s_GrossMoney.Top = 0.0625F;
            this.s_GrossMoney.Width = 0.66F;
            // 
            // s_TotalStockSalesMoney
            // 
            this.s_TotalStockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalStockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalStockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalStockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalStockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockSalesMoney.DataField = "TotalStockSalesMoney";
            this.s_TotalStockSalesMoney.Height = 0.156F;
            this.s_TotalStockSalesMoney.Left = 3.07F;
            this.s_TotalStockSalesMoney.MultiLine = false;
            this.s_TotalStockSalesMoney.Name = "s_TotalStockSalesMoney";
            this.s_TotalStockSalesMoney.OutputFormat = resources.GetString("s_TotalStockSalesMoney.OutputFormat");
            this.s_TotalStockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalStockSalesMoney.SummaryGroup = "SectionHeader";
            this.s_TotalStockSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalStockSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalStockSalesMoney.Text = "123,546,789";
            this.s_TotalStockSalesMoney.Top = 0.25F;
            this.s_TotalStockSalesMoney.Width = 0.66F;
            // 
            // s_TotalGrossMoney
            // 
            this.s_TotalGrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoney.DataField = "TotalGrossMoney";
            this.s_TotalGrossMoney.Height = 0.156F;
            this.s_TotalGrossMoney.Left = 3.73F;
            this.s_TotalGrossMoney.MultiLine = false;
            this.s_TotalGrossMoney.Name = "s_TotalGrossMoney";
            this.s_TotalGrossMoney.OutputFormat = resources.GetString("s_TotalGrossMoney.OutputFormat");
            this.s_TotalGrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalGrossMoney.SummaryGroup = "SectionHeader";
            this.s_TotalGrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalGrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalGrossMoney.Text = "123,546,789";
            this.s_TotalGrossMoney.Top = 0.25F;
            this.s_TotalGrossMoney.Width = 0.66F;
            // 
            // s_GrossMarginRate
            // 
            this.s_GrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_GrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_GrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_GrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_GrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMarginRate.Height = 0.16F;
            this.s_GrossMarginRate.Left = 4.39F;
            this.s_GrossMarginRate.MultiLine = false;
            this.s_GrossMarginRate.Name = "s_GrossMarginRate";
            this.s_GrossMarginRate.OutputFormat = resources.GetString("s_GrossMarginRate.OutputFormat");
            this.s_GrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_GrossMarginRate.SummaryGroup = "SectionHeader";
            this.s_GrossMarginRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_GrossMarginRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_GrossMarginRate.Text = "123,45";
            this.s_GrossMarginRate.Top = 0.06F;
            this.s_GrossMarginRate.Width = 0.375F;
            // 
            // s_TotalGrossMarginRate
            // 
            this.s_TotalGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMarginRate.Height = 0.16F;
            this.s_TotalGrossMarginRate.Left = 4.39F;
            this.s_TotalGrossMarginRate.MultiLine = false;
            this.s_TotalGrossMarginRate.Name = "s_TotalGrossMarginRate";
            this.s_TotalGrossMarginRate.OutputFormat = resources.GetString("s_TotalGrossMarginRate.OutputFormat");
            this.s_TotalGrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalGrossMarginRate.SummaryGroup = "SectionHeader";
            this.s_TotalGrossMarginRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalGrossMarginRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalGrossMarginRate.Text = "123,45";
            this.s_TotalGrossMarginRate.Top = 0.25F;
            this.s_TotalGrossMarginRate.Width = 0.375F;
            // 
            // s_CostMoney
            // 
            this.s_CostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_CostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_CostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CostMoney.DataField = "CostMoney";
            this.s_CostMoney.Height = 0.156F;
            this.s_CostMoney.Left = 5.425F;
            this.s_CostMoney.MultiLine = false;
            this.s_CostMoney.Name = "s_CostMoney";
            this.s_CostMoney.OutputFormat = resources.GetString("s_CostMoney.OutputFormat");
            this.s_CostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CostMoney.SummaryGroup = "SectionHeader";
            this.s_CostMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CostMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CostMoney.Text = "123,546,789";
            this.s_CostMoney.Top = 0.0625F;
            this.s_CostMoney.Width = 0.66F;
            // 
            // s_TotalCostMoney
            // 
            this.s_TotalCostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalCostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalCostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalCostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalCostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCostMoney.DataField = "TotalCostMoney";
            this.s_TotalCostMoney.Height = 0.156F;
            this.s_TotalCostMoney.Left = 5.425F;
            this.s_TotalCostMoney.MultiLine = false;
            this.s_TotalCostMoney.Name = "s_TotalCostMoney";
            this.s_TotalCostMoney.OutputFormat = resources.GetString("s_TotalCostMoney.OutputFormat");
            this.s_TotalCostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalCostMoney.SummaryGroup = "SectionHeader";
            this.s_TotalCostMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalCostMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalCostMoney.Text = "123,546,789";
            this.s_TotalCostMoney.Top = 0.25F;
            this.s_TotalCostMoney.Width = 0.66F;
            // 
            // s_YearSalesComp
            // 
            this.s_YearSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.s_YearSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.s_YearSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.s_YearSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.s_YearSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearSalesComp.DataField = "YearSalesComp";
            this.s_YearSalesComp.Height = 0.156F;
            this.s_YearSalesComp.Left = 8.76F;
            this.s_YearSalesComp.MultiLine = false;
            this.s_YearSalesComp.Name = "s_YearSalesComp";
            this.s_YearSalesComp.OutputFormat = resources.GetString("s_YearSalesComp.OutputFormat");
            this.s_YearSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_YearSalesComp.SummaryGroup = "SectionHeader";
            this.s_YearSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_YearSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_YearSalesComp.Text = "123,546,789";
            this.s_YearSalesComp.Top = 0.25F;
            this.s_YearSalesComp.Width = 0.66F;
            // 
            // s_TotalOrderSalesMoney
            // 
            this.s_TotalOrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalOrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalOrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalOrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalOrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderSalesMoney.DataField = "TotalOrderSalesMoney";
            this.s_TotalOrderSalesMoney.Height = 0.156F;
            this.s_TotalOrderSalesMoney.Left = 2.41F;
            this.s_TotalOrderSalesMoney.MultiLine = false;
            this.s_TotalOrderSalesMoney.Name = "s_TotalOrderSalesMoney";
            this.s_TotalOrderSalesMoney.OutputFormat = resources.GetString("s_TotalOrderSalesMoney.OutputFormat");
            this.s_TotalOrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalOrderSalesMoney.SummaryGroup = "SectionHeader";
            this.s_TotalOrderSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalOrderSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalOrderSalesMoney.Text = "123,546,789";
            this.s_TotalOrderSalesMoney.Top = 0.25F;
            this.s_TotalOrderSalesMoney.Width = 0.66F;
            // 
            // s_StockMoney
            // 
            this.s_StockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoney.DataField = "StockMoney";
            this.s_StockMoney.Height = 0.156F;
            this.s_StockMoney.Left = 6.1F;
            this.s_StockMoney.MultiLine = false;
            this.s_StockMoney.Name = "s_StockMoney";
            this.s_StockMoney.OutputFormat = resources.GetString("s_StockMoney.OutputFormat");
            this.s_StockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockMoney.SummaryGroup = "SectionHeader";
            this.s_StockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockMoney.Text = "123,546,789";
            this.s_StockMoney.Top = 0.0625F;
            this.s_StockMoney.Width = 0.66F;
            // 
            // s_TotalStockMoney
            // 
            this.s_TotalStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockMoney.DataField = "TotalStockMoney";
            this.s_TotalStockMoney.Height = 0.156F;
            this.s_TotalStockMoney.Left = 6.1F;
            this.s_TotalStockMoney.MultiLine = false;
            this.s_TotalStockMoney.Name = "s_TotalStockMoney";
            this.s_TotalStockMoney.OutputFormat = resources.GetString("s_TotalStockMoney.OutputFormat");
            this.s_TotalStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalStockMoney.SummaryGroup = "SectionHeader";
            this.s_TotalStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalStockMoney.Text = "123,546,789";
            this.s_TotalStockMoney.Top = 0.25F;
            this.s_TotalStockMoney.Width = 0.66F;
            // 
            // s_TotalOrderStockMoney
            // 
            this.s_TotalOrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalOrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalOrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalOrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalOrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalOrderStockMoney.DataField = "TotalOrderStockMoney";
            this.s_TotalOrderStockMoney.Height = 0.156F;
            this.s_TotalOrderStockMoney.Left = 6.76F;
            this.s_TotalOrderStockMoney.MultiLine = false;
            this.s_TotalOrderStockMoney.Name = "s_TotalOrderStockMoney";
            this.s_TotalOrderStockMoney.OutputFormat = resources.GetString("s_TotalOrderStockMoney.OutputFormat");
            this.s_TotalOrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalOrderStockMoney.SummaryGroup = "SectionHeader";
            this.s_TotalOrderStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalOrderStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalOrderStockMoney.Text = "123,546,789";
            this.s_TotalOrderStockMoney.Top = 0.25F;
            this.s_TotalOrderStockMoney.Width = 0.66F;
            // 
            // s_SalesMoney
            // 
            this.s_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoney.DataField = "SalesMoney";
            this.s_SalesMoney.Height = 0.156F;
            this.s_SalesMoney.Left = 1.75F;
            this.s_SalesMoney.MultiLine = false;
            this.s_SalesMoney.Name = "s_SalesMoney";
            this.s_SalesMoney.OutputFormat = resources.GetString("s_SalesMoney.OutputFormat");
            this.s_SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_SalesMoney.SummaryGroup = "SectionHeader";
            this.s_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_SalesMoney.Text = "123,546,789";
            this.s_SalesMoney.Top = 0.0625F;
            this.s_SalesMoney.Width = 0.66F;
            // 
            // s_OrderSalesMoney
            // 
            this.s_OrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_OrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_OrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderSalesMoney.DataField = "OrderSalesMoney";
            this.s_OrderSalesMoney.Height = 0.156F;
            this.s_OrderSalesMoney.Left = 2.41F;
            this.s_OrderSalesMoney.MultiLine = false;
            this.s_OrderSalesMoney.Name = "s_OrderSalesMoney";
            this.s_OrderSalesMoney.OutputFormat = resources.GetString("s_OrderSalesMoney.OutputFormat");
            this.s_OrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OrderSalesMoney.SummaryGroup = "SectionHeader";
            this.s_OrderSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OrderSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OrderSalesMoney.Text = "123,546,789";
            this.s_OrderSalesMoney.Top = 0.0625F;
            this.s_OrderSalesMoney.Width = 0.66F;
            // 
            // s_TotalSalesMoney
            // 
            this.s_TotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoney.DataField = "TotalSalesMoney";
            this.s_TotalSalesMoney.Height = 0.156F;
            this.s_TotalSalesMoney.Left = 1.75F;
            this.s_TotalSalesMoney.MultiLine = false;
            this.s_TotalSalesMoney.Name = "s_TotalSalesMoney";
            this.s_TotalSalesMoney.OutputFormat = resources.GetString("s_TotalSalesMoney.OutputFormat");
            this.s_TotalSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalSalesMoney.SummaryGroup = "SectionHeader";
            this.s_TotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalSalesMoney.Text = "123,546,789";
            this.s_TotalSalesMoney.Top = 0.25F;
            this.s_TotalSalesMoney.Width = 0.66F;
            // 
            // s_OrderStockMoney
            // 
            this.s_OrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_OrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_OrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OrderStockMoney.DataField = "OrderStockMoney";
            this.s_OrderStockMoney.Height = 0.156F;
            this.s_OrderStockMoney.Left = 6.76F;
            this.s_OrderStockMoney.MultiLine = false;
            this.s_OrderStockMoney.Name = "s_OrderStockMoney";
            this.s_OrderStockMoney.OutputFormat = resources.GetString("s_OrderStockMoney.OutputFormat");
            this.s_OrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OrderStockMoney.SummaryGroup = "SectionHeader";
            this.s_OrderStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OrderStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OrderStockMoney.Text = "123,546,789";
            this.s_OrderStockMoney.Top = 0.0625F;
            this.s_OrderStockMoney.Width = 0.66F;
            // 
            // s_StockStockMoney
            // 
            this.s_StockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockStockMoney.DataField = "StockStockMoney";
            this.s_StockStockMoney.Height = 0.156F;
            this.s_StockStockMoney.Left = 7.42F;
            this.s_StockStockMoney.MultiLine = false;
            this.s_StockStockMoney.Name = "s_StockStockMoney";
            this.s_StockStockMoney.OutputFormat = resources.GetString("s_StockStockMoney.OutputFormat");
            this.s_StockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockStockMoney.SummaryGroup = "SectionHeader";
            this.s_StockStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockStockMoney.Text = "123,546,789";
            this.s_StockStockMoney.Top = 0.0625F;
            this.s_StockStockMoney.Width = 0.66F;
            // 
            // s_TotalStockStockMoney
            // 
            this.s_TotalStockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalStockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalStockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalStockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalStockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalStockStockMoney.DataField = "TotalStockStockMoney";
            this.s_TotalStockStockMoney.Height = 0.156F;
            this.s_TotalStockStockMoney.Left = 7.42F;
            this.s_TotalStockStockMoney.MultiLine = false;
            this.s_TotalStockStockMoney.Name = "s_TotalStockStockMoney";
            this.s_TotalStockStockMoney.OutputFormat = resources.GetString("s_TotalStockStockMoney.OutputFormat");
            this.s_TotalStockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalStockStockMoney.SummaryGroup = "SectionHeader";
            this.s_TotalStockStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalStockStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalStockStockMoney.Text = "123,546,789";
            this.s_TotalStockStockMoney.Top = 0.25F;
            this.s_TotalStockStockMoney.Width = 0.66F;
            // 
            // s_TermStockComp
            // 
            this.s_TermStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermStockComp.DataField = "TermStockComp";
            this.s_TermStockComp.Height = 0.156F;
            this.s_TermStockComp.Left = 9.42F;
            this.s_TermStockComp.MultiLine = false;
            this.s_TermStockComp.Name = "s_TermStockComp";
            this.s_TermStockComp.OutputFormat = resources.GetString("s_TermStockComp.OutputFormat");
            this.s_TermStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TermStockComp.SummaryGroup = "SectionHeader";
            this.s_TermStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermStockComp.Text = "123,546,789";
            this.s_TermStockComp.Top = 0.063F;
            this.s_TermStockComp.Width = 0.66F;
            // 
            // s_YearStockComp
            // 
            this.s_YearStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.s_YearStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.s_YearStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.s_YearStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.s_YearStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_YearStockComp.DataField = "YearStockComp";
            this.s_YearStockComp.Height = 0.156F;
            this.s_YearStockComp.Left = 9.42F;
            this.s_YearStockComp.MultiLine = false;
            this.s_YearStockComp.Name = "s_YearStockComp";
            this.s_YearStockComp.OutputFormat = resources.GetString("s_YearStockComp.OutputFormat");
            this.s_YearStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_YearStockComp.SummaryGroup = "SectionHeader";
            this.s_YearStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_YearStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_YearStockComp.Text = "123,546,789";
            this.s_YearStockComp.Top = 0.25F;
            this.s_YearStockComp.Width = 0.66F;
            // 
            // s_Difference
            // 
            this.s_Difference.Border.BottomColor = System.Drawing.Color.Black;
            this.s_Difference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_Difference.Border.LeftColor = System.Drawing.Color.Black;
            this.s_Difference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_Difference.Border.RightColor = System.Drawing.Color.Black;
            this.s_Difference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_Difference.Border.TopColor = System.Drawing.Color.Black;
            this.s_Difference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_Difference.DataField = "Difference";
            this.s_Difference.Height = 0.156F;
            this.s_Difference.Left = 10.08F;
            this.s_Difference.MultiLine = false;
            this.s_Difference.Name = "s_Difference";
            this.s_Difference.OutputFormat = resources.GetString("s_Difference.OutputFormat");
            this.s_Difference.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_Difference.SummaryGroup = "SectionHeader";
            this.s_Difference.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_Difference.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_Difference.Text = "123,546,789";
            this.s_Difference.Top = 0.063F;
            this.s_Difference.Width = 0.66F;
            // 
            // s_TotalDifference
            // 
            this.s_TotalDifference.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalDifference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalDifference.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalDifference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalDifference.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalDifference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalDifference.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalDifference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalDifference.DataField = "TotalDifference";
            this.s_TotalDifference.Height = 0.156F;
            this.s_TotalDifference.Left = 10.08F;
            this.s_TotalDifference.MultiLine = false;
            this.s_TotalDifference.Name = "s_TotalDifference";
            this.s_TotalDifference.OutputFormat = resources.GetString("s_TotalDifference.OutputFormat");
            this.s_TotalDifference.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalDifference.SummaryGroup = "SectionHeader";
            this.s_TotalDifference.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalDifference.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalDifference.Text = "123,546,789";
            this.s_TotalDifference.Top = 0.25F;
            this.s_TotalDifference.Width = 0.66F;
            // 
            // s_MoveShipmentPrice
            // 
            this.s_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.s_MoveShipmentPrice.Height = 0.156F;
            this.s_MoveShipmentPrice.Left = 4.765F;
            this.s_MoveShipmentPrice.MultiLine = false;
            this.s_MoveShipmentPrice.Name = "s_MoveShipmentPrice";
            this.s_MoveShipmentPrice.OutputFormat = resources.GetString("s_MoveShipmentPrice.OutputFormat");
            this.s_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MoveShipmentPrice.SummaryGroup = "SectionHeader";
            this.s_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoveShipmentPrice.Text = "123,546,789";
            this.s_MoveShipmentPrice.Top = 0.0625F;
            this.s_MoveShipmentPrice.Width = 0.66F;
            // 
            // s_TotalMoveShipmentPrice
            // 
            this.s_TotalMoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalMoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalMoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalMoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalMoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveShipmentPrice.DataField = "TotalMoveShipmentPrice";
            this.s_TotalMoveShipmentPrice.Height = 0.156F;
            this.s_TotalMoveShipmentPrice.Left = 4.765F;
            this.s_TotalMoveShipmentPrice.MultiLine = false;
            this.s_TotalMoveShipmentPrice.Name = "s_TotalMoveShipmentPrice";
            this.s_TotalMoveShipmentPrice.OutputFormat = resources.GetString("s_TotalMoveShipmentPrice.OutputFormat");
            this.s_TotalMoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalMoveShipmentPrice.SummaryGroup = "SectionHeader";
            this.s_TotalMoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalMoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalMoveShipmentPrice.Text = "123,546,789";
            this.s_TotalMoveShipmentPrice.Top = 0.25F;
            this.s_TotalMoveShipmentPrice.Width = 0.66F;
            // 
            // s_MoveArrivalPric
            // 
            this.s_MoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveArrivalPric.DataField = "MoveArrivalPric";
            this.s_MoveArrivalPric.Height = 0.156F;
            this.s_MoveArrivalPric.Left = 8.08F;
            this.s_MoveArrivalPric.MultiLine = false;
            this.s_MoveArrivalPric.Name = "s_MoveArrivalPric";
            this.s_MoveArrivalPric.OutputFormat = resources.GetString("s_MoveArrivalPric.OutputFormat");
            this.s_MoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MoveArrivalPric.SummaryGroup = "SectionHeader";
            this.s_MoveArrivalPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoveArrivalPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoveArrivalPric.Text = "123,546,789";
            this.s_MoveArrivalPric.Top = 0.0625F;
            this.s_MoveArrivalPric.Width = 0.66F;
            // 
            // s_TotalMoveArrivalPric
            // 
            this.s_TotalMoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalMoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalMoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalMoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalMoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalMoveArrivalPric.DataField = "TotalMoveArrivalPric";
            this.s_TotalMoveArrivalPric.Height = 0.156F;
            this.s_TotalMoveArrivalPric.Left = 8.08F;
            this.s_TotalMoveArrivalPric.MultiLine = false;
            this.s_TotalMoveArrivalPric.Name = "s_TotalMoveArrivalPric";
            this.s_TotalMoveArrivalPric.OutputFormat = resources.GetString("s_TotalMoveArrivalPric.OutputFormat");
            this.s_TotalMoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalMoveArrivalPric.SummaryGroup = "SectionHeader";
            this.s_TotalMoveArrivalPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalMoveArrivalPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalMoveArrivalPric.Text = "123,546,789";
            this.s_TotalMoveArrivalPric.Top = 0.25F;
            this.s_TotalMoveArrivalPric.Width = 0.66F;
            // 
            // s_SalesMoneyOrg
            // 
            this.s_SalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrg.DataField = "SalesMoneyOrg";
            this.s_SalesMoneyOrg.Height = 0.156F;
            this.s_SalesMoneyOrg.Left = 1.75F;
            this.s_SalesMoneyOrg.MultiLine = false;
            this.s_SalesMoneyOrg.Name = "s_SalesMoneyOrg";
            this.s_SalesMoneyOrg.OutputFormat = resources.GetString("s_SalesMoneyOrg.OutputFormat");
            this.s_SalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_SalesMoneyOrg.SummaryGroup = "SectionHeader";
            this.s_SalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_SalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_SalesMoneyOrg.Text = "123,546,789";
            this.s_SalesMoneyOrg.Top = 0.4375F;
            this.s_SalesMoneyOrg.Visible = false;
            this.s_SalesMoneyOrg.Width = 0.66F;
            // 
            // s_TotalSalesMoneyOrg
            // 
            this.s_TotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.s_TotalSalesMoneyOrg.Height = 0.156F;
            this.s_TotalSalesMoneyOrg.Left = 1.75F;
            this.s_TotalSalesMoneyOrg.MultiLine = false;
            this.s_TotalSalesMoneyOrg.Name = "s_TotalSalesMoneyOrg";
            this.s_TotalSalesMoneyOrg.OutputFormat = resources.GetString("s_TotalSalesMoneyOrg.OutputFormat");
            this.s_TotalSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalSalesMoneyOrg.SummaryGroup = "SectionHeader";
            this.s_TotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalSalesMoneyOrg.Text = "123,546,789";
            this.s_TotalSalesMoneyOrg.Top = 0.625F;
            this.s_TotalSalesMoneyOrg.Visible = false;
            this.s_TotalSalesMoneyOrg.Width = 0.66F;
            // 
            // s_GrossMoneyOrg
            // 
            this.s_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.s_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.s_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.s_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.s_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.s_GrossMoneyOrg.Height = 0.156F;
            this.s_GrossMoneyOrg.Left = 3.75F;
            this.s_GrossMoneyOrg.MultiLine = false;
            this.s_GrossMoneyOrg.Name = "s_GrossMoneyOrg";
            this.s_GrossMoneyOrg.OutputFormat = resources.GetString("s_GrossMoneyOrg.OutputFormat");
            this.s_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_GrossMoneyOrg.SummaryGroup = "SectionHeader";
            this.s_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_GrossMoneyOrg.Text = "123,546,789";
            this.s_GrossMoneyOrg.Top = 0.4375F;
            this.s_GrossMoneyOrg.Visible = false;
            this.s_GrossMoneyOrg.Width = 0.66F;
            // 
            // s_TotalGrossMoneyOrg
            // 
            this.s_TotalGrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalGrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalGrossMoneyOrg.DataField = "TotalGrossMoneyOrg";
            this.s_TotalGrossMoneyOrg.Height = 0.156F;
            this.s_TotalGrossMoneyOrg.Left = 3.75F;
            this.s_TotalGrossMoneyOrg.MultiLine = false;
            this.s_TotalGrossMoneyOrg.Name = "s_TotalGrossMoneyOrg";
            this.s_TotalGrossMoneyOrg.OutputFormat = resources.GetString("s_TotalGrossMoneyOrg.OutputFormat");
            this.s_TotalGrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalGrossMoneyOrg.SummaryGroup = "SectionHeader";
            this.s_TotalGrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalGrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalGrossMoneyOrg.Text = "123,546,789";
            this.s_TotalGrossMoneyOrg.Top = 0.625F;
            this.s_TotalGrossMoneyOrg.Visible = false;
            this.s_TotalGrossMoneyOrg.Width = 0.66F;
            // 
            // line17
            // 
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0.12F;
            this.line17.Left = 6.09F;
            this.line17.LineWeight = 2F;
            this.line17.Name = "line17";
            this.line17.Top = 0.25F;
            this.line17.Width = 0F;
            this.line17.X1 = 6.09F;
            this.line17.X2 = 6.09F;
            this.line17.Y1 = 0.25F;
            this.line17.Y2 = 0.37F;
            // 
            // line18
            // 
            this.line18.Border.BottomColor = System.Drawing.Color.Black;
            this.line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.LeftColor = System.Drawing.Color.Black;
            this.line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.RightColor = System.Drawing.Color.Black;
            this.line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.TopColor = System.Drawing.Color.Black;
            this.line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Height = 0.1175F;
            this.line18.Left = 6.09F;
            this.line18.LineWeight = 2F;
            this.line18.Name = "line18";
            this.line18.Top = 0.0625F;
            this.line18.Width = 0F;
            this.line18.X1 = 6.09F;
            this.line18.X2 = 6.09F;
            this.line18.Y1 = 0.0625F;
            this.line18.Y2 = 0.18F;
            // 
            // line23
            // 
            this.line23.Border.BottomColor = System.Drawing.Color.Black;
            this.line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.LeftColor = System.Drawing.Color.Black;
            this.line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.RightColor = System.Drawing.Color.Black;
            this.line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.TopColor = System.Drawing.Color.Black;
            this.line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Height = 0.1175F;
            this.line23.Left = 8.75F;
            this.line23.LineWeight = 2F;
            this.line23.Name = "line23";
            this.line23.Top = 0.0625F;
            this.line23.Width = 0F;
            this.line23.X1 = 8.75F;
            this.line23.X2 = 8.75F;
            this.line23.Y1 = 0.0625F;
            this.line23.Y2 = 0.18F;
            // 
            // line24
            // 
            this.line24.Border.BottomColor = System.Drawing.Color.Black;
            this.line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.LeftColor = System.Drawing.Color.Black;
            this.line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.RightColor = System.Drawing.Color.Black;
            this.line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.TopColor = System.Drawing.Color.Black;
            this.line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Height = 0.12F;
            this.line24.Left = 8.75F;
            this.line24.LineWeight = 2F;
            this.line24.Name = "line24";
            this.line24.Top = 0.25F;
            this.line24.Width = 0F;
            this.line24.X1 = 8.75F;
            this.line24.X2 = 8.75F;
            this.line24.Y1 = 0.25F;
            this.line24.Y2 = 0.37F;
            // 
            // WareHouseHeader
            // 
            this.WareHouseHeader.CanShrink = true;
            this.WareHouseHeader.Height = 0F;
            this.WareHouseHeader.Name = "WareHouseHeader";
            this.WareHouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.WareHouseHeader.Visible = false;
            // 
            // WareHouseFooter
            // 
            this.WareHouseFooter.CanShrink = true;
            this.WareHouseFooter.Height = 0F;
            this.WareHouseFooter.KeepTogether = true;
            this.WareHouseFooter.Name = "WareHouseFooter";
            this.WareHouseFooter.Visible = false;
            // 
            // DailyHeader
            // 
            this.DailyHeader.CanShrink = true;
            this.DailyHeader.DataField = "DailyHeaderField";
            this.DailyHeader.Height = 0F;
            this.DailyHeader.KeepTogether = true;
            this.DailyHeader.Name = "DailyHeader";
            this.DailyHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.DailyHeader.Visible = false;
            // 
            // DailyFooter
            // 
            this.DailyFooter.CanShrink = true;
            this.DailyFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DailyTitle,
            this.d_TermSalesComp,
            this.d_StockSalesMoney,
            this.d_TotalStockSalesMoney,
            this.d_GrossMoney,
            this.d_GrossMarginRate,
            this.d_CostMoney,
            this.d_TotalGrossMoney,
            this.d_TotalGrossMarginRate,
            this.d_TotalCostMoney,
            this.d_YearSalesComp,
            this.d_SalesMoney,
            this.d_TotalOrderSalesMoney,
            this.d_StockMoney,
            this.d_TotalStockMoney,
            this.d_TotalOrderStockMoney,
            this.d_YearStockComp,
            this.d_OrderSalesMoney,
            this.d_TotalSalesMoney,
            this.d_OrderStockMoney,
            this.d_StockStockMoney,
            this.d_TotalStockStockMoney,
            this.d_TermStockComp,
            this.d_Difference,
            this.d_TotalDifference,
            this.line4,
            this.d_MoveShipmentPrice,
            this.d_TotalMoveShipmentPrice,
            this.d_MoveArrivalPric,
            this.d_TotalMoveArrivalPric,
            this.d_SalesMoneyOrg,
            this.d_GrossMoneyOrg,
            this.d_TotalSalesMoneyOrg,
            this.d_TotalGrossMoneyOrg,
            this.line9,
            this.line10,
            this.line11,
            this.line12});
            this.DailyFooter.Height = 0.8229167F;
            this.DailyFooter.KeepTogether = true;
            this.DailyFooter.Name = "DailyFooter";
            this.DailyFooter.Visible = false;
            this.DailyFooter.Format += new System.EventHandler(this.DailyFooter_Format);
            this.DailyFooter.BeforePrint += new System.EventHandler(this.DailyFooter_BeforePrint);
            // 
            // DailyTitle
            // 
            this.DailyTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.DailyTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.DailyTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyTitle.Border.RightColor = System.Drawing.Color.Black;
            this.DailyTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyTitle.Border.TopColor = System.Drawing.Color.Black;
            this.DailyTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DailyTitle.Height = 0.25F;
            this.DailyTitle.Left = 1.225F;
            this.DailyTitle.MultiLine = false;
            this.DailyTitle.Name = "DailyTitle";
            this.DailyTitle.OutputFormat = resources.GetString("DailyTitle.OutputFormat");
            this.DailyTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.DailyTitle.Text = "仕入先計";
            this.DailyTitle.Top = 0.0625F;
            this.DailyTitle.Width = 0.5F;
            // 
            // d_TermSalesComp
            // 
            this.d_TermSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesComp.DataField = "TermSalesComp";
            this.d_TermSalesComp.Height = 0.156F;
            this.d_TermSalesComp.Left = 8.76F;
            this.d_TermSalesComp.MultiLine = false;
            this.d_TermSalesComp.Name = "d_TermSalesComp";
            this.d_TermSalesComp.OutputFormat = resources.GetString("d_TermSalesComp.OutputFormat");
            this.d_TermSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TermSalesComp.SummaryGroup = "WareHouseHeader";
            this.d_TermSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermSalesComp.Text = "123,546,789";
            this.d_TermSalesComp.Top = 0.06F;
            this.d_TermSalesComp.Width = 0.66F;
            // 
            // d_StockSalesMoney
            // 
            this.d_StockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockSalesMoney.DataField = "StockSalesMoney";
            this.d_StockSalesMoney.Height = 0.156F;
            this.d_StockSalesMoney.Left = 3.07F;
            this.d_StockSalesMoney.MultiLine = false;
            this.d_StockSalesMoney.Name = "d_StockSalesMoney";
            this.d_StockSalesMoney.OutputFormat = resources.GetString("d_StockSalesMoney.OutputFormat");
            this.d_StockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockSalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_StockSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockSalesMoney.Text = "123,546,789";
            this.d_StockSalesMoney.Top = 0.06F;
            this.d_StockSalesMoney.Width = 0.66F;
            // 
            // d_TotalStockSalesMoney
            // 
            this.d_TotalStockSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalStockSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalStockSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalStockSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalStockSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockSalesMoney.DataField = "TotalStockSalesMoney";
            this.d_TotalStockSalesMoney.Height = 0.156F;
            this.d_TotalStockSalesMoney.Left = 3.07F;
            this.d_TotalStockSalesMoney.MultiLine = false;
            this.d_TotalStockSalesMoney.Name = "d_TotalStockSalesMoney";
            this.d_TotalStockSalesMoney.OutputFormat = resources.GetString("d_TotalStockSalesMoney.OutputFormat");
            this.d_TotalStockSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalStockSalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalStockSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalStockSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalStockSalesMoney.Text = "123,546,789";
            this.d_TotalStockSalesMoney.Top = 0.25F;
            this.d_TotalStockSalesMoney.Width = 0.66F;
            // 
            // d_GrossMoney
            // 
            this.d_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoney.DataField = "GrossMoney";
            this.d_GrossMoney.Height = 0.156F;
            this.d_GrossMoney.Left = 3.73F;
            this.d_GrossMoney.MultiLine = false;
            this.d_GrossMoney.Name = "d_GrossMoney";
            this.d_GrossMoney.OutputFormat = resources.GetString("d_GrossMoney.OutputFormat");
            this.d_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_GrossMoney.SummaryGroup = "WareHouseHeader";
            this.d_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_GrossMoney.Text = "123,546,789";
            this.d_GrossMoney.Top = 0.06F;
            this.d_GrossMoney.Width = 0.66F;
            // 
            // d_GrossMarginRate
            // 
            this.d_GrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_GrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_GrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_GrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_GrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMarginRate.Height = 0.16F;
            this.d_GrossMarginRate.Left = 4.39F;
            this.d_GrossMarginRate.MultiLine = false;
            this.d_GrossMarginRate.Name = "d_GrossMarginRate";
            this.d_GrossMarginRate.OutputFormat = resources.GetString("d_GrossMarginRate.OutputFormat");
            this.d_GrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_GrossMarginRate.SummaryGroup = "WareHouseHeader";
            this.d_GrossMarginRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_GrossMarginRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_GrossMarginRate.Text = "123,45";
            this.d_GrossMarginRate.Top = 0.06F;
            this.d_GrossMarginRate.Width = 0.375F;
            // 
            // d_CostMoney
            // 
            this.d_CostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_CostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_CostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_CostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_CostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_CostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_CostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_CostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_CostMoney.DataField = "CostMoney";
            this.d_CostMoney.Height = 0.156F;
            this.d_CostMoney.Left = 5.425F;
            this.d_CostMoney.MultiLine = false;
            this.d_CostMoney.Name = "d_CostMoney";
            this.d_CostMoney.OutputFormat = resources.GetString("d_CostMoney.OutputFormat");
            this.d_CostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_CostMoney.SummaryGroup = "WareHouseHeader";
            this.d_CostMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_CostMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_CostMoney.Text = "123,546,789";
            this.d_CostMoney.Top = 0.0625F;
            this.d_CostMoney.Width = 0.66F;
            // 
            // d_TotalGrossMoney
            // 
            this.d_TotalGrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoney.DataField = "TotalGrossMoney";
            this.d_TotalGrossMoney.Height = 0.156F;
            this.d_TotalGrossMoney.Left = 3.73F;
            this.d_TotalGrossMoney.MultiLine = false;
            this.d_TotalGrossMoney.Name = "d_TotalGrossMoney";
            this.d_TotalGrossMoney.OutputFormat = resources.GetString("d_TotalGrossMoney.OutputFormat");
            this.d_TotalGrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalGrossMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalGrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalGrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalGrossMoney.Text = "123,546,789";
            this.d_TotalGrossMoney.Top = 0.25F;
            this.d_TotalGrossMoney.Width = 0.66F;
            // 
            // d_TotalGrossMarginRate
            // 
            this.d_TotalGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMarginRate.Height = 0.16F;
            this.d_TotalGrossMarginRate.Left = 4.39F;
            this.d_TotalGrossMarginRate.MultiLine = false;
            this.d_TotalGrossMarginRate.Name = "d_TotalGrossMarginRate";
            this.d_TotalGrossMarginRate.OutputFormat = resources.GetString("d_TotalGrossMarginRate.OutputFormat");
            this.d_TotalGrossMarginRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalGrossMarginRate.SummaryGroup = "WareHouseHeader";
            this.d_TotalGrossMarginRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalGrossMarginRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalGrossMarginRate.Text = "123,45";
            this.d_TotalGrossMarginRate.Top = 0.25F;
            this.d_TotalGrossMarginRate.Width = 0.375F;
            // 
            // d_TotalCostMoney
            // 
            this.d_TotalCostMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalCostMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCostMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalCostMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCostMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalCostMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCostMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalCostMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCostMoney.DataField = "TotalCostMoney";
            this.d_TotalCostMoney.Height = 0.156F;
            this.d_TotalCostMoney.Left = 5.425F;
            this.d_TotalCostMoney.MultiLine = false;
            this.d_TotalCostMoney.Name = "d_TotalCostMoney";
            this.d_TotalCostMoney.OutputFormat = resources.GetString("d_TotalCostMoney.OutputFormat");
            this.d_TotalCostMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalCostMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalCostMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalCostMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalCostMoney.Text = "123,546,789";
            this.d_TotalCostMoney.Top = 0.25F;
            this.d_TotalCostMoney.Width = 0.66F;
            // 
            // d_YearSalesComp
            // 
            this.d_YearSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.d_YearSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.d_YearSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.d_YearSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.d_YearSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearSalesComp.DataField = "YearSalesComp";
            this.d_YearSalesComp.Height = 0.156F;
            this.d_YearSalesComp.Left = 8.76F;
            this.d_YearSalesComp.MultiLine = false;
            this.d_YearSalesComp.Name = "d_YearSalesComp";
            this.d_YearSalesComp.OutputFormat = resources.GetString("d_YearSalesComp.OutputFormat");
            this.d_YearSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_YearSalesComp.SummaryGroup = "WareHouseHeader";
            this.d_YearSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_YearSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_YearSalesComp.Text = "123,546,789";
            this.d_YearSalesComp.Top = 0.25F;
            this.d_YearSalesComp.Width = 0.66F;
            // 
            // d_SalesMoney
            // 
            this.d_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoney.DataField = "SalesMoney";
            this.d_SalesMoney.Height = 0.156F;
            this.d_SalesMoney.Left = 1.75F;
            this.d_SalesMoney.MultiLine = false;
            this.d_SalesMoney.Name = "d_SalesMoney";
            this.d_SalesMoney.OutputFormat = resources.GetString("d_SalesMoney.OutputFormat");
            this.d_SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_SalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_SalesMoney.Text = "123,546,789";
            this.d_SalesMoney.Top = 0.063F;
            this.d_SalesMoney.Width = 0.66F;
            // 
            // d_TotalOrderSalesMoney
            // 
            this.d_TotalOrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalOrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalOrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalOrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalOrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderSalesMoney.DataField = "TotalOrderSalesMoney";
            this.d_TotalOrderSalesMoney.Height = 0.156F;
            this.d_TotalOrderSalesMoney.Left = 2.41F;
            this.d_TotalOrderSalesMoney.MultiLine = false;
            this.d_TotalOrderSalesMoney.Name = "d_TotalOrderSalesMoney";
            this.d_TotalOrderSalesMoney.OutputFormat = resources.GetString("d_TotalOrderSalesMoney.OutputFormat");
            this.d_TotalOrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalOrderSalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalOrderSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalOrderSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalOrderSalesMoney.Text = "123,546,789";
            this.d_TotalOrderSalesMoney.Top = 0.25F;
            this.d_TotalOrderSalesMoney.Width = 0.66F;
            // 
            // d_StockMoney
            // 
            this.d_StockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoney.DataField = "StockMoney";
            this.d_StockMoney.Height = 0.156F;
            this.d_StockMoney.Left = 6.1F;
            this.d_StockMoney.MultiLine = false;
            this.d_StockMoney.Name = "d_StockMoney";
            this.d_StockMoney.OutputFormat = resources.GetString("d_StockMoney.OutputFormat");
            this.d_StockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockMoney.SummaryGroup = "WareHouseHeader";
            this.d_StockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockMoney.Text = "123,546,789";
            this.d_StockMoney.Top = 0.0625F;
            this.d_StockMoney.Width = 0.66F;
            // 
            // d_TotalStockMoney
            // 
            this.d_TotalStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockMoney.DataField = "TotalStockMoney";
            this.d_TotalStockMoney.Height = 0.156F;
            this.d_TotalStockMoney.Left = 6.1F;
            this.d_TotalStockMoney.MultiLine = false;
            this.d_TotalStockMoney.Name = "d_TotalStockMoney";
            this.d_TotalStockMoney.OutputFormat = resources.GetString("d_TotalStockMoney.OutputFormat");
            this.d_TotalStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalStockMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalStockMoney.Text = "123,546,789";
            this.d_TotalStockMoney.Top = 0.25F;
            this.d_TotalStockMoney.Width = 0.66F;
            // 
            // d_TotalOrderStockMoney
            // 
            this.d_TotalOrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalOrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalOrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalOrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalOrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalOrderStockMoney.DataField = "TotalOrderStockMoney";
            this.d_TotalOrderStockMoney.Height = 0.156F;
            this.d_TotalOrderStockMoney.Left = 6.76F;
            this.d_TotalOrderStockMoney.MultiLine = false;
            this.d_TotalOrderStockMoney.Name = "d_TotalOrderStockMoney";
            this.d_TotalOrderStockMoney.OutputFormat = resources.GetString("d_TotalOrderStockMoney.OutputFormat");
            this.d_TotalOrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalOrderStockMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalOrderStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalOrderStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalOrderStockMoney.Text = "123,546,789";
            this.d_TotalOrderStockMoney.Top = 0.25F;
            this.d_TotalOrderStockMoney.Width = 0.66F;
            // 
            // d_YearStockComp
            // 
            this.d_YearStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.d_YearStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.d_YearStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.d_YearStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.d_YearStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_YearStockComp.DataField = "YearStockComp";
            this.d_YearStockComp.Height = 0.156F;
            this.d_YearStockComp.Left = 9.42F;
            this.d_YearStockComp.MultiLine = false;
            this.d_YearStockComp.Name = "d_YearStockComp";
            this.d_YearStockComp.OutputFormat = resources.GetString("d_YearStockComp.OutputFormat");
            this.d_YearStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_YearStockComp.SummaryGroup = "WareHouseHeader";
            this.d_YearStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_YearStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_YearStockComp.Text = "123,546,789";
            this.d_YearStockComp.Top = 0.25F;
            this.d_YearStockComp.Width = 0.66F;
            // 
            // d_OrderSalesMoney
            // 
            this.d_OrderSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_OrderSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_OrderSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_OrderSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_OrderSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderSalesMoney.DataField = "OrderSalesMoney";
            this.d_OrderSalesMoney.Height = 0.156F;
            this.d_OrderSalesMoney.Left = 2.41F;
            this.d_OrderSalesMoney.MultiLine = false;
            this.d_OrderSalesMoney.Name = "d_OrderSalesMoney";
            this.d_OrderSalesMoney.OutputFormat = resources.GetString("d_OrderSalesMoney.OutputFormat");
            this.d_OrderSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_OrderSalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_OrderSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_OrderSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_OrderSalesMoney.Text = "123,546,789";
            this.d_OrderSalesMoney.Top = 0.06F;
            this.d_OrderSalesMoney.Width = 0.66F;
            // 
            // d_TotalSalesMoney
            // 
            this.d_TotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoney.DataField = "TotalSalesMoney";
            this.d_TotalSalesMoney.Height = 0.156F;
            this.d_TotalSalesMoney.Left = 1.75F;
            this.d_TotalSalesMoney.MultiLine = false;
            this.d_TotalSalesMoney.Name = "d_TotalSalesMoney";
            this.d_TotalSalesMoney.OutputFormat = resources.GetString("d_TotalSalesMoney.OutputFormat");
            this.d_TotalSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalSalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalSalesMoney.Text = "123,546,789";
            this.d_TotalSalesMoney.Top = 0.25F;
            this.d_TotalSalesMoney.Width = 0.66F;
            // 
            // d_OrderStockMoney
            // 
            this.d_OrderStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_OrderStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_OrderStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_OrderStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_OrderStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_OrderStockMoney.DataField = "OrderStockMoney";
            this.d_OrderStockMoney.Height = 0.156F;
            this.d_OrderStockMoney.Left = 6.76F;
            this.d_OrderStockMoney.MultiLine = false;
            this.d_OrderStockMoney.Name = "d_OrderStockMoney";
            this.d_OrderStockMoney.OutputFormat = resources.GetString("d_OrderStockMoney.OutputFormat");
            this.d_OrderStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_OrderStockMoney.SummaryGroup = "WareHouseHeader";
            this.d_OrderStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_OrderStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_OrderStockMoney.Text = "123,546,789";
            this.d_OrderStockMoney.Top = 0.06F;
            this.d_OrderStockMoney.Width = 0.66F;
            // 
            // d_StockStockMoney
            // 
            this.d_StockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockStockMoney.DataField = "StockStockMoney";
            this.d_StockStockMoney.Height = 0.156F;
            this.d_StockStockMoney.Left = 7.42F;
            this.d_StockStockMoney.MultiLine = false;
            this.d_StockStockMoney.Name = "d_StockStockMoney";
            this.d_StockStockMoney.OutputFormat = resources.GetString("d_StockStockMoney.OutputFormat");
            this.d_StockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockStockMoney.SummaryGroup = "WareHouseHeader";
            this.d_StockStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockStockMoney.Text = "123,546,789";
            this.d_StockStockMoney.Top = 0.06F;
            this.d_StockStockMoney.Width = 0.66F;
            // 
            // d_TotalStockStockMoney
            // 
            this.d_TotalStockStockMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalStockStockMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockStockMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalStockStockMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockStockMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalStockStockMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockStockMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalStockStockMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalStockStockMoney.DataField = "TotalStockStockMoney";
            this.d_TotalStockStockMoney.Height = 0.156F;
            this.d_TotalStockStockMoney.Left = 7.42F;
            this.d_TotalStockStockMoney.MultiLine = false;
            this.d_TotalStockStockMoney.Name = "d_TotalStockStockMoney";
            this.d_TotalStockStockMoney.OutputFormat = resources.GetString("d_TotalStockStockMoney.OutputFormat");
            this.d_TotalStockStockMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalStockStockMoney.SummaryGroup = "WareHouseHeader";
            this.d_TotalStockStockMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalStockStockMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalStockStockMoney.Text = "123,546,789";
            this.d_TotalStockStockMoney.Top = 0.25F;
            this.d_TotalStockStockMoney.Width = 0.66F;
            // 
            // d_TermStockComp
            // 
            this.d_TermStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermStockComp.DataField = "TermStockComp";
            this.d_TermStockComp.Height = 0.156F;
            this.d_TermStockComp.Left = 9.42F;
            this.d_TermStockComp.MultiLine = false;
            this.d_TermStockComp.Name = "d_TermStockComp";
            this.d_TermStockComp.OutputFormat = resources.GetString("d_TermStockComp.OutputFormat");
            this.d_TermStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TermStockComp.SummaryGroup = "WareHouseHeader";
            this.d_TermStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermStockComp.Text = "123,546,789";
            this.d_TermStockComp.Top = 0.063F;
            this.d_TermStockComp.Width = 0.66F;
            // 
            // d_Difference
            // 
            this.d_Difference.Border.BottomColor = System.Drawing.Color.Black;
            this.d_Difference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_Difference.Border.LeftColor = System.Drawing.Color.Black;
            this.d_Difference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_Difference.Border.RightColor = System.Drawing.Color.Black;
            this.d_Difference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_Difference.Border.TopColor = System.Drawing.Color.Black;
            this.d_Difference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_Difference.DataField = "Difference";
            this.d_Difference.Height = 0.156F;
            this.d_Difference.Left = 10.08F;
            this.d_Difference.MultiLine = false;
            this.d_Difference.Name = "d_Difference";
            this.d_Difference.OutputFormat = resources.GetString("d_Difference.OutputFormat");
            this.d_Difference.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_Difference.SummaryGroup = "WareHouseHeader";
            this.d_Difference.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_Difference.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_Difference.Text = "123,546,789";
            this.d_Difference.Top = 0.063F;
            this.d_Difference.Width = 0.66F;
            // 
            // d_TotalDifference
            // 
            this.d_TotalDifference.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalDifference.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalDifference.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalDifference.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalDifference.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalDifference.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalDifference.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalDifference.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalDifference.DataField = "TotalDifference";
            this.d_TotalDifference.Height = 0.156F;
            this.d_TotalDifference.Left = 10.08F;
            this.d_TotalDifference.MultiLine = false;
            this.d_TotalDifference.Name = "d_TotalDifference";
            this.d_TotalDifference.OutputFormat = resources.GetString("d_TotalDifference.OutputFormat");
            this.d_TotalDifference.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalDifference.SummaryGroup = "WareHouseHeader";
            this.d_TotalDifference.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalDifference.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalDifference.Text = "123,546,789";
            this.d_TotalDifference.Top = 0.25F;
            this.d_TotalDifference.Width = 0.66F;
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
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // d_MoveShipmentPrice
            // 
            this.d_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.d_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.d_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.d_MoveShipmentPrice.Height = 0.156F;
            this.d_MoveShipmentPrice.Left = 4.765F;
            this.d_MoveShipmentPrice.MultiLine = false;
            this.d_MoveShipmentPrice.Name = "d_MoveShipmentPrice";
            this.d_MoveShipmentPrice.OutputFormat = resources.GetString("d_MoveShipmentPrice.OutputFormat");
            this.d_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MoveShipmentPrice.SummaryGroup = "WareHouseHeader";
            this.d_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MoveShipmentPrice.Text = "123,546,789";
            this.d_MoveShipmentPrice.Top = 0.0625F;
            this.d_MoveShipmentPrice.Width = 0.66F;
            // 
            // d_TotalMoveShipmentPrice
            // 
            this.d_TotalMoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalMoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalMoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalMoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalMoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveShipmentPrice.DataField = "TotalMoveShipmentPrice";
            this.d_TotalMoveShipmentPrice.Height = 0.156F;
            this.d_TotalMoveShipmentPrice.Left = 4.765F;
            this.d_TotalMoveShipmentPrice.MultiLine = false;
            this.d_TotalMoveShipmentPrice.Name = "d_TotalMoveShipmentPrice";
            this.d_TotalMoveShipmentPrice.OutputFormat = resources.GetString("d_TotalMoveShipmentPrice.OutputFormat");
            this.d_TotalMoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalMoveShipmentPrice.SummaryGroup = "WareHouseHeader";
            this.d_TotalMoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalMoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalMoveShipmentPrice.Text = "123,546,789";
            this.d_TotalMoveShipmentPrice.Top = 0.25F;
            this.d_TotalMoveShipmentPrice.Width = 0.66F;
            // 
            // d_MoveArrivalPric
            // 
            this.d_MoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.d_MoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.d_MoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveArrivalPric.DataField = "MoveArrivalPric";
            this.d_MoveArrivalPric.Height = 0.156F;
            this.d_MoveArrivalPric.Left = 8.08F;
            this.d_MoveArrivalPric.MultiLine = false;
            this.d_MoveArrivalPric.Name = "d_MoveArrivalPric";
            this.d_MoveArrivalPric.OutputFormat = resources.GetString("d_MoveArrivalPric.OutputFormat");
            this.d_MoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MoveArrivalPric.SummaryGroup = "WareHouseHeader";
            this.d_MoveArrivalPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MoveArrivalPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MoveArrivalPric.Text = "123,546,789";
            this.d_MoveArrivalPric.Top = 0.0625F;
            this.d_MoveArrivalPric.Width = 0.66F;
            // 
            // d_TotalMoveArrivalPric
            // 
            this.d_TotalMoveArrivalPric.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalMoveArrivalPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveArrivalPric.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalMoveArrivalPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveArrivalPric.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalMoveArrivalPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveArrivalPric.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalMoveArrivalPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalMoveArrivalPric.DataField = "TotalMoveArrivalPric";
            this.d_TotalMoveArrivalPric.Height = 0.156F;
            this.d_TotalMoveArrivalPric.Left = 8.08F;
            this.d_TotalMoveArrivalPric.MultiLine = false;
            this.d_TotalMoveArrivalPric.Name = "d_TotalMoveArrivalPric";
            this.d_TotalMoveArrivalPric.OutputFormat = resources.GetString("d_TotalMoveArrivalPric.OutputFormat");
            this.d_TotalMoveArrivalPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalMoveArrivalPric.SummaryGroup = "WareHouseHeader";
            this.d_TotalMoveArrivalPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalMoveArrivalPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalMoveArrivalPric.Text = "123,546,789";
            this.d_TotalMoveArrivalPric.Top = 0.25F;
            this.d_TotalMoveArrivalPric.Width = 0.66F;
            // 
            // d_SalesMoneyOrg
            // 
            this.d_SalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrg.DataField = "SalesMoneyOrg";
            this.d_SalesMoneyOrg.Height = 0.156F;
            this.d_SalesMoneyOrg.Left = 1.75F;
            this.d_SalesMoneyOrg.MultiLine = false;
            this.d_SalesMoneyOrg.Name = "d_SalesMoneyOrg";
            this.d_SalesMoneyOrg.OutputFormat = resources.GetString("d_SalesMoneyOrg.OutputFormat");
            this.d_SalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_SalesMoneyOrg.SummaryGroup = "WareHouseHeader";
            this.d_SalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_SalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_SalesMoneyOrg.Text = "123,546,789";
            this.d_SalesMoneyOrg.Top = 0.4375F;
            this.d_SalesMoneyOrg.Visible = false;
            this.d_SalesMoneyOrg.Width = 0.66F;
            // 
            // d_GrossMoneyOrg
            // 
            this.d_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.d_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.d_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.d_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.d_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.d_GrossMoneyOrg.Height = 0.156F;
            this.d_GrossMoneyOrg.Left = 3.75F;
            this.d_GrossMoneyOrg.MultiLine = false;
            this.d_GrossMoneyOrg.Name = "d_GrossMoneyOrg";
            this.d_GrossMoneyOrg.OutputFormat = resources.GetString("d_GrossMoneyOrg.OutputFormat");
            this.d_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_GrossMoneyOrg.SummaryGroup = "WareHouseHeader";
            this.d_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_GrossMoneyOrg.Text = "123,546,789";
            this.d_GrossMoneyOrg.Top = 0.4375F;
            this.d_GrossMoneyOrg.Visible = false;
            this.d_GrossMoneyOrg.Width = 0.66F;
            // 
            // d_TotalSalesMoneyOrg
            // 
            this.d_TotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.d_TotalSalesMoneyOrg.Height = 0.156F;
            this.d_TotalSalesMoneyOrg.Left = 1.75F;
            this.d_TotalSalesMoneyOrg.MultiLine = false;
            this.d_TotalSalesMoneyOrg.Name = "d_TotalSalesMoneyOrg";
            this.d_TotalSalesMoneyOrg.OutputFormat = resources.GetString("d_TotalSalesMoneyOrg.OutputFormat");
            this.d_TotalSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalSalesMoneyOrg.SummaryGroup = "WareHouseHeader";
            this.d_TotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalSalesMoneyOrg.Text = "123,546,789";
            this.d_TotalSalesMoneyOrg.Top = 0.625F;
            this.d_TotalSalesMoneyOrg.Visible = false;
            this.d_TotalSalesMoneyOrg.Width = 0.66F;
            // 
            // d_TotalGrossMoneyOrg
            // 
            this.d_TotalGrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalGrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalGrossMoneyOrg.DataField = "TotalGrossMoneyOrg";
            this.d_TotalGrossMoneyOrg.Height = 0.156F;
            this.d_TotalGrossMoneyOrg.Left = 3.75F;
            this.d_TotalGrossMoneyOrg.MultiLine = false;
            this.d_TotalGrossMoneyOrg.Name = "d_TotalGrossMoneyOrg";
            this.d_TotalGrossMoneyOrg.OutputFormat = resources.GetString("d_TotalGrossMoneyOrg.OutputFormat");
            this.d_TotalGrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalGrossMoneyOrg.SummaryGroup = "WareHouseHeader";
            this.d_TotalGrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalGrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalGrossMoneyOrg.Text = "123,546,789";
            this.d_TotalGrossMoneyOrg.Top = 0.625F;
            this.d_TotalGrossMoneyOrg.Visible = false;
            this.d_TotalGrossMoneyOrg.Width = 0.66F;
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0.1175F;
            this.line9.Left = 6.09F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0.0625F;
            this.line9.Width = 0F;
            this.line9.X1 = 6.09F;
            this.line9.X2 = 6.09F;
            this.line9.Y1 = 0.0625F;
            this.line9.Y2 = 0.18F;
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
            this.line10.Height = 0.12F;
            this.line10.Left = 6.09F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0.25F;
            this.line10.Width = 0F;
            this.line10.X1 = 6.09F;
            this.line10.X2 = 6.09F;
            this.line10.Y1 = 0.25F;
            this.line10.Y2 = 0.37F;
            // 
            // line11
            // 
            this.line11.Border.BottomColor = System.Drawing.Color.Black;
            this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.LeftColor = System.Drawing.Color.Black;
            this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.RightColor = System.Drawing.Color.Black;
            this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.TopColor = System.Drawing.Color.Black;
            this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Height = 0.1175F;
            this.line11.Left = 8.75F;
            this.line11.LineWeight = 2F;
            this.line11.Name = "line11";
            this.line11.Top = 0.0625F;
            this.line11.Width = 0F;
            this.line11.X1 = 8.75F;
            this.line11.X2 = 8.75F;
            this.line11.Y1 = 0.0625F;
            this.line11.Y2 = 0.18F;
            // 
            // line12
            // 
            this.line12.Border.BottomColor = System.Drawing.Color.Black;
            this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.LeftColor = System.Drawing.Color.Black;
            this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.RightColor = System.Drawing.Color.Black;
            this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.TopColor = System.Drawing.Color.Black;
            this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Height = 0.12F;
            this.line12.Left = 8.75F;
            this.line12.LineWeight = 2F;
            this.line12.Name = "line12";
            this.line12.Top = 0.25F;
            this.line12.Width = 0F;
            this.line12.X1 = 8.75F;
            this.line12.X2 = 8.75F;
            this.line12.Y1 = 0.25F;
            this.line12.Y2 = 0.37F;
            // 
            // DCTOK02152P_01A4C
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
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.WareHouseHeader);
            this.Sections.Add(this.DailyHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.DailyFooter);
            this.Sections.Add(this.WareHouseFooter);
            this.Sections.Add(this.SectionFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02032P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalOrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalGrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalOrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Difference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalGrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ProDuctNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeaderSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalStockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalGrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalCostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_YearSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalOrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_YearStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalOrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalStockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Difference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalMoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalMoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalGrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalStockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalGrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalCostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_YearSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalOrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalOrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalStockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_YearStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_Difference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalMoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalMoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalGrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalStockSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_CostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalGrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalCostMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_YearSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalOrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalOrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_YearStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_OrderSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_OrderStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalStockStockMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_Difference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalMoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalMoveArrivalPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalGrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
