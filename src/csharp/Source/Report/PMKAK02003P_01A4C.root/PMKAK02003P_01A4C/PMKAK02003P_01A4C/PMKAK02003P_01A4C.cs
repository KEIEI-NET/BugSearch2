//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
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
	/// 支払一覧表（総括）印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 支払一覧表（総括）のフォームクラスです。</br>
	/// <br>Programmer : FSI東 隆史</br>
	/// <br>Date       : 2012/09/04</br>
    /// </remarks>
	public class PMKAK02003P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 支払一覧表（総括）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 支払一覧表（総括）フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
		public PMKAK02003P_01A4C()
		{
			InitializeComponent();
            this._outputCnt = 0;
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			 _otherDataList;				// その他データ

		private	SumSuplierPayMainCndtn	 _sumSuplierPayMainCndtn;			// 抽出条件クラス

		// その他データ格納項目
		private string				 _detailAddupSecNameTtl;		// 明細拠点名称タイトル

		private int					 _printCount;					// ページ数カウント用

        private DataSet _outputDs;						            // 印刷用DataSet
        private int _outputCnt;										// 支払内訳抽出用カウンタ
        private const string ct_SuplierPayMainTable = PMKAK02005EA.Col_Tbl_SuplierPayMain;		// 支払一覧表（総括）テーブル名称
        // サブレポート用レポートクラス宣言
        DrawingDetail _rptDrawingDetail = null;
		
		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
        ListCommon_PageFooter _rptPageFooter = null;
        private SubReport DrawingDetail_SubReport;
        private Label Label_CashPayment;
        private Label Label_TrfrPayment;
        private Label Label_CheckPayment;
        private Label Label_DraftPayment;
        private Label Label_OffsetPayment;
        private Label Label_OthsPayment;
        private Label Label_FundTransferPayment;
        private Label Label_ThisTimeFeePayNrml;
        private Label Label_ThisTimeDisPayNrml;
        private TextBox PaymentMonthName;
        private TextBox textBox10;
        private TextBox ThisTimeDisPayNrml;
        private TextBox ThisTimeFeePayNrml;
        private TextBox CashPayment;
        private TextBox TrfrPayment;
        private TextBox CheckPayment;
        private TextBox DraftPayment;
        private TextBox OffsetPayment;
        private TextBox StockTtl3TmBfBlPay;
        private TextBox StockTtl2TmBfBlPay;
        private TextBox LastTimePayment;
        private TextBox OthsPayment;
        private TextBox FundTransferPayment;
        private Label label18;
        private Label label19;
        private TextBox s_TrfrPayment;
        private TextBox s_CheckPayment;
        private TextBox s_DraftPayment;
        private TextBox s_OffsetPayment;
        private TextBox s_StockTtl3TmBfBlPay;
        private TextBox s_StockTtl2TmBfBlPay;
        private TextBox s_LastTimePayment;
        private TextBox s_OthsPayment;
        private TextBox s_FundTransferPayment;
        private TextBox s_ThisTimeFeePayNrml;
        private TextBox s_ThisTimeDisPayNrml;
        private TextBox t_TrfrPayment;
        private TextBox t_CheckPayment;
        private TextBox t_DraftPayment;
        private TextBox t_OffsetPayment;
        private TextBox t_StockTtl3TmBfBlPay;
        private TextBox t_StockTtl2TmBfBlPay;
        private TextBox t_LastTimePayment;
        private TextBox t_ThisTimeDisPayNrml;
        private TextBox t_FundTransferPayment;
        private TextBox t_ThisTimeFeePayNrml;
        private TextBox t_OthsPayment;
        private TextBox SumAddUpSecCode;
        private TextBox SumAddUpSecName;
        private Line line2;
        private TextBox ResultsSectCd;
        private GroupHeader SumSuplierPayHeader;
        private GroupFooter SumSuplierPayFooter;

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
		#endregion

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
				this._printInfo = value;
				this._sumSuplierPayMainCndtn = (SumSuplierPayMainCndtn)this._printInfo.jyoken;
                this._outputDs = (DataSet)this._printInfo.rdData;
			}
		}

		/// <summary>
		/// その他データ
		/// </summary>
		public ArrayList OtherDataList
		{
			set
			{
				this._otherDataList = value;
				if (this._otherDataList != null)
				{
					if ( this._otherDataList.Count > 0 )
					{
						this._detailAddupSecNameTtl = this._otherDataList[0].ToString();
					}
				}
			}
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderSubtitle = value;}
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
				// TODO:  PMKAK02003P_03A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKAK02003P_03A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			// 項目の名称をセット
			tb_ReportTitle.Text			= this._pageHeaderSubtitle;				// サブタイトル
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;		// ソート条件

            if (this._sumSuplierPayMainCndtn.NewPageDiv == 1)
            {
                // しない
                SectionHeader.NewPage = NewPage.None;
            }

            if (this._sumSuplierPayMainCndtn.BalancePayeeDetail == 1)
            {
                // 残高支払内訳を印字しない
                // タイトル
                Label_StockTtl3TmBfBlPay.Visible = false;
                Label_StockTtl2TmBfBlPay.Visible = false;
                Label_LastTimePayment.Visible = false;
                Label_CashPayment.Visible = false;
                Label_TrfrPayment.Visible = false;
                Label_CheckPayment.Visible = false;
                Label_DraftPayment.Visible = false;
                Label_OffsetPayment.Visible = false;
                Label_OthsPayment.Visible = false;
                Label_FundTransferPayment.Visible = false;
                Label_ThisTimeFeePayNrml.Visible = false;
                Label_ThisTimeDisPayNrml.Visible = false;

                // 明細
                StockTtl3TmBfBlPay.Visible = false;
                StockTtl2TmBfBlPay.Visible = false;
                LastTimePayment.Visible = false;
                CashPayment.Visible = false;
                TrfrPayment.Visible = false;
                CheckPayment.Visible = false;
                DraftPayment.Visible = false;
                OffsetPayment.Visible = false;
                OthsPayment.Visible = false;
                FundTransferPayment.Visible = false;
                ThisTimeFeePayNrml.Visible = false;
                ThisTimeDisPayNrml.Visible = false;

                // 拠点計
                s_StockTtl3TmBfBlPay.Visible = false;
                s_StockTtl2TmBfBlPay.Visible = false;
                s_LastTimePayment.Visible = false;
                s_CashPayment.Visible = false;
                s_TrfrPayment.Visible = false;
                s_CheckPayment.Visible = false;
                s_DraftPayment.Visible = false;
                s_OffsetPayment.Visible = false;
                s_OthsPayment.Visible = false;
                s_FundTransferPayment.Visible = false;
                s_ThisTimeFeePayNrml.Visible = false;
                s_ThisTimeDisPayNrml.Visible = false;

                // 総合計
                t_StockTtl3TmBfBlPay.Visible = false;
                t_StockTtl2TmBfBlPay.Visible = false;
                t_LastTimePayment.Visible = false;
                t_CashPayment.Visible = false;
                t_TrfrPayment.Visible = false;
                t_CheckPayment.Visible = false;
                t_DraftPayment.Visible = false;
                t_OffsetPayment.Visible = false;
                t_OthsPayment.Visible = false;
                t_FundTransferPayment.Visible = false;
                t_ThisTimeFeePayNrml.Visible = false;
                t_ThisTimeDisPayNrml.Visible = false;
            }
		}
		#endregion

        /// <summary>
        /// 総括支払先内訳データの取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 総括支払先内訳データを取得します。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private DataView GetDrawingData()
        {
            DataRowView outputDr = null;
            DataView dr = null;
            
            if (this._outputDs.Tables[ct_SuplierPayMainTable].DefaultView.Count > this._outputCnt)
            {
                string sort = "";
                string filter = "";

                // 現在印刷している行を取得
                outputDr = this._outputDs.Tables[ct_SuplierPayMainTable].DefaultView[this._outputCnt];
                this._outputCnt++;

                // フィルタ条件
                filter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}' AND {6} = {7} AND {8} = 0",
                            PMKAK02005EA.Col_SumAddUpSecCode,
                            outputDr[PMKAK02005EA.Col_SumAddUpSecCode],
                            PMKAK02005EA.Col_SumPayeeCode,
                            outputDr[PMKAK02005EA.Col_SumPayeeCode],
                            PMKAK02005EA.Col_AddUpSecCode,
                            outputDr[PMKAK02005EA.Col_AddUpSecCode],
                            PMKAK02005EA.Col_PayeeCode,
                            outputDr[PMKAK02005EA.Col_PayeeCode],
                            PMKAK02005EA.Col_SupplierCd);

                // ソート順
                sort = PMKAK02005EA.Col_SumAddUpSecCode + " ASC,"
                     + PMKAK02005EA.Col_SumPayeeCode + " ASC,"
                     + PMKAK02005EA.Col_AddUpSecCode + " ASC,"
                     + PMKAK02005EA.Col_PayeeCode + " ASC";

                dr = new DataView(this._outputDs.Tables[ct_SuplierPayMainTable], filter, sort, DataViewRowState.CurrentRows);
            }
            return dr;
        }

		#endregion

		#region ■ Control Event
		#region ◆ PMKAK02003P_01A4C_ReportStart Event
		/// <summary>
        /// PMKAK02003P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : レポートの設定をするイベントです。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
        private void PMKAK02003P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();
        }
        #endregion ◆ PMKAK02003P_01A4C_ReportStart Event

        #region ◆ PageHeader_Format Event
        /// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( SumSuplierPayMainCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
		}
		#endregion ◆ PageHeader_Format Event

		#region ◆ ExtraHeader_Format Event
		/// <summary>
		/// ExtraHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
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
		#endregion ◆ ExtraHeader_Format Event

		#region ◆ Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);
		}
		#endregion ◆ Detail_BeforePrint Event

		#region ◆ Detail_AfterPrint Event
		/// <summary>
		/// Detail_AfterPrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : FSI東 隆史</br>
		/// <br>Date        : 2012/09/04</br>
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
		#endregion ◆ Detail_AfterPrint Event

        /// <summary>
        /// 明細フォーマットイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : セクションがページに描画される前に発生します。</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            if (this._sumSuplierPayMainCndtn.SumPayeeDetail == 0)
            {
                // 総括支払先内訳が"印字する"
                DataView dr = this.GetDrawingData();
                if (dr != null)
                {
                    if (dr.Count > 0)
                    {
                        // サブレポートのVisibleセット
                        DrawingDetail_SubReport.Visible = true;

                        // インスタンスが作成されていなければ作成
                        if (_rptDrawingDetail == null)
                        {
                            _rptDrawingDetail = new DrawingDetail(this._sumSuplierPayMainCndtn);
                        }
                        else
                        {
                            // インスタンスが作成されていれば、データソースを初期化する
                            // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない)
                            _rptDrawingDetail.DataSource = null;
                        }

                        // データソースの設定
                        _rptDrawingDetail.DataSource = dr;      // バインドするデータをセット
                        // サブレポートにデータをセット
                        DrawingDetail_SubReport.Report = _rptDrawingDetail;
                    }
                    else
                    {
                        // サブレポートのVisibleセット
                        DrawingDetail_SubReport.Visible = false;
                    }
                }
            }
            else
            {
                // サブレポートのVisibleセット
                DrawingDetail_SubReport.Visible = false;
            }
        }

		#region ◆ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
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
		#endregion ◆ PageFooter_Format Event

		#endregion ■ Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_SortOrderName;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Label Label104;
		private DataDynamics.ActiveReports.Label Label105;
		private DataDynamics.ActiveReports.Label Label106;
		private DataDynamics.ActiveReports.Label Label107;
		private DataDynamics.ActiveReports.Label Label108;
		private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.TextBox tb_AddUpSecName_Title;
		private DataDynamics.ActiveReports.Label Label_StockTtl3TmBfBlPay;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.Label Label_StockTtl2TmBfBlPay;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label_LastTimePayment;
		private DataDynamics.ActiveReports.Label Label7;
        private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.Line Line13;
		private DataDynamics.ActiveReports.TextBox PaymentBalance;
		private DataDynamics.ActiveReports.TextBox ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcPay;
		private DataDynamics.ActiveReports.TextBox ThisTimeStockPrice;
        private DataDynamics.ActiveReports.TextBox OfsThisStockTax;
		private DataDynamics.ActiveReports.TextBox SumPayeeCode;
		private DataDynamics.ActiveReports.TextBox SumPayeeSnm;
		private DataDynamics.ActiveReports.TextBox RetGoodsDiscount;
        private DataDynamics.ActiveReports.TextBox PureCost;
		private DataDynamics.ActiveReports.TextBox ThisTotal;
		private DataDynamics.ActiveReports.TextBox StockTotalPayBalance;
		private DataDynamics.ActiveReports.TextBox PaymentDay;
        private DataDynamics.ActiveReports.TextBox StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox MONEYKINDNAME13;
		private DataDynamics.ActiveReports.TextBox Section_PaymentBalance;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimeTtlBlcPay;
		private DataDynamics.ActiveReports.TextBox Section_StockTotalPayBalance;
		private DataDynamics.ActiveReports.TextBox Section_RetGoodsDiscount;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimeStockPrice;
		private DataDynamics.ActiveReports.TextBox Section_PureCost;
		private DataDynamics.ActiveReports.TextBox Section_OfsThisStockTax;
		private DataDynamics.ActiveReports.TextBox s_CashPayment;
		private DataDynamics.ActiveReports.TextBox Section_ThisTotal;
		private DataDynamics.ActiveReports.TextBox Section_StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label Label109;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Total_PaymentBalance;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimeTtlBlcPay;
		private DataDynamics.ActiveReports.TextBox Total_ThisTotal;
		private DataDynamics.ActiveReports.TextBox Total_RetGoodsDiscount;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimeStockPrice;
		private DataDynamics.ActiveReports.TextBox Total_PureCost;
		private DataDynamics.ActiveReports.TextBox t_CashPayment;
		private DataDynamics.ActiveReports.TextBox Total_OfsThisStockTax;
		private DataDynamics.ActiveReports.TextBox Total_StockTotalPayBalance;
		private DataDynamics.ActiveReports.TextBox Total_StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>        
        public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKAK02003P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.DrawingDetail_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.PaymentBalance = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcPay = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.SumPayeeCode = new DataDynamics.ActiveReports.TextBox();
            this.SumPayeeSnm = new DataDynamics.ActiveReports.TextBox();
            this.RetGoodsDiscount = new DataDynamics.ActiveReports.TextBox();
            this.PureCost = new DataDynamics.ActiveReports.TextBox();
            this.ThisTotal = new DataDynamics.ActiveReports.TextBox();
            this.StockTotalPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.PaymentDay = new DataDynamics.ActiveReports.TextBox();
            this.StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.PaymentMonthName = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.StockTtl3TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.StockTtl2TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.LastTimePayment = new DataDynamics.ActiveReports.TextBox();
            this.OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.ResultsSectCd = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.tb_AddUpSecName_Title = new DataDynamics.ActiveReports.TextBox();
            this.Label_StockTtl3TmBfBlPay = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label_StockTtl2TmBfBlPay = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label_LastTimePayment = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label_CashPayment = new DataDynamics.ActiveReports.Label();
            this.Label_TrfrPayment = new DataDynamics.ActiveReports.Label();
            this.Label_CheckPayment = new DataDynamics.ActiveReports.Label();
            this.Label_DraftPayment = new DataDynamics.ActiveReports.Label();
            this.Label_OffsetPayment = new DataDynamics.ActiveReports.Label();
            this.Label_OthsPayment = new DataDynamics.ActiveReports.Label();
            this.Label_FundTransferPayment = new DataDynamics.ActiveReports.Label();
            this.Label_ThisTimeFeePayNrml = new DataDynamics.ActiveReports.Label();
            this.Label_ThisTimeDisPayNrml = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Total_PaymentBalance = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimeTtlBlcPay = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTotal = new DataDynamics.ActiveReports.TextBox();
            this.Total_RetGoodsDiscount = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Total_PureCost = new DataDynamics.ActiveReports.TextBox();
            this.t_CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.Total_OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.Total_StockTotalPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.Total_StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.t_TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.t_CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.t_DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.t_OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.t_StockTtl3TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.t_StockTtl2TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.t_LastTimePayment = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.t_FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.t_ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.t_OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SumAddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SumAddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.Section_PaymentBalance = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimeTtlBlcPay = new DataDynamics.ActiveReports.TextBox();
            this.Section_StockTotalPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.Section_RetGoodsDiscount = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Section_PureCost = new DataDynamics.ActiveReports.TextBox();
            this.Section_OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.s_CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTotal = new DataDynamics.ActiveReports.TextBox();
            this.Section_StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.s_TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_StockTtl3TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.s_StockTtl2TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.s_LastTimePayment = new DataDynamics.ActiveReports.TextBox();
            this.s_OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.SumSuplierPayHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SumSuplierPayFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentMonthName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl3TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl2TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_StockTtl3TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_StockTtl2TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_LastTimePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeTtlBlcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_RetGoodsDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PureCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockTotalPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_StockTtl3TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_StockTtl2TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_LastTimePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumAddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumAddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeTtlBlcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockTotalPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_RetGoodsDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PureCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockTtl3TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockTtl2TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_LastTimePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DrawingDetail_SubReport});
            this.Detail.Height = 0.219F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // DrawingDetail_SubReport
            // 
            this.DrawingDetail_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.DrawingDetail_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DrawingDetail_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.DrawingDetail_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DrawingDetail_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.DrawingDetail_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DrawingDetail_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.DrawingDetail_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DrawingDetail_SubReport.CloseBorder = false;
            this.DrawingDetail_SubReport.Height = 0.125F;
            this.DrawingDetail_SubReport.Left = 0.4375F;
            this.DrawingDetail_SubReport.Name = "DrawingDetail_SubReport";
            this.DrawingDetail_SubReport.Report = null;
            this.DrawingDetail_SubReport.ReportName = "DrawingDetail_SubReport";
            this.DrawingDetail_SubReport.Top = 0F;
            this.DrawingDetail_SubReport.Width = 10.375F;
            // 
            // Line13
            // 
            this.Line13.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.RightColor = System.Drawing.Color.Black;
            this.Line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.TopColor = System.Drawing.Color.Black;
            this.Line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Height = 0F;
            this.Line13.Left = 0F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 10.8F;
            this.Line13.X1 = 0F;
            this.Line13.X2 = 10.8F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0F;
            // 
            // PaymentBalance
            // 
            this.PaymentBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentBalance.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentBalance.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentBalance.DataField = "PaymentBalance";
            this.PaymentBalance.Height = 0.125F;
            this.PaymentBalance.Left = 2.4375F;
            this.PaymentBalance.MultiLine = false;
            this.PaymentBalance.Name = "PaymentBalance";
            this.PaymentBalance.OutputFormat = resources.GetString("PaymentBalance.OutputFormat");
            this.PaymentBalance.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.PaymentBalance.SummaryGroup = "SumSuplierPayHeader";
            this.PaymentBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.PaymentBalance.Text = "1,234,567,890";
            this.PaymentBalance.Top = 0F;
            this.PaymentBalance.Width = 0.6875F;
            // 
            // ThisTimePayNrml
            // 
            this.ThisTimePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.DataField = "ThisTimePayNrml";
            this.ThisTimePayNrml.Height = 0.125F;
            this.ThisTimePayNrml.Left = 3.125F;
            this.ThisTimePayNrml.MultiLine = false;
            this.ThisTimePayNrml.Name = "ThisTimePayNrml";
            this.ThisTimePayNrml.OutputFormat = resources.GetString("ThisTimePayNrml.OutputFormat");
            this.ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTimePayNrml.SummaryGroup = "SumSuplierPayHeader";
            this.ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimePayNrml.Text = "1,234,567,890";
            this.ThisTimePayNrml.Top = 0F;
            this.ThisTimePayNrml.Width = 0.6875F;
            // 
            // ThisTimeTtlBlcPay
            // 
            this.ThisTimeTtlBlcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.DataField = "ThisTimeTtlBlcPay";
            this.ThisTimeTtlBlcPay.Height = 0.125F;
            this.ThisTimeTtlBlcPay.Left = 3.8125F;
            this.ThisTimeTtlBlcPay.MultiLine = false;
            this.ThisTimeTtlBlcPay.Name = "ThisTimeTtlBlcPay";
            this.ThisTimeTtlBlcPay.OutputFormat = resources.GetString("ThisTimeTtlBlcPay.OutputFormat");
            this.ThisTimeTtlBlcPay.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTimeTtlBlcPay.SummaryGroup = "SumSuplierPayHeader";
            this.ThisTimeTtlBlcPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeTtlBlcPay.Text = "1,234,567,890";
            this.ThisTimeTtlBlcPay.Top = 0F;
            this.ThisTimeTtlBlcPay.Width = 0.6875F;
            // 
            // ThisTimeStockPrice
            // 
            this.ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.Height = 0.125F;
            this.ThisTimeStockPrice.Left = 4.5F;
            this.ThisTimeStockPrice.MultiLine = false;
            this.ThisTimeStockPrice.Name = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.OutputFormat = resources.GetString("ThisTimeStockPrice.OutputFormat");
            this.ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTimeStockPrice.SummaryGroup = "SumSuplierPayHeader";
            this.ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeStockPrice.Text = "1,234,567,890";
            this.ThisTimeStockPrice.Top = 0F;
            this.ThisTimeStockPrice.Width = 0.6875F;
            // 
            // OfsThisStockTax
            // 
            this.OfsThisStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.DataField = "OfsThisStockTax";
            this.OfsThisStockTax.Height = 0.125F;
            this.OfsThisStockTax.Left = 6.5625F;
            this.OfsThisStockTax.MultiLine = false;
            this.OfsThisStockTax.Name = "OfsThisStockTax";
            this.OfsThisStockTax.OutputFormat = resources.GetString("OfsThisStockTax.OutputFormat");
            this.OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.OfsThisStockTax.SummaryGroup = "SumSuplierPayHeader";
            this.OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.OfsThisStockTax.Text = "1,234,567,890";
            this.OfsThisStockTax.Top = 0F;
            this.OfsThisStockTax.Width = 0.6875F;
            // 
            // SumPayeeCode
            // 
            this.SumPayeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SumPayeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SumPayeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.SumPayeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.SumPayeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeCode.DataField = "SumPayeeCode";
            this.SumPayeeCode.Height = 0.125F;
            this.SumPayeeCode.Left = 0F;
            this.SumPayeeCode.MultiLine = false;
            this.SumPayeeCode.Name = "SumPayeeCode";
            this.SumPayeeCode.OutputFormat = resources.GetString("SumPayeeCode.OutputFormat");
            this.SumPayeeCode.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ ゴシック; ver" +
                "tical-align: top; ";
            this.SumPayeeCode.Text = "123456";
            this.SumPayeeCode.Top = 0F;
            this.SumPayeeCode.Width = 0.375F;
            // 
            // SumPayeeSnm
            // 
            this.SumPayeeSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SumPayeeSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SumPayeeSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SumPayeeSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SumPayeeSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumPayeeSnm.DataField = "SumPayeeSnm";
            this.SumPayeeSnm.Height = 0.125F;
            this.SumPayeeSnm.Left = 0.4375F;
            this.SumPayeeSnm.MultiLine = false;
            this.SumPayeeSnm.Name = "SumPayeeSnm";
            this.SumPayeeSnm.OutputFormat = resources.GetString("SumPayeeSnm.OutputFormat");
            this.SumPayeeSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.SumPayeeSnm.Text = "あいうえおかきくけこさしすせそたちつてと";
            this.SumPayeeSnm.Top = 0F;
            this.SumPayeeSnm.Width = 1.9375F;
            // 
            // RetGoodsDiscount
            // 
            this.RetGoodsDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.RetGoodsDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RetGoodsDiscount.DataField = "RetGoodsDiscount";
            this.RetGoodsDiscount.Height = 0.125F;
            this.RetGoodsDiscount.Left = 5.1875F;
            this.RetGoodsDiscount.MultiLine = false;
            this.RetGoodsDiscount.Name = "RetGoodsDiscount";
            this.RetGoodsDiscount.OutputFormat = resources.GetString("RetGoodsDiscount.OutputFormat");
            this.RetGoodsDiscount.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.RetGoodsDiscount.SummaryGroup = "SumSuplierPayHeader";
            this.RetGoodsDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.RetGoodsDiscount.Text = "1,234,567,890";
            this.RetGoodsDiscount.Top = 0F;
            this.RetGoodsDiscount.Width = 0.6875F;
            // 
            // PureCost
            // 
            this.PureCost.Border.BottomColor = System.Drawing.Color.Black;
            this.PureCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.Border.LeftColor = System.Drawing.Color.Black;
            this.PureCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.Border.RightColor = System.Drawing.Color.Black;
            this.PureCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.Border.TopColor = System.Drawing.Color.Black;
            this.PureCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureCost.DataField = "PureCost";
            this.PureCost.Height = 0.125F;
            this.PureCost.Left = 5.875F;
            this.PureCost.MultiLine = false;
            this.PureCost.Name = "PureCost";
            this.PureCost.OutputFormat = resources.GetString("PureCost.OutputFormat");
            this.PureCost.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.PureCost.SummaryGroup = "SumSuplierPayHeader";
            this.PureCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.PureCost.Text = "1,234,567,890";
            this.PureCost.Top = 0F;
            this.PureCost.Width = 0.6875F;
            // 
            // ThisTotal
            // 
            this.ThisTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTotal.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTotal.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTotal.DataField = "ThisTotal";
            this.ThisTotal.Height = 0.125F;
            this.ThisTotal.Left = 7.25F;
            this.ThisTotal.MultiLine = false;
            this.ThisTotal.Name = "ThisTotal";
            this.ThisTotal.OutputFormat = resources.GetString("ThisTotal.OutputFormat");
            this.ThisTotal.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTotal.SummaryGroup = "SumSuplierPayHeader";
            this.ThisTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTotal.Text = "1,234,567,890";
            this.ThisTotal.Top = 0F;
            this.ThisTotal.Width = 0.6875F;
            // 
            // StockTotalPayBalance
            // 
            this.StockTotalPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.DataField = "StockTotalPayBalance";
            this.StockTotalPayBalance.Height = 0.125F;
            this.StockTotalPayBalance.Left = 7.9375F;
            this.StockTotalPayBalance.MultiLine = false;
            this.StockTotalPayBalance.Name = "StockTotalPayBalance";
            this.StockTotalPayBalance.OutputFormat = resources.GetString("StockTotalPayBalance.OutputFormat");
            this.StockTotalPayBalance.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.StockTotalPayBalance.SummaryGroup = "SumSuplierPayHeader";
            this.StockTotalPayBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockTotalPayBalance.Text = "1,234,567,890";
            this.StockTotalPayBalance.Top = 0F;
            this.StockTotalPayBalance.Width = 0.6875F;
            // 
            // PaymentDay
            // 
            this.PaymentDay.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentDay.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentDay.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentDay.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentDay.DataField = "PaymentDay";
            this.PaymentDay.Height = 0.125F;
            this.PaymentDay.Left = 9.8125F;
            this.PaymentDay.MultiLine = false;
            this.PaymentDay.Name = "PaymentDay";
            this.PaymentDay.OutputFormat = resources.GetString("PaymentDay.OutputFormat");
            this.PaymentDay.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ 明朝; vert" +
                "ical-align: top; ";
            this.PaymentDay.Text = "99";
            this.PaymentDay.Top = 0F;
            this.PaymentDay.Width = 0.1875F;
            // 
            // StockSlipCount
            // 
            this.StockSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.StockSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockSlipCount.DataField = "StockSlipCount";
            this.StockSlipCount.Height = 0.125F;
            this.StockSlipCount.Left = 8.625F;
            this.StockSlipCount.MultiLine = false;
            this.StockSlipCount.Name = "StockSlipCount";
            this.StockSlipCount.OutputFormat = resources.GetString("StockSlipCount.OutputFormat");
            this.StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.StockSlipCount.SummaryGroup = "SumSuplierPayHeader";
            this.StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockSlipCount.Text = "123,456";
            this.StockSlipCount.Top = 0F;
            this.StockSlipCount.Width = 0.6875F;
            // 
            // PaymentMonthName
            // 
            this.PaymentMonthName.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentMonthName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentMonthName.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentMonthName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentMonthName.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentMonthName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentMonthName.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentMonthName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentMonthName.DataField = "PaymentMonthName";
            this.PaymentMonthName.Height = 0.125F;
            this.PaymentMonthName.Left = 9.375F;
            this.PaymentMonthName.MultiLine = false;
            this.PaymentMonthName.Name = "PaymentMonthName";
            this.PaymentMonthName.OutputFormat = resources.GetString("PaymentMonthName.OutputFormat");
            this.PaymentMonthName.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.PaymentMonthName.Text = "あいうえ";
            this.PaymentMonthName.Top = 0F;
            this.PaymentMonthName.Width = 0.4375F;
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
            this.textBox10.Left = 10F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: top; ";
            this.textBox10.Text = "日";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.125F;
            // 
            // ThisTimeDisPayNrml
            // 
            this.ThisTimeDisPayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDisPayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDisPayNrml.DataField = "ThisTimeDisPayNrml";
            this.ThisTimeDisPayNrml.Height = 0.125F;
            this.ThisTimeDisPayNrml.Left = 10F;
            this.ThisTimeDisPayNrml.MultiLine = false;
            this.ThisTimeDisPayNrml.Name = "ThisTimeDisPayNrml";
            this.ThisTimeDisPayNrml.OutputFormat = resources.GetString("ThisTimeDisPayNrml.OutputFormat");
            this.ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTimeDisPayNrml.SummaryGroup = "SumSuplierPayHeader";
            this.ThisTimeDisPayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeDisPayNrml.Text = "1,234,567,890";
            this.ThisTimeDisPayNrml.Top = 0.125F;
            this.ThisTimeDisPayNrml.Width = 0.6875F;
            // 
            // ThisTimeFeePayNrml
            // 
            this.ThisTimeFeePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeFeePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeFeePayNrml.DataField = "ThisTimeFeePayNrml";
            this.ThisTimeFeePayNrml.Height = 0.125F;
            this.ThisTimeFeePayNrml.Left = 9.3125F;
            this.ThisTimeFeePayNrml.MultiLine = false;
            this.ThisTimeFeePayNrml.Name = "ThisTimeFeePayNrml";
            this.ThisTimeFeePayNrml.OutputFormat = resources.GetString("ThisTimeFeePayNrml.OutputFormat");
            this.ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.ThisTimeFeePayNrml.SummaryGroup = "SumSuplierPayHeader";
            this.ThisTimeFeePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeFeePayNrml.Text = "1,234,567,890";
            this.ThisTimeFeePayNrml.Top = 0.125F;
            this.ThisTimeFeePayNrml.Width = 0.6875F;
            // 
            // CashPayment
            // 
            this.CashPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.CashPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.CashPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.Border.RightColor = System.Drawing.Color.Black;
            this.CashPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.Border.TopColor = System.Drawing.Color.Black;
            this.CashPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashPayment.DataField = "CashPayment";
            this.CashPayment.Height = 0.125F;
            this.CashPayment.Left = 4.5F;
            this.CashPayment.MultiLine = false;
            this.CashPayment.Name = "CashPayment";
            this.CashPayment.OutputFormat = resources.GetString("CashPayment.OutputFormat");
            this.CashPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.CashPayment.SummaryGroup = "SumSuplierPayHeader";
            this.CashPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CashPayment.Text = "1,234,567,890";
            this.CashPayment.Top = 0.125F;
            this.CashPayment.Width = 0.6875F;
            // 
            // TrfrPayment
            // 
            this.TrfrPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.Border.RightColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.Border.TopColor = System.Drawing.Color.Black;
            this.TrfrPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TrfrPayment.DataField = "TrfrPayment";
            this.TrfrPayment.Height = 0.125F;
            this.TrfrPayment.Left = 5.1875F;
            this.TrfrPayment.MultiLine = false;
            this.TrfrPayment.Name = "TrfrPayment";
            this.TrfrPayment.OutputFormat = resources.GetString("TrfrPayment.OutputFormat");
            this.TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.TrfrPayment.SummaryGroup = "SumSuplierPayHeader";
            this.TrfrPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TrfrPayment.Text = "1,234,567,890";
            this.TrfrPayment.Top = 0.125F;
            this.TrfrPayment.Width = 0.6875F;
            // 
            // CheckPayment
            // 
            this.CheckPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.Border.RightColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.Border.TopColor = System.Drawing.Color.Black;
            this.CheckPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckPayment.DataField = "CheckPayment";
            this.CheckPayment.Height = 0.125F;
            this.CheckPayment.Left = 5.875F;
            this.CheckPayment.MultiLine = false;
            this.CheckPayment.Name = "CheckPayment";
            this.CheckPayment.OutputFormat = resources.GetString("CheckPayment.OutputFormat");
            this.CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.CheckPayment.SummaryGroup = "SumSuplierPayHeader";
            this.CheckPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CheckPayment.Text = "1,234,567,890";
            this.CheckPayment.Top = 0.125F;
            this.CheckPayment.Width = 0.6875F;
            // 
            // DraftPayment
            // 
            this.DraftPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.Border.RightColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.Border.TopColor = System.Drawing.Color.Black;
            this.DraftPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayment.DataField = "DraftPayment";
            this.DraftPayment.Height = 0.125F;
            this.DraftPayment.Left = 6.5625F;
            this.DraftPayment.MultiLine = false;
            this.DraftPayment.Name = "DraftPayment";
            this.DraftPayment.OutputFormat = resources.GetString("DraftPayment.OutputFormat");
            this.DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.DraftPayment.SummaryGroup = "SumSuplierPayHeader";
            this.DraftPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DraftPayment.Text = "1,234,567,890";
            this.DraftPayment.Top = 0.125F;
            this.DraftPayment.Width = 0.6875F;
            // 
            // OffsetPayment
            // 
            this.OffsetPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.Border.RightColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.Border.TopColor = System.Drawing.Color.Black;
            this.OffsetPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetPayment.DataField = "OffsetPayment";
            this.OffsetPayment.Height = 0.125F;
            this.OffsetPayment.Left = 7.25F;
            this.OffsetPayment.MultiLine = false;
            this.OffsetPayment.Name = "OffsetPayment";
            this.OffsetPayment.OutputFormat = resources.GetString("OffsetPayment.OutputFormat");
            this.OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.OffsetPayment.SummaryGroup = "SumSuplierPayHeader";
            this.OffsetPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.OffsetPayment.Text = "1,234,567,890";
            this.OffsetPayment.Top = 0.125F;
            this.OffsetPayment.Width = 0.6875F;
            // 
            // StockTtl3TmBfBlPay
            // 
            this.StockTtl3TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.DataField = "StockTtl3TmBfBlPay";
            this.StockTtl3TmBfBlPay.Height = 0.125F;
            this.StockTtl3TmBfBlPay.Left = 2.4375F;
            this.StockTtl3TmBfBlPay.MultiLine = false;
            this.StockTtl3TmBfBlPay.Name = "StockTtl3TmBfBlPay";
            this.StockTtl3TmBfBlPay.OutputFormat = resources.GetString("StockTtl3TmBfBlPay.OutputFormat");
            this.StockTtl3TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.StockTtl3TmBfBlPay.SummaryGroup = "SumSuplierPayHeader";
            this.StockTtl3TmBfBlPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockTtl3TmBfBlPay.Text = "1,234,567,890";
            this.StockTtl3TmBfBlPay.Top = 0.125F;
            this.StockTtl3TmBfBlPay.Width = 0.6875F;
            // 
            // StockTtl2TmBfBlPay
            // 
            this.StockTtl2TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.DataField = "StockTtl2TmBfBlPay";
            this.StockTtl2TmBfBlPay.Height = 0.125F;
            this.StockTtl2TmBfBlPay.Left = 3.125F;
            this.StockTtl2TmBfBlPay.MultiLine = false;
            this.StockTtl2TmBfBlPay.Name = "StockTtl2TmBfBlPay";
            this.StockTtl2TmBfBlPay.OutputFormat = resources.GetString("StockTtl2TmBfBlPay.OutputFormat");
            this.StockTtl2TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.StockTtl2TmBfBlPay.SummaryGroup = "SumSuplierPayHeader";
            this.StockTtl2TmBfBlPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockTtl2TmBfBlPay.Text = "1,234,567,890";
            this.StockTtl2TmBfBlPay.Top = 0.125F;
            this.StockTtl2TmBfBlPay.Width = 0.6875F;
            // 
            // LastTimePayment
            // 
            this.LastTimePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.DataField = "LastTimePayment";
            this.LastTimePayment.Height = 0.125F;
            this.LastTimePayment.Left = 3.8125F;
            this.LastTimePayment.MultiLine = false;
            this.LastTimePayment.Name = "LastTimePayment";
            this.LastTimePayment.OutputFormat = resources.GetString("LastTimePayment.OutputFormat");
            this.LastTimePayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.LastTimePayment.SummaryGroup = "SumSuplierPayHeader";
            this.LastTimePayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LastTimePayment.Text = "1,234,567,890";
            this.LastTimePayment.Top = 0.125F;
            this.LastTimePayment.Width = 0.6875F;
            // 
            // OthsPayment
            // 
            this.OthsPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.Border.RightColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.Border.TopColor = System.Drawing.Color.Black;
            this.OthsPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OthsPayment.DataField = "OthsPayment";
            this.OthsPayment.Height = 0.125F;
            this.OthsPayment.Left = 7.9375F;
            this.OthsPayment.MultiLine = false;
            this.OthsPayment.Name = "OthsPayment";
            this.OthsPayment.OutputFormat = resources.GetString("OthsPayment.OutputFormat");
            this.OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.OthsPayment.SummaryGroup = "SumSuplierPayHeader";
            this.OthsPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.OthsPayment.Text = "1,234,567,890";
            this.OthsPayment.Top = 0.125F;
            this.OthsPayment.Width = 0.6875F;
            // 
            // FundTransferPayment
            // 
            this.FundTransferPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.Border.RightColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.Border.TopColor = System.Drawing.Color.Black;
            this.FundTransferPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FundTransferPayment.DataField = "FundTransferPayment";
            this.FundTransferPayment.Height = 0.125F;
            this.FundTransferPayment.Left = 8.625F;
            this.FundTransferPayment.MultiLine = false;
            this.FundTransferPayment.Name = "FundTransferPayment";
            this.FundTransferPayment.OutputFormat = resources.GetString("FundTransferPayment.OutputFormat");
            this.FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 6.75pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: top; ";
            this.FundTransferPayment.SummaryGroup = "SumSuplierPayHeader";
            this.FundTransferPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.FundTransferPayment.Text = "1,234,567,890";
            this.FundTransferPayment.Top = 0.125F;
            this.FundTransferPayment.Width = 0.6875F;
            // 
            // ResultsSectCd
            // 
            this.ResultsSectCd.Border.BottomColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.LeftColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.RightColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.Border.TopColor = System.Drawing.Color.Black;
            this.ResultsSectCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ResultsSectCd.DataField = "ResultsSectCd";
            this.ResultsSectCd.Height = 0.125F;
            this.ResultsSectCd.Left = 0F;
            this.ResultsSectCd.MultiLine = false;
            this.ResultsSectCd.Name = "ResultsSectCd";
            this.ResultsSectCd.OutputFormat = resources.GetString("ResultsSectCd.OutputFormat");
            this.ResultsSectCd.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ ゴシック; ver" +
                "tical-align: top; ";
            this.ResultsSectCd.Text = "00";
            this.ResultsSectCd.Top = 0.125F;
            this.ResultsSectCd.Visible = false;
            this.ResultsSectCd.Width = 0.125F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.tb_SortOrderName,
            this.Label1,
            this.tb_PrintDate,
            this.Label4,
            this.tb_PrintPage,
            this.tb_PrintTime});
            this.PageHeader.Height = 0.25F;
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
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "支払一覧表（総括）";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.tb_SortOrderName.Left = 3.063F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[ソート条件]";
            this.tb_SortOrderName.Top = 0.063F;
            this.tb_SortOrderName.Width = 2.1875F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.15625F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 7.9375F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label1.Text = "作成日付：";
            this.Label1.Top = 0.0625F;
            this.Label1.Width = 0.625F;
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
            this.Label4.Height = 0.15625F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 9.9375F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label4.Text = "ページ：";
            this.Label4.Top = 0.0625F;
            this.Label4.Width = 0.5F;
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
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.1979167F;
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
            this.Header_SubReport.Height = 0.1875F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8125F;
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
            this.Label104,
            this.Label105,
            this.Label106,
            this.Label107,
            this.Label108,
            this.Line42,
            this.tb_AddUpSecName_Title,
            this.Label_StockTtl3TmBfBlPay,
            this.Label2,
            this.Label_StockTtl2TmBfBlPay,
            this.Label5,
            this.Label_LastTimePayment,
            this.Label7,
            this.Label8,
            this.Label_CashPayment,
            this.Label_TrfrPayment,
            this.Label_CheckPayment,
            this.Label_DraftPayment,
            this.Label_OffsetPayment,
            this.Label_OthsPayment,
            this.Label_FundTransferPayment,
            this.Label_ThisTimeFeePayNrml,
            this.Label_ThisTimeDisPayNrml,
            this.label18,
            this.label19});
            this.TitleHeader.Height = 0.3020833F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Label104
            // 
            this.Label104.Border.BottomColor = System.Drawing.Color.Black;
            this.Label104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.LeftColor = System.Drawing.Color.Black;
            this.Label104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.RightColor = System.Drawing.Color.Black;
            this.Label104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.TopColor = System.Drawing.Color.Black;
            this.Label104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Height = 0.125F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Label104.Text = "仕入先";
            this.Label104.Top = 0F;
            this.Label104.Width = 0.5F;
            // 
            // Label105
            // 
            this.Label105.Border.BottomColor = System.Drawing.Color.Black;
            this.Label105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.LeftColor = System.Drawing.Color.Black;
            this.Label105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.RightColor = System.Drawing.Color.Black;
            this.Label105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.TopColor = System.Drawing.Color.Black;
            this.Label105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Height = 0.125F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 2.5F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label105.Text = "支払残高";
            this.Label105.Top = 0F;
            this.Label105.Width = 0.625F;
            // 
            // Label106
            // 
            this.Label106.Border.BottomColor = System.Drawing.Color.Black;
            this.Label106.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.LeftColor = System.Drawing.Color.Black;
            this.Label106.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.RightColor = System.Drawing.Color.Black;
            this.Label106.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Border.TopColor = System.Drawing.Color.Black;
            this.Label106.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label106.Height = 0.125F;
            this.Label106.HyperLink = "";
            this.Label106.Left = 3.1875F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label106.Text = "今回支払";
            this.Label106.Top = 0F;
            this.Label106.Width = 0.625F;
            // 
            // Label107
            // 
            this.Label107.Border.BottomColor = System.Drawing.Color.Black;
            this.Label107.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.LeftColor = System.Drawing.Color.Black;
            this.Label107.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.RightColor = System.Drawing.Color.Black;
            this.Label107.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Border.TopColor = System.Drawing.Color.Black;
            this.Label107.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label107.Height = 0.125F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 3.875F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label107.Text = "繰越額";
            this.Label107.Top = 0F;
            this.Label107.Width = 0.625F;
            // 
            // Label108
            // 
            this.Label108.Border.BottomColor = System.Drawing.Color.Black;
            this.Label108.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.LeftColor = System.Drawing.Color.Black;
            this.Label108.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.RightColor = System.Drawing.Color.Black;
            this.Label108.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Border.TopColor = System.Drawing.Color.Black;
            this.Label108.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label108.Height = 0.125F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 9.375F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Label108.Text = "支払日";
            this.Label108.Top = 0F;
            this.Label108.Width = 0.625F;
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
            // tb_AddUpSecName_Title
            // 
            this.tb_AddUpSecName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName_Title.Height = 0.125F;
            this.tb_AddUpSecName_Title.Left = 8.6875F;
            this.tb_AddUpSecName_Title.MultiLine = false;
            this.tb_AddUpSecName_Title.Name = "tb_AddUpSecName_Title";
            this.tb_AddUpSecName_Title.OutputFormat = resources.GetString("tb_AddUpSecName_Title.OutputFormat");
            this.tb_AddUpSecName_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.tb_AddUpSecName_Title.Text = "伝票枚数";
            this.tb_AddUpSecName_Title.Top = 0F;
            this.tb_AddUpSecName_Title.Width = 0.625F;
            // 
            // Label_StockTtl3TmBfBlPay
            // 
            this.Label_StockTtl3TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_StockTtl3TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl3TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_StockTtl3TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl3TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.Label_StockTtl3TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl3TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.Label_StockTtl3TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl3TmBfBlPay.Height = 0.125F;
            this.Label_StockTtl3TmBfBlPay.HyperLink = "";
            this.Label_StockTtl3TmBfBlPay.Left = 2.5F;
            this.Label_StockTtl3TmBfBlPay.MultiLine = false;
            this.Label_StockTtl3TmBfBlPay.Name = "Label_StockTtl3TmBfBlPay";
            this.Label_StockTtl3TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_StockTtl3TmBfBlPay.Text = "前々々回";
            this.Label_StockTtl3TmBfBlPay.Top = 0.125F;
            this.Label_StockTtl3TmBfBlPay.Width = 0.625F;
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
            this.Label2.Height = 0.125F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 4.5625F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "仕入額";
            this.Label2.Top = 0F;
            this.Label2.Width = 0.625F;
            // 
            // Label_StockTtl2TmBfBlPay
            // 
            this.Label_StockTtl2TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_StockTtl2TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl2TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_StockTtl2TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl2TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.Label_StockTtl2TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl2TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.Label_StockTtl2TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_StockTtl2TmBfBlPay.Height = 0.125F;
            this.Label_StockTtl2TmBfBlPay.HyperLink = "";
            this.Label_StockTtl2TmBfBlPay.Left = 3.1875F;
            this.Label_StockTtl2TmBfBlPay.MultiLine = false;
            this.Label_StockTtl2TmBfBlPay.Name = "Label_StockTtl2TmBfBlPay";
            this.Label_StockTtl2TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_StockTtl2TmBfBlPay.Text = "前々回";
            this.Label_StockTtl2TmBfBlPay.Top = 0.125F;
            this.Label_StockTtl2TmBfBlPay.Width = 0.625F;
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
            this.Label5.Height = 0.125F;
            this.Label5.HyperLink = "";
            this.Label5.Left = 6.625F;
            this.Label5.MultiLine = false;
            this.Label5.Name = "Label5";
            this.Label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label5.Text = "消費税";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.625F;
            // 
            // Label_LastTimePayment
            // 
            this.Label_LastTimePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_LastTimePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_LastTimePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_LastTimePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_LastTimePayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_LastTimePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_LastTimePayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_LastTimePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_LastTimePayment.Height = 0.125F;
            this.Label_LastTimePayment.HyperLink = "";
            this.Label_LastTimePayment.Left = 3.875F;
            this.Label_LastTimePayment.MultiLine = false;
            this.Label_LastTimePayment.Name = "Label_LastTimePayment";
            this.Label_LastTimePayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_LastTimePayment.Text = "前回";
            this.Label_LastTimePayment.Top = 0.125F;
            this.Label_LastTimePayment.Width = 0.625F;
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
            this.Label7.Height = 0.125F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 7.3125F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label7.Text = "今回合計";
            this.Label7.Top = 0F;
            this.Label7.Width = 0.625F;
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
            this.Label8.Height = 0.125F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 8F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label8.Text = "今回支払残";
            this.Label8.Top = 0F;
            this.Label8.Width = 0.625F;
            // 
            // Label_CashPayment
            // 
            this.Label_CashPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_CashPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CashPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_CashPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CashPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_CashPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CashPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_CashPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CashPayment.Height = 0.125F;
            this.Label_CashPayment.HyperLink = "";
            this.Label_CashPayment.Left = 4.5625F;
            this.Label_CashPayment.MultiLine = false;
            this.Label_CashPayment.Name = "Label_CashPayment";
            this.Label_CashPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_CashPayment.Text = "現金";
            this.Label_CashPayment.Top = 0.125F;
            this.Label_CashPayment.Width = 0.625F;
            // 
            // Label_TrfrPayment
            // 
            this.Label_TrfrPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_TrfrPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_TrfrPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_TrfrPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_TrfrPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_TrfrPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_TrfrPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_TrfrPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_TrfrPayment.Height = 0.125F;
            this.Label_TrfrPayment.HyperLink = "";
            this.Label_TrfrPayment.Left = 5.25F;
            this.Label_TrfrPayment.MultiLine = false;
            this.Label_TrfrPayment.Name = "Label_TrfrPayment";
            this.Label_TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_TrfrPayment.Text = "振込";
            this.Label_TrfrPayment.Top = 0.125F;
            this.Label_TrfrPayment.Width = 0.625F;
            // 
            // Label_CheckPayment
            // 
            this.Label_CheckPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_CheckPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_CheckPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_CheckPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_CheckPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckPayment.Height = 0.125F;
            this.Label_CheckPayment.HyperLink = "";
            this.Label_CheckPayment.Left = 5.9375F;
            this.Label_CheckPayment.MultiLine = false;
            this.Label_CheckPayment.Name = "Label_CheckPayment";
            this.Label_CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_CheckPayment.Text = "小切手";
            this.Label_CheckPayment.Top = 0.125F;
            this.Label_CheckPayment.Width = 0.625F;
            // 
            // Label_DraftPayment
            // 
            this.Label_DraftPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_DraftPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DraftPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_DraftPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DraftPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_DraftPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DraftPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_DraftPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DraftPayment.Height = 0.125F;
            this.Label_DraftPayment.HyperLink = "";
            this.Label_DraftPayment.Left = 6.625F;
            this.Label_DraftPayment.MultiLine = false;
            this.Label_DraftPayment.Name = "Label_DraftPayment";
            this.Label_DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_DraftPayment.Text = "手形";
            this.Label_DraftPayment.Top = 0.125F;
            this.Label_DraftPayment.Width = 0.625F;
            // 
            // Label_OffsetPayment
            // 
            this.Label_OffsetPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_OffsetPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OffsetPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_OffsetPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OffsetPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_OffsetPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OffsetPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_OffsetPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OffsetPayment.Height = 0.125F;
            this.Label_OffsetPayment.HyperLink = "";
            this.Label_OffsetPayment.Left = 7.3125F;
            this.Label_OffsetPayment.MultiLine = false;
            this.Label_OffsetPayment.Name = "Label_OffsetPayment";
            this.Label_OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_OffsetPayment.Text = "相殺";
            this.Label_OffsetPayment.Top = 0.125F;
            this.Label_OffsetPayment.Width = 0.625F;
            // 
            // Label_OthsPayment
            // 
            this.Label_OthsPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_OthsPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OthsPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_OthsPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OthsPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_OthsPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OthsPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_OthsPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_OthsPayment.Height = 0.125F;
            this.Label_OthsPayment.HyperLink = "";
            this.Label_OthsPayment.Left = 8F;
            this.Label_OthsPayment.MultiLine = false;
            this.Label_OthsPayment.Name = "Label_OthsPayment";
            this.Label_OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_OthsPayment.Text = "その他";
            this.Label_OthsPayment.Top = 0.125F;
            this.Label_OthsPayment.Width = 0.625F;
            // 
            // Label_FundTransferPayment
            // 
            this.Label_FundTransferPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_FundTransferPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_FundTransferPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_FundTransferPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_FundTransferPayment.Border.RightColor = System.Drawing.Color.Black;
            this.Label_FundTransferPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_FundTransferPayment.Border.TopColor = System.Drawing.Color.Black;
            this.Label_FundTransferPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_FundTransferPayment.Height = 0.125F;
            this.Label_FundTransferPayment.HyperLink = "";
            this.Label_FundTransferPayment.Left = 8.6875F;
            this.Label_FundTransferPayment.MultiLine = false;
            this.Label_FundTransferPayment.Name = "Label_FundTransferPayment";
            this.Label_FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_FundTransferPayment.Text = "口座振替";
            this.Label_FundTransferPayment.Top = 0.125F;
            this.Label_FundTransferPayment.Width = 0.625F;
            // 
            // Label_ThisTimeFeePayNrml
            // 
            this.Label_ThisTimeFeePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_ThisTimeFeePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeFeePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_ThisTimeFeePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeFeePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Label_ThisTimeFeePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeFeePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Label_ThisTimeFeePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeFeePayNrml.Height = 0.125F;
            this.Label_ThisTimeFeePayNrml.HyperLink = "";
            this.Label_ThisTimeFeePayNrml.Left = 9.375F;
            this.Label_ThisTimeFeePayNrml.MultiLine = false;
            this.Label_ThisTimeFeePayNrml.Name = "Label_ThisTimeFeePayNrml";
            this.Label_ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_ThisTimeFeePayNrml.Text = "手数料";
            this.Label_ThisTimeFeePayNrml.Top = 0.125F;
            this.Label_ThisTimeFeePayNrml.Width = 0.625F;
            // 
            // Label_ThisTimeDisPayNrml
            // 
            this.Label_ThisTimeDisPayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_ThisTimeDisPayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeDisPayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_ThisTimeDisPayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeDisPayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Label_ThisTimeDisPayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeDisPayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Label_ThisTimeDisPayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ThisTimeDisPayNrml.Height = 0.125F;
            this.Label_ThisTimeDisPayNrml.HyperLink = "";
            this.Label_ThisTimeDisPayNrml.Left = 10.0625F;
            this.Label_ThisTimeDisPayNrml.MultiLine = false;
            this.Label_ThisTimeDisPayNrml.Name = "Label_ThisTimeDisPayNrml";
            this.Label_ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_ThisTimeDisPayNrml.Text = "値引";
            this.Label_ThisTimeDisPayNrml.Top = 0.125F;
            this.Label_ThisTimeDisPayNrml.Width = 0.625F;
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
            this.label18.Height = 0.125F;
            this.label18.HyperLink = "";
            this.label18.Left = 5.25F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "返品値引";
            this.label18.Top = 0F;
            this.label18.Width = 0.625F;
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
            this.label19.Height = 0.125F;
            this.label19.HyperLink = "";
            this.label19.Left = 5.9375F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "純仕入額";
            this.label19.Top = 0F;
            this.label19.Width = 0.625F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
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
            this.Label109,
            this.Line43,
            this.Total_PaymentBalance,
            this.Total_ThisTimePayNrml,
            this.Total_ThisTimeTtlBlcPay,
            this.Total_ThisTotal,
            this.Total_RetGoodsDiscount,
            this.Total_ThisTimeStockPrice,
            this.Total_PureCost,
            this.t_CashPayment,
            this.Total_OfsThisStockTax,
            this.Total_StockTotalPayBalance,
            this.Total_StockSlipCount,
            this.t_TrfrPayment,
            this.t_CheckPayment,
            this.t_DraftPayment,
            this.t_OffsetPayment,
            this.t_StockTtl3TmBfBlPay,
            this.t_StockTtl2TmBfBlPay,
            this.t_LastTimePayment,
            this.t_ThisTimeDisPayNrml,
            this.t_FundTransferPayment,
            this.t_ThisTimeFeePayNrml,
            this.t_OthsPayment});
            this.GrandTotalFooter.Height = 0.3541667F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // Label109
            // 
            this.Label109.Border.BottomColor = System.Drawing.Color.Black;
            this.Label109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.LeftColor = System.Drawing.Color.Black;
            this.Label109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.RightColor = System.Drawing.Color.Black;
            this.Label109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.TopColor = System.Drawing.Color.Black;
            this.Label109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Height = 0.125F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 1F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7.5pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Label109.Text = "総合計";
            this.Label109.Top = 0F;
            this.Label109.Width = 0.5625F;
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
            // Total_PaymentBalance
            // 
            this.Total_PaymentBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PaymentBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PaymentBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentBalance.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PaymentBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentBalance.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PaymentBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PaymentBalance.DataField = "PaymentBalance";
            this.Total_PaymentBalance.Height = 0.125F;
            this.Total_PaymentBalance.Left = 2.4375F;
            this.Total_PaymentBalance.MultiLine = false;
            this.Total_PaymentBalance.Name = "Total_PaymentBalance";
            this.Total_PaymentBalance.OutputFormat = resources.GetString("Total_PaymentBalance.OutputFormat");
            this.Total_PaymentBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PaymentBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_PaymentBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_PaymentBalance.Text = "1,234,567,890";
            this.Total_PaymentBalance.Top = 0F;
            this.Total_PaymentBalance.Width = 0.6875F;
            // 
            // Total_ThisTimePayNrml
            // 
            this.Total_ThisTimePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimePayNrml.DataField = "ThisTimePayNrml";
            this.Total_ThisTimePayNrml.Height = 0.125F;
            this.Total_ThisTimePayNrml.Left = 3.125F;
            this.Total_ThisTimePayNrml.MultiLine = false;
            this.Total_ThisTimePayNrml.Name = "Total_ThisTimePayNrml";
            this.Total_ThisTimePayNrml.OutputFormat = resources.GetString("Total_ThisTimePayNrml.OutputFormat");
            this.Total_ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimePayNrml.Text = "1,234,567,890";
            this.Total_ThisTimePayNrml.Top = 0F;
            this.Total_ThisTimePayNrml.Width = 0.6875F;
            // 
            // Total_ThisTimeTtlBlcPay
            // 
            this.Total_ThisTimeTtlBlcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcPay.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcPay.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcPay.DataField = "ThisTimeTtlBlcPay";
            this.Total_ThisTimeTtlBlcPay.Height = 0.125F;
            this.Total_ThisTimeTtlBlcPay.Left = 3.8125F;
            this.Total_ThisTimeTtlBlcPay.MultiLine = false;
            this.Total_ThisTimeTtlBlcPay.Name = "Total_ThisTimeTtlBlcPay";
            this.Total_ThisTimeTtlBlcPay.OutputFormat = resources.GetString("Total_ThisTimeTtlBlcPay.OutputFormat");
            this.Total_ThisTimeTtlBlcPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimeTtlBlcPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimeTtlBlcPay.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimeTtlBlcPay.Text = "1,234,567,890";
            this.Total_ThisTimeTtlBlcPay.Top = 0F;
            this.Total_ThisTimeTtlBlcPay.Width = 0.6875F;
            // 
            // Total_ThisTotal
            // 
            this.Total_ThisTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTotal.DataField = "ThisTotal";
            this.Total_ThisTotal.Height = 0.125F;
            this.Total_ThisTotal.Left = 7.25F;
            this.Total_ThisTotal.MultiLine = false;
            this.Total_ThisTotal.Name = "Total_ThisTotal";
            this.Total_ThisTotal.OutputFormat = resources.GetString("Total_ThisTotal.OutputFormat");
            this.Total_ThisTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTotal.Text = "1,234,567,890";
            this.Total_ThisTotal.Top = 0F;
            this.Total_ThisTotal.Width = 0.6875F;
            // 
            // Total_RetGoodsDiscount
            // 
            this.Total_RetGoodsDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_RetGoodsDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_RetGoodsDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_RetGoodsDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_RetGoodsDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.Total_RetGoodsDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_RetGoodsDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.Total_RetGoodsDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_RetGoodsDiscount.DataField = "RetGoodsDiscount";
            this.Total_RetGoodsDiscount.Height = 0.125F;
            this.Total_RetGoodsDiscount.Left = 5.1875F;
            this.Total_RetGoodsDiscount.MultiLine = false;
            this.Total_RetGoodsDiscount.Name = "Total_RetGoodsDiscount";
            this.Total_RetGoodsDiscount.OutputFormat = resources.GetString("Total_RetGoodsDiscount.OutputFormat");
            this.Total_RetGoodsDiscount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_RetGoodsDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_RetGoodsDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_RetGoodsDiscount.Text = "1,234,567,890";
            this.Total_RetGoodsDiscount.Top = 0F;
            this.Total_RetGoodsDiscount.Width = 0.6875F;
            // 
            // Total_ThisTimeStockPrice
            // 
            this.Total_ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.Total_ThisTimeStockPrice.Height = 0.125F;
            this.Total_ThisTimeStockPrice.Left = 4.5F;
            this.Total_ThisTimeStockPrice.MultiLine = false;
            this.Total_ThisTimeStockPrice.Name = "Total_ThisTimeStockPrice";
            this.Total_ThisTimeStockPrice.OutputFormat = resources.GetString("Total_ThisTimeStockPrice.OutputFormat");
            this.Total_ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimeStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimeStockPrice.Text = "1,234,567,890";
            this.Total_ThisTimeStockPrice.Top = 0F;
            this.Total_ThisTimeStockPrice.Width = 0.6875F;
            // 
            // Total_PureCost
            // 
            this.Total_PureCost.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_PureCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PureCost.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_PureCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PureCost.Border.RightColor = System.Drawing.Color.Black;
            this.Total_PureCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PureCost.Border.TopColor = System.Drawing.Color.Black;
            this.Total_PureCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_PureCost.DataField = "PureCost";
            this.Total_PureCost.Height = 0.125F;
            this.Total_PureCost.Left = 5.875F;
            this.Total_PureCost.MultiLine = false;
            this.Total_PureCost.Name = "Total_PureCost";
            this.Total_PureCost.OutputFormat = resources.GetString("Total_PureCost.OutputFormat");
            this.Total_PureCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_PureCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_PureCost.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_PureCost.Text = "1,234,567,890";
            this.Total_PureCost.Top = 0F;
            this.Total_PureCost.Width = 0.6875F;
            // 
            // t_CashPayment
            // 
            this.t_CashPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_CashPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_CashPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_CashPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_CashPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CashPayment.DataField = "CashPayment";
            this.t_CashPayment.Height = 0.125F;
            this.t_CashPayment.Left = 4.5F;
            this.t_CashPayment.MultiLine = false;
            this.t_CashPayment.Name = "t_CashPayment";
            this.t_CashPayment.OutputFormat = resources.GetString("t_CashPayment.OutputFormat");
            this.t_CashPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_CashPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_CashPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_CashPayment.Text = "1,234,567,890";
            this.t_CashPayment.Top = 0.125F;
            this.t_CashPayment.Width = 0.6875F;
            // 
            // Total_OfsThisStockTax
            // 
            this.Total_OfsThisStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_OfsThisStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_OfsThisStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.Total_OfsThisStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.Total_OfsThisStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_OfsThisStockTax.DataField = "OfsThisStockTax";
            this.Total_OfsThisStockTax.Height = 0.125F;
            this.Total_OfsThisStockTax.Left = 6.5625F;
            this.Total_OfsThisStockTax.MultiLine = false;
            this.Total_OfsThisStockTax.Name = "Total_OfsThisStockTax";
            this.Total_OfsThisStockTax.OutputFormat = resources.GetString("Total_OfsThisStockTax.OutputFormat");
            this.Total_OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_OfsThisStockTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_OfsThisStockTax.Text = "1,234,567,890";
            this.Total_OfsThisStockTax.Top = 0F;
            this.Total_OfsThisStockTax.Width = 0.6875F;
            // 
            // Total_StockTotalPayBalance
            // 
            this.Total_StockTotalPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_StockTotalPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockTotalPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_StockTotalPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockTotalPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.Total_StockTotalPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockTotalPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.Total_StockTotalPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockTotalPayBalance.DataField = "StockTotalPayBalance";
            this.Total_StockTotalPayBalance.Height = 0.125F;
            this.Total_StockTotalPayBalance.Left = 7.9375F;
            this.Total_StockTotalPayBalance.MultiLine = false;
            this.Total_StockTotalPayBalance.Name = "Total_StockTotalPayBalance";
            this.Total_StockTotalPayBalance.OutputFormat = resources.GetString("Total_StockTotalPayBalance.OutputFormat");
            this.Total_StockTotalPayBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_StockTotalPayBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_StockTotalPayBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_StockTotalPayBalance.Text = "1,234,567,890";
            this.Total_StockTotalPayBalance.Top = 0F;
            this.Total_StockTotalPayBalance.Width = 0.6875F;
            // 
            // Total_StockSlipCount
            // 
            this.Total_StockSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_StockSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_StockSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.Total_StockSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.Total_StockSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockSlipCount.DataField = "StockSlipCount";
            this.Total_StockSlipCount.Height = 0.125F;
            this.Total_StockSlipCount.Left = 8.625F;
            this.Total_StockSlipCount.MultiLine = false;
            this.Total_StockSlipCount.Name = "Total_StockSlipCount";
            this.Total_StockSlipCount.OutputFormat = resources.GetString("Total_StockSlipCount.OutputFormat");
            this.Total_StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_StockSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_StockSlipCount.Text = "123,456";
            this.Total_StockSlipCount.Top = 0F;
            this.Total_StockSlipCount.Width = 0.6875F;
            // 
            // t_TrfrPayment
            // 
            this.t_TrfrPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_TrfrPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_TrfrPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_TrfrPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_TrfrPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_TrfrPayment.DataField = "TrfrPayment";
            this.t_TrfrPayment.Height = 0.125F;
            this.t_TrfrPayment.Left = 5.1875F;
            this.t_TrfrPayment.MultiLine = false;
            this.t_TrfrPayment.Name = "t_TrfrPayment";
            this.t_TrfrPayment.OutputFormat = resources.GetString("t_TrfrPayment.OutputFormat");
            this.t_TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_TrfrPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_TrfrPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_TrfrPayment.Text = "1,234,567,890";
            this.t_TrfrPayment.Top = 0.125F;
            this.t_TrfrPayment.Width = 0.6875F;
            // 
            // t_CheckPayment
            // 
            this.t_CheckPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_CheckPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_CheckPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_CheckPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_CheckPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_CheckPayment.DataField = "CheckPayment";
            this.t_CheckPayment.Height = 0.125F;
            this.t_CheckPayment.Left = 5.875F;
            this.t_CheckPayment.MultiLine = false;
            this.t_CheckPayment.Name = "t_CheckPayment";
            this.t_CheckPayment.OutputFormat = resources.GetString("t_CheckPayment.OutputFormat");
            this.t_CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_CheckPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_CheckPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_CheckPayment.Text = "1,234,567,890";
            this.t_CheckPayment.Top = 0.125F;
            this.t_CheckPayment.Width = 0.6875F;
            // 
            // t_DraftPayment
            // 
            this.t_DraftPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_DraftPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_DraftPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_DraftPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_DraftPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_DraftPayment.DataField = "DraftPayment";
            this.t_DraftPayment.Height = 0.125F;
            this.t_DraftPayment.Left = 6.5625F;
            this.t_DraftPayment.MultiLine = false;
            this.t_DraftPayment.Name = "t_DraftPayment";
            this.t_DraftPayment.OutputFormat = resources.GetString("t_DraftPayment.OutputFormat");
            this.t_DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_DraftPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_DraftPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_DraftPayment.Text = "1,234,567,890";
            this.t_DraftPayment.Top = 0.125F;
            this.t_DraftPayment.Width = 0.6875F;
            // 
            // t_OffsetPayment
            // 
            this.t_OffsetPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_OffsetPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_OffsetPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_OffsetPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_OffsetPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OffsetPayment.DataField = "OffsetPayment";
            this.t_OffsetPayment.Height = 0.125F;
            this.t_OffsetPayment.Left = 7.25F;
            this.t_OffsetPayment.MultiLine = false;
            this.t_OffsetPayment.Name = "t_OffsetPayment";
            this.t_OffsetPayment.OutputFormat = resources.GetString("t_OffsetPayment.OutputFormat");
            this.t_OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_OffsetPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_OffsetPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_OffsetPayment.Text = "1,234,567,890";
            this.t_OffsetPayment.Top = 0.125F;
            this.t_OffsetPayment.Width = 0.6875F;
            // 
            // t_StockTtl3TmBfBlPay
            // 
            this.t_StockTtl3TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.t_StockTtl3TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl3TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.t_StockTtl3TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl3TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.t_StockTtl3TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl3TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.t_StockTtl3TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl3TmBfBlPay.DataField = "StockTtl3TmBfBlPay";
            this.t_StockTtl3TmBfBlPay.Height = 0.125F;
            this.t_StockTtl3TmBfBlPay.Left = 2.4375F;
            this.t_StockTtl3TmBfBlPay.MultiLine = false;
            this.t_StockTtl3TmBfBlPay.Name = "t_StockTtl3TmBfBlPay";
            this.t_StockTtl3TmBfBlPay.OutputFormat = resources.GetString("t_StockTtl3TmBfBlPay.OutputFormat");
            this.t_StockTtl3TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_StockTtl3TmBfBlPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_StockTtl3TmBfBlPay.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_StockTtl3TmBfBlPay.Text = "1,234,567,890";
            this.t_StockTtl3TmBfBlPay.Top = 0.125F;
            this.t_StockTtl3TmBfBlPay.Width = 0.6875F;
            // 
            // t_StockTtl2TmBfBlPay
            // 
            this.t_StockTtl2TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.t_StockTtl2TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl2TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.t_StockTtl2TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl2TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.t_StockTtl2TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl2TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.t_StockTtl2TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_StockTtl2TmBfBlPay.DataField = "StockTtl2TmBfBlPay";
            this.t_StockTtl2TmBfBlPay.Height = 0.125F;
            this.t_StockTtl2TmBfBlPay.Left = 3.125F;
            this.t_StockTtl2TmBfBlPay.MultiLine = false;
            this.t_StockTtl2TmBfBlPay.Name = "t_StockTtl2TmBfBlPay";
            this.t_StockTtl2TmBfBlPay.OutputFormat = resources.GetString("t_StockTtl2TmBfBlPay.OutputFormat");
            this.t_StockTtl2TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_StockTtl2TmBfBlPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_StockTtl2TmBfBlPay.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_StockTtl2TmBfBlPay.Text = "1,234,567,890";
            this.t_StockTtl2TmBfBlPay.Top = 0.125F;
            this.t_StockTtl2TmBfBlPay.Width = 0.6875F;
            // 
            // t_LastTimePayment
            // 
            this.t_LastTimePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_LastTimePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_LastTimePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_LastTimePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_LastTimePayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_LastTimePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_LastTimePayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_LastTimePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_LastTimePayment.DataField = "LastTimePayment";
            this.t_LastTimePayment.Height = 0.125F;
            this.t_LastTimePayment.Left = 3.8125F;
            this.t_LastTimePayment.MultiLine = false;
            this.t_LastTimePayment.Name = "t_LastTimePayment";
            this.t_LastTimePayment.OutputFormat = resources.GetString("t_LastTimePayment.OutputFormat");
            this.t_LastTimePayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_LastTimePayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_LastTimePayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_LastTimePayment.Text = "1,234,567,890";
            this.t_LastTimePayment.Top = 0.125F;
            this.t_LastTimePayment.Width = 0.6875F;
            // 
            // t_ThisTimeDisPayNrml
            // 
            this.t_ThisTimeDisPayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisPayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisPayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisPayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisPayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisPayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisPayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeDisPayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeDisPayNrml.DataField = "ThisTimeDisPayNrml";
            this.t_ThisTimeDisPayNrml.Height = 0.125F;
            this.t_ThisTimeDisPayNrml.Left = 10F;
            this.t_ThisTimeDisPayNrml.MultiLine = false;
            this.t_ThisTimeDisPayNrml.Name = "t_ThisTimeDisPayNrml";
            this.t_ThisTimeDisPayNrml.OutputFormat = resources.GetString("t_ThisTimeDisPayNrml.OutputFormat");
            this.t_ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeDisPayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_ThisTimeDisPayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_ThisTimeDisPayNrml.Text = "1,234,567,890";
            this.t_ThisTimeDisPayNrml.Top = 0.125F;
            this.t_ThisTimeDisPayNrml.Width = 0.6875F;
            // 
            // t_FundTransferPayment
            // 
            this.t_FundTransferPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_FundTransferPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_FundTransferPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_FundTransferPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_FundTransferPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_FundTransferPayment.DataField = "FundTransferPayment";
            this.t_FundTransferPayment.Height = 0.125F;
            this.t_FundTransferPayment.Left = 8.625F;
            this.t_FundTransferPayment.MultiLine = false;
            this.t_FundTransferPayment.Name = "t_FundTransferPayment";
            this.t_FundTransferPayment.OutputFormat = resources.GetString("t_FundTransferPayment.OutputFormat");
            this.t_FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_FundTransferPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_FundTransferPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_FundTransferPayment.Text = "1,234,567,890";
            this.t_FundTransferPayment.Top = 0.125F;
            this.t_FundTransferPayment.Width = 0.6875F;
            // 
            // t_ThisTimeFeePayNrml
            // 
            this.t_ThisTimeFeePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.t_ThisTimeFeePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_ThisTimeFeePayNrml.DataField = "ThisTimeFeePayNrml";
            this.t_ThisTimeFeePayNrml.Height = 0.125F;
            this.t_ThisTimeFeePayNrml.Left = 9.3125F;
            this.t_ThisTimeFeePayNrml.MultiLine = false;
            this.t_ThisTimeFeePayNrml.Name = "t_ThisTimeFeePayNrml";
            this.t_ThisTimeFeePayNrml.OutputFormat = resources.GetString("t_ThisTimeFeePayNrml.OutputFormat");
            this.t_ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_ThisTimeFeePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_ThisTimeFeePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_ThisTimeFeePayNrml.Text = "1,234,567,890";
            this.t_ThisTimeFeePayNrml.Top = 0.125F;
            this.t_ThisTimeFeePayNrml.Width = 0.6875F;
            // 
            // t_OthsPayment
            // 
            this.t_OthsPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.t_OthsPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.t_OthsPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsPayment.Border.RightColor = System.Drawing.Color.Black;
            this.t_OthsPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsPayment.Border.TopColor = System.Drawing.Color.Black;
            this.t_OthsPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.t_OthsPayment.DataField = "OthsPayment";
            this.t_OthsPayment.Height = 0.125F;
            this.t_OthsPayment.Left = 7.9375F;
            this.t_OthsPayment.MultiLine = false;
            this.t_OthsPayment.Name = "t_OthsPayment";
            this.t_OthsPayment.OutputFormat = resources.GetString("t_OthsPayment.OutputFormat");
            this.t_OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.t_OthsPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.t_OthsPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.t_OthsPayment.Text = "1,234,567,890";
            this.t_OthsPayment.Top = 0.125F;
            this.t_OthsPayment.Width = 0.6875F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SumAddUpSecCode,
            this.SumAddUpSecName,
            this.line2});
            this.SectionHeader.DataField = "SumAddUpSecCode";
            this.SectionHeader.Height = 0.1979167F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SumAddUpSecCode
            // 
            this.SumAddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SumAddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SumAddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.SumAddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.SumAddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecCode.DataField = "SumAddUpSecCode";
            this.SumAddUpSecCode.Height = 0.125F;
            this.SumAddUpSecCode.Left = 0F;
            this.SumAddUpSecCode.MultiLine = false;
            this.SumAddUpSecCode.Name = "SumAddUpSecCode";
            this.SumAddUpSecCode.OutputFormat = resources.GetString("SumAddUpSecCode.OutputFormat");
            this.SumAddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 6.75pt; font-family: ＭＳ ゴシック; ver" +
                "tical-align: top; ";
            this.SumAddUpSecCode.Text = "00";
            this.SumAddUpSecCode.Top = 0F;
            this.SumAddUpSecCode.Width = 0.125F;
            // 
            // SumAddUpSecName
            // 
            this.SumAddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.SumAddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.SumAddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.SumAddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.SumAddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumAddUpSecName.DataField = "SumAddUpSecName";
            this.SumAddUpSecName.Height = 0.125F;
            this.SumAddUpSecName.Left = 0.1875F;
            this.SumAddUpSecName.MultiLine = false;
            this.SumAddUpSecName.Name = "SumAddUpSecName";
            this.SumAddUpSecName.Style = "text-align: left; font-size: 6.75pt; vertical-align: top; ";
            this.SumAddUpSecName.SummaryGroup = "SumSuplierPayHeader";
            this.SumAddUpSecName.Text = "拠点３４５６７８９０";
            this.SumAddUpSecName.Top = 0F;
            this.SumAddUpSecName.Width = 1F;
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
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.MONEYKINDNAME13,
            this.Section_PaymentBalance,
            this.Section_ThisTimePayNrml,
            this.Section_ThisTimeTtlBlcPay,
            this.Section_StockTotalPayBalance,
            this.Section_RetGoodsDiscount,
            this.Section_ThisTimeStockPrice,
            this.Section_PureCost,
            this.Section_OfsThisStockTax,
            this.s_CashPayment,
            this.Section_ThisTotal,
            this.Section_StockSlipCount,
            this.s_TrfrPayment,
            this.s_CheckPayment,
            this.s_DraftPayment,
            this.s_OffsetPayment,
            this.s_StockTtl3TmBfBlPay,
            this.s_StockTtl2TmBfBlPay,
            this.s_LastTimePayment,
            this.s_OthsPayment,
            this.s_FundTransferPayment,
            this.s_ThisTimeFeePayNrml,
            this.s_ThisTimeDisPayNrml});
            this.SectionFooter.Height = 0.3645833F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
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
            // MONEYKINDNAME13
            // 
            this.MONEYKINDNAME13.Border.BottomColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.LeftColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.RightColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.TopColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.DataField = "MONEYKINDNAME";
            this.MONEYKINDNAME13.Height = 0.125F;
            this.MONEYKINDNAME13.Left = 1F;
            this.MONEYKINDNAME13.MultiLine = false;
            this.MONEYKINDNAME13.Name = "MONEYKINDNAME13";
            this.MONEYKINDNAME13.OutputFormat = resources.GetString("MONEYKINDNAME13.OutputFormat");
            this.MONEYKINDNAME13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7.5pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.MONEYKINDNAME13.Text = "拠点計";
            this.MONEYKINDNAME13.Top = 0F;
            this.MONEYKINDNAME13.Width = 0.5625F;
            // 
            // Section_PaymentBalance
            // 
            this.Section_PaymentBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PaymentBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PaymentBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentBalance.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PaymentBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentBalance.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PaymentBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PaymentBalance.DataField = "PaymentBalance";
            this.Section_PaymentBalance.Height = 0.125F;
            this.Section_PaymentBalance.Left = 2.4375F;
            this.Section_PaymentBalance.MultiLine = false;
            this.Section_PaymentBalance.Name = "Section_PaymentBalance";
            this.Section_PaymentBalance.OutputFormat = resources.GetString("Section_PaymentBalance.OutputFormat");
            this.Section_PaymentBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PaymentBalance.SummaryGroup = "SectionHeader";
            this.Section_PaymentBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PaymentBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PaymentBalance.Text = "1,234,567,890";
            this.Section_PaymentBalance.Top = 0F;
            this.Section_PaymentBalance.Width = 0.6875F;
            // 
            // Section_ThisTimePayNrml
            // 
            this.Section_ThisTimePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimePayNrml.DataField = "ThisTimePayNrml";
            this.Section_ThisTimePayNrml.Height = 0.125F;
            this.Section_ThisTimePayNrml.Left = 3.125F;
            this.Section_ThisTimePayNrml.MultiLine = false;
            this.Section_ThisTimePayNrml.Name = "Section_ThisTimePayNrml";
            this.Section_ThisTimePayNrml.OutputFormat = resources.GetString("Section_ThisTimePayNrml.OutputFormat");
            this.Section_ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimePayNrml.SummaryGroup = "SectionHeader";
            this.Section_ThisTimePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimePayNrml.Text = "1,234,567,890";
            this.Section_ThisTimePayNrml.Top = 0F;
            this.Section_ThisTimePayNrml.Width = 0.6875F;
            // 
            // Section_ThisTimeTtlBlcPay
            // 
            this.Section_ThisTimeTtlBlcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcPay.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcPay.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcPay.DataField = "ThisTimeTtlBlcPay";
            this.Section_ThisTimeTtlBlcPay.Height = 0.125F;
            this.Section_ThisTimeTtlBlcPay.Left = 3.8125F;
            this.Section_ThisTimeTtlBlcPay.MultiLine = false;
            this.Section_ThisTimeTtlBlcPay.Name = "Section_ThisTimeTtlBlcPay";
            this.Section_ThisTimeTtlBlcPay.OutputFormat = resources.GetString("Section_ThisTimeTtlBlcPay.OutputFormat");
            this.Section_ThisTimeTtlBlcPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimeTtlBlcPay.SummaryGroup = "SectionHeader";
            this.Section_ThisTimeTtlBlcPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimeTtlBlcPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimeTtlBlcPay.Text = "1,234,567,890";
            this.Section_ThisTimeTtlBlcPay.Top = 0F;
            this.Section_ThisTimeTtlBlcPay.Width = 0.6875F;
            // 
            // Section_StockTotalPayBalance
            // 
            this.Section_StockTotalPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_StockTotalPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockTotalPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_StockTotalPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockTotalPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.Section_StockTotalPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockTotalPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.Section_StockTotalPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockTotalPayBalance.DataField = "StockTotalPayBalance";
            this.Section_StockTotalPayBalance.Height = 0.125F;
            this.Section_StockTotalPayBalance.Left = 7.9375F;
            this.Section_StockTotalPayBalance.MultiLine = false;
            this.Section_StockTotalPayBalance.Name = "Section_StockTotalPayBalance";
            this.Section_StockTotalPayBalance.OutputFormat = resources.GetString("Section_StockTotalPayBalance.OutputFormat");
            this.Section_StockTotalPayBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_StockTotalPayBalance.SummaryGroup = "SectionHeader";
            this.Section_StockTotalPayBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_StockTotalPayBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_StockTotalPayBalance.Text = "1,234,567,890";
            this.Section_StockTotalPayBalance.Top = 0F;
            this.Section_StockTotalPayBalance.Width = 0.6875F;
            // 
            // Section_RetGoodsDiscount
            // 
            this.Section_RetGoodsDiscount.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_RetGoodsDiscount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_RetGoodsDiscount.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_RetGoodsDiscount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_RetGoodsDiscount.Border.RightColor = System.Drawing.Color.Black;
            this.Section_RetGoodsDiscount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_RetGoodsDiscount.Border.TopColor = System.Drawing.Color.Black;
            this.Section_RetGoodsDiscount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_RetGoodsDiscount.DataField = "RetGoodsDiscount";
            this.Section_RetGoodsDiscount.Height = 0.125F;
            this.Section_RetGoodsDiscount.Left = 5.1875F;
            this.Section_RetGoodsDiscount.MultiLine = false;
            this.Section_RetGoodsDiscount.Name = "Section_RetGoodsDiscount";
            this.Section_RetGoodsDiscount.OutputFormat = resources.GetString("Section_RetGoodsDiscount.OutputFormat");
            this.Section_RetGoodsDiscount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_RetGoodsDiscount.SummaryGroup = "SectionHeader";
            this.Section_RetGoodsDiscount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_RetGoodsDiscount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_RetGoodsDiscount.Text = "1,234,567,890";
            this.Section_RetGoodsDiscount.Top = 0F;
            this.Section_RetGoodsDiscount.Width = 0.6875F;
            // 
            // Section_ThisTimeStockPrice
            // 
            this.Section_ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.Section_ThisTimeStockPrice.Height = 0.125F;
            this.Section_ThisTimeStockPrice.Left = 4.5F;
            this.Section_ThisTimeStockPrice.MultiLine = false;
            this.Section_ThisTimeStockPrice.Name = "Section_ThisTimeStockPrice";
            this.Section_ThisTimeStockPrice.OutputFormat = resources.GetString("Section_ThisTimeStockPrice.OutputFormat");
            this.Section_ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimeStockPrice.SummaryGroup = "SectionHeader";
            this.Section_ThisTimeStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimeStockPrice.Text = "1,234,567,890";
            this.Section_ThisTimeStockPrice.Top = 0F;
            this.Section_ThisTimeStockPrice.Width = 0.6875F;
            // 
            // Section_PureCost
            // 
            this.Section_PureCost.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_PureCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PureCost.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_PureCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PureCost.Border.RightColor = System.Drawing.Color.Black;
            this.Section_PureCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PureCost.Border.TopColor = System.Drawing.Color.Black;
            this.Section_PureCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_PureCost.DataField = "PureCost";
            this.Section_PureCost.Height = 0.125F;
            this.Section_PureCost.Left = 5.875F;
            this.Section_PureCost.MultiLine = false;
            this.Section_PureCost.Name = "Section_PureCost";
            this.Section_PureCost.OutputFormat = resources.GetString("Section_PureCost.OutputFormat");
            this.Section_PureCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_PureCost.SummaryGroup = "SectionHeader";
            this.Section_PureCost.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_PureCost.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_PureCost.Text = "1,234,567,890";
            this.Section_PureCost.Top = 0F;
            this.Section_PureCost.Width = 0.6875F;
            // 
            // Section_OfsThisStockTax
            // 
            this.Section_OfsThisStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_OfsThisStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_OfsThisStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.Section_OfsThisStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.Section_OfsThisStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_OfsThisStockTax.DataField = "OfsThisStockTax";
            this.Section_OfsThisStockTax.Height = 0.125F;
            this.Section_OfsThisStockTax.Left = 6.5625F;
            this.Section_OfsThisStockTax.MultiLine = false;
            this.Section_OfsThisStockTax.Name = "Section_OfsThisStockTax";
            this.Section_OfsThisStockTax.OutputFormat = resources.GetString("Section_OfsThisStockTax.OutputFormat");
            this.Section_OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_OfsThisStockTax.SummaryGroup = "SectionHeader";
            this.Section_OfsThisStockTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_OfsThisStockTax.Text = "1,234,567,890";
            this.Section_OfsThisStockTax.Top = 0F;
            this.Section_OfsThisStockTax.Width = 0.6875F;
            // 
            // s_CashPayment
            // 
            this.s_CashPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CashPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CashPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_CashPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_CashPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment.DataField = "CashPayment";
            this.s_CashPayment.Height = 0.125F;
            this.s_CashPayment.Left = 4.5F;
            this.s_CashPayment.MultiLine = false;
            this.s_CashPayment.Name = "s_CashPayment";
            this.s_CashPayment.OutputFormat = resources.GetString("s_CashPayment.OutputFormat");
            this.s_CashPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CashPayment.SummaryGroup = "SectionHeader";
            this.s_CashPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CashPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CashPayment.Text = "1,234,567,890";
            this.s_CashPayment.Top = 0.125F;
            this.s_CashPayment.Width = 0.6875F;
            // 
            // Section_ThisTotal
            // 
            this.Section_ThisTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTotal.DataField = "ThisTotal";
            this.Section_ThisTotal.Height = 0.125F;
            this.Section_ThisTotal.Left = 7.25F;
            this.Section_ThisTotal.MultiLine = false;
            this.Section_ThisTotal.Name = "Section_ThisTotal";
            this.Section_ThisTotal.OutputFormat = resources.GetString("Section_ThisTotal.OutputFormat");
            this.Section_ThisTotal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTotal.SummaryGroup = "SectionHeader";
            this.Section_ThisTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTotal.Text = "1,234,567,890";
            this.Section_ThisTotal.Top = 0F;
            this.Section_ThisTotal.Width = 0.6875F;
            // 
            // Section_StockSlipCount
            // 
            this.Section_StockSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_StockSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_StockSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.Section_StockSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.Section_StockSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockSlipCount.DataField = "StockSlipCount";
            this.Section_StockSlipCount.Height = 0.125F;
            this.Section_StockSlipCount.Left = 8.625F;
            this.Section_StockSlipCount.MultiLine = false;
            this.Section_StockSlipCount.Name = "Section_StockSlipCount";
            this.Section_StockSlipCount.OutputFormat = resources.GetString("Section_StockSlipCount.OutputFormat");
            this.Section_StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_StockSlipCount.SummaryGroup = "SectionHeader";
            this.Section_StockSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_StockSlipCount.Text = "123,456";
            this.Section_StockSlipCount.Top = 0F;
            this.Section_StockSlipCount.Width = 0.6875F;
            // 
            // s_TrfrPayment
            // 
            this.s_TrfrPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TrfrPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TrfrPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_TrfrPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_TrfrPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment.DataField = "TrfrPayment";
            this.s_TrfrPayment.Height = 0.125F;
            this.s_TrfrPayment.Left = 5.1875F;
            this.s_TrfrPayment.MultiLine = false;
            this.s_TrfrPayment.Name = "s_TrfrPayment";
            this.s_TrfrPayment.OutputFormat = resources.GetString("s_TrfrPayment.OutputFormat");
            this.s_TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TrfrPayment.SummaryGroup = "SectionHeader";
            this.s_TrfrPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TrfrPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TrfrPayment.Text = "1,234,567,890";
            this.s_TrfrPayment.Top = 0.125F;
            this.s_TrfrPayment.Width = 0.6875F;
            // 
            // s_CheckPayment
            // 
            this.s_CheckPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CheckPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CheckPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_CheckPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_CheckPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment.DataField = "CheckPayment";
            this.s_CheckPayment.Height = 0.125F;
            this.s_CheckPayment.Left = 5.875F;
            this.s_CheckPayment.MultiLine = false;
            this.s_CheckPayment.Name = "s_CheckPayment";
            this.s_CheckPayment.OutputFormat = resources.GetString("s_CheckPayment.OutputFormat");
            this.s_CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CheckPayment.SummaryGroup = "SectionHeader";
            this.s_CheckPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CheckPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CheckPayment.Text = "1,234,567,890";
            this.s_CheckPayment.Top = 0.125F;
            this.s_CheckPayment.Width = 0.6875F;
            // 
            // s_DraftPayment
            // 
            this.s_DraftPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_DraftPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_DraftPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_DraftPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_DraftPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment.DataField = "DraftPayment";
            this.s_DraftPayment.Height = 0.125F;
            this.s_DraftPayment.Left = 6.5625F;
            this.s_DraftPayment.MultiLine = false;
            this.s_DraftPayment.Name = "s_DraftPayment";
            this.s_DraftPayment.OutputFormat = resources.GetString("s_DraftPayment.OutputFormat");
            this.s_DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_DraftPayment.SummaryGroup = "SectionHeader";
            this.s_DraftPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DraftPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DraftPayment.Text = "1,234,567,890";
            this.s_DraftPayment.Top = 0.125F;
            this.s_DraftPayment.Width = 0.6875F;
            // 
            // s_OffsetPayment
            // 
            this.s_OffsetPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OffsetPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OffsetPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_OffsetPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_OffsetPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment.DataField = "OffsetPayment";
            this.s_OffsetPayment.Height = 0.125F;
            this.s_OffsetPayment.Left = 7.25F;
            this.s_OffsetPayment.MultiLine = false;
            this.s_OffsetPayment.Name = "s_OffsetPayment";
            this.s_OffsetPayment.OutputFormat = resources.GetString("s_OffsetPayment.OutputFormat");
            this.s_OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OffsetPayment.SummaryGroup = "SectionHeader";
            this.s_OffsetPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OffsetPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OffsetPayment.Text = "1,234,567,890";
            this.s_OffsetPayment.Top = 0.125F;
            this.s_OffsetPayment.Width = 0.6875F;
            // 
            // s_StockTtl3TmBfBlPay
            // 
            this.s_StockTtl3TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockTtl3TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl3TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockTtl3TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl3TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockTtl3TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl3TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockTtl3TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl3TmBfBlPay.DataField = "StockTtl3TmBfBlPay";
            this.s_StockTtl3TmBfBlPay.Height = 0.125F;
            this.s_StockTtl3TmBfBlPay.Left = 2.4375F;
            this.s_StockTtl3TmBfBlPay.MultiLine = false;
            this.s_StockTtl3TmBfBlPay.Name = "s_StockTtl3TmBfBlPay";
            this.s_StockTtl3TmBfBlPay.OutputFormat = resources.GetString("s_StockTtl3TmBfBlPay.OutputFormat");
            this.s_StockTtl3TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockTtl3TmBfBlPay.SummaryGroup = "SectionHeader";
            this.s_StockTtl3TmBfBlPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockTtl3TmBfBlPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockTtl3TmBfBlPay.Text = "1,234,567,890";
            this.s_StockTtl3TmBfBlPay.Top = 0.125F;
            this.s_StockTtl3TmBfBlPay.Width = 0.6875F;
            // 
            // s_StockTtl2TmBfBlPay
            // 
            this.s_StockTtl2TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.s_StockTtl2TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl2TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.s_StockTtl2TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl2TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.s_StockTtl2TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl2TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.s_StockTtl2TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_StockTtl2TmBfBlPay.DataField = "StockTtl2TmBfBlPay";
            this.s_StockTtl2TmBfBlPay.Height = 0.125F;
            this.s_StockTtl2TmBfBlPay.Left = 3.125F;
            this.s_StockTtl2TmBfBlPay.MultiLine = false;
            this.s_StockTtl2TmBfBlPay.Name = "s_StockTtl2TmBfBlPay";
            this.s_StockTtl2TmBfBlPay.OutputFormat = resources.GetString("s_StockTtl2TmBfBlPay.OutputFormat");
            this.s_StockTtl2TmBfBlPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_StockTtl2TmBfBlPay.SummaryGroup = "SectionHeader";
            this.s_StockTtl2TmBfBlPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_StockTtl2TmBfBlPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_StockTtl2TmBfBlPay.Text = "1,234,567,890";
            this.s_StockTtl2TmBfBlPay.Top = 0.125F;
            this.s_StockTtl2TmBfBlPay.Width = 0.6875F;
            // 
            // s_LastTimePayment
            // 
            this.s_LastTimePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_LastTimePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_LastTimePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimePayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_LastTimePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimePayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_LastTimePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_LastTimePayment.DataField = "LastTimePayment";
            this.s_LastTimePayment.Height = 0.125F;
            this.s_LastTimePayment.Left = 3.8125F;
            this.s_LastTimePayment.MultiLine = false;
            this.s_LastTimePayment.Name = "s_LastTimePayment";
            this.s_LastTimePayment.OutputFormat = resources.GetString("s_LastTimePayment.OutputFormat");
            this.s_LastTimePayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_LastTimePayment.SummaryGroup = "SectionHeader";
            this.s_LastTimePayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_LastTimePayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_LastTimePayment.Text = "1,234,567,890";
            this.s_LastTimePayment.Top = 0.125F;
            this.s_LastTimePayment.Width = 0.6875F;
            // 
            // s_OthsPayment
            // 
            this.s_OthsPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OthsPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OthsPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_OthsPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_OthsPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment.DataField = "OthsPayment";
            this.s_OthsPayment.Height = 0.125F;
            this.s_OthsPayment.Left = 7.9375F;
            this.s_OthsPayment.MultiLine = false;
            this.s_OthsPayment.Name = "s_OthsPayment";
            this.s_OthsPayment.OutputFormat = resources.GetString("s_OthsPayment.OutputFormat");
            this.s_OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OthsPayment.SummaryGroup = "SectionHeader";
            this.s_OthsPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OthsPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OthsPayment.Text = "1,234,567,890";
            this.s_OthsPayment.Top = 0.125F;
            this.s_OthsPayment.Width = 0.6875F;
            // 
            // s_FundTransferPayment
            // 
            this.s_FundTransferPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment.Border.RightColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment.Border.TopColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment.DataField = "FundTransferPayment";
            this.s_FundTransferPayment.Height = 0.125F;
            this.s_FundTransferPayment.Left = 8.625F;
            this.s_FundTransferPayment.MultiLine = false;
            this.s_FundTransferPayment.Name = "s_FundTransferPayment";
            this.s_FundTransferPayment.OutputFormat = resources.GetString("s_FundTransferPayment.OutputFormat");
            this.s_FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_FundTransferPayment.SummaryGroup = "SectionHeader";
            this.s_FundTransferPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_FundTransferPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_FundTransferPayment.Text = "1,234,567,890";
            this.s_FundTransferPayment.Top = 0.125F;
            this.s_FundTransferPayment.Width = 0.6875F;
            // 
            // s_ThisTimeFeePayNrml
            // 
            this.s_ThisTimeFeePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml.DataField = "ThisTimeFeePayNrml";
            this.s_ThisTimeFeePayNrml.Height = 0.125F;
            this.s_ThisTimeFeePayNrml.Left = 9.3125F;
            this.s_ThisTimeFeePayNrml.MultiLine = false;
            this.s_ThisTimeFeePayNrml.Name = "s_ThisTimeFeePayNrml";
            this.s_ThisTimeFeePayNrml.OutputFormat = resources.GetString("s_ThisTimeFeePayNrml.OutputFormat");
            this.s_ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeFeePayNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeePayNrml.Text = "1,234,567,890";
            this.s_ThisTimeFeePayNrml.Top = 0.125F;
            this.s_ThisTimeFeePayNrml.Width = 0.6875F;
            // 
            // s_ThisTimeDisPayNrml
            // 
            this.s_ThisTimeDisPayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml.DataField = "ThisTimeDisPayNrml";
            this.s_ThisTimeDisPayNrml.Height = 0.125F;
            this.s_ThisTimeDisPayNrml.Left = 10F;
            this.s_ThisTimeDisPayNrml.MultiLine = false;
            this.s_ThisTimeDisPayNrml.Name = "s_ThisTimeDisPayNrml";
            this.s_ThisTimeDisPayNrml.OutputFormat = resources.GetString("s_ThisTimeDisPayNrml.OutputFormat");
            this.s_ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeDisPayNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisPayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisPayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisPayNrml.Text = "1,234,567,890";
            this.s_ThisTimeDisPayNrml.Top = 0.125F;
            this.s_ThisTimeDisPayNrml.Width = 0.6875F;
            // 
            // SumSuplierPayHeader
            // 
            this.SumSuplierPayHeader.CanShrink = true;
            this.SumSuplierPayHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ThisTimeDisPayNrml,
            this.ThisTimeFeePayNrml,
            this.FundTransferPayment,
            this.OthsPayment,
            this.OffsetPayment,
            this.DraftPayment,
            this.CheckPayment,
            this.TrfrPayment,
            this.CashPayment,
            this.LastTimePayment,
            this.StockTtl2TmBfBlPay,
            this.StockTtl3TmBfBlPay,
            this.SumPayeeCode,
            this.SumPayeeSnm,
            this.ResultsSectCd,
            this.PaymentBalance,
            this.ThisTimePayNrml,
            this.ThisTimeTtlBlcPay,
            this.ThisTimeStockPrice,
            this.RetGoodsDiscount,
            this.PureCost,
            this.OfsThisStockTax,
            this.ThisTotal,
            this.StockTotalPayBalance,
            this.PaymentDay,
            this.textBox10,
            this.PaymentMonthName,
            this.StockSlipCount,
            this.Line13});
            this.SumSuplierPayHeader.DataField = "SumPayeeCode";
            this.SumSuplierPayHeader.Height = 0.365F;
            this.SumSuplierPayHeader.Name = "SumSuplierPayHeader";
            this.SumSuplierPayHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SumSuplierPayFooter
            // 
            this.SumSuplierPayFooter.CanShrink = true;
            this.SumSuplierPayFooter.Height = 0F;
            this.SumSuplierPayFooter.KeepTogether = true;
            this.SumSuplierPayFooter.Name = "SumSuplierPayFooter";
            // 
            // PMKAK02003P_01A4C
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
            this.Sections.Add(this.SumSuplierPayHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SumSuplierPayFooter);
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
            this.ReportStart += new System.EventHandler(this.PMKAK02003P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetGoodsDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentMonthName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl3TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl2TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsSectCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_StockTtl3TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_StockTtl2TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_LastTimePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PaymentBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeTtlBlcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_RetGoodsDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_PureCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockTotalPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_StockTtl3TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_StockTtl2TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_LastTimePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumAddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumAddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PaymentBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeTtlBlcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockTotalPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_RetGoodsDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_PureCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockTtl3TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_StockTtl2TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_LastTimePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
