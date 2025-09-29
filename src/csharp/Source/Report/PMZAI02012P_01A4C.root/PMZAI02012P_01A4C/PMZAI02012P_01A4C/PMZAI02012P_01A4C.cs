//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫月報年報
// プログラム概要   : 在庫月報年報の印刷フォーム。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長沼 賢二
// 作 成 日  2008/07/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/10  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/02/26  修正内容 : 明細ヘッダが仕入先が変わるタイミングでも表示されるよう修正。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/24  修正内容 : 不具合対応[12679]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12802]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/28  修正内容 : 不具合対応[13401]
//                                  ・GroupKeepTogetherをFirstDetailに修正
//                                  ・SupplierHeader、WarehouseHeader、GrandTotalHeaderのRepeatStyleをOnPageIncludeNoDetailに修正
//----------------------------------------------------------------------------//
// 管理番号  11175324-00 作成担当 : 譚洪
// 修 正 日  2015/10/02  修正内容 : Redmine#47391 ｸﾞﾙｰﾌﾟ計・中分類計・大分計・メーカー計・仕入先計・倉庫計・総合計に対してのマークが不具合対応
//----------------------------------------------------------------------------//
// 管理番号  11175324-00 作成担当 : 李侠
// 修 正 日  2015/10/08  修正内容 : Redmine#47391の#16マークが不具合対応
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
	/// 在庫月報年報印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 在庫月報年報のフォームクラスです。</br>
	/// <br>Programmer   : 30416 長沼 賢二</br>
	/// <br>Date         : 2008.07.17</br>
	/// <br></br>
	/// <br>UpdateNote   : 2008/10/10 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>UpdateNote   : 2009/02/26 上野 俊治　明細ヘッダが仕入先が変わるタイミングでも表示されるよう修正。</br>
    /// <br>             : 2009/03/24 照田 貴志　不具合対応[12679]</br>
    /// <br>             : 2009/03/27 照田 貴志　不具合対応[12802]</br>
    /// <br>             : 2009/05/28 照田 貴志　不具合対応[13401]</br>
    /// <br>               ・GroupKeepTogetherをFirstDetailに修正</br>
    /// <br>               ・SupplierHeader、WarehouseHeader、GrandTotalHeaderのRepeatStyleをOnPageIncludeNoDetailに修正</br>
    /// <br>UpdateNote   : 2015/10/02 譚洪　Redmine#47391 ｸﾞﾙｰﾌﾟ計・中分類計・大分計・メーカー計・仕入先計・倉庫計・総合計に対してのマークが不具合対応</br>
    /// <br>UpdateNote   : 2015/10/08 李侠　Redmine#47391の#16に対してのマークが不具合対応</br>
    /// <br>             :</br>
	/// </remarks>
	public class PMZAI02012P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 在庫月報年報フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 在庫月報年報フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer   : 30416　長沼 賢二</br>
		/// <br>Date         : 2008.07.17</br>
		/// </remarks>
		public PMZAI02012P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									    // 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				    // 抽出条件
		private int					_pageFooterOutCode;				    // フッター出力区分
		private StringCollection	_pageFooters;					    // フッターメッセージ
		private	SFCMN06002C			_printInfo;						    // 印刷情報クラス
		private string				_pageHeaderTitle;				    // フォームタイトル
		private string				_pageHeaderSortOderTitle;		    // ソート順

        private StockMonthYearReportCndtn _stockMonthYearReportCndtn;   // 抽出条件クラス

        private bool _extraHeaderVisible = true;                        // 抽出条件ヘッダ表示フラグ     //ADD 2009/05/28 不具合対応[13401]

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private GroupHeader GoodsMakerHeader;
        private GroupFooter GoodsMakerFooter;
        private TextBox GOODSMAKERTITLE;
        private GroupHeader SupplierHeader;
        private GroupFooter SupplierFooter;
        private TextBox SUPPLIERTITLE;
        private GroupHeader LargeGoodsGanreHeader;
        private GroupFooter LargeGoodsGanreFooter;
        private TextBox LGOODSGANRETITLE;
        private GroupHeader MediumGoodsGanreHeader;
        private GroupFooter MediumGoodsGanreFooter;
        private TextBox MGOODSGANRETITLE;
        private Label Lb_LMonthStockCnt;
        private TextBox LMonthStockCnt;
        private Label Lb_StockCount;
        private Label Lb_MoveArrivalCnt;
        private Label Lb_TotalArrivalCnt;
        private Label Lb_MoveShipmentCnt;
        private Label Lb_TotalShipmentCnt;
        private Label Lb_SalesCount;
        private TextBox StockCount;
        private TextBox MoveArrivalCnt;
        private TextBox TotalArrivalCnt;
        private TextBox SalesCount;
        private TextBox MoveShipmentCnt;
        private TextBox TotalShipmentCnt;
        private Label Lb_LMonthStockPrice;
        private TextBox LMonthStockPrice;
        private Label Lb_StockPriceTaxExc;
        private Label Lb_MoveArrivalPrice;
        private Label Lb_TotalArrivalPrice;
        private Label Lb_SalesMoneyTaxExc;
        private Label Lb_MoveShipmentPrice;
        private Label Lb_TotalShipmentPrice;
        private Label Lb_GrossProfit;
        private Label Lb_Mark;
        private TextBox StockPriceTaxExc;
        private TextBox MoveArrivalPrice;
        private TextBox TotalArrivalPrice;
        private TextBox SalesMoneyTaxExc;
        private Label Lb_MaximumStockCnt;
        private Label Lb_MinimumStockCnt;
        private Label Lb_SalesCost;
        private Label Lb_TurnOver;
        private TextBox MaximumStockCnt;
        private TextBox MinimumStockCnt;
        private TextBox SalesCost;
        private TextBox TurnOver;
        private TextBox MoveShipmentPrice;
        private TextBox TotalShipmentPrice;
        private TextBox GrossProfit;
        private TextBox Mark;
        private TextBox GrossProfitRate;
        private TextBox StockTotal;
        private TextBox StockMashinePrice;
        private Label Lb_GrossProfitRate;
        private Label Lb_StockTotal;
        private Label Lb_StockMashinePrice;
        private GroupHeader DetailGoodsGanreHeader;
        private GroupFooter DetailGoodsGanreFooter;
        private TextBox GROUPTOTALTITLE;
        private TextBox GoodsMakerCode;
        private TextBox MakerName;
        private TextBox Gm_LMonthStockPrice;
        private TextBox Gm_StockPriceTaxExc;
        private TextBox Gm_MoveArrivalPrice;
        private TextBox Gm_TotalArrivalPrice;
        private TextBox Gm_SalesMoneyTaxExc;
        private TextBox Gm_MoveShipmentPrice;
        private TextBox Gm_TotalShipmentPrice;
        private TextBox Gm_GrossProfit;
        private TextBox Gm_Mark;
        private TextBox Gm_GrossProfitRate;
        private TextBox Gm_StockTotal;
        private TextBox Gm_StockMashinePrice;
        private TextBox Wh_SalesMoneyTaxExc;
        private TextBox Wh_LMonthStockPrice;
        private TextBox Wh_StockPriceTaxExc;
        private TextBox Wh_MoveArrivalPrice;
        private TextBox Wh_TotalArrivalPrice;
        private TextBox Wh_MoveShipmentPrice;
        private TextBox Wh_TotalShipmentPrice;
        private TextBox Wh_GrossProfitRate;
        private TextBox Wh_StockTotal;
        private TextBox Wh_StockMashinePrice;
        private TextBox Wh_Mark;
        private TextBox Wh_GrossProfit;
        private TextBox Sup_GrossProfit;
        private TextBox Sup_LMonthStockPrice;
        private TextBox Sup_StockPriceTaxExc;
        private TextBox Sup_MoveArrivalPrice;
        private TextBox Sup_TotalArrivalPrice;
        private TextBox Sup_MoveShipmentPrice;
        private TextBox Sup_TotalShipmentPrice;
        private TextBox Sup_GrossProfitRate;
        private TextBox Sup_StockTotal;
        private TextBox Sup_StockMashinePrice;
        private TextBox Sup_SalesMoneyTaxExc;
        private TextBox Sup_Mark;
        private TextBox Ttl_LMonthStockPrice;
        private TextBox Ttl_GrossProfitRate;
        private TextBox Ttl_StockTotal;
        private TextBox Ttl_StockPriceTaxExc;
        private TextBox Ttl_MoveArrivalPrice;
        private TextBox Ttl_StockMashinePrice;
        private TextBox Ttl_TotalArrivalPrice;
        private TextBox Ttl_SalesMoneyTaxExc;
        private TextBox Ttl_MoveShipmentPrice;
        private TextBox Ttl_TotalShipmentPrice;
        private TextBox Ttl_GrossProfit;
        private TextBox Ttl_Mark;
        private TextBox GoodsLGroupName;
        private TextBox GoodsLGroupCode;
        private TextBox Lg_LMonthStockPrice;
        private TextBox Lg_GrossProfitRate;
        private TextBox Lg_StockTotal;
        private TextBox Lg_StockPriceTaxExc;
        private TextBox Lg_MoveArrivalPrice;
        private TextBox Lg_StockMashinePrice;
        private TextBox Lg_TotalArrivalPrice;
        private TextBox Lg_SalesMoneyTaxExc;
        private TextBox Lg_MoveShipmentPrice;
        private TextBox Lg_TotalShipmentPrice;
        private TextBox Lg_GrossProfit;
        private TextBox Lg_Mark;
        private TextBox GoodsMGroupName;
        private TextBox GoodsMGroupCode;
        private TextBox Mg_LMonthStockPrice;
        private TextBox Mg_GrossProfitRate;
        private TextBox Mg_StockTotal;
        private TextBox Mg_StockPriceTaxExc;
        private TextBox Mg_MoveArrivalPrice;
        private TextBox Mg_StockMashinePrice;
        private TextBox Mg_TotalArrivalPrice;
        private TextBox Mg_SalesMoneyTaxExc;
        private TextBox Mg_MoveShipmentPrice;
        private TextBox Mg_TotalShipmentPrice;
        private TextBox Mg_GrossProfit;
        private TextBox Mg_Mark;
        private TextBox BLGroupName;
        private TextBox BLGroupCode;
        private TextBox Blg_LMonthStockPrice;
        private TextBox Blg_GrossProfitRate;
        private TextBox Blg_StockTotal;
        private TextBox Blg_StockPriceTaxExc;
        private TextBox Blg_MoveArrivalPrice;
        private TextBox Blg_StockMashinePrice;
        private TextBox Blg_TotalArrivalPrice;
        private TextBox Blg_SalesMoneyTaxExc;
        private TextBox Blg_MoveShipmentPrice;
        private TextBox Blg_TotalShipmentPrice;
        private TextBox Blg_GrossProfit;
        private TextBox Blg_Mark;
        private Line line9;
        private Line line8;
        private Line line6;
        private Line line4;
        private Line line3;
        private Label label1;
        private Label label4;
        private Line line2;
        private Line line11;
        private TextBox Wh_WarehouseCode;
        private TextBox Wh_WarehouseName;
        private Line Line7;
        private TextBox Wh_StockSupplierCode;
        private TextBox Wh_SupplierSnm;
        private TextBox WarehouseName;
        private TextBox WarehouseCode;
        private TextBox StockSupplierCode;
        private TextBox SupplierSnm;

		// Disposeチェック用フラグ
		bool disposed = false;

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
                this._stockMonthYearReportCndtn = (StockMonthYearReportCndtn)this._printInfo.jyoken;
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
				// TODO:  DCZAI02163P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  DCZAI02163P_01A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            // --- ADD 2008/10/10 ------------------------------------------------------------------------------>>>>>
            // グループ対象の項目指定
            this.WarehouseHeader.DataField = "Sort_WarehouseCode";
            this.SupplierHeader.DataField = "Sort_CustomerCode";
            this.GoodsMakerHeader.DataField = "Sort_GoodsMakerCd";
            this.LargeGoodsGanreHeader.DataField = "Sort_GoodsLGroupCode";
            this.MediumGoodsGanreHeader.DataField = "Sort_GoodsMGroupCode";
            this.DetailGoodsGanreHeader.DataField = "Sort_BLGroupCode";

            // 改頁
            if (this._stockMonthYearReportCndtn.NewPageDiv == StockMonthYearReportCndtn.NewPageDivState.EachSummaly)
            {
                // 倉庫
                this.WarehouseHeader.NewPage = NewPage.Before;
                this.WarehouseHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                // しない
                this.WarehouseHeader.NewPage = NewPage.None;
                //this.WarehouseHeader.RepeatStyle = RepeatStyle.OnPage;                //DEL 2009/05/28 不具合対応[13401]
                this.WarehouseHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;   //ADD 2009/05/28 不具合対応[13401]
            }
            // --- ADD 2008/10/10 ------------------------------------------------------------------------------<<<<<

            #region ＜＜　各合計の　印字有無制御　＞＞
            // メーカー計なし
            if (this._stockMonthYearReportCndtn.GoodsMakerSummaryPrintDiv == StockMonthYearReportCndtn.SummaryPrintDivState.None)
            {
                this.GoodsMakerHeader.Visible = false;
                this.GoodsMakerFooter.Visible = false;
            }
            // 倉庫計なし
            if (this._stockMonthYearReportCndtn.WarehouseSummaryPrintDiv == StockMonthYearReportCndtn.SummaryPrintDivState.None)
            {
                //this.WarehouseHeader.Visible = false;
                this.WarehouseFooter.Visible = false;
            }
            // 仕入先計なし
            if (this._stockMonthYearReportCndtn.SupplierSummaryPrintDiv == StockMonthYearReportCndtn.SummaryPrintDivState.None)
            {
                //this.SupplierHeader.Visible = false; // DEL 2009/02/26
                this.SupplierFooter.Visible = false;
            }
            // 商品大分類計なし
            if (this._stockMonthYearReportCndtn.LargeGoodsGanreSummaryPrintDiv == StockMonthYearReportCndtn.SummaryPrintDivState.None)
            {
                this.LargeGoodsGanreHeader.Visible = false;
                this.LargeGoodsGanreFooter.Visible = false;
            }
            // 商品中分類計なし
            if (this._stockMonthYearReportCndtn.MediumGoodsGanreSummaryPrintDiv == StockMonthYearReportCndtn.SummaryPrintDivState.None)
            {
                this.MediumGoodsGanreHeader.Visible = false;
                this.MediumGoodsGanreFooter.Visible = false;
            }
            // BLグループ計なし
            if (this._stockMonthYearReportCndtn.DetailGoodsGanreSummaryPrintDiv == StockMonthYearReportCndtn.SummaryPrintDivState.None)
            {
                this.DetailGoodsGanreHeader.Visible = false;
                this.DetailGoodsGanreFooter.Visible = false;
            }      
            #endregion

        }
        /// <summary>
        /// 範囲月数の取得処理
        /// </summary>
        /// <returns>範囲月数（ex.４月～６月ならば３）</returns>
        private int GetMonthRange(DateTime stYearMonth, DateTime edYearMonth)
        {
            int stMonth = stYearMonth.Month;
            int edMonth = edYearMonth.Month;

            if (edYearMonth.Year > stYearMonth.Year) {
                edMonth += 12;
            }

            return (edMonth - stMonth + 1);
        }
		#endregion ◆ レポート要素出力設定


		#region ◆ グループサプレス関係
		#region ◎ グループサプレス判断
		/// <summary>
		/// グループサプレス判断
		/// </summary>
		private void CheckGroupSuppression()
		{
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。
		}
		#endregion
		#endregion
		#endregion

		#region ■ Control Event

		#region ◎ DCZAI02163P_01A4C_ReportStart Event
		/// <summary>
		/// DCZAI02163P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ DCZAI02163P_01A4C_PageEnd Event
		/// <summary>
		/// DCZAI02163P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: DCZAI02163P_01A4C_PageEnd Event</br>
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( StockMonthYearReportCndtn.ct_DateFomat, DateTime.Now );
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 拠点オプション有無判定
            //string sectionTitle = string.Format( "{0}拠点：", this._stockNoShipmentListCndtn.MainExtractTitle );
            //if ( this._stockNoShipmentListCndtn.IsOptSection )
            //{
            //    if ( this._stockNoShipmentListCndtn.IsSelectAllSection )
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "全社" );
            //    }
            //    else
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    }

            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
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
		/// <br>Programmer  : 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行KEY退避をクリア（次明細はサプレス解除）
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		private DataDynamics.ActiveReports.Label Lb_GoodsNo;
		private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_WarehouseShelfNo;
		private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox GoodsNo;
		private DataDynamics.ActiveReports.TextBox GoodsName;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.TextBox WAREHOUSETITLE;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
        private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMZAI02012P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.LMonthStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.StockCount = new DataDynamics.ActiveReports.TextBox();
            this.MoveArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.TotalArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesCount = new DataDynamics.ActiveReports.TextBox();
            this.MoveShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.TotalShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.SalesCost = new DataDynamics.ActiveReports.TextBox();
            this.TurnOver = new DataDynamics.ActiveReports.TextBox();
            this.MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Mark = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
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
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_MoveArrivalCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_TotalArrivalCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MoveShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_TotalShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesCount = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Lb_MoveArrivalPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_TotalArrivalPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoneyTaxExc = new DataDynamics.ActiveReports.Label();
            this.Lb_MoveShipmentPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_TotalShipmentPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_GrossProfit = new DataDynamics.ActiveReports.Label();
            this.Lb_Mark = new DataDynamics.ActiveReports.Label();
            this.Lb_MaximumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesCost = new DataDynamics.ActiveReports.Label();
            this.Lb_TurnOver = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_LMonthStockPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_LMonthStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_StockCount = new DataDynamics.ActiveReports.Label();
            this.Lb_StockPriceTaxExc = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_StockMashinePrice = new DataDynamics.ActiveReports.Label();
            this.Lb_StockTotal = new DataDynamics.ActiveReports.Label();
            this.Lb_MinimumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_GrossProfitRate = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_Mark = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.WAREHOUSETITLE = new DataDynamics.ActiveReports.TextBox();
            this.Wh_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.Wh_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Wh_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Wh_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Wh_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.Wh_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Wh_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Wh_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Wh_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Wh_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.Wh_Mark = new DataDynamics.ActiveReports.TextBox();
            this.Wh_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.GoodsMakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GOODSMAKERTITLE = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCode = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.Gm_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Gm_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Gm_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Gm_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Gm_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Gm_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Gm_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Gm_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Gm_Mark = new DataDynamics.ActiveReports.TextBox();
            this.Gm_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Gm_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Gm_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Wh_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.Wh_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Wh_StockSupplierCode = new DataDynamics.ActiveReports.TextBox();
            this.Wh_SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SUPPLIERTITLE = new DataDynamics.ActiveReports.TextBox();
            this.StockSupplierCode = new DataDynamics.ActiveReports.TextBox();
            this.Sup_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.Sup_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Sup_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Sup_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Sup_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Sup_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Sup_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Sup_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Sup_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Sup_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.Sup_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Sup_Mark = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.LargeGoodsGanreHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.LargeGoodsGanreFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.LGOODSGANRETITLE = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Lg_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Lg_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Lg_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Lg_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Lg_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Lg_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.Lg_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Lg_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Lg_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Lg_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Lg_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Lg_Mark = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.MediumGoodsGanreHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MediumGoodsGanreFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.MGOODSGANRETITLE = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Mg_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Mg_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Mg_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Mg_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Mg_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Mg_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.Mg_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Mg_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Mg_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Mg_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Mg_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Mg_Mark = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.DetailGoodsGanreHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DetailGoodsGanreFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GROUPTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupName = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Blg_LMonthStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Blg_GrossProfitRate = new DataDynamics.ActiveReports.TextBox();
            this.Blg_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.Blg_StockPriceTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Blg_MoveArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Blg_StockMashinePrice = new DataDynamics.ActiveReports.TextBox();
            this.Blg_TotalArrivalPrice = new DataDynamics.ActiveReports.TextBox();
            this.Blg_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Blg_MoveShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Blg_TotalShipmentPrice = new DataDynamics.ActiveReports.TextBox();
            this.Blg_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Blg_Mark = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMonthStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TurnOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LMonthStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WAREHOUSETITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GOODSMAKERTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockSupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SUPPLIERTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSupplierCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LGOODSGANRETITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MGOODSGANRETITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GROUPTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_LMonthStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_GrossProfitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_StockPriceTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_MoveArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_StockMashinePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_TotalArrivalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_MoveShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_TotalShipmentPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.GoodsName,
            this.WarehouseShelfNo,
            this.LMonthStockCnt,
            this.StockCount,
            this.MoveArrivalCnt,
            this.TotalArrivalCnt,
            this.SalesCount,
            this.MoveShipmentCnt,
            this.TotalShipmentCnt,
            this.LMonthStockPrice,
            this.StockPriceTaxExc,
            this.MoveArrivalPrice,
            this.TotalArrivalPrice,
            this.SalesMoneyTaxExc,
            this.MaximumStockCnt,
            this.MinimumStockCnt,
            this.SalesCost,
            this.TurnOver,
            this.MoveShipmentPrice,
            this.TotalShipmentPrice,
            this.GrossProfit,
            this.Mark,
            this.GrossProfitRate,
            this.StockTotal,
            this.StockMashinePrice,
            this.line11});
            this.Detail.Height = 0.625F;
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
            this.GoodsNo.Height = 0.156F;
            this.GoodsNo.Left = 0.0625F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.25F;
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
            this.GoodsName.Height = 0.156F;
            this.GoodsName.Left = 1.3125F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1F;
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
            this.WarehouseShelfNo.Left = 2.3125F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0.0625F;
            this.WarehouseShelfNo.Width = 0.4375F;
            // 
            // LMonthStockCnt
            // 
            this.LMonthStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.LMonthStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.LMonthStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.LMonthStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.LMonthStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockCnt.DataField = "LMonthStockCnt";
            this.LMonthStockCnt.Height = 0.156F;
            this.LMonthStockCnt.Left = 2.75F;
            this.LMonthStockCnt.MultiLine = false;
            this.LMonthStockCnt.Name = "LMonthStockCnt";
            this.LMonthStockCnt.OutputFormat = resources.GetString("LMonthStockCnt.OutputFormat");
            this.LMonthStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.LMonthStockCnt.Text = "1,234,567";
            this.LMonthStockCnt.Top = 0.0625F;
            this.LMonthStockCnt.Width = 0.5F;
            // 
            // StockCount
            // 
            this.StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCount.DataField = "StockCount";
            this.StockCount.Height = 0.156F;
            this.StockCount.Left = 3.25F;
            this.StockCount.MultiLine = false;
            this.StockCount.Name = "StockCount";
            this.StockCount.OutputFormat = resources.GetString("StockCount.OutputFormat");
            this.StockCount.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockCount.Text = "1,234,567";
            this.StockCount.Top = 0.0625F;
            this.StockCount.Width = 0.75F;
            // 
            // MoveArrivalCnt
            // 
            this.MoveArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MoveArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MoveArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalCnt.DataField = "MoveArrivalCnt";
            this.MoveArrivalCnt.Height = 0.156F;
            this.MoveArrivalCnt.Left = 4F;
            this.MoveArrivalCnt.MultiLine = false;
            this.MoveArrivalCnt.Name = "MoveArrivalCnt";
            this.MoveArrivalCnt.OutputFormat = resources.GetString("MoveArrivalCnt.OutputFormat");
            this.MoveArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MoveArrivalCnt.Text = "1,234,567";
            this.MoveArrivalCnt.Top = 0.0625F;
            this.MoveArrivalCnt.Width = 0.75F;
            // 
            // TotalArrivalCnt
            // 
            this.TotalArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.TotalArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.TotalArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalCnt.DataField = "TotalArrivalCnt";
            this.TotalArrivalCnt.Height = 0.156F;
            this.TotalArrivalCnt.Left = 4.75F;
            this.TotalArrivalCnt.MultiLine = false;
            this.TotalArrivalCnt.Name = "TotalArrivalCnt";
            this.TotalArrivalCnt.OutputFormat = resources.GetString("TotalArrivalCnt.OutputFormat");
            this.TotalArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalArrivalCnt.Text = "1,234,567";
            this.TotalArrivalCnt.Top = 0.0625F;
            this.TotalArrivalCnt.Width = 0.75F;
            // 
            // SalesCount
            // 
            this.SalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCount.DataField = "SalesCount";
            this.SalesCount.Height = 0.156F;
            this.SalesCount.Left = 5.5F;
            this.SalesCount.MultiLine = false;
            this.SalesCount.Name = "SalesCount";
            this.SalesCount.OutputFormat = resources.GetString("SalesCount.OutputFormat");
            this.SalesCount.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesCount.Text = "1,234,567";
            this.SalesCount.Top = 0.0625F;
            this.SalesCount.Width = 0.75F;
            // 
            // MoveShipmentCnt
            // 
            this.MoveShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MoveShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MoveShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveShipmentCnt.DataField = "MoveShipmentCnt";
            this.MoveShipmentCnt.Height = 0.156F;
            this.MoveShipmentCnt.Left = 6.25F;
            this.MoveShipmentCnt.MultiLine = false;
            this.MoveShipmentCnt.Name = "MoveShipmentCnt";
            this.MoveShipmentCnt.OutputFormat = resources.GetString("MoveShipmentCnt.OutputFormat");
            this.MoveShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MoveShipmentCnt.Text = "1,234,567";
            this.MoveShipmentCnt.Top = 0.0625F;
            this.MoveShipmentCnt.Width = 0.75F;
            // 
            // TotalShipmentCnt
            // 
            this.TotalShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.TotalShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.TotalShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentCnt.DataField = "TotalShipmentCnt";
            this.TotalShipmentCnt.Height = 0.156F;
            this.TotalShipmentCnt.Left = 7F;
            this.TotalShipmentCnt.MultiLine = false;
            this.TotalShipmentCnt.Name = "TotalShipmentCnt";
            this.TotalShipmentCnt.OutputFormat = resources.GetString("TotalShipmentCnt.OutputFormat");
            this.TotalShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalShipmentCnt.Text = "1,234,567";
            this.TotalShipmentCnt.Top = 0.0625F;
            this.TotalShipmentCnt.Width = 0.75F;
            // 
            // LMonthStockPrice
            // 
            this.LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LMonthStockPrice.DataField = "LMonthStockPrice";
            this.LMonthStockPrice.Height = 0.156F;
            this.LMonthStockPrice.Left = 2.5F;
            this.LMonthStockPrice.MultiLine = false;
            this.LMonthStockPrice.Name = "LMonthStockPrice";
            this.LMonthStockPrice.OutputFormat = resources.GetString("LMonthStockPrice.OutputFormat");
            this.LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.LMonthStockPrice.Text = "1,234,567,890";
            this.LMonthStockPrice.Top = 0.22F;
            this.LMonthStockPrice.Width = 0.75F;
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
            this.StockPriceTaxExc.Left = 3.25F;
            this.StockPriceTaxExc.MultiLine = false;
            this.StockPriceTaxExc.Name = "StockPriceTaxExc";
            this.StockPriceTaxExc.OutputFormat = resources.GetString("StockPriceTaxExc.OutputFormat");
            this.StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockPriceTaxExc.Text = "1,234,567,890";
            this.StockPriceTaxExc.Top = 0.22F;
            this.StockPriceTaxExc.Width = 0.75F;
            // 
            // MoveArrivalPrice
            // 
            this.MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.MoveArrivalPrice.Height = 0.156F;
            this.MoveArrivalPrice.Left = 4F;
            this.MoveArrivalPrice.MultiLine = false;
            this.MoveArrivalPrice.Name = "MoveArrivalPrice";
            this.MoveArrivalPrice.OutputFormat = resources.GetString("MoveArrivalPrice.OutputFormat");
            this.MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MoveArrivalPrice.Text = "1,234,567,890";
            this.MoveArrivalPrice.Top = 0.22F;
            this.MoveArrivalPrice.Width = 0.75F;
            // 
            // TotalArrivalPrice
            // 
            this.TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.TotalArrivalPrice.Height = 0.156F;
            this.TotalArrivalPrice.Left = 4.75F;
            this.TotalArrivalPrice.MultiLine = false;
            this.TotalArrivalPrice.Name = "TotalArrivalPrice";
            this.TotalArrivalPrice.OutputFormat = resources.GetString("TotalArrivalPrice.OutputFormat");
            this.TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalArrivalPrice.Text = "1,234,567,890";
            this.TotalArrivalPrice.Top = 0.22F;
            this.TotalArrivalPrice.Width = 0.75F;
            // 
            // SalesMoneyTaxExc
            // 
            this.SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.Height = 0.156F;
            this.SalesMoneyTaxExc.Left = 5.5F;
            this.SalesMoneyTaxExc.MultiLine = false;
            this.SalesMoneyTaxExc.Name = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.OutputFormat = resources.GetString("SalesMoneyTaxExc.OutputFormat");
            this.SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyTaxExc.Text = "1,234,567,890";
            this.SalesMoneyTaxExc.Top = 0.22F;
            this.SalesMoneyTaxExc.Width = 0.75F;
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
            this.MaximumStockCnt.Height = 0.156F;
            this.MaximumStockCnt.Left = 7.75F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MaximumStockCnt.Text = "1,234,567";
            this.MaximumStockCnt.Top = 0.0625F;
            this.MaximumStockCnt.Width = 0.75F;
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
            this.MinimumStockCnt.Height = 0.156F;
            this.MinimumStockCnt.Left = 8.5F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MinimumStockCnt.Text = "1,234,567";
            this.MinimumStockCnt.Top = 0.0625F;
            this.MinimumStockCnt.Width = 0.5625F;
            // 
            // SalesCost
            // 
            this.SalesCost.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCost.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCost.Border.RightColor = System.Drawing.Color.Black;
            this.SalesCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCost.Border.TopColor = System.Drawing.Color.Black;
            this.SalesCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesCost.DataField = "SalesCost";
            this.SalesCost.Height = 0.156F;
            this.SalesCost.Left = 9.0625F;
            this.SalesCost.MultiLine = false;
            this.SalesCost.Name = "SalesCost";
            this.SalesCost.OutputFormat = resources.GetString("SalesCost.OutputFormat");
            this.SalesCost.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesCost.Text = "1,234,567.00";
            this.SalesCost.Top = 0.0625F;
            this.SalesCost.Width = 0.6875F;
            // 
            // TurnOver
            // 
            this.TurnOver.Border.BottomColor = System.Drawing.Color.Black;
            this.TurnOver.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TurnOver.Border.LeftColor = System.Drawing.Color.Black;
            this.TurnOver.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TurnOver.Border.RightColor = System.Drawing.Color.Black;
            this.TurnOver.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TurnOver.Border.TopColor = System.Drawing.Color.Black;
            this.TurnOver.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TurnOver.DataField = "TurnOver";
            this.TurnOver.Height = 0.156F;
            this.TurnOver.Left = 9.75F;
            this.TurnOver.MultiLine = false;
            this.TurnOver.Name = "TurnOver";
            this.TurnOver.OutputFormat = resources.GetString("TurnOver.OutputFormat");
            this.TurnOver.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TurnOver.Text = "123.00";
            this.TurnOver.Top = 0.0625F;
            this.TurnOver.Width = 0.75F;
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
            this.MoveShipmentPrice.Left = 6.25F;
            this.MoveShipmentPrice.MultiLine = false;
            this.MoveShipmentPrice.Name = "MoveShipmentPrice";
            this.MoveShipmentPrice.OutputFormat = resources.GetString("MoveShipmentPrice.OutputFormat");
            this.MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MoveShipmentPrice.Text = "1,234,567,890";
            this.MoveShipmentPrice.Top = 0.22F;
            this.MoveShipmentPrice.Width = 0.75F;
            // 
            // TotalShipmentPrice
            // 
            this.TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.TotalShipmentPrice.Height = 0.156F;
            this.TotalShipmentPrice.Left = 7F;
            this.TotalShipmentPrice.MultiLine = false;
            this.TotalShipmentPrice.Name = "TotalShipmentPrice";
            this.TotalShipmentPrice.OutputFormat = resources.GetString("TotalShipmentPrice.OutputFormat");
            this.TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalShipmentPrice.Text = "1,234,567,890";
            this.TotalShipmentPrice.Top = 0.22F;
            this.TotalShipmentPrice.Width = 0.75F;
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
            this.GrossProfit.Left = 7.75F;
            this.GrossProfit.MultiLine = false;
            this.GrossProfit.Name = "GrossProfit";
            this.GrossProfit.OutputFormat = resources.GetString("GrossProfit.OutputFormat");
            this.GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfit.Text = "1,234,567,890";
            this.GrossProfit.Top = 0.22F;
            this.GrossProfit.Width = 0.75F;
            // 
            // Mark
            // 
            this.Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mark.DataField = "Mark";
            this.Mark.Height = 0.156F;
            this.Mark.Left = 10.5F;
            this.Mark.MultiLine = false;
            this.Mark.Name = "Mark";
            this.Mark.OutputFormat = resources.GetString("Mark.OutputFormat");
            this.Mark.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.Mark.Text = "123";
            this.Mark.Top = 0.0625F;
            this.Mark.Width = 0.25F;
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
            this.GrossProfitRate.DataField = "GrossProfitRate";
            this.GrossProfitRate.Height = 0.156F;
            this.GrossProfitRate.Left = 8.5F;
            this.GrossProfitRate.MultiLine = false;
            this.GrossProfitRate.Name = "GrossProfitRate";
            this.GrossProfitRate.OutputFormat = resources.GetString("GrossProfitRate.OutputFormat");
            this.GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitRate.Text = "123.00";
            this.GrossProfitRate.Top = 0.22F;
            this.GrossProfitRate.Width = 0.5625F;
            // 
            // StockTotal
            // 
            this.StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotal.DataField = "StockTotal";
            this.StockTotal.Height = 0.156F;
            this.StockTotal.Left = 9.0625F;
            this.StockTotal.MultiLine = false;
            this.StockTotal.Name = "StockTotal";
            this.StockTotal.OutputFormat = resources.GetString("StockTotal.OutputFormat");
            this.StockTotal.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockTotal.Text = "1,234,567";
            this.StockTotal.Top = 0.22F;
            this.StockTotal.Width = 0.6875F;
            // 
            // StockMashinePrice
            // 
            this.StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockMashinePrice.DataField = "StockMashinePrice";
            this.StockMashinePrice.Height = 0.156F;
            this.StockMashinePrice.Left = 9.75F;
            this.StockMashinePrice.MultiLine = false;
            this.StockMashinePrice.Name = "StockMashinePrice";
            this.StockMashinePrice.OutputFormat = resources.GetString("StockMashinePrice.OutputFormat");
            this.StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockMashinePrice.Text = "1,234,567,890";
            this.StockMashinePrice.Top = 0.22F;
            this.StockMashinePrice.Width = 0.75F;
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
            this.line11.Height = 0F;
            this.line11.Left = 0F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0F;
            this.line11.Width = 10.8125F;
            this.line11.X1 = 0F;
            this.line11.X2 = 10.8125F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0F;
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
            this.tb_ReportTitle.Text = "在庫月報年報";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.Lb_MoveArrivalCnt,
            this.Lb_TotalArrivalCnt,
            this.Lb_MoveShipmentCnt,
            this.Lb_TotalShipmentCnt,
            this.Lb_SalesCount,
            this.Line5,
            this.Lb_MoveArrivalPrice,
            this.Lb_TotalArrivalPrice,
            this.Lb_SalesMoneyTaxExc,
            this.Lb_MoveShipmentPrice,
            this.Lb_TotalShipmentPrice,
            this.Lb_GrossProfit,
            this.Lb_Mark,
            this.Lb_MaximumStockCnt,
            this.Lb_SalesCost,
            this.Lb_TurnOver,
            this.label4,
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.Lb_WarehouseShelfNo,
            this.Lb_LMonthStockPrice,
            this.Lb_LMonthStockCnt,
            this.Lb_StockCount,
            this.Lb_StockPriceTaxExc,
            this.line2,
            this.Lb_StockMashinePrice,
            this.Lb_StockTotal,
            this.Lb_MinimumStockCnt,
            this.Lb_GrossProfitRate,
            this.label1});
            this.TitleHeader.Height = 0.6354167F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Lb_MoveArrivalCnt
            // 
            this.Lb_MoveArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalCnt.Height = 0.156F;
            this.Lb_MoveArrivalCnt.HyperLink = "";
            this.Lb_MoveArrivalCnt.Left = 4.0625F;
            this.Lb_MoveArrivalCnt.MultiLine = false;
            this.Lb_MoveArrivalCnt.Name = "Lb_MoveArrivalCnt";
            this.Lb_MoveArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MoveArrivalCnt.Text = "移動入庫数";
            this.Lb_MoveArrivalCnt.Top = 0.25F;
            this.Lb_MoveArrivalCnt.Width = 0.6875F;
            // 
            // Lb_TotalArrivalCnt
            // 
            this.Lb_TotalArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalCnt.Height = 0.15625F;
            this.Lb_TotalArrivalCnt.HyperLink = "";
            this.Lb_TotalArrivalCnt.Left = 4.8125F;
            this.Lb_TotalArrivalCnt.MultiLine = false;
            this.Lb_TotalArrivalCnt.Name = "Lb_TotalArrivalCnt";
            this.Lb_TotalArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TotalArrivalCnt.Text = "合計入荷数";
            this.Lb_TotalArrivalCnt.Top = 0.25F;
            this.Lb_TotalArrivalCnt.Width = 0.6875F;
            // 
            // Lb_MoveShipmentCnt
            // 
            this.Lb_MoveShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentCnt.Height = 0.15625F;
            this.Lb_MoveShipmentCnt.HyperLink = "";
            this.Lb_MoveShipmentCnt.Left = 6.3125F;
            this.Lb_MoveShipmentCnt.MultiLine = false;
            this.Lb_MoveShipmentCnt.Name = "Lb_MoveShipmentCnt";
            this.Lb_MoveShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MoveShipmentCnt.Text = "移動出庫数";
            this.Lb_MoveShipmentCnt.Top = 0.25F;
            this.Lb_MoveShipmentCnt.Width = 0.6875F;
            // 
            // Lb_TotalShipmentCnt
            // 
            this.Lb_TotalShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentCnt.Height = 0.15625F;
            this.Lb_TotalShipmentCnt.HyperLink = "";
            this.Lb_TotalShipmentCnt.Left = 7.0625F;
            this.Lb_TotalShipmentCnt.MultiLine = false;
            this.Lb_TotalShipmentCnt.Name = "Lb_TotalShipmentCnt";
            this.Lb_TotalShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TotalShipmentCnt.Text = "合計出荷数";
            this.Lb_TotalShipmentCnt.Top = 0.25F;
            this.Lb_TotalShipmentCnt.Width = 0.6875F;
            // 
            // Lb_SalesCount
            // 
            this.Lb_SalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCount.Height = 0.15625F;
            this.Lb_SalesCount.HyperLink = "";
            this.Lb_SalesCount.Left = 5.5625F;
            this.Lb_SalesCount.MultiLine = false;
            this.Lb_SalesCount.Name = "Lb_SalesCount";
            this.Lb_SalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesCount.Text = "売上数";
            this.Lb_SalesCount.Top = 0.25F;
            this.Lb_SalesCount.Width = 0.6875F;
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
            this.Line5.Width = 10.81F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.81F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // Lb_MoveArrivalPrice
            // 
            this.Lb_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveArrivalPrice.Height = 0.156F;
            this.Lb_MoveArrivalPrice.HyperLink = "";
            this.Lb_MoveArrivalPrice.Left = 4.0625F;
            this.Lb_MoveArrivalPrice.MultiLine = false;
            this.Lb_MoveArrivalPrice.Name = "Lb_MoveArrivalPrice";
            this.Lb_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MoveArrivalPrice.Text = "移動入庫額";
            this.Lb_MoveArrivalPrice.Top = 0.407F;
            this.Lb_MoveArrivalPrice.Width = 0.6875F;
            // 
            // Lb_TotalArrivalPrice
            // 
            this.Lb_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalArrivalPrice.Height = 0.15625F;
            this.Lb_TotalArrivalPrice.HyperLink = "";
            this.Lb_TotalArrivalPrice.Left = 4.8125F;
            this.Lb_TotalArrivalPrice.MultiLine = false;
            this.Lb_TotalArrivalPrice.Name = "Lb_TotalArrivalPrice";
            this.Lb_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TotalArrivalPrice.Text = "合計入荷額";
            this.Lb_TotalArrivalPrice.Top = 0.407F;
            this.Lb_TotalArrivalPrice.Width = 0.6875F;
            // 
            // Lb_SalesMoneyTaxExc
            // 
            this.Lb_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExc.Height = 0.15625F;
            this.Lb_SalesMoneyTaxExc.HyperLink = "";
            this.Lb_SalesMoneyTaxExc.Left = 5.5625F;
            this.Lb_SalesMoneyTaxExc.MultiLine = false;
            this.Lb_SalesMoneyTaxExc.Name = "Lb_SalesMoneyTaxExc";
            this.Lb_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesMoneyTaxExc.Text = "売上額";
            this.Lb_SalesMoneyTaxExc.Top = 0.407F;
            this.Lb_SalesMoneyTaxExc.Width = 0.6875F;
            // 
            // Lb_MoveShipmentPrice
            // 
            this.Lb_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MoveShipmentPrice.Height = 0.15625F;
            this.Lb_MoveShipmentPrice.HyperLink = "";
            this.Lb_MoveShipmentPrice.Left = 6.3125F;
            this.Lb_MoveShipmentPrice.MultiLine = false;
            this.Lb_MoveShipmentPrice.Name = "Lb_MoveShipmentPrice";
            this.Lb_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MoveShipmentPrice.Text = "移動出庫額";
            this.Lb_MoveShipmentPrice.Top = 0.407F;
            this.Lb_MoveShipmentPrice.Width = 0.6875F;
            // 
            // Lb_TotalShipmentPrice
            // 
            this.Lb_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TotalShipmentPrice.Height = 0.15625F;
            this.Lb_TotalShipmentPrice.HyperLink = "";
            this.Lb_TotalShipmentPrice.Left = 7.0625F;
            this.Lb_TotalShipmentPrice.MultiLine = false;
            this.Lb_TotalShipmentPrice.Name = "Lb_TotalShipmentPrice";
            this.Lb_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TotalShipmentPrice.Text = "合計出荷額";
            this.Lb_TotalShipmentPrice.Top = 0.407F;
            this.Lb_TotalShipmentPrice.Width = 0.6875F;
            // 
            // Lb_GrossProfit
            // 
            this.Lb_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfit.Height = 0.15625F;
            this.Lb_GrossProfit.HyperLink = "";
            this.Lb_GrossProfit.Left = 7.8125F;
            this.Lb_GrossProfit.MultiLine = false;
            this.Lb_GrossProfit.Name = "Lb_GrossProfit";
            this.Lb_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrossProfit.Text = "粗利額";
            this.Lb_GrossProfit.Top = 0.407F;
            this.Lb_GrossProfit.Width = 0.75F;
            // 
            // Lb_Mark
            // 
            this.Lb_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Mark.Height = 0.125F;
            this.Lb_Mark.HyperLink = "";
            this.Lb_Mark.Left = 10.5F;
            this.Lb_Mark.MultiLine = false;
            this.Lb_Mark.Name = "Lb_Mark";
            this.Lb_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Mark.Text = "ﾏｰｸ";
            this.Lb_Mark.Top = 0.25F;
            this.Lb_Mark.Width = 0.25F;
            // 
            // Lb_MaximumStockCnt
            // 
            this.Lb_MaximumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MaximumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MaximumStockCnt.Height = 0.15625F;
            this.Lb_MaximumStockCnt.HyperLink = "";
            this.Lb_MaximumStockCnt.Left = 7.8125F;
            this.Lb_MaximumStockCnt.MultiLine = false;
            this.Lb_MaximumStockCnt.Name = "Lb_MaximumStockCnt";
            this.Lb_MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MaximumStockCnt.Text = "最高数";
            this.Lb_MaximumStockCnt.Top = 0.25F;
            this.Lb_MaximumStockCnt.Width = 0.75F;
            // 
            // Lb_SalesCost
            // 
            this.Lb_SalesCost.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCost.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCost.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCost.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCost.Height = 0.15625F;
            this.Lb_SalesCost.HyperLink = "";
            this.Lb_SalesCost.Left = 9.1875F;
            this.Lb_SalesCost.MultiLine = false;
            this.Lb_SalesCost.Name = "Lb_SalesCost";
            this.Lb_SalesCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesCost.Text = "原価";
            this.Lb_SalesCost.Top = 0.25F;
            this.Lb_SalesCost.Width = 0.625F;
            // 
            // Lb_TurnOver
            // 
            this.Lb_TurnOver.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TurnOver.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TurnOver.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TurnOver.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TurnOver.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TurnOver.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TurnOver.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TurnOver.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TurnOver.Height = 0.15625F;
            this.Lb_TurnOver.HyperLink = "";
            this.Lb_TurnOver.Left = 9.8125F;
            this.Lb_TurnOver.MultiLine = false;
            this.Lb_TurnOver.Name = "Lb_TurnOver";
            this.Lb_TurnOver.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_TurnOver.Text = "回転率";
            this.Lb_TurnOver.Top = 0.25F;
            this.Lb_TurnOver.Width = 0.6875F;
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
            this.label4.Left = 1.3125F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "仕入先";
            this.label4.Top = 0.0625F;
            this.label4.Width = 1.5625F;
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
            this.Lb_GoodsNo.Height = 0.156F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 0.0625F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.25F;
            this.Lb_GoodsNo.Width = 1.25F;
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
            this.Lb_GoodsName.Height = 0.156F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 1.3125F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.25F;
            this.Lb_GoodsName.Width = 1F;
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
            this.Lb_WarehouseShelfNo.Left = 2.3125F;
            this.Lb_WarehouseShelfNo.MultiLine = false;
            this.Lb_WarehouseShelfNo.Name = "Lb_WarehouseShelfNo";
            this.Lb_WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo.Text = "棚番";
            this.Lb_WarehouseShelfNo.Top = 0.25F;
            this.Lb_WarehouseShelfNo.Width = 0.4375F;
            // 
            // Lb_LMonthStockPrice
            // 
            this.Lb_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockPrice.Height = 0.156F;
            this.Lb_LMonthStockPrice.HyperLink = "";
            this.Lb_LMonthStockPrice.Left = 2.5625F;
            this.Lb_LMonthStockPrice.MultiLine = false;
            this.Lb_LMonthStockPrice.Name = "Lb_LMonthStockPrice";
            this.Lb_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_LMonthStockPrice.Text = "前残額";
            this.Lb_LMonthStockPrice.Top = 0.407F;
            this.Lb_LMonthStockPrice.Width = 0.6875F;
            // 
            // Lb_LMonthStockCnt
            // 
            this.Lb_LMonthStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_LMonthStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LMonthStockCnt.Height = 0.156F;
            this.Lb_LMonthStockCnt.HyperLink = "";
            this.Lb_LMonthStockCnt.Left = 2.75F;
            this.Lb_LMonthStockCnt.MultiLine = false;
            this.Lb_LMonthStockCnt.Name = "Lb_LMonthStockCnt";
            this.Lb_LMonthStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_LMonthStockCnt.Text = "前残数";
            this.Lb_LMonthStockCnt.Top = 0.25F;
            this.Lb_LMonthStockCnt.Width = 0.5F;
            // 
            // Lb_StockCount
            // 
            this.Lb_StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCount.Height = 0.156F;
            this.Lb_StockCount.HyperLink = "";
            this.Lb_StockCount.Left = 3.3125F;
            this.Lb_StockCount.MultiLine = false;
            this.Lb_StockCount.Name = "Lb_StockCount";
            this.Lb_StockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockCount.Text = "仕入数";
            this.Lb_StockCount.Top = 0.25F;
            this.Lb_StockCount.Width = 0.6875F;
            // 
            // Lb_StockPriceTaxExc
            // 
            this.Lb_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPriceTaxExc.Height = 0.156F;
            this.Lb_StockPriceTaxExc.HyperLink = "";
            this.Lb_StockPriceTaxExc.Left = 3.3125F;
            this.Lb_StockPriceTaxExc.MultiLine = false;
            this.Lb_StockPriceTaxExc.Name = "Lb_StockPriceTaxExc";
            this.Lb_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockPriceTaxExc.Text = "仕入額";
            this.Lb_StockPriceTaxExc.Top = 0.407F;
            this.Lb_StockPriceTaxExc.Width = 0.6875F;
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
            this.line2.Top = 0.21F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.21F;
            this.line2.Y2 = 0.21F;
            // 
            // Lb_StockMashinePrice
            // 
            this.Lb_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockMashinePrice.Height = 0.15625F;
            this.Lb_StockMashinePrice.HyperLink = "";
            this.Lb_StockMashinePrice.Left = 9.8125F;
            this.Lb_StockMashinePrice.MultiLine = false;
            this.Lb_StockMashinePrice.Name = "Lb_StockMashinePrice";
            this.Lb_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockMashinePrice.Text = "現在庫額";
            this.Lb_StockMashinePrice.Top = 0.407F;
            this.Lb_StockMashinePrice.Width = 0.6875F;
            // 
            // Lb_StockTotal
            // 
            this.Lb_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Height = 0.15625F;
            this.Lb_StockTotal.HyperLink = "";
            this.Lb_StockTotal.Left = 9.1875F;
            this.Lb_StockTotal.MultiLine = false;
            this.Lb_StockTotal.Name = "Lb_StockTotal";
            this.Lb_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockTotal.Text = "現在庫数";
            this.Lb_StockTotal.Top = 0.407F;
            this.Lb_StockTotal.Width = 0.625F;
            // 
            // Lb_MinimumStockCnt
            // 
            this.Lb_MinimumStockCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MinimumStockCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MinimumStockCnt.Height = 0.15625F;
            this.Lb_MinimumStockCnt.HyperLink = "";
            this.Lb_MinimumStockCnt.Left = 8.625F;
            this.Lb_MinimumStockCnt.MultiLine = false;
            this.Lb_MinimumStockCnt.Name = "Lb_MinimumStockCnt";
            this.Lb_MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MinimumStockCnt.Text = "発注点";
            this.Lb_MinimumStockCnt.Top = 0.25F;
            this.Lb_MinimumStockCnt.Width = 0.5F;
            // 
            // Lb_GrossProfitRate
            // 
            this.Lb_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitRate.Height = 0.15625F;
            this.Lb_GrossProfitRate.HyperLink = "";
            this.Lb_GrossProfitRate.Left = 8.625F;
            this.Lb_GrossProfitRate.MultiLine = false;
            this.Lb_GrossProfitRate.Name = "Lb_GrossProfitRate";
            this.Lb_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrossProfitRate.Text = "粗利率";
            this.Lb_GrossProfitRate.Top = 0.407F;
            this.Lb_GrossProfitRate.Width = 0.5F;
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
            this.label1.Left = 0F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "倉庫";
            this.label1.Top = 0.0625F;
            this.label1.Width = 1.3125F;
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
            this.GrandTotalHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ALLTOTALTITLE,
            this.Line43,
            this.Ttl_LMonthStockPrice,
            this.Ttl_GrossProfitRate,
            this.Ttl_StockTotal,
            this.Ttl_StockPriceTaxExc,
            this.Ttl_MoveArrivalPrice,
            this.Ttl_StockMashinePrice,
            this.Ttl_TotalArrivalPrice,
            this.Ttl_SalesMoneyTaxExc,
            this.Ttl_MoveShipmentPrice,
            this.Ttl_TotalShipmentPrice,
            this.Ttl_GrossProfit,
            this.Ttl_Mark});
            this.GrandTotalFooter.Height = 0.448F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
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
            this.ALLTOTALTITLE.Height = 0.219F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 0.1875F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.031F;
            this.ALLTOTALTITLE.Width = 0.8125F;
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
            // Ttl_LMonthStockPrice
            // 
            this.Ttl_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Ttl_LMonthStockPrice.Height = 0.1565F;
            this.Ttl_LMonthStockPrice.Left = 2.5F;
            this.Ttl_LMonthStockPrice.MultiLine = false;
            this.Ttl_LMonthStockPrice.Name = "Ttl_LMonthStockPrice";
            this.Ttl_LMonthStockPrice.OutputFormat = resources.GetString("Ttl_LMonthStockPrice.OutputFormat");
            this.Ttl_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_LMonthStockPrice.Text = "1,234,567,890";
            this.Ttl_LMonthStockPrice.Top = 0.031F;
            this.Ttl_LMonthStockPrice.Width = 0.75F;
            // 
            // Ttl_GrossProfitRate
            // 
            this.Ttl_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfitRate.DataField = "GrossProfitRate";
            this.Ttl_GrossProfitRate.Height = 0.1565F;
            this.Ttl_GrossProfitRate.Left = 8.5F;
            this.Ttl_GrossProfitRate.MultiLine = false;
            this.Ttl_GrossProfitRate.Name = "Ttl_GrossProfitRate";
            this.Ttl_GrossProfitRate.OutputFormat = resources.GetString("Ttl_GrossProfitRate.OutputFormat");
            this.Ttl_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_GrossProfitRate.Text = "123.00";
            this.Ttl_GrossProfitRate.Top = 0.03F;
            this.Ttl_GrossProfitRate.Width = 0.5625F;
            // 
            // Ttl_StockTotal
            // 
            this.Ttl_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockTotal.DataField = "StockTotal";
            this.Ttl_StockTotal.Height = 0.1565F;
            this.Ttl_StockTotal.Left = 9.0625F;
            this.Ttl_StockTotal.MultiLine = false;
            this.Ttl_StockTotal.Name = "Ttl_StockTotal";
            this.Ttl_StockTotal.OutputFormat = resources.GetString("Ttl_StockTotal.OutputFormat");
            this.Ttl_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_StockTotal.Text = "1,234,567";
            this.Ttl_StockTotal.Top = 0.03F;
            this.Ttl_StockTotal.Width = 0.6875F;
            // 
            // Ttl_StockPriceTaxExc
            // 
            this.Ttl_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Ttl_StockPriceTaxExc.Height = 0.156F;
            this.Ttl_StockPriceTaxExc.Left = 3.25F;
            this.Ttl_StockPriceTaxExc.MultiLine = false;
            this.Ttl_StockPriceTaxExc.Name = "Ttl_StockPriceTaxExc";
            this.Ttl_StockPriceTaxExc.OutputFormat = resources.GetString("Ttl_StockPriceTaxExc.OutputFormat");
            this.Ttl_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_StockPriceTaxExc.Text = "1,234,567,890";
            this.Ttl_StockPriceTaxExc.Top = 0.031F;
            this.Ttl_StockPriceTaxExc.Width = 0.75F;
            // 
            // Ttl_MoveArrivalPrice
            // 
            this.Ttl_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Ttl_MoveArrivalPrice.Height = 0.1565F;
            this.Ttl_MoveArrivalPrice.Left = 4F;
            this.Ttl_MoveArrivalPrice.MultiLine = false;
            this.Ttl_MoveArrivalPrice.Name = "Ttl_MoveArrivalPrice";
            this.Ttl_MoveArrivalPrice.OutputFormat = resources.GetString("Ttl_MoveArrivalPrice.OutputFormat");
            this.Ttl_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_MoveArrivalPrice.Text = "1,234,567,890";
            this.Ttl_MoveArrivalPrice.Top = 0.031F;
            this.Ttl_MoveArrivalPrice.Width = 0.75F;
            // 
            // Ttl_StockMashinePrice
            // 
            this.Ttl_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockMashinePrice.DataField = "StockMashinePrice";
            this.Ttl_StockMashinePrice.Height = 0.1565F;
            this.Ttl_StockMashinePrice.Left = 9.75F;
            this.Ttl_StockMashinePrice.MultiLine = false;
            this.Ttl_StockMashinePrice.Name = "Ttl_StockMashinePrice";
            this.Ttl_StockMashinePrice.OutputFormat = resources.GetString("Ttl_StockMashinePrice.OutputFormat");
            this.Ttl_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_StockMashinePrice.Text = "1,234,567,890";
            this.Ttl_StockMashinePrice.Top = 0.03F;
            this.Ttl_StockMashinePrice.Width = 0.75F;
            // 
            // Ttl_TotalArrivalPrice
            // 
            this.Ttl_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Ttl_TotalArrivalPrice.Height = 0.1565F;
            this.Ttl_TotalArrivalPrice.Left = 4.75F;
            this.Ttl_TotalArrivalPrice.MultiLine = false;
            this.Ttl_TotalArrivalPrice.Name = "Ttl_TotalArrivalPrice";
            this.Ttl_TotalArrivalPrice.OutputFormat = resources.GetString("Ttl_TotalArrivalPrice.OutputFormat");
            this.Ttl_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalArrivalPrice.Text = "1,234,567,890";
            this.Ttl_TotalArrivalPrice.Top = 0.031F;
            this.Ttl_TotalArrivalPrice.Width = 0.75F;
            // 
            // Ttl_SalesMoneyTaxExc
            // 
            this.Ttl_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Ttl_SalesMoneyTaxExc.Height = 0.1565F;
            this.Ttl_SalesMoneyTaxExc.Left = 5.5F;
            this.Ttl_SalesMoneyTaxExc.MultiLine = false;
            this.Ttl_SalesMoneyTaxExc.Name = "Ttl_SalesMoneyTaxExc";
            this.Ttl_SalesMoneyTaxExc.OutputFormat = resources.GetString("Ttl_SalesMoneyTaxExc.OutputFormat");
            this.Ttl_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Ttl_SalesMoneyTaxExc.Top = 0.031F;
            this.Ttl_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Ttl_MoveShipmentPrice
            // 
            this.Ttl_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Ttl_MoveShipmentPrice.Height = 0.1565F;
            this.Ttl_MoveShipmentPrice.Left = 6.25F;
            this.Ttl_MoveShipmentPrice.MultiLine = false;
            this.Ttl_MoveShipmentPrice.Name = "Ttl_MoveShipmentPrice";
            this.Ttl_MoveShipmentPrice.OutputFormat = resources.GetString("Ttl_MoveShipmentPrice.OutputFormat");
            this.Ttl_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_MoveShipmentPrice.Text = "1,234,567,890";
            this.Ttl_MoveShipmentPrice.Top = 0.031F;
            this.Ttl_MoveShipmentPrice.Width = 0.75F;
            // 
            // Ttl_TotalShipmentPrice
            // 
            this.Ttl_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Ttl_TotalShipmentPrice.Height = 0.1565F;
            this.Ttl_TotalShipmentPrice.Left = 7F;
            this.Ttl_TotalShipmentPrice.MultiLine = false;
            this.Ttl_TotalShipmentPrice.Name = "Ttl_TotalShipmentPrice";
            this.Ttl_TotalShipmentPrice.OutputFormat = resources.GetString("Ttl_TotalShipmentPrice.OutputFormat");
            this.Ttl_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalShipmentPrice.Text = "1,234,567,890";
            this.Ttl_TotalShipmentPrice.Top = 0.031F;
            this.Ttl_TotalShipmentPrice.Width = 0.75F;
            // 
            // Ttl_GrossProfit
            // 
            this.Ttl_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossProfit.DataField = "GrossProfit";
            this.Ttl_GrossProfit.Height = 0.1565F;
            this.Ttl_GrossProfit.Left = 7.75F;
            this.Ttl_GrossProfit.MultiLine = false;
            this.Ttl_GrossProfit.Name = "Ttl_GrossProfit";
            this.Ttl_GrossProfit.OutputFormat = resources.GetString("Ttl_GrossProfit.OutputFormat");
            this.Ttl_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_GrossProfit.Text = "1,234,567,890";
            this.Ttl_GrossProfit.Top = 0.031F;
            this.Ttl_GrossProfit.Width = 0.75F;
            // 
            // Ttl_Mark
            // 
            this.Ttl_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_Mark.DataField = "Mark";
            this.Ttl_Mark.Height = 0.1565F;
            this.Ttl_Mark.Left = 10.5F;
            this.Ttl_Mark.MultiLine = false;
            this.Ttl_Mark.Name = "Ttl_Mark";
            this.Ttl_Mark.OutputFormat = resources.GetString("Ttl_Mark.OutputFormat");
            this.Ttl_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_Mark.Text = "123";
            this.Ttl_Mark.Top = 0.031F;
            this.Ttl_Mark.Width = 0.25F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.DataField = "Sort_WarehouseCode";
            this.WarehouseHeader.Height = 0F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WAREHOUSETITLE,
            this.Wh_SalesMoneyTaxExc,
            this.WarehouseName,
            this.Wh_LMonthStockPrice,
            this.Wh_StockPriceTaxExc,
            this.Wh_MoveArrivalPrice,
            this.Wh_TotalArrivalPrice,
            this.WarehouseCode,
            this.Wh_MoveShipmentPrice,
            this.Wh_TotalShipmentPrice,
            this.Wh_GrossProfitRate,
            this.Wh_StockTotal,
            this.Wh_StockMashinePrice,
            this.Wh_Mark,
            this.Wh_GrossProfit,
            this.Line45});
            this.WarehouseFooter.Height = 0.448F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.Format += new System.EventHandler(this.WarehouseFooter_Format);
            // 
            // WAREHOUSETITLE
            // 
            this.WAREHOUSETITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.WAREHOUSETITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.WAREHOUSETITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETITLE.Border.RightColor = System.Drawing.Color.Black;
            this.WAREHOUSETITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETITLE.Border.TopColor = System.Drawing.Color.Black;
            this.WAREHOUSETITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WAREHOUSETITLE.Height = 0.219F;
            this.WAREHOUSETITLE.Left = 0.1875F;
            this.WAREHOUSETITLE.MultiLine = false;
            this.WAREHOUSETITLE.Name = "WAREHOUSETITLE";
            this.WAREHOUSETITLE.OutputFormat = resources.GetString("WAREHOUSETITLE.OutputFormat");
            this.WAREHOUSETITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.WAREHOUSETITLE.Text = "倉庫計";
            this.WAREHOUSETITLE.Top = 0.031F;
            this.WAREHOUSETITLE.Width = 0.8125F;
            // 
            // Wh_SalesMoneyTaxExc
            // 
            this.Wh_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Wh_SalesMoneyTaxExc.Height = 0.1565F;
            this.Wh_SalesMoneyTaxExc.Left = 5.5F;
            this.Wh_SalesMoneyTaxExc.MultiLine = false;
            this.Wh_SalesMoneyTaxExc.Name = "Wh_SalesMoneyTaxExc";
            this.Wh_SalesMoneyTaxExc.OutputFormat = resources.GetString("Wh_SalesMoneyTaxExc.OutputFormat");
            this.Wh_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_SalesMoneyTaxExc.SummaryGroup = "WarehouseHeader";
            this.Wh_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Wh_SalesMoneyTaxExc.Top = 0.031F;
            this.Wh_SalesMoneyTaxExc.Width = 0.75F;
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
            this.WarehouseName.Left = 1.3125F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OutputFormat = resources.GetString("WarehouseName.OutputFormat");
            this.WarehouseName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.WarehouseName.Text = "あいうえおかきくけこ";
            this.WarehouseName.Top = 0.1875F;
            this.WarehouseName.Visible = false;
            this.WarehouseName.Width = 1.188F;
            // 
            // Wh_LMonthStockPrice
            // 
            this.Wh_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Wh_LMonthStockPrice.Height = 0.1565F;
            this.Wh_LMonthStockPrice.Left = 2.5F;
            this.Wh_LMonthStockPrice.MultiLine = false;
            this.Wh_LMonthStockPrice.Name = "Wh_LMonthStockPrice";
            this.Wh_LMonthStockPrice.OutputFormat = resources.GetString("Wh_LMonthStockPrice.OutputFormat");
            this.Wh_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_LMonthStockPrice.SummaryGroup = "WarehouseHeader";
            this.Wh_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_LMonthStockPrice.Text = "1,234,567,890";
            this.Wh_LMonthStockPrice.Top = 0.031F;
            this.Wh_LMonthStockPrice.Width = 0.75F;
            // 
            // Wh_StockPriceTaxExc
            // 
            this.Wh_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Wh_StockPriceTaxExc.Height = 0.156F;
            this.Wh_StockPriceTaxExc.Left = 3.25F;
            this.Wh_StockPriceTaxExc.MultiLine = false;
            this.Wh_StockPriceTaxExc.Name = "Wh_StockPriceTaxExc";
            this.Wh_StockPriceTaxExc.OutputFormat = resources.GetString("Wh_StockPriceTaxExc.OutputFormat");
            this.Wh_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_StockPriceTaxExc.SummaryGroup = "WarehouseHeader";
            this.Wh_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_StockPriceTaxExc.Text = "1,234,567,890";
            this.Wh_StockPriceTaxExc.Top = 0.031F;
            this.Wh_StockPriceTaxExc.Width = 0.75F;
            // 
            // Wh_MoveArrivalPrice
            // 
            this.Wh_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Wh_MoveArrivalPrice.Height = 0.1565F;
            this.Wh_MoveArrivalPrice.Left = 4F;
            this.Wh_MoveArrivalPrice.MultiLine = false;
            this.Wh_MoveArrivalPrice.Name = "Wh_MoveArrivalPrice";
            this.Wh_MoveArrivalPrice.OutputFormat = resources.GetString("Wh_MoveArrivalPrice.OutputFormat");
            this.Wh_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_MoveArrivalPrice.SummaryGroup = "WarehouseHeader";
            this.Wh_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_MoveArrivalPrice.Text = "1,234,567,890";
            this.Wh_MoveArrivalPrice.Top = 0.031F;
            this.Wh_MoveArrivalPrice.Width = 0.75F;
            // 
            // Wh_TotalArrivalPrice
            // 
            this.Wh_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Wh_TotalArrivalPrice.Height = 0.1565F;
            this.Wh_TotalArrivalPrice.Left = 4.75F;
            this.Wh_TotalArrivalPrice.MultiLine = false;
            this.Wh_TotalArrivalPrice.Name = "Wh_TotalArrivalPrice";
            this.Wh_TotalArrivalPrice.OutputFormat = resources.GetString("Wh_TotalArrivalPrice.OutputFormat");
            this.Wh_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_TotalArrivalPrice.SummaryGroup = "WarehouseHeader";
            this.Wh_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_TotalArrivalPrice.Text = "1,234,567,890";
            this.Wh_TotalArrivalPrice.Top = 0.031F;
            this.Wh_TotalArrivalPrice.Width = 0.75F;
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
            this.WarehouseCode.Height = 0.15625F;
            this.WarehouseCode.Left = 1.3125F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.WarehouseCode.Text = "1234567890";
            this.WarehouseCode.Top = 0F;
            this.WarehouseCode.Visible = false;
            this.WarehouseCode.Width = 0.75F;
            // 
            // Wh_MoveShipmentPrice
            // 
            this.Wh_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Wh_MoveShipmentPrice.Height = 0.1565F;
            this.Wh_MoveShipmentPrice.Left = 6.25F;
            this.Wh_MoveShipmentPrice.MultiLine = false;
            this.Wh_MoveShipmentPrice.Name = "Wh_MoveShipmentPrice";
            this.Wh_MoveShipmentPrice.OutputFormat = resources.GetString("Wh_MoveShipmentPrice.OutputFormat");
            this.Wh_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_MoveShipmentPrice.SummaryGroup = "WarehouseHeader";
            this.Wh_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_MoveShipmentPrice.Text = "1,234,567,890";
            this.Wh_MoveShipmentPrice.Top = 0.031F;
            this.Wh_MoveShipmentPrice.Width = 0.75F;
            // 
            // Wh_TotalShipmentPrice
            // 
            this.Wh_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Wh_TotalShipmentPrice.Height = 0.1565F;
            this.Wh_TotalShipmentPrice.Left = 7F;
            this.Wh_TotalShipmentPrice.MultiLine = false;
            this.Wh_TotalShipmentPrice.Name = "Wh_TotalShipmentPrice";
            this.Wh_TotalShipmentPrice.OutputFormat = resources.GetString("Wh_TotalShipmentPrice.OutputFormat");
            this.Wh_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_TotalShipmentPrice.SummaryGroup = "WarehouseHeader";
            this.Wh_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_TotalShipmentPrice.Text = "1,234,567,890";
            this.Wh_TotalShipmentPrice.Top = 0.031F;
            this.Wh_TotalShipmentPrice.Width = 0.75F;
            // 
            // Wh_GrossProfitRate
            // 
            this.Wh_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfitRate.DataField = "GrossProfitRate";
            this.Wh_GrossProfitRate.Height = 0.1565F;
            this.Wh_GrossProfitRate.Left = 8.5F;
            this.Wh_GrossProfitRate.MultiLine = false;
            this.Wh_GrossProfitRate.Name = "Wh_GrossProfitRate";
            this.Wh_GrossProfitRate.OutputFormat = resources.GetString("Wh_GrossProfitRate.OutputFormat");
            this.Wh_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_GrossProfitRate.SummaryGroup = "WarehouseHeader";
            this.Wh_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_GrossProfitRate.Text = "123.00";
            this.Wh_GrossProfitRate.Top = 0.03F;
            this.Wh_GrossProfitRate.Width = 0.5625F;
            // 
            // Wh_StockTotal
            // 
            this.Wh_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockTotal.DataField = "StockTotal";
            this.Wh_StockTotal.Height = 0.1565F;
            this.Wh_StockTotal.Left = 9.0625F;
            this.Wh_StockTotal.MultiLine = false;
            this.Wh_StockTotal.Name = "Wh_StockTotal";
            this.Wh_StockTotal.OutputFormat = resources.GetString("Wh_StockTotal.OutputFormat");
            this.Wh_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_StockTotal.SummaryGroup = "WarehouseHeader";
            this.Wh_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_StockTotal.Text = "1,234,567";
            this.Wh_StockTotal.Top = 0.03F;
            this.Wh_StockTotal.Width = 0.6875F;
            // 
            // Wh_StockMashinePrice
            // 
            this.Wh_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockMashinePrice.DataField = "StockMashinePrice";
            this.Wh_StockMashinePrice.Height = 0.1565F;
            this.Wh_StockMashinePrice.Left = 9.75F;
            this.Wh_StockMashinePrice.MultiLine = false;
            this.Wh_StockMashinePrice.Name = "Wh_StockMashinePrice";
            this.Wh_StockMashinePrice.OutputFormat = resources.GetString("Wh_StockMashinePrice.OutputFormat");
            this.Wh_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_StockMashinePrice.SummaryGroup = "WarehouseHeader";
            this.Wh_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_StockMashinePrice.Text = "1,234,567,890";
            this.Wh_StockMashinePrice.Top = 0.03F;
            this.Wh_StockMashinePrice.Width = 0.75F;
            // 
            // Wh_Mark
            // 
            this.Wh_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_Mark.DataField = "Mark";
            this.Wh_Mark.Height = 0.1565F;
            this.Wh_Mark.Left = 10.5F;
            this.Wh_Mark.MultiLine = false;
            this.Wh_Mark.Name = "Wh_Mark";
            this.Wh_Mark.OutputFormat = resources.GetString("Wh_Mark.OutputFormat");
            this.Wh_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_Mark.SummaryGroup = "WarehouseHeader";
            this.Wh_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_Mark.Text = "123";
            this.Wh_Mark.Top = 0.031F;
            this.Wh_Mark.Width = 0.25F;
            // 
            // Wh_GrossProfit
            // 
            this.Wh_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_GrossProfit.DataField = "GrossProfit";
            this.Wh_GrossProfit.Height = 0.1565F;
            this.Wh_GrossProfit.Left = 7.75F;
            this.Wh_GrossProfit.MultiLine = false;
            this.Wh_GrossProfit.Name = "Wh_GrossProfit";
            this.Wh_GrossProfit.OutputFormat = resources.GetString("Wh_GrossProfit.OutputFormat");
            this.Wh_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_GrossProfit.SummaryGroup = "WarehouseHeader";
            this.Wh_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_GrossProfit.Text = "1,234,567,890";
            this.Wh_GrossProfit.Top = 0.031F;
            this.Wh_GrossProfit.Width = 0.75F;
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
            // GoodsMakerHeader
            // 
            this.GoodsMakerHeader.Height = 0F;
            this.GoodsMakerHeader.Name = "GoodsMakerHeader";
            // 
            // GoodsMakerFooter
            // 
            this.GoodsMakerFooter.CanShrink = true;
            this.GoodsMakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GOODSMAKERTITLE,
            this.GoodsMakerCode,
            this.MakerName,
            this.Gm_LMonthStockPrice,
            this.Gm_StockPriceTaxExc,
            this.Gm_MoveArrivalPrice,
            this.Gm_TotalArrivalPrice,
            this.Gm_SalesMoneyTaxExc,
            this.Gm_MoveShipmentPrice,
            this.Gm_TotalShipmentPrice,
            this.Gm_GrossProfit,
            this.Gm_Mark,
            this.Gm_GrossProfitRate,
            this.Gm_StockTotal,
            this.Gm_StockMashinePrice,
            this.line9});
            this.GoodsMakerFooter.Height = 0.4479167F;
            this.GoodsMakerFooter.KeepTogether = true;
            this.GoodsMakerFooter.Name = "GoodsMakerFooter";
            this.GoodsMakerFooter.Format += new System.EventHandler(this.GoodsMakerFooter_Format);
            // 
            // GOODSMAKERTITLE
            // 
            this.GOODSMAKERTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.GOODSMAKERTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GOODSMAKERTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.GOODSMAKERTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GOODSMAKERTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.GOODSMAKERTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GOODSMAKERTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.GOODSMAKERTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GOODSMAKERTITLE.Height = 0.219F;
            this.GOODSMAKERTITLE.Left = 0.1875F;
            this.GOODSMAKERTITLE.MultiLine = false;
            this.GOODSMAKERTITLE.Name = "GOODSMAKERTITLE";
            this.GOODSMAKERTITLE.OutputFormat = resources.GetString("GOODSMAKERTITLE.OutputFormat");
            this.GOODSMAKERTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GOODSMAKERTITLE.Text = "メーカー計";
            this.GOODSMAKERTITLE.Top = 0.031F;
            this.GOODSMAKERTITLE.Width = 0.8125F;
            // 
            // GoodsMakerCode
            // 
            this.GoodsMakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCode.DataField = "GoodsMakerCd";
            this.GoodsMakerCode.Height = 0.15625F;
            this.GoodsMakerCode.Left = 1.125F;
            this.GoodsMakerCode.MultiLine = false;
            this.GoodsMakerCode.Name = "GoodsMakerCode";
            this.GoodsMakerCode.OutputFormat = resources.GetString("GoodsMakerCode.OutputFormat");
            this.GoodsMakerCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsMakerCode.Text = "1234";
            this.GoodsMakerCode.Top = 0.03125F;
            this.GoodsMakerCode.Width = 0.3125F;
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
            this.MakerName.Left = 1.4375F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこ";
            this.MakerName.Top = 0.03125F;
            this.MakerName.Width = 1.0625F;
            // 
            // Gm_LMonthStockPrice
            // 
            this.Gm_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Gm_LMonthStockPrice.Height = 0.1565F;
            this.Gm_LMonthStockPrice.Left = 2.5F;
            this.Gm_LMonthStockPrice.MultiLine = false;
            this.Gm_LMonthStockPrice.Name = "Gm_LMonthStockPrice";
            this.Gm_LMonthStockPrice.OutputFormat = resources.GetString("Gm_LMonthStockPrice.OutputFormat");
            this.Gm_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_LMonthStockPrice.SummaryGroup = "GoodsMakerHeader";
            this.Gm_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_LMonthStockPrice.Text = "1,234,567,890";
            this.Gm_LMonthStockPrice.Top = 0.031F;
            this.Gm_LMonthStockPrice.Width = 0.75F;
            // 
            // Gm_StockPriceTaxExc
            // 
            this.Gm_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Gm_StockPriceTaxExc.Height = 0.156F;
            this.Gm_StockPriceTaxExc.Left = 3.25F;
            this.Gm_StockPriceTaxExc.MultiLine = false;
            this.Gm_StockPriceTaxExc.Name = "Gm_StockPriceTaxExc";
            this.Gm_StockPriceTaxExc.OutputFormat = resources.GetString("Gm_StockPriceTaxExc.OutputFormat");
            this.Gm_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_StockPriceTaxExc.SummaryGroup = "GoodsMakerHeader";
            this.Gm_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_StockPriceTaxExc.Text = "1,234,567,890";
            this.Gm_StockPriceTaxExc.Top = 0.031F;
            this.Gm_StockPriceTaxExc.Width = 0.75F;
            // 
            // Gm_MoveArrivalPrice
            // 
            this.Gm_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Gm_MoveArrivalPrice.Height = 0.1565F;
            this.Gm_MoveArrivalPrice.Left = 4F;
            this.Gm_MoveArrivalPrice.MultiLine = false;
            this.Gm_MoveArrivalPrice.Name = "Gm_MoveArrivalPrice";
            this.Gm_MoveArrivalPrice.OutputFormat = resources.GetString("Gm_MoveArrivalPrice.OutputFormat");
            this.Gm_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_MoveArrivalPrice.SummaryGroup = "GoodsMakerHeader";
            this.Gm_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_MoveArrivalPrice.Text = "1,234,567,890";
            this.Gm_MoveArrivalPrice.Top = 0.031F;
            this.Gm_MoveArrivalPrice.Width = 0.75F;
            // 
            // Gm_TotalArrivalPrice
            // 
            this.Gm_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Gm_TotalArrivalPrice.Height = 0.1565F;
            this.Gm_TotalArrivalPrice.Left = 4.75F;
            this.Gm_TotalArrivalPrice.MultiLine = false;
            this.Gm_TotalArrivalPrice.Name = "Gm_TotalArrivalPrice";
            this.Gm_TotalArrivalPrice.OutputFormat = resources.GetString("Gm_TotalArrivalPrice.OutputFormat");
            this.Gm_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_TotalArrivalPrice.SummaryGroup = "GoodsMakerHeader";
            this.Gm_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_TotalArrivalPrice.Text = "1,234,567,890";
            this.Gm_TotalArrivalPrice.Top = 0.031F;
            this.Gm_TotalArrivalPrice.Width = 0.75F;
            // 
            // Gm_SalesMoneyTaxExc
            // 
            this.Gm_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Gm_SalesMoneyTaxExc.Height = 0.1565F;
            this.Gm_SalesMoneyTaxExc.Left = 5.5F;
            this.Gm_SalesMoneyTaxExc.MultiLine = false;
            this.Gm_SalesMoneyTaxExc.Name = "Gm_SalesMoneyTaxExc";
            this.Gm_SalesMoneyTaxExc.OutputFormat = resources.GetString("Gm_SalesMoneyTaxExc.OutputFormat");
            this.Gm_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_SalesMoneyTaxExc.SummaryGroup = "GoodsMakerHeader";
            this.Gm_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Gm_SalesMoneyTaxExc.Top = 0.031F;
            this.Gm_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Gm_MoveShipmentPrice
            // 
            this.Gm_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Gm_MoveShipmentPrice.Height = 0.1565F;
            this.Gm_MoveShipmentPrice.Left = 6.25F;
            this.Gm_MoveShipmentPrice.MultiLine = false;
            this.Gm_MoveShipmentPrice.Name = "Gm_MoveShipmentPrice";
            this.Gm_MoveShipmentPrice.OutputFormat = resources.GetString("Gm_MoveShipmentPrice.OutputFormat");
            this.Gm_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_MoveShipmentPrice.SummaryGroup = "GoodsMakerHeader";
            this.Gm_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_MoveShipmentPrice.Text = "1,234,567,890";
            this.Gm_MoveShipmentPrice.Top = 0.031F;
            this.Gm_MoveShipmentPrice.Width = 0.75F;
            // 
            // Gm_TotalShipmentPrice
            // 
            this.Gm_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Gm_TotalShipmentPrice.Height = 0.1565F;
            this.Gm_TotalShipmentPrice.Left = 7F;
            this.Gm_TotalShipmentPrice.MultiLine = false;
            this.Gm_TotalShipmentPrice.Name = "Gm_TotalShipmentPrice";
            this.Gm_TotalShipmentPrice.OutputFormat = resources.GetString("Gm_TotalShipmentPrice.OutputFormat");
            this.Gm_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_TotalShipmentPrice.SummaryGroup = "GoodsMakerHeader";
            this.Gm_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_TotalShipmentPrice.Text = "1,234,567,890";
            this.Gm_TotalShipmentPrice.Top = 0.031F;
            this.Gm_TotalShipmentPrice.Width = 0.75F;
            // 
            // Gm_GrossProfit
            // 
            this.Gm_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfit.DataField = "GrossProfit";
            this.Gm_GrossProfit.Height = 0.1565F;
            this.Gm_GrossProfit.Left = 7.75F;
            this.Gm_GrossProfit.MultiLine = false;
            this.Gm_GrossProfit.Name = "Gm_GrossProfit";
            this.Gm_GrossProfit.OutputFormat = resources.GetString("Gm_GrossProfit.OutputFormat");
            this.Gm_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_GrossProfit.SummaryGroup = "GoodsMakerHeader";
            this.Gm_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_GrossProfit.Text = "1,234,567,890";
            this.Gm_GrossProfit.Top = 0.031F;
            this.Gm_GrossProfit.Width = 0.75F;
            // 
            // Gm_Mark
            // 
            this.Gm_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_Mark.DataField = "Mark";
            this.Gm_Mark.Height = 0.1565F;
            this.Gm_Mark.Left = 10.5F;
            this.Gm_Mark.MultiLine = false;
            this.Gm_Mark.Name = "Gm_Mark";
            this.Gm_Mark.OutputFormat = resources.GetString("Gm_Mark.OutputFormat");
            this.Gm_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_Mark.SummaryGroup = "GoodsMakerHeader";
            this.Gm_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_Mark.Text = "123";
            this.Gm_Mark.Top = 0.031F;
            this.Gm_Mark.Width = 0.25F;
            // 
            // Gm_GrossProfitRate
            // 
            this.Gm_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_GrossProfitRate.DataField = "GrossProfitRate";
            this.Gm_GrossProfitRate.Height = 0.1565F;
            this.Gm_GrossProfitRate.Left = 8.5F;
            this.Gm_GrossProfitRate.MultiLine = false;
            this.Gm_GrossProfitRate.Name = "Gm_GrossProfitRate";
            this.Gm_GrossProfitRate.OutputFormat = resources.GetString("Gm_GrossProfitRate.OutputFormat");
            this.Gm_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_GrossProfitRate.SummaryGroup = "GoodsMakerHeader";
            this.Gm_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_GrossProfitRate.Text = "123.00";
            this.Gm_GrossProfitRate.Top = 0.03F;
            this.Gm_GrossProfitRate.Width = 0.5625F;
            // 
            // Gm_StockTotal
            // 
            this.Gm_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockTotal.DataField = "StockTotal";
            this.Gm_StockTotal.Height = 0.1565F;
            this.Gm_StockTotal.Left = 9.0625F;
            this.Gm_StockTotal.MultiLine = false;
            this.Gm_StockTotal.Name = "Gm_StockTotal";
            this.Gm_StockTotal.OutputFormat = resources.GetString("Gm_StockTotal.OutputFormat");
            this.Gm_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_StockTotal.SummaryGroup = "GoodsMakerHeader";
            this.Gm_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_StockTotal.Text = "1,234,567";
            this.Gm_StockTotal.Top = 0.03F;
            this.Gm_StockTotal.Width = 0.6875F;
            // 
            // Gm_StockMashinePrice
            // 
            this.Gm_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Gm_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Gm_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Gm_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Gm_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gm_StockMashinePrice.DataField = "StockMashinePrice";
            this.Gm_StockMashinePrice.Height = 0.1565F;
            this.Gm_StockMashinePrice.Left = 9.75F;
            this.Gm_StockMashinePrice.MultiLine = false;
            this.Gm_StockMashinePrice.Name = "Gm_StockMashinePrice";
            this.Gm_StockMashinePrice.OutputFormat = resources.GetString("Gm_StockMashinePrice.OutputFormat");
            this.Gm_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Gm_StockMashinePrice.SummaryGroup = "GoodsMakerHeader";
            this.Gm_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gm_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gm_StockMashinePrice.Text = "1,234,567,890";
            this.Gm_StockMashinePrice.Top = 0.03F;
            this.Gm_StockMashinePrice.Width = 0.75F;
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
            this.line9.Height = 0F;
            this.line9.Left = 0F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0F;
            this.line9.Width = 10.8F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.8F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.CanShrink = true;
            this.SupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Wh_WarehouseCode,
            this.Wh_WarehouseName,
            this.Line7,
            this.Wh_StockSupplierCode,
            this.Wh_SupplierSnm});
            this.SupplierHeader.DataField = "StockStockSupplierCode";
            this.SupplierHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SupplierHeader.Height = 0.25F;
            this.SupplierHeader.KeepTogether = true;
            this.SupplierHeader.Name = "SupplierHeader";
            this.SupplierHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SupplierHeader.Format += new System.EventHandler(this.SupplierHeader_Format);
            // 
            // Wh_WarehouseCode
            // 
            this.Wh_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.DataField = "WarehouseCode";
            this.Wh_WarehouseCode.Height = 0.156F;
            this.Wh_WarehouseCode.Left = 0F;
            this.Wh_WarehouseCode.MultiLine = false;
            this.Wh_WarehouseCode.Name = "Wh_WarehouseCode";
            this.Wh_WarehouseCode.OutputFormat = resources.GetString("Wh_WarehouseCode.OutputFormat");
            this.Wh_WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.Wh_WarehouseCode.Text = "1234";
            this.Wh_WarehouseCode.Top = 0.0625F;
            this.Wh_WarehouseCode.Width = 0.25F;
            // 
            // Wh_WarehouseName
            // 
            this.Wh_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.DataField = "WarehouseName";
            this.Wh_WarehouseName.Height = 0.156F;
            this.Wh_WarehouseName.Left = 0.25F;
            this.Wh_WarehouseName.MultiLine = false;
            this.Wh_WarehouseName.Name = "Wh_WarehouseName";
            this.Wh_WarehouseName.OutputFormat = resources.GetString("Wh_WarehouseName.OutputFormat");
            this.Wh_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Wh_WarehouseName.Text = "あいうえおかきくけこ";
            this.Wh_WarehouseName.Top = 0.0625F;
            this.Wh_WarehouseName.Width = 1.0625F;
            // 
            // Line7
            // 
            this.Line7.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.RightColor = System.Drawing.Color.Black;
            this.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.TopColor = System.Drawing.Color.Black;
            this.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Height = 0F;
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 2F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 10.8F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 10.8F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0F;
            // 
            // Wh_StockSupplierCode
            // 
            this.Wh_StockSupplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_StockSupplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockSupplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_StockSupplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockSupplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_StockSupplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockSupplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_StockSupplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_StockSupplierCode.DataField = "StockSupplierCode";
            this.Wh_StockSupplierCode.Height = 0.156F;
            this.Wh_StockSupplierCode.Left = 1.3125F;
            this.Wh_StockSupplierCode.MultiLine = false;
            this.Wh_StockSupplierCode.Name = "Wh_StockSupplierCode";
            this.Wh_StockSupplierCode.OutputFormat = resources.GetString("Wh_StockSupplierCode.OutputFormat");
            this.Wh_StockSupplierCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.Wh_StockSupplierCode.Text = "123456";
            this.Wh_StockSupplierCode.Top = 0.0625F;
            this.Wh_StockSupplierCode.Width = 0.375F;
            // 
            // Wh_SupplierSnm
            // 
            this.Wh_SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_SupplierSnm.DataField = "SupplierSnm";
            this.Wh_SupplierSnm.Height = 0.156F;
            this.Wh_SupplierSnm.Left = 1.6875F;
            this.Wh_SupplierSnm.MultiLine = false;
            this.Wh_SupplierSnm.Name = "Wh_SupplierSnm";
            this.Wh_SupplierSnm.OutputFormat = resources.GetString("Wh_SupplierSnm.OutputFormat");
            this.Wh_SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Wh_SupplierSnm.Text = "あいうえおかきくけこ";
            this.Wh_SupplierSnm.Top = 0.0625F;
            this.Wh_SupplierSnm.Width = 1.1875F;
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.CanShrink = true;
            this.SupplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SUPPLIERTITLE,
            this.StockSupplierCode,
            this.Sup_GrossProfit,
            this.SupplierSnm,
            this.Sup_LMonthStockPrice,
            this.Sup_StockPriceTaxExc,
            this.Sup_MoveArrivalPrice,
            this.Sup_TotalArrivalPrice,
            this.Sup_MoveShipmentPrice,
            this.Sup_TotalShipmentPrice,
            this.Sup_GrossProfitRate,
            this.Sup_StockTotal,
            this.Sup_StockMashinePrice,
            this.Sup_SalesMoneyTaxExc,
            this.Sup_Mark,
            this.line8});
            this.SupplierFooter.Height = 0.448F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            this.SupplierFooter.Format += new System.EventHandler(this.SupplierFooter_Format);
            // 
            // SUPPLIERTITLE
            // 
            this.SUPPLIERTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SUPPLIERTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUPPLIERTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SUPPLIERTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUPPLIERTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SUPPLIERTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUPPLIERTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SUPPLIERTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SUPPLIERTITLE.Height = 0.219F;
            this.SUPPLIERTITLE.Left = 0.1875F;
            this.SUPPLIERTITLE.MultiLine = false;
            this.SUPPLIERTITLE.Name = "SUPPLIERTITLE";
            this.SUPPLIERTITLE.OutputFormat = resources.GetString("SUPPLIERTITLE.OutputFormat");
            this.SUPPLIERTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SUPPLIERTITLE.Text = "仕入先計";
            this.SUPPLIERTITLE.Top = 0.031F;
            this.SUPPLIERTITLE.Width = 0.8125F;
            // 
            // StockSupplierCode
            // 
            this.StockSupplierCode.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSupplierCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSupplierCode.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSupplierCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSupplierCode.Border.RightColor = System.Drawing.Color.Black;
            this.StockSupplierCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSupplierCode.Border.TopColor = System.Drawing.Color.Black;
            this.StockSupplierCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSupplierCode.DataField = "StockSupplierCode";
            this.StockSupplierCode.Height = 0.15625F;
            this.StockSupplierCode.Left = 1.3125F;
            this.StockSupplierCode.MultiLine = false;
            this.StockSupplierCode.Name = "StockSupplierCode";
            this.StockSupplierCode.OutputFormat = resources.GetString("StockSupplierCode.OutputFormat");
            this.StockSupplierCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.StockSupplierCode.Text = "1234567890";
            this.StockSupplierCode.Top = 0F;
            this.StockSupplierCode.Visible = false;
            this.StockSupplierCode.Width = 0.75F;
            // 
            // Sup_GrossProfit
            // 
            this.Sup_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfit.DataField = "GrossProfit";
            this.Sup_GrossProfit.Height = 0.1565F;
            this.Sup_GrossProfit.Left = 7.75F;
            this.Sup_GrossProfit.MultiLine = false;
            this.Sup_GrossProfit.Name = "Sup_GrossProfit";
            this.Sup_GrossProfit.OutputFormat = resources.GetString("Sup_GrossProfit.OutputFormat");
            this.Sup_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_GrossProfit.SummaryGroup = "SupplierHeader";
            this.Sup_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_GrossProfit.Text = "1,234,567,890";
            this.Sup_GrossProfit.Top = 0.031F;
            this.Sup_GrossProfit.Width = 0.75F;
            // 
            // SupplierSnm
            // 
            this.SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.DataField = "SupplierSnm";
            this.SupplierSnm.Height = 0.156F;
            this.SupplierSnm.Left = 1.3125F;
            this.SupplierSnm.MultiLine = false;
            this.SupplierSnm.Name = "SupplierSnm";
            this.SupplierSnm.OutputFormat = resources.GetString("SupplierSnm.OutputFormat");
            this.SupplierSnm.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.SupplierSnm.Text = "あいうえおかきくけこ";
            this.SupplierSnm.Top = 0.1875F;
            this.SupplierSnm.Visible = false;
            this.SupplierSnm.Width = 1.188F;
            // 
            // Sup_LMonthStockPrice
            // 
            this.Sup_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Sup_LMonthStockPrice.Height = 0.1565F;
            this.Sup_LMonthStockPrice.Left = 2.5F;
            this.Sup_LMonthStockPrice.MultiLine = false;
            this.Sup_LMonthStockPrice.Name = "Sup_LMonthStockPrice";
            this.Sup_LMonthStockPrice.OutputFormat = resources.GetString("Sup_LMonthStockPrice.OutputFormat");
            this.Sup_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_LMonthStockPrice.SummaryGroup = "SupplierHeader";
            this.Sup_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_LMonthStockPrice.Text = "1,234,567,890";
            this.Sup_LMonthStockPrice.Top = 0.031F;
            this.Sup_LMonthStockPrice.Width = 0.75F;
            // 
            // Sup_StockPriceTaxExc
            // 
            this.Sup_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Sup_StockPriceTaxExc.Height = 0.156F;
            this.Sup_StockPriceTaxExc.Left = 3.25F;
            this.Sup_StockPriceTaxExc.MultiLine = false;
            this.Sup_StockPriceTaxExc.Name = "Sup_StockPriceTaxExc";
            this.Sup_StockPriceTaxExc.OutputFormat = resources.GetString("Sup_StockPriceTaxExc.OutputFormat");
            this.Sup_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_StockPriceTaxExc.SummaryGroup = "SupplierHeader";
            this.Sup_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_StockPriceTaxExc.Text = "1,234,567,890";
            this.Sup_StockPriceTaxExc.Top = 0.031F;
            this.Sup_StockPriceTaxExc.Width = 0.75F;
            // 
            // Sup_MoveArrivalPrice
            // 
            this.Sup_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Sup_MoveArrivalPrice.Height = 0.1565F;
            this.Sup_MoveArrivalPrice.Left = 4F;
            this.Sup_MoveArrivalPrice.MultiLine = false;
            this.Sup_MoveArrivalPrice.Name = "Sup_MoveArrivalPrice";
            this.Sup_MoveArrivalPrice.OutputFormat = resources.GetString("Sup_MoveArrivalPrice.OutputFormat");
            this.Sup_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_MoveArrivalPrice.SummaryGroup = "SupplierHeader";
            this.Sup_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_MoveArrivalPrice.Text = "1,234,567,890";
            this.Sup_MoveArrivalPrice.Top = 0.031F;
            this.Sup_MoveArrivalPrice.Width = 0.75F;
            // 
            // Sup_TotalArrivalPrice
            // 
            this.Sup_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Sup_TotalArrivalPrice.Height = 0.1565F;
            this.Sup_TotalArrivalPrice.Left = 4.75F;
            this.Sup_TotalArrivalPrice.MultiLine = false;
            this.Sup_TotalArrivalPrice.Name = "Sup_TotalArrivalPrice";
            this.Sup_TotalArrivalPrice.OutputFormat = resources.GetString("Sup_TotalArrivalPrice.OutputFormat");
            this.Sup_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_TotalArrivalPrice.SummaryGroup = "SupplierHeader";
            this.Sup_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_TotalArrivalPrice.Text = "1,234,567,890";
            this.Sup_TotalArrivalPrice.Top = 0.031F;
            this.Sup_TotalArrivalPrice.Width = 0.75F;
            // 
            // Sup_MoveShipmentPrice
            // 
            this.Sup_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Sup_MoveShipmentPrice.Height = 0.1565F;
            this.Sup_MoveShipmentPrice.Left = 6.25F;
            this.Sup_MoveShipmentPrice.MultiLine = false;
            this.Sup_MoveShipmentPrice.Name = "Sup_MoveShipmentPrice";
            this.Sup_MoveShipmentPrice.OutputFormat = resources.GetString("Sup_MoveShipmentPrice.OutputFormat");
            this.Sup_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_MoveShipmentPrice.SummaryGroup = "SupplierHeader";
            this.Sup_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_MoveShipmentPrice.Text = "1,234,567,890";
            this.Sup_MoveShipmentPrice.Top = 0.031F;
            this.Sup_MoveShipmentPrice.Width = 0.75F;
            // 
            // Sup_TotalShipmentPrice
            // 
            this.Sup_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Sup_TotalShipmentPrice.Height = 0.1565F;
            this.Sup_TotalShipmentPrice.Left = 7F;
            this.Sup_TotalShipmentPrice.MultiLine = false;
            this.Sup_TotalShipmentPrice.Name = "Sup_TotalShipmentPrice";
            this.Sup_TotalShipmentPrice.OutputFormat = resources.GetString("Sup_TotalShipmentPrice.OutputFormat");
            this.Sup_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_TotalShipmentPrice.SummaryGroup = "SupplierHeader";
            this.Sup_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_TotalShipmentPrice.Text = "1,234,567,890";
            this.Sup_TotalShipmentPrice.Top = 0.031F;
            this.Sup_TotalShipmentPrice.Width = 0.75F;
            // 
            // Sup_GrossProfitRate
            // 
            this.Sup_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_GrossProfitRate.DataField = "GrossProfitRate";
            this.Sup_GrossProfitRate.Height = 0.1565F;
            this.Sup_GrossProfitRate.Left = 8.5F;
            this.Sup_GrossProfitRate.MultiLine = false;
            this.Sup_GrossProfitRate.Name = "Sup_GrossProfitRate";
            this.Sup_GrossProfitRate.OutputFormat = resources.GetString("Sup_GrossProfitRate.OutputFormat");
            this.Sup_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_GrossProfitRate.SummaryGroup = "SupplierHeader";
            this.Sup_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_GrossProfitRate.Text = "123.00";
            this.Sup_GrossProfitRate.Top = 0.03F;
            this.Sup_GrossProfitRate.Width = 0.5625F;
            // 
            // Sup_StockTotal
            // 
            this.Sup_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockTotal.DataField = "StockTotal";
            this.Sup_StockTotal.Height = 0.1565F;
            this.Sup_StockTotal.Left = 9.0625F;
            this.Sup_StockTotal.MultiLine = false;
            this.Sup_StockTotal.Name = "Sup_StockTotal";
            this.Sup_StockTotal.OutputFormat = resources.GetString("Sup_StockTotal.OutputFormat");
            this.Sup_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_StockTotal.SummaryGroup = "SupplierHeader";
            this.Sup_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_StockTotal.Text = "1,234,567";
            this.Sup_StockTotal.Top = 0.03F;
            this.Sup_StockTotal.Width = 0.6875F;
            // 
            // Sup_StockMashinePrice
            // 
            this.Sup_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_StockMashinePrice.DataField = "StockMashinePrice";
            this.Sup_StockMashinePrice.Height = 0.1565F;
            this.Sup_StockMashinePrice.Left = 9.75F;
            this.Sup_StockMashinePrice.MultiLine = false;
            this.Sup_StockMashinePrice.Name = "Sup_StockMashinePrice";
            this.Sup_StockMashinePrice.OutputFormat = resources.GetString("Sup_StockMashinePrice.OutputFormat");
            this.Sup_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_StockMashinePrice.SummaryGroup = "SupplierHeader";
            this.Sup_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_StockMashinePrice.Text = "1,234,567,890";
            this.Sup_StockMashinePrice.Top = 0.03F;
            this.Sup_StockMashinePrice.Width = 0.75F;
            // 
            // Sup_SalesMoneyTaxExc
            // 
            this.Sup_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Sup_SalesMoneyTaxExc.Height = 0.1565F;
            this.Sup_SalesMoneyTaxExc.Left = 5.5F;
            this.Sup_SalesMoneyTaxExc.MultiLine = false;
            this.Sup_SalesMoneyTaxExc.Name = "Sup_SalesMoneyTaxExc";
            this.Sup_SalesMoneyTaxExc.OutputFormat = resources.GetString("Sup_SalesMoneyTaxExc.OutputFormat");
            this.Sup_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_SalesMoneyTaxExc.SummaryGroup = "SupplierHeader";
            this.Sup_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Sup_SalesMoneyTaxExc.Top = 0.031F;
            this.Sup_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Sup_Mark
            // 
            this.Sup_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Sup_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Sup_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Sup_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Sup_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sup_Mark.DataField = "Mark";
            this.Sup_Mark.Height = 0.1565F;
            this.Sup_Mark.Left = 10.5F;
            this.Sup_Mark.MultiLine = false;
            this.Sup_Mark.Name = "Sup_Mark";
            this.Sup_Mark.OutputFormat = resources.GetString("Sup_Mark.OutputFormat");
            this.Sup_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sup_Mark.SummaryGroup = "SupplierHeader";
            this.Sup_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sup_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sup_Mark.Text = "123";
            this.Sup_Mark.Top = 0.031F;
            this.Sup_Mark.Width = 0.25F;
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
            this.line8.Width = 10.8F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // LargeGoodsGanreHeader
            // 
            this.LargeGoodsGanreHeader.Height = 0F;
            this.LargeGoodsGanreHeader.Name = "LargeGoodsGanreHeader";
            // 
            // LargeGoodsGanreFooter
            // 
            this.LargeGoodsGanreFooter.CanShrink = true;
            this.LargeGoodsGanreFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.LGOODSGANRETITLE,
            this.GoodsLGroupName,
            this.GoodsLGroupCode,
            this.Lg_LMonthStockPrice,
            this.Lg_GrossProfitRate,
            this.Lg_StockTotal,
            this.Lg_StockPriceTaxExc,
            this.Lg_MoveArrivalPrice,
            this.Lg_StockMashinePrice,
            this.Lg_TotalArrivalPrice,
            this.Lg_SalesMoneyTaxExc,
            this.Lg_MoveShipmentPrice,
            this.Lg_TotalShipmentPrice,
            this.Lg_GrossProfit,
            this.Lg_Mark,
            this.line6});
            this.LargeGoodsGanreFooter.Height = 0.448F;
            this.LargeGoodsGanreFooter.KeepTogether = true;
            this.LargeGoodsGanreFooter.Name = "LargeGoodsGanreFooter";
            this.LargeGoodsGanreFooter.Format += new System.EventHandler(this.LargeGoodsGanreFooter_Format);
            // 
            // LGOODSGANRETITLE
            // 
            this.LGOODSGANRETITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.LGOODSGANRETITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LGOODSGANRETITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.LGOODSGANRETITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LGOODSGANRETITLE.Border.RightColor = System.Drawing.Color.Black;
            this.LGOODSGANRETITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LGOODSGANRETITLE.Border.TopColor = System.Drawing.Color.Black;
            this.LGOODSGANRETITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LGOODSGANRETITLE.Height = 0.219F;
            this.LGOODSGANRETITLE.Left = 0.1875F;
            this.LGOODSGANRETITLE.MultiLine = false;
            this.LGOODSGANRETITLE.Name = "LGOODSGANRETITLE";
            this.LGOODSGANRETITLE.OutputFormat = resources.GetString("LGOODSGANRETITLE.OutputFormat");
            this.LGOODSGANRETITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.LGOODSGANRETITLE.Text = "大分類計";
            this.LGOODSGANRETITLE.Top = 0.031F;
            this.LGOODSGANRETITLE.Width = 0.8125F;
            // 
            // GoodsLGroupName
            // 
            this.GoodsLGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsLGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsLGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsLGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsLGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupName.DataField = "Sort_GoodsLGroupName";
            this.GoodsLGroupName.Height = 0.156F;
            this.GoodsLGroupName.Left = 1.4375F;
            this.GoodsLGroupName.MultiLine = false;
            this.GoodsLGroupName.Name = "GoodsLGroupName";
            this.GoodsLGroupName.OutputFormat = resources.GetString("GoodsLGroupName.OutputFormat");
            this.GoodsLGroupName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GoodsLGroupName.Text = "あいうえおかきくけこ";
            this.GoodsLGroupName.Top = 0.031F;
            this.GoodsLGroupName.Width = 1.0625F;
            // 
            // GoodsLGroupCode
            // 
            this.GoodsLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroupCode.DataField = "Sort_GoodsLGroupCode";
            this.GoodsLGroupCode.Height = 0.15625F;
            this.GoodsLGroupCode.Left = 1.125F;
            this.GoodsLGroupCode.MultiLine = false;
            this.GoodsLGroupCode.Name = "GoodsLGroupCode";
            this.GoodsLGroupCode.OutputFormat = resources.GetString("GoodsLGroupCode.OutputFormat");
            this.GoodsLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsLGroupCode.Text = "1234";
            this.GoodsLGroupCode.Top = 0.031F;
            this.GoodsLGroupCode.Width = 0.3125F;
            // 
            // Lg_LMonthStockPrice
            // 
            this.Lg_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Lg_LMonthStockPrice.Height = 0.1565F;
            this.Lg_LMonthStockPrice.Left = 2.5F;
            this.Lg_LMonthStockPrice.MultiLine = false;
            this.Lg_LMonthStockPrice.Name = "Lg_LMonthStockPrice";
            this.Lg_LMonthStockPrice.OutputFormat = resources.GetString("Lg_LMonthStockPrice.OutputFormat");
            this.Lg_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_LMonthStockPrice.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_LMonthStockPrice.Text = "1,234,567,890";
            this.Lg_LMonthStockPrice.Top = 0.031F;
            this.Lg_LMonthStockPrice.Width = 0.75F;
            // 
            // Lg_GrossProfitRate
            // 
            this.Lg_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfitRate.DataField = "GrossProfitRate";
            this.Lg_GrossProfitRate.Height = 0.1565F;
            this.Lg_GrossProfitRate.Left = 8.5F;
            this.Lg_GrossProfitRate.MultiLine = false;
            this.Lg_GrossProfitRate.Name = "Lg_GrossProfitRate";
            this.Lg_GrossProfitRate.OutputFormat = resources.GetString("Lg_GrossProfitRate.OutputFormat");
            this.Lg_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_GrossProfitRate.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_GrossProfitRate.Text = "123.00";
            this.Lg_GrossProfitRate.Top = 0.03F;
            this.Lg_GrossProfitRate.Width = 0.5625F;
            // 
            // Lg_StockTotal
            // 
            this.Lg_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockTotal.DataField = "StockTotal";
            this.Lg_StockTotal.Height = 0.1565F;
            this.Lg_StockTotal.Left = 9.0625F;
            this.Lg_StockTotal.MultiLine = false;
            this.Lg_StockTotal.Name = "Lg_StockTotal";
            this.Lg_StockTotal.OutputFormat = resources.GetString("Lg_StockTotal.OutputFormat");
            this.Lg_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_StockTotal.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_StockTotal.Text = "1,234,567";
            this.Lg_StockTotal.Top = 0.03F;
            this.Lg_StockTotal.Width = 0.6875F;
            // 
            // Lg_StockPriceTaxExc
            // 
            this.Lg_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Lg_StockPriceTaxExc.Height = 0.156F;
            this.Lg_StockPriceTaxExc.Left = 3.25F;
            this.Lg_StockPriceTaxExc.MultiLine = false;
            this.Lg_StockPriceTaxExc.Name = "Lg_StockPriceTaxExc";
            this.Lg_StockPriceTaxExc.OutputFormat = resources.GetString("Lg_StockPriceTaxExc.OutputFormat");
            this.Lg_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_StockPriceTaxExc.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_StockPriceTaxExc.Text = "1,234,567,890";
            this.Lg_StockPriceTaxExc.Top = 0.031F;
            this.Lg_StockPriceTaxExc.Width = 0.75F;
            // 
            // Lg_MoveArrivalPrice
            // 
            this.Lg_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Lg_MoveArrivalPrice.Height = 0.1565F;
            this.Lg_MoveArrivalPrice.Left = 4F;
            this.Lg_MoveArrivalPrice.MultiLine = false;
            this.Lg_MoveArrivalPrice.Name = "Lg_MoveArrivalPrice";
            this.Lg_MoveArrivalPrice.OutputFormat = resources.GetString("Lg_MoveArrivalPrice.OutputFormat");
            this.Lg_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_MoveArrivalPrice.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_MoveArrivalPrice.Text = "1,234,567,890";
            this.Lg_MoveArrivalPrice.Top = 0.031F;
            this.Lg_MoveArrivalPrice.Width = 0.75F;
            // 
            // Lg_StockMashinePrice
            // 
            this.Lg_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_StockMashinePrice.DataField = "StockMashinePrice";
            this.Lg_StockMashinePrice.Height = 0.1565F;
            this.Lg_StockMashinePrice.Left = 9.75F;
            this.Lg_StockMashinePrice.MultiLine = false;
            this.Lg_StockMashinePrice.Name = "Lg_StockMashinePrice";
            this.Lg_StockMashinePrice.OutputFormat = resources.GetString("Lg_StockMashinePrice.OutputFormat");
            this.Lg_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_StockMashinePrice.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_StockMashinePrice.Text = "1,234,567,890";
            this.Lg_StockMashinePrice.Top = 0.03F;
            this.Lg_StockMashinePrice.Width = 0.75F;
            // 
            // Lg_TotalArrivalPrice
            // 
            this.Lg_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Lg_TotalArrivalPrice.Height = 0.1565F;
            this.Lg_TotalArrivalPrice.Left = 4.75F;
            this.Lg_TotalArrivalPrice.MultiLine = false;
            this.Lg_TotalArrivalPrice.Name = "Lg_TotalArrivalPrice";
            this.Lg_TotalArrivalPrice.OutputFormat = resources.GetString("Lg_TotalArrivalPrice.OutputFormat");
            this.Lg_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_TotalArrivalPrice.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_TotalArrivalPrice.Text = "1,234,567,890";
            this.Lg_TotalArrivalPrice.Top = 0.031F;
            this.Lg_TotalArrivalPrice.Width = 0.75F;
            // 
            // Lg_SalesMoneyTaxExc
            // 
            this.Lg_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Lg_SalesMoneyTaxExc.Height = 0.1565F;
            this.Lg_SalesMoneyTaxExc.Left = 5.5F;
            this.Lg_SalesMoneyTaxExc.MultiLine = false;
            this.Lg_SalesMoneyTaxExc.Name = "Lg_SalesMoneyTaxExc";
            this.Lg_SalesMoneyTaxExc.OutputFormat = resources.GetString("Lg_SalesMoneyTaxExc.OutputFormat");
            this.Lg_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_SalesMoneyTaxExc.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Lg_SalesMoneyTaxExc.Top = 0.031F;
            this.Lg_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Lg_MoveShipmentPrice
            // 
            this.Lg_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Lg_MoveShipmentPrice.Height = 0.1565F;
            this.Lg_MoveShipmentPrice.Left = 6.25F;
            this.Lg_MoveShipmentPrice.MultiLine = false;
            this.Lg_MoveShipmentPrice.Name = "Lg_MoveShipmentPrice";
            this.Lg_MoveShipmentPrice.OutputFormat = resources.GetString("Lg_MoveShipmentPrice.OutputFormat");
            this.Lg_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_MoveShipmentPrice.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_MoveShipmentPrice.Text = "1,234,567,890";
            this.Lg_MoveShipmentPrice.Top = 0.031F;
            this.Lg_MoveShipmentPrice.Width = 0.75F;
            // 
            // Lg_TotalShipmentPrice
            // 
            this.Lg_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Lg_TotalShipmentPrice.Height = 0.1565F;
            this.Lg_TotalShipmentPrice.Left = 7F;
            this.Lg_TotalShipmentPrice.MultiLine = false;
            this.Lg_TotalShipmentPrice.Name = "Lg_TotalShipmentPrice";
            this.Lg_TotalShipmentPrice.OutputFormat = resources.GetString("Lg_TotalShipmentPrice.OutputFormat");
            this.Lg_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_TotalShipmentPrice.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_TotalShipmentPrice.Text = "1,234,567,890";
            this.Lg_TotalShipmentPrice.Top = 0.031F;
            this.Lg_TotalShipmentPrice.Width = 0.75F;
            // 
            // Lg_GrossProfit
            // 
            this.Lg_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_GrossProfit.DataField = "GrossProfit";
            this.Lg_GrossProfit.Height = 0.1565F;
            this.Lg_GrossProfit.Left = 7.75F;
            this.Lg_GrossProfit.MultiLine = false;
            this.Lg_GrossProfit.Name = "Lg_GrossProfit";
            this.Lg_GrossProfit.OutputFormat = resources.GetString("Lg_GrossProfit.OutputFormat");
            this.Lg_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_GrossProfit.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_GrossProfit.Text = "1,234,567,890";
            this.Lg_GrossProfit.Top = 0.031F;
            this.Lg_GrossProfit.Width = 0.75F;
            // 
            // Lg_Mark
            // 
            this.Lg_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Lg_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Lg_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Lg_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Lg_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lg_Mark.DataField = "Mark";
            this.Lg_Mark.Height = 0.1565F;
            this.Lg_Mark.Left = 10.5F;
            this.Lg_Mark.MultiLine = false;
            this.Lg_Mark.Name = "Lg_Mark";
            this.Lg_Mark.OutputFormat = resources.GetString("Lg_Mark.OutputFormat");
            this.Lg_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Lg_Mark.SummaryGroup = "LargeGoodsGanreHeader";
            this.Lg_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Lg_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Lg_Mark.Text = "123";
            this.Lg_Mark.Top = 0.031F;
            this.Lg_Mark.Width = 0.25F;
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
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // MediumGoodsGanreHeader
            // 
            this.MediumGoodsGanreHeader.Height = 0F;
            this.MediumGoodsGanreHeader.Name = "MediumGoodsGanreHeader";
            // 
            // MediumGoodsGanreFooter
            // 
            this.MediumGoodsGanreFooter.CanShrink = true;
            this.MediumGoodsGanreFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.MGOODSGANRETITLE,
            this.GoodsMGroupName,
            this.GoodsMGroupCode,
            this.Mg_LMonthStockPrice,
            this.Mg_GrossProfitRate,
            this.Mg_StockTotal,
            this.Mg_StockPriceTaxExc,
            this.Mg_MoveArrivalPrice,
            this.Mg_StockMashinePrice,
            this.Mg_TotalArrivalPrice,
            this.Mg_SalesMoneyTaxExc,
            this.Mg_MoveShipmentPrice,
            this.Mg_TotalShipmentPrice,
            this.Mg_GrossProfit,
            this.Mg_Mark,
            this.line4});
            this.MediumGoodsGanreFooter.Height = 0.448F;
            this.MediumGoodsGanreFooter.KeepTogether = true;
            this.MediumGoodsGanreFooter.Name = "MediumGoodsGanreFooter";
            this.MediumGoodsGanreFooter.Format += new System.EventHandler(this.MediumGoodsGanreFooter_Format);
            // 
            // MGOODSGANRETITLE
            // 
            this.MGOODSGANRETITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.MGOODSGANRETITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MGOODSGANRETITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.MGOODSGANRETITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MGOODSGANRETITLE.Border.RightColor = System.Drawing.Color.Black;
            this.MGOODSGANRETITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MGOODSGANRETITLE.Border.TopColor = System.Drawing.Color.Black;
            this.MGOODSGANRETITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MGOODSGANRETITLE.Height = 0.219F;
            this.MGOODSGANRETITLE.Left = 0.1875F;
            this.MGOODSGANRETITLE.MultiLine = false;
            this.MGOODSGANRETITLE.Name = "MGOODSGANRETITLE";
            this.MGOODSGANRETITLE.OutputFormat = resources.GetString("MGOODSGANRETITLE.OutputFormat");
            this.MGOODSGANRETITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.MGOODSGANRETITLE.Text = "中分類計";
            this.MGOODSGANRETITLE.Top = 0.031F;
            this.MGOODSGANRETITLE.Width = 0.8125F;
            // 
            // GoodsMGroupName
            // 
            this.GoodsMGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.DataField = "Sort_GoodsMGroupName";
            this.GoodsMGroupName.Height = 0.156F;
            this.GoodsMGroupName.Left = 1.4375F;
            this.GoodsMGroupName.MultiLine = false;
            this.GoodsMGroupName.Name = "GoodsMGroupName";
            this.GoodsMGroupName.OutputFormat = resources.GetString("GoodsMGroupName.OutputFormat");
            this.GoodsMGroupName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.GoodsMGroupName.Text = "あいうえおかきくけこ";
            this.GoodsMGroupName.Top = 0.031F;
            this.GoodsMGroupName.Width = 1.0625F;
            // 
            // GoodsMGroupCode
            // 
            this.GoodsMGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupCode.DataField = "Sort_GoodsMGroupCode";
            this.GoodsMGroupCode.Height = 0.15625F;
            this.GoodsMGroupCode.Left = 1.125F;
            this.GoodsMGroupCode.MultiLine = false;
            this.GoodsMGroupCode.Name = "GoodsMGroupCode";
            this.GoodsMGroupCode.OutputFormat = resources.GetString("GoodsMGroupCode.OutputFormat");
            this.GoodsMGroupCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.GoodsMGroupCode.Text = "1234";
            this.GoodsMGroupCode.Top = 0.031F;
            this.GoodsMGroupCode.Width = 0.3125F;
            // 
            // Mg_LMonthStockPrice
            // 
            this.Mg_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Mg_LMonthStockPrice.Height = 0.1565F;
            this.Mg_LMonthStockPrice.Left = 2.5F;
            this.Mg_LMonthStockPrice.MultiLine = false;
            this.Mg_LMonthStockPrice.Name = "Mg_LMonthStockPrice";
            this.Mg_LMonthStockPrice.OutputFormat = resources.GetString("Mg_LMonthStockPrice.OutputFormat");
            this.Mg_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_LMonthStockPrice.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_LMonthStockPrice.Text = "1,234,567,890";
            this.Mg_LMonthStockPrice.Top = 0.031F;
            this.Mg_LMonthStockPrice.Width = 0.75F;
            // 
            // Mg_GrossProfitRate
            // 
            this.Mg_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfitRate.DataField = "GrossProfitRate";
            this.Mg_GrossProfitRate.Height = 0.1565F;
            this.Mg_GrossProfitRate.Left = 8.5F;
            this.Mg_GrossProfitRate.MultiLine = false;
            this.Mg_GrossProfitRate.Name = "Mg_GrossProfitRate";
            this.Mg_GrossProfitRate.OutputFormat = resources.GetString("Mg_GrossProfitRate.OutputFormat");
            this.Mg_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_GrossProfitRate.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_GrossProfitRate.Text = "123.00";
            this.Mg_GrossProfitRate.Top = 0.03F;
            this.Mg_GrossProfitRate.Width = 0.5625F;
            // 
            // Mg_StockTotal
            // 
            this.Mg_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockTotal.DataField = "StockTotal";
            this.Mg_StockTotal.Height = 0.1565F;
            this.Mg_StockTotal.Left = 9.0625F;
            this.Mg_StockTotal.MultiLine = false;
            this.Mg_StockTotal.Name = "Mg_StockTotal";
            this.Mg_StockTotal.OutputFormat = resources.GetString("Mg_StockTotal.OutputFormat");
            this.Mg_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_StockTotal.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_StockTotal.Text = "1,234,567";
            this.Mg_StockTotal.Top = 0.03F;
            this.Mg_StockTotal.Width = 0.6875F;
            // 
            // Mg_StockPriceTaxExc
            // 
            this.Mg_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Mg_StockPriceTaxExc.Height = 0.156F;
            this.Mg_StockPriceTaxExc.Left = 3.25F;
            this.Mg_StockPriceTaxExc.MultiLine = false;
            this.Mg_StockPriceTaxExc.Name = "Mg_StockPriceTaxExc";
            this.Mg_StockPriceTaxExc.OutputFormat = resources.GetString("Mg_StockPriceTaxExc.OutputFormat");
            this.Mg_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_StockPriceTaxExc.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_StockPriceTaxExc.Text = "1,234,567,890";
            this.Mg_StockPriceTaxExc.Top = 0.031F;
            this.Mg_StockPriceTaxExc.Width = 0.75F;
            // 
            // Mg_MoveArrivalPrice
            // 
            this.Mg_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Mg_MoveArrivalPrice.Height = 0.1565F;
            this.Mg_MoveArrivalPrice.Left = 4F;
            this.Mg_MoveArrivalPrice.MultiLine = false;
            this.Mg_MoveArrivalPrice.Name = "Mg_MoveArrivalPrice";
            this.Mg_MoveArrivalPrice.OutputFormat = resources.GetString("Mg_MoveArrivalPrice.OutputFormat");
            this.Mg_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_MoveArrivalPrice.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_MoveArrivalPrice.Text = "1,234,567,890";
            this.Mg_MoveArrivalPrice.Top = 0.031F;
            this.Mg_MoveArrivalPrice.Width = 0.75F;
            // 
            // Mg_StockMashinePrice
            // 
            this.Mg_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_StockMashinePrice.DataField = "StockMashinePrice";
            this.Mg_StockMashinePrice.Height = 0.1565F;
            this.Mg_StockMashinePrice.Left = 9.75F;
            this.Mg_StockMashinePrice.MultiLine = false;
            this.Mg_StockMashinePrice.Name = "Mg_StockMashinePrice";
            this.Mg_StockMashinePrice.OutputFormat = resources.GetString("Mg_StockMashinePrice.OutputFormat");
            this.Mg_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_StockMashinePrice.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_StockMashinePrice.Text = "1,234,567,890";
            this.Mg_StockMashinePrice.Top = 0.03F;
            this.Mg_StockMashinePrice.Width = 0.75F;
            // 
            // Mg_TotalArrivalPrice
            // 
            this.Mg_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Mg_TotalArrivalPrice.Height = 0.1565F;
            this.Mg_TotalArrivalPrice.Left = 4.75F;
            this.Mg_TotalArrivalPrice.MultiLine = false;
            this.Mg_TotalArrivalPrice.Name = "Mg_TotalArrivalPrice";
            this.Mg_TotalArrivalPrice.OutputFormat = resources.GetString("Mg_TotalArrivalPrice.OutputFormat");
            this.Mg_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_TotalArrivalPrice.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_TotalArrivalPrice.Text = "1,234,567,890";
            this.Mg_TotalArrivalPrice.Top = 0.031F;
            this.Mg_TotalArrivalPrice.Width = 0.75F;
            // 
            // Mg_SalesMoneyTaxExc
            // 
            this.Mg_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Mg_SalesMoneyTaxExc.Height = 0.1565F;
            this.Mg_SalesMoneyTaxExc.Left = 5.5F;
            this.Mg_SalesMoneyTaxExc.MultiLine = false;
            this.Mg_SalesMoneyTaxExc.Name = "Mg_SalesMoneyTaxExc";
            this.Mg_SalesMoneyTaxExc.OutputFormat = resources.GetString("Mg_SalesMoneyTaxExc.OutputFormat");
            this.Mg_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_SalesMoneyTaxExc.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Mg_SalesMoneyTaxExc.Top = 0.031F;
            this.Mg_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Mg_MoveShipmentPrice
            // 
            this.Mg_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Mg_MoveShipmentPrice.Height = 0.1565F;
            this.Mg_MoveShipmentPrice.Left = 6.25F;
            this.Mg_MoveShipmentPrice.MultiLine = false;
            this.Mg_MoveShipmentPrice.Name = "Mg_MoveShipmentPrice";
            this.Mg_MoveShipmentPrice.OutputFormat = resources.GetString("Mg_MoveShipmentPrice.OutputFormat");
            this.Mg_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_MoveShipmentPrice.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_MoveShipmentPrice.Text = "1,234,567,890";
            this.Mg_MoveShipmentPrice.Top = 0.031F;
            this.Mg_MoveShipmentPrice.Width = 0.75F;
            // 
            // Mg_TotalShipmentPrice
            // 
            this.Mg_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Mg_TotalShipmentPrice.Height = 0.1565F;
            this.Mg_TotalShipmentPrice.Left = 7F;
            this.Mg_TotalShipmentPrice.MultiLine = false;
            this.Mg_TotalShipmentPrice.Name = "Mg_TotalShipmentPrice";
            this.Mg_TotalShipmentPrice.OutputFormat = resources.GetString("Mg_TotalShipmentPrice.OutputFormat");
            this.Mg_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_TotalShipmentPrice.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_TotalShipmentPrice.Text = "1,234,567,890";
            this.Mg_TotalShipmentPrice.Top = 0.031F;
            this.Mg_TotalShipmentPrice.Width = 0.75F;
            // 
            // Mg_GrossProfit
            // 
            this.Mg_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_GrossProfit.DataField = "GrossProfit";
            this.Mg_GrossProfit.Height = 0.1565F;
            this.Mg_GrossProfit.Left = 7.75F;
            this.Mg_GrossProfit.MultiLine = false;
            this.Mg_GrossProfit.Name = "Mg_GrossProfit";
            this.Mg_GrossProfit.OutputFormat = resources.GetString("Mg_GrossProfit.OutputFormat");
            this.Mg_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_GrossProfit.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_GrossProfit.Text = "1,234,567,890";
            this.Mg_GrossProfit.Top = 0.031F;
            this.Mg_GrossProfit.Width = 0.75F;
            // 
            // Mg_Mark
            // 
            this.Mg_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Mg_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Mg_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Mg_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Mg_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Mg_Mark.DataField = "Mark";
            this.Mg_Mark.Height = 0.1565F;
            this.Mg_Mark.Left = 10.5F;
            this.Mg_Mark.MultiLine = false;
            this.Mg_Mark.Name = "Mg_Mark";
            this.Mg_Mark.OutputFormat = resources.GetString("Mg_Mark.OutputFormat");
            this.Mg_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Mg_Mark.SummaryGroup = "MediumGoodsGanreHeader";
            this.Mg_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Mg_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Mg_Mark.Text = "123";
            this.Mg_Mark.Top = 0.031F;
            this.Mg_Mark.Width = 0.25F;
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
            // DetailGoodsGanreHeader
            // 
            this.DetailGoodsGanreHeader.DataField = "Sort_BLGroupCode";
            this.DetailGoodsGanreHeader.Height = 0.01041667F;
            this.DetailGoodsGanreHeader.Name = "DetailGoodsGanreHeader";
            // 
            // DetailGoodsGanreFooter
            // 
            this.DetailGoodsGanreFooter.CanShrink = true;
            this.DetailGoodsGanreFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GROUPTOTALTITLE,
            this.BLGroupName,
            this.BLGroupCode,
            this.Blg_LMonthStockPrice,
            this.Blg_GrossProfitRate,
            this.Blg_StockTotal,
            this.Blg_StockPriceTaxExc,
            this.Blg_MoveArrivalPrice,
            this.Blg_StockMashinePrice,
            this.Blg_TotalArrivalPrice,
            this.Blg_SalesMoneyTaxExc,
            this.Blg_MoveShipmentPrice,
            this.Blg_TotalShipmentPrice,
            this.Blg_GrossProfit,
            this.Blg_Mark,
            this.line3});
            this.DetailGoodsGanreFooter.Height = 0.4375F;
            this.DetailGoodsGanreFooter.KeepTogether = true;
            this.DetailGoodsGanreFooter.Name = "DetailGoodsGanreFooter";
            this.DetailGoodsGanreFooter.Format += new System.EventHandler(this.DetailGoodsGanreFooter_Format);
            // 
            // GROUPTOTALTITLE
            // 
            this.GROUPTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.GROUPTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GROUPTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.GROUPTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GROUPTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.GROUPTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GROUPTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.GROUPTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GROUPTOTALTITLE.Height = 0.219F;
            this.GROUPTOTALTITLE.Left = 0.1875F;
            this.GROUPTOTALTITLE.MultiLine = false;
            this.GROUPTOTALTITLE.Name = "GROUPTOTALTITLE";
            this.GROUPTOTALTITLE.OutputFormat = resources.GetString("GROUPTOTALTITLE.OutputFormat");
            this.GROUPTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GROUPTOTALTITLE.Text = "グループ計";
            this.GROUPTOTALTITLE.Top = 0.03F;
            this.GROUPTOTALTITLE.Width = 0.8125F;
            // 
            // BLGroupName
            // 
            this.BLGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupName.DataField = "Sort_BLGroupName";
            this.BLGroupName.Height = 0.156F;
            this.BLGroupName.Left = 1.4375F;
            this.BLGroupName.MultiLine = false;
            this.BLGroupName.Name = "BLGroupName";
            this.BLGroupName.OutputFormat = resources.GetString("BLGroupName.OutputFormat");
            this.BLGroupName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.BLGroupName.Text = "あいうえおかきくけこ";
            this.BLGroupName.Top = 0.03F;
            this.BLGroupName.Width = 1.0625F;
            // 
            // BLGroupCode
            // 
            this.BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGroupCode.DataField = "Sort_BLGroupCode";
            this.BLGroupCode.Height = 0.156F;
            this.BLGroupCode.Left = 1.125F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7pt; font-family" +
                ": ＭＳ ゴシック; vertical-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0.03F;
            this.BLGroupCode.Width = 0.3125F;
            // 
            // Blg_LMonthStockPrice
            // 
            this.Blg_LMonthStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_LMonthStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_LMonthStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_LMonthStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_LMonthStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_LMonthStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_LMonthStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_LMonthStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_LMonthStockPrice.DataField = "LMonthStockPrice";
            this.Blg_LMonthStockPrice.Height = 0.156F;
            this.Blg_LMonthStockPrice.Left = 2.5F;
            this.Blg_LMonthStockPrice.MultiLine = false;
            this.Blg_LMonthStockPrice.Name = "Blg_LMonthStockPrice";
            this.Blg_LMonthStockPrice.OutputFormat = resources.GetString("Blg_LMonthStockPrice.OutputFormat");
            this.Blg_LMonthStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_LMonthStockPrice.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_LMonthStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_LMonthStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_LMonthStockPrice.Text = "1,234,567,890";
            this.Blg_LMonthStockPrice.Top = 0.03F;
            this.Blg_LMonthStockPrice.Width = 0.75F;
            // 
            // Blg_GrossProfitRate
            // 
            this.Blg_GrossProfitRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_GrossProfitRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfitRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_GrossProfitRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfitRate.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_GrossProfitRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfitRate.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_GrossProfitRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfitRate.DataField = "GrossProfitRate";
            this.Blg_GrossProfitRate.Height = 0.156F;
            this.Blg_GrossProfitRate.Left = 8.5F;
            this.Blg_GrossProfitRate.MultiLine = false;
            this.Blg_GrossProfitRate.Name = "Blg_GrossProfitRate";
            this.Blg_GrossProfitRate.OutputFormat = resources.GetString("Blg_GrossProfitRate.OutputFormat");
            this.Blg_GrossProfitRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_GrossProfitRate.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_GrossProfitRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_GrossProfitRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_GrossProfitRate.Text = "123.00";
            this.Blg_GrossProfitRate.Top = 0.03F;
            this.Blg_GrossProfitRate.Width = 0.5625F;
            // 
            // Blg_StockTotal
            // 
            this.Blg_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockTotal.DataField = "StockTotal";
            this.Blg_StockTotal.Height = 0.156F;
            this.Blg_StockTotal.Left = 9.0625F;
            this.Blg_StockTotal.MultiLine = false;
            this.Blg_StockTotal.Name = "Blg_StockTotal";
            this.Blg_StockTotal.OutputFormat = resources.GetString("Blg_StockTotal.OutputFormat");
            this.Blg_StockTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_StockTotal.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_StockTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_StockTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_StockTotal.Text = "1,234,567";
            this.Blg_StockTotal.Top = 0.03F;
            this.Blg_StockTotal.Width = 0.6875F;
            // 
            // Blg_StockPriceTaxExc
            // 
            this.Blg_StockPriceTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_StockPriceTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockPriceTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_StockPriceTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockPriceTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_StockPriceTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockPriceTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_StockPriceTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockPriceTaxExc.DataField = "StockPriceTaxExc";
            this.Blg_StockPriceTaxExc.Height = 0.156F;
            this.Blg_StockPriceTaxExc.Left = 3.25F;
            this.Blg_StockPriceTaxExc.MultiLine = false;
            this.Blg_StockPriceTaxExc.Name = "Blg_StockPriceTaxExc";
            this.Blg_StockPriceTaxExc.OutputFormat = resources.GetString("Blg_StockPriceTaxExc.OutputFormat");
            this.Blg_StockPriceTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_StockPriceTaxExc.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_StockPriceTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_StockPriceTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_StockPriceTaxExc.Text = "1,234,567,890";
            this.Blg_StockPriceTaxExc.Top = 0.03F;
            this.Blg_StockPriceTaxExc.Width = 0.75F;
            // 
            // Blg_MoveArrivalPrice
            // 
            this.Blg_MoveArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_MoveArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_MoveArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_MoveArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_MoveArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveArrivalPrice.DataField = "MoveArrivalPrice";
            this.Blg_MoveArrivalPrice.Height = 0.156F;
            this.Blg_MoveArrivalPrice.Left = 4F;
            this.Blg_MoveArrivalPrice.MultiLine = false;
            this.Blg_MoveArrivalPrice.Name = "Blg_MoveArrivalPrice";
            this.Blg_MoveArrivalPrice.OutputFormat = resources.GetString("Blg_MoveArrivalPrice.OutputFormat");
            this.Blg_MoveArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_MoveArrivalPrice.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_MoveArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_MoveArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_MoveArrivalPrice.Text = "1,234,567,890";
            this.Blg_MoveArrivalPrice.Top = 0.03F;
            this.Blg_MoveArrivalPrice.Width = 0.75F;
            // 
            // Blg_StockMashinePrice
            // 
            this.Blg_StockMashinePrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_StockMashinePrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockMashinePrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_StockMashinePrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockMashinePrice.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_StockMashinePrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockMashinePrice.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_StockMashinePrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_StockMashinePrice.DataField = "StockMashinePrice";
            this.Blg_StockMashinePrice.Height = 0.156F;
            this.Blg_StockMashinePrice.Left = 9.75F;
            this.Blg_StockMashinePrice.MultiLine = false;
            this.Blg_StockMashinePrice.Name = "Blg_StockMashinePrice";
            this.Blg_StockMashinePrice.OutputFormat = resources.GetString("Blg_StockMashinePrice.OutputFormat");
            this.Blg_StockMashinePrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_StockMashinePrice.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_StockMashinePrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_StockMashinePrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_StockMashinePrice.Text = "1,234,567,890";
            this.Blg_StockMashinePrice.Top = 0.03F;
            this.Blg_StockMashinePrice.Width = 0.75F;
            // 
            // Blg_TotalArrivalPrice
            // 
            this.Blg_TotalArrivalPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_TotalArrivalPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalArrivalPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_TotalArrivalPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalArrivalPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_TotalArrivalPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalArrivalPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_TotalArrivalPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalArrivalPrice.DataField = "TotalArrivalPrice";
            this.Blg_TotalArrivalPrice.Height = 0.156F;
            this.Blg_TotalArrivalPrice.Left = 4.75F;
            this.Blg_TotalArrivalPrice.MultiLine = false;
            this.Blg_TotalArrivalPrice.Name = "Blg_TotalArrivalPrice";
            this.Blg_TotalArrivalPrice.OutputFormat = resources.GetString("Blg_TotalArrivalPrice.OutputFormat");
            this.Blg_TotalArrivalPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_TotalArrivalPrice.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_TotalArrivalPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_TotalArrivalPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_TotalArrivalPrice.Text = "1,234,567,890";
            this.Blg_TotalArrivalPrice.Top = 0.03F;
            this.Blg_TotalArrivalPrice.Width = 0.75F;
            // 
            // Blg_SalesMoneyTaxExc
            // 
            this.Blg_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Blg_SalesMoneyTaxExc.Height = 0.156F;
            this.Blg_SalesMoneyTaxExc.Left = 5.5F;
            this.Blg_SalesMoneyTaxExc.MultiLine = false;
            this.Blg_SalesMoneyTaxExc.Name = "Blg_SalesMoneyTaxExc";
            this.Blg_SalesMoneyTaxExc.OutputFormat = resources.GetString("Blg_SalesMoneyTaxExc.OutputFormat");
            this.Blg_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_SalesMoneyTaxExc.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Blg_SalesMoneyTaxExc.Top = 0.03F;
            this.Blg_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Blg_MoveShipmentPrice
            // 
            this.Blg_MoveShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_MoveShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_MoveShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_MoveShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_MoveShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_MoveShipmentPrice.DataField = "MoveShipmentPrice";
            this.Blg_MoveShipmentPrice.Height = 0.156F;
            this.Blg_MoveShipmentPrice.Left = 6.25F;
            this.Blg_MoveShipmentPrice.MultiLine = false;
            this.Blg_MoveShipmentPrice.Name = "Blg_MoveShipmentPrice";
            this.Blg_MoveShipmentPrice.OutputFormat = resources.GetString("Blg_MoveShipmentPrice.OutputFormat");
            this.Blg_MoveShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_MoveShipmentPrice.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_MoveShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_MoveShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_MoveShipmentPrice.Text = "1,234,567,890";
            this.Blg_MoveShipmentPrice.Top = 0.03F;
            this.Blg_MoveShipmentPrice.Width = 0.75F;
            // 
            // Blg_TotalShipmentPrice
            // 
            this.Blg_TotalShipmentPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_TotalShipmentPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalShipmentPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_TotalShipmentPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalShipmentPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_TotalShipmentPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalShipmentPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_TotalShipmentPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_TotalShipmentPrice.DataField = "TotalShipmentPrice";
            this.Blg_TotalShipmentPrice.Height = 0.156F;
            this.Blg_TotalShipmentPrice.Left = 7F;
            this.Blg_TotalShipmentPrice.MultiLine = false;
            this.Blg_TotalShipmentPrice.Name = "Blg_TotalShipmentPrice";
            this.Blg_TotalShipmentPrice.OutputFormat = resources.GetString("Blg_TotalShipmentPrice.OutputFormat");
            this.Blg_TotalShipmentPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_TotalShipmentPrice.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_TotalShipmentPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_TotalShipmentPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_TotalShipmentPrice.Text = "1,234,567,890";
            this.Blg_TotalShipmentPrice.Top = 0.03F;
            this.Blg_TotalShipmentPrice.Width = 0.75F;
            // 
            // Blg_GrossProfit
            // 
            this.Blg_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_GrossProfit.DataField = "GrossProfit";
            this.Blg_GrossProfit.Height = 0.156F;
            this.Blg_GrossProfit.Left = 7.75F;
            this.Blg_GrossProfit.MultiLine = false;
            this.Blg_GrossProfit.Name = "Blg_GrossProfit";
            this.Blg_GrossProfit.OutputFormat = resources.GetString("Blg_GrossProfit.OutputFormat");
            this.Blg_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_GrossProfit.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_GrossProfit.Text = "1,234,567,890";
            this.Blg_GrossProfit.Top = 0.03F;
            this.Blg_GrossProfit.Width = 0.75F;
            // 
            // Blg_Mark
            // 
            this.Blg_Mark.Border.BottomColor = System.Drawing.Color.Black;
            this.Blg_Mark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_Mark.Border.LeftColor = System.Drawing.Color.Black;
            this.Blg_Mark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_Mark.Border.RightColor = System.Drawing.Color.Black;
            this.Blg_Mark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_Mark.Border.TopColor = System.Drawing.Color.Black;
            this.Blg_Mark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Blg_Mark.DataField = "Mark";
            this.Blg_Mark.Height = 0.156F;
            this.Blg_Mark.Left = 10.5F;
            this.Blg_Mark.MultiLine = false;
            this.Blg_Mark.Name = "Blg_Mark";
            this.Blg_Mark.OutputFormat = resources.GetString("Blg_Mark.OutputFormat");
            this.Blg_Mark.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Blg_Mark.SummaryGroup = "DetailGoodsGanreHeader";
            this.Blg_Mark.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Blg_Mark.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Blg_Mark.Text = "123";
            this.Blg_Mark.Top = 0.03F;
            this.Blg_Mark.Width = 0.25F;
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
            // PMZAI02012P_01A4C
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
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.GoodsMakerHeader);
            this.Sections.Add(this.LargeGoodsGanreHeader);
            this.Sections.Add(this.MediumGoodsGanreHeader);
            this.Sections.Add(this.DetailGoodsGanreHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.DetailGoodsGanreFooter);
            this.Sections.Add(this.MediumGoodsGanreFooter);
            this.Sections.Add(this.LargeGoodsGanreFooter);
            this.Sections.Add(this.GoodsMakerFooter);
            this.Sections.Add(this.SupplierFooter);
            this.Sections.Add(this.WarehouseFooter);
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
            this.PageStart += new System.EventHandler(this.PMZAI02012P_01A4C_PageStart);
            this.PageEnd += new System.EventHandler(this.DCZAI02163P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCZAI02163P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMonthStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TurnOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TurnOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LMonthStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WAREHOUSETITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GOODSMAKERTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gm_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_StockSupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SUPPLIERTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSupplierCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sup_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LGOODSGANRETITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lg_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MGOODSGANRETITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mg_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GROUPTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_LMonthStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_GrossProfitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_StockPriceTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_MoveArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_StockMashinePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_TotalArrivalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_MoveShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_TotalShipmentPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blg_Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        /// <summary>
         /// GrandTotalFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Ttl_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Ttl_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Ttl_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Ttl_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Ttl_GrossProfitRate.Value)
            //{
            //    Ttl_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Ttl_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Ttl_GrossProfitRate.Value)
            //{
            //    Ttl_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Ttl_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Ttl_GrossProfitRate.Value)
            //{
            //    Ttl_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Ttl_GrossProfitRate.Value)
            //{
            //    Ttl_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Ttl_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Ttl_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Ttl_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Ttl_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- DEL 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Ttl_SalesMoneyTaxExc.Value.ToString(), Ttl_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Ttl_GrossProfitRate.Value = grossMarginRate;
            Ttl_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        /// <summary>
        /// DetailGoodsGanreFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailGoodsGanreFooter_Format(object sender, EventArgs e)
        {
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Blg_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Blg_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Blg_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Blg_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Blg_GrossProfitRate.Value)
            //{
            //    Blg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Blg_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Blg_GrossProfitRate.Value)
            //{
            //    Blg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Blg_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Blg_GrossProfitRate.Value)
            //{
            //    Blg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Blg_GrossProfitRate.Value)
            //{
            //    Blg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            /* ---DEL 2009/03/27 不具合対応[12802] ---------------------------->>>>>
            // --- ADD 2008/10/10 ------------------------------>>>>>
            // ALL0は表示しない
            if (this.BLGroupCode.Text == "00000")
            {
                this.BLGroupCode.Text = string.Empty;       // グループコード
            }
            // --- ADD 2008/10/10 ------------------------------<<<<<
               ---DEL 2009/03/27 不具合対応[12802] ----------------------------<<<<< */

            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Blg_SalesMoneyTaxExc.Value.ToString(),out salesMoneyTaxExc);
            //long.TryParse(Blg_GrossProfit.Value.ToString(),out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Blg_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Blg_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- DEL 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Blg_SalesMoneyTaxExc.Value.ToString(), Blg_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Blg_GrossProfitRate.Value = grossMarginRate;
            Blg_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        /// <summary>
        /// MediumGoodsGanreFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediumGoodsGanreFooter_Format(object sender, EventArgs e)
        {
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Mg_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Mg_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Mg_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Mg_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Mg_GrossProfitRate.Value)
            //{
            //    Mg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Mg_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Mg_GrossProfitRate.Value)
            //{
            //    Mg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Mg_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Mg_GrossProfitRate.Value)
            //{
            //    Mg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Mg_GrossProfitRate.Value)
            //{
            //    Mg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            /* ---DEL 2009/03/27 不具合対応[12802] ---------------------------->>>>>
            // --- ADD 2008/10/10 ------------------------------>>>>>
            // ALL0は表示しない
            if (this.GoodsMGroupCode.Text == "0000")
            {
                this.GoodsMGroupCode.Text = string.Empty;   // 中分類コード
            }
            // --- ADD 2008/10/10 ------------------------------<<<<<
               ---DEL 2009/03/27 不具合対応[12802] ----------------------------<<<<< */

            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Mg_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Mg_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Mg_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Mg_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Mg_SalesMoneyTaxExc.Value.ToString(), Mg_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Mg_GrossProfitRate.Value = grossMarginRate;
            Mg_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        /// <summary>
        /// LargeGoodsGanreFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LargeGoodsGanreFooter_Format(object sender, EventArgs e)
        {
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Lg_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Lg_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Lg_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Lg_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Lg_GrossProfitRate.Value)
            //{
            //    Lg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Lg_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Lg_GrossProfitRate.Value)
            //{
            //    Lg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Lg_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Lg_GrossProfitRate.Value)
            //{
            //    Lg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Lg_GrossProfitRate.Value)
            //{
            //    Lg_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            /* ---DEL 2009/03/27 不具合対応[12802] ---------------------------->>>>>
            // --- ADD 2008/10/10 ------------------------------>>>>>
            // ALL0は表示しない
            if (this.GoodsLGroupCode.Text == "0000")
            {
                this.GoodsLGroupCode.Text = string.Empty;   // 大分類コード
            }
            // --- ADD 2008/10/10 ------------------------------<<<<<
               ---DEL 2009/03/27 不具合対応[12802] ----------------------------<<<<< */

            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Lg_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Lg_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Lg_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Lg_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Lg_SalesMoneyTaxExc.Value.ToString(), Lg_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Lg_GrossProfitRate.Value = grossMarginRate;
            Lg_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        /// <summary>
        /// SupplierFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierFooter_Format(object sender, EventArgs e)
        {

            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Sup_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Sup_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Sup_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Sup_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Sup_GrossProfitRate.Value)
            //{
            //    Sup_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Sup_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Sup_GrossProfitRate.Value)
            //{
            //    Sup_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Sup_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Sup_GrossProfitRate.Value)
            //{
            //    Sup_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Sup_GrossProfitRate.Value)
            //{
            //    Sup_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            /* ---DEL 2009/03/27 不具合対応[12802] --------------------------->>>>>
            // --- ADD 2008/10/10 ------------------------------>>>>>
            // ALL0は表示しない
            if (this.StockSupplierCode.Text == "000000")
            {
                this.StockSupplierCode.Text = string.Empty; // 仕入先コード
            }
            // --- ADD 2008/10/10 ------------------------------<<<<<
               ---DEL 2009/03/27 不具合対応[12802] ---------------------------<<<<< */

            // --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Sup_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Sup_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Sup_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Sup_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Sup_SalesMoneyTaxExc.Value.ToString(), Sup_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Sup_GrossProfitRate.Value = grossMarginRate;
            Sup_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        /// <summary>
        /// WarehouseFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseFooter_Format(object sender, EventArgs e)
        {
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Wh_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Wh_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Wh_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Wh_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Wh_GrossProfitRate.Value)
            //{
            //    Wh_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Wh_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Wh_GrossProfitRate.Value)
            //{
            //    Wh_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Wh_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Wh_GrossProfitRate.Value)
            //{
            //    Wh_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Wh_GrossProfitRate.Value)
            //{
            //    Wh_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            /* ---DEL 2009/03/27 不具合対応[12802] ------------------------------->>>>>
            // --- ADD 2008/10/10 ------------------------------>>>>>
            // ALL0は表示しない
            if (this.WarehouseCode.Text == "0000")
            {
                this.WarehouseCode.Text = string.Empty;     // 倉庫コード
            }
            // --- ADD 2008/10/10 ------------------------------<<<<<
               ---DEL 2009/03/27 不具合対応[12802] -------------------------------<<<<< */

            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Wh_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Wh_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Wh_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Wh_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- DEL 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Wh_SalesMoneyTaxExc.Value.ToString(), Wh_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Wh_GrossProfitRate.Value = grossMarginRate;
            Wh_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        /// <summary>
        /// GoodsMakerFooter_Format イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMakerFooter_Format(object sender, EventArgs e)
        {
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            //// 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Gm_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Gm_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Gm_GrossProfitRate.Value = 0.00;
            //}
            //else
            //{
            //    Gm_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            //// --- ADD 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<

            //if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > (double)Gm_GrossProfitRate.Value)
            //{
            //    Gm_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckLower <= (double)Gm_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckBest >= (double)Gm_GrossProfitRate.Value)
            //{
            //    Gm_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest < (double)Gm_GrossProfitRate.Value && this._stockMonthYearReportCndtn.GrsProfitCheckUpper >= (double)Gm_GrossProfitRate.Value)
            //{
            //    Gm_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            //}
            //else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper < (double)Gm_GrossProfitRate.Value)
            //{
            //    Gm_Mark.Text = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            //}
            // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

            /* ---DEL 2009/03/27 不具合対応[12802] ----------------------------->>>>>
            // --- ADD 2008/10/10 ------------------------------>>>>>
            // ALL0は表示しない
            if (this.GoodsMakerCode.Text == "0000")
            {
                this.GoodsMakerCode.Text = string.Empty;    // メーカーコード
            }
            // --- ADD 2008/10/10 ------------------------------<<<<<
               ---DEL 2009/03/27 不具合対応[12802] -----------------------------<<<<< */

            // --- DEL 2015/10/02 Redmine#47391不具合対応 --------------------------------------->>>>>
            // ---ADD 2009/03/24 不具合対応[12679] --------------------------------------->>>>>
            // 粗利率は計算で求める
            //long salesMoneyTaxExc = 0;
            //long grossProfit = 0;

            //long.TryParse(Gm_SalesMoneyTaxExc.Value.ToString(), out salesMoneyTaxExc);
            //long.TryParse(Gm_GrossProfit.Value.ToString(), out grossProfit);
            //if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            //{
            //    Gm_GrossProfitRate.Value = 0;
            //}
            //else
            //{
            //    Gm_GrossProfitRate.Value = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            //}
            // ---ADD 2009/03/24 不具合対応[12679] ---------------------------------------<<<<<
            // --- DEL 2015/10/02 Redmine#47391不具合対応 ---------------------------------------<<<<<
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
            // 粗利率より、粗利マークを設定する。
            double grossMarginRate = 0.00;
            string grossMarginMark = string.Empty;
            SetGrossMargin(Gm_SalesMoneyTaxExc.Value.ToString(), Gm_GrossProfit.Value.ToString(), out grossMarginRate, out grossMarginMark);
            Gm_GrossProfitRate.Value = grossMarginRate;
            Gm_Mark.Text = grossMarginMark;
            // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
        }

        // --- ADD 2009/02/26 -------------------------------->>>>>
        //// --- ADD 2008/10/10 ------------------------------------------>>>>>
        ///// <summary>
        ///// 倉庫ヘッダーFormatイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void WarehouseHeader_Format(object sender, EventArgs e)
        //{
        //    // 仕入先が"000000"のものは印字しない
        //    if (this.Wh_StockSupplierCode.Text == "000000")
        //    {
        //        this.Wh_StockSupplierCode.Text = string.Empty;
        //    }
        //}
        //// --- ADD 2008/10/10 ------------------------------------------<<<<<
        // --- ADD 2009/02/26 --------------------------------<<<<<

        // --- ADD 2009/02/26 -------------------------------->>>>>
        /// <summary>
        /// SupplierHeader_Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupplierHeader_Format(object sender, EventArgs e)
        {
            /* ---DEL 2009/03/27 不具合対応[12802] -------------------------->>>>>
            // 仕入先が"000000"のものは印字しない
            if (this.Wh_StockSupplierCode.Text == "000000")
            {
                this.Wh_StockSupplierCode.Text = string.Empty;
            }
               ---DEL 2009/03/27 不具合対応[12802] --------------------------<<<<< */
        }
        // --- ADD 2009/02/26 -------------------------------->>>>>

        // ---ADD 2009/05/28 不具合対応[13401] --------------------------------->>>>>
        /// <summary>
        /// 新しいページを処理する前に発生します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI02012P_01A4C_PageStart(object sender, EventArgs e)
        {
            if (this._extraCondHeadOutDiv == 0)
            {
                // 毎ページ出力
                this.ExtraHeader.Visible = true;
            }
            else
            {
                // 先頭ページのみ出力
                if (this._extraHeaderVisible)
                {
                    this.ExtraHeader.Visible = true;
                    this._extraHeaderVisible = false;
                }
                else
                {
                    this.ExtraHeader.Visible = false;
                }
            }
        }
        // ---ADD 2009/05/28 不具合対応[13401] ---------------------------------<<<<<
        // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
        /// <summary>
        /// 粗利率と粗利マークの設定処理
        /// </summary>
        /// <param name="money">金額</param>
        /// <param name="profit">粗利</param>
        /// <param name="grossMarginRate">粗利率</param>
        /// <param name="grossMarginMark">粗利チェックマーク</param>
        /// <remarks>
        /// <br>Note		: 金額と粗利から粗利率及び粗利マークを設定します。</br>
        /// <br>Programmer	: 李侠</br>
        /// <br>Date		: 2015/10/08</br>
        /// </remarks>
        private void SetGrossMargin(string money, string profit, out double grossMarginRate, out string grossMarginMark)
        {
            grossMarginRate = 0.00;
            grossMarginMark = string.Empty;

            // 金額と粗利から粗利率を算出する。
            long salesMoneyTaxExc = 0;
            long grossProfit = 0;
            long.TryParse(money, out salesMoneyTaxExc);
            long.TryParse(profit, out grossProfit);
            if ((salesMoneyTaxExc == 0) || (grossProfit == 0))
            {
                grossMarginRate = 0.00;
            }
            else
            {
                grossMarginRate = Math.Round(((double)grossProfit / salesMoneyTaxExc) * 100, 2);
            }

            // 粗利率より、マークの設定を判定する。
            if (this._stockMonthYearReportCndtn.GrsProfitCheckLower > grossMarginRate)
            {
                grossMarginMark = this._stockMonthYearReportCndtn.GrsProfitChkLowSign;
            }
            else if (this._stockMonthYearReportCndtn.GrsProfitCheckBest > grossMarginRate)
            {
                grossMarginMark = this._stockMonthYearReportCndtn.GrsProfitChkBestSign;
            }
            else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper > grossMarginRate)
            {
                grossMarginMark = this._stockMonthYearReportCndtn.GrsProfitChkUprSign;
            }
            else if (this._stockMonthYearReportCndtn.GrsProfitCheckUpper <= grossMarginRate)
            {
                grossMarginMark = this._stockMonthYearReportCndtn.GrsProfitChkMaxSign;
            }
        }
        // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
    }
}
