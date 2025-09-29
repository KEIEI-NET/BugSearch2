using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入先マスタ（印刷）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 仕入先マスタ（印刷）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN08565P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 仕入先マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 仕入先マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08565P_01A4C()
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
        
		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label label1;
        private Label label5;
        private TextBox suppliercd;
        private TextBox suppliertelno;
        private TextBox suppliersnm;
        private Line line2;
        private Line line3;
        private TextBox supplierkana;
        private TextBox suppliertelno1;
        private TextBox suppliertelno2;
        private Label lblcompanytelno1;
        private Label lblcompanytelno2;
        private Label lblcompanytelno3;
        private Label label13;
        private TextBox supplierpostno;
        private TextBox supplieraddrall;
        private TextBox stockagentcode;
        private Label label14;
        private Label label16;
        private TextBox mngsectioncode;
        private TextBox stockagentname;
        private TextBox payeesnm;
        private TextBox sectionguidenm;
        private Label label17;
        private Label label18;
        private TextBox paymenttotalday;
        private TextBox paymentcond;
        private TextBox paymentsectioncode;
        private TextBox payeecode;
        private Label label4;
        private Label label6;
        private TextBox paymentmonthday;
        private Label label7;

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
				// TODO:  PMKHN08565P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08565P_01A4C.WatermarkMode setter 実装を追加します。
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			
			// 項目の名称をセット
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// サブタイトル

            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            
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

		#region ◎ PMKHN08565P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08565P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08565P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08565P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08565P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08565P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08565P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
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
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
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

		#region ◎ Detail_Format Event
		/// <summary>
		/// Detail_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: Detailグループのフォーマットイベント。</br>
		/// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            if (this.paymenttotalday.Value != null)
            {
                if ((int)this.paymenttotalday.Value != 0)
                {
                    this.paymenttotalday.Text = this.paymenttotalday.Value + "日";
                }
            }
            if (this.paymentmonthday.Text != null)
            {
                if (!this.paymentmonthday.Text.Trim().Equals(string.Empty))
                {
                    this.paymentmonthday.Text = this.paymentmonthday.Text + "日";
                }
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
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
		/// <br>Programmer  : 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
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
		/// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.03.18 30413 犬飼 フッター部の印刷設定 >>>>>>START
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
            // 2009.03.18 30413 犬飼 フッター部の印刷設定 <<<<<<END
        }
		#endregion
        
        #region ◎ PageFooter_AfterPrint Event
        /// <summary>
        /// PageFooter_AfterPrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画された後に発生します。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
        /// <br>Date		: 2008.10.30</br>
        /// </remarks>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
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
        private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08565P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.suppliercd = new DataDynamics.ActiveReports.TextBox();
            this.suppliertelno = new DataDynamics.ActiveReports.TextBox();
            this.suppliersnm = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.supplierkana = new DataDynamics.ActiveReports.TextBox();
            this.suppliertelno1 = new DataDynamics.ActiveReports.TextBox();
            this.suppliertelno2 = new DataDynamics.ActiveReports.TextBox();
            this.supplierpostno = new DataDynamics.ActiveReports.TextBox();
            this.supplieraddrall = new DataDynamics.ActiveReports.TextBox();
            this.stockagentcode = new DataDynamics.ActiveReports.TextBox();
            this.mngsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.stockagentname = new DataDynamics.ActiveReports.TextBox();
            this.payeesnm = new DataDynamics.ActiveReports.TextBox();
            this.sectionguidenm = new DataDynamics.ActiveReports.TextBox();
            this.paymenttotalday = new DataDynamics.ActiveReports.TextBox();
            this.paymentcond = new DataDynamics.ActiveReports.TextBox();
            this.paymentsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.payeecode = new DataDynamics.ActiveReports.TextBox();
            this.paymentmonthday = new DataDynamics.ActiveReports.TextBox();
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
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.lblcompanytelno1 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno2 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno3 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.suppliercd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliertelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierkana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliertelno1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliertelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierpostno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplieraddrall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockagentcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockagentname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payeesnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidenm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymenttotalday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentcond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payeecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentmonthday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.suppliercd,
            this.suppliertelno,
            this.suppliersnm,
            this.line3,
            this.supplierkana,
            this.suppliertelno1,
            this.suppliertelno2,
            this.supplierpostno,
            this.supplieraddrall,
            this.stockagentcode,
            this.mngsectioncode,
            this.stockagentname,
            this.payeesnm,
            this.sectionguidenm,
            this.paymenttotalday,
            this.paymentcond,
            this.paymentsectioncode,
            this.payeecode,
            this.paymentmonthday});
            this.Detail.Height = 0.3833333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // suppliercd
            // 
            this.suppliercd.Border.BottomColor = System.Drawing.Color.Black;
            this.suppliercd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliercd.Border.LeftColor = System.Drawing.Color.Black;
            this.suppliercd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliercd.Border.RightColor = System.Drawing.Color.Black;
            this.suppliercd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliercd.Border.TopColor = System.Drawing.Color.Black;
            this.suppliercd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliercd.DataField = "suppliercd";
            this.suppliercd.Height = 0.15F;
            this.suppliercd.Left = 0F;
            this.suppliercd.MultiLine = false;
            this.suppliercd.Name = "suppliercd";
            this.suppliercd.OutputFormat = resources.GetString("suppliercd.OutputFormat");
            this.suppliercd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.suppliercd.Text = "123456";
            this.suppliercd.Top = 0.02083333F;
            this.suppliercd.Width = 0.37F;
            // 
            // suppliertelno
            // 
            this.suppliertelno.Border.BottomColor = System.Drawing.Color.Black;
            this.suppliertelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno.Border.LeftColor = System.Drawing.Color.Black;
            this.suppliertelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno.Border.RightColor = System.Drawing.Color.Black;
            this.suppliertelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno.Border.TopColor = System.Drawing.Color.Black;
            this.suppliertelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno.DataField = "suppliertelno";
            this.suppliertelno.Height = 0.15F;
            this.suppliertelno.Left = 2.625F;
            this.suppliertelno.MultiLine = false;
            this.suppliertelno.Name = "suppliertelno";
            this.suppliertelno.OutputFormat = resources.GetString("suppliertelno.OutputFormat");
            this.suppliertelno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.suppliertelno.Text = "1234567890123456";
            this.suppliertelno.Top = 0.02083333F;
            this.suppliertelno.Width = 0.95F;
            // 
            // suppliersnm
            // 
            this.suppliersnm.Border.BottomColor = System.Drawing.Color.Black;
            this.suppliersnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliersnm.Border.LeftColor = System.Drawing.Color.Black;
            this.suppliersnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliersnm.Border.RightColor = System.Drawing.Color.Black;
            this.suppliersnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliersnm.Border.TopColor = System.Drawing.Color.Black;
            this.suppliersnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliersnm.DataField = "suppliersnm";
            this.suppliersnm.Height = 0.15F;
            this.suppliersnm.Left = 0.3749999F;
            this.suppliersnm.MultiLine = false;
            this.suppliersnm.Name = "suppliersnm";
            this.suppliersnm.OutputFormat = resources.GetString("suppliersnm.OutputFormat");
            this.suppliersnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.suppliersnm.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.suppliersnm.Top = 0.02083333F;
            this.suppliersnm.Width = 2.28F;
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
            this.line3.Top = 0.34375F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.34375F;
            this.line3.Y2 = 0.34375F;
            // 
            // supplierkana
            // 
            this.supplierkana.Border.BottomColor = System.Drawing.Color.Black;
            this.supplierkana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierkana.Border.LeftColor = System.Drawing.Color.Black;
            this.supplierkana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierkana.Border.RightColor = System.Drawing.Color.Black;
            this.supplierkana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierkana.Border.TopColor = System.Drawing.Color.Black;
            this.supplierkana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierkana.DataField = "supplierkana";
            this.supplierkana.Height = 0.15F;
            this.supplierkana.Left = 0.3749999F;
            this.supplierkana.MultiLine = false;
            this.supplierkana.Name = "supplierkana";
            this.supplierkana.OutputFormat = resources.GetString("supplierkana.OutputFormat");
            this.supplierkana.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.supplierkana.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.supplierkana.Top = 0.1916666F;
            this.supplierkana.Width = 2.25F;
            // 
            // suppliertelno1
            // 
            this.suppliertelno1.Border.BottomColor = System.Drawing.Color.Black;
            this.suppliertelno1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno1.Border.LeftColor = System.Drawing.Color.Black;
            this.suppliertelno1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno1.Border.RightColor = System.Drawing.Color.Black;
            this.suppliertelno1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno1.Border.TopColor = System.Drawing.Color.Black;
            this.suppliertelno1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno1.DataField = "suppliertelno1";
            this.suppliertelno1.Height = 0.15F;
            this.suppliertelno1.Left = 3.572917F;
            this.suppliertelno1.MultiLine = false;
            this.suppliertelno1.Name = "suppliertelno1";
            this.suppliertelno1.OutputFormat = resources.GetString("suppliertelno1.OutputFormat");
            this.suppliertelno1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.suppliertelno1.Text = "1234567890123456";
            this.suppliertelno1.Top = 0.02083333F;
            this.suppliertelno1.Width = 0.95F;
            // 
            // suppliertelno2
            // 
            this.suppliertelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.suppliertelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.suppliertelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno2.Border.RightColor = System.Drawing.Color.Black;
            this.suppliertelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno2.Border.TopColor = System.Drawing.Color.Black;
            this.suppliertelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.suppliertelno2.DataField = "suppliertelno2";
            this.suppliertelno2.Height = 0.15F;
            this.suppliertelno2.Left = 4.520833F;
            this.suppliertelno2.MultiLine = false;
            this.suppliertelno2.Name = "suppliertelno2";
            this.suppliertelno2.OutputFormat = resources.GetString("suppliertelno2.OutputFormat");
            this.suppliertelno2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.suppliertelno2.Text = "1234567890123456";
            this.suppliertelno2.Top = 0.02083333F;
            this.suppliertelno2.Width = 0.95F;
            // 
            // supplierpostno
            // 
            this.supplierpostno.Border.BottomColor = System.Drawing.Color.Black;
            this.supplierpostno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierpostno.Border.LeftColor = System.Drawing.Color.Black;
            this.supplierpostno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierpostno.Border.RightColor = System.Drawing.Color.Black;
            this.supplierpostno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierpostno.Border.TopColor = System.Drawing.Color.Black;
            this.supplierpostno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierpostno.DataField = "supplierpostno";
            this.supplierpostno.Height = 0.15F;
            this.supplierpostno.Left = 2.625F;
            this.supplierpostno.MultiLine = false;
            this.supplierpostno.Name = "supplierpostno";
            this.supplierpostno.OutputFormat = resources.GetString("supplierpostno.OutputFormat");
            this.supplierpostno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.supplierpostno.Text = "1234567890";
            this.supplierpostno.Top = 0.1916666F;
            this.supplierpostno.Width = 0.6F;
            // 
            // supplieraddrall
            // 
            this.supplieraddrall.Border.BottomColor = System.Drawing.Color.Black;
            this.supplieraddrall.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplieraddrall.Border.LeftColor = System.Drawing.Color.Black;
            this.supplieraddrall.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplieraddrall.Border.RightColor = System.Drawing.Color.Black;
            this.supplieraddrall.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplieraddrall.Border.TopColor = System.Drawing.Color.Black;
            this.supplieraddrall.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplieraddrall.DataField = "supplieraddrall";
            this.supplieraddrall.Height = 0.15F;
            this.supplieraddrall.Left = 3.239583F;
            this.supplieraddrall.MultiLine = false;
            this.supplieraddrall.Name = "supplieraddrall";
            this.supplieraddrall.OutputFormat = resources.GetString("supplieraddrall.OutputFormat");
            this.supplieraddrall.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.supplieraddrall.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.supplieraddrall.Top = 0.1875F;
            this.supplieraddrall.Width = 6.2F;
            // 
            // stockagentcode
            // 
            this.stockagentcode.Border.BottomColor = System.Drawing.Color.Black;
            this.stockagentcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentcode.Border.LeftColor = System.Drawing.Color.Black;
            this.stockagentcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentcode.Border.RightColor = System.Drawing.Color.Black;
            this.stockagentcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentcode.Border.TopColor = System.Drawing.Color.Black;
            this.stockagentcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentcode.DataField = "stockagentcode";
            this.stockagentcode.Height = 0.15F;
            this.stockagentcode.Left = 7.124998F;
            this.stockagentcode.MultiLine = false;
            this.stockagentcode.Name = "stockagentcode";
            this.stockagentcode.OutputFormat = resources.GetString("stockagentcode.OutputFormat");
            this.stockagentcode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.stockagentcode.Text = "1234";
            this.stockagentcode.Top = 0.02083333F;
            this.stockagentcode.Width = 0.25F;
            // 
            // mngsectioncode
            // 
            this.mngsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.mngsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.mngsectioncode.DataField = "mngsectioncode";
            this.mngsectioncode.Height = 0.15F;
            this.mngsectioncode.Left = 9.447915F;
            this.mngsectioncode.MultiLine = false;
            this.mngsectioncode.Name = "mngsectioncode";
            this.mngsectioncode.OutputFormat = resources.GetString("mngsectioncode.OutputFormat");
            this.mngsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.mngsectioncode.Text = "1234";
            this.mngsectioncode.Top = 0.1875F;
            this.mngsectioncode.Width = 0.17F;
            // 
            // stockagentname
            // 
            this.stockagentname.Border.BottomColor = System.Drawing.Color.Black;
            this.stockagentname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentname.Border.LeftColor = System.Drawing.Color.Black;
            this.stockagentname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentname.Border.RightColor = System.Drawing.Color.Black;
            this.stockagentname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentname.Border.TopColor = System.Drawing.Color.Black;
            this.stockagentname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockagentname.DataField = "stockagentname";
            this.stockagentname.Height = 0.15F;
            this.stockagentname.Left = 7.374997F;
            this.stockagentname.MultiLine = false;
            this.stockagentname.Name = "stockagentname";
            this.stockagentname.OutputFormat = resources.GetString("stockagentname.OutputFormat");
            this.stockagentname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.stockagentname.Text = "あいうえおかきくけこ";
            this.stockagentname.Top = 0.02083333F;
            this.stockagentname.Width = 1.15F;
            // 
            // payeesnm
            // 
            this.payeesnm.Border.BottomColor = System.Drawing.Color.Black;
            this.payeesnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeesnm.Border.LeftColor = System.Drawing.Color.Black;
            this.payeesnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeesnm.Border.RightColor = System.Drawing.Color.Black;
            this.payeesnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeesnm.Border.TopColor = System.Drawing.Color.Black;
            this.payeesnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeesnm.DataField = "payeesnm";
            this.payeesnm.Height = 0.15F;
            this.payeesnm.Left = 9.062497F;
            this.payeesnm.MultiLine = false;
            this.payeesnm.Name = "payeesnm";
            this.payeesnm.OutputFormat = resources.GetString("payeesnm.OutputFormat");
            this.payeesnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.payeesnm.Text = "あいうえおかきくけこあいうえお";
            this.payeesnm.Top = 0.02083333F;
            this.payeesnm.Width = 1.75F;
            // 
            // sectionguidenm
            // 
            this.sectionguidenm.Border.BottomColor = System.Drawing.Color.Black;
            this.sectionguidenm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidenm.Border.LeftColor = System.Drawing.Color.Black;
            this.sectionguidenm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidenm.Border.RightColor = System.Drawing.Color.Black;
            this.sectionguidenm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidenm.Border.TopColor = System.Drawing.Color.Black;
            this.sectionguidenm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidenm.DataField = "sectionguidenm";
            this.sectionguidenm.Height = 0.15F;
            this.sectionguidenm.Left = 9.614584F;
            this.sectionguidenm.MultiLine = false;
            this.sectionguidenm.Name = "sectionguidenm";
            this.sectionguidenm.OutputFormat = resources.GetString("sectionguidenm.OutputFormat");
            this.sectionguidenm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sectionguidenm.Text = "あいうえおかきくけこ";
            this.sectionguidenm.Top = 0.1875F;
            this.sectionguidenm.Width = 1.15F;
            // 
            // paymenttotalday
            // 
            this.paymenttotalday.Border.BottomColor = System.Drawing.Color.Black;
            this.paymenttotalday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymenttotalday.Border.LeftColor = System.Drawing.Color.Black;
            this.paymenttotalday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymenttotalday.Border.RightColor = System.Drawing.Color.Black;
            this.paymenttotalday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymenttotalday.Border.TopColor = System.Drawing.Color.Black;
            this.paymenttotalday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymenttotalday.DataField = "paymenttotalday";
            this.paymenttotalday.Height = 0.15F;
            this.paymenttotalday.Left = 5.46875F;
            this.paymenttotalday.MultiLine = false;
            this.paymenttotalday.Name = "paymenttotalday";
            this.paymenttotalday.OutputFormat = resources.GetString("paymenttotalday.OutputFormat");
            this.paymenttotalday.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.paymenttotalday.Text = "99日";
            this.paymenttotalday.Top = 0.02083333F;
            this.paymenttotalday.Width = 0.27F;
            // 
            // paymentcond
            // 
            this.paymentcond.Border.BottomColor = System.Drawing.Color.Black;
            this.paymentcond.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentcond.Border.LeftColor = System.Drawing.Color.Black;
            this.paymentcond.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentcond.Border.RightColor = System.Drawing.Color.Black;
            this.paymentcond.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentcond.Border.TopColor = System.Drawing.Color.Black;
            this.paymentcond.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentcond.DataField = "paymentcond";
            this.paymentcond.Height = 0.15F;
            this.paymentcond.Left = 5.739583F;
            this.paymentcond.MultiLine = false;
            this.paymentcond.Name = "paymentcond";
            this.paymentcond.OutputFormat = resources.GetString("paymentcond.OutputFormat");
            this.paymentcond.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.paymentcond.Text = "80:その他";
            this.paymentcond.Top = 0.02083333F;
            this.paymentcond.Width = 0.57F;
            // 
            // paymentsectioncode
            // 
            this.paymentsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.paymentsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.paymentsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.paymentsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.paymentsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentsectioncode.DataField = "paymentsectioncode";
            this.paymentsectioncode.Height = 0.15F;
            this.paymentsectioncode.Left = 8.520829F;
            this.paymentsectioncode.MultiLine = false;
            this.paymentsectioncode.Name = "paymentsectioncode";
            this.paymentsectioncode.OutputFormat = resources.GetString("paymentsectioncode.OutputFormat");
            this.paymentsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.paymentsectioncode.Text = "12";
            this.paymentsectioncode.Top = 0.02083333F;
            this.paymentsectioncode.Width = 0.17F;
            // 
            // payeecode
            // 
            this.payeecode.Border.BottomColor = System.Drawing.Color.Black;
            this.payeecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeecode.Border.LeftColor = System.Drawing.Color.Black;
            this.payeecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeecode.Border.RightColor = System.Drawing.Color.Black;
            this.payeecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeecode.Border.TopColor = System.Drawing.Color.Black;
            this.payeecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.payeecode.DataField = "payeecode";
            this.payeecode.Height = 0.15F;
            this.payeecode.Left = 8.687498F;
            this.payeecode.MultiLine = false;
            this.payeecode.Name = "payeecode";
            this.payeecode.OutputFormat = resources.GetString("payeecode.OutputFormat");
            this.payeecode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.payeecode.Text = "123456";
            this.payeecode.Top = 0.02083333F;
            this.payeecode.Width = 0.37F;
            // 
            // paymentmonthday
            // 
            this.paymentmonthday.Border.BottomColor = System.Drawing.Color.Black;
            this.paymentmonthday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentmonthday.Border.LeftColor = System.Drawing.Color.Black;
            this.paymentmonthday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentmonthday.Border.RightColor = System.Drawing.Color.Black;
            this.paymentmonthday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentmonthday.Border.TopColor = System.Drawing.Color.Black;
            this.paymentmonthday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.paymentmonthday.DataField = "paymentmonthday";
            this.paymentmonthday.Height = 0.15F;
            this.paymentmonthday.Left = 6.3125F;
            this.paymentmonthday.MultiLine = false;
            this.paymentmonthday.Name = "paymentmonthday";
            this.paymentmonthday.OutputFormat = resources.GetString("paymentmonthday.OutputFormat");
            this.paymentmonthday.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.paymentmonthday.Text = "80:その他";
            this.paymentmonthday.Top = 0.02083333F;
            this.paymentmonthday.Width = 0.8F;
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
            this.tb_ReportTitle.Text = "仕入先マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3020833F;
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
            this.Line5,
            this.label1,
            this.label5,
            this.line2,
            this.lblcompanytelno1,
            this.lblcompanytelno2,
            this.lblcompanytelno3,
            this.label13,
            this.label14,
            this.label16,
            this.label17,
            this.label18,
            this.label4,
            this.label6,
            this.label7});
            this.TitleHeader.Height = 0.425F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Line5.Width = 10.8F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
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
            this.label1.Height = 0.15F;
            this.label1.HyperLink = "";
            this.label1.Left = 0F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "仕入先";
            this.label1.Top = 0.0625F;
            this.label1.Width = 2.25F;
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
            this.label5.Height = 0.15F;
            this.label5.HyperLink = "";
            this.label5.Left = 0.3749999F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "ｶﾅ";
            this.label5.Top = 0.2395834F;
            this.label5.Width = 1.14F;
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
            this.line2.Top = 0.3958333F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.3958333F;
            this.line2.Y2 = 0.3958333F;
            // 
            // lblcompanytelno1
            // 
            this.lblcompanytelno1.Border.BottomColor = System.Drawing.Color.Black;
            this.lblcompanytelno1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno1.Border.LeftColor = System.Drawing.Color.Black;
            this.lblcompanytelno1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno1.Border.RightColor = System.Drawing.Color.Black;
            this.lblcompanytelno1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno1.Border.TopColor = System.Drawing.Color.Black;
            this.lblcompanytelno1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno1.Height = 0.15F;
            this.lblcompanytelno1.HyperLink = "";
            this.lblcompanytelno1.Left = 2.625F;
            this.lblcompanytelno1.MultiLine = false;
            this.lblcompanytelno1.Name = "lblcompanytelno1";
            this.lblcompanytelno1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno1.Text = "電話番号１";
            this.lblcompanytelno1.Top = 0.0625F;
            this.lblcompanytelno1.Width = 0.95F;
            // 
            // lblcompanytelno2
            // 
            this.lblcompanytelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.lblcompanytelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.lblcompanytelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno2.Border.RightColor = System.Drawing.Color.Black;
            this.lblcompanytelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno2.Border.TopColor = System.Drawing.Color.Black;
            this.lblcompanytelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno2.Height = 0.15F;
            this.lblcompanytelno2.HyperLink = "";
            this.lblcompanytelno2.Left = 3.572917F;
            this.lblcompanytelno2.MultiLine = false;
            this.lblcompanytelno2.Name = "lblcompanytelno2";
            this.lblcompanytelno2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno2.Text = "電話番号２";
            this.lblcompanytelno2.Top = 0.0625F;
            this.lblcompanytelno2.Width = 0.95F;
            // 
            // lblcompanytelno3
            // 
            this.lblcompanytelno3.Border.BottomColor = System.Drawing.Color.Black;
            this.lblcompanytelno3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno3.Border.LeftColor = System.Drawing.Color.Black;
            this.lblcompanytelno3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno3.Border.RightColor = System.Drawing.Color.Black;
            this.lblcompanytelno3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno3.Border.TopColor = System.Drawing.Color.Black;
            this.lblcompanytelno3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcompanytelno3.Height = 0.15F;
            this.lblcompanytelno3.HyperLink = "";
            this.lblcompanytelno3.Left = 4.520833F;
            this.lblcompanytelno3.MultiLine = false;
            this.lblcompanytelno3.Name = "lblcompanytelno3";
            this.lblcompanytelno3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno3.Text = "ＦＡＸ";
            this.lblcompanytelno3.Top = 0.0625F;
            this.lblcompanytelno3.Width = 0.95F;
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
            this.label13.Height = 0.15F;
            this.label13.HyperLink = "";
            this.label13.Left = 2.625F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "郵便番号";
            this.label13.Top = 0.2395834F;
            this.label13.Width = 0.6F;
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
            this.label14.Height = 0.15F;
            this.label14.HyperLink = "";
            this.label14.Left = 5.46875F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "締日";
            this.label14.Top = 0.0625F;
            this.label14.Width = 0.27F;
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
            this.label16.Height = 0.15F;
            this.label16.HyperLink = "";
            this.label16.Left = 5.739583F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "支払条件";
            this.label16.Top = 0.0625F;
            this.label16.Width = 0.57F;
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
            this.label17.Height = 0.15F;
            this.label17.HyperLink = "";
            this.label17.Left = 8.520829F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "支払先";
            this.label17.Top = 0.0625F;
            this.label17.Width = 1.4F;
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
            this.label18.Height = 0.15F;
            this.label18.HyperLink = "";
            this.label18.Left = 9.447915F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "拠点";
            this.label18.Top = 0.2395834F;
            this.label18.Width = 1.15F;
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
            this.label4.Height = 0.15F;
            this.label4.HyperLink = "";
            this.label4.Left = 7.124998F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "担当者";
            this.label4.Top = 0.0625F;
            this.label4.Width = 0.57F;
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
            this.label6.Height = 0.15F;
            this.label6.HyperLink = "";
            this.label6.Left = 3.239583F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "住所";
            this.label6.Top = 0.2395834F;
            this.label6.Width = 0.95F;
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
            this.label7.Height = 0.15F;
            this.label7.HyperLink = "";
            this.label7.Left = 6.3125F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "支払月日";
            this.label7.Top = 0.0625F;
            this.label7.Width = 0.57F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0.006510417F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08565P_01A4C
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
            this.PageEnd += new System.EventHandler(this.PMKHN08565P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08565P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.suppliercd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliertelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierkana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliertelno1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliertelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierpostno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplieraddrall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockagentcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mngsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockagentname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payeesnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidenm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymenttotalday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentcond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payeecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentmonthday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
