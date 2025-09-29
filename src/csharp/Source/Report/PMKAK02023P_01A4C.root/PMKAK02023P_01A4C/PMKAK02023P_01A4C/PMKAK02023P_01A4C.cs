//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表(総括)
// プログラム概要   : 買掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成 仕入総括機能対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 修 正 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//
// 管理番号  11870141-00 作成担当 : 3H 仰亮亮
// 修 正 日  2022/10/22  修正内容 : インボイス対応（税率別合計金額不具合修正）
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
	/// 買掛残高一覧表(総括)印刷フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 買掛残高一覧表(総括)のフォームクラスです。</br>
    /// <br>Programmer  : FSI冨樫 紗由里</br>
    /// <br>Date        : 2012/09/14</br>
    /// <br>UpdateNote  : 11570208-00 軽減税率対応</br>
    /// <br>Programmer  : 3H 劉星光</br>
    /// <br>Date	    : 2020/04/10</br>
    /// <br>UpdateNote  : 11870141-00 インボイス対応（税率別合計金額不具合修正）</br>
    /// <br>Programmer  : 3H 仰亮亮</br>
    /// <br>Date        : 2022/10/20</br>
	/// </remarks>
	public class PMKAK02023P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region ■ Constructor
		/// <summary>
        /// 買掛残高一覧表(総括)フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note	   : 買掛残高一覧表(総括)フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		public PMKAK02023P_01A4C()
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

        private SumAccPaymentListCndtn _sumAccPaymentListCndtn;			// 抽出条件クラス


		// その他データ格納項目
		private string				 _detailAddupSecNameTtl;		// 明細拠点名称タイトル

		private int					 _printCount;					// ページ数カウント用

        private DataSet _outputDs;						            // 印刷用DataSet
        private int _outputCnt;										// 支払内訳抽出用カウンタ
        private const string ct_AccPaymentListTable = PMKAK02025EA.ct_Tbl_AccPaymentList;		// 買掛残高一覧表（総括）テーブル名称
        // サブレポート用レポートクラス宣言
        DrawingDetail _rptDrawingDetail = null;
		
		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// フッターレポート作成
		ListCommon_PageFooter _rptPageFooter	= null;
        private TextBox StockPricTax;
        private Label label3;
        private TextBox Total_StockPricTax;
        private TextBox Section_StockPricTax;
        private TextBox StckTtlAccPayBalance;
        private Label label6;
        private TextBox Total_StckTtlAccPayBalance;
        private TextBox Section_StckTtlAccPayBalance;
        private TextBox CashPayment;
        private TextBox TrfrPayment;
        private TextBox CheckPayment;
        private TextBox DraftPayment;
        private TextBox OffsetPayment;
        private TextBox FundTransferPayment;
        private TextBox OthsPayment;
        private TextBox ThisTimeFeePayNrml;
        private TextBox ThisTimeDisPayNrml;
        private Label Label_Payee1;
        private Label Label_Payee2;
        private Label Label_Payee3;
        private Label Label_Payee4;
        private Label Label_Payee5;
        private Label Label_Payee6;
        private Label Label_Payee7;
        private Label Label_Payee8;
        private Label Label_Payee9;
        private TextBox g_CashPayment;
        private TextBox g_TrfrPayment;
        private TextBox g_CheckPayment;
        private TextBox g_DraftPayment;
        private TextBox g_OffsetPayment;
        private TextBox g_FundTransferPayment;
        private TextBox g_OthsPayment;
        private TextBox g_ThisTimeFeePayNrml;
        private TextBox g_ThisTimeDisPayNrml;
        private TextBox s_CashPayment;
        private TextBox s_TrfrPayment;
        private TextBox s_CheckPayment;
        private TextBox s_DraftPayment;
        private TextBox s_OffsetPayment;
        private TextBox s_FundTransferPayment;
        private TextBox s_OthsPayment;
        private TextBox s_ThisTimeFeePayNrml;
        private TextBox s_ThisTimeDisPayNrml;
        private Label label9;
        private TextBox SumAddUpSecCode;
        private TextBox SumSectionGuideNm;
        private GroupHeader SumAccPaymentHeader;
        private GroupFooter SumAccPaymentFooter;
        private SubReport DrawingDetail_SubReport;
        private Line line2;
        private Label Label_Tax;
        private TextBox MonAddUpNonProc;
        private GroupHeader GrandTotalHeader2;
        private GroupFooter GrandTotalFooter2;
        private GroupHeader SectionHeader2;
        private GroupFooter SectionFooter2;
        private Line line3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox s_CashPayment2;
        private TextBox s_TrfrPayment2;
        private TextBox s_CheckPayment2;
        private TextBox s_DraftPayment2;
        private TextBox s_OffsetPayment2;
        private TextBox s_OthsPayment2;
        private TextBox s_FundTransferPayment2;
        private TextBox s_ThisTimeFeePayNrml2;
        private TextBox s_ThisTimeDisPayNrml2;
        private Label label10;
        private Line line4;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox28;
        private TextBox textBox29;
        private TextBox textBox30;
        private TextBox g_CashPayment2;
        private TextBox g_TrfrPayment2;
        private TextBox g_CheckPayment2;
        private TextBox g_DraftPayment2;
        private TextBox g_OffsetPayment2;
        private TextBox g_OthsPayment2;
        private TextBox g_FundTransferPayment2;
        private TextBox g_ThisTimeFeePayNrml2;
        private TextBox g_ThisTimeDisPayNrml2;
        private TextBox textBox40;
        private TextBox textBox41;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox textBox44;
        private TextBox textBox45;
        private TextBox textBox46;
        private TextBox textBox47;
        private TextBox textBox48;
        private TextBox textBox49;
        private TextBox textBox50;
        private TextBox textBox51;
        private TextBox textBox52;
        private TextBox textBox53;
        private TextBox textBox54;
        private TextBox textBox55;
        private TextBox textBox56;
        private TextBox textBox57;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox textBox58;
        private TextBox textBox59;
        private TextBox textBox60;
        private TextBox textBox61;
        private TextBox textBox62;
        private TextBox textBox63;
        private TextBox textBox64;
        private TextBox textBox65;
        private TextBox textBox66;
        private TextBox textBox67;
        private TextBox textBox68;
        private TextBox textBox69;
        private TextBox textBox70;
        private TextBox textBox71;
        private TextBox textBox72;
        private TextBox textBox73;
        private TextBox textBox74;
        private TextBox textBox75;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private Label label17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox31;
        private TextBox textBox32;
        private TextBox textBox33;
        private Label label18;

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
                this._sumAccPaymentListCndtn = (SumAccPaymentListCndtn)this._printInfo.jyoken;
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
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote  : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 3H 劉星光</br>
        /// <br>Date	    : 2020/04/10</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
            
            // 改頁
            if (this._sumAccPaymentListCndtn.NewPageType == 1)
            {
                // しない
                SectionHeader.NewPage = NewPage.None;
            }

            // 支払内訳印字設定
            SetPaymentDtl();
          
			// 項目の名称をセット
			tb_ReportTitle.Text			= this._pageHeaderSubtitle;				// サブタイトル

            // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
            // 税別内訳印字区分
            if (this._sumAccPaymentListCndtn.TaxPrintDiv == 0)
            {
                SectionFooter2.Visible = SectionFooter.Visible;
                GrandTotalFooter2.Visible = GrandTotalFooter.Visible;

                SectionFooter.Visible = false;
                GrandTotalFooter.Visible = false;
            }
            else
            {
                SectionFooter2.Visible = false;
                GrandTotalFooter2.Visible = false;
            }
            // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
		}
		#endregion

        #region ◆ 支払内訳印字設定
        /// <summary>
        /// 支払内訳印字設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の支払内訳から印字設定行う</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        private void SetPaymentDtl()
        {
            // 支払内訳
            if (this._sumAccPaymentListCndtn.PayDtlDiv == 1)
            {
                // 印字しない
                // 明細タイトル
                Label_Payee1.Visible = false;
                Label_Payee2.Visible = false;
                Label_Payee3.Visible = false;
                Label_Payee4.Visible = false;
                Label_Payee5.Visible = false;
                Label_Payee6.Visible = false;
                Label_Payee7.Visible = false;
                Label_Payee8.Visible = false;
                Label_Payee9.Visible = false;
                // 明細行
                CashPayment.Visible = false;
                TrfrPayment.Visible = false;
                CheckPayment.Visible = false;
                DraftPayment.Visible = false;
                OffsetPayment.Visible = false;
                FundTransferPayment.Visible = false;
                OthsPayment.Visible = false;
                ThisTimeFeePayNrml.Visible = false;
                ThisTimeDisPayNrml.Visible = false;
                // 拠点計
                s_CashPayment.Visible = false;
                s_TrfrPayment.Visible = false;
                s_CheckPayment.Visible = false;
                s_DraftPayment.Visible = false;
                s_OffsetPayment.Visible = false;
                s_FundTransferPayment.Visible = false;
                s_OthsPayment.Visible = false;
                s_ThisTimeFeePayNrml.Visible = false;
                s_ThisTimeDisPayNrml.Visible = false;
                // 総合計
                g_CashPayment.Visible = false;
                g_TrfrPayment.Visible = false;
                g_CheckPayment.Visible = false;
                g_DraftPayment.Visible = false;
                g_OffsetPayment.Visible = false;
                g_FundTransferPayment.Visible = false;
                g_OthsPayment.Visible = false;
                g_ThisTimeFeePayNrml.Visible = false;
                g_ThisTimeDisPayNrml.Visible = false;
                // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
                #region 税別内訳
                // 拠点計
                s_CashPayment2.Visible = false;
                s_TrfrPayment2.Visible = false;
                s_CheckPayment2.Visible = false;
                s_DraftPayment2.Visible = false;
                s_OffsetPayment2.Visible = false;
                s_FundTransferPayment2.Visible = false;
                s_OthsPayment2.Visible = false;
                s_ThisTimeFeePayNrml2.Visible = false;
                s_ThisTimeDisPayNrml2.Visible = false;
                // 総合計
                g_CashPayment2.Visible = false;
                g_TrfrPayment2.Visible = false;
                g_CheckPayment2.Visible = false;
                g_DraftPayment2.Visible = false;
                g_OffsetPayment2.Visible = false;
                g_FundTransferPayment2.Visible = false;
                g_OthsPayment2.Visible = false;
                g_ThisTimeFeePayNrml2.Visible = false;
                g_ThisTimeDisPayNrml2.Visible = false;
                #endregion
                // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
            }
        }
        #endregion

        /// <summary>
        /// 支払先内訳データの取得
        /// </summary>
        /// <remarks>
        /// <br>Note        : 支払先内訳データを取得します。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private DataView GetDrawingData()
        {
            DataRowView outputDr = null;
            DataView dr = null;
            
            //if (this._outputDs.Tables[ct_AccPaymentListTable].Rows.Count > this._outputCnt)
            if (this._outputDs.Tables[ct_AccPaymentListTable].DefaultView.Count > this._outputCnt)
            {
                string sort = "";
                string filter = "";

                // 現在印刷している行を取得
                outputDr = this._outputDs.Tables[ct_AccPaymentListTable].DefaultView[this._outputCnt];
                this._outputCnt++;

                // フィルタ条件
                filter = String.Format("{0} = '{1}' AND {2} = {3} AND {4} = '{5}' AND {6} = {7}",
                            PMKAK02025EA.ct_Col_SumAddUpSecCode,
                            outputDr[PMKAK02025EA.ct_Col_SumAddUpSecCode],
                            PMKAK02025EA.ct_Col_SumPayeeCode,
                            outputDr[PMKAK02025EA.ct_Col_SumPayeeCode],
                            PMKAK02025EA.ct_Col_AddUpSecCode,
                            outputDr[PMKAK02025EA.ct_Col_AddUpSecCode],
                            PMKAK02025EA.ct_Col_PayeeCode,
                            outputDr[PMKAK02025EA.ct_Col_PayeeCode]);
                // ソート順
                sort = PMKAK02025EA.ct_Col_SumAddUpSecCode + " ASC,"
                     + PMKAK02025EA.ct_Col_SumPayeeCode + " ASC,"
                     + PMKAK02025EA.ct_Col_AddUpSecCode + " ASC,"
                     + PMKAK02025EA.ct_Col_PayeeCode + " ASC";

                dr = new DataView(this._outputDs.Tables[ct_AccPaymentListTable], filter, sort, DataViewRowState.CurrentRows);
            }
            return dr;
        }

        #endregion

        #region ■ Control Event
        #region ◆ PMKAK02023P_01A4C_ReportStart Event
        /// <summary>
        /// PMKAK02023P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : レポートの設定をするイベントです。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
        private void PMKAK02023P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();
        }
        #endregion ◆ PMKAK02023P_01A4C_ReportStart Event

        #region ◆ PageHeader_Format Event
        /// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString( SumAccPaymentListCndtn.ct_DateFomat, DateTime.Now);
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
		/// <br>Note	   : ExtraHeaderグループの初期化イベントです。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
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

            if (this._sumAccPaymentListCndtn.NewPageType != 1)
            {
                // 改頁しない以外は、暫定消費税の文言を表示制御
                Label_Tax.Visible = (bool)this.MonAddUpNonProc.Value;
            }
            else
            {
                // 改頁しないは、暫定消費税の文言を表示しない
                Label_Tax.Visible = false;
            }

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion ◆ ExtraHeader_Format Event

        #region ◆ SumAccPaymentHeader_Format Event
        private void SumAccPaymentHeader_Format(object sender, EventArgs e)
        {
            if (this._sumAccPaymentListCndtn.SumSuppDtlDiv == 1 &&
                this._sumAccPaymentListCndtn.PayDtlDiv == 1)
            {
                // 総括内訳を印字しない。かつ、支払内訳を印字しない場合は
                // SumAccPaymentHeaderの高さを変える
                this.SumAccPaymentHeader.Height = 0.146F;
            }
        }
        #endregion ◆ SumAccPaymentHeader_Format Event


		#region ◆ Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
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
		/// <br>Note       : セクションがページに描画された後に発生します。</br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            if (this._sumAccPaymentListCndtn.SumSuppDtlDiv == 0)
            {
                // 総括内訳が"印字する"
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
                            _rptDrawingDetail = new DrawingDetail(this._sumAccPaymentListCndtn);
                        }
                        else
                        {
                            // インスタンスが作成されていれば、データソースを初期化する
                            // (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない)
                            _rptDrawingDetail.DataSource = null;
                        }

                        // 月次計上有無値をサブレポートにセット
                        _rptDrawingDetail._monAddUpNonProc = (bool)this.MonAddUpNonProc.Value;
                        
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

                // 改ページしない以外は、メインレポートの月次計上有無値をセット
                this.SumAccPaymentHeader.CanShrink = false;

                // GroupKeepTogetherもFirstDetail→Noneにセット
                this.SumAccPaymentHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.None;

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
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
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
		private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.TextBox tb_AddUpSecName_Title;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label7;
        private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.TextBox LastTimeAccPay;
		private DataDynamics.ActiveReports.TextBox ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox ThisTimeTtlBlcAcPay;
		private DataDynamics.ActiveReports.TextBox ThisTimeStockPrice;
        private DataDynamics.ActiveReports.TextBox ThisRgdsDisPric;
		private DataDynamics.ActiveReports.TextBox SumPayeeCode;
        private DataDynamics.ActiveReports.TextBox SumPayeeSnm;
		private DataDynamics.ActiveReports.TextBox PureStock;
        private DataDynamics.ActiveReports.TextBox OfsThisStockTax;
        private DataDynamics.ActiveReports.TextBox StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
		private DataDynamics.ActiveReports.Line Line45;
		private DataDynamics.ActiveReports.TextBox MONEYKINDNAME13;
		private DataDynamics.ActiveReports.TextBox Section_LastTimeAccPay;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox Section_ThisTimeTtlBlcAcPay;
        private DataDynamics.ActiveReports.TextBox Section_OfsThisStockTax;
        private DataDynamics.ActiveReports.TextBox s_ThisTimeStockPrice;
        private DataDynamics.ActiveReports.TextBox s_ThisRgdsDisPric;
		private DataDynamics.ActiveReports.TextBox s_PureStock;
		private DataDynamics.ActiveReports.TextBox Section_StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.Label Label109;
		private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.TextBox Total_LastTimeAccPay;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimePayNrml;
		private DataDynamics.ActiveReports.TextBox Total_ThisTimeTtlBlcAcPay;
        private DataDynamics.ActiveReports.TextBox g_PureStock;
        private DataDynamics.ActiveReports.TextBox g_ThisTimeStockPrice;
		private DataDynamics.ActiveReports.TextBox g_ThisRgdsDisPric;
		private DataDynamics.ActiveReports.TextBox Total_OfsThisStockTax;
		private DataDynamics.ActiveReports.TextBox Total_StockSlipCount;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// InitializeComponent
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKAK02023P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.DrawingDetail_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.LastTimeAccPay = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcAcPay = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.SumPayeeCode = new DataDynamics.ActiveReports.TextBox();
            this.SumPayeeSnm = new DataDynamics.ActiveReports.TextBox();
            this.PureStock = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.StockPricTax = new DataDynamics.ActiveReports.TextBox();
            this.StckTtlAccPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.Label_Tax = new DataDynamics.ActiveReports.Label();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.Label106 = new DataDynamics.ActiveReports.Label();
            this.Label107 = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.tb_AddUpSecName_Title = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee1 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee2 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee3 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee4 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee5 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee6 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee7 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee8 = new DataDynamics.ActiveReports.Label();
            this.Label_Payee9 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.Total_LastTimeAccPay = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Total_ThisTimeTtlBlcAcPay = new DataDynamics.ActiveReports.TextBox();
            this.g_PureStock = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.Total_OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.Total_StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.Total_StockPricTax = new DataDynamics.ActiveReports.TextBox();
            this.Total_StckTtlAccPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.g_CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SumAddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.SumSectionGuideNm = new DataDynamics.ActiveReports.TextBox();
            this.MonAddUpNonProc = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.Section_LastTimeAccPay = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.Section_ThisTimeTtlBlcAcPay = new DataDynamics.ActiveReports.TextBox();
            this.Section_OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisRgdsDisPric = new DataDynamics.ActiveReports.TextBox();
            this.s_PureStock = new DataDynamics.ActiveReports.TextBox();
            this.Section_StockSlipCount = new DataDynamics.ActiveReports.TextBox();
            this.Section_StockPricTax = new DataDynamics.ActiveReports.TextBox();
            this.Section_StckTtlAccPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.s_CashPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_TrfrPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_CheckPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_DraftPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_OffsetPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_FundTransferPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_OthsPayment = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisPayNrml = new DataDynamics.ActiveReports.TextBox();
            this.SumAccPaymentHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SumAccPaymentFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.GrandTotalHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.textBox21 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox23 = new DataDynamics.ActiveReports.TextBox();
            this.textBox24 = new DataDynamics.ActiveReports.TextBox();
            this.textBox25 = new DataDynamics.ActiveReports.TextBox();
            this.textBox26 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.g_CashPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_TrfrPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_CheckPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_DraftPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OffsetPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_OthsPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_FundTransferPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeFeePayNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.g_ThisTimeDisPayNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox58 = new DataDynamics.ActiveReports.TextBox();
            this.textBox59 = new DataDynamics.ActiveReports.TextBox();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.textBox61 = new DataDynamics.ActiveReports.TextBox();
            this.textBox62 = new DataDynamics.ActiveReports.TextBox();
            this.textBox63 = new DataDynamics.ActiveReports.TextBox();
            this.textBox64 = new DataDynamics.ActiveReports.TextBox();
            this.textBox65 = new DataDynamics.ActiveReports.TextBox();
            this.textBox66 = new DataDynamics.ActiveReports.TextBox();
            this.textBox67 = new DataDynamics.ActiveReports.TextBox();
            this.textBox68 = new DataDynamics.ActiveReports.TextBox();
            this.textBox69 = new DataDynamics.ActiveReports.TextBox();
            this.textBox70 = new DataDynamics.ActiveReports.TextBox();
            this.textBox71 = new DataDynamics.ActiveReports.TextBox();
            this.textBox72 = new DataDynamics.ActiveReports.TextBox();
            this.textBox73 = new DataDynamics.ActiveReports.TextBox();
            this.textBox74 = new DataDynamics.ActiveReports.TextBox();
            this.textBox75 = new DataDynamics.ActiveReports.TextBox();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.SectionHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.textBox10 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.s_CashPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_TrfrPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_CheckPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_DraftPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OffsetPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_OthsPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_FundTransferPayment2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeFeePayNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.s_ThisTimeDisPayNrml2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox40 = new DataDynamics.ActiveReports.TextBox();
            this.textBox41 = new DataDynamics.ActiveReports.TextBox();
            this.textBox42 = new DataDynamics.ActiveReports.TextBox();
            this.textBox43 = new DataDynamics.ActiveReports.TextBox();
            this.textBox44 = new DataDynamics.ActiveReports.TextBox();
            this.textBox45 = new DataDynamics.ActiveReports.TextBox();
            this.textBox46 = new DataDynamics.ActiveReports.TextBox();
            this.textBox47 = new DataDynamics.ActiveReports.TextBox();
            this.textBox48 = new DataDynamics.ActiveReports.TextBox();
            this.textBox49 = new DataDynamics.ActiveReports.TextBox();
            this.textBox50 = new DataDynamics.ActiveReports.TextBox();
            this.textBox51 = new DataDynamics.ActiveReports.TextBox();
            this.textBox52 = new DataDynamics.ActiveReports.TextBox();
            this.textBox53 = new DataDynamics.ActiveReports.TextBox();
            this.textBox54 = new DataDynamics.ActiveReports.TextBox();
            this.textBox55 = new DataDynamics.ActiveReports.TextBox();
            this.textBox56 = new DataDynamics.ActiveReports.TextBox();
            this.textBox57 = new DataDynamics.ActiveReports.TextBox();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.textBox12 = new DataDynamics.ActiveReports.TextBox();
            this.textBox13 = new DataDynamics.ActiveReports.TextBox();
            this.textBox14 = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.textBox18 = new DataDynamics.ActiveReports.TextBox();
            this.textBox19 = new DataDynamics.ActiveReports.TextBox();
            this.textBox20 = new DataDynamics.ActiveReports.TextBox();
            this.textBox31 = new DataDynamics.ActiveReports.TextBox();
            this.textBox32 = new DataDynamics.ActiveReports.TextBox();
            this.textBox33 = new DataDynamics.ActiveReports.TextBox();
            this.label18 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeAccPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcAcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckTtlAccPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Tax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_LastTimeAccPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeTtlBlcAcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PureStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StckTtlAccPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumAddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumSectionGuideNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonAddUpNonProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_LastTimeAccPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeTtlBlcAcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisRgdsDisPric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_PureStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockSlipCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockPricTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StckTtlAccPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisPayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CashPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeePayNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisPayNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferPayment2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeePayNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisPayNrml2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DrawingDetail_SubReport});
            this.Detail.Height = 0.125F;
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
            this.DrawingDetail_SubReport.Left = 0.5F;
            this.DrawingDetail_SubReport.Name = "DrawingDetail_SubReport";
            this.DrawingDetail_SubReport.Report = null;
            this.DrawingDetail_SubReport.ReportName = "DrawingDetail_SubReport";
            this.DrawingDetail_SubReport.Top = 0F;
            this.DrawingDetail_SubReport.Width = 10.3125F;
            // 
            // LastTimeAccPay
            // 
            this.LastTimeAccPay.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeAccPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeAccPay.DataField = "LastTimeAccPay";
            this.LastTimeAccPay.Height = 0.125F;
            this.LastTimeAccPay.Left = 2.8125F;
            this.LastTimeAccPay.MultiLine = false;
            this.LastTimeAccPay.Name = "LastTimeAccPay";
            this.LastTimeAccPay.OutputFormat = resources.GetString("LastTimeAccPay.OutputFormat");
            this.LastTimeAccPay.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.LastTimeAccPay.SummaryGroup = "SumAccPaymentHeader";
            this.LastTimeAccPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.LastTimeAccPay.Text = "11,234,567,890";
            this.LastTimeAccPay.Top = 0F;
            this.LastTimeAccPay.Width = 0.8125F;
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
            this.ThisTimePayNrml.Left = 3.625F;
            this.ThisTimePayNrml.MultiLine = false;
            this.ThisTimePayNrml.Name = "ThisTimePayNrml";
            this.ThisTimePayNrml.OutputFormat = resources.GetString("ThisTimePayNrml.OutputFormat");
            this.ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimePayNrml.SummaryGroup = "SumAccPaymentHeader";
            this.ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimePayNrml.Text = "1,234,567,890";
            this.ThisTimePayNrml.Top = 0F;
            this.ThisTimePayNrml.Width = 0.8125F;
            // 
            // ThisTimeTtlBlcAcPay
            // 
            this.ThisTimeTtlBlcAcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcAcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcAcPay.DataField = "ThisTimeTtlBlcAcPay";
            this.ThisTimeTtlBlcAcPay.Height = 0.125F;
            this.ThisTimeTtlBlcAcPay.Left = 4.4375F;
            this.ThisTimeTtlBlcAcPay.MultiLine = false;
            this.ThisTimeTtlBlcAcPay.Name = "ThisTimeTtlBlcAcPay";
            this.ThisTimeTtlBlcAcPay.OutputFormat = resources.GetString("ThisTimeTtlBlcAcPay.OutputFormat");
            this.ThisTimeTtlBlcAcPay.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeTtlBlcAcPay.SummaryGroup = "SumAccPaymentHeader";
            this.ThisTimeTtlBlcAcPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeTtlBlcAcPay.Text = "11,234,567,890";
            this.ThisTimeTtlBlcAcPay.Top = 0F;
            this.ThisTimeTtlBlcAcPay.Width = 0.8125F;
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
            this.ThisTimeStockPrice.Left = 5.25F;
            this.ThisTimeStockPrice.MultiLine = false;
            this.ThisTimeStockPrice.Name = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.OutputFormat = resources.GetString("ThisTimeStockPrice.OutputFormat");
            this.ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeStockPrice.SummaryGroup = "SumAccPaymentHeader";
            this.ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeStockPrice.Text = "1,234,567,890";
            this.ThisTimeStockPrice.Top = 0F;
            this.ThisTimeStockPrice.Width = 0.8125F;
            // 
            // ThisRgdsDisPric
            // 
            this.ThisRgdsDisPric.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.Border.RightColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.Border.TopColor = System.Drawing.Color.Black;
            this.ThisRgdsDisPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDisPric.DataField = "ThisRgdsDisPric";
            this.ThisRgdsDisPric.Height = 0.125F;
            this.ThisRgdsDisPric.Left = 6.0625F;
            this.ThisRgdsDisPric.MultiLine = false;
            this.ThisRgdsDisPric.Name = "ThisRgdsDisPric";
            this.ThisRgdsDisPric.OutputFormat = resources.GetString("ThisRgdsDisPric.OutputFormat");
            this.ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisRgdsDisPric.SummaryGroup = "SumAccPaymentHeader";
            this.ThisRgdsDisPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisRgdsDisPric.Text = "1,234,567,890";
            this.ThisRgdsDisPric.Top = 0F;
            this.ThisRgdsDisPric.Width = 0.8125F;
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
            this.SumPayeeCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SumPayeeCode.Text = "123456";
            this.SumPayeeCode.Top = 0F;
            this.SumPayeeCode.Width = 0.4375F;
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
            this.SumPayeeSnm.Left = 0.5F;
            this.SumPayeeSnm.MultiLine = false;
            this.SumPayeeSnm.Name = "SumPayeeSnm";
            this.SumPayeeSnm.OutputFormat = resources.GetString("SumPayeeSnm.OutputFormat");
            this.SumPayeeSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SumPayeeSnm.Text = "支払先略称６７８９０１２３４５６７８９０";
            this.SumPayeeSnm.Top = 0F;
            this.SumPayeeSnm.Width = 2.25F;
            // 
            // PureStock
            // 
            this.PureStock.Border.BottomColor = System.Drawing.Color.Black;
            this.PureStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.Border.LeftColor = System.Drawing.Color.Black;
            this.PureStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.Border.RightColor = System.Drawing.Color.Black;
            this.PureStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.Border.TopColor = System.Drawing.Color.Black;
            this.PureStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PureStock.DataField = "PureStock";
            this.PureStock.Height = 0.125F;
            this.PureStock.Left = 6.875F;
            this.PureStock.MultiLine = false;
            this.PureStock.Name = "PureStock";
            this.PureStock.OutputFormat = resources.GetString("PureStock.OutputFormat");
            this.PureStock.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.PureStock.SummaryGroup = "SumAccPaymentHeader";
            this.PureStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.PureStock.Text = "1,234,567,890";
            this.PureStock.Top = 0F;
            this.PureStock.Width = 0.8125F;
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
            this.OfsThisStockTax.Left = 7.6875F;
            this.OfsThisStockTax.MultiLine = false;
            this.OfsThisStockTax.Name = "OfsThisStockTax";
            this.OfsThisStockTax.OutputFormat = resources.GetString("OfsThisStockTax.OutputFormat");
            this.OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OfsThisStockTax.SummaryGroup = "SumAccPaymentHeader";
            this.OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.OfsThisStockTax.Text = "1,234,567,890";
            this.OfsThisStockTax.Top = 0F;
            this.OfsThisStockTax.Width = 0.8125F;
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
            this.StockSlipCount.Left = 10.1875F;
            this.StockSlipCount.MultiLine = false;
            this.StockSlipCount.Name = "StockSlipCount";
            this.StockSlipCount.OutputFormat = resources.GetString("StockSlipCount.OutputFormat");
            this.StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockSlipCount.SummaryGroup = "SumAccPaymentHeader";
            this.StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockSlipCount.Text = "234,567";
            this.StockSlipCount.Top = 0F;
            this.StockSlipCount.Width = 0.5F;
            // 
            // StockPricTax
            // 
            this.StockPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.StockPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPricTax.DataField = "StockPricTax";
            this.StockPricTax.Height = 0.125F;
            this.StockPricTax.Left = 8.5F;
            this.StockPricTax.MultiLine = false;
            this.StockPricTax.Name = "StockPricTax";
            this.StockPricTax.OutputFormat = resources.GetString("StockPricTax.OutputFormat");
            this.StockPricTax.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StockPricTax.SummaryGroup = "SumAccPaymentHeader";
            this.StockPricTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StockPricTax.Text = "1,234,567,890";
            this.StockPricTax.Top = 0F;
            this.StockPricTax.Width = 0.8125F;
            // 
            // StckTtlAccPayBalance
            // 
            this.StckTtlAccPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.StckTtlAccPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StckTtlAccPayBalance.DataField = "StckTtlAccPayBalance";
            this.StckTtlAccPayBalance.Height = 0.125F;
            this.StckTtlAccPayBalance.Left = 9.3125F;
            this.StckTtlAccPayBalance.MultiLine = false;
            this.StckTtlAccPayBalance.Name = "StckTtlAccPayBalance";
            this.StckTtlAccPayBalance.OutputFormat = resources.GetString("StckTtlAccPayBalance.OutputFormat");
            this.StckTtlAccPayBalance.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.StckTtlAccPayBalance.SummaryGroup = "SumAccPaymentHeader";
            this.StckTtlAccPayBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.StckTtlAccPayBalance.Text = "1,234,567,890";
            this.StckTtlAccPayBalance.Top = 0F;
            this.StckTtlAccPayBalance.Width = 0.8125F;
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
            this.CashPayment.Left = 2.8125F;
            this.CashPayment.MultiLine = false;
            this.CashPayment.Name = "CashPayment";
            this.CashPayment.OutputFormat = resources.GetString("CashPayment.OutputFormat");
            this.CashPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CashPayment.SummaryGroup = "SumAccPaymentHeader";
            this.CashPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CashPayment.Text = "11,234,567,890";
            this.CashPayment.Top = 0.125F;
            this.CashPayment.Width = 0.8125F;
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
            this.TrfrPayment.Left = 3.625F;
            this.TrfrPayment.MultiLine = false;
            this.TrfrPayment.Name = "TrfrPayment";
            this.TrfrPayment.OutputFormat = resources.GetString("TrfrPayment.OutputFormat");
            this.TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.TrfrPayment.SummaryGroup = "SumAccPaymentHeader";
            this.TrfrPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TrfrPayment.Text = "11,234,567,890";
            this.TrfrPayment.Top = 0.125F;
            this.TrfrPayment.Width = 0.8125F;
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
            this.CheckPayment.Left = 4.4375F;
            this.CheckPayment.MultiLine = false;
            this.CheckPayment.Name = "CheckPayment";
            this.CheckPayment.OutputFormat = resources.GetString("CheckPayment.OutputFormat");
            this.CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.CheckPayment.SummaryGroup = "SumAccPaymentHeader";
            this.CheckPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.CheckPayment.Text = "11,234,567,890";
            this.CheckPayment.Top = 0.125F;
            this.CheckPayment.Width = 0.8125F;
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
            this.DraftPayment.Left = 5.25F;
            this.DraftPayment.MultiLine = false;
            this.DraftPayment.Name = "DraftPayment";
            this.DraftPayment.OutputFormat = resources.GetString("DraftPayment.OutputFormat");
            this.DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.DraftPayment.SummaryGroup = "SumAccPaymentHeader";
            this.DraftPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.DraftPayment.Text = "11,234,567,890";
            this.DraftPayment.Top = 0.125F;
            this.DraftPayment.Width = 0.8125F;
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
            this.OffsetPayment.Left = 6.0625F;
            this.OffsetPayment.MultiLine = false;
            this.OffsetPayment.Name = "OffsetPayment";
            this.OffsetPayment.OutputFormat = resources.GetString("OffsetPayment.OutputFormat");
            this.OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OffsetPayment.SummaryGroup = "SumAccPaymentHeader";
            this.OffsetPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.OffsetPayment.Text = "11,234,567,890";
            this.OffsetPayment.Top = 0.125F;
            this.OffsetPayment.Width = 0.8125F;
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
            this.FundTransferPayment.Left = 7.6875F;
            this.FundTransferPayment.MultiLine = false;
            this.FundTransferPayment.Name = "FundTransferPayment";
            this.FundTransferPayment.OutputFormat = resources.GetString("FundTransferPayment.OutputFormat");
            this.FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.FundTransferPayment.SummaryGroup = "SumAccPaymentHeader";
            this.FundTransferPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.FundTransferPayment.Text = "11,234,567,890";
            this.FundTransferPayment.Top = 0.125F;
            this.FundTransferPayment.Width = 0.8125F;
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
            this.OthsPayment.Left = 6.875F;
            this.OthsPayment.MultiLine = false;
            this.OthsPayment.Name = "OthsPayment";
            this.OthsPayment.OutputFormat = resources.GetString("OthsPayment.OutputFormat");
            this.OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.OthsPayment.SummaryGroup = "SumAccPaymentHeader";
            this.OthsPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.OthsPayment.Text = "11,234,567,890";
            this.OthsPayment.Top = 0.125F;
            this.OthsPayment.Width = 0.8125F;
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
            this.ThisTimeFeePayNrml.Left = 8.5F;
            this.ThisTimeFeePayNrml.MultiLine = false;
            this.ThisTimeFeePayNrml.Name = "ThisTimeFeePayNrml";
            this.ThisTimeFeePayNrml.OutputFormat = resources.GetString("ThisTimeFeePayNrml.OutputFormat");
            this.ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeFeePayNrml.SummaryGroup = "SumAccPaymentHeader";
            this.ThisTimeFeePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeFeePayNrml.Text = "11,234,567,890";
            this.ThisTimeFeePayNrml.Top = 0.125F;
            this.ThisTimeFeePayNrml.Width = 0.8125F;
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
            this.ThisTimeDisPayNrml.Left = 9.3125F;
            this.ThisTimeDisPayNrml.MultiLine = false;
            this.ThisTimeDisPayNrml.Name = "ThisTimeDisPayNrml";
            this.ThisTimeDisPayNrml.OutputFormat = resources.GetString("ThisTimeDisPayNrml.OutputFormat");
            this.ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ThisTimeDisPayNrml.SummaryGroup = "SumAccPaymentHeader";
            this.ThisTimeDisPayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ThisTimeDisPayNrml.Text = "11,234,567,890";
            this.ThisTimeDisPayNrml.Top = 0.125F;
            this.ThisTimeDisPayNrml.Width = 0.8125F;
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
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.tb_SortOrderName,
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
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "買掛残高一覧表(総括)";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            this.tb_SortOrderName.Text = null;
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
            this.Header_SubReport,
            this.Label_Tax});
            this.ExtraHeader.Height = 0.3125F;
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
            // Label_Tax
            // 
            this.Label_Tax.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Tax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Tax.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Tax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Tax.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Tax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Tax.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Tax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Tax.Height = 0.125F;
            this.Label_Tax.HyperLink = "";
            this.Label_Tax.Left = 7.9375F;
            this.Label_Tax.MultiLine = false;
            this.Label_Tax.Name = "Label_Tax";
            this.Label_Tax.Style = "ddo-char-set: 128; text-align: left; font-weight: normal; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Label_Tax.Text = "｢当該月は、月次更新未処理です｣";
            this.Label_Tax.Top = 0.125F;
            this.Label_Tax.Visible = false;
            this.Label_Tax.Width = 1.75F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label104,
            this.Label105,
            this.Label106,
            this.Label107,
            this.Line42,
            this.tb_AddUpSecName_Title,
            this.Label2,
            this.Label5,
            this.Label7,
            this.Label8,
            this.label3,
            this.label6,
            this.Label_Payee1,
            this.Label_Payee2,
            this.Label_Payee3,
            this.Label_Payee4,
            this.Label_Payee5,
            this.Label_Payee6,
            this.Label_Payee7,
            this.Label_Payee8,
            this.Label_Payee9,
            this.label9});
            this.TitleHeader.Height = 0.4583333F;
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
            this.Label104.Height = 0.1875F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.Label104.Text = "仕入先";
            this.Label104.Top = 0.1875F;
            this.Label104.Width = 0.5625F;
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
            this.Label105.Height = 0.1875F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 2.8125F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label105.Text = "前月買掛残";
            this.Label105.Top = 0F;
            this.Label105.Width = 0.8125F;
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
            this.Label106.Height = 0.1875F;
            this.Label106.HyperLink = "";
            this.Label106.Left = 3.6875F;
            this.Label106.MultiLine = false;
            this.Label106.Name = "Label106";
            this.Label106.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label106.Text = "当月支払";
            this.Label106.Top = 0F;
            this.Label106.Width = 0.75F;
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
            this.Label107.Height = 0.1875F;
            this.Label107.HyperLink = "";
            this.Label107.Left = 4.625F;
            this.Label107.MultiLine = false;
            this.Label107.Name = "Label107";
            this.Label107.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label107.Text = "繰越額";
            this.Label107.Top = 0F;
            this.Label107.Width = 0.625F;
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
            this.tb_AddUpSecName_Title.Height = 0.1875F;
            this.tb_AddUpSecName_Title.Left = 10.1875F;
            this.tb_AddUpSecName_Title.MultiLine = false;
            this.tb_AddUpSecName_Title.Name = "tb_AddUpSecName_Title";
            this.tb_AddUpSecName_Title.OutputFormat = resources.GetString("tb_AddUpSecName_Title.OutputFormat");
            this.tb_AddUpSecName_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_AddUpSecName_Title.Text = "枚数";
            this.tb_AddUpSecName_Title.Top = 0F;
            this.tb_AddUpSecName_Title.Width = 0.5F;
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
            this.Label2.Height = 0.1875F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 5.375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label2.Text = "仕入額";
            this.Label2.Top = 0F;
            this.Label2.Width = 0.6875F;
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
            this.Label5.Height = 0.1875F;
            this.Label5.HyperLink = "";
            this.Label5.Left = 6.25F;
            this.Label5.MultiLine = false;
            this.Label5.Name = "Label5";
            this.Label5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label5.Text = "返品値引";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.625F;
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
            this.Label7.Height = 0.1875F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 7.0625F;
            this.Label7.MultiLine = false;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label7.Text = "純仕入額";
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
            this.Label8.Height = 0.1875F;
            this.Label8.HyperLink = "";
            this.Label8.Left = 7.875F;
            this.Label8.MultiLine = false;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label8.Text = "消費税";
            this.Label8.Top = 0F;
            this.Label8.Width = 0.625F;
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
            this.label3.Height = 0.1875F;
            this.label3.HyperLink = "";
            this.label3.Left = 8.6875F;
            this.label3.MultiLine = false;
            this.label3.Name = "label3";
            this.label3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label3.Text = "当月合計";
            this.label3.Top = 0F;
            this.label3.Width = 0.625F;
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
            this.label6.Height = 0.1875F;
            this.label6.HyperLink = "";
            this.label6.Left = 9.4375F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.label6.Text = "当月末残高";
            this.label6.Top = 0F;
            this.label6.Width = 0.6875F;
            // 
            // Label_Payee1
            // 
            this.Label_Payee1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee1.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee1.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee1.Height = 0.1875F;
            this.Label_Payee1.HyperLink = "";
            this.Label_Payee1.Left = 2.8125F;
            this.Label_Payee1.MultiLine = false;
            this.Label_Payee1.Name = "Label_Payee1";
            this.Label_Payee1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee1.Text = "現金";
            this.Label_Payee1.Top = 0.1875F;
            this.Label_Payee1.Width = 0.8125F;
            // 
            // Label_Payee2
            // 
            this.Label_Payee2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee2.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee2.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee2.Height = 0.1875F;
            this.Label_Payee2.HyperLink = "";
            this.Label_Payee2.Left = 3.6875F;
            this.Label_Payee2.MultiLine = false;
            this.Label_Payee2.Name = "Label_Payee2";
            this.Label_Payee2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee2.Text = "振込";
            this.Label_Payee2.Top = 0.1875F;
            this.Label_Payee2.Width = 0.75F;
            // 
            // Label_Payee3
            // 
            this.Label_Payee3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee3.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee3.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee3.Height = 0.1875F;
            this.Label_Payee3.HyperLink = "";
            this.Label_Payee3.Left = 4.625F;
            this.Label_Payee3.MultiLine = false;
            this.Label_Payee3.Name = "Label_Payee3";
            this.Label_Payee3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee3.Text = "小切手";
            this.Label_Payee3.Top = 0.1875F;
            this.Label_Payee3.Width = 0.625F;
            // 
            // Label_Payee4
            // 
            this.Label_Payee4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee4.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee4.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee4.Height = 0.1875F;
            this.Label_Payee4.HyperLink = "";
            this.Label_Payee4.Left = 5.375F;
            this.Label_Payee4.MultiLine = false;
            this.Label_Payee4.Name = "Label_Payee4";
            this.Label_Payee4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee4.Text = "手形";
            this.Label_Payee4.Top = 0.1875F;
            this.Label_Payee4.Width = 0.6875F;
            // 
            // Label_Payee5
            // 
            this.Label_Payee5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee5.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee5.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee5.Height = 0.1875F;
            this.Label_Payee5.HyperLink = "";
            this.Label_Payee5.Left = 6.25F;
            this.Label_Payee5.MultiLine = false;
            this.Label_Payee5.Name = "Label_Payee5";
            this.Label_Payee5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee5.Text = "相殺";
            this.Label_Payee5.Top = 0.1875F;
            this.Label_Payee5.Width = 0.625F;
            // 
            // Label_Payee6
            // 
            this.Label_Payee6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee6.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee6.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee6.Height = 0.1875F;
            this.Label_Payee6.HyperLink = "";
            this.Label_Payee6.Left = 7.0625F;
            this.Label_Payee6.MultiLine = false;
            this.Label_Payee6.Name = "Label_Payee6";
            this.Label_Payee6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee6.Text = "その他";
            this.Label_Payee6.Top = 0.1875F;
            this.Label_Payee6.Width = 0.625F;
            // 
            // Label_Payee7
            // 
            this.Label_Payee7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee7.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee7.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee7.Height = 0.1875F;
            this.Label_Payee7.HyperLink = "";
            this.Label_Payee7.Left = 7.875F;
            this.Label_Payee7.MultiLine = false;
            this.Label_Payee7.Name = "Label_Payee7";
            this.Label_Payee7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee7.Text = "口座振替";
            this.Label_Payee7.Top = 0.1875F;
            this.Label_Payee7.Width = 0.625F;
            // 
            // Label_Payee8
            // 
            this.Label_Payee8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee8.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee8.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee8.Height = 0.1875F;
            this.Label_Payee8.HyperLink = "";
            this.Label_Payee8.Left = 8.6875F;
            this.Label_Payee8.MultiLine = false;
            this.Label_Payee8.Name = "Label_Payee8";
            this.Label_Payee8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee8.Text = "手数料";
            this.Label_Payee8.Top = 0.1875F;
            this.Label_Payee8.Width = 0.625F;
            // 
            // Label_Payee9
            // 
            this.Label_Payee9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Payee9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Payee9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee9.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Payee9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee9.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Payee9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Payee9.Height = 0.1875F;
            this.Label_Payee9.HyperLink = "";
            this.Label_Payee9.Left = 9.4375F;
            this.Label_Payee9.MultiLine = false;
            this.Label_Payee9.Name = "Label_Payee9";
            this.Label_Payee9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: middle; ";
            this.Label_Payee9.Text = "値引";
            this.Label_Payee9.Top = 0.1875F;
            this.Label_Payee9.Width = 0.6875F;
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
            this.label9.Height = 0.1875F;
            this.label9.HyperLink = "";
            this.label9.Left = 0F;
            this.label9.MultiLine = false;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: middle; ";
            this.label9.Text = "拠点";
            this.label9.Top = 0F;
            this.label9.Width = 0.5625F;
            // 
            // TitleFooter
            // 
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
            this.Total_LastTimeAccPay,
            this.Total_ThisTimePayNrml,
            this.Total_ThisTimeTtlBlcAcPay,
            this.g_PureStock,
            this.g_ThisTimeStockPrice,
            this.g_ThisRgdsDisPric,
            this.Total_OfsThisStockTax,
            this.Total_StockSlipCount,
            this.Total_StockPricTax,
            this.Total_StckTtlAccPayBalance,
            this.g_CashPayment,
            this.g_TrfrPayment,
            this.g_CheckPayment,
            this.g_DraftPayment,
            this.g_OffsetPayment,
            this.g_FundTransferPayment,
            this.g_OthsPayment,
            this.g_ThisTimeFeePayNrml,
            this.g_ThisTimeDisPayNrml});
            this.GrandTotalFooter.Height = 0.34375F;
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
            this.Label109.Height = 0.1875F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 0.1875F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Label109.Text = "総合計";
            this.Label109.Top = 0.0625F;
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
            // Total_LastTimeAccPay
            // 
            this.Total_LastTimeAccPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccPay.Border.RightColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccPay.Border.TopColor = System.Drawing.Color.Black;
            this.Total_LastTimeAccPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_LastTimeAccPay.DataField = "LastTimeAccPay";
            this.Total_LastTimeAccPay.Height = 0.125F;
            this.Total_LastTimeAccPay.Left = 2.8125F;
            this.Total_LastTimeAccPay.MultiLine = false;
            this.Total_LastTimeAccPay.Name = "Total_LastTimeAccPay";
            this.Total_LastTimeAccPay.OutputFormat = resources.GetString("Total_LastTimeAccPay.OutputFormat");
            this.Total_LastTimeAccPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_LastTimeAccPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_LastTimeAccPay.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_LastTimeAccPay.Text = "1,234,567,890";
            this.Total_LastTimeAccPay.Top = 0F;
            this.Total_LastTimeAccPay.Width = 0.8125F;
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
            this.Total_ThisTimePayNrml.Left = 3.625F;
            this.Total_ThisTimePayNrml.MultiLine = false;
            this.Total_ThisTimePayNrml.Name = "Total_ThisTimePayNrml";
            this.Total_ThisTimePayNrml.OutputFormat = resources.GetString("Total_ThisTimePayNrml.OutputFormat");
            this.Total_ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimePayNrml.Text = "1,234,567,890";
            this.Total_ThisTimePayNrml.Top = 0F;
            this.Total_ThisTimePayNrml.Width = 0.8125F;
            // 
            // Total_ThisTimeTtlBlcAcPay
            // 
            this.Total_ThisTimeTtlBlcAcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcPay.Border.RightColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcPay.Border.TopColor = System.Drawing.Color.Black;
            this.Total_ThisTimeTtlBlcAcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_ThisTimeTtlBlcAcPay.DataField = "ThisTimeTtlBlcAcPay";
            this.Total_ThisTimeTtlBlcAcPay.Height = 0.125F;
            this.Total_ThisTimeTtlBlcAcPay.Left = 4.4375F;
            this.Total_ThisTimeTtlBlcAcPay.MultiLine = false;
            this.Total_ThisTimeTtlBlcAcPay.Name = "Total_ThisTimeTtlBlcAcPay";
            this.Total_ThisTimeTtlBlcAcPay.OutputFormat = resources.GetString("Total_ThisTimeTtlBlcAcPay.OutputFormat");
            this.Total_ThisTimeTtlBlcAcPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_ThisTimeTtlBlcAcPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_ThisTimeTtlBlcAcPay.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_ThisTimeTtlBlcAcPay.Text = "1,234,567,890";
            this.Total_ThisTimeTtlBlcAcPay.Top = 0F;
            this.Total_ThisTimeTtlBlcAcPay.Width = 0.8125F;
            // 
            // g_PureStock
            // 
            this.g_PureStock.Border.BottomColor = System.Drawing.Color.Black;
            this.g_PureStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureStock.Border.LeftColor = System.Drawing.Color.Black;
            this.g_PureStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureStock.Border.RightColor = System.Drawing.Color.Black;
            this.g_PureStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureStock.Border.TopColor = System.Drawing.Color.Black;
            this.g_PureStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_PureStock.DataField = "PureStock";
            this.g_PureStock.Height = 0.125F;
            this.g_PureStock.Left = 6.875F;
            this.g_PureStock.MultiLine = false;
            this.g_PureStock.Name = "g_PureStock";
            this.g_PureStock.OutputFormat = resources.GetString("g_PureStock.OutputFormat");
            this.g_PureStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_PureStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_PureStock.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_PureStock.Text = "1,234,567,890";
            this.g_PureStock.Top = 0F;
            this.g_PureStock.Width = 0.8125F;
            // 
            // g_ThisTimeStockPrice
            // 
            this.g_ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.g_ThisTimeStockPrice.Height = 0.125F;
            this.g_ThisTimeStockPrice.Left = 5.25F;
            this.g_ThisTimeStockPrice.MultiLine = false;
            this.g_ThisTimeStockPrice.Name = "g_ThisTimeStockPrice";
            this.g_ThisTimeStockPrice.OutputFormat = resources.GetString("g_ThisTimeStockPrice.OutputFormat");
            this.g_ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeStockPrice.Text = "1,234,567,890";
            this.g_ThisTimeStockPrice.Top = 0F;
            this.g_ThisTimeStockPrice.Width = 0.8125F;
            // 
            // g_ThisRgdsDisPric
            // 
            this.g_ThisRgdsDisPric.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisRgdsDisPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisRgdsDisPric.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisRgdsDisPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisRgdsDisPric.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisRgdsDisPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisRgdsDisPric.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisRgdsDisPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisRgdsDisPric.DataField = "ThisRgdsDisPric";
            this.g_ThisRgdsDisPric.Height = 0.125F;
            this.g_ThisRgdsDisPric.Left = 6.0625F;
            this.g_ThisRgdsDisPric.MultiLine = false;
            this.g_ThisRgdsDisPric.Name = "g_ThisRgdsDisPric";
            this.g_ThisRgdsDisPric.OutputFormat = resources.GetString("g_ThisRgdsDisPric.OutputFormat");
            this.g_ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisRgdsDisPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisRgdsDisPric.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisRgdsDisPric.Text = "1,234,567,890";
            this.g_ThisRgdsDisPric.Top = 0F;
            this.g_ThisRgdsDisPric.Width = 0.8125F;
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
            this.Total_OfsThisStockTax.Left = 7.6875F;
            this.Total_OfsThisStockTax.MultiLine = false;
            this.Total_OfsThisStockTax.Name = "Total_OfsThisStockTax";
            this.Total_OfsThisStockTax.OutputFormat = resources.GetString("Total_OfsThisStockTax.OutputFormat");
            this.Total_OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_OfsThisStockTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_OfsThisStockTax.Text = "1,234,567,890";
            this.Total_OfsThisStockTax.Top = 0F;
            this.Total_OfsThisStockTax.Width = 0.8125F;
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
            this.Total_StockSlipCount.Left = 10.1875F;
            this.Total_StockSlipCount.MultiLine = false;
            this.Total_StockSlipCount.Name = "Total_StockSlipCount";
            this.Total_StockSlipCount.OutputFormat = resources.GetString("Total_StockSlipCount.OutputFormat");
            this.Total_StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_StockSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_StockSlipCount.Text = "234,567";
            this.Total_StockSlipCount.Top = 0F;
            this.Total_StockSlipCount.Width = 0.5F;
            // 
            // Total_StockPricTax
            // 
            this.Total_StockPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_StockPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_StockPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.Total_StockPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.Total_StockPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StockPricTax.DataField = "StockPricTax";
            this.Total_StockPricTax.Height = 0.125F;
            this.Total_StockPricTax.Left = 8.5F;
            this.Total_StockPricTax.MultiLine = false;
            this.Total_StockPricTax.Name = "Total_StockPricTax";
            this.Total_StockPricTax.OutputFormat = resources.GetString("Total_StockPricTax.OutputFormat");
            this.Total_StockPricTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_StockPricTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_StockPricTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_StockPricTax.Text = "1,234,567,890";
            this.Total_StockPricTax.Top = 0F;
            this.Total_StockPricTax.Width = 0.8125F;
            // 
            // Total_StckTtlAccPayBalance
            // 
            this.Total_StckTtlAccPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_StckTtlAccPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StckTtlAccPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_StckTtlAccPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StckTtlAccPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.Total_StckTtlAccPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StckTtlAccPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.Total_StckTtlAccPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_StckTtlAccPayBalance.DataField = "StckTtlAccPayBalance";
            this.Total_StckTtlAccPayBalance.Height = 0.125F;
            this.Total_StckTtlAccPayBalance.Left = 9.3125F;
            this.Total_StckTtlAccPayBalance.MultiLine = false;
            this.Total_StckTtlAccPayBalance.Name = "Total_StckTtlAccPayBalance";
            this.Total_StckTtlAccPayBalance.OutputFormat = resources.GetString("Total_StckTtlAccPayBalance.OutputFormat");
            this.Total_StckTtlAccPayBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Total_StckTtlAccPayBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.Total_StckTtlAccPayBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.Total_StckTtlAccPayBalance.Text = "1,234,567,890";
            this.Total_StckTtlAccPayBalance.Top = 0F;
            this.Total_StckTtlAccPayBalance.Width = 0.8125F;
            // 
            // g_CashPayment
            // 
            this.g_CashPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CashPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CashPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_CashPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_CashPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment.DataField = "CashPayment";
            this.g_CashPayment.Height = 0.125F;
            this.g_CashPayment.Left = 2.8125F;
            this.g_CashPayment.MultiLine = false;
            this.g_CashPayment.Name = "g_CashPayment";
            this.g_CashPayment.OutputFormat = resources.GetString("g_CashPayment.OutputFormat");
            this.g_CashPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CashPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CashPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CashPayment.Text = "1,234,567,890";
            this.g_CashPayment.Top = 0.125F;
            this.g_CashPayment.Width = 0.8125F;
            // 
            // g_TrfrPayment
            // 
            this.g_TrfrPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TrfrPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TrfrPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_TrfrPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_TrfrPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment.DataField = "TrfrPayment";
            this.g_TrfrPayment.Height = 0.125F;
            this.g_TrfrPayment.Left = 3.625F;
            this.g_TrfrPayment.MultiLine = false;
            this.g_TrfrPayment.Name = "g_TrfrPayment";
            this.g_TrfrPayment.OutputFormat = resources.GetString("g_TrfrPayment.OutputFormat");
            this.g_TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TrfrPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TrfrPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TrfrPayment.Text = "1,234,567,890";
            this.g_TrfrPayment.Top = 0.125F;
            this.g_TrfrPayment.Width = 0.8125F;
            // 
            // g_CheckPayment
            // 
            this.g_CheckPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CheckPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CheckPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_CheckPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_CheckPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment.DataField = "CheckPayment";
            this.g_CheckPayment.Height = 0.125F;
            this.g_CheckPayment.Left = 4.4375F;
            this.g_CheckPayment.MultiLine = false;
            this.g_CheckPayment.Name = "g_CheckPayment";
            this.g_CheckPayment.OutputFormat = resources.GetString("g_CheckPayment.OutputFormat");
            this.g_CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CheckPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CheckPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CheckPayment.Text = "1,234,567,890";
            this.g_CheckPayment.Top = 0.125F;
            this.g_CheckPayment.Width = 0.8125F;
            // 
            // g_DraftPayment
            // 
            this.g_DraftPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_DraftPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_DraftPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_DraftPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_DraftPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment.DataField = "DraftPayment";
            this.g_DraftPayment.Height = 0.125F;
            this.g_DraftPayment.Left = 5.25F;
            this.g_DraftPayment.MultiLine = false;
            this.g_DraftPayment.Name = "g_DraftPayment";
            this.g_DraftPayment.OutputFormat = resources.GetString("g_DraftPayment.OutputFormat");
            this.g_DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_DraftPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_DraftPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_DraftPayment.Text = "1,234,567,890";
            this.g_DraftPayment.Top = 0.125F;
            this.g_DraftPayment.Width = 0.8125F;
            // 
            // g_OffsetPayment
            // 
            this.g_OffsetPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OffsetPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OffsetPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_OffsetPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_OffsetPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment.DataField = "OffsetPayment";
            this.g_OffsetPayment.Height = 0.125F;
            this.g_OffsetPayment.Left = 6.0625F;
            this.g_OffsetPayment.MultiLine = false;
            this.g_OffsetPayment.Name = "g_OffsetPayment";
            this.g_OffsetPayment.OutputFormat = resources.GetString("g_OffsetPayment.OutputFormat");
            this.g_OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OffsetPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OffsetPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OffsetPayment.Text = "1,234,567,890";
            this.g_OffsetPayment.Top = 0.125F;
            this.g_OffsetPayment.Width = 0.8125F;
            // 
            // g_FundTransferPayment
            // 
            this.g_FundTransferPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment.DataField = "FundTransferPayment";
            this.g_FundTransferPayment.Height = 0.125F;
            this.g_FundTransferPayment.Left = 7.6875F;
            this.g_FundTransferPayment.MultiLine = false;
            this.g_FundTransferPayment.Name = "g_FundTransferPayment";
            this.g_FundTransferPayment.OutputFormat = resources.GetString("g_FundTransferPayment.OutputFormat");
            this.g_FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_FundTransferPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_FundTransferPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_FundTransferPayment.Text = "1,234,567,890";
            this.g_FundTransferPayment.Top = 0.125F;
            this.g_FundTransferPayment.Width = 0.8125F;
            // 
            // g_OthsPayment
            // 
            this.g_OthsPayment.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OthsPayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OthsPayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment.Border.RightColor = System.Drawing.Color.Black;
            this.g_OthsPayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment.Border.TopColor = System.Drawing.Color.Black;
            this.g_OthsPayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment.DataField = "OthsPayment";
            this.g_OthsPayment.Height = 0.125F;
            this.g_OthsPayment.Left = 6.875F;
            this.g_OthsPayment.MultiLine = false;
            this.g_OthsPayment.Name = "g_OthsPayment";
            this.g_OthsPayment.OutputFormat = resources.GetString("g_OthsPayment.OutputFormat");
            this.g_OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OthsPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OthsPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OthsPayment.Text = "1,234,567,890";
            this.g_OthsPayment.Top = 0.125F;
            this.g_OthsPayment.Width = 0.8125F;
            // 
            // g_ThisTimeFeePayNrml
            // 
            this.g_ThisTimeFeePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml.DataField = "ThisTimeFeePayNrml";
            this.g_ThisTimeFeePayNrml.Height = 0.125F;
            this.g_ThisTimeFeePayNrml.Left = 8.5F;
            this.g_ThisTimeFeePayNrml.MultiLine = false;
            this.g_ThisTimeFeePayNrml.Name = "g_ThisTimeFeePayNrml";
            this.g_ThisTimeFeePayNrml.OutputFormat = resources.GetString("g_ThisTimeFeePayNrml.OutputFormat");
            this.g_ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeFeePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeFeePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeFeePayNrml.Text = "1,234,567,890";
            this.g_ThisTimeFeePayNrml.Top = 0.125F;
            this.g_ThisTimeFeePayNrml.Width = 0.8125F;
            // 
            // g_ThisTimeDisPayNrml
            // 
            this.g_ThisTimeDisPayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml.DataField = "ThisTimeDisPayNrml";
            this.g_ThisTimeDisPayNrml.Height = 0.125F;
            this.g_ThisTimeDisPayNrml.Left = 9.3125F;
            this.g_ThisTimeDisPayNrml.MultiLine = false;
            this.g_ThisTimeDisPayNrml.Name = "g_ThisTimeDisPayNrml";
            this.g_ThisTimeDisPayNrml.OutputFormat = resources.GetString("g_ThisTimeDisPayNrml.OutputFormat");
            this.g_ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeDisPayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDisPayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDisPayNrml.Text = "1,234,567,890";
            this.g_ThisTimeDisPayNrml.Top = 0.125F;
            this.g_ThisTimeDisPayNrml.Width = 0.8125F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SumAddUpSecCode,
            this.SumSectionGuideNm,
            this.Line37,
            this.MonAddUpNonProc});
            this.SectionHeader.DataField = "SumAddUpSecCode";
            this.SectionHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
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
            this.SumAddUpSecCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-" +
                "space: inherit; vertical-align: top; ";
            this.SumAddUpSecCode.Text = "00";
            this.SumAddUpSecCode.Top = 0F;
            this.SumAddUpSecCode.Width = 0.1875F;
            // 
            // SumSectionGuideNm
            // 
            this.SumSectionGuideNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SumSectionGuideNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumSectionGuideNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SumSectionGuideNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumSectionGuideNm.Border.RightColor = System.Drawing.Color.Black;
            this.SumSectionGuideNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumSectionGuideNm.Border.TopColor = System.Drawing.Color.Black;
            this.SumSectionGuideNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SumSectionGuideNm.DataField = "SumSectionGuideNm";
            this.SumSectionGuideNm.Height = 0.125F;
            this.SumSectionGuideNm.Left = 0.25F;
            this.SumSectionGuideNm.MultiLine = false;
            this.SumSectionGuideNm.Name = "SumSectionGuideNm";
            this.SumSectionGuideNm.Style = "text-align: left; font-size: 8pt; white-space: inherit; vertical-align: top; ";
            this.SumSectionGuideNm.Text = "拠点３４５６７８９０";
            this.SumSectionGuideNm.Top = 0F;
            this.SumSectionGuideNm.Width = 1.1875F;
            // 
            // MonAddUpNonProc
            // 
            this.MonAddUpNonProc.Border.BottomColor = System.Drawing.Color.Black;
            this.MonAddUpNonProc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonAddUpNonProc.Border.LeftColor = System.Drawing.Color.Black;
            this.MonAddUpNonProc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonAddUpNonProc.Border.RightColor = System.Drawing.Color.Black;
            this.MonAddUpNonProc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonAddUpNonProc.Border.TopColor = System.Drawing.Color.Black;
            this.MonAddUpNonProc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MonAddUpNonProc.DataField = "MonAddUpNonProc";
            this.MonAddUpNonProc.Height = 0.125F;
            this.MonAddUpNonProc.Left = 1.5F;
            this.MonAddUpNonProc.MultiLine = false;
            this.MonAddUpNonProc.Name = "MonAddUpNonProc";
            this.MonAddUpNonProc.OutputFormat = resources.GetString("MonAddUpNonProc.OutputFormat");
            this.MonAddUpNonProc.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-" +
                "space: inherit; vertical-align: top; ";
            this.MonAddUpNonProc.Text = null;
            this.MonAddUpNonProc.Top = 0F;
            this.MonAddUpNonProc.Visible = false;
            this.MonAddUpNonProc.Width = 0.1875F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line45,
            this.MONEYKINDNAME13,
            this.Section_LastTimeAccPay,
            this.Section_ThisTimePayNrml,
            this.Section_ThisTimeTtlBlcAcPay,
            this.Section_OfsThisStockTax,
            this.s_ThisTimeStockPrice,
            this.s_ThisRgdsDisPric,
            this.s_PureStock,
            this.Section_StockSlipCount,
            this.Section_StockPricTax,
            this.Section_StckTtlAccPayBalance,
            this.s_CashPayment,
            this.s_TrfrPayment,
            this.s_CheckPayment,
            this.s_DraftPayment,
            this.s_OffsetPayment,
            this.s_FundTransferPayment,
            this.s_OthsPayment,
            this.s_ThisTimeFeePayNrml,
            this.s_ThisTimeDisPayNrml});
            this.SectionFooter.Height = 0.3333333F;
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
            this.MONEYKINDNAME13.Height = 0.15625F;
            this.MONEYKINDNAME13.Left = 0.1875F;
            this.MONEYKINDNAME13.MultiLine = false;
            this.MONEYKINDNAME13.Name = "MONEYKINDNAME13";
            this.MONEYKINDNAME13.OutputFormat = resources.GetString("MONEYKINDNAME13.OutputFormat");
            this.MONEYKINDNAME13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.MONEYKINDNAME13.Text = "拠点計";
            this.MONEYKINDNAME13.Top = 0.0625F;
            this.MONEYKINDNAME13.Width = 0.5625F;
            // 
            // Section_LastTimeAccPay
            // 
            this.Section_LastTimeAccPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccPay.Border.RightColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccPay.Border.TopColor = System.Drawing.Color.Black;
            this.Section_LastTimeAccPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_LastTimeAccPay.DataField = "LastTimeAccPay";
            this.Section_LastTimeAccPay.Height = 0.125F;
            this.Section_LastTimeAccPay.Left = 2.8125F;
            this.Section_LastTimeAccPay.MultiLine = false;
            this.Section_LastTimeAccPay.Name = "Section_LastTimeAccPay";
            this.Section_LastTimeAccPay.OutputFormat = resources.GetString("Section_LastTimeAccPay.OutputFormat");
            this.Section_LastTimeAccPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_LastTimeAccPay.SummaryGroup = "SectionHeader";
            this.Section_LastTimeAccPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_LastTimeAccPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_LastTimeAccPay.Text = "1,234,567,890";
            this.Section_LastTimeAccPay.Top = 0F;
            this.Section_LastTimeAccPay.Width = 0.8125F;
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
            this.Section_ThisTimePayNrml.Left = 3.625F;
            this.Section_ThisTimePayNrml.MultiLine = false;
            this.Section_ThisTimePayNrml.Name = "Section_ThisTimePayNrml";
            this.Section_ThisTimePayNrml.OutputFormat = resources.GetString("Section_ThisTimePayNrml.OutputFormat");
            this.Section_ThisTimePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimePayNrml.SummaryGroup = "SectionHeader";
            this.Section_ThisTimePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimePayNrml.Text = "1,234,567,890";
            this.Section_ThisTimePayNrml.Top = 0F;
            this.Section_ThisTimePayNrml.Width = 0.8125F;
            // 
            // Section_ThisTimeTtlBlcAcPay
            // 
            this.Section_ThisTimeTtlBlcAcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcPay.Border.RightColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcPay.Border.TopColor = System.Drawing.Color.Black;
            this.Section_ThisTimeTtlBlcAcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_ThisTimeTtlBlcAcPay.DataField = "ThisTimeTtlBlcAcPay";
            this.Section_ThisTimeTtlBlcAcPay.Height = 0.125F;
            this.Section_ThisTimeTtlBlcAcPay.Left = 4.4375F;
            this.Section_ThisTimeTtlBlcAcPay.MultiLine = false;
            this.Section_ThisTimeTtlBlcAcPay.Name = "Section_ThisTimeTtlBlcAcPay";
            this.Section_ThisTimeTtlBlcAcPay.OutputFormat = resources.GetString("Section_ThisTimeTtlBlcAcPay.OutputFormat");
            this.Section_ThisTimeTtlBlcAcPay.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_ThisTimeTtlBlcAcPay.SummaryGroup = "SectionHeader";
            this.Section_ThisTimeTtlBlcAcPay.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_ThisTimeTtlBlcAcPay.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_ThisTimeTtlBlcAcPay.Text = "1,234,567,890";
            this.Section_ThisTimeTtlBlcAcPay.Top = 0F;
            this.Section_ThisTimeTtlBlcAcPay.Width = 0.8125F;
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
            this.Section_OfsThisStockTax.Left = 7.6875F;
            this.Section_OfsThisStockTax.MultiLine = false;
            this.Section_OfsThisStockTax.Name = "Section_OfsThisStockTax";
            this.Section_OfsThisStockTax.OutputFormat = resources.GetString("Section_OfsThisStockTax.OutputFormat");
            this.Section_OfsThisStockTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_OfsThisStockTax.SummaryGroup = "SectionHeader";
            this.Section_OfsThisStockTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_OfsThisStockTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_OfsThisStockTax.Text = "1,234,567,890";
            this.Section_OfsThisStockTax.Top = 0F;
            this.Section_OfsThisStockTax.Width = 0.8125F;
            // 
            // s_ThisTimeStockPrice
            // 
            this.s_ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.s_ThisTimeStockPrice.Height = 0.125F;
            this.s_ThisTimeStockPrice.Left = 5.25F;
            this.s_ThisTimeStockPrice.MultiLine = false;
            this.s_ThisTimeStockPrice.Name = "s_ThisTimeStockPrice";
            this.s_ThisTimeStockPrice.OutputFormat = resources.GetString("s_ThisTimeStockPrice.OutputFormat");
            this.s_ThisTimeStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeStockPrice.SummaryGroup = "SectionHeader";
            this.s_ThisTimeStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeStockPrice.Text = "1,234,567,890";
            this.s_ThisTimeStockPrice.Top = 0F;
            this.s_ThisTimeStockPrice.Width = 0.8125F;
            // 
            // s_ThisRgdsDisPric
            // 
            this.s_ThisRgdsDisPric.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisRgdsDisPric.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisRgdsDisPric.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisRgdsDisPric.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisRgdsDisPric.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisRgdsDisPric.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisRgdsDisPric.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisRgdsDisPric.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisRgdsDisPric.DataField = "ThisRgdsDisPric";
            this.s_ThisRgdsDisPric.Height = 0.125F;
            this.s_ThisRgdsDisPric.Left = 6.0625F;
            this.s_ThisRgdsDisPric.MultiLine = false;
            this.s_ThisRgdsDisPric.Name = "s_ThisRgdsDisPric";
            this.s_ThisRgdsDisPric.OutputFormat = resources.GetString("s_ThisRgdsDisPric.OutputFormat");
            this.s_ThisRgdsDisPric.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisRgdsDisPric.SummaryGroup = "SectionHeader";
            this.s_ThisRgdsDisPric.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisRgdsDisPric.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisRgdsDisPric.Text = "1,234,567,890";
            this.s_ThisRgdsDisPric.Top = 0F;
            this.s_ThisRgdsDisPric.Width = 0.8125F;
            // 
            // s_PureStock
            // 
            this.s_PureStock.Border.BottomColor = System.Drawing.Color.Black;
            this.s_PureStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureStock.Border.LeftColor = System.Drawing.Color.Black;
            this.s_PureStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureStock.Border.RightColor = System.Drawing.Color.Black;
            this.s_PureStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureStock.Border.TopColor = System.Drawing.Color.Black;
            this.s_PureStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_PureStock.DataField = "PureStock";
            this.s_PureStock.Height = 0.125F;
            this.s_PureStock.Left = 6.875F;
            this.s_PureStock.MultiLine = false;
            this.s_PureStock.Name = "s_PureStock";
            this.s_PureStock.OutputFormat = resources.GetString("s_PureStock.OutputFormat");
            this.s_PureStock.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_PureStock.SummaryGroup = "SectionHeader";
            this.s_PureStock.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_PureStock.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_PureStock.Text = "1,234,567,890";
            this.s_PureStock.Top = 0F;
            this.s_PureStock.Width = 0.8125F;
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
            this.Section_StockSlipCount.Left = 10.1875F;
            this.Section_StockSlipCount.MultiLine = false;
            this.Section_StockSlipCount.Name = "Section_StockSlipCount";
            this.Section_StockSlipCount.OutputFormat = resources.GetString("Section_StockSlipCount.OutputFormat");
            this.Section_StockSlipCount.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_StockSlipCount.SummaryGroup = "SectionHeader";
            this.Section_StockSlipCount.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_StockSlipCount.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_StockSlipCount.Text = "234,567";
            this.Section_StockSlipCount.Top = 0F;
            this.Section_StockSlipCount.Width = 0.5F;
            // 
            // Section_StockPricTax
            // 
            this.Section_StockPricTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_StockPricTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockPricTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_StockPricTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockPricTax.Border.RightColor = System.Drawing.Color.Black;
            this.Section_StockPricTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockPricTax.Border.TopColor = System.Drawing.Color.Black;
            this.Section_StockPricTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StockPricTax.DataField = "StockPricTax";
            this.Section_StockPricTax.Height = 0.125F;
            this.Section_StockPricTax.Left = 8.5F;
            this.Section_StockPricTax.MultiLine = false;
            this.Section_StockPricTax.Name = "Section_StockPricTax";
            this.Section_StockPricTax.OutputFormat = resources.GetString("Section_StockPricTax.OutputFormat");
            this.Section_StockPricTax.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_StockPricTax.SummaryGroup = "SectionHeader";
            this.Section_StockPricTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_StockPricTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_StockPricTax.Text = "1,234,567,890";
            this.Section_StockPricTax.Top = 0F;
            this.Section_StockPricTax.Width = 0.8125F;
            // 
            // Section_StckTtlAccPayBalance
            // 
            this.Section_StckTtlAccPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_StckTtlAccPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StckTtlAccPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_StckTtlAccPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StckTtlAccPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.Section_StckTtlAccPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StckTtlAccPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.Section_StckTtlAccPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_StckTtlAccPayBalance.DataField = "StckTtlAccPayBalance";
            this.Section_StckTtlAccPayBalance.Height = 0.125F;
            this.Section_StckTtlAccPayBalance.Left = 9.3125F;
            this.Section_StckTtlAccPayBalance.MultiLine = false;
            this.Section_StckTtlAccPayBalance.Name = "Section_StckTtlAccPayBalance";
            this.Section_StckTtlAccPayBalance.OutputFormat = resources.GetString("Section_StckTtlAccPayBalance.OutputFormat");
            this.Section_StckTtlAccPayBalance.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.Section_StckTtlAccPayBalance.SummaryGroup = "SectionHeader";
            this.Section_StckTtlAccPayBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_StckTtlAccPayBalance.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_StckTtlAccPayBalance.Text = "1,234,567,890";
            this.Section_StckTtlAccPayBalance.Top = 0F;
            this.Section_StckTtlAccPayBalance.Width = 0.8125F;
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
            this.s_CashPayment.Left = 2.8125F;
            this.s_CashPayment.MultiLine = false;
            this.s_CashPayment.Name = "s_CashPayment";
            this.s_CashPayment.OutputFormat = resources.GetString("s_CashPayment.OutputFormat");
            this.s_CashPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CashPayment.SummaryGroup = "SectionHeader";
            this.s_CashPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CashPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CashPayment.Text = "1,234,567,890";
            this.s_CashPayment.Top = 0.125F;
            this.s_CashPayment.Width = 0.8125F;
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
            this.s_TrfrPayment.Left = 3.625F;
            this.s_TrfrPayment.MultiLine = false;
            this.s_TrfrPayment.Name = "s_TrfrPayment";
            this.s_TrfrPayment.OutputFormat = resources.GetString("s_TrfrPayment.OutputFormat");
            this.s_TrfrPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TrfrPayment.SummaryGroup = "SectionHeader";
            this.s_TrfrPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TrfrPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TrfrPayment.Text = "1,234,567,890";
            this.s_TrfrPayment.Top = 0.125F;
            this.s_TrfrPayment.Width = 0.8125F;
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
            this.s_CheckPayment.Left = 4.4375F;
            this.s_CheckPayment.MultiLine = false;
            this.s_CheckPayment.Name = "s_CheckPayment";
            this.s_CheckPayment.OutputFormat = resources.GetString("s_CheckPayment.OutputFormat");
            this.s_CheckPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CheckPayment.SummaryGroup = "SectionHeader";
            this.s_CheckPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CheckPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CheckPayment.Text = "1,234,567,890";
            this.s_CheckPayment.Top = 0.125F;
            this.s_CheckPayment.Width = 0.8125F;
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
            this.s_DraftPayment.Left = 5.25F;
            this.s_DraftPayment.MultiLine = false;
            this.s_DraftPayment.Name = "s_DraftPayment";
            this.s_DraftPayment.OutputFormat = resources.GetString("s_DraftPayment.OutputFormat");
            this.s_DraftPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_DraftPayment.SummaryGroup = "SectionHeader";
            this.s_DraftPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DraftPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DraftPayment.Text = "1,234,567,890";
            this.s_DraftPayment.Top = 0.125F;
            this.s_DraftPayment.Width = 0.8125F;
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
            this.s_OffsetPayment.Left = 6.0625F;
            this.s_OffsetPayment.MultiLine = false;
            this.s_OffsetPayment.Name = "s_OffsetPayment";
            this.s_OffsetPayment.OutputFormat = resources.GetString("s_OffsetPayment.OutputFormat");
            this.s_OffsetPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OffsetPayment.SummaryGroup = "SectionHeader";
            this.s_OffsetPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OffsetPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OffsetPayment.Text = "1,234,567,890";
            this.s_OffsetPayment.Top = 0.125F;
            this.s_OffsetPayment.Width = 0.8125F;
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
            this.s_FundTransferPayment.Left = 7.6875F;
            this.s_FundTransferPayment.MultiLine = false;
            this.s_FundTransferPayment.Name = "s_FundTransferPayment";
            this.s_FundTransferPayment.OutputFormat = resources.GetString("s_FundTransferPayment.OutputFormat");
            this.s_FundTransferPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_FundTransferPayment.SummaryGroup = "SectionHeader";
            this.s_FundTransferPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_FundTransferPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_FundTransferPayment.Text = "1,234,567,890";
            this.s_FundTransferPayment.Top = 0.125F;
            this.s_FundTransferPayment.Width = 0.8125F;
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
            this.s_OthsPayment.Left = 6.875F;
            this.s_OthsPayment.MultiLine = false;
            this.s_OthsPayment.Name = "s_OthsPayment";
            this.s_OthsPayment.OutputFormat = resources.GetString("s_OthsPayment.OutputFormat");
            this.s_OthsPayment.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OthsPayment.SummaryGroup = "SectionHeader";
            this.s_OthsPayment.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OthsPayment.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OthsPayment.Text = "1,234,567,890";
            this.s_OthsPayment.Top = 0.125F;
            this.s_OthsPayment.Width = 0.8125F;
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
            this.s_ThisTimeFeePayNrml.Left = 8.5F;
            this.s_ThisTimeFeePayNrml.MultiLine = false;
            this.s_ThisTimeFeePayNrml.Name = "s_ThisTimeFeePayNrml";
            this.s_ThisTimeFeePayNrml.OutputFormat = resources.GetString("s_ThisTimeFeePayNrml.OutputFormat");
            this.s_ThisTimeFeePayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeFeePayNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeePayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeePayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeePayNrml.Text = "1,234,567,890";
            this.s_ThisTimeFeePayNrml.Top = 0.125F;
            this.s_ThisTimeFeePayNrml.Width = 0.8125F;
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
            this.s_ThisTimeDisPayNrml.Left = 9.3125F;
            this.s_ThisTimeDisPayNrml.MultiLine = false;
            this.s_ThisTimeDisPayNrml.Name = "s_ThisTimeDisPayNrml";
            this.s_ThisTimeDisPayNrml.OutputFormat = resources.GetString("s_ThisTimeDisPayNrml.OutputFormat");
            this.s_ThisTimeDisPayNrml.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeDisPayNrml.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisPayNrml.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisPayNrml.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisPayNrml.Text = "1,234,567,890";
            this.s_ThisTimeDisPayNrml.Top = 0.125F;
            this.s_ThisTimeDisPayNrml.Width = 0.8125F;
            // 
            // SumAccPaymentHeader
            // 
            this.SumAccPaymentHeader.CanShrink = true;
            this.SumAccPaymentHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SumPayeeCode,
            this.SumPayeeSnm,
            this.LastTimeAccPay,
            this.CashPayment,
            this.ThisTimePayNrml,
            this.ThisTimeTtlBlcAcPay,
            this.ThisTimeStockPrice,
            this.ThisRgdsDisPric,
            this.PureStock,
            this.OfsThisStockTax,
            this.StockPricTax,
            this.StckTtlAccPayBalance,
            this.StockSlipCount,
            this.TrfrPayment,
            this.CheckPayment,
            this.DraftPayment,
            this.OffsetPayment,
            this.OthsPayment,
            this.FundTransferPayment,
            this.ThisTimeFeePayNrml,
            this.ThisTimeDisPayNrml,
            this.line2});
            this.SumAccPaymentHeader.DataField = "SumPayeeCode";
            this.SumAccPaymentHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.SumAccPaymentHeader.Height = 0.2395833F;
            this.SumAccPaymentHeader.KeepTogether = true;
            this.SumAccPaymentHeader.Name = "SumAccPaymentHeader";
            this.SumAccPaymentHeader.Format += new System.EventHandler(this.SumAccPaymentHeader_Format);
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
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // SumAccPaymentFooter
            // 
            this.SumAccPaymentFooter.Height = 0F;
            this.SumAccPaymentFooter.KeepTogether = true;
            this.SumAccPaymentFooter.Name = "SumAccPaymentFooter";
            // 
            // GrandTotalHeader2
            // 
            this.GrandTotalHeader2.Height = 0F;
            this.GrandTotalHeader2.Name = "GrandTotalHeader2";
            this.GrandTotalHeader2.Visible = false;
            // 
            // GrandTotalFooter2
            // 
            this.GrandTotalFooter2.CanShrink = true;
            this.GrandTotalFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label10,
            this.line4,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.g_CashPayment2,
            this.g_TrfrPayment2,
            this.g_CheckPayment2,
            this.g_DraftPayment2,
            this.g_OffsetPayment2,
            this.g_OthsPayment2,
            this.g_FundTransferPayment2,
            this.g_ThisTimeFeePayNrml2,
            this.g_ThisTimeDisPayNrml2,
            this.textBox58,
            this.textBox59,
            this.textBox60,
            this.textBox61,
            this.textBox62,
            this.textBox63,
            this.textBox64,
            this.textBox65,
            this.textBox66,
            this.textBox67,
            this.textBox68,
            this.textBox69,
            this.textBox70,
            this.textBox71,
            this.textBox72,
            this.textBox73,
            this.textBox74,
            this.textBox75,
            this.label14,
            this.label15,
            this.label16,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.label18});
            this.GrandTotalFooter2.Height = 0.7549213F;
            this.GrandTotalFooter2.KeepTogether = true;
            this.GrandTotalFooter2.Name = "GrandTotalFooter2";
            this.GrandTotalFooter2.Visible = false;
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
            this.label10.Height = 0.1875F;
            this.label10.HyperLink = "";
            this.label10.Left = 0.1875F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.label10.Text = "総合計";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.5625F;
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
            this.textBox21.DataField = "LastTimeAccPay";
            this.textBox21.Height = 0.125F;
            this.textBox21.Left = 2.8125F;
            this.textBox21.MultiLine = false;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox21.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox21.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox21.Text = "1,234,567,890";
            this.textBox21.Top = 0F;
            this.textBox21.Width = 0.8125F;
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
            this.textBox22.DataField = "ThisTimePayNrml";
            this.textBox22.Height = 0.125F;
            this.textBox22.Left = 3.625F;
            this.textBox22.MultiLine = false;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox22.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox22.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox22.Text = "1,234,567,890";
            this.textBox22.Top = 0F;
            this.textBox22.Width = 0.8125F;
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
            this.textBox23.DataField = "ThisTimeTtlBlcAcPay";
            this.textBox23.Height = 0.125F;
            this.textBox23.Left = 4.4375F;
            this.textBox23.MultiLine = false;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox23.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox23.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox23.Text = "1,234,567,890";
            this.textBox23.Top = 0F;
            this.textBox23.Width = 0.8125F;
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
            this.textBox24.DataField = "PureStock";
            this.textBox24.Height = 0.125F;
            this.textBox24.Left = 6.875F;
            this.textBox24.MultiLine = false;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox24.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox24.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox24.Text = "1,234,567,890";
            this.textBox24.Top = 0F;
            this.textBox24.Width = 0.8125F;
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
            this.textBox25.DataField = "ThisTimeStockPrice";
            this.textBox25.Height = 0.125F;
            this.textBox25.Left = 5.25F;
            this.textBox25.MultiLine = false;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox25.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox25.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox25.Text = "1,234,567,890";
            this.textBox25.Top = 0F;
            this.textBox25.Width = 0.8125F;
            // 
            // textBox26
            // 
            this.textBox26.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.RightColor = System.Drawing.Color.Black;
            this.textBox26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.Border.TopColor = System.Drawing.Color.Black;
            this.textBox26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox26.DataField = "ThisRgdsDisPric";
            this.textBox26.Height = 0.125F;
            this.textBox26.Left = 6.0625F;
            this.textBox26.MultiLine = false;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox26.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox26.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox26.Text = "1,234,567,890";
            this.textBox26.Top = 0F;
            this.textBox26.Width = 0.8125F;
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
            this.textBox27.DataField = "OfsThisStockTax";
            this.textBox27.Height = 0.125F;
            this.textBox27.Left = 7.6875F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox27.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox27.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox27.Text = "1,234,567,890";
            this.textBox27.Top = 0F;
            this.textBox27.Width = 0.8125F;
            // 
            // textBox28
            // 
            this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.RightColor = System.Drawing.Color.Black;
            this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.TopColor = System.Drawing.Color.Black;
            this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.DataField = "StockSlipCount";
            this.textBox28.Height = 0.125F;
            this.textBox28.Left = 10.1875F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox28.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox28.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox28.Text = "234,567";
            this.textBox28.Top = 0F;
            this.textBox28.Width = 0.5F;
            // 
            // textBox29
            // 
            this.textBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.RightColor = System.Drawing.Color.Black;
            this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.TopColor = System.Drawing.Color.Black;
            this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.DataField = "StockPricTax";
            this.textBox29.Height = 0.125F;
            this.textBox29.Left = 8.5F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox29.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox29.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox29.Text = "1,234,567,890";
            this.textBox29.Top = 0F;
            this.textBox29.Width = 0.8125F;
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
            this.textBox30.DataField = "StckTtlAccPayBalance";
            this.textBox30.Height = 0.125F;
            this.textBox30.Left = 9.3125F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox30.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox30.Text = "1,234,567,890";
            this.textBox30.Top = 0F;
            this.textBox30.Width = 0.8125F;
            // 
            // g_CashPayment2
            // 
            this.g_CashPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CashPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CashPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_CashPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_CashPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CashPayment2.DataField = "CashPayment";
            this.g_CashPayment2.Height = 0.125F;
            this.g_CashPayment2.Left = 2.8125F;
            this.g_CashPayment2.MultiLine = false;
            this.g_CashPayment2.Name = "g_CashPayment2";
            this.g_CashPayment2.OutputFormat = resources.GetString("g_CashPayment2.OutputFormat");
            this.g_CashPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CashPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CashPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CashPayment2.Text = "1,234,567,890";
            this.g_CashPayment2.Top = 0.6299213F;
            this.g_CashPayment2.Width = 0.8125F;
            // 
            // g_TrfrPayment2
            // 
            this.g_TrfrPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_TrfrPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_TrfrPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_TrfrPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_TrfrPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_TrfrPayment2.DataField = "TrfrPayment";
            this.g_TrfrPayment2.Height = 0.125F;
            this.g_TrfrPayment2.Left = 3.625F;
            this.g_TrfrPayment2.MultiLine = false;
            this.g_TrfrPayment2.Name = "g_TrfrPayment2";
            this.g_TrfrPayment2.OutputFormat = resources.GetString("g_TrfrPayment2.OutputFormat");
            this.g_TrfrPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_TrfrPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_TrfrPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_TrfrPayment2.Text = "1,234,567,890";
            this.g_TrfrPayment2.Top = 0.6299213F;
            this.g_TrfrPayment2.Width = 0.8125F;
            // 
            // g_CheckPayment2
            // 
            this.g_CheckPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_CheckPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_CheckPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_CheckPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_CheckPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_CheckPayment2.DataField = "CheckPayment";
            this.g_CheckPayment2.Height = 0.125F;
            this.g_CheckPayment2.Left = 4.4375F;
            this.g_CheckPayment2.MultiLine = false;
            this.g_CheckPayment2.Name = "g_CheckPayment2";
            this.g_CheckPayment2.OutputFormat = resources.GetString("g_CheckPayment2.OutputFormat");
            this.g_CheckPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_CheckPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_CheckPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_CheckPayment2.Text = "1,234,567,890";
            this.g_CheckPayment2.Top = 0.6299213F;
            this.g_CheckPayment2.Width = 0.8125F;
            // 
            // g_DraftPayment2
            // 
            this.g_DraftPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_DraftPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_DraftPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_DraftPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_DraftPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_DraftPayment2.DataField = "DraftPayment";
            this.g_DraftPayment2.Height = 0.125F;
            this.g_DraftPayment2.Left = 5.25F;
            this.g_DraftPayment2.MultiLine = false;
            this.g_DraftPayment2.Name = "g_DraftPayment2";
            this.g_DraftPayment2.OutputFormat = resources.GetString("g_DraftPayment2.OutputFormat");
            this.g_DraftPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_DraftPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_DraftPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_DraftPayment2.Text = "1,234,567,890";
            this.g_DraftPayment2.Top = 0.6299213F;
            this.g_DraftPayment2.Width = 0.8125F;
            // 
            // g_OffsetPayment2
            // 
            this.g_OffsetPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OffsetPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OffsetPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OffsetPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OffsetPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OffsetPayment2.DataField = "OffsetPayment";
            this.g_OffsetPayment2.Height = 0.125F;
            this.g_OffsetPayment2.Left = 6.0625F;
            this.g_OffsetPayment2.MultiLine = false;
            this.g_OffsetPayment2.Name = "g_OffsetPayment2";
            this.g_OffsetPayment2.OutputFormat = resources.GetString("g_OffsetPayment2.OutputFormat");
            this.g_OffsetPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OffsetPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OffsetPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OffsetPayment2.Text = "1,234,567,890";
            this.g_OffsetPayment2.Top = 0.6299213F;
            this.g_OffsetPayment2.Width = 0.8125F;
            // 
            // g_OthsPayment2
            // 
            this.g_OthsPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_OthsPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_OthsPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_OthsPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_OthsPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_OthsPayment2.DataField = "FundTransferPayment";
            this.g_OthsPayment2.Height = 0.125F;
            this.g_OthsPayment2.Left = 7.6875F;
            this.g_OthsPayment2.MultiLine = false;
            this.g_OthsPayment2.Name = "g_OthsPayment2";
            this.g_OthsPayment2.OutputFormat = resources.GetString("g_OthsPayment2.OutputFormat");
            this.g_OthsPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_OthsPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_OthsPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_OthsPayment2.Text = "1,234,567,890";
            this.g_OthsPayment2.Top = 0.6299213F;
            this.g_OthsPayment2.Width = 0.8125F;
            // 
            // g_FundTransferPayment2
            // 
            this.g_FundTransferPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.g_FundTransferPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_FundTransferPayment2.DataField = "OthsPayment";
            this.g_FundTransferPayment2.Height = 0.125F;
            this.g_FundTransferPayment2.Left = 6.875F;
            this.g_FundTransferPayment2.MultiLine = false;
            this.g_FundTransferPayment2.Name = "g_FundTransferPayment2";
            this.g_FundTransferPayment2.OutputFormat = resources.GetString("g_FundTransferPayment2.OutputFormat");
            this.g_FundTransferPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_FundTransferPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_FundTransferPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_FundTransferPayment2.Text = "1,234,567,890";
            this.g_FundTransferPayment2.Top = 0.6299213F;
            this.g_FundTransferPayment2.Width = 0.8125F;
            // 
            // g_ThisTimeFeePayNrml2
            // 
            this.g_ThisTimeFeePayNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeFeePayNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeFeePayNrml2.DataField = "ThisTimeFeePayNrml";
            this.g_ThisTimeFeePayNrml2.Height = 0.125F;
            this.g_ThisTimeFeePayNrml2.Left = 8.5F;
            this.g_ThisTimeFeePayNrml2.MultiLine = false;
            this.g_ThisTimeFeePayNrml2.Name = "g_ThisTimeFeePayNrml2";
            this.g_ThisTimeFeePayNrml2.OutputFormat = resources.GetString("g_ThisTimeFeePayNrml2.OutputFormat");
            this.g_ThisTimeFeePayNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeFeePayNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeFeePayNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeFeePayNrml2.Text = "1,234,567,890";
            this.g_ThisTimeFeePayNrml2.Top = 0.6299213F;
            this.g_ThisTimeFeePayNrml2.Width = 0.8125F;
            // 
            // g_ThisTimeDisPayNrml2
            // 
            this.g_ThisTimeDisPayNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.g_ThisTimeDisPayNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.g_ThisTimeDisPayNrml2.DataField = "ThisTimeDisPayNrml";
            this.g_ThisTimeDisPayNrml2.Height = 0.125F;
            this.g_ThisTimeDisPayNrml2.Left = 9.3125F;
            this.g_ThisTimeDisPayNrml2.MultiLine = false;
            this.g_ThisTimeDisPayNrml2.Name = "g_ThisTimeDisPayNrml2";
            this.g_ThisTimeDisPayNrml2.OutputFormat = resources.GetString("g_ThisTimeDisPayNrml2.OutputFormat");
            this.g_ThisTimeDisPayNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.g_ThisTimeDisPayNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.g_ThisTimeDisPayNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.g_ThisTimeDisPayNrml2.Text = "1,234,567,890";
            this.g_ThisTimeDisPayNrml2.Top = 0.6299213F;
            this.g_ThisTimeDisPayNrml2.Width = 0.8125F;
            // 
            // textBox58
            // 
            this.textBox58.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.RightColor = System.Drawing.Color.Black;
            this.textBox58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.Border.TopColor = System.Drawing.Color.Black;
            this.textBox58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox58.DataField = "TotalThisTimeStockPriceTaxRate1";
            this.textBox58.Height = 0.125F;
            this.textBox58.Left = 5.25F;
            this.textBox58.MultiLine = false;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox58.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox58.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox58.Text = "1,234,567,890";
            this.textBox58.Top = 0.125F;
            this.textBox58.Width = 0.8125F;
            // 
            // textBox59
            // 
            this.textBox59.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.RightColor = System.Drawing.Color.Black;
            this.textBox59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.Border.TopColor = System.Drawing.Color.Black;
            this.textBox59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox59.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox59.Height = 0.125F;
            this.textBox59.Left = 6.0625F;
            this.textBox59.MultiLine = false;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox59.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox59.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox59.Text = "1,234,567,890";
            this.textBox59.Top = 0.125F;
            this.textBox59.Width = 0.8125F;
            // 
            // textBox60
            // 
            this.textBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.RightColor = System.Drawing.Color.Black;
            this.textBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.TopColor = System.Drawing.Color.Black;
            this.textBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.DataField = "TotalPureStockTaxRate1";
            this.textBox60.Height = 0.125F;
            this.textBox60.Left = 6.875F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox60.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox60.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox60.Text = "1,234,567,890";
            this.textBox60.Top = 0.125F;
            this.textBox60.Width = 0.8125F;
            // 
            // textBox61
            // 
            this.textBox61.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.RightColor = System.Drawing.Color.Black;
            this.textBox61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.Border.TopColor = System.Drawing.Color.Black;
            this.textBox61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox61.DataField = "TotalStockPricTaxTaxRate1";
            this.textBox61.Height = 0.125F;
            this.textBox61.Left = 7.6875F;
            this.textBox61.MultiLine = false;
            this.textBox61.Name = "textBox61";
            this.textBox61.OutputFormat = resources.GetString("textBox61.OutputFormat");
            this.textBox61.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox61.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox61.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox61.Text = "1,234,567,890";
            this.textBox61.Top = 0.125F;
            this.textBox61.Width = 0.8125F;
            // 
            // textBox62
            // 
            this.textBox62.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.RightColor = System.Drawing.Color.Black;
            this.textBox62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.Border.TopColor = System.Drawing.Color.Black;
            this.textBox62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox62.DataField = "TotalStckTtlAccPayBalanceTaxRate1";
            this.textBox62.Height = 0.125F;
            this.textBox62.Left = 8.5F;
            this.textBox62.MultiLine = false;
            this.textBox62.Name = "textBox62";
            this.textBox62.OutputFormat = resources.GetString("textBox62.OutputFormat");
            this.textBox62.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox62.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox62.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox62.Text = "1,234,567,890";
            this.textBox62.Top = 0.125F;
            this.textBox62.Width = 0.8125F;
            // 
            // textBox63
            // 
            this.textBox63.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.RightColor = System.Drawing.Color.Black;
            this.textBox63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.Border.TopColor = System.Drawing.Color.Black;
            this.textBox63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox63.DataField = "TotalStockSlipCountTaxRate1";
            this.textBox63.Height = 0.125F;
            this.textBox63.Left = 10.1875F;
            this.textBox63.MultiLine = false;
            this.textBox63.Name = "textBox63";
            this.textBox63.OutputFormat = resources.GetString("textBox63.OutputFormat");
            this.textBox63.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox63.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox63.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox63.Text = "234,567";
            this.textBox63.Top = 0.125F;
            this.textBox63.Width = 0.5F;
            // 
            // textBox64
            // 
            this.textBox64.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.RightColor = System.Drawing.Color.Black;
            this.textBox64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.Border.TopColor = System.Drawing.Color.Black;
            this.textBox64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox64.DataField = "TotalThisTimeStockPriceTaxRate2";
            this.textBox64.Height = 0.125F;
            this.textBox64.Left = 5.25F;
            this.textBox64.MultiLine = false;
            this.textBox64.Name = "textBox64";
            this.textBox64.OutputFormat = resources.GetString("textBox64.OutputFormat");
            this.textBox64.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox64.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox64.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox64.Text = "1,234,567,890";
            this.textBox64.Top = 0.25F;
            this.textBox64.Width = 0.8125F;
            // 
            // textBox65
            // 
            this.textBox65.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.Border.RightColor = System.Drawing.Color.Black;
            this.textBox65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.Border.TopColor = System.Drawing.Color.Black;
            this.textBox65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox65.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox65.Height = 0.125F;
            this.textBox65.Left = 6.0625F;
            this.textBox65.MultiLine = false;
            this.textBox65.Name = "textBox65";
            this.textBox65.OutputFormat = resources.GetString("textBox65.OutputFormat");
            this.textBox65.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox65.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox65.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox65.Text = "1,234,567,890";
            this.textBox65.Top = 0.25F;
            this.textBox65.Width = 0.8125F;
            // 
            // textBox66
            // 
            this.textBox66.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox66.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox66.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.Border.RightColor = System.Drawing.Color.Black;
            this.textBox66.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.Border.TopColor = System.Drawing.Color.Black;
            this.textBox66.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox66.DataField = "TotalPureStockTaxRate2";
            this.textBox66.Height = 0.125F;
            this.textBox66.Left = 6.875F;
            this.textBox66.MultiLine = false;
            this.textBox66.Name = "textBox66";
            this.textBox66.OutputFormat = resources.GetString("textBox66.OutputFormat");
            this.textBox66.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox66.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox66.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox66.Text = "1,234,567,890";
            this.textBox66.Top = 0.25F;
            this.textBox66.Width = 0.8125F;
            // 
            // textBox67
            // 
            this.textBox67.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox67.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox67.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.Border.RightColor = System.Drawing.Color.Black;
            this.textBox67.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.Border.TopColor = System.Drawing.Color.Black;
            this.textBox67.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox67.DataField = "TotalStockPricTaxTaxRate2";
            this.textBox67.Height = 0.125F;
            this.textBox67.Left = 7.6875F;
            this.textBox67.MultiLine = false;
            this.textBox67.Name = "textBox67";
            this.textBox67.OutputFormat = resources.GetString("textBox67.OutputFormat");
            this.textBox67.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox67.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox67.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox67.Text = "1,234,567,890";
            this.textBox67.Top = 0.25F;
            this.textBox67.Width = 0.8125F;
            // 
            // textBox68
            // 
            this.textBox68.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox68.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox68.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.RightColor = System.Drawing.Color.Black;
            this.textBox68.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.Border.TopColor = System.Drawing.Color.Black;
            this.textBox68.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox68.DataField = "TotalStckTtlAccPayBalanceTaxRate2";
            this.textBox68.Height = 0.125F;
            this.textBox68.Left = 8.5F;
            this.textBox68.MultiLine = false;
            this.textBox68.Name = "textBox68";
            this.textBox68.OutputFormat = resources.GetString("textBox68.OutputFormat");
            this.textBox68.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox68.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox68.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox68.Text = "1,234,567,890";
            this.textBox68.Top = 0.25F;
            this.textBox68.Width = 0.8125F;
            // 
            // textBox69
            // 
            this.textBox69.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox69.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox69.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.RightColor = System.Drawing.Color.Black;
            this.textBox69.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.Border.TopColor = System.Drawing.Color.Black;
            this.textBox69.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox69.DataField = "TotalStockSlipCountTaxRate2";
            this.textBox69.Height = 0.125F;
            this.textBox69.Left = 10.1875F;
            this.textBox69.MultiLine = false;
            this.textBox69.Name = "textBox69";
            this.textBox69.OutputFormat = resources.GetString("textBox69.OutputFormat");
            this.textBox69.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox69.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox69.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox69.Text = "234,567";
            this.textBox69.Top = 0.25F;
            this.textBox69.Width = 0.5F;
            // 
            // textBox70
            // 
            this.textBox70.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox70.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox70.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Border.RightColor = System.Drawing.Color.Black;
            this.textBox70.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.Border.TopColor = System.Drawing.Color.Black;
            this.textBox70.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox70.DataField = "TotalThisTimeStockPriceOther";
            this.textBox70.Height = 0.125F;
            this.textBox70.Left = 5.25F;
            this.textBox70.MultiLine = false;
            this.textBox70.Name = "textBox70";
            this.textBox70.OutputFormat = resources.GetString("textBox70.OutputFormat");
            this.textBox70.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox70.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox70.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox70.Text = "1,234,567,890";
            this.textBox70.Top = 0.375F;
            this.textBox70.Width = 0.8125F;
            // 
            // textBox71
            // 
            this.textBox71.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox71.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox71.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.Border.RightColor = System.Drawing.Color.Black;
            this.textBox71.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.Border.TopColor = System.Drawing.Color.Black;
            this.textBox71.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox71.DataField = "TotalThisRgdsDisPricOther";
            this.textBox71.Height = 0.125F;
            this.textBox71.Left = 6.0625F;
            this.textBox71.MultiLine = false;
            this.textBox71.Name = "textBox71";
            this.textBox71.OutputFormat = resources.GetString("textBox71.OutputFormat");
            this.textBox71.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox71.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox71.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox71.Text = "1,234,567,890";
            this.textBox71.Top = 0.375F;
            this.textBox71.Width = 0.8125F;
            // 
            // textBox72
            // 
            this.textBox72.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox72.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox72.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.RightColor = System.Drawing.Color.Black;
            this.textBox72.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.Border.TopColor = System.Drawing.Color.Black;
            this.textBox72.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox72.DataField = "TotalPureStockOther";
            this.textBox72.Height = 0.125F;
            this.textBox72.Left = 6.875F;
            this.textBox72.MultiLine = false;
            this.textBox72.Name = "textBox72";
            this.textBox72.OutputFormat = resources.GetString("textBox72.OutputFormat");
            this.textBox72.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox72.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox72.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox72.Text = "1,234,567,890";
            this.textBox72.Top = 0.375F;
            this.textBox72.Width = 0.8125F;
            // 
            // textBox73
            // 
            this.textBox73.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox73.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox73.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.RightColor = System.Drawing.Color.Black;
            this.textBox73.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.Border.TopColor = System.Drawing.Color.Black;
            this.textBox73.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox73.DataField = "TotalStockPricTaxOther";
            this.textBox73.Height = 0.125F;
            this.textBox73.Left = 7.6875F;
            this.textBox73.MultiLine = false;
            this.textBox73.Name = "textBox73";
            this.textBox73.OutputFormat = resources.GetString("textBox73.OutputFormat");
            this.textBox73.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox73.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox73.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox73.Text = "1,234,567,890";
            this.textBox73.Top = 0.375F;
            this.textBox73.Width = 0.8125F;
            // 
            // textBox74
            // 
            this.textBox74.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox74.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox74.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.Border.RightColor = System.Drawing.Color.Black;
            this.textBox74.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.Border.TopColor = System.Drawing.Color.Black;
            this.textBox74.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox74.DataField = "TotalStckTtlAccPayBalanceOther";
            this.textBox74.Height = 0.125F;
            this.textBox74.Left = 8.5F;
            this.textBox74.MultiLine = false;
            this.textBox74.Name = "textBox74";
            this.textBox74.OutputFormat = resources.GetString("textBox74.OutputFormat");
            this.textBox74.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox74.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox74.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox74.Text = "1,234,567,890";
            this.textBox74.Top = 0.375F;
            this.textBox74.Width = 0.8125F;
            // 
            // textBox75
            // 
            this.textBox75.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox75.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox75.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.RightColor = System.Drawing.Color.Black;
            this.textBox75.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.Border.TopColor = System.Drawing.Color.Black;
            this.textBox75.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox75.DataField = "TotalStockSlipCountOther";
            this.textBox75.Height = 0.125F;
            this.textBox75.Left = 10.1875F;
            this.textBox75.MultiLine = false;
            this.textBox75.Name = "textBox75";
            this.textBox75.OutputFormat = resources.GetString("textBox75.OutputFormat");
            this.textBox75.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox75.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox75.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox75.Text = "234,567";
            this.textBox75.Top = 0.375F;
            this.textBox75.Width = 0.5F;
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
            this.label14.DataField = "TitleTaxRate1";
            this.label14.Height = 0.125F;
            this.label14.HyperLink = null;
            this.label14.Left = 4.5F;
            this.label14.Name = "label14";
            this.label14.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label14.Text = "10%";
            this.label14.Top = 0.125F;
            this.label14.Width = 0.75F;
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
            this.label15.DataField = "TitleTaxRate2";
            this.label15.Height = 0.125F;
            this.label15.HyperLink = null;
            this.label15.Left = 4.5F;
            this.label15.Name = "label15";
            this.label15.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label15.Text = "8%";
            this.label15.Top = 0.25F;
            this.label15.Width = 0.75F;
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
            this.label16.Height = 0.125F;
            this.label16.HyperLink = null;
            this.label16.Left = 4.5F;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label16.Text = "その他";
            this.label16.Top = 0.375F;
            this.label16.Width = 0.75F;
            // 
            // SectionHeader2
            // 
            this.SectionHeader2.Height = 0F;
            this.SectionHeader2.Name = "SectionHeader2";
            this.SectionHeader2.Visible = false;
            // 
            // SectionFooter2
            // 
            this.SectionFooter2.CanShrink = true;
            this.SectionFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.s_CashPayment2,
            this.s_TrfrPayment2,
            this.s_CheckPayment2,
            this.s_DraftPayment2,
            this.s_OffsetPayment2,
            this.s_OthsPayment2,
            this.s_FundTransferPayment2,
            this.s_ThisTimeFeePayNrml2,
            this.s_ThisTimeDisPayNrml2,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox48,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
            this.label11,
            this.label12,
            this.label13,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.label17});
            this.SectionFooter2.Height = 0.7559055F;
            this.SectionFooter2.KeepTogether = true;
            this.SectionFooter2.Name = "SectionFooter2";
            this.SectionFooter2.Visible = false;
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
            this.textBox1.DataField = "MONEYKINDNAME";
            this.textBox1.Height = 0.15625F;
            this.textBox1.Left = 0.1875F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.textBox1.Text = "拠点計";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.5625F;
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
            this.textBox2.DataField = "LastTimeAccPay";
            this.textBox2.Height = 0.125F;
            this.textBox2.Left = 2.8125F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox2.SummaryGroup = "SectionHeader";
            this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox2.Text = "1,234,567,890";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.8125F;
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
            this.textBox3.DataField = "ThisTimePayNrml";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 3.625F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox3.SummaryGroup = "SectionHeader";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "1,234,567,890";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.8125F;
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
            this.textBox4.DataField = "ThisTimeTtlBlcAcPay";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 4.4375F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox4.SummaryGroup = "SectionHeader";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox4.Text = "1,234,567,890";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.8125F;
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
            this.textBox5.DataField = "OfsThisStockTax";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 7.6875F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox5.SummaryGroup = "SectionHeader";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox5.Text = "1,234,567,890";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.8125F;
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
            this.textBox6.DataField = "ThisTimeStockPrice";
            this.textBox6.Height = 0.125F;
            this.textBox6.Left = 5.25F;
            this.textBox6.MultiLine = false;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox6.SummaryGroup = "SectionHeader";
            this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox6.Text = "1,234,567,890";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.8125F;
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
            this.textBox7.DataField = "ThisRgdsDisPric";
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 6.0625F;
            this.textBox7.MultiLine = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox7.SummaryGroup = "SectionHeader";
            this.textBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox7.Text = "1,234,567,890";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.8125F;
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
            this.textBox8.DataField = "PureStock";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 6.875F;
            this.textBox8.MultiLine = false;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox8.SummaryGroup = "SectionHeader";
            this.textBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox8.Text = "1,234,567,890";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.8125F;
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
            this.textBox9.DataField = "StockSlipCount";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 10.1875F;
            this.textBox9.MultiLine = false;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox9.SummaryGroup = "SectionHeader";
            this.textBox9.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox9.Text = "234,567";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.5F;
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
            this.textBox10.DataField = "StockPricTax";
            this.textBox10.Height = 0.125F;
            this.textBox10.Left = 8.5F;
            this.textBox10.MultiLine = false;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox10.SummaryGroup = "SectionHeader";
            this.textBox10.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox10.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox10.Text = "1,234,567,890";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.8125F;
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
            this.textBox11.DataField = "StckTtlAccPayBalance";
            this.textBox11.Height = 0.125F;
            this.textBox11.Left = 9.3125F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox11.SummaryGroup = "SectionHeader";
            this.textBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox11.Text = "1,234,567,890";
            this.textBox11.Top = 0F;
            this.textBox11.Width = 0.8125F;
            // 
            // s_CashPayment2
            // 
            this.s_CashPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CashPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CashPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_CashPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_CashPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CashPayment2.DataField = "CashPayment";
            this.s_CashPayment2.Height = 0.125F;
            this.s_CashPayment2.Left = 2.8125F;
            this.s_CashPayment2.MultiLine = false;
            this.s_CashPayment2.Name = "s_CashPayment2";
            this.s_CashPayment2.OutputFormat = resources.GetString("s_CashPayment2.OutputFormat");
            this.s_CashPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CashPayment2.SummaryGroup = "SectionHeader";
            this.s_CashPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CashPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CashPayment2.Text = "1,234,567,890";
            this.s_CashPayment2.Top = 0.6299213F;
            this.s_CashPayment2.Width = 0.8125F;
            // 
            // s_TrfrPayment2
            // 
            this.s_TrfrPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_TrfrPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_TrfrPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_TrfrPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_TrfrPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_TrfrPayment2.DataField = "TrfrPayment";
            this.s_TrfrPayment2.Height = 0.125F;
            this.s_TrfrPayment2.Left = 3.625F;
            this.s_TrfrPayment2.MultiLine = false;
            this.s_TrfrPayment2.Name = "s_TrfrPayment2";
            this.s_TrfrPayment2.OutputFormat = resources.GetString("s_TrfrPayment2.OutputFormat");
            this.s_TrfrPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_TrfrPayment2.SummaryGroup = "SectionHeader";
            this.s_TrfrPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_TrfrPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_TrfrPayment2.Text = "1,234,567,890";
            this.s_TrfrPayment2.Top = 0.6299213F;
            this.s_TrfrPayment2.Width = 0.8125F;
            // 
            // s_CheckPayment2
            // 
            this.s_CheckPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_CheckPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_CheckPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_CheckPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_CheckPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_CheckPayment2.DataField = "CheckPayment";
            this.s_CheckPayment2.Height = 0.125F;
            this.s_CheckPayment2.Left = 4.4375F;
            this.s_CheckPayment2.MultiLine = false;
            this.s_CheckPayment2.Name = "s_CheckPayment2";
            this.s_CheckPayment2.OutputFormat = resources.GetString("s_CheckPayment2.OutputFormat");
            this.s_CheckPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_CheckPayment2.SummaryGroup = "SectionHeader";
            this.s_CheckPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_CheckPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_CheckPayment2.Text = "1,234,567,890";
            this.s_CheckPayment2.Top = 0.6299213F;
            this.s_CheckPayment2.Width = 0.8125F;
            // 
            // s_DraftPayment2
            // 
            this.s_DraftPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_DraftPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_DraftPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_DraftPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_DraftPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_DraftPayment2.DataField = "DraftPayment";
            this.s_DraftPayment2.Height = 0.125F;
            this.s_DraftPayment2.Left = 5.25F;
            this.s_DraftPayment2.MultiLine = false;
            this.s_DraftPayment2.Name = "s_DraftPayment2";
            this.s_DraftPayment2.OutputFormat = resources.GetString("s_DraftPayment2.OutputFormat");
            this.s_DraftPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_DraftPayment2.SummaryGroup = "SectionHeader";
            this.s_DraftPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_DraftPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_DraftPayment2.Text = "1,234,567,890";
            this.s_DraftPayment2.Top = 0.6299213F;
            this.s_DraftPayment2.Width = 0.8125F;
            // 
            // s_OffsetPayment2
            // 
            this.s_OffsetPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OffsetPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OffsetPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OffsetPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OffsetPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OffsetPayment2.DataField = "OffsetPayment";
            this.s_OffsetPayment2.Height = 0.125F;
            this.s_OffsetPayment2.Left = 6.0625F;
            this.s_OffsetPayment2.MultiLine = false;
            this.s_OffsetPayment2.Name = "s_OffsetPayment2";
            this.s_OffsetPayment2.OutputFormat = resources.GetString("s_OffsetPayment2.OutputFormat");
            this.s_OffsetPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OffsetPayment2.SummaryGroup = "SectionHeader";
            this.s_OffsetPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OffsetPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OffsetPayment2.Text = "1,234,567,890";
            this.s_OffsetPayment2.Top = 0.6299213F;
            this.s_OffsetPayment2.Width = 0.8125F;
            // 
            // s_OthsPayment2
            // 
            this.s_OthsPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_OthsPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_OthsPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_OthsPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_OthsPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_OthsPayment2.DataField = "FundTransferPayment";
            this.s_OthsPayment2.Height = 0.125F;
            this.s_OthsPayment2.Left = 7.6875F;
            this.s_OthsPayment2.MultiLine = false;
            this.s_OthsPayment2.Name = "s_OthsPayment2";
            this.s_OthsPayment2.OutputFormat = resources.GetString("s_OthsPayment2.OutputFormat");
            this.s_OthsPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_OthsPayment2.SummaryGroup = "SectionHeader";
            this.s_OthsPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_OthsPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_OthsPayment2.Text = "1,234,567,890";
            this.s_OthsPayment2.Top = 0.6299213F;
            this.s_OthsPayment2.Width = 0.8125F;
            // 
            // s_FundTransferPayment2
            // 
            this.s_FundTransferPayment2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment2.Border.RightColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment2.Border.TopColor = System.Drawing.Color.Black;
            this.s_FundTransferPayment2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_FundTransferPayment2.DataField = "OthsPayment";
            this.s_FundTransferPayment2.Height = 0.125F;
            this.s_FundTransferPayment2.Left = 6.875F;
            this.s_FundTransferPayment2.MultiLine = false;
            this.s_FundTransferPayment2.Name = "s_FundTransferPayment2";
            this.s_FundTransferPayment2.OutputFormat = resources.GetString("s_FundTransferPayment2.OutputFormat");
            this.s_FundTransferPayment2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_FundTransferPayment2.SummaryGroup = "SectionHeader";
            this.s_FundTransferPayment2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_FundTransferPayment2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_FundTransferPayment2.Text = "1,234,567,890";
            this.s_FundTransferPayment2.Top = 0.6299213F;
            this.s_FundTransferPayment2.Width = 0.8125F;
            // 
            // s_ThisTimeFeePayNrml2
            // 
            this.s_ThisTimeFeePayNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeFeePayNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeFeePayNrml2.DataField = "ThisTimeFeePayNrml";
            this.s_ThisTimeFeePayNrml2.Height = 0.125F;
            this.s_ThisTimeFeePayNrml2.Left = 8.5F;
            this.s_ThisTimeFeePayNrml2.MultiLine = false;
            this.s_ThisTimeFeePayNrml2.Name = "s_ThisTimeFeePayNrml2";
            this.s_ThisTimeFeePayNrml2.OutputFormat = resources.GetString("s_ThisTimeFeePayNrml2.OutputFormat");
            this.s_ThisTimeFeePayNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeFeePayNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeFeePayNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeFeePayNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeFeePayNrml2.Text = "1,234,567,890";
            this.s_ThisTimeFeePayNrml2.Top = 0.6299213F;
            this.s_ThisTimeFeePayNrml2.Width = 0.8125F;
            // 
            // s_ThisTimeDisPayNrml2
            // 
            this.s_ThisTimeDisPayNrml2.Border.BottomColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml2.Border.LeftColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml2.Border.RightColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml2.Border.TopColor = System.Drawing.Color.Black;
            this.s_ThisTimeDisPayNrml2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.s_ThisTimeDisPayNrml2.DataField = "ThisTimeDisPayNrml";
            this.s_ThisTimeDisPayNrml2.Height = 0.125F;
            this.s_ThisTimeDisPayNrml2.Left = 9.3125F;
            this.s_ThisTimeDisPayNrml2.MultiLine = false;
            this.s_ThisTimeDisPayNrml2.Name = "s_ThisTimeDisPayNrml2";
            this.s_ThisTimeDisPayNrml2.OutputFormat = resources.GetString("s_ThisTimeDisPayNrml2.OutputFormat");
            this.s_ThisTimeDisPayNrml2.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.s_ThisTimeDisPayNrml2.SummaryGroup = "SectionHeader";
            this.s_ThisTimeDisPayNrml2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.s_ThisTimeDisPayNrml2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.s_ThisTimeDisPayNrml2.Text = "1,234,567,890";
            this.s_ThisTimeDisPayNrml2.Top = 0.6299213F;
            this.s_ThisTimeDisPayNrml2.Width = 0.8125F;
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
            this.textBox40.DataField = "TotalThisTimeStockPriceTaxRate1";
            this.textBox40.Height = 0.125F;
            this.textBox40.Left = 5.25F;
            this.textBox40.MultiLine = false;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox40.SummaryGroup = "SectionHeader";
            this.textBox40.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox40.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox40.Text = "1,234,567,890";
            this.textBox40.Top = 0.125F;
            this.textBox40.Width = 0.8125F;
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
            this.textBox41.DataField = "TotalThisRgdsDisPricTaxRate1";
            this.textBox41.Height = 0.125F;
            this.textBox41.Left = 6.0625F;
            this.textBox41.MultiLine = false;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox41.SummaryGroup = "SectionHeader";
            this.textBox41.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox41.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox41.Text = "1,234,567,890";
            this.textBox41.Top = 0.125F;
            this.textBox41.Width = 0.8125F;
            // 
            // textBox42
            // 
            this.textBox42.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.RightColor = System.Drawing.Color.Black;
            this.textBox42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.Border.TopColor = System.Drawing.Color.Black;
            this.textBox42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox42.DataField = "TotalPureStockTaxRate1";
            this.textBox42.Height = 0.125F;
            this.textBox42.Left = 6.875F;
            this.textBox42.MultiLine = false;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox42.SummaryGroup = "SectionHeader";
            this.textBox42.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox42.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox42.Text = "1,234,567,890";
            this.textBox42.Top = 0.125F;
            this.textBox42.Width = 0.8125F;
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
            this.textBox43.DataField = "TotalStockPricTaxTaxRate1";
            this.textBox43.Height = 0.125F;
            this.textBox43.Left = 7.6875F;
            this.textBox43.MultiLine = false;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox43.SummaryGroup = "SectionHeader";
            this.textBox43.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox43.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox43.Text = "1,234,567,890";
            this.textBox43.Top = 0.125F;
            this.textBox43.Width = 0.8125F;
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
            this.textBox44.DataField = "TotalStckTtlAccPayBalanceTaxRate1";
            this.textBox44.Height = 0.125F;
            this.textBox44.Left = 8.5F;
            this.textBox44.MultiLine = false;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox44.SummaryGroup = "SectionHeader";
            this.textBox44.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox44.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox44.Text = "1,234,567,890";
            this.textBox44.Top = 0.125F;
            this.textBox44.Width = 0.8125F;
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
            this.textBox45.DataField = "TotalStockSlipCountTaxRate1";
            this.textBox45.Height = 0.125F;
            this.textBox45.Left = 10.1875F;
            this.textBox45.MultiLine = false;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox45.SummaryGroup = "SectionHeader";
            this.textBox45.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox45.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox45.Text = "234,567";
            this.textBox45.Top = 0.125F;
            this.textBox45.Width = 0.5F;
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
            this.textBox46.DataField = "TotalThisTimeStockPriceTaxRate2";
            this.textBox46.Height = 0.125F;
            this.textBox46.Left = 5.25F;
            this.textBox46.MultiLine = false;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox46.SummaryGroup = "SectionHeader";
            this.textBox46.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox46.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox46.Text = "1,234,567,890";
            this.textBox46.Top = 0.25F;
            this.textBox46.Width = 0.8125F;
            // 
            // textBox47
            // 
            this.textBox47.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.Border.RightColor = System.Drawing.Color.Black;
            this.textBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.Border.TopColor = System.Drawing.Color.Black;
            this.textBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox47.DataField = "TotalThisRgdsDisPricTaxRate2";
            this.textBox47.Height = 0.125F;
            this.textBox47.Left = 6.0625F;
            this.textBox47.MultiLine = false;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox47.SummaryGroup = "SectionHeader";
            this.textBox47.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox47.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox47.Text = "1,234,567,890";
            this.textBox47.Top = 0.25F;
            this.textBox47.Width = 0.8125F;
            // 
            // textBox48
            // 
            this.textBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.RightColor = System.Drawing.Color.Black;
            this.textBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.TopColor = System.Drawing.Color.Black;
            this.textBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.DataField = "TotalPureStockTaxRate2";
            this.textBox48.Height = 0.125F;
            this.textBox48.Left = 6.875F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox48.SummaryGroup = "SectionHeader";
            this.textBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox48.Text = "1,234,567,890";
            this.textBox48.Top = 0.25F;
            this.textBox48.Width = 0.8125F;
            // 
            // textBox49
            // 
            this.textBox49.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.Border.RightColor = System.Drawing.Color.Black;
            this.textBox49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.Border.TopColor = System.Drawing.Color.Black;
            this.textBox49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox49.DataField = "TotalStockPricTaxTaxRate2";
            this.textBox49.Height = 0.125F;
            this.textBox49.Left = 7.6875F;
            this.textBox49.MultiLine = false;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox49.SummaryGroup = "SectionHeader";
            this.textBox49.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox49.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox49.Text = "1,234,567,890";
            this.textBox49.Top = 0.25F;
            this.textBox49.Width = 0.8125F;
            // 
            // textBox50
            // 
            this.textBox50.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.Border.RightColor = System.Drawing.Color.Black;
            this.textBox50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.Border.TopColor = System.Drawing.Color.Black;
            this.textBox50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox50.DataField = "TotalStckTtlAccPayBalanceTaxRate2";
            this.textBox50.Height = 0.125F;
            this.textBox50.Left = 8.5F;
            this.textBox50.MultiLine = false;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox50.SummaryGroup = "SectionHeader";
            this.textBox50.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox50.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox50.Text = "1,234,567,890";
            this.textBox50.Top = 0.25F;
            this.textBox50.Width = 0.8125F;
            // 
            // textBox51
            // 
            this.textBox51.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.Border.RightColor = System.Drawing.Color.Black;
            this.textBox51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.Border.TopColor = System.Drawing.Color.Black;
            this.textBox51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox51.DataField = "TotalStockSlipCountTaxRate2";
            this.textBox51.Height = 0.125F;
            this.textBox51.Left = 10.1875F;
            this.textBox51.MultiLine = false;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox51.SummaryGroup = "SectionHeader";
            this.textBox51.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox51.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox51.Text = "234,567";
            this.textBox51.Top = 0.25F;
            this.textBox51.Width = 0.5F;
            // 
            // textBox52
            // 
            this.textBox52.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.RightColor = System.Drawing.Color.Black;
            this.textBox52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.Border.TopColor = System.Drawing.Color.Black;
            this.textBox52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox52.DataField = "TotalThisTimeStockPriceOther";
            this.textBox52.Height = 0.125F;
            this.textBox52.Left = 5.25F;
            this.textBox52.MultiLine = false;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox52.SummaryGroup = "SectionHeader";
            this.textBox52.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox52.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox52.Text = "1,234,567,890";
            this.textBox52.Top = 0.375F;
            this.textBox52.Width = 0.8125F;
            // 
            // textBox53
            // 
            this.textBox53.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.Border.RightColor = System.Drawing.Color.Black;
            this.textBox53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.Border.TopColor = System.Drawing.Color.Black;
            this.textBox53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox53.DataField = "TotalThisRgdsDisPricOther";
            this.textBox53.Height = 0.125F;
            this.textBox53.Left = 6.0625F;
            this.textBox53.MultiLine = false;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox53.SummaryGroup = "SectionHeader";
            this.textBox53.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox53.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox53.Text = "1,234,567,890";
            this.textBox53.Top = 0.375F;
            this.textBox53.Width = 0.8125F;
            // 
            // textBox54
            // 
            this.textBox54.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.RightColor = System.Drawing.Color.Black;
            this.textBox54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.Border.TopColor = System.Drawing.Color.Black;
            this.textBox54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox54.DataField = "TotalPureStockOther";
            this.textBox54.Height = 0.125F;
            this.textBox54.Left = 6.875F;
            this.textBox54.MultiLine = false;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox54.SummaryGroup = "SectionHeader";
            this.textBox54.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox54.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox54.Text = "1,234,567,890";
            this.textBox54.Top = 0.375F;
            this.textBox54.Width = 0.8125F;
            // 
            // textBox55
            // 
            this.textBox55.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.Border.RightColor = System.Drawing.Color.Black;
            this.textBox55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.Border.TopColor = System.Drawing.Color.Black;
            this.textBox55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox55.DataField = "TotalStockPricTaxOther";
            this.textBox55.Height = 0.125F;
            this.textBox55.Left = 7.6875F;
            this.textBox55.MultiLine = false;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox55.SummaryGroup = "SectionHeader";
            this.textBox55.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox55.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox55.Text = "1,234,567,890";
            this.textBox55.Top = 0.375F;
            this.textBox55.Width = 0.8125F;
            // 
            // textBox56
            // 
            this.textBox56.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.Border.RightColor = System.Drawing.Color.Black;
            this.textBox56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.Border.TopColor = System.Drawing.Color.Black;
            this.textBox56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox56.DataField = "TotalStckTtlAccPayBalanceOther";
            this.textBox56.Height = 0.125F;
            this.textBox56.Left = 8.5F;
            this.textBox56.MultiLine = false;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox56.SummaryGroup = "SectionHeader";
            this.textBox56.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox56.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox56.Text = "1,234,567,890";
            this.textBox56.Top = 0.375F;
            this.textBox56.Width = 0.8125F;
            // 
            // textBox57
            // 
            this.textBox57.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.RightColor = System.Drawing.Color.Black;
            this.textBox57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.Border.TopColor = System.Drawing.Color.Black;
            this.textBox57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox57.DataField = "TotalStockSlipCountOther";
            this.textBox57.Height = 0.125F;
            this.textBox57.Left = 10.1875F;
            this.textBox57.MultiLine = false;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox57.SummaryGroup = "SectionHeader";
            this.textBox57.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox57.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox57.Text = "234,567";
            this.textBox57.Top = 0.375F;
            this.textBox57.Width = 0.5F;
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
            this.label11.DataField = "TitleTaxRate1";
            this.label11.Height = 0.125F;
            this.label11.HyperLink = null;
            this.label11.Left = 4.5F;
            this.label11.Name = "label11";
            this.label11.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label11.Text = "10%";
            this.label11.Top = 0.125F;
            this.label11.Width = 0.75F;
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
            this.label12.DataField = "TitleTaxRate2";
            this.label12.Height = 0.125F;
            this.label12.HyperLink = null;
            this.label12.Left = 4.5F;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label12.Text = "8%";
            this.label12.Top = 0.25F;
            this.label12.Width = 0.75F;
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
            this.label13.Height = 0.125F;
            this.label13.HyperLink = null;
            this.label13.Left = 4.5F;
            this.label13.Name = "label13";
            this.label13.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label13.Text = "その他";
            this.label13.Top = 0.375F;
            this.label13.Width = 0.75F;
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
            this.textBox12.DataField = "TotalThisTimeStockPriceTaxFree";
            this.textBox12.Height = 0.125F;
            this.textBox12.Left = 5.248032F;
            this.textBox12.MultiLine = false;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox12.SummaryGroup = "SectionHeader";
            this.textBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox12.Text = "1,234,567,890";
            this.textBox12.Top = 0.503937F;
            this.textBox12.Width = 0.8125F;
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
            this.textBox13.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox13.Height = 0.125F;
            this.textBox13.Left = 6.062992F;
            this.textBox13.MultiLine = false;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox13.SummaryGroup = "SectionHeader";
            this.textBox13.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox13.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox13.Text = "1,234,567,890";
            this.textBox13.Top = 0.503937F;
            this.textBox13.Width = 0.8125F;
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
            this.textBox14.DataField = "TotalPureStockTaxFree";
            this.textBox14.Height = 0.125F;
            this.textBox14.Left = 6.874015F;
            this.textBox14.MultiLine = false;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox14.SummaryGroup = "SectionHeader";
            this.textBox14.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox14.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox14.Text = "1,234,567,890";
            this.textBox14.Top = 0.503937F;
            this.textBox14.Width = 0.8125F;
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
            this.textBox15.DataField = "TotalStockPricTaxTaxFree";
            this.textBox15.Height = 0.125F;
            this.textBox15.Left = 7.688977F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox15.SummaryGroup = "SectionHeader";
            this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox15.Text = "1,234,567,890";
            this.textBox15.Top = 0.503937F;
            this.textBox15.Width = 0.8125F;
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
            this.textBox16.DataField = "TotalStckTtlAccPayBalanceTaxFree";
            this.textBox16.Height = 0.125F;
            this.textBox16.Left = 8.5F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox16.SummaryGroup = "SectionHeader";
            this.textBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox16.Text = "1,234,567,890";
            this.textBox16.Top = 0.503937F;
            this.textBox16.Width = 0.8125F;
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
            this.textBox17.DataField = "TotalStockSlipCountTaxFree";
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 10.18701F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox17.SummaryGroup = "SectionHeader";
            this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox17.Text = "234,567";
            this.textBox17.Top = 0.503937F;
            this.textBox17.Width = 0.5F;
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
            this.label17.Height = 0.125F;
            this.label17.HyperLink = null;
            this.label17.Left = 4.5F;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label17.Text = "非課税";
            this.label17.Top = 0.503937F;
            this.label17.Width = 0.75F;
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
            this.textBox18.DataField = "TotalThisTimeStockPriceTaxFree";
            this.textBox18.Height = 0.125F;
            this.textBox18.Left = 5.248032F;
            this.textBox18.MultiLine = false;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox18.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox18.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox18.Text = "1,234,567,890";
            this.textBox18.Top = 0.503937F;
            this.textBox18.Width = 0.8125F;
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
            this.textBox19.DataField = "TotalThisRgdsDisPricTaxFree";
            this.textBox19.Height = 0.125F;
            this.textBox19.Left = 6.062992F;
            this.textBox19.MultiLine = false;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox19.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox19.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox19.Text = "1,234,567,890";
            this.textBox19.Top = 0.503937F;
            this.textBox19.Width = 0.8125F;
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
            this.textBox20.DataField = "TotalPureStockTaxFree";
            this.textBox20.Height = 0.125F;
            this.textBox20.Left = 6.874015F;
            this.textBox20.MultiLine = false;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox20.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox20.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox20.Text = "1,234,567,890";
            this.textBox20.Top = 0.503937F;
            this.textBox20.Width = 0.8125F;
            // 
            // textBox31
            // 
            this.textBox31.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.RightColor = System.Drawing.Color.Black;
            this.textBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.Border.TopColor = System.Drawing.Color.Black;
            this.textBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox31.DataField = "TotalStockPricTaxTaxFree";
            this.textBox31.Height = 0.125F;
            this.textBox31.Left = 7.688977F;
            this.textBox31.MultiLine = false;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox31.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox31.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox31.Text = "1,234,567,890";
            this.textBox31.Top = 0.503937F;
            this.textBox31.Width = 0.8125F;
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
            this.textBox32.DataField = "TotalStckTtlAccPayBalanceTaxFree";
            this.textBox32.Height = 0.125F;
            this.textBox32.Left = 8.5F;
            this.textBox32.MultiLine = false;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox32.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox32.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox32.Text = "1,234,567,890";
            this.textBox32.Top = 0.503937F;
            this.textBox32.Width = 0.8125F;
            // 
            // textBox33
            // 
            this.textBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.RightColor = System.Drawing.Color.Black;
            this.textBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.Border.TopColor = System.Drawing.Color.Black;
            this.textBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox33.DataField = "TotalStockSlipCountTaxFree";
            this.textBox33.Height = 0.125F;
            this.textBox33.Left = 10.18898F;
            this.textBox33.MultiLine = false;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ ゴシック; vertical-align: top; ";
            this.textBox33.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox33.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox33.Text = "234,567";
            this.textBox33.Top = 0.503937F;
            this.textBox33.Width = 0.5F;
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
            this.label18.HyperLink = null;
            this.label18.Left = 4.5F;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.label18.Text = "非課税";
            this.label18.Top = 0.503937F;
            this.label18.Width = 0.75F;
            // 
            // PMKAK02023P_01A4C
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
            this.PrintWidth = 10.89375F;
            this.Script = "public void ActiveReport_ReportStart()\n{\n\n}";
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.GrandTotalHeader2);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SectionHeader2);
            this.Sections.Add(this.SumAccPaymentHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SumAccPaymentFooter);
            this.Sections.Add(this.SectionFooter2);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter2);
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
            this.ReportStart += new System.EventHandler(this.PMKAK02023P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeAccPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcAcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumPayeeSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StckTtlAccPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Tax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label106)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label107)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Payee9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_LastTimeAccPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_ThisTimeTtlBlcAcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_PureStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StockPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_StckTtlAccPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumAddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SumSectionGuideNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonAddUpNonProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_LastTimeAccPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_ThisTimeTtlBlcAcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisRgdsDisPric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_PureStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockSlipCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StockPricTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_StckTtlAccPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisPayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CashPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_TrfrPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_CheckPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_DraftPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OffsetPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_OthsPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_FundTransferPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeFeePayNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_ThisTimeDisPayNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox72)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox73)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox74)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox75)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CashPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_TrfrPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_CheckPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_DraftPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OffsetPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_OthsPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_FundTransferPayment2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeFeePayNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_ThisTimeDisPayNrml2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
