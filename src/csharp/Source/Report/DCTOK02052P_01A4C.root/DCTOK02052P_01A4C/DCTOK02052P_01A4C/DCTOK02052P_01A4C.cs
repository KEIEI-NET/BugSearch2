//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：出荷商品分析表
// プログラム概要   ：出荷商品分析表を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2008/10/20     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2009/02/10     修正内容：障害対応11327
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30452 上野 俊治
// 修正日    2009/03/24     修正内容：障害対応12687
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/10     修正内容：Mantis【13128】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2009/09/15     修正内容：Mantis【14237】拠点名の上の罫線がない（デザイン修正のみ）
// ---------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 出荷商品分析表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 出荷商品分析表のフォームクラスです。</br>
	/// <br>Programmer   : 20081 疋田 勇人</br>
	/// <br>Date         : 2007.12.03</br>
    /// <br>Update Note  : 2008.10.20 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
    /// <br>Update Note  : 2009.02.10 30452 上野 俊治</br>
    /// <br>              ・障害対応11327</br>
    /// <br>Update Note  : 2009/03/24 30452 上野 俊治</br>
    /// <br>              ・障害対応12687</br>
	/// </remarks>
	public class DCTOK02052P_01A4C : ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 出荷商品分析表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : 出荷商品分析表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer   : 20081　疋田 勇人</br>
		/// <br>Date         : 2007.12.03</br>
		/// </remarks>
		public DCTOK02052P_01A4C()
		{
			InitializeComponent();
            
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									  // 印刷件数用カウンタ

		private int					_extraCondHeadOutDiv;			  // 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				  // 抽出条件
		private int					_pageFooterOutCode;				  // フッター出力区分
		private StringCollection	_pageFooters;					  // フッターメッセージ
		private	SFCMN06002C			_printInfo;						  // 印刷情報クラス
		private string				_pageHeaderTitle;				  // フォームタイトル
		private string				_pageHeaderSortOderTitle;		  // ソート順
        //private string              _sectionCode      = string.Empty; // 拠点コードのバッファ
        //private string              _goodsMakerCd     = string.Empty ;// 商品コードのバッファ

        private ExtrInfo_ShipGoodsAnalyze _extrInfo_ShipGoodsAnalyze; // 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;
        private TextBox GrossMoneyRate;
        private Label label4;
        private TextBox StockCount;
        private TextBox OrderCount;
        private TextBox Ttl_GrossMoneyRate;
        private TextBox Sec_GrossMoneyRate;
        private TextBox tb_SortOrderName;
        private TextBox Ttl_StockCount;
        private TextBox Ttl_OrderCount;
        private TextBox Sec_StockCount;
        private TextBox Sec_OrderCount;
        private GroupHeader MakerNameHeader;
        private GroupFooter MakerNameFooter;
        private GroupHeader SuplierHeader;
        private GroupFooter SuplierFooter;
        private TextBox MakHd_SectionCode;
        private TextBox MakHd_SectionGuideNm;
        private Label MakHd_SectionTitle;
        private TextBox MakHd_SupplierCd;
        private TextBox MakHd_SupplierSnm;
        private Label MakHd_SuplierTitle;
        private TextBox MakHd_GoodsMakerCd;
        private TextBox MakHd_MakerName;
        private Label MakHd_GoodsMakerTitle;
        private Line Line_DetailHead;
        private Label label1;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox MakFt_GrossMoney;
        private TextBox MakFt_PureSalesMoney;
        private TextBox MakFt_TotalCount;
        private TextBox MakFt_GrossMoneyRate;
        private TextBox MakFt_StockCount;
        private TextBox MakFt_OrderCount;
        private TextBox SupFt_TotalCount;
        private TextBox SupFt_PureSalesMoney;
        private TextBox SupFt_GrossMoney;
        private TextBox SupFt_GrossMoneyRate;
        private TextBox SupFt_StockCount;
        private TextBox SupFt_OrderCount;
        private Line line4;
        private Line line3;
        private TextBox MakFt_GrossMoneyOrg;
        private TextBox MakFt_PureSalesMoneyOrg;
        private TextBox TtlFt_GrossMoneyOrg;
        private TextBox TtlFt_PureSalesMoneyOrg;
        private TextBox SecFt_GrossMoneyOrg;
        private TextBox SecFt_PureSalesMoneyOrg;
        private TextBox SupFt_GrossMoneyOrg;
        private TextBox SupFt_PureSalesMoneyOrg;
        private Line upline_MakerNameHeader;

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
                this._extrInfo_ShipGoodsAnalyze = (ExtrInfo_ShipGoodsAnalyze)this._printInfo.jyoken;
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル
            tb_SortOrderName.Text = this._pageHeaderSortOderTitle;      // ソート条件

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            // 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._extrInfo_ShipGoodsAnalyze.IsOptSection ) {
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._extrInfo_ShipGoodsAnalyze.SecCodeList.Length < 2 ) ||
            //        this._extrInfo_ShipGoodsAnalyze.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCTOK02054EA.ct_Col_Sort_SectionCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else {
            //    // 拠点無
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}

            //SectionHeader.DataField = DCTOK02054EA.ct_Col_Sort_SectionCode;
            //SectionHeader.Visible = true;
            //SectionFooter.Visible = true;

            // --- DEL 2008/10/20 -------------------------------->>>>>
            //// 拠点計を出力するかしないかを選択する
            ////switch (this._extrInfo_ShipGoodsAnalyze.SubttlPrintDiv) // DEL 2008/10/20
            //switch (this._extrInfo_ShipGoodsAnalyze.SectionSumPrintDiv) // ADD 2008/10/20
            //{
            //    // する
            //    case ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do:
            //        {
            //            //SectionHeader.DataField = DCTOK02054EA.ct_Col_Sort_SectionCode; // DEL 2008/10/20
            //            SectionHeader.DataField = DCTOK02054EA.ct_Col_SectionCode; // ADD 2008/10/20
            //            SectionHeader.Visible = true;
            //            SectionFooter.Visible = true;
            //            break;
            //        }
            //    case ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.None:
            //        {
            //            SectionHeader.DataField = "";
            //            SectionHeader.Visible = false;
            //            SectionFooter.Visible = false;
            //            break;
            //        }
            //    default:
            //        break;
            //}

            //// 営業所毎の改ページ有無を設定
            //switch (this._extrInfo_ShipGoodsAnalyze.NewPageDiv) {
            //    // 営業所毎改ページする
            //    case ExtrInfo_ShipGoodsAnalyze.NewPageDivState.BySection:
            //        {
            //            //SectionHeader.DataField = DCTOK02054EA.ct_Col_Sort_SectionCode; // DEL 2008/10/20
            //            SectionHeader.DataField = DCTOK02054EA.ct_Col_SectionCode; // ADD 2008/10/20
            //            //SectionHeader.Visible = true;
            //            SectionHeader.NewPage = NewPage.Before;
            //            break;
            //        }
            //    // 改ページしない
            //    case ExtrInfo_ShipGoodsAnalyze.NewPageDivState.None:
            //        {
            //            //SectionHeader.DataField = DCTOK02054EA.ct_Col_Sort_SectionCode; // DEL 2008/10/20
            //            SectionHeader.DataField = DCTOK02054EA.ct_Col_SectionCode; // ADD 2008/10/20
            //            SectionHeader.NewPage = NewPage.None;
            //            break;
            //        }
            //    default :
            //        break;
            //}
            // --- DEL 2008/10/20 --------------------------------<<<<<
            // --- ADD 2008/12/11 -------------------------------->>>>>
            // 明細ヘッダ項目の制御
            if (this._extrInfo_ShipGoodsAnalyze.TtlType == ExtrInfo_ShipGoodsAnalyze.TtlTypeState.All)
            {
                // 集計方法「全社」の場合、拠点を非表示にする
                this.MakHd_SectionTitle.Visible = false;
                this.MakHd_SectionCode.Visible = false;
                this.MakHd_SectionGuideNm.Visible = false;

                // 拠点分左詰
                PointF point = new PointF();

                this.MakHd_SuplierTitle.Location = this.MakHd_SectionTitle.Location;
                point = this.MakHd_SuplierTitle.Location;

                point.X += this.MakHd_SuplierTitle.Width;

                this.MakHd_SupplierCd.Location = point;
                point.X += this.MakHd_SupplierCd.Width;

                this.MakHd_SupplierSnm.Location = point;
                point.X += this.MakHd_SupplierSnm.Width + 0.1F;

                this.MakHd_GoodsMakerTitle.Location = point;
                point.X += this.MakHd_GoodsMakerTitle.Width;

                this.MakHd_GoodsMakerCd.Location = point;
                point.X += this.MakHd_GoodsMakerCd.Width;

                this.MakHd_MakerName.Location = point;
            }
            // --- ADD 2008/12/11 --------------------------------<<<<<
            // --- ADD 2008/10/20 -------------------------------->>>>>
            // 出荷数項目の制御
            if (this._extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Total)
            {
                this.TotalCount.DataField = DCTOK02054EA.ct_Col_TotalCount;
                this.MakFt_TotalCount.DataField = DCTOK02054EA.ct_Col_TotalCount;
                this.SupFt_TotalCount.DataField = DCTOK02054EA.ct_Col_TotalCount;
                this.Sec_TotalCount.DataField = DCTOK02054EA.ct_Col_TotalCount;
                this.Ttl_TotalCount.DataField = DCTOK02054EA.ct_Col_TotalCount;
            }
            else if (this._extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Stock)
            {
                this.TotalCount.DataField = DCTOK02054EA.ct_Col_StockCount;
                this.MakFt_TotalCount.DataField = DCTOK02054EA.ct_Col_StockCount;
                this.SupFt_TotalCount.DataField = DCTOK02054EA.ct_Col_StockCount;
                this.Sec_TotalCount.DataField = DCTOK02054EA.ct_Col_StockCount;
                this.Ttl_TotalCount.DataField = DCTOK02054EA.ct_Col_StockCount;
            }
            else if (this._extrInfo_ShipGoodsAnalyze.RsltTtlDiv == ExtrInfo_ShipGoodsAnalyze.RsltTtlDivState.Acquire)
            {
                this.TotalCount.DataField = DCTOK02054EA.ct_Col_OrderCount;
                this.MakFt_TotalCount.DataField = DCTOK02054EA.ct_Col_OrderCount;
                this.SupFt_TotalCount.DataField = DCTOK02054EA.ct_Col_OrderCount;
                this.Sec_TotalCount.DataField = DCTOK02054EA.ct_Col_OrderCount;
                this.Ttl_TotalCount.DataField = DCTOK02054EA.ct_Col_OrderCount;
            }

            // 小計印刷制御
            if (this._extrInfo_ShipGoodsAnalyze.SectionSumPrintDiv == ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do)
            {
                SectionFooter.Visible = true;
            }
            else
            {
                SectionFooter.Visible = false;
            }

            if (this._extrInfo_ShipGoodsAnalyze.SuplierSumPrintDiv == ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do)
            {
                SuplierFooter.Visible = true;
            }
            else
            {
                SuplierFooter.Visible = false;
            }

            if (this._extrInfo_ShipGoodsAnalyze.MakerSumPrintDiv == ExtrInfo_ShipGoodsAnalyze.SubttlPrintDivState.Do)
            {
                MakerNameFooter.Visible = true;
            }
            else
            {
                MakerNameFooter.Visible = false;
            }

            // 改頁制御
            if (this._extrInfo_ShipGoodsAnalyze.NewPageDiv == ExtrInfo_ShipGoodsAnalyze.NewPageDivState.BySection)
            {
                SectionHeader.NewPage = NewPage.Before;
            }
            else if (this._extrInfo_ShipGoodsAnalyze.NewPageDiv == ExtrInfo_ShipGoodsAnalyze.NewPageDivState.BySupplier)
            {
                SuplierHeader.NewPage = NewPage.Before;
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<

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
        /// <summary>
        /// 月タイトル取得
        /// </summary>
        /// <param name="stYearMonth"></param>
        /// <param name="index"></param>
        /// <returns>月タイトル(ex.１月,２月…)</returns>
        private string GetMonthTitle(DateTime stYearMonth, int index) 
        {
            int month = stYearMonth.Month + index;
            
            if (month > 12) month -= 12;

            return (month.ToString() + "月");
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

            //if ((_sectionCode == SectionCode.Text) && (_goodsMakerCd == GoodsMakerCd.Text))
            //{
            //    SectionCode.Visible = false;
            //    SectionGuideNm.Visible = false;

            //    GoodsMakerCd.Visible = false;
            //    MakerName.Visible = false;

                //// 拠点コードとメーカーコードのVisbile=falseなら、以下の項目のポジションを変更する
                //GoodsShortName.Location   = new System.Drawing.PointF((float)0.125, (float)0.0);
                //GoodsNo.Location          = new System.Drawing.PointF((float)1.365, (float)0.0);
                //StockCreateDate.Location  = new System.Drawing.PointF((float)3.156, (float)0.0);
                //SupplierStock.Location    = new System.Drawing.PointF((float)3.948, (float)0.0);
                //MinimumStockCnt.Location  = new System.Drawing.PointF((float)4.427, (float)0.0);
                //MaximumStockCnt.Location  = new System.Drawing.PointF((float)4.917, (float)0.0);
                //RankTotalCount.Location   = new System.Drawing.PointF((float)5.469, (float)0.0);
                //TotalCount.Location       = new System.Drawing.PointF((float)5.938, (float)0.0);
                //StockCount.Location       = new System.Drawing.PointF((float)6.438, (float)0.0);
                //OrderCount.Location       = new System.Drawing.PointF((float)6.917, (float)0.0);
                //RankSalesMoney.Location   = new System.Drawing.PointF((float)7.5,   (float)0.0);
                //SalesMoney.Location       = new System.Drawing.PointF((float)7.979, (float)0.0);
                //RankGrossMoney.Location   = new System.Drawing.PointF((float)8.813, (float)0.0);
                //GrossMoney.Location       = new System.Drawing.PointF((float)9.292, (float)0.0);
                //GrossMarginRate.Location  = new System.Drawing.PointF((float)10.031,(float)0.0);

            //}
            //else
            //{
            //    SectionCode.Visible = true;
            //    SectionGuideNm.Visible = true;

            //    GoodsMakerCd.Visible = true;
            //    MakerName.Visible = true;

            //    this._sectionCode = SectionCode.Text;
            //    this._goodsMakerCd = GoodsMakerCd.Text;

                //GoodsShortName.Location   = new System.Drawing.PointF((float)0.125, (float)0.104);
                //GoodsNo.Location          = new System.Drawing.PointF((float)1.365, (float)0.104);
                //StockCreateDate.Location  = new System.Drawing.PointF((float)3.156, (float)0.104);
                //SupplierStock.Location    = new System.Drawing.PointF((float)3.948, (float)0.104);
                //MinimumStockCnt.Location  = new System.Drawing.PointF((float)4.427, (float)0.104);
                //MaximumStockCnt.Location  = new System.Drawing.PointF((float)4.917, (float)0.104);
                //RankTotalCount.Location   = new System.Drawing.PointF((float)5.469, (float)0.104);
                //TotalCount.Location       = new System.Drawing.PointF((float)5.938, (float)0.104);
                //StockCount.Location       = new System.Drawing.PointF((float)6.438, (float)0.104);
                //OrderCount.Location       = new System.Drawing.PointF((float)6.917, (float)0.104);
                //RankSalesMoney.Location   = new System.Drawing.PointF((float)7.5,   (float)0.104);
                //SalesMoney.Location       = new System.Drawing.PointF((float)7.979, (float)0.104);
                //RankGrossMoney.Location   = new System.Drawing.PointF((float)8.813, (float)0.104);
                //GrossMoney.Location       = new System.Drawing.PointF((float)9.292, (float)0.104);
                //GrossMarginRate.Location  = new System.Drawing.PointF((float)10.031,(float)0.104);
            //}
        

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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）
            
            //this._sectionCode  = string.Empty;
            //this._goodsMakerCd = string.Empty;
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString( ExtrInfo_ShipGoodsAnalyze.ct_DateFomat, DateTime.Now );
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
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

            
   			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion

        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary>
        /// MakerNameHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerNameHeader_BeforePrint(object sender, EventArgs e)
        {
            if (this.MakHd_SectionCode.Text == null 
                || this.MakHd_SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.MakHd_SectionCode.Text = "";
                this.MakHd_SectionGuideNm.Text = "";
            }

            if (this.MakHd_SupplierCd.Text == null
                || this.MakHd_SupplierCd.Text.PadLeft(6, '0') == "000000")
            {
                this.MakHd_SupplierCd.Text = "";
                this.MakHd_SupplierSnm.Text = "";
            }

            if (this.MakHd_GoodsMakerCd.Text == null
                || this.MakHd_GoodsMakerCd.Text.PadLeft(4, '0') == "0000")
            {
                this.MakHd_GoodsMakerCd.Text = "";
                this.MakHd_MakerName.Text = "";
            }

        }
        // --- ADD 2008/10/20 --------------------------------<<<<<

		#region ◎ Detail_Format Event
		/// <summary>
		/// Detail_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: Detailグループのフォーマットイベント。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // 拠点コードとメーカーコードのVisbile=falseなら、Detailの高さを調節する
            //if ((_sectionCode == SectionCode.Text) && (_goodsMakerCd == GoodsMakerCd.Text))
            //{
            //    this.Detail.Height = (float)0.160;
            //}
            //else
            //{
            //    this.Detail.Height = (float)0.229;
            //}
            
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
            // ADD 2009/04/10 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { PureSalesMoney, GrossMoney });
            PriceUnitCalc(dList);
            // ADD 2009/04/10 ------<<<

            // ↓ 08/04/03 Keigo Yata Add ///////////////////////////////////////////////
			// グループサプレスの判断
			this.CheckGroupSuppression();

            
            // 在庫登録日が最小値なら、在庫登録日、現在数、最低数、最高数を非表示
            //if (StockCreateDate.Text == "01/01/01") // DEL 2008/10/20
            if (Convert.ToDateTime(StockCreateDate.Text) == DateTime.MinValue) // ADD 2008/10/20
            {
                StockCreateDate.Visible = false;     // 在庫登録日
                ShipmentPosCnt.Visible   = false;     // 現在数
                MinimumStockCnt.Visible = false;     // 最低数
                MaximumStockCnt.Visible = false;     // 最高数
            }
            else
            {
                StockCreateDate.Visible = true;     // 在庫登録日
                ShipmentPosCnt.Visible   = true;     // 現在数
                MinimumStockCnt.Visible = true;     // 最低数
                MaximumStockCnt.Visible = true;     // 最高数
            }


            // ↑ 08/04/03 Keigo Yata Add ///////////////////////////////////////////////

            // --- ADD 2008/10/20 -------------------------------->>>>>
            if (this.RankTotalCount.Text == "0" || this.RankTotalCount.Text == "100000000")
            {
                this.RankTotalCount.Text = "";
            }
            if (this.RankGrossMoney.Text == "0" || this.RankSalesMoney.Text == "100000000")
            {
                this.RankSalesMoney.Text = "";
            }
            if (this.RankGrossMoney.Text == "0" || this.RankGrossMoney.Text == "100000000")
            {
                this.RankGrossMoney.Text = "";
            }
            // --- ADD 2008/10/20 --------------------------------<<<<<

            // --- ADD 2008/10/20 -------------------------------->>>>>
            this.GrossMoneyRate.Text = this.GrossMoneyRate.Text + "%";
            // --- ADD 2008/10/20 --------------------------------<<<<<

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
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			this._printCount++;
			
			if (this.ProgressBarUpEvent != null)
			{
                this.ProgressBarUpEvent(this, this._printCount); // ADD 2009/02/10
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
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
		/// <br>Programmer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.12.03</br>
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

        // --- ADD 2008/10/20 -------------------------------->>>>>
        #region ◎ GrandTotalFooter_BeforePrint Event
        /// <summary>
        /// GrandTotalFooter BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/10 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { Ttl_PureSalesMoney, Ttl_GrossMoney });
            PriceUnitCalc(dList);
            // ADD 2009/04/10 ------<<<

            Decimal grossMoneyRate;

            // 粗利率
            if ((Convert.ToInt64(this.TtlFt_PureSalesMoneyOrg.Value) == 0) || (Convert.ToInt64(this.TtlFt_GrossMoneyOrg.Value) == 0))
            {
                grossMoneyRate = 0;
            }
            else
            {
                grossMoneyRate = Convert.ToDecimal(this.TtlFt_GrossMoneyOrg.Value) / Convert.ToDecimal(this.TtlFt_PureSalesMoneyOrg.Value) * 100;
            }

            // --- DEL 2009/03/24 -------------------------------->>>>>
            //if (grossMoneyRate < 0)
            //{
            //    grossMoneyRate = grossMoneyRate * -1;
            //}
            // --- DEL 2009/03/24 --------------------------------<<<<<

            this.Ttl_GrossMoneyRate.Value = (double)grossMoneyRate;
            this.Ttl_GrossMoneyRate.Text = Ttl_GrossMoneyRate.Text + "%";
        }
        #endregion

        #region ◎ SectionFooter_BeforePrint Event
        /// <summary>
        /// SectionFooter BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/10 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { Sec_PureSalesMoney, Sec_GrossMoney });
            PriceUnitCalc(dList);
            // ADD 2009/04/10 ------<<<

            Decimal grossMoneyRate;

            // 粗利率
            if ((Convert.ToInt64(this.SecFt_PureSalesMoneyOrg.Value) == 0) || (Convert.ToInt64(this.SecFt_GrossMoneyOrg.Value) == 0))
            {
                grossMoneyRate = 0;
            }
            else
            {
                grossMoneyRate = Convert.ToDecimal(this.SecFt_GrossMoneyOrg.Value) / Convert.ToDecimal(this.SecFt_PureSalesMoneyOrg.Value) * 100;
            }

            // --- DEL 2009/03/24 -------------------------------->>>>>
            //if (grossMoneyRate < 0)
            //{
            //    grossMoneyRate = grossMoneyRate * -1;
            //}
            // --- DEL 2009/03/24 --------------------------------<<<<<

            this.Sec_GrossMoneyRate.Value = (double)grossMoneyRate;
            this.Sec_GrossMoneyRate.Text = Sec_GrossMoneyRate.Text + "%";
        }
        #endregion

        #region ◎ SuplierFooter_BeforePrint Event
        /// <summary>
        /// SuplierFooter BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuplierFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/10 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { SupFt_PureSalesMoney, SupFt_GrossMoney });
            PriceUnitCalc(dList);
            // ADD 2009/04/10 ------<<<

            Decimal grossMoneyRate;

            // 粗利率
            if ((Convert.ToInt64(this.SupFt_PureSalesMoneyOrg.Value) == 0) || (Convert.ToInt64(this.SupFt_GrossMoneyOrg.Value) == 0))
            {
                grossMoneyRate = 0;
            }
            else
            {
                grossMoneyRate = Convert.ToDecimal(this.SupFt_GrossMoneyOrg.Value) / Convert.ToDecimal(this.SupFt_PureSalesMoneyOrg.Value) * 100;
            }

            // --- DEL 2009/03/24 -------------------------------->>>>>
            //if (grossMoneyRate < 0)
            //{
            //    grossMoneyRate = grossMoneyRate * -1;
            //}
            // --- DEL 2009/03/24 --------------------------------<<<<<

            this.SupFt_GrossMoneyRate.Value = (double)grossMoneyRate;
            this.SupFt_GrossMoneyRate.Text = SupFt_GrossMoneyRate.Text + "%";
        }
        #endregion

        #region ◎ MakerNameFooter_BeforePrint Event
        /// <summary>
        /// MakerNameFooter BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerNameFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/10 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { MakFt_PureSalesMoney, MakFt_GrossMoney });
            PriceUnitCalc(dList);
            // ADD 2009/04/10 ------<<<

            Decimal grossMoneyRate;

            // 粗利率
            if ((Convert.ToInt64(this.MakFt_PureSalesMoneyOrg.Value) == 0) || (Convert.ToInt64(this.MakFt_GrossMoneyOrg.Value) == 0))
            {
                grossMoneyRate = 0;
            }
            else
            {
                grossMoneyRate = Convert.ToDecimal(this.MakFt_GrossMoneyOrg.Value) / Convert.ToDecimal(this.MakFt_PureSalesMoneyOrg.Value) * 100;
            }

            // --- DEL 2009/03/24 -------------------------------->>>>>
            //if (grossMoneyRate < 0)
            //{
            //    grossMoneyRate = grossMoneyRate * -1;
            //}
            // --- DEL 2009/03/24 --------------------------------<<<<<

            this.MakFt_GrossMoneyRate.Value = (double)grossMoneyRate;
            this.MakFt_GrossMoneyRate.Text = MakFt_GrossMoneyRate.Text + "%";
        }
        #endregion
        // --- ADD 2008/10/20 -------------------------------->>>>>

		#endregion ■ Control Event

        // ADD 2009/04/10 ------>>>
        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._extrInfo_ShipGoodsAnalyze.MoneyUnit == ExtrInfo_ShipGoodsAnalyze.MoneyUnitState.Thousand)
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
        // ADD 2009/04/10 ------<<<

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
        private DataDynamics.ActiveReports.Label Lb_GoodsName;
		private DataDynamics.ActiveReports.Label Lb_StockCreateDate;
		private DataDynamics.ActiveReports.Label Lb_SalesMoneyTaxExcOrder;
        private DataDynamics.ActiveReports.Label Lb_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.Label Lb_GoodsNo;
		private DataDynamics.ActiveReports.Label Lb_GrossProfitOrder;
		private DataDynamics.ActiveReports.Label Lb_GrossProfit;
		private DataDynamics.ActiveReports.Label Lb_ShipmentCntOrder;
		private DataDynamics.ActiveReports.Label Lb_ShipmentCnt;
		private DataDynamics.ActiveReports.Label Lb_ShipmentPosCnt;
		private DataDynamics.ActiveReports.Label Lb_MinimumStockCnt;
		private DataDynamics.ActiveReports.Label Lb_MaximumStockCnt;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox GoodsNo;
        private DataDynamics.ActiveReports.TextBox GoodsShortName;
		private DataDynamics.ActiveReports.TextBox StockCreateDate;
		private DataDynamics.ActiveReports.TextBox MaximumStockCnt;
		private DataDynamics.ActiveReports.TextBox MinimumStockCnt;
		private DataDynamics.ActiveReports.TextBox ShipmentPosCnt;
		private DataDynamics.ActiveReports.TextBox TotalCount;
		private DataDynamics.ActiveReports.TextBox RankGrossMoney;
		private DataDynamics.ActiveReports.TextBox GrossMoney;
		private DataDynamics.ActiveReports.TextBox RankSalesMoney;
		private DataDynamics.ActiveReports.TextBox RankTotalCount;
        private DataDynamics.ActiveReports.TextBox PureSalesMoney;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.TextBox TextBox;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.TextBox Sec_TotalCount;
		private DataDynamics.ActiveReports.TextBox Sec_PureSalesMoney;
		private DataDynamics.ActiveReports.TextBox Sec_GrossMoney;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Ttl_TotalCount;
		private DataDynamics.ActiveReports.TextBox Ttl_PureSalesMoney;
		private DataDynamics.ActiveReports.TextBox Ttl_GrossMoney;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCTOK02052P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsShortName = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.TotalCount = new DataDynamics.ActiveReports.TextBox();
            this.RankGrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.RankSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.RankTotalCount = new DataDynamics.ActiveReports.TextBox();
            this.PureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.GrossMoneyRate = new DataDynamics.ActiveReports.TextBox();
            this.StockCount = new DataDynamics.ActiveReports.TextBox();
            this.OrderCount = new DataDynamics.ActiveReports.TextBox();
            this.Line_DetailHead = new DataDynamics.ActiveReports.Line();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_StockCreateDate = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoneyTaxExcOrder = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoneyTaxExc = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GrossProfitOrder = new DataDynamics.ActiveReports.Label();
            this.Lb_GrossProfit = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCntOrder = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MinimumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MaximumStockCnt = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_TotalCount = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_PureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_GrossMoneyRate = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_StockCount = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_OrderCount = new DataDynamics.ActiveReports.TextBox();
            this.TtlFt_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.TtlFt_PureSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Sec_TotalCount = new DataDynamics.ActiveReports.TextBox();
            this.Sec_PureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Sec_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.Sec_GrossMoneyRate = new DataDynamics.ActiveReports.TextBox();
            this.Sec_StockCount = new DataDynamics.ActiveReports.TextBox();
            this.Sec_OrderCount = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.SecFt_PureSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.MakerNameHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakHd_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.MakHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.MakHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.MakHd_SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.MakHd_SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.MakHd_SuplierTitle = new DataDynamics.ActiveReports.Label();
            this.MakHd_GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakHd_MakerName = new DataDynamics.ActiveReports.TextBox();
            this.MakHd_GoodsMakerTitle = new DataDynamics.ActiveReports.Label();
            this.MakerNameFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_PureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_TotalCount = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_GrossMoneyRate = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_StockCount = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_OrderCount = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.MakFt_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.MakFt_PureSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.SuplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SuplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_TotalCount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_PureSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_GrossMoney = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_GrossMoneyRate = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_StockCount = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_OrderCount = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SupFt_GrossMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.SupFt_PureSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.upline_MakerNameHeader = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankGrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankTotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoneyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_PureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossMoneyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_OrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlFt_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlFt_PureSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_TotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_PureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_GrossMoneyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_OrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SuplierTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_GoodsMakerTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_PureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossMoneyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_OrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_PureSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossMoneyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanGrow = false;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsShortName,
            this.StockCreateDate,
            this.MaximumStockCnt,
            this.MinimumStockCnt,
            this.ShipmentPosCnt,
            this.TotalCount,
            this.RankGrossMoney,
            this.GrossMoney,
            this.RankSalesMoney,
            this.RankTotalCount,
            this.PureSalesMoney,
            this.GrossMoneyRate,
            this.StockCount,
            this.OrderCount,
            this.Line_DetailHead,
            this.GoodsNo});
            this.Detail.Height = 0.1979167F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // GoodsShortName
            // 
            this.GoodsShortName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsShortName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsShortName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsShortName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsShortName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsShortName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsShortName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsShortName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsShortName.DataField = "GoodsShortName";
            this.GoodsShortName.Height = 0.156F;
            this.GoodsShortName.Left = 0.12F;
            this.GoodsShortName.MultiLine = false;
            this.GoodsShortName.Name = "GoodsShortName";
            this.GoodsShortName.OutputFormat = resources.GetString("GoodsShortName.OutputFormat");
            this.GoodsShortName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsShortName.Text = "12345678901234567890";
            this.GoodsShortName.Top = 0.01F;
            this.GoodsShortName.Width = 1.15F;
            // 
            // StockCreateDate
            // 
            this.StockCreateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.RightColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.Border.TopColor = System.Drawing.Color.Black;
            this.StockCreateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockCreateDate.DataField = "StockCreateDate";
            this.StockCreateDate.Height = 0.156F;
            this.StockCreateDate.Left = 2.6875F;
            this.StockCreateDate.MultiLine = false;
            this.StockCreateDate.Name = "StockCreateDate";
            this.StockCreateDate.OutputFormat = resources.GetString("StockCreateDate.OutputFormat");
            this.StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.StockCreateDate.Text = "9999/99/99";
            this.StockCreateDate.Top = 0.01F;
            this.StockCreateDate.Width = 0.6F;
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
            this.MaximumStockCnt.Left = 4.6875F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MaximumStockCnt.Text = "123,456,789";
            this.MaximumStockCnt.Top = 0.01F;
            this.MaximumStockCnt.Width = 0.65F;
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
            this.MinimumStockCnt.Left = 4F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MinimumStockCnt.Text = "123,456,789";
            this.MinimumStockCnt.Top = 0.01F;
            this.MinimumStockCnt.Width = 0.65F;
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
            this.ShipmentPosCnt.Left = 3.3125F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentPosCnt.Text = "123,456,789";
            this.ShipmentPosCnt.Top = 0.01F;
            this.ShipmentPosCnt.Width = 0.65F;
            // 
            // TotalCount
            // 
            this.TotalCount.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCount.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCount.Border.RightColor = System.Drawing.Color.Black;
            this.TotalCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCount.Border.TopColor = System.Drawing.Color.Black;
            this.TotalCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCount.DataField = "TotalCount";
            this.TotalCount.Height = 0.156F;
            this.TotalCount.Left = 5.875F;
            this.TotalCount.MultiLine = false;
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.OutputFormat = resources.GetString("TotalCount.OutputFormat");
            this.TotalCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TotalCount.Text = "123,456,789";
            this.TotalCount.Top = 0.01F;
            this.TotalCount.Width = 0.65F;
            // 
            // RankGrossMoney
            // 
            this.RankGrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.RankGrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankGrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.RankGrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankGrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.RankGrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankGrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.RankGrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankGrossMoney.DataField = "RankGrossMoney";
            this.RankGrossMoney.Height = 0.156F;
            this.RankGrossMoney.Left = 9.125F;
            this.RankGrossMoney.MultiLine = false;
            this.RankGrossMoney.Name = "RankGrossMoney";
            this.RankGrossMoney.OutputFormat = resources.GetString("RankGrossMoney.OutputFormat");
            this.RankGrossMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.RankGrossMoney.Text = "12345678";
            this.RankGrossMoney.Top = 0.01F;
            this.RankGrossMoney.Width = 0.48F;
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
            this.GrossMoney.DataField = "PrintGrossMoney";
            this.GrossMoney.Height = 0.156F;
            this.GrossMoney.Left = 9.625F;
            this.GrossMoney.MultiLine = false;
            this.GrossMoney.Name = "GrossMoney";
            this.GrossMoney.OutputFormat = resources.GetString("GrossMoney.OutputFormat");
            this.GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossMoney.Text = "123,456,789";
            this.GrossMoney.Top = 0.01F;
            this.GrossMoney.Width = 0.65F;
            // 
            // RankSalesMoney
            // 
            this.RankSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.RankSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.RankSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.RankSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.RankSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankSalesMoney.DataField = "RankSalesMoney";
            this.RankSalesMoney.Height = 0.156F;
            this.RankSalesMoney.Left = 7.9375F;
            this.RankSalesMoney.MultiLine = false;
            this.RankSalesMoney.Name = "RankSalesMoney";
            this.RankSalesMoney.OutputFormat = resources.GetString("RankSalesMoney.OutputFormat");
            this.RankSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.RankSalesMoney.Text = "12345678";
            this.RankSalesMoney.Top = 0.01F;
            this.RankSalesMoney.Width = 0.48F;
            // 
            // RankTotalCount
            // 
            this.RankTotalCount.Border.BottomColor = System.Drawing.Color.Black;
            this.RankTotalCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankTotalCount.Border.LeftColor = System.Drawing.Color.Black;
            this.RankTotalCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankTotalCount.Border.RightColor = System.Drawing.Color.Black;
            this.RankTotalCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankTotalCount.Border.TopColor = System.Drawing.Color.Black;
            this.RankTotalCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RankTotalCount.DataField = "RankTotalCount";
            this.RankTotalCount.Height = 0.156F;
            this.RankTotalCount.Left = 5.375F;
            this.RankTotalCount.MultiLine = false;
            this.RankTotalCount.Name = "RankTotalCount";
            this.RankTotalCount.OutputFormat = resources.GetString("RankTotalCount.OutputFormat");
            this.RankTotalCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.RankTotalCount.Text = "12345678";
            this.RankTotalCount.Top = 0.01F;
            this.RankTotalCount.Width = 0.48F;
            // 
            // PureSalesMoney
            // 
            this.PureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.PureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.PureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.PureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.PureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureSalesMoney.DataField = "PureSalesMoney";
            this.PureSalesMoney.Height = 0.156F;
            this.PureSalesMoney.Left = 8.4375F;
            this.PureSalesMoney.MultiLine = false;
            this.PureSalesMoney.Name = "PureSalesMoney";
            this.PureSalesMoney.OutputFormat = resources.GetString("PureSalesMoney.OutputFormat");
            this.PureSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PureSalesMoney.Text = "123,456,789";
            this.PureSalesMoney.Top = 0.01F;
            this.PureSalesMoney.Width = 0.65F;
            // 
            // GrossMoneyRate
            // 
            this.GrossMoneyRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMoneyRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMoneyRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMoneyRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMoneyRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMoneyRate.DataField = "GrossMoneyRate";
            this.GrossMoneyRate.Height = 0.156F;
            this.GrossMoneyRate.Left = 10.3125F;
            this.GrossMoneyRate.MultiLine = false;
            this.GrossMoneyRate.Name = "GrossMoneyRate";
            this.GrossMoneyRate.OutputFormat = resources.GetString("GrossMoneyRate.OutputFormat");
            this.GrossMoneyRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossMoneyRate.Text = "100.00%";
            this.GrossMoneyRate.Top = 0.01F;
            this.GrossMoneyRate.Width = 0.42F;
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
            this.StockCount.Left = 6.5625F;
            this.StockCount.MultiLine = false;
            this.StockCount.Name = "StockCount";
            this.StockCount.OutputFormat = resources.GetString("StockCount.OutputFormat");
            this.StockCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockCount.Text = "123,456,789";
            this.StockCount.Top = 0.01F;
            this.StockCount.Width = 0.65F;
            // 
            // OrderCount
            // 
            this.OrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.OrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.OrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderCount.DataField = "OrderCount";
            this.OrderCount.Height = 0.156F;
            this.OrderCount.Left = 7.25F;
            this.OrderCount.MultiLine = false;
            this.OrderCount.Name = "OrderCount";
            this.OrderCount.OutputFormat = resources.GetString("OrderCount.OutputFormat");
            this.OrderCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OrderCount.Text = "123,456,789";
            this.OrderCount.Top = 0.01F;
            this.OrderCount.Width = 0.65F;
            // 
            // Line_DetailHead
            // 
            this.Line_DetailHead.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.RightColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Border.TopColor = System.Drawing.Color.Black;
            this.Line_DetailHead.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_DetailHead.Height = 0F;
            this.Line_DetailHead.Left = 0F;
            this.Line_DetailHead.LineWeight = 2F;
            this.Line_DetailHead.Name = "Line_DetailHead";
            this.Line_DetailHead.Top = 0F;
            this.Line_DetailHead.Width = 10.8F;
            this.Line_DetailHead.X1 = 0F;
            this.Line_DetailHead.X2 = 10.8F;
            this.Line_DetailHead.Y1 = 0F;
            this.Line_DetailHead.Y2 = 0F;
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
            this.GoodsNo.Left = 1.28F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.01F;
            this.GoodsNo.Width = 1.4F;
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
            this.tb_SortOrderName});
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "出荷商品分析表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.625F;
            // 
            // tb_SortOrderName
            // 
            this.tb_SortOrderName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.CanShrink = true;
            this.tb_SortOrderName.Height = 0.15625F;
            this.tb_SortOrderName.Left = 3.0625F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.04166667F;
            this.tb_SortOrderName.Width = 2.0625F;
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
            this.ExtraHeader.Height = 0.5416667F;
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
            this.Lb_GoodsName,
            this.Lb_StockCreateDate,
            this.Lb_SalesMoneyTaxExcOrder,
            this.Lb_SalesMoneyTaxExc,
            this.Lb_GoodsNo,
            this.Lb_GrossProfitOrder,
            this.Lb_GrossProfit,
            this.Lb_ShipmentCntOrder,
            this.Lb_ShipmentCnt,
            this.Lb_ShipmentPosCnt,
            this.Lb_MinimumStockCnt,
            this.Lb_MaximumStockCnt,
            this.label4,
            this.label1,
            this.label5});
            this.TitleHeader.Height = 0.21875F;
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
            this.Line42.Width = 10.8125F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8125F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
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
            this.Lb_GoodsName.Left = 0.12F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.031F;
            this.Lb_GoodsName.Width = 1.15F;
            // 
            // Lb_StockCreateDate
            // 
            this.Lb_StockCreateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockCreateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockCreateDate.Height = 0.15625F;
            this.Lb_StockCreateDate.HyperLink = "";
            this.Lb_StockCreateDate.Left = 2.6875F;
            this.Lb_StockCreateDate.MultiLine = false;
            this.Lb_StockCreateDate.Name = "Lb_StockCreateDate";
            this.Lb_StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockCreateDate.Text = "在庫登録日";
            this.Lb_StockCreateDate.Top = 0.031F;
            this.Lb_StockCreateDate.Width = 0.625F;
            // 
            // Lb_SalesMoneyTaxExcOrder
            // 
            this.Lb_SalesMoneyTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesMoneyTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoneyTaxExcOrder.Height = 0.156F;
            this.Lb_SalesMoneyTaxExcOrder.HyperLink = "";
            this.Lb_SalesMoneyTaxExcOrder.Left = 5.375F;
            this.Lb_SalesMoneyTaxExcOrder.MultiLine = false;
            this.Lb_SalesMoneyTaxExcOrder.Name = "Lb_SalesMoneyTaxExcOrder";
            this.Lb_SalesMoneyTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesMoneyTaxExcOrder.Text = "出荷順位";
            this.Lb_SalesMoneyTaxExcOrder.Top = 0.031F;
            this.Lb_SalesMoneyTaxExcOrder.Width = 0.48F;
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
            this.Lb_SalesMoneyTaxExc.Height = 0.156F;
            this.Lb_SalesMoneyTaxExc.HyperLink = "";
            this.Lb_SalesMoneyTaxExc.Left = 8.4375F;
            this.Lb_SalesMoneyTaxExc.MultiLine = false;
            this.Lb_SalesMoneyTaxExc.Name = "Lb_SalesMoneyTaxExc";
            this.Lb_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesMoneyTaxExc.Text = "売上";
            this.Lb_SalesMoneyTaxExc.Top = 0.031F;
            this.Lb_SalesMoneyTaxExc.Width = 0.65F;
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
            this.Lb_GoodsNo.Left = 1.28F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.031F;
            this.Lb_GoodsNo.Width = 1.4F;
            // 
            // Lb_GrossProfitOrder
            // 
            this.Lb_GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GrossProfitOrder.Height = 0.156F;
            this.Lb_GrossProfitOrder.HyperLink = "";
            this.Lb_GrossProfitOrder.Left = 7.9375F;
            this.Lb_GrossProfitOrder.MultiLine = false;
            this.Lb_GrossProfitOrder.Name = "Lb_GrossProfitOrder";
            this.Lb_GrossProfitOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrossProfitOrder.Text = "売上順位";
            this.Lb_GrossProfitOrder.Top = 0.031F;
            this.Lb_GrossProfitOrder.Width = 0.48F;
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
            this.Lb_GrossProfit.Height = 0.156F;
            this.Lb_GrossProfit.HyperLink = "";
            this.Lb_GrossProfit.Left = 9.625F;
            this.Lb_GrossProfit.MultiLine = false;
            this.Lb_GrossProfit.Name = "Lb_GrossProfit";
            this.Lb_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrossProfit.Text = "粗利";
            this.Lb_GrossProfit.Top = 0.031F;
            this.Lb_GrossProfit.Width = 0.65F;
            // 
            // Lb_ShipmentCntOrder
            // 
            this.Lb_ShipmentCntOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCntOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCntOrder.Height = 0.156F;
            this.Lb_ShipmentCntOrder.HyperLink = "";
            this.Lb_ShipmentCntOrder.Left = 9.125F;
            this.Lb_ShipmentCntOrder.MultiLine = false;
            this.Lb_ShipmentCntOrder.Name = "Lb_ShipmentCntOrder";
            this.Lb_ShipmentCntOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCntOrder.Text = "粗利順位";
            this.Lb_ShipmentCntOrder.Top = 0.031F;
            this.Lb_ShipmentCntOrder.Width = 0.48F;
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
            this.Lb_ShipmentCnt.Height = 0.156F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 5.875F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCnt.Text = "出荷数";
            this.Lb_ShipmentCnt.Top = 0.031F;
            this.Lb_ShipmentCnt.Width = 0.65F;
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
            this.Lb_ShipmentPosCnt.Left = 3.3125F;
            this.Lb_ShipmentPosCnt.MultiLine = false;
            this.Lb_ShipmentPosCnt.Name = "Lb_ShipmentPosCnt";
            this.Lb_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentPosCnt.Text = "現在数";
            this.Lb_ShipmentPosCnt.Top = 0.031F;
            this.Lb_ShipmentPosCnt.Width = 0.65F;
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
            this.Lb_MinimumStockCnt.Height = 0.156F;
            this.Lb_MinimumStockCnt.HyperLink = "";
            this.Lb_MinimumStockCnt.Left = 4F;
            this.Lb_MinimumStockCnt.MultiLine = false;
            this.Lb_MinimumStockCnt.Name = "Lb_MinimumStockCnt";
            this.Lb_MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MinimumStockCnt.Text = "最低数";
            this.Lb_MinimumStockCnt.Top = 0.031F;
            this.Lb_MinimumStockCnt.Width = 0.65F;
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
            this.Lb_MaximumStockCnt.Height = 0.156F;
            this.Lb_MaximumStockCnt.HyperLink = "";
            this.Lb_MaximumStockCnt.Left = 4.6875F;
            this.Lb_MaximumStockCnt.MultiLine = false;
            this.Lb_MaximumStockCnt.Name = "Lb_MaximumStockCnt";
            this.Lb_MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MaximumStockCnt.Text = "最高数";
            this.Lb_MaximumStockCnt.Top = 0.031F;
            this.Lb_MaximumStockCnt.Width = 0.65F;
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
            this.label4.Left = 10.3125F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "粗利率";
            this.label4.Top = 0.031F;
            this.label4.Width = 0.42F;
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
            this.label1.Left = 6.5625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "在庫";
            this.label1.Top = 0.031F;
            this.label1.Width = 0.65F;
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
            this.label5.Left = 7.25F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "取寄";
            this.label5.Top = 0.031F;
            this.label5.Width = 0.65F;
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
            this.GrandTotalHeader.KeepTogether = true;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ALLTOTALTITLE,
            this.Line43,
            this.Ttl_TotalCount,
            this.Ttl_PureSalesMoney,
            this.Ttl_GrossMoney,
            this.Ttl_GrossMoneyRate,
            this.Ttl_StockCount,
            this.Ttl_OrderCount,
            this.TtlFt_GrossMoneyOrg,
            this.TtlFt_PureSalesMoneyOrg});
            this.GrandTotalFooter.Height = 0.2916667F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.ALLTOTALTITLE.Left = 4.427083F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03125F;
            this.ALLTOTALTITLE.Width = 0.5625F;
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
            // Ttl_TotalCount
            // 
            this.Ttl_TotalCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_TotalCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_TotalCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalCount.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_TotalCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalCount.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_TotalCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_TotalCount.DataField = "TotalCount";
            this.Ttl_TotalCount.Height = 0.156F;
            this.Ttl_TotalCount.Left = 5.875F;
            this.Ttl_TotalCount.MultiLine = false;
            this.Ttl_TotalCount.Name = "Ttl_TotalCount";
            this.Ttl_TotalCount.OutputFormat = resources.GetString("Ttl_TotalCount.OutputFormat");
            this.Ttl_TotalCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_TotalCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_TotalCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_TotalCount.Text = "123,456,789";
            this.Ttl_TotalCount.Top = 0.03125F;
            this.Ttl_TotalCount.Width = 0.65F;
            // 
            // Ttl_PureSalesMoney
            // 
            this.Ttl_PureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_PureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_PureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_PureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_PureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_PureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_PureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_PureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_PureSalesMoney.DataField = "PureSalesMoney";
            this.Ttl_PureSalesMoney.Height = 0.156F;
            this.Ttl_PureSalesMoney.Left = 8.0875F;
            this.Ttl_PureSalesMoney.MultiLine = false;
            this.Ttl_PureSalesMoney.Name = "Ttl_PureSalesMoney";
            this.Ttl_PureSalesMoney.OutputFormat = resources.GetString("Ttl_PureSalesMoney.OutputFormat");
            this.Ttl_PureSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_PureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_PureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_PureSalesMoney.Text = "123,456,789,012";
            this.Ttl_PureSalesMoney.Top = 0.03125F;
            this.Ttl_PureSalesMoney.Width = 1F;
            // 
            // Ttl_GrossMoney
            // 
            this.Ttl_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoney.DataField = "PrintGrossMoney";
            this.Ttl_GrossMoney.Height = 0.156F;
            this.Ttl_GrossMoney.Left = 9.275F;
            this.Ttl_GrossMoney.MultiLine = false;
            this.Ttl_GrossMoney.Name = "Ttl_GrossMoney";
            this.Ttl_GrossMoney.OutputFormat = resources.GetString("Ttl_GrossMoney.OutputFormat");
            this.Ttl_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_GrossMoney.Text = "123,456,789,012";
            this.Ttl_GrossMoney.Top = 0.03125F;
            this.Ttl_GrossMoney.Width = 1F;
            // 
            // Ttl_GrossMoneyRate
            // 
            this.Ttl_GrossMoneyRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoneyRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoneyRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoneyRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoneyRate.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoneyRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoneyRate.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_GrossMoneyRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_GrossMoneyRate.Height = 0.156F;
            this.Ttl_GrossMoneyRate.Left = 10.3125F;
            this.Ttl_GrossMoneyRate.MultiLine = false;
            this.Ttl_GrossMoneyRate.Name = "Ttl_GrossMoneyRate";
            this.Ttl_GrossMoneyRate.OutputFormat = resources.GetString("Ttl_GrossMoneyRate.OutputFormat");
            this.Ttl_GrossMoneyRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossMoneyRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_GrossMoneyRate.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_GrossMoneyRate.Text = "123,456,789";
            this.Ttl_GrossMoneyRate.Top = 0.03125F;
            this.Ttl_GrossMoneyRate.Width = 0.42F;
            // 
            // Ttl_StockCount
            // 
            this.Ttl_StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_StockCount.DataField = "StockCount";
            this.Ttl_StockCount.Height = 0.156F;
            this.Ttl_StockCount.Left = 6.5625F;
            this.Ttl_StockCount.MultiLine = false;
            this.Ttl_StockCount.Name = "Ttl_StockCount";
            this.Ttl_StockCount.OutputFormat = resources.GetString("Ttl_StockCount.OutputFormat");
            this.Ttl_StockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_StockCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_StockCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_StockCount.Text = "123,456,789";
            this.Ttl_StockCount.Top = 0.03125F;
            this.Ttl_StockCount.Width = 0.65F;
            // 
            // Ttl_OrderCount
            // 
            this.Ttl_OrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_OrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_OrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_OrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_OrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_OrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_OrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_OrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_OrderCount.DataField = "OrderCount";
            this.Ttl_OrderCount.Height = 0.156F;
            this.Ttl_OrderCount.Left = 7.25F;
            this.Ttl_OrderCount.MultiLine = false;
            this.Ttl_OrderCount.Name = "Ttl_OrderCount";
            this.Ttl_OrderCount.OutputFormat = resources.GetString("Ttl_OrderCount.OutputFormat");
            this.Ttl_OrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_OrderCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_OrderCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_OrderCount.Text = "123,456,789";
            this.Ttl_OrderCount.Top = 0.03125F;
            this.Ttl_OrderCount.Width = 0.65F;
            // 
            // TtlFt_GrossMoneyOrg
            // 
            this.TtlFt_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.TtlFt_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.TtlFt_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.TtlFt_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.TtlFt_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.TtlFt_GrossMoneyOrg.Height = 0.156F;
            this.TtlFt_GrossMoneyOrg.Left = 1F;
            this.TtlFt_GrossMoneyOrg.MultiLine = false;
            this.TtlFt_GrossMoneyOrg.Name = "TtlFt_GrossMoneyOrg";
            this.TtlFt_GrossMoneyOrg.OutputFormat = resources.GetString("TtlFt_GrossMoneyOrg.OutputFormat");
            this.TtlFt_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.TtlFt_GrossMoneyOrg.SummaryGroup = "GrandTotalHeader";
            this.TtlFt_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TtlFt_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TtlFt_GrossMoneyOrg.Text = "123,456,789,012";
            this.TtlFt_GrossMoneyOrg.Top = 0.03125F;
            this.TtlFt_GrossMoneyOrg.Visible = false;
            this.TtlFt_GrossMoneyOrg.Width = 1F;
            // 
            // TtlFt_PureSalesMoneyOrg
            // 
            this.TtlFt_PureSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.TtlFt_PureSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_PureSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.TtlFt_PureSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_PureSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.TtlFt_PureSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_PureSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.TtlFt_PureSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TtlFt_PureSalesMoneyOrg.DataField = "PureSalesMoneyOrg";
            this.TtlFt_PureSalesMoneyOrg.Height = 0.156F;
            this.TtlFt_PureSalesMoneyOrg.Left = 0F;
            this.TtlFt_PureSalesMoneyOrg.MultiLine = false;
            this.TtlFt_PureSalesMoneyOrg.Name = "TtlFt_PureSalesMoneyOrg";
            this.TtlFt_PureSalesMoneyOrg.OutputFormat = resources.GetString("TtlFt_PureSalesMoneyOrg.OutputFormat");
            this.TtlFt_PureSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.TtlFt_PureSalesMoneyOrg.SummaryGroup = "GrandTotalHeader";
            this.TtlFt_PureSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TtlFt_PureSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TtlFt_PureSalesMoneyOrg.Text = "123,456,789,012";
            this.TtlFt_PureSalesMoneyOrg.Top = 0.03125F;
            this.TtlFt_PureSalesMoneyOrg.Visible = false;
            this.TtlFt_PureSalesMoneyOrg.Width = 1F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox,
            this.Line2,
            this.Sec_TotalCount,
            this.Sec_PureSalesMoney,
            this.Sec_GrossMoney,
            this.Sec_GrossMoneyRate,
            this.Sec_StockCount,
            this.Sec_OrderCount,
            this.SecFt_GrossMoneyOrg,
            this.SecFt_PureSalesMoneyOrg});
            this.SectionFooter.Height = 0.28125F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
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
            this.TextBox.Height = 0.219F;
            this.TextBox.Left = 4.427083F;
            this.TextBox.MultiLine = false;
            this.TextBox.Name = "TextBox";
            this.TextBox.OutputFormat = resources.GetString("TextBox.OutputFormat");
            this.TextBox.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.TextBox.Text = "拠点計";
            this.TextBox.Top = 0.031F;
            this.TextBox.Width = 0.5625F;
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
            // Sec_TotalCount
            // 
            this.Sec_TotalCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_TotalCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_TotalCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_TotalCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_TotalCount.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_TotalCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_TotalCount.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_TotalCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_TotalCount.DataField = "TotalCount";
            this.Sec_TotalCount.Height = 0.156F;
            this.Sec_TotalCount.Left = 5.875F;
            this.Sec_TotalCount.MultiLine = false;
            this.Sec_TotalCount.Name = "Sec_TotalCount";
            this.Sec_TotalCount.OutputFormat = resources.GetString("Sec_TotalCount.OutputFormat");
            this.Sec_TotalCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_TotalCount.SummaryGroup = "SectionHeader";
            this.Sec_TotalCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_TotalCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_TotalCount.Text = "123,456,789";
            this.Sec_TotalCount.Top = 0.031F;
            this.Sec_TotalCount.Width = 0.65F;
            // 
            // Sec_PureSalesMoney
            // 
            this.Sec_PureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_PureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_PureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_PureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_PureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_PureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_PureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_PureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_PureSalesMoney.DataField = "PureSalesMoney";
            this.Sec_PureSalesMoney.Height = 0.156F;
            this.Sec_PureSalesMoney.Left = 8.0875F;
            this.Sec_PureSalesMoney.MultiLine = false;
            this.Sec_PureSalesMoney.Name = "Sec_PureSalesMoney";
            this.Sec_PureSalesMoney.OutputFormat = resources.GetString("Sec_PureSalesMoney.OutputFormat");
            this.Sec_PureSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_PureSalesMoney.SummaryGroup = "SectionHeader";
            this.Sec_PureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_PureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_PureSalesMoney.Text = "123,456,789,012";
            this.Sec_PureSalesMoney.Top = 0.031F;
            this.Sec_PureSalesMoney.Width = 1F;
            // 
            // Sec_GrossMoney
            // 
            this.Sec_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoney.DataField = "PrintGrossMoney";
            this.Sec_GrossMoney.Height = 0.156F;
            this.Sec_GrossMoney.Left = 9.275F;
            this.Sec_GrossMoney.MultiLine = false;
            this.Sec_GrossMoney.Name = "Sec_GrossMoney";
            this.Sec_GrossMoney.OutputFormat = resources.GetString("Sec_GrossMoney.OutputFormat");
            this.Sec_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_GrossMoney.SummaryGroup = "SectionHeader";
            this.Sec_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_GrossMoney.Text = "123,456,789,012";
            this.Sec_GrossMoney.Top = 0.031F;
            this.Sec_GrossMoney.Width = 1F;
            // 
            // Sec_GrossMoneyRate
            // 
            this.Sec_GrossMoneyRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_GrossMoneyRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoneyRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_GrossMoneyRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoneyRate.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_GrossMoneyRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoneyRate.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_GrossMoneyRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_GrossMoneyRate.Height = 0.156F;
            this.Sec_GrossMoneyRate.Left = 10.3125F;
            this.Sec_GrossMoneyRate.MultiLine = false;
            this.Sec_GrossMoneyRate.Name = "Sec_GrossMoneyRate";
            this.Sec_GrossMoneyRate.OutputFormat = resources.GetString("Sec_GrossMoneyRate.OutputFormat");
            this.Sec_GrossMoneyRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_GrossMoneyRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_GrossMoneyRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_GrossMoneyRate.Text = "123,456,789";
            this.Sec_GrossMoneyRate.Top = 0.031F;
            this.Sec_GrossMoneyRate.Width = 0.42F;
            // 
            // Sec_StockCount
            // 
            this.Sec_StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_StockCount.DataField = "StockCount";
            this.Sec_StockCount.Height = 0.156F;
            this.Sec_StockCount.Left = 6.5625F;
            this.Sec_StockCount.MultiLine = false;
            this.Sec_StockCount.Name = "Sec_StockCount";
            this.Sec_StockCount.OutputFormat = resources.GetString("Sec_StockCount.OutputFormat");
            this.Sec_StockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_StockCount.SummaryGroup = "SectionHeader";
            this.Sec_StockCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_StockCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_StockCount.Text = "123,456,789";
            this.Sec_StockCount.Top = 0.031F;
            this.Sec_StockCount.Width = 0.65F;
            // 
            // Sec_OrderCount
            // 
            this.Sec_OrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Sec_OrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_OrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Sec_OrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_OrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.Sec_OrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_OrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.Sec_OrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sec_OrderCount.DataField = "OrderCount";
            this.Sec_OrderCount.Height = 0.156F;
            this.Sec_OrderCount.Left = 7.25F;
            this.Sec_OrderCount.MultiLine = false;
            this.Sec_OrderCount.Name = "Sec_OrderCount";
            this.Sec_OrderCount.OutputFormat = resources.GetString("Sec_OrderCount.OutputFormat");
            this.Sec_OrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Sec_OrderCount.SummaryGroup = "SectionHeader";
            this.Sec_OrderCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sec_OrderCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sec_OrderCount.Text = "123,456,789";
            this.Sec_OrderCount.Top = 0.031F;
            this.Sec_OrderCount.Width = 0.65F;
            // 
            // SecFt_GrossMoneyOrg
            // 
            this.SecFt_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.SecFt_GrossMoneyOrg.Height = 0.156F;
            this.SecFt_GrossMoneyOrg.Left = 1F;
            this.SecFt_GrossMoneyOrg.MultiLine = false;
            this.SecFt_GrossMoneyOrg.Name = "SecFt_GrossMoneyOrg";
            this.SecFt_GrossMoneyOrg.OutputFormat = resources.GetString("SecFt_GrossMoneyOrg.OutputFormat");
            this.SecFt_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_GrossMoneyOrg.SummaryGroup = "SectionHeader";
            this.SecFt_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_GrossMoneyOrg.Text = "123,456,789,012";
            this.SecFt_GrossMoneyOrg.Top = 0.031F;
            this.SecFt_GrossMoneyOrg.Visible = false;
            this.SecFt_GrossMoneyOrg.Width = 1F;
            // 
            // SecFt_PureSalesMoneyOrg
            // 
            this.SecFt_PureSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SecFt_PureSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SecFt_PureSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SecFt_PureSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SecFt_PureSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecFt_PureSalesMoneyOrg.DataField = "PureSalesMoneyOrg";
            this.SecFt_PureSalesMoneyOrg.Height = 0.156F;
            this.SecFt_PureSalesMoneyOrg.Left = 0F;
            this.SecFt_PureSalesMoneyOrg.MultiLine = false;
            this.SecFt_PureSalesMoneyOrg.Name = "SecFt_PureSalesMoneyOrg";
            this.SecFt_PureSalesMoneyOrg.OutputFormat = resources.GetString("SecFt_PureSalesMoneyOrg.OutputFormat");
            this.SecFt_PureSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SecFt_PureSalesMoneyOrg.SummaryGroup = "SectionHeader";
            this.SecFt_PureSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SecFt_PureSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SecFt_PureSalesMoneyOrg.Text = "123,456,789,012";
            this.SecFt_PureSalesMoneyOrg.Top = 0.031F;
            this.SecFt_PureSalesMoneyOrg.Visible = false;
            this.SecFt_PureSalesMoneyOrg.Width = 1F;
            // 
            // MakerNameHeader
            // 
            this.MakerNameHeader.CanShrink = true;
            this.MakerNameHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.MakHd_SectionCode,
            this.MakHd_SectionGuideNm,
            this.MakHd_SectionTitle,
            this.MakHd_SupplierCd,
            this.MakHd_SupplierSnm,
            this.MakHd_SuplierTitle,
            this.MakHd_GoodsMakerCd,
            this.MakHd_MakerName,
            this.MakHd_GoodsMakerTitle,
            this.upline_MakerNameHeader});
            this.MakerNameHeader.DataField = "GoodsMakerCd";
            this.MakerNameHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.MakerNameHeader.Height = 0.2395833F;
            this.MakerNameHeader.KeepTogether = true;
            this.MakerNameHeader.Name = "MakerNameHeader";
            this.MakerNameHeader.BeforePrint += new System.EventHandler(this.MakerNameHeader_BeforePrint);
            // 
            // MakHd_SectionCode
            // 
            this.MakHd_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionCode.DataField = "SectionCode";
            this.MakHd_SectionCode.Height = 0.156F;
            this.MakHd_SectionCode.Left = 0.5625F;
            this.MakHd_SectionCode.MultiLine = false;
            this.MakHd_SectionCode.Name = "MakHd_SectionCode";
            this.MakHd_SectionCode.OutputFormat = resources.GetString("MakHd_SectionCode.OutputFormat");
            this.MakHd_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.MakHd_SectionCode.Text = "12";
            this.MakHd_SectionCode.Top = 0.031F;
            this.MakHd_SectionCode.Width = 0.2F;
            // 
            // MakHd_SectionGuideNm
            // 
            this.MakHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionGuideNm.DataField = "SectionGuideNm";
            this.MakHd_SectionGuideNm.Height = 0.15625F;
            this.MakHd_SectionGuideNm.Left = 0.75F;
            this.MakHd_SectionGuideNm.MultiLine = false;
            this.MakHd_SectionGuideNm.Name = "MakHd_SectionGuideNm";
            this.MakHd_SectionGuideNm.OutputFormat = resources.GetString("MakHd_SectionGuideNm.OutputFormat");
            this.MakHd_SectionGuideNm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.MakHd_SectionGuideNm.Top = 0.031F;
            this.MakHd_SectionGuideNm.Width = 1.1875F;
            // 
            // MakHd_SectionTitle
            // 
            this.MakHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SectionTitle.Height = 0.156F;
            this.MakHd_SectionTitle.HyperLink = "";
            this.MakHd_SectionTitle.Left = 0.25F;
            this.MakHd_SectionTitle.MultiLine = false;
            this.MakHd_SectionTitle.Name = "MakHd_SectionTitle";
            this.MakHd_SectionTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.MakHd_SectionTitle.Text = "拠点";
            this.MakHd_SectionTitle.Top = 0.031F;
            this.MakHd_SectionTitle.Width = 0.313F;
            // 
            // MakHd_SupplierCd
            // 
            this.MakHd_SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierCd.DataField = "SupplierCd";
            this.MakHd_SupplierCd.Height = 0.156F;
            this.MakHd_SupplierCd.Left = 2.375F;
            this.MakHd_SupplierCd.MultiLine = false;
            this.MakHd_SupplierCd.Name = "MakHd_SupplierCd";
            this.MakHd_SupplierCd.OutputFormat = resources.GetString("MakHd_SupplierCd.OutputFormat");
            this.MakHd_SupplierCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.MakHd_SupplierCd.Text = "123456";
            this.MakHd_SupplierCd.Top = 0.031F;
            this.MakHd_SupplierCd.Width = 0.4F;
            // 
            // MakHd_SupplierSnm
            // 
            this.MakHd_SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SupplierSnm.DataField = "SupplierSnm";
            this.MakHd_SupplierSnm.Height = 0.156F;
            this.MakHd_SupplierSnm.Left = 2.75F;
            this.MakHd_SupplierSnm.MultiLine = false;
            this.MakHd_SupplierSnm.Name = "MakHd_SupplierSnm";
            this.MakHd_SupplierSnm.OutputFormat = resources.GetString("MakHd_SupplierSnm.OutputFormat");
            this.MakHd_SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakHd_SupplierSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.MakHd_SupplierSnm.Top = 0.031F;
            this.MakHd_SupplierSnm.Width = 2.3F;
            // 
            // MakHd_SuplierTitle
            // 
            this.MakHd_SuplierTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_SuplierTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SuplierTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_SuplierTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SuplierTitle.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_SuplierTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SuplierTitle.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_SuplierTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_SuplierTitle.Height = 0.156F;
            this.MakHd_SuplierTitle.HyperLink = "";
            this.MakHd_SuplierTitle.Left = 2F;
            this.MakHd_SuplierTitle.MultiLine = false;
            this.MakHd_SuplierTitle.Name = "MakHd_SuplierTitle";
            this.MakHd_SuplierTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.MakHd_SuplierTitle.Text = "仕入先";
            this.MakHd_SuplierTitle.Top = 0.031F;
            this.MakHd_SuplierTitle.Width = 0.4F;
            // 
            // MakHd_GoodsMakerCd
            // 
            this.MakHd_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerCd.DataField = "GoodsMakerCd";
            this.MakHd_GoodsMakerCd.Height = 0.156F;
            this.MakHd_GoodsMakerCd.Left = 5.625F;
            this.MakHd_GoodsMakerCd.MultiLine = false;
            this.MakHd_GoodsMakerCd.Name = "MakHd_GoodsMakerCd";
            this.MakHd_GoodsMakerCd.OutputFormat = resources.GetString("MakHd_GoodsMakerCd.OutputFormat");
            this.MakHd_GoodsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.MakHd_GoodsMakerCd.Text = "1234";
            this.MakHd_GoodsMakerCd.Top = 0.031F;
            this.MakHd_GoodsMakerCd.Width = 0.3F;
            // 
            // MakHd_MakerName
            // 
            this.MakHd_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_MakerName.DataField = "MakerName";
            this.MakHd_MakerName.Height = 0.156F;
            this.MakHd_MakerName.Left = 5.9375F;
            this.MakHd_MakerName.MultiLine = false;
            this.MakHd_MakerName.Name = "MakHd_MakerName";
            this.MakHd_MakerName.OutputFormat = resources.GetString("MakHd_MakerName.OutputFormat");
            this.MakHd_MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakHd_MakerName.Text = "あいうえおかきくけこ";
            this.MakHd_MakerName.Top = 0.031F;
            this.MakHd_MakerName.Width = 1.2F;
            // 
            // MakHd_GoodsMakerTitle
            // 
            this.MakHd_GoodsMakerTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerTitle.Border.RightColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerTitle.Border.TopColor = System.Drawing.Color.Black;
            this.MakHd_GoodsMakerTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakHd_GoodsMakerTitle.Height = 0.156F;
            this.MakHd_GoodsMakerTitle.HyperLink = "";
            this.MakHd_GoodsMakerTitle.Left = 5.125F;
            this.MakHd_GoodsMakerTitle.MultiLine = false;
            this.MakHd_GoodsMakerTitle.Name = "MakHd_GoodsMakerTitle";
            this.MakHd_GoodsMakerTitle.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.MakHd_GoodsMakerTitle.Text = "メーカー";
            this.MakHd_GoodsMakerTitle.Top = 0.031F;
            this.MakHd_GoodsMakerTitle.Width = 0.5F;
            // 
            // MakerNameFooter
            // 
            this.MakerNameFooter.CanShrink = true;
            this.MakerNameFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2,
            this.MakFt_GrossMoney,
            this.MakFt_PureSalesMoney,
            this.MakFt_TotalCount,
            this.MakFt_GrossMoneyRate,
            this.MakFt_StockCount,
            this.MakFt_OrderCount,
            this.line4,
            this.MakFt_GrossMoneyOrg,
            this.MakFt_PureSalesMoneyOrg});
            this.MakerNameFooter.Height = 0.34375F;
            this.MakerNameFooter.KeepTogether = true;
            this.MakerNameFooter.Name = "MakerNameFooter";
            this.MakerNameFooter.BeforePrint += new System.EventHandler(this.MakerNameFooter_BeforePrint);
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
            this.textBox2.Height = 0.219F;
            this.textBox2.Left = 4.427F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox2.Text = "メーカー計";
            this.textBox2.Top = 0.031F;
            this.textBox2.Width = 0.8F;
            // 
            // MakFt_GrossMoney
            // 
            this.MakFt_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoney.DataField = "PrintGrossMoney";
            this.MakFt_GrossMoney.Height = 0.156F;
            this.MakFt_GrossMoney.Left = 9.275F;
            this.MakFt_GrossMoney.MultiLine = false;
            this.MakFt_GrossMoney.Name = "MakFt_GrossMoney";
            this.MakFt_GrossMoney.OutputFormat = resources.GetString("MakFt_GrossMoney.OutputFormat");
            this.MakFt_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GrossMoney.SummaryGroup = "MakerNameHeader";
            this.MakFt_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_GrossMoney.Text = "123,456,789,012";
            this.MakFt_GrossMoney.Top = 0.031F;
            this.MakFt_GrossMoney.Width = 1F;
            // 
            // MakFt_PureSalesMoney
            // 
            this.MakFt_PureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoney.DataField = "PureSalesMoney";
            this.MakFt_PureSalesMoney.Height = 0.156F;
            this.MakFt_PureSalesMoney.Left = 8.0875F;
            this.MakFt_PureSalesMoney.MultiLine = false;
            this.MakFt_PureSalesMoney.Name = "MakFt_PureSalesMoney";
            this.MakFt_PureSalesMoney.OutputFormat = resources.GetString("MakFt_PureSalesMoney.OutputFormat");
            this.MakFt_PureSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_PureSalesMoney.SummaryGroup = "MakerNameHeader";
            this.MakFt_PureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_PureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_PureSalesMoney.Text = "123,456,789,012";
            this.MakFt_PureSalesMoney.Top = 0.031F;
            this.MakFt_PureSalesMoney.Width = 1F;
            // 
            // MakFt_TotalCount
            // 
            this.MakFt_TotalCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_TotalCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_TotalCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalCount.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_TotalCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalCount.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_TotalCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_TotalCount.DataField = "TotalCount";
            this.MakFt_TotalCount.Height = 0.156F;
            this.MakFt_TotalCount.Left = 5.875F;
            this.MakFt_TotalCount.MultiLine = false;
            this.MakFt_TotalCount.Name = "MakFt_TotalCount";
            this.MakFt_TotalCount.OutputFormat = resources.GetString("MakFt_TotalCount.OutputFormat");
            this.MakFt_TotalCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_TotalCount.SummaryGroup = "MakerNameHeader";
            this.MakFt_TotalCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_TotalCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_TotalCount.Text = "123,456,789";
            this.MakFt_TotalCount.Top = 0.031F;
            this.MakFt_TotalCount.Width = 0.65F;
            // 
            // MakFt_GrossMoneyRate
            // 
            this.MakFt_GrossMoneyRate.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyRate.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyRate.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyRate.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyRate.Height = 0.156F;
            this.MakFt_GrossMoneyRate.Left = 10.3125F;
            this.MakFt_GrossMoneyRate.MultiLine = false;
            this.MakFt_GrossMoneyRate.Name = "MakFt_GrossMoneyRate";
            this.MakFt_GrossMoneyRate.OutputFormat = resources.GetString("MakFt_GrossMoneyRate.OutputFormat");
            this.MakFt_GrossMoneyRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GrossMoneyRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_GrossMoneyRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_GrossMoneyRate.Text = "123,456,789";
            this.MakFt_GrossMoneyRate.Top = 0.031F;
            this.MakFt_GrossMoneyRate.Width = 0.42F;
            // 
            // MakFt_StockCount
            // 
            this.MakFt_StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_StockCount.DataField = "StockCount";
            this.MakFt_StockCount.Height = 0.156F;
            this.MakFt_StockCount.Left = 6.5625F;
            this.MakFt_StockCount.MultiLine = false;
            this.MakFt_StockCount.Name = "MakFt_StockCount";
            this.MakFt_StockCount.OutputFormat = resources.GetString("MakFt_StockCount.OutputFormat");
            this.MakFt_StockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_StockCount.SummaryGroup = "MakerNameHeader";
            this.MakFt_StockCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_StockCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_StockCount.Text = "123,456,789";
            this.MakFt_StockCount.Top = 0.031F;
            this.MakFt_StockCount.Width = 0.65F;
            // 
            // MakFt_OrderCount
            // 
            this.MakFt_OrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_OrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_OrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_OrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_OrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_OrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_OrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_OrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_OrderCount.DataField = "OrderCount";
            this.MakFt_OrderCount.Height = 0.156F;
            this.MakFt_OrderCount.Left = 7.25F;
            this.MakFt_OrderCount.MultiLine = false;
            this.MakFt_OrderCount.Name = "MakFt_OrderCount";
            this.MakFt_OrderCount.OutputFormat = resources.GetString("MakFt_OrderCount.OutputFormat");
            this.MakFt_OrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_OrderCount.SummaryGroup = "MakerNameHeader";
            this.MakFt_OrderCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_OrderCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_OrderCount.Text = "123,456,789";
            this.MakFt_OrderCount.Top = 0.031F;
            this.MakFt_OrderCount.Width = 0.65F;
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
            // MakFt_GrossMoneyOrg
            // 
            this.MakFt_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.MakFt_GrossMoneyOrg.Height = 0.156F;
            this.MakFt_GrossMoneyOrg.Left = 1F;
            this.MakFt_GrossMoneyOrg.MultiLine = false;
            this.MakFt_GrossMoneyOrg.Name = "MakFt_GrossMoneyOrg";
            this.MakFt_GrossMoneyOrg.OutputFormat = resources.GetString("MakFt_GrossMoneyOrg.OutputFormat");
            this.MakFt_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_GrossMoneyOrg.SummaryGroup = "MakerNameHeader";
            this.MakFt_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_GrossMoneyOrg.Text = "123,456,789,012";
            this.MakFt_GrossMoneyOrg.Top = 0.031F;
            this.MakFt_GrossMoneyOrg.Visible = false;
            this.MakFt_GrossMoneyOrg.Width = 1F;
            // 
            // MakFt_PureSalesMoneyOrg
            // 
            this.MakFt_PureSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.MakFt_PureSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakFt_PureSalesMoneyOrg.DataField = "PureSalesMoneyOrg";
            this.MakFt_PureSalesMoneyOrg.Height = 0.156F;
            this.MakFt_PureSalesMoneyOrg.Left = 0F;
            this.MakFt_PureSalesMoneyOrg.MultiLine = false;
            this.MakFt_PureSalesMoneyOrg.Name = "MakFt_PureSalesMoneyOrg";
            this.MakFt_PureSalesMoneyOrg.OutputFormat = resources.GetString("MakFt_PureSalesMoneyOrg.OutputFormat");
            this.MakFt_PureSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.MakFt_PureSalesMoneyOrg.SummaryGroup = "MakerNameHeader";
            this.MakFt_PureSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.MakFt_PureSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.MakFt_PureSalesMoneyOrg.Text = "123,456,789,012";
            this.MakFt_PureSalesMoneyOrg.Top = 0.031F;
            this.MakFt_PureSalesMoneyOrg.Visible = false;
            this.MakFt_PureSalesMoneyOrg.Width = 1F;
            // 
            // SuplierHeader
            // 
            this.SuplierHeader.DataField = "SupplierCd";
            this.SuplierHeader.Height = 0F;
            this.SuplierHeader.KeepTogether = true;
            this.SuplierHeader.Name = "SuplierHeader";
            // 
            // SuplierFooter
            // 
            this.SuplierFooter.CanShrink = true;
            this.SuplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.SupFt_TotalCount,
            this.SupFt_PureSalesMoney,
            this.SupFt_GrossMoney,
            this.SupFt_GrossMoneyRate,
            this.SupFt_StockCount,
            this.SupFt_OrderCount,
            this.line3,
            this.SupFt_GrossMoneyOrg,
            this.SupFt_PureSalesMoneyOrg});
            this.SuplierFooter.Height = 0.3229167F;
            this.SuplierFooter.KeepTogether = true;
            this.SuplierFooter.Name = "SuplierFooter";
            this.SuplierFooter.BeforePrint += new System.EventHandler(this.SuplierFooter_BeforePrint);
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.219F;
            this.textBox1.Left = 4.427F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox1.Text = "仕入先計計";
            this.textBox1.Top = 0.031F;
            this.textBox1.Width = 0.7F;
            // 
            // SupFt_TotalCount
            // 
            this.SupFt_TotalCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_TotalCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_TotalCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalCount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_TotalCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalCount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_TotalCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_TotalCount.DataField = "TotalCount";
            this.SupFt_TotalCount.Height = 0.156F;
            this.SupFt_TotalCount.Left = 5.875F;
            this.SupFt_TotalCount.MultiLine = false;
            this.SupFt_TotalCount.Name = "SupFt_TotalCount";
            this.SupFt_TotalCount.OutputFormat = resources.GetString("SupFt_TotalCount.OutputFormat");
            this.SupFt_TotalCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_TotalCount.SummaryGroup = "SuplierHeader";
            this.SupFt_TotalCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_TotalCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_TotalCount.Text = "123,456,789";
            this.SupFt_TotalCount.Top = 0.031F;
            this.SupFt_TotalCount.Width = 0.65F;
            // 
            // SupFt_PureSalesMoney
            // 
            this.SupFt_PureSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoney.DataField = "PureSalesMoney";
            this.SupFt_PureSalesMoney.Height = 0.156F;
            this.SupFt_PureSalesMoney.Left = 8.0875F;
            this.SupFt_PureSalesMoney.MultiLine = false;
            this.SupFt_PureSalesMoney.Name = "SupFt_PureSalesMoney";
            this.SupFt_PureSalesMoney.OutputFormat = resources.GetString("SupFt_PureSalesMoney.OutputFormat");
            this.SupFt_PureSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_PureSalesMoney.SummaryGroup = "SuplierHeader";
            this.SupFt_PureSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_PureSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_PureSalesMoney.Text = "123,456,789,012";
            this.SupFt_PureSalesMoney.Top = 0.031F;
            this.SupFt_PureSalesMoney.Width = 1F;
            // 
            // SupFt_GrossMoney
            // 
            this.SupFt_GrossMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoney.DataField = "PrintGrossMoney";
            this.SupFt_GrossMoney.Height = 0.156F;
            this.SupFt_GrossMoney.Left = 9.275F;
            this.SupFt_GrossMoney.MultiLine = false;
            this.SupFt_GrossMoney.Name = "SupFt_GrossMoney";
            this.SupFt_GrossMoney.OutputFormat = resources.GetString("SupFt_GrossMoney.OutputFormat");
            this.SupFt_GrossMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_GrossMoney.SummaryGroup = "SuplierHeader";
            this.SupFt_GrossMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_GrossMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_GrossMoney.Text = "123,456,789,012";
            this.SupFt_GrossMoney.Top = 0.031F;
            this.SupFt_GrossMoney.Width = 1F;
            // 
            // SupFt_GrossMoneyRate
            // 
            this.SupFt_GrossMoneyRate.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyRate.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyRate.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyRate.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyRate.Height = 0.156F;
            this.SupFt_GrossMoneyRate.Left = 10.3125F;
            this.SupFt_GrossMoneyRate.MultiLine = false;
            this.SupFt_GrossMoneyRate.Name = "SupFt_GrossMoneyRate";
            this.SupFt_GrossMoneyRate.OutputFormat = resources.GetString("SupFt_GrossMoneyRate.OutputFormat");
            this.SupFt_GrossMoneyRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_GrossMoneyRate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_GrossMoneyRate.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_GrossMoneyRate.Text = "123,456,789";
            this.SupFt_GrossMoneyRate.Top = 0.031F;
            this.SupFt_GrossMoneyRate.Width = 0.42F;
            // 
            // SupFt_StockCount
            // 
            this.SupFt_StockCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_StockCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_StockCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockCount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_StockCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockCount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_StockCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_StockCount.DataField = "StockCount";
            this.SupFt_StockCount.Height = 0.156F;
            this.SupFt_StockCount.Left = 6.5625F;
            this.SupFt_StockCount.MultiLine = false;
            this.SupFt_StockCount.Name = "SupFt_StockCount";
            this.SupFt_StockCount.OutputFormat = resources.GetString("SupFt_StockCount.OutputFormat");
            this.SupFt_StockCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_StockCount.SummaryGroup = "SuplierHeader";
            this.SupFt_StockCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_StockCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_StockCount.Text = "123,456,789";
            this.SupFt_StockCount.Top = 0.031F;
            this.SupFt_StockCount.Width = 0.65F;
            // 
            // SupFt_OrderCount
            // 
            this.SupFt_OrderCount.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_OrderCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderCount.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_OrderCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderCount.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_OrderCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderCount.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_OrderCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_OrderCount.DataField = "OrderCount";
            this.SupFt_OrderCount.Height = 0.156F;
            this.SupFt_OrderCount.Left = 7.25F;
            this.SupFt_OrderCount.MultiLine = false;
            this.SupFt_OrderCount.Name = "SupFt_OrderCount";
            this.SupFt_OrderCount.OutputFormat = resources.GetString("SupFt_OrderCount.OutputFormat");
            this.SupFt_OrderCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_OrderCount.SummaryGroup = "SuplierHeader";
            this.SupFt_OrderCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_OrderCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_OrderCount.Text = "123,456,789";
            this.SupFt_OrderCount.Top = 0.031F;
            this.SupFt_OrderCount.Width = 0.65F;
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
            // SupFt_GrossMoneyOrg
            // 
            this.SupFt_GrossMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_GrossMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_GrossMoneyOrg.DataField = "GrossMoneyOrg";
            this.SupFt_GrossMoneyOrg.Height = 0.156F;
            this.SupFt_GrossMoneyOrg.Left = 1F;
            this.SupFt_GrossMoneyOrg.MultiLine = false;
            this.SupFt_GrossMoneyOrg.Name = "SupFt_GrossMoneyOrg";
            this.SupFt_GrossMoneyOrg.OutputFormat = resources.GetString("SupFt_GrossMoneyOrg.OutputFormat");
            this.SupFt_GrossMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_GrossMoneyOrg.SummaryGroup = "SuplierHeader";
            this.SupFt_GrossMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_GrossMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_GrossMoneyOrg.Text = "123,456,789,012";
            this.SupFt_GrossMoneyOrg.Top = 0.031F;
            this.SupFt_GrossMoneyOrg.Visible = false;
            this.SupFt_GrossMoneyOrg.Width = 1F;
            // 
            // SupFt_PureSalesMoneyOrg
            // 
            this.SupFt_PureSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.SupFt_PureSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupFt_PureSalesMoneyOrg.DataField = "PureSalesMoneyOrg";
            this.SupFt_PureSalesMoneyOrg.Height = 0.156F;
            this.SupFt_PureSalesMoneyOrg.Left = 0F;
            this.SupFt_PureSalesMoneyOrg.MultiLine = false;
            this.SupFt_PureSalesMoneyOrg.Name = "SupFt_PureSalesMoneyOrg";
            this.SupFt_PureSalesMoneyOrg.OutputFormat = resources.GetString("SupFt_PureSalesMoneyOrg.OutputFormat");
            this.SupFt_PureSalesMoneyOrg.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.SupFt_PureSalesMoneyOrg.SummaryGroup = "SuplierHeader";
            this.SupFt_PureSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SupFt_PureSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SupFt_PureSalesMoneyOrg.Text = "123,456,789,012";
            this.SupFt_PureSalesMoneyOrg.Top = 0.031F;
            this.SupFt_PureSalesMoneyOrg.Visible = false;
            this.SupFt_PureSalesMoneyOrg.Width = 1F;
            // 
            // upline_MakerNameHeader
            // 
            this.upline_MakerNameHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.upline_MakerNameHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_MakerNameHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.upline_MakerNameHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_MakerNameHeader.Border.RightColor = System.Drawing.Color.Black;
            this.upline_MakerNameHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_MakerNameHeader.Border.TopColor = System.Drawing.Color.Black;
            this.upline_MakerNameHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.upline_MakerNameHeader.Height = 0F;
            this.upline_MakerNameHeader.Left = 0F;
            this.upline_MakerNameHeader.LineWeight = 2F;
            this.upline_MakerNameHeader.Name = "upline_MakerNameHeader";
            this.upline_MakerNameHeader.Top = 0F;
            this.upline_MakerNameHeader.Width = 10.8F;
            this.upline_MakerNameHeader.X1 = 0F;
            this.upline_MakerNameHeader.X2 = 10.8F;
            this.upline_MakerNameHeader.Y1 = 0F;
            this.upline_MakerNameHeader.Y2 = 0F;
            // 
            // DCTOK02052P_01A4C
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
            this.PrintWidth = 10.76875F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SuplierHeader);
            this.Sections.Add(this.MakerNameHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.MakerNameFooter);
            this.Sections.Add(this.SuplierFooter);
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
            ((System.ComponentModel.ISupportInitialize)(this.GoodsShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankGrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankTotalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMoneyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_TotalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_PureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossMoneyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_OrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlFt_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TtlFt_PureSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_TotalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_PureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_GrossMoneyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sec_OrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecFt_PureSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_SuplierTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakHd_GoodsMakerTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_PureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_TotalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossMoneyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_OrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakFt_PureSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_TotalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossMoneyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_StockCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_OrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_GrossMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupFt_PureSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


         // --- DEL 2008/10/20 -------------------------------->>>>>
        //private void SectionFooter_Format(object sender, EventArgs e)
        //{
        //    // 粗利率
        //    if ((double.Parse(this.Sec_PureSalesMoney.Value.ToString()) == 0) || (double.Parse(this.Sec_GrossMoney.Value.ToString()) == 0))
        //    {
        //        Sec_GrossMoneyRate.Value = 0;
        //    }
        //    else
        //    {
        //        Sec_GrossMoneyRate.Value = double.Parse(this.Sec_GrossMoney.Value.ToString()) / double.Parse(this.Sec_PureSalesMoney.Value.ToString());
        //    }
        //}

        //private void GrandTotalFooter_Format(object sender, EventArgs e)
        //{
        //    // 粗利率
        //    if ((double.Parse(this.Ttl_PureSalesMoney.Value.ToString()) == 0) || (double.Parse(this.Ttl_GrossMoney.Value.ToString()) == 0))
        //    {
        //        Ttl_GrossMoneyRate.Value = 0;
        //    }
        //    else
        //    {
        //        Ttl_GrossMoneyRate.Value = double.Parse(this.Ttl_GrossMoney.Value.ToString()) / double.Parse(this.Ttl_PureSalesMoney.Value.ToString());
        //    }
        //}
        // --- DEL 2008/10/20 --------------------------------<<<<<
	}
}
