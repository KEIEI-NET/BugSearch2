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
	/// 従業員マスタ（印刷）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 従業員マスタ（印刷）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN08525P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 従業員マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 従業員マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08525P_01A4C()
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
        private Label label4;
        private Label label5;
        private TextBox employeecode;
        private TextBox name;
        private Line line2;
        private Line line3;
        private TextBox kana;
        private TextBox shortname;
        private Label label8;
        private Label lblcompanytelno1;
        private Label lblcompanytelno2;
        private Label label13;
        private TextBox birthday;
        private TextBox authoritylevelnm1;
        private TextBox authoritylevelnm2;
        private TextBox belongsectioncode;
        private Label label14;
        private Label label15;
        private TextBox belongsubsectioncode;
        private TextBox employanalyscode1;
        private TextBox sectionguidenm;
        private TextBox subsectionname;
        private Label label17;
        private Label label18;
        private TextBox sexname;
        private Label label6;
        private TextBox companytelno;
        private TextBox portabletelno;
        private TextBox entercompanydate;
        private TextBox retirementdate;
        private TextBox employanalyscode4;
        private TextBox employanalyscode2;
        private TextBox employanalyscode5;
        private TextBox employanalyscode3;
        private TextBox employanalyscode6;
        private Label label7;
        private Label label9;
        private Label label10;
        private Label label11;

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
				// TODO:  PMKHN08525P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08525P_01A4C.WatermarkMode setter 実装を追加します。
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

		#region ◎ PMKHN08525P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08525P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08525P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08525P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08525P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08525P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08525P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08525P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.kana = new DataDynamics.ActiveReports.TextBox();
            this.employeecode = new DataDynamics.ActiveReports.TextBox();
            this.name = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.shortname = new DataDynamics.ActiveReports.TextBox();
            this.birthday = new DataDynamics.ActiveReports.TextBox();
            this.authoritylevelnm1 = new DataDynamics.ActiveReports.TextBox();
            this.authoritylevelnm2 = new DataDynamics.ActiveReports.TextBox();
            this.belongsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.belongsubsectioncode = new DataDynamics.ActiveReports.TextBox();
            this.employanalyscode1 = new DataDynamics.ActiveReports.TextBox();
            this.sectionguidenm = new DataDynamics.ActiveReports.TextBox();
            this.subsectionname = new DataDynamics.ActiveReports.TextBox();
            this.sexname = new DataDynamics.ActiveReports.TextBox();
            this.companytelno = new DataDynamics.ActiveReports.TextBox();
            this.portabletelno = new DataDynamics.ActiveReports.TextBox();
            this.entercompanydate = new DataDynamics.ActiveReports.TextBox();
            this.retirementdate = new DataDynamics.ActiveReports.TextBox();
            this.employanalyscode4 = new DataDynamics.ActiveReports.TextBox();
            this.employanalyscode2 = new DataDynamics.ActiveReports.TextBox();
            this.employanalyscode5 = new DataDynamics.ActiveReports.TextBox();
            this.employanalyscode3 = new DataDynamics.ActiveReports.TextBox();
            this.employanalyscode6 = new DataDynamics.ActiveReports.TextBox();
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
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno1 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno2 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.kana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authoritylevelnm1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.authoritylevelnm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.belongsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.belongsubsectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidenm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsectionname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portabletelno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entercompanydate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.retirementdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.kana,
            this.employeecode,
            this.name,
            this.line3,
            this.shortname,
            this.birthday,
            this.authoritylevelnm1,
            this.authoritylevelnm2,
            this.belongsectioncode,
            this.belongsubsectioncode,
            this.employanalyscode1,
            this.sectionguidenm,
            this.subsectionname,
            this.sexname,
            this.companytelno,
            this.portabletelno,
            this.entercompanydate,
            this.retirementdate,
            this.employanalyscode4,
            this.employanalyscode2,
            this.employanalyscode5,
            this.employanalyscode3,
            this.employanalyscode6});
            this.Detail.Height = 0.4231771F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // kana
            // 
            this.kana.Border.BottomColor = System.Drawing.Color.Black;
            this.kana.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.Border.LeftColor = System.Drawing.Color.Black;
            this.kana.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.Border.RightColor = System.Drawing.Color.Black;
            this.kana.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.Border.TopColor = System.Drawing.Color.Black;
            this.kana.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.kana.DataField = "kana";
            this.kana.Height = 0.15F;
            this.kana.Left = 0.3125F;
            this.kana.MultiLine = false;
            this.kana.Name = "kana";
            this.kana.OutputFormat = resources.GetString("kana.OutputFormat");
            this.kana.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.kana.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.kana.Top = 0.1916666F;
            this.kana.Width = 3.37F;
            // 
            // employeecode
            // 
            this.employeecode.Border.BottomColor = System.Drawing.Color.Black;
            this.employeecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.Border.LeftColor = System.Drawing.Color.Black;
            this.employeecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.Border.RightColor = System.Drawing.Color.Black;
            this.employeecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.Border.TopColor = System.Drawing.Color.Black;
            this.employeecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.DataField = "employeecode";
            this.employeecode.Height = 0.15F;
            this.employeecode.Left = 0F;
            this.employeecode.MultiLine = false;
            this.employeecode.Name = "employeecode";
            this.employeecode.OutputFormat = resources.GetString("employeecode.OutputFormat");
            this.employeecode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employeecode.Text = "1234";
            this.employeecode.Top = 0.02083333F;
            this.employeecode.Width = 0.3125F;
            // 
            // name
            // 
            this.name.Border.BottomColor = System.Drawing.Color.Black;
            this.name.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.Border.LeftColor = System.Drawing.Color.Black;
            this.name.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.Border.RightColor = System.Drawing.Color.Black;
            this.name.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.Border.TopColor = System.Drawing.Color.Black;
            this.name.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.name.DataField = "name";
            this.name.Height = 0.15F;
            this.name.Left = 0.3125F;
            this.name.MultiLine = false;
            this.name.Name = "name";
            this.name.OutputFormat = resources.GetString("name.OutputFormat");
            this.name.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.name.Text = "あいうえおかきくけこ";
            this.name.Top = 0.02083333F;
            this.name.Width = 1.14F;
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
            this.line3.Top = 0.3541667F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.3541667F;
            this.line3.Y2 = 0.3541667F;
            // 
            // shortname
            // 
            this.shortname.Border.BottomColor = System.Drawing.Color.Black;
            this.shortname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shortname.Border.LeftColor = System.Drawing.Color.Black;
            this.shortname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shortname.Border.RightColor = System.Drawing.Color.Black;
            this.shortname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shortname.Border.TopColor = System.Drawing.Color.Black;
            this.shortname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shortname.DataField = "shortname";
            this.shortname.Height = 0.15F;
            this.shortname.Left = 1.510417F;
            this.shortname.MultiLine = false;
            this.shortname.Name = "shortname";
            this.shortname.OutputFormat = resources.GetString("shortname.OutputFormat");
            this.shortname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.shortname.Text = "あいうえお";
            this.shortname.Top = 0.02083333F;
            this.shortname.Width = 1.14F;
            // 
            // birthday
            // 
            this.birthday.Border.BottomColor = System.Drawing.Color.Black;
            this.birthday.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.birthday.Border.LeftColor = System.Drawing.Color.Black;
            this.birthday.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.birthday.Border.RightColor = System.Drawing.Color.Black;
            this.birthday.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.birthday.Border.TopColor = System.Drawing.Color.Black;
            this.birthday.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.birthday.DataField = "birthday";
            this.birthday.Height = 0.15F;
            this.birthday.Left = 3.708332F;
            this.birthday.MultiLine = false;
            this.birthday.Name = "birthday";
            this.birthday.OutputFormat = resources.GetString("birthday.OutputFormat");
            this.birthday.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.birthday.Text = "9999/99/99";
            this.birthday.Top = 0.02083333F;
            this.birthday.Width = 0.6F;
            // 
            // authoritylevelnm1
            // 
            this.authoritylevelnm1.Border.BottomColor = System.Drawing.Color.Black;
            this.authoritylevelnm1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm1.Border.LeftColor = System.Drawing.Color.Black;
            this.authoritylevelnm1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm1.Border.RightColor = System.Drawing.Color.Black;
            this.authoritylevelnm1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm1.Border.TopColor = System.Drawing.Color.Black;
            this.authoritylevelnm1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm1.DataField = "authoritylevelnm1";
            this.authoritylevelnm1.Height = 0.15F;
            this.authoritylevelnm1.Left = 4.343751F;
            this.authoritylevelnm1.MultiLine = false;
            this.authoritylevelnm1.Name = "authoritylevelnm1";
            this.authoritylevelnm1.OutputFormat = resources.GetString("authoritylevelnm1.OutputFormat");
            this.authoritylevelnm1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.authoritylevelnm1.Text = "あいうえおかきくけこ";
            this.authoritylevelnm1.Top = 0.02083333F;
            this.authoritylevelnm1.Width = 1.14F;
            // 
            // authoritylevelnm2
            // 
            this.authoritylevelnm2.Border.BottomColor = System.Drawing.Color.Black;
            this.authoritylevelnm2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm2.Border.LeftColor = System.Drawing.Color.Black;
            this.authoritylevelnm2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm2.Border.RightColor = System.Drawing.Color.Black;
            this.authoritylevelnm2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm2.Border.TopColor = System.Drawing.Color.Black;
            this.authoritylevelnm2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.authoritylevelnm2.DataField = "authoritylevelnm2";
            this.authoritylevelnm2.Height = 0.15F;
            this.authoritylevelnm2.Left = 4.343751F;
            this.authoritylevelnm2.MultiLine = false;
            this.authoritylevelnm2.Name = "authoritylevelnm2";
            this.authoritylevelnm2.OutputFormat = resources.GetString("authoritylevelnm2.OutputFormat");
            this.authoritylevelnm2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.authoritylevelnm2.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.authoritylevelnm2.Top = 0.1916666F;
            this.authoritylevelnm2.Width = 1.14F;
            // 
            // belongsectioncode
            // 
            this.belongsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.belongsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.belongsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.belongsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.belongsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsectioncode.DataField = "belongsectioncode";
            this.belongsectioncode.Height = 0.15F;
            this.belongsectioncode.Left = 5.510418F;
            this.belongsectioncode.MultiLine = false;
            this.belongsectioncode.Name = "belongsectioncode";
            this.belongsectioncode.OutputFormat = resources.GetString("belongsectioncode.OutputFormat");
            this.belongsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.belongsectioncode.Text = "12";
            this.belongsectioncode.Top = 0.02083333F;
            this.belongsectioncode.Width = 0.14F;
            // 
            // belongsubsectioncode
            // 
            this.belongsubsectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.belongsubsectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsubsectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.belongsubsectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsubsectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.belongsubsectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsubsectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.belongsubsectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.belongsubsectioncode.DataField = "belongsubsectioncode";
            this.belongsubsectioncode.Height = 0.15F;
            this.belongsubsectioncode.Left = 5.510418F;
            this.belongsubsectioncode.MultiLine = false;
            this.belongsubsectioncode.Name = "belongsubsectioncode";
            this.belongsubsectioncode.OutputFormat = resources.GetString("belongsubsectioncode.OutputFormat");
            this.belongsubsectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.belongsubsectioncode.Text = "12";
            this.belongsubsectioncode.Top = 0.1916666F;
            this.belongsubsectioncode.Width = 0.14F;
            // 
            // employanalyscode1
            // 
            this.employanalyscode1.Border.BottomColor = System.Drawing.Color.Black;
            this.employanalyscode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode1.Border.LeftColor = System.Drawing.Color.Black;
            this.employanalyscode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode1.Border.RightColor = System.Drawing.Color.Black;
            this.employanalyscode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode1.Border.TopColor = System.Drawing.Color.Black;
            this.employanalyscode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode1.DataField = "employanalyscode1";
            this.employanalyscode1.Height = 0.15F;
            this.employanalyscode1.Left = 9.625F;
            this.employanalyscode1.MultiLine = false;
            this.employanalyscode1.Name = "employanalyscode1";
            this.employanalyscode1.OutputFormat = resources.GetString("employanalyscode1.OutputFormat");
            this.employanalyscode1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employanalyscode1.Text = "1234";
            this.employanalyscode1.Top = 0.02083333F;
            this.employanalyscode1.Width = 0.25F;
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
            this.sectionguidenm.Left = 5.66667F;
            this.sectionguidenm.MultiLine = false;
            this.sectionguidenm.Name = "sectionguidenm";
            this.sectionguidenm.OutputFormat = resources.GetString("sectionguidenm.OutputFormat");
            this.sectionguidenm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sectionguidenm.Text = "あいうえおかきくけこ";
            this.sectionguidenm.Top = 0.02083333F;
            this.sectionguidenm.Width = 1.15F;
            // 
            // subsectionname
            // 
            this.subsectionname.Border.BottomColor = System.Drawing.Color.Black;
            this.subsectionname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.Border.LeftColor = System.Drawing.Color.Black;
            this.subsectionname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.Border.RightColor = System.Drawing.Color.Black;
            this.subsectionname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.Border.TopColor = System.Drawing.Color.Black;
            this.subsectionname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subsectionname.DataField = "subsectionname";
            this.subsectionname.Height = 0.15F;
            this.subsectionname.Left = 5.66667F;
            this.subsectionname.MultiLine = false;
            this.subsectionname.Name = "subsectionname";
            this.subsectionname.OutputFormat = resources.GetString("subsectionname.OutputFormat");
            this.subsectionname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.subsectionname.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.subsectionname.Top = 0.1916666F;
            this.subsectionname.Width = 2.27F;
            // 
            // sexname
            // 
            this.sexname.Border.BottomColor = System.Drawing.Color.Black;
            this.sexname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sexname.Border.LeftColor = System.Drawing.Color.Black;
            this.sexname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sexname.Border.RightColor = System.Drawing.Color.Black;
            this.sexname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sexname.Border.TopColor = System.Drawing.Color.Black;
            this.sexname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sexname.DataField = "sexname";
            this.sexname.Height = 0.15F;
            this.sexname.Left = 3.708332F;
            this.sexname.MultiLine = false;
            this.sexname.Name = "sexname";
            this.sexname.OutputFormat = resources.GetString("sexname.OutputFormat");
            this.sexname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sexname.Text = "男";
            this.sexname.Top = 0.1916666F;
            this.sexname.Width = 0.6F;
            // 
            // companytelno
            // 
            this.companytelno.Border.BottomColor = System.Drawing.Color.Black;
            this.companytelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno.Border.LeftColor = System.Drawing.Color.Black;
            this.companytelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno.Border.RightColor = System.Drawing.Color.Black;
            this.companytelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno.Border.TopColor = System.Drawing.Color.Black;
            this.companytelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno.DataField = "companytelno";
            this.companytelno.Height = 0.15F;
            this.companytelno.Left = 7.958338F;
            this.companytelno.MultiLine = false;
            this.companytelno.Name = "companytelno";
            this.companytelno.OutputFormat = resources.GetString("companytelno.OutputFormat");
            this.companytelno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companytelno.Text = "1234567890123456";
            this.companytelno.Top = 0.02083333F;
            this.companytelno.Width = 0.95F;
            // 
            // portabletelno
            // 
            this.portabletelno.Border.BottomColor = System.Drawing.Color.Black;
            this.portabletelno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.Border.LeftColor = System.Drawing.Color.Black;
            this.portabletelno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.Border.RightColor = System.Drawing.Color.Black;
            this.portabletelno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.Border.TopColor = System.Drawing.Color.Black;
            this.portabletelno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.portabletelno.DataField = "portabletelno";
            this.portabletelno.Height = 0.15F;
            this.portabletelno.Left = 7.958338F;
            this.portabletelno.MultiLine = false;
            this.portabletelno.Name = "portabletelno";
            this.portabletelno.OutputFormat = resources.GetString("portabletelno.OutputFormat");
            this.portabletelno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.portabletelno.Text = "1234567890123456";
            this.portabletelno.Top = 0.1916666F;
            this.portabletelno.Width = 0.95F;
            // 
            // entercompanydate
            // 
            this.entercompanydate.Border.BottomColor = System.Drawing.Color.Black;
            this.entercompanydate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.entercompanydate.Border.LeftColor = System.Drawing.Color.Black;
            this.entercompanydate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.entercompanydate.Border.RightColor = System.Drawing.Color.Black;
            this.entercompanydate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.entercompanydate.Border.TopColor = System.Drawing.Color.Black;
            this.entercompanydate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.entercompanydate.DataField = "entercompanydate";
            this.entercompanydate.Height = 0.15F;
            this.entercompanydate.Left = 8.927085F;
            this.entercompanydate.MultiLine = false;
            this.entercompanydate.Name = "entercompanydate";
            this.entercompanydate.OutputFormat = resources.GetString("entercompanydate.OutputFormat");
            this.entercompanydate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.entercompanydate.Text = "9999/99/99";
            this.entercompanydate.Top = 0.02083333F;
            this.entercompanydate.Width = 0.6F;
            // 
            // retirementdate
            // 
            this.retirementdate.Border.BottomColor = System.Drawing.Color.Black;
            this.retirementdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.retirementdate.Border.LeftColor = System.Drawing.Color.Black;
            this.retirementdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.retirementdate.Border.RightColor = System.Drawing.Color.Black;
            this.retirementdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.retirementdate.Border.TopColor = System.Drawing.Color.Black;
            this.retirementdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.retirementdate.DataField = "retirementdate";
            this.retirementdate.Height = 0.15F;
            this.retirementdate.Left = 8.927085F;
            this.retirementdate.MultiLine = false;
            this.retirementdate.Name = "retirementdate";
            this.retirementdate.OutputFormat = resources.GetString("retirementdate.OutputFormat");
            this.retirementdate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.retirementdate.Text = "9999/99/99";
            this.retirementdate.Top = 0.1916666F;
            this.retirementdate.Width = 0.6F;
            // 
            // employanalyscode4
            // 
            this.employanalyscode4.Border.BottomColor = System.Drawing.Color.Black;
            this.employanalyscode4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode4.Border.LeftColor = System.Drawing.Color.Black;
            this.employanalyscode4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode4.Border.RightColor = System.Drawing.Color.Black;
            this.employanalyscode4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode4.Border.TopColor = System.Drawing.Color.Black;
            this.employanalyscode4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode4.DataField = "employanalyscode4";
            this.employanalyscode4.Height = 0.15F;
            this.employanalyscode4.Left = 9.625F;
            this.employanalyscode4.MultiLine = false;
            this.employanalyscode4.Name = "employanalyscode4";
            this.employanalyscode4.OutputFormat = resources.GetString("employanalyscode4.OutputFormat");
            this.employanalyscode4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employanalyscode4.Text = "1234";
            this.employanalyscode4.Top = 0.1916666F;
            this.employanalyscode4.Width = 0.25F;
            // 
            // employanalyscode2
            // 
            this.employanalyscode2.Border.BottomColor = System.Drawing.Color.Black;
            this.employanalyscode2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode2.Border.LeftColor = System.Drawing.Color.Black;
            this.employanalyscode2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode2.Border.RightColor = System.Drawing.Color.Black;
            this.employanalyscode2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode2.Border.TopColor = System.Drawing.Color.Black;
            this.employanalyscode2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode2.DataField = "employanalyscode2";
            this.employanalyscode2.Height = 0.15F;
            this.employanalyscode2.Left = 10F;
            this.employanalyscode2.MultiLine = false;
            this.employanalyscode2.Name = "employanalyscode2";
            this.employanalyscode2.OutputFormat = resources.GetString("employanalyscode2.OutputFormat");
            this.employanalyscode2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employanalyscode2.Text = "1234";
            this.employanalyscode2.Top = 0.02083333F;
            this.employanalyscode2.Width = 0.25F;
            // 
            // employanalyscode5
            // 
            this.employanalyscode5.Border.BottomColor = System.Drawing.Color.Black;
            this.employanalyscode5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode5.Border.LeftColor = System.Drawing.Color.Black;
            this.employanalyscode5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode5.Border.RightColor = System.Drawing.Color.Black;
            this.employanalyscode5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode5.Border.TopColor = System.Drawing.Color.Black;
            this.employanalyscode5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode5.DataField = "employanalyscode5";
            this.employanalyscode5.Height = 0.15F;
            this.employanalyscode5.Left = 10F;
            this.employanalyscode5.MultiLine = false;
            this.employanalyscode5.Name = "employanalyscode5";
            this.employanalyscode5.OutputFormat = resources.GetString("employanalyscode5.OutputFormat");
            this.employanalyscode5.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employanalyscode5.Text = "1234";
            this.employanalyscode5.Top = 0.1916666F;
            this.employanalyscode5.Width = 0.25F;
            // 
            // employanalyscode3
            // 
            this.employanalyscode3.Border.BottomColor = System.Drawing.Color.Black;
            this.employanalyscode3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode3.Border.LeftColor = System.Drawing.Color.Black;
            this.employanalyscode3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode3.Border.RightColor = System.Drawing.Color.Black;
            this.employanalyscode3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode3.Border.TopColor = System.Drawing.Color.Black;
            this.employanalyscode3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode3.DataField = "employanalyscode3";
            this.employanalyscode3.Height = 0.15F;
            this.employanalyscode3.Left = 10.375F;
            this.employanalyscode3.MultiLine = false;
            this.employanalyscode3.Name = "employanalyscode3";
            this.employanalyscode3.OutputFormat = resources.GetString("employanalyscode3.OutputFormat");
            this.employanalyscode3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employanalyscode3.Text = "1234";
            this.employanalyscode3.Top = 0.02083333F;
            this.employanalyscode3.Width = 0.25F;
            // 
            // employanalyscode6
            // 
            this.employanalyscode6.Border.BottomColor = System.Drawing.Color.Black;
            this.employanalyscode6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode6.Border.LeftColor = System.Drawing.Color.Black;
            this.employanalyscode6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode6.Border.RightColor = System.Drawing.Color.Black;
            this.employanalyscode6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode6.Border.TopColor = System.Drawing.Color.Black;
            this.employanalyscode6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employanalyscode6.DataField = "employanalyscode6";
            this.employanalyscode6.Height = 0.15F;
            this.employanalyscode6.Left = 10.375F;
            this.employanalyscode6.MultiLine = false;
            this.employanalyscode6.Name = "employanalyscode6";
            this.employanalyscode6.OutputFormat = resources.GetString("employanalyscode6.OutputFormat");
            this.employanalyscode6.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employanalyscode6.Text = "1234";
            this.employanalyscode6.Top = 0.1916666F;
            this.employanalyscode6.Width = 0.25F;
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
            this.tb_ReportTitle.Text = "従業員マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3125F;
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
            this.label4,
            this.label5,
            this.line2,
            this.label8,
            this.lblcompanytelno1,
            this.lblcompanytelno2,
            this.label13,
            this.label14,
            this.label15,
            this.label17,
            this.label18,
            this.label6,
            this.label7,
            this.label9,
            this.label10,
            this.label11});
            this.TitleHeader.Height = 0.4361979F;
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
            this.label1.Text = "ｺｰﾄﾞ";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.3125F;
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
            this.label4.Left = 0.3125F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "名称";
            this.label4.Top = 0.06250001F;
            this.label4.Width = 1.14F;
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
            this.label5.Left = 0.3125F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label5.Text = "ｶﾅ";
            this.label5.Top = 0.2395834F;
            this.label5.Width = 3.37F;
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
            this.line2.Top = 0.40625F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.40625F;
            this.line2.Y2 = 0.40625F;
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
            this.label8.Height = 0.15F;
            this.label8.HyperLink = "";
            this.label8.Left = 1.510417F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "略称";
            this.label8.Top = 0.0625F;
            this.label8.Width = 1.14F;
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
            this.lblcompanytelno1.Left = 3.708332F;
            this.lblcompanytelno1.MultiLine = false;
            this.lblcompanytelno1.Name = "lblcompanytelno1";
            this.lblcompanytelno1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno1.Text = "性別";
            this.lblcompanytelno1.Top = 0.2395834F;
            this.lblcompanytelno1.Width = 0.6F;
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
            this.lblcompanytelno2.Left = 3.708332F;
            this.lblcompanytelno2.MultiLine = false;
            this.lblcompanytelno2.Name = "lblcompanytelno2";
            this.lblcompanytelno2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno2.Text = "生年月日";
            this.lblcompanytelno2.Top = 0.0625F;
            this.lblcompanytelno2.Width = 0.6F;
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
            this.label13.Left = 4.343751F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "ロール（業務）";
            this.label13.Top = 0.0625F;
            this.label13.Width = 1.14F;
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
            this.label14.Left = 5.510418F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "所属拠点";
            this.label14.Top = 0.0625F;
            this.label14.Width = 2.27F;
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
            this.label15.Height = 0.15F;
            this.label15.HyperLink = "";
            this.label15.Left = 5.510418F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "所属部門";
            this.label15.Top = 0.2395834F;
            this.label15.Width = 2.27F;
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
            this.label17.Left = 9.625F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "分析コード１～３";
            this.label17.Top = 0.0625F;
            this.label17.Width = 1F;
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
            this.label18.Left = 9.625F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "分析コード４～６";
            this.label18.Top = 0.2395834F;
            this.label18.Width = 1F;
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
            this.label6.Left = 4.343751F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "ロール（権限）";
            this.label6.Top = 0.2395834F;
            this.label6.Width = 1.14F;
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
            this.label7.Left = 7.958338F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "電話番号（会社）";
            this.label7.Top = 0.0625F;
            this.label7.Width = 0.95F;
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
            this.label9.Height = 0.15F;
            this.label9.HyperLink = "";
            this.label9.Left = 7.958338F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "電話番号（携帯）";
            this.label9.Top = 0.2395834F;
            this.label9.Width = 0.95F;
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
            this.label10.Height = 0.15F;
            this.label10.HyperLink = "";
            this.label10.Left = 8.927085F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "入社日";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.6F;
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
            this.label11.Height = 0.15F;
            this.label11.HyperLink = "";
            this.label11.Left = 8.927085F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label11.Text = "退社日";
            this.label11.Top = 0.2395834F;
            this.label11.Width = 0.6F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08525P_01A4C
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
            this.PageEnd += new System.EventHandler(this.PMKHN08525P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08525P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.kana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authoritylevelnm1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.authoritylevelnm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.belongsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.belongsubsectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidenm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsectionname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portabletelno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entercompanydate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.retirementdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employanalyscode6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
