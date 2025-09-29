//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタインポート・エクスポートエラーリスト
// プログラム概要   : 掛率マスタインポート・エクスポートエラーリスト印刷フォームクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using System.Drawing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
    /// 掛率マスタインポート・エクスポートエラーリスト印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 掛率マスタインポート・エクスポートエラーリストのフォームクラスです。</br>
    /// <br>Programmer	: FSI菅原 庸平</br>
    /// <br>Date        : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
	public class PMKHN09823P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 掛率マスタインポート・エクスポートエラーリストフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 掛率マスタインポート・エクスポートエラーリストフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
		/// </remarks>
		public PMKHN09823P_01A4C()
		{
			InitializeComponent();
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

		// その他データ格納項目
		private string				 _detailAddupSecNameTtl;		// 明細拠点名称タイトル
		private int					 _printCount;					// ページ数カウント用
        private string               _secCodeBuf;                   // 拠点コードの重複入力回避用
        private string               _depositDateBuf;               // 入金日付の重複入力回避用

		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
        ListCommon_PageFooter _rptPageFooter = null;
        private GroupHeader AgentHeader;
        private GroupFooter AgentFooter;
        private Label Label_CheckDeposit;
        private Label Label_ErrorNote;
        private TextBox CheckDeposit;
        private TextBox ErrorNote;
        private Label label_SecCode;
        private Line line2;
        private Label label_DraftDeposit;
        private TextBox SecCode;
        private TextBox DepositSlipNum;
        private TextBox DraftDeposit;

		// Disposeチェック用フラグ
		bool disposed = false;

        private TextBox DepositDate;
        private Label Label_DepositDate;
        private Label label_DepositSlipNum;
        private Label label_CustomerCode;
        private TextBox CashDeposit;
        private Label label_CashDeposit;
        private TextBox TransferDeposit;
        private Label label_TransferDeposit;
        private Label label_FeeDeposit;
        private Label label3;
        private Label label_DiscountDeposit;
        private Label label_OtherDeposit;
        private Label label_DebitAmount;
        private Label label_FactoringDeposit;
        private Label label_BankCode;
        private TextBox FeeDeposit;
        private TextBox OffsetDeposit;
        private TextBox DiscountDeposit;
        private TextBox OtherDeposit;
        private TextBox DebitAmount;
        private TextBox FactoringDeposit;
        private TextBox BankCode;
        private TextBox CustomerCode;

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
				return 0;
			}
			set
			{
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
		/// <br>Note        : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
            this._printCount = 0;
		}
		#endregion

		#endregion

		#region ■ Control Event
        #region ◆ PMKHN09823P_01A4C_ReportStart Event
        /// <summary>
        /// PMKHN09823P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : レポートの設定をするイベントです。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
		/// </remarks>
        private void PMKHN09823P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();
        }
        #endregion ◆ PMKHN09823P_01A4C_ReportStart Event

        #region ◆ PageHeader_Format Event
        /// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ページヘッダーグループの初期化イベントです。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");
        }
		#endregion ◆ PageHeader_Format Event

        #region ◆ TitleHeader_Before Event
        /// <summary>
        /// TitleHeader_Before Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ページヘッダーグループの初期化イベントです。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// </remarks>
        private void TitleHeader_BeforePrint(object sender, System.EventArgs eArgs)
        {
            _depositDateBuf = string.Empty;
            _secCodeBuf = string.Empty;
        }
        #endregion ◆ TitleHeader_Before Event

        #region ◆ Detail_BeforePrint Event
        /// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
            // 前行の拠点コードと一致している場合は表示しない
            // 拠点コード文字列が3文字以上の場合は「**」と表示(PM7相当)
            if (SecCode.Text != _secCodeBuf)
            {
                _secCodeBuf = SecCode.Text;
                SecCode.Visible = true;

                if (SecCode.Text.Length > 2)
                {
                    SecCode.Text = "**";
                }
            }
            else
            {
                SecCode.Visible = false;
            }

            // 全行の入金日付と一致している場合は表示しない
            if (DepositDate.Text != _depositDateBuf)
            {
                DepositDate.Visible = true;
                _depositDateBuf = DepositDate.Text;
            }
            else
            {
                DepositDate.Visible = false;
            }
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
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
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

		#region ◆ PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : PageFooter_Formatグループの初期化イベントです。</br>
        /// <br>Programmer	: FSI菅原 庸平</br>
        /// <br>Date        : 2013/06/12</br>
        /// <br></br>
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
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
        private DataDynamics.ActiveReports.TextBox tb_PrintTime;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// InitializeComponent
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09823P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SecCode = new DataDynamics.ActiveReports.TextBox();
            this.DepositSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.CheckDeposit = new DataDynamics.ActiveReports.TextBox();
            this.ErrorNote = new DataDynamics.ActiveReports.TextBox();
            this.DraftDeposit = new DataDynamics.ActiveReports.TextBox();
            this.DepositDate = new DataDynamics.ActiveReports.TextBox();
            this.CashDeposit = new DataDynamics.ActiveReports.TextBox();
            this.TransferDeposit = new DataDynamics.ActiveReports.TextBox();
            this.FeeDeposit = new DataDynamics.ActiveReports.TextBox();
            this.OffsetDeposit = new DataDynamics.ActiveReports.TextBox();
            this.DiscountDeposit = new DataDynamics.ActiveReports.TextBox();
            this.OtherDeposit = new DataDynamics.ActiveReports.TextBox();
            this.DebitAmount = new DataDynamics.ActiveReports.TextBox();
            this.FactoringDeposit = new DataDynamics.ActiveReports.TextBox();
            this.BankCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Label_DepositDate = new DataDynamics.ActiveReports.Label();
            this.Label_CheckDeposit = new DataDynamics.ActiveReports.Label();
            this.Label_ErrorNote = new DataDynamics.ActiveReports.Label();
            this.label_SecCode = new DataDynamics.ActiveReports.Label();
            this.label_DraftDeposit = new DataDynamics.ActiveReports.Label();
            this.label_DepositSlipNum = new DataDynamics.ActiveReports.Label();
            this.label_CustomerCode = new DataDynamics.ActiveReports.Label();
            this.label_CashDeposit = new DataDynamics.ActiveReports.Label();
            this.label_TransferDeposit = new DataDynamics.ActiveReports.Label();
            this.label_FeeDeposit = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label_DiscountDeposit = new DataDynamics.ActiveReports.Label();
            this.label_OtherDeposit = new DataDynamics.ActiveReports.Label();
            this.label_DebitAmount = new DataDynamics.ActiveReports.Label();
            this.label_FactoringDeposit = new DataDynamics.ActiveReports.Label();
            this.label_BankCode = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.AgentHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.AgentFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.SecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeeDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoringDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_DepositDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CheckDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_ErrorNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_SecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DraftDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DepositSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_CashDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_TransferDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_FeeDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DiscountDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_OtherDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DebitAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_FactoringDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_BankCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SecCode,
            this.DepositSlipNum,
            this.CheckDeposit,
            this.ErrorNote,
            this.DraftDeposit,
            this.DepositDate,
            this.CashDeposit,
            this.TransferDeposit,
            this.FeeDeposit,
            this.OffsetDeposit,
            this.DiscountDeposit,
            this.OtherDeposit,
            this.DebitAmount,
            this.FactoringDeposit,
            this.BankCode,
            this.CustomerCode});
            this.Detail.Height = 0.188F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // SecCode
            // 
            this.SecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecCode.Border.RightColor = System.Drawing.Color.Black;
            this.SecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecCode.Border.TopColor = System.Drawing.Color.Black;
            this.SecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SecCode.DataField = "SecCode";
            this.SecCode.Height = 0.188F;
            this.SecCode.Left = 0.0615F;
            this.SecCode.MultiLine = false;
            this.SecCode.Name = "SecCode";
            this.SecCode.Style = "ddo-char-set: 1; text-align: center; font-size: 6pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SecCode.Text = "NN";
            this.SecCode.Top = 0F;
            this.SecCode.Width = 0.123F;
            // 
            // DepositSlipNum
            // 
            this.DepositSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.DepositSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.DepositSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositSlipNum.DataField = "DepositSlipNum";
            this.DepositSlipNum.Height = 0.188F;
            this.DepositSlipNum.Left = 0.75F;
            this.DepositSlipNum.MultiLine = false;
            this.DepositSlipNum.Name = "DepositSlipNum";
            this.DepositSlipNum.Style = "ddo-char-set: 1; text-align: center; font-size: 6pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DepositSlipNum.Text = "999999";
            this.DepositSlipNum.Top = 0F;
            this.DepositSlipNum.Width = 0.42F;
            // 
            // CheckDeposit
            // 
            this.CheckDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.CheckDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.CheckDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckDeposit.DataField = "CheckDeposit";
            this.CheckDeposit.Height = 0.188F;
            this.CheckDeposit.Left = 2.947F;
            this.CheckDeposit.MultiLine = false;
            this.CheckDeposit.Name = "CheckDeposit";
            this.CheckDeposit.OutputFormat = resources.GetString("CheckDeposit.OutputFormat");
            this.CheckDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.CheckDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.CheckDeposit.Top = 0F;
            this.CheckDeposit.Width = 0.676F;
            // 
            // ErrorNote
            // 
            this.ErrorNote.Border.BottomColor = System.Drawing.Color.Black;
            this.ErrorNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorNote.Border.LeftColor = System.Drawing.Color.Black;
            this.ErrorNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorNote.Border.RightColor = System.Drawing.Color.Black;
            this.ErrorNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorNote.Border.TopColor = System.Drawing.Color.Black;
            this.ErrorNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErrorNote.DataField = "ErrorNote";
            this.ErrorNote.Height = 0.188F;
            this.ErrorNote.Left = 8.718F;
            this.ErrorNote.Name = "ErrorNote";
            this.ErrorNote.Style = "ddo-char-set: 1; text-align: left; font-size: 6pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.ErrorNote.Text = "商品ｺｰﾄﾞ(未入力）、品名表示未入力、仕切価格ﾏｲﾅｽ、ﾒｰｶｰ参考卸価格ﾏｲﾅｽ";
            this.ErrorNote.Top = 0F;
            this.ErrorNote.Width = 2.06F;
            // 
            // DraftDeposit
            // 
            this.DraftDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.DraftDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.DraftDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.DraftDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.DraftDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftDeposit.DataField = "DraftDeposit";
            this.DraftDeposit.Height = 0.188F;
            this.DraftDeposit.Left = 3.633F;
            this.DraftDeposit.MultiLine = false;
            this.DraftDeposit.Name = "DraftDeposit";
            this.DraftDeposit.OutputFormat = resources.GetString("DraftDeposit.OutputFormat");
            this.DraftDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.DraftDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.DraftDeposit.Top = 0F;
            this.DraftDeposit.Width = 0.676F;
            // 
            // DepositDate
            // 
            this.DepositDate.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositDate.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositDate.Border.RightColor = System.Drawing.Color.Black;
            this.DepositDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositDate.Border.TopColor = System.Drawing.Color.Black;
            this.DepositDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositDate.DataField = "DepositDate";
            this.DepositDate.Height = 0.188F;
            this.DepositDate.Left = 0.215F;
            this.DepositDate.MultiLine = false;
            this.DepositDate.Name = "DepositDate";
            this.DepositDate.Style = "ddo-char-set: 1; text-align: center; font-size: 6pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.DepositDate.Text = "YYYY/MM/DD";
            this.DepositDate.Top = 0F;
            this.DepositDate.Width = 0.492F;
            // 
            // CashDeposit
            // 
            this.CashDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.CashDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.CashDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.CashDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.CashDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CashDeposit.DataField = "CashDeposit";
            this.CashDeposit.Height = 0.188F;
            this.CashDeposit.Left = 1.575F;
            this.CashDeposit.MultiLine = false;
            this.CashDeposit.Name = "CashDeposit";
            this.CashDeposit.OutputFormat = resources.GetString("CashDeposit.OutputFormat");
            this.CashDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.CashDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.CashDeposit.Top = 0F;
            this.CashDeposit.Width = 0.676F;
            // 
            // TransferDeposit
            // 
            this.TransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.TransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.TransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.TransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.TransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TransferDeposit.DataField = "TransferDeposit";
            this.TransferDeposit.Height = 0.188F;
            this.TransferDeposit.Left = 2.261F;
            this.TransferDeposit.MultiLine = false;
            this.TransferDeposit.Name = "TransferDeposit";
            this.TransferDeposit.OutputFormat = resources.GetString("TransferDeposit.OutputFormat");
            this.TransferDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.TransferDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.TransferDeposit.Top = 0F;
            this.TransferDeposit.Width = 0.676F;
            // 
            // FeeDeposit
            // 
            this.FeeDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.FeeDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeeDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.FeeDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeeDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.FeeDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeeDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.FeeDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FeeDeposit.DataField = "FeeDeposit";
            this.FeeDeposit.Height = 0.188F;
            this.FeeDeposit.Left = 4.319F;
            this.FeeDeposit.MultiLine = false;
            this.FeeDeposit.Name = "FeeDeposit";
            this.FeeDeposit.OutputFormat = resources.GetString("FeeDeposit.OutputFormat");
            this.FeeDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.FeeDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.FeeDeposit.Top = 0F;
            this.FeeDeposit.Width = 0.676F;
            // 
            // OffsetDeposit
            // 
            this.OffsetDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.OffsetDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.OffsetDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.OffsetDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.OffsetDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OffsetDeposit.DataField = "OffsetDeposit";
            this.OffsetDeposit.Height = 0.188F;
            this.OffsetDeposit.Left = 5.005F;
            this.OffsetDeposit.MultiLine = false;
            this.OffsetDeposit.Name = "OffsetDeposit";
            this.OffsetDeposit.OutputFormat = resources.GetString("OffsetDeposit.OutputFormat");
            this.OffsetDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.OffsetDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.OffsetDeposit.Top = 0F;
            this.OffsetDeposit.Width = 0.676F;
            // 
            // DiscountDeposit
            // 
            this.DiscountDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.DiscountDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.DiscountDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.DiscountDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.DiscountDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DiscountDeposit.DataField = "DiscountDeposit";
            this.DiscountDeposit.Height = 0.188F;
            this.DiscountDeposit.Left = 5.691F;
            this.DiscountDeposit.MultiLine = false;
            this.DiscountDeposit.Name = "DiscountDeposit";
            this.DiscountDeposit.OutputFormat = resources.GetString("DiscountDeposit.OutputFormat");
            this.DiscountDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.DiscountDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.DiscountDeposit.Top = 0F;
            this.DiscountDeposit.Width = 0.676F;
            // 
            // OtherDeposit
            // 
            this.OtherDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.OtherDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OtherDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.OtherDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OtherDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.OtherDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OtherDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.OtherDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OtherDeposit.DataField = "OtherDeposit";
            this.OtherDeposit.Height = 0.188F;
            this.OtherDeposit.Left = 6.377F;
            this.OtherDeposit.MultiLine = false;
            this.OtherDeposit.Name = "OtherDeposit";
            this.OtherDeposit.OutputFormat = resources.GetString("OtherDeposit.OutputFormat");
            this.OtherDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.OtherDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.OtherDeposit.Top = 0F;
            this.OtherDeposit.Width = 0.676F;
            // 
            // DebitAmount
            // 
            this.DebitAmount.Border.BottomColor = System.Drawing.Color.Black;
            this.DebitAmount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DebitAmount.Border.LeftColor = System.Drawing.Color.Black;
            this.DebitAmount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DebitAmount.Border.RightColor = System.Drawing.Color.Black;
            this.DebitAmount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DebitAmount.Border.TopColor = System.Drawing.Color.Black;
            this.DebitAmount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DebitAmount.DataField = "DraftDeposit";
            this.DebitAmount.Height = 0.188F;
            this.DebitAmount.Left = 7.063F;
            this.DebitAmount.MultiLine = false;
            this.DebitAmount.Name = "DebitAmount";
            this.DebitAmount.OutputFormat = resources.GetString("DebitAmount.OutputFormat");
            this.DebitAmount.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.DebitAmount.Text = "ZZZ,ZZZ,ZZ9";
            this.DebitAmount.Top = 0F;
            this.DebitAmount.Width = 0.676F;
            // 
            // FactoringDeposit
            // 
            this.FactoringDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.FactoringDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FactoringDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.FactoringDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FactoringDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.FactoringDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FactoringDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.FactoringDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FactoringDeposit.DataField = "FactoringDeposit";
            this.FactoringDeposit.Height = 0.188F;
            this.FactoringDeposit.Left = 7.746F;
            this.FactoringDeposit.MultiLine = false;
            this.FactoringDeposit.Name = "FactoringDeposit";
            this.FactoringDeposit.OutputFormat = resources.GetString("FactoringDeposit.OutputFormat");
            this.FactoringDeposit.Style = "ddo-char-set: 1; text-align: right; font-size: 6pt; font-family: ＭＳ ゴシック; vertica" +
                "l-align: top; ";
            this.FactoringDeposit.Text = "ZZZ,ZZZ,ZZ9";
            this.FactoringDeposit.Top = 0F;
            this.FactoringDeposit.Width = 0.676F;
            // 
            // BankCode
            // 
            this.BankCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BankCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BankCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BankCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BankCode.Border.RightColor = System.Drawing.Color.Black;
            this.BankCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BankCode.Border.TopColor = System.Drawing.Color.Black;
            this.BankCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BankCode.DataField = "BankCode";
            this.BankCode.Height = 0.188F;
            this.BankCode.Left = 8.447F;
            this.BankCode.MultiLine = false;
            this.BankCode.Name = "BankCode";
            this.BankCode.Style = "ddo-char-set: 1; text-align: center; font-size: 6pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BankCode.Text = "9999";
            this.BankCode.Top = 0F;
            this.BankCode.Width = 0.246F;
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
            this.CustomerCode.Height = 0.188F;
            this.CustomerCode.Left = 1.196F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Style = "ddo-char-set: 1; text-align: center; font-size: 6pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.CustomerCode.Text = "999999";
            this.CustomerCode.Top = 0F;
            this.CustomerCode.Width = 0.369F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Label1,
            this.tb_PrintDate,
            this.Label4,
            this.tb_PrintPage,
            this.tb_PrintTime,
            this.Line1});
            this.PageHeader.Height = 0.2604167F;
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "入金データ取込エラーリスト";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.6875F;
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
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.tb_PrintDate.Text = "平成24年6月 4日";
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
            this.Line1.Top = 0.25F;
            this.Line1.Width = 10.8125F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8125F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.239F;
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
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line42,
            this.Label_DepositDate,
            this.Label_CheckDeposit,
            this.Label_ErrorNote,
            this.label_SecCode,
            this.label_DraftDeposit,
            this.label_DepositSlipNum,
            this.label_CustomerCode,
            this.label_CashDeposit,
            this.label_TransferDeposit,
            this.label_FeeDeposit,
            this.label3,
            this.label_DiscountDeposit,
            this.label_OtherDeposit,
            this.label_DebitAmount,
            this.label_FactoringDeposit,
            this.label_BankCode,
            this.line2});
            this.TitleHeader.Height = 0.3020833F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.BeforePrint += new System.EventHandler(this.TitleHeader_BeforePrint);
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
            // Label_DepositDate
            // 
            this.Label_DepositDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_DepositDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DepositDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_DepositDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DepositDate.Border.RightColor = System.Drawing.Color.Black;
            this.Label_DepositDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DepositDate.Border.TopColor = System.Drawing.Color.Black;
            this.Label_DepositDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_DepositDate.Height = 0.25F;
            this.Label_DepositDate.HyperLink = "";
            this.Label_DepositDate.Left = 0.215F;
            this.Label_DepositDate.MultiLine = false;
            this.Label_DepositDate.Name = "Label_DepositDate";
            this.Label_DepositDate.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_DepositDate.Text = "入金日付";
            this.Label_DepositDate.Top = 0F;
            this.Label_DepositDate.Width = 0.492F;
            // 
            // Label_CheckDeposit
            // 
            this.Label_CheckDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_CheckDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_CheckDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.Label_CheckDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.Label_CheckDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_CheckDeposit.Height = 0.25F;
            this.Label_CheckDeposit.HyperLink = "";
            this.Label_CheckDeposit.Left = 3.264417F;
            this.Label_CheckDeposit.MultiLine = false;
            this.Label_CheckDeposit.Name = "Label_CheckDeposit";
            this.Label_CheckDeposit.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_CheckDeposit.Text = "小切手";
            this.Label_CheckDeposit.Top = 0F;
            this.Label_CheckDeposit.Width = 0.369F;
            // 
            // Label_ErrorNote
            // 
            this.Label_ErrorNote.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_ErrorNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ErrorNote.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_ErrorNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ErrorNote.Border.RightColor = System.Drawing.Color.Black;
            this.Label_ErrorNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ErrorNote.Border.TopColor = System.Drawing.Color.Black;
            this.Label_ErrorNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_ErrorNote.Height = 0.25F;
            this.Label_ErrorNote.HyperLink = "";
            this.Label_ErrorNote.Left = 8.718F;
            this.Label_ErrorNote.MultiLine = false;
            this.Label_ErrorNote.Name = "Label_ErrorNote";
            this.Label_ErrorNote.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": ＭＳ 明朝; vertical-align: middle; ";
            this.Label_ErrorNote.Text = "エラー内容";
            this.Label_ErrorNote.Top = 0F;
            this.Label_ErrorNote.Width = 0.615F;
            // 
            // label_SecCode
            // 
            this.label_SecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.label_SecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_SecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.label_SecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_SecCode.Border.RightColor = System.Drawing.Color.Black;
            this.label_SecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_SecCode.Border.TopColor = System.Drawing.Color.Black;
            this.label_SecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_SecCode.Height = 0.25F;
            this.label_SecCode.HyperLink = "";
            this.label_SecCode.Left = 0.0615F;
            this.label_SecCode.MultiLine = false;
            this.label_SecCode.Name = "label_SecCode";
            this.label_SecCode.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label_SecCode.Text = "拠";
            this.label_SecCode.Top = 0F;
            this.label_SecCode.Width = 0.123F;
            // 
            // label_DraftDeposit
            // 
            this.label_DraftDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_DraftDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DraftDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_DraftDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DraftDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_DraftDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DraftDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_DraftDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DraftDeposit.Height = 0.25F;
            this.label_DraftDeposit.HyperLink = "";
            this.label_DraftDeposit.Left = 4.049F;
            this.label_DraftDeposit.MultiLine = false;
            this.label_DraftDeposit.Name = "label_DraftDeposit";
            this.label_DraftDeposit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.label_DraftDeposit.Text = "手形";
            this.label_DraftDeposit.Top = 0F;
            this.label_DraftDeposit.Width = 0.26F;
            // 
            // label_DepositSlipNum
            // 
            this.label_DepositSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.label_DepositSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DepositSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.label_DepositSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DepositSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.label_DepositSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DepositSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.label_DepositSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DepositSlipNum.Height = 0.25F;
            this.label_DepositSlipNum.HyperLink = "";
            this.label_DepositSlipNum.Left = 0.7708333F;
            this.label_DepositSlipNum.MultiLine = false;
            this.label_DepositSlipNum.Name = "label_DepositSlipNum";
            this.label_DepositSlipNum.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label_DepositSlipNum.Text = "伝票№";
            this.label_DepositSlipNum.Top = 0F;
            this.label_DepositSlipNum.Width = 0.369F;
            // 
            // label_CustomerCode
            // 
            this.label_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.label_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.label_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.label_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.label_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CustomerCode.Height = 0.25F;
            this.label_CustomerCode.HyperLink = "";
            this.label_CustomerCode.Left = 1.1875F;
            this.label_CustomerCode.MultiLine = false;
            this.label_CustomerCode.Name = "label_CustomerCode";
            this.label_CustomerCode.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label_CustomerCode.Text = "得意先";
            this.label_CustomerCode.Top = 0F;
            this.label_CustomerCode.Width = 0.369F;
            // 
            // label_CashDeposit
            // 
            this.label_CashDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_CashDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CashDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_CashDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CashDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_CashDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CashDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_CashDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_CashDeposit.Height = 0.25F;
            this.label_CashDeposit.HyperLink = "";
            this.label_CashDeposit.Left = 2.003583F;
            this.label_CashDeposit.MultiLine = false;
            this.label_CashDeposit.Name = "label_CashDeposit";
            this.label_CashDeposit.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label_CashDeposit.Text = "現金";
            this.label_CashDeposit.Top = 0F;
            this.label_CashDeposit.Width = 0.26F;
            // 
            // label_TransferDeposit
            // 
            this.label_TransferDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_TransferDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_TransferDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_TransferDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_TransferDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_TransferDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_TransferDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_TransferDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_TransferDeposit.Height = 0.25F;
            this.label_TransferDeposit.HyperLink = "";
            this.label_TransferDeposit.Left = 2.677083F;
            this.label_TransferDeposit.MultiLine = false;
            this.label_TransferDeposit.Name = "label_TransferDeposit";
            this.label_TransferDeposit.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label_TransferDeposit.Text = "振込";
            this.label_TransferDeposit.Top = 0F;
            this.label_TransferDeposit.Width = 0.26F;
            // 
            // label_FeeDeposit
            // 
            this.label_FeeDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_FeeDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FeeDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_FeeDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FeeDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_FeeDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FeeDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_FeeDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FeeDeposit.Height = 0.25F;
            this.label_FeeDeposit.HyperLink = "";
            this.label_FeeDeposit.Left = 4.626F;
            this.label_FeeDeposit.MultiLine = false;
            this.label_FeeDeposit.Name = "label_FeeDeposit";
            this.label_FeeDeposit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.label_FeeDeposit.Text = "手数料";
            this.label_FeeDeposit.Top = 0F;
            this.label_FeeDeposit.Width = 0.369F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.25F;
            this.label3.HyperLink = "";
            this.label3.Left = 5.40625F;
            this.label3.MultiLine = false;
            this.label3.Name = "label3";
            this.label3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.label3.Text = "相殺";
            this.label3.Top = 0F;
            this.label3.Width = 0.26F;
            // 
            // label_DiscountDeposit
            // 
            this.label_DiscountDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_DiscountDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DiscountDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_DiscountDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DiscountDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_DiscountDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DiscountDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_DiscountDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DiscountDeposit.Height = 0.25F;
            this.label_DiscountDeposit.HyperLink = "";
            this.label_DiscountDeposit.Left = 6.106F;
            this.label_DiscountDeposit.MultiLine = false;
            this.label_DiscountDeposit.Name = "label_DiscountDeposit";
            this.label_DiscountDeposit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.label_DiscountDeposit.Text = "値引";
            this.label_DiscountDeposit.Top = 0F;
            this.label_DiscountDeposit.Width = 0.26F;
            // 
            // label_OtherDeposit
            // 
            this.label_OtherDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_OtherDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_OtherDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_OtherDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_OtherDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_OtherDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_OtherDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_OtherDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_OtherDeposit.Height = 0.25F;
            this.label_OtherDeposit.HyperLink = "";
            this.label_OtherDeposit.Left = 6.684F;
            this.label_OtherDeposit.MultiLine = false;
            this.label_OtherDeposit.Name = "label_OtherDeposit";
            this.label_OtherDeposit.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.label_OtherDeposit.Text = "その他";
            this.label_OtherDeposit.Top = 0F;
            this.label_OtherDeposit.Width = 0.369F;
            // 
            // label_DebitAmount
            // 
            this.label_DebitAmount.Border.BottomColor = System.Drawing.Color.Black;
            this.label_DebitAmount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DebitAmount.Border.LeftColor = System.Drawing.Color.Black;
            this.label_DebitAmount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DebitAmount.Border.RightColor = System.Drawing.Color.Black;
            this.label_DebitAmount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DebitAmount.Border.TopColor = System.Drawing.Color.Black;
            this.label_DebitAmount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_DebitAmount.Height = 0.25F;
            this.label_DebitAmount.HyperLink = "";
            this.label_DebitAmount.Left = 7.244F;
            this.label_DebitAmount.MultiLine = false;
            this.label_DebitAmount.Name = "label_DebitAmount";
            this.label_DebitAmount.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ 明朝; vertical-align: middle; ";
            this.label_DebitAmount.Text = "口座振替";
            this.label_DebitAmount.Top = 0F;
            this.label_DebitAmount.Width = 0.492F;
            // 
            // label_FactoringDeposit
            // 
            this.label_FactoringDeposit.Border.BottomColor = System.Drawing.Color.Black;
            this.label_FactoringDeposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FactoringDeposit.Border.LeftColor = System.Drawing.Color.Black;
            this.label_FactoringDeposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FactoringDeposit.Border.RightColor = System.Drawing.Color.Black;
            this.label_FactoringDeposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FactoringDeposit.Border.TopColor = System.Drawing.Color.Black;
            this.label_FactoringDeposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_FactoringDeposit.Height = 0.2F;
            this.label_FactoringDeposit.HyperLink = "";
            this.label_FactoringDeposit.Left = 7.746F;
            this.label_FactoringDeposit.MultiLine = false;
            this.label_FactoringDeposit.Name = "label_FactoringDeposit";
            this.label_FactoringDeposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 6.75pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.label_FactoringDeposit.Text = "ファクタリング";
            this.label_FactoringDeposit.Top = 0.015F;
            this.label_FactoringDeposit.Width = 0.702F;
            // 
            // label_BankCode
            // 
            this.label_BankCode.Border.BottomColor = System.Drawing.Color.Black;
            this.label_BankCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_BankCode.Border.LeftColor = System.Drawing.Color.Black;
            this.label_BankCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_BankCode.Border.RightColor = System.Drawing.Color.Black;
            this.label_BankCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_BankCode.Border.TopColor = System.Drawing.Color.Black;
            this.label_BankCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_BankCode.Height = 0.25F;
            this.label_BankCode.HyperLink = "";
            this.label_BankCode.Left = 8.447F;
            this.label_BankCode.MultiLine = false;
            this.label_BankCode.Name = "label_BankCode";
            this.label_BankCode.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label_BankCode.Text = "銀";
            this.label_BankCode.Top = 0F;
            this.label_BankCode.Width = 0.246F;
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
            this.line2.Left = 0.0625F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0.25F;
            this.line2.Width = 10.75F;
            this.line2.X1 = 0.0625F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.25F;
            this.line2.Y2 = 0.25F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // AgentHeader
            // 
            this.AgentHeader.CanShrink = true;
            this.AgentHeader.DataField = "AddUpSecCode";
            this.AgentHeader.Height = 0F;
            this.AgentHeader.Name = "AgentHeader";
            this.AgentHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.AgentHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // AgentFooter
            // 
            this.AgentFooter.Height = 0F;
            this.AgentFooter.KeepTogether = true;
            this.AgentFooter.Name = "AgentFooter";
            // 
            // PMKHN09823P_01A4C
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
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.8125F;
            this.Script = "public void ActiveReport_ReportStart()\n{\n\n}";
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.AgentHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.AgentFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMKHN09823P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.SecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeeDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtherDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoringDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BankCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_DepositDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_CheckDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_ErrorNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_SecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DraftDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DepositSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_CashDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_TransferDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_FeeDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DiscountDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_OtherDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_DebitAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_FactoringDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_BankCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
