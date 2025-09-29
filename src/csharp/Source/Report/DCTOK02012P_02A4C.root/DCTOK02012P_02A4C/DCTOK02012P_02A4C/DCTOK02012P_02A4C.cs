//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：売上日報月報
// プログラム概要   ：売上日報月報を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/08/26     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/06     修正内容：Mantis【13120】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/05/20     修正内容：Mantis【13309】拠点計の売上目標を追加
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：許培珠
// 修正日    2012/04/16     修正内容：redmine#29135 5/24配信分 売上・粗利目標、進捗率・達成率の印字について
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当：李亜博
// 修 正 日  2012/05/22     修正内容：Redmine#29908 06/27配信分 売上日報月報 粗利率の不正表示
//----------------------------------------------------------------------//
// 管理番号  10806793-00    作成担当：zhuhh  
// 修 正 日  2012/12/28     修正内容：2013/03/13配信分 
//                                  　redmine #34098 罫線印字制御を追加する
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 周洋
// 修 正 日  2014/12/04  修正内容 : 仕掛一覧№2591 Redmine#43991 金額桁数が10億と100億まで印刷されないの対応
//----------------------------------------------------------------------------//
// 管理番号                 作成担当：周洋
// 修 正 日  2014/12/09     修正内容：仕掛一覧№2591 Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
//----------------------------------------------------------------------------//
// 管理番号              　 作成担当：周洋
// 修 正 日  2014/12/18  　 修正内容：仕掛一覧№2591 Redmine#43991の#51 金額単位「千円」で出力する不具合の対応
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

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
    /// <br>Update Note : 2012/05/22 李亜博</br>
    /// <br>管理番号    : 10801804-00 06/27配信分</br>
    ///                   Redmine#29908   売上日報月報 粗利率の不正表示</br>
    /// <br>UpdateNote  : 2012/12/28 zhuhh</br>
    /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
    /// <br>            : redmine #34098 罫線印字制御を追加する</br>
    /// <br>UpdateNote  : 2014/12/04 周洋</br>
    /// <br>              仕掛一覧№2591 Redmine#43991</br>
    /// <br>              金額桁数が10億と100億まで印刷されないの対応</br>
    /// <br>UpdateNote  : 2014/12/09 周洋</br>
    /// <br>              仕掛一覧№2591 Redmine#43991の#43</br>
    /// <br>              1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
    /// <br>UpdateNote  : 2014/12/18 周洋</br>
    /// <br>              仕掛一覧№2591 Redmine#43991の#51</br>
    /// <br>              金額単位「千円」で出力する不具合の対応</br>
    /// <br></br>
	/// </remarks>
	public class DCTOK02012P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
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
		public DCTOK02012P_02A4C()
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

		private SalesDayMonthReport _salesDayMonthReport;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        // サプレスバッファ
		private Label label6;
		private Label label9;
		private Label label10;
		private Label label11;
        private Label label12;
        private TextBox textBox13;
		private TextBox s_TermTotalCost;
		private TextBox s_MonthTotalCost;
		private TextBox w_TermTotalCost;
		private TextBox w_MonthTotalCost;
        private TextBox g_TermTotalCost;
		private TextBox textBox28;
		private TextBox g_MonthSalesTargetMoney;
		private TextBox s_MonthSalesTargetMoney;
		private TextBox w_MonthSalesTargetMoney;
		private TextBox textBox35;
		private TextBox textBox36;
		private TextBox textBox44;
		private TextBox g_TermProfitRate;
		private TextBox g_MonthProfitRate;
		private TextBox g_MonthTargetProfitRate;
		private TextBox s_TermProfitRate;
		private TextBox s_MonthProfitRate;
		private TextBox s_MonthTargetProfitRate;
		private TextBox w_TermProfitRate;
		private TextBox w_MonthProfitRate;
		private TextBox w_MonthTargetProfitRate;
		private TextBox textBox52;
		private TextBox g_MonthSalesTargetProfit;
		private TextBox s_MonthSalesTargetProfit;
		private TextBox w_MonthSalesTargetProfit;
		private TextBox DailyTitle;
		private TextBox d_TermProfit;
		private TextBox textBox61;
		private TextBox textBox62;
		private TextBox d_TermSalesTotalTaxExc;
		private TextBox d_MonthSalesTotalTaxExc;
		private TextBox d_TermSalesBackTotalTaxExc;
		private TextBox d_TermSalesBackTotalTaxRate;
		private TextBox d_TermSalesDisTtlTaxExc;
		private TextBox d_MonthSalesBackTotalTaxExc;
		private TextBox d_MonthSalesBackTotalTaxRate;
		private TextBox d_MonthSalesDisTtlTaxExc;
		private TextBox d_MonthTargetSalesRate;
        private TextBox d_MonthProfit;
		private TextBox d_TermTotalCost;
		private TextBox d_MonthTotalCost;
		private TextBox d_MonthSalesTargetMoney;
		private TextBox d_TermProfitRate;
		private TextBox d_MonthProfitRate;
		private TextBox d_MonthTargetProfitRate;
		private TextBox d_MonthSalesTargetProfit;
		private TextBox SectionHeaderLine;
		private TextBox WareHouseHeaderLine;
		private Line line3;
		private Line upline_SectionHeader;
		private TextBox SectionHeaderLineName;
		private TextBox WareHouseHeaderLineName;
		private TextBox DetailLineName;
        private TextBox textBox25;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox34;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox29;
        private TextBox textBox30;
        private TextBox textBox31;
        private TextBox textBox32;
        private TextBox textBox33;
        private TextBox textBox37;
        private TextBox textBox38;
        private TextBox textBox39;
        private TextBox textBox40;
        private TextBox textBox41;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox SectionHeaderLineTitle;
        private Line line2;
        private Line Line_PageFooter;
        private TextBox PageFooters0;
        private TextBox PageFooters1;
        private TextBox textBox14;
        private TextBox g_MonthTotalCost;
        private Line line4;
        private TextBox textBox5;

#if False
		string _slipSuppresBuf = "";

		// 2007.09.03 立花 裕輔 add ---------------->
		// メーカー情報サプレスバッファ
		string _makerSuppresBuf = "";
		// 商品情報サプレスバッファ
		string _goodsSuppresBuf = "";
		// 2007.09.03 立花 裕輔 add <----------------
#endif
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
				this._salesDayMonthReport	= (SalesDayMonthReport)this._printInfo.jyoken;
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
        /// <br>UpdateNote  : 2012/12/28 zhuhh</br>
        /// <br>管理番号    : 10806793-00 2013/03/13配信分</br>
        /// <br>            : redmine #34098 罫線印字制御を追加する</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			// 拠点計を出力するかしないかを選択する
			// 拠点有無を判断
			//if ( this._salesDayMonthReport.IsOptSection )
			//{
			//	// 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
			//	if ((this._salesDayMonthReport.SectionCode.Length < 2) || 
			//		this._salesDayMonthReport.IsSelectAllSection )
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
			SortTitle.Text = this._pageHeaderSortOderTitle;     

			// タイトル項目の名称をセット
			tb_ReportTitle.Text = this._pageHeaderTitle;

            // 2008.12.05 30413 犬飼 罫線の印字制御を削除 >>>>>>START
            //全社 拠点単位の判定
			bool TtlTypeBool = true;
			if (_salesDayMonthReport.TtlType == 0)
			{
				TtlTypeBool = false;
                //bottomline_TitleHeader.Visible = true;
                //upline_SectionHeader.Visible = false;
				_salesDayMonthReport.CrMode = 1;
			}
			else
			{
				TtlTypeBool = true;
                //bottomline_TitleHeader.Visible = false;
                //upline_SectionHeader.Visible = false;
			}
            // 2008.12.05 30413 犬飼 罫線の印字制御を削除 <<<<<<END
            
            // 2008.08.26 30413 犬飼 出力単位別の帳票設定を変更 >>>>>>START
            ////帳票種別 0:拠点別 1:部署別 2:課別 3:地区別 4:業種別 5:担当者別 6:受注者別 7:発行者別 8:得意先別 9:地区別得意先別 10:業種別得意先別意 11:担当者別得意先別
            ////帳票種別 0:拠点別
            //if (this._salesDayMonthReport.TotalType == 0)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = NewPage.None;
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //    SectionTitle.Visible = false;
            //    SectionTitle.Text = "";
            //    SectionHeaderLine.DataField = "";
            //    SectionHeaderLine.Visible = false;

            //    //Title
            //    Lb_TitleHeader.Text = "拠点";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;

            //    //Title-Line
            //    bottomline_TitleHeader.Visible = true;
            //    upline_SectionHeader.Visible = false;

            //}
            ////帳票種別 1:部署別
            //else if (this._salesDayMonthReport.TotalType == 1)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = true;
            //    SectionTitle.Visible = true;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = true;

            //    //Title
            //    Lb_TitleHeader.Text = "部署";
            //    Lb_TitleHeader.Alignment = TextAlignment.Right;
            //    DetailLine.Alignment = TextAlignment.Right;
            //}
            ////帳票種別 2:課別
            //else if (this._salesDayMonthReport.TotalType == 2)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "WareHouseHeaderField";
            //    WareHouseHeader.Visible = true;
            //    WareHouseFooter.Visible = true;
            //    WareHouseTitle.Visible = true;
            //    WareHouseTitle.Text = "部署計";
            //    WareHouseHeaderLine.DataField = "WareHouseHeaderLine";
            //    WareHouseHeaderLine.Visible = true;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = true;
            //    SectionTitle.Visible = true;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = true;

            //    //Title
            //    Lb_TitleHeader.Text = "課";
            //    Lb_TitleHeader.Alignment = TextAlignment.Right;
            //    DetailLine.Alignment = TextAlignment.Right;
            //}
            ////帳票種別 3:地区別
            //else if (this._salesDayMonthReport.TotalType == 3)
            //{
            //    //Daily
            //    //DailyHeader.DataField = "DailyHeaderField";
            //    //DailyHeader.Visible = true;
            //    //DailyFooter.Visible = true;
            //    //DailyTitle.Visible = true;
            //    //DailyTitle.Text = "地区計";

            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "地区";
            //    Lb_TitleHeader.Alignment = TextAlignment.Right;
            //    DetailLine.Alignment = TextAlignment.Right;
            //}
            ////帳票種別 4:業種別
            //else if (this._salesDayMonthReport.TotalType == 4)
            //{
            //    //Daily
            //    //DailyHeader.DataField = "DailyHeaderField";
            //    //DailyHeader.Visible = true;
            //    //DailyFooter.Visible = true;
            //    //DailyTitle.Visible = true;
            //    //DailyTitle.Text = "業種計";

            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "業種";
            //    Lb_TitleHeader.Alignment = TextAlignment.Right;
            //    DetailLine.Alignment = TextAlignment.Right;
            //}
            ////帳票種別 5:担当者別
            //else if (this._salesDayMonthReport.TotalType == 5)
            //{
            //    //Daily
            //    //DailyHeader.DataField = "DailyHeaderField";
            //    //DailyHeader.Visible = true;
            //    //DailyFooter.Visible = true;
            //    //DailyTitle.Visible = true;
            //    //DailyTitle.Text = "担当者計";

            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";


            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "担当者";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}

            ////帳票種別 6:受注者別
            //else if (this._salesDayMonthReport.TotalType == 6)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "受注者";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}
            ////帳票種別 7:発行者別
            //else if (this._salesDayMonthReport.TotalType == 7)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "発行者";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}
            ////帳票種別 8:得意先別
            //else if (this._salesDayMonthReport.TotalType == 8)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "";
            //    WareHouseHeader.Visible = false;
            //    WareHouseFooter.Visible = false;
            //    WareHouseTitle.Visible = false;
            //    WareHouseTitle.Text = "";
            //    WareHouseHeaderLine.DataField = "";
            //    WareHouseHeaderLine.Visible = false;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "得意先";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}
            ////帳票種別 9:地区別得意先別
            //else if (this._salesDayMonthReport.TotalType == 9)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "WareHouseHeaderField";
            //    WareHouseHeader.Visible = true;
            //    WareHouseFooter.Visible = true;
            //    WareHouseTitle.Visible = true;
            //    WareHouseTitle.Text = "地区計";
            //    WareHouseHeaderLine.DataField = "WareHouseHeaderLine";
            //    WareHouseHeaderLine.Visible = true;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "得意先";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}

            ////帳票種別 10:業種別得意先別
            //else if (this._salesDayMonthReport.TotalType == 10)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "WareHouseHeaderField";
            //    WareHouseHeader.Visible = true;
            //    WareHouseFooter.Visible = true;
            //    WareHouseTitle.Visible = true;
            //    WareHouseTitle.Text = "業種計";
            //    WareHouseHeaderLine.DataField = "WareHouseHeaderLine";
            //    WareHouseHeaderLine.Visible = true;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "得意先";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}
            ////帳票種別 11:担当者別得意先別
            //else if (this._salesDayMonthReport.TotalType == 11)
            //{
            //    //Daily
            //    DailyHeader.DataField = "";
            //    DailyHeader.Visible = false;
            //    DailyFooter.Visible = false;
            //    DailyTitle.Visible = false;
            //    DailyTitle.Text = "";

            //    //WareHouse
            //    WareHouseHeader.DataField = "WareHouseHeaderField";
            //    WareHouseHeader.Visible = true;
            //    WareHouseFooter.Visible = true;
            //    WareHouseTitle.Visible = true;
            //    WareHouseTitle.Text = "担当者計";
            //    WareHouseHeaderLine.DataField = "WareHouseHeaderLine";
            //    WareHouseHeaderLine.Visible = true;

            //    //Section
            //    SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
            //    SectionHeader.DataField = "SectionHeaderField";
            //    SectionHeader.Visible = true;
            //    SectionFooter.Visible = TtlTypeBool;
            //    SectionTitle.Visible = TtlTypeBool;
            //    SectionTitle.Text = "拠点計";
            //    SectionHeaderLine.DataField = "SectionHeaderLine";
            //    SectionHeaderLine.Visible = TtlTypeBool;

            //    //Title
            //    Lb_TitleHeader.Text = "得意先";
            //    Lb_TitleHeader.Alignment = TextAlignment.Left;
            //    DetailLine.Alignment = TextAlignment.Left;
            //}

            // 出力単位別
            switch (this._salesDayMonthReport.TotalType)
            {
                case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:              // 販売区分
                    {
                        //Title
                        Lb_TitleHeader.DataField = "販売区分";
                        Lb_TitleHeader.Alignment = TextAlignment.Left;
                        DetailLine.Alignment = TextAlignment.Left;

                        if ((this._salesDayMonthReport.TtlType == 1))
                        {
                            // 集計方法が「拠点毎」
                            //Section
                            SectionHeader.NewPage = (NewPage)_salesDayMonthReport.CrMode;
                            SectionHeader.Visible = true;
                            SectionFooter.Visible = TtlTypeBool;
                            SectionTitle.Visible = TtlTypeBool;
                            SectionTitle.Text = "拠点計";
                            SectionHeaderLine.Visible = TtlTypeBool;
                        }
                        
                        break;
                    }
            }
            // 2008.08.26 30413 犬飼 出力単位別の帳票設定を変更 <<<<<<END

            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 ----->>>>>
            if (this._salesDayMonthReport.LineMaSqOfChDiv == 1)
            {
                line4.Visible = true;
                upline_SectionHeader.Visible = false;
                line2.Visible = false;
                line3.Visible = false;
                Line.Visible = false;
                Line45.Visible = false;
                Line43.Visible = false;
            }
            else
            {
                line4.Visible = false ;
                upline_SectionHeader.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
                Line.Visible = true;
                Line45.Visible = true;
                Line43.Visible = true;
            }
            // ----- ADD zhuhh 2012/12/28 for Redmine #34098 -----<<<<<

            // ADD 2009/05/20 ------>>>
            // 拠点計印字の場合は、総合計の売上目標を拠点計の合計とする
            // ----- ADD 2012/04/16 xupz for redmine#29135---------->>>>>
            //redmine#29135 集計方法が拠点毎、かつ、拠点計印字の場合は、総合計の売上目標を拠点計の合計とする。集計方法が全社の場合、上記の処理は行わない
            if(this._salesDayMonthReport.TtlType != 0)
            // ----- ADD 2012/04/16 xupz for redmine#29135----------<<<<<
            {
                switch (this._salesDayMonthReport.TotalType)
                {
                    case (int)SalesDayMonthReport.TotalTypeState.SalesDiv:              // 販売区分
                        {
                            // 販売区分は、ソート順が無い
                            s_MonthSalesTargetMoney.DataField = "SectionTargetMoney";
                            s_MonthSalesTargetProfit.DataField = "SectionTargetProfit";
                            g_MonthSalesTargetMoney.DataField = "SectionTargetMoney";
                            g_MonthSalesTargetProfit.DataField = "SectionTargetProfit";
                            break;
                        }
                }
            }
            // ADD 2009/05/20 ------<<<
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
			    if ( this._salesDayMonthReport.StockMoveFormalDiv == SalesDayMonthReport.StockMoveFormalDivState.StockMove )
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
			//string sectionTitle = string.Format("{0}拠点：", this._salesDayMonthReport.MainExtractTitle);
			//if ( this._salesDayMonthReport.IsOptSection )
			//{
				if ( this._salesDayMonthReport.IsSelectAllSection )
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
        /// <br>Update Note : 2014/12/04 周洋</br>
        /// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // 2008.12.05 30413 犬飼 コード"0000"は非表示 >>>>>>START
            if (DetailLine.Value.ToString() == "0000")
            {
                // 非表示とする
                DetailLine.Visible = false;
                DetailLineName.Visible = false;
            }
            else
            {
                // 表示とする
                DetailLine.Visible = true;
                DetailLineName.Visible = true;
            }
            // 2008.12.05 30413 犬飼 コード"0000"は非表示 <<<<<<END

            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
            //TextBox[] arrDetail = new TextBox[] { StckPriceDayTotal, StckPriceMonthTotal, textBox13, textBox14, textBox28, NetStcPrcDayTotal, NetStcPrcMonthTotal, textBox52 };
            //foreach (TextBox i in arrDetail)
            //{
            //    if (i.Text.Length == 13)
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    else
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //}
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
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
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
            // ADD 2009/04/06 ------>>>
            // 日計の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { StckPriceDayTotal, RetGdsDayTotal, DisDayTotal, textBox13, NetStcPrcDayTotal });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> mList = new List<TextBox>();
            mList.AddRange(new TextBox[] { StckPriceMonthTotal, RetGdsMonthTotal, DisDayMonthTotal, textBox14, textBox28, NetStcPrcMonthTotal, textBox52 });
            PriceUnitCalc(mList);
            // ADD 2009/04/06 ------<<<

            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            TextBox[] arrDetail = new TextBox[] { StckPriceDayTotal, StckPriceMonthTotal, textBox13, textBox14, textBox28, NetStcPrcDayTotal, NetStcPrcMonthTotal, textBox52 };
            foreach (TextBox i in arrDetail)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else if (i.Text.Length >= 14)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
            }
            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<

			// グループサプレスの判断
			this.CheckGroupSuppression();
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
        /// <br>Update Note : 2012/05/22 李亜博</br>
        /// <br>管理番号    : 10801804-00 06/27配信分</br>
        ///                   Redmine#29908   売上日報月報 粗利率の不正表示</br> 
        /// <br>Update Note : 2014/12/04 周洋</br>
        /// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
		{
			//月次売上達成率
			if (double.Parse(this.d_MonthSalesTargetMoney.Value.ToString()) == 0)
			{
				d_MonthTargetSalesRate.Value = 0;
			}
			else
			{
				d_MonthTargetSalesRate.Value = double.Parse(this.d_MonthTotalCost.Value.ToString()) * 100 / double.Parse(this.d_MonthSalesTargetMoney.Value.ToString());
			}

			//返品率
			if (double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				d_TermSalesBackTotalTaxRate.Value = 0;
			}
			else
			{
				d_TermSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.d_TermSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString()));
			}

			if (double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				d_MonthSalesBackTotalTaxRate.Value = 0;
			}
			else
			{
				d_MonthSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.d_MonthSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString()));
			}

			//粗利率
            //if (double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
            if (double.Parse(this.d_TermTotalCost.Value.ToString())==0)//ADD 2012/05/22 李亜博 Redmine#29908
			{
				d_TermProfitRate.Value = 0;
			}
			else
			{
				d_TermProfitRate.Value = double.Parse(this.d_TermProfit.Value.ToString()) * 100 / double.Parse(this.d_TermTotalCost.Value.ToString());
			}

            //if (double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
            if (double.Parse(this.d_MonthTotalCost.Value.ToString())==0)//ADD 2012/05/22 李亜博 Redmine#29908
			{
				d_MonthProfitRate.Value = 0;
			}
			else
			{
				d_MonthProfitRate.Value = double.Parse(this.d_MonthProfit.Value.ToString()) * 100 / double.Parse(this.d_MonthTotalCost.Value.ToString());
			}

			//月次粗利達成率
			if (double.Parse(this.d_MonthSalesTargetProfit.Value.ToString()) == 0)
			{
				d_MonthTargetProfitRate.Value = 0;
			}
			else
			{
				d_MonthTargetProfitRate.Value = double.Parse(this.d_MonthProfit.Value.ToString()) * 100 / double.Parse(this.d_MonthSalesTargetProfit.Value.ToString());
			}

            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
            //TextBox[] arrDaily = new TextBox[] { d_TermSalesTotalTaxExc, d_MonthSalesTotalTaxExc, d_TermTotalCost, d_MonthTotalCost, d_MonthSalesTargetMoney, d_TermProfit, d_MonthProfit, d_MonthSalesTargetProfit };
            //foreach (TextBox i in arrDaily)
            //{
            //    if (i.Text.Length == 13)
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    else
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //}
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
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
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2008.12.10 30413 ページフッターは独自とする >>>>>>START
            // フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
                //// インスタンスが作成されていなければ作成
                //if ( _rptPageFooter == null)
                //{
                //    _rptPageFooter = new ListCommon_PageFooter();
                //}
                //else
                //{
                //    // インスタンスが作成されていれば、データソースを初期化する
                //    // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
                //    _rptPageFooter.DataSource = null;
                //}
		
                //// フッター印字項目設定
                //if (this._pageFooters[0] != null)
                //{
                //    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                //}
                //if (this._pageFooters[1] != null)
                //{
                //    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                //}
			
                //this.Footer_SubReport.Report = _rptPageFooter;

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
            // 2008.12.10 30413 ページフッターは独自とする <<<<<<END
        }
		#endregion

		#endregion ■ Control Event

        /// <summary>
        /// WareHouseFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2012/05/22 李亜博</br>
        /// <br>管理番号    : 10801804-00 06/27配信分</br>
        ///                   Redmine#29908   売上日報月報 粗利率の不正表示</br> 
        /// <br>Update Note : 2014/12/04 周洋</br>
        /// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        /// </remarks>
        private void WareHouseFooter_Format(object sender, System.EventArgs eArgs)
        {
            //月次売上達成率
            if (double.Parse(this.w_MonthSalesTargetMoney.Value.ToString()) == 0)
            {
                w_MonthTargetSalesRate.Value = 0;
            }
            else
            {
                w_MonthTargetSalesRate.Value = double.Parse(this.w_MonthTotalCost.Value.ToString()) * 100 / double.Parse(this.w_MonthSalesTargetMoney.Value.ToString());
            }

            //返品率
            if (double.Parse(this.w_TermSalesTotalTaxExc.Value.ToString()) == 0)
            {
                w_TermSalesBackTotalTaxRate.Value = 0;
            }
            else
            {
                w_TermSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.w_TermSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.w_TermSalesTotalTaxExc.Value.ToString()));
            }

            if (double.Parse(this.w_MonthSalesTotalTaxExc.Value.ToString()) == 0)
            {
                w_MonthSalesBackTotalTaxRate.Value = 0;
            }
            else
            {
                w_MonthSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.w_MonthSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.w_MonthSalesTotalTaxExc.Value.ToString()));
            }

            //粗利率
            //if (double.Parse(this.w_TermSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
            if (double.Parse(this.w_TermTotalCost.Value.ToString()) == 0)//ADD 2012/05/22 李亜博 Redmine#29908
            {
                w_TermProfitRate.Value = 0;
            }
            else
            {
                w_TermProfitRate.Value = double.Parse(this.w_TermProfit.Value.ToString()) * 100 / double.Parse(this.w_TermTotalCost.Value.ToString());
            }

            //if (double.Parse(this.w_MonthSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
            if (double.Parse(this.w_MonthTotalCost.Value.ToString()) == 0)//ADD 2012/05/22 李亜博 Redmine#29908
            {
                w_MonthProfitRate.Value = 0;
            }
            else
            {
                w_MonthProfitRate.Value = double.Parse(this.w_MonthProfit.Value.ToString()) * 100 / double.Parse(this.w_MonthTotalCost.Value.ToString());
            }

            //月次粗利達成率
            if (double.Parse(this.w_MonthSalesTargetProfit.Value.ToString()) == 0)
            {
                w_MonthTargetProfitRate.Value = 0;
            }
            else
            {
                w_MonthTargetProfitRate.Value = double.Parse(this.w_MonthProfit.Value.ToString()) * 100 / double.Parse(this.w_MonthSalesTargetProfit.Value.ToString());
            }

            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
            //TextBox[] arrWareHouse = new TextBox[] { w_TermSalesTotalTaxExc, w_MonthSalesTotalTaxExc, w_TermTotalCost, w_MonthTotalCost, w_MonthSalesTargetMoney, w_TermProfit, w_MonthProfit, w_MonthSalesTargetProfit };
            //foreach (TextBox i in arrWareHouse)
            //{
            //    if (i.Text.Length == 13)
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    else
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //}
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        /// <summary>
        /// SectionFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2012/05/22 李亜博</br>
        /// <br>管理番号    : 10801804-00 06/27配信分</br>
        ///                   Redmine#29908   売上日報月報 粗利率の不正表示</br> 
        /// <br>Update Note : 2014/12/04 周洋</br>
        /// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, System.EventArgs eArgs)
        {
            //月次売上達成率
            if (double.Parse(this.s_MonthSalesTargetMoney.Value.ToString()) == 0)
            {
                s_MonthTargetSalesRate.Value = 0;
            }
            else
            {
                s_MonthTargetSalesRate.Value = double.Parse(this.s_MonthTotalCost.Value.ToString()) * 100 / double.Parse(this.s_MonthSalesTargetMoney.Value.ToString());
            }

            //返品率
            if (double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString()) == 0)
            {
                s_TermSalesBackTotalTaxRate.Value = 0;
            }
            else
            {
                s_TermSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.s_TermSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString()));
            }

            if (double.Parse(this.w_MonthSalesTotalTaxExc.Value.ToString()) == 0)
            {
                s_MonthSalesBackTotalTaxRate.Value = 0;
            }
            else
            {
                s_MonthSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.s_MonthSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.s_MonthSalesTotalTaxExc.Value.ToString()));
            }

            //粗利率
            //if (double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
            if (double.Parse(this.s_TermTotalCost.Value.ToString()) == 0)//ADD 2012/05/22 李亜博 Redmine#29908
            {
                s_TermProfitRate.Value = 0;
            }
            else
            {
                s_TermProfitRate.Value = double.Parse(this.s_TermProfit.Value.ToString()) * 100 / double.Parse(this.s_TermTotalCost.Value.ToString());
            }

            //if (double.Parse(this.s_MonthSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
            if (double.Parse(this.s_MonthTotalCost.Value.ToString()) == 0)//ADD 2012/05/22 李亜博 Redmine#29908
            {
                s_MonthProfitRate.Value = 0;
            }
            else
            {
                s_MonthProfitRate.Value = double.Parse(this.s_MonthProfit.Value.ToString()) * 100 / double.Parse(this.s_MonthTotalCost.Value.ToString());
            }

            //月次粗利達成率
            if (double.Parse(this.s_MonthSalesTargetProfit.Value.ToString()) == 0)
            {
                s_MonthTargetProfitRate.Value = 0;
            }
            else
            {
                s_MonthTargetProfitRate.Value = double.Parse(this.s_MonthProfit.Value.ToString()) * 100 / double.Parse(this.s_MonthSalesTargetProfit.Value.ToString());
            }

            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
            //TextBox[] arrSection = new TextBox[] { s_TermSalesTotalTaxExc, s_MonthSalesTotalTaxExc, s_TermTotalCost, s_MonthTotalCost, s_MonthSalesTargetMoney, s_TermProfit, s_MonthProfit, s_MonthSalesTargetProfit };
            //foreach (TextBox i in arrSection)
            //{
            //    if (i.Text.Length == 13)
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    else
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //}
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        /// <summary>
        /// GrandTotalFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Update Note : 2012/05/22 李亜博</br>
        /// <br>管理番号    : 10801804-00 06/27配信分</br>
        ///                   Redmine#29908   売上日報月報 粗利率の不正表示</br>
        /// <br>Update Note : 2014/12/04 周洋</br>
        /// <br>              Redmine#43991 №2591 金額桁数が10億と100億まで印刷されないの対応</br>
        /// <br>Update Note : 2014/12/09 周洋</br>
        /// <br>              Redmine#43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応</br>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        /// </remarks>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            //月次売上達成率
            if (double.Parse(this.g_MonthSalesTargetMoney.Value.ToString()) == 0)
            {
                g_MonthTargetSalesRate.Value = 0;
            }
            else
            {
                g_MonthTargetSalesRate.Value = double.Parse(this.g_MonthTotalCost.Value.ToString()) * 100 / double.Parse(this.g_MonthSalesTargetMoney.Value.ToString());
            }

            //返品率
            if (double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString()) == 0)
            {
                g_TermSalesBackTotalTaxRate.Value = 0;
            }
            else
            {
                g_TermSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.g_TermSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString()));
            }

            if (double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString()) == 0)
            {
                g_MonthSalesBackTotalTaxRate.Value = 0;
            }
            else
            {
                g_MonthSalesBackTotalTaxRate.Value = Math.Abs(double.Parse(this.g_MonthSalesBackTotalTaxExc.Value.ToString()) * 100 / double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString()));
            }

            //粗利率
            //if (double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
              if (double.Parse(this.g_TermTotalCost.Value.ToString()) == 0)//ADD 2012/05/22 李亜博 Redmine#29908
            {
                g_TermProfitRate.Value = 0;
            }
            else
            {
                g_TermProfitRate.Value = double.Parse(this.g_TermProfit.Value.ToString()) * 100 / double.Parse(this.g_TermTotalCost.Value.ToString());
            }

            //if (double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString()) == 0)//DEL 2012/05/22 李亜博 Redmine#29908
              if (double.Parse(this.g_MonthTotalCost.Value.ToString()) == 0)//ADD 2012/05/22 李亜博 Redmine#29908
            {
                g_MonthProfitRate.Value = 0;
            }
            else
            {
                g_MonthProfitRate.Value = double.Parse(this.g_MonthProfit.Value.ToString()) * 100 / double.Parse(this.g_MonthTotalCost.Value.ToString());
            }

            //月次粗利達成率
            if (double.Parse(this.g_MonthSalesTargetProfit.Value.ToString()) == 0)
            {
                g_MonthTargetProfitRate.Value = 0;
            }
            else
            {
                g_MonthTargetProfitRate.Value = double.Parse(this.g_MonthProfit.Value.ToString()) * 100 / double.Parse(this.g_MonthSalesTargetProfit.Value.ToString());
            }

            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応----->>>>>
            //TextBox[] arrTotal = new TextBox[] { g_TermSalesTotalTaxExc, g_MonthSalesTotalTaxExc, g_TermTotalCost, g_MonthTotalCost, g_MonthSalesTargetMoney, g_TermProfit, g_MonthProfit, g_MonthSalesTargetProfit };
            //foreach (TextBox i in arrTotal)
            //{
            //    if (i.Text.Length == 13)
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    //else if (i.Text.Length == 14)    //DEL 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    else if (i.Text.Length >= 14)    //ADD 周洋 2014/12/09 for Redmine43991の#43 1000億以上の桁になると、フォントサイズがまた大きくなりますの対応
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //    else
            //    {
            //        i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            //    }
            //}
            //// -----ADD 周洋 2014/12/04 for Redmine43991 №2591 金額桁数が10億と100億まで印刷されないの対応-----<<<<<
            // -----DEL 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        // ADD 2009/04/06 ------>>>
        /// <summary>
        /// DailyFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        private void DailyFooter_BeforePrint(object sender, EventArgs e)
        {
            // 日計の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { d_TermSalesTotalTaxExc, d_TermSalesBackTotalTaxExc, d_TermSalesDisTtlTaxExc, d_TermTotalCost, d_TermProfit });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> mList = new List<TextBox>();
            mList.AddRange(new TextBox[] { d_MonthSalesTotalTaxExc, d_MonthSalesBackTotalTaxExc, d_MonthSalesDisTtlTaxExc, d_MonthTotalCost, d_MonthSalesTargetMoney, d_MonthProfit, d_MonthSalesTargetProfit });
            PriceUnitCalc(mList);

            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            TextBox[] arrDaily = new TextBox[] { d_TermSalesTotalTaxExc, d_MonthSalesTotalTaxExc, d_TermTotalCost, d_MonthTotalCost, d_MonthSalesTargetMoney, d_TermProfit, d_MonthProfit, d_MonthSalesTargetProfit };
            foreach (TextBox i in arrDaily)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else if (i.Text.Length >= 14)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
            }
            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        /// <summary>
        /// WareHouseFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        private void WareHouseFooter_BeforePrint(object sender, EventArgs e)
        {
            // 日計の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { w_TermSalesTotalTaxExc, w_TermSalesBackTotalTaxExc, w_TermSalesDisTtlTaxExc, w_TermTotalCost, w_TermProfit });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> mList = new List<TextBox>();
            mList.AddRange(new TextBox[] { w_MonthSalesTotalTaxExc, w_MonthSalesBackTotalTaxExc, w_MonthSalesDisTtlTaxExc, w_MonthTotalCost, w_MonthSalesTargetMoney, w_MonthProfit, w_MonthSalesTargetProfit });
            PriceUnitCalc(mList);

            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            TextBox[] arrWareHouse = new TextBox[] { w_TermSalesTotalTaxExc, w_MonthSalesTotalTaxExc, w_TermTotalCost, w_MonthTotalCost, w_MonthSalesTargetMoney, w_TermProfit, w_MonthProfit, w_MonthSalesTargetProfit };
            foreach (TextBox i in arrWareHouse)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else if (i.Text.Length >= 14)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
            }
            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        /// <summary>
        /// SectionFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // 日計の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { s_TermSalesTotalTaxExc, s_TermSalesBackTotalTaxExc, s_TermSalesDisTtlTaxExc, s_TermTotalCost, s_TermProfit });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> mList = new List<TextBox>();
            mList.AddRange(new TextBox[] { s_MonthSalesTotalTaxExc, s_MonthSalesBackTotalTaxExc, s_MonthSalesDisTtlTaxExc, s_MonthTotalCost, s_MonthSalesTargetMoney, s_MonthProfit, s_MonthSalesTargetProfit });
            PriceUnitCalc(mList);

            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            TextBox[] arrSection = new TextBox[] { s_TermSalesTotalTaxExc, s_MonthSalesTotalTaxExc, s_TermTotalCost, s_MonthTotalCost, s_MonthSalesTargetMoney, s_TermProfit, s_MonthProfit, s_MonthSalesTargetProfit };
            foreach (TextBox i in arrSection)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else if (i.Text.Length >= 14)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
            }
            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <br>UpdateNote  : 2014/12/18 周洋</br>
        /// <br>              Redmine#43991の#51 金額単位「千円」で出力する不具合の対応</br>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // 日計の円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { g_TermSalesTotalTaxExc, g_TermSalesBackTotalTaxExc, g_TermSalesDisTtlTaxExc, g_TermTotalCost, g_TermProfit });
            PriceUnitCalc(dList);
            // 累計の円単位計算
            List<TextBox> mList = new List<TextBox>();
            mList.AddRange(new TextBox[] { g_MonthSalesTotalTaxExc, g_MonthSalesBackTotalTaxExc, g_MonthSalesDisTtlTaxExc, g_MonthTotalCost, g_MonthSalesTargetMoney, g_MonthProfit, g_MonthSalesTargetProfit });
            PriceUnitCalc(mList);

            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応----->>>>>
            TextBox[] arrTotal = new TextBox[] { g_TermSalesTotalTaxExc, g_MonthSalesTotalTaxExc, g_TermTotalCost, g_MonthTotalCost, g_MonthSalesTargetMoney, g_TermProfit, g_MonthProfit, g_MonthSalesTargetProfit };
            foreach (TextBox i in arrTotal)
            {
                if (i.Text.Length == 13)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.4pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else if (i.Text.Length >= 14)
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
                else
                {
                    i.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
                }
            }
            // -----ADD 周洋 2014/12/18 for Redmine43991の#51 金額単位「千円」で出力する不具合の対応-----<<<<<
        }

        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._salesDayMonthReport.MoneyUnit == 1)
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
        // ADD 2009/04/06 ------<<<

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.TextBox SortTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label Lb_TitleHeader;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
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
		private DataDynamics.ActiveReports.TextBox NetStcPrcDayTotal;
		private DataDynamics.ActiveReports.TextBox TextBox;
		private DataDynamics.ActiveReports.TextBox TextBox1;
		private DataDynamics.ActiveReports.TextBox StckPriceDayTotal;
		private DataDynamics.ActiveReports.TextBox RetGdsDayTotal;
		private DataDynamics.ActiveReports.TextBox RetGdsDayRate;
		private DataDynamics.ActiveReports.TextBox DisDayTotal;
		private DataDynamics.ActiveReports.TextBox StckPriceMonthTotal;
		private DataDynamics.ActiveReports.TextBox RetGdsMonthTotal;
		private DataDynamics.ActiveReports.TextBox RetGdsMonthRate;
		private DataDynamics.ActiveReports.TextBox DisDayMonthTotal;
		private DataDynamics.ActiveReports.TextBox DisDayMonthRate;
		private DataDynamics.ActiveReports.TextBox NetStcPrcMonthTotal;
		private DataDynamics.ActiveReports.GroupFooter DailyFooter;
		private DataDynamics.ActiveReports.GroupFooter WareHouseFooter;
		private DataDynamics.ActiveReports.TextBox WareHouseTitle;
		private DataDynamics.ActiveReports.TextBox w_TermProfit;
		private DataDynamics.ActiveReports.Line Line;
		private DataDynamics.ActiveReports.TextBox TextBox15;
		private DataDynamics.ActiveReports.TextBox TextBox16;
		private DataDynamics.ActiveReports.TextBox w_TermSalesTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox w_MonthSalesTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox w_TermSalesBackTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox w_TermSalesBackTotalTaxRate;
		private DataDynamics.ActiveReports.TextBox w_TermSalesDisTtlTaxExc;
		private DataDynamics.ActiveReports.TextBox w_MonthSalesBackTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox w_MonthSalesBackTotalTaxRate;
		private DataDynamics.ActiveReports.TextBox w_MonthSalesDisTtlTaxExc;
		private DataDynamics.ActiveReports.TextBox w_MonthTargetSalesRate;
		private DataDynamics.ActiveReports.TextBox w_MonthProfit;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SectionTitle;
		private DataDynamics.ActiveReports.TextBox s_TermProfit;
		private DataDynamics.ActiveReports.TextBox TextBox17;
		private DataDynamics.ActiveReports.TextBox TextBox18;
		private DataDynamics.ActiveReports.TextBox s_TermSalesTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox s_TermSalesBackTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox s_MonthSalesTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox s_MonthSalesBackTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox s_TermSalesBackTotalTaxRate;
		private DataDynamics.ActiveReports.TextBox s_MonthSalesBackTotalTaxRate;
		private DataDynamics.ActiveReports.TextBox s_TermSalesDisTtlTaxExc;
		private DataDynamics.ActiveReports.TextBox s_MonthSalesDisTtlTaxExc;
		private DataDynamics.ActiveReports.TextBox s_MonthTargetSalesRate;
		private DataDynamics.ActiveReports.TextBox s_MonthProfit;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotalTitle;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox g_TermProfit;
		private DataDynamics.ActiveReports.TextBox TextBox19;
		private DataDynamics.ActiveReports.TextBox TextBox20;
		private DataDynamics.ActiveReports.TextBox g_TermSalesTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox g_MonthSalesTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox g_TermSalesBackTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox g_MonthSalesBackTotalTaxExc;
		private DataDynamics.ActiveReports.TextBox g_TermSalesBackTotalTaxRate;
		private DataDynamics.ActiveReports.TextBox g_MonthSalesBackTotalTaxRate;
		private DataDynamics.ActiveReports.TextBox g_TermSalesDisTtlTaxExc;
		private DataDynamics.ActiveReports.TextBox g_MonthSalesDisTtlTaxExc;
		private DataDynamics.ActiveReports.TextBox g_MonthTargetSalesRate;
		private DataDynamics.ActiveReports.TextBox g_MonthProfit;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02012P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.DetailLine = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.StckPriceDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsDayRate = new DataDynamics.ActiveReports.TextBox();
            this.DisDayTotal = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.RetGdsMonthRate = new DataDynamics.ActiveReports.TextBox();
            this.DisDayMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.DisDayMonthRate = new DataDynamics.ActiveReports.TextBox();
            this.NetStcPrcMonthTotal = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.DetailLineName = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.SortTitle = new DataDynamics.ActiveReports.TextBox();
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
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Lb_StockUnitPrice = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Lb_ProDuctNumber = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.g_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.g_TermProfit = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox20 = new DataDynamics.ActiveReports.TextBox();
            this.g_TermSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_TermSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_TermSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.g_TermSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthTargetSalesRate = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthProfit = new DataDynamics.ActiveReports.TextBox();
            this.g_TermTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesTargetMoney = new DataDynamics.ActiveReports.TextBox();
            this.g_TermProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthTargetProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.g_MonthSalesTargetProfit = new DataDynamics.ActiveReports.TextBox();
            this.textBox39 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionHeaderLine = new DataDynamics.ActiveReports.TextBox();
            this.upline_SectionHeader = new DataDynamics.ActiveReports.Line();
            this.SectionHeaderLineName = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeaderLineTitle = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.s_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.s_TermProfit = new DataDynamics.ActiveReports.TextBox();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.s_TermSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_TermSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_TermSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.s_TermSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthTargetSalesRate = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthProfit = new DataDynamics.ActiveReports.TextBox();
            this.s_TermTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesTargetMoney = new DataDynamics.ActiveReports.TextBox();
            this.s_TermProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthTargetProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.s_MonthSalesTargetProfit = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WareHouseHeaderLine = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseHeaderLineName = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.w_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.WareHouseTitle = new DataDynamics.ActiveReports.TextBox();
            this.w_TermProfit = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.w_TermSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.w_TermSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.w_TermSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.w_TermSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthTargetSalesRate = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthProfit = new DataDynamics.ActiveReports.TextBox();
            this.w_TermTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthSalesTargetMoney = new DataDynamics.ActiveReports.TextBox();
            this.w_TermProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthTargetProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.w_MonthSalesTargetProfit = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.DailyHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DailyFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.d_MonthTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.DailyTitle = new DataDynamics.ActiveReports.TextBox();
            this.d_TermProfit = new DataDynamics.ActiveReports.TextBox();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.d_TermSalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_TermSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_TermSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.d_TermSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesBackTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesBackTotalTaxRate = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesDisTtlTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthTargetSalesRate = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthProfit = new DataDynamics.ActiveReports.TextBox();
            this.d_TermTotalCost = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesTargetMoney = new DataDynamics.ActiveReports.TextBox();
            this.d_TermProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthTargetProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.d_MonthSalesTargetProfit = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ProDuctNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTargetSalesRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesTargetMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTargetProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesTargetProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTargetSalesRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesTargetMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTargetProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesTargetProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseHeaderLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseHeaderLineName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthTargetSalesRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesTargetMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthTargetProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesTargetProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesBackTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesBackTotalTaxRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesDisTtlTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTargetSalesRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermTotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesTargetMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTargetProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesTargetProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox14,
            this.StckPriceMonthTotal,
            this.DetailLine,
            this.NetStcPrcDayTotal,
            this.TextBox,
            this.TextBox1,
            this.StckPriceDayTotal,
            this.RetGdsDayTotal,
            this.RetGdsDayRate,
            this.DisDayTotal,
            this.RetGdsMonthTotal,
            this.RetGdsMonthRate,
            this.DisDayMonthTotal,
            this.DisDayMonthRate,
            this.NetStcPrcMonthTotal,
            this.textBox13,
            this.textBox28,
            this.textBox35,
            this.textBox36,
            this.textBox44,
            this.textBox52,
            this.DetailLineName,
            this.textBox25,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox7,
            this.textBox8,
            this.line2});
            this.Detail.Height = 0.34375F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightColor = System.Drawing.Color.Black;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopColor = System.Drawing.Color.Black;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DataField = "MonthPureSalesTotalCost";
            this.textBox14.Height = 0.125F;
            this.textBox14.Left = 5.875F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox14.Text = "1,234,567,890";
            this.textBox14.Top = 0.125F;
            this.textBox14.Width = 0.76F;
            // 
            // StckPriceMonthTotal
            // 
            this.StckPriceMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceMonthTotal.DataField = "MonthSalesNetPrice";
            this.StckPriceMonthTotal.Height = 0.125F;
            this.StckPriceMonthTotal.Left = 3F;
            this.StckPriceMonthTotal.MultiLine = false;
            this.StckPriceMonthTotal.Name = "StckPriceMonthTotal";
            this.StckPriceMonthTotal.OutputFormat = resources.GetString("StckPriceMonthTotal.OutputFormat");
            this.StckPriceMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.StckPriceMonthTotal.Text = "1,234,567,890";
            this.StckPriceMonthTotal.Top = 0.125F;
            this.StckPriceMonthTotal.Width = 0.76F;
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
            this.DetailLine.Height = 0.125F;
            this.DetailLine.Left = 0F;
            this.DetailLine.MultiLine = false;
            this.DetailLine.Name = "DetailLine";
            this.DetailLine.OutputFormat = resources.GetString("DetailLine.OutputFormat");
            this.DetailLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.DetailLine.Text = "12345678";
            this.DetailLine.Top = 0F;
            this.DetailLine.Width = 0.5F;
            // 
            // NetStcPrcDayTotal
            // 
            this.NetStcPrcDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcDayTotal.DataField = "TermProfit";
            this.NetStcPrcDayTotal.Height = 0.125F;
            this.NetStcPrcDayTotal.Left = 8.0625F;
            this.NetStcPrcDayTotal.MultiLine = false;
            this.NetStcPrcDayTotal.Name = "NetStcPrcDayTotal";
            this.NetStcPrcDayTotal.OutputFormat = resources.GetString("NetStcPrcDayTotal.OutputFormat");
            this.NetStcPrcDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.NetStcPrcDayTotal.Text = "123,546,789";
            this.NetStcPrcDayTotal.Top = 0F;
            this.NetStcPrcDayTotal.Width = 0.76F;
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Height = 0.125F;
            this.TextBox.Left = 2.625F;
            this.TextBox.MultiLine = false;
            this.TextBox.Name = "TextBox";
            this.TextBox.OutputFormat = resources.GetString("TextBox.OutputFormat");
            this.TextBox.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox.Text = "日計";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.3125F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Height = 0.125F;
            this.TextBox1.Left = 2.625F;
            this.TextBox1.MultiLine = false;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox1.Text = "累計";
            this.TextBox1.Top = 0.125F;
            this.TextBox1.Width = 0.3125F;
            // 
            // StckPriceDayTotal
            // 
            this.StckPriceDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.StckPriceDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.StckPriceDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.StckPriceDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.StckPriceDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckPriceDayTotal.DataField = "TermSalesNetPrice";
            this.StckPriceDayTotal.Height = 0.125F;
            this.StckPriceDayTotal.Left = 3F;
            this.StckPriceDayTotal.MultiLine = false;
            this.StckPriceDayTotal.Name = "StckPriceDayTotal";
            this.StckPriceDayTotal.OutputFormat = resources.GetString("StckPriceDayTotal.OutputFormat");
            this.StckPriceDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.StckPriceDayTotal.Text = "1,234,567,890";
            this.StckPriceDayTotal.Top = 0F;
            this.StckPriceDayTotal.Width = 0.76F;
            // 
            // RetGdsDayTotal
            // 
            this.RetGdsDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayTotal.DataField = "TermSalesBackNetPrice";
            this.RetGdsDayTotal.Height = 0.125F;
            this.RetGdsDayTotal.Left = 3.8125F;
            this.RetGdsDayTotal.MultiLine = false;
            this.RetGdsDayTotal.Name = "RetGdsDayTotal";
            this.RetGdsDayTotal.OutputFormat = resources.GetString("RetGdsDayTotal.OutputFormat");
            this.RetGdsDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.RetGdsDayTotal.Text = "123,546,789";
            this.RetGdsDayTotal.Top = 0F;
            this.RetGdsDayTotal.Width = 0.6875F;
            // 
            // RetGdsDayRate
            // 
            this.RetGdsDayRate.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsDayRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayRate.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsDayRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayRate.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsDayRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayRate.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsDayRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsDayRate.DataField = "TermSalesBackTotalTaxRate";
            this.RetGdsDayRate.Height = 0.125F;
            this.RetGdsDayRate.Left = 4.5625F;
            this.RetGdsDayRate.MultiLine = false;
            this.RetGdsDayRate.Name = "RetGdsDayRate";
            this.RetGdsDayRate.OutputFormat = resources.GetString("RetGdsDayRate.OutputFormat");
            this.RetGdsDayRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.RetGdsDayRate.Text = "123,45";
            this.RetGdsDayRate.Top = 0F;
            this.RetGdsDayRate.Width = 0.375F;
            // 
            // DisDayTotal
            // 
            this.DisDayTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotal.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotal.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayTotal.DataField = "TermSalesDisTtlTaxExc";
            this.DisDayTotal.Height = 0.125F;
            this.DisDayTotal.Left = 5.125F;
            this.DisDayTotal.MultiLine = false;
            this.DisDayTotal.Name = "DisDayTotal";
            this.DisDayTotal.OutputFormat = resources.GetString("DisDayTotal.OutputFormat");
            this.DisDayTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.DisDayTotal.Text = "123,546,789";
            this.DisDayTotal.Top = 0F;
            this.DisDayTotal.Width = 0.6875F;
            // 
            // RetGdsMonthTotal
            // 
            this.RetGdsMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthTotal.DataField = "MonthSalesBackNetPrice";
            this.RetGdsMonthTotal.Height = 0.125F;
            this.RetGdsMonthTotal.Left = 3.8125F;
            this.RetGdsMonthTotal.MultiLine = false;
            this.RetGdsMonthTotal.Name = "RetGdsMonthTotal";
            this.RetGdsMonthTotal.OutputFormat = resources.GetString("RetGdsMonthTotal.OutputFormat");
            this.RetGdsMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.RetGdsMonthTotal.Text = "123,546,789";
            this.RetGdsMonthTotal.Top = 0.125F;
            this.RetGdsMonthTotal.Width = 0.6875F;
            // 
            // RetGdsMonthRate
            // 
            this.RetGdsMonthRate.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGdsMonthRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthRate.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGdsMonthRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthRate.Border.RightColor = System.Drawing.Color.Black;
            this.RetGdsMonthRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthRate.Border.TopColor = System.Drawing.Color.Black;
            this.RetGdsMonthRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGdsMonthRate.DataField = "MonthSalesBackTotalTaxRate";
            this.RetGdsMonthRate.Height = 0.125F;
            this.RetGdsMonthRate.Left = 4.5625F;
            this.RetGdsMonthRate.MultiLine = false;
            this.RetGdsMonthRate.Name = "RetGdsMonthRate";
            this.RetGdsMonthRate.OutputFormat = resources.GetString("RetGdsMonthRate.OutputFormat");
            this.RetGdsMonthRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.RetGdsMonthRate.Text = "123,45";
            this.RetGdsMonthRate.Top = 0.125F;
            this.RetGdsMonthRate.Width = 0.375F;
            // 
            // DisDayMonthTotal
            // 
            this.DisDayMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthTotal.DataField = "MonthSalesDisTtlTaxExc";
            this.DisDayMonthTotal.Height = 0.125F;
            this.DisDayMonthTotal.Left = 5.125F;
            this.DisDayMonthTotal.MultiLine = false;
            this.DisDayMonthTotal.Name = "DisDayMonthTotal";
            this.DisDayMonthTotal.OutputFormat = resources.GetString("DisDayMonthTotal.OutputFormat");
            this.DisDayMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.DisDayMonthTotal.Text = "123,546,789";
            this.DisDayMonthTotal.Top = 0.125F;
            this.DisDayMonthTotal.Width = 0.6875F;
            // 
            // DisDayMonthRate
            // 
            this.DisDayMonthRate.Border.BottomColor = System.Drawing.Color.Black;
            this.DisDayMonthRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthRate.Border.LeftColor = System.Drawing.Color.Black;
            this.DisDayMonthRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthRate.Border.RightColor = System.Drawing.Color.Black;
            this.DisDayMonthRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthRate.Border.TopColor = System.Drawing.Color.Black;
            this.DisDayMonthRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DisDayMonthRate.DataField = "MonthTargetSalesRate";
            this.DisDayMonthRate.Height = 0.125F;
            this.DisDayMonthRate.Left = 7.5F;
            this.DisDayMonthRate.MultiLine = false;
            this.DisDayMonthRate.Name = "DisDayMonthRate";
            this.DisDayMonthRate.OutputFormat = resources.GetString("DisDayMonthRate.OutputFormat");
            this.DisDayMonthRate.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.DisDayMonthRate.Text = "123,45";
            this.DisDayMonthRate.Top = 0.125F;
            this.DisDayMonthRate.Width = 0.375F;
            // 
            // NetStcPrcMonthTotal
            // 
            this.NetStcPrcMonthTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotal.Border.RightColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotal.Border.TopColor = System.Drawing.Color.Black;
            this.NetStcPrcMonthTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.NetStcPrcMonthTotal.DataField = "MonthProfit";
            this.NetStcPrcMonthTotal.Height = 0.125F;
            this.NetStcPrcMonthTotal.Left = 8.0625F;
            this.NetStcPrcMonthTotal.MultiLine = false;
            this.NetStcPrcMonthTotal.Name = "NetStcPrcMonthTotal";
            this.NetStcPrcMonthTotal.OutputFormat = resources.GetString("NetStcPrcMonthTotal.OutputFormat");
            this.NetStcPrcMonthTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.NetStcPrcMonthTotal.Text = "123,546,789";
            this.NetStcPrcMonthTotal.Top = 0.125F;
            this.NetStcPrcMonthTotal.Width = 0.76F;
            // 
            // textBox13
            // 
            this.textBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.RightColor = System.Drawing.Color.Black;
            this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.Border.TopColor = System.Drawing.Color.Black;
            this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox13.DataField = "TermPureSalesTotalCost";
            this.textBox13.Height = 0.125F;
            this.textBox13.Left = 5.875F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox13.Text = "1,234,567,890";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.76F;
            // 
            // textBox28
            // 
            this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.RightColor = System.Drawing.Color.Black;
            this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.TopColor = System.Drawing.Color.Black;
            this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.DataField = "MonthSalesTargetMoney";
            this.textBox28.Height = 0.125F;
            this.textBox28.Left = 6.6875F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox28.Text = "1,234,567,890";
            this.textBox28.Top = 0.125F;
            this.textBox28.Width = 0.76F;
            // 
            // textBox35
            // 
            this.textBox35.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.RightColor = System.Drawing.Color.Black;
            this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.TopColor = System.Drawing.Color.Black;
            this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.DataField = "TermProfitRate";
            this.textBox35.Height = 0.125F;
            this.textBox35.Left = 8.875F;
            this.textBox35.MultiLine = false;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox35.Text = "123,45";
            this.textBox35.Top = 0F;
            this.textBox35.Width = 0.375F;
            // 
            // textBox36
            // 
            this.textBox36.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.RightColor = System.Drawing.Color.Black;
            this.textBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.TopColor = System.Drawing.Color.Black;
            this.textBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.DataField = "MonthProfitRate";
            this.textBox36.Height = 0.125F;
            this.textBox36.Left = 8.875F;
            this.textBox36.MultiLine = false;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox36.Text = "123,45";
            this.textBox36.Top = 0.125F;
            this.textBox36.Width = 0.375F;
            // 
            // textBox44
            // 
            this.textBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.RightColor = System.Drawing.Color.Black;
            this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.TopColor = System.Drawing.Color.Black;
            this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.DataField = "MonthTargetProfitRate";
            this.textBox44.Height = 0.125F;
            this.textBox44.Left = 10.25F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox44.Text = "123,45";
            this.textBox44.Top = 0.125F;
            this.textBox44.Width = 0.375F;
            // 
            // textBox52
            // 
            this.textBox52.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.RightColor = System.Drawing.Color.Black;
            this.textBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.TopColor = System.Drawing.Color.Black;
            this.textBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.DataField = "MonthSalesTargetProfit";
            this.textBox52.Height = 0.125F;
            this.textBox52.Left = 9.427F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox52.Text = "123,546,789";
            this.textBox52.Top = 0.125F;
            this.textBox52.Width = 0.76F;
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
            this.DetailLineName.Height = 0.125F;
            this.DetailLineName.Left = 0.5625F;
            this.DetailLineName.MultiLine = false;
            this.DetailLineName.Name = "DetailLineName";
            this.DetailLineName.OutputFormat = resources.GetString("DetailLineName.OutputFormat");
            this.DetailLineName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.DetailLineName.Text = "名称３４５６７８９０１２３４５";
            this.DetailLineName.Top = 0F;
            this.DetailLineName.Width = 1.75F;
            // 
            // textBox25
            // 
            this.textBox25.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.RightColor = System.Drawing.Color.Black;
            this.textBox25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Border.TopColor = System.Drawing.Color.Black;
            this.textBox25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox25.Height = 0.125F;
            this.textBox25.Left = 4.9375F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox25.Text = "%";
            this.textBox25.Top = 0F;
            this.textBox25.Width = 0.125F;
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
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 4.9375F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox2.Text = "%";
            this.textBox2.Top = 0.125F;
            this.textBox2.Width = 0.125F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 7.875F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox3.Text = "%";
            this.textBox3.Top = 0.125F;
            this.textBox3.Width = 0.125F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 9.25F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox4.Text = "%";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.125F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 9.25F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox7.Text = "%";
            this.textBox7.Top = 0.125F;
            this.textBox7.Width = 0.125F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 10.625F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox8.Text = "%";
            this.textBox8.Top = 0.125F;
            this.textBox8.Width = 0.125F;
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
            this.line2.Width = 10.9F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.9F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
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
            this.tb_ReportTitle,
            this.SortTitle});
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
            this.Line1.Width = 10.9F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.9F;
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
            this.tb_ReportTitle.Text = "販売区分別 売上日報月報";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // SortTitle
            // 
            this.SortTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SortTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SortTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SortTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SortTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SortTitle.Height = 0.125F;
            this.SortTitle.Left = 4.75F;
            this.SortTitle.Name = "SortTitle";
            this.SortTitle.Style = "font-size: 8pt; vertical-align: top; ";
            this.SortTitle.Text = "[拠点 コード順/カナ順]";
            this.SortTitle.Top = 0.06299213F;
            this.SortTitle.Width = 1.722F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line_PageFooter,
            this.PageFooters0,
            this.PageFooters1});
            this.PageFooter.Height = 0.21875F;
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
            this.Line_PageFooter.Width = 10.9F;
            this.Line_PageFooter.X1 = 0F;
            this.Line_PageFooter.X2 = 10.9F;
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
            this.PageFooters1.Left = 7.875F;
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
            this.Label5,
            this.Lb_StockUnitPrice,
            this.Label7,
            this.Label8,
            this.Lb_ProDuctNumber,
            this.label6,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.line4});
            this.TitleHeader.Height = 0.3020833F;
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
            this.Line42.Width = 10.9F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.9F;
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
            this.Lb_TitleHeader.Height = 0.1875F;
            this.Lb_TitleHeader.HyperLink = "";
            this.Lb_TitleHeader.Left = 0F;
            this.Lb_TitleHeader.MultiLine = false;
            this.Lb_TitleHeader.Name = "Lb_TitleHeader";
            this.Lb_TitleHeader.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_TitleHeader.Text = "販売区分";
            this.Lb_TitleHeader.Top = 0F;
            this.Lb_TitleHeader.Width = 0.5625F;
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
            this.Label4.Height = 0.1875F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 9.427F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label4.Text = "粗利目標";
            this.Label4.Top = 0F;
            this.Label4.Width = 0.76F;
            // 
            // Label5
            // 
            this.Label5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.RightColor = System.Drawing.Color.Black;
            this.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.TopColor = System.Drawing.Color.Black;
            this.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Height = 0.1875F;
            this.Label5.HyperLink = "";
            this.Label5.Left = 7.51F;
            this.Label5.MultiLine = false;
            this.Label5.Name = "Label5";
            this.Label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label5.Text = "達成率";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.4375F;
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
            this.Lb_StockUnitPrice.Height = 0.1875F;
            this.Lb_StockUnitPrice.HyperLink = "";
            this.Lb_StockUnitPrice.Left = 5.125F;
            this.Lb_StockUnitPrice.MultiLine = false;
            this.Lb_StockUnitPrice.Name = "Lb_StockUnitPrice";
            this.Lb_StockUnitPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_StockUnitPrice.Text = "値引";
            this.Lb_StockUnitPrice.Top = 0F;
            this.Lb_StockUnitPrice.Width = 0.6875F;
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
            this.Label7.Height = 0.1875F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 3F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label7.Text = "売上";
            this.Label7.Top = 0F;
            this.Label7.Width = 0.76F;
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
            this.Label8.Height = 0.1875F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 3.813F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label8.Text = "返品";
            this.Label8.Top = 0F;
            this.Label8.Width = 0.6875F;
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
            this.Lb_ProDuctNumber.Height = 0.1875F;
            this.Lb_ProDuctNumber.HyperLink = "";
            this.Lb_ProDuctNumber.Left = 4.573F;
            this.Lb_ProDuctNumber.MultiLine = false;
            this.Lb_ProDuctNumber.Name = "Lb_ProDuctNumber";
            this.Lb_ProDuctNumber.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Lb_ProDuctNumber.Text = "返品率";
            this.Lb_ProDuctNumber.Top = 0F;
            this.Lb_ProDuctNumber.Width = 0.4375F;
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
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = "";
            this.label6.Left = 5.875F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label6.Text = "純売上";
            this.label6.Top = 0F;
            this.label6.Width = 0.76F;
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
            this.label9.Height = 0.1875F;
            this.label9.HyperLink = "";
            this.label9.Left = 6.688F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label9.Text = "売上目標";
            this.label9.Top = 0F;
            this.label9.Width = 0.76F;
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
            this.label10.Left = 8.0625F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label10.Text = "粗利";
            this.label10.Top = 0F;
            this.label10.Width = 0.76F;
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
            this.label11.Left = 8.885F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label11.Text = "粗利率";
            this.label11.Top = 0F;
            this.label11.Width = 0.4375F;
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
            this.label12.Left = 10.26F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label12.Text = "達成率";
            this.label12.Top = 0F;
            this.label12.Width = 0.4375F;
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
            this.line4.Top = 0.1889764F;
            this.line4.Width = 10.9F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.9F;
            this.line4.Y1 = 0.1889764F;
            this.line4.Y2 = 0.1889764F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0.04166667F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            this.TitleFooter.Format += new System.EventHandler(this.TitleFooter_Format);
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
            this.Line41.Width = 10.9F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 10.9F;
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
            this.g_MonthTotalCost,
            this.g_MonthSalesTotalTaxExc,
            this.GrandTotalTitle,
            this.Line43,
            this.g_TermProfit,
            this.TextBox19,
            this.TextBox20,
            this.g_TermSalesTotalTaxExc,
            this.g_TermSalesBackTotalTaxExc,
            this.g_MonthSalesBackTotalTaxExc,
            this.g_TermSalesBackTotalTaxRate,
            this.g_MonthSalesBackTotalTaxRate,
            this.g_TermSalesDisTtlTaxExc,
            this.g_MonthSalesDisTtlTaxExc,
            this.g_MonthTargetSalesRate,
            this.g_MonthProfit,
            this.g_TermTotalCost,
            this.g_MonthSalesTargetMoney,
            this.g_TermProfitRate,
            this.g_MonthProfitRate,
            this.g_MonthTargetProfitRate,
            this.g_MonthSalesTargetProfit,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox34});
            this.GrandTotalFooter.Height = 0.34375F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.g_MonthTotalCost.DataField = "MonthPureSalesTotalCost";
            this.g_MonthTotalCost.Height = 0.125F;
            this.g_MonthTotalCost.Left = 5.875F;
            this.g_MonthTotalCost.MultiLine = false;
            this.g_MonthTotalCost.Name = "g_MonthTotalCost";
            this.g_MonthTotalCost.OutputFormat = resources.GetString("g_MonthTotalCost.OutputFormat");
            this.g_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthTotalCost.Text = "1,234,567,890";
            this.g_MonthTotalCost.Top = 0.125F;
            this.g_MonthTotalCost.Width = 0.76F;
            // 
            // g_MonthSalesTotalTaxExc
            // 
            this.g_MonthSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTotalTaxExc.DataField = "MonthSalesNetPrice";
            this.g_MonthSalesTotalTaxExc.Height = 0.125F;
            this.g_MonthSalesTotalTaxExc.Left = 3F;
            this.g_MonthSalesTotalTaxExc.MultiLine = false;
            this.g_MonthSalesTotalTaxExc.Name = "g_MonthSalesTotalTaxExc";
            this.g_MonthSalesTotalTaxExc.OutputFormat = resources.GetString("g_MonthSalesTotalTaxExc.OutputFormat");
            this.g_MonthSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesTotalTaxExc.Text = "1,234,567,890";
            this.g_MonthSalesTotalTaxExc.Top = 0.125F;
            this.g_MonthSalesTotalTaxExc.Width = 0.76F;
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
            this.GrandTotalTitle.Height = 0.1875F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 2.0625F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0F;
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
            this.Line43.Width = 10.9F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.9F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // g_TermProfit
            // 
            this.g_TermProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfit.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfit.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfit.DataField = "TermProfit";
            this.g_TermProfit.Height = 0.125F;
            this.g_TermProfit.Left = 8.0625F;
            this.g_TermProfit.MultiLine = false;
            this.g_TermProfit.Name = "g_TermProfit";
            this.g_TermProfit.OutputFormat = resources.GetString("g_TermProfit.OutputFormat");
            this.g_TermProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermProfit.Text = "123,546,789";
            this.g_TermProfit.Top = 0F;
            this.g_TermProfit.Width = 0.76F;
            // 
            // TextBox19
            // 
            this.TextBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Height = 0.125F;
            this.TextBox19.Left = 2.625F;
            this.TextBox19.MultiLine = false;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox19.Text = "日計";
            this.TextBox19.Top = 0F;
            this.TextBox19.Width = 0.3125F;
            // 
            // TextBox20
            // 
            this.TextBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox20.Height = 0.125F;
            this.TextBox20.Left = 2.625F;
            this.TextBox20.MultiLine = false;
            this.TextBox20.Name = "TextBox20";
            this.TextBox20.OutputFormat = resources.GetString("TextBox20.OutputFormat");
            this.TextBox20.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox20.Text = "累計";
            this.TextBox20.Top = 0.125F;
            this.TextBox20.Width = 0.3125F;
            // 
            // g_TermSalesTotalTaxExc
            // 
            this.g_TermSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesTotalTaxExc.DataField = "TermSalesNetPrice";
            this.g_TermSalesTotalTaxExc.Height = 0.125F;
            this.g_TermSalesTotalTaxExc.Left = 3F;
            this.g_TermSalesTotalTaxExc.MultiLine = false;
            this.g_TermSalesTotalTaxExc.Name = "g_TermSalesTotalTaxExc";
            this.g_TermSalesTotalTaxExc.OutputFormat = resources.GetString("g_TermSalesTotalTaxExc.OutputFormat");
            this.g_TermSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermSalesTotalTaxExc.Text = "1,234,567,890";
            this.g_TermSalesTotalTaxExc.Top = 0F;
            this.g_TermSalesTotalTaxExc.Width = 0.76F;
            // 
            // g_TermSalesBackTotalTaxExc
            // 
            this.g_TermSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxExc.DataField = "TermSalesBackNetPrice";
            this.g_TermSalesBackTotalTaxExc.Height = 0.125F;
            this.g_TermSalesBackTotalTaxExc.Left = 3.8125F;
            this.g_TermSalesBackTotalTaxExc.MultiLine = false;
            this.g_TermSalesBackTotalTaxExc.Name = "g_TermSalesBackTotalTaxExc";
            this.g_TermSalesBackTotalTaxExc.OutputFormat = resources.GetString("g_TermSalesBackTotalTaxExc.OutputFormat");
            this.g_TermSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermSalesBackTotalTaxExc.Text = "123,546,789";
            this.g_TermSalesBackTotalTaxExc.Top = 0F;
            this.g_TermSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // g_MonthSalesBackTotalTaxExc
            // 
            this.g_MonthSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxExc.DataField = "MonthSalesBackNetPrice";
            this.g_MonthSalesBackTotalTaxExc.Height = 0.125F;
            this.g_MonthSalesBackTotalTaxExc.Left = 3.8125F;
            this.g_MonthSalesBackTotalTaxExc.MultiLine = false;
            this.g_MonthSalesBackTotalTaxExc.Name = "g_MonthSalesBackTotalTaxExc";
            this.g_MonthSalesBackTotalTaxExc.OutputFormat = resources.GetString("g_MonthSalesBackTotalTaxExc.OutputFormat");
            this.g_MonthSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesBackTotalTaxExc.Text = "123,546,789";
            this.g_MonthSalesBackTotalTaxExc.Top = 0.125F;
            this.g_MonthSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // g_TermSalesBackTotalTaxRate
            // 
            this.g_TermSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesBackTotalTaxRate.DataField = "TermSalesBackTotalTaxRate";
            this.g_TermSalesBackTotalTaxRate.Height = 0.125F;
            this.g_TermSalesBackTotalTaxRate.Left = 4.5625F;
            this.g_TermSalesBackTotalTaxRate.MultiLine = false;
            this.g_TermSalesBackTotalTaxRate.Name = "g_TermSalesBackTotalTaxRate";
            this.g_TermSalesBackTotalTaxRate.OutputFormat = resources.GetString("g_TermSalesBackTotalTaxRate.OutputFormat");
            this.g_TermSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermSalesBackTotalTaxRate.Text = "123,45";
            this.g_TermSalesBackTotalTaxRate.Top = 0F;
            this.g_TermSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // g_MonthSalesBackTotalTaxRate
            // 
            this.g_MonthSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesBackTotalTaxRate.DataField = "MonthSalesBackTotalTaxRate";
            this.g_MonthSalesBackTotalTaxRate.Height = 0.125F;
            this.g_MonthSalesBackTotalTaxRate.Left = 4.5625F;
            this.g_MonthSalesBackTotalTaxRate.MultiLine = false;
            this.g_MonthSalesBackTotalTaxRate.Name = "g_MonthSalesBackTotalTaxRate";
            this.g_MonthSalesBackTotalTaxRate.OutputFormat = resources.GetString("g_MonthSalesBackTotalTaxRate.OutputFormat");
            this.g_MonthSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesBackTotalTaxRate.Text = "123,45";
            this.g_MonthSalesBackTotalTaxRate.Top = 0.125F;
            this.g_MonthSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // g_TermSalesDisTtlTaxExc
            // 
            this.g_TermSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermSalesDisTtlTaxExc.DataField = "TermSalesDisTtlTaxExc";
            this.g_TermSalesDisTtlTaxExc.Height = 0.125F;
            this.g_TermSalesDisTtlTaxExc.Left = 5.125F;
            this.g_TermSalesDisTtlTaxExc.MultiLine = false;
            this.g_TermSalesDisTtlTaxExc.Name = "g_TermSalesDisTtlTaxExc";
            this.g_TermSalesDisTtlTaxExc.OutputFormat = resources.GetString("g_TermSalesDisTtlTaxExc.OutputFormat");
            this.g_TermSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermSalesDisTtlTaxExc.Text = "123,546,789";
            this.g_TermSalesDisTtlTaxExc.Top = 0F;
            this.g_TermSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // g_MonthSalesDisTtlTaxExc
            // 
            this.g_MonthSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesDisTtlTaxExc.DataField = "MonthSalesDisTtlTaxExc";
            this.g_MonthSalesDisTtlTaxExc.Height = 0.125F;
            this.g_MonthSalesDisTtlTaxExc.Left = 5.125F;
            this.g_MonthSalesDisTtlTaxExc.MultiLine = false;
            this.g_MonthSalesDisTtlTaxExc.Name = "g_MonthSalesDisTtlTaxExc";
            this.g_MonthSalesDisTtlTaxExc.OutputFormat = resources.GetString("g_MonthSalesDisTtlTaxExc.OutputFormat");
            this.g_MonthSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesDisTtlTaxExc.Text = "123,546,789";
            this.g_MonthSalesDisTtlTaxExc.Top = 0.125F;
            this.g_MonthSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // g_MonthTargetSalesRate
            // 
            this.g_MonthTargetSalesRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthTargetSalesRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetSalesRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthTargetSalesRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetSalesRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthTargetSalesRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetSalesRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthTargetSalesRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetSalesRate.Height = 0.125F;
            this.g_MonthTargetSalesRate.Left = 7.5F;
            this.g_MonthTargetSalesRate.MultiLine = false;
            this.g_MonthTargetSalesRate.Name = "g_MonthTargetSalesRate";
            this.g_MonthTargetSalesRate.OutputFormat = resources.GetString("g_MonthTargetSalesRate.OutputFormat");
            this.g_MonthTargetSalesRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthTargetSalesRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthTargetSalesRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthTargetSalesRate.Text = "123,45";
            this.g_MonthTargetSalesRate.Top = 0.125F;
            this.g_MonthTargetSalesRate.Width = 0.375F;
            // 
            // g_MonthProfit
            // 
            this.g_MonthProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfit.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfit.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfit.DataField = "MonthProfit";
            this.g_MonthProfit.Height = 0.125F;
            this.g_MonthProfit.Left = 8.0625F;
            this.g_MonthProfit.MultiLine = false;
            this.g_MonthProfit.Name = "g_MonthProfit";
            this.g_MonthProfit.OutputFormat = resources.GetString("g_MonthProfit.OutputFormat");
            this.g_MonthProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthProfit.Text = "123,546,789";
            this.g_MonthProfit.Top = 0.125F;
            this.g_MonthProfit.Width = 0.76F;
            // 
            // g_TermTotalCost
            // 
            this.g_TermTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermTotalCost.DataField = "TermPureSalesTotalCost";
            this.g_TermTotalCost.Height = 0.125F;
            this.g_TermTotalCost.Left = 5.875F;
            this.g_TermTotalCost.MultiLine = false;
            this.g_TermTotalCost.Name = "g_TermTotalCost";
            this.g_TermTotalCost.OutputFormat = resources.GetString("g_TermTotalCost.OutputFormat");
            this.g_TermTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermTotalCost.Text = "1,234,567,890";
            this.g_TermTotalCost.Top = 0F;
            this.g_TermTotalCost.Width = 0.76F;
            // 
            // g_MonthSalesTargetMoney
            // 
            this.g_MonthSalesTargetMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetMoney.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetMoney.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetMoney.DataField = "MonthSalesTargetMoney";
            this.g_MonthSalesTargetMoney.Height = 0.125F;
            this.g_MonthSalesTargetMoney.Left = 6.6875F;
            this.g_MonthSalesTargetMoney.MultiLine = false;
            this.g_MonthSalesTargetMoney.Name = "g_MonthSalesTargetMoney";
            this.g_MonthSalesTargetMoney.OutputFormat = resources.GetString("g_MonthSalesTargetMoney.OutputFormat");
            this.g_MonthSalesTargetMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthSalesTargetMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesTargetMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesTargetMoney.Text = "1,234,567,890";
            this.g_MonthSalesTargetMoney.Top = 0.125F;
            this.g_MonthSalesTargetMoney.Width = 0.76F;
            // 
            // g_TermProfitRate
            // 
            this.g_TermProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TermProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TermProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_TermProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_TermProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TermProfitRate.Height = 0.125F;
            this.g_TermProfitRate.Left = 8.875F;
            this.g_TermProfitRate.MultiLine = false;
            this.g_TermProfitRate.Name = "g_TermProfitRate";
            this.g_TermProfitRate.OutputFormat = resources.GetString("g_TermProfitRate.OutputFormat");
            this.g_TermProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_TermProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TermProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TermProfitRate.Text = "123,45";
            this.g_TermProfitRate.Top = 0F;
            this.g_TermProfitRate.Width = 0.375F;
            // 
            // g_MonthProfitRate
            // 
            this.g_MonthProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthProfitRate.Height = 0.125F;
            this.g_MonthProfitRate.Left = 8.875F;
            this.g_MonthProfitRate.MultiLine = false;
            this.g_MonthProfitRate.Name = "g_MonthProfitRate";
            this.g_MonthProfitRate.OutputFormat = resources.GetString("g_MonthProfitRate.OutputFormat");
            this.g_MonthProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthProfitRate.Text = "123,45";
            this.g_MonthProfitRate.Top = 0.125F;
            this.g_MonthProfitRate.Width = 0.375F;
            // 
            // g_MonthTargetProfitRate
            // 
            this.g_MonthTargetProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthTargetProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthTargetProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthTargetProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthTargetProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthTargetProfitRate.Height = 0.125F;
            this.g_MonthTargetProfitRate.Left = 10.25F;
            this.g_MonthTargetProfitRate.MultiLine = false;
            this.g_MonthTargetProfitRate.Name = "g_MonthTargetProfitRate";
            this.g_MonthTargetProfitRate.OutputFormat = resources.GetString("g_MonthTargetProfitRate.OutputFormat");
            this.g_MonthTargetProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthTargetProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthTargetProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthTargetProfitRate.Text = "123,45";
            this.g_MonthTargetProfitRate.Top = 0.125F;
            this.g_MonthTargetProfitRate.Width = 0.375F;
            // 
            // g_MonthSalesTargetProfit
            // 
            this.g_MonthSalesTargetProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetProfit.Border.RightColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetProfit.Border.TopColor = System.Drawing.Color.Black;
            this.g_MonthSalesTargetProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_MonthSalesTargetProfit.DataField = "MonthSalesTargetProfit";
            this.g_MonthSalesTargetProfit.Height = 0.125F;
            this.g_MonthSalesTargetProfit.Left = 9.427F;
            this.g_MonthSalesTargetProfit.MultiLine = false;
            this.g_MonthSalesTargetProfit.Name = "g_MonthSalesTargetProfit";
            this.g_MonthSalesTargetProfit.OutputFormat = resources.GetString("g_MonthSalesTargetProfit.OutputFormat");
            this.g_MonthSalesTargetProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.g_MonthSalesTargetProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_MonthSalesTargetProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_MonthSalesTargetProfit.Text = "123,546,789";
            this.g_MonthSalesTargetProfit.Top = 0.125F;
            this.g_MonthSalesTargetProfit.Width = 0.76F;
            // 
            // textBox39
            // 
            this.textBox39.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.RightColor = System.Drawing.Color.Black;
            this.textBox39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Border.TopColor = System.Drawing.Color.Black;
            this.textBox39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox39.Height = 0.125F;
            this.textBox39.Left = 4.9375F;
            this.textBox39.MultiLine = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox39.Text = "%";
            this.textBox39.Top = 0F;
            this.textBox39.Width = 0.125F;
            // 
            // textBox40
            // 
            this.textBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.RightColor = System.Drawing.Color.Black;
            this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.TopColor = System.Drawing.Color.Black;
            this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Height = 0.125F;
            this.textBox40.Left = 4.9375F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox40.Text = "%";
            this.textBox40.Top = 0.125F;
            this.textBox40.Width = 0.125F;
            // 
            // textBox41
            // 
            this.textBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.RightColor = System.Drawing.Color.Black;
            this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.TopColor = System.Drawing.Color.Black;
            this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Height = 0.125F;
            this.textBox41.Left = 7.875F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox41.Text = "%";
            this.textBox41.Top = 0.125F;
            this.textBox41.Width = 0.125F;
            // 
            // textBox42
            // 
            this.textBox42.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.RightColor = System.Drawing.Color.Black;
            this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.TopColor = System.Drawing.Color.Black;
            this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Height = 0.125F;
            this.textBox42.Left = 9.25F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox42.Text = "%";
            this.textBox42.Top = 0F;
            this.textBox42.Width = 0.125F;
            // 
            // textBox43
            // 
            this.textBox43.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.RightColor = System.Drawing.Color.Black;
            this.textBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.TopColor = System.Drawing.Color.Black;
            this.textBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Height = 0.125F;
            this.textBox43.Left = 9.25F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox43.Text = "%";
            this.textBox43.Top = 0.125F;
            this.textBox43.Width = 0.125F;
            // 
            // textBox34
            // 
            this.textBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.RightColor = System.Drawing.Color.Black;
            this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.TopColor = System.Drawing.Color.Black;
            this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Height = 0.125F;
            this.textBox34.Left = 10.625F;
            this.textBox34.MultiLine = false;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox34.Text = "%";
            this.textBox34.Top = 0.125F;
            this.textBox34.Width = 0.125F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionHeaderLine,
            this.upline_SectionHeader,
            this.SectionHeaderLineName,
            this.SectionHeaderLineTitle});
            this.SectionHeader.DataField = "SectionHeaderField";
            this.SectionHeader.Height = 0.2291667F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Visible = false;
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
            this.SectionHeaderLine.Height = 0.125F;
            this.SectionHeaderLine.Left = 0.5F;
            this.SectionHeaderLine.MultiLine = false;
            this.SectionHeaderLine.Name = "SectionHeaderLine";
            this.SectionHeaderLine.OutputFormat = resources.GetString("SectionHeaderLine.OutputFormat");
            this.SectionHeaderLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SectionHeaderLine.Text = "12";
            this.SectionHeaderLine.Top = 0F;
            this.SectionHeaderLine.Width = 0.1875F;
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
            this.upline_SectionHeader.Width = 10.9F;
            this.upline_SectionHeader.X1 = 0F;
            this.upline_SectionHeader.X2 = 10.9F;
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
            this.SectionHeaderLineName.Height = 0.125F;
            this.SectionHeaderLineName.Left = 0.75F;
            this.SectionHeaderLineName.MultiLine = false;
            this.SectionHeaderLineName.Name = "SectionHeaderLineName";
            this.SectionHeaderLineName.OutputFormat = resources.GetString("SectionHeaderLineName.OutputFormat");
            this.SectionHeaderLineName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionHeaderLineName.Text = "拠点名称５６７８９０";
            this.SectionHeaderLineName.Top = 0F;
            this.SectionHeaderLineName.Width = 1.25F;
            // 
            // SectionHeaderLineTitle
            // 
            this.SectionHeaderLineTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionHeaderLineTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionHeaderLineTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SectionHeaderLineTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SectionHeaderLineTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionHeaderLineTitle.Height = 0.125F;
            this.SectionHeaderLineTitle.Left = 0.125F;
            this.SectionHeaderLineTitle.MultiLine = false;
            this.SectionHeaderLineTitle.Name = "SectionHeaderLineTitle";
            this.SectionHeaderLineTitle.OutputFormat = resources.GetString("SectionHeaderLineTitle.OutputFormat");
            this.SectionHeaderLineTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.SectionHeaderLineTitle.Text = "拠点";
            this.SectionHeaderLineTitle.Top = 0F;
            this.SectionHeaderLineTitle.Width = 0.3125F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.s_MonthTotalCost,
            this.s_MonthSalesTotalTaxExc,
            this.Line45,
            this.SectionTitle,
            this.s_TermProfit,
            this.TextBox17,
            this.TextBox18,
            this.s_TermSalesTotalTaxExc,
            this.s_TermSalesBackTotalTaxExc,
            this.s_MonthSalesBackTotalTaxExc,
            this.s_TermSalesBackTotalTaxRate,
            this.s_MonthSalesBackTotalTaxRate,
            this.s_TermSalesDisTtlTaxExc,
            this.s_MonthSalesDisTtlTaxExc,
            this.s_MonthTargetSalesRate,
            this.s_MonthProfit,
            this.s_TermTotalCost,
            this.s_MonthSalesTargetMoney,
            this.s_TermProfitRate,
            this.s_MonthProfitRate,
            this.s_MonthTargetProfitRate,
            this.s_MonthSalesTargetProfit,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox37,
            this.textBox38});
            this.SectionFooter.Height = 0.3541667F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
            this.SectionFooter.Format += new System.EventHandler(this.SectionFooter_Format);
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
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
            this.s_MonthTotalCost.DataField = "MonthPureSalesTotalCost";
            this.s_MonthTotalCost.Height = 0.125F;
            this.s_MonthTotalCost.Left = 5.875F;
            this.s_MonthTotalCost.MultiLine = false;
            this.s_MonthTotalCost.Name = "s_MonthTotalCost";
            this.s_MonthTotalCost.OutputFormat = resources.GetString("s_MonthTotalCost.OutputFormat");
            this.s_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthTotalCost.SummaryGroup = "SectionHeader";
            this.s_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthTotalCost.Text = "1,234,567,890";
            this.s_MonthTotalCost.Top = 0.125F;
            this.s_MonthTotalCost.Width = 0.76F;
            // 
            // s_MonthSalesTotalTaxExc
            // 
            this.s_MonthSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTotalTaxExc.DataField = "MonthSalesNetPrice";
            this.s_MonthSalesTotalTaxExc.Height = 0.125F;
            this.s_MonthSalesTotalTaxExc.Left = 3F;
            this.s_MonthSalesTotalTaxExc.MultiLine = false;
            this.s_MonthSalesTotalTaxExc.Name = "s_MonthSalesTotalTaxExc";
            this.s_MonthSalesTotalTaxExc.OutputFormat = resources.GetString("s_MonthSalesTotalTaxExc.OutputFormat");
            this.s_MonthSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthSalesTotalTaxExc.SummaryGroup = "SectionHeader";
            this.s_MonthSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesTotalTaxExc.Text = "1,234,567,890";
            this.s_MonthSalesTotalTaxExc.Top = 0.125F;
            this.s_MonthSalesTotalTaxExc.Width = 0.76F;
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
            this.Line45.Width = 10.9F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.9F;
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
            this.SectionTitle.Height = 0.1875F;
            this.SectionTitle.Left = 2.0625F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0F;
            this.SectionTitle.Width = 0.5F;
            // 
            // s_TermProfit
            // 
            this.s_TermProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfit.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfit.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfit.DataField = "TermProfit";
            this.s_TermProfit.Height = 0.125F;
            this.s_TermProfit.Left = 8.0625F;
            this.s_TermProfit.MultiLine = false;
            this.s_TermProfit.Name = "s_TermProfit";
            this.s_TermProfit.OutputFormat = resources.GetString("s_TermProfit.OutputFormat");
            this.s_TermProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermProfit.SummaryGroup = "SectionHeader";
            this.s_TermProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermProfit.Text = "123,546,789";
            this.s_TermProfit.Top = 0F;
            this.s_TermProfit.Width = 0.76F;
            // 
            // TextBox17
            // 
            this.TextBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Height = 0.125F;
            this.TextBox17.Left = 2.625F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox17.Text = "日計";
            this.TextBox17.Top = 0F;
            this.TextBox17.Width = 0.3125F;
            // 
            // TextBox18
            // 
            this.TextBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Height = 0.125F;
            this.TextBox18.Left = 2.625F;
            this.TextBox18.MultiLine = false;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox18.Text = "累計";
            this.TextBox18.Top = 0.125F;
            this.TextBox18.Width = 0.3125F;
            // 
            // s_TermSalesTotalTaxExc
            // 
            this.s_TermSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesTotalTaxExc.DataField = "TermSalesNetPrice";
            this.s_TermSalesTotalTaxExc.Height = 0.125F;
            this.s_TermSalesTotalTaxExc.Left = 3F;
            this.s_TermSalesTotalTaxExc.MultiLine = false;
            this.s_TermSalesTotalTaxExc.Name = "s_TermSalesTotalTaxExc";
            this.s_TermSalesTotalTaxExc.OutputFormat = resources.GetString("s_TermSalesTotalTaxExc.OutputFormat");
            this.s_TermSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermSalesTotalTaxExc.SummaryGroup = "SectionHeader";
            this.s_TermSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermSalesTotalTaxExc.Text = "1,234,567,890";
            this.s_TermSalesTotalTaxExc.Top = 0F;
            this.s_TermSalesTotalTaxExc.Width = 0.76F;
            // 
            // s_TermSalesBackTotalTaxExc
            // 
            this.s_TermSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxExc.DataField = "TermSalesBackNetPrice";
            this.s_TermSalesBackTotalTaxExc.Height = 0.125F;
            this.s_TermSalesBackTotalTaxExc.Left = 3.8125F;
            this.s_TermSalesBackTotalTaxExc.MultiLine = false;
            this.s_TermSalesBackTotalTaxExc.Name = "s_TermSalesBackTotalTaxExc";
            this.s_TermSalesBackTotalTaxExc.OutputFormat = resources.GetString("s_TermSalesBackTotalTaxExc.OutputFormat");
            this.s_TermSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermSalesBackTotalTaxExc.SummaryGroup = "SectionHeader";
            this.s_TermSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermSalesBackTotalTaxExc.Text = "123,546,789";
            this.s_TermSalesBackTotalTaxExc.Top = 0F;
            this.s_TermSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // s_MonthSalesBackTotalTaxExc
            // 
            this.s_MonthSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxExc.DataField = "MonthSalesBackNetPrice";
            this.s_MonthSalesBackTotalTaxExc.Height = 0.125F;
            this.s_MonthSalesBackTotalTaxExc.Left = 3.8125F;
            this.s_MonthSalesBackTotalTaxExc.MultiLine = false;
            this.s_MonthSalesBackTotalTaxExc.Name = "s_MonthSalesBackTotalTaxExc";
            this.s_MonthSalesBackTotalTaxExc.OutputFormat = resources.GetString("s_MonthSalesBackTotalTaxExc.OutputFormat");
            this.s_MonthSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthSalesBackTotalTaxExc.SummaryGroup = "SectionHeader";
            this.s_MonthSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesBackTotalTaxExc.Text = "123,546,789";
            this.s_MonthSalesBackTotalTaxExc.Top = 0.125F;
            this.s_MonthSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // s_TermSalesBackTotalTaxRate
            // 
            this.s_TermSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesBackTotalTaxRate.DataField = "TermSalesBackTotalTaxRate";
            this.s_TermSalesBackTotalTaxRate.Height = 0.125F;
            this.s_TermSalesBackTotalTaxRate.Left = 4.5625F;
            this.s_TermSalesBackTotalTaxRate.MultiLine = false;
            this.s_TermSalesBackTotalTaxRate.Name = "s_TermSalesBackTotalTaxRate";
            this.s_TermSalesBackTotalTaxRate.OutputFormat = resources.GetString("s_TermSalesBackTotalTaxRate.OutputFormat");
            this.s_TermSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermSalesBackTotalTaxRate.SummaryGroup = "SectionHeader";
            this.s_TermSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermSalesBackTotalTaxRate.Text = "123,45";
            this.s_TermSalesBackTotalTaxRate.Top = 0F;
            this.s_TermSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // s_MonthSalesBackTotalTaxRate
            // 
            this.s_MonthSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesBackTotalTaxRate.DataField = "MonthSalesBackTotalTaxRate";
            this.s_MonthSalesBackTotalTaxRate.Height = 0.125F;
            this.s_MonthSalesBackTotalTaxRate.Left = 4.5625F;
            this.s_MonthSalesBackTotalTaxRate.MultiLine = false;
            this.s_MonthSalesBackTotalTaxRate.Name = "s_MonthSalesBackTotalTaxRate";
            this.s_MonthSalesBackTotalTaxRate.OutputFormat = resources.GetString("s_MonthSalesBackTotalTaxRate.OutputFormat");
            this.s_MonthSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthSalesBackTotalTaxRate.SummaryGroup = "SectionHeader";
            this.s_MonthSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesBackTotalTaxRate.Text = "123,45";
            this.s_MonthSalesBackTotalTaxRate.Top = 0.125F;
            this.s_MonthSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // s_TermSalesDisTtlTaxExc
            // 
            this.s_TermSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermSalesDisTtlTaxExc.DataField = "TermSalesDisTtlTaxExc";
            this.s_TermSalesDisTtlTaxExc.Height = 0.125F;
            this.s_TermSalesDisTtlTaxExc.Left = 5.125F;
            this.s_TermSalesDisTtlTaxExc.MultiLine = false;
            this.s_TermSalesDisTtlTaxExc.Name = "s_TermSalesDisTtlTaxExc";
            this.s_TermSalesDisTtlTaxExc.OutputFormat = resources.GetString("s_TermSalesDisTtlTaxExc.OutputFormat");
            this.s_TermSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermSalesDisTtlTaxExc.SummaryGroup = "SectionHeader";
            this.s_TermSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermSalesDisTtlTaxExc.Text = "123,546,789";
            this.s_TermSalesDisTtlTaxExc.Top = 0F;
            this.s_TermSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // s_MonthSalesDisTtlTaxExc
            // 
            this.s_MonthSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesDisTtlTaxExc.DataField = "MonthSalesDisTtlTaxExc";
            this.s_MonthSalesDisTtlTaxExc.Height = 0.125F;
            this.s_MonthSalesDisTtlTaxExc.Left = 5.125F;
            this.s_MonthSalesDisTtlTaxExc.MultiLine = false;
            this.s_MonthSalesDisTtlTaxExc.Name = "s_MonthSalesDisTtlTaxExc";
            this.s_MonthSalesDisTtlTaxExc.OutputFormat = resources.GetString("s_MonthSalesDisTtlTaxExc.OutputFormat");
            this.s_MonthSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthSalesDisTtlTaxExc.SummaryGroup = "SectionHeader";
            this.s_MonthSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesDisTtlTaxExc.Text = "123,546,789";
            this.s_MonthSalesDisTtlTaxExc.Top = 0.125F;
            this.s_MonthSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // s_MonthTargetSalesRate
            // 
            this.s_MonthTargetSalesRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthTargetSalesRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetSalesRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthTargetSalesRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetSalesRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthTargetSalesRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetSalesRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthTargetSalesRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetSalesRate.Height = 0.125F;
            this.s_MonthTargetSalesRate.Left = 7.5F;
            this.s_MonthTargetSalesRate.MultiLine = false;
            this.s_MonthTargetSalesRate.Name = "s_MonthTargetSalesRate";
            this.s_MonthTargetSalesRate.OutputFormat = resources.GetString("s_MonthTargetSalesRate.OutputFormat");
            this.s_MonthTargetSalesRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthTargetSalesRate.SummaryGroup = "SectionHeader";
            this.s_MonthTargetSalesRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthTargetSalesRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthTargetSalesRate.Text = "123,45";
            this.s_MonthTargetSalesRate.Top = 0.125F;
            this.s_MonthTargetSalesRate.Width = 0.375F;
            // 
            // s_MonthProfit
            // 
            this.s_MonthProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfit.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfit.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfit.DataField = "MonthProfit";
            this.s_MonthProfit.Height = 0.125F;
            this.s_MonthProfit.Left = 8.0625F;
            this.s_MonthProfit.MultiLine = false;
            this.s_MonthProfit.Name = "s_MonthProfit";
            this.s_MonthProfit.OutputFormat = resources.GetString("s_MonthProfit.OutputFormat");
            this.s_MonthProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthProfit.SummaryGroup = "SectionHeader";
            this.s_MonthProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthProfit.Text = "123,546,789";
            this.s_MonthProfit.Top = 0.125F;
            this.s_MonthProfit.Width = 0.76F;
            // 
            // s_TermTotalCost
            // 
            this.s_TermTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermTotalCost.DataField = "TermPureSalesTotalCost";
            this.s_TermTotalCost.Height = 0.125F;
            this.s_TermTotalCost.Left = 5.875F;
            this.s_TermTotalCost.MultiLine = false;
            this.s_TermTotalCost.Name = "s_TermTotalCost";
            this.s_TermTotalCost.OutputFormat = resources.GetString("s_TermTotalCost.OutputFormat");
            this.s_TermTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermTotalCost.SummaryGroup = "SectionHeader";
            this.s_TermTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermTotalCost.Text = "1,234,567,890";
            this.s_TermTotalCost.Top = 0F;
            this.s_TermTotalCost.Width = 0.76F;
            // 
            // s_MonthSalesTargetMoney
            // 
            this.s_MonthSalesTargetMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetMoney.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetMoney.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetMoney.DataField = "MonthSalesTargetMoney";
            this.s_MonthSalesTargetMoney.Height = 0.125F;
            this.s_MonthSalesTargetMoney.Left = 6.6875F;
            this.s_MonthSalesTargetMoney.MultiLine = false;
            this.s_MonthSalesTargetMoney.Name = "s_MonthSalesTargetMoney";
            this.s_MonthSalesTargetMoney.OutputFormat = resources.GetString("s_MonthSalesTargetMoney.OutputFormat");
            this.s_MonthSalesTargetMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthSalesTargetMoney.SummaryGroup = "SectionHeader";
            this.s_MonthSalesTargetMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesTargetMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesTargetMoney.Text = "1,234,567,890";
            this.s_MonthSalesTargetMoney.Top = 0.125F;
            this.s_MonthSalesTargetMoney.Width = 0.76F;
            // 
            // s_TermProfitRate
            // 
            this.s_TermProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TermProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TermProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_TermProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_TermProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TermProfitRate.Height = 0.125F;
            this.s_TermProfitRate.Left = 8.875F;
            this.s_TermProfitRate.MultiLine = false;
            this.s_TermProfitRate.Name = "s_TermProfitRate";
            this.s_TermProfitRate.OutputFormat = resources.GetString("s_TermProfitRate.OutputFormat");
            this.s_TermProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_TermProfitRate.SummaryGroup = "SectionHeader";
            this.s_TermProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TermProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TermProfitRate.Text = "123,45";
            this.s_TermProfitRate.Top = 0F;
            this.s_TermProfitRate.Width = 0.375F;
            // 
            // s_MonthProfitRate
            // 
            this.s_MonthProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthProfitRate.Height = 0.125F;
            this.s_MonthProfitRate.Left = 8.875F;
            this.s_MonthProfitRate.MultiLine = false;
            this.s_MonthProfitRate.Name = "s_MonthProfitRate";
            this.s_MonthProfitRate.OutputFormat = resources.GetString("s_MonthProfitRate.OutputFormat");
            this.s_MonthProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthProfitRate.SummaryGroup = "SectionHeader";
            this.s_MonthProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthProfitRate.Text = "123,45";
            this.s_MonthProfitRate.Top = 0.125F;
            this.s_MonthProfitRate.Width = 0.375F;
            // 
            // s_MonthTargetProfitRate
            // 
            this.s_MonthTargetProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthTargetProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthTargetProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthTargetProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthTargetProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthTargetProfitRate.Height = 0.125F;
            this.s_MonthTargetProfitRate.Left = 10.25F;
            this.s_MonthTargetProfitRate.MultiLine = false;
            this.s_MonthTargetProfitRate.Name = "s_MonthTargetProfitRate";
            this.s_MonthTargetProfitRate.OutputFormat = resources.GetString("s_MonthTargetProfitRate.OutputFormat");
            this.s_MonthTargetProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthTargetProfitRate.SummaryGroup = "SectionHeader";
            this.s_MonthTargetProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthTargetProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthTargetProfitRate.Text = "123,45";
            this.s_MonthTargetProfitRate.Top = 0.125F;
            this.s_MonthTargetProfitRate.Width = 0.375F;
            // 
            // s_MonthSalesTargetProfit
            // 
            this.s_MonthSalesTargetProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetProfit.Border.RightColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetProfit.Border.TopColor = System.Drawing.Color.Black;
            this.s_MonthSalesTargetProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_MonthSalesTargetProfit.DataField = "MonthSalesTargetProfit";
            this.s_MonthSalesTargetProfit.Height = 0.125F;
            this.s_MonthSalesTargetProfit.Left = 9.427F;
            this.s_MonthSalesTargetProfit.MultiLine = false;
            this.s_MonthSalesTargetProfit.Name = "s_MonthSalesTargetProfit";
            this.s_MonthSalesTargetProfit.OutputFormat = resources.GetString("s_MonthSalesTargetProfit.OutputFormat");
            this.s_MonthSalesTargetProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.s_MonthSalesTargetProfit.SummaryGroup = "SectionHeader";
            this.s_MonthSalesTargetProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_MonthSalesTargetProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_MonthSalesTargetProfit.Text = "123,546,789";
            this.s_MonthSalesTargetProfit.Top = 0.125F;
            this.s_MonthSalesTargetProfit.Width = 0.76F;
            // 
            // textBox30
            // 
            this.textBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.RightColor = System.Drawing.Color.Black;
            this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.TopColor = System.Drawing.Color.Black;
            this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Height = 0.125F;
            this.textBox30.Left = 4.9375F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox30.Text = "%";
            this.textBox30.Top = 0F;
            this.textBox30.Width = 0.125F;
            // 
            // textBox31
            // 
            this.textBox31.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.RightColor = System.Drawing.Color.Black;
            this.textBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.TopColor = System.Drawing.Color.Black;
            this.textBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Height = 0.125F;
            this.textBox31.Left = 4.9375F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox31.Text = "%";
            this.textBox31.Top = 0.125F;
            this.textBox31.Width = 0.125F;
            // 
            // textBox32
            // 
            this.textBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.RightColor = System.Drawing.Color.Black;
            this.textBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.TopColor = System.Drawing.Color.Black;
            this.textBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Height = 0.125F;
            this.textBox32.Left = 7.875F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox32.Text = "%";
            this.textBox32.Top = 0.125F;
            this.textBox32.Width = 0.125F;
            // 
            // textBox33
            // 
            this.textBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.RightColor = System.Drawing.Color.Black;
            this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.TopColor = System.Drawing.Color.Black;
            this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Height = 0.125F;
            this.textBox33.Left = 9.25F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox33.Text = "%";
            this.textBox33.Top = 0F;
            this.textBox33.Width = 0.125F;
            // 
            // textBox37
            // 
            this.textBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.RightColor = System.Drawing.Color.Black;
            this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.TopColor = System.Drawing.Color.Black;
            this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Height = 0.125F;
            this.textBox37.Left = 9.25F;
            this.textBox37.MultiLine = false;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox37.Text = "%";
            this.textBox37.Top = 0.125F;
            this.textBox37.Width = 0.125F;
            // 
            // textBox38
            // 
            this.textBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.RightColor = System.Drawing.Color.Black;
            this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.TopColor = System.Drawing.Color.Black;
            this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Height = 0.125F;
            this.textBox38.Left = 10.625F;
            this.textBox38.MultiLine = false;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox38.Text = "%";
            this.textBox38.Top = 0.125F;
            this.textBox38.Width = 0.125F;
            // 
            // WareHouseHeader
            // 
            this.WareHouseHeader.CanShrink = true;
            this.WareHouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WareHouseHeaderLine,
            this.WareHouseHeaderLineName});
            this.WareHouseHeader.DataField = "WareHouseHeaderField";
            this.WareHouseHeader.Height = 0.25F;
            this.WareHouseHeader.Name = "WareHouseHeader";
            this.WareHouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.WareHouseHeader.Visible = false;
            // 
            // WareHouseHeaderLine
            // 
            this.WareHouseHeaderLine.Border.BottomColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLine.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLine.Border.LeftColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLine.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLine.Border.RightColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLine.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLine.Border.TopColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLine.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLine.DataField = "WareHouseHeaderLine";
            this.WareHouseHeaderLine.Height = 0.125F;
            this.WareHouseHeaderLine.Left = 0.125F;
            this.WareHouseHeaderLine.MultiLine = false;
            this.WareHouseHeaderLine.Name = "WareHouseHeaderLine";
            this.WareHouseHeaderLine.OutputFormat = resources.GetString("WareHouseHeaderLine.OutputFormat");
            this.WareHouseHeaderLine.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.WareHouseHeaderLine.Text = "12345678";
            this.WareHouseHeaderLine.Top = 0F;
            this.WareHouseHeaderLine.Width = 0.5F;
            // 
            // WareHouseHeaderLineName
            // 
            this.WareHouseHeaderLineName.Border.BottomColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLineName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLineName.Border.LeftColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLineName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLineName.Border.RightColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLineName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLineName.Border.TopColor = System.Drawing.Color.Black;
            this.WareHouseHeaderLineName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseHeaderLineName.DataField = "WareHouseHeaderLineName";
            this.WareHouseHeaderLineName.Height = 0.125F;
            this.WareHouseHeaderLineName.Left = 0.6875F;
            this.WareHouseHeaderLineName.MultiLine = false;
            this.WareHouseHeaderLineName.Name = "WareHouseHeaderLineName";
            this.WareHouseHeaderLineName.OutputFormat = resources.GetString("WareHouseHeaderLineName.OutputFormat");
            this.WareHouseHeaderLineName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WareHouseHeaderLineName.Text = "123456";
            this.WareHouseHeaderLineName.Top = 0F;
            this.WareHouseHeaderLineName.Width = 3F;
            // 
            // WareHouseFooter
            // 
            this.WareHouseFooter.CanShrink = true;
            this.WareHouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.w_MonthTotalCost,
            this.w_MonthSalesTotalTaxExc,
            this.WareHouseTitle,
            this.w_TermProfit,
            this.Line,
            this.TextBox15,
            this.TextBox16,
            this.w_TermSalesTotalTaxExc,
            this.w_TermSalesBackTotalTaxExc,
            this.w_TermSalesBackTotalTaxRate,
            this.w_TermSalesDisTtlTaxExc,
            this.w_MonthSalesBackTotalTaxExc,
            this.w_MonthSalesBackTotalTaxRate,
            this.w_MonthSalesDisTtlTaxExc,
            this.w_MonthTargetSalesRate,
            this.w_MonthProfit,
            this.w_TermTotalCost,
            this.w_MonthSalesTargetMoney,
            this.w_TermProfitRate,
            this.w_MonthProfitRate,
            this.w_MonthTargetProfitRate,
            this.w_MonthSalesTargetProfit,
            this.textBox23,
            this.textBox24,
            this.textBox26,
            this.textBox27,
            this.textBox29,
            this.textBox5});
            this.WareHouseFooter.Height = 0.3333333F;
            this.WareHouseFooter.KeepTogether = true;
            this.WareHouseFooter.Name = "WareHouseFooter";
            this.WareHouseFooter.Visible = false;
            this.WareHouseFooter.Format += new System.EventHandler(this.WareHouseFooter_Format);
            this.WareHouseFooter.BeforePrint += new System.EventHandler(this.WareHouseFooter_BeforePrint);
            // 
            // w_MonthTotalCost
            // 
            this.w_MonthTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTotalCost.DataField = "MonthPureSalesTotalCost";
            this.w_MonthTotalCost.Height = 0.125F;
            this.w_MonthTotalCost.Left = 5.875F;
            this.w_MonthTotalCost.MultiLine = false;
            this.w_MonthTotalCost.Name = "w_MonthTotalCost";
            this.w_MonthTotalCost.OutputFormat = resources.GetString("w_MonthTotalCost.OutputFormat");
            this.w_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthTotalCost.SummaryGroup = "WareHouseHeader";
            this.w_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthTotalCost.Text = "1,234,567,890";
            this.w_MonthTotalCost.Top = 0.125F;
            this.w_MonthTotalCost.Width = 0.76F;
            // 
            // w_MonthSalesTotalTaxExc
            // 
            this.w_MonthSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTotalTaxExc.DataField = "MonthSalesNetPrice";
            this.w_MonthSalesTotalTaxExc.Height = 0.125F;
            this.w_MonthSalesTotalTaxExc.Left = 3F;
            this.w_MonthSalesTotalTaxExc.MultiLine = false;
            this.w_MonthSalesTotalTaxExc.Name = "w_MonthSalesTotalTaxExc";
            this.w_MonthSalesTotalTaxExc.OutputFormat = resources.GetString("w_MonthSalesTotalTaxExc.OutputFormat");
            this.w_MonthSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthSalesTotalTaxExc.SummaryGroup = "WareHouseHeader";
            this.w_MonthSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthSalesTotalTaxExc.Text = "1,234,567,890";
            this.w_MonthSalesTotalTaxExc.Top = 0.125F;
            this.w_MonthSalesTotalTaxExc.Width = 0.76F;
            // 
            // WareHouseTitle
            // 
            this.WareHouseTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.WareHouseTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.WareHouseTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle.Border.RightColor = System.Drawing.Color.Black;
            this.WareHouseTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle.Border.TopColor = System.Drawing.Color.Black;
            this.WareHouseTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WareHouseTitle.Height = 0.1875F;
            this.WareHouseTitle.Left = 2.0625F;
            this.WareHouseTitle.MultiLine = false;
            this.WareHouseTitle.Name = "WareHouseTitle";
            this.WareHouseTitle.OutputFormat = resources.GetString("WareHouseTitle.OutputFormat");
            this.WareHouseTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WareHouseTitle.Text = "担当計";
            this.WareHouseTitle.Top = 0F;
            this.WareHouseTitle.Width = 0.5F;
            // 
            // w_TermProfit
            // 
            this.w_TermProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfit.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfit.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfit.DataField = "TermProfit";
            this.w_TermProfit.Height = 0.125F;
            this.w_TermProfit.Left = 8.0625F;
            this.w_TermProfit.MultiLine = false;
            this.w_TermProfit.Name = "w_TermProfit";
            this.w_TermProfit.OutputFormat = resources.GetString("w_TermProfit.OutputFormat");
            this.w_TermProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermProfit.SummaryGroup = "WareHouseHeader";
            this.w_TermProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermProfit.Text = "123,546,789";
            this.w_TermProfit.Top = 0F;
            this.w_TermProfit.Width = 0.76F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 10.9F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.9F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // TextBox15
            // 
            this.TextBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Height = 0.125F;
            this.TextBox15.Left = 2.625F;
            this.TextBox15.MultiLine = false;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox15.Text = "日計";
            this.TextBox15.Top = 0F;
            this.TextBox15.Width = 0.3125F;
            // 
            // TextBox16
            // 
            this.TextBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Height = 0.125F;
            this.TextBox16.Left = 2.625F;
            this.TextBox16.MultiLine = false;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.TextBox16.Text = "累計";
            this.TextBox16.Top = 0.125F;
            this.TextBox16.Width = 0.3125F;
            // 
            // w_TermSalesTotalTaxExc
            // 
            this.w_TermSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesTotalTaxExc.DataField = "TermSalesNetPrice";
            this.w_TermSalesTotalTaxExc.Height = 0.125F;
            this.w_TermSalesTotalTaxExc.Left = 3F;
            this.w_TermSalesTotalTaxExc.MultiLine = false;
            this.w_TermSalesTotalTaxExc.Name = "w_TermSalesTotalTaxExc";
            this.w_TermSalesTotalTaxExc.OutputFormat = resources.GetString("w_TermSalesTotalTaxExc.OutputFormat");
            this.w_TermSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermSalesTotalTaxExc.SummaryGroup = "WareHouseHeader";
            this.w_TermSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermSalesTotalTaxExc.Text = "1,234,567,890";
            this.w_TermSalesTotalTaxExc.Top = 0F;
            this.w_TermSalesTotalTaxExc.Width = 0.76F;
            // 
            // w_TermSalesBackTotalTaxExc
            // 
            this.w_TermSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxExc.DataField = "TermSalesBackNetPrice";
            this.w_TermSalesBackTotalTaxExc.Height = 0.125F;
            this.w_TermSalesBackTotalTaxExc.Left = 3.8125F;
            this.w_TermSalesBackTotalTaxExc.MultiLine = false;
            this.w_TermSalesBackTotalTaxExc.Name = "w_TermSalesBackTotalTaxExc";
            this.w_TermSalesBackTotalTaxExc.OutputFormat = resources.GetString("w_TermSalesBackTotalTaxExc.OutputFormat");
            this.w_TermSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermSalesBackTotalTaxExc.SummaryGroup = "WareHouseHeader";
            this.w_TermSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermSalesBackTotalTaxExc.Text = "123,546,789";
            this.w_TermSalesBackTotalTaxExc.Top = 0F;
            this.w_TermSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // w_TermSalesBackTotalTaxRate
            // 
            this.w_TermSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesBackTotalTaxRate.DataField = "TermSalesBackTotalTaxRate";
            this.w_TermSalesBackTotalTaxRate.Height = 0.125F;
            this.w_TermSalesBackTotalTaxRate.Left = 4.5625F;
            this.w_TermSalesBackTotalTaxRate.MultiLine = false;
            this.w_TermSalesBackTotalTaxRate.Name = "w_TermSalesBackTotalTaxRate";
            this.w_TermSalesBackTotalTaxRate.OutputFormat = resources.GetString("w_TermSalesBackTotalTaxRate.OutputFormat");
            this.w_TermSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermSalesBackTotalTaxRate.SummaryGroup = "WareHouseHeader";
            this.w_TermSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermSalesBackTotalTaxRate.Text = "123,45";
            this.w_TermSalesBackTotalTaxRate.Top = 0F;
            this.w_TermSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // w_TermSalesDisTtlTaxExc
            // 
            this.w_TermSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermSalesDisTtlTaxExc.DataField = "TermSalesDisTtlTaxExc";
            this.w_TermSalesDisTtlTaxExc.Height = 0.125F;
            this.w_TermSalesDisTtlTaxExc.Left = 5.125F;
            this.w_TermSalesDisTtlTaxExc.MultiLine = false;
            this.w_TermSalesDisTtlTaxExc.Name = "w_TermSalesDisTtlTaxExc";
            this.w_TermSalesDisTtlTaxExc.OutputFormat = resources.GetString("w_TermSalesDisTtlTaxExc.OutputFormat");
            this.w_TermSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermSalesDisTtlTaxExc.SummaryGroup = "WareHouseHeader";
            this.w_TermSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermSalesDisTtlTaxExc.Text = "123,546,789";
            this.w_TermSalesDisTtlTaxExc.Top = 0F;
            this.w_TermSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // w_MonthSalesBackTotalTaxExc
            // 
            this.w_MonthSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxExc.DataField = "MonthSalesBackNetPrice";
            this.w_MonthSalesBackTotalTaxExc.Height = 0.125F;
            this.w_MonthSalesBackTotalTaxExc.Left = 3.8125F;
            this.w_MonthSalesBackTotalTaxExc.MultiLine = false;
            this.w_MonthSalesBackTotalTaxExc.Name = "w_MonthSalesBackTotalTaxExc";
            this.w_MonthSalesBackTotalTaxExc.OutputFormat = resources.GetString("w_MonthSalesBackTotalTaxExc.OutputFormat");
            this.w_MonthSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthSalesBackTotalTaxExc.SummaryGroup = "WareHouseHeader";
            this.w_MonthSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthSalesBackTotalTaxExc.Text = "123,546,789";
            this.w_MonthSalesBackTotalTaxExc.Top = 0.125F;
            this.w_MonthSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // w_MonthSalesBackTotalTaxRate
            // 
            this.w_MonthSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesBackTotalTaxRate.DataField = "MonthSalesBackTotalTaxRate";
            this.w_MonthSalesBackTotalTaxRate.Height = 0.125F;
            this.w_MonthSalesBackTotalTaxRate.Left = 4.5625F;
            this.w_MonthSalesBackTotalTaxRate.MultiLine = false;
            this.w_MonthSalesBackTotalTaxRate.Name = "w_MonthSalesBackTotalTaxRate";
            this.w_MonthSalesBackTotalTaxRate.OutputFormat = resources.GetString("w_MonthSalesBackTotalTaxRate.OutputFormat");
            this.w_MonthSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthSalesBackTotalTaxRate.SummaryGroup = "WareHouseHeader";
            this.w_MonthSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthSalesBackTotalTaxRate.Text = "123,45";
            this.w_MonthSalesBackTotalTaxRate.Top = 0.125F;
            this.w_MonthSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // w_MonthSalesDisTtlTaxExc
            // 
            this.w_MonthSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesDisTtlTaxExc.DataField = "MonthSalesDisTtlTaxExc";
            this.w_MonthSalesDisTtlTaxExc.Height = 0.125F;
            this.w_MonthSalesDisTtlTaxExc.Left = 5.125F;
            this.w_MonthSalesDisTtlTaxExc.MultiLine = false;
            this.w_MonthSalesDisTtlTaxExc.Name = "w_MonthSalesDisTtlTaxExc";
            this.w_MonthSalesDisTtlTaxExc.OutputFormat = resources.GetString("w_MonthSalesDisTtlTaxExc.OutputFormat");
            this.w_MonthSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthSalesDisTtlTaxExc.SummaryGroup = "WareHouseHeader";
            this.w_MonthSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthSalesDisTtlTaxExc.Text = "123,546,789";
            this.w_MonthSalesDisTtlTaxExc.Top = 0.125F;
            this.w_MonthSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // w_MonthTargetSalesRate
            // 
            this.w_MonthTargetSalesRate.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthTargetSalesRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetSalesRate.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthTargetSalesRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetSalesRate.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthTargetSalesRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetSalesRate.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthTargetSalesRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetSalesRate.Height = 0.125F;
            this.w_MonthTargetSalesRate.Left = 7.5F;
            this.w_MonthTargetSalesRate.MultiLine = false;
            this.w_MonthTargetSalesRate.Name = "w_MonthTargetSalesRate";
            this.w_MonthTargetSalesRate.OutputFormat = resources.GetString("w_MonthTargetSalesRate.OutputFormat");
            this.w_MonthTargetSalesRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthTargetSalesRate.SummaryGroup = "WareHouseHeader";
            this.w_MonthTargetSalesRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthTargetSalesRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthTargetSalesRate.Text = "123,45";
            this.w_MonthTargetSalesRate.Top = 0.125F;
            this.w_MonthTargetSalesRate.Width = 0.375F;
            // 
            // w_MonthProfit
            // 
            this.w_MonthProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfit.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfit.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfit.DataField = "MonthProfit";
            this.w_MonthProfit.Height = 0.125F;
            this.w_MonthProfit.Left = 8.0625F;
            this.w_MonthProfit.MultiLine = false;
            this.w_MonthProfit.Name = "w_MonthProfit";
            this.w_MonthProfit.OutputFormat = resources.GetString("w_MonthProfit.OutputFormat");
            this.w_MonthProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthProfit.SummaryGroup = "WareHouseHeader";
            this.w_MonthProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthProfit.Text = "123,546,789";
            this.w_MonthProfit.Top = 0.125F;
            this.w_MonthProfit.Width = 0.76F;
            // 
            // w_TermTotalCost
            // 
            this.w_TermTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermTotalCost.DataField = "TermPureSalesTotalCost";
            this.w_TermTotalCost.Height = 0.125F;
            this.w_TermTotalCost.Left = 5.875F;
            this.w_TermTotalCost.MultiLine = false;
            this.w_TermTotalCost.Name = "w_TermTotalCost";
            this.w_TermTotalCost.OutputFormat = resources.GetString("w_TermTotalCost.OutputFormat");
            this.w_TermTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermTotalCost.SummaryGroup = "WareHouseHeader";
            this.w_TermTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermTotalCost.Text = "1,234,567,890";
            this.w_TermTotalCost.Top = 0F;
            this.w_TermTotalCost.Width = 0.76F;
            // 
            // w_MonthSalesTargetMoney
            // 
            this.w_MonthSalesTargetMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetMoney.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetMoney.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetMoney.DataField = "MonthSalesTargetMoney";
            this.w_MonthSalesTargetMoney.Height = 0.125F;
            this.w_MonthSalesTargetMoney.Left = 6.6875F;
            this.w_MonthSalesTargetMoney.MultiLine = false;
            this.w_MonthSalesTargetMoney.Name = "w_MonthSalesTargetMoney";
            this.w_MonthSalesTargetMoney.OutputFormat = resources.GetString("w_MonthSalesTargetMoney.OutputFormat");
            this.w_MonthSalesTargetMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthSalesTargetMoney.SummaryGroup = "WareHouseHeader";
            this.w_MonthSalesTargetMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthSalesTargetMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthSalesTargetMoney.Text = "1,234,567,890";
            this.w_MonthSalesTargetMoney.Top = 0.125F;
            this.w_MonthSalesTargetMoney.Width = 0.76F;
            // 
            // w_TermProfitRate
            // 
            this.w_TermProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.w_TermProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.w_TermProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.w_TermProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.w_TermProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_TermProfitRate.Height = 0.125F;
            this.w_TermProfitRate.Left = 8.875F;
            this.w_TermProfitRate.MultiLine = false;
            this.w_TermProfitRate.Name = "w_TermProfitRate";
            this.w_TermProfitRate.OutputFormat = resources.GetString("w_TermProfitRate.OutputFormat");
            this.w_TermProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_TermProfitRate.SummaryGroup = "WareHouseHeader";
            this.w_TermProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_TermProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_TermProfitRate.Text = "123,45";
            this.w_TermProfitRate.Top = 0F;
            this.w_TermProfitRate.Width = 0.375F;
            // 
            // w_MonthProfitRate
            // 
            this.w_MonthProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthProfitRate.Height = 0.125F;
            this.w_MonthProfitRate.Left = 8.875F;
            this.w_MonthProfitRate.MultiLine = false;
            this.w_MonthProfitRate.Name = "w_MonthProfitRate";
            this.w_MonthProfitRate.OutputFormat = resources.GetString("w_MonthProfitRate.OutputFormat");
            this.w_MonthProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthProfitRate.SummaryGroup = "WareHouseHeader";
            this.w_MonthProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthProfitRate.Text = "123,45";
            this.w_MonthProfitRate.Top = 0.125F;
            this.w_MonthProfitRate.Width = 0.375F;
            // 
            // w_MonthTargetProfitRate
            // 
            this.w_MonthTargetProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthTargetProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthTargetProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthTargetProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthTargetProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthTargetProfitRate.Height = 0.125F;
            this.w_MonthTargetProfitRate.Left = 10.25F;
            this.w_MonthTargetProfitRate.MultiLine = false;
            this.w_MonthTargetProfitRate.Name = "w_MonthTargetProfitRate";
            this.w_MonthTargetProfitRate.OutputFormat = resources.GetString("w_MonthTargetProfitRate.OutputFormat");
            this.w_MonthTargetProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthTargetProfitRate.SummaryGroup = "WareHouseHeader";
            this.w_MonthTargetProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthTargetProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthTargetProfitRate.Text = "123,45";
            this.w_MonthTargetProfitRate.Top = 0.125F;
            this.w_MonthTargetProfitRate.Width = 0.375F;
            // 
            // w_MonthSalesTargetProfit
            // 
            this.w_MonthSalesTargetProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetProfit.Border.RightColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetProfit.Border.TopColor = System.Drawing.Color.Black;
            this.w_MonthSalesTargetProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.w_MonthSalesTargetProfit.DataField = "MonthSalesTargetProfit";
            this.w_MonthSalesTargetProfit.Height = 0.125F;
            this.w_MonthSalesTargetProfit.Left = 9.427F;
            this.w_MonthSalesTargetProfit.MultiLine = false;
            this.w_MonthSalesTargetProfit.Name = "w_MonthSalesTargetProfit";
            this.w_MonthSalesTargetProfit.OutputFormat = resources.GetString("w_MonthSalesTargetProfit.OutputFormat");
            this.w_MonthSalesTargetProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.w_MonthSalesTargetProfit.SummaryGroup = "WareHouseHeader";
            this.w_MonthSalesTargetProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.w_MonthSalesTargetProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.w_MonthSalesTargetProfit.Text = "123,546,789";
            this.w_MonthSalesTargetProfit.Top = 0.125F;
            this.w_MonthSalesTargetProfit.Width = 0.76F;
            // 
            // textBox23
            // 
            this.textBox23.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.RightColor = System.Drawing.Color.Black;
            this.textBox23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Border.TopColor = System.Drawing.Color.Black;
            this.textBox23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox23.Height = 0.125F;
            this.textBox23.Left = 4.9375F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox23.Text = "%";
            this.textBox23.Top = 0F;
            this.textBox23.Width = 0.125F;
            // 
            // textBox24
            // 
            this.textBox24.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.RightColor = System.Drawing.Color.Black;
            this.textBox24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Border.TopColor = System.Drawing.Color.Black;
            this.textBox24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox24.Height = 0.125F;
            this.textBox24.Left = 4.9375F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox24.Text = "%";
            this.textBox24.Top = 0.125F;
            this.textBox24.Width = 0.125F;
            // 
            // textBox26
            // 
            this.textBox26.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.RightColor = System.Drawing.Color.Black;
            this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.TopColor = System.Drawing.Color.Black;
            this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Height = 0.125F;
            this.textBox26.Left = 7.875F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox26.Text = "%";
            this.textBox26.Top = 0.125F;
            this.textBox26.Width = 0.125F;
            // 
            // textBox27
            // 
            this.textBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.RightColor = System.Drawing.Color.Black;
            this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.TopColor = System.Drawing.Color.Black;
            this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Height = 0.125F;
            this.textBox27.Left = 9.25F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox27.Text = "%";
            this.textBox27.Top = 0.125F;
            this.textBox27.Width = 0.125F;
            // 
            // textBox29
            // 
            this.textBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.RightColor = System.Drawing.Color.Black;
            this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.TopColor = System.Drawing.Color.Black;
            this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Height = 0.125F;
            this.textBox29.Left = 10.625F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox29.Text = "%";
            this.textBox29.Top = 0.125F;
            this.textBox29.Width = 0.125F;
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
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 9.25F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox5.Text = "%";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.125F;
            // 
            // DailyHeader
            // 
            this.DailyHeader.CanShrink = true;
            this.DailyHeader.DataField = "DailyHeaderField";
            this.DailyHeader.Height = 0F;
            this.DailyHeader.Name = "DailyHeader";
            this.DailyHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.DailyHeader.Visible = false;
            // 
            // DailyFooter
            // 
            this.DailyFooter.CanShrink = true;
            this.DailyFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.d_MonthTotalCost,
            this.d_MonthSalesTotalTaxExc,
            this.DailyTitle,
            this.d_TermProfit,
            this.textBox61,
            this.textBox62,
            this.d_TermSalesTotalTaxExc,
            this.d_TermSalesBackTotalTaxExc,
            this.d_TermSalesBackTotalTaxRate,
            this.d_TermSalesDisTtlTaxExc,
            this.d_MonthSalesBackTotalTaxExc,
            this.d_MonthSalesBackTotalTaxRate,
            this.d_MonthSalesDisTtlTaxExc,
            this.d_MonthTargetSalesRate,
            this.d_MonthProfit,
            this.d_TermTotalCost,
            this.d_MonthSalesTargetMoney,
            this.d_TermProfitRate,
            this.d_MonthProfitRate,
            this.d_MonthTargetProfitRate,
            this.d_MonthSalesTargetProfit,
            this.line3,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox21,
            this.textBox22});
            this.DailyFooter.Height = 0.34375F;
            this.DailyFooter.KeepTogether = true;
            this.DailyFooter.Name = "DailyFooter";
            this.DailyFooter.Visible = false;
            this.DailyFooter.Format += new System.EventHandler(this.DailyFooter_Format);
            this.DailyFooter.BeforePrint += new System.EventHandler(this.DailyFooter_BeforePrint);
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
            this.d_MonthTotalCost.DataField = "MonthPureSalesTotalCost";
            this.d_MonthTotalCost.Height = 0.125F;
            this.d_MonthTotalCost.Left = 5.875F;
            this.d_MonthTotalCost.MultiLine = false;
            this.d_MonthTotalCost.Name = "d_MonthTotalCost";
            this.d_MonthTotalCost.OutputFormat = resources.GetString("d_MonthTotalCost.OutputFormat");
            this.d_MonthTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthTotalCost.SummaryGroup = "DailyHeader";
            this.d_MonthTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthTotalCost.Text = "1,234,567,890";
            this.d_MonthTotalCost.Top = 0.125F;
            this.d_MonthTotalCost.Width = 0.76F;
            // 
            // d_MonthSalesTotalTaxExc
            // 
            this.d_MonthSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTotalTaxExc.DataField = "MonthSalesNetPrice";
            this.d_MonthSalesTotalTaxExc.Height = 0.125F;
            this.d_MonthSalesTotalTaxExc.Left = 3F;
            this.d_MonthSalesTotalTaxExc.MultiLine = false;
            this.d_MonthSalesTotalTaxExc.Name = "d_MonthSalesTotalTaxExc";
            this.d_MonthSalesTotalTaxExc.OutputFormat = resources.GetString("d_MonthSalesTotalTaxExc.OutputFormat");
            this.d_MonthSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthSalesTotalTaxExc.SummaryGroup = "DailyHeader";
            this.d_MonthSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesTotalTaxExc.Text = "1,234,567,890";
            this.d_MonthSalesTotalTaxExc.Top = 0.125F;
            this.d_MonthSalesTotalTaxExc.Width = 0.76F;
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
            this.DailyTitle.Height = 0.1875F;
            this.DailyTitle.Left = 2.0625F;
            this.DailyTitle.MultiLine = false;
            this.DailyTitle.Name = "DailyTitle";
            this.DailyTitle.OutputFormat = resources.GetString("DailyTitle.OutputFormat");
            this.DailyTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.DailyTitle.Text = "担当計";
            this.DailyTitle.Top = 0F;
            this.DailyTitle.Width = 0.5F;
            // 
            // d_TermProfit
            // 
            this.d_TermProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfit.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfit.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfit.DataField = "TermProfit";
            this.d_TermProfit.Height = 0.125F;
            this.d_TermProfit.Left = 8.0625F;
            this.d_TermProfit.MultiLine = false;
            this.d_TermProfit.Name = "d_TermProfit";
            this.d_TermProfit.OutputFormat = resources.GetString("d_TermProfit.OutputFormat");
            this.d_TermProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermProfit.SummaryGroup = "DailyHeader";
            this.d_TermProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermProfit.Text = "123,546,789";
            this.d_TermProfit.Top = 0F;
            this.d_TermProfit.Width = 0.76F;
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
            this.textBox61.Height = 0.125F;
            this.textBox61.Left = 2.625F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox61.Text = "日計";
            this.textBox61.Top = 0F;
            this.textBox61.Width = 0.3125F;
            // 
            // textBox62
            // 
            this.textBox62.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.RightColor = System.Drawing.Color.Black;
            this.textBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.TopColor = System.Drawing.Color.Black;
            this.textBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Height = 0.125F;
            this.textBox62.Left = 2.625F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.textBox62.Text = "累計";
            this.textBox62.Top = 0.125F;
            this.textBox62.Width = 0.3125F;
            // 
            // d_TermSalesTotalTaxExc
            // 
            this.d_TermSalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermSalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermSalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermSalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermSalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesTotalTaxExc.DataField = "TermSalesNetPrice";
            this.d_TermSalesTotalTaxExc.Height = 0.125F;
            this.d_TermSalesTotalTaxExc.Left = 3F;
            this.d_TermSalesTotalTaxExc.MultiLine = false;
            this.d_TermSalesTotalTaxExc.Name = "d_TermSalesTotalTaxExc";
            this.d_TermSalesTotalTaxExc.OutputFormat = resources.GetString("d_TermSalesTotalTaxExc.OutputFormat");
            this.d_TermSalesTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermSalesTotalTaxExc.SummaryGroup = "DailyHeader";
            this.d_TermSalesTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermSalesTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermSalesTotalTaxExc.Text = "1,234,567,890";
            this.d_TermSalesTotalTaxExc.Top = 0F;
            this.d_TermSalesTotalTaxExc.Width = 0.76F;
            // 
            // d_TermSalesBackTotalTaxExc
            // 
            this.d_TermSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxExc.DataField = "TermSalesBackNetPrice";
            this.d_TermSalesBackTotalTaxExc.Height = 0.125F;
            this.d_TermSalesBackTotalTaxExc.Left = 3.8125F;
            this.d_TermSalesBackTotalTaxExc.MultiLine = false;
            this.d_TermSalesBackTotalTaxExc.Name = "d_TermSalesBackTotalTaxExc";
            this.d_TermSalesBackTotalTaxExc.OutputFormat = resources.GetString("d_TermSalesBackTotalTaxExc.OutputFormat");
            this.d_TermSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermSalesBackTotalTaxExc.SummaryGroup = "DailyHeader";
            this.d_TermSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermSalesBackTotalTaxExc.Text = "123,546,789";
            this.d_TermSalesBackTotalTaxExc.Top = 0F;
            this.d_TermSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // d_TermSalesBackTotalTaxRate
            // 
            this.d_TermSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesBackTotalTaxRate.DataField = "TermSalesBackTotalTaxRate";
            this.d_TermSalesBackTotalTaxRate.Height = 0.125F;
            this.d_TermSalesBackTotalTaxRate.Left = 4.5625F;
            this.d_TermSalesBackTotalTaxRate.MultiLine = false;
            this.d_TermSalesBackTotalTaxRate.Name = "d_TermSalesBackTotalTaxRate";
            this.d_TermSalesBackTotalTaxRate.OutputFormat = resources.GetString("d_TermSalesBackTotalTaxRate.OutputFormat");
            this.d_TermSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermSalesBackTotalTaxRate.SummaryGroup = "DailyHeader";
            this.d_TermSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermSalesBackTotalTaxRate.Text = "123,45";
            this.d_TermSalesBackTotalTaxRate.Top = 0F;
            this.d_TermSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // d_TermSalesDisTtlTaxExc
            // 
            this.d_TermSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermSalesDisTtlTaxExc.DataField = "TermSalesDisTtlTaxExc";
            this.d_TermSalesDisTtlTaxExc.Height = 0.125F;
            this.d_TermSalesDisTtlTaxExc.Left = 5.125F;
            this.d_TermSalesDisTtlTaxExc.MultiLine = false;
            this.d_TermSalesDisTtlTaxExc.Name = "d_TermSalesDisTtlTaxExc";
            this.d_TermSalesDisTtlTaxExc.OutputFormat = resources.GetString("d_TermSalesDisTtlTaxExc.OutputFormat");
            this.d_TermSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermSalesDisTtlTaxExc.SummaryGroup = "DailyHeader";
            this.d_TermSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermSalesDisTtlTaxExc.Text = "123,546,789";
            this.d_TermSalesDisTtlTaxExc.Top = 0F;
            this.d_TermSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // d_MonthSalesBackTotalTaxExc
            // 
            this.d_MonthSalesBackTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxExc.DataField = "MonthSalesBackNetPrice";
            this.d_MonthSalesBackTotalTaxExc.Height = 0.125F;
            this.d_MonthSalesBackTotalTaxExc.Left = 3.8125F;
            this.d_MonthSalesBackTotalTaxExc.MultiLine = false;
            this.d_MonthSalesBackTotalTaxExc.Name = "d_MonthSalesBackTotalTaxExc";
            this.d_MonthSalesBackTotalTaxExc.OutputFormat = resources.GetString("d_MonthSalesBackTotalTaxExc.OutputFormat");
            this.d_MonthSalesBackTotalTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthSalesBackTotalTaxExc.SummaryGroup = "DailyHeader";
            this.d_MonthSalesBackTotalTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesBackTotalTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesBackTotalTaxExc.Text = "123,546,789";
            this.d_MonthSalesBackTotalTaxExc.Top = 0.125F;
            this.d_MonthSalesBackTotalTaxExc.Width = 0.6875F;
            // 
            // d_MonthSalesBackTotalTaxRate
            // 
            this.d_MonthSalesBackTotalTaxRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesBackTotalTaxRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesBackTotalTaxRate.DataField = "MonthSalesBackTotalTaxRate";
            this.d_MonthSalesBackTotalTaxRate.Height = 0.125F;
            this.d_MonthSalesBackTotalTaxRate.Left = 4.5625F;
            this.d_MonthSalesBackTotalTaxRate.MultiLine = false;
            this.d_MonthSalesBackTotalTaxRate.Name = "d_MonthSalesBackTotalTaxRate";
            this.d_MonthSalesBackTotalTaxRate.OutputFormat = resources.GetString("d_MonthSalesBackTotalTaxRate.OutputFormat");
            this.d_MonthSalesBackTotalTaxRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthSalesBackTotalTaxRate.SummaryGroup = "DailyHeader";
            this.d_MonthSalesBackTotalTaxRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesBackTotalTaxRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesBackTotalTaxRate.Text = "123,45";
            this.d_MonthSalesBackTotalTaxRate.Top = 0.125F;
            this.d_MonthSalesBackTotalTaxRate.Width = 0.375F;
            // 
            // d_MonthSalesDisTtlTaxExc
            // 
            this.d_MonthSalesDisTtlTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesDisTtlTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesDisTtlTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesDisTtlTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesDisTtlTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesDisTtlTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesDisTtlTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesDisTtlTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesDisTtlTaxExc.DataField = "MonthSalesDisTtlTaxExc";
            this.d_MonthSalesDisTtlTaxExc.Height = 0.125F;
            this.d_MonthSalesDisTtlTaxExc.Left = 5.125F;
            this.d_MonthSalesDisTtlTaxExc.MultiLine = false;
            this.d_MonthSalesDisTtlTaxExc.Name = "d_MonthSalesDisTtlTaxExc";
            this.d_MonthSalesDisTtlTaxExc.OutputFormat = resources.GetString("d_MonthSalesDisTtlTaxExc.OutputFormat");
            this.d_MonthSalesDisTtlTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthSalesDisTtlTaxExc.SummaryGroup = "DailyHeader";
            this.d_MonthSalesDisTtlTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesDisTtlTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesDisTtlTaxExc.Text = "123,546,789";
            this.d_MonthSalesDisTtlTaxExc.Top = 0.125F;
            this.d_MonthSalesDisTtlTaxExc.Width = 0.6875F;
            // 
            // d_MonthTargetSalesRate
            // 
            this.d_MonthTargetSalesRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthTargetSalesRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetSalesRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthTargetSalesRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetSalesRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthTargetSalesRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetSalesRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthTargetSalesRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetSalesRate.Height = 0.125F;
            this.d_MonthTargetSalesRate.Left = 7.5F;
            this.d_MonthTargetSalesRate.MultiLine = false;
            this.d_MonthTargetSalesRate.Name = "d_MonthTargetSalesRate";
            this.d_MonthTargetSalesRate.OutputFormat = resources.GetString("d_MonthTargetSalesRate.OutputFormat");
            this.d_MonthTargetSalesRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthTargetSalesRate.SummaryGroup = "DailyHeader";
            this.d_MonthTargetSalesRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthTargetSalesRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthTargetSalesRate.Text = "123,45";
            this.d_MonthTargetSalesRate.Top = 0.125F;
            this.d_MonthTargetSalesRate.Width = 0.375F;
            // 
            // d_MonthProfit
            // 
            this.d_MonthProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfit.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfit.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfit.DataField = "MonthProfit";
            this.d_MonthProfit.Height = 0.125F;
            this.d_MonthProfit.Left = 8.0625F;
            this.d_MonthProfit.MultiLine = false;
            this.d_MonthProfit.Name = "d_MonthProfit";
            this.d_MonthProfit.OutputFormat = resources.GetString("d_MonthProfit.OutputFormat");
            this.d_MonthProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthProfit.SummaryGroup = "DailyHeader";
            this.d_MonthProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthProfit.Text = "123,546,789";
            this.d_MonthProfit.Top = 0.125F;
            this.d_MonthProfit.Width = 0.76F;
            // 
            // d_TermTotalCost
            // 
            this.d_TermTotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermTotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermTotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermTotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermTotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermTotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermTotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermTotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermTotalCost.DataField = "TermPureSalesTotalCost";
            this.d_TermTotalCost.Height = 0.125F;
            this.d_TermTotalCost.Left = 5.875F;
            this.d_TermTotalCost.MultiLine = false;
            this.d_TermTotalCost.Name = "d_TermTotalCost";
            this.d_TermTotalCost.OutputFormat = resources.GetString("d_TermTotalCost.OutputFormat");
            this.d_TermTotalCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermTotalCost.SummaryGroup = "DailyHeader";
            this.d_TermTotalCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermTotalCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermTotalCost.Text = "1,234,567,890";
            this.d_TermTotalCost.Top = 0F;
            this.d_TermTotalCost.Width = 0.76F;
            // 
            // d_MonthSalesTargetMoney
            // 
            this.d_MonthSalesTargetMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetMoney.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetMoney.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetMoney.DataField = "MonthSalesTargetMoney";
            this.d_MonthSalesTargetMoney.Height = 0.125F;
            this.d_MonthSalesTargetMoney.Left = 6.6875F;
            this.d_MonthSalesTargetMoney.MultiLine = false;
            this.d_MonthSalesTargetMoney.Name = "d_MonthSalesTargetMoney";
            this.d_MonthSalesTargetMoney.OutputFormat = resources.GetString("d_MonthSalesTargetMoney.OutputFormat");
            this.d_MonthSalesTargetMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthSalesTargetMoney.SummaryGroup = "DailyHeader";
            this.d_MonthSalesTargetMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesTargetMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesTargetMoney.Text = "1,234,567,890";
            this.d_MonthSalesTargetMoney.Top = 0.125F;
            this.d_MonthSalesTargetMoney.Width = 0.76F;
            // 
            // d_TermProfitRate
            // 
            this.d_TermProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_TermProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_TermProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_TermProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_TermProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_TermProfitRate.Height = 0.125F;
            this.d_TermProfitRate.Left = 8.875F;
            this.d_TermProfitRate.MultiLine = false;
            this.d_TermProfitRate.Name = "d_TermProfitRate";
            this.d_TermProfitRate.OutputFormat = resources.GetString("d_TermProfitRate.OutputFormat");
            this.d_TermProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_TermProfitRate.SummaryGroup = "DailyHeader";
            this.d_TermProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_TermProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_TermProfitRate.Text = "123,45";
            this.d_TermProfitRate.Top = 0F;
            this.d_TermProfitRate.Width = 0.375F;
            // 
            // d_MonthProfitRate
            // 
            this.d_MonthProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthProfitRate.Height = 0.125F;
            this.d_MonthProfitRate.Left = 8.875F;
            this.d_MonthProfitRate.MultiLine = false;
            this.d_MonthProfitRate.Name = "d_MonthProfitRate";
            this.d_MonthProfitRate.OutputFormat = resources.GetString("d_MonthProfitRate.OutputFormat");
            this.d_MonthProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthProfitRate.SummaryGroup = "DailyHeader";
            this.d_MonthProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthProfitRate.Text = "123,45";
            this.d_MonthProfitRate.Top = 0.125F;
            this.d_MonthProfitRate.Width = 0.375F;
            // 
            // d_MonthTargetProfitRate
            // 
            this.d_MonthTargetProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthTargetProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthTargetProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthTargetProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthTargetProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthTargetProfitRate.Height = 0.125F;
            this.d_MonthTargetProfitRate.Left = 10.25F;
            this.d_MonthTargetProfitRate.MultiLine = false;
            this.d_MonthTargetProfitRate.Name = "d_MonthTargetProfitRate";
            this.d_MonthTargetProfitRate.OutputFormat = resources.GetString("d_MonthTargetProfitRate.OutputFormat");
            this.d_MonthTargetProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthTargetProfitRate.SummaryGroup = "DailyHeader";
            this.d_MonthTargetProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthTargetProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthTargetProfitRate.Text = "123,45";
            this.d_MonthTargetProfitRate.Top = 0.125F;
            this.d_MonthTargetProfitRate.Width = 0.375F;
            // 
            // d_MonthSalesTargetProfit
            // 
            this.d_MonthSalesTargetProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetProfit.Border.RightColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetProfit.Border.TopColor = System.Drawing.Color.Black;
            this.d_MonthSalesTargetProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.d_MonthSalesTargetProfit.DataField = "MonthSalesTargetProfit";
            this.d_MonthSalesTargetProfit.Height = 0.125F;
            this.d_MonthSalesTargetProfit.Left = 9.427F;
            this.d_MonthSalesTargetProfit.MultiLine = false;
            this.d_MonthSalesTargetProfit.Name = "d_MonthSalesTargetProfit";
            this.d_MonthSalesTargetProfit.OutputFormat = resources.GetString("d_MonthSalesTargetProfit.OutputFormat");
            this.d_MonthSalesTargetProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.d_MonthSalesTargetProfit.SummaryGroup = "DailyHeader";
            this.d_MonthSalesTargetProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.d_MonthSalesTargetProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.d_MonthSalesTargetProfit.Text = "123,546,789";
            this.d_MonthSalesTargetProfit.Top = 0.125F;
            this.d_MonthSalesTargetProfit.Width = 0.76F;
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
            this.line3.Left = 0.0625F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.9F;
            this.line3.X1 = 0.0625F;
            this.line3.X2 = 10.9F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 4.9375F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox9.Text = "%";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.125F;
            // 
            // textBox10
            // 
            this.textBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.RightColor = System.Drawing.Color.Black;
            this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Border.TopColor = System.Drawing.Color.Black;
            this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox10.Height = 0.125F;
            this.textBox10.Left = 4.9375F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox10.Text = "%";
            this.textBox10.Top = 0.125F;
            this.textBox10.Width = 0.125F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Height = 0.125F;
            this.textBox11.Left = 7.875F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox11.Text = "%";
            this.textBox11.Top = 0.125F;
            this.textBox11.Width = 0.125F;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightColor = System.Drawing.Color.Black;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopColor = System.Drawing.Color.Black;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 9.25F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox12.Text = "%";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.125F;
            // 
            // textBox21
            // 
            this.textBox21.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.RightColor = System.Drawing.Color.Black;
            this.textBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Border.TopColor = System.Drawing.Color.Black;
            this.textBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox21.Height = 0.125F;
            this.textBox21.Left = 9.25F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox21.Text = "%";
            this.textBox21.Top = 0.125F;
            this.textBox21.Width = 0.125F;
            // 
            // textBox22
            // 
            this.textBox22.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.RightColor = System.Drawing.Color.Black;
            this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.TopColor = System.Drawing.Color.Black;
            this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Height = 0.125F;
            this.textBox22.Left = 10.625F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; white-space: nowrap; vertical-align: top; ";
            this.textBox22.Text = "%";
            this.textBox22.Top = 0.125F;
            this.textBox22.Width = 0.125F;
            // 
            // DCTOK02012P_02A4C
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
            this.PrintWidth = 11.0625F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckPriceDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsDayRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGdsMonthRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisDayMonthRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetStcPrcMonthTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SortTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ProDuctNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTargetSalesRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesTargetMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TermProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthTargetProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_MonthSalesTargetProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionHeaderLineTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTargetSalesRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesTargetMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TermProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthTargetProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_MonthSalesTargetProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseHeaderLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseHeaderLineName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WareHouseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthTargetSalesRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesTargetMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_TermProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthTargetProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.w_MonthSalesTargetProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DailyTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesBackTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesBackTotalTaxRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesDisTtlTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTargetSalesRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermTotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesTargetMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_TermProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthTargetProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_MonthSalesTargetProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

		private void TitleFooter_Format(object sender, EventArgs e)
		{

		}

	}
}
