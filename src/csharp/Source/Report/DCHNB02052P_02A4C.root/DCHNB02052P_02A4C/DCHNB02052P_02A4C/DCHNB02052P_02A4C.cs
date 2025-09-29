//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上順位表
// プログラム概要   : 売上順位表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2008/09/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/07  修正内容 : 障害対応13155
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【13127】残案件No.19 端数処理
//----------------------------------------------------------------------------//

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
	/// 売上順位表(BLコード別)印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 売上順位表のフォームクラスです。</br>
	/// <br>Programmer	: 30452 上野 俊治</br>
	/// <br>Date		: 2008.09.24</br>
    /// <br>Update Note : 2009/04/07 30452 上野 俊治</br>
    /// <br>            ・障害対応13155</br>
	/// <br></br>
	/// </remarks>
	public class DCHNB02052P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
		/// 出荷商品順位表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 出荷商品順位表フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 96186　立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		public DCHNB02052P_02A4C()
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

		private ShipmGoodsOdrReport _shipmGoodsOdrReport;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        // サプレスバッファ
        private Label Lb_GoodsMakerCd;
		private TextBox OrderNo;
        private Label label16;
        private TextBox textBox11;
        private Line line3;
        private TextBox MakerName;
        private Label Lb_BLGoodsHalfName;
        private GroupHeader GoodsMGroupHeader;
        private GroupFooter GoodsMGroupFooter;
        private TextBox textBox7;
        private GroupHeader SuplierHeader;
        private GroupFooter SuplierFooter;
        private TextBox textBox13;
        private Line line7;
        private Line line4;
        private GroupHeader GoodsLGroupHeader;
        private GroupFooter GoodsLGroupFooter;
        private TextBox GoodsLGroup;
        private TextBox GoodsMGroup;
        private Label label5;
        private TextBox BLGroupCode;
        private TextBox BLGoodsCode;
        private TextBox BLGoodsHalfName;
        private TextBox TotalSalesCount;
        private TextBox TotalSalesMoney;
        private TextBox CmpPureSalesRatio;
        private TextBox GrossProfit;
        private TextBox ProfitRatio;
        private TextBox CmpProfitRatio;
        private TextBox textBox6;
        private TextBox GoodsMGroupName;
        private TextBox GoodsLGroupName;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox mgTotalSalesCount;
        private TextBox mgTotalSalesMoney;
        private TextBox mgGrossProfit;
        private TextBox mgCmpPureSalesRatio;
        private TextBox mgProfitRatio;
        private TextBox mgCmpProfitRatio;
        private TextBox lgTotalSalesCount;
        private TextBox lgTotalSalesMoney;
        private TextBox lgGrossProfit;
        private TextBox lgCmpPureSalesRatio;
        private TextBox lgProfitRatio;
        private TextBox lgCmpProfitRatio;
        private TextBox mkTotalSalesCount;
        private TextBox mkTotalSalesMoney;
        private TextBox mkGrossProfit;
        private TextBox mkCmpPureSalesRatio;
        private TextBox mkProfitRatio;
        private TextBox mkCmpProfitRatio;
        private TextBox suTotalSalesCount;
        private TextBox suTotalSalesMoney;
        private TextBox suGrossProfit;
        private TextBox suCmpPureSalesRatio;
        private TextBox suProfitRatio;
        private TextBox suCmpProfitRatio;
        private TextBox seTotalSalesCount;
        private TextBox seTotalSalesMoney;
        private TextBox seGrossProfit;
        private TextBox seCmpPureSalesRatio;
        private TextBox seProfitRatio;
        private TextBox seCmpProfitRatio;
        private TextBox toTotalSalesCount;
        private TextBox toTotalSalesMoney;
        private TextBox toGrossProfit;
        private TextBox toCmpPureSalesRatio;
        private TextBox toProfitRatio;
        private TextBox toCmpProfitRatio;
        private TextBox mgTotalSalesMoneySum;
        private TextBox mgGrossProfitSum;
        private TextBox mkGrossProfitSum;
        private TextBox mkTotalSalesMoneySum;
        private TextBox seTotalSalesMoneySum;
        private TextBox seGrossProfitSum;
        private TextBox suGrossProfitSum;
        private TextBox suTotalSalesMoneySum;
        private TextBox toTotalSalesMoneySum;
        private TextBox toGrossProfitSum;
        private GroupHeader BLGroupHeader;
        private GroupFooter BLGroupFooter;
        private TextBox textBox21;
        private Line line8;
        private TextBox grTotalSalesCount;
        private TextBox grTotalSalesMoney;
        private TextBox grGrossProfit;
        private TextBox grCmpPureSalesRatio;
        private TextBox grProfitRatio;
        private TextBox grCmpProfitRatio;
        private TextBox grTotalSalesMoneySum;
        private TextBox grGrossProfitSum;
        private TextBox lgTotalSalesMoneySum;
        private Line line2;
        private TextBox subTotalBLGroupKanaName;
        private TextBox subTotalBLGroupCode;
        private TextBox grTotalSalesMoneyOrg;
        private TextBox grGrossProfitOrg;
        private TextBox mgTotalSalesMoneyOrg;
        private TextBox mgGrossProfitOrg;
        private TextBox lgTotalSalesMoneyOrg;
        private TextBox lgGrossProfitOrg;
        private TextBox mkTotalSalesMoneyOrg;
        private TextBox mkGrossProfitOrg;
        private TextBox suTotalSalesMoneyOrg;
        private TextBox suGrossProfitOrg;
        private TextBox seTotalSalesMoneyOrg;
        private TextBox seGrossProfitOrg;
        private TextBox toTotalSalesMoneyOrg;
        private TextBox toGrossProfitOrg;
        private TextBox SupHd_AddUpSecCode;
        private TextBox SupHd_SectionGuideNm;
        private TextBox SupHd_SupplierCd;
        private TextBox SupHd_SupplierNm;
        private Label SupHd_SectionTitle;
        private Label SupHd_SupplierTitle;
        private Line line5;
        private Line line6;
        private TextBox lgGrossProfitSum;

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
				this._shipmGoodsOdrReport	= (ShipmGoodsOdrReport)this._printInfo.jyoken;
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
				// TODO:  MAZAI02032P_02A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAZAI02032P_02A4C.WatermarkMode setter 実装を追加します。
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
			
			// タイトル項目の名称をセット
			tb_ReportTitle.Text = this._pageHeaderTitle;

			//-------------------------------------------------------
			// 小計印刷設定
            //-------------------------------------------------------
            #region 小計印刷
            //小計印刷(拠点)
            if (_shipmGoodsOdrReport.SubtotalSection != 0)
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //SectionHeader.DataField = "SectionHeaderField";
                //SectionHeader.Visible = true;
                //if (_shipmGoodsOdrReport.CrMode == 1)
                //{
                //    SectionHeader.NewPage = NewPage.Before;
                //}
                //else
                //{
                //    SectionHeader.NewPage = NewPage.None;
                //}
                // --- DEL 2008/12/05 --------------------------------<<<<<

                //Footer
                SectionFooter.Visible = true;
            }
            else
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //SectionHeader.DataField = "";
                //SectionHeader.Visible = false;
                //SectionHeader.NewPage = NewPage.None;
                ////Footer
                //SectionFooter.Visible = true;
                //SectionFooter.Height = 0F;
                // --- DEL 2008/12/05 --------------------------------<<<<<
                SectionFooter.Visible = false; // ADD 2008/12/05
            }

            // 小計印刷(仕入先)
            if (_shipmGoodsOdrReport.SubtotalSupplier != 0)
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //SuplierHeader.DataField = "SuplierField";
                //SuplierHeader.Visible = true;
                //if (_shipmGoodsOdrReport.CrMode == 4)
                //{
                //    SuplierHeader.NewPage = NewPage.Before;
                //}
                //else
                //{
                //    SuplierHeader.NewPage = NewPage.None;
                //}
                // --- DEL 2008/12/05 --------------------------------<<<<<

                //Footer
                SuplierFooter.Visible = true;
            }
            else
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //SuplierHeader.DataField = "";
                //SuplierHeader.Visible = false;
                //SuplierHeader.NewPage = NewPage.None;
                ////Footer
                //SuplierFooter.Visible = true;
                //SuplierFooter.Height = 0F;
                // --- DEL 2008/12/05 --------------------------------<<<<<
                SuplierFooter.Visible = false; // ADD 2008/12/05
            }

            //小計印刷(メーカー)
            if (_shipmGoodsOdrReport.SubtotalMaker != 0)
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //MakerHeader.DataField = "MakerField";
                //MakerHeader.Visible = true;
                //MakerHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<

                //Footer
                MakerFooter.Visible = true;
            }
            else
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //MakerHeader.DataField = "";
                //MakerHeader.Visible = false;
                //MakerHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<
                //Footer
                MakerFooter.Visible = false;
            }

            // 小計印刷(商品大分類)
            if (_shipmGoodsOdrReport.SubtotalGoodsLGroup != 0)
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //GoodsLGroupHeader.DataField = "GoodsLGroupField";
                //GoodsLGroupHeader.Visible = true;
                //GoodsLGroupHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<

                //Footer
                GoodsLGroupFooter.Visible = true;
            }
            else
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //GoodsLGroupHeader.DataField = "";
                //GoodsLGroupHeader.Visible = false;
                //GoodsLGroupHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<
                //Footer
                GoodsLGroupFooter.Visible = false;
            }

            // 小計印刷(商品中分類)
            if (_shipmGoodsOdrReport.SubtotalGoodsMGroup != 0)
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //GoodsMGroupHeader.DataField = "GoodsMGroupField";
                //GoodsMGroupHeader.Visible = true;
                //GoodsMGroupHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<

                //Footer
                GoodsMGroupFooter.Visible = true;
            }
            else
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //GoodsMGroupHeader.DataField = "";
                //GoodsMGroupHeader.Visible = false;
                //GoodsMGroupHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<
                //Footer
                GoodsMGroupFooter.Visible = false;
            }

            // 小計印刷(グループコード)
            if (_shipmGoodsOdrReport.SubtotalGroupCode != 0)
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //BLGroupHeader.DataField = "BLGroupField";
                //BLGroupHeader.Visible = true;
                //BLGroupHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<

                //Footer
                BLGroupFooter.Visible = true;
            }
            else
            {
                // --- DEL 2008/12/05 -------------------------------->>>>>
                ////Heder
                //BLGroupHeader.DataField = "";
                //BLGroupHeader.Visible = true; // 拠点等の表示のため
                //BLGroupHeader.NewPage = NewPage.None;
                // --- DEL 2008/12/05 --------------------------------<<<<<
                //Footer
                BLGroupFooter.Visible = false;
            }

            #endregion

            //-------------------------------------------------------
			// 集計方法設定
			//-------------------------------------------------------
            #region [集計方法設定]
            //集計方法（0:全社・1:拠点）
            if (_shipmGoodsOdrReport.TtlType == 0)
            {
                SectionHeader.DataField = "";
                SectionHeader.Visible = false;
            }
            else
            {
                SectionHeader.DataField = "AddUpSecCode";
                SectionHeader.Visible = true;
            }
            #endregion

            // --- ADD 2008/12/09 -------------------------------->>>>>
            //-------------------------------------------------------
            // ヘッダ設定
            //-------------------------------------------------------
            #region [ヘッダ設定]
            if (this._shipmGoodsOdrReport.TtlType == 0) // 全社
            {
                this.SupHd_SectionTitle.Visible = false;
                this.SupHd_AddUpSecCode.Visible = false;
                this.SupHd_SectionGuideNm.Visible = false;

                this.SupHd_SupplierTitle.Location = this.SupHd_SectionTitle.Location;

                PointF point = new PointF();
                point = this.SupHd_SupplierTitle.Location;

                point.X += this.SupHd_SupplierTitle.Width + 0.05F;
                this.SupHd_SupplierCd.Location = point;

                point.X += this.SupHd_SupplierCd.Width;
                this.SupHd_SupplierNm.Location = point;
            }
            #endregion
            // --- ADD 2008/12/09 --------------------------------<<<<<

            //-------------------------------------------------------
            // 改頁設定
            //-------------------------------------------------------
            #region 改頁
            switch (this._shipmGoodsOdrReport.CrMode)
            {
                case 1: // 拠点
                    {
                        this.SectionHeader.NewPage = NewPage.Before;
                        break;
                    }
                case 4: // 仕入先
                    {
                        this.SuplierHeader.NewPage = NewPage.Before;
                        break;
                    }
            }
            #endregion
        }

		#endregion ◆ レポート要素出力設定

        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(object numerator, object denominator)
        {
            double workRate;
            double numeratorD = Convert.ToDouble(numerator);
            double denominatorD = Convert.ToDouble(denominator);

            if (denominatorD == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numeratorD / denominatorD) * 100;
            }
            if (workRate < 0) workRate = workRate * -1;

            return workRate;
        }

		#endregion

		#region ■ Control Event

		#region ◎ MAZAI02032P_02A4C_ReportStart Event
		/// <summary>
		/// MAZAI02032P_02A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void MAZAI02032P_02A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ MAZAI02032P_02A4C_PageEnd Event
		/// <summary>
		/// MAZAI02032P_02A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: MAZAI02032P_02A4C_PageEnd Event</br>
		/// <br>Programmer	: 96186 立花 裕輔</br>
		/// <br>Date		: 2007.09.03</br>
		/// </remarks>
		private void MAZAI02032P_02A4C_PageEnd(object sender, System.EventArgs eArgs)
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
			//string sectionTitle = string.Format("{0}拠点：", this._shipmGoodsOdrReport.MainExtractTitle);
			//if ( this._shipmGoodsOdrReport.IsOptSection )
			//{
				if ( this._shipmGoodsOdrReport.IsSelectAllSection )
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
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { TotalSalesMoney, GrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 0:順位無の場合 100000000:最大順位を超えた場合
            if (this.OrderNo.Text == "0" || this.OrderNo.Text == "100000000")
            {
                this.OrderNo.Text = "";
            }

            if (Convert.ToInt32(this.GoodsMakerCd.Text) == 0)
            {
                this.GoodsMakerCd.Text = "";
                this.MakerName.Text = "";
            }

            if (Convert.ToInt32(this.GoodsLGroup.Text) == 0)
            {
                this.GoodsLGroup.Text = "";
                this.GoodsLGroupName.Text = "";
            }

            if (Convert.ToInt32(this.GoodsMGroup.Text) == 0)
            {
                this.GoodsMGroup.Text = "";
                this.GoodsMGroupName.Text = "";
            }

            if (Convert.ToInt32(this.BLGroupCode.Text) == 0)
            {
                this.BLGroupCode.Text = "";
            }

            if (Convert.ToInt32(this.BLGoodsCode.Text) == 0)
            {
                this.BLGoodsCode.Text = "";
                this.BLGoodsHalfName.Text = "";
            }

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
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
		{
#if False
			//月間粗利率
			if (double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				d_TermProfitRate.Value = 0;
			}
			else
			{
				d_TermProfitRate.Value = double.Parse(this.d_TermProfit.Value.ToString()) / double.Parse(this.d_TermSalesTotalTaxExc.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				d_MonthProfitRate.Value = 0;
			}
			else
			{
				d_MonthProfitRate.Value = double.Parse(this.d_MonthProfit.Value.ToString()) / double.Parse(this.d_MonthSalesTotalTaxExc.Value.ToString());
			}
#endif
		}


		private void BLGoodsFooter_Format(object sender, EventArgs e)
		{

		}

		private void MakerFooter_Format(object sender, EventArgs e)
		{

		}

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
#if False
			//月間粗利率
			if (double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				s_TermProfitRate.Value = 0;
			}
			else
			{
				s_TermProfitRate.Value = double.Parse(this.s_TermProfit.Value.ToString()) / double.Parse(this.s_TermSalesTotalTaxExc.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.s_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				s_MonthProfitRate.Value = 0;
			}
			else
			{
				s_MonthProfitRate.Value = double.Parse(this.s_MonthProfit.Value.ToString()) / double.Parse(this.s_MonthSalesTotalTaxExc.Value.ToString());
			}
#endif
		}

		private void GrandTotalFooter_Format(object sender, EventArgs e)
		{
#if False
			//月間粗利率
			if (double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString()) == 0)
			{
				g_TermProfitRate.Value = 0;
			}
			else
			{
				g_TermProfitRate.Value = double.Parse(this.g_TermProfit.Value.ToString()) / double.Parse(this.g_TermSalesTotalTaxExc.Value.ToString());
			}

			//年間粗利率
			if (double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString()) == 0)
			{
				g_MonthProfitRate.Value = 0;
			}
			else
			{
				g_MonthProfitRate.Value = double.Parse(this.g_MonthProfit.Value.ToString()) / double.Parse(this.g_MonthSalesTotalTaxExc.Value.ToString());
			}
#endif
		}

		//private void MakerFooter_Format(object sender, System.EventArgs eArgs)
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

        /// <summary>
        /// SuplierHeader_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuplierHeader_BeforePrint(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SupHd_SupplierCd.Text) ||
                Convert.ToInt32(this.SupHd_SupplierCd.Text) == 0)
            {
                this.SupHd_SupplierCd.Text = "";
                this.SupHd_SupplierNm.Text = "";
            }
        }

        /// <summary>
        /// BLGroupFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.subTotalBLGroupCode.Text) == 0)
            {
                this.subTotalBLGroupCode.Text = "";
                this.subTotalBLGroupKanaName.Text = "";
            }

            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { grTotalSalesMoney, grGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.grProfitRatio.Value = this.GetRatio(this.grGrossProfitOrg.Value, this.grTotalSalesMoneyOrg.Value);

            // 売上構成比
            this.grCmpPureSalesRatio.Value = this.GetRatio(this.grTotalSalesMoneyOrg.Value, this.grTotalSalesMoneySum.Value);

            // 粗利構成比
            this.grCmpProfitRatio.Value = this.GetRatio(this.grGrossProfitOrg.Value, this.grGrossProfitSum.Value);
        }

        /// <summary>
        /// GoodsMGroupFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsMGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { mgTotalSalesMoney, mgGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.mgProfitRatio.Value = this.GetRatio(this.mgGrossProfitOrg.Value, this.mgTotalSalesMoneyOrg.Value);

            // 売上構成比
            this.mgCmpPureSalesRatio.Value = this.GetRatio(this.mgTotalSalesMoneyOrg.Value, this.mgTotalSalesMoneySum.Value);

            // 粗利構成比
            this.mgCmpProfitRatio.Value = this.GetRatio(this.mgGrossProfitOrg.Value, this.mgGrossProfitSum.Value);
        }

        /// <summary>
        /// GoodsLGroupFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsLGroupFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { lgTotalSalesMoney, lgGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.lgProfitRatio.Value = this.GetRatio(this.lgGrossProfitOrg.Value, this.lgTotalSalesMoneyOrg.Value);

            // 売上構成比
            this.lgCmpPureSalesRatio.Value = this.GetRatio(this.lgTotalSalesMoneyOrg.Value, this.lgTotalSalesMoneySum.Value);

            // 粗利構成比
            this.lgCmpProfitRatio.Value = this.GetRatio(this.lgGrossProfitOrg.Value, this.lgGrossProfitSum.Value);
        }

        /// <summary>
        /// MakerFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { mkTotalSalesMoney, mkGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.mkProfitRatio.Value = this.GetRatio(this.mkGrossProfitOrg.Value, this.mkTotalSalesMoneyOrg.Value);

            // 売上構成比
            this.mkCmpPureSalesRatio.Value = this.GetRatio(this.mkTotalSalesMoneyOrg.Value, this.mkTotalSalesMoneySum.Value);

            // 粗利構成比
            this.mkCmpProfitRatio.Value = this.GetRatio(this.mkGrossProfitOrg.Value, this.mkGrossProfitSum.Value);
        }

        /// <summary>
        /// SuplierFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuplierFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { suTotalSalesMoney, suGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.suProfitRatio.Value = this.GetRatio(this.suGrossProfitOrg.Value, this.suTotalSalesMoneyOrg.Value);

            // 売上構成比
            this.suCmpPureSalesRatio.Value = this.GetRatio(this.suTotalSalesMoneyOrg.Value, this.suTotalSalesMoneySum.Value);

            // 粗利構成比
            this.suCmpProfitRatio.Value = this.GetRatio(this.suGrossProfitOrg.Value, this.suGrossProfitSum.Value);
        }

        /// <summary>
        /// SectionFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { seTotalSalesMoney, seGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.seProfitRatio.Value = this.GetRatio(this.seGrossProfitOrg.Value, this.seTotalSalesMoneyOrg.Value);

            // 売上構成比
            this.seCmpPureSalesRatio.Value = this.GetRatio(this.seTotalSalesMoneyOrg.Value, this.seTotalSalesMoneySum.Value);

            // 粗利構成比
            this.seCmpProfitRatio.Value = this.GetRatio(this.seGrossProfitOrg.Value, this.seGrossProfitSum.Value);
        }

        /// <summary>
        /// GrandTotalFooter_BeforePrintイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            // ADD 2009/04/13 ------>>>
            // 円単位計算
            List<TextBox> dList = new List<TextBox>();
            dList.AddRange(new TextBox[] { toTotalSalesMoney, toGrossProfit });
            PriceUnitCalc(dList);
            // ADD 2009/04/13 ------<<<

            // 粗利率
            this.toProfitRatio.Value = this.GetRatio(this.toGrossProfitOrg.Value, this.toTotalSalesMoneyOrg.Value);

            if (this._shipmGoodsOdrReport.ConstUnit == 0)
            {
                // 売上構成比
                this.toCmpPureSalesRatio.Value = this.GetRatio(this.toTotalSalesMoneyOrg.Value, this.toTotalSalesMoneySum.Value);
                // 粗利構成比
                this.toCmpProfitRatio.Value = this.GetRatio(this.toGrossProfitOrg.Value, this.toGrossProfitSum.Value);
            }
            else
            {
                // 拠点毎の場合は表示しない
                this.toCmpPureSalesRatio.Visible = false;
                this.toCmpProfitRatio.Visible = false;
            }

        }

		#endregion ■ Control Event

        // ADD 2009/04/13 ------>>>
        /// <summary>
        /// 千円単位計算
        /// </summary>
        /// <param name="calcList"></param>
        private void PriceUnitCalc(List<TextBox> calcList)
        {
            if (this._shipmGoodsOdrReport.MoneyUnit == 1)
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
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader MakerHeader;
		private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox GoodsMakerCd;
		private DataDynamics.ActiveReports.GroupFooter MakerFooter;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.TextBox SectionTitle;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label GrandTotalTitle;
        private DataDynamics.ActiveReports.Line Line43;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHNB02052P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.OrderNo = new DataDynamics.ActiveReports.TextBox();
            this.MakerName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroup = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroup = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.TotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.CmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.ProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.CmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupName = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupName = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
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
            this.Lb_GoodsMakerCd = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsHalfName = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalTitle = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.toTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.toTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.toGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.toCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.toProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.toCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.toTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.toGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.toTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.toGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SectionTitle = new DataDynamics.ActiveReports.TextBox();
            this.seTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.seTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.seGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.seCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.seProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.seCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.seTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.seGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.seTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.seGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.mkTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.mkTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.mkGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.mkCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.mkProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.mkCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.mkGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.mkTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.mkTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.mkGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsMGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.mgTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.mgTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.mgGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.mgCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.mgProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.mgCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.mgTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.mgGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.mgTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.mgGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.SuplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupHd_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SupplierNm = new DataDynamics.ActiveReports.TextBox();
            this.SupHd_SectionTitle = new DataDynamics.ActiveReports.Label();
            this.SupHd_SupplierTitle = new DataDynamics.ActiveReports.Label();
            this.SuplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.suTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.suTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.suGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.suCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.suProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.suCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.suGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.suTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.suTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.suGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.GoodsLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GoodsLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.lgTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.lgTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.lgGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.lgCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.lgProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.lgCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.lgTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.lgGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.lgTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.lgGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.BLGroupHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.BLGroupFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.grTotalSalesCount = new DataDynamics.ActiveReports.TextBox();
            this.grTotalSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.grGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.grCmpPureSalesRatio = new DataDynamics.ActiveReports.TextBox();
            this.grProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.grCmpProfitRatio = new DataDynamics.ActiveReports.TextBox();
            this.grTotalSalesMoneySum = new DataDynamics.ActiveReports.TextBox();
            this.grGrossProfitSum = new DataDynamics.ActiveReports.TextBox();
            this.subTotalBLGroupKanaName = new DataDynamics.ActiveReports.TextBox();
            this.subTotalBLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.grTotalSalesMoneyOrg = new DataDynamics.ActiveReports.TextBox();
            this.grGrossProfitOrg = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCmpPureSalesRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCmpProfitRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesMoneySum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGrossProfitSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupKanaName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesMoneyOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGrossProfitOrg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsMakerCd,
            this.OrderNo,
            this.MakerName,
            this.GoodsLGroup,
            this.GoodsMGroup,
            this.BLGroupCode,
            this.BLGoodsCode,
            this.BLGoodsHalfName,
            this.TotalSalesCount,
            this.TotalSalesMoney,
            this.CmpPureSalesRatio,
            this.GrossProfit,
            this.ProfitRatio,
            this.CmpProfitRatio,
            this.GoodsMGroupName,
            this.GoodsLGroupName,
            this.line5});
            this.Detail.Height = 0.2708333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.GoodsMakerCd.Height = 0.16F;
            this.GoodsMakerCd.Left = 0.5F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMakerCd.Text = "1234";
            this.GoodsMakerCd.Top = 0.031F;
            this.GoodsMakerCd.Width = 0.26F;
            // 
            // OrderNo
            // 
            this.OrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.OrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.OrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.OrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.OrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OrderNo.DataField = "OrderNo";
            this.OrderNo.Height = 0.156F;
            this.OrderNo.Left = 0.03F;
            this.OrderNo.MultiLine = false;
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.OutputFormat = resources.GetString("OrderNo.OutputFormat");
            this.OrderNo.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.OrderNo.Text = "12345678";
            this.OrderNo.Top = 0.031F;
            this.OrderNo.Width = 0.48F;
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
            this.MakerName.DataField = "MakerShortName";
            this.MakerName.Height = 0.16F;
            this.MakerName.Left = 0.75F;
            this.MakerName.MultiLine = false;
            this.MakerName.Name = "MakerName";
            this.MakerName.OutputFormat = resources.GetString("MakerName.OutputFormat");
            this.MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MakerName.Text = "あいうえおかきくけこ";
            this.MakerName.Top = 0.031F;
            this.MakerName.Width = 1.15F;
            // 
            // GoodsLGroup
            // 
            this.GoodsLGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsLGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsLGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroup.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsLGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroup.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsLGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsLGroup.DataField = "GoodsLGroup";
            this.GoodsLGroup.Height = 0.16F;
            this.GoodsLGroup.Left = 1.938F;
            this.GoodsLGroup.MultiLine = false;
            this.GoodsLGroup.Name = "GoodsLGroup";
            this.GoodsLGroup.OutputFormat = resources.GetString("GoodsLGroup.OutputFormat");
            this.GoodsLGroup.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsLGroup.Text = "1234";
            this.GoodsLGroup.Top = 0.031F;
            this.GoodsLGroup.Width = 0.26F;
            // 
            // GoodsMGroup
            // 
            this.GoodsMGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.DataField = "GoodsMGroup";
            this.GoodsMGroup.Height = 0.16F;
            this.GoodsMGroup.Left = 3.375F;
            this.GoodsMGroup.MultiLine = false;
            this.GoodsMGroup.Name = "GoodsMGroup";
            this.GoodsMGroup.OutputFormat = resources.GetString("GoodsMGroup.OutputFormat");
            this.GoodsMGroup.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.GoodsMGroup.Text = "1234";
            this.GoodsMGroup.Top = 0.031F;
            this.GoodsMGroup.Width = 0.26F;
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
            this.BLGroupCode.DataField = "BLGroupCode";
            this.BLGroupCode.Height = 0.16F;
            this.BLGroupCode.Left = 4.79F;
            this.BLGroupCode.MultiLine = false;
            this.BLGroupCode.Name = "BLGroupCode";
            this.BLGroupCode.OutputFormat = resources.GetString("BLGroupCode.OutputFormat");
            this.BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGroupCode.Text = "12345";
            this.BLGroupCode.Top = 0.031F;
            this.BLGroupCode.Width = 0.35F;
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
            this.BLGoodsCode.Height = 0.16F;
            this.BLGoodsCode.Left = 5.625F;
            this.BLGoodsCode.MultiLine = false;
            this.BLGoodsCode.Name = "BLGoodsCode";
            this.BLGoodsCode.OutputFormat = resources.GetString("BLGoodsCode.OutputFormat");
            this.BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BLGoodsCode.Text = "12345";
            this.BLGoodsCode.Top = 0.031F;
            this.BLGoodsCode.Width = 0.32F;
            // 
            // BLGoodsHalfName
            // 
            this.BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.DataField = "BLGoodsHalfName";
            this.BLGoodsHalfName.Height = 0.16F;
            this.BLGoodsHalfName.Left = 5.95F;
            this.BLGoodsHalfName.MultiLine = false;
            this.BLGoodsHalfName.Name = "BLGoodsHalfName";
            this.BLGoodsHalfName.OutputFormat = resources.GetString("BLGoodsHalfName.OutputFormat");
            this.BLGoodsHalfName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BLGoodsHalfName.Text = "あいうえおかきくけこ";
            this.BLGoodsHalfName.Top = 0.031F;
            this.BLGoodsHalfName.Width = 1.15F;
            // 
            // TotalSalesCount
            // 
            this.TotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.TotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.TotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalSalesCount.CanShrink = true;
            this.TotalSalesCount.DataField = "TotalSalesCount";
            this.TotalSalesCount.Height = 0.16F;
            this.TotalSalesCount.Left = 7.09F;
            this.TotalSalesCount.MultiLine = false;
            this.TotalSalesCount.Name = "TotalSalesCount";
            this.TotalSalesCount.OutputFormat = resources.GetString("TotalSalesCount.OutputFormat");
            this.TotalSalesCount.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.TotalSalesCount.Top = 0.031F;
            this.TotalSalesCount.Width = 0.8F;
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
            this.TotalSalesMoney.CanShrink = true;
            this.TotalSalesMoney.DataField = "TotalSalesMoney";
            this.TotalSalesMoney.Height = 0.16F;
            this.TotalSalesMoney.Left = 7.91F;
            this.TotalSalesMoney.MultiLine = false;
            this.TotalSalesMoney.Name = "TotalSalesMoney";
            this.TotalSalesMoney.OutputFormat = resources.GetString("TotalSalesMoney.OutputFormat");
            this.TotalSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.TotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.TotalSalesMoney.Top = 0.031F;
            this.TotalSalesMoney.Width = 0.8F;
            // 
            // CmpPureSalesRatio
            // 
            this.CmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.CmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpPureSalesRatio.CanShrink = true;
            this.CmpPureSalesRatio.DataField = "CmpPureSalesRatio";
            this.CmpPureSalesRatio.Height = 0.16F;
            this.CmpPureSalesRatio.Left = 8.74F;
            this.CmpPureSalesRatio.MultiLine = false;
            this.CmpPureSalesRatio.Name = "CmpPureSalesRatio";
            this.CmpPureSalesRatio.OutputFormat = resources.GetString("CmpPureSalesRatio.OutputFormat");
            this.CmpPureSalesRatio.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.CmpPureSalesRatio.Text = "999.99";
            this.CmpPureSalesRatio.Top = 0.031F;
            this.CmpPureSalesRatio.Width = 0.373F;
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
            this.GrossProfit.CanShrink = true;
            this.GrossProfit.DataField = "GrossProfit";
            this.GrossProfit.Height = 0.16F;
            this.GrossProfit.Left = 9.15F;
            this.GrossProfit.MultiLine = false;
            this.GrossProfit.Name = "GrossProfit";
            this.GrossProfit.OutputFormat = resources.GetString("GrossProfit.OutputFormat");
            this.GrossProfit.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.GrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.GrossProfit.Top = 0.031F;
            this.GrossProfit.Width = 0.8F;
            // 
            // ProfitRatio
            // 
            this.ProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.ProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.ProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.ProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.ProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProfitRatio.CanShrink = true;
            this.ProfitRatio.DataField = "ProfitRatio";
            this.ProfitRatio.Height = 0.16F;
            this.ProfitRatio.Left = 9.98F;
            this.ProfitRatio.MultiLine = false;
            this.ProfitRatio.Name = "ProfitRatio";
            this.ProfitRatio.OutputFormat = resources.GetString("ProfitRatio.OutputFormat");
            this.ProfitRatio.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.ProfitRatio.Text = "999.99";
            this.ProfitRatio.Top = 0.031F;
            this.ProfitRatio.Width = 0.375F;
            // 
            // CmpProfitRatio
            // 
            this.CmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.CmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.CmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.CmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.CmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CmpProfitRatio.CanShrink = true;
            this.CmpProfitRatio.DataField = "CmpProfitRatio";
            this.CmpProfitRatio.Height = 0.16F;
            this.CmpProfitRatio.Left = 10.375F;
            this.CmpProfitRatio.MultiLine = false;
            this.CmpProfitRatio.Name = "CmpProfitRatio";
            this.CmpProfitRatio.OutputFormat = resources.GetString("CmpProfitRatio.OutputFormat");
            this.CmpProfitRatio.Style = "ddo-char-set: 128; text-align: right; font-weight: normal; font-size: 8pt; font-f" +
                "amily: ＭＳ ゴシック; vertical-align: top; ";
            this.CmpProfitRatio.Text = "999.99";
            this.CmpProfitRatio.Top = 0.031F;
            this.CmpProfitRatio.Width = 0.375F;
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
            this.GoodsMGroupName.DataField = "GoodsMGroupName";
            this.GoodsMGroupName.Height = 0.16F;
            this.GoodsMGroupName.Left = 3.625F;
            this.GoodsMGroupName.MultiLine = false;
            this.GoodsMGroupName.Name = "GoodsMGroupName";
            this.GoodsMGroupName.OutputFormat = resources.GetString("GoodsMGroupName.OutputFormat");
            this.GoodsMGroupName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsMGroupName.Text = "あいうえおかきくけこ";
            this.GoodsMGroupName.Top = 0.031F;
            this.GoodsMGroupName.Width = 1.15F;
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
            this.GoodsLGroupName.DataField = "GoodsLGroupName";
            this.GoodsLGroupName.Height = 0.16F;
            this.GoodsLGroupName.Left = 2.188F;
            this.GoodsLGroupName.MultiLine = false;
            this.GoodsLGroupName.Name = "GoodsLGroupName";
            this.GoodsLGroupName.OutputFormat = resources.GetString("GoodsLGroupName.OutputFormat");
            this.GoodsLGroupName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsLGroupName.Text = "あいうえおかきくけこ";
            this.GoodsLGroupName.Top = 0.031F;
            this.GoodsLGroupName.Width = 1.15F;
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
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
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
            this.Label3.Left = 7.5625F;
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
            this.tb_PrintDate.Left = 8.125F;
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
            this.Label2.Left = 9.5625F;
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
            this.tb_PrintPage.Left = 10.0625F;
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
            this.tb_PrintTime.Left = 9.0625F;
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
            this.tb_ReportTitle.Text = "売上順位表（BLコード別）";
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
            this.Lb_GoodsMakerCd,
            this.label16,
            this.Lb_BLGoodsHalfName,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13});
            this.TitleHeader.Height = 0.3125F;
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
            this.Lb_GoodsMakerCd.Height = 0.16F;
            this.Lb_GoodsMakerCd.HyperLink = "";
            this.Lb_GoodsMakerCd.Left = 0.5F;
            this.Lb_GoodsMakerCd.MultiLine = false;
            this.Lb_GoodsMakerCd.Name = "Lb_GoodsMakerCd";
            this.Lb_GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMakerCd.Text = "メーカー";
            this.Lb_GoodsMakerCd.Top = 0.01F;
            this.Lb_GoodsMakerCd.Width = 0.875F;
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
            this.label16.Left = 0.03F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "順位";
            this.label16.Top = 0.01F;
            this.label16.Width = 0.48F;
            // 
            // Lb_BLGoodsHalfName
            // 
            this.Lb_BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsHalfName.Height = 0.16F;
            this.Lb_BLGoodsHalfName.HyperLink = "";
            this.Lb_BLGoodsHalfName.Left = 1.938F;
            this.Lb_BLGoodsHalfName.MultiLine = false;
            this.Lb_BLGoodsHalfName.Name = "Lb_BLGoodsHalfName";
            this.Lb_BLGoodsHalfName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsHalfName.Text = "商品大分類";
            this.Lb_BLGoodsHalfName.Top = 0.01F;
            this.Lb_BLGoodsHalfName.Width = 1.08F;
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
            this.label5.Height = 0.16F;
            this.label5.HyperLink = "";
            this.label5.Left = 3.375F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "商品中分類";
            this.label5.Top = 0.01F;
            this.label5.Width = 1.08F;
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
            this.label6.Height = 0.16F;
            this.label6.HyperLink = "";
            this.label6.Left = 4.79F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "グループコード";
            this.label6.Top = 0.01F;
            this.label6.Width = 0.83F;
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
            this.label7.Height = 0.16F;
            this.label7.HyperLink = "";
            this.label7.Left = 5.625F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "ＢＬコード";
            this.label7.Top = 0.01F;
            this.label7.Width = 1.08F;
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
            this.label8.Height = 0.16F;
            this.label8.HyperLink = "";
            this.label8.Left = 7.09F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "出荷数";
            this.label8.Top = 0.01F;
            this.label8.Width = 0.8F;
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
            this.label9.Height = 0.16F;
            this.label9.HyperLink = "";
            this.label9.Left = 7.91F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "純売上";
            this.label9.Top = 0.01F;
            this.label9.Width = 0.8F;
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
            this.label10.Height = 0.16F;
            this.label10.HyperLink = "";
            this.label10.Left = 8.74F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "構成比";
            this.label10.Top = 0.01F;
            this.label10.Width = 0.373F;
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
            this.label11.Height = 0.16F;
            this.label11.HyperLink = "";
            this.label11.Left = 9.15F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "粗利";
            this.label11.Top = 0.01F;
            this.label11.Width = 0.8F;
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
            this.label12.Height = 0.16F;
            this.label12.HyperLink = "";
            this.label12.Left = 9.98F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "粗利率";
            this.label12.Top = 0.01F;
            this.label12.Width = 0.373F;
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
            this.label13.Height = 0.16F;
            this.label13.HyperLink = "";
            this.label13.Left = 10.375F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "構成比";
            this.label13.Top = 0.01F;
            this.label13.Width = 0.373F;
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
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GrandTotalTitle,
            this.Line43,
            this.toTotalSalesCount,
            this.toTotalSalesMoney,
            this.toGrossProfit,
            this.toCmpPureSalesRatio,
            this.toProfitRatio,
            this.toCmpProfitRatio,
            this.toTotalSalesMoneySum,
            this.toGrossProfitSum,
            this.toTotalSalesMoneyOrg,
            this.toGrossProfitOrg});
            this.GrandTotalFooter.Height = 0.2604167F;
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
            this.GrandTotalTitle.Height = 0.2F;
            this.GrandTotalTitle.HyperLink = "";
            this.GrandTotalTitle.Left = 4.25F;
            this.GrandTotalTitle.MultiLine = false;
            this.GrandTotalTitle.Name = "GrandTotalTitle";
            this.GrandTotalTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.GrandTotalTitle.Text = "総合計";
            this.GrandTotalTitle.Top = 0.031F;
            this.GrandTotalTitle.Width = 1.3F;
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
            // toTotalSalesCount
            // 
            this.toTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.toTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesCount.CanShrink = true;
            this.toTotalSalesCount.DataField = "TotalSalesCount";
            this.toTotalSalesCount.Height = 0.16F;
            this.toTotalSalesCount.Left = 7.09F;
            this.toTotalSalesCount.MultiLine = false;
            this.toTotalSalesCount.Name = "toTotalSalesCount";
            this.toTotalSalesCount.OutputFormat = resources.GetString("toTotalSalesCount.OutputFormat");
            this.toTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toTotalSalesCount.SummaryGroup = "GrandTotalHeader";
            this.toTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.toTotalSalesCount.Top = 0.031F;
            this.toTotalSalesCount.Width = 0.8F;
            // 
            // toTotalSalesMoney
            // 
            this.toTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.toTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.toTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.toTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.toTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoney.CanShrink = true;
            this.toTotalSalesMoney.DataField = "TotalSalesMoney";
            this.toTotalSalesMoney.Height = 0.16F;
            this.toTotalSalesMoney.Left = 7.91F;
            this.toTotalSalesMoney.MultiLine = false;
            this.toTotalSalesMoney.Name = "toTotalSalesMoney";
            this.toTotalSalesMoney.OutputFormat = resources.GetString("toTotalSalesMoney.OutputFormat");
            this.toTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toTotalSalesMoney.SummaryGroup = "GrandTotalHeader";
            this.toTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.toTotalSalesMoney.Top = 0.031F;
            this.toTotalSalesMoney.Width = 0.8F;
            // 
            // toGrossProfit
            // 
            this.toGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.toGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.toGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.toGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.toGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfit.CanShrink = true;
            this.toGrossProfit.DataField = "GrossProfit";
            this.toGrossProfit.Height = 0.16F;
            this.toGrossProfit.Left = 9.15F;
            this.toGrossProfit.MultiLine = false;
            this.toGrossProfit.Name = "toGrossProfit";
            this.toGrossProfit.OutputFormat = resources.GetString("toGrossProfit.OutputFormat");
            this.toGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toGrossProfit.SummaryGroup = "GrandTotalHeader";
            this.toGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.toGrossProfit.Top = 0.031F;
            this.toGrossProfit.Width = 0.8F;
            // 
            // toCmpPureSalesRatio
            // 
            this.toCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.toCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpPureSalesRatio.CanShrink = true;
            this.toCmpPureSalesRatio.Height = 0.16F;
            this.toCmpPureSalesRatio.Left = 8.74F;
            this.toCmpPureSalesRatio.MultiLine = false;
            this.toCmpPureSalesRatio.Name = "toCmpPureSalesRatio";
            this.toCmpPureSalesRatio.OutputFormat = resources.GetString("toCmpPureSalesRatio.OutputFormat");
            this.toCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toCmpPureSalesRatio.Text = "999.99";
            this.toCmpPureSalesRatio.Top = 0.031F;
            this.toCmpPureSalesRatio.Width = 0.375F;
            // 
            // toProfitRatio
            // 
            this.toProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.toProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toProfitRatio.CanShrink = true;
            this.toProfitRatio.Height = 0.16F;
            this.toProfitRatio.Left = 9.98F;
            this.toProfitRatio.MultiLine = false;
            this.toProfitRatio.Name = "toProfitRatio";
            this.toProfitRatio.OutputFormat = resources.GetString("toProfitRatio.OutputFormat");
            this.toProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toProfitRatio.Text = "999.99";
            this.toProfitRatio.Top = 0.031F;
            this.toProfitRatio.Width = 0.375F;
            // 
            // toCmpProfitRatio
            // 
            this.toCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.toCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.toCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.toCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.toCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toCmpProfitRatio.CanShrink = true;
            this.toCmpProfitRatio.Height = 0.16F;
            this.toCmpProfitRatio.Left = 10.375F;
            this.toCmpProfitRatio.MultiLine = false;
            this.toCmpProfitRatio.Name = "toCmpProfitRatio";
            this.toCmpProfitRatio.OutputFormat = resources.GetString("toCmpProfitRatio.OutputFormat");
            this.toCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toCmpProfitRatio.Text = "999.99";
            this.toCmpProfitRatio.Top = 0.031F;
            this.toCmpProfitRatio.Width = 0.375F;
            // 
            // toTotalSalesMoneySum
            // 
            this.toTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneySum.CanShrink = true;
            this.toTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.toTotalSalesMoneySum.Height = 0.16F;
            this.toTotalSalesMoneySum.Left = 0F;
            this.toTotalSalesMoneySum.MultiLine = false;
            this.toTotalSalesMoneySum.Name = "toTotalSalesMoneySum";
            this.toTotalSalesMoneySum.OutputFormat = resources.GetString("toTotalSalesMoneySum.OutputFormat");
            this.toTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.toTotalSalesMoneySum.Top = 0.031F;
            this.toTotalSalesMoneySum.Visible = false;
            this.toTotalSalesMoneySum.Width = 0.7F;
            // 
            // toGrossProfitSum
            // 
            this.toGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.toGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.toGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.toGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.toGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitSum.CanShrink = true;
            this.toGrossProfitSum.DataField = "GrossProfitSum";
            this.toGrossProfitSum.Height = 0.16F;
            this.toGrossProfitSum.Left = 0.688F;
            this.toGrossProfitSum.MultiLine = false;
            this.toGrossProfitSum.Name = "toGrossProfitSum";
            this.toGrossProfitSum.OutputFormat = resources.GetString("toGrossProfitSum.OutputFormat");
            this.toGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.toGrossProfitSum.Top = 0.031F;
            this.toGrossProfitSum.Visible = false;
            this.toGrossProfitSum.Width = 0.7F;
            // 
            // toTotalSalesMoneyOrg
            // 
            this.toTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.toTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toTotalSalesMoneyOrg.CanShrink = true;
            this.toTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.toTotalSalesMoneyOrg.Height = 0.16F;
            this.toTotalSalesMoneyOrg.Left = 1.375F;
            this.toTotalSalesMoneyOrg.MultiLine = false;
            this.toTotalSalesMoneyOrg.Name = "toTotalSalesMoneyOrg";
            this.toTotalSalesMoneyOrg.OutputFormat = resources.GetString("toTotalSalesMoneyOrg.OutputFormat");
            this.toTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toTotalSalesMoneyOrg.SummaryGroup = "GrandTotalHeader";
            this.toTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.toTotalSalesMoneyOrg.Top = 0.031F;
            this.toTotalSalesMoneyOrg.Visible = false;
            this.toTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // toGrossProfitOrg
            // 
            this.toGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.toGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.toGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.toGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.toGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.toGrossProfitOrg.CanShrink = true;
            this.toGrossProfitOrg.DataField = "GrossProfitOrg";
            this.toGrossProfitOrg.Height = 0.16F;
            this.toGrossProfitOrg.Left = 2.063F;
            this.toGrossProfitOrg.MultiLine = false;
            this.toGrossProfitOrg.Name = "toGrossProfitOrg";
            this.toGrossProfitOrg.OutputFormat = resources.GetString("toGrossProfitOrg.OutputFormat");
            this.toGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.toGrossProfitOrg.SummaryGroup = "GrandTotalHeader";
            this.toGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.toGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.toGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.toGrossProfitOrg.Top = 0.031F;
            this.toGrossProfitOrg.Visible = false;
            this.toGrossProfitOrg.Width = 0.7F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.DataField = "SectionHeaderField";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SectionHeader.Height = 0F;
            this.SectionHeader.KeepTogether = true;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SectionTitle,
            this.seTotalSalesCount,
            this.seTotalSalesMoney,
            this.seGrossProfit,
            this.seCmpPureSalesRatio,
            this.seProfitRatio,
            this.seCmpProfitRatio,
            this.seTotalSalesMoneySum,
            this.seGrossProfitSum,
            this.seTotalSalesMoneyOrg,
            this.seGrossProfitOrg});
            this.SectionFooter.Height = 0.2291667F;
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
            this.SectionTitle.Height = 0.2F;
            this.SectionTitle.Left = 4.25F;
            this.SectionTitle.MultiLine = false;
            this.SectionTitle.Name = "SectionTitle";
            this.SectionTitle.OutputFormat = resources.GetString("SectionTitle.OutputFormat");
            this.SectionTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SectionTitle.Text = "拠点計";
            this.SectionTitle.Top = 0.031F;
            this.SectionTitle.Width = 1.3F;
            // 
            // seTotalSalesCount
            // 
            this.seTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.seTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesCount.CanShrink = true;
            this.seTotalSalesCount.DataField = "TotalSalesCount";
            this.seTotalSalesCount.Height = 0.16F;
            this.seTotalSalesCount.Left = 7.09F;
            this.seTotalSalesCount.MultiLine = false;
            this.seTotalSalesCount.Name = "seTotalSalesCount";
            this.seTotalSalesCount.OutputFormat = resources.GetString("seTotalSalesCount.OutputFormat");
            this.seTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seTotalSalesCount.SummaryGroup = "SectionHeader";
            this.seTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.seTotalSalesCount.Top = 0.031F;
            this.seTotalSalesCount.Width = 0.8F;
            // 
            // seTotalSalesMoney
            // 
            this.seTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.seTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.seTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.seTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.seTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoney.CanShrink = true;
            this.seTotalSalesMoney.DataField = "TotalSalesMoney";
            this.seTotalSalesMoney.Height = 0.16F;
            this.seTotalSalesMoney.Left = 7.91F;
            this.seTotalSalesMoney.MultiLine = false;
            this.seTotalSalesMoney.Name = "seTotalSalesMoney";
            this.seTotalSalesMoney.OutputFormat = resources.GetString("seTotalSalesMoney.OutputFormat");
            this.seTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seTotalSalesMoney.SummaryGroup = "SectionHeader";
            this.seTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.seTotalSalesMoney.Top = 0.031F;
            this.seTotalSalesMoney.Width = 0.8F;
            // 
            // seGrossProfit
            // 
            this.seGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.seGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.seGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.seGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.seGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfit.CanShrink = true;
            this.seGrossProfit.DataField = "GrossProfit";
            this.seGrossProfit.Height = 0.16F;
            this.seGrossProfit.Left = 9.15F;
            this.seGrossProfit.MultiLine = false;
            this.seGrossProfit.Name = "seGrossProfit";
            this.seGrossProfit.OutputFormat = resources.GetString("seGrossProfit.OutputFormat");
            this.seGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seGrossProfit.SummaryGroup = "SectionHeader";
            this.seGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.seGrossProfit.Top = 0.031F;
            this.seGrossProfit.Width = 0.8F;
            // 
            // seCmpPureSalesRatio
            // 
            this.seCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.seCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpPureSalesRatio.CanShrink = true;
            this.seCmpPureSalesRatio.Height = 0.16F;
            this.seCmpPureSalesRatio.Left = 8.74F;
            this.seCmpPureSalesRatio.MultiLine = false;
            this.seCmpPureSalesRatio.Name = "seCmpPureSalesRatio";
            this.seCmpPureSalesRatio.OutputFormat = resources.GetString("seCmpPureSalesRatio.OutputFormat");
            this.seCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seCmpPureSalesRatio.Text = "999.99";
            this.seCmpPureSalesRatio.Top = 0.031F;
            this.seCmpPureSalesRatio.Width = 0.375F;
            // 
            // seProfitRatio
            // 
            this.seProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.seProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seProfitRatio.CanShrink = true;
            this.seProfitRatio.Height = 0.16F;
            this.seProfitRatio.Left = 9.98F;
            this.seProfitRatio.MultiLine = false;
            this.seProfitRatio.Name = "seProfitRatio";
            this.seProfitRatio.OutputFormat = resources.GetString("seProfitRatio.OutputFormat");
            this.seProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seProfitRatio.Text = "999.99";
            this.seProfitRatio.Top = 0.031F;
            this.seProfitRatio.Width = 0.375F;
            // 
            // seCmpProfitRatio
            // 
            this.seCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.seCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.seCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.seCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.seCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seCmpProfitRatio.CanShrink = true;
            this.seCmpProfitRatio.Height = 0.16F;
            this.seCmpProfitRatio.Left = 10.375F;
            this.seCmpProfitRatio.MultiLine = false;
            this.seCmpProfitRatio.Name = "seCmpProfitRatio";
            this.seCmpProfitRatio.OutputFormat = resources.GetString("seCmpProfitRatio.OutputFormat");
            this.seCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seCmpProfitRatio.Text = "999.99";
            this.seCmpProfitRatio.Top = 0.031F;
            this.seCmpProfitRatio.Width = 0.375F;
            // 
            // seTotalSalesMoneySum
            // 
            this.seTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneySum.CanShrink = true;
            this.seTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.seTotalSalesMoneySum.Height = 0.16F;
            this.seTotalSalesMoneySum.Left = 0F;
            this.seTotalSalesMoneySum.MultiLine = false;
            this.seTotalSalesMoneySum.Name = "seTotalSalesMoneySum";
            this.seTotalSalesMoneySum.OutputFormat = resources.GetString("seTotalSalesMoneySum.OutputFormat");
            this.seTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.seTotalSalesMoneySum.Top = 0.031F;
            this.seTotalSalesMoneySum.Visible = false;
            this.seTotalSalesMoneySum.Width = 0.7F;
            // 
            // seGrossProfitSum
            // 
            this.seGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.seGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.seGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.seGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.seGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitSum.CanShrink = true;
            this.seGrossProfitSum.DataField = "GrossProfitSum";
            this.seGrossProfitSum.Height = 0.16F;
            this.seGrossProfitSum.Left = 0.688F;
            this.seGrossProfitSum.MultiLine = false;
            this.seGrossProfitSum.Name = "seGrossProfitSum";
            this.seGrossProfitSum.OutputFormat = resources.GetString("seGrossProfitSum.OutputFormat");
            this.seGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.seGrossProfitSum.Top = 0.031F;
            this.seGrossProfitSum.Visible = false;
            this.seGrossProfitSum.Width = 0.7F;
            // 
            // seTotalSalesMoneyOrg
            // 
            this.seTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.seTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seTotalSalesMoneyOrg.CanShrink = true;
            this.seTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.seTotalSalesMoneyOrg.Height = 0.16F;
            this.seTotalSalesMoneyOrg.Left = 1.375F;
            this.seTotalSalesMoneyOrg.MultiLine = false;
            this.seTotalSalesMoneyOrg.Name = "seTotalSalesMoneyOrg";
            this.seTotalSalesMoneyOrg.OutputFormat = resources.GetString("seTotalSalesMoneyOrg.OutputFormat");
            this.seTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seTotalSalesMoneyOrg.SummaryGroup = "SectionHeader";
            this.seTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.seTotalSalesMoneyOrg.Top = 0.031F;
            this.seTotalSalesMoneyOrg.Visible = false;
            this.seTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // seGrossProfitOrg
            // 
            this.seGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.seGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.seGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.seGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.seGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.seGrossProfitOrg.CanShrink = true;
            this.seGrossProfitOrg.DataField = "GrossProfitOrg";
            this.seGrossProfitOrg.Height = 0.16F;
            this.seGrossProfitOrg.Left = 2.063F;
            this.seGrossProfitOrg.MultiLine = false;
            this.seGrossProfitOrg.Name = "seGrossProfitOrg";
            this.seGrossProfitOrg.OutputFormat = resources.GetString("seGrossProfitOrg.OutputFormat");
            this.seGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.seGrossProfitOrg.SummaryGroup = "SectionHeader";
            this.seGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.seGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.seGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.seGrossProfitOrg.Top = 0.031F;
            this.seGrossProfitOrg.Visible = false;
            this.seGrossProfitOrg.Width = 0.7F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.CanShrink = true;
            this.MakerHeader.DataField = "MakerField";
            this.MakerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.MakerHeader.Height = 0F;
            this.MakerHeader.KeepTogether = true;
            this.MakerHeader.Name = "MakerHeader";
            this.MakerHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // MakerFooter
            // 
            this.MakerFooter.CanShrink = true;
            this.MakerFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox11,
            this.line3,
            this.mkTotalSalesCount,
            this.mkTotalSalesMoney,
            this.mkGrossProfit,
            this.mkCmpPureSalesRatio,
            this.mkProfitRatio,
            this.mkCmpProfitRatio,
            this.mkGrossProfitSum,
            this.mkTotalSalesMoneySum,
            this.mkTotalSalesMoneyOrg,
            this.mkGrossProfitOrg});
            this.MakerFooter.Height = 0.2395833F;
            this.MakerFooter.KeepTogether = true;
            this.MakerFooter.Name = "MakerFooter";
            this.MakerFooter.Format += new System.EventHandler(this.MakerFooter_Format);
            this.MakerFooter.BeforePrint += new System.EventHandler(this.MakerFooter_BeforePrint);
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
            this.textBox11.Height = 0.2F;
            this.textBox11.Left = 4.25F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox11.Text = "メーカー計";
            this.textBox11.Top = 0.031F;
            this.textBox11.Width = 1.3F;
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
            // mkTotalSalesCount
            // 
            this.mkTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.mkTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.mkTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.mkTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.mkTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesCount.CanShrink = true;
            this.mkTotalSalesCount.DataField = "TotalSalesCount";
            this.mkTotalSalesCount.Height = 0.16F;
            this.mkTotalSalesCount.Left = 7.09F;
            this.mkTotalSalesCount.MultiLine = false;
            this.mkTotalSalesCount.Name = "mkTotalSalesCount";
            this.mkTotalSalesCount.OutputFormat = resources.GetString("mkTotalSalesCount.OutputFormat");
            this.mkTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkTotalSalesCount.SummaryGroup = "MakerHeader";
            this.mkTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.mkTotalSalesCount.Top = 0.031F;
            this.mkTotalSalesCount.Width = 0.8F;
            // 
            // mkTotalSalesMoney
            // 
            this.mkTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoney.CanShrink = true;
            this.mkTotalSalesMoney.DataField = "TotalSalesMoney";
            this.mkTotalSalesMoney.Height = 0.16F;
            this.mkTotalSalesMoney.Left = 7.91F;
            this.mkTotalSalesMoney.MultiLine = false;
            this.mkTotalSalesMoney.Name = "mkTotalSalesMoney";
            this.mkTotalSalesMoney.OutputFormat = resources.GetString("mkTotalSalesMoney.OutputFormat");
            this.mkTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkTotalSalesMoney.SummaryGroup = "MakerHeader";
            this.mkTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.mkTotalSalesMoney.Top = 0.031F;
            this.mkTotalSalesMoney.Width = 0.8F;
            // 
            // mkGrossProfit
            // 
            this.mkGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.mkGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.mkGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.mkGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.mkGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfit.CanShrink = true;
            this.mkGrossProfit.DataField = "GrossProfit";
            this.mkGrossProfit.Height = 0.16F;
            this.mkGrossProfit.Left = 9.15F;
            this.mkGrossProfit.MultiLine = false;
            this.mkGrossProfit.Name = "mkGrossProfit";
            this.mkGrossProfit.OutputFormat = resources.GetString("mkGrossProfit.OutputFormat");
            this.mkGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkGrossProfit.SummaryGroup = "MakerHeader";
            this.mkGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.mkGrossProfit.Top = 0.031F;
            this.mkGrossProfit.Width = 0.8F;
            // 
            // mkCmpPureSalesRatio
            // 
            this.mkCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.mkCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.mkCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.mkCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.mkCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpPureSalesRatio.CanShrink = true;
            this.mkCmpPureSalesRatio.Height = 0.16F;
            this.mkCmpPureSalesRatio.Left = 8.74F;
            this.mkCmpPureSalesRatio.MultiLine = false;
            this.mkCmpPureSalesRatio.Name = "mkCmpPureSalesRatio";
            this.mkCmpPureSalesRatio.OutputFormat = resources.GetString("mkCmpPureSalesRatio.OutputFormat");
            this.mkCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkCmpPureSalesRatio.Text = "999.99";
            this.mkCmpPureSalesRatio.Top = 0.031F;
            this.mkCmpPureSalesRatio.Width = 0.375F;
            // 
            // mkProfitRatio
            // 
            this.mkProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.mkProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.mkProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.mkProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.mkProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkProfitRatio.CanShrink = true;
            this.mkProfitRatio.Height = 0.16F;
            this.mkProfitRatio.Left = 9.98F;
            this.mkProfitRatio.MultiLine = false;
            this.mkProfitRatio.Name = "mkProfitRatio";
            this.mkProfitRatio.OutputFormat = resources.GetString("mkProfitRatio.OutputFormat");
            this.mkProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkProfitRatio.Text = "999.99";
            this.mkProfitRatio.Top = 0.031F;
            this.mkProfitRatio.Width = 0.375F;
            // 
            // mkCmpProfitRatio
            // 
            this.mkCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.mkCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.mkCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.mkCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.mkCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkCmpProfitRatio.CanShrink = true;
            this.mkCmpProfitRatio.Height = 0.16F;
            this.mkCmpProfitRatio.Left = 10.375F;
            this.mkCmpProfitRatio.MultiLine = false;
            this.mkCmpProfitRatio.Name = "mkCmpProfitRatio";
            this.mkCmpProfitRatio.OutputFormat = resources.GetString("mkCmpProfitRatio.OutputFormat");
            this.mkCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkCmpProfitRatio.Text = "999.99";
            this.mkCmpProfitRatio.Top = 0.031F;
            this.mkCmpProfitRatio.Width = 0.375F;
            // 
            // mkGrossProfitSum
            // 
            this.mkGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.mkGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.mkGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.mkGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.mkGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitSum.CanShrink = true;
            this.mkGrossProfitSum.DataField = "GrossProfitSum";
            this.mkGrossProfitSum.Height = 0.16F;
            this.mkGrossProfitSum.Left = 0.688F;
            this.mkGrossProfitSum.MultiLine = false;
            this.mkGrossProfitSum.Name = "mkGrossProfitSum";
            this.mkGrossProfitSum.OutputFormat = resources.GetString("mkGrossProfitSum.OutputFormat");
            this.mkGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.mkGrossProfitSum.Top = 0.031F;
            this.mkGrossProfitSum.Visible = false;
            this.mkGrossProfitSum.Width = 0.7F;
            // 
            // mkTotalSalesMoneySum
            // 
            this.mkTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneySum.CanShrink = true;
            this.mkTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.mkTotalSalesMoneySum.Height = 0.16F;
            this.mkTotalSalesMoneySum.Left = 0F;
            this.mkTotalSalesMoneySum.MultiLine = false;
            this.mkTotalSalesMoneySum.Name = "mkTotalSalesMoneySum";
            this.mkTotalSalesMoneySum.OutputFormat = resources.GetString("mkTotalSalesMoneySum.OutputFormat");
            this.mkTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.mkTotalSalesMoneySum.Top = 0.031F;
            this.mkTotalSalesMoneySum.Visible = false;
            this.mkTotalSalesMoneySum.Width = 0.7F;
            // 
            // mkTotalSalesMoneyOrg
            // 
            this.mkTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.mkTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkTotalSalesMoneyOrg.CanShrink = true;
            this.mkTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.mkTotalSalesMoneyOrg.Height = 0.16F;
            this.mkTotalSalesMoneyOrg.Left = 1.375F;
            this.mkTotalSalesMoneyOrg.MultiLine = false;
            this.mkTotalSalesMoneyOrg.Name = "mkTotalSalesMoneyOrg";
            this.mkTotalSalesMoneyOrg.OutputFormat = resources.GetString("mkTotalSalesMoneyOrg.OutputFormat");
            this.mkTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkTotalSalesMoneyOrg.SummaryGroup = "MakerHeader";
            this.mkTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.mkTotalSalesMoneyOrg.Top = 0.031F;
            this.mkTotalSalesMoneyOrg.Visible = false;
            this.mkTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // mkGrossProfitOrg
            // 
            this.mkGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.mkGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.mkGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.mkGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.mkGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mkGrossProfitOrg.CanShrink = true;
            this.mkGrossProfitOrg.DataField = "GrossProfitOrg";
            this.mkGrossProfitOrg.Height = 0.16F;
            this.mkGrossProfitOrg.Left = 2.063F;
            this.mkGrossProfitOrg.MultiLine = false;
            this.mkGrossProfitOrg.Name = "mkGrossProfitOrg";
            this.mkGrossProfitOrg.OutputFormat = resources.GetString("mkGrossProfitOrg.OutputFormat");
            this.mkGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mkGrossProfitOrg.SummaryGroup = "MakerHeader";
            this.mkGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mkGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mkGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.mkGrossProfitOrg.Top = 0.031F;
            this.mkGrossProfitOrg.Visible = false;
            this.mkGrossProfitOrg.Width = 0.7F;
            // 
            // GoodsMGroupHeader
            // 
            this.GoodsMGroupHeader.CanShrink = true;
            this.GoodsMGroupHeader.DataField = "GoodsMGroupField";
            this.GoodsMGroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.GoodsMGroupHeader.Height = 0F;
            this.GoodsMGroupHeader.KeepTogether = true;
            this.GoodsMGroupHeader.Name = "GoodsMGroupHeader";
            this.GoodsMGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // GoodsMGroupFooter
            // 
            this.GoodsMGroupFooter.CanShrink = true;
            this.GoodsMGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox7,
            this.line7,
            this.mgTotalSalesCount,
            this.mgTotalSalesMoney,
            this.mgGrossProfit,
            this.mgCmpPureSalesRatio,
            this.mgProfitRatio,
            this.mgCmpProfitRatio,
            this.mgTotalSalesMoneySum,
            this.mgGrossProfitSum,
            this.mgTotalSalesMoneyOrg,
            this.mgGrossProfitOrg});
            this.GoodsMGroupFooter.Height = 0.2395833F;
            this.GoodsMGroupFooter.KeepTogether = true;
            this.GoodsMGroupFooter.Name = "GoodsMGroupFooter";
            this.GoodsMGroupFooter.BeforePrint += new System.EventHandler(this.GoodsMGroupFooter_BeforePrint);
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
            this.textBox7.Height = 0.2F;
            this.textBox7.Left = 4.25F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox7.Text = "商品中分類計";
            this.textBox7.Top = 0.031F;
            this.textBox7.Width = 1.3F;
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
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // mgTotalSalesCount
            // 
            this.mgTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.mgTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.mgTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.mgTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.mgTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesCount.CanShrink = true;
            this.mgTotalSalesCount.DataField = "TotalSalesCount";
            this.mgTotalSalesCount.Height = 0.16F;
            this.mgTotalSalesCount.Left = 7.09F;
            this.mgTotalSalesCount.MultiLine = false;
            this.mgTotalSalesCount.Name = "mgTotalSalesCount";
            this.mgTotalSalesCount.OutputFormat = resources.GetString("mgTotalSalesCount.OutputFormat");
            this.mgTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgTotalSalesCount.SummaryGroup = "GoodsMGroupHeader";
            this.mgTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.mgTotalSalesCount.Top = 0.031F;
            this.mgTotalSalesCount.Width = 0.8F;
            // 
            // mgTotalSalesMoney
            // 
            this.mgTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoney.CanShrink = true;
            this.mgTotalSalesMoney.DataField = "TotalSalesMoney";
            this.mgTotalSalesMoney.Height = 0.16F;
            this.mgTotalSalesMoney.Left = 7.91F;
            this.mgTotalSalesMoney.MultiLine = false;
            this.mgTotalSalesMoney.Name = "mgTotalSalesMoney";
            this.mgTotalSalesMoney.OutputFormat = resources.GetString("mgTotalSalesMoney.OutputFormat");
            this.mgTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgTotalSalesMoney.SummaryGroup = "GoodsMGroupHeader";
            this.mgTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.mgTotalSalesMoney.Top = 0.031F;
            this.mgTotalSalesMoney.Width = 0.8F;
            // 
            // mgGrossProfit
            // 
            this.mgGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.mgGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.mgGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.mgGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.mgGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfit.CanShrink = true;
            this.mgGrossProfit.DataField = "GrossProfit";
            this.mgGrossProfit.Height = 0.16F;
            this.mgGrossProfit.Left = 9.15F;
            this.mgGrossProfit.MultiLine = false;
            this.mgGrossProfit.Name = "mgGrossProfit";
            this.mgGrossProfit.OutputFormat = resources.GetString("mgGrossProfit.OutputFormat");
            this.mgGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgGrossProfit.SummaryGroup = "GoodsMGroupHeader";
            this.mgGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.mgGrossProfit.Top = 0.031F;
            this.mgGrossProfit.Width = 0.8F;
            // 
            // mgCmpPureSalesRatio
            // 
            this.mgCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.mgCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.mgCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.mgCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.mgCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpPureSalesRatio.CanShrink = true;
            this.mgCmpPureSalesRatio.Height = 0.16F;
            this.mgCmpPureSalesRatio.Left = 8.74F;
            this.mgCmpPureSalesRatio.MultiLine = false;
            this.mgCmpPureSalesRatio.Name = "mgCmpPureSalesRatio";
            this.mgCmpPureSalesRatio.OutputFormat = resources.GetString("mgCmpPureSalesRatio.OutputFormat");
            this.mgCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgCmpPureSalesRatio.Text = "999.99";
            this.mgCmpPureSalesRatio.Top = 0.031F;
            this.mgCmpPureSalesRatio.Width = 0.375F;
            // 
            // mgProfitRatio
            // 
            this.mgProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.mgProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.mgProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.mgProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.mgProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgProfitRatio.CanShrink = true;
            this.mgProfitRatio.Height = 0.16F;
            this.mgProfitRatio.Left = 9.98F;
            this.mgProfitRatio.MultiLine = false;
            this.mgProfitRatio.Name = "mgProfitRatio";
            this.mgProfitRatio.OutputFormat = resources.GetString("mgProfitRatio.OutputFormat");
            this.mgProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgProfitRatio.Text = "999.99";
            this.mgProfitRatio.Top = 0.031F;
            this.mgProfitRatio.Width = 0.375F;
            // 
            // mgCmpProfitRatio
            // 
            this.mgCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.mgCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.mgCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.mgCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.mgCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgCmpProfitRatio.CanShrink = true;
            this.mgCmpProfitRatio.Height = 0.16F;
            this.mgCmpProfitRatio.Left = 10.375F;
            this.mgCmpProfitRatio.MultiLine = false;
            this.mgCmpProfitRatio.Name = "mgCmpProfitRatio";
            this.mgCmpProfitRatio.OutputFormat = resources.GetString("mgCmpProfitRatio.OutputFormat");
            this.mgCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgCmpProfitRatio.Text = "999.99";
            this.mgCmpProfitRatio.Top = 0.031F;
            this.mgCmpProfitRatio.Width = 0.375F;
            // 
            // mgTotalSalesMoneySum
            // 
            this.mgTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneySum.CanShrink = true;
            this.mgTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.mgTotalSalesMoneySum.Height = 0.16F;
            this.mgTotalSalesMoneySum.Left = 0F;
            this.mgTotalSalesMoneySum.MultiLine = false;
            this.mgTotalSalesMoneySum.Name = "mgTotalSalesMoneySum";
            this.mgTotalSalesMoneySum.OutputFormat = resources.GetString("mgTotalSalesMoneySum.OutputFormat");
            this.mgTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.mgTotalSalesMoneySum.Top = 0.031F;
            this.mgTotalSalesMoneySum.Visible = false;
            this.mgTotalSalesMoneySum.Width = 0.7F;
            // 
            // mgGrossProfitSum
            // 
            this.mgGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.mgGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.mgGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.mgGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.mgGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitSum.CanShrink = true;
            this.mgGrossProfitSum.DataField = "GrossProfitSum";
            this.mgGrossProfitSum.Height = 0.16F;
            this.mgGrossProfitSum.Left = 0.688F;
            this.mgGrossProfitSum.MultiLine = false;
            this.mgGrossProfitSum.Name = "mgGrossProfitSum";
            this.mgGrossProfitSum.OutputFormat = resources.GetString("mgGrossProfitSum.OutputFormat");
            this.mgGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.mgGrossProfitSum.Top = 0.031F;
            this.mgGrossProfitSum.Visible = false;
            this.mgGrossProfitSum.Width = 0.7F;
            // 
            // mgTotalSalesMoneyOrg
            // 
            this.mgTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.mgTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgTotalSalesMoneyOrg.CanShrink = true;
            this.mgTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.mgTotalSalesMoneyOrg.Height = 0.16F;
            this.mgTotalSalesMoneyOrg.Left = 1.375F;
            this.mgTotalSalesMoneyOrg.MultiLine = false;
            this.mgTotalSalesMoneyOrg.Name = "mgTotalSalesMoneyOrg";
            this.mgTotalSalesMoneyOrg.OutputFormat = resources.GetString("mgTotalSalesMoneyOrg.OutputFormat");
            this.mgTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgTotalSalesMoneyOrg.SummaryGroup = "GoodsMGroupHeader";
            this.mgTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.mgTotalSalesMoneyOrg.Top = 0.031F;
            this.mgTotalSalesMoneyOrg.Visible = false;
            this.mgTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // mgGrossProfitOrg
            // 
            this.mgGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.mgGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.mgGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.mgGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.mgGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mgGrossProfitOrg.CanShrink = true;
            this.mgGrossProfitOrg.DataField = "GrossProfitOrg";
            this.mgGrossProfitOrg.Height = 0.16F;
            this.mgGrossProfitOrg.Left = 2.063F;
            this.mgGrossProfitOrg.MultiLine = false;
            this.mgGrossProfitOrg.Name = "mgGrossProfitOrg";
            this.mgGrossProfitOrg.OutputFormat = resources.GetString("mgGrossProfitOrg.OutputFormat");
            this.mgGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.mgGrossProfitOrg.SummaryGroup = "GoodsMGroupHeader";
            this.mgGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.mgGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.mgGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.mgGrossProfitOrg.Top = 0.031F;
            this.mgGrossProfitOrg.Visible = false;
            this.mgGrossProfitOrg.Width = 0.7F;
            // 
            // SuplierHeader
            // 
            this.SuplierHeader.CanShrink = true;
            this.SuplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupHd_AddUpSecCode,
            this.SupHd_SectionGuideNm,
            this.SupHd_SupplierCd,
            this.SupHd_SupplierNm,
            this.SupHd_SectionTitle,
            this.SupHd_SupplierTitle,
            this.line6});
            this.SuplierHeader.DataField = "SuplierField";
            this.SuplierHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SuplierHeader.Height = 0.25F;
            this.SuplierHeader.KeepTogether = true;
            this.SuplierHeader.Name = "SuplierHeader";
            this.SuplierHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.SuplierHeader.BeforePrint += new System.EventHandler(this.SuplierHeader_BeforePrint);
            // 
            // SupHd_AddUpSecCode
            // 
            this.SupHd_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_AddUpSecCode.DataField = "AddUpSecCode";
            this.SupHd_AddUpSecCode.Height = 0.16F;
            this.SupHd_AddUpSecCode.Left = 0.625F;
            this.SupHd_AddUpSecCode.MultiLine = false;
            this.SupHd_AddUpSecCode.Name = "SupHd_AddUpSecCode";
            this.SupHd_AddUpSecCode.OutputFormat = resources.GetString("SupHd_AddUpSecCode.OutputFormat");
            this.SupHd_AddUpSecCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_AddUpSecCode.Text = "12";
            this.SupHd_AddUpSecCode.Top = 0F;
            this.SupHd_AddUpSecCode.Width = 0.2F;
            // 
            // SupHd_SectionGuideNm
            // 
            this.SupHd_SectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionGuideNm.DataField = "SectionGuideNm";
            this.SupHd_SectionGuideNm.Height = 0.16F;
            this.SupHd_SectionGuideNm.Left = 0.875F;
            this.SupHd_SectionGuideNm.MultiLine = false;
            this.SupHd_SectionGuideNm.Name = "SupHd_SectionGuideNm";
            this.SupHd_SectionGuideNm.OutputFormat = resources.GetString("SupHd_SectionGuideNm.OutputFormat");
            this.SupHd_SectionGuideNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SupHd_SectionGuideNm.Text = "あいうえおかきくけこ";
            this.SupHd_SectionGuideNm.Top = 0F;
            this.SupHd_SectionGuideNm.Width = 1.2F;
            // 
            // SupHd_SupplierCd
            // 
            this.SupHd_SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierCd.DataField = "SupplierCd";
            this.SupHd_SupplierCd.Height = 0.16F;
            this.SupHd_SupplierCd.Left = 2.75F;
            this.SupHd_SupplierCd.MultiLine = false;
            this.SupHd_SupplierCd.Name = "SupHd_SupplierCd";
            this.SupHd_SupplierCd.OutputFormat = resources.GetString("SupHd_SupplierCd.OutputFormat");
            this.SupHd_SupplierCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertical" +
                "-align: top; ";
            this.SupHd_SupplierCd.Text = "123456";
            this.SupHd_SupplierCd.Top = 0F;
            this.SupHd_SupplierCd.Width = 0.385F;
            // 
            // SupHd_SupplierNm
            // 
            this.SupHd_SupplierNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierNm.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierNm.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierNm.DataField = "SupplierNm";
            this.SupHd_SupplierNm.Height = 0.16F;
            this.SupHd_SupplierNm.Left = 3.1875F;
            this.SupHd_SupplierNm.MultiLine = false;
            this.SupHd_SupplierNm.Name = "SupHd_SupplierNm";
            this.SupHd_SupplierNm.OutputFormat = resources.GetString("SupHd_SupplierNm.OutputFormat");
            this.SupHd_SupplierNm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.SupHd_SupplierNm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SupHd_SupplierNm.Top = 0F;
            this.SupHd_SupplierNm.Width = 2.3F;
            // 
            // SupHd_SectionTitle
            // 
            this.SupHd_SectionTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SectionTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SectionTitle.Height = 0.16F;
            this.SupHd_SectionTitle.HyperLink = "";
            this.SupHd_SectionTitle.Left = 0F;
            this.SupHd_SectionTitle.MultiLine = false;
            this.SupHd_SectionTitle.Name = "SupHd_SectionTitle";
            this.SupHd_SectionTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SectionTitle.Text = "拠点";
            this.SupHd_SectionTitle.Top = 0F;
            this.SupHd_SectionTitle.Width = 0.55F;
            // 
            // SupHd_SupplierTitle
            // 
            this.SupHd_SupplierTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SupHd_SupplierTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupHd_SupplierTitle.Height = 0.16F;
            this.SupHd_SupplierTitle.HyperLink = "";
            this.SupHd_SupplierTitle.Left = 2.125F;
            this.SupHd_SupplierTitle.MultiLine = false;
            this.SupHd_SupplierTitle.Name = "SupHd_SupplierTitle";
            this.SupHd_SupplierTitle.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.SupHd_SupplierTitle.Text = "仕入先";
            this.SupHd_SupplierTitle.Top = 0F;
            this.SupHd_SupplierTitle.Width = 0.55F;
            // 
            // SuplierFooter
            // 
            this.SuplierFooter.CanShrink = true;
            this.SuplierFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox13,
            this.line4,
            this.suTotalSalesCount,
            this.suTotalSalesMoney,
            this.suGrossProfit,
            this.suCmpPureSalesRatio,
            this.suProfitRatio,
            this.suCmpProfitRatio,
            this.suGrossProfitSum,
            this.suTotalSalesMoneySum,
            this.suTotalSalesMoneyOrg,
            this.suGrossProfitOrg});
            this.SuplierFooter.Height = 0.2395833F;
            this.SuplierFooter.KeepTogether = true;
            this.SuplierFooter.Name = "SuplierFooter";
            this.SuplierFooter.BeforePrint += new System.EventHandler(this.SuplierFooter_BeforePrint);
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
            this.textBox13.Height = 0.2F;
            this.textBox13.Left = 4.25F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox13.Text = "仕入先計";
            this.textBox13.Top = 0.031F;
            this.textBox13.Width = 1.3F;
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
            // suTotalSalesCount
            // 
            this.suTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.suTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesCount.CanShrink = true;
            this.suTotalSalesCount.DataField = "TotalSalesCount";
            this.suTotalSalesCount.Height = 0.16F;
            this.suTotalSalesCount.Left = 7.09F;
            this.suTotalSalesCount.MultiLine = false;
            this.suTotalSalesCount.Name = "suTotalSalesCount";
            this.suTotalSalesCount.OutputFormat = resources.GetString("suTotalSalesCount.OutputFormat");
            this.suTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suTotalSalesCount.SummaryGroup = "SuplierHeader";
            this.suTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.suTotalSalesCount.Top = 0.031F;
            this.suTotalSalesCount.Width = 0.8F;
            // 
            // suTotalSalesMoney
            // 
            this.suTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.suTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.suTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.suTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.suTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoney.CanShrink = true;
            this.suTotalSalesMoney.DataField = "TotalSalesMoney";
            this.suTotalSalesMoney.Height = 0.16F;
            this.suTotalSalesMoney.Left = 7.91F;
            this.suTotalSalesMoney.MultiLine = false;
            this.suTotalSalesMoney.Name = "suTotalSalesMoney";
            this.suTotalSalesMoney.OutputFormat = resources.GetString("suTotalSalesMoney.OutputFormat");
            this.suTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suTotalSalesMoney.SummaryGroup = "SuplierHeader";
            this.suTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.suTotalSalesMoney.Top = 0.031F;
            this.suTotalSalesMoney.Width = 0.8F;
            // 
            // suGrossProfit
            // 
            this.suGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.suGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.suGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.suGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.suGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfit.CanShrink = true;
            this.suGrossProfit.DataField = "GrossProfit";
            this.suGrossProfit.Height = 0.16F;
            this.suGrossProfit.Left = 9.15F;
            this.suGrossProfit.MultiLine = false;
            this.suGrossProfit.Name = "suGrossProfit";
            this.suGrossProfit.OutputFormat = resources.GetString("suGrossProfit.OutputFormat");
            this.suGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suGrossProfit.SummaryGroup = "SuplierHeader";
            this.suGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.suGrossProfit.Top = 0.031F;
            this.suGrossProfit.Width = 0.8F;
            // 
            // suCmpPureSalesRatio
            // 
            this.suCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.suCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpPureSalesRatio.CanShrink = true;
            this.suCmpPureSalesRatio.Height = 0.16F;
            this.suCmpPureSalesRatio.Left = 8.74F;
            this.suCmpPureSalesRatio.MultiLine = false;
            this.suCmpPureSalesRatio.Name = "suCmpPureSalesRatio";
            this.suCmpPureSalesRatio.OutputFormat = resources.GetString("suCmpPureSalesRatio.OutputFormat");
            this.suCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suCmpPureSalesRatio.Text = "999.99";
            this.suCmpPureSalesRatio.Top = 0.031F;
            this.suCmpPureSalesRatio.Width = 0.375F;
            // 
            // suProfitRatio
            // 
            this.suProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.suProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suProfitRatio.CanShrink = true;
            this.suProfitRatio.Height = 0.16F;
            this.suProfitRatio.Left = 9.98F;
            this.suProfitRatio.MultiLine = false;
            this.suProfitRatio.Name = "suProfitRatio";
            this.suProfitRatio.OutputFormat = resources.GetString("suProfitRatio.OutputFormat");
            this.suProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suProfitRatio.Text = "999.99";
            this.suProfitRatio.Top = 0.031F;
            this.suProfitRatio.Width = 0.375F;
            // 
            // suCmpProfitRatio
            // 
            this.suCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.suCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.suCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.suCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.suCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suCmpProfitRatio.CanShrink = true;
            this.suCmpProfitRatio.Height = 0.16F;
            this.suCmpProfitRatio.Left = 10.375F;
            this.suCmpProfitRatio.MultiLine = false;
            this.suCmpProfitRatio.Name = "suCmpProfitRatio";
            this.suCmpProfitRatio.OutputFormat = resources.GetString("suCmpProfitRatio.OutputFormat");
            this.suCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suCmpProfitRatio.Text = "999.99";
            this.suCmpProfitRatio.Top = 0.031F;
            this.suCmpProfitRatio.Width = 0.375F;
            // 
            // suGrossProfitSum
            // 
            this.suGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.suGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.suGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.suGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.suGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitSum.CanShrink = true;
            this.suGrossProfitSum.DataField = "GrossProfitSum";
            this.suGrossProfitSum.Height = 0.16F;
            this.suGrossProfitSum.Left = 0.688F;
            this.suGrossProfitSum.MultiLine = false;
            this.suGrossProfitSum.Name = "suGrossProfitSum";
            this.suGrossProfitSum.OutputFormat = resources.GetString("suGrossProfitSum.OutputFormat");
            this.suGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.suGrossProfitSum.Top = 0.031F;
            this.suGrossProfitSum.Visible = false;
            this.suGrossProfitSum.Width = 0.7F;
            // 
            // suTotalSalesMoneySum
            // 
            this.suTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneySum.CanShrink = true;
            this.suTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.suTotalSalesMoneySum.Height = 0.16F;
            this.suTotalSalesMoneySum.Left = 0F;
            this.suTotalSalesMoneySum.MultiLine = false;
            this.suTotalSalesMoneySum.Name = "suTotalSalesMoneySum";
            this.suTotalSalesMoneySum.OutputFormat = resources.GetString("suTotalSalesMoneySum.OutputFormat");
            this.suTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.suTotalSalesMoneySum.Top = 0.031F;
            this.suTotalSalesMoneySum.Visible = false;
            this.suTotalSalesMoneySum.Width = 0.7F;
            // 
            // suTotalSalesMoneyOrg
            // 
            this.suTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.suTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suTotalSalesMoneyOrg.CanShrink = true;
            this.suTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.suTotalSalesMoneyOrg.Height = 0.16F;
            this.suTotalSalesMoneyOrg.Left = 1.375F;
            this.suTotalSalesMoneyOrg.MultiLine = false;
            this.suTotalSalesMoneyOrg.Name = "suTotalSalesMoneyOrg";
            this.suTotalSalesMoneyOrg.OutputFormat = resources.GetString("suTotalSalesMoneyOrg.OutputFormat");
            this.suTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suTotalSalesMoneyOrg.SummaryGroup = "SuplierHeader";
            this.suTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.suTotalSalesMoneyOrg.Top = 0.031F;
            this.suTotalSalesMoneyOrg.Visible = false;
            this.suTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // suGrossProfitOrg
            // 
            this.suGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.suGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.suGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.suGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.suGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suGrossProfitOrg.CanShrink = true;
            this.suGrossProfitOrg.DataField = "GrossProfitOrg";
            this.suGrossProfitOrg.Height = 0.16F;
            this.suGrossProfitOrg.Left = 2.063F;
            this.suGrossProfitOrg.MultiLine = false;
            this.suGrossProfitOrg.Name = "suGrossProfitOrg";
            this.suGrossProfitOrg.OutputFormat = resources.GetString("suGrossProfitOrg.OutputFormat");
            this.suGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.suGrossProfitOrg.SummaryGroup = "SuplierHeader";
            this.suGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.suGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.suGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.suGrossProfitOrg.Top = 0.031F;
            this.suGrossProfitOrg.Visible = false;
            this.suGrossProfitOrg.Width = 0.7F;
            // 
            // GoodsLGroupHeader
            // 
            this.GoodsLGroupHeader.CanShrink = true;
            this.GoodsLGroupHeader.DataField = "GoodsLGroupField";
            this.GoodsLGroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.GoodsLGroupHeader.Height = 0F;
            this.GoodsLGroupHeader.KeepTogether = true;
            this.GoodsLGroupHeader.Name = "GoodsLGroupHeader";
            this.GoodsLGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // GoodsLGroupFooter
            // 
            this.GoodsLGroupFooter.CanShrink = true;
            this.GoodsLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox6,
            this.lgTotalSalesCount,
            this.lgTotalSalesMoney,
            this.lgGrossProfit,
            this.lgCmpPureSalesRatio,
            this.lgProfitRatio,
            this.lgCmpProfitRatio,
            this.lgTotalSalesMoneySum,
            this.lgGrossProfitSum,
            this.line2,
            this.lgTotalSalesMoneyOrg,
            this.lgGrossProfitOrg});
            this.GoodsLGroupFooter.Height = 0.25F;
            this.GoodsLGroupFooter.KeepTogether = true;
            this.GoodsLGroupFooter.Name = "GoodsLGroupFooter";
            this.GoodsLGroupFooter.BeforePrint += new System.EventHandler(this.GoodsLGroupFooter_BeforePrint);
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Height = 0.2F;
            this.textBox6.Left = 4.25F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox6.Text = "商品大分類計";
            this.textBox6.Top = 0.031F;
            this.textBox6.Width = 1.3F;
            // 
            // lgTotalSalesCount
            // 
            this.lgTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.lgTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.lgTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.lgTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.lgTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesCount.CanShrink = true;
            this.lgTotalSalesCount.DataField = "TotalSalesCount";
            this.lgTotalSalesCount.Height = 0.16F;
            this.lgTotalSalesCount.Left = 7.09F;
            this.lgTotalSalesCount.MultiLine = false;
            this.lgTotalSalesCount.Name = "lgTotalSalesCount";
            this.lgTotalSalesCount.OutputFormat = resources.GetString("lgTotalSalesCount.OutputFormat");
            this.lgTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgTotalSalesCount.SummaryGroup = "GoodsLGroupHeader";
            this.lgTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.lgTotalSalesCount.Top = 0.031F;
            this.lgTotalSalesCount.Width = 0.8F;
            // 
            // lgTotalSalesMoney
            // 
            this.lgTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoney.CanShrink = true;
            this.lgTotalSalesMoney.DataField = "TotalSalesMoney";
            this.lgTotalSalesMoney.Height = 0.16F;
            this.lgTotalSalesMoney.Left = 7.91F;
            this.lgTotalSalesMoney.MultiLine = false;
            this.lgTotalSalesMoney.Name = "lgTotalSalesMoney";
            this.lgTotalSalesMoney.OutputFormat = resources.GetString("lgTotalSalesMoney.OutputFormat");
            this.lgTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgTotalSalesMoney.SummaryGroup = "GoodsLGroupHeader";
            this.lgTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.lgTotalSalesMoney.Top = 0.031F;
            this.lgTotalSalesMoney.Width = 0.8F;
            // 
            // lgGrossProfit
            // 
            this.lgGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.lgGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.lgGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.lgGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.lgGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfit.CanShrink = true;
            this.lgGrossProfit.DataField = "GrossProfit";
            this.lgGrossProfit.Height = 0.16F;
            this.lgGrossProfit.Left = 9.15F;
            this.lgGrossProfit.MultiLine = false;
            this.lgGrossProfit.Name = "lgGrossProfit";
            this.lgGrossProfit.OutputFormat = resources.GetString("lgGrossProfit.OutputFormat");
            this.lgGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgGrossProfit.SummaryGroup = "GoodsLGroupHeader";
            this.lgGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.lgGrossProfit.Top = 0.031F;
            this.lgGrossProfit.Width = 0.8F;
            // 
            // lgCmpPureSalesRatio
            // 
            this.lgCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.lgCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.lgCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.lgCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.lgCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpPureSalesRatio.CanShrink = true;
            this.lgCmpPureSalesRatio.Height = 0.16F;
            this.lgCmpPureSalesRatio.Left = 8.74F;
            this.lgCmpPureSalesRatio.MultiLine = false;
            this.lgCmpPureSalesRatio.Name = "lgCmpPureSalesRatio";
            this.lgCmpPureSalesRatio.OutputFormat = resources.GetString("lgCmpPureSalesRatio.OutputFormat");
            this.lgCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgCmpPureSalesRatio.Text = "999.99";
            this.lgCmpPureSalesRatio.Top = 0.031F;
            this.lgCmpPureSalesRatio.Width = 0.375F;
            // 
            // lgProfitRatio
            // 
            this.lgProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.lgProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.lgProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.lgProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.lgProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgProfitRatio.CanShrink = true;
            this.lgProfitRatio.Height = 0.16F;
            this.lgProfitRatio.Left = 9.98F;
            this.lgProfitRatio.MultiLine = false;
            this.lgProfitRatio.Name = "lgProfitRatio";
            this.lgProfitRatio.OutputFormat = resources.GetString("lgProfitRatio.OutputFormat");
            this.lgProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgProfitRatio.Text = "999.99";
            this.lgProfitRatio.Top = 0.031F;
            this.lgProfitRatio.Width = 0.375F;
            // 
            // lgCmpProfitRatio
            // 
            this.lgCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.lgCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.lgCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.lgCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.lgCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgCmpProfitRatio.CanShrink = true;
            this.lgCmpProfitRatio.Height = 0.16F;
            this.lgCmpProfitRatio.Left = 10.375F;
            this.lgCmpProfitRatio.MultiLine = false;
            this.lgCmpProfitRatio.Name = "lgCmpProfitRatio";
            this.lgCmpProfitRatio.OutputFormat = resources.GetString("lgCmpProfitRatio.OutputFormat");
            this.lgCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgCmpProfitRatio.Text = "999.99";
            this.lgCmpProfitRatio.Top = 0.031F;
            this.lgCmpProfitRatio.Width = 0.375F;
            // 
            // lgTotalSalesMoneySum
            // 
            this.lgTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneySum.CanShrink = true;
            this.lgTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.lgTotalSalesMoneySum.Height = 0.16F;
            this.lgTotalSalesMoneySum.Left = 0F;
            this.lgTotalSalesMoneySum.MultiLine = false;
            this.lgTotalSalesMoneySum.Name = "lgTotalSalesMoneySum";
            this.lgTotalSalesMoneySum.OutputFormat = resources.GetString("lgTotalSalesMoneySum.OutputFormat");
            this.lgTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.lgTotalSalesMoneySum.Top = 0.031F;
            this.lgTotalSalesMoneySum.Visible = false;
            this.lgTotalSalesMoneySum.Width = 0.7F;
            // 
            // lgGrossProfitSum
            // 
            this.lgGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.lgGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.lgGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.lgGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.lgGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitSum.CanShrink = true;
            this.lgGrossProfitSum.DataField = "GrossProfitSum";
            this.lgGrossProfitSum.Height = 0.16F;
            this.lgGrossProfitSum.Left = 0.688F;
            this.lgGrossProfitSum.MultiLine = false;
            this.lgGrossProfitSum.Name = "lgGrossProfitSum";
            this.lgGrossProfitSum.OutputFormat = resources.GetString("lgGrossProfitSum.OutputFormat");
            this.lgGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.lgGrossProfitSum.Top = 0.031F;
            this.lgGrossProfitSum.Visible = false;
            this.lgGrossProfitSum.Width = 0.7F;
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
            // lgTotalSalesMoneyOrg
            // 
            this.lgTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.lgTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgTotalSalesMoneyOrg.CanShrink = true;
            this.lgTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.lgTotalSalesMoneyOrg.Height = 0.16F;
            this.lgTotalSalesMoneyOrg.Left = 1.375F;
            this.lgTotalSalesMoneyOrg.MultiLine = false;
            this.lgTotalSalesMoneyOrg.Name = "lgTotalSalesMoneyOrg";
            this.lgTotalSalesMoneyOrg.OutputFormat = resources.GetString("lgTotalSalesMoneyOrg.OutputFormat");
            this.lgTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgTotalSalesMoneyOrg.SummaryGroup = "GoodsLGroupHeader";
            this.lgTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.lgTotalSalesMoneyOrg.Top = 0.031F;
            this.lgTotalSalesMoneyOrg.Visible = false;
            this.lgTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // lgGrossProfitOrg
            // 
            this.lgGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.lgGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.lgGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.lgGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.lgGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lgGrossProfitOrg.CanShrink = true;
            this.lgGrossProfitOrg.DataField = "GrossProfitOrg";
            this.lgGrossProfitOrg.Height = 0.16F;
            this.lgGrossProfitOrg.Left = 2.063F;
            this.lgGrossProfitOrg.MultiLine = false;
            this.lgGrossProfitOrg.Name = "lgGrossProfitOrg";
            this.lgGrossProfitOrg.OutputFormat = resources.GetString("lgGrossProfitOrg.OutputFormat");
            this.lgGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.lgGrossProfitOrg.SummaryGroup = "GoodsLGroupHeader";
            this.lgGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.lgGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.lgGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.lgGrossProfitOrg.Top = 0.031F;
            this.lgGrossProfitOrg.Visible = false;
            this.lgGrossProfitOrg.Width = 0.7F;
            // 
            // BLGroupHeader
            // 
            this.BLGroupHeader.CanShrink = true;
            this.BLGroupHeader.DataField = "BLGroupField";
            this.BLGroupHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.BLGroupHeader.Height = 0F;
            this.BLGroupHeader.KeepTogether = true;
            this.BLGroupHeader.Name = "BLGroupHeader";
            this.BLGroupHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // BLGroupFooter
            // 
            this.BLGroupFooter.CanShrink = true;
            this.BLGroupFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox21,
            this.line8,
            this.grTotalSalesCount,
            this.grTotalSalesMoney,
            this.grGrossProfit,
            this.grCmpPureSalesRatio,
            this.grProfitRatio,
            this.grCmpProfitRatio,
            this.grTotalSalesMoneySum,
            this.grGrossProfitSum,
            this.subTotalBLGroupKanaName,
            this.subTotalBLGroupCode,
            this.grTotalSalesMoneyOrg,
            this.grGrossProfitOrg});
            this.BLGroupFooter.Height = 0.28125F;
            this.BLGroupFooter.KeepTogether = true;
            this.BLGroupFooter.Name = "BLGroupFooter";
            this.BLGroupFooter.BeforePrint += new System.EventHandler(this.BLGroupFooter_BeforePrint);
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
            this.textBox21.Height = 0.2F;
            this.textBox21.Left = 4.25F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox21.Text = "グループコード計";
            this.textBox21.Top = 0.031F;
            this.textBox21.Width = 1.3F;
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
            // grTotalSalesCount
            // 
            this.grTotalSalesCount.Border.BottomColor = System.Drawing.Color.Black;
            this.grTotalSalesCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesCount.Border.LeftColor = System.Drawing.Color.Black;
            this.grTotalSalesCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesCount.Border.RightColor = System.Drawing.Color.Black;
            this.grTotalSalesCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesCount.Border.TopColor = System.Drawing.Color.Black;
            this.grTotalSalesCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesCount.CanShrink = true;
            this.grTotalSalesCount.DataField = "TotalSalesCount";
            this.grTotalSalesCount.Height = 0.16F;
            this.grTotalSalesCount.Left = 7.09F;
            this.grTotalSalesCount.MultiLine = false;
            this.grTotalSalesCount.Name = "grTotalSalesCount";
            this.grTotalSalesCount.OutputFormat = resources.GetString("grTotalSalesCount.OutputFormat");
            this.grTotalSalesCount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grTotalSalesCount.SummaryGroup = "BLGroupHeader";
            this.grTotalSalesCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grTotalSalesCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grTotalSalesCount.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.grTotalSalesCount.Top = 0.031F;
            this.grTotalSalesCount.Width = 0.8F;
            // 
            // grTotalSalesMoney
            // 
            this.grTotalSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.grTotalSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.grTotalSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.grTotalSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.grTotalSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoney.CanShrink = true;
            this.grTotalSalesMoney.DataField = "TotalSalesMoney";
            this.grTotalSalesMoney.Height = 0.16F;
            this.grTotalSalesMoney.Left = 7.91F;
            this.grTotalSalesMoney.MultiLine = false;
            this.grTotalSalesMoney.Name = "grTotalSalesMoney";
            this.grTotalSalesMoney.OutputFormat = resources.GetString("grTotalSalesMoney.OutputFormat");
            this.grTotalSalesMoney.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grTotalSalesMoney.SummaryGroup = "BLGroupHeader";
            this.grTotalSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grTotalSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grTotalSalesMoney.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.grTotalSalesMoney.Top = 0.031F;
            this.grTotalSalesMoney.Width = 0.8F;
            // 
            // grGrossProfit
            // 
            this.grGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.grGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.grGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.grGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.grGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfit.CanShrink = true;
            this.grGrossProfit.DataField = "GrossProfit";
            this.grGrossProfit.Height = 0.16F;
            this.grGrossProfit.Left = 9.15F;
            this.grGrossProfit.MultiLine = false;
            this.grGrossProfit.Name = "grGrossProfit";
            this.grGrossProfit.OutputFormat = resources.GetString("grGrossProfit.OutputFormat");
            this.grGrossProfit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grGrossProfit.SummaryGroup = "BLGroupHeader";
            this.grGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grGrossProfit.Text = "Z,ZZZ,ZZZ,ZZ9";
            this.grGrossProfit.Top = 0.031F;
            this.grGrossProfit.Width = 0.8F;
            // 
            // grCmpPureSalesRatio
            // 
            this.grCmpPureSalesRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.grCmpPureSalesRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpPureSalesRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.grCmpPureSalesRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpPureSalesRatio.Border.RightColor = System.Drawing.Color.Black;
            this.grCmpPureSalesRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpPureSalesRatio.Border.TopColor = System.Drawing.Color.Black;
            this.grCmpPureSalesRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpPureSalesRatio.CanShrink = true;
            this.grCmpPureSalesRatio.Height = 0.16F;
            this.grCmpPureSalesRatio.Left = 8.74F;
            this.grCmpPureSalesRatio.MultiLine = false;
            this.grCmpPureSalesRatio.Name = "grCmpPureSalesRatio";
            this.grCmpPureSalesRatio.OutputFormat = resources.GetString("grCmpPureSalesRatio.OutputFormat");
            this.grCmpPureSalesRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grCmpPureSalesRatio.Text = "999.99";
            this.grCmpPureSalesRatio.Top = 0.031F;
            this.grCmpPureSalesRatio.Width = 0.375F;
            // 
            // grProfitRatio
            // 
            this.grProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.grProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.grProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.grProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.grProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grProfitRatio.CanShrink = true;
            this.grProfitRatio.Height = 0.16F;
            this.grProfitRatio.Left = 9.98F;
            this.grProfitRatio.MultiLine = false;
            this.grProfitRatio.Name = "grProfitRatio";
            this.grProfitRatio.OutputFormat = resources.GetString("grProfitRatio.OutputFormat");
            this.grProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grProfitRatio.Text = "999.99";
            this.grProfitRatio.Top = 0.031F;
            this.grProfitRatio.Width = 0.375F;
            // 
            // grCmpProfitRatio
            // 
            this.grCmpProfitRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.grCmpProfitRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpProfitRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.grCmpProfitRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpProfitRatio.Border.RightColor = System.Drawing.Color.Black;
            this.grCmpProfitRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpProfitRatio.Border.TopColor = System.Drawing.Color.Black;
            this.grCmpProfitRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grCmpProfitRatio.CanShrink = true;
            this.grCmpProfitRatio.Height = 0.16F;
            this.grCmpProfitRatio.Left = 10.375F;
            this.grCmpProfitRatio.MultiLine = false;
            this.grCmpProfitRatio.Name = "grCmpProfitRatio";
            this.grCmpProfitRatio.OutputFormat = resources.GetString("grCmpProfitRatio.OutputFormat");
            this.grCmpProfitRatio.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grCmpProfitRatio.Text = "999.99";
            this.grCmpProfitRatio.Top = 0.031F;
            this.grCmpProfitRatio.Width = 0.375F;
            // 
            // grTotalSalesMoneySum
            // 
            this.grTotalSalesMoneySum.Border.BottomColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneySum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneySum.Border.LeftColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneySum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneySum.Border.RightColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneySum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneySum.Border.TopColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneySum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneySum.CanShrink = true;
            this.grTotalSalesMoneySum.DataField = "TotalSalesMoneySum";
            this.grTotalSalesMoneySum.Height = 0.16F;
            this.grTotalSalesMoneySum.Left = 0F;
            this.grTotalSalesMoneySum.MultiLine = false;
            this.grTotalSalesMoneySum.Name = "grTotalSalesMoneySum";
            this.grTotalSalesMoneySum.OutputFormat = resources.GetString("grTotalSalesMoneySum.OutputFormat");
            this.grTotalSalesMoneySum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grTotalSalesMoneySum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grTotalSalesMoneySum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grTotalSalesMoneySum.Text = "ZZZZ,ZZZ,ZZ9";
            this.grTotalSalesMoneySum.Top = 0.031F;
            this.grTotalSalesMoneySum.Visible = false;
            this.grTotalSalesMoneySum.Width = 0.7F;
            // 
            // grGrossProfitSum
            // 
            this.grGrossProfitSum.Border.BottomColor = System.Drawing.Color.Black;
            this.grGrossProfitSum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitSum.Border.LeftColor = System.Drawing.Color.Black;
            this.grGrossProfitSum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitSum.Border.RightColor = System.Drawing.Color.Black;
            this.grGrossProfitSum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitSum.Border.TopColor = System.Drawing.Color.Black;
            this.grGrossProfitSum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitSum.CanShrink = true;
            this.grGrossProfitSum.DataField = "GrossProfitSum";
            this.grGrossProfitSum.Height = 0.16F;
            this.grGrossProfitSum.Left = 0.688F;
            this.grGrossProfitSum.MultiLine = false;
            this.grGrossProfitSum.Name = "grGrossProfitSum";
            this.grGrossProfitSum.OutputFormat = resources.GetString("grGrossProfitSum.OutputFormat");
            this.grGrossProfitSum.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grGrossProfitSum.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grGrossProfitSum.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grGrossProfitSum.Text = "ZZZZ,ZZZ,ZZ9";
            this.grGrossProfitSum.Top = 0.031F;
            this.grGrossProfitSum.Visible = false;
            this.grGrossProfitSum.Width = 0.7F;
            // 
            // subTotalBLGroupKanaName
            // 
            this.subTotalBLGroupKanaName.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalBLGroupKanaName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupKanaName.DataField = "BLGroupKanaName";
            this.subTotalBLGroupKanaName.Height = 0.16F;
            this.subTotalBLGroupKanaName.Left = 5.935F;
            this.subTotalBLGroupKanaName.MultiLine = false;
            this.subTotalBLGroupKanaName.Name = "subTotalBLGroupKanaName";
            this.subTotalBLGroupKanaName.OutputFormat = resources.GetString("subTotalBLGroupKanaName.OutputFormat");
            this.subTotalBLGroupKanaName.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: top; ";
            this.subTotalBLGroupKanaName.Text = "12345678901234567890";
            this.subTotalBLGroupKanaName.Top = 0.031F;
            this.subTotalBLGroupKanaName.Width = 1.15F;
            // 
            // subTotalBLGroupCode
            // 
            this.subTotalBLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.subTotalBLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subTotalBLGroupCode.DataField = "BLGroupCode";
            this.subTotalBLGroupCode.Height = 0.16F;
            this.subTotalBLGroupCode.Left = 5.625F;
            this.subTotalBLGroupCode.MultiLine = false;
            this.subTotalBLGroupCode.Name = "subTotalBLGroupCode";
            this.subTotalBLGroupCode.OutputFormat = resources.GetString("subTotalBLGroupCode.OutputFormat");
            this.subTotalBLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ ゴシック; vertical-align: top; ";
            this.subTotalBLGroupCode.Text = "12345";
            this.subTotalBLGroupCode.Top = 0.031F;
            this.subTotalBLGroupCode.Width = 0.32F;
            // 
            // grTotalSalesMoneyOrg
            // 
            this.grTotalSalesMoneyOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneyOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneyOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneyOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneyOrg.Border.RightColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneyOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneyOrg.Border.TopColor = System.Drawing.Color.Black;
            this.grTotalSalesMoneyOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grTotalSalesMoneyOrg.CanShrink = true;
            this.grTotalSalesMoneyOrg.DataField = "TotalSalesMoneyOrg";
            this.grTotalSalesMoneyOrg.Height = 0.16F;
            this.grTotalSalesMoneyOrg.Left = 1.375F;
            this.grTotalSalesMoneyOrg.MultiLine = false;
            this.grTotalSalesMoneyOrg.Name = "grTotalSalesMoneyOrg";
            this.grTotalSalesMoneyOrg.OutputFormat = resources.GetString("grTotalSalesMoneyOrg.OutputFormat");
            this.grTotalSalesMoneyOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grTotalSalesMoneyOrg.SummaryGroup = "BLGroupHeader";
            this.grTotalSalesMoneyOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grTotalSalesMoneyOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grTotalSalesMoneyOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.grTotalSalesMoneyOrg.Top = 0.031F;
            this.grTotalSalesMoneyOrg.Visible = false;
            this.grTotalSalesMoneyOrg.Width = 0.7F;
            // 
            // grGrossProfitOrg
            // 
            this.grGrossProfitOrg.Border.BottomColor = System.Drawing.Color.Black;
            this.grGrossProfitOrg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitOrg.Border.LeftColor = System.Drawing.Color.Black;
            this.grGrossProfitOrg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitOrg.Border.RightColor = System.Drawing.Color.Black;
            this.grGrossProfitOrg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitOrg.Border.TopColor = System.Drawing.Color.Black;
            this.grGrossProfitOrg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.grGrossProfitOrg.CanShrink = true;
            this.grGrossProfitOrg.DataField = "GrossProfitOrg";
            this.grGrossProfitOrg.Height = 0.16F;
            this.grGrossProfitOrg.Left = 2.063F;
            this.grGrossProfitOrg.MultiLine = false;
            this.grGrossProfitOrg.Name = "grGrossProfitOrg";
            this.grGrossProfitOrg.OutputFormat = resources.GetString("grGrossProfitOrg.OutputFormat");
            this.grGrossProfitOrg.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; vertical-align: top; ";
            this.grGrossProfitOrg.SummaryGroup = "BLGroupHeader";
            this.grGrossProfitOrg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.grGrossProfitOrg.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.grGrossProfitOrg.Text = "ZZZZ,ZZZ,ZZ9";
            this.grGrossProfitOrg.Top = 0.031F;
            this.grGrossProfitOrg.Visible = false;
            this.grGrossProfitOrg.Width = 0.7F;
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
            // DCHNB02052P_02A4C
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
            this.PrintWidth = 10.88542F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SuplierHeader);
            this.Sections.Add(this.MakerHeader);
            this.Sections.Add(this.GoodsLGroupHeader);
            this.Sections.Add(this.GoodsMGroupHeader);
            this.Sections.Add(this.BLGroupHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.BLGroupFooter);
            this.Sections.Add(this.GoodsMGroupFooter);
            this.Sections.Add(this.GoodsLGroupFooter);
            this.Sections.Add(this.MakerFooter);
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
            this.PageEnd += new System.EventHandler(this.MAZAI02032P_02A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.MAZAI02032P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsLGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mkGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mgGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SectionTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupHd_SupplierTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCmpPureSalesRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grCmpProfitRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesMoneySum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGrossProfitSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupKanaName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subTotalBLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTotalSalesMoneyOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grGrossProfitOrg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
        
	}
}
