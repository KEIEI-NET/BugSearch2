using System;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;
// ---------- ADD 2012/10/02 ---------->>>>>
using System.Data;
// ---------- ADD 2012/10/02 ----------<<<<<
namespace Broadleaf.Drawing.Printing
{
	public class DCKAK02582P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeCommon, IPrintActiveReportTypeList	
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public DCKAK02582P_01A4C()
		{
			InitializeComponent();
		}
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		// 拠点表示有無
		private bool _isSection;
		
		// 抽出条件ヘッダ出力区分
		private int _extraCondHeadOutDiv;
		
		// ソート順タイトル
		private string _pageHeaderSortOderTitle;
		
		// 抽出条件印字項目
		private StringCollection _extraConditions;
		
		// フッター出力有無
		private int _pageFooterOutCode;
		
		// フッタメッセージ1
		private StringCollection _pageFooters;
		
		// 印刷情報
		private SFCMN06002C _printInfo;

        // 印刷条件
        private ExtrInfo_AccPayBalance _extraInfo;

		// 関連データオブジェクト
		private ArrayList _otherDataList;
		
        //罫線(明細の区切り線(点線))
        private bool Round_Line;

		// 背景透かしモード(無し)
		private int _watermarkMode = 0;
        private DataDynamics.ActiveReports.Label Label25;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label label9;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Label label13;
        private DataDynamics.ActiveReports.Label label14;
        private DataDynamics.ActiveReports.Label label24;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox15;
        private DataDynamics.ActiveReports.TextBox textBox27;
        private DataDynamics.ActiveReports.TextBox textBox30;
        private DataDynamics.ActiveReports.TextBox textBox32;
        private DataDynamics.ActiveReports.TextBox textBox34;
        private DataDynamics.ActiveReports.TextBox textBox35;
        private DataDynamics.ActiveReports.TextBox textBox36;
        private DataDynamics.ActiveReports.TextBox textBox37;
        private DataDynamics.ActiveReports.TextBox textBox38;
        private DataDynamics.ActiveReports.TextBox textBox40;
        public DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox10;
        private DataDynamics.ActiveReports.TextBox StckTtlAccPayBlance;
        private GroupHeader PayeeHeader;
        private GroupFooter PayeeFooter;
        private DataDynamics.ActiveReports.Label label19;
        private DataDynamics.ActiveReports.TextBox textBox11;
        private DataDynamics.ActiveReports.TextBox textBox16;
        private DataDynamics.ActiveReports.Label label20;
        private DataDynamics.ActiveReports.TextBox textBox17;
        private DataDynamics.ActiveReports.Label label23;
        private DataDynamics.ActiveReports.TextBox textBox18;
        private DataDynamics.ActiveReports.Label label26;
        private DataDynamics.ActiveReports.TextBox textBox19;
        private ReportHeader ReportHeader1;
        private ReportFooter ReportFooter1;
        private DataDynamics.ActiveReports.Label label16;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox7;
        private DataDynamics.ActiveReports.TextBox textBox8;
        private DataDynamics.ActiveReports.TextBox textBox12;
        private DataDynamics.ActiveReports.TextBox textBox14;
        private Line line2;
        private DataDynamics.ActiveReports.Label label18;
        private DataDynamics.ActiveReports.TextBox textBox13;
        private DataDynamics.ActiveReports.TextBox textBox24;
        private DataDynamics.ActiveReports.TextBox textBox41;
        private DataDynamics.ActiveReports.TextBox textBox43;
        private DataDynamics.ActiveReports.TextBox textBox44;
        private DataDynamics.ActiveReports.TextBox textBox45;
        private DataDynamics.ActiveReports.TextBox textBox46;
        private Line line12;
        private GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.Label label15;
        private DataDynamics.ActiveReports.TextBox textBox6;
        private DataDynamics.ActiveReports.TextBox textBox9;
        private DataDynamics.ActiveReports.TextBox textBox20;
        private DataDynamics.ActiveReports.TextBox textBox21;
        private DataDynamics.ActiveReports.TextBox textBox22;
        private DataDynamics.ActiveReports.TextBox textBox23;
        private DataDynamics.ActiveReports.TextBox textBox25;
        private SubReport Footer_SubReport;
        private Line line10;
        private Line line3;
        private Line Line52;
        private Line line13;
        private GroupFooter GrandTotalFooter;
		
		// 印刷件数
		private int _printCount = 1;

		#endregion

		//================================================================================
		//  プロパティ
		//================================================================================
		#region public property
		#region IPrintActiveReportTypeList メンバ
		/// <summary>
		/// ページヘッダソート順タイトル項目
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set
			{
				this._pageHeaderSortOderTitle = value;
			}
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{this._extraCondHeadOutDiv = value;}
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set
			{
				this._extraConditions = value;
			}
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set
			{
				this._pageFooterOutCode = value;
			}
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set
			{
				this._pageFooters = value;
			}
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
					if (this._otherDataList.Count > 0)
					{
						this._isSection = (bool)this._otherDataList[0];
					}
				}
			}
		}

        /// <summary>
        /// ページヘッダサブタイトル
        /// </summary>
		public string PageHeaderSubtitle
		{
			set{}
		}
		#endregion
		
		#region IPrintActiveReportTypeCommon メンバ 		
		/// <summary>プログレスバーカウントアップイベント</summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;

		/// <summary>背景透かしモード</summary>
		/// <value>0：背景透かし無し, 1:背景透かし有り</value>
		public int WatermarkMode
		{
			set{}
			get{return this._watermarkMode;}
		}
		#endregion
		#endregion

		//================================================================================
		//  イベント
		//================================================================================
		#region event
		/// <summary>
		/// レポートスタートイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
        /// <br>Update Note : 2012/10/02 FSI菅原　要</br>
        /// <br>　　　　　　: 仕入総括機能オプション有効時の対応</br>
        /// </remarks>
		private void SFUKK06125P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
            // 条件取得
            this._extraInfo = (ExtrInfo_AccPayBalance)this._printInfo.jyoken;

			// 印刷件数初期化
			this._printCount = 0;
			
			// 罫線表示・非表示制御
			foreach (Section section in this.Sections)
			{
				Section targetSection = section; 
				this.SetVisibleRuledLine(ref targetSection);
			}

            // 印字設定 --------------------------------------------------------------------------------------
            // 拠点計を出力するかしないかを選択する
            // 拠点有無を判断
            if (this._extraInfo.IsOptSection)
            {
                // ---------- DEL 2012/10/02 ---------->>>>>
                //// 全社がチェックされていない時で拠点選択のチェック数が「1」以下の時は、拠点計レコードは出力しない
                //if ((this._extraInfo.SectionCodes.Length < 2) && (this._extraInfo.IsSelectAllSection == false))
                //{
                //    SectionHeader.DataField = "";
                //    SectionHeader.Visible = false;
                //    SectionFooter.Visible = false;
                //}
                //else
                //{
                //    SectionHeader.DataField = DCKAK02584EA.Col_AddUpSecCode;
                //    SectionHeader.Visible = true;
                //    SectionFooter.Visible = true;
                //}
                // ---------- DEL 2012/10/02 ----------<<<<<

                // ---------- ADD 2012/10/02 ---------->>>>>
                // 一旦、拠点計レコードを出力しない設定にする
                SectionHeader.DataField = "";
                SectionHeader.Visible = false;
                SectionFooter.Visible = false;

                // DataSourceを取得
                DataView dv = (DataView)this.DataSource;
                DataTable _printDataTable = dv.Table;

                // 先頭レコードの計上拠点コードを取得
                DataRow dr = _printDataTable.Rows[0];
                string code = (string)dr[DCKAK02584EA.Col_AddUpSecCode];

                // 2件目以降のレコードを順次取得し、計上拠点コードをチェック
                for (int i = 1; i < _printDataTable.Rows.Count; i++)
                {
                    dr = _printDataTable.Rows[i];
                    if (code != (string)dr[DCKAK02584EA.Col_AddUpSecCode])
                    {
                        // 先頭レコードと異なる計上拠点のレコードが存在するため、
                        // 拠点計レコードを出力する設定に更新
                        //   仕入総括機能（個別）オプション有効時、画面上での拠点選択のチェック数が「1」でも、
                        //   結果として複数拠点のレコードが印字される場合があるため
                        SectionHeader.DataField = DCKAK02584EA.Col_AddUpSecCode;
                        SectionHeader.Visible = true;
                        SectionFooter.Visible = true;
                        break;
                    }
                }
                // ---------- ADD 2012/10/02 ----------<<<<<
            }
            else
            {
                // 拠点無
                SectionHeader.DataField = "";
                SectionHeader.Visible = false;
                SectionFooter.Visible = false;
            }
        }

		/// <summary>
		/// ページヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// ソート順
			this.SORTTITLE.Text = this._pageHeaderSortOderTitle;
			
			// 作成日付
			DateTime now = DateTime.Now;
    		this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
			
			// 作成時間
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);

            this.Round_Line = false;
		}

		/// <summary>
		/// 拠点ヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// ヘッダ出力制御
			if (this._extraCondHeadOutDiv == 0)
			{
				// >>>>> 2006.08.21 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				// 毎ページ出力
				this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
				//// 毎ページ出力
				//this.ExtraHeader.RepeatStyle = RepeatStyle.OnPage;
				// <<<<< 2006.08.21 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
			} 
			else 
			{
				// 先頭ページのみ
				this.ExtraHeader.RepeatStyle = RepeatStyle.None;
			}
			
			// ヘッダーサブレポート作成
			ListCommon_ExtraHeader rpt   = new ListCommon_ExtraHeader();

			//// 抽出条件印字項目設定
			rpt.ExtraConditions         = this._extraConditions;
			
			this.Header_SubReport.Report = rpt;
			
		}

		/// <summary>
		/// タイトルヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void TitleHeader_Format(object sender, System.EventArgs eArgs)
		{
		}

		/// <summary>
		/// ページフッタフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// フッター出力する？
			if (this._pageFooterOutCode == 0)
			{
				// フッターレポート作成
				ListCommon_PageFooter rpt = new ListCommon_PageFooter();

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    rpt.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    rpt.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = rpt;
			}
		}
		
		/// <summary>
		/// 明細アフタープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
        /// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.11.15</br>
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
		
		// ===============================================================================
		// ActiveReportsデザイナで生成されたコード
		// ===============================================================================
		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox SORTTITLE;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox DATE;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox PAGE;
		private DataDynamics.ActiveReports.TextBox TIME;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKAK02582P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox34 = new DataDynamics.ActiveReports.TextBox();
            this.textBox35 = new DataDynamics.ActiveReports.TextBox();
            this.textBox36 = new DataDynamics.ActiveReports.TextBox();
            this.textBox37 = new DataDynamics.ActiveReports.TextBox();
            this.textBox38 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.StckTtlAccPayBlance = new DataDynamics.ActiveReports.TextBox();
            this.Line52 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PAGE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label25 = new DataDynamics.ActiveReports.Label();
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
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.PayeeHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.PayeeFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox45 = new DataDynamics.ActiveReports.TextBox();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.ReportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.line10 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckTtlAccPayBlance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanGrow = false;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox30,
            this.textBox32,
            this.textBox34,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox40,
            this.textBox4,
            this.textBox10,
            this.StckTtlAccPayBlance,
            this.Line52});
            this.Detail.Height = 0.25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // textBox30
            // 
            this.textBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.RightColor = System.Drawing.Color.Black;
            this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.TopColor = System.Drawing.Color.Black;
            this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.CanGrow = false;
            this.textBox30.DataField = "AddUpYearMonth";
            this.textBox30.Height = 0.15F;
            this.textBox30.Left = 0.25F;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox30.Text = "9999/99";
            this.textBox30.Top = 0.05F;
            this.textBox30.Width = 0.625F;
            // 
            // textBox32
            // 
            this.textBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.RightColor = System.Drawing.Color.Black;
            this.textBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.Border.TopColor = System.Drawing.Color.Black;
            this.textBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox32.CanGrow = false;
            this.textBox32.DataField = "ThisTimePayNrml";
            this.textBox32.Height = 0.15F;
            this.textBox32.Left = 2.25F;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox32.Text = "123456789123";
            this.textBox32.Top = 0.05F;
            this.textBox32.Width = 0.875F;
            // 
            // textBox34
            // 
            this.textBox34.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.RightColor = System.Drawing.Color.Black;
            this.textBox34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.Border.TopColor = System.Drawing.Color.Black;
            this.textBox34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox34.CanGrow = false;
            this.textBox34.DataField = "LastTimeAccPay";
            this.textBox34.Height = 0.15F;
            this.textBox34.Left = 1.313F;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox34.Text = "123456789123";
            this.textBox34.Top = 0.05F;
            this.textBox34.Width = 0.875F;
            // 
            // textBox35
            // 
            this.textBox35.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.RightColor = System.Drawing.Color.Black;
            this.textBox35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.Border.TopColor = System.Drawing.Color.Black;
            this.textBox35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox35.CanGrow = false;
            this.textBox35.DataField = "ThisTimeTtlBlcAcPay";
            this.textBox35.Height = 0.15F;
            this.textBox35.Left = 3.188F;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox35.Text = "123456789123";
            this.textBox35.Top = 0.05F;
            this.textBox35.Width = 0.875F;
            // 
            // textBox36
            // 
            this.textBox36.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.RightColor = System.Drawing.Color.Black;
            this.textBox36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.Border.TopColor = System.Drawing.Color.Black;
            this.textBox36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox36.CanGrow = false;
            this.textBox36.DataField = "ThisTimeStockPrice";
            this.textBox36.Height = 0.15F;
            this.textBox36.Left = 4.125F;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox36.Text = "123456789123";
            this.textBox36.Top = 0.05F;
            this.textBox36.Width = 0.875F;
            // 
            // textBox37
            // 
            this.textBox37.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.RightColor = System.Drawing.Color.Black;
            this.textBox37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.Border.TopColor = System.Drawing.Color.Black;
            this.textBox37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox37.CanGrow = false;
            this.textBox37.DataField = "OfsThisTimeStock";
            this.textBox37.Height = 0.15F;
            this.textBox37.Left = 6F;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox37.Text = "123456789123";
            this.textBox37.Top = 0.05F;
            this.textBox37.Width = 0.875F;
            // 
            // textBox38
            // 
            this.textBox38.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.RightColor = System.Drawing.Color.Black;
            this.textBox38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.Border.TopColor = System.Drawing.Color.Black;
            this.textBox38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox38.CanGrow = false;
            this.textBox38.DataField = "OfsThisStockTax";
            this.textBox38.Height = 0.15F;
            this.textBox38.Left = 6.938F;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox38.Text = "123456789123";
            this.textBox38.Top = 0.05F;
            this.textBox38.Width = 0.875F;
            // 
            // textBox40
            // 
            this.textBox40.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.RightColor = System.Drawing.Color.Black;
            this.textBox40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.Border.TopColor = System.Drawing.Color.Black;
            this.textBox40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox40.CanGrow = false;
            this.textBox40.DataField = "StockSlipCount";
            this.textBox40.Height = 0.15F;
            this.textBox40.Left = 9.75F;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox40.Text = "666666";
            this.textBox40.Top = 0.05F;
            this.textBox40.Width = 0.5F;
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
            this.textBox4.CanGrow = false;
            this.textBox4.DataField = "RgdsDisT";
            this.textBox4.Height = 0.15F;
            this.textBox4.Left = 5.063F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox4.Text = "123456789123";
            this.textBox4.Top = 0.05F;
            this.textBox4.Width = 0.875F;
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
            this.textBox10.CanGrow = false;
            this.textBox10.DataField = "ThisStockTax";
            this.textBox10.Height = 0.15F;
            this.textBox10.Left = 7.875F;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox10.Text = "123456789123";
            this.textBox10.Top = 0.05F;
            this.textBox10.Width = 0.875F;
            // 
            // StckTtlAccPayBlance
            // 
            this.StckTtlAccPayBlance.Border.BottomColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBlance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBlance.Border.LeftColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBlance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBlance.Border.RightColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBlance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBlance.Border.TopColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBlance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBlance.CanGrow = false;
            this.StckTtlAccPayBlance.DataField = "StckTtlAccPayBalance";
            this.StckTtlAccPayBlance.Height = 0.15F;
            this.StckTtlAccPayBlance.Left = 8.813F;
            this.StckTtlAccPayBlance.Name = "StckTtlAccPayBlance";
            this.StckTtlAccPayBlance.OutputFormat = resources.GetString("StckTtlAccPayBlance.OutputFormat");
            this.StckTtlAccPayBlance.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.StckTtlAccPayBlance.Text = "123456789123";
            this.StckTtlAccPayBlance.Top = 0.05F;
            this.StckTtlAccPayBlance.Width = 0.875F;
            // 
            // Line52
            // 
            this.Line52.Border.BottomColor = System.Drawing.Color.Black;
            this.Line52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line52.Border.LeftColor = System.Drawing.Color.Black;
            this.Line52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line52.Border.RightColor = System.Drawing.Color.Black;
            this.Line52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line52.Border.TopColor = System.Drawing.Color.Black;
            this.Line52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line52.Height = 0F;
            this.Line52.Left = 0F;
            this.Line52.LineWeight = 1F;
            this.Line52.Name = "Line52";
            this.Line52.Top = 0F;
            this.Line52.Width = 10.8F;
            this.Line52.X1 = 0F;
            this.Line52.X2 = 10.8F;
            this.Line52.Y1 = 0F;
            this.Line52.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.SORTTITLE,
            this.Label3,
            this.DATE,
            this.Label2,
            this.PAGE,
            this.TIME,
            this.Line1});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 0.219F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; font-style: italic; font-size: 14.25pt; vertical-align: top; ";
            this.Label1.Text = "買掛残高元帳";
            this.Label1.Top = 0F;
            this.Label1.Width = 2.531F;
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
            this.SORTTITLE.Left = 2.75F;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "font-size: 8pt; vertical-align: top; ";
            this.SORTTITLE.Text = null;
            this.SORTTITLE.Top = 0.0625F;
            this.SORTTITLE.Width = 1.722F;
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
            this.Label3.Height = 0.156F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // DATE
            // 
            this.DATE.Border.BottomColor = System.Drawing.Color.Black;
            this.DATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.LeftColor = System.Drawing.Color.Black;
            this.DATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.RightColor = System.Drawing.Color.Black;
            this.DATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.TopColor = System.Drawing.Color.Black;
            this.DATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.CanShrink = true;
            this.DATE.Height = 0.156F;
            this.DATE.Left = 8.5F;
            this.DATE.MultiLine = false;
            this.DATE.Name = "DATE";
            this.DATE.OutputFormat = resources.GetString("DATE.OutputFormat");
            this.DATE.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.063F;
            this.DATE.Width = 0.938F;
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
            this.Label2.Height = 0.156F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.938F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.063F;
            this.Label2.Width = 0.5F;
            // 
            // PAGE
            // 
            this.PAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.CanShrink = true;
            this.PAGE.Height = 0.156F;
            this.PAGE.Left = 10.438F;
            this.PAGE.MultiLine = false;
            this.PAGE.Name = "PAGE";
            this.PAGE.OutputFormat = resources.GetString("PAGE.OutputFormat");
            this.PAGE.Style = "text-align: right; font-size: 8.25pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PAGE.Text = null;
            this.PAGE.Top = 0.063F;
            this.PAGE.Width = 0.281F;
            // 
            // TIME
            // 
            this.TIME.Border.BottomColor = System.Drawing.Color.Black;
            this.TIME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.LeftColor = System.Drawing.Color.Black;
            this.TIME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.RightColor = System.Drawing.Color.Black;
            this.TIME.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.TopColor = System.Drawing.Color.Black;
            this.TIME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Height = 0.156F;
            this.TIME.Left = 9.438F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "font-size: 8pt; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.063F;
            this.TIME.Width = 0.5F;
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
            this.Line1.Top = 0.219F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.219F;
            this.Line1.Y2 = 0.219F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2083333F;
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
            this.Footer_SubReport.Height = 0.1875F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8125F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.375F;
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
            this.ExtraFooter.CanGrow = false;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // SectionHeader
            // 
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.SectionHeader.Visible = false;
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
            this.label14.Left = 0F;
            this.label14.Name = "label14";
            this.label14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.label14.Text = "拠  点：";
            this.label14.Top = 0.05F;
            this.label14.Width = 0.45F;
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
            this.label24.Height = 0.15F;
            this.label24.HyperLink = "";
            this.label24.Left = 3.5F;
            this.label24.Name = "label24";
            this.label24.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.label24.Text = "支払条件：";
            this.label24.Top = 0.05F;
            this.label24.Width = 0.563F;
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
            this.textBox3.CanGrow = false;
            this.textBox3.DataField = "AddUpSecCode";
            this.textBox3.Height = 0.15F;
            this.textBox3.Left = 0.5F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox3.Text = "666666";
            this.textBox3.Top = 0.05F;
            this.textBox3.Width = 0.188F;
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
            this.textBox15.CanGrow = false;
            this.textBox15.DataField = "AddUpSecName";
            this.textBox15.Height = 0.15F;
            this.textBox15.Left = 0.75F;
            this.textBox15.Name = "textBox15";
            this.textBox15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox15.Text = "拠点名称００";
            this.textBox15.Top = 0.05F;
            this.textBox15.Width = 1.313F;
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
            this.textBox27.CanGrow = false;
            this.textBox27.DataField = "PaymentCond";
            this.textBox27.Height = 0.15F;
            this.textBox27.Left = 4.125F;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox27.Text = "テスト";
            this.textBox27.Top = 0.05F;
            this.textBox27.Width = 0.5F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label16,
            this.textBox1,
            this.textBox2,
            this.textBox5,
            this.textBox7,
            this.textBox8,
            this.textBox12,
            this.textBox14,
            this.line2});
            this.SectionFooter.Height = 0.3F;
            this.SectionFooter.Name = "SectionFooter";
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
            this.label16.Left = 1F;
            this.label16.Name = "label16";
            this.label16.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; white-space: nowrap; vertical-align: middle; ";
            this.label16.Text = "拠点計";
            this.label16.Top = 0.05F;
            this.label16.Width = 0.625F;
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
            this.textBox1.CanGrow = false;
            this.textBox1.DataField = "ThisTimePayNrml";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 2.25F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox1.SummaryGroup = "SectionHeader";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox1.Text = "123456789123";
            this.textBox1.Top = 0.05F;
            this.textBox1.Width = 0.875F;
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
            this.textBox2.CanGrow = false;
            this.textBox2.DataField = "ThisTimeStockPrice";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 4.125F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox2.SummaryGroup = "SectionHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "123456789123";
            this.textBox2.Top = 0.05F;
            this.textBox2.Width = 0.875F;
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
            this.textBox5.CanGrow = false;
            this.textBox5.DataField = "RgdsDisT";
            this.textBox5.Height = 0.2F;
            this.textBox5.Left = 5.063F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox5.SummaryGroup = "SectionHeader";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "123456789123";
            this.textBox5.Top = 0.05F;
            this.textBox5.Width = 0.875F;
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
            this.textBox7.CanGrow = false;
            this.textBox7.DataField = "OfsThisTimeStock";
            this.textBox7.Height = 0.2F;
            this.textBox7.Left = 6F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox7.SummaryGroup = "SectionHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "123456789123";
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
            this.textBox8.CanGrow = false;
            this.textBox8.DataField = "OfsThisStockTax";
            this.textBox8.Height = 0.2F;
            this.textBox8.Left = 6.938F;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox8.SummaryGroup = "SectionHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "123456789123";
            this.textBox8.Top = 0.05F;
            this.textBox8.Width = 0.875F;
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
            this.textBox12.CanGrow = false;
            this.textBox12.DataField = "ThisStockTax";
            this.textBox12.Height = 0.2F;
            this.textBox12.Left = 7.875F;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox12.SummaryGroup = "SectionHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "123456789123";
            this.textBox12.Top = 0.05F;
            this.textBox12.Width = 0.875F;
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
            this.textBox14.CanGrow = false;
            this.textBox14.DataField = "StockSlipCount";
            this.textBox14.Height = 0.2F;
            this.textBox14.Left = 9.75F;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox14.SummaryGroup = "SectionHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "666666";
            this.textBox14.Top = 0.05F;
            this.textBox14.Width = 0.5F;
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
            // TitleHeader
            // 
            this.TitleHeader.CanGrow = false;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label25,
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
            this.line13});
            this.TitleHeader.Height = 0.22F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.15F;
            this.Label25.HyperLink = "";
            this.Label25.Left = 0.25F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.Label25.Text = "月度";
            this.Label25.Top = 0.035F;
            this.Label25.Width = 0.625F;
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
            this.label4.Left = 1.313F;
            this.label4.Name = "label4";
            this.label4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label4.Text = "前月残高";
            this.label4.Top = 0.035F;
            this.label4.Width = 0.875F;
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
            this.label5.Left = 2.25F;
            this.label5.Name = "label5";
            this.label5.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label5.Text = "当月支払額";
            this.label5.Top = 0.035F;
            this.label5.Width = 0.875F;
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
            this.label6.Left = 3.188F;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label6.Text = "繰越残高";
            this.label6.Top = 0.035F;
            this.label6.Width = 0.875F;
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
            this.label7.Left = 4.125F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label7.Text = "当月仕入額";
            this.label7.Top = 0.035F;
            this.label7.Width = 0.875F;
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
            this.label8.Left = 5.063F;
            this.label8.Name = "label8";
            this.label8.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label8.Text = "返品・値引";
            this.label8.Top = 0.035F;
            this.label8.Width = 0.875F;
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
            this.label9.Left = 6F;
            this.label9.Name = "label9";
            this.label9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label9.Text = "純仕入額";
            this.label9.Top = 0.035F;
            this.label9.Width = 0.875F;
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
            this.label10.Left = 6.938F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label10.Text = "消費税";
            this.label10.Top = 0.035F;
            this.label10.Width = 0.875F;
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
            this.label11.Left = 7.875F;
            this.label11.Name = "label11";
            this.label11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label11.Text = "税込仕入額";
            this.label11.Top = 0.035F;
            this.label11.Width = 0.875F;
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
            this.label12.Left = 8.813F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label12.Text = "当月末残高";
            this.label12.Top = 0.035F;
            this.label12.Width = 0.875F;
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
            this.label13.Left = 9.75F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: middle; ";
            this.label13.Text = "伝票枚数";
            this.label13.Top = 0.035F;
            this.label13.Width = 0.5F;
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
            this.line13.Height = 0F;
            this.line13.Left = 0F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0F;
            this.line13.Width = 10.8F;
            this.line13.X1 = 0F;
            this.line13.X2 = 10.8F;
            this.line13.Y1 = 0F;
            this.line13.Y2 = 0F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanGrow = false;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PayeeHeader
            // 
            this.PayeeHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label19,
            this.textBox11,
            this.textBox16,
            this.label20,
            this.textBox17,
            this.label23,
            this.textBox18,
            this.label26,
            this.textBox19,
            this.label14,
            this.textBox3,
            this.textBox15,
            this.label24,
            this.textBox27,
            this.line3});
            // ---------- DEL 2012/10/02 ---------->>>>>
            //this.PayeeHeader.DataField = "PayeeCode";
            // ---------- DEL 2012/10/02 ----------<<<<<
            // ---------- ADD 2012/10/02 ---------->>>>>
            this.PayeeHeader.DataField = "=AddUpSecCode+PayeeCode";
            // ---------- ADD 2012/10/02 ----------<<<<<
            this.PayeeHeader.Height = 0.45F;
            this.PayeeHeader.Name = "PayeeHeader";
            this.PayeeHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.PayeeHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
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
            this.label19.Left = 0F;
            this.label19.Name = "label19";
            this.label19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.label19.Text = "仕入先：";
            this.label19.Top = 0.25F;
            this.label19.Width = 0.45F;
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
            this.textBox11.CanGrow = false;
            this.textBox11.DataField = "PayeeCode";
            this.textBox11.Height = 0.15F;
            this.textBox11.Left = 0.5F;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox11.Text = "123456";
            this.textBox11.Top = 0.25F;
            this.textBox11.Width = 0.375F;
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
            this.textBox16.CanGrow = false;
            this.textBox16.DataField = "PayeeSnm";
            this.textBox16.Height = 0.15F;
            this.textBox16.Left = 0.9375F;
            this.textBox16.Name = "textBox16";
            this.textBox16.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox16.Text = "ああああああああああああああああああああ";
            this.textBox16.Top = 0.25F;
            this.textBox16.Width = 2.313F;
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
            this.label20.Height = 0.15F;
            this.label20.HyperLink = "";
            this.label20.Left = 3.5F;
            this.label20.Name = "label20";
            this.label20.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.label20.Text = "締日：";
            this.label20.Top = 0.25F;
            this.label20.Width = 0.375F;
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
            this.textBox17.CanGrow = false;
            this.textBox17.DataField = "PaymentTotalDay";
            this.textBox17.Height = 0.15F;
            this.textBox17.Left = 3.938F;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox17.Text = "99";
            this.textBox17.Top = 0.25F;
            this.textBox17.Width = 0.25F;
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
            this.label23.Height = 0.15F;
            this.label23.HyperLink = "";
            this.label23.Left = 4.375F;
            this.label23.Name = "label23";
            this.label23.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.label23.Text = "支払月：";
            this.label23.Top = 0.25F;
            this.label23.Width = 0.5F;
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
            this.textBox18.CanGrow = false;
            this.textBox18.DataField = "PaymentMonthName";
            this.textBox18.Height = 0.15F;
            this.textBox18.Left = 4.938F;
            this.textBox18.Name = "textBox18";
            this.textBox18.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox18.Text = null;
            this.textBox18.Top = 0.25F;
            this.textBox18.Width = 0.5F;
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
            this.label26.Height = 0.15F;
            this.label26.HyperLink = "";
            this.label26.Left = 5.563F;
            this.label26.Name = "label26";
            this.label26.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: middle; ";
            this.label26.Text = "支払日：";
            this.label26.Top = 0.25F;
            this.label26.Width = 0.5F;
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
            this.textBox19.CanGrow = false;
            this.textBox19.DataField = "PaymentDay";
            this.textBox19.Height = 0.15F;
            this.textBox19.Left = 6.125F;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: ＭＳ 明朝; white-space: nowrap; vertical-align: middle; ";
            this.textBox19.Text = "99";
            this.textBox19.Top = 0.25F;
            this.textBox19.Width = 0.25F;
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
            // PayeeFooter
            // 
            this.PayeeFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label18,
            this.textBox13,
            this.textBox24,
            this.textBox41,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.line12});
            this.PayeeFooter.Height = 0.3F;
            this.PayeeFooter.Name = "PayeeFooter";
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
            this.label18.Height = 0.2F;
            this.label18.HyperLink = "";
            this.label18.Left = 1F;
            this.label18.Name = "label18";
            this.label18.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; white-space: nowrap; vertical-align: middle; ";
            this.label18.Text = "仕入先計";
            this.label18.Top = 0.05F;
            this.label18.Width = 0.625F;
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
            this.textBox13.CanGrow = false;
            this.textBox13.DataField = "ThisTimePayNrml";
            this.textBox13.Height = 0.2F;
            this.textBox13.Left = 2.25F;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox13.SummaryGroup = "PayeeHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "123456789123";
            this.textBox13.Top = 0.05F;
            this.textBox13.Width = 0.875F;
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
            this.textBox24.CanGrow = false;
            this.textBox24.DataField = "ThisTimeStockPrice";
            this.textBox24.Height = 0.2F;
            this.textBox24.Left = 4.125F;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox24.SummaryGroup = "PayeeHeader";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox24.Text = "123456789123";
            this.textBox24.Top = 0.05F;
            this.textBox24.Width = 0.875F;
            // 
            // textBox41
            // 
            this.textBox41.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.RightColor = System.Drawing.Color.Black;
            this.textBox41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.Border.TopColor = System.Drawing.Color.Black;
            this.textBox41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox41.CanGrow = false;
            this.textBox41.DataField = "RgdsDisT";
            this.textBox41.Height = 0.2F;
            this.textBox41.Left = 5.063F;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox41.SummaryGroup = "PayeeHeader";
            this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox41.Text = "123456789123";
            this.textBox41.Top = 0.05F;
            this.textBox41.Width = 0.875F;
            // 
            // textBox43
            // 
            this.textBox43.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.RightColor = System.Drawing.Color.Black;
            this.textBox43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.Border.TopColor = System.Drawing.Color.Black;
            this.textBox43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox43.CanGrow = false;
            this.textBox43.DataField = "OfsThisTimeStock";
            this.textBox43.Height = 0.2F;
            this.textBox43.Left = 6F;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox43.SummaryGroup = "PayeeHeader";
            this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox43.Text = "123456789123";
            this.textBox43.Top = 0.05F;
            this.textBox43.Width = 0.875F;
            // 
            // textBox44
            // 
            this.textBox44.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.RightColor = System.Drawing.Color.Black;
            this.textBox44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.Border.TopColor = System.Drawing.Color.Black;
            this.textBox44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox44.CanGrow = false;
            this.textBox44.DataField = "OfsThisStockTax";
            this.textBox44.Height = 0.2F;
            this.textBox44.Left = 6.938F;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox44.SummaryGroup = "PayeeHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox44.Text = "123456789123";
            this.textBox44.Top = 0.05F;
            this.textBox44.Width = 0.875F;
            // 
            // textBox45
            // 
            this.textBox45.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.Border.RightColor = System.Drawing.Color.Black;
            this.textBox45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.Border.TopColor = System.Drawing.Color.Black;
            this.textBox45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox45.CanGrow = false;
            this.textBox45.DataField = "ThisStockTax";
            this.textBox45.Height = 0.2F;
            this.textBox45.Left = 7.875F;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox45.SummaryGroup = "PayeeHeader";
            this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox45.Text = "123456789123";
            this.textBox45.Top = 0.05F;
            this.textBox45.Width = 0.875F;
            // 
            // textBox46
            // 
            this.textBox46.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.RightColor = System.Drawing.Color.Black;
            this.textBox46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.Border.TopColor = System.Drawing.Color.Black;
            this.textBox46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox46.CanGrow = false;
            this.textBox46.DataField = "StockSlipCount";
            this.textBox46.Height = 0.2F;
            this.textBox46.Left = 9.75F;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox46.SummaryGroup = "PayeeHeader";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "666666";
            this.textBox46.Top = 0.05F;
            this.textBox46.Width = 0.5F;
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
            this.line12.Height = 0F;
            this.line12.Left = 0F;
            this.line12.LineWeight = 2F;
            this.line12.Name = "line12";
            this.line12.Top = 0F;
            this.line12.Width = 10.8F;
            this.line12.X1 = 0F;
            this.line12.X2 = 10.8F;
            this.line12.Y1 = 0F;
            this.line12.Y2 = 0F;
            // 
            // ReportHeader1
            // 
            this.ReportHeader1.Height = 0.25F;
            this.ReportHeader1.Name = "ReportHeader1";
            this.ReportHeader1.Visible = false;
            // 
            // ReportFooter1
            // 
            this.ReportFooter1.Height = 0F;
            this.ReportFooter1.Name = "ReportFooter1";
            this.ReportFooter1.Visible = false;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label15,
            this.textBox6,
            this.textBox9,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox25,
            this.line10});
            this.GrandTotalFooter.Height = 0.3F;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
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
            this.label15.Left = 1F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; white-space: nowrap; vertical-align: middle; ";
            this.label15.Text = "総合計";
            this.label15.Top = 0.05F;
            this.label15.Width = 0.625F;
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
            this.textBox6.CanGrow = false;
            this.textBox6.DataField = "ThisTimePayNrml";
            this.textBox6.Height = 0.2F;
            this.textBox6.Left = 2.25F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox6.SummaryGroup = "PayeeHeader";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox6.Text = "123456789123";
            this.textBox6.Top = 0.05F;
            this.textBox6.Width = 0.875F;
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
            this.textBox9.CanGrow = false;
            this.textBox9.DataField = "ThisTimeStockPrice";
            this.textBox9.Height = 0.2F;
            this.textBox9.Left = 4.125F;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox9.SummaryGroup = "PayeeHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox9.Text = "123456789123";
            this.textBox9.Top = 0.05F;
            this.textBox9.Width = 0.875F;
            // 
            // textBox20
            // 
            this.textBox20.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.RightColor = System.Drawing.Color.Black;
            this.textBox20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.Border.TopColor = System.Drawing.Color.Black;
            this.textBox20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox20.CanGrow = false;
            this.textBox20.DataField = "RgdsDisT";
            this.textBox20.Height = 0.2F;
            this.textBox20.Left = 5.063F;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox20.SummaryGroup = "PayeeHeader";
            this.textBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox20.Text = "123456789123";
            this.textBox20.Top = 0.05F;
            this.textBox20.Width = 0.875F;
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
            this.textBox21.CanGrow = false;
            this.textBox21.DataField = "OfsThisTimeStock";
            this.textBox21.Height = 0.2F;
            this.textBox21.Left = 6F;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox21.SummaryGroup = "PayeeHeader";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox21.Text = "123456789123";
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
            this.textBox22.CanGrow = false;
            this.textBox22.DataField = "OfsThisStockTax";
            this.textBox22.Height = 0.2F;
            this.textBox22.Left = 6.938F;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox22.SummaryGroup = "PayeeHeader";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox22.Text = "123456789123";
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
            this.textBox23.CanGrow = false;
            this.textBox23.DataField = "ThisStockTax";
            this.textBox23.Height = 0.2F;
            this.textBox23.Left = 7.875F;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox23.SummaryGroup = "PayeeHeader";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox23.Text = "123456789123";
            this.textBox23.Top = 0.05F;
            this.textBox23.Width = 0.875F;
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
            this.textBox25.CanGrow = false;
            this.textBox25.DataField = "StockSlipCount";
            this.textBox25.Height = 0.2F;
            this.textBox25.Left = 9.75F;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: ＭＳ ゴシック; white-space: nowrap; vertical-align: middle; ";
            this.textBox25.SummaryGroup = "PayeeHeader";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox25.Text = "666666";
            this.textBox25.Top = 0.05F;
            this.textBox25.Width = 0.5F;
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
            this.line10.Height = 0F;
            this.line10.Left = 0F;
            this.line10.LineWeight = 2F;
            this.line10.Name = "line10";
            this.line10.Top = 0F;
            this.line10.Width = 10.8F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.8F;
            this.line10.Y1 = 0F;
            this.line10.Y2 = 0F;
            // 
            // DCKAK02582P_01A4C
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
            this.Sections.Add(this.ReportHeader1);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.PayeeHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.PayeeFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.SFUKK06125P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckTtlAccPayBlance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

		// ===============================================================================
		// 内部使用関数
		// ===============================================================================
		#region private methods		
		/// <summary>
		/// 罫線表示非表示制御処理
		/// </summary>
         /// <param name="sections">対象オブジェクト</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void SetVisibleRuledLine(ref Section sections)
		{
			// 罫線有無判定
			bool isRuledLine = (this._printInfo.frycd == 1);
			

			for (int i = 0; i < sections.Controls.Count; i++)
			{
				if (sections.Controls[i] is Line)
				{
					Line line = (Line)sections.Controls[i];
					
					// 表示非表示対象の罫線か
					if (line.Name.IndexOf("RuledLine") != -1)
					{
						line.Visible = isRuledLine; 
					}
				}
			}
		}

        /// <summary>
        /// 明細の区切り線(点線)の設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
            if (this.Round_Line == false)
            {
                this.Line19.Visible = false;
                this.Round_Line = true;
            }
            else
            {
                this.Line19.Visible = true;
            }
               --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/
        }

        #endregion
	}
}
