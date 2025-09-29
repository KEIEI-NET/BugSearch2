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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 売上日報月報印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 売上日報月報のフォームクラスです。</br>
	/// <br>Programmer	: 96186 立花 裕輔</br>
	/// <br>Date		: 2007.09.03</br>
    /// <br>Update Note: 2008.12.09 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
	/// <br></br>
	/// </remarks>
	public class DCTOK02032P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 売上日報月報フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 売上日報月報フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 96186　立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		public DCTOK02032P_01A4C()
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

		private SalStcCompReport _salStcCompReport;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

		// サプレスバッファ
		private Label label1;
		private Label label6;
		private Label label9;
		private Label label10;
		private TextBox SalesMoney;
		private TextBox MonthSalesMoney;
		private TextBox g_SalesMoney;
		private TextBox g_MonthSalesMoney;
		private TextBox s_MonthSalesMoneyOrder;
		private TextBox StockPriceTaxExc;
		private TextBox MonthTotalCost;
		private TextBox s_StockPriceTaxExc;
		private TextBox s_MonthStockPriceTaxExc;
		private TextBox g_StockPriceTaxExc;
		private TextBox g_MonthStockPriceTaxExc;
		private TextBox MonthStockPriceTaxExc;
		private TextBox g_MonthStockPriceTaxExcOrder;
		private TextBox s_MonthStockPriceTaxExcOrder;
		private TextBox MonthBalance;
		private TextBox g_MonthStockComp;
		private TextBox s_SalesMoney;
		private TextBox DailyTitle;
        private TextBox d_TermSalesComp;
		private TextBox d_SalesMoneyStock;
		private TextBox d_MonthSalesMoneyStock;
		private TextBox d_GrossProfit;
		private TextBox d_GrossProfitRate;
		private TextBox d_TotalCost;
		private TextBox d_MonthGrossProfit;
		private TextBox d_MonthGrossProfitRate;
		private TextBox d_MonthTotalCost;
		private TextBox d_MonthSalesComp;
		private TextBox d_SalesMoney;
		private TextBox d_MonthSalesMoneyOrder;
		private TextBox d_StockPriceTaxExc;
		private TextBox d_MonthStockPriceTaxExc;
		private TextBox d_MonthStockPriceTaxExcOrder;
		private TextBox d_MonthStockComp;
		private TextBox SectionHeaderLine;
		private Label label5;
		private Label label11;
		private Label label12;
		private Label Lb_TitleHeaderSub;
		private TextBox TotalCost;
		private TextBox StockPriceTaxExcOrder;
		private TextBox StockPriceTaxExcStock;
		private TextBox TermStockComp;
		private TextBox TermBalance;
		private TextBox MonthStockPriceTaxExcStock;
		private TextBox MonthSalesComp;
		private TextBox MonthStockComp;
		private TextBox d_StockPriceTaxExcOrder;
		private TextBox d_SalesMoneyOrder;
		private TextBox d_MonthSalesMoney;
		private TextBox g_TermBalance;
		private TextBox g_SalesMoneyOrder;
		private TextBox g_MonthSalesMoneyOrder;
		private TextBox g_StockPriceTaxExcOrder;
		private TextBox g_StockPriceTaxExcStock;
		private TextBox g_MonthStockPriceTaxExcStock;
		private TextBox g_TermStockComp;
		private TextBox s_SalesMoneyOrder;
		private TextBox s_MonthSalesMoney;
		private TextBox s_StockPriceTaxExcOrder;
		private TextBox s_StockPriceTaxExcStock;
		private TextBox s_MonthStockPriceTaxExcStock;
		private TextBox s_TermStockComp;
		private TextBox s_MonthStockComp;
		private TextBox s_TermBalance;
		private TextBox s_MonthBalance;
		private TextBox d_StockPriceTaxExcStock;
		private TextBox d_MonthStockPriceTaxExcStock;
		private TextBox d_TermStockComp;
		private TextBox d_TermBalance;
		private TextBox d_MonthBalance;
		private TextBox g_MonthBalance;
		private Label label14;
		private Label label15;
		private Line upline_SectionHeader;
		private Line line4;
        private Line bottomline_TitleHeader;
		private TextBox DetailLineName;
		private TextBox SectionHeaderLineName;
        private Label label13;
        private TextBox MoveMoney;
        private TextBox MonthMoveMoney;
        private Label label17;
        private TextBox StockMoveMoney;
        private TextBox MonthStockMoveMoney;
        private TextBox s_MoveMoney;
        private TextBox s_MonthMoveMoney;
        private TextBox d_MoveMoney;
        private TextBox d_MonthMoveMoney;
        private TextBox g_MoveMoney;
        private TextBox g_MonthMoveMoney;
        private TextBox g_StockMoveMoney;
        private TextBox g_MonthStockMoveMoney;
        private TextBox s_StockMoveMoney;
        private TextBox s_MonthStockMoveMoney;
        private TextBox d_StockMoveMoney;
        private TextBox d_MonthStockMoveMoney;
        private Line line2;
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
        private Line Line_PageFooter;
        private TextBox PageFooters0;
        private TextBox PageFooters1;
		private Label label16;

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
				this._salStcCompReport	= (SalStcCompReport)this._printInfo.jyoken;
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
			//if ( this._salStcCompReport.IsOptSection )
			//{
			//	// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
			//	if ((this._salStcCompReport.SectionCode.Length < 2) || 
			//		this._salStcCompReport.IsSelectAllSection )
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
			bool TtlTypeBool = true;

			//帳票種別 0:拠点別 1:仕入先別
			//帳票種別 0:拠点別
			if (this._salStcCompReport.PrintType == 0)
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
				if (this._salStcCompReport.CrMode == 0)
				{
					SectionHeader.NewPage = NewPage.None;
				}
				else
				{
					SectionHeader.NewPage = NewPage.Before;
				}
				SectionHeader.DataField = "SectionHeaderField";
				SectionHeader.Visible = true;
				SectionFooter.Visible = TtlTypeBool;
				SectionTitle.Visible = TtlTypeBool;
				SectionTitle.Text = "拠点計";
				SectionHeaderLine.DataField = "SectionHeaderLine";
				SectionHeaderLine.Visible = TtlTypeBool;

				//Title
				Lb_TitleHeader.Text = "拠点";
				Lb_TitleHeader.Visible = true;
				Lb_TitleHeaderSub.Text = "仕入先";
				Lb_TitleHeader.Visible = true;
				upline_SectionHeader.Visible = true;
				//bottomline_TitleHeader.Visible = false;
			}
			//帳票種別 1:仕入先別
			else if (this._salStcCompReport.PrintType == 1)
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
				if (this._salStcCompReport.CrMode == 0)
				{
					SectionHeader.NewPage = NewPage.None;
				}
				else
				{
					SectionHeader.NewPage = NewPage.Before;
				}
				SectionHeader.DataField = "SectionHeaderField";
				SectionHeader.Visible = true;
				SectionFooter.Visible = TtlTypeBool;
				SectionTitle.Visible = TtlTypeBool;
				SectionTitle.Text = "仕入先計";
				SectionHeaderLine.DataField = "SectionHeaderLine";
				SectionHeaderLine.Visible = TtlTypeBool;

				//Title
				Lb_TitleHeader.Text = "仕入先";
				Lb_TitleHeader.Visible = true;
				Lb_TitleHeaderSub.Text = "拠点";
				Lb_TitleHeader.Visible = true;
				upline_SectionHeader.Visible = true;
				//bottomline_TitleHeader.Visible = false;
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
			    if ( this._salStcCompReport.StockMoveFormalDiv == SalStcCompReport.StockMoveFormalDivState.StockMove )
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

        // --- ADD 2008/12/09 -------------------------------->>>>>
        #region ◆ 率計算
        /// <summary>
        /// 率項目計算処理
        /// </summary>
        /// <param name="numeratorBox">分子</param>
        /// <param name="denominatorBox">分母</param>
        private double GetRatio(TextBox numeratorBox, TextBox denominatorBox)
        {
            double numerator = Convert.ToDouble(numeratorBox.Text);
            double denominator = Convert.ToDouble(denominatorBox.Text);

            double ratio = this.GetRatio(numerator, denominator);

            return ratio;
        }

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(double numerator, double denominator)
        {
            double workRate;

            if (denominator == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }

            return workRate;
        }
        #endregion
        // --- ADD 2008/12/09 --------------------------------<<<<<
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
			//string sectionTitle = string.Format("{0}拠点：", this._salStcCompReport.MainExtractTitle);
			//if ( this._salStcCompReport.IsOptSection )
			//{
				if ( this._salStcCompReport.IsSelectAllSection )
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

            // 率計算
            // 粗利率(日計)
            this.GrossProfitRate.Value = this.GetRatio(this.GrossProfit, this.SalesMoney);
            // 粗利率(累計)
            this.MonthGrossProfitRate.Value = this.GetRatio(this.MonthGrossProfit, this.MonthSalesMoney);
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
			//期間粗利率
			if (double.Parse(this.d_SalesMoney.Value.ToString()) == 0)
			{
				d_GrossProfitRate.Value = 0;
			}
			else
			{
				d_GrossProfitRate.Value = double.Parse(this.d_GrossProfit.Value.ToString()) * 100 / double.Parse(this.d_SalesMoney.Value.ToString());
			}

			//月間粗利率
			if (double.Parse(this.d_MonthSalesMoney.Value.ToString()) == 0)
			{
				d_MonthGrossProfitRate.Value = 0;
			}
			else
			{
				d_MonthGrossProfitRate.Value = double.Parse(this.d_MonthGrossProfit.Value.ToString()) * 100 / double.Parse(this.d_MonthSalesMoney.Value.ToString());
			}
		}

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
			//期間粗利率
			if (double.Parse(this.s_SalesMoney.Value.ToString()) == 0)
			{
				s_GrossProfitRate.Value = 0;
			}
			else
			{
				s_GrossProfitRate.Value = double.Parse(this.s_GrossProfit.Value.ToString()) * 100 / double.Parse(this.s_SalesMoney.Value.ToString());
			}

			//月間粗利率
			if (double.Parse(this.s_MonthSalesMoney.Value.ToString()) == 0)
			{
				s_MonthGrossProfitRate.Value = 0;
			}
			else
			{
				s_MonthGrossProfitRate.Value = double.Parse(this.s_MonthGrossProfit.Value.ToString()) * 100 / double.Parse(this.s_MonthSalesMoney.Value.ToString());
			}
		}

		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
			//期間粗利率
			//期間粗利率
			if (double.Parse(this.g_SalesMoney.Value.ToString()) == 0)
			{
				g_GrossProfitRate.Value = 0;
			}
			else
			{
				g_GrossProfitRate.Value = double.Parse(this.g_GrossProfit.Value.ToString()) * 100 / double.Parse(this.g_SalesMoney.Value.ToString());
			}

			//月間粗利率
			if (double.Parse(this.g_MonthSalesMoney.Value.ToString()) == 0)
			{
				g_MonthGrossProfitRate.Value = 0;
			}
			else
			{
				g_MonthGrossProfitRate.Value = double.Parse(this.g_MonthGrossProfit.Value.ToString()) * 100 / double.Parse(this.g_MonthSalesMoney.Value.ToString());
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
            // --- DEL 2008/12/09 -------------------------------->>>>>
            //// フッター出力する？
            //if (this._pageFooterOutCode == 0)
            //{
            //    // インスタンスが作成されていなければ作成
            //    if ( _rptPageFooter == null)
            //    {
            //        _rptPageFooter = new ListCommon_PageFooter();
            //    }
            //    else
            //    {
            //        // インスタンスが作成されていれば、データソースを初期化する
            //        // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
            //        _rptPageFooter.DataSource = null;
            //    }
		
            //    // フッター印字項目設定
            //    if (this._pageFooters[0] != null)
            //    {
            //        _rptPageFooter.PrintFooter1 = this._pageFooters[0];
            //    }
            //    if (this._pageFooters[1] != null)
            //    {
            //        _rptPageFooter.PrintFooter2 = this._pageFooters[1];
            //    }
			
            //    this.Footer_SubReport.Report = _rptPageFooter;
            //}
            // --- DEL 2008/12/09 --------------------------------<<<<<
            // --- ADD 2009/1/6 -------------------------------->>>>>
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッター罫線印字設定
                Line_PageFooter.Visible = true;

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    PageFooters0.Visible = true;
                    PageFooters0.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    PageFooters1.Visible = true;
                    PageFooters1.Value = this._pageFooters[1];
                }
            }
            else
            {
                // フッター罫線印字設定
                Line_PageFooter.Visible = false;

                PageFooters0.Visible = false;
                PageFooters1.Visible = false;
            }
            // --- ADD 2009/1/6 --------------------------------<<<<<
		}
		#endregion

        // --- ADD 2008/12/09 -------------------------------->>>>>
        /// <summary>
        /// SectionHeader_BeforePrintイベント
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
		private DataDynamics.ActiveReports.TextBox DetailLine;
        private DataDynamics.ActiveReports.TextBox TermSalesComp;
		private DataDynamics.ActiveReports.TextBox SalesMoneyOrder;
		private DataDynamics.ActiveReports.TextBox SalesMoneyStock;
		private DataDynamics.ActiveReports.TextBox GrossProfitRate;
		private DataDynamics.ActiveReports.TextBox GrossProfit;
		private DataDynamics.ActiveReports.TextBox MonthSalesMoneyOrder;
		private DataDynamics.ActiveReports.TextBox MonthSalesMoneyStock;
		private DataDynamics.ActiveReports.TextBox MonthGrossProfitRate;
		private DataDynamics.ActiveReports.TextBox MonthGrossProfit;
		private DataDynamics.ActiveReports.TextBox MonthStockPriceTaxExcOrder;
		private DataDynamics.ActiveReports.GroupFooter DailyFooter;
		private DataDynamics.ActiveReports.GroupFooter WareHouseFooter;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SectionTitle;
        private DataDynamics.ActiveReports.TextBox s_TermSalesComp;
		private DataDynamics.ActiveReports.TextBox s_SalesMoneyStock;
		private DataDynamics.ActiveReports.TextBox s_GrossProfit;
		private DataDynamics.ActiveReports.TextBox s_MonthSalesMoneyStock;
		private DataDynamics.ActiveReports.TextBox s_MonthGrossProfit;
		private DataDynamics.ActiveReports.TextBox s_GrossProfitRate;
		private DataDynamics.ActiveReports.TextBox s_MonthGrossProfitRate;
		private DataDynamics.ActiveReports.TextBox s_TotalCost;
		private DataDynamics.ActiveReports.TextBox s_MonthTotalCost;
		private DataDynamics.ActiveReports.TextBox s_MonthSalesComp;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotalTitle;
		private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.TextBox g_TermSalesComp;
		private DataDynamics.ActiveReports.TextBox g_SalesMoneyStock;
		private DataDynamics.ActiveReports.TextBox g_MonthSalesMoneyStock;
		private DataDynamics.ActiveReports.TextBox g_GrossProfit;
		private DataDynamics.ActiveReports.TextBox g_MonthGrossProfit;
		private DataDynamics.ActiveReports.TextBox g_GrossProfitRate;
		private DataDynamics.ActiveReports.TextBox g_MonthGrossProfitRate;
		private DataDynamics.ActiveReports.TextBox g_TotalCost;
		private DataDynamics.ActiveReports.TextBox g_MonthTotalCost;
		private DataDynamics.ActiveReports.TextBox g_MonthSalesComp;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02032P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.DetailLine = new DataDynamics.ActiveReports.TextBox();
            this.TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.MonthGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.MonthStockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.MonthStockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.MonthBalance = new DataDynamics.ActiveReports.TextBox();
            this.TotalCost = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.TermBalance = new DataDynamics.ActiveReports.TextBox();
            this.MonthStockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.MonthSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.MonthStockComp = new DataDynamics.ActiveReports.TextBox();
            this.DetailLineName = new DataDynamics.ActiveReports.TextBox();
            this.MoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.MonthMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.StockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.MonthStockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Line_PageFooter = new DataDynamics.ActiveReports.Line();
            this.PageFooters0 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooters1 = new DataDynamics.ActiveReports.TextBox();
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
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.g_TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.g_SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.g_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.g_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.g_TotalCost = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.g_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthStockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthStockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthStockComp = new DataDynamics.ActiveReports.TextBox();
            this.g_SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.g_StockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.g_StockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthStockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.g_TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.g_TermBalance = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthBalance = new DataDynamics.ActiveReports.TextBox();
            this.g_MoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_StockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthStockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.line20 = new DataDynamics.ActiveReports.Line();
            this.line21 = new DataDynamics.ActiveReports.Line();
            this.line22 = new DataDynamics.ActiveReports.Line();
            this.line23 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionHeaderLine = new DataDynamics.ActiveReports.TextBox();
            this.upline_SectionHeader = new DataDynamics.ActiveReports.Line();
            this.SectionHeaderLineName = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.s_TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.s_SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.s_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.s_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.s_TotalCost = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.s_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthStockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthStockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.s_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_StockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.s_StockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthStockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.s_TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthStockComp = new DataDynamics.ActiveReports.TextBox();
            this.s_TermBalance = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthBalance = new DataDynamics.ActiveReports.TextBox();
            this.s_MoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_StockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthStockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.line18 = new DataDynamics.ActiveReports.Line();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.WareHouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WareHouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.DailyHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DailyFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.DailyTitle = new DataDynamics.ActiveReports.TextBox();
            this.d_TermSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.d_SalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesMoneyStock = new DataDynamics.ActiveReports.TextBox();
            this.d_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.d_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.d_TotalCost = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthGrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesComp = new DataDynamics.ActiveReports.TextBox();
            this.d_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.d_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthStockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthStockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthStockComp = new DataDynamics.ActiveReports.TextBox();
            this.d_SalesMoneyOrder = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_StockPriceTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.d_StockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthStockPriceTaxExcStock = new DataDynamics.ActiveReports.TextBox();
            this.d_TermStockComp = new DataDynamics.ActiveReports.TextBox();
            this.d_TermBalance = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthBalance = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.d_MoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_StockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthStockMoveMoney = new DataDynamics.ActiveReports.TextBox();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.line15 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesMoneyStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthGrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoneyOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockPriceTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockPriceTaxExcStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermStockComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockMoveMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DetailLine,
            this.TermSalesComp,
            this.SalesMoneyOrder,
            this.SalesMoneyStock,
            this.GrossProfitRate,
            this.GrossProfit,
            this.MonthSalesMoneyOrder,
            this.MonthSalesMoneyStock,
            this.MonthGrossProfitRate,
            this.MonthGrossProfit,
            this.MonthStockPriceTaxExcOrder,
            this.SalesMoney,
            this.MonthSalesMoney,
            this.StockPriceTaxExc,
            this.MonthTotalCost,
            this.MonthStockPriceTaxExc,
            this.MonthBalance,
            this.TotalCost,
            this.StockPriceTaxExcOrder,
            this.StockPriceTaxExcStock,
            this.TermStockComp,
            this.TermBalance,
            this.MonthStockPriceTaxExcStock,
            this.MonthSalesComp,
            this.MonthStockComp,
            this.DetailLineName,
            this.MoveMoney,
            this.MonthMoveMoney,
            this.StockMoveMoney,
            this.MonthStockMoveMoney,
            this.line2,
            this.line8,
            this.line9,
            this.line10,
            this.line11});
            this.Detail.Height = 0.4791667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            // SalesMoneyOrder
            // 
            this.SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.SalesMoneyOrder.Height = 0.156F;
            this.SalesMoneyOrder.Left = 2.41F;
            this.SalesMoneyOrder.MultiLine = false;
            this.SalesMoneyOrder.Name = "SalesMoneyOrder";
            this.SalesMoneyOrder.OutputFormat = resources.GetString("SalesMoneyOrder.OutputFormat");
            this.SalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyOrder.Text = "123,546,789";
            this.SalesMoneyOrder.Top = 0.06F;
            this.SalesMoneyOrder.Width = 0.66F;
            // 
            // SalesMoneyStock
            // 
            this.SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyStock.DataField = "SalesMoneyStock";
            this.SalesMoneyStock.Height = 0.156F;
            this.SalesMoneyStock.Left = 3.07F;
            this.SalesMoneyStock.MultiLine = false;
            this.SalesMoneyStock.Name = "SalesMoneyStock";
            this.SalesMoneyStock.OutputFormat = resources.GetString("SalesMoneyStock.OutputFormat");
            this.SalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.SalesMoneyStock.Text = "123,546,789";
            this.SalesMoneyStock.Top = 0.06F;
            this.SalesMoneyStock.Width = 0.66F;
            // 
            // GrossProfitRate
            // 
            this.GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitRate.Height = 0.16F;
            this.GrossProfitRate.Left = 4.39F;
            this.GrossProfitRate.MultiLine = false;
            this.GrossProfitRate.Name = "GrossProfitRate";
            this.GrossProfitRate.OutputFormat = resources.GetString("GrossProfitRate.OutputFormat");
            this.GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfitRate.Text = "123,45";
            this.GrossProfitRate.Top = 0.06F;
            this.GrossProfitRate.Width = 0.375F;
            // 
            // GrossProfit
            // 
            this.GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.DataField = "GrossProfit";
            this.GrossProfit.Height = 0.156F;
            this.GrossProfit.Left = 3.73F;
            this.GrossProfit.MultiLine = false;
            this.GrossProfit.Name = "GrossProfit";
            this.GrossProfit.OutputFormat = resources.GetString("GrossProfit.OutputFormat");
            this.GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfit.Text = "123,546,789";
            this.GrossProfit.Top = 0.06F;
            this.GrossProfit.Width = 0.66F;
            // 
            // MonthSalesMoneyOrder
            // 
            this.MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.MonthSalesMoneyOrder.Height = 0.156F;
            this.MonthSalesMoneyOrder.Left = 2.41F;
            this.MonthSalesMoneyOrder.MultiLine = false;
            this.MonthSalesMoneyOrder.Name = "MonthSalesMoneyOrder";
            this.MonthSalesMoneyOrder.OutputFormat = resources.GetString("MonthSalesMoneyOrder.OutputFormat");
            this.MonthSalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyOrder.Text = "123,546,789";
            this.MonthSalesMoneyOrder.Top = 0.25F;
            this.MonthSalesMoneyOrder.Width = 0.66F;
            // 
            // MonthSalesMoneyStock
            // 
            this.MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.MonthSalesMoneyStock.Height = 0.156F;
            this.MonthSalesMoneyStock.Left = 3.07F;
            this.MonthSalesMoneyStock.MultiLine = false;
            this.MonthSalesMoneyStock.Name = "MonthSalesMoneyStock";
            this.MonthSalesMoneyStock.OutputFormat = resources.GetString("MonthSalesMoneyStock.OutputFormat");
            this.MonthSalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoneyStock.Text = "123,546,789";
            this.MonthSalesMoneyStock.Top = 0.25F;
            this.MonthSalesMoneyStock.Width = 0.66F;
            // 
            // MonthGrossProfitRate
            // 
            this.MonthGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfitRate.Height = 0.16F;
            this.MonthGrossProfitRate.Left = 4.39F;
            this.MonthGrossProfitRate.MultiLine = false;
            this.MonthGrossProfitRate.Name = "MonthGrossProfitRate";
            this.MonthGrossProfitRate.OutputFormat = resources.GetString("MonthGrossProfitRate.OutputFormat");
            this.MonthGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfitRate.Text = "123,45";
            this.MonthGrossProfitRate.Top = 0.25F;
            this.MonthGrossProfitRate.Width = 0.375F;
            // 
            // MonthGrossProfit
            // 
            this.MonthGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.MonthGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthGrossProfit.DataField = "MonthGrossProfit";
            this.MonthGrossProfit.Height = 0.156F;
            this.MonthGrossProfit.Left = 3.73F;
            this.MonthGrossProfit.MultiLine = false;
            this.MonthGrossProfit.Name = "MonthGrossProfit";
            this.MonthGrossProfit.OutputFormat = resources.GetString("MonthGrossProfit.OutputFormat");
            this.MonthGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthGrossProfit.Text = "123,546,789";
            this.MonthGrossProfit.Top = 0.25F;
            this.MonthGrossProfit.Width = 0.66F;
            // 
            // MonthStockPriceTaxExcOrder
            // 
            this.MonthStockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcOrder.DataField = "MonthStockPriceTaxExcOrder";
            this.MonthStockPriceTaxExcOrder.Height = 0.156F;
            this.MonthStockPriceTaxExcOrder.Left = 6.76F;
            this.MonthStockPriceTaxExcOrder.MultiLine = false;
            this.MonthStockPriceTaxExcOrder.Name = "MonthStockPriceTaxExcOrder";
            this.MonthStockPriceTaxExcOrder.OutputFormat = resources.GetString("MonthStockPriceTaxExcOrder.OutputFormat");
            this.MonthStockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthStockPriceTaxExcOrder.Text = "123,546,789";
            this.MonthStockPriceTaxExcOrder.Top = 0.25F;
            this.MonthStockPriceTaxExcOrder.Width = 0.66F;
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
            // MonthSalesMoney
            // 
            this.MonthSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesMoney.DataField = "MonthSalesMoney";
            this.MonthSalesMoney.Height = 0.156F;
            this.MonthSalesMoney.Left = 1.75F;
            this.MonthSalesMoney.MultiLine = false;
            this.MonthSalesMoney.Name = "MonthSalesMoney";
            this.MonthSalesMoney.OutputFormat = resources.GetString("MonthSalesMoney.OutputFormat");
            this.MonthSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesMoney.Text = "123,546,789";
            this.MonthSalesMoney.Top = 0.25F;
            this.MonthSalesMoney.Width = 0.66F;
            // 
            // StockPriceTaxExc
            // 
            this.StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.StockPriceTaxExc.Height = 0.156F;
            this.StockPriceTaxExc.Left = 6.1F;
            this.StockPriceTaxExc.MultiLine = false;
            this.StockPriceTaxExc.Name = "StockPriceTaxExc";
            this.StockPriceTaxExc.OutputFormat = resources.GetString("StockPriceTaxExc.OutputFormat");
            this.StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockPriceTaxExc.Text = "123,546,789";
            this.StockPriceTaxExc.Top = 0.0625F;
            this.StockPriceTaxExc.Width = 0.66F;
            // 
            // MonthTotalCost
            // 
            this.MonthTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.MonthTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.MonthTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthTotalCost.DataField = "MonthTotalCost";
            this.MonthTotalCost.Height = 0.156F;
            this.MonthTotalCost.Left = 5.425F;
            this.MonthTotalCost.MultiLine = false;
            this.MonthTotalCost.Name = "MonthTotalCost";
            this.MonthTotalCost.OutputFormat = resources.GetString("MonthTotalCost.OutputFormat");
            this.MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthTotalCost.Text = "123,546,789";
            this.MonthTotalCost.Top = 0.25F;
            this.MonthTotalCost.Width = 0.66F;
            // 
            // MonthStockPriceTaxExc
            // 
            this.MonthStockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExc.DataField = "MonthStockPriceTaxExc";
            this.MonthStockPriceTaxExc.Height = 0.156F;
            this.MonthStockPriceTaxExc.Left = 6.1F;
            this.MonthStockPriceTaxExc.MultiLine = false;
            this.MonthStockPriceTaxExc.Name = "MonthStockPriceTaxExc";
            this.MonthStockPriceTaxExc.OutputFormat = resources.GetString("MonthStockPriceTaxExc.OutputFormat");
            this.MonthStockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthStockPriceTaxExc.Text = "123,546,789";
            this.MonthStockPriceTaxExc.Top = 0.25F;
            this.MonthStockPriceTaxExc.Width = 0.66F;
            // 
            // MonthBalance
            // 
            this.MonthBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthBalance.Border.RightColor = System.Drawing.Color.Black;
            this.MonthBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthBalance.Border.TopColor = System.Drawing.Color.Black;
            this.MonthBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthBalance.DataField = "MonthBalance";
            this.MonthBalance.Height = 0.156F;
            this.MonthBalance.Left = 10.08F;
            this.MonthBalance.MultiLine = false;
            this.MonthBalance.Name = "MonthBalance";
            this.MonthBalance.OutputFormat = resources.GetString("MonthBalance.OutputFormat");
            this.MonthBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthBalance.Text = "123,546,789";
            this.MonthBalance.Top = 0.25F;
            this.MonthBalance.Width = 0.66F;
            // 
            // TotalCost
            // 
            this.TotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.TotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.TotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.DataField = "TotalCost";
            this.TotalCost.Height = 0.156F;
            this.TotalCost.Left = 5.425F;
            this.TotalCost.MultiLine = false;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.OutputFormat = resources.GetString("TotalCost.OutputFormat");
            this.TotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalCost.Text = "123,546,789";
            this.TotalCost.Top = 0.0625F;
            this.TotalCost.Width = 0.66F;
            // 
            // StockPriceTaxExcOrder
            // 
            this.StockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcOrder.DataField = "StockPriceTaxExcOrder";
            this.StockPriceTaxExcOrder.Height = 0.156F;
            this.StockPriceTaxExcOrder.Left = 6.76F;
            this.StockPriceTaxExcOrder.MultiLine = false;
            this.StockPriceTaxExcOrder.Name = "StockPriceTaxExcOrder";
            this.StockPriceTaxExcOrder.OutputFormat = resources.GetString("StockPriceTaxExcOrder.OutputFormat");
            this.StockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockPriceTaxExcOrder.Text = "123,546,789";
            this.StockPriceTaxExcOrder.Top = 0.0625F;
            this.StockPriceTaxExcOrder.Width = 0.66F;
            // 
            // StockPriceTaxExcStock
            // 
            this.StockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.StockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPriceTaxExcStock.DataField = "StockPriceTaxExcStock";
            this.StockPriceTaxExcStock.Height = 0.156F;
            this.StockPriceTaxExcStock.Left = 7.42F;
            this.StockPriceTaxExcStock.MultiLine = false;
            this.StockPriceTaxExcStock.Name = "StockPriceTaxExcStock";
            this.StockPriceTaxExcStock.OutputFormat = resources.GetString("StockPriceTaxExcStock.OutputFormat");
            this.StockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockPriceTaxExcStock.Text = "123,546,789";
            this.StockPriceTaxExcStock.Top = 0.0625F;
            this.StockPriceTaxExcStock.Width = 0.66F;
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
            // TermBalance
            // 
            this.TermBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.TermBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.TermBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermBalance.Border.RightColor = System.Drawing.Color.Black;
            this.TermBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermBalance.Border.TopColor = System.Drawing.Color.Black;
            this.TermBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TermBalance.DataField = "TermBalance";
            this.TermBalance.Height = 0.156F;
            this.TermBalance.Left = 10.08F;
            this.TermBalance.MultiLine = false;
            this.TermBalance.Name = "TermBalance";
            this.TermBalance.OutputFormat = resources.GetString("TermBalance.OutputFormat");
            this.TermBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TermBalance.Text = "123,546,789";
            this.TermBalance.Top = 0.0625F;
            this.TermBalance.Width = 0.66F;
            // 
            // MonthStockPriceTaxExcStock
            // 
            this.MonthStockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.MonthStockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockPriceTaxExcStock.DataField = "MonthStockPriceTaxExcStock";
            this.MonthStockPriceTaxExcStock.Height = 0.156F;
            this.MonthStockPriceTaxExcStock.Left = 7.42F;
            this.MonthStockPriceTaxExcStock.MultiLine = false;
            this.MonthStockPriceTaxExcStock.Name = "MonthStockPriceTaxExcStock";
            this.MonthStockPriceTaxExcStock.OutputFormat = resources.GetString("MonthStockPriceTaxExcStock.OutputFormat");
            this.MonthStockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthStockPriceTaxExcStock.Text = "123,546,789";
            this.MonthStockPriceTaxExcStock.Top = 0.25F;
            this.MonthStockPriceTaxExcStock.Width = 0.66F;
            // 
            // MonthSalesComp
            // 
            this.MonthSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.MonthSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.MonthSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthSalesComp.DataField = "MonthSalesComp";
            this.MonthSalesComp.Height = 0.156F;
            this.MonthSalesComp.Left = 8.76F;
            this.MonthSalesComp.MultiLine = false;
            this.MonthSalesComp.Name = "MonthSalesComp";
            this.MonthSalesComp.OutputFormat = resources.GetString("MonthSalesComp.OutputFormat");
            this.MonthSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthSalesComp.Text = "123,546,789";
            this.MonthSalesComp.Top = 0.25F;
            this.MonthSalesComp.Width = 0.66F;
            // 
            // MonthStockComp
            // 
            this.MonthStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.MonthStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.MonthStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockComp.DataField = "MonthStockComp";
            this.MonthStockComp.Height = 0.156F;
            this.MonthStockComp.Left = 9.42F;
            this.MonthStockComp.MultiLine = false;
            this.MonthStockComp.Name = "MonthStockComp";
            this.MonthStockComp.OutputFormat = resources.GetString("MonthStockComp.OutputFormat");
            this.MonthStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthStockComp.Text = "123,546,789";
            this.MonthStockComp.Top = 0.25F;
            this.MonthStockComp.Width = 0.66F;
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
            // MoveMoney
            // 
            this.MoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveMoney.DataField = "MoveMoney";
            this.MoveMoney.Height = 0.156F;
            this.MoveMoney.Left = 4.765F;
            this.MoveMoney.MultiLine = false;
            this.MoveMoney.Name = "MoveMoney";
            this.MoveMoney.OutputFormat = resources.GetString("MoveMoney.OutputFormat");
            this.MoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MoveMoney.Text = "123,546,789";
            this.MoveMoney.Top = 0.06F;
            this.MoveMoney.Width = 0.66F;
            // 
            // MonthMoveMoney
            // 
            this.MonthMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MonthMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MonthMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthMoveMoney.DataField = "MonthMoveMoney";
            this.MonthMoveMoney.Height = 0.156F;
            this.MonthMoveMoney.Left = 4.765F;
            this.MonthMoveMoney.MultiLine = false;
            this.MonthMoveMoney.Name = "MonthMoveMoney";
            this.MonthMoveMoney.OutputFormat = resources.GetString("MonthMoveMoney.OutputFormat");
            this.MonthMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthMoveMoney.Text = "123,546,789";
            this.MonthMoveMoney.Top = 0.25F;
            this.MonthMoveMoney.Width = 0.66F;
            // 
            // StockMoveMoney
            // 
            this.StockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.StockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.StockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.StockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.StockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMoveMoney.DataField = "StockMoveMoney";
            this.StockMoveMoney.Height = 0.156F;
            this.StockMoveMoney.Left = 8.08F;
            this.StockMoveMoney.MultiLine = false;
            this.StockMoveMoney.Name = "StockMoveMoney";
            this.StockMoveMoney.OutputFormat = resources.GetString("StockMoveMoney.OutputFormat");
            this.StockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.StockMoveMoney.Text = "123,546,789";
            this.StockMoveMoney.Top = 0.0625F;
            this.StockMoveMoney.Width = 0.66F;
            // 
            // MonthStockMoveMoney
            // 
            this.MonthStockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MonthStockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MonthStockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MonthStockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MonthStockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonthStockMoveMoney.DataField = "MonthStockMoveMoney";
            this.MonthStockMoveMoney.Height = 0.156F;
            this.MonthStockMoveMoney.Left = 8.08F;
            this.MonthStockMoveMoney.MultiLine = false;
            this.MonthStockMoveMoney.Name = "MonthStockMoveMoney";
            this.MonthStockMoveMoney.OutputFormat = resources.GetString("MonthStockMoveMoney.OutputFormat");
            this.MonthStockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.MonthStockMoveMoney.Text = "123,546,789";
            this.MonthStockMoveMoney.Top = 0.25F;
            this.MonthStockMoveMoney.Width = 0.66F;
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
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.line8.Left = 6.09F;
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0.0625F;
            this.line8.Width = 0F;
            this.line8.X1 = 6.09F;
            this.line8.X2 = 6.09F;
            this.line8.Y1 = 0.0625F;
            this.line8.Y2 = 0.18F;
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
            this.line9.Height = 0.12F;
            this.line9.Left = 6.09F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0.25F;
            this.line9.Width = 0F;
            this.line9.X1 = 6.09F;
            this.line9.X2 = 6.09F;
            this.line9.Y1 = 0.25F;
            this.line9.Y2 = 0.37F;
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
            this.line10.Left = 8.75F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0.25F;
            this.line10.Width = 0F;
            this.line10.X1 = 8.75F;
            this.line10.X2 = 8.75F;
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
            this.tb_ReportTitle.Text = "売上仕入対比表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line_PageFooter,
            this.PageFooters0,
            this.PageFooters1});
            this.PageFooter.Height = 0.271F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Line_PageFooter
            // 
            this.Line_PageFooter.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.RightColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Border.TopColor = System.Drawing.Color.Black;
            this.Line_PageFooter.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_PageFooter.Height = 0F;
            this.Line_PageFooter.Left = 0F;
            this.Line_PageFooter.LineWeight = 2F;
            this.Line_PageFooter.Name = "Line_PageFooter";
            this.Line_PageFooter.Top = 0F;
            this.Line_PageFooter.Width = 10.8F;
            this.Line_PageFooter.X1 = 0F;
            this.Line_PageFooter.X2 = 10.8F;
            this.Line_PageFooter.Y1 = 0F;
            this.Line_PageFooter.Y2 = 0F;
            // 
            // PageFooters0
            // 
            this.PageFooters0.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters0.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters0.Height = 0.125F;
            this.PageFooters0.Left = 0F;
            this.PageFooters0.MultiLine = false;
            this.PageFooters0.Name = "PageFooters0";
            this.PageFooters0.OutputFormat = resources.GetString("PageFooters0.OutputFormat");
            this.PageFooters0.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.PageFooters0.Text = null;
            this.PageFooters0.Top = 0F;
            this.PageFooters0.Width = 3F;
            // 
            // PageFooters1
            // 
            this.PageFooters1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Height = 0.125F;
            this.PageFooters1.Left = 7.8F;
            this.PageFooters1.MultiLine = false;
            this.PageFooters1.Name = "PageFooters1";
            this.PageFooters1.OutputFormat = resources.GetString("PageFooters1.OutputFormat");
            this.PageFooters1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PageFooters1.Text = null;
            this.PageFooters1.Top = 0F;
            this.PageFooters1.Width = 3F;
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
            this.label13,
            this.label17,
            this.line3,
            this.line5,
            this.line6,
            this.line7});
            this.TitleHeader.Height = 0.625F;
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
            this.line3.Height = 0.117F;
            this.line3.Left = 6.09F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0.063F;
            this.line3.Width = 0F;
            this.line3.X1 = 6.09F;
            this.line3.X2 = 6.09F;
            this.line3.Y1 = 0.063F;
            this.line3.Y2 = 0.18F;
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
            this.line5.Height = 0.12F;
            this.line5.Left = 6.09F;
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0.25F;
            this.line5.Width = 0F;
            this.line5.X1 = 6.09F;
            this.line5.X2 = 6.09F;
            this.line5.Y1 = 0.25F;
            this.line5.Y2 = 0.37F;
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
            this.line6.Height = 0.1175F;
            this.line6.Left = 8.75F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0.0625F;
            this.line6.Width = 0F;
            this.line6.X1 = 8.75F;
            this.line6.X2 = 8.75F;
            this.line6.Y1 = 0.0625F;
            this.line6.Y2 = 0.18F;
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
            this.g_SalesMoneyStock,
            this.g_MonthSalesMoneyStock,
            this.g_GrossProfit,
            this.g_MonthGrossProfit,
            this.g_GrossProfitRate,
            this.g_MonthGrossProfitRate,
            this.g_TotalCost,
            this.g_MonthTotalCost,
            this.g_MonthSalesComp,
            this.g_SalesMoney,
            this.g_MonthSalesMoney,
            this.g_StockPriceTaxExc,
            this.g_MonthStockPriceTaxExc,
            this.g_MonthStockPriceTaxExcOrder,
            this.g_MonthStockComp,
            this.g_SalesMoneyOrder,
            this.g_MonthSalesMoneyOrder,
            this.g_StockPriceTaxExcOrder,
            this.g_StockPriceTaxExcStock,
            this.g_MonthStockPriceTaxExcStock,
            this.g_TermStockComp,
            this.g_TermBalance,
            this.g_MonthBalance,
            this.g_MoveMoney,
            this.g_MonthMoveMoney,
            this.g_StockMoveMoney,
            this.g_MonthStockMoveMoney,
            this.line20,
            this.line21,
            this.line22,
            this.line23});
            this.GrandTotalFooter.Height = 0.4895833F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
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
            this.GrandTotalTitle.Left = 1.05F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
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
            this.g_TermSalesComp.Top = 0.06F;
            this.g_TermSalesComp.Width = 0.66F;
            // 
            // g_SalesMoneyStock
            // 
            this.g_SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.g_SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.g_SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyStock.DataField = "SalesMoneyStock";
            this.g_SalesMoneyStock.Height = 0.156F;
            this.g_SalesMoneyStock.Left = 3.07F;
            this.g_SalesMoneyStock.MultiLine = false;
            this.g_SalesMoneyStock.Name = "g_SalesMoneyStock";
            this.g_SalesMoneyStock.OutputFormat = resources.GetString("g_SalesMoneyStock.OutputFormat");
            this.g_SalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_SalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_SalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_SalesMoneyStock.Text = "123,546,789";
            this.g_SalesMoneyStock.Top = 0.06F;
            this.g_SalesMoneyStock.Width = 0.66F;
            // 
            // g_MonthSalesMoneyStock
            // 
            this.g_MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.g_MonthSalesMoneyStock.Height = 0.156F;
            this.g_MonthSalesMoneyStock.Left = 3.07F;
            this.g_MonthSalesMoneyStock.MultiLine = false;
            this.g_MonthSalesMoneyStock.Name = "g_MonthSalesMoneyStock";
            this.g_MonthSalesMoneyStock.OutputFormat = resources.GetString("g_MonthSalesMoneyStock.OutputFormat");
            this.g_MonthSalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthSalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesMoneyStock.Text = "123,546,789";
            this.g_MonthSalesMoneyStock.Top = 0.25F;
            this.g_MonthSalesMoneyStock.Width = 0.66F;
            // 
            // g_GrossProfit
            // 
            this.g_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.g_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.g_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfit.DataField = "GrossProfit";
            this.g_GrossProfit.Height = 0.156F;
            this.g_GrossProfit.Left = 3.73F;
            this.g_GrossProfit.MultiLine = false;
            this.g_GrossProfit.Name = "g_GrossProfit";
            this.g_GrossProfit.OutputFormat = resources.GetString("g_GrossProfit.OutputFormat");
            this.g_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_GrossProfit.Text = "123,546,789";
            this.g_GrossProfit.Top = 0.06F;
            this.g_GrossProfit.Width = 0.66F;
            // 
            // g_MonthGrossProfit
            // 
            this.g_MonthGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfit.DataField = "MonthGrossProfit";
            this.g_MonthGrossProfit.Height = 0.156F;
            this.g_MonthGrossProfit.Left = 3.73F;
            this.g_MonthGrossProfit.MultiLine = false;
            this.g_MonthGrossProfit.Name = "g_MonthGrossProfit";
            this.g_MonthGrossProfit.OutputFormat = resources.GetString("g_MonthGrossProfit.OutputFormat");
            this.g_MonthGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthGrossProfit.Text = "123,546,789";
            this.g_MonthGrossProfit.Top = 0.25F;
            this.g_MonthGrossProfit.Width = 0.66F;
            // 
            // g_GrossProfitRate
            // 
            this.g_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_GrossProfitRate.Height = 0.16F;
            this.g_GrossProfitRate.Left = 4.39F;
            this.g_GrossProfitRate.MultiLine = false;
            this.g_GrossProfitRate.Name = "g_GrossProfitRate";
            this.g_GrossProfitRate.OutputFormat = resources.GetString("g_GrossProfitRate.OutputFormat");
            this.g_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_GrossProfitRate.Text = "123,45";
            this.g_GrossProfitRate.Top = 0.06F;
            this.g_GrossProfitRate.Width = 0.375F;
            // 
            // g_MonthGrossProfitRate
            // 
            this.g_MonthGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthGrossProfitRate.Height = 0.16F;
            this.g_MonthGrossProfitRate.Left = 4.39F;
            this.g_MonthGrossProfitRate.MultiLine = false;
            this.g_MonthGrossProfitRate.Name = "g_MonthGrossProfitRate";
            this.g_MonthGrossProfitRate.OutputFormat = resources.GetString("g_MonthGrossProfitRate.OutputFormat");
            this.g_MonthGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthGrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthGrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthGrossProfitRate.Text = "123,45";
            this.g_MonthGrossProfitRate.Top = 0.25F;
            this.g_MonthGrossProfitRate.Width = 0.375F;
            // 
            // g_TotalCost
            // 
            this.g_TotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.g_TotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.g_TotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TotalCost.DataField = "TotalCost";
            this.g_TotalCost.Height = 0.156F;
            this.g_TotalCost.Left = 5.425F;
            this.g_TotalCost.MultiLine = false;
            this.g_TotalCost.Name = "g_TotalCost";
            this.g_TotalCost.OutputFormat = resources.GetString("g_TotalCost.OutputFormat");
            this.g_TotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TotalCost.Text = "123,546,789";
            this.g_TotalCost.Top = 0.06F;
            this.g_TotalCost.Width = 0.66F;
            // 
            // g_MonthTotalCost
            // 
            this.g_MonthTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTotalCost.DataField = "MonthTotalCost";
            this.g_MonthTotalCost.Height = 0.156F;
            this.g_MonthTotalCost.Left = 5.425F;
            this.g_MonthTotalCost.MultiLine = false;
            this.g_MonthTotalCost.Name = "g_MonthTotalCost";
            this.g_MonthTotalCost.OutputFormat = resources.GetString("g_MonthTotalCost.OutputFormat");
            this.g_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthTotalCost.Text = "123,546,789";
            this.g_MonthTotalCost.Top = 0.25F;
            this.g_MonthTotalCost.Width = 0.66F;
            // 
            // g_MonthSalesComp
            // 
            this.g_MonthSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesComp.DataField = "MonthSalesComp";
            this.g_MonthSalesComp.Height = 0.156F;
            this.g_MonthSalesComp.Left = 8.76F;
            this.g_MonthSalesComp.MultiLine = false;
            this.g_MonthSalesComp.Name = "g_MonthSalesComp";
            this.g_MonthSalesComp.OutputFormat = resources.GetString("g_MonthSalesComp.OutputFormat");
            this.g_MonthSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesComp.Text = "123,546,789";
            this.g_MonthSalesComp.Top = 0.25F;
            this.g_MonthSalesComp.Width = 0.66F;
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
            this.g_SalesMoney.Top = 0.063F;
            this.g_SalesMoney.Width = 0.66F;
            // 
            // g_MonthSalesMoney
            // 
            this.g_MonthSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoney.DataField = "MonthSalesMoney";
            this.g_MonthSalesMoney.Height = 0.156F;
            this.g_MonthSalesMoney.Left = 1.75F;
            this.g_MonthSalesMoney.MultiLine = false;
            this.g_MonthSalesMoney.Name = "g_MonthSalesMoney";
            this.g_MonthSalesMoney.OutputFormat = resources.GetString("g_MonthSalesMoney.OutputFormat");
            this.g_MonthSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesMoney.Text = "123,546,789";
            this.g_MonthSalesMoney.Top = 0.25F;
            this.g_MonthSalesMoney.Width = 0.66F;
            // 
            // g_StockPriceTaxExc
            // 
            this.g_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.g_StockPriceTaxExc.Height = 0.156F;
            this.g_StockPriceTaxExc.Left = 6.1F;
            this.g_StockPriceTaxExc.MultiLine = false;
            this.g_StockPriceTaxExc.Name = "g_StockPriceTaxExc";
            this.g_StockPriceTaxExc.OutputFormat = resources.GetString("g_StockPriceTaxExc.OutputFormat");
            this.g_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockPriceTaxExc.Text = "123,546,789";
            this.g_StockPriceTaxExc.Top = 0.06F;
            this.g_StockPriceTaxExc.Width = 0.66F;
            // 
            // g_MonthStockPriceTaxExc
            // 
            this.g_MonthStockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExc.DataField = "MonthStockPriceTaxExc";
            this.g_MonthStockPriceTaxExc.Height = 0.156F;
            this.g_MonthStockPriceTaxExc.Left = 6.1F;
            this.g_MonthStockPriceTaxExc.MultiLine = false;
            this.g_MonthStockPriceTaxExc.Name = "g_MonthStockPriceTaxExc";
            this.g_MonthStockPriceTaxExc.OutputFormat = resources.GetString("g_MonthStockPriceTaxExc.OutputFormat");
            this.g_MonthStockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthStockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthStockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthStockPriceTaxExc.Text = "123,546,789";
            this.g_MonthStockPriceTaxExc.Top = 0.25F;
            this.g_MonthStockPriceTaxExc.Width = 0.66F;
            // 
            // g_MonthStockPriceTaxExcOrder
            // 
            this.g_MonthStockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcOrder.DataField = "MonthStockPriceTaxExcOrder";
            this.g_MonthStockPriceTaxExcOrder.Height = 0.156F;
            this.g_MonthStockPriceTaxExcOrder.Left = 6.76F;
            this.g_MonthStockPriceTaxExcOrder.MultiLine = false;
            this.g_MonthStockPriceTaxExcOrder.Name = "g_MonthStockPriceTaxExcOrder";
            this.g_MonthStockPriceTaxExcOrder.OutputFormat = resources.GetString("g_MonthStockPriceTaxExcOrder.OutputFormat");
            this.g_MonthStockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthStockPriceTaxExcOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthStockPriceTaxExcOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthStockPriceTaxExcOrder.Text = "123,546,789";
            this.g_MonthStockPriceTaxExcOrder.Top = 0.25F;
            this.g_MonthStockPriceTaxExcOrder.Width = 0.66F;
            // 
            // g_MonthStockComp
            // 
            this.g_MonthStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockComp.DataField = "MonthStockComp";
            this.g_MonthStockComp.Height = 0.156F;
            this.g_MonthStockComp.Left = 9.42F;
            this.g_MonthStockComp.MultiLine = false;
            this.g_MonthStockComp.Name = "g_MonthStockComp";
            this.g_MonthStockComp.OutputFormat = resources.GetString("g_MonthStockComp.OutputFormat");
            this.g_MonthStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthStockComp.Text = "123,546,789";
            this.g_MonthStockComp.Top = 0.25F;
            this.g_MonthStockComp.Width = 0.66F;
            // 
            // g_SalesMoneyOrder
            // 
            this.g_SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.g_SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.g_SalesMoneyOrder.Height = 0.156F;
            this.g_SalesMoneyOrder.Left = 2.41F;
            this.g_SalesMoneyOrder.MultiLine = false;
            this.g_SalesMoneyOrder.Name = "g_SalesMoneyOrder";
            this.g_SalesMoneyOrder.OutputFormat = resources.GetString("g_SalesMoneyOrder.OutputFormat");
            this.g_SalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_SalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_SalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_SalesMoneyOrder.Text = "123,546,789";
            this.g_SalesMoneyOrder.Top = 0.06F;
            this.g_SalesMoneyOrder.Width = 0.66F;
            // 
            // g_MonthSalesMoneyOrder
            // 
            this.g_MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.g_MonthSalesMoneyOrder.Height = 0.156F;
            this.g_MonthSalesMoneyOrder.Left = 2.41F;
            this.g_MonthSalesMoneyOrder.MultiLine = false;
            this.g_MonthSalesMoneyOrder.Name = "g_MonthSalesMoneyOrder";
            this.g_MonthSalesMoneyOrder.OutputFormat = resources.GetString("g_MonthSalesMoneyOrder.OutputFormat");
            this.g_MonthSalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthSalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesMoneyOrder.Text = "123,546,789";
            this.g_MonthSalesMoneyOrder.Top = 0.25F;
            this.g_MonthSalesMoneyOrder.Width = 0.66F;
            // 
            // g_StockPriceTaxExcOrder
            // 
            this.g_StockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcOrder.DataField = "StockPriceTaxExcOrder";
            this.g_StockPriceTaxExcOrder.Height = 0.156F;
            this.g_StockPriceTaxExcOrder.Left = 6.76F;
            this.g_StockPriceTaxExcOrder.MultiLine = false;
            this.g_StockPriceTaxExcOrder.Name = "g_StockPriceTaxExcOrder";
            this.g_StockPriceTaxExcOrder.OutputFormat = resources.GetString("g_StockPriceTaxExcOrder.OutputFormat");
            this.g_StockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockPriceTaxExcOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockPriceTaxExcOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockPriceTaxExcOrder.Text = "123,546,789";
            this.g_StockPriceTaxExcOrder.Top = 0.0625F;
            this.g_StockPriceTaxExcOrder.Width = 0.66F;
            // 
            // g_StockPriceTaxExcStock
            // 
            this.g_StockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockPriceTaxExcStock.DataField = "StockPriceTaxExcStock";
            this.g_StockPriceTaxExcStock.Height = 0.156F;
            this.g_StockPriceTaxExcStock.Left = 7.42F;
            this.g_StockPriceTaxExcStock.MultiLine = false;
            this.g_StockPriceTaxExcStock.Name = "g_StockPriceTaxExcStock";
            this.g_StockPriceTaxExcStock.OutputFormat = resources.GetString("g_StockPriceTaxExcStock.OutputFormat");
            this.g_StockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockPriceTaxExcStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockPriceTaxExcStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockPriceTaxExcStock.Text = "123,546,789";
            this.g_StockPriceTaxExcStock.Top = 0.06F;
            this.g_StockPriceTaxExcStock.Width = 0.66F;
            // 
            // g_MonthStockPriceTaxExcStock
            // 
            this.g_MonthStockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthStockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockPriceTaxExcStock.DataField = "MonthStockPriceTaxExcStock";
            this.g_MonthStockPriceTaxExcStock.Height = 0.156F;
            this.g_MonthStockPriceTaxExcStock.Left = 7.42F;
            this.g_MonthStockPriceTaxExcStock.MultiLine = false;
            this.g_MonthStockPriceTaxExcStock.Name = "g_MonthStockPriceTaxExcStock";
            this.g_MonthStockPriceTaxExcStock.OutputFormat = resources.GetString("g_MonthStockPriceTaxExcStock.OutputFormat");
            this.g_MonthStockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthStockPriceTaxExcStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthStockPriceTaxExcStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthStockPriceTaxExcStock.Text = "123,546,789";
            this.g_MonthStockPriceTaxExcStock.Top = 0.25F;
            this.g_MonthStockPriceTaxExcStock.Width = 0.66F;
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
            this.g_TermStockComp.Top = 0.063F;
            this.g_TermStockComp.Width = 0.66F;
            // 
            // g_TermBalance
            // 
            this.g_TermBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermBalance.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermBalance.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermBalance.DataField = "TermBalance";
            this.g_TermBalance.Height = 0.156F;
            this.g_TermBalance.Left = 10.08F;
            this.g_TermBalance.MultiLine = false;
            this.g_TermBalance.Name = "g_TermBalance";
            this.g_TermBalance.OutputFormat = resources.GetString("g_TermBalance.OutputFormat");
            this.g_TermBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TermBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermBalance.Text = "123,546,789";
            this.g_TermBalance.Top = 0.063F;
            this.g_TermBalance.Width = 0.66F;
            // 
            // g_MonthBalance
            // 
            this.g_MonthBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthBalance.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthBalance.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthBalance.DataField = "MonthBalance";
            this.g_MonthBalance.Height = 0.156F;
            this.g_MonthBalance.Left = 10.08F;
            this.g_MonthBalance.MultiLine = false;
            this.g_MonthBalance.Name = "g_MonthBalance";
            this.g_MonthBalance.OutputFormat = resources.GetString("g_MonthBalance.OutputFormat");
            this.g_MonthBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthBalance.Text = "123,546,789";
            this.g_MonthBalance.Top = 0.25F;
            this.g_MonthBalance.Width = 0.66F;
            // 
            // g_MoveMoney
            // 
            this.g_MoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_MoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_MoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MoveMoney.DataField = "MoveMoney";
            this.g_MoveMoney.Height = 0.156F;
            this.g_MoveMoney.Left = 4.765F;
            this.g_MoveMoney.MultiLine = false;
            this.g_MoveMoney.Name = "g_MoveMoney";
            this.g_MoveMoney.OutputFormat = resources.GetString("g_MoveMoney.OutputFormat");
            this.g_MoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MoveMoney.Text = "123,546,789";
            this.g_MoveMoney.Top = 0.0625F;
            this.g_MoveMoney.Width = 0.66F;
            // 
            // g_MonthMoveMoney
            // 
            this.g_MonthMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthMoveMoney.DataField = "MonthMoveMoney";
            this.g_MonthMoveMoney.Height = 0.156F;
            this.g_MonthMoveMoney.Left = 4.765F;
            this.g_MonthMoveMoney.MultiLine = false;
            this.g_MonthMoveMoney.Name = "g_MonthMoveMoney";
            this.g_MonthMoveMoney.OutputFormat = resources.GetString("g_MonthMoveMoney.OutputFormat");
            this.g_MonthMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthMoveMoney.Text = "123,546,789";
            this.g_MonthMoveMoney.Top = 0.25F;
            this.g_MonthMoveMoney.Width = 0.66F;
            // 
            // g_StockMoveMoney
            // 
            this.g_StockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_StockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_StockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_StockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_StockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_StockMoveMoney.DataField = "StockMoveMoney";
            this.g_StockMoveMoney.Height = 0.156F;
            this.g_StockMoveMoney.Left = 8.08F;
            this.g_StockMoveMoney.MultiLine = false;
            this.g_StockMoveMoney.Name = "g_StockMoveMoney";
            this.g_StockMoveMoney.OutputFormat = resources.GetString("g_StockMoveMoney.OutputFormat");
            this.g_StockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_StockMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_StockMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_StockMoveMoney.Text = "123,546,789";
            this.g_StockMoveMoney.Top = 0.0625F;
            this.g_StockMoveMoney.Width = 0.66F;
            // 
            // g_MonthStockMoveMoney
            // 
            this.g_MonthStockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthStockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthStockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthStockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthStockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthStockMoveMoney.DataField = "MonthStockMoveMoney";
            this.g_MonthStockMoveMoney.Height = 0.156F;
            this.g_MonthStockMoveMoney.Left = 8.08F;
            this.g_MonthStockMoveMoney.MultiLine = false;
            this.g_MonthStockMoveMoney.Name = "g_MonthStockMoveMoney";
            this.g_MonthStockMoveMoney.OutputFormat = resources.GetString("g_MonthStockMoveMoney.OutputFormat");
            this.g_MonthStockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_MonthStockMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthStockMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthStockMoveMoney.Text = "123,546,789";
            this.g_MonthStockMoveMoney.Top = 0.25F;
            this.g_MonthStockMoveMoney.Width = 0.66F;
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
            this.line21.Left = 6.09F;
            this.line21.LineWeight = 2F;
            this.line21.Name = "line21";
            this.line21.Top = 0.25F;
            this.line21.Width = 0F;
            this.line21.X1 = 6.09F;
            this.line21.X2 = 6.09F;
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
            this.line23.Height = 0.12F;
            this.line23.Left = 8.75F;
            this.line23.LineWeight = 2F;
            this.line23.Name = "line23";
            this.line23.Top = 0.25F;
            this.line23.Width = 0F;
            this.line23.X1 = 8.75F;
            this.line23.X2 = 8.75F;
            this.line23.Y1 = 0.25F;
            this.line23.Y2 = 0.37F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionHeaderLine,
            this.upline_SectionHeader,
            this.SectionHeaderLineName});
            this.SectionHeader.DataField = "SectionHeaderField";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0.2083333F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.BeforePrint += new System.EventHandler(this.SectionHeader_BeforePrint);
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
            this.SectionHeaderLineName.Top = 0.01F;
            this.SectionHeaderLineName.Width = 3F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SectionTitle,
            this.s_TermSalesComp,
            this.s_SalesMoneyStock,
            this.s_GrossProfit,
            this.s_MonthSalesMoneyStock,
            this.s_MonthGrossProfit,
            this.s_GrossProfitRate,
            this.s_MonthGrossProfitRate,
            this.s_TotalCost,
            this.s_MonthTotalCost,
            this.s_MonthSalesComp,
            this.s_MonthSalesMoneyOrder,
            this.s_StockPriceTaxExc,
            this.s_MonthStockPriceTaxExc,
            this.s_MonthStockPriceTaxExcOrder,
            this.s_SalesMoney,
            this.s_SalesMoneyOrder,
            this.s_MonthSalesMoney,
            this.s_StockPriceTaxExcOrder,
            this.s_StockPriceTaxExcStock,
            this.s_MonthStockPriceTaxExcStock,
            this.s_TermStockComp,
            this.s_MonthStockComp,
            this.s_TermBalance,
            this.s_MonthBalance,
            this.s_MoveMoney,
            this.s_MonthMoveMoney,
            this.s_StockMoveMoney,
            this.s_MonthStockMoveMoney,
            this.line16,
            this.line17,
            this.line18,
            this.line19});
            this.SectionFooter.Height = 0.4791667F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
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
            this.SectionTitle.Left = 1.05F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
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
            this.s_TermSalesComp.Top = 0.06F;
            this.s_TermSalesComp.Width = 0.66F;
            // 
            // s_SalesMoneyStock
            // 
            this.s_SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.s_SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.s_SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.s_SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.s_SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyStock.DataField = "SalesMoneyStock";
            this.s_SalesMoneyStock.Height = 0.156F;
            this.s_SalesMoneyStock.Left = 3.07F;
            this.s_SalesMoneyStock.MultiLine = false;
            this.s_SalesMoneyStock.Name = "s_SalesMoneyStock";
            this.s_SalesMoneyStock.OutputFormat = resources.GetString("s_SalesMoneyStock.OutputFormat");
            this.s_SalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_SalesMoneyStock.SummaryGroup = "SectionHeader";
            this.s_SalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_SalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_SalesMoneyStock.Text = "123,546,789";
            this.s_SalesMoneyStock.Top = 0.06F;
            this.s_SalesMoneyStock.Width = 0.66F;
            // 
            // s_GrossProfit
            // 
            this.s_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.s_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.s_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfit.DataField = "GrossProfit";
            this.s_GrossProfit.Height = 0.156F;
            this.s_GrossProfit.Left = 3.73F;
            this.s_GrossProfit.MultiLine = false;
            this.s_GrossProfit.Name = "s_GrossProfit";
            this.s_GrossProfit.OutputFormat = resources.GetString("s_GrossProfit.OutputFormat");
            this.s_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_GrossProfit.SummaryGroup = "SectionHeader";
            this.s_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_GrossProfit.Text = "123,546,789";
            this.s_GrossProfit.Top = 0.06F;
            this.s_GrossProfit.Width = 0.66F;
            // 
            // s_MonthSalesMoneyStock
            // 
            this.s_MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.s_MonthSalesMoneyStock.Height = 0.156F;
            this.s_MonthSalesMoneyStock.Left = 3.07F;
            this.s_MonthSalesMoneyStock.MultiLine = false;
            this.s_MonthSalesMoneyStock.Name = "s_MonthSalesMoneyStock";
            this.s_MonthSalesMoneyStock.OutputFormat = resources.GetString("s_MonthSalesMoneyStock.OutputFormat");
            this.s_MonthSalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthSalesMoneyStock.SummaryGroup = "SectionHeader";
            this.s_MonthSalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesMoneyStock.Text = "123,546,789";
            this.s_MonthSalesMoneyStock.Top = 0.25F;
            this.s_MonthSalesMoneyStock.Width = 0.66F;
            // 
            // s_MonthGrossProfit
            // 
            this.s_MonthGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfit.DataField = "MonthGrossProfit";
            this.s_MonthGrossProfit.Height = 0.156F;
            this.s_MonthGrossProfit.Left = 3.73F;
            this.s_MonthGrossProfit.MultiLine = false;
            this.s_MonthGrossProfit.Name = "s_MonthGrossProfit";
            this.s_MonthGrossProfit.OutputFormat = resources.GetString("s_MonthGrossProfit.OutputFormat");
            this.s_MonthGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthGrossProfit.SummaryGroup = "SectionHeader";
            this.s_MonthGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthGrossProfit.Text = "123,546,789";
            this.s_MonthGrossProfit.Top = 0.25F;
            this.s_MonthGrossProfit.Width = 0.66F;
            // 
            // s_GrossProfitRate
            // 
            this.s_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_GrossProfitRate.Height = 0.16F;
            this.s_GrossProfitRate.Left = 4.39F;
            this.s_GrossProfitRate.MultiLine = false;
            this.s_GrossProfitRate.Name = "s_GrossProfitRate";
            this.s_GrossProfitRate.OutputFormat = resources.GetString("s_GrossProfitRate.OutputFormat");
            this.s_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_GrossProfitRate.SummaryGroup = "SectionHeader";
            this.s_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_GrossProfitRate.Text = "123,45";
            this.s_GrossProfitRate.Top = 0.06F;
            this.s_GrossProfitRate.Width = 0.375F;
            // 
            // s_MonthGrossProfitRate
            // 
            this.s_MonthGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthGrossProfitRate.Height = 0.16F;
            this.s_MonthGrossProfitRate.Left = 4.39F;
            this.s_MonthGrossProfitRate.MultiLine = false;
            this.s_MonthGrossProfitRate.Name = "s_MonthGrossProfitRate";
            this.s_MonthGrossProfitRate.OutputFormat = resources.GetString("s_MonthGrossProfitRate.OutputFormat");
            this.s_MonthGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthGrossProfitRate.SummaryGroup = "SectionHeader";
            this.s_MonthGrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthGrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthGrossProfitRate.Text = "123,45";
            this.s_MonthGrossProfitRate.Top = 0.25F;
            this.s_MonthGrossProfitRate.Width = 0.375F;
            // 
            // s_TotalCost
            // 
            this.s_TotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.s_TotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.s_TotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TotalCost.DataField = "TotalCost";
            this.s_TotalCost.Height = 0.156F;
            this.s_TotalCost.Left = 5.425F;
            this.s_TotalCost.MultiLine = false;
            this.s_TotalCost.Name = "s_TotalCost";
            this.s_TotalCost.OutputFormat = resources.GetString("s_TotalCost.OutputFormat");
            this.s_TotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TotalCost.SummaryGroup = "SectionHeader";
            this.s_TotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TotalCost.Text = "123,546,789";
            this.s_TotalCost.Top = 0.06F;
            this.s_TotalCost.Width = 0.66F;
            // 
            // s_MonthTotalCost
            // 
            this.s_MonthTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTotalCost.DataField = "MonthTotalCost";
            this.s_MonthTotalCost.Height = 0.156F;
            this.s_MonthTotalCost.Left = 5.425F;
            this.s_MonthTotalCost.MultiLine = false;
            this.s_MonthTotalCost.Name = "s_MonthTotalCost";
            this.s_MonthTotalCost.OutputFormat = resources.GetString("s_MonthTotalCost.OutputFormat");
            this.s_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthTotalCost.SummaryGroup = "SectionHeader";
            this.s_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthTotalCost.Text = "123,546,789";
            this.s_MonthTotalCost.Top = 0.25F;
            this.s_MonthTotalCost.Width = 0.66F;
            // 
            // s_MonthSalesComp
            // 
            this.s_MonthSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesComp.DataField = "MonthSalesComp";
            this.s_MonthSalesComp.Height = 0.156F;
            this.s_MonthSalesComp.Left = 8.76F;
            this.s_MonthSalesComp.MultiLine = false;
            this.s_MonthSalesComp.Name = "s_MonthSalesComp";
            this.s_MonthSalesComp.OutputFormat = resources.GetString("s_MonthSalesComp.OutputFormat");
            this.s_MonthSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthSalesComp.SummaryGroup = "SectionHeader";
            this.s_MonthSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesComp.Text = "123,546,789";
            this.s_MonthSalesComp.Top = 0.25F;
            this.s_MonthSalesComp.Width = 0.66F;
            // 
            // s_MonthSalesMoneyOrder
            // 
            this.s_MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.s_MonthSalesMoneyOrder.Height = 0.156F;
            this.s_MonthSalesMoneyOrder.Left = 2.41F;
            this.s_MonthSalesMoneyOrder.MultiLine = false;
            this.s_MonthSalesMoneyOrder.Name = "s_MonthSalesMoneyOrder";
            this.s_MonthSalesMoneyOrder.OutputFormat = resources.GetString("s_MonthSalesMoneyOrder.OutputFormat");
            this.s_MonthSalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthSalesMoneyOrder.SummaryGroup = "SectionHeader";
            this.s_MonthSalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesMoneyOrder.Text = "123,546,789";
            this.s_MonthSalesMoneyOrder.Top = 0.25F;
            this.s_MonthSalesMoneyOrder.Width = 0.66F;
            // 
            // s_StockPriceTaxExc
            // 
            this.s_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.s_StockPriceTaxExc.Height = 0.156F;
            this.s_StockPriceTaxExc.Left = 6.1F;
            this.s_StockPriceTaxExc.MultiLine = false;
            this.s_StockPriceTaxExc.Name = "s_StockPriceTaxExc";
            this.s_StockPriceTaxExc.OutputFormat = resources.GetString("s_StockPriceTaxExc.OutputFormat");
            this.s_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockPriceTaxExc.SummaryGroup = "SectionHeader";
            this.s_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockPriceTaxExc.Text = "123,546,789";
            this.s_StockPriceTaxExc.Top = 0.0625F;
            this.s_StockPriceTaxExc.Width = 0.66F;
            // 
            // s_MonthStockPriceTaxExc
            // 
            this.s_MonthStockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExc.DataField = "MonthStockPriceTaxExc";
            this.s_MonthStockPriceTaxExc.Height = 0.156F;
            this.s_MonthStockPriceTaxExc.Left = 6.1F;
            this.s_MonthStockPriceTaxExc.MultiLine = false;
            this.s_MonthStockPriceTaxExc.Name = "s_MonthStockPriceTaxExc";
            this.s_MonthStockPriceTaxExc.OutputFormat = resources.GetString("s_MonthStockPriceTaxExc.OutputFormat");
            this.s_MonthStockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthStockPriceTaxExc.SummaryGroup = "SectionHeader";
            this.s_MonthStockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthStockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthStockPriceTaxExc.Text = "123,546,789";
            this.s_MonthStockPriceTaxExc.Top = 0.25F;
            this.s_MonthStockPriceTaxExc.Width = 0.66F;
            // 
            // s_MonthStockPriceTaxExcOrder
            // 
            this.s_MonthStockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcOrder.DataField = "MonthStockPriceTaxExcOrder";
            this.s_MonthStockPriceTaxExcOrder.Height = 0.156F;
            this.s_MonthStockPriceTaxExcOrder.Left = 6.76F;
            this.s_MonthStockPriceTaxExcOrder.MultiLine = false;
            this.s_MonthStockPriceTaxExcOrder.Name = "s_MonthStockPriceTaxExcOrder";
            this.s_MonthStockPriceTaxExcOrder.OutputFormat = resources.GetString("s_MonthStockPriceTaxExcOrder.OutputFormat");
            this.s_MonthStockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthStockPriceTaxExcOrder.SummaryGroup = "SectionHeader";
            this.s_MonthStockPriceTaxExcOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthStockPriceTaxExcOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthStockPriceTaxExcOrder.Text = "123,546,789";
            this.s_MonthStockPriceTaxExcOrder.Top = 0.25F;
            this.s_MonthStockPriceTaxExcOrder.Width = 0.66F;
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
            this.s_SalesMoney.Top = 0.063F;
            this.s_SalesMoney.Width = 0.66F;
            // 
            // s_SalesMoneyOrder
            // 
            this.s_SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.s_SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.s_SalesMoneyOrder.Height = 0.156F;
            this.s_SalesMoneyOrder.Left = 2.41F;
            this.s_SalesMoneyOrder.MultiLine = false;
            this.s_SalesMoneyOrder.Name = "s_SalesMoneyOrder";
            this.s_SalesMoneyOrder.OutputFormat = resources.GetString("s_SalesMoneyOrder.OutputFormat");
            this.s_SalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_SalesMoneyOrder.SummaryGroup = "SectionHeader";
            this.s_SalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_SalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_SalesMoneyOrder.Text = "123,546,789";
            this.s_SalesMoneyOrder.Top = 0.06F;
            this.s_SalesMoneyOrder.Width = 0.66F;
            // 
            // s_MonthSalesMoney
            // 
            this.s_MonthSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesMoney.DataField = "MonthSalesMoney";
            this.s_MonthSalesMoney.Height = 0.156F;
            this.s_MonthSalesMoney.Left = 1.75F;
            this.s_MonthSalesMoney.MultiLine = false;
            this.s_MonthSalesMoney.Name = "s_MonthSalesMoney";
            this.s_MonthSalesMoney.OutputFormat = resources.GetString("s_MonthSalesMoney.OutputFormat");
            this.s_MonthSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthSalesMoney.SummaryGroup = "SectionHeader";
            this.s_MonthSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesMoney.Text = "123,546,789";
            this.s_MonthSalesMoney.Top = 0.25F;
            this.s_MonthSalesMoney.Width = 0.66F;
            // 
            // s_StockPriceTaxExcOrder
            // 
            this.s_StockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcOrder.DataField = "StockPriceTaxExcOrder";
            this.s_StockPriceTaxExcOrder.Height = 0.156F;
            this.s_StockPriceTaxExcOrder.Left = 6.76F;
            this.s_StockPriceTaxExcOrder.MultiLine = false;
            this.s_StockPriceTaxExcOrder.Name = "s_StockPriceTaxExcOrder";
            this.s_StockPriceTaxExcOrder.OutputFormat = resources.GetString("s_StockPriceTaxExcOrder.OutputFormat");
            this.s_StockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockPriceTaxExcOrder.SummaryGroup = "SectionHeader";
            this.s_StockPriceTaxExcOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockPriceTaxExcOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockPriceTaxExcOrder.Text = "123,546,789";
            this.s_StockPriceTaxExcOrder.Top = 0.0625F;
            this.s_StockPriceTaxExcOrder.Width = 0.66F;
            // 
            // s_StockPriceTaxExcStock
            // 
            this.s_StockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockPriceTaxExcStock.DataField = "StockPriceTaxExcStock";
            this.s_StockPriceTaxExcStock.Height = 0.156F;
            this.s_StockPriceTaxExcStock.Left = 7.42F;
            this.s_StockPriceTaxExcStock.MultiLine = false;
            this.s_StockPriceTaxExcStock.Name = "s_StockPriceTaxExcStock";
            this.s_StockPriceTaxExcStock.OutputFormat = resources.GetString("s_StockPriceTaxExcStock.OutputFormat");
            this.s_StockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockPriceTaxExcStock.SummaryGroup = "SectionHeader";
            this.s_StockPriceTaxExcStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockPriceTaxExcStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockPriceTaxExcStock.Text = "123,546,789";
            this.s_StockPriceTaxExcStock.Top = 0.0625F;
            this.s_StockPriceTaxExcStock.Width = 0.66F;
            // 
            // s_MonthStockPriceTaxExcStock
            // 
            this.s_MonthStockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthStockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockPriceTaxExcStock.DataField = "MonthStockPriceTaxExcStock";
            this.s_MonthStockPriceTaxExcStock.Height = 0.156F;
            this.s_MonthStockPriceTaxExcStock.Left = 7.42F;
            this.s_MonthStockPriceTaxExcStock.MultiLine = false;
            this.s_MonthStockPriceTaxExcStock.Name = "s_MonthStockPriceTaxExcStock";
            this.s_MonthStockPriceTaxExcStock.OutputFormat = resources.GetString("s_MonthStockPriceTaxExcStock.OutputFormat");
            this.s_MonthStockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthStockPriceTaxExcStock.SummaryGroup = "SectionHeader";
            this.s_MonthStockPriceTaxExcStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthStockPriceTaxExcStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthStockPriceTaxExcStock.Text = "123,546,789";
            this.s_MonthStockPriceTaxExcStock.Top = 0.25F;
            this.s_MonthStockPriceTaxExcStock.Width = 0.66F;
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
            this.s_TermStockComp.Top = 0.0625F;
            this.s_TermStockComp.Width = 0.66F;
            // 
            // s_MonthStockComp
            // 
            this.s_MonthStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockComp.DataField = "MonthStockComp";
            this.s_MonthStockComp.Height = 0.156F;
            this.s_MonthStockComp.Left = 9.42F;
            this.s_MonthStockComp.MultiLine = false;
            this.s_MonthStockComp.Name = "s_MonthStockComp";
            this.s_MonthStockComp.OutputFormat = resources.GetString("s_MonthStockComp.OutputFormat");
            this.s_MonthStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthStockComp.SummaryGroup = "SectionHeader";
            this.s_MonthStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthStockComp.Text = "123,546,789";
            this.s_MonthStockComp.Top = 0.25F;
            this.s_MonthStockComp.Width = 0.66F;
            // 
            // s_TermBalance
            // 
            this.s_TermBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermBalance.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermBalance.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermBalance.DataField = "TermBalance";
            this.s_TermBalance.Height = 0.156F;
            this.s_TermBalance.Left = 10.08F;
            this.s_TermBalance.MultiLine = false;
            this.s_TermBalance.Name = "s_TermBalance";
            this.s_TermBalance.OutputFormat = resources.GetString("s_TermBalance.OutputFormat");
            this.s_TermBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TermBalance.SummaryGroup = "SectionHeader";
            this.s_TermBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermBalance.Text = "123,546,789";
            this.s_TermBalance.Top = 0.063F;
            this.s_TermBalance.Width = 0.66F;
            // 
            // s_MonthBalance
            // 
            this.s_MonthBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthBalance.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthBalance.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthBalance.DataField = "MonthBalance";
            this.s_MonthBalance.Height = 0.156F;
            this.s_MonthBalance.Left = 10.08F;
            this.s_MonthBalance.MultiLine = false;
            this.s_MonthBalance.Name = "s_MonthBalance";
            this.s_MonthBalance.OutputFormat = resources.GetString("s_MonthBalance.OutputFormat");
            this.s_MonthBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthBalance.SummaryGroup = "SectionHeader";
            this.s_MonthBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthBalance.Text = "123,546,789";
            this.s_MonthBalance.Top = 0.25F;
            this.s_MonthBalance.Width = 0.66F;
            // 
            // s_MoveMoney
            // 
            this.s_MoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_MoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_MoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MoveMoney.DataField = "MoveMoney";
            this.s_MoveMoney.Height = 0.156F;
            this.s_MoveMoney.Left = 4.765F;
            this.s_MoveMoney.MultiLine = false;
            this.s_MoveMoney.Name = "s_MoveMoney";
            this.s_MoveMoney.OutputFormat = resources.GetString("s_MoveMoney.OutputFormat");
            this.s_MoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MoveMoney.SummaryGroup = "SectionHeader";
            this.s_MoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MoveMoney.Text = "123,546,789";
            this.s_MoveMoney.Top = 0.0625F;
            this.s_MoveMoney.Width = 0.66F;
            // 
            // s_MonthMoveMoney
            // 
            this.s_MonthMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthMoveMoney.DataField = "MonthMoveMoney";
            this.s_MonthMoveMoney.Height = 0.156F;
            this.s_MonthMoveMoney.Left = 4.765F;
            this.s_MonthMoveMoney.MultiLine = false;
            this.s_MonthMoveMoney.Name = "s_MonthMoveMoney";
            this.s_MonthMoveMoney.OutputFormat = resources.GetString("s_MonthMoveMoney.OutputFormat");
            this.s_MonthMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthMoveMoney.SummaryGroup = "SectionHeader";
            this.s_MonthMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthMoveMoney.Text = "123,546,789";
            this.s_MonthMoveMoney.Top = 0.25F;
            this.s_MonthMoveMoney.Width = 0.66F;
            // 
            // s_StockMoveMoney
            // 
            this.s_StockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockMoveMoney.DataField = "StockMoveMoney";
            this.s_StockMoveMoney.Height = 0.156F;
            this.s_StockMoveMoney.Left = 8.08F;
            this.s_StockMoveMoney.MultiLine = false;
            this.s_StockMoveMoney.Name = "s_StockMoveMoney";
            this.s_StockMoveMoney.OutputFormat = resources.GetString("s_StockMoveMoney.OutputFormat");
            this.s_StockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockMoveMoney.SummaryGroup = "SectionHeader";
            this.s_StockMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockMoveMoney.Text = "123,546,789";
            this.s_StockMoveMoney.Top = 0.0625F;
            this.s_StockMoveMoney.Width = 0.66F;
            // 
            // s_MonthStockMoveMoney
            // 
            this.s_MonthStockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthStockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthStockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthStockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthStockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthStockMoveMoney.DataField = "MonthStockMoveMoney";
            this.s_MonthStockMoveMoney.Height = 0.156F;
            this.s_MonthStockMoveMoney.Left = 8.08F;
            this.s_MonthStockMoveMoney.MultiLine = false;
            this.s_MonthStockMoveMoney.Name = "s_MonthStockMoveMoney";
            this.s_MonthStockMoveMoney.OutputFormat = resources.GetString("s_MonthStockMoveMoney.OutputFormat");
            this.s_MonthStockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_MonthStockMoveMoney.SummaryGroup = "SectionHeader";
            this.s_MonthStockMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthStockMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthStockMoveMoney.Text = "123,546,789";
            this.s_MonthStockMoveMoney.Top = 0.25F;
            this.s_MonthStockMoveMoney.Width = 0.66F;
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
            this.line16.Height = 0.12F;
            this.line16.Left = 6.09F;
            this.line16.LineWeight = 2F;
            this.line16.Name = "line16";
            this.line16.Top = 0.25F;
            this.line16.Width = 0F;
            this.line16.X1 = 6.09F;
            this.line16.X2 = 6.09F;
            this.line16.Y1 = 0.25F;
            this.line16.Y2 = 0.37F;
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
            this.line17.Height = 0.1175F;
            this.line17.Left = 6.09F;
            this.line17.LineWeight = 2F;
            this.line17.Name = "line17";
            this.line17.Top = 0.0625F;
            this.line17.Width = 0F;
            this.line17.X1 = 6.09F;
            this.line17.X2 = 6.09F;
            this.line17.Y1 = 0.0625F;
            this.line17.Y2 = 0.18F;
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
            this.line18.Height = 0.12F;
            this.line18.Left = 8.75F;
            this.line18.LineWeight = 2F;
            this.line18.Name = "line18";
            this.line18.Top = 0.25F;
            this.line18.Width = 0F;
            this.line18.X1 = 8.75F;
            this.line18.X2 = 8.75F;
            this.line18.Y1 = 0.25F;
            this.line18.Y2 = 0.37F;
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
            this.line19.Height = 0.1175F;
            this.line19.Left = 8.75F;
            this.line19.LineWeight = 2F;
            this.line19.Name = "line19";
            this.line19.Top = 0.0625F;
            this.line19.Width = 0F;
            this.line19.X1 = 8.75F;
            this.line19.X2 = 8.75F;
            this.line19.Y1 = 0.0625F;
            this.line19.Y2 = 0.18F;
            // 
            // WareHouseHeader
            // 
            this.WareHouseHeader.CanShrink = true;
            this.WareHouseHeader.Height = 0F;
            this.WareHouseHeader.Name = "WareHouseHeader";
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
            this.DailyHeader.Name = "DailyHeader";
            this.DailyHeader.Visible = false;
            // 
            // DailyFooter
            // 
            this.DailyFooter.CanShrink = true;
            this.DailyFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DailyTitle,
            this.d_TermSalesComp,
            this.d_SalesMoneyStock,
            this.d_MonthSalesMoneyStock,
            this.d_GrossProfit,
            this.d_GrossProfitRate,
            this.d_TotalCost,
            this.d_MonthGrossProfit,
            this.d_MonthGrossProfitRate,
            this.d_MonthTotalCost,
            this.d_MonthSalesComp,
            this.d_SalesMoney,
            this.d_MonthSalesMoneyOrder,
            this.d_StockPriceTaxExc,
            this.d_MonthStockPriceTaxExc,
            this.d_MonthStockPriceTaxExcOrder,
            this.d_MonthStockComp,
            this.d_SalesMoneyOrder,
            this.d_MonthSalesMoney,
            this.d_StockPriceTaxExcOrder,
            this.d_StockPriceTaxExcStock,
            this.d_MonthStockPriceTaxExcStock,
            this.d_TermStockComp,
            this.d_TermBalance,
            this.d_MonthBalance,
            this.line4,
            this.d_MoveMoney,
            this.d_MonthMoveMoney,
            this.d_StockMoveMoney,
            this.d_MonthStockMoveMoney,
            this.line12,
            this.line13,
            this.line14,
            this.line15});
            this.DailyFooter.Height = 0.5F;
            this.DailyFooter.KeepTogether = true;
            this.DailyFooter.Name = "DailyFooter";
            this.DailyFooter.Visible = false;
            this.DailyFooter.Format += new System.EventHandler(this.DailyFooter_Format);
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
            this.DailyTitle.Left = 1.05F;
            this.DailyTitle.MultiLine = false;
            this.DailyTitle.Name = "DailyTitle";
            this.DailyTitle.OutputFormat = resources.GetString("DailyTitle.OutputFormat");
            this.DailyTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DailyTitle.Text = "仕入先計";
            this.DailyTitle.Top = 0.0625F;
            this.DailyTitle.Width = 0.65F;
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
            // d_SalesMoneyStock
            // 
            this.d_SalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.d_SalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.d_SalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.d_SalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.d_SalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyStock.DataField = "SalesMoneyStock";
            this.d_SalesMoneyStock.Height = 0.156F;
            this.d_SalesMoneyStock.Left = 3.07F;
            this.d_SalesMoneyStock.MultiLine = false;
            this.d_SalesMoneyStock.Name = "d_SalesMoneyStock";
            this.d_SalesMoneyStock.OutputFormat = resources.GetString("d_SalesMoneyStock.OutputFormat");
            this.d_SalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_SalesMoneyStock.SummaryGroup = "WareHouseHeader";
            this.d_SalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_SalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_SalesMoneyStock.Text = "123,546,789";
            this.d_SalesMoneyStock.Top = 0.06F;
            this.d_SalesMoneyStock.Width = 0.66F;
            // 
            // d_MonthSalesMoneyStock
            // 
            this.d_MonthSalesMoneyStock.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyStock.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyStock.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyStock.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyStock.DataField = "MonthSalesMoneyStock";
            this.d_MonthSalesMoneyStock.Height = 0.156F;
            this.d_MonthSalesMoneyStock.Left = 3.07F;
            this.d_MonthSalesMoneyStock.MultiLine = false;
            this.d_MonthSalesMoneyStock.Name = "d_MonthSalesMoneyStock";
            this.d_MonthSalesMoneyStock.OutputFormat = resources.GetString("d_MonthSalesMoneyStock.OutputFormat");
            this.d_MonthSalesMoneyStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthSalesMoneyStock.SummaryGroup = "WareHouseHeader";
            this.d_MonthSalesMoneyStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesMoneyStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesMoneyStock.Text = "123,546,789";
            this.d_MonthSalesMoneyStock.Top = 0.25F;
            this.d_MonthSalesMoneyStock.Width = 0.66F;
            // 
            // d_GrossProfit
            // 
            this.d_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.d_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.d_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.d_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.d_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfit.DataField = "GrossProfit";
            this.d_GrossProfit.Height = 0.156F;
            this.d_GrossProfit.Left = 3.73F;
            this.d_GrossProfit.MultiLine = false;
            this.d_GrossProfit.Name = "d_GrossProfit";
            this.d_GrossProfit.OutputFormat = resources.GetString("d_GrossProfit.OutputFormat");
            this.d_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_GrossProfit.SummaryGroup = "WareHouseHeader";
            this.d_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_GrossProfit.Text = "123,546,789";
            this.d_GrossProfit.Top = 0.06F;
            this.d_GrossProfit.Width = 0.66F;
            // 
            // d_GrossProfitRate
            // 
            this.d_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_GrossProfitRate.Height = 0.16F;
            this.d_GrossProfitRate.Left = 4.39F;
            this.d_GrossProfitRate.MultiLine = false;
            this.d_GrossProfitRate.Name = "d_GrossProfitRate";
            this.d_GrossProfitRate.OutputFormat = resources.GetString("d_GrossProfitRate.OutputFormat");
            this.d_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_GrossProfitRate.SummaryGroup = "WareHouseHeader";
            this.d_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_GrossProfitRate.Text = "123,45";
            this.d_GrossProfitRate.Top = 0.06F;
            this.d_GrossProfitRate.Width = 0.375F;
            // 
            // d_TotalCost
            // 
            this.d_TotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.d_TotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.d_TotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TotalCost.DataField = "TotalCost";
            this.d_TotalCost.Height = 0.156F;
            this.d_TotalCost.Left = 5.425F;
            this.d_TotalCost.MultiLine = false;
            this.d_TotalCost.Name = "d_TotalCost";
            this.d_TotalCost.OutputFormat = resources.GetString("d_TotalCost.OutputFormat");
            this.d_TotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TotalCost.SummaryGroup = "WareHouseHeader";
            this.d_TotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TotalCost.Text = "123,546,789";
            this.d_TotalCost.Top = 0.06F;
            this.d_TotalCost.Width = 0.66F;
            // 
            // d_MonthGrossProfit
            // 
            this.d_MonthGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfit.DataField = "MonthGrossProfit";
            this.d_MonthGrossProfit.Height = 0.156F;
            this.d_MonthGrossProfit.Left = 3.73F;
            this.d_MonthGrossProfit.MultiLine = false;
            this.d_MonthGrossProfit.Name = "d_MonthGrossProfit";
            this.d_MonthGrossProfit.OutputFormat = resources.GetString("d_MonthGrossProfit.OutputFormat");
            this.d_MonthGrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthGrossProfit.SummaryGroup = "WareHouseHeader";
            this.d_MonthGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthGrossProfit.Text = "123,546,789";
            this.d_MonthGrossProfit.Top = 0.25F;
            this.d_MonthGrossProfit.Width = 0.66F;
            // 
            // d_MonthGrossProfitRate
            // 
            this.d_MonthGrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthGrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthGrossProfitRate.Height = 0.16F;
            this.d_MonthGrossProfitRate.Left = 4.39F;
            this.d_MonthGrossProfitRate.MultiLine = false;
            this.d_MonthGrossProfitRate.Name = "d_MonthGrossProfitRate";
            this.d_MonthGrossProfitRate.OutputFormat = resources.GetString("d_MonthGrossProfitRate.OutputFormat");
            this.d_MonthGrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthGrossProfitRate.SummaryGroup = "WareHouseHeader";
            this.d_MonthGrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthGrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthGrossProfitRate.Text = "123,45";
            this.d_MonthGrossProfitRate.Top = 0.25F;
            this.d_MonthGrossProfitRate.Width = 0.375F;
            // 
            // d_MonthTotalCost
            // 
            this.d_MonthTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTotalCost.DataField = "MonthTotalCost";
            this.d_MonthTotalCost.Height = 0.156F;
            this.d_MonthTotalCost.Left = 5.425F;
            this.d_MonthTotalCost.MultiLine = false;
            this.d_MonthTotalCost.Name = "d_MonthTotalCost";
            this.d_MonthTotalCost.OutputFormat = resources.GetString("d_MonthTotalCost.OutputFormat");
            this.d_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthTotalCost.SummaryGroup = "WareHouseHeader";
            this.d_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthTotalCost.Text = "123,546,789";
            this.d_MonthTotalCost.Top = 0.25F;
            this.d_MonthTotalCost.Width = 0.66F;
            // 
            // d_MonthSalesComp
            // 
            this.d_MonthSalesComp.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesComp.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesComp.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesComp.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesComp.DataField = "MonthSalesComp";
            this.d_MonthSalesComp.Height = 0.156F;
            this.d_MonthSalesComp.Left = 8.76F;
            this.d_MonthSalesComp.MultiLine = false;
            this.d_MonthSalesComp.Name = "d_MonthSalesComp";
            this.d_MonthSalesComp.OutputFormat = resources.GetString("d_MonthSalesComp.OutputFormat");
            this.d_MonthSalesComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthSalesComp.SummaryGroup = "WareHouseHeader";
            this.d_MonthSalesComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesComp.Text = "123,546,789";
            this.d_MonthSalesComp.Top = 0.25F;
            this.d_MonthSalesComp.Width = 0.66F;
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
            // d_MonthSalesMoneyOrder
            // 
            this.d_MonthSalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoneyOrder.DataField = "MonthSalesMoneyOrder";
            this.d_MonthSalesMoneyOrder.Height = 0.156F;
            this.d_MonthSalesMoneyOrder.Left = 2.41F;
            this.d_MonthSalesMoneyOrder.MultiLine = false;
            this.d_MonthSalesMoneyOrder.Name = "d_MonthSalesMoneyOrder";
            this.d_MonthSalesMoneyOrder.OutputFormat = resources.GetString("d_MonthSalesMoneyOrder.OutputFormat");
            this.d_MonthSalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthSalesMoneyOrder.SummaryGroup = "WareHouseHeader";
            this.d_MonthSalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesMoneyOrder.Text = "123,546,789";
            this.d_MonthSalesMoneyOrder.Top = 0.25F;
            this.d_MonthSalesMoneyOrder.Width = 0.66F;
            // 
            // d_StockPriceTaxExc
            // 
            this.d_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.d_StockPriceTaxExc.Height = 0.156F;
            this.d_StockPriceTaxExc.Left = 6.1F;
            this.d_StockPriceTaxExc.MultiLine = false;
            this.d_StockPriceTaxExc.Name = "d_StockPriceTaxExc";
            this.d_StockPriceTaxExc.OutputFormat = resources.GetString("d_StockPriceTaxExc.OutputFormat");
            this.d_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockPriceTaxExc.SummaryGroup = "WareHouseHeader";
            this.d_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockPriceTaxExc.Text = "123,546,789";
            this.d_StockPriceTaxExc.Top = 0.06F;
            this.d_StockPriceTaxExc.Width = 0.66F;
            // 
            // d_MonthStockPriceTaxExc
            // 
            this.d_MonthStockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExc.DataField = "MonthStockPriceTaxExc";
            this.d_MonthStockPriceTaxExc.Height = 0.156F;
            this.d_MonthStockPriceTaxExc.Left = 6.1F;
            this.d_MonthStockPriceTaxExc.MultiLine = false;
            this.d_MonthStockPriceTaxExc.Name = "d_MonthStockPriceTaxExc";
            this.d_MonthStockPriceTaxExc.OutputFormat = resources.GetString("d_MonthStockPriceTaxExc.OutputFormat");
            this.d_MonthStockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthStockPriceTaxExc.SummaryGroup = "WareHouseHeader";
            this.d_MonthStockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthStockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthStockPriceTaxExc.Text = "123,546,789";
            this.d_MonthStockPriceTaxExc.Top = 0.25F;
            this.d_MonthStockPriceTaxExc.Width = 0.66F;
            // 
            // d_MonthStockPriceTaxExcOrder
            // 
            this.d_MonthStockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcOrder.DataField = "MonthStockPriceTaxExcOrder";
            this.d_MonthStockPriceTaxExcOrder.Height = 0.156F;
            this.d_MonthStockPriceTaxExcOrder.Left = 6.76F;
            this.d_MonthStockPriceTaxExcOrder.MultiLine = false;
            this.d_MonthStockPriceTaxExcOrder.Name = "d_MonthStockPriceTaxExcOrder";
            this.d_MonthStockPriceTaxExcOrder.OutputFormat = resources.GetString("d_MonthStockPriceTaxExcOrder.OutputFormat");
            this.d_MonthStockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthStockPriceTaxExcOrder.SummaryGroup = "WareHouseHeader";
            this.d_MonthStockPriceTaxExcOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthStockPriceTaxExcOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthStockPriceTaxExcOrder.Text = "123,546,789";
            this.d_MonthStockPriceTaxExcOrder.Top = 0.25F;
            this.d_MonthStockPriceTaxExcOrder.Width = 0.66F;
            // 
            // d_MonthStockComp
            // 
            this.d_MonthStockComp.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthStockComp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockComp.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthStockComp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockComp.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthStockComp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockComp.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthStockComp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockComp.DataField = "MonthStockComp";
            this.d_MonthStockComp.Height = 0.156F;
            this.d_MonthStockComp.Left = 9.42F;
            this.d_MonthStockComp.MultiLine = false;
            this.d_MonthStockComp.Name = "d_MonthStockComp";
            this.d_MonthStockComp.OutputFormat = resources.GetString("d_MonthStockComp.OutputFormat");
            this.d_MonthStockComp.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthStockComp.SummaryGroup = "WareHouseHeader";
            this.d_MonthStockComp.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthStockComp.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthStockComp.Text = "123,546,789";
            this.d_MonthStockComp.Top = 0.25F;
            this.d_MonthStockComp.Width = 0.66F;
            // 
            // d_SalesMoneyOrder
            // 
            this.d_SalesMoneyOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrder.Border.RightColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrder.Border.TopColor = System.Drawing.Color.Black;
            this.d_SalesMoneyOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_SalesMoneyOrder.DataField = "SalesMoneyOrder";
            this.d_SalesMoneyOrder.Height = 0.156F;
            this.d_SalesMoneyOrder.Left = 2.41F;
            this.d_SalesMoneyOrder.MultiLine = false;
            this.d_SalesMoneyOrder.Name = "d_SalesMoneyOrder";
            this.d_SalesMoneyOrder.OutputFormat = resources.GetString("d_SalesMoneyOrder.OutputFormat");
            this.d_SalesMoneyOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_SalesMoneyOrder.SummaryGroup = "WareHouseHeader";
            this.d_SalesMoneyOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_SalesMoneyOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_SalesMoneyOrder.Text = "123,546,789";
            this.d_SalesMoneyOrder.Top = 0.06F;
            this.d_SalesMoneyOrder.Width = 0.66F;
            // 
            // d_MonthSalesMoney
            // 
            this.d_MonthSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesMoney.DataField = "MonthSalesMoney";
            this.d_MonthSalesMoney.Height = 0.156F;
            this.d_MonthSalesMoney.Left = 1.75F;
            this.d_MonthSalesMoney.MultiLine = false;
            this.d_MonthSalesMoney.Name = "d_MonthSalesMoney";
            this.d_MonthSalesMoney.OutputFormat = resources.GetString("d_MonthSalesMoney.OutputFormat");
            this.d_MonthSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthSalesMoney.SummaryGroup = "WareHouseHeader";
            this.d_MonthSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesMoney.Text = "123,546,789";
            this.d_MonthSalesMoney.Top = 0.25F;
            this.d_MonthSalesMoney.Width = 0.66F;
            // 
            // d_StockPriceTaxExcOrder
            // 
            this.d_StockPriceTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcOrder.DataField = "StockPriceTaxExcOrder";
            this.d_StockPriceTaxExcOrder.Height = 0.156F;
            this.d_StockPriceTaxExcOrder.Left = 6.76F;
            this.d_StockPriceTaxExcOrder.MultiLine = false;
            this.d_StockPriceTaxExcOrder.Name = "d_StockPriceTaxExcOrder";
            this.d_StockPriceTaxExcOrder.OutputFormat = resources.GetString("d_StockPriceTaxExcOrder.OutputFormat");
            this.d_StockPriceTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockPriceTaxExcOrder.SummaryGroup = "WareHouseHeader";
            this.d_StockPriceTaxExcOrder.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockPriceTaxExcOrder.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockPriceTaxExcOrder.Text = "123,546,789";
            this.d_StockPriceTaxExcOrder.Top = 0.06F;
            this.d_StockPriceTaxExcOrder.Width = 0.66F;
            // 
            // d_StockPriceTaxExcStock
            // 
            this.d_StockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockPriceTaxExcStock.DataField = "StockPriceTaxExcStock";
            this.d_StockPriceTaxExcStock.Height = 0.156F;
            this.d_StockPriceTaxExcStock.Left = 7.42F;
            this.d_StockPriceTaxExcStock.MultiLine = false;
            this.d_StockPriceTaxExcStock.Name = "d_StockPriceTaxExcStock";
            this.d_StockPriceTaxExcStock.OutputFormat = resources.GetString("d_StockPriceTaxExcStock.OutputFormat");
            this.d_StockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockPriceTaxExcStock.SummaryGroup = "WareHouseHeader";
            this.d_StockPriceTaxExcStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockPriceTaxExcStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockPriceTaxExcStock.Text = "123,546,789";
            this.d_StockPriceTaxExcStock.Top = 0.06F;
            this.d_StockPriceTaxExcStock.Width = 0.66F;
            // 
            // d_MonthStockPriceTaxExcStock
            // 
            this.d_MonthStockPriceTaxExcStock.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcStock.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcStock.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcStock.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthStockPriceTaxExcStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockPriceTaxExcStock.DataField = "MonthStockPriceTaxExcStock";
            this.d_MonthStockPriceTaxExcStock.Height = 0.156F;
            this.d_MonthStockPriceTaxExcStock.Left = 7.42F;
            this.d_MonthStockPriceTaxExcStock.MultiLine = false;
            this.d_MonthStockPriceTaxExcStock.Name = "d_MonthStockPriceTaxExcStock";
            this.d_MonthStockPriceTaxExcStock.OutputFormat = resources.GetString("d_MonthStockPriceTaxExcStock.OutputFormat");
            this.d_MonthStockPriceTaxExcStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthStockPriceTaxExcStock.SummaryGroup = "WareHouseHeader";
            this.d_MonthStockPriceTaxExcStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthStockPriceTaxExcStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthStockPriceTaxExcStock.Text = "123,546,789";
            this.d_MonthStockPriceTaxExcStock.Top = 0.25F;
            this.d_MonthStockPriceTaxExcStock.Width = 0.66F;
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
            // d_TermBalance
            // 
            this.d_TermBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermBalance.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermBalance.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermBalance.DataField = "TermBalance";
            this.d_TermBalance.Height = 0.156F;
            this.d_TermBalance.Left = 10.08F;
            this.d_TermBalance.MultiLine = false;
            this.d_TermBalance.Name = "d_TermBalance";
            this.d_TermBalance.OutputFormat = resources.GetString("d_TermBalance.OutputFormat");
            this.d_TermBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_TermBalance.SummaryGroup = "WareHouseHeader";
            this.d_TermBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermBalance.Text = "123,546,789";
            this.d_TermBalance.Top = 0.063F;
            this.d_TermBalance.Width = 0.66F;
            // 
            // d_MonthBalance
            // 
            this.d_MonthBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthBalance.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthBalance.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthBalance.DataField = "MonthBalance";
            this.d_MonthBalance.Height = 0.156F;
            this.d_MonthBalance.Left = 10.08F;
            this.d_MonthBalance.MultiLine = false;
            this.d_MonthBalance.Name = "d_MonthBalance";
            this.d_MonthBalance.OutputFormat = resources.GetString("d_MonthBalance.OutputFormat");
            this.d_MonthBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthBalance.SummaryGroup = "WareHouseHeader";
            this.d_MonthBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthBalance.Text = "123,546,789";
            this.d_MonthBalance.Top = 0.25F;
            this.d_MonthBalance.Width = 0.66F;
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
            // d_MoveMoney
            // 
            this.d_MoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_MoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_MoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MoveMoney.DataField = "MoveMoney";
            this.d_MoveMoney.Height = 0.156F;
            this.d_MoveMoney.Left = 4.765F;
            this.d_MoveMoney.MultiLine = false;
            this.d_MoveMoney.Name = "d_MoveMoney";
            this.d_MoveMoney.OutputFormat = resources.GetString("d_MoveMoney.OutputFormat");
            this.d_MoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MoveMoney.SummaryGroup = "WareHouseHeader";
            this.d_MoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MoveMoney.Text = "123,546,789";
            this.d_MoveMoney.Top = 0.0625F;
            this.d_MoveMoney.Width = 0.66F;
            // 
            // d_MonthMoveMoney
            // 
            this.d_MonthMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthMoveMoney.DataField = "MonthMoveMoney";
            this.d_MonthMoveMoney.Height = 0.156F;
            this.d_MonthMoveMoney.Left = 4.765F;
            this.d_MonthMoveMoney.MultiLine = false;
            this.d_MonthMoveMoney.Name = "d_MonthMoveMoney";
            this.d_MonthMoveMoney.OutputFormat = resources.GetString("d_MonthMoveMoney.OutputFormat");
            this.d_MonthMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthMoveMoney.SummaryGroup = "WareHouseHeader";
            this.d_MonthMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthMoveMoney.Text = "123,546,789";
            this.d_MonthMoveMoney.Top = 0.25F;
            this.d_MonthMoveMoney.Width = 0.66F;
            // 
            // d_StockMoveMoney
            // 
            this.d_StockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_StockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_StockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_StockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_StockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_StockMoveMoney.DataField = "StockMoveMoney";
            this.d_StockMoveMoney.Height = 0.156F;
            this.d_StockMoveMoney.Left = 8.08F;
            this.d_StockMoveMoney.MultiLine = false;
            this.d_StockMoveMoney.Name = "d_StockMoveMoney";
            this.d_StockMoveMoney.OutputFormat = resources.GetString("d_StockMoveMoney.OutputFormat");
            this.d_StockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_StockMoveMoney.SummaryGroup = "WareHouseHeader";
            this.d_StockMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_StockMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_StockMoveMoney.Text = "123,546,789";
            this.d_StockMoveMoney.Top = 0.0625F;
            this.d_StockMoveMoney.Width = 0.66F;
            // 
            // d_MonthStockMoveMoney
            // 
            this.d_MonthStockMoveMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthStockMoveMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockMoveMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthStockMoveMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockMoveMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthStockMoveMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockMoveMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthStockMoveMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthStockMoveMoney.DataField = "MonthStockMoveMoney";
            this.d_MonthStockMoveMoney.Height = 0.156F;
            this.d_MonthStockMoveMoney.Left = 8.08F;
            this.d_MonthStockMoveMoney.MultiLine = false;
            this.d_MonthStockMoveMoney.Name = "d_MonthStockMoveMoney";
            this.d_MonthStockMoveMoney.OutputFormat = resources.GetString("d_MonthStockMoveMoney.OutputFormat");
            this.d_MonthStockMoveMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.d_MonthStockMoveMoney.SummaryGroup = "WareHouseHeader";
            this.d_MonthStockMoveMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthStockMoveMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthStockMoveMoney.Text = "123,546,789";
            this.d_MonthStockMoveMoney.Top = 0.25F;
            this.d_MonthStockMoveMoney.Width = 0.66F;
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
            this.line12.Left = 6.09F;
            this.line12.LineWeight = 2F;
            this.line12.Name = "line12";
            this.line12.Top = 0.25F;
            this.line12.Width = 0F;
            this.line12.X1 = 6.09F;
            this.line12.X2 = 6.09F;
            this.line12.Y1 = 0.25F;
            this.line12.Y2 = 0.37F;
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
            this.line13.Height = 0.1175F;
            this.line13.Left = 6.09F;
            this.line13.LineWeight = 2F;
            this.line13.Name = "line13";
            this.line13.Top = 0.0625F;
            this.line13.Width = 0F;
            this.line13.X1 = 6.09F;
            this.line13.X2 = 6.09F;
            this.line13.Y1 = 0.0625F;
            this.line13.Y2 = 0.18F;
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
            this.line14.Height = 0.12F;
            this.line14.Left = 8.75F;
            this.line14.LineWeight = 2F;
            this.line14.Name = "line14";
            this.line14.Top = 0.25F;
            this.line14.Width = 0F;
            this.line14.X1 = 8.75F;
            this.line14.X2 = 8.75F;
            this.line14.Y1 = 0.25F;
            this.line14.Y2 = 0.37F;
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
            this.line15.Height = 0.1175F;
            this.line15.Left = 8.75F;
            this.line15.LineWeight = 2F;
            this.line15.Name = "line15";
            this.line15.Top = 0.0625F;
            this.line15.Width = 0F;
            this.line15.X1 = 8.75F;
            this.line15.X2 = 8.75F;
            this.line15.Y1 = 0.0625F;
            this.line15.Y2 = 0.18F;
            // 
            // DCTOK02032P_01A4C
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
            this.PrintWidth = 10.8F;
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
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TermBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthStockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_StockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthStockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthStockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesMoneyStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthGrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_SalesMoneyOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockPriceTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockPriceTaxExcStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermStockComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_StockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthStockMoveMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        

	}
}
