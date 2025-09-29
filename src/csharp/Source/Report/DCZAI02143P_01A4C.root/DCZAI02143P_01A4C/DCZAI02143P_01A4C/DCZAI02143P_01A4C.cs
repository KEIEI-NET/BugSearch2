//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫分析順位表
// プログラム概要   : 在庫分析順位表の印刷レイアウトの制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/01  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/27  修正内容 : 障害対応12033
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12783]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/06  修正内容 : 不具合対応[13001]
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
	/// 在庫分析順位表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : 在庫分析順位表のフォームクラスです。</br>
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2007.09.19</br>
	/// <br></br>
	/// <br>UpdateNote   : 2008/10/01 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Update Note  : 2009/02/27 30452 上野 俊治</br>
    /// <br>              ・障害対応12033</br>
	/// <br>             : 2009/03/27 照田 貴志　不具合対応[12783]</br>
    /// <br>             : 2009/04/06 照田 貴志　不具合対応[13001]</br>
    /// </remarks>
	public class DCZAI02143P_01A4C : ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫分析順位表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : 在庫分析順位表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer   : 22018　鈴木　正臣</br>
		/// <br>Date         : 2007.09.19</br>
		/// </remarks>
		public DCZAI02143P_01A4C()
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

        private StockAnalysisOrderListCndtn _stockAnalysisOrderListCndtn;				// 抽出条件クラス

        private string _groupKey = string.Empty;                    // グループサプレス用キー   //ADD 2009/03/27 不具合対応[12783]

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;
        private TextBox tb_PrintSortOrder;
        private TextBox CustomerName;
        private Line Line;
        private GroupHeader SectionTitleHeader;
        private Label Lb_Warehouse;
        private GroupFooter SectionTitleFooter;
        private Line line3;
        private Line line4;
        private TextBox GoodsMakerCd;
        private Label label1;
        private TextBox Dm2_ShipmentCnt;
        private TextBox Dm2_ShipmentCntOrder;
        private TextBox Dm2_GrossProfit;
        private TextBox Dm2_GrossProfitOrder;
        private TextBox Dm2_SalesMoneyTaxExc;
        private TextBox Dm2_SalesMoneyTaxExcOrder;
        private TextBox Dm1_ShipmentCnt;
        private TextBox Dm1_ShipmentCntOrder;
        private TextBox Dm1_GrossProfit;
        private TextBox Dm1_GrossProfitOrder;
        private TextBox Dm1_SalesMoneyTaxExc;
        private TextBox Dm1_SalesMoneyTaxExcOrder;
        private TextBox textBox1;
        private TextBox textBox2;

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
				this._stockAnalysisOrderListCndtn	= (StockAnalysisOrderListCndtn)this._printInfo.jyoken;
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

            
            //// 拠点計を出力するかしないかを選択する
            //// 拠点有無を判断
            //if ( this._stockAnalysisOrderListCndtn.IsOptSection ) {
            //    // 全社がチェックされている時、または拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
            //    if ( ( this._stockAnalysisOrderListCndtn.SectionCodes.Length < 2 ) ||
            //        this._stockAnalysisOrderListCndtn.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCZAI02145EA.ct_Col_Sort_SectionCode;
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

            /* ---DEL 2009/04/06 不具合対応[13001] ------------------------------------------->>>>>
            SectionHeader.DataField = DCZAI02145EA.ct_Col_Sort_SectionCode;
            SectionHeader.Visible = true;
            SectionFooter.Visible = true;
               ---DEL 2009/04/06 不具合対応[13001] -------------------------------------------<<<<< */

            // 倉庫毎の改ページ有無を設定
            switch (this._stockAnalysisOrderListCndtn.NewPageDiv) {
                // 倉庫毎改ページする
                case StockAnalysisOrderListCndtn.NewPageDivState.ByWarehouse :
                    WarehouseHeader.NewPage = NewPage.Before;
                    break;
                // 改ページしない
                case StockAnalysisOrderListCndtn.NewPageDivState.None :
                    WarehouseHeader.NewPage = NewPage.None;
                    break;
                default :
                    break;
            }

            if (this._stockAnalysisOrderListCndtn.PrintTypeDiv == StockAnalysisOrderListCndtn.PrintTypeDivState.Total)
            {
                /* ---DEL 2009/04/06 不具合対応[13001] ---------------------------------->>>>>
                SectionHeader.Visible = false;
                SectionFooter.Visible = false;
                   ---DEL 2009/04/06 不具合対応[13001] ----------------------------------<<<<< */
                WarehouseHeader.Visible = false;
                WarehouseFooter.Visible = false;
                // ---ADD 2008/10/01 -------------------->>>>>
                // "拠点"、"倉庫"表示用ヘッダーを非表示とする
                SectionTitleHeader.Visible = false;
                SectionTitleFooter.Visible = false;     
                // ---ADD 2008/10/01 --------------------<<<<<

                // ---ADD 2009/03/27 不具合対応[12783] ---------------------->>>>>
                Lb_WarehouseShelfNo.Visible = false;
                WarehouseShelfNo.Visible = false;
                Lb_StockCreateDate.Visible = false;
                StockCreateDate.Visible = false;
                Lb_ShipmentPosCnt.Visible = false;
                ShipmentPosCnt.Visible = false;
                Lb_MinimumStockCnt.Visible = false;
                MinimumStockCnt.Visible = false;
                Lb_MaximumStockCnt.Visible = false;
                MaximumStockCnt.Visible = false;
                // ---ADD 2009/03/27 不具合対応[12783] ----------------------<<<<<
            }

            // ---ADD 2009/03/27 不具合対応[12783] -------------------------------------------------------------->>>>>
            if (this._stockAnalysisOrderListCndtn.OrderPrintType == StockAnalysisOrderListCndtn.OrderPrintTypeState.GrossProfitOrder)
            {
                //タイトル
                Lb_SalesMoneyTaxExcOrder.Left = Dm1_SalesMoneyTaxExcOrder.Left;
                Lb_SalesMoneyTaxExc.Left = Dm1_SalesMoneyTaxExc.Left;
                Lb_GrossProfitOrder.Left = Dm1_GrossProfitOrder.Left;
                Lb_GrossProfit.Left = Dm1_GrossProfit.Left;
                Lb_ShipmentCntOrder.Left = Dm1_ShipmentCntOrder.Left;
                Lb_ShipmentCnt.Left = Dm1_ShipmentCnt.Left;

                //明細
                SalesMoneyTaxExcOrder.Left = Dm1_SalesMoneyTaxExcOrder.Left;
                SalesMoneyTaxExc.Left = Dm1_SalesMoneyTaxExc.Left;
                GrossProfitOrder.Left = Dm1_GrossProfitOrder.Left;
                GrossProfit.Left = Dm1_GrossProfit.Left;
                ShipmentCntOrder.Left = Dm1_ShipmentCntOrder.Left;
                ShipmentCnt.Left = Dm1_ShipmentCnt.Left;

                //各計
                Wh_SalesMoneyTaxExc.Left = Dm1_SalesMoneyTaxExcOrder.Left;
                Wh_GrossProfit.Left = Dm1_GrossProfitOrder.Left;
                Wh_ShipmentCnt.Left = Dm1_ShipmentCntOrder.Left;
                /* ---DEL 2009/04/06 不具合対応[13001] ----------------------------->>>>>
                Sec_SalesMoneyTaxExc.Left = Dm1_SalesMoneyTaxExcOrder.Left;
                Sec_GrossProfit.Left = Dm1_GrossProfitOrder.Left;
                Sec_ShipmentCnt.Left = Dm1_ShipmentCntOrder.Left;
                   ---DEL 2009/04/06 不具合対応[13001] -----------------------------<<<<< */
                Ttl_SalesMoneyTaxExc.Left = Dm1_SalesMoneyTaxExcOrder.Left;
                Ttl_GrossProfit.Left = Dm1_GrossProfitOrder.Left;
                Ttl_ShipmentCnt.Left = Dm1_ShipmentCntOrder.Left;
            }
            else if (this._stockAnalysisOrderListCndtn.OrderPrintType == StockAnalysisOrderListCndtn.OrderPrintTypeState.ShipmentCntOrder)
            {
                //タイトル
                Lb_SalesMoneyTaxExcOrder.Left = Dm2_SalesMoneyTaxExcOrder.Left;
                Lb_SalesMoneyTaxExc.Left = Dm2_SalesMoneyTaxExc.Left;
                Lb_GrossProfitOrder.Left = Dm2_GrossProfitOrder.Left;
                Lb_GrossProfit.Left = Dm2_GrossProfit.Left;
                Lb_ShipmentCntOrder.Left = Dm2_ShipmentCntOrder.Left;
                Lb_ShipmentCnt.Left = Dm2_ShipmentCnt.Left;

                //明細
                SalesMoneyTaxExcOrder.Left = Dm2_SalesMoneyTaxExcOrder.Left;
                SalesMoneyTaxExc.Left = Dm2_SalesMoneyTaxExc.Left;
                GrossProfitOrder.Left = Dm2_GrossProfitOrder.Left;
                GrossProfit.Left = Dm2_GrossProfit.Left;
                ShipmentCntOrder.Left = Dm2_ShipmentCntOrder.Left;
                ShipmentCnt.Left = Dm2_ShipmentCnt.Left;

                //各計
                Wh_SalesMoneyTaxExc.Left = Dm2_SalesMoneyTaxExcOrder.Left;
                Wh_GrossProfit.Left = Dm2_GrossProfitOrder.Left;
                Wh_ShipmentCnt.Left = Dm2_ShipmentCntOrder.Left;
                /* ---DEL 2009/04/06 不具合対応[13001] ------------------------------->>>>>
                Sec_SalesMoneyTaxExc.Left = Dm2_SalesMoneyTaxExcOrder.Left;
                Sec_GrossProfit.Left = Dm2_GrossProfitOrder.Left;
                Sec_ShipmentCnt.Left = Dm2_ShipmentCntOrder.Left;
                   ---DEL 2009/04/06 不具合対応[13001] -------------------------------<<<<< */
                Ttl_SalesMoneyTaxExc.Left = Dm2_SalesMoneyTaxExcOrder.Left;
                Ttl_GrossProfit.Left = Dm2_GrossProfitOrder.Left;
                Ttl_ShipmentCnt.Left = Dm2_ShipmentCntOrder.Left;
            }
            else
            {
            }
            // ---ADD 2009/03/27 不具合対応[12783] --------------------------------------------------------------<<<<<

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

            // ---ADD 2009/03/27 不具合対応[12783] ------------------------------------------------>>>>>
            string groupKey = string.Empty;
            if (this._stockAnalysisOrderListCndtn.PrintTypeDiv == StockAnalysisOrderListCndtn.PrintTypeDivState.Total)
            {
                groupKey = this.CustomerCode.Value.ToString();
            }
            else
            {
                //groupKey = this.SectionCode.Value.ToString() + this.WarehouseCode.Value.ToString() + this.CustomerCode.Value.ToString();      //DEL 2009/04/06 不具合対応[13001]
                groupKey = this.WarehouseCode.Value.ToString() + this.CustomerCode.Value.ToString();                                            //ADD 2009/04/06 不具合対応[13001]
            }

            if (this._groupKey == groupKey)
            {
                this.CustomerCode.Visible = false;
                this.CustomerName.Visible = false;
            }
            else
            {
                this.CustomerCode.Visible = true;
                this.CustomerName.Visible = true;
            }

            this._groupKey = groupKey;
            // ---ADD 2009/03/27 不具合対応[12783] ------------------------------------------------<<<<<

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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
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
		/// <br>Programmer	: 22018 鈴木　正臣</br>
		/// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private void MAZAI02032P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( StockAnalysisOrderListCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 印刷順
            this.tb_PrintSortOrder.Text = string.Format( "[ {0} ]", this._pageHeaderSortOderTitle );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
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
            //string sectionTitle = string.Format( "{0}拠点：", this._stockAnalysisOrderListCndtn.MainExtractTitle );
            //if ( this._stockAnalysisOrderListCndtn.IsOptSection )
            //{
            //    if ( this._stockAnalysisOrderListCndtn.IsSelectAllSection )
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

        // --- ADD 2009/02/27 -------------------------------->>>>>
        #region ◎ WarehouseHeader_BeforePrint Event
        /// <summary>
        /// WarehouseHeader_BeforePrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader_BeforePrint(object sender, EventArgs e)
        {
            // ゼロ値の場合、表示しない
            /* ---DEL 2009/04/06 不具合対応[13001] ---------------------------->>>>>
            if (string.IsNullOrEmpty(this.SectionCode.Text)
                || this.SectionCode.Text.PadLeft(2, '0') == "00")
            {
                this.SectionCode.Text = string.Empty;
                this.SectionGuideNm.Text = string.Empty;
            }
               ---DEL 2009/04/06 不具合対応[13001] ----------------------------<<<<< */

            if (string.IsNullOrEmpty(this.WarehouseCode.Text)
                || this.WarehouseCode.Text.PadLeft(4, '0') == "0000")
            {
                this.WarehouseCode.Text = string.Empty;
                this.WarehouseName.Text = string.Empty;
            }
        }
        #endregion
        // --- ADD 2009/02/27 --------------------------------<<<<<
        

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

            /* --- DEL 2009/03/27 不具合対応[12783] ------------------------->>>>>
            // --- ADD 2009/02/27 -------------------------------->>>>>
            // ゼロ値の場合、表示しない
            if (string.IsNullOrEmpty(this.CustomerCode.Text)
                || this.CustomerCode.Text.PadLeft(6, '0') == "000000")
            {
                this.CustomerCode.Text = string.Empty;
                this.textBox1.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.LargeGoodsGanreCode.Text)
                || this.LargeGoodsGanreCode.Text.PadLeft(4, '0') == "0000")
            {
                this.LargeGoodsGanreCode.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.MediumGoodsGanreCode.Text)
                || this.MediumGoodsGanreCode.Text.PadLeft(4, '0') == "0000")
            {
                this.MediumGoodsGanreCode.Text = string.Empty;
            }

            if (string.IsNullOrEmpty(this.DetailGoodsGanreCode.Text)
                || this.DetailGoodsGanreCode.Text.PadLeft(5, '0') == "00000")
            {
                this.DetailGoodsGanreCode.Text = string.Empty;
            }
            // --- ADD 2009/02/27 --------------------------------<<<<<
               --- DEL 2009/03/27 不具合対応[12783] -------------------------<<<<< */
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
			
#if DEBUG
            return;
#endif

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

        // ---ADD 2009/03/27 不具合対応[12783] ---------------------------------->>>>>
        #region ◎ PageFooter_AfterPrint Event
        /// <summary>
        /// PageFooter_AfterPrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのアフタープリントイベント。</br>
        /// <br>Programmer	: 照田　貴志</br>
        /// <br>Date		: 2009/03/27</br>
        /// </remarks>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
            this._groupKey = string.Empty;
        }
        // ---ADD 2009/03/27 不具合対応[12783] ----------------------------------<<<<<
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
		private DataDynamics.ActiveReports.Label Lb_Customer;
		private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label Lb_GoodsName;
		private DataDynamics.ActiveReports.Label Lb_WarehouseShelfNo;
		private DataDynamics.ActiveReports.Label Lb_StockCreateDate;
		private DataDynamics.ActiveReports.Label Lb_SalesMoneyTaxExcOrder;
        private DataDynamics.ActiveReports.Label Lb_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.Label Lb_LargeGoodsGanreCode;
		private DataDynamics.ActiveReports.Label Lb_MediumGoodsGanreCode;
		private DataDynamics.ActiveReports.Label Lb_DetailGoodsGanreCode;
		private DataDynamics.ActiveReports.Label Lb_GoodsNo;
		private DataDynamics.ActiveReports.Label Lb_GrossProfitOrder;
		private DataDynamics.ActiveReports.Label Lb_GrossProfit;
		private DataDynamics.ActiveReports.Label Lb_ShipmentCntOrder;
		private DataDynamics.ActiveReports.Label Lb_ShipmentCnt;
		private DataDynamics.ActiveReports.Label Lb_ShipmentPosCnt;
		private DataDynamics.ActiveReports.Label Lb_MinimumStockCnt;
		private DataDynamics.ActiveReports.Label Lb_MaximumStockCnt;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
        private DataDynamics.ActiveReports.TextBox WarehouseCode;
		private DataDynamics.ActiveReports.TextBox WarehouseName;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox GoodsNo;
		private DataDynamics.ActiveReports.TextBox GoodsName;
		private DataDynamics.ActiveReports.TextBox WarehouseShelfNo;
		private DataDynamics.ActiveReports.TextBox StockCreateDate;
		private DataDynamics.ActiveReports.TextBox MaximumStockCnt;
		private DataDynamics.ActiveReports.TextBox MinimumStockCnt;
		private DataDynamics.ActiveReports.TextBox ShipmentPosCnt;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt;
		private DataDynamics.ActiveReports.TextBox ShipmentCntOrder;
		private DataDynamics.ActiveReports.TextBox GrossProfit;
		private DataDynamics.ActiveReports.TextBox GrossProfitOrder;
		private DataDynamics.ActiveReports.TextBox SalesMoneyTaxExcOrder;
		private DataDynamics.ActiveReports.TextBox SalesMoneyTaxExc;
        private DataDynamics.ActiveReports.TextBox CustomerCode;
		private DataDynamics.ActiveReports.TextBox LargeGoodsGanreCode;
		private DataDynamics.ActiveReports.TextBox MediumGoodsGanreCode;
		private DataDynamics.ActiveReports.TextBox DetailGoodsGanreCode;
		private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox SECTOTALTITLE;
		private DataDynamics.ActiveReports.TextBox Wh_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.TextBox Wh_GrossProfit;
        private DataDynamics.ActiveReports.TextBox Wh_ShipmentCnt;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label ALLTOTALTITLE;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Ttl_SalesMoneyTaxExc;
		private DataDynamics.ActiveReports.TextBox Ttl_GrossProfit;
		private DataDynamics.ActiveReports.TextBox Ttl_ShipmentCnt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCZAI02143P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.StockCreateDate = new DataDynamics.ActiveReports.TextBox();
            this.MaximumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.MinimumStockCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentPosCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCntOrder = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.LargeGoodsGanreCode = new DataDynamics.ActiveReports.TextBox();
            this.MediumGoodsGanreCode = new DataDynamics.ActiveReports.TextBox();
            this.DetailGoodsGanreCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.SalesMoneyTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.Dm2_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Dm2_ShipmentCntOrder = new DataDynamics.ActiveReports.TextBox();
            this.Dm2_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Dm2_GrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.Dm2_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Dm2_SalesMoneyTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.Dm1_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Dm1_ShipmentCntOrder = new DataDynamics.ActiveReports.TextBox();
            this.Dm1_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Dm1_GrossProfitOrder = new DataDynamics.ActiveReports.TextBox();
            this.Dm1_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Dm1_SalesMoneyTaxExcOrder = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_PrintSortOrder = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_WarehouseShelfNo = new DataDynamics.ActiveReports.Label();
            this.Lb_StockCreateDate = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GrossProfitOrder = new DataDynamics.ActiveReports.Label();
            this.Lb_GrossProfit = new DataDynamics.ActiveReports.Label();
            this.Lb_MinimumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_MaximumStockCnt = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Lb_LargeGoodsGanreCode = new DataDynamics.ActiveReports.Label();
            this.Lb_MediumGoodsGanreCode = new DataDynamics.ActiveReports.Label();
            this.Lb_DetailGoodsGanreCode = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoneyTaxExcOrder = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoneyTaxExc = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCntOrder = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentPosCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Lb_Customer = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Ttl_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Ttl_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Wh_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Wh_GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Wh_SalesMoneyTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.SectionTitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_Warehouse = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.SectionTitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediumGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_ShipmentCntOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_SalesMoneyTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_ShipmentCntOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_SalesMoneyTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfitOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LargeGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MediumGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DetailGoodsGanreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExcOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_SalesMoneyTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).BeginInit();
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
            this.StockCreateDate,
            this.MaximumStockCnt,
            this.MinimumStockCnt,
            this.ShipmentPosCnt,
            this.ShipmentCnt,
            this.ShipmentCntOrder,
            this.GrossProfit,
            this.GrossProfitOrder,
            this.SalesMoneyTaxExc,
            this.CustomerCode,
            this.LargeGoodsGanreCode,
            this.MediumGoodsGanreCode,
            this.DetailGoodsGanreCode,
            this.CustomerName,
            this.line4,
            this.SalesMoneyTaxExcOrder,
            this.GoodsMakerCd,
            this.Dm2_ShipmentCnt,
            this.Dm2_ShipmentCntOrder,
            this.Dm2_GrossProfit,
            this.Dm2_GrossProfitOrder,
            this.Dm2_SalesMoneyTaxExc,
            this.Dm2_SalesMoneyTaxExcOrder,
            this.Dm1_ShipmentCnt,
            this.Dm1_ShipmentCntOrder,
            this.Dm1_GrossProfit,
            this.Dm1_GrossProfitOrder,
            this.Dm1_SalesMoneyTaxExc,
            this.Dm1_SalesMoneyTaxExcOrder,
            this.textBox1,
            this.textBox2});
            this.Detail.Height = 0.8958333F;
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
            this.GoodsNo.Height = 0.16F;
            this.GoodsNo.Left = 2.25F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0.0625F;
            this.GoodsNo.Width = 1.375F;
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
            this.GoodsName.Height = 0.16F;
            this.GoodsName.Left = 3.625F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "12345678901234567890";
            this.GoodsName.Top = 0.0625F;
            this.GoodsName.Width = 1.1875F;
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
            this.WarehouseShelfNo.Height = 0.16F;
            this.WarehouseShelfNo.Left = 4.8125F;
            this.WarehouseShelfNo.MultiLine = false;
            this.WarehouseShelfNo.Name = "WarehouseShelfNo";
            this.WarehouseShelfNo.OutputFormat = resources.GetString("WarehouseShelfNo.OutputFormat");
            this.WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseShelfNo.Text = "12345678";
            this.WarehouseShelfNo.Top = 0.0625F;
            this.WarehouseShelfNo.Width = 0.5F;
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
            this.StockCreateDate.Height = 0.16F;
            this.StockCreateDate.Left = 8.8125F;
            this.StockCreateDate.MultiLine = false;
            this.StockCreateDate.Name = "StockCreateDate";
            this.StockCreateDate.OutputFormat = resources.GetString("StockCreateDate.OutputFormat");
            this.StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.StockCreateDate.Text = "99/99/99";
            this.StockCreateDate.Top = 0.0625F;
            this.StockCreateDate.Width = 0.5F;
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
            this.MaximumStockCnt.Height = 0.15625F;
            this.MaximumStockCnt.Left = 10.3125F;
            this.MaximumStockCnt.MultiLine = false;
            this.MaximumStockCnt.Name = "MaximumStockCnt";
            this.MaximumStockCnt.OutputFormat = resources.GetString("MaximumStockCnt.OutputFormat");
            this.MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MaximumStockCnt.Text = "123,456";
            this.MaximumStockCnt.Top = 0.0625F;
            this.MaximumStockCnt.Width = 0.4375F;
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
            this.MinimumStockCnt.Height = 0.15625F;
            this.MinimumStockCnt.Left = 9.875F;
            this.MinimumStockCnt.MultiLine = false;
            this.MinimumStockCnt.Name = "MinimumStockCnt";
            this.MinimumStockCnt.OutputFormat = resources.GetString("MinimumStockCnt.OutputFormat");
            this.MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.MinimumStockCnt.Text = "123,456";
            this.MinimumStockCnt.Top = 0.0625F;
            this.MinimumStockCnt.Width = 0.4375F;
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
            this.ShipmentPosCnt.Height = 0.16F;
            this.ShipmentPosCnt.Left = 9.3125F;
            this.ShipmentPosCnt.MultiLine = false;
            this.ShipmentPosCnt.Name = "ShipmentPosCnt";
            this.ShipmentPosCnt.OutputFormat = resources.GetString("ShipmentPosCnt.OutputFormat");
            this.ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentPosCnt.Text = "1,234,567";
            this.ShipmentPosCnt.Top = 0.0625F;
            this.ShipmentPosCnt.Width = 0.5625F;
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
            this.ShipmentCnt.Height = 0.16F;
            this.ShipmentCnt.Left = 8.125F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCnt.Text = "12,345,678";
            this.ShipmentCnt.Top = 0.0625F;
            this.ShipmentCnt.Width = 0.625F;
            // 
            // ShipmentCntOrder
            // 
            this.ShipmentCntOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCntOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCntOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntOrder.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCntOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntOrder.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCntOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCntOrder.DataField = "ShipmentCntOrder";
            this.ShipmentCntOrder.Height = 0.16F;
            this.ShipmentCntOrder.Left = 7.6875F;
            this.ShipmentCntOrder.MultiLine = false;
            this.ShipmentCntOrder.Name = "ShipmentCntOrder";
            this.ShipmentCntOrder.OutputFormat = resources.GetString("ShipmentCntOrder.OutputFormat");
            this.ShipmentCntOrder.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ShipmentCntOrder.Text = "123,456";
            this.ShipmentCntOrder.Top = 0.0625F;
            this.ShipmentCntOrder.Width = 0.4375F;
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
            this.GrossProfit.Height = 0.16F;
            this.GrossProfit.Left = 6.9375F;
            this.GrossProfit.MultiLine = false;
            this.GrossProfit.Name = "GrossProfit";
            this.GrossProfit.OutputFormat = resources.GetString("GrossProfit.OutputFormat");
            this.GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfit.Text = "1,234,567,890";
            this.GrossProfit.Top = 0.0625F;
            this.GrossProfit.Width = 0.75F;
            // 
            // GrossProfitOrder
            // 
            this.GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfitOrder.DataField = "GrossProfitOrder";
            this.GrossProfitOrder.Height = 0.16F;
            this.GrossProfitOrder.Left = 6.5F;
            this.GrossProfitOrder.MultiLine = false;
            this.GrossProfitOrder.Name = "GrossProfitOrder";
            this.GrossProfitOrder.OutputFormat = resources.GetString("GrossProfitOrder.OutputFormat");
            this.GrossProfitOrder.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.GrossProfitOrder.Text = "123,456";
            this.GrossProfitOrder.Top = 0.0625F;
            this.GrossProfitOrder.Width = 0.4375F;
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
            this.SalesMoneyTaxExc.Height = 0.16F;
            this.SalesMoneyTaxExc.Left = 5.75F;
            this.SalesMoneyTaxExc.MultiLine = false;
            this.SalesMoneyTaxExc.Name = "SalesMoneyTaxExc";
            this.SalesMoneyTaxExc.OutputFormat = resources.GetString("SalesMoneyTaxExc.OutputFormat");
            this.SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyTaxExc.Text = "1,234,567,890";
            this.SalesMoneyTaxExc.Top = 0.0625F;
            this.SalesMoneyTaxExc.Width = 0.75F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.15625F;
            this.CustomerCode.Left = 0.0625F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CustomerCode.Text = "123456";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.375F;
            // 
            // LargeGoodsGanreCode
            // 
            this.LargeGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.LargeGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LargeGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.LargeGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LargeGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.LargeGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LargeGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.LargeGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LargeGoodsGanreCode.DataField = "LargeGoodsGanreCode";
            this.LargeGoodsGanreCode.Height = 0.15625F;
            this.LargeGoodsGanreCode.Left = 1.25F;
            this.LargeGoodsGanreCode.MultiLine = false;
            this.LargeGoodsGanreCode.Name = "LargeGoodsGanreCode";
            this.LargeGoodsGanreCode.OutputFormat = resources.GetString("LargeGoodsGanreCode.OutputFormat");
            this.LargeGoodsGanreCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.LargeGoodsGanreCode.Text = "1234";
            this.LargeGoodsGanreCode.Top = 0.0625F;
            this.LargeGoodsGanreCode.Width = 0.3125F;
            // 
            // MediumGoodsGanreCode
            // 
            this.MediumGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.MediumGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MediumGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.MediumGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MediumGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.MediumGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MediumGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.MediumGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MediumGoodsGanreCode.DataField = "MediumGoodsGanreCode";
            this.MediumGoodsGanreCode.Height = 0.16F;
            this.MediumGoodsGanreCode.Left = 1.5625F;
            this.MediumGoodsGanreCode.MultiLine = false;
            this.MediumGoodsGanreCode.Name = "MediumGoodsGanreCode";
            this.MediumGoodsGanreCode.OutputFormat = resources.GetString("MediumGoodsGanreCode.OutputFormat");
            this.MediumGoodsGanreCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.MediumGoodsGanreCode.Text = "1234";
            this.MediumGoodsGanreCode.Top = 0.0625F;
            this.MediumGoodsGanreCode.Width = 0.3125F;
            // 
            // DetailGoodsGanreCode
            // 
            this.DetailGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.DetailGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.DetailGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.DetailGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.DetailGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DetailGoodsGanreCode.DataField = "DetailGoodsGanreCode";
            this.DetailGoodsGanreCode.Height = 0.16F;
            this.DetailGoodsGanreCode.Left = 1.875F;
            this.DetailGoodsGanreCode.MultiLine = false;
            this.DetailGoodsGanreCode.Name = "DetailGoodsGanreCode";
            this.DetailGoodsGanreCode.OutputFormat = resources.GetString("DetailGoodsGanreCode.OutputFormat");
            this.DetailGoodsGanreCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DetailGoodsGanreCode.Text = "12345";
            this.DetailGoodsGanreCode.Top = 0.0625F;
            this.DetailGoodsGanreCode.Width = 0.375F;
            // 
            // CustomerName
            // 
            this.CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.DataField = "CustomerName";
            this.CustomerName.Height = 0.16F;
            this.CustomerName.Left = 0.4375F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OutputFormat = resources.GetString("CustomerName.OutputFormat");
            this.CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerName.Text = "あいうえ";
            this.CustomerName.Top = 0.0625F;
            this.CustomerName.Width = 0.5F;
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
            // SalesMoneyTaxExcOrder
            // 
            this.SalesMoneyTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoneyTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoneyTaxExcOrder.DataField = "SalesMoneyTaxExcOrder";
            this.SalesMoneyTaxExcOrder.Height = 0.16F;
            this.SalesMoneyTaxExcOrder.Left = 5.3125F;
            this.SalesMoneyTaxExcOrder.MultiLine = false;
            this.SalesMoneyTaxExcOrder.Name = "SalesMoneyTaxExcOrder";
            this.SalesMoneyTaxExcOrder.OutputFormat = resources.GetString("SalesMoneyTaxExcOrder.OutputFormat");
            this.SalesMoneyTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesMoneyTaxExcOrder.Text = "123,456";
            this.SalesMoneyTaxExcOrder.Top = 0.0625F;
            this.SalesMoneyTaxExcOrder.Width = 0.4375F;
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
            this.GoodsMakerCd.Height = 0.15625F;
            this.GoodsMakerCd.Left = 0.9375F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "0000";
            this.GoodsMakerCd.Top = 0.0625F;
            this.GoodsMakerCd.Width = 0.3125F;
            // 
            // Dm2_ShipmentCnt
            // 
            this.Dm2_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCnt.DataField = "ShipmentCnt";
            this.Dm2_ShipmentCnt.Height = 0.16F;
            this.Dm2_ShipmentCnt.Left = 5.75F;
            this.Dm2_ShipmentCnt.MultiLine = false;
            this.Dm2_ShipmentCnt.Name = "Dm2_ShipmentCnt";
            this.Dm2_ShipmentCnt.OutputFormat = resources.GetString("Dm2_ShipmentCnt.OutputFormat");
            this.Dm2_ShipmentCnt.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm2_ShipmentCnt.Text = "12,345,678";
            this.Dm2_ShipmentCnt.Top = 0.625F;
            this.Dm2_ShipmentCnt.Visible = false;
            this.Dm2_ShipmentCnt.Width = 0.625F;
            // 
            // Dm2_ShipmentCntOrder
            // 
            this.Dm2_ShipmentCntOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCntOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCntOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCntOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCntOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCntOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCntOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Dm2_ShipmentCntOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_ShipmentCntOrder.DataField = "ShipmentCntOrder";
            this.Dm2_ShipmentCntOrder.Height = 0.16F;
            this.Dm2_ShipmentCntOrder.Left = 5.3125F;
            this.Dm2_ShipmentCntOrder.MultiLine = false;
            this.Dm2_ShipmentCntOrder.Name = "Dm2_ShipmentCntOrder";
            this.Dm2_ShipmentCntOrder.OutputFormat = resources.GetString("Dm2_ShipmentCntOrder.OutputFormat");
            this.Dm2_ShipmentCntOrder.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm2_ShipmentCntOrder.Text = "123,456";
            this.Dm2_ShipmentCntOrder.Top = 0.625F;
            this.Dm2_ShipmentCntOrder.Visible = false;
            this.Dm2_ShipmentCntOrder.Width = 0.4375F;
            // 
            // Dm2_GrossProfit
            // 
            this.Dm2_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfit.DataField = "GrossProfit";
            this.Dm2_GrossProfit.Height = 0.16F;
            this.Dm2_GrossProfit.Left = 8F;
            this.Dm2_GrossProfit.MultiLine = false;
            this.Dm2_GrossProfit.Name = "Dm2_GrossProfit";
            this.Dm2_GrossProfit.OutputFormat = resources.GetString("Dm2_GrossProfit.OutputFormat");
            this.Dm2_GrossProfit.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm2_GrossProfit.Text = "1,234,567,890";
            this.Dm2_GrossProfit.Top = 0.625F;
            this.Dm2_GrossProfit.Visible = false;
            this.Dm2_GrossProfit.Width = 0.75F;
            // 
            // Dm2_GrossProfitOrder
            // 
            this.Dm2_GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Dm2_GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_GrossProfitOrder.DataField = "GrossProfitOrder";
            this.Dm2_GrossProfitOrder.Height = 0.16F;
            this.Dm2_GrossProfitOrder.Left = 7.5625F;
            this.Dm2_GrossProfitOrder.MultiLine = false;
            this.Dm2_GrossProfitOrder.Name = "Dm2_GrossProfitOrder";
            this.Dm2_GrossProfitOrder.OutputFormat = resources.GetString("Dm2_GrossProfitOrder.OutputFormat");
            this.Dm2_GrossProfitOrder.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm2_GrossProfitOrder.Text = "123,456";
            this.Dm2_GrossProfitOrder.Top = 0.625F;
            this.Dm2_GrossProfitOrder.Visible = false;
            this.Dm2_GrossProfitOrder.Width = 0.4375F;
            // 
            // Dm2_SalesMoneyTaxExc
            // 
            this.Dm2_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Dm2_SalesMoneyTaxExc.Height = 0.16F;
            this.Dm2_SalesMoneyTaxExc.Left = 6.8125F;
            this.Dm2_SalesMoneyTaxExc.MultiLine = false;
            this.Dm2_SalesMoneyTaxExc.Name = "Dm2_SalesMoneyTaxExc";
            this.Dm2_SalesMoneyTaxExc.OutputFormat = resources.GetString("Dm2_SalesMoneyTaxExc.OutputFormat");
            this.Dm2_SalesMoneyTaxExc.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm2_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Dm2_SalesMoneyTaxExc.Top = 0.625F;
            this.Dm2_SalesMoneyTaxExc.Visible = false;
            this.Dm2_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Dm2_SalesMoneyTaxExcOrder
            // 
            this.Dm2_SalesMoneyTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Dm2_SalesMoneyTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm2_SalesMoneyTaxExcOrder.DataField = "SalesMoneyTaxExcOrder";
            this.Dm2_SalesMoneyTaxExcOrder.Height = 0.16F;
            this.Dm2_SalesMoneyTaxExcOrder.Left = 6.375F;
            this.Dm2_SalesMoneyTaxExcOrder.MultiLine = false;
            this.Dm2_SalesMoneyTaxExcOrder.Name = "Dm2_SalesMoneyTaxExcOrder";
            this.Dm2_SalesMoneyTaxExcOrder.OutputFormat = resources.GetString("Dm2_SalesMoneyTaxExcOrder.OutputFormat");
            this.Dm2_SalesMoneyTaxExcOrder.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm2_SalesMoneyTaxExcOrder.Text = "123,456";
            this.Dm2_SalesMoneyTaxExcOrder.Top = 0.625F;
            this.Dm2_SalesMoneyTaxExcOrder.Visible = false;
            this.Dm2_SalesMoneyTaxExcOrder.Width = 0.4375F;
            // 
            // Dm1_ShipmentCnt
            // 
            this.Dm1_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCnt.DataField = "ShipmentCnt";
            this.Dm1_ShipmentCnt.Height = 0.16F;
            this.Dm1_ShipmentCnt.Left = 8.125F;
            this.Dm1_ShipmentCnt.MultiLine = false;
            this.Dm1_ShipmentCnt.Name = "Dm1_ShipmentCnt";
            this.Dm1_ShipmentCnt.OutputFormat = resources.GetString("Dm1_ShipmentCnt.OutputFormat");
            this.Dm1_ShipmentCnt.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm1_ShipmentCnt.Text = "12,345,678";
            this.Dm1_ShipmentCnt.Top = 0.375F;
            this.Dm1_ShipmentCnt.Visible = false;
            this.Dm1_ShipmentCnt.Width = 0.625F;
            // 
            // Dm1_ShipmentCntOrder
            // 
            this.Dm1_ShipmentCntOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCntOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCntOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCntOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCntOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCntOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCntOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Dm1_ShipmentCntOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_ShipmentCntOrder.DataField = "ShipmentCntOrder";
            this.Dm1_ShipmentCntOrder.Height = 0.16F;
            this.Dm1_ShipmentCntOrder.Left = 7.6875F;
            this.Dm1_ShipmentCntOrder.MultiLine = false;
            this.Dm1_ShipmentCntOrder.Name = "Dm1_ShipmentCntOrder";
            this.Dm1_ShipmentCntOrder.OutputFormat = resources.GetString("Dm1_ShipmentCntOrder.OutputFormat");
            this.Dm1_ShipmentCntOrder.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm1_ShipmentCntOrder.Text = "123,456";
            this.Dm1_ShipmentCntOrder.Top = 0.375F;
            this.Dm1_ShipmentCntOrder.Visible = false;
            this.Dm1_ShipmentCntOrder.Width = 0.4375F;
            // 
            // Dm1_GrossProfit
            // 
            this.Dm1_GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfit.DataField = "GrossProfit";
            this.Dm1_GrossProfit.Height = 0.16F;
            this.Dm1_GrossProfit.Left = 5.75F;
            this.Dm1_GrossProfit.MultiLine = false;
            this.Dm1_GrossProfit.Name = "Dm1_GrossProfit";
            this.Dm1_GrossProfit.OutputFormat = resources.GetString("Dm1_GrossProfit.OutputFormat");
            this.Dm1_GrossProfit.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm1_GrossProfit.Text = "1,234,567,890";
            this.Dm1_GrossProfit.Top = 0.375F;
            this.Dm1_GrossProfit.Visible = false;
            this.Dm1_GrossProfit.Width = 0.75F;
            // 
            // Dm1_GrossProfitOrder
            // 
            this.Dm1_GrossProfitOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfitOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfitOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfitOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfitOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfitOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfitOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Dm1_GrossProfitOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_GrossProfitOrder.DataField = "GrossProfitOrder";
            this.Dm1_GrossProfitOrder.Height = 0.16F;
            this.Dm1_GrossProfitOrder.Left = 5.3125F;
            this.Dm1_GrossProfitOrder.MultiLine = false;
            this.Dm1_GrossProfitOrder.Name = "Dm1_GrossProfitOrder";
            this.Dm1_GrossProfitOrder.OutputFormat = resources.GetString("Dm1_GrossProfitOrder.OutputFormat");
            this.Dm1_GrossProfitOrder.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm1_GrossProfitOrder.Text = "123,456";
            this.Dm1_GrossProfitOrder.Top = 0.375F;
            this.Dm1_GrossProfitOrder.Visible = false;
            this.Dm1_GrossProfitOrder.Width = 0.4375F;
            // 
            // Dm1_SalesMoneyTaxExc
            // 
            this.Dm1_SalesMoneyTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExc.DataField = "SalesMoneyTaxExc";
            this.Dm1_SalesMoneyTaxExc.Height = 0.16F;
            this.Dm1_SalesMoneyTaxExc.Left = 6.9375F;
            this.Dm1_SalesMoneyTaxExc.MultiLine = false;
            this.Dm1_SalesMoneyTaxExc.Name = "Dm1_SalesMoneyTaxExc";
            this.Dm1_SalesMoneyTaxExc.OutputFormat = resources.GetString("Dm1_SalesMoneyTaxExc.OutputFormat");
            this.Dm1_SalesMoneyTaxExc.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm1_SalesMoneyTaxExc.Text = "1,234,567,890";
            this.Dm1_SalesMoneyTaxExc.Top = 0.375F;
            this.Dm1_SalesMoneyTaxExc.Visible = false;
            this.Dm1_SalesMoneyTaxExc.Width = 0.75F;
            // 
            // Dm1_SalesMoneyTaxExcOrder
            // 
            this.Dm1_SalesMoneyTaxExcOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExcOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExcOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExcOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExcOrder.Border.RightColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExcOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExcOrder.Border.TopColor = System.Drawing.Color.Black;
            this.Dm1_SalesMoneyTaxExcOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Dm1_SalesMoneyTaxExcOrder.DataField = "SalesMoneyTaxExcOrder";
            this.Dm1_SalesMoneyTaxExcOrder.Height = 0.16F;
            this.Dm1_SalesMoneyTaxExcOrder.Left = 6.5F;
            this.Dm1_SalesMoneyTaxExcOrder.MultiLine = false;
            this.Dm1_SalesMoneyTaxExcOrder.Name = "Dm1_SalesMoneyTaxExcOrder";
            this.Dm1_SalesMoneyTaxExcOrder.OutputFormat = resources.GetString("Dm1_SalesMoneyTaxExcOrder.OutputFormat");
            this.Dm1_SalesMoneyTaxExcOrder.Style = "color: Gray; ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: Ｍ" +
                "Ｓ ゴシック; vertical-align: top; ";
            this.Dm1_SalesMoneyTaxExcOrder.Text = "123,456";
            this.Dm1_SalesMoneyTaxExcOrder.Top = 0.375F;
            this.Dm1_SalesMoneyTaxExcOrder.Visible = false;
            this.Dm1_SalesMoneyTaxExcOrder.Width = 0.4375F;
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
            this.textBox1.Height = 0.16F;
            this.textBox1.Left = 8.8125F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "color: Gray; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8" +
                "pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.textBox1.Text = "←出力順：粗利額順時の項目位置";
            this.textBox1.Top = 0.375F;
            this.textBox1.Visible = false;
            this.textBox1.Width = 1.8125F;
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
            this.textBox2.Height = 0.16F;
            this.textBox2.Left = 8.8125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "color: Gray; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: 8" +
                "pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.textBox2.Text = "←出力順：出荷数順時の項目位置";
            this.textBox2.Top = 0.625F;
            this.textBox2.Visible = false;
            this.textBox2.Width = 1.8125F;
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
            this.tb_PrintSortOrder});
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
            this.tb_ReportTitle.Text = "在庫分析順位表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.5F;
            // 
            // tb_PrintSortOrder
            // 
            this.tb_PrintSortOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintSortOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintSortOrder.Height = 0.125F;
            this.tb_PrintSortOrder.Left = 3F;
            this.tb_PrintSortOrder.MultiLine = false;
            this.tb_PrintSortOrder.Name = "tb_PrintSortOrder";
            this.tb_PrintSortOrder.OutputFormat = resources.GetString("tb_PrintSortOrder.OutputFormat");
            this.tb_PrintSortOrder.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.tb_PrintSortOrder.Text = "あいうえおかきくけこ";
            this.tb_PrintSortOrder.Top = 0.0625F;
            this.tb_PrintSortOrder.Width = 1.1875F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2604167F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.PageFooter.AfterPrint += new System.EventHandler(this.PageFooter_AfterPrint);
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
            this.Lb_WarehouseShelfNo,
            this.Lb_StockCreateDate,
            this.Lb_GoodsNo,
            this.Lb_GrossProfitOrder,
            this.Lb_GrossProfit,
            this.Lb_MinimumStockCnt,
            this.Lb_MaximumStockCnt,
            this.Line,
            this.Lb_LargeGoodsGanreCode,
            this.Lb_MediumGoodsGanreCode,
            this.Lb_DetailGoodsGanreCode,
            this.Lb_GoodsName,
            this.Lb_SalesMoneyTaxExcOrder,
            this.Lb_SalesMoneyTaxExc,
            this.Lb_ShipmentCntOrder,
            this.Lb_ShipmentPosCnt,
            this.Lb_ShipmentCnt,
            this.label1,
            this.Lb_Customer});
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
            this.Lb_WarehouseShelfNo.Height = 0.15625F;
            this.Lb_WarehouseShelfNo.HyperLink = "";
            this.Lb_WarehouseShelfNo.Left = 4.8125F;
            this.Lb_WarehouseShelfNo.MultiLine = false;
            this.Lb_WarehouseShelfNo.Name = "Lb_WarehouseShelfNo";
            this.Lb_WarehouseShelfNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_WarehouseShelfNo.Text = "棚番";
            this.Lb_WarehouseShelfNo.Top = 0F;
            this.Lb_WarehouseShelfNo.Width = 0.5F;
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
            this.Lb_StockCreateDate.Height = 0.16F;
            this.Lb_StockCreateDate.HyperLink = "";
            this.Lb_StockCreateDate.Left = 8.8125F;
            this.Lb_StockCreateDate.MultiLine = false;
            this.Lb_StockCreateDate.Name = "Lb_StockCreateDate";
            this.Lb_StockCreateDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_StockCreateDate.Text = "在庫登録日";
            this.Lb_StockCreateDate.Top = 0F;
            this.Lb_StockCreateDate.Width = 0.625F;
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
            this.Lb_GoodsNo.Height = 0.16F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 2.25F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0F;
            this.Lb_GoodsNo.Width = 1.375F;
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
            this.Lb_GrossProfitOrder.Height = 0.15625F;
            this.Lb_GrossProfitOrder.HyperLink = "";
            this.Lb_GrossProfitOrder.Left = 6.5F;
            this.Lb_GrossProfitOrder.MultiLine = false;
            this.Lb_GrossProfitOrder.Name = "Lb_GrossProfitOrder";
            this.Lb_GrossProfitOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrossProfitOrder.Text = "順位";
            this.Lb_GrossProfitOrder.Top = 0F;
            this.Lb_GrossProfitOrder.Width = 0.4375F;
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
            this.Lb_GrossProfit.Left = 6.9375F;
            this.Lb_GrossProfit.MultiLine = false;
            this.Lb_GrossProfit.Name = "Lb_GrossProfit";
            this.Lb_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GrossProfit.Text = "粗利額";
            this.Lb_GrossProfit.Top = 0F;
            this.Lb_GrossProfit.Width = 0.75F;
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
            this.Lb_MinimumStockCnt.Height = 0.16F;
            this.Lb_MinimumStockCnt.HyperLink = "";
            this.Lb_MinimumStockCnt.Left = 9.875F;
            this.Lb_MinimumStockCnt.MultiLine = false;
            this.Lb_MinimumStockCnt.Name = "Lb_MinimumStockCnt";
            this.Lb_MinimumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MinimumStockCnt.Text = "最低数";
            this.Lb_MinimumStockCnt.Top = 0F;
            this.Lb_MinimumStockCnt.Width = 0.4375F;
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
            this.Lb_MaximumStockCnt.Height = 0.16F;
            this.Lb_MaximumStockCnt.HyperLink = "";
            this.Lb_MaximumStockCnt.Left = 10.3125F;
            this.Lb_MaximumStockCnt.MultiLine = false;
            this.Lb_MaximumStockCnt.Name = "Lb_MaximumStockCnt";
            this.Lb_MaximumStockCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MaximumStockCnt.Text = "最高数";
            this.Lb_MaximumStockCnt.Top = 0F;
            this.Lb_MaximumStockCnt.Width = 0.4375F;
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
            this.Line.Top = 0.1875F;
            this.Line.Width = 10.8125F;
            this.Line.X1 = 0F;
            this.Line.X2 = 10.8125F;
            this.Line.Y1 = 0.1875F;
            this.Line.Y2 = 0.1875F;
            // 
            // Lb_LargeGoodsGanreCode
            // 
            this.Lb_LargeGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_LargeGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LargeGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_LargeGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LargeGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_LargeGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LargeGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_LargeGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LargeGoodsGanreCode.Height = 0.16F;
            this.Lb_LargeGoodsGanreCode.HyperLink = "";
            this.Lb_LargeGoodsGanreCode.Left = 1.25F;
            this.Lb_LargeGoodsGanreCode.MultiLine = false;
            this.Lb_LargeGoodsGanreCode.Name = "Lb_LargeGoodsGanreCode";
            this.Lb_LargeGoodsGanreCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_LargeGoodsGanreCode.Text = "商大";
            this.Lb_LargeGoodsGanreCode.Top = 0F;
            this.Lb_LargeGoodsGanreCode.Width = 0.3125F;
            // 
            // Lb_MediumGoodsGanreCode
            // 
            this.Lb_MediumGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MediumGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MediumGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MediumGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MediumGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MediumGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MediumGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MediumGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MediumGoodsGanreCode.Height = 0.16F;
            this.Lb_MediumGoodsGanreCode.HyperLink = "";
            this.Lb_MediumGoodsGanreCode.Left = 1.5625F;
            this.Lb_MediumGoodsGanreCode.MultiLine = false;
            this.Lb_MediumGoodsGanreCode.Name = "Lb_MediumGoodsGanreCode";
            this.Lb_MediumGoodsGanreCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MediumGoodsGanreCode.Text = "商中";
            this.Lb_MediumGoodsGanreCode.Top = 0F;
            this.Lb_MediumGoodsGanreCode.Width = 0.3125F;
            // 
            // Lb_DetailGoodsGanreCode
            // 
            this.Lb_DetailGoodsGanreCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DetailGoodsGanreCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailGoodsGanreCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DetailGoodsGanreCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailGoodsGanreCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DetailGoodsGanreCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailGoodsGanreCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DetailGoodsGanreCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DetailGoodsGanreCode.Height = 0.16F;
            this.Lb_DetailGoodsGanreCode.HyperLink = "";
            this.Lb_DetailGoodsGanreCode.Left = 1.875F;
            this.Lb_DetailGoodsGanreCode.MultiLine = false;
            this.Lb_DetailGoodsGanreCode.Name = "Lb_DetailGoodsGanreCode";
            this.Lb_DetailGoodsGanreCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DetailGoodsGanreCode.Text = "ｸﾞﾙｰﾌﾟ";
            this.Lb_DetailGoodsGanreCode.Top = 0F;
            this.Lb_DetailGoodsGanreCode.Width = 0.375F;
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
            this.Lb_GoodsName.Height = 0.16F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 3.625F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0F;
            this.Lb_GoodsName.Width = 1.1875F;
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
            this.Lb_SalesMoneyTaxExcOrder.Height = 0.15625F;
            this.Lb_SalesMoneyTaxExcOrder.HyperLink = "";
            this.Lb_SalesMoneyTaxExcOrder.Left = 5.3125F;
            this.Lb_SalesMoneyTaxExcOrder.MultiLine = false;
            this.Lb_SalesMoneyTaxExcOrder.Name = "Lb_SalesMoneyTaxExcOrder";
            this.Lb_SalesMoneyTaxExcOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesMoneyTaxExcOrder.Text = "順位";
            this.Lb_SalesMoneyTaxExcOrder.Top = 0F;
            this.Lb_SalesMoneyTaxExcOrder.Width = 0.4375F;
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
            this.Lb_SalesMoneyTaxExc.Left = 5.75F;
            this.Lb_SalesMoneyTaxExc.MultiLine = false;
            this.Lb_SalesMoneyTaxExc.Name = "Lb_SalesMoneyTaxExc";
            this.Lb_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesMoneyTaxExc.Text = "売上金額";
            this.Lb_SalesMoneyTaxExc.Top = 0F;
            this.Lb_SalesMoneyTaxExc.Width = 0.75F;
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
            this.Lb_ShipmentCntOrder.Height = 0.15625F;
            this.Lb_ShipmentCntOrder.HyperLink = "";
            this.Lb_ShipmentCntOrder.Left = 7.6875F;
            this.Lb_ShipmentCntOrder.MultiLine = false;
            this.Lb_ShipmentCntOrder.Name = "Lb_ShipmentCntOrder";
            this.Lb_ShipmentCntOrder.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCntOrder.Text = "順位";
            this.Lb_ShipmentCntOrder.Top = 0F;
            this.Lb_ShipmentCntOrder.Width = 0.4375F;
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
            this.Lb_ShipmentPosCnt.Height = 0.16F;
            this.Lb_ShipmentPosCnt.HyperLink = "";
            this.Lb_ShipmentPosCnt.Left = 9.4375F;
            this.Lb_ShipmentPosCnt.MultiLine = false;
            this.Lb_ShipmentPosCnt.Name = "Lb_ShipmentPosCnt";
            this.Lb_ShipmentPosCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentPosCnt.Text = "現在数";
            this.Lb_ShipmentPosCnt.Top = 0F;
            this.Lb_ShipmentPosCnt.Width = 0.4375F;
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
            this.Lb_ShipmentCnt.Height = 0.15625F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 8.125F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ShipmentCnt.Text = "出荷数";
            this.Lb_ShipmentCnt.Top = 0F;
            this.Lb_ShipmentCnt.Width = 0.625F;
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
            this.label1.Height = 0.16F;
            this.label1.HyperLink = "";
            this.label1.Left = 0.9375F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "ﾒｰｶｰ";
            this.label1.Top = 0F;
            this.label1.Width = 0.3125F;
            // 
            // Lb_Customer
            // 
            this.Lb_Customer.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Height = 0.16F;
            this.Lb_Customer.HyperLink = "";
            this.Lb_Customer.Left = 0.0625F;
            this.Lb_Customer.MultiLine = false;
            this.Lb_Customer.Name = "Lb_Customer";
            this.Lb_Customer.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer.Text = "仕入先";
            this.Lb_Customer.Top = 0F;
            this.Lb_Customer.Width = 0.875F;
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
            this.ALLTOTALTITLE,
            this.Line43,
            this.Ttl_SalesMoneyTaxExc,
            this.Ttl_GrossProfit,
            this.Ttl_ShipmentCnt});
            this.GrandTotalFooter.Height = 0.2291667F;
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
            this.ALLTOTALTITLE.Height = 0.219F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 4.75F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.03F;
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
            this.Ttl_SalesMoneyTaxExc.Left = 5.3125F;
            this.Ttl_SalesMoneyTaxExc.MultiLine = false;
            this.Ttl_SalesMoneyTaxExc.Name = "Ttl_SalesMoneyTaxExc";
            this.Ttl_SalesMoneyTaxExc.OutputFormat = resources.GetString("Ttl_SalesMoneyTaxExc.OutputFormat");
            this.Ttl_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_SalesMoneyTaxExc.Text = "12,345,678,901";
            this.Ttl_SalesMoneyTaxExc.Top = 0.03F;
            this.Ttl_SalesMoneyTaxExc.Width = 1.1875F;
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
            this.Ttl_GrossProfit.Left = 6.5F;
            this.Ttl_GrossProfit.MultiLine = false;
            this.Ttl_GrossProfit.Name = "Ttl_GrossProfit";
            this.Ttl_GrossProfit.OutputFormat = resources.GetString("Ttl_GrossProfit.OutputFormat");
            this.Ttl_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_GrossProfit.Text = "12,345,678,901";
            this.Ttl_GrossProfit.Top = 0.03F;
            this.Ttl_GrossProfit.Width = 1.1875F;
            // 
            // Ttl_ShipmentCnt
            // 
            this.Ttl_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Ttl_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ttl_ShipmentCnt.DataField = "ShipmentCnt";
            this.Ttl_ShipmentCnt.Height = 0.16F;
            this.Ttl_ShipmentCnt.Left = 7.6875F;
            this.Ttl_ShipmentCnt.MultiLine = false;
            this.Ttl_ShipmentCnt.Name = "Ttl_ShipmentCnt";
            this.Ttl_ShipmentCnt.OutputFormat = resources.GetString("Ttl_ShipmentCnt.OutputFormat");
            this.Ttl_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Ttl_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Ttl_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Ttl_ShipmentCnt.Text = "12,345,678";
            this.Ttl_ShipmentCnt.Top = 0.03F;
            this.Ttl_ShipmentCnt.Width = 1.0625F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.WarehouseCode,
            this.WarehouseName});
            this.WarehouseHeader.DataField = "Sort_WarehouseCode";
            this.WarehouseHeader.Height = 0.25F;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.WarehouseHeader.BeforePrint += new System.EventHandler(this.WarehouseHeader_BeforePrint);
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
            this.WarehouseCode.Left = 0F;
            this.WarehouseCode.MultiLine = false;
            this.WarehouseCode.Name = "WarehouseCode";
            this.WarehouseCode.OutputFormat = resources.GetString("WarehouseCode.OutputFormat");
            this.WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.WarehouseCode.Text = "1234";
            this.WarehouseCode.Top = 0.042F;
            this.WarehouseCode.Width = 0.308F;
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
            this.WarehouseName.Height = 0.15625F;
            this.WarehouseName.Left = 0.3125F;
            this.WarehouseName.MultiLine = false;
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OutputFormat = resources.GetString("WarehouseName.OutputFormat");
            this.WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.WarehouseName.Text = "あいうえおか";
            this.WarehouseName.Top = 0.042F;
            this.WarehouseName.Width = 0.758F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.Wh_ShipmentCnt,
            this.Wh_GrossProfit,
            this.Wh_SalesMoneyTaxExc});
            this.WarehouseFooter.Height = 0.2291667F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
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
            // SECTOTALTITLE
            // 
            this.SECTOTALTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SECTOTALTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SECTOTALTITLE.Height = 0.219F;
            this.SECTOTALTITLE.Left = 4.75F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SECTOTALTITLE.Text = "倉庫計";
            this.SECTOTALTITLE.Top = 0.03F;
            this.SECTOTALTITLE.Width = 0.5625F;
            // 
            // Wh_ShipmentCnt
            // 
            this.Wh_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_ShipmentCnt.DataField = "ShipmentCnt";
            this.Wh_ShipmentCnt.Height = 0.1565F;
            this.Wh_ShipmentCnt.Left = 7.6875F;
            this.Wh_ShipmentCnt.MultiLine = false;
            this.Wh_ShipmentCnt.Name = "Wh_ShipmentCnt";
            this.Wh_ShipmentCnt.OutputFormat = resources.GetString("Wh_ShipmentCnt.OutputFormat");
            this.Wh_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_ShipmentCnt.SummaryGroup = "WarehouseHeader";
            this.Wh_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_ShipmentCnt.Text = "12,345,678";
            this.Wh_ShipmentCnt.Top = 0.03F;
            this.Wh_ShipmentCnt.Width = 1.0625F;
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
            this.Wh_GrossProfit.Left = 6.5F;
            this.Wh_GrossProfit.MultiLine = false;
            this.Wh_GrossProfit.Name = "Wh_GrossProfit";
            this.Wh_GrossProfit.OutputFormat = resources.GetString("Wh_GrossProfit.OutputFormat");
            this.Wh_GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_GrossProfit.SummaryGroup = "WarehouseHeader";
            this.Wh_GrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_GrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_GrossProfit.Text = "12,345,678,901";
            this.Wh_GrossProfit.Top = 0.03F;
            this.Wh_GrossProfit.Width = 1.1875F;
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
            this.Wh_SalesMoneyTaxExc.Left = 5.3125F;
            this.Wh_SalesMoneyTaxExc.MultiLine = false;
            this.Wh_SalesMoneyTaxExc.Name = "Wh_SalesMoneyTaxExc";
            this.Wh_SalesMoneyTaxExc.OutputFormat = resources.GetString("Wh_SalesMoneyTaxExc.OutputFormat");
            this.Wh_SalesMoneyTaxExc.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Wh_SalesMoneyTaxExc.SummaryGroup = "WarehouseHeader";
            this.Wh_SalesMoneyTaxExc.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Wh_SalesMoneyTaxExc.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Wh_SalesMoneyTaxExc.Text = "12,345,678,901";
            this.Wh_SalesMoneyTaxExc.Top = 0.03F;
            this.Wh_SalesMoneyTaxExc.Width = 1.1875F;
            // 
            // SectionTitleHeader
            // 
            this.SectionTitleHeader.CanShrink = true;
            this.SectionTitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Lb_Warehouse,
            this.line3});
            this.SectionTitleHeader.Height = 0.1875F;
            this.SectionTitleHeader.Name = "SectionTitleHeader";
            this.SectionTitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Lb_Warehouse.Height = 0.15625F;
            this.Lb_Warehouse.HyperLink = "";
            this.Lb_Warehouse.Left = 0F;
            this.Lb_Warehouse.MultiLine = false;
            this.Lb_Warehouse.Name = "Lb_Warehouse";
            this.Lb_Warehouse.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Warehouse.Text = "倉庫";
            this.Lb_Warehouse.Top = 0F;
            this.Lb_Warehouse.Width = 1.0625F;
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
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // SectionTitleFooter
            // 
            this.SectionTitleFooter.Height = 0.25F;
            this.SectionTitleFooter.Name = "SectionTitleFooter";
            // 
            // DCZAI02143P_01A4C
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
            this.Sections.Add(this.SectionTitleHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.WarehouseFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.SectionTitleFooter);
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
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCntOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediumGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoneyTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_ShipmentCntOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm2_SalesMoneyTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_ShipmentCntOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dm1_SalesMoneyTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockCreateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfitOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MinimumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MaximumStockCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LargeGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MediumGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DetailGoodsGanreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExcOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCntOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentPosCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ttl_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_SalesMoneyTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Warehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
