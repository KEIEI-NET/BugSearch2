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

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 支払残高元帳印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 支払残高元帳のフォームクラスです。</br>
	/// <br>Programmer	: 20081 疋田　勇人</br>
	/// <br>Date		: 2007.10.03</br>
    /// <br>Update Note : 2008/12/10 30414 忍 幸史 Partsman用に変更</br>
	/// </remarks>
	public class DCKAK02562P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 支払残高元帳フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 支払残高元帳フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 20081　疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
		/// </remarks>
		public DCKAK02562P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
		private int _printCount;									// 印刷件数用カウンタ

		private string				_pageHeaderSortOderTitle;		// ソート順
		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderSubtitle;			// フォームサブタイトル
		private ArrayList			_otherDataList;					// その他データ
        private ExtrInfo_PaymentBalance _extrInfo_PaymentBalance;	// 抽出条件クラス
		// その他データ格納項目
		private string				_sumTitle;						// 小計タイトル
		private string				_agentKindTitle;				// 担当者タイトル
		private string				_detailAddupSecNameTtl;			// 明細拠点名称タイトル
        /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
		private DataSet				_outputDs;						// 印刷用DataSet
           --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
        private const string ct_PaymentTable = DCKAK02564EA.Col_Tbl_PaymentBalance;    // 支払残高元帳テーブル名称

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;
        private Label Label104;
        private TextBox PayeeSnm;
        private TextBox TextBox12;
        private TextBox PaymentCond;
        private TextBox TextBox13;
        private TextBox TextBox17;
        private TextBox TextBox14;
        private TextBox TextBox18;
        private TextBox TextBox15;
        private TextBox TextBox19;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private TextBox SECTOTALTITLE;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox10;
        private Line line2;
        private Label ALLTOTALTITLE;
        private TextBox textBox16;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox25;
        private TextBox textBox27;
        private TextBox PayeeCode;
        private TextBox AddUpSecCode;

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
                this._extrInfo_PaymentBalance = (ExtrInfo_PaymentBalance)this._printInfo.jyoken;
                /* --- DEL 2008/12/10 --------------------------------------------------------------------->>>>>
				this._outputDs			= (DataSet)this._printInfo.rdData;
                   --- DEL 2008/12/10 ---------------------------------------------------------------------<<<<<*/
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
						this._sumTitle				= this._otherDataList[0].ToString();
						this._agentKindTitle		= this._otherDataList[1].ToString();
						this._detailAddupSecNameTtl = this._otherDataList[2].ToString();
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
				// TODO:  MAHNB02012P_02A4C.WatermarkMode getter 実装を追加します。
				return 0;
			}
			set
			{
				// TODO:  MAHNB02012P_02A4C.WatermarkMode setter 実装を追加します。
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
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// 印字設定 --------------------------------------------------------------------------------------
			// 拠点計を出力するかしないかを選択する
			// 拠点有無を判断
			if ( this._extrInfo_PaymentBalance.IsOptSection )
			{
				// 全社がチェックされていない時で拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
				if ( ( this._extrInfo_PaymentBalance.PaymentAddupSecCodeList.Length < 2 ) && (this._extrInfo_PaymentBalance.IsSelectAllSection == false))
				{
					SectionHeader.DataField = "";
					SectionHeader.Visible = false;
                    //SectionFooter.Visible = false;
				}
				else
				{
					SectionHeader.DataField = DCKAK02564EA.Col_AddUpSecCode;
					SectionHeader.Visible = true;
                    //SectionFooter.Visible = true;
				}
			}
			else
			{
				// 拠点無
				SectionHeader.DataField = "";
				SectionHeader.Visible = false;
                //SectionFooter.Visible = false;
			}		
			
			// 項目の名称をセット
			//tb_ReportTitle.Text			= this._pageHeaderSubtitle;		   // サブタイトル
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;   // ソート条件
		}
		#endregion ◆ レポート要素出力設定

		#endregion
	
		#region ■ Control Event

        #region ◎ DCKAK02562P_01A4C_ReportStart Event
        /// <summary>
        /// DCKAK02562P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
		/// </remarks>
        private void DCKAK02562P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
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
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString(ExtrInfo_PaymentBalance.ct_DateFomat, DateTime.Now);
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
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
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

			// 拠点オプション有無判定
			if ( this._extrInfo_PaymentBalance.IsOptSection )
			{
                // --- CHG 2008/12/10 --------------------------------------------------------------------->>>>>
                //this._rptExtraHeader.SectionCondition.Text = "計上拠点：" + this.AddUpSecCode.Text + " " + this.tb_AddUpSecName.Text;
                this._rptExtraHeader.SectionCondition.Text = "拠点：" + this.AddUpSecCode.Text + " " + this.tb_AddUpSecName.Text;
                // --- CHG 2008/12/10 ---------------------------------------------------------------------<<<<<
            } 
			else 
			{
				this._rptExtraHeader.SectionCondition.Text = "";
			}

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
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
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
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
		/// <br>Programmer  : 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
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

		#region ◎ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: PageFooterグループのフォーマットイベント。</br>
		/// <br>Programmer	: 20081 疋田　勇人</br>
		/// <br>Date		: 2007.10.03</br>
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
		private DataDynamics.ActiveReports.TextBox tb_SortOrderName;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Label Label86;
		private DataDynamics.ActiveReports.Label Label105;
		private DataDynamics.ActiveReports.Label Label106;
		private DataDynamics.ActiveReports.Label Label107;
		private DataDynamics.ActiveReports.Label Label108;
		private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.Label Label;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label6;
        private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.TextBox tb_AddUpSecName;
		private DataDynamics.ActiveReports.GroupHeader DailyHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcPay;
		private DataDynamics.ActiveReports.Line Line13;
		private DataDynamics.ActiveReports.TextBox ThisTimeStockPrice;
		private DataDynamics.ActiveReports.TextBox LastTimePayment;
		private DataDynamics.ActiveReports.TextBox ThisTimePayNrml;
		private DataDynamics.ActiveReports.Line Line37;
        private DataDynamics.ActiveReports.TextBox AddUpDate;
		private DataDynamics.ActiveReports.TextBox RgdsDisT;
		private DataDynamics.ActiveReports.TextBox OfsThisTimeStock;
		private DataDynamics.ActiveReports.TextBox OfsThisStockTax;
		private DataDynamics.ActiveReports.TextBox ThisNetStckTax;
		private DataDynamics.ActiveReports.TextBox StockTotalPayBalance;
		private DataDynamics.ActiveReports.TextBox StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter DailyFooter;
		private DataDynamics.ActiveReports.Line Line44;
        private DataDynamics.ActiveReports.TextBox tb_SumTitle;
		private DataDynamics.ActiveReports.TextBox Sum_ThisTimeStockPrice;
		private DataDynamics.ActiveReports.TextBox Sum_ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox Sum_RgdsDisT;
		private DataDynamics.ActiveReports.TextBox Sum_OfsThisTimeStock;
		private DataDynamics.ActiveReports.TextBox Sum_OfsThisStockTax;
        private DataDynamics.ActiveReports.TextBox Sum_ThisNetStckTax;
        private DataDynamics.ActiveReports.TextBox Sum_StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKAK02562P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ThisTimeTtlBlcPay = new DataDynamics.ActiveReports.TextBox();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.LastTimePayment = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.AddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.RgdsDisT = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisTimeStock = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.ThisNetStckTax = new DataDynamics.ActiveReports.TextBox();
            this.StockTotalPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label86 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Label108 = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.PayeeSnm = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.PaymentCond = new DataDynamics.ActiveReports.TextBox();
            this.TextBox13 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.PayeeCode = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.SECTOTALTITLE = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.DailyHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DailyFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line44 = new DataDynamics.ActiveReports.Line();
            this.tb_SumTitle = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Sum_RgdsDisT = new DataDynamics.ActiveReports.TextBox();
            this.Sum_OfsThisTimeStock = new DataDynamics.ActiveReports.TextBox();
            this.Sum_OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.Sum_ThisNetStckTax = new DataDynamics.ActiveReports.TextBox();
            this.Sum_StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.ALLTOTALTITLE = new DataDynamics.ActiveReports.Label();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RgdsDisT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisNetStckTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_RgdsDisT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_OfsThisTimeStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ThisNetStckTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ThisTimeTtlBlcPay,
            this.Line13,
            this.ThisTimeStockPrice,
            this.LastTimePayment,
            this.ThisTimePayNrml,
            this.Line37,
            this.AddUpDate,
            this.RgdsDisT,
            this.OfsThisTimeStock,
            this.OfsThisStockTax,
            this.ThisNetStckTax,
            this.StockTotalPayBalance,
            this.StockSlipCount});
            this.Detail.Height = 0.25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            this.ThisTimeTtlBlcPay.Height = 0.15F;
            this.ThisTimeTtlBlcPay.Left = 3.188F;
            this.ThisTimeTtlBlcPay.MultiLine = false;
            this.ThisTimeTtlBlcPay.Name = "ThisTimeTtlBlcPay";
            this.ThisTimeTtlBlcPay.OutputFormat = resources.GetString("ThisTimeTtlBlcPay.OutputFormat");
            this.ThisTimeTtlBlcPay.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.ThisTimeTtlBlcPay.Text = "1,234,567,890";
            this.ThisTimeTtlBlcPay.Top = 0.05F;
            this.ThisTimeTtlBlcPay.Width = 0.875F;
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
            this.Line13.Width = 10.875F;
            this.Line13.X1 = 0F;
            this.Line13.X2 = 10.875F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0F;
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
            this.ThisTimeStockPrice.Height = 0.15F;
            this.ThisTimeStockPrice.Left = 4.125F;
            this.ThisTimeStockPrice.MultiLine = false;
            this.ThisTimeStockPrice.Name = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.OutputFormat = resources.GetString("ThisTimeStockPrice.OutputFormat");
            this.ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.ThisTimeStockPrice.Text = "1,234,567,890";
            this.ThisTimeStockPrice.Top = 0.05F;
            this.ThisTimeStockPrice.Width = 0.875F;
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
            this.LastTimePayment.Height = 0.15F;
            this.LastTimePayment.Left = 1.313F;
            this.LastTimePayment.MultiLine = false;
            this.LastTimePayment.Name = "LastTimePayment";
            this.LastTimePayment.OutputFormat = resources.GetString("LastTimePayment.OutputFormat");
            this.LastTimePayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.LastTimePayment.Text = "1,234,567,890";
            this.LastTimePayment.Top = 0.05F;
            this.LastTimePayment.Width = 0.875F;
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
            this.ThisTimePayNrml.Height = 0.15F;
            this.ThisTimePayNrml.Left = 2.25F;
            this.ThisTimePayNrml.MultiLine = false;
            this.ThisTimePayNrml.Name = "ThisTimePayNrml";
            this.ThisTimePayNrml.OutputFormat = resources.GetString("ThisTimePayNrml.OutputFormat");
            this.ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.ThisTimePayNrml.Text = "1,234,567,890";
            this.ThisTimePayNrml.Top = 0.05F;
            this.ThisTimePayNrml.Width = 0.875F;
            // 
            // Line37
            // 
            this.Line37.Border.BottomColor = System.Drawing.Color.Black;
            this.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.LeftColor = System.Drawing.Color.Black;
            this.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.RightColor = System.Drawing.Color.Black;
            this.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.TopColor = System.Drawing.Color.Black;
            this.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Height = 0F;
            this.Line37.Left = 0F;
            this.Line37.LineWeight = 1F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 0F;
            this.Line37.Width = 10.8F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // AddUpDate
            // 
            this.AddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpDate.DataField = "AddUpDate";
            this.AddUpDate.Height = 0.15F;
            this.AddUpDate.Left = 0.25F;
            this.AddUpDate.MultiLine = false;
            this.AddUpDate.Name = "AddUpDate";
            this.AddUpDate.OutputFormat = resources.GetString("AddUpDate.OutputFormat");
            this.AddUpDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.AddUpDate.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.AddUpDate.Text = "H17.12.31";
            this.AddUpDate.Top = 0.05F;
            this.AddUpDate.Width = 0.75F;
            // 
            // RgdsDisT
            // 
            this.RgdsDisT.Border.BottomColor = System.Drawing.Color.Black;
            this.RgdsDisT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RgdsDisT.Border.LeftColor = System.Drawing.Color.Black;
            this.RgdsDisT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RgdsDisT.Border.RightColor = System.Drawing.Color.Black;
            this.RgdsDisT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RgdsDisT.Border.TopColor = System.Drawing.Color.Black;
            this.RgdsDisT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RgdsDisT.DataField = "RgdsDisT";
            this.RgdsDisT.Height = 0.15F;
            this.RgdsDisT.Left = 5.063F;
            this.RgdsDisT.MultiLine = false;
            this.RgdsDisT.Name = "RgdsDisT";
            this.RgdsDisT.OutputFormat = resources.GetString("RgdsDisT.OutputFormat");
            this.RgdsDisT.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.RgdsDisT.Text = "1,234,567,890";
            this.RgdsDisT.Top = 0.05F;
            this.RgdsDisT.Width = 0.875F;
            // 
            // OfsThisTimeStock
            // 
            this.OfsThisTimeStock.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.DataField = "OfsThisTimeStock";
            this.OfsThisTimeStock.Height = 0.15F;
            this.OfsThisTimeStock.Left = 6F;
            this.OfsThisTimeStock.MultiLine = false;
            this.OfsThisTimeStock.Name = "OfsThisTimeStock";
            this.OfsThisTimeStock.OutputFormat = resources.GetString("OfsThisTimeStock.OutputFormat");
            this.OfsThisTimeStock.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.OfsThisTimeStock.Text = "1,234,567,890";
            this.OfsThisTimeStock.Top = 0.05F;
            this.OfsThisTimeStock.Width = 0.875F;
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
            this.OfsThisStockTax.Height = 0.15F;
            this.OfsThisStockTax.Left = 6.938F;
            this.OfsThisStockTax.MultiLine = false;
            this.OfsThisStockTax.Name = "OfsThisStockTax";
            this.OfsThisStockTax.OutputFormat = resources.GetString("OfsThisStockTax.OutputFormat");
            this.OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.OfsThisStockTax.Text = "1,234,567,890";
            this.OfsThisStockTax.Top = 0.05F;
            this.OfsThisStockTax.Width = 0.875F;
            // 
            // ThisNetStckTax
            // 
            this.ThisNetStckTax.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisNetStckTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisNetStckTax.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisNetStckTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisNetStckTax.Border.RightColor = System.Drawing.Color.Black;
            this.ThisNetStckTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisNetStckTax.Border.TopColor = System.Drawing.Color.Black;
            this.ThisNetStckTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisNetStckTax.DataField = "ThisNetStckTax";
            this.ThisNetStckTax.Height = 0.15F;
            this.ThisNetStckTax.Left = 7.875F;
            this.ThisNetStckTax.MultiLine = false;
            this.ThisNetStckTax.Name = "ThisNetStckTax";
            this.ThisNetStckTax.OutputFormat = resources.GetString("ThisNetStckTax.OutputFormat");
            this.ThisNetStckTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.ThisNetStckTax.Text = "1,234,567,890";
            this.ThisNetStckTax.Top = 0.05F;
            this.ThisNetStckTax.Width = 0.875F;
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
            this.StockTotalPayBalance.Height = 0.15F;
            this.StockTotalPayBalance.Left = 8.813F;
            this.StockTotalPayBalance.MultiLine = false;
            this.StockTotalPayBalance.Name = "StockTotalPayBalance";
            this.StockTotalPayBalance.OutputFormat = resources.GetString("StockTotalPayBalance.OutputFormat");
            this.StockTotalPayBalance.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.StockTotalPayBalance.Text = "1,234,567,890";
            this.StockTotalPayBalance.Top = 0.05F;
            this.StockTotalPayBalance.Width = 0.875F;
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
            this.StockSlipCount.Height = 0.15F;
            this.StockSlipCount.Left = 9.75F;
            this.StockSlipCount.MultiLine = false;
            this.StockSlipCount.Name = "StockSlipCount";
            this.StockSlipCount.OutputFormat = resources.GetString("StockSlipCount.OutputFormat");
            this.StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.StockSlipCount.Text = "234,567";
            this.StockSlipCount.Top = 0.05F;
            this.StockSlipCount.Width = 0.5F;
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
            this.tb_SortOrderName,
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
            this.tb_SortOrderName.Top = 0.0625F;
            this.tb_SortOrderName.Width = 2.0625F;
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
            this.tb_ReportTitle.Text = "支払残高元帳";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.ExtraHeader.Height = 0.2395833F;
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
            this.Header_SubReport.Height = 0.25F;
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
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label86,
            this.Label105,
            this.Label106,
            this.Label107,
            this.Label108,
            this.Line42,
            this.Label,
            this.Label1,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Label7,
            this.Label104,
            this.PayeeSnm,
            this.TextBox12,
            this.PaymentCond,
            this.TextBox13,
            this.TextBox17,
            this.TextBox14,
            this.TextBox18,
            this.TextBox15,
            this.TextBox19,
            this.PayeeCode});
            this.TitleHeader.Height = 0.45F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Label86
            // 
            this.Label86.Border.BottomColor = System.Drawing.Color.Black;
            this.Label86.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.LeftColor = System.Drawing.Color.Black;
            this.Label86.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.RightColor = System.Drawing.Color.Black;
            this.Label86.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Border.TopColor = System.Drawing.Color.Black;
            this.Label86.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label86.Height = 0.15F;
            this.Label86.HyperLink = "";
            this.Label86.Left = 0.25F;
            this.Label86.MultiLine = false;
            this.Label86.Name = "Label86";
            this.Label86.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Label86.Text = "支払日付";
            this.Label86.Top = 0.25F;
            this.Label86.Width = 0.75F;
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
            this.Label105.Height = 0.15F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 1.313F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label105.Text = "前回残高";
            this.Label105.Top = 0.25F;
            this.Label105.Width = 0.875F;
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
            this.Label106.Height = 0.15F;
            this.Label106.HyperLink = "";
            this.Label106.Left = 2.25F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label106.Text = "今回支払額";
            this.Label106.Top = 0.25F;
            this.Label106.Width = 0.875F;
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
            this.Label107.Height = 0.15F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 3.1875F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label107.Text = "繰越残高";
            this.Label107.Top = 0.25F;
            this.Label107.Width = 0.875F;
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
            this.Label108.Height = 0.15F;
            this.Label108.HyperLink = "";
            this.Label108.Left = 4.125F;
            this.Label108.MultiLine = false;
            this.Label108.Name = "Label108";
            this.Label108.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label108.Text = "今回仕入額";
            this.Label108.Top = 0.25F;
            this.Label108.Width = 0.875F;
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
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.15F;
            this.Label.HyperLink = "";
            this.Label.Left = 5.063F;
            this.Label.MultiLine = false;
            this.Label.Name = "Label";
            this.Label.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label.Text = "返品・値引";
            this.Label.Top = 0.25F;
            this.Label.Width = 0.875F;
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
            this.Label1.Height = 0.15F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 6F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label1.Text = "純仕入額";
            this.Label1.Top = 0.25F;
            this.Label1.Width = 0.875F;
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
            this.Label4.Height = 0.15F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 6.9375F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label4.Text = "消費税";
            this.Label4.Top = 0.25F;
            this.Label4.Width = 0.875F;
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
            this.Label5.Height = 0.15F;
            this.Label5.HyperLink = "";
            this.Label5.Left = 7.875F;
            this.Label5.MultiLine = false;
            this.Label5.Name = "Label5";
            this.Label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label5.Text = "税込仕入額";
            this.Label5.Top = 0.25F;
            this.Label5.Width = 0.875F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.15F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 8.8125F;
            this.Label6.MultiLine = false;
            this.Label6.Name = "Label6";
            this.Label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label6.Text = "今回残高";
            this.Label6.Top = 0.25F;
            this.Label6.Width = 0.875F;
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
            this.Label7.Height = 0.15F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 9.75F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label7.Text = "伝票枚数";
            this.Label7.Top = 0.25F;
            this.Label7.Width = 0.5F;
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
            this.Label104.Height = 0.15F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0.125F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Label104.Text = "仕入先";
            this.Label104.Top = 0.05F;
            this.Label104.Width = 0.375F;
            // 
            // PayeeSnm
            // 
            this.PayeeSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.DataField = "PayeeSnm";
            this.PayeeSnm.Height = 0.15F;
            this.PayeeSnm.Left = 1F;
            this.PayeeSnm.MultiLine = false;
            this.PayeeSnm.Name = "PayeeSnm";
            this.PayeeSnm.OutputFormat = resources.GetString("PayeeSnm.OutputFormat");
            this.PayeeSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.PayeeSnm.Text = "＊＊＊＊＊＊＊＊＊１＊＊＊＊＊＊＊＊＊２";
            this.PayeeSnm.Top = 0.05F;
            this.PayeeSnm.Width = 2.25F;
            // 
            // TextBox12
            // 
            this.TextBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Height = 0.15F;
            this.TextBox12.Left = 3.375F;
            this.TextBox12.MultiLine = false;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat");
            this.TextBox12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.TextBox12.Text = "支払条件";
            this.TextBox12.Top = 0.05F;
            this.TextBox12.Width = 0.5F;
            // 
            // PaymentCond
            // 
            this.PaymentCond.Border.BottomColor = System.Drawing.Color.Black;
            this.PaymentCond.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentCond.Border.LeftColor = System.Drawing.Color.Black;
            this.PaymentCond.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentCond.Border.RightColor = System.Drawing.Color.Black;
            this.PaymentCond.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentCond.Border.TopColor = System.Drawing.Color.Black;
            this.PaymentCond.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PaymentCond.DataField = "PaymentCond";
            this.PaymentCond.Height = 0.15F;
            this.PaymentCond.Left = 3.938F;
            this.PaymentCond.MultiLine = false;
            this.PaymentCond.Name = "PaymentCond";
            this.PaymentCond.OutputFormat = resources.GetString("PaymentCond.OutputFormat");
            this.PaymentCond.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.PaymentCond.Text = "１２３４";
            this.PaymentCond.Top = 0.05F;
            this.PaymentCond.Width = 0.5F;
            // 
            // TextBox13
            // 
            this.TextBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Height = 0.15F;
            this.TextBox13.Left = 4.563F;
            this.TextBox13.MultiLine = false;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat");
            this.TextBox13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.TextBox13.Text = "締日";
            this.TextBox13.Top = 0.05F;
            this.TextBox13.Width = 0.313F;
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
            this.TextBox17.DataField = "PaymentTotalDay";
            this.TextBox17.Height = 0.15F;
            this.TextBox17.Left = 4.938F;
            this.TextBox17.MultiLine = false;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.TextBox17.Text = "12";
            this.TextBox17.Top = 0.05F;
            this.TextBox17.Width = 0.25F;
            // 
            // TextBox14
            // 
            this.TextBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Height = 0.15F;
            this.TextBox14.Left = 5.313F;
            this.TextBox14.MultiLine = false;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat");
            this.TextBox14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.TextBox14.Text = "支払月";
            this.TextBox14.Top = 0.05F;
            this.TextBox14.Width = 0.438F;
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
            this.TextBox18.DataField = "PaymentMonthName";
            this.TextBox18.Height = 0.15F;
            this.TextBox18.Left = 5.813F;
            this.TextBox18.MultiLine = false;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.TextBox18.Text = "123456789012345678901234567890";
            this.TextBox18.Top = 0.05F;
            this.TextBox18.Width = 0.5F;
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
            this.TextBox15.Height = 0.15F;
            this.TextBox15.Left = 6.438F;
            this.TextBox15.MultiLine = false;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.TextBox15.Text = "支払日";
            this.TextBox15.Top = 0.05F;
            this.TextBox15.Width = 0.438F;
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
            this.TextBox19.DataField = "PaymentDay";
            this.TextBox19.Height = 0.15F;
            this.TextBox19.Left = 6.938F;
            this.TextBox19.MultiLine = false;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.OutputFormat = resources.GetString("TextBox19.OutputFormat");
            this.TextBox19.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: middle; ";
            this.TextBox19.Text = "12";
            this.TextBox19.Top = 0.05F;
            this.TextBox19.Width = 0.25F;
            // 
            // PayeeCode
            // 
            this.PayeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.DataField = "PayeeCode";
            this.PayeeCode.Height = 0.15F;
            this.PayeeCode.Left = 0.563F;
            this.PayeeCode.MultiLine = false;
            this.PayeeCode.Name = "PayeeCode";
            this.PayeeCode.OutputFormat = resources.GetString("PayeeCode.OutputFormat");
            this.PayeeCode.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: middle; ";
            this.PayeeCode.Text = "123456";
            this.PayeeCode.Top = 0.05F;
            this.PayeeCode.Width = 0.375F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_AddUpSecName,
            this.AddUpSecCode});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.Visible = false;
            // 
            // tb_AddUpSecName
            // 
            this.tb_AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.CanShrink = true;
            this.tb_AddUpSecName.DataField = "AddUpSecName";
            this.tb_AddUpSecName.Height = 0.15F;
            this.tb_AddUpSecName.Left = 1.5F;
            this.tb_AddUpSecName.MultiLine = false;
            this.tb_AddUpSecName.Name = "tb_AddUpSecName";
            this.tb_AddUpSecName.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_AddUpSecName.Text = null;
            this.tb_AddUpSecName.Top = 0F;
            this.tb_AddUpSecName.Visible = false;
            this.tb_AddUpSecName.Width = 0.75F;
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.DataField = "AddUpSecCode";
            this.AddUpSecCode.Height = 0.125F;
            this.AddUpSecCode.Left = 0.5625F;
            this.AddUpSecCode.MultiLine = false;
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.OutputFormat = resources.GetString("AddUpSecCode.OutputFormat");
            this.AddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.AddUpSecCode.Text = "123456";
            this.AddUpSecCode.Top = 0F;
            this.AddUpSecCode.Visible = false;
            this.AddUpSecCode.Width = 0.375F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.SECTOTALTITLE,
            this.textBox2,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox10});
            this.SectionFooter.Height = 0.3F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.Visible = false;
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
            this.SECTOTALTITLE.Height = 0.2F;
            this.SECTOTALTITLE.Left = 0.125F;
            this.SECTOTALTITLE.MultiLine = false;
            this.SECTOTALTITLE.Name = "SECTOTALTITLE";
            this.SECTOTALTITLE.OutputFormat = resources.GetString("SECTOTALTITLE.OutputFormat");
            this.SECTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.SECTOTALTITLE.Text = "拠点計";
            this.SECTOTALTITLE.Top = 0.05F;
            this.SECTOTALTITLE.Width = 0.563F;
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
            this.textBox2.DataField = "ThisTimePayNrml";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 2.25F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox2.SummaryGroup = "SectionHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "1,234,567,890";
            this.textBox2.Top = 0.05F;
            this.textBox2.Width = 0.875F;
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
            this.textBox4.DataField = "ThisTimeStockPrice";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 4.125F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox4.SummaryGroup = "SectionHeader";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "1,234,567,890";
            this.textBox4.Top = 0.05F;
            this.textBox4.Width = 0.875F;
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
            this.textBox5.DataField = "RgdsDisT";
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 5.063F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox5.SummaryGroup = "SectionHeader";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "1,234,567,890";
            this.textBox5.Top = 0.05F;
            this.textBox5.Width = 0.875F;
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
            this.textBox6.DataField = "OfsThisTimeStock";
            this.textBox6.Height = 0.2F;
            this.textBox6.Left = 6F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox6.SummaryGroup = "SectionHeader";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "1,234,567,890";
            this.textBox6.Top = 0.05F;
            this.textBox6.Width = 0.875F;
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
            this.textBox7.DataField = "OfsThisStockTax";
            this.textBox7.Height = 0.2F;
            this.textBox7.Left = 6.938F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox7.SummaryGroup = "SectionHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "1,234,567,890";
            this.textBox7.Top = 0.05F;
            this.textBox7.Width = 0.875F;
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
            this.textBox8.DataField = "ThisNetStckTax";
            this.textBox8.Height = 0.2F;
            this.textBox8.Left = 7.875F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox8.SummaryGroup = "SectionHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "1,234,567,890";
            this.textBox8.Top = 0.05F;
            this.textBox8.Width = 0.875F;
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
            this.textBox10.DataField = "StockSlipCount";
            this.textBox10.Height = 0.2F;
            this.textBox10.Left = 9.75F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox10.SummaryGroup = "SectionHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "234,567";
            this.textBox10.Top = 0.05F;
            this.textBox10.Width = 0.5F;
            // 
            // DailyHeader
            // 
            this.DailyHeader.CanShrink = true;
            this.DailyHeader.DataField = "PayeeCode";
            this.DailyHeader.Height = 0F;
            this.DailyHeader.Name = "DailyHeader";
            this.DailyHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // DailyFooter
            // 
            this.DailyFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line44,
            this.tb_SumTitle,
            this.Sum_ThisTimeStockPrice,
            this.Sum_ThisTimePayNrml,
            this.Sum_RgdsDisT,
            this.Sum_OfsThisTimeStock,
            this.Sum_OfsThisStockTax,
            this.Sum_ThisNetStckTax,
            this.Sum_StockSlipCount});
            this.DailyFooter.Height = 0.3F;
            this.DailyFooter.KeepTogether = true;
            this.DailyFooter.Name = "DailyFooter";
            // 
            // Line44
            // 
            this.Line44.Border.BottomColor = System.Drawing.Color.Black;
            this.Line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.LeftColor = System.Drawing.Color.Black;
            this.Line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.RightColor = System.Drawing.Color.Black;
            this.Line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Border.TopColor = System.Drawing.Color.Black;
            this.Line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line44.Height = 0F;
            this.Line44.Left = 0F;
            this.Line44.LineWeight = 2F;
            this.Line44.Name = "Line44";
            this.Line44.Top = 0F;
            this.Line44.Width = 10.8F;
            this.Line44.X1 = 0F;
            this.Line44.X2 = 10.8F;
            this.Line44.Y1 = 0F;
            this.Line44.Y2 = 0F;
            // 
            // tb_SumTitle
            // 
            this.tb_SumTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SumTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SumTitle.Height = 0.2F;
            this.tb_SumTitle.Left = 0.125F;
            this.tb_SumTitle.MultiLine = false;
            this.tb_SumTitle.Name = "tb_SumTitle";
            this.tb_SumTitle.OutputFormat = resources.GetString("tb_SumTitle.OutputFormat");
            this.tb_SumTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_SumTitle.Text = "仕入先計";
            this.tb_SumTitle.Top = 0.05F;
            this.tb_SumTitle.Width = 0.688F;
            // 
            // Sum_ThisTimeStockPrice
            // 
            this.Sum_ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.Sum_ThisTimeStockPrice.Height = 0.2F;
            this.Sum_ThisTimeStockPrice.Left = 4.125F;
            this.Sum_ThisTimeStockPrice.MultiLine = false;
            this.Sum_ThisTimeStockPrice.Name = "Sum_ThisTimeStockPrice";
            this.Sum_ThisTimeStockPrice.OutputFormat = resources.GetString("Sum_ThisTimeStockPrice.OutputFormat");
            this.Sum_ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_ThisTimeStockPrice.SummaryGroup = "DailyHeader";
            this.Sum_ThisTimeStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ThisTimeStockPrice.Text = "1,234,567,890";
            this.Sum_ThisTimeStockPrice.Top = 0.05F;
            this.Sum_ThisTimeStockPrice.Width = 0.875F;
            // 
            // Sum_ThisTimePayNrml
            // 
            this.Sum_ThisTimePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ThisTimePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ThisTimePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ThisTimePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ThisTimePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisTimePayNrml.DataField = "ThisTimePayNrml";
            this.Sum_ThisTimePayNrml.Height = 0.2F;
            this.Sum_ThisTimePayNrml.Left = 2.25F;
            this.Sum_ThisTimePayNrml.MultiLine = false;
            this.Sum_ThisTimePayNrml.Name = "Sum_ThisTimePayNrml";
            this.Sum_ThisTimePayNrml.OutputFormat = resources.GetString("Sum_ThisTimePayNrml.OutputFormat");
            this.Sum_ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_ThisTimePayNrml.SummaryGroup = "DailyHeader";
            this.Sum_ThisTimePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ThisTimePayNrml.Text = "1,234,567,890";
            this.Sum_ThisTimePayNrml.Top = 0.05F;
            this.Sum_ThisTimePayNrml.Width = 0.875F;
            // 
            // Sum_RgdsDisT
            // 
            this.Sum_RgdsDisT.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_RgdsDisT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_RgdsDisT.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_RgdsDisT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_RgdsDisT.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_RgdsDisT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_RgdsDisT.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_RgdsDisT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_RgdsDisT.DataField = "RgdsDisT";
            this.Sum_RgdsDisT.Height = 0.2F;
            this.Sum_RgdsDisT.Left = 5.063F;
            this.Sum_RgdsDisT.MultiLine = false;
            this.Sum_RgdsDisT.Name = "Sum_RgdsDisT";
            this.Sum_RgdsDisT.OutputFormat = resources.GetString("Sum_RgdsDisT.OutputFormat");
            this.Sum_RgdsDisT.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_RgdsDisT.SummaryGroup = "DailyHeader";
            this.Sum_RgdsDisT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_RgdsDisT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_RgdsDisT.Text = "1,234,567,890";
            this.Sum_RgdsDisT.Top = 0.05F;
            this.Sum_RgdsDisT.Width = 0.875F;
            // 
            // Sum_OfsThisTimeStock
            // 
            this.Sum_OfsThisTimeStock.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_OfsThisTimeStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisTimeStock.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_OfsThisTimeStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisTimeStock.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_OfsThisTimeStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisTimeStock.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_OfsThisTimeStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisTimeStock.DataField = "OfsThisTimeStock";
            this.Sum_OfsThisTimeStock.Height = 0.2F;
            this.Sum_OfsThisTimeStock.Left = 6F;
            this.Sum_OfsThisTimeStock.MultiLine = false;
            this.Sum_OfsThisTimeStock.Name = "Sum_OfsThisTimeStock";
            this.Sum_OfsThisTimeStock.OutputFormat = resources.GetString("Sum_OfsThisTimeStock.OutputFormat");
            this.Sum_OfsThisTimeStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_OfsThisTimeStock.SummaryGroup = "DailyHeader";
            this.Sum_OfsThisTimeStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_OfsThisTimeStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_OfsThisTimeStock.Text = "1,234,567,890";
            this.Sum_OfsThisTimeStock.Top = 0.05F;
            this.Sum_OfsThisTimeStock.Width = 0.875F;
            // 
            // Sum_OfsThisStockTax
            // 
            this.Sum_OfsThisStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_OfsThisStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_OfsThisStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_OfsThisStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_OfsThisStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_OfsThisStockTax.DataField = "OfsThisStockTax";
            this.Sum_OfsThisStockTax.Height = 0.2F;
            this.Sum_OfsThisStockTax.Left = 6.938F;
            this.Sum_OfsThisStockTax.MultiLine = false;
            this.Sum_OfsThisStockTax.Name = "Sum_OfsThisStockTax";
            this.Sum_OfsThisStockTax.OutputFormat = resources.GetString("Sum_OfsThisStockTax.OutputFormat");
            this.Sum_OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_OfsThisStockTax.SummaryGroup = "DailyHeader";
            this.Sum_OfsThisStockTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_OfsThisStockTax.Text = "1,234,567,890";
            this.Sum_OfsThisStockTax.Top = 0.05F;
            this.Sum_OfsThisStockTax.Width = 0.875F;
            // 
            // Sum_ThisNetStckTax
            // 
            this.Sum_ThisNetStckTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_ThisNetStckTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisNetStckTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_ThisNetStckTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisNetStckTax.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_ThisNetStckTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisNetStckTax.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_ThisNetStckTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_ThisNetStckTax.DataField = "ThisNetStckTax";
            this.Sum_ThisNetStckTax.Height = 0.2F;
            this.Sum_ThisNetStckTax.Left = 7.875F;
            this.Sum_ThisNetStckTax.MultiLine = false;
            this.Sum_ThisNetStckTax.Name = "Sum_ThisNetStckTax";
            this.Sum_ThisNetStckTax.OutputFormat = resources.GetString("Sum_ThisNetStckTax.OutputFormat");
            this.Sum_ThisNetStckTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_ThisNetStckTax.SummaryGroup = "DailyHeader";
            this.Sum_ThisNetStckTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_ThisNetStckTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_ThisNetStckTax.Text = "1,234,567,890";
            this.Sum_ThisNetStckTax.Top = 0.05F;
            this.Sum_ThisNetStckTax.Width = 0.875F;
            // 
            // Sum_StockSlipCount
            // 
            this.Sum_StockSlipCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Sum_StockSlipCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_StockSlipCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Sum_StockSlipCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_StockSlipCount.Border.RightColor = System.Drawing.Color.Black;
            this.Sum_StockSlipCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_StockSlipCount.Border.TopColor = System.Drawing.Color.Black;
            this.Sum_StockSlipCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sum_StockSlipCount.DataField = "StockSlipCount";
            this.Sum_StockSlipCount.Height = 0.2F;
            this.Sum_StockSlipCount.Left = 9.75F;
            this.Sum_StockSlipCount.MultiLine = false;
            this.Sum_StockSlipCount.Name = "Sum_StockSlipCount";
            this.Sum_StockSlipCount.OutputFormat = resources.GetString("Sum_StockSlipCount.OutputFormat");
            this.Sum_StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.Sum_StockSlipCount.SummaryGroup = "DailyHeader";
            this.Sum_StockSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Sum_StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Sum_StockSlipCount.Text = "234,567";
            this.Sum_StockSlipCount.Top = 0.05F;
            this.Sum_StockSlipCount.Width = 0.5F;
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
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.ALLTOTALTITLE,
            this.textBox16,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox27});
            this.GrandTotalFooter.Height = 0.3F;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Visible = false;
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
            this.ALLTOTALTITLE.Height = 0.2F;
            this.ALLTOTALTITLE.HyperLink = "";
            this.ALLTOTALTITLE.Left = 0.125F;
            this.ALLTOTALTITLE.MultiLine = false;
            this.ALLTOTALTITLE.Name = "ALLTOTALTITLE";
            this.ALLTOTALTITLE.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.ALLTOTALTITLE.Text = "総合計";
            this.ALLTOTALTITLE.Top = 0.05F;
            this.ALLTOTALTITLE.Width = 0.563F;
            // 
            // textBox16
            // 
            this.textBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.RightColor = System.Drawing.Color.Black;
            this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.TopColor = System.Drawing.Color.Black;
            this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.DataField = "ThisTimePayNrml";
            this.textBox16.Height = 0.2F;
            this.textBox16.Left = 2.25F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox16.Text = "1,234,567,890";
            this.textBox16.Top = 0.05F;
            this.textBox16.Width = 0.875F;
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
            this.textBox21.DataField = "ThisTimeStockPrice";
            this.textBox21.Height = 0.2F;
            this.textBox21.Left = 4.125F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox21.Text = "1,234,567,890";
            this.textBox21.Top = 0.05F;
            this.textBox21.Width = 0.875F;
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
            this.textBox22.DataField = "RgdsDisT";
            this.textBox22.Height = 0.2F;
            this.textBox22.Left = 5.063F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox22.Text = "1,234,567,890";
            this.textBox22.Top = 0.05F;
            this.textBox22.Width = 0.875F;
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
            this.textBox23.DataField = "OfsThisTimeStock";
            this.textBox23.Height = 0.2F;
            this.textBox23.Left = 6F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox23.Text = "1,234,567,890";
            this.textBox23.Top = 0.05F;
            this.textBox23.Width = 0.875F;
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
            this.textBox24.DataField = "OfsThisStockTax";
            this.textBox24.Height = 0.2F;
            this.textBox24.Left = 6.938F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox24.Text = "1,234,567,890";
            this.textBox24.Top = 0.05F;
            this.textBox24.Width = 0.875F;
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
            this.textBox25.DataField = "ThisNetStckTax";
            this.textBox25.Height = 0.2F;
            this.textBox25.Left = 7.875F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox25.Text = "1,234,567,890";
            this.textBox25.Top = 0.05F;
            this.textBox25.Width = 0.875F;
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
            this.textBox27.DataField = "StockSlipCount";
            this.textBox27.Height = 0.2F;
            this.textBox27.Left = 9.75F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: middle; ";
            this.textBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox27.Text = "234,567";
            this.textBox27.Top = 0.05F;
            this.textBox27.Width = 0.5F;
            // 
            // DCKAK02562P_01A4C
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
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.DailyHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.DailyFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.DCKAK02562P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RgdsDisT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisNetStckTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label86)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label108)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SECTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SumTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_RgdsDisT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_OfsThisTimeStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_ThisNetStckTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sum_StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALLTOTALTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

	}
}
