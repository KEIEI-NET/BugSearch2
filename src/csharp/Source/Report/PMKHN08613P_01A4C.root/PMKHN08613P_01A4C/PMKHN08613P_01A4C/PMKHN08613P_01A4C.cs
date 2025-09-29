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
	/// 商品マスタ（印刷）フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 商品マスタ（印刷）のフォームクラスです。</br>
	/// <br>Programmer   : 30462 行澤 仁美</br>
	/// <br>Date         : 2008.10.30</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN08613P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 商品マスタ（印刷）フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note         : 商品マスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 30462 行澤 仁美</br>
        /// <br>Date         : 2008.10.30</br>
		/// </remarks>
		public PMKHN08613P_01A4C()
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

        private GoodsPrintWork      _goodsPrintWork;                   // 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private Line line4;
        private Line line6;
        private TextBox SORTTITLE;

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
                this._goodsPrintWork = (GoodsPrintWork)this._printInfo.jyoken;
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
				// TODO:  PMKHN08613P_01A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  PMKHN08613P_01A4C.WatermarkMode setter 実装を追加します。
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

            if (this._goodsPrintWork.PrintType == 0)
            {
                this.line2.Visible = false;
                this.line3.Visible = false;
                this.line4.Visible = true;
                this.line6.Visible = true;

                this.Lb_goodsspecialnote.Visible = false;
                this.Lb_pricestartdate.Visible = false;
                this.Lb_newlistprice.Visible = false;
                this.Lb_taxationdivcd.Visible = false;
                this.Lb_offerdatadiv.Visible = false;
                this.Lb_enterpriseganrecode.Visible = false;
                this.Lb_goodskindcode2.Visible = false;
                this.Lb_goodskindcode.Visible = true;

                this.goodsspecialnote.Visible = false;
                this.pricestartdate.Visible = false;
                this.newlistprice.Visible = false;
                this.taxationdivcd.Visible = false;
                this.offerdatadiv.Visible = false;
                this.enterpriseganrecode.Visible = false;
                this.enterpriseganrecodename.Visible = false;
            }
            else
            {
                this.line2.Visible = true;
                this.line3.Visible = true;
                this.line4.Visible = false;
                this.line6.Visible = false;

                this.Lb_goodsspecialnote.Visible = true;
                this.Lb_pricestartdate.Visible = true;
                this.Lb_newlistprice.Visible = true;
                this.Lb_taxationdivcd.Visible = true;
                this.Lb_offerdatadiv.Visible = true;
                this.Lb_enterpriseganrecode.Visible = true;
                this.Lb_goodskindcode2.Visible = true;
                this.Lb_goodskindcode.Visible = false;

                this.goodsspecialnote.Visible = true;
                this.pricestartdate.Visible = true;
                this.newlistprice.Visible = true;
                this.taxationdivcd.Visible = true;
                this.offerdatadiv.Visible = true;
                this.enterpriseganrecode.Visible = true;
                this.enterpriseganrecodename.Visible = true;

                this.goodskindcode.Top = this.goodsspecialnote.Top;
                this.goodskindcode.Left = this.dummygoodskindcode.Left;
            }
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

		#region ◎ PMKHN08613P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN08613P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08613P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region ◎ PMKHN08613P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN08613P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PMKHN08613P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 行澤 仁美</br>
		/// <br>Date		: 2008.10.30</br>
		/// </remarks>
		private void PMKHN08613P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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

            string str_sort = "";
            switch (this._goodsPrintWork.PrintOdr)
            {
                case 0:
                    str_sort = "メーカー順";
                    break;
                case 1:
                    str_sort = "ＢＬコード順";
                    break;
                case 2:
                    str_sort = "仕入先順";
                    break;
                case 3:
                    str_sort = "品番順";
                    break;
            }
            this.SORTTITLE.Text = str_sort;
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
            // 2009.03.23 30413 犬飼 フッター部の印刷設定 >>>>>>START
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
            // 2009.03.23 30413 犬飼 フッター部の印刷設定 <<<<<<END
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

        private Label label1;
        private Label Lb_goodsspecialnote;
        private Line line2;
        private Line line3;
        private TextBox goodsspecialnote;
        private Label label8;
        private Label lblcompanytelno2;
        private Label label13;
        private Label label14;
        private Label Lb_pricestartdate;
        private TextBox pricestartdate;
        private Label label7;
        private TextBox goodsmakercd;
        private TextBox makershortname;
        private TextBox goodsno;
        private TextBox blgoodscode;
        private TextBox goodsname;
        private TextBox suppliercd;
        private TextBox suppliersnm;
        private TextBox listprice;
        private TextBox goodsraterank;
        private TextBox supplierlot;
        private TextBox goodskindcode;
        private TextBox updatedatetime;
        private TextBox dummygoodskindcode;
        private TextBox stockrate;
        private TextBox salesunitcost;
        private Label label4;
        private Label label12;
        private Label label10;
        private Label label16;
        private Label Lb_goodskindcode;
        private Label label19;
        private TextBox newlistprice;
        private Label Lb_newlistprice;
        private TextBox taxationdivcd;
        private TextBox offerdatadiv;
        private TextBox enterpriseganrecode;
        private TextBox enterpriseganrecodename;
        private Label Lb_goodskindcode2;
        private Label Lb_taxationdivcd;
        private Label Lb_offerdatadiv;
        private Label Lb_enterpriseganrecode;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08613P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.goodsspecialnote = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.pricestartdate = new DataDynamics.ActiveReports.TextBox();
            this.goodsmakercd = new DataDynamics.ActiveReports.TextBox();
            this.makershortname = new DataDynamics.ActiveReports.TextBox();
            this.goodsno = new DataDynamics.ActiveReports.TextBox();
            this.blgoodscode = new DataDynamics.ActiveReports.TextBox();
            this.goodsname = new DataDynamics.ActiveReports.TextBox();
            this.suppliercd = new DataDynamics.ActiveReports.TextBox();
            this.suppliersnm = new DataDynamics.ActiveReports.TextBox();
            this.listprice = new DataDynamics.ActiveReports.TextBox();
            this.goodsraterank = new DataDynamics.ActiveReports.TextBox();
            this.supplierlot = new DataDynamics.ActiveReports.TextBox();
            this.goodskindcode = new DataDynamics.ActiveReports.TextBox();
            this.updatedatetime = new DataDynamics.ActiveReports.TextBox();
            this.dummygoodskindcode = new DataDynamics.ActiveReports.TextBox();
            this.stockrate = new DataDynamics.ActiveReports.TextBox();
            this.salesunitcost = new DataDynamics.ActiveReports.TextBox();
            this.newlistprice = new DataDynamics.ActiveReports.TextBox();
            this.taxationdivcd = new DataDynamics.ActiveReports.TextBox();
            this.offerdatadiv = new DataDynamics.ActiveReports.TextBox();
            this.enterpriseganrecode = new DataDynamics.ActiveReports.TextBox();
            this.enterpriseganrecodename = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Lb_goodsspecialnote = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.lblcompanytelno2 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.Lb_pricestartdate = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.Lb_goodskindcode = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.Lb_newlistprice = new DataDynamics.ActiveReports.Label();
            this.Lb_goodskindcode2 = new DataDynamics.ActiveReports.Label();
            this.Lb_taxationdivcd = new DataDynamics.ActiveReports.Label();
            this.Lb_offerdatadiv = new DataDynamics.ActiveReports.Label();
            this.Lb_enterpriseganrecode = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.goodsspecialnote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricestartdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsmakercd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.makershortname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blgoodscode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliercd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listprice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsraterank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodskindcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatedatetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dummygoodskindcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesunitcost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newlistprice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxationdivcd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offerdatadiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecodename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_goodsspecialnote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_pricestartdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_goodskindcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_newlistprice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_goodskindcode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_taxationdivcd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_offerdatadiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_enterpriseganrecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.goodsspecialnote,
            this.line3,
            this.pricestartdate,
            this.goodsmakercd,
            this.makershortname,
            this.goodsno,
            this.blgoodscode,
            this.goodsname,
            this.suppliercd,
            this.suppliersnm,
            this.listprice,
            this.goodsraterank,
            this.supplierlot,
            this.goodskindcode,
            this.updatedatetime,
            this.dummygoodskindcode,
            this.stockrate,
            this.salesunitcost,
            this.newlistprice,
            this.taxationdivcd,
            this.offerdatadiv,
            this.enterpriseganrecode,
            this.enterpriseganrecodename,
            this.line6});
            this.Detail.Height = 1.166667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // goodsspecialnote
            // 
            this.goodsspecialnote.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsspecialnote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsspecialnote.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsspecialnote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsspecialnote.Border.RightColor = System.Drawing.Color.Black;
            this.goodsspecialnote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsspecialnote.Border.TopColor = System.Drawing.Color.Black;
            this.goodsspecialnote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsspecialnote.DataField = "goodsspecialnote";
            this.goodsspecialnote.Height = 0.15F;
            this.goodsspecialnote.Left = 0.3125F;
            this.goodsspecialnote.MultiLine = false;
            this.goodsspecialnote.Name = "goodsspecialnote";
            this.goodsspecialnote.OutputFormat = resources.GetString("goodsspecialnote.OutputFormat");
            this.goodsspecialnote.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.goodsspecialnote.Text = "あいうえおかきくけこあいうえおかきくけこあいうえおかきくけこあいうえおかきくけこ";
            this.goodsspecialnote.Top = 0.1875F;
            this.goodsspecialnote.Width = 3.9375F;
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
            // pricestartdate
            // 
            this.pricestartdate.Border.BottomColor = System.Drawing.Color.Black;
            this.pricestartdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pricestartdate.Border.LeftColor = System.Drawing.Color.Black;
            this.pricestartdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pricestartdate.Border.RightColor = System.Drawing.Color.Black;
            this.pricestartdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pricestartdate.Border.TopColor = System.Drawing.Color.Black;
            this.pricestartdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pricestartdate.DataField = "pricestartdate";
            this.pricestartdate.Height = 0.15F;
            this.pricestartdate.Left = 6.3125F;
            this.pricestartdate.MultiLine = false;
            this.pricestartdate.Name = "pricestartdate";
            this.pricestartdate.OutputFormat = resources.GetString("pricestartdate.OutputFormat");
            this.pricestartdate.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.pricestartdate.Text = "9999/99/99";
            this.pricestartdate.Top = 0.1875F;
            this.pricestartdate.Width = 0.6F;
            // 
            // goodsmakercd
            // 
            this.goodsmakercd.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsmakercd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsmakercd.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsmakercd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsmakercd.Border.RightColor = System.Drawing.Color.Black;
            this.goodsmakercd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsmakercd.Border.TopColor = System.Drawing.Color.Black;
            this.goodsmakercd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsmakercd.DataField = "goodsmakercd";
            this.goodsmakercd.Height = 0.15F;
            this.goodsmakercd.Left = 0F;
            this.goodsmakercd.MultiLine = false;
            this.goodsmakercd.Name = "goodsmakercd";
            this.goodsmakercd.OutputFormat = resources.GetString("goodsmakercd.OutputFormat");
            this.goodsmakercd.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.goodsmakercd.Text = "1234";
            this.goodsmakercd.Top = 0.02083334F;
            this.goodsmakercd.Width = 0.3125F;
            // 
            // makershortname
            // 
            this.makershortname.Border.BottomColor = System.Drawing.Color.Black;
            this.makershortname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.makershortname.Border.LeftColor = System.Drawing.Color.Black;
            this.makershortname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.makershortname.Border.RightColor = System.Drawing.Color.Black;
            this.makershortname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.makershortname.Border.TopColor = System.Drawing.Color.Black;
            this.makershortname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.makershortname.DataField = "makershortname";
            this.makershortname.Height = 0.15F;
            this.makershortname.Left = 0.3125F;
            this.makershortname.MultiLine = false;
            this.makershortname.Name = "makershortname";
            this.makershortname.OutputFormat = resources.GetString("makershortname.OutputFormat");
            this.makershortname.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.makershortname.Text = "あいうえおかきくけこ";
            this.makershortname.Top = 0.02083334F;
            this.makershortname.Width = 1F;
            // 
            // goodsno
            // 
            this.goodsno.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsno.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsno.Border.RightColor = System.Drawing.Color.Black;
            this.goodsno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsno.Border.TopColor = System.Drawing.Color.Black;
            this.goodsno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsno.DataField = "goodsno";
            this.goodsno.Height = 0.15F;
            this.goodsno.Left = 1.354167F;
            this.goodsno.MultiLine = false;
            this.goodsno.Name = "goodsno";
            this.goodsno.OutputFormat = resources.GetString("goodsno.OutputFormat");
            this.goodsno.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.goodsno.Text = "123456789012345678901234";
            this.goodsno.Top = 0.02083334F;
            this.goodsno.Width = 1.25F;
            // 
            // blgoodscode
            // 
            this.blgoodscode.Border.BottomColor = System.Drawing.Color.Black;
            this.blgoodscode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.blgoodscode.Border.LeftColor = System.Drawing.Color.Black;
            this.blgoodscode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.blgoodscode.Border.RightColor = System.Drawing.Color.Black;
            this.blgoodscode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.blgoodscode.Border.TopColor = System.Drawing.Color.Black;
            this.blgoodscode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.blgoodscode.DataField = "blgoodscode";
            this.blgoodscode.Height = 0.15F;
            this.blgoodscode.Left = 2.645833F;
            this.blgoodscode.MultiLine = false;
            this.blgoodscode.Name = "blgoodscode";
            this.blgoodscode.OutputFormat = resources.GetString("blgoodscode.OutputFormat");
            this.blgoodscode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.blgoodscode.Text = "12345";
            this.blgoodscode.Top = 0.02083334F;
            this.blgoodscode.Width = 0.3124999F;
            // 
            // goodsname
            // 
            this.goodsname.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsname.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsname.Border.RightColor = System.Drawing.Color.Black;
            this.goodsname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsname.Border.TopColor = System.Drawing.Color.Black;
            this.goodsname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsname.DataField = "goodsname";
            this.goodsname.Height = 0.15F;
            this.goodsname.Left = 3F;
            this.goodsname.MultiLine = false;
            this.goodsname.Name = "goodsname";
            this.goodsname.OutputFormat = resources.GetString("goodsname.OutputFormat");
            this.goodsname.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.goodsname.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.goodsname.Top = 0.02083334F;
            this.goodsname.Width = 2F;
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
            this.suppliercd.Left = 5.041667F;
            this.suppliercd.MultiLine = false;
            this.suppliercd.Name = "suppliercd";
            this.suppliercd.OutputFormat = resources.GetString("suppliercd.OutputFormat");
            this.suppliercd.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.suppliercd.Text = "123456";
            this.suppliercd.Top = 0.02083334F;
            this.suppliercd.Width = 0.3750001F;
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
            this.suppliersnm.Left = 5.458333F;
            this.suppliersnm.MultiLine = false;
            this.suppliersnm.Name = "suppliersnm";
            this.suppliersnm.OutputFormat = resources.GetString("suppliersnm.OutputFormat");
            this.suppliersnm.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.suppliersnm.Text = "あいうえおかきくけこあいうえお";
            this.suppliersnm.Top = 0.02083334F;
            this.suppliersnm.Width = 1.5F;
            // 
            // listprice
            // 
            this.listprice.Border.BottomColor = System.Drawing.Color.Black;
            this.listprice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.listprice.Border.LeftColor = System.Drawing.Color.Black;
            this.listprice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.listprice.Border.RightColor = System.Drawing.Color.Black;
            this.listprice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.listprice.Border.TopColor = System.Drawing.Color.Black;
            this.listprice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.listprice.DataField = "listprice";
            this.listprice.Height = 0.15F;
            this.listprice.Left = 7F;
            this.listprice.MultiLine = false;
            this.listprice.Name = "listprice";
            this.listprice.OutputFormat = resources.GetString("listprice.OutputFormat");
            this.listprice.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.listprice.Text = "12,345,678.90";
            this.listprice.Top = 0.02083334F;
            this.listprice.Width = 0.6875002F;
            // 
            // goodsraterank
            // 
            this.goodsraterank.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsraterank.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsraterank.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsraterank.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsraterank.Border.RightColor = System.Drawing.Color.Black;
            this.goodsraterank.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsraterank.Border.TopColor = System.Drawing.Color.Black;
            this.goodsraterank.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsraterank.DataField = "goodsraterank";
            this.goodsraterank.Height = 0.15F;
            this.goodsraterank.Left = 8.875001F;
            this.goodsraterank.MultiLine = false;
            this.goodsraterank.Name = "goodsraterank";
            this.goodsraterank.OutputFormat = resources.GetString("goodsraterank.OutputFormat");
            this.goodsraterank.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.goodsraterank.Text = "1234";
            this.goodsraterank.Top = 0.02083334F;
            this.goodsraterank.Width = 0.25F;
            // 
            // supplierlot
            // 
            this.supplierlot.Border.BottomColor = System.Drawing.Color.Black;
            this.supplierlot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierlot.Border.LeftColor = System.Drawing.Color.Black;
            this.supplierlot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierlot.Border.RightColor = System.Drawing.Color.Black;
            this.supplierlot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierlot.Border.TopColor = System.Drawing.Color.Black;
            this.supplierlot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.supplierlot.DataField = "supplierlot";
            this.supplierlot.Height = 0.15F;
            this.supplierlot.Left = 9.208336F;
            this.supplierlot.MultiLine = false;
            this.supplierlot.Name = "supplierlot";
            this.supplierlot.OutputFormat = resources.GetString("supplierlot.OutputFormat");
            this.supplierlot.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.supplierlot.Text = "1234";
            this.supplierlot.Top = 0.02083334F;
            this.supplierlot.Width = 0.3F;
            // 
            // goodskindcode
            // 
            this.goodskindcode.Border.BottomColor = System.Drawing.Color.Black;
            this.goodskindcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodskindcode.Border.LeftColor = System.Drawing.Color.Black;
            this.goodskindcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodskindcode.Border.RightColor = System.Drawing.Color.Black;
            this.goodskindcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodskindcode.Border.TopColor = System.Drawing.Color.Black;
            this.goodskindcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodskindcode.DataField = "goodskindcode";
            this.goodskindcode.Height = 0.15F;
            this.goodskindcode.Left = 9.645834F;
            this.goodskindcode.MultiLine = false;
            this.goodskindcode.Name = "goodskindcode";
            this.goodskindcode.OutputFormat = resources.GetString("goodskindcode.OutputFormat");
            this.goodskindcode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.goodskindcode.Text = "あいう";
            this.goodskindcode.Top = 0.02083334F;
            this.goodskindcode.Width = 0.3749998F;
            // 
            // updatedatetime
            // 
            this.updatedatetime.Border.BottomColor = System.Drawing.Color.Black;
            this.updatedatetime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.updatedatetime.Border.LeftColor = System.Drawing.Color.Black;
            this.updatedatetime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.updatedatetime.Border.RightColor = System.Drawing.Color.Black;
            this.updatedatetime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.updatedatetime.Border.TopColor = System.Drawing.Color.Black;
            this.updatedatetime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.updatedatetime.DataField = "updatedatetime";
            this.updatedatetime.Height = 0.15F;
            this.updatedatetime.Left = 10.0625F;
            this.updatedatetime.MultiLine = false;
            this.updatedatetime.Name = "updatedatetime";
            this.updatedatetime.OutputFormat = resources.GetString("updatedatetime.OutputFormat");
            this.updatedatetime.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.updatedatetime.Text = "9999/99/99";
            this.updatedatetime.Top = 0.02083334F;
            this.updatedatetime.Width = 0.5625002F;
            // 
            // dummygoodskindcode
            // 
            this.dummygoodskindcode.Border.BottomColor = System.Drawing.Color.Black;
            this.dummygoodskindcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dummygoodskindcode.Border.LeftColor = System.Drawing.Color.Black;
            this.dummygoodskindcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dummygoodskindcode.Border.RightColor = System.Drawing.Color.Black;
            this.dummygoodskindcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dummygoodskindcode.Border.TopColor = System.Drawing.Color.Black;
            this.dummygoodskindcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.dummygoodskindcode.Height = 0.15F;
            this.dummygoodskindcode.Left = 7.729167F;
            this.dummygoodskindcode.MultiLine = false;
            this.dummygoodskindcode.Name = "dummygoodskindcode";
            this.dummygoodskindcode.OutputFormat = resources.GetString("dummygoodskindcode.OutputFormat");
            this.dummygoodskindcode.Style = "ddo-char-set: 128; text-align: left; background-color: #FFC0C0; font-size: 8pt; f" +
                "ont-family: ＭＳ 明朝; vertical-align: top; ";
            this.dummygoodskindcode.Text = "ダミー";
            this.dummygoodskindcode.Top = 0.625F;
            this.dummygoodskindcode.Visible = false;
            this.dummygoodskindcode.Width = 0.3749998F;
            // 
            // stockrate
            // 
            this.stockrate.Border.BottomColor = System.Drawing.Color.Black;
            this.stockrate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockrate.Border.LeftColor = System.Drawing.Color.Black;
            this.stockrate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockrate.Border.RightColor = System.Drawing.Color.Black;
            this.stockrate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockrate.Border.TopColor = System.Drawing.Color.Black;
            this.stockrate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.stockrate.DataField = "stockrate";
            this.stockrate.Height = 0.15F;
            this.stockrate.Left = 7.729167F;
            this.stockrate.MultiLine = false;
            this.stockrate.Name = "stockrate";
            this.stockrate.OutputFormat = resources.GetString("stockrate.OutputFormat");
            this.stockrate.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.stockrate.Text = "-123.99";
            this.stockrate.Top = 0.02083334F;
            this.stockrate.Width = 0.3749999F;
            // 
            // salesunitcost
            // 
            this.salesunitcost.Border.BottomColor = System.Drawing.Color.Black;
            this.salesunitcost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesunitcost.Border.LeftColor = System.Drawing.Color.Black;
            this.salesunitcost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesunitcost.Border.RightColor = System.Drawing.Color.Black;
            this.salesunitcost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesunitcost.Border.TopColor = System.Drawing.Color.Black;
            this.salesunitcost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.salesunitcost.DataField = "salesunitcost";
            this.salesunitcost.Height = 0.15F;
            this.salesunitcost.Left = 8.145834F;
            this.salesunitcost.MultiLine = false;
            this.salesunitcost.Name = "salesunitcost";
            this.salesunitcost.OutputFormat = resources.GetString("salesunitcost.OutputFormat");
            this.salesunitcost.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.salesunitcost.Text = "12,345,678.90";
            this.salesunitcost.Top = 0.02083334F;
            this.salesunitcost.Width = 0.6875002F;
            // 
            // newlistprice
            // 
            this.newlistprice.Border.BottomColor = System.Drawing.Color.Black;
            this.newlistprice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.newlistprice.Border.LeftColor = System.Drawing.Color.Black;
            this.newlistprice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.newlistprice.Border.RightColor = System.Drawing.Color.Black;
            this.newlistprice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.newlistprice.Border.TopColor = System.Drawing.Color.Black;
            this.newlistprice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.newlistprice.DataField = "newlistprice";
            this.newlistprice.Height = 0.15F;
            this.newlistprice.Left = 7F;
            this.newlistprice.MultiLine = false;
            this.newlistprice.Name = "newlistprice";
            this.newlistprice.OutputFormat = resources.GetString("newlistprice.OutputFormat");
            this.newlistprice.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.newlistprice.Text = "12,345,678.90";
            this.newlistprice.Top = 0.1875F;
            this.newlistprice.Width = 0.6875002F;
            // 
            // taxationdivcd
            // 
            this.taxationdivcd.Border.BottomColor = System.Drawing.Color.Black;
            this.taxationdivcd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationdivcd.Border.LeftColor = System.Drawing.Color.Black;
            this.taxationdivcd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationdivcd.Border.RightColor = System.Drawing.Color.Black;
            this.taxationdivcd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationdivcd.Border.TopColor = System.Drawing.Color.Black;
            this.taxationdivcd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.taxationdivcd.DataField = "taxationdivcd";
            this.taxationdivcd.Height = 0.15F;
            this.taxationdivcd.Left = 8.145834F;
            this.taxationdivcd.MultiLine = false;
            this.taxationdivcd.Name = "taxationdivcd";
            this.taxationdivcd.OutputFormat = resources.GetString("taxationdivcd.OutputFormat");
            this.taxationdivcd.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.taxationdivcd.Text = "あいうえおか";
            this.taxationdivcd.Top = 0.1875F;
            this.taxationdivcd.Width = 0.6875002F;
            // 
            // offerdatadiv
            // 
            this.offerdatadiv.Border.BottomColor = System.Drawing.Color.Black;
            this.offerdatadiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.offerdatadiv.Border.LeftColor = System.Drawing.Color.Black;
            this.offerdatadiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.offerdatadiv.Border.RightColor = System.Drawing.Color.Black;
            this.offerdatadiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.offerdatadiv.Border.TopColor = System.Drawing.Color.Black;
            this.offerdatadiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.offerdatadiv.DataField = "offerdatadiv";
            this.offerdatadiv.Height = 0.15F;
            this.offerdatadiv.Left = 8.875F;
            this.offerdatadiv.MultiLine = false;
            this.offerdatadiv.Name = "offerdatadiv";
            this.offerdatadiv.OutputFormat = resources.GetString("offerdatadiv.OutputFormat");
            this.offerdatadiv.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.offerdatadiv.Text = "あいうえ";
            this.offerdatadiv.Top = 0.1875F;
            this.offerdatadiv.Width = 0.4375001F;
            // 
            // enterpriseganrecode
            // 
            this.enterpriseganrecode.Border.BottomColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.Border.LeftColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.Border.RightColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.Border.TopColor = System.Drawing.Color.Black;
            this.enterpriseganrecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecode.DataField = "enterpriseganrecode";
            this.enterpriseganrecode.Height = 0.15F;
            this.enterpriseganrecode.Left = 9.375F;
            this.enterpriseganrecode.MultiLine = false;
            this.enterpriseganrecode.Name = "enterpriseganrecode";
            this.enterpriseganrecode.OutputFormat = resources.GetString("enterpriseganrecode.OutputFormat");
            this.enterpriseganrecode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.enterpriseganrecode.Text = "1234";
            this.enterpriseganrecode.Top = 0.1875F;
            this.enterpriseganrecode.Width = 0.3125F;
            // 
            // enterpriseganrecodename
            // 
            this.enterpriseganrecodename.Border.BottomColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.Border.LeftColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.Border.RightColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.Border.TopColor = System.Drawing.Color.Black;
            this.enterpriseganrecodename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.enterpriseganrecodename.DataField = "enterpriseganrecodename";
            this.enterpriseganrecodename.Height = 0.15F;
            this.enterpriseganrecodename.Left = 9.6875F;
            this.enterpriseganrecodename.MultiLine = false;
            this.enterpriseganrecodename.Name = "enterpriseganrecodename";
            this.enterpriseganrecodename.OutputFormat = resources.GetString("enterpriseganrecodename.OutputFormat");
            this.enterpriseganrecodename.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.enterpriseganrecodename.Text = "あいうえおかきくけこ";
            this.enterpriseganrecodename.Top = 0.1875F;
            this.enterpriseganrecodename.Width = 1F;
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
            this.line6.Top = 0.1770833F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0.1770833F;
            this.line6.Y2 = 0.1770833F;
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
            this.SORTTITLE});
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
            this.tb_ReportTitle.Text = "商品マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
            // 
            // SORTTITLE
            // 
            this.SORTTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Height = 0.125F;
            this.SORTTITLE.Left = 3.75F;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "color: Black; font-size: 8pt; vertical-align: top; ";
            this.SORTTITLE.Text = null;
            this.SORTTITLE.Top = 0.0625F;
            this.SORTTITLE.Width = 2F;
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
            this.Lb_goodsspecialnote,
            this.line2,
            this.label8,
            this.lblcompanytelno2,
            this.label13,
            this.label14,
            this.Lb_pricestartdate,
            this.label7,
            this.label4,
            this.label12,
            this.label10,
            this.label16,
            this.Lb_goodskindcode,
            this.label19,
            this.Lb_newlistprice,
            this.Lb_goodskindcode2,
            this.Lb_taxationdivcd,
            this.Lb_offerdatadiv,
            this.Lb_enterpriseganrecode,
            this.line4});
            this.TitleHeader.Height = 0.675F;
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
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label1.Text = "ﾒｰｶｰ";
            this.label1.Top = 0.0625F;
            this.label1.Width = 0.3125F;
            // 
            // Lb_goodsspecialnote
            // 
            this.Lb_goodsspecialnote.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_goodsspecialnote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodsspecialnote.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_goodsspecialnote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodsspecialnote.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_goodsspecialnote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodsspecialnote.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_goodsspecialnote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodsspecialnote.Height = 0.15F;
            this.Lb_goodsspecialnote.HyperLink = "";
            this.Lb_goodsspecialnote.Left = 0.3125F;
            this.Lb_goodsspecialnote.MultiLine = false;
            this.Lb_goodsspecialnote.Name = "Lb_goodsspecialnote";
            this.Lb_goodsspecialnote.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_goodsspecialnote.Text = "規格・特記事項";
            this.Lb_goodsspecialnote.Top = 0.2395834F;
            this.Lb_goodsspecialnote.Width = 3.37F;
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
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
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
            this.label8.Left = 1.354167F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label8.Text = "品番";
            this.label8.Top = 0.0625F;
            this.label8.Width = 1.14F;
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
            this.lblcompanytelno2.Left = 2.645833F;
            this.lblcompanytelno2.MultiLine = false;
            this.lblcompanytelno2.Name = "lblcompanytelno2";
            this.lblcompanytelno2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.lblcompanytelno2.Text = "BLｺｰﾄﾞ";
            this.lblcompanytelno2.Top = 0.0625F;
            this.lblcompanytelno2.Width = 0.375F;
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
            this.label13.Left = 3F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label13.Text = "品名";
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
            this.label14.Left = 5.041667F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label14.Text = "仕入先";
            this.label14.Top = 0.0625F;
            this.label14.Width = 1.75F;
            // 
            // Lb_pricestartdate
            // 
            this.Lb_pricestartdate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_pricestartdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_pricestartdate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_pricestartdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_pricestartdate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_pricestartdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_pricestartdate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_pricestartdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_pricestartdate.Height = 0.15F;
            this.Lb_pricestartdate.HyperLink = "";
            this.Lb_pricestartdate.Left = 6.3125F;
            this.Lb_pricestartdate.MultiLine = false;
            this.Lb_pricestartdate.Name = "Lb_pricestartdate";
            this.Lb_pricestartdate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_pricestartdate.Text = "適用日";
            this.Lb_pricestartdate.Top = 0.2395834F;
            this.Lb_pricestartdate.Width = 0.6F;
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
            this.label7.Left = 7F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label7.Text = "標準価格";
            this.label7.Top = 0.0625F;
            this.label7.Width = 0.6875002F;
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
            this.label4.Left = 7.729167F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label4.Text = "仕入率";
            this.label4.Top = 0.0625F;
            this.label4.Width = 0.3749999F;
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
            this.label12.Height = 0.15F;
            this.label12.HyperLink = "";
            this.label12.Left = 8.145834F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label12.Text = "原単価";
            this.label12.Top = 0.0625F;
            this.label12.Width = 0.6875002F;
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
            this.label10.Left = 8.875001F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "層別";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.25F;
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
            this.label16.Left = 9.158336F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label16.Text = "ロット";
            this.label16.Top = 0.0625F;
            this.label16.Width = 0.35F;
            // 
            // Lb_goodskindcode
            // 
            this.Lb_goodskindcode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode.Height = 0.15F;
            this.Lb_goodskindcode.HyperLink = "";
            this.Lb_goodskindcode.Left = 9.645834F;
            this.Lb_goodskindcode.MultiLine = false;
            this.Lb_goodskindcode.Name = "Lb_goodskindcode";
            this.Lb_goodskindcode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_goodskindcode.Text = "純優";
            this.Lb_goodskindcode.Top = 0.0625F;
            this.Lb_goodskindcode.Width = 0.25F;
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
            this.label19.Left = 10.0625F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.label19.Text = "登録日";
            this.label19.Top = 0.0625F;
            this.label19.Width = 0.5625002F;
            // 
            // Lb_newlistprice
            // 
            this.Lb_newlistprice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_newlistprice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_newlistprice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_newlistprice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_newlistprice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_newlistprice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_newlistprice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_newlistprice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_newlistprice.Height = 0.15F;
            this.Lb_newlistprice.HyperLink = "";
            this.Lb_newlistprice.Left = 7F;
            this.Lb_newlistprice.MultiLine = false;
            this.Lb_newlistprice.Name = "Lb_newlistprice";
            this.Lb_newlistprice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_newlistprice.Text = "新標準価格";
            this.Lb_newlistprice.Top = 0.2395834F;
            this.Lb_newlistprice.Width = 0.6875002F;
            // 
            // Lb_goodskindcode2
            // 
            this.Lb_goodskindcode2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_goodskindcode2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_goodskindcode2.Height = 0.15F;
            this.Lb_goodskindcode2.HyperLink = "";
            this.Lb_goodskindcode2.Left = 7.729167F;
            this.Lb_goodskindcode2.MultiLine = false;
            this.Lb_goodskindcode2.Name = "Lb_goodskindcode2";
            this.Lb_goodskindcode2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_goodskindcode2.Text = "純優";
            this.Lb_goodskindcode2.Top = 0.2395834F;
            this.Lb_goodskindcode2.Width = 0.3749999F;
            // 
            // Lb_taxationdivcd
            // 
            this.Lb_taxationdivcd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_taxationdivcd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_taxationdivcd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_taxationdivcd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_taxationdivcd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_taxationdivcd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_taxationdivcd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_taxationdivcd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_taxationdivcd.Height = 0.15F;
            this.Lb_taxationdivcd.HyperLink = "";
            this.Lb_taxationdivcd.Left = 8.145834F;
            this.Lb_taxationdivcd.MultiLine = false;
            this.Lb_taxationdivcd.Name = "Lb_taxationdivcd";
            this.Lb_taxationdivcd.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_taxationdivcd.Text = "税区分";
            this.Lb_taxationdivcd.Top = 0.2395834F;
            this.Lb_taxationdivcd.Width = 0.3749999F;
            // 
            // Lb_offerdatadiv
            // 
            this.Lb_offerdatadiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_offerdatadiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_offerdatadiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_offerdatadiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_offerdatadiv.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_offerdatadiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_offerdatadiv.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_offerdatadiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_offerdatadiv.Height = 0.15F;
            this.Lb_offerdatadiv.HyperLink = "";
            this.Lb_offerdatadiv.Left = 8.875F;
            this.Lb_offerdatadiv.MultiLine = false;
            this.Lb_offerdatadiv.Name = "Lb_offerdatadiv";
            this.Lb_offerdatadiv.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_offerdatadiv.Text = "提供区分";
            this.Lb_offerdatadiv.Top = 0.2395834F;
            this.Lb_offerdatadiv.Width = 0.4999997F;
            // 
            // Lb_enterpriseganrecode
            // 
            this.Lb_enterpriseganrecode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_enterpriseganrecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_enterpriseganrecode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_enterpriseganrecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_enterpriseganrecode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_enterpriseganrecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_enterpriseganrecode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_enterpriseganrecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_enterpriseganrecode.Height = 0.15F;
            this.Lb_enterpriseganrecode.HyperLink = "";
            this.Lb_enterpriseganrecode.Left = 9.375F;
            this.Lb_enterpriseganrecode.MultiLine = false;
            this.Lb_enterpriseganrecode.Name = "Lb_enterpriseganrecode";
            this.Lb_enterpriseganrecode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_enterpriseganrecode.Text = "商品区分";
            this.Lb_enterpriseganrecode.Top = 0.2395834F;
            this.Lb_enterpriseganrecode.Width = 0.4999997F;
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
            this.line4.Top = 0.21875F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0.21875F;
            this.line4.Y2 = 0.21875F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PMKHN08613P_01A4C
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
            this.PageEnd += new System.EventHandler(this.PMKHN08613P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08613P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.goodsspecialnote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pricestartdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsmakercd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.makershortname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blgoodscode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliercd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listprice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsraterank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodskindcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatedatetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dummygoodskindcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesunitcost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newlistprice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxationdivcd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offerdatadiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterpriseganrecodename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_goodsspecialnote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcompanytelno2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_pricestartdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_goodskindcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_newlistprice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_goodskindcode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_taxationdivcd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_offerdatadiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_enterpriseganrecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


        
	}
}
