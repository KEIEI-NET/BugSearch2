//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率マスタ一括登録修正Ⅱ(得意先より)
// プログラム概要   ：掛率マスタ一括登録修正Ⅱ(得意先より)を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：宋剛
// 作成日    2013/02/17     作成内容：新規作成
// ---------------------------------------------------------------------//


using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
    /// 掛率マスタ一括登録修正Ⅱ印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 掛率マスタ一括登録修正Ⅱ(得意先より)を印刷・PDF出力のフォームクラスです。</br>
	/// <br>Programmer	: 宋剛</br>
	/// <br>Date		: 2013/02/17</br>
    /// </remarks>
    /// <br></br>
	/// </remarks>
	public class PMKHN09909P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 掛率マスタ一括登録修正Ⅱフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: 掛率マスタ一括登録修正Ⅱフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
		/// </remarks>
		public PMKHN09909P_02A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor

		#region ■ Private Member
        
		private int _printCount;									// 印刷件数用カウンタ
        private int _cnt = 0;
		private int					_extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	_extraConditions;				// 抽出条件
		private int					_pageFooterOutCode;				// フッター出力区分
		private StringCollection	_pageFooters;					// フッターメッセージ
		private	SFCMN06002C			_printInfo;						// 印刷情報クラス
		private string				_pageHeaderTitle;				// フォームタイトル
		private string				_pageHeaderSortOderTitle;		// ソート順

        private Rate2SearchParam _rateSearchParam;				// 抽出条件クラス

		// ヘッダーサブレポート宣言
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// フッターレポート宣言
		ListCommon_PageFooter _rptPageFooter		= null;

		// Disposeチェック用フラグ
		bool disposed = false;

        // サプレスバッファ
        private Label label18;
        private Label Lb_TitleHeader;
        private Label label1;
        private Label label15;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Line line2;
        private Line line3;
        private Line line5;
        private Line line6;
        private Line line7;
        private Line line9;
        private Line line8;
        private Line line10;
        private Line line11;
        private Line line12;
        private Line line13;
        private Line line14;
        private Line line15;
        private Line line16;
        private Line line18;
        private Label label30;
        private Line line17;
        private Line line19;
        private Line col1Left;
        private Line line24;
        private Line col2Left;
        private Line line38;
        private Line line39;
        private Line line23;
        private Line line26;
        private Line line27;
        private Line line28;
        private Line line29;
        private Line line30;
        private Line line31;
        private Line line32;
        private Line col1Top;
        private Line col2Top;
        private Line col2Right;
        private Line col3Left;
        private Line col3Top;
        private Line col4Left;
        private Line col4Top;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Line col0Top;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox3_1;
        private Line line4;
        private Line line22;
        private Line line25;
        private Line line33;
        private Line line34;
        private Line line48;
        private TextBox textBox16;
        private Label label27;
        private Label label28;
        private TextBox sectionName;
        private Line line60;
        private TextBox textBox2_1;
        private GroupHeader Col1HeadNmChageHeader;
        private GroupFooter Col1HeadNmChageFooter;
        private Label customerSearchMode;
        private Label label14;
        private Line line20;
        private TextBox textBox17;
        private TextBox textBox18;
        private Line line35;
        private Line line36;
        private Label label16;
        private TextBox textBox19;
        private Line line37;
        private Label label17;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label29;
        private Label label31;
        private TextBox textBox1HideValue;
        private Line line21;

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
                this._rateSearchParam = (Rate2SearchParam)this._printInfo.jyoken;
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

		#endregion

		#region ■ Control Event

        #region ◎ PMKHN09909P_02A4C_ReportStart Event
        /// <summary>
        /// PMKHN09909P_02A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポート開始時のイベントです。</br>
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
		/// </remarks>
		private void PMKHN09909P_02A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
            _cnt = 0;
		}
		#endregion

        #region ◎ PMKHN09909P_02A4C_PageEnd Event
        /// <summary>
        /// PMKHN09909P_02A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note		: PMKHN09909P_02A4C_PageEnd Event</br>
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
		/// </remarks>
		private void PMKHN09909P_02A4C_PageEnd(object sender, System.EventArgs eArgs)
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
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
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
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
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

            // 拠点名称設定
            if (null != _rateSearchParam)
            {
                this.sectionName.Text = _rateSearchParam.SectionName[0];
            }
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
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            
            //COL1初期化
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                col0Top.Visible = false;
                col1Top.Visible = false;
            }
            else
            {
                col0Top.Visible = true;
                col1Top.Visible = true;
            }

            //COL2初期化
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                col2Top.Visible = false;
                
                if (string.IsNullOrEmpty(this.textBox1.Text))
                {
                    col2Right.Visible = true;
                    col2Left.Visible = true;
                }
                else
                {
                    col2Right.Visible = false;
                    col2Left.Visible = false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    col2Top.Visible = true;
                    col2Right.Visible = false;
                    col2Left.Visible = true;
                }
                else
                {
                    col2Top.Visible = true;
                    col2Right.Visible = true;
                    col2Left.Visible = true;
                }
            }

            //COL3初期化

            if (!string.IsNullOrEmpty(textBox3_1.Text))
            {
                col2Right.Visible = false;
                col3Top.Visible = true;
                col3Left.Visible = false;

                col4Top.Visible = true;
                col4Left.Visible = false;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                col3Top.Visible = true;
                col3Left.Visible = false;
            }
            else
            {
                col3Top.Visible = true;
                col3Left.Visible = false;
            }


            //COL4初期化
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                col4Top.Visible = true;
                col4Left.Visible = false;
            }
            else
            {
                col4Top.Visible = true;
                col4Left.Visible = true;
            }

            

            _cnt = _cnt + 1;

            // 一行目の場合、明細行の頭のラインの表示チェックを行います
            if (_cnt % PMKHN09903EC.CNTPERPAGE == 1)
            {
                line22.Visible = true;

                // PDF表示について、同一商品掛率G/層別の明細の印刷で改ページする場合、商品掛率G/層別コードのみ記載する
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = textBox1HideValue.Text;
                }
            }
            else
            {
                line22.Visible = false;
            }


            // 最後行目の場合、明細行の尾のラインの表示チェックを行います
            if (_cnt % PMKHN09903EC.CNTPERPAGE == 0)
            {
                line4.Visible = true;
            }
            else
            {
                line4.Visible = false;
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
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{

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
		/// <br>Programmer  : 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
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
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2013/02/17</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッター罫線印字設定
                line20.Visible = true;

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    textBox17.Visible = true;
                    textBox17.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    textBox18.Visible = true;
                    textBox18.Value = this._pageFooters[1];
                }
            }
            else
            {
                // フッター罫線印字設定
                line20.Visible = false;

                textBox17.Visible = false;
                textBox18.Visible = false;
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
        private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09909P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox2_1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3_1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line21 = new DataDynamics.ActiveReports.Line();
            this.line22 = new DataDynamics.ActiveReports.Line();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.col1Left = new DataDynamics.ActiveReports.Line();
            this.col2Left = new DataDynamics.ActiveReports.Line();
            this.line31 = new DataDynamics.ActiveReports.Line();
            this.col1Top = new DataDynamics.ActiveReports.Line();
            this.col2Top = new DataDynamics.ActiveReports.Line();
            this.col2Right = new DataDynamics.ActiveReports.Line();
            this.col3Left = new DataDynamics.ActiveReports.Line();
            this.col3Top = new DataDynamics.ActiveReports.Line();
            this.col4Left = new DataDynamics.ActiveReports.Line();
            this.col4Top = new DataDynamics.ActiveReports.Line();
            this.col0Top = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.line32 = new DataDynamics.ActiveReports.Line();
            this.line27 = new DataDynamics.ActiveReports.Line();
            this.line28 = new DataDynamics.ActiveReports.Line();
            this.line29 = new DataDynamics.ActiveReports.Line();
            this.line30 = new DataDynamics.ActiveReports.Line();
            this.line26 = new DataDynamics.ActiveReports.Line();
            this.line23 = new DataDynamics.ActiveReports.Line();
            this.line39 = new DataDynamics.ActiveReports.Line();
            this.line38 = new DataDynamics.ActiveReports.Line();
            this.line24 = new DataDynamics.ActiveReports.Line();
            this.line48 = new DataDynamics.ActiveReports.Line();
            this.line34 = new DataDynamics.ActiveReports.Line();
            this.line35 = new DataDynamics.ActiveReports.Line();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1HideValue = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.line20 = new DataDynamics.ActiveReports.Line();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.label28 = new DataDynamics.ActiveReports.Label();
            this.sectionName = new DataDynamics.ActiveReports.TextBox();
            this.line60 = new DataDynamics.ActiveReports.Line();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.Lb_TitleHeader = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.line15 = new DataDynamics.ActiveReports.Line();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.line18 = new DataDynamics.ActiveReports.Line();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.line17 = new DataDynamics.ActiveReports.Line();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.customerSearchMode = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.line33 = new DataDynamics.ActiveReports.Line();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.line36 = new DataDynamics.ActiveReports.Line();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.line37 = new DataDynamics.ActiveReports.Line();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label22 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line25 = new DataDynamics.ActiveReports.Line();
            this.Col1HeadNmChageHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Col1HeadNmChageFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1HideValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerSearchMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox2_1,
            this.textBox3_1,
            this.textBox4,
            this.textBox15,
            this.line4,
            this.line21,
            this.line22,
            this.textBox5,
            this.col1Left,
            this.col2Left,
            this.line31,
            this.col1Top,
            this.col2Top,
            this.col2Right,
            this.col3Left,
            this.col3Top,
            this.col4Left,
            this.col4Top,
            this.col0Top,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox16,
            this.line32,
            this.line27,
            this.line28,
            this.line29,
            this.line30,
            this.line26,
            this.line23,
            this.line39,
            this.line38,
            this.line24,
            this.line48,
            this.line34,
            this.line35,
            this.textBox19,
            this.textBox1HideValue});
            this.Detail.Height = 0.207F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // textBox2_1
            // 
            this.textBox2_1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2_1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2_1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2_1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2_1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2_1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2_1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2_1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2_1.DataField = "Col2Name";
            this.textBox2_1.Height = 0.188F;
            this.textBox2_1.Left = 0.6875F;
            this.textBox2_1.Name = "textBox2_1";
            this.textBox2_1.Style = "text-align: left; white-space: nowrap; vertical-align: bottom; ";
            this.textBox2_1.Text = "textBox2";
            this.textBox2_1.Top = 0F;
            this.textBox2_1.Width = 3F;
            // 
            // textBox3_1
            // 
            this.textBox3_1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3_1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3_1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3_1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3_1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3_1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3_1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3_1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3_1.DataField = "Col3GlcdName";
            this.textBox3_1.Height = 0.188F;
            this.textBox3_1.Left = 1.375F;
            this.textBox3_1.Name = "textBox3_1";
            this.textBox3_1.Style = "white-space: nowrap; vertical-align: bottom; ";
            this.textBox3_1.Text = "textBox3_1";
            this.textBox3_1.Top = 0F;
            this.textBox3_1.Width = 2.3F;
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
            this.textBox4.DataField = "Col4BLCodeName";
            this.textBox4.Height = 0.2F;
            this.textBox4.Left = 1.875F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "white-space: nowrap; vertical-align: bottom; ";
            this.textBox4.Text = "testBox4";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 1.85F;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightColor = System.Drawing.Color.Black;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopColor = System.Drawing.Color.Black;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.DataField = "Col11InputValue";
            this.textBox15.Height = 0.188F;
            this.textBox15.Left = 10.6875F;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox15.Text = "999.99";
            this.textBox15.Top = 0F;
            this.textBox15.Width = 0.54F;
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
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.2F;
            this.line4.Visible = false;
            this.line4.Width = 11.25F;
            this.line4.X1 = 0F;
            this.line4.X2 = 11.25F;
            this.line4.Y1 = 0.2F;
            this.line4.Y2 = 0.2F;
            // 
            // line21
            // 
            this.line21.Border.BottomColor = System.Drawing.Color.Black;
            this.line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.LeftColor = System.Drawing.Color.Black;
            this.line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.RightColor = System.Drawing.Color.Black;
            this.line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Border.TopColor = System.Drawing.Color.Black;
            this.line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line21.Height = 0F;
            this.line21.Left = 3.875F;
            this.line21.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line21.LineWeight = 1F;
            this.line21.Name = "line21";
            this.line21.Top = 0F;
            this.line21.Width = 7.375F;
            this.line21.X1 = 3.875F;
            this.line21.X2 = 11.25F;
            this.line21.Y1 = 0F;
            this.line21.Y2 = 0F;
            // 
            // line22
            // 
            this.line22.Border.BottomColor = System.Drawing.Color.Black;
            this.line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.LeftColor = System.Drawing.Color.Black;
            this.line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.RightColor = System.Drawing.Color.Black;
            this.line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Border.TopColor = System.Drawing.Color.Black;
            this.line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line22.Height = 0F;
            this.line22.Left = 0F;
            this.line22.LineWeight = 1F;
            this.line22.Name = "line22";
            this.line22.Top = 0F;
            this.line22.Visible = false;
            this.line22.Width = 11.25F;
            this.line22.X1 = 0F;
            this.line22.X2 = 11.25F;
            this.line22.Y1 = 0F;
            this.line22.Y2 = 0F;
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
            this.textBox5.DataField = "Col6CostRate";
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 4.28F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox5.Text = "999.99";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.75F;
            // 
            // col1Left
            // 
            this.col1Left.Border.BottomColor = System.Drawing.Color.Black;
            this.col1Left.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Left.Border.LeftColor = System.Drawing.Color.Black;
            this.col1Left.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Left.Border.RightColor = System.Drawing.Color.Black;
            this.col1Left.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Left.Border.TopColor = System.Drawing.Color.Black;
            this.col1Left.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Left.Height = 0.2F;
            this.col1Left.Left = 0F;
            this.col1Left.LineWeight = 1F;
            this.col1Left.Name = "col1Left";
            this.col1Left.Top = 0F;
            this.col1Left.Width = 0F;
            this.col1Left.X1 = 0F;
            this.col1Left.X2 = 0F;
            this.col1Left.Y1 = 0F;
            this.col1Left.Y2 = 0.2F;
            // 
            // col2Left
            // 
            this.col2Left.Border.BottomColor = System.Drawing.Color.Black;
            this.col2Left.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Left.Border.LeftColor = System.Drawing.Color.Black;
            this.col2Left.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Left.Border.RightColor = System.Drawing.Color.Black;
            this.col2Left.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Left.Border.TopColor = System.Drawing.Color.Black;
            this.col2Left.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Left.Height = 0.2F;
            this.col2Left.Left = 0.6875F;
            this.col2Left.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col2Left.LineWeight = 1F;
            this.col2Left.Name = "col2Left";
            this.col2Left.Top = 0F;
            this.col2Left.Width = 0F;
            this.col2Left.X1 = 0.6875F;
            this.col2Left.X2 = 0.6875F;
            this.col2Left.Y1 = 0F;
            this.col2Left.Y2 = 0.2F;
            // 
            // line31
            // 
            this.line31.Border.BottomColor = System.Drawing.Color.Black;
            this.line31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.LeftColor = System.Drawing.Color.Black;
            this.line31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.RightColor = System.Drawing.Color.Black;
            this.line31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.TopColor = System.Drawing.Color.Black;
            this.line31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Height = 0.2F;
            this.line31.Left = 11.25F;
            this.line31.LineWeight = 1F;
            this.line31.Name = "line31";
            this.line31.Top = 0F;
            this.line31.Width = 0F;
            this.line31.X1 = 11.25F;
            this.line31.X2 = 11.25F;
            this.line31.Y1 = 0F;
            this.line31.Y2 = 0.2F;
            // 
            // col1Top
            // 
            this.col1Top.Border.BottomColor = System.Drawing.Color.Black;
            this.col1Top.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Top.Border.LeftColor = System.Drawing.Color.Black;
            this.col1Top.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Top.Border.RightColor = System.Drawing.Color.Black;
            this.col1Top.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Top.Border.TopColor = System.Drawing.Color.Black;
            this.col1Top.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col1Top.Height = 0F;
            this.col1Top.Left = 0F;
            this.col1Top.LineWeight = 1F;
            this.col1Top.Name = "col1Top";
            this.col1Top.Top = 0F;
            this.col1Top.Width = 0.6875F;
            this.col1Top.X1 = 0F;
            this.col1Top.X2 = 0.6875F;
            this.col1Top.Y1 = 0F;
            this.col1Top.Y2 = 0F;
            // 
            // col2Top
            // 
            this.col2Top.Border.BottomColor = System.Drawing.Color.Black;
            this.col2Top.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Top.Border.LeftColor = System.Drawing.Color.Black;
            this.col2Top.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Top.Border.RightColor = System.Drawing.Color.Black;
            this.col2Top.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Top.Border.TopColor = System.Drawing.Color.Black;
            this.col2Top.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Top.Height = 0F;
            this.col2Top.Left = 0.6875F;
            this.col2Top.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col2Top.LineWeight = 1F;
            this.col2Top.Name = "col2Top";
            this.col2Top.Top = 0F;
            this.col2Top.Width = 0.6875F;
            this.col2Top.X1 = 0.6875F;
            this.col2Top.X2 = 1.375F;
            this.col2Top.Y1 = 0F;
            this.col2Top.Y2 = 0F;
            // 
            // col2Right
            // 
            this.col2Right.Border.BottomColor = System.Drawing.Color.Black;
            this.col2Right.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Right.Border.LeftColor = System.Drawing.Color.Black;
            this.col2Right.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Right.Border.RightColor = System.Drawing.Color.Black;
            this.col2Right.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Right.Border.TopColor = System.Drawing.Color.Black;
            this.col2Right.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col2Right.Height = 0.2F;
            this.col2Right.Left = 1.375F;
            this.col2Right.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col2Right.LineWeight = 1F;
            this.col2Right.Name = "col2Right";
            this.col2Right.Top = 0F;
            this.col2Right.Width = 0F;
            this.col2Right.X1 = 1.375F;
            this.col2Right.X2 = 1.375F;
            this.col2Right.Y1 = 0F;
            this.col2Right.Y2 = 0.2F;
            // 
            // col3Left
            // 
            this.col3Left.Border.BottomColor = System.Drawing.Color.Black;
            this.col3Left.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Left.Border.LeftColor = System.Drawing.Color.Black;
            this.col3Left.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Left.Border.RightColor = System.Drawing.Color.Black;
            this.col3Left.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Left.Border.TopColor = System.Drawing.Color.Black;
            this.col3Left.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Left.Height = 0.2F;
            this.col3Left.Left = 1.375F;
            this.col3Left.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col3Left.LineWeight = 1F;
            this.col3Left.Name = "col3Left";
            this.col3Left.Top = 0F;
            this.col3Left.Width = 0F;
            this.col3Left.X1 = 1.375F;
            this.col3Left.X2 = 1.375F;
            this.col3Left.Y1 = 0F;
            this.col3Left.Y2 = 0.2F;
            // 
            // col3Top
            // 
            this.col3Top.Border.BottomColor = System.Drawing.Color.Black;
            this.col3Top.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Top.Border.LeftColor = System.Drawing.Color.Black;
            this.col3Top.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Top.Border.RightColor = System.Drawing.Color.Black;
            this.col3Top.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Top.Border.TopColor = System.Drawing.Color.Black;
            this.col3Top.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col3Top.Height = 0F;
            this.col3Top.Left = 1.375F;
            this.col3Top.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col3Top.LineWeight = 1F;
            this.col3Top.Name = "col3Top";
            this.col3Top.Top = 0F;
            this.col3Top.Width = 0.495F;
            this.col3Top.X1 = 1.375F;
            this.col3Top.X2 = 1.87F;
            this.col3Top.Y1 = 0F;
            this.col3Top.Y2 = 0F;
            // 
            // col4Left
            // 
            this.col4Left.Border.BottomColor = System.Drawing.Color.Black;
            this.col4Left.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Left.Border.LeftColor = System.Drawing.Color.Black;
            this.col4Left.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Left.Border.RightColor = System.Drawing.Color.Black;
            this.col4Left.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Left.Border.TopColor = System.Drawing.Color.Black;
            this.col4Left.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Left.Height = 0.2F;
            this.col4Left.Left = 1.875F;
            this.col4Left.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col4Left.LineWeight = 1F;
            this.col4Left.Name = "col4Left";
            this.col4Left.Top = 0F;
            this.col4Left.Width = 0F;
            this.col4Left.X1 = 1.875F;
            this.col4Left.X2 = 1.875F;
            this.col4Left.Y1 = 0F;
            this.col4Left.Y2 = 0.2F;
            // 
            // col4Top
            // 
            this.col4Top.Border.BottomColor = System.Drawing.Color.Black;
            this.col4Top.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Top.Border.LeftColor = System.Drawing.Color.Black;
            this.col4Top.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Top.Border.RightColor = System.Drawing.Color.Black;
            this.col4Top.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Top.Border.TopColor = System.Drawing.Color.Black;
            this.col4Top.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col4Top.Height = 0F;
            this.col4Top.Left = 1.86F;
            this.col4Top.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.col4Top.LineWeight = 1F;
            this.col4Top.Name = "col4Top";
            this.col4Top.Top = 0F;
            this.col4Top.Width = 2.015F;
            this.col4Top.X1 = 1.86F;
            this.col4Top.X2 = 3.875F;
            this.col4Top.Y1 = 0F;
            this.col4Top.Y2 = 0F;
            // 
            // col0Top
            // 
            this.col0Top.Border.BottomColor = System.Drawing.Color.Black;
            this.col0Top.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col0Top.Border.LeftColor = System.Drawing.Color.Black;
            this.col0Top.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col0Top.Border.RightColor = System.Drawing.Color.Black;
            this.col0Top.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col0Top.Border.TopColor = System.Drawing.Color.Black;
            this.col0Top.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.col0Top.Height = 0F;
            this.col0Top.Left = 0F;
            this.col0Top.LineWeight = 1F;
            this.col0Top.Name = "col0Top";
            this.col0Top.Top = 0F;
            this.col0Top.Width = 11.25F;
            this.col0Top.X1 = 0F;
            this.col0Top.X2 = 11.25F;
            this.col0Top.Y1 = 0F;
            this.col0Top.Y2 = 0F;
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
            this.textBox1.DataField = "Col1ShowValue";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 0F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "white-space: nowrap; vertical-align: bottom; ";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.688F;
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
            this.textBox2.DataField = "Col2ShowGlcd";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.6875F;
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = true;
            this.textBox2.Style = "text-align: left; white-space: nowrap; vertical-align: bottom; ";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.688F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "Col3Blcd";
            this.textBox3.Height = 0.2F;
            this.textBox3.Left = 1.375F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "text-align: right; white-space: nowrap; vertical-align: bottom; ";
            this.textBox3.Text = "3";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.488F;
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
            this.textBox6.DataField = "Col2InputValue";
            this.textBox6.Height = 0.2F;
            this.textBox6.Left = 5.625F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox6.Text = "999.99";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.54F;
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
            this.textBox7.DataField = "Col3InputValue";
            this.textBox7.Height = 0.2F;
            this.textBox7.Left = 6.1875F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox7.Text = "999.99";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.54F;
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
            this.textBox8.DataField = "Col4InputValue";
            this.textBox8.Height = 0.2F;
            this.textBox8.Left = 6.75F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox8.Text = "999.99";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.54F;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.DataField = "Col5InputValue";
            this.textBox9.Height = 0.2F;
            this.textBox9.Left = 7.3125F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox9.Text = "999.99";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.54F;
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
            this.textBox10.DataField = "Col6InputValue";
            this.textBox10.Height = 0.2F;
            this.textBox10.Left = 7.875F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox10.Text = "999.99";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.54F;
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
            this.textBox11.DataField = "Col7InputValue";
            this.textBox11.Height = 0.2F;
            this.textBox11.Left = 8.4375F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox11.Text = "999.99";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.54F;
            // 
            // textBox12
            // 
            this.textBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.RightColor = System.Drawing.Color.Black;
            this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.Border.TopColor = System.Drawing.Color.Black;
            this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox12.DataField = "Col8InputValue";
            this.textBox12.Height = 0.2F;
            this.textBox12.Left = 9F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox12.Text = "999.99";
            this.textBox12.Top = 0F;
            this.textBox12.Width = 0.54F;
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
            this.textBox13.DataField = "Col9InputValue";
            this.textBox13.Height = 0.2F;
            this.textBox13.Left = 9.5625F;
            this.textBox13.Name = "textBox13";
            this.textBox13.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox13.Text = "999.99";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.54F;
            // 
            // textBox14
            // 
            this.textBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.RightColor = System.Drawing.Color.Black;
            this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.Border.TopColor = System.Drawing.Color.Black;
            this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox14.DataField = "Col10InputValue";
            this.textBox14.Height = 0.2F;
            this.textBox14.Left = 10.125F;
            this.textBox14.Name = "textBox14";
            this.textBox14.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox14.Text = "999.99";
            this.textBox14.Top = 0F;
            this.textBox14.Width = 0.54F;
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
            this.textBox16.DataField = "Col1InputValue";
            this.textBox16.Height = 0.2F;
            this.textBox16.Left = 5.06F;
            this.textBox16.Name = "textBox16";
            this.textBox16.Style = "text-align: right; vertical-align: bottom; ";
            this.textBox16.Text = "999.99";
            this.textBox16.Top = 0F;
            this.textBox16.Width = 0.54F;
            // 
            // line32
            // 
            this.line32.Border.BottomColor = System.Drawing.Color.Black;
            this.line32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Border.LeftColor = System.Drawing.Color.Black;
            this.line32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Border.RightColor = System.Drawing.Color.Black;
            this.line32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Border.TopColor = System.Drawing.Color.Black;
            this.line32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line32.Height = 0.2F;
            this.line32.Left = 10.6875F;
            this.line32.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line32.LineWeight = 1F;
            this.line32.Name = "line32";
            this.line32.Top = 0F;
            this.line32.Width = 0F;
            this.line32.X1 = 10.6875F;
            this.line32.X2 = 10.6875F;
            this.line32.Y1 = 0F;
            this.line32.Y2 = 0.2F;
            // 
            // line27
            // 
            this.line27.Border.BottomColor = System.Drawing.Color.Black;
            this.line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.LeftColor = System.Drawing.Color.Black;
            this.line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.RightColor = System.Drawing.Color.Black;
            this.line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.TopColor = System.Drawing.Color.Black;
            this.line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Height = 0.2F;
            this.line27.Left = 10.125F;
            this.line27.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line27.LineWeight = 1F;
            this.line27.Name = "line27";
            this.line27.Top = 0F;
            this.line27.Width = 0F;
            this.line27.X1 = 10.125F;
            this.line27.X2 = 10.125F;
            this.line27.Y1 = 0F;
            this.line27.Y2 = 0.2F;
            // 
            // line28
            // 
            this.line28.Border.BottomColor = System.Drawing.Color.Black;
            this.line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.LeftColor = System.Drawing.Color.Black;
            this.line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.RightColor = System.Drawing.Color.Black;
            this.line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Border.TopColor = System.Drawing.Color.Black;
            this.line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line28.Height = 0.2F;
            this.line28.Left = 9.5625F;
            this.line28.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line28.LineWeight = 1F;
            this.line28.Name = "line28";
            this.line28.Top = 0F;
            this.line28.Width = 0F;
            this.line28.X1 = 9.5625F;
            this.line28.X2 = 9.5625F;
            this.line28.Y1 = 0F;
            this.line28.Y2 = 0.2F;
            // 
            // line29
            // 
            this.line29.Border.BottomColor = System.Drawing.Color.Black;
            this.line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.LeftColor = System.Drawing.Color.Black;
            this.line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.RightColor = System.Drawing.Color.Black;
            this.line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Border.TopColor = System.Drawing.Color.Black;
            this.line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line29.Height = 0.2F;
            this.line29.Left = 9F;
            this.line29.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line29.LineWeight = 1F;
            this.line29.Name = "line29";
            this.line29.Top = 0F;
            this.line29.Width = 0F;
            this.line29.X1 = 9F;
            this.line29.X2 = 9F;
            this.line29.Y1 = 0F;
            this.line29.Y2 = 0.2F;
            // 
            // line30
            // 
            this.line30.Border.BottomColor = System.Drawing.Color.Black;
            this.line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.LeftColor = System.Drawing.Color.Black;
            this.line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.RightColor = System.Drawing.Color.Black;
            this.line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.TopColor = System.Drawing.Color.Black;
            this.line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Height = 0.2F;
            this.line30.Left = 8.4375F;
            this.line30.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line30.LineWeight = 1F;
            this.line30.Name = "line30";
            this.line30.Top = 0F;
            this.line30.Width = 0F;
            this.line30.X1 = 8.4375F;
            this.line30.X2 = 8.4375F;
            this.line30.Y1 = 0F;
            this.line30.Y2 = 0.2F;
            // 
            // line26
            // 
            this.line26.Border.BottomColor = System.Drawing.Color.Black;
            this.line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.LeftColor = System.Drawing.Color.Black;
            this.line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.RightColor = System.Drawing.Color.Black;
            this.line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.TopColor = System.Drawing.Color.Black;
            this.line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Height = 0.2F;
            this.line26.Left = 7.875F;
            this.line26.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line26.LineWeight = 1F;
            this.line26.Name = "line26";
            this.line26.Top = 0F;
            this.line26.Width = 0F;
            this.line26.X1 = 7.875F;
            this.line26.X2 = 7.875F;
            this.line26.Y1 = 0F;
            this.line26.Y2 = 0.2F;
            // 
            // line23
            // 
            this.line23.Border.BottomColor = System.Drawing.Color.Black;
            this.line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.LeftColor = System.Drawing.Color.Black;
            this.line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.RightColor = System.Drawing.Color.Black;
            this.line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Border.TopColor = System.Drawing.Color.Black;
            this.line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line23.Height = 0.2F;
            this.line23.Left = 7.3125F;
            this.line23.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line23.LineWeight = 1F;
            this.line23.Name = "line23";
            this.line23.Top = 0F;
            this.line23.Width = 0F;
            this.line23.X1 = 7.3125F;
            this.line23.X2 = 7.3125F;
            this.line23.Y1 = 0F;
            this.line23.Y2 = 0.2F;
            // 
            // line39
            // 
            this.line39.Border.BottomColor = System.Drawing.Color.Black;
            this.line39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.LeftColor = System.Drawing.Color.Black;
            this.line39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.RightColor = System.Drawing.Color.Black;
            this.line39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.TopColor = System.Drawing.Color.Black;
            this.line39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Height = 0.2F;
            this.line39.Left = 6.75F;
            this.line39.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line39.LineWeight = 1F;
            this.line39.Name = "line39";
            this.line39.Top = 0F;
            this.line39.Width = 0F;
            this.line39.X1 = 6.75F;
            this.line39.X2 = 6.75F;
            this.line39.Y1 = 0F;
            this.line39.Y2 = 0.2F;
            // 
            // line38
            // 
            this.line38.Border.BottomColor = System.Drawing.Color.Black;
            this.line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.LeftColor = System.Drawing.Color.Black;
            this.line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.RightColor = System.Drawing.Color.Black;
            this.line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.TopColor = System.Drawing.Color.Black;
            this.line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Height = 0.2F;
            this.line38.Left = 6.1875F;
            this.line38.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line38.LineWeight = 1F;
            this.line38.Name = "line38";
            this.line38.Top = 0F;
            this.line38.Width = 0F;
            this.line38.X1 = 6.1875F;
            this.line38.X2 = 6.1875F;
            this.line38.Y1 = 0F;
            this.line38.Y2 = 0.2F;
            // 
            // line24
            // 
            this.line24.Border.BottomColor = System.Drawing.Color.Black;
            this.line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.LeftColor = System.Drawing.Color.Black;
            this.line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.RightColor = System.Drawing.Color.Black;
            this.line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.TopColor = System.Drawing.Color.Black;
            this.line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Height = 0.2F;
            this.line24.Left = 5.625F;
            this.line24.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 0F;
            this.line24.Width = 0F;
            this.line24.X1 = 5.625F;
            this.line24.X2 = 5.625F;
            this.line24.Y1 = 0F;
            this.line24.Y2 = 0.2F;
            // 
            // line48
            // 
            this.line48.Border.BottomColor = System.Drawing.Color.Black;
            this.line48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.LeftColor = System.Drawing.Color.Black;
            this.line48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.RightColor = System.Drawing.Color.Black;
            this.line48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.TopColor = System.Drawing.Color.Black;
            this.line48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Height = 0.2F;
            this.line48.Left = 5.06F;
            this.line48.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line48.LineWeight = 1F;
            this.line48.Name = "line48";
            this.line48.Top = 0F;
            this.line48.Width = 0F;
            this.line48.X1 = 5.06F;
            this.line48.X2 = 5.06F;
            this.line48.Y1 = 0F;
            this.line48.Y2 = 0.2F;
            // 
            // line34
            // 
            this.line34.Border.BottomColor = System.Drawing.Color.Black;
            this.line34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.LeftColor = System.Drawing.Color.Black;
            this.line34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.RightColor = System.Drawing.Color.Black;
            this.line34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.TopColor = System.Drawing.Color.Black;
            this.line34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Height = 0.2F;
            this.line34.Left = 4.28F;
            this.line34.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line34.LineWeight = 1F;
            this.line34.Name = "line34";
            this.line34.Top = 0F;
            this.line34.Width = 0F;
            this.line34.X1 = 4.28F;
            this.line34.X2 = 4.28F;
            this.line34.Y1 = 0F;
            this.line34.Y2 = 0.2F;
            // 
            // line35
            // 
            this.line35.Border.BottomColor = System.Drawing.Color.Black;
            this.line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.LeftColor = System.Drawing.Color.Black;
            this.line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.RightColor = System.Drawing.Color.Black;
            this.line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.TopColor = System.Drawing.Color.Black;
            this.line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Height = 0.2F;
            this.line35.Left = 3.75F;
            this.line35.LineStyle = DataDynamics.ActiveReports.LineStyle.Dot;
            this.line35.LineWeight = 1F;
            this.line35.Name = "line35";
            this.line35.Top = 0F;
            this.line35.Width = 0F;
            this.line35.X1 = 3.75F;
            this.line35.X2 = 3.75F;
            this.line35.Y1 = 0F;
            this.line35.Y2 = 0.2F;
            // 
            // textBox19
            // 
            this.textBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.RightColor = System.Drawing.Color.Black;
            this.textBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.Border.TopColor = System.Drawing.Color.Black;
            this.textBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox19.DataField = "Col5Maker";
            this.textBox19.Height = 0.2F;
            this.textBox19.Left = 3.75F;
            this.textBox19.Name = "textBox19";
            this.textBox19.Style = "text-align: right; white-space: nowrap; vertical-align: bottom; ";
            this.textBox19.Text = "１２３４";
            this.textBox19.Top = 0F;
            this.textBox19.Width = 0.5F;
            // 
            // textBox1HideValue
            // 
            this.textBox1HideValue.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1HideValue.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1HideValue.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1HideValue.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1HideValue.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1HideValue.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1HideValue.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1HideValue.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1HideValue.DataField = "Col1HideValue";
            this.textBox1HideValue.Height = 0.1979167F;
            this.textBox1HideValue.Left = 2.6875F;
            this.textBox1HideValue.Name = "textBox1HideValue";
            this.textBox1HideValue.Style = "";
            this.textBox1HideValue.Text = "textBox1HideValue";
            this.textBox1HideValue.Top = 0F;
            this.textBox1HideValue.Visible = false;
            this.textBox1HideValue.Width = 1F;
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
            this.Label3.Left = 8.1875F;
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
            this.tb_PrintDate.Left = 8.75F;
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
            this.Label2.Left = 10.1875F;
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
            this.tb_PrintPage.Left = 10.6875F;
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
            this.Line1.Width = 11.25F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 11.25F;
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
            this.tb_PrintTime.Left = 9.6875F;
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
            this.tb_ReportTitle.Text = "掛率マスタ印刷";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 4.416667F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line20,
            this.textBox17,
            this.textBox18});
            this.PageFooter.Height = 0.271F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // line20
            // 
            this.line20.Border.BottomColor = System.Drawing.Color.Black;
            this.line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.LeftColor = System.Drawing.Color.Black;
            this.line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.RightColor = System.Drawing.Color.Black;
            this.line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Border.TopColor = System.Drawing.Color.Black;
            this.line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line20.Height = 0F;
            this.line20.Left = 0F;
            this.line20.LineWeight = 2F;
            this.line20.Name = "line20";
            this.line20.Top = 0F;
            this.line20.Width = 11.25F;
            this.line20.X1 = 0F;
            this.line20.X2 = 11.25F;
            this.line20.Y1 = 0F;
            this.line20.Y2 = 0F;
            // 
            // textBox17
            // 
            this.textBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.RightColor = System.Drawing.Color.Black;
            this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.TopColor = System.Drawing.Color.Black;
            this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 0F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical-a" +
                "lign: top; ";
            this.textBox17.Text = null;
            this.textBox17.Top = 0F;
            this.textBox17.Width = 3F;
            // 
            // textBox18
            // 
            this.textBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.RightColor = System.Drawing.Color.Black;
            this.textBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Border.TopColor = System.Drawing.Color.Black;
            this.textBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox18.Height = 0.125F;
            this.textBox18.Left = 8.25F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.textBox18.Text = null;
            this.textBox18.Top = 0F;
            this.textBox18.Width = 3F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport,
            this.label28,
            this.sectionName,
            this.line60});
            this.ExtraHeader.Height = 0.39F;
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
            this.Header_SubReport.Height = 0.2F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0.19F;
            this.Header_SubReport.Width = 10.813F;
            // 
            // label28
            // 
            this.label28.Border.BottomColor = System.Drawing.Color.Black;
            this.label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.LeftColor = System.Drawing.Color.Black;
            this.label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.RightColor = System.Drawing.Color.Black;
            this.label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Border.TopColor = System.Drawing.Color.Black;
            this.label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label28.Height = 0.1875F;
            this.label28.HyperLink = null;
            this.label28.Left = 0F;
            this.label28.Name = "label28";
            this.label28.Style = "ddo-char-set: 1; font-weight: normal; font-size: 8pt; vertical-align: bottom; ";
            this.label28.Text = "拠点 : ";
            this.label28.Top = 0F;
            this.label28.Width = 0.4375F;
            // 
            // sectionName
            // 
            this.sectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.sectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.sectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionName.Border.RightColor = System.Drawing.Color.Black;
            this.sectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionName.Border.TopColor = System.Drawing.Color.Black;
            this.sectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionName.Height = 0.1875F;
            this.sectionName.Left = 0.4375F;
            this.sectionName.Name = "sectionName";
            this.sectionName.Style = "ddo-char-set: 1; font-weight: normal; font-size: 8pt; vertical-align: bottom; ";
            this.sectionName.Text = "sectionName";
            this.sectionName.Top = 0F;
            this.sectionName.Width = 1.625F;
            // 
            // line60
            // 
            this.line60.Border.BottomColor = System.Drawing.Color.Black;
            this.line60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line60.Border.LeftColor = System.Drawing.Color.Black;
            this.line60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line60.Border.RightColor = System.Drawing.Color.Black;
            this.line60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line60.Border.TopColor = System.Drawing.Color.Black;
            this.line60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line60.Height = 0F;
            this.line60.Left = 0F;
            this.line60.LineWeight = 1F;
            this.line60.Name = "line60";
            this.line60.Top = 0.5F;
            this.line60.Width = 11.25F;
            this.line60.X1 = 0F;
            this.line60.X2 = 11.25F;
            this.line60.Y1 = 0.5F;
            this.line60.Y2 = 0.5F;
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
            this.label18,
            this.Lb_TitleHeader,
            this.label1,
            this.label15,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.line5,
            this.line6,
            this.line7,
            this.line9,
            this.line8,
            this.line10,
            this.line11,
            this.line12,
            this.line13,
            this.line14,
            this.line15,
            this.line16,
            this.line18,
            this.label30,
            this.line17,
            this.line19,
            this.label27,
            this.line2,
            this.line3,
            this.customerSearchMode,
            this.Line42,
            this.line33,
            this.label14,
            this.line36,
            this.label16,
            this.line37,
            this.label17,
            this.label19,
            this.label20,
            this.label21,
            this.label22,
            this.label23,
            this.label24,
            this.label25,
            this.label26,
            this.label29,
            this.label31});
            this.TitleHeader.Height = 0.768F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
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
            this.label18.DataField = "Row1Name";
            this.label18.Height = 0.1875F;
            this.label18.HyperLink = "";
            this.label18.Left = 5.0625F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 9pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: middle; ";
            this.label18.Text = "売価率";
            this.label18.Top = 0.19F;
            this.label18.Width = 6.1875F;
            // 
            // Lb_TitleHeader
            // 
            this.Lb_TitleHeader.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_TitleHeader.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_TitleHeader.DataField = "Col1HeadValue";
            this.Lb_TitleHeader.Height = 0.2F;
            this.Lb_TitleHeader.HyperLink = "";
            this.Lb_TitleHeader.Left = 0F;
            this.Lb_TitleHeader.MultiLine = false;
            this.Lb_TitleHeader.Name = "Lb_TitleHeader";
            this.Lb_TitleHeader.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.Lb_TitleHeader.Text = "層別";
            this.Lb_TitleHeader.Top = 0.375F;
            this.Lb_TitleHeader.Width = 0.688F;
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
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = "";
            this.label1.Left = 4.28F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label1.Text = "仕入率";
            this.label1.Top = 0.375F;
            this.label1.Width = 0.79F;
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
            this.label15.Height = 0.2F;
            this.label15.HyperLink = "";
            this.label15.Left = 0.6875F;
            this.label15.MultiLine = false;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label15.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
            this.label15.Top = 0.375F;
            this.label15.Width = 0.688F;
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
            this.label4.DataField = "Col2InputHeadName";
            this.label4.Height = 0.2F;
            this.label4.HyperLink = "";
            this.label4.Left = 5.625F;
            this.label4.MultiLine = false;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label4.Text = "0001";
            this.label4.Top = 0.375F;
            this.label4.Width = 0.54F;
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
            this.label5.DataField = "Col3InputHeadName";
            this.label5.Height = 0.2F;
            this.label5.HyperLink = "";
            this.label5.Left = 6.1875F;
            this.label5.MultiLine = false;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label5.Text = "0002";
            this.label5.Top = 0.375F;
            this.label5.Width = 0.54F;
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
            this.label6.DataField = "Col4InputHeadName";
            this.label6.Height = 0.2F;
            this.label6.HyperLink = "";
            this.label6.Left = 6.75F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label6.Text = "0003";
            this.label6.Top = 0.375F;
            this.label6.Width = 0.54F;
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
            this.label7.DataField = "Col5InputHeadName";
            this.label7.Height = 0.2F;
            this.label7.HyperLink = "";
            this.label7.Left = 7.3125F;
            this.label7.MultiLine = false;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label7.Text = "0004";
            this.label7.Top = 0.375F;
            this.label7.Width = 0.54F;
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
            this.label8.DataField = "Col6InputHeadName";
            this.label8.Height = 0.2F;
            this.label8.HyperLink = "";
            this.label8.Left = 7.875F;
            this.label8.MultiLine = false;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label8.Text = "0005";
            this.label8.Top = 0.375F;
            this.label8.Width = 0.54F;
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
            this.label9.DataField = "Col7InputHeadName";
            this.label9.Height = 0.2F;
            this.label9.HyperLink = "";
            this.label9.Left = 8.4375F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label9.Text = "0006";
            this.label9.Top = 0.375F;
            this.label9.Width = 0.54F;
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
            this.label10.DataField = "Col8InputHeadName";
            this.label10.Height = 0.2F;
            this.label10.HyperLink = "";
            this.label10.Left = 9F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label10.Text = "0007";
            this.label10.Top = 0.375F;
            this.label10.Width = 0.54F;
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
            this.label11.DataField = "Col9InputHeadName";
            this.label11.Height = 0.2F;
            this.label11.HyperLink = "";
            this.label11.Left = 9.5625F;
            this.label11.MultiLine = false;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label11.Text = "0008";
            this.label11.Top = 0.375F;
            this.label11.Width = 0.54F;
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
            this.label12.DataField = "Col10InputHeadName";
            this.label12.Height = 0.2F;
            this.label12.HyperLink = "";
            this.label12.Left = 10.125F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label12.Text = "0009";
            this.label12.Top = 0.375F;
            this.label12.Width = 0.54F;
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
            this.label13.DataField = "Col11InputHeadName";
            this.label13.Height = 0.2F;
            this.label13.HyperLink = "";
            this.label13.Left = 10.6875F;
            this.label13.MultiLine = false;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label13.Text = "0010";
            this.label13.Top = 0.375F;
            this.label13.Width = 0.54F;
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
            this.line5.Height = 0.405F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.375F;
            this.line5.Width = 0F;
            this.line5.X1 = 0F;
            this.line5.X2 = 0F;
            this.line5.Y1 = 0.375F;
            this.line5.Y2 = 0.78F;
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
            this.line6.Height = 0.405F;
            this.line6.Left = 5.625F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.375F;
            this.line6.Width = 0F;
            this.line6.X1 = 5.625F;
            this.line6.X2 = 5.625F;
            this.line6.Y1 = 0.375F;
            this.line6.Y2 = 0.78F;
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
            this.line7.Height = 0.405F;
            this.line7.Left = 6.1875F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0.375F;
            this.line7.Width = 0F;
            this.line7.X1 = 6.1875F;
            this.line7.X2 = 6.1875F;
            this.line7.Y1 = 0.375F;
            this.line7.Y2 = 0.78F;
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0.405F;
            this.line9.Left = 6.75F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 0.375F;
            this.line9.Width = 0F;
            this.line9.X1 = 6.75F;
            this.line9.X2 = 6.75F;
            this.line9.Y1 = 0.375F;
            this.line9.Y2 = 0.78F;
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
            this.line8.Height = 0.405F;
            this.line8.Left = 10.6875F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 0.375F;
            this.line8.Width = 0F;
            this.line8.X1 = 10.6875F;
            this.line8.X2 = 10.6875F;
            this.line8.Y1 = 0.375F;
            this.line8.Y2 = 0.78F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0.405F;
            this.line10.Left = 10.125F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0.375F;
            this.line10.Width = 0F;
            this.line10.X1 = 10.125F;
            this.line10.X2 = 10.125F;
            this.line10.Y1 = 0.375F;
            this.line10.Y2 = 0.78F;
            // 
            // line11
            // 
            this.line11.Border.BottomColor = System.Drawing.Color.Black;
            this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.LeftColor = System.Drawing.Color.Black;
            this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.RightColor = System.Drawing.Color.Black;
            this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.TopColor = System.Drawing.Color.Black;
            this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Height = 0.405F;
            this.line11.Left = 7.3125F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0.375F;
            this.line11.Width = 0F;
            this.line11.X1 = 7.3125F;
            this.line11.X2 = 7.3125F;
            this.line11.Y1 = 0.375F;
            this.line11.Y2 = 0.78F;
            // 
            // line12
            // 
            this.line12.Border.BottomColor = System.Drawing.Color.Black;
            this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.LeftColor = System.Drawing.Color.Black;
            this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.RightColor = System.Drawing.Color.Black;
            this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.TopColor = System.Drawing.Color.Black;
            this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Height = 0.405F;
            this.line12.Left = 7.875F;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.Top = 0.375F;
            this.line12.Width = 0F;
            this.line12.X1 = 7.875F;
            this.line12.X2 = 7.875F;
            this.line12.Y1 = 0.375F;
            this.line12.Y2 = 0.78F;
            // 
            // line13
            // 
            this.line13.Border.BottomColor = System.Drawing.Color.Black;
            this.line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.LeftColor = System.Drawing.Color.Black;
            this.line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.RightColor = System.Drawing.Color.Black;
            this.line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.TopColor = System.Drawing.Color.Black;
            this.line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Height = 0.405F;
            this.line13.Left = 8.4375F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0.375F;
            this.line13.Width = 0F;
            this.line13.X1 = 8.4375F;
            this.line13.X2 = 8.4375F;
            this.line13.Y1 = 0.375F;
            this.line13.Y2 = 0.78F;
            // 
            // line14
            // 
            this.line14.Border.BottomColor = System.Drawing.Color.Black;
            this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.LeftColor = System.Drawing.Color.Black;
            this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.RightColor = System.Drawing.Color.Black;
            this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.TopColor = System.Drawing.Color.Black;
            this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Height = 0.405F;
            this.line14.Left = 9.5625F;
            this.line14.LineWeight = 1F;
            this.line14.Name = "line14";
            this.line14.Top = 0.375F;
            this.line14.Width = 0F;
            this.line14.X1 = 9.5625F;
            this.line14.X2 = 9.5625F;
            this.line14.Y1 = 0.375F;
            this.line14.Y2 = 0.78F;
            // 
            // line15
            // 
            this.line15.Border.BottomColor = System.Drawing.Color.Black;
            this.line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.LeftColor = System.Drawing.Color.Black;
            this.line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.RightColor = System.Drawing.Color.Black;
            this.line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Border.TopColor = System.Drawing.Color.Black;
            this.line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line15.Height = 0.405F;
            this.line15.Left = 9F;
            this.line15.LineWeight = 1F;
            this.line15.Name = "line15";
            this.line15.Top = 0.375F;
            this.line15.Width = 0F;
            this.line15.X1 = 9F;
            this.line15.X2 = 9F;
            this.line15.Y1 = 0.375F;
            this.line15.Y2 = 0.78F;
            // 
            // line16
            // 
            this.line16.Border.BottomColor = System.Drawing.Color.Black;
            this.line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.LeftColor = System.Drawing.Color.Black;
            this.line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.RightColor = System.Drawing.Color.Black;
            this.line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.TopColor = System.Drawing.Color.Black;
            this.line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Height = 0.5925F;
            this.line16.Left = 11.25F;
            this.line16.LineWeight = 1.8F;
            this.line16.Name = "line16";
            this.line16.Top = 0.1875F;
            this.line16.Width = 0F;
            this.line16.X1 = 11.25F;
            this.line16.X2 = 11.25F;
            this.line16.Y1 = 0.1875F;
            this.line16.Y2 = 0.78F;
            // 
            // line18
            // 
            this.line18.Border.BottomColor = System.Drawing.Color.Black;
            this.line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.LeftColor = System.Drawing.Color.Black;
            this.line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.RightColor = System.Drawing.Color.Black;
            this.line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Border.TopColor = System.Drawing.Color.Black;
            this.line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line18.Height = 0.205F;
            this.line18.Left = 0.6875F;
            this.line18.LineWeight = 1F;
            this.line18.Name = "line18";
            this.line18.Top = 0.375F;
            this.line18.Width = 0F;
            this.line18.X1 = 0.6875F;
            this.line18.X2 = 0.6875F;
            this.line18.Y1 = 0.375F;
            this.line18.Y2 = 0.58F;
            // 
            // label30
            // 
            this.label30.Border.BottomColor = System.Drawing.Color.Black;
            this.label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.LeftColor = System.Drawing.Color.Black;
            this.label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.RightColor = System.Drawing.Color.Black;
            this.label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.TopColor = System.Drawing.Color.Black;
            this.label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Height = 0.2F;
            this.label30.HyperLink = "";
            this.label30.Left = 1.375F;
            this.label30.MultiLine = false;
            this.label30.Name = "label30";
            this.label30.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label30.Text = "BLｺｰﾄﾞ";
            this.label30.Top = 0.375F;
            this.label30.Width = 0.488F;
            // 
            // line17
            // 
            this.line17.Border.BottomColor = System.Drawing.Color.Black;
            this.line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.LeftColor = System.Drawing.Color.Black;
            this.line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.RightColor = System.Drawing.Color.Black;
            this.line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Border.TopColor = System.Drawing.Color.Black;
            this.line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line17.Height = 0.205F;
            this.line17.Left = 1.375F;
            this.line17.LineWeight = 1F;
            this.line17.Name = "line17";
            this.line17.Top = 0.375F;
            this.line17.Width = 0F;
            this.line17.X1 = 1.375F;
            this.line17.X2 = 1.375F;
            this.line17.Y1 = 0.375F;
            this.line17.Y2 = 0.58F;
            // 
            // line19
            // 
            this.line19.Border.BottomColor = System.Drawing.Color.Black;
            this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.LeftColor = System.Drawing.Color.Black;
            this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.RightColor = System.Drawing.Color.Black;
            this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.TopColor = System.Drawing.Color.Black;
            this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Height = 0.205F;
            this.line19.Left = 1.875F;
            this.line19.LineWeight = 1F;
            this.line19.Name = "line19";
            this.line19.Top = 0.375F;
            this.line19.Width = 0F;
            this.line19.X1 = 1.875F;
            this.line19.X2 = 1.875F;
            this.line19.Y1 = 0.375F;
            this.line19.Y2 = 0.58F;
            // 
            // label27
            // 
            this.label27.Border.BottomColor = System.Drawing.Color.Black;
            this.label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.LeftColor = System.Drawing.Color.Black;
            this.label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.RightColor = System.Drawing.Color.Black;
            this.label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.TopColor = System.Drawing.Color.Black;
            this.label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.DataField = "Col1InputHeadName";
            this.label27.Height = 0.2F;
            this.label27.HyperLink = "";
            this.label27.Left = 5.06F;
            this.label27.LineSpacing = 2F;
            this.label27.MultiLine = false;
            this.label27.Name = "label27";
            this.label27.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label27.Text = "0000";
            this.label27.Top = 0.375F;
            this.label27.Width = 0.54F;
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
            this.line2.Height = 0.5925F;
            this.line2.Left = 5.06F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.1875F;
            this.line2.Width = 0F;
            this.line2.X1 = 5.06F;
            this.line2.X2 = 5.06F;
            this.line2.Y1 = 0.1875F;
            this.line2.Y2 = 0.78F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.375F;
            this.line3.Width = 11.25F;
            this.line3.X1 = 0F;
            this.line3.X2 = 11.25F;
            this.line3.Y1 = 0.375F;
            this.line3.Y2 = 0.375F;
            // 
            // customerSearchMode
            // 
            this.customerSearchMode.Border.BottomColor = System.Drawing.Color.Black;
            this.customerSearchMode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerSearchMode.Border.LeftColor = System.Drawing.Color.Black;
            this.customerSearchMode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerSearchMode.Border.RightColor = System.Drawing.Color.Black;
            this.customerSearchMode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerSearchMode.Border.TopColor = System.Drawing.Color.Black;
            this.customerSearchMode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerSearchMode.Height = 0.1875F;
            this.customerSearchMode.HyperLink = "";
            this.customerSearchMode.Left = 4.28F;
            this.customerSearchMode.MultiLine = false;
            this.customerSearchMode.Name = "customerSearchMode";
            this.customerSearchMode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.customerSearchMode.Text = "得意先掛率G";
            this.customerSearchMode.Top = 0.1875F;
            this.customerSearchMode.Width = 0.79F;
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
            this.Line42.Left = 4.28F;
            this.Line42.LineWeight = 1F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0.1875F;
            this.Line42.Width = 6.97F;
            this.Line42.X1 = 4.28F;
            this.Line42.X2 = 11.25F;
            this.Line42.Y1 = 0.1875F;
            this.Line42.Y2 = 0.1875F;
            // 
            // line33
            // 
            this.line33.Border.BottomColor = System.Drawing.Color.Black;
            this.line33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.LeftColor = System.Drawing.Color.Black;
            this.line33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.RightColor = System.Drawing.Color.Black;
            this.line33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.TopColor = System.Drawing.Color.Black;
            this.line33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Height = 0.3925F;
            this.line33.Left = 4.28F;
            this.line33.LineWeight = 1F;
            this.line33.Name = "line33";
            this.line33.Top = 0.1875F;
            this.line33.Width = 0F;
            this.line33.X1 = 4.28F;
            this.line33.X2 = 4.28F;
            this.line33.Y1 = 0.1875F;
            this.line33.Y2 = 0.58F;
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
            this.label14.Height = 0.2F;
            this.label14.HyperLink = "";
            this.label14.Left = 1.875F;
            this.label14.MultiLine = false;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label14.Text = "名称";
            this.label14.Top = 0.375F;
            this.label14.Width = 1.85F;
            // 
            // line36
            // 
            this.line36.Border.BottomColor = System.Drawing.Color.Black;
            this.line36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.LeftColor = System.Drawing.Color.Black;
            this.line36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.RightColor = System.Drawing.Color.Black;
            this.line36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.TopColor = System.Drawing.Color.Black;
            this.line36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Height = 0.205F;
            this.line36.Left = 3.75F;
            this.line36.LineWeight = 1F;
            this.line36.Name = "line36";
            this.line36.Top = 0.375F;
            this.line36.Width = 0F;
            this.line36.X1 = 3.75F;
            this.line36.X2 = 3.75F;
            this.line36.Y1 = 0.375F;
            this.line36.Y2 = 0.58F;
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
            this.label16.Height = 0.2F;
            this.label16.HyperLink = "";
            this.label16.Left = 3.75F;
            this.label16.LineSpacing = 2F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label16.Text = "メーカー";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.54F;
            // 
            // line37
            // 
            this.line37.Border.BottomColor = System.Drawing.Color.Black;
            this.line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.LeftColor = System.Drawing.Color.Black;
            this.line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.RightColor = System.Drawing.Color.Black;
            this.line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.TopColor = System.Drawing.Color.Black;
            this.line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Height = 0F;
            this.line37.Left = 0F;
            this.line37.LineWeight = 1F;
            this.line37.Name = "line37";
            this.line37.Top = 0.58F;
            this.line37.Width = 11.25F;
            this.line37.X1 = 0F;
            this.line37.X2 = 11.25F;
            this.line37.Y1 = 0.58F;
            this.line37.Y2 = 0.58F;
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
            this.label17.DataField = "Col1InputHeadNm";
            this.label17.Height = 0.2F;
            this.label17.HyperLink = "";
            this.label17.Left = 5.0625F;
            this.label17.LineSpacing = 2F;
            this.label17.MultiLine = false;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label17.Text = "0000";
            this.label17.Top = 0.5625F;
            this.label17.Width = 0.54F;
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
            this.label19.DataField = "Col2InputHeadNm";
            this.label19.Height = 0.2F;
            this.label19.HyperLink = "";
            this.label19.Left = 5.625F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label19.Text = "0001";
            this.label19.Top = 0.5625F;
            this.label19.Width = 0.54F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.DataField = "Col3InputHeadNm";
            this.label20.Height = 0.2F;
            this.label20.HyperLink = "";
            this.label20.Left = 6.1875F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label20.Text = "0002";
            this.label20.Top = 0.5625F;
            this.label20.Width = 0.54F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.DataField = "Col4InputHeadNm";
            this.label21.Height = 0.2F;
            this.label21.HyperLink = "";
            this.label21.Left = 6.75F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label21.Text = "0003";
            this.label21.Top = 0.5625F;
            this.label21.Width = 0.54F;
            // 
            // label22
            // 
            this.label22.Border.BottomColor = System.Drawing.Color.Black;
            this.label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.LeftColor = System.Drawing.Color.Black;
            this.label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.RightColor = System.Drawing.Color.Black;
            this.label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.Border.TopColor = System.Drawing.Color.Black;
            this.label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label22.DataField = "Col5InputHeadNm";
            this.label22.Height = 0.2F;
            this.label22.HyperLink = "";
            this.label22.Left = 7.3125F;
            this.label22.MultiLine = false;
            this.label22.Name = "label22";
            this.label22.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label22.Text = "0004";
            this.label22.Top = 0.5625F;
            this.label22.Width = 0.54F;
            // 
            // label23
            // 
            this.label23.Border.BottomColor = System.Drawing.Color.Black;
            this.label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.LeftColor = System.Drawing.Color.Black;
            this.label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.RightColor = System.Drawing.Color.Black;
            this.label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.TopColor = System.Drawing.Color.Black;
            this.label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.DataField = "Col6InputHeadNm";
            this.label23.Height = 0.2F;
            this.label23.HyperLink = "";
            this.label23.Left = 7.875F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label23.Text = "0005";
            this.label23.Top = 0.5625F;
            this.label23.Width = 0.54F;
            // 
            // label24
            // 
            this.label24.Border.BottomColor = System.Drawing.Color.Black;
            this.label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.LeftColor = System.Drawing.Color.Black;
            this.label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.RightColor = System.Drawing.Color.Black;
            this.label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.TopColor = System.Drawing.Color.Black;
            this.label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.DataField = "Col7InputHeadNm";
            this.label24.Height = 0.2F;
            this.label24.HyperLink = "";
            this.label24.Left = 8.4375F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label24.Text = "0006";
            this.label24.Top = 0.5625F;
            this.label24.Width = 0.54F;
            // 
            // label25
            // 
            this.label25.Border.BottomColor = System.Drawing.Color.Black;
            this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.LeftColor = System.Drawing.Color.Black;
            this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.RightColor = System.Drawing.Color.Black;
            this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.TopColor = System.Drawing.Color.Black;
            this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.DataField = "Col8InputHeadNm";
            this.label25.Height = 0.2F;
            this.label25.HyperLink = "";
            this.label25.Left = 9F;
            this.label25.MultiLine = false;
            this.label25.Name = "label25";
            this.label25.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label25.Text = "0007";
            this.label25.Top = 0.5625F;
            this.label25.Width = 0.54F;
            // 
            // label26
            // 
            this.label26.Border.BottomColor = System.Drawing.Color.Black;
            this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.LeftColor = System.Drawing.Color.Black;
            this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.RightColor = System.Drawing.Color.Black;
            this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.TopColor = System.Drawing.Color.Black;
            this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.DataField = "Col9InputHeadNm";
            this.label26.Height = 0.2F;
            this.label26.HyperLink = "";
            this.label26.Left = 9.5625F;
            this.label26.MultiLine = false;
            this.label26.Name = "label26";
            this.label26.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label26.Text = "0008";
            this.label26.Top = 0.5625F;
            this.label26.Width = 0.54F;
            // 
            // label29
            // 
            this.label29.Border.BottomColor = System.Drawing.Color.Black;
            this.label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.LeftColor = System.Drawing.Color.Black;
            this.label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.RightColor = System.Drawing.Color.Black;
            this.label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.TopColor = System.Drawing.Color.Black;
            this.label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.DataField = "Col10InputHeadNm";
            this.label29.Height = 0.2F;
            this.label29.HyperLink = "";
            this.label29.Left = 10.125F;
            this.label29.MultiLine = false;
            this.label29.Name = "label29";
            this.label29.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label29.Text = "0009";
            this.label29.Top = 0.5625F;
            this.label29.Width = 0.54F;
            // 
            // label31
            // 
            this.label31.Border.BottomColor = System.Drawing.Color.Black;
            this.label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.LeftColor = System.Drawing.Color.Black;
            this.label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.RightColor = System.Drawing.Color.Black;
            this.label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.TopColor = System.Drawing.Color.Black;
            this.label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.DataField = "Col11InputHeadNm";
            this.label31.Height = 0.2F;
            this.label31.HyperLink = "";
            this.label31.Left = 10.6875F;
            this.label31.MultiLine = false;
            this.label31.Name = "label31";
            this.label31.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 9pt; font-fami" +
                "ly: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.label31.Text = "0010";
            this.label31.Top = 0.5625F;
            this.label31.Width = 0.54F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.ColumnLayout = false;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line25});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // line25
            // 
            this.line25.Border.BottomColor = System.Drawing.Color.Black;
            this.line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.LeftColor = System.Drawing.Color.Black;
            this.line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.RightColor = System.Drawing.Color.Black;
            this.line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.TopColor = System.Drawing.Color.Black;
            this.line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Height = 0F;
            this.line25.Left = 0F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 0F;
            this.line25.Width = 11.25F;
            this.line25.X1 = 0F;
            this.line25.X2 = 11.25F;
            this.line25.Y1 = 0F;
            this.line25.Y2 = 0F;
            // 
            // Col1HeadNmChageHeader
            // 
            this.Col1HeadNmChageHeader.DataField = "Col1InputHeadName";
            this.Col1HeadNmChageHeader.Height = 0F;
            this.Col1HeadNmChageHeader.Name = "Col1HeadNmChageHeader";
            this.Col1HeadNmChageHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.Col1HeadNmChageHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Col1HeadNmChageFooter
            // 
            this.Col1HeadNmChageFooter.Height = 0F;
            this.Col1HeadNmChageFooter.Name = "Col1HeadNmChageFooter";
            this.Col1HeadNmChageFooter.AfterPrint += new System.EventHandler(this.Col1HeadNmChageFooter_AfterPrint);
            // 
            // PMKHN09909P_02A4C
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
            this.PrintWidth = 11.3125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.Col1HeadNmChageHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.Col1HeadNmChageFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.PageEnd += new System.EventHandler(this.PMKHN09909P_02A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN09909P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1HideValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_TitleHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerSearchMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        #region ◎ Col1HeadNmChageFooter_AfterPrint Event
        /// <summary>
        /// 変更ページ処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: Col1HeadNmChageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer	: 宋剛</br>
        /// <br>Date		: 2013/02/17</br>
        /// </remarks>
        private void Col1HeadNmChageFooter_AfterPrint(object sender, EventArgs e)
        {
            _cnt = 0;
        }
        #endregion ◎ Col1HeadNmChageFooter_AfterPrint Event

        /// <summary>
        /// TitleHeader_Formatフォーマット処理
        /// </summary>
        // <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            if (null != _rateSearchParam)
            {
                if (_rateSearchParam.CustomerSearchMode == 0)
                {
                    this.customerSearchMode.Text = "得意先掛率Ｇ";
                }
                else
                {
                    this.customerSearchMode.Text = "得意先";
                }
            }
        }
    }
}
