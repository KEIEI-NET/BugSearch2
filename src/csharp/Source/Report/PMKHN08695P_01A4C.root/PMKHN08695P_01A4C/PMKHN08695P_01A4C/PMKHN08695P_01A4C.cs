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
	/// 拠点情報マスタ（印刷）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 拠点情報マスタ（印刷）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
    /// <br>UpdateNote  : 2008/11/27 30462 行澤仁美　バグ修正 [8297]ガイド名称のDataField修正</br>
	/// </remarks>
	public class PMKHN08695P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 拠点情報マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 拠点情報マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08695P_01A4C()
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

        private SectionPrintWork    _sectionPrintWork;                   // 抽出条件クラス
        
		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Label label1;
        private Label label4;
        private Label label5;
        private TextBox sectioncode;
        private TextBox companytelno1;
        private TextBox companyname1;
        private Line line2;
        private Line line3;
        private Label label6;
        private TextBox sectionguidesnm;
        private TextBox companysetnote1;
        private TextBox sectionguidenm;
        private TextBox companyname2;
        private Label label7;
        private Label label8;
        private TextBox companytelno2;
        private TextBox companytelno3;
        private TextBox companysetnote2;
        private Label label9;
        private Label lblcompanytelno1;
        private Label lblcompanytelno2;
        private Label lblcompanytelno3;
        private Label label13;
        private TextBox postno;
        private TextBox address1;
        private TextBox address3;
        private TextBox address4;
        private TextBox sectwarehousecd1;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox sectwarehousecd2;
        private TextBox sectwarehousecd3;
        private TextBox warehousename1;
        private TextBox warehousename2;
        private TextBox warehousename3;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox companyteltitle1;
        private TextBox companyteltitle2;
        private TextBox companyteltitle3;

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
                this._sectionPrintWork = (SectionPrintWork)this._printInfo.jyoken;
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
				// TODO:  PMKHN08695P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08695P_01A4C.WatermarkMode setter 実装を追加します。
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

		#region ◎ PMKHN08695P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08695P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08695P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08695P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08695P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08695P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08695P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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

            // 電話タイトル設定
            this.lblcompanytelno1.Text = "（" + this.companyteltitle1.Value + "）";
            this.lblcompanytelno2.Text = "（" + this.companyteltitle2.Value + "）";
            this.lblcompanytelno3.Text = "（" + this.companyteltitle3.Value + "）";

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08695P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.sectioncode = new DataDynamics.ActiveReports.TextBox();
            this.companytelno1 = new DataDynamics.ActiveReports.TextBox();
            this.companyname1 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.sectionguidesnm = new DataDynamics.ActiveReports.TextBox();
            this.companysetnote1 = new DataDynamics.ActiveReports.TextBox();
            this.sectionguidenm = new DataDynamics.ActiveReports.TextBox();
            this.companyname2 = new DataDynamics.ActiveReports.TextBox();
            this.companytelno2 = new DataDynamics.ActiveReports.TextBox();
            this.companytelno3 = new DataDynamics.ActiveReports.TextBox();
            this.companysetnote2 = new DataDynamics.ActiveReports.TextBox();
            this.postno = new DataDynamics.ActiveReports.TextBox();
            this.address1 = new DataDynamics.ActiveReports.TextBox();
            this.address3 = new DataDynamics.ActiveReports.TextBox();
            this.address4 = new DataDynamics.ActiveReports.TextBox();
            this.sectwarehousecd1 = new DataDynamics.ActiveReports.TextBox();
            this.sectwarehousecd2 = new DataDynamics.ActiveReports.TextBox();
            this.sectwarehousecd3 = new DataDynamics.ActiveReports.TextBox();
            this.warehousename1 = new DataDynamics.ActiveReports.TextBox();
            this.warehousename2 = new DataDynamics.ActiveReports.TextBox();
            this.warehousename3 = new DataDynamics.ActiveReports.TextBox();
            this.companyteltitle1 = new DataDynamics.ActiveReports.TextBox();
            this.companyteltitle2 = new DataDynamics.ActiveReports.TextBox();
            this.companyteltitle3 = new DataDynamics.ActiveReports.TextBox();
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
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno1 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno2 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno3 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.sectioncode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyname1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidesnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companysetnote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidenm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyname2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companysetnote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectwarehousecd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectwarehousecd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectwarehousecd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousename1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousename2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousename3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyteltitle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyteltitle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyteltitle3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.sectioncode,
            this.companytelno1,
            this.companyname1,
            this.line3,
            this.sectionguidesnm,
            this.companysetnote1,
            this.sectionguidenm,
            this.companyname2,
            this.companytelno2,
            this.companytelno3,
            this.companysetnote2,
            this.postno,
            this.address1,
            this.address3,
            this.address4,
            this.sectwarehousecd1,
            this.sectwarehousecd2,
            this.sectwarehousecd3,
            this.warehousename1,
            this.warehousename2,
            this.warehousename3,
            this.companyteltitle1,
            this.companyteltitle2,
            this.companyteltitle3});
            this.Detail.Height = 0.7083333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // sectioncode
            // 
            this.sectioncode.Border.BottomColor = System.Drawing.Color.Black;
            this.sectioncode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.Border.LeftColor = System.Drawing.Color.Black;
            this.sectioncode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.Border.RightColor = System.Drawing.Color.Black;
            this.sectioncode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.Border.TopColor = System.Drawing.Color.Black;
            this.sectioncode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectioncode.DataField = "sectioncode";
            this.sectioncode.Height = 0.15F;
            this.sectioncode.Left = 0F;
            this.sectioncode.MultiLine = false;
            this.sectioncode.Name = "sectioncode";
            this.sectioncode.OutputFormat = resources.GetString("sectioncode.OutputFormat");
            this.sectioncode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.sectioncode.Text = "1234";
            this.sectioncode.Top = 0.02083333F;
            this.sectioncode.Width = 0.3125F;
            // 
            // companytelno1
            // 
            this.companytelno1.Border.BottomColor = System.Drawing.Color.Black;
            this.companytelno1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno1.Border.LeftColor = System.Drawing.Color.Black;
            this.companytelno1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno1.Border.RightColor = System.Drawing.Color.Black;
            this.companytelno1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno1.Border.TopColor = System.Drawing.Color.Black;
            this.companytelno1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno1.DataField = "companytelno1";
            this.companytelno1.Height = 0.15F;
            this.companytelno1.Left = 2.5625F;
            this.companytelno1.MultiLine = false;
            this.companytelno1.Name = "companytelno1";
            this.companytelno1.OutputFormat = resources.GetString("companytelno1.OutputFormat");
            this.companytelno1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companytelno1.Text = "1234567890123456";
            this.companytelno1.Top = 0.1875F;
            this.companytelno1.Width = 0.95F;
            // 
            // companyname1
            // 
            this.companyname1.Border.BottomColor = System.Drawing.Color.Black;
            this.companyname1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname1.Border.LeftColor = System.Drawing.Color.Black;
            this.companyname1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname1.Border.RightColor = System.Drawing.Color.Black;
            this.companyname1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname1.Border.TopColor = System.Drawing.Color.Black;
            this.companyname1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname1.DataField = "companyname1";
            this.companyname1.Height = 0.15F;
            this.companyname1.Left = 0.3125F;
            this.companyname1.MultiLine = false;
            this.companyname1.Name = "companyname1";
            this.companyname1.OutputFormat = resources.GetString("companyname1.OutputFormat");
            this.companyname1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companyname1.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.companyname1.Top = 0.02083333F;
            this.companyname1.Width = 2.25F;
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
            this.line3.Top = 0.5104167F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.5104167F;
            this.line3.Y2 = 0.5104167F;
            // 
            // sectionguidesnm
            // 
            this.sectionguidesnm.Border.BottomColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.Border.LeftColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.Border.RightColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.Border.TopColor = System.Drawing.Color.Black;
            this.sectionguidesnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionguidesnm.DataField = "sectionguidesnm";
            this.sectionguidesnm.Height = 0.15F;
            this.sectionguidesnm.Left = 0.3125F;
            this.sectionguidesnm.MultiLine = false;
            this.sectionguidesnm.Name = "sectionguidesnm";
            this.sectionguidesnm.OutputFormat = resources.GetString("sectionguidesnm.OutputFormat");
            this.sectionguidesnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sectionguidesnm.Text = "あいうえおかきくけこ";
            this.sectionguidesnm.Top = 0.1916666F;
            this.sectionguidesnm.Width = 1.14F;
            // 
            // companysetnote1
            // 
            this.companysetnote1.Border.BottomColor = System.Drawing.Color.Black;
            this.companysetnote1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote1.Border.LeftColor = System.Drawing.Color.Black;
            this.companysetnote1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote1.Border.RightColor = System.Drawing.Color.Black;
            this.companysetnote1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote1.Border.TopColor = System.Drawing.Color.Black;
            this.companysetnote1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote1.DataField = "companysetnote1";
            this.companysetnote1.Height = 0.15F;
            this.companysetnote1.Left = 0.3125F;
            this.companysetnote1.MultiLine = false;
            this.companysetnote1.Name = "companysetnote1";
            this.companysetnote1.OutputFormat = resources.GetString("companysetnote1.OutputFormat");
            this.companysetnote1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companysetnote1.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.companysetnote1.Top = 0.3520833F;
            this.companysetnote1.Width = 2.25F;
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
            this.sectionguidenm.Left = 1.4225F;
            this.sectionguidenm.MultiLine = false;
            this.sectionguidenm.Name = "sectionguidenm";
            this.sectionguidenm.OutputFormat = resources.GetString("sectionguidenm.OutputFormat");
            this.sectionguidenm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.sectionguidenm.Text = "あいうえおかきくけこ";
            this.sectionguidenm.Top = 0.1875F;
            this.sectionguidenm.Width = 1.14F;
            // 
            // companyname2
            // 
            this.companyname2.Border.BottomColor = System.Drawing.Color.Black;
            this.companyname2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname2.Border.LeftColor = System.Drawing.Color.Black;
            this.companyname2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname2.Border.RightColor = System.Drawing.Color.Black;
            this.companyname2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname2.Border.TopColor = System.Drawing.Color.Black;
            this.companyname2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyname2.DataField = "companyname2";
            this.companyname2.Height = 0.15F;
            this.companyname2.Left = 2.5625F;
            this.companyname2.MultiLine = false;
            this.companyname2.Name = "companyname2";
            this.companyname2.OutputFormat = resources.GetString("companyname2.OutputFormat");
            this.companyname2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companyname2.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.companyname2.Top = 0.02083333F;
            this.companyname2.Width = 2.25F;
            // 
            // companytelno2
            // 
            this.companytelno2.Border.BottomColor = System.Drawing.Color.Black;
            this.companytelno2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno2.Border.LeftColor = System.Drawing.Color.Black;
            this.companytelno2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno2.Border.RightColor = System.Drawing.Color.Black;
            this.companytelno2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno2.Border.TopColor = System.Drawing.Color.Black;
            this.companytelno2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno2.DataField = "companytelno2";
            this.companytelno2.Height = 0.15F;
            this.companytelno2.Left = 3.5F;
            this.companytelno2.MultiLine = false;
            this.companytelno2.Name = "companytelno2";
            this.companytelno2.OutputFormat = resources.GetString("companytelno2.OutputFormat");
            this.companytelno2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companytelno2.Text = "1234567890123456";
            this.companytelno2.Top = 0.1875F;
            this.companytelno2.Width = 0.95F;
            // 
            // companytelno3
            // 
            this.companytelno3.Border.BottomColor = System.Drawing.Color.Black;
            this.companytelno3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno3.Border.LeftColor = System.Drawing.Color.Black;
            this.companytelno3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno3.Border.RightColor = System.Drawing.Color.Black;
            this.companytelno3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno3.Border.TopColor = System.Drawing.Color.Black;
            this.companytelno3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companytelno3.DataField = "companytelno3";
            this.companytelno3.Height = 0.15F;
            this.companytelno3.Left = 4.4375F;
            this.companytelno3.MultiLine = false;
            this.companytelno3.Name = "companytelno3";
            this.companytelno3.OutputFormat = resources.GetString("companytelno3.OutputFormat");
            this.companytelno3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companytelno3.Text = "1234567890123456";
            this.companytelno3.Top = 0.1875F;
            this.companytelno3.Width = 0.95F;
            // 
            // companysetnote2
            // 
            this.companysetnote2.Border.BottomColor = System.Drawing.Color.Black;
            this.companysetnote2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote2.Border.LeftColor = System.Drawing.Color.Black;
            this.companysetnote2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote2.Border.RightColor = System.Drawing.Color.Black;
            this.companysetnote2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote2.Border.TopColor = System.Drawing.Color.Black;
            this.companysetnote2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companysetnote2.DataField = "companysetnote2";
            this.companysetnote2.Height = 0.15F;
            this.companysetnote2.Left = 2.5625F;
            this.companysetnote2.MultiLine = false;
            this.companysetnote2.Name = "companysetnote2";
            this.companysetnote2.OutputFormat = resources.GetString("companysetnote2.OutputFormat");
            this.companysetnote2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.companysetnote2.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.companysetnote2.Top = 0.3520833F;
            this.companysetnote2.Width = 2.25F;
            // 
            // postno
            // 
            this.postno.Border.BottomColor = System.Drawing.Color.Black;
            this.postno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.Border.LeftColor = System.Drawing.Color.Black;
            this.postno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.Border.RightColor = System.Drawing.Color.Black;
            this.postno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.Border.TopColor = System.Drawing.Color.Black;
            this.postno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.postno.DataField = "postno";
            this.postno.Height = 0.15F;
            this.postno.Left = 5.395832F;
            this.postno.MultiLine = false;
            this.postno.Name = "postno";
            this.postno.OutputFormat = resources.GetString("postno.OutputFormat");
            this.postno.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.postno.Text = "1234567890";
            this.postno.Top = 0.02083333F;
            this.postno.Width = 0.6F;
            // 
            // address1
            // 
            this.address1.Border.BottomColor = System.Drawing.Color.Black;
            this.address1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.Border.LeftColor = System.Drawing.Color.Black;
            this.address1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.Border.RightColor = System.Drawing.Color.Black;
            this.address1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.Border.TopColor = System.Drawing.Color.Black;
            this.address1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address1.DataField = "address1";
            this.address1.Height = 0.15F;
            this.address1.Left = 6F;
            this.address1.MultiLine = false;
            this.address1.Name = "address1";
            this.address1.OutputFormat = resources.GetString("address1.OutputFormat");
            this.address1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.address1.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.address1.Top = 0.02083333F;
            this.address1.Width = 3.37F;
            // 
            // address3
            // 
            this.address3.Border.BottomColor = System.Drawing.Color.Black;
            this.address3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.Border.LeftColor = System.Drawing.Color.Black;
            this.address3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.Border.RightColor = System.Drawing.Color.Black;
            this.address3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.Border.TopColor = System.Drawing.Color.Black;
            this.address3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address3.DataField = "address3";
            this.address3.Height = 0.15F;
            this.address3.Left = 6F;
            this.address3.MultiLine = false;
            this.address3.Name = "address3";
            this.address3.OutputFormat = resources.GetString("address3.OutputFormat");
            this.address3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.address3.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.address3.Top = 0.1875F;
            this.address3.Width = 3.37F;
            // 
            // address4
            // 
            this.address4.Border.BottomColor = System.Drawing.Color.Black;
            this.address4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.Border.LeftColor = System.Drawing.Color.Black;
            this.address4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.Border.RightColor = System.Drawing.Color.Black;
            this.address4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.Border.TopColor = System.Drawing.Color.Black;
            this.address4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.address4.DataField = "address4";
            this.address4.Height = 0.15F;
            this.address4.Left = 6F;
            this.address4.MultiLine = false;
            this.address4.Name = "address4";
            this.address4.OutputFormat = resources.GetString("address4.OutputFormat");
            this.address4.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.address4.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.address4.Top = 0.3520833F;
            this.address4.Width = 3.37F;
            // 
            // sectwarehousecd1
            // 
            this.sectwarehousecd1.Border.BottomColor = System.Drawing.Color.Black;
            this.sectwarehousecd1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd1.Border.LeftColor = System.Drawing.Color.Black;
            this.sectwarehousecd1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd1.Border.RightColor = System.Drawing.Color.Black;
            this.sectwarehousecd1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd1.Border.TopColor = System.Drawing.Color.Black;
            this.sectwarehousecd1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd1.DataField = "sectwarehousecd1";
            this.sectwarehousecd1.Height = 0.15F;
            this.sectwarehousecd1.Left = 9.375F;
            this.sectwarehousecd1.MultiLine = false;
            this.sectwarehousecd1.Name = "sectwarehousecd1";
            this.sectwarehousecd1.OutputFormat = resources.GetString("sectwarehousecd1.OutputFormat");
            this.sectwarehousecd1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.sectwarehousecd1.Text = "1234";
            this.sectwarehousecd1.Top = 0.02083333F;
            this.sectwarehousecd1.Width = 0.25F;
            // 
            // sectwarehousecd2
            // 
            this.sectwarehousecd2.Border.BottomColor = System.Drawing.Color.Black;
            this.sectwarehousecd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd2.Border.LeftColor = System.Drawing.Color.Black;
            this.sectwarehousecd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd2.Border.RightColor = System.Drawing.Color.Black;
            this.sectwarehousecd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd2.Border.TopColor = System.Drawing.Color.Black;
            this.sectwarehousecd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd2.DataField = "sectwarehousecd2";
            this.sectwarehousecd2.Height = 0.15F;
            this.sectwarehousecd2.Left = 9.375F;
            this.sectwarehousecd2.MultiLine = false;
            this.sectwarehousecd2.Name = "sectwarehousecd2";
            this.sectwarehousecd2.OutputFormat = resources.GetString("sectwarehousecd2.OutputFormat");
            this.sectwarehousecd2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.sectwarehousecd2.Text = "1234";
            this.sectwarehousecd2.Top = 0.1875F;
            this.sectwarehousecd2.Width = 0.25F;
            // 
            // sectwarehousecd3
            // 
            this.sectwarehousecd3.Border.BottomColor = System.Drawing.Color.Black;
            this.sectwarehousecd3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd3.Border.LeftColor = System.Drawing.Color.Black;
            this.sectwarehousecd3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd3.Border.RightColor = System.Drawing.Color.Black;
            this.sectwarehousecd3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd3.Border.TopColor = System.Drawing.Color.Black;
            this.sectwarehousecd3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectwarehousecd3.DataField = "sectwarehousecd3";
            this.sectwarehousecd3.Height = 0.15F;
            this.sectwarehousecd3.Left = 9.375F;
            this.sectwarehousecd3.MultiLine = false;
            this.sectwarehousecd3.Name = "sectwarehousecd3";
            this.sectwarehousecd3.OutputFormat = resources.GetString("sectwarehousecd3.OutputFormat");
            this.sectwarehousecd3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.sectwarehousecd3.Text = "1234";
            this.sectwarehousecd3.Top = 0.3520833F;
            this.sectwarehousecd3.Width = 0.25F;
            // 
            // warehousename1
            // 
            this.warehousename1.Border.BottomColor = System.Drawing.Color.Black;
            this.warehousename1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename1.Border.LeftColor = System.Drawing.Color.Black;
            this.warehousename1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename1.Border.RightColor = System.Drawing.Color.Black;
            this.warehousename1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename1.Border.TopColor = System.Drawing.Color.Black;
            this.warehousename1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename1.DataField = "warehousename1";
            this.warehousename1.Height = 0.15F;
            this.warehousename1.Left = 9.625F;
            this.warehousename1.MultiLine = false;
            this.warehousename1.Name = "warehousename1";
            this.warehousename1.OutputFormat = resources.GetString("warehousename1.OutputFormat");
            this.warehousename1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.warehousename1.Text = "あいうえおかきくけこ";
            this.warehousename1.Top = 0.02083333F;
            this.warehousename1.Width = 1.15F;
            // 
            // warehousename2
            // 
            this.warehousename2.Border.BottomColor = System.Drawing.Color.Black;
            this.warehousename2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename2.Border.LeftColor = System.Drawing.Color.Black;
            this.warehousename2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename2.Border.RightColor = System.Drawing.Color.Black;
            this.warehousename2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename2.Border.TopColor = System.Drawing.Color.Black;
            this.warehousename2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename2.DataField = "warehousename2";
            this.warehousename2.Height = 0.15F;
            this.warehousename2.Left = 9.625F;
            this.warehousename2.MultiLine = false;
            this.warehousename2.Name = "warehousename2";
            this.warehousename2.OutputFormat = resources.GetString("warehousename2.OutputFormat");
            this.warehousename2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.warehousename2.Text = "あいうえおかきくけこ";
            this.warehousename2.Top = 0.1875F;
            this.warehousename2.Width = 1.15F;
            // 
            // warehousename3
            // 
            this.warehousename3.Border.BottomColor = System.Drawing.Color.Black;
            this.warehousename3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename3.Border.LeftColor = System.Drawing.Color.Black;
            this.warehousename3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename3.Border.RightColor = System.Drawing.Color.Black;
            this.warehousename3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename3.Border.TopColor = System.Drawing.Color.Black;
            this.warehousename3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.warehousename3.DataField = "warehousename3";
            this.warehousename3.Height = 0.15F;
            this.warehousename3.Left = 9.625F;
            this.warehousename3.MultiLine = false;
            this.warehousename3.Name = "warehousename3";
            this.warehousename3.OutputFormat = resources.GetString("warehousename3.OutputFormat");
            this.warehousename3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.warehousename3.Text = "あいうえおかきくけこ";
            this.warehousename3.Top = 0.3520833F;
            this.warehousename3.Width = 1.15F;
            // 
            // companyteltitle1
            // 
            this.companyteltitle1.Border.BottomColor = System.Drawing.Color.Black;
            this.companyteltitle1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle1.Border.LeftColor = System.Drawing.Color.Black;
            this.companyteltitle1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle1.Border.RightColor = System.Drawing.Color.Black;
            this.companyteltitle1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle1.Border.TopColor = System.Drawing.Color.Black;
            this.companyteltitle1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle1.DataField = "companyteltitle1";
            this.companyteltitle1.Height = 0.15F;
            this.companyteltitle1.Left = 3.125F;
            this.companyteltitle1.MultiLine = false;
            this.companyteltitle1.Name = "companyteltitle1";
            this.companyteltitle1.OutputFormat = resources.GetString("companyteltitle1.OutputFormat");
            this.companyteltitle1.Style = "ddo-char-set: 128; text-align: left; background-color: #FF8080; font-size: 8pt; f" +
                "ont-family: ＭＳ 明朝; vertical-align: top; ";
            this.companyteltitle1.Text = "1234567890123456";
            this.companyteltitle1.Top = 0.5625F;
            this.companyteltitle1.Visible = false;
            this.companyteltitle1.Width = 0.95F;
            // 
            // companyteltitle2
            // 
            this.companyteltitle2.Border.BottomColor = System.Drawing.Color.Black;
            this.companyteltitle2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle2.Border.LeftColor = System.Drawing.Color.Black;
            this.companyteltitle2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle2.Border.RightColor = System.Drawing.Color.Black;
            this.companyteltitle2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle2.Border.TopColor = System.Drawing.Color.Black;
            this.companyteltitle2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle2.DataField = "companyteltitle2";
            this.companyteltitle2.Height = 0.15F;
            this.companyteltitle2.Left = 4.0625F;
            this.companyteltitle2.MultiLine = false;
            this.companyteltitle2.Name = "companyteltitle2";
            this.companyteltitle2.OutputFormat = resources.GetString("companyteltitle2.OutputFormat");
            this.companyteltitle2.Style = "ddo-char-set: 128; text-align: left; background-color: #FF8080; font-size: 8pt; f" +
                "ont-family: ＭＳ 明朝; vertical-align: top; ";
            this.companyteltitle2.Text = "1234567890123456";
            this.companyteltitle2.Top = 0.5625F;
            this.companyteltitle2.Visible = false;
            this.companyteltitle2.Width = 0.95F;
            // 
            // companyteltitle3
            // 
            this.companyteltitle3.Border.BottomColor = System.Drawing.Color.Black;
            this.companyteltitle3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle3.Border.LeftColor = System.Drawing.Color.Black;
            this.companyteltitle3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle3.Border.RightColor = System.Drawing.Color.Black;
            this.companyteltitle3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle3.Border.TopColor = System.Drawing.Color.Black;
            this.companyteltitle3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.companyteltitle3.DataField = "companyteltitle3";
            this.companyteltitle3.Height = 0.15F;
            this.companyteltitle3.Left = 5F;
            this.companyteltitle3.MultiLine = false;
            this.companyteltitle3.Name = "companyteltitle3";
            this.companyteltitle3.OutputFormat = resources.GetString("companyteltitle3.OutputFormat");
            this.companyteltitle3.Style = "ddo-char-set: 128; text-align: left; background-color: #FF8080; font-size: 8pt; f" +
                "ont-family: ＭＳ 明朝; vertical-align: top; ";
            this.companyteltitle3.Text = "1234567890123456";
            this.companyteltitle3.Top = 0.5625F;
            this.companyteltitle3.Visible = false;
            this.companyteltitle3.Width = 0.95F;
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
            this.tb_ReportTitle.Text = "拠点情報マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.28125F;
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
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.lblcompanytelno1,
            this.lblcompanytelno2,
            this.lblcompanytelno3,
            this.label13,
            this.label14,
            this.label15,
            this.label16,
            this.label17,
            this.label18,
            this.label19});
            this.TitleHeader.Height = 0.6375F;
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
            this.label4.Text = "名称１";
            this.label4.Top = 0.06250001F;
            this.label4.Width = 2.25F;
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
            this.label5.Text = "略称";
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
            this.line2.Top = 0.5729167F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.5729167F;
            this.line2.Y2 = 0.5729167F;
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
            this.label6.Left = 0.3125F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label6.Text = "備考１";
            this.label6.Top = 0.4208334F;
            this.label6.Width = 2.25F;
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
            this.label7.Left = 1.4225F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "ガイド名称";
            this.label7.Top = 0.2395834F;
            this.label7.Width = 1.14F;
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
            this.label8.Left = 2.5625F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "名称２";
            this.label8.Top = 0.0625F;
            this.label8.Width = 2.25F;
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
            this.label9.Left = 2.5625F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label9.Text = "備考２";
            this.label9.Top = 0.4208334F;
            this.label9.Width = 2.25F;
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
            this.lblcompanytelno1.Left = 2.5625F;
            this.lblcompanytelno1.MultiLine = false;
            this.lblcompanytelno1.Name = "lblcompanytelno1";
            this.lblcompanytelno1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno1.Text = "（電話番号１）";
            this.lblcompanytelno1.Top = 0.2395834F;
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
            this.lblcompanytelno2.Left = 3.5F;
            this.lblcompanytelno2.MultiLine = false;
            this.lblcompanytelno2.Name = "lblcompanytelno2";
            this.lblcompanytelno2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno2.Text = "（電話番号２）";
            this.lblcompanytelno2.Top = 0.2395834F;
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
            this.lblcompanytelno3.Left = 4.4375F;
            this.lblcompanytelno3.MultiLine = false;
            this.lblcompanytelno3.Name = "lblcompanytelno3";
            this.lblcompanytelno3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno3.Text = "（電話番号３）";
            this.lblcompanytelno3.Top = 0.2395834F;
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
            this.label13.Left = 5.395832F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "郵便番号";
            this.label13.Top = 0.0625F;
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
            this.label14.Left = 6F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "住所１";
            this.label14.Top = 0.0625F;
            this.label14.Width = 3.37F;
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
            this.label15.Left = 6F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label15.Text = "住所２";
            this.label15.Top = 0.2395834F;
            this.label15.Width = 3.37F;
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
            this.label16.Left = 6F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "住所３";
            this.label16.Top = 0.4208334F;
            this.label16.Width = 3.37F;
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
            this.label17.Left = 9.375F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label17.Text = "拠点倉庫１";
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
            this.label18.Left = 9.375F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label18.Text = "拠点倉庫２";
            this.label18.Top = 0.2395834F;
            this.label18.Width = 1.4F;
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
            this.label19.Height = 0.15F;
            this.label19.HyperLink = "";
            this.label19.Left = 9.375F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "拠点倉庫３";
            this.label19.Top = 0.4208334F;
            this.label19.Width = 1.4F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0.01041667F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08695P_01A4C
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
            this.PageEnd += new System.EventHandler(this.PMKHN08695P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08695P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.sectioncode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyname1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidesnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companysetnote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionguidenm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyname2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companytelno3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companysetnote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectwarehousecd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectwarehousecd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectwarehousecd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousename1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousename2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousename3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyteltitle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyteltitle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyteltitle3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
