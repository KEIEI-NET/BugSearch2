using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Data;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 発行確認一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 発行確認一覧表のフォームクラスです。</br>
    /// <br>Programer	: 30009 渋谷 大輔</br>
    /// <br>Date		: 2008.12.02</br>
    /// <br>Programer	: 30009 渋谷 大輔</br>
    /// <br>Date		: 2009.01.13</br>
    /// </remarks>
	public class PMUOE02044P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
    {
        # region Constructor
        /// <summary>
		/// 発行確認一覧表フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 発行確認一覧表フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		public PMUOE02044P_01A4C()
		{
			InitializeComponent();
        }
        # endregion

        # region Dispose
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
						if (this._hedrpt != null)
						{
							this._hedrpt.Dispose();
						}
						if (this._fotrpt != null)
						{
							this._fotrpt.Dispose();
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
        # endregion

        # region Private Member
        private string				 _pageHeaderSortOderTitle;		// ソート順
		private int					 _extraCondHeadOutDiv;			// 抽出条件ヘッダ出力区分
		private StringCollection	 _extraConditions;				// 抽出条件
		private int					 _pageFooterOutCode;			// フッター出力区分
		private StringCollection	 _pageFooters;					// フッターメッセージ
		private	SFCMN06002C			 _printInfo;					// 印刷情報クラス
		private ArrayList			 _otherDataList;				// その他データ
		private PublicationConfOrderCndtn _extrInfo;				// 抽出条件クラス

		// その他データ格納項目
		private int					 _printCount;					// ページ数カウント用
		private string				 _pageHeaderSubtitle;			// フォームサブタイトル

		// ヘッダーサブレポート作成
		ListCommon_ExtraHeader _hedrpt   = null;
		// フッターレポート作成
		ListCommon_PageFooter _fotrpt = null;
		//Dispose判定フラグ
		Boolean disposed = false;

        private Label ListPrice_Title;
        private Label ReceiveDate_Title;
        private Label OnlineRowNo_Title;
        private Label UoeRemark1_Title;
        private Label UoeRemark2_Title;
        private Label SystemDivName_Title;
        private Label AnswerPartsNo_Title;
        private Label WarehouseCode_Title;
        private Label AnswerListPrice_Title;
        private Label AnswerSalesUnitCost_Title;
        private Label UOESectOutGoodsCnt_Title;
        private Label BOSlipNo1_Title;
        private Label BOSlipNo2_Title;
        private Label BOSlipNo3_Title;
        private Label BOShipmentCnt1_Title;
        private Label BOShipmentCnt2_Title;
        private Label BOShipmentCnt3_Title;
        private Label MakerFollowCnt_Title;
        private Label EOAlwcCount_Title;
        private Label BOManagementNo_Title;
        private Label UOESupplierName_Title;
        private Label CheckCnts_Title;
        private Label AnswerPartsName_Title;
        private TextBox ReceiveDate_TextBox;
        private TextBox OnlineRowNo_TextBox;
        private TextBox UoeRemark1_TextBox;
        private TextBox UoeRemark2_TextBox;
        private TextBox SystemDivName_TextBox;
        private TextBox AnswerPartsNo_TextBox;
        private TextBox AnswerPartsName_TextBox;
        private TextBox WarehouseCode_TextBox;
        private TextBox ListPrice_TextBox;
        private TextBox AnswerListPrice_TextBox;
        private TextBox AnswerSalesUnitCost_TextBox;
        private TextBox AcceptAnOrderCnt_TextBox;
        private TextBox UOESectionSlipNo_TextBox;
        private TextBox UOESectOutGoodsCnt_TextBox;
        private TextBox BOShipmentCnt1_TextBox;
        private TextBox BOSlipNo1_TextBox;
        private TextBox BOShipmentCnt2_TextBox;
        private TextBox BOSlipNo2_TextBox;
        private TextBox BOShipmentCnt3_TextBox;
        private TextBox BOSlipNo3_TextBox;
        private TextBox MakerFollowCnt_TextBox;
        private TextBox BOManagementNo_TextBox;
        private TextBox EOAlwcCount_TextBox;
        private TextBox CheckCnts_TextBox;
        private TextBox SectionGuideNm_TextBox;
        private Label SectionGuideNm_Title;
        private TextBox SectionGuideNmCond_TextBox;
        private Line line5;
        private Line line6;
        private Line line2;
        private Line line3;
        private Line line4;
        private Label ReceiveDateCond_Title;
        private TextBox St_ReceiveDate_TextBox;
        private Label label1;
        private TextBox Ed_ReceiveDate_TextBox;
        private Label SystemDivNameHeader_Title;
        private TextBox SystemDivNameHeader_TextBox;
        private Label PrintCond_Title;
        private TextBox PrintCond_TextBox;
        private TextBox UOESupplierName_TextBox; 
		# endregion

		# region IPrintActiveReportTypeList インターフェース
		/// <summary>
		/// ページヘッダソート順タイトル項目
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set { _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set { _extraCondHeadOutDiv = value; }
		}

		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set { this._extraConditions = value; }
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set { this._pageFooterOutCode = value; }
		}

		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set { this._pageFooters = value; }
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo = value;
                this._extrInfo = (PublicationConfOrderCndtn)this._printInfo.jyoken;
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
			}
		}

		/// <summary>
		/// 帳票サブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set { this._pageHeaderSubtitle = value; }
		}

		/// <summary>
		/// 印刷件数カウントアップイベント
		/// </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;
		# endregion

		# region IPrintActiveReportTypeCommon インターフェース
		/// <summary>
		/// 背景透過設定値プロパティ
		/// </summary>
		public int WatermarkMode
		{
			get{return 0;}
			set{}
		}
		# endregion

		#region Private Method
        # region レポート要素出力設定
		/// <summary>
		/// レポート要素出力設定
		/// </summary>
 		/// <remarks>
		/// <br>Note       : レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{

        }
        # endregion

        # region グループサプレス処理
        /// <summary>
        /// グループサプレス処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス処理を行います</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>    
        private void SetOfGroupSuppres()
        {

        }
        # endregion

		# region 明細項目移動処理
		/// <summary>
        /// 明細項目移動処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : 明細項目の移動処理を行います</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>    
        private void MoveDetailItem()
        {
        }
		# endregion

		# region バッファクリア処理
		/// <summary>
        /// サプレス用バッファクリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note      : グループサプレス用のバッファを初期化します</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
        private void BufferClear()
        {
        }
        # endregion
        # endregion

        # region Control Event
        #region PageHeader_Formatイベント
        /// <summary>
		/// PageHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページヘッダーグループの初期化イベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付           
            // 現在の時刻を取得
			DateTime now = DateTime.Now;
            // 作成日(西暦で表示)
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);			
			// 作成時間
			this.PrintTime.Text   = now.ToString("HH:mm");
        }
        #endregion

        # region ExtraHeader_Formatイベント
        /// <summary>
		/// ExtraHeader_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ExtraHeaderグループの初期化イベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
            // 拠点
            this.SectionGuideNmCond_TextBox.Text = this.SectionGuideNm_TextBox.Text;

            // 発注日
            
            this.St_ReceiveDate_TextBox.Text = this._extrInfo.St_ReceiveDate.ToString("yyyy/MM/dd");
            this.Ed_ReceiveDate_TextBox.Text = this._extrInfo.Ed_ReceiveDate.ToString("yyyy/MM/dd");

            // システム区分
            this.SystemDivNameHeader_TextBox.Text = PMUOE02049EA.GetSystemDivNm(this._extrInfo.SystemDivCd);

            // 印刷条件
            if (this._extrInfo.PrintCndtn == 0)
            {
                this.PrintCond_TextBox.Text = "チェック分のみ";
            }
            else if (this._extrInfo.PrintCndtn == 1)
            {
                this.PrintCond_TextBox.Text = "全て";
            }

		}
        # endregion

        # region PageFooter_Formatイベント
        /// <summary>
		/// PageFooter_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : PageFooter_Formatグループの初期化イベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッターレポート作成
                if (this._fotrpt == null)
                    this._fotrpt = new ListCommon_PageFooter();

                // フッター印字項目設定
                if (this._pageFooters[0] != null)
                {
                    this._fotrpt.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this._fotrpt.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = this._fotrpt;
            }
        }
        # endregion

        # region ReportStartイベント
        /// <summary>
        /// PMUOE02044P_01A4C_ReportStartイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : レポートの設定をするイベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
        private void PMUOE02044P_01A4C_ReportStart(object sender, EventArgs e)
        {
            // レポート要素出力設定
            this.SetOfReportMembersOutput();
        }


        # endregion

        # region Detail_AfterPrintイベント
        /// <summary>
		/// Detail_AfterPrintイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
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
        # endregion

        # region Detail_BeforePrintイベント
        /// <summary>
		/// Detail_BeforePrintイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// グループサプレス処理
			this.SetOfGroupSuppres();
			
			// レポート用文字列編集処理（連帳帳票用）
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        # endregion

        # region Detail_Formatイベント
        /// <summary>
		/// Detail_Formatイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : Detailセクションの印刷前に発生するイベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			// 明細項目移動処理
			this.MoveDetailItem();

            // 2009.01.13 add >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 拠点
            if (this.UOESectOutGoodsCnt_TextBox.Text == "0")
                this.UOESectOutGoodsCnt_TextBox.Text = string.Empty;
            // フォロー
            if (this.BOShipmentCnt1_TextBox.Text == "0")
                this.BOShipmentCnt1_TextBox.Text = string.Empty;
            if (this.BOShipmentCnt2_TextBox.Text == "0")
                this.BOShipmentCnt2_TextBox.Text = string.Empty;
            if (this.BOShipmentCnt3_TextBox.Text == "0")
                this.BOShipmentCnt3_TextBox.Text = string.Empty;
            // メーカーフォロー
            if (this.MakerFollowCnt_TextBox.Text == "0")
                this.MakerFollowCnt_TextBox.Text = string.Empty;
            // EO
            if (this.EOAlwcCount_TextBox.Text == "0")
                this.EOAlwcCount_TextBox.Text = string.Empty;
            // 2009.01.13 add <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}
        # endregion

        # region PageEndイベント
        /// <summary>
		/// PageEndイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ページが終わる時に発生するイベントです。</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
        private void PMUOE02044P_01A4C_PageEnd(object sender, EventArgs e)
        {
            // サプレス用バッファクリア処理
            this.BufferClear();
        }

        # endregion
        # endregion

        #region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label PrintDate_Title;
		private DataDynamics.ActiveReports.TextBox PrintDate;
		private DataDynamics.ActiveReports.Label PrintPage_Title;
		private DataDynamics.ActiveReports.TextBox PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox PrintTime;
        private DataDynamics.ActiveReports.Label FormName;
        private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Label UOESectionSlipNo_Title;
        private DataDynamics.ActiveReports.Label GoodsNo_Title;
		private DataDynamics.ActiveReports.Label OnlineNo_Title;
		private DataDynamics.ActiveReports.Label AcceptAnOrderCnt_Title;
        private DataDynamics.ActiveReports.Label WarehouseShelfNo_Title;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox GoodsNo_TextBox;
        private DataDynamics.ActiveReports.TextBox WarehouseShelfNo_TextBox;
        private DataDynamics.ActiveReports.TextBox OnlineNo_TextBox;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE02044P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseShelfNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.OnlineNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.ReceiveDate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.OnlineRowNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark1_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.UoeRemark2_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SystemDivName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnswerPartsNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnswerPartsName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseCode_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnswerListPrice_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AnswerSalesUnitCost_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.UOESectionSlipNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.UOESectOutGoodsCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOShipmentCnt1_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOSlipNo1_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOShipmentCnt2_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOSlipNo2_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOShipmentCnt3_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOSlipNo3_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.MakerFollowCnt_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.BOManagementNo_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.EOAlwcCount_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.CheckCnts_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierName_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideNm_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PrintDate_Title = new DataDynamics.ActiveReports.Label();
            this.PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.PrintPage_Title = new DataDynamics.ActiveReports.Label();
            this.PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.FormName = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionGuideNm_Title = new DataDynamics.ActiveReports.Label();
            this.SectionGuideNmCond_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.ReceiveDateCond_Title = new DataDynamics.ActiveReports.Label();
            this.St_ReceiveDate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Ed_ReceiveDate_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.SystemDivNameHeader_Title = new DataDynamics.ActiveReports.Label();
            this.SystemDivNameHeader_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.PrintCond_Title = new DataDynamics.ActiveReports.Label();
            this.PrintCond_TextBox = new DataDynamics.ActiveReports.TextBox();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.UOESectionSlipNo_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.OnlineNo_Title = new DataDynamics.ActiveReports.Label();
            this.AcceptAnOrderCnt_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseShelfNo_Title = new DataDynamics.ActiveReports.Label();
            this.ListPrice_Title = new DataDynamics.ActiveReports.Label();
            this.ReceiveDate_Title = new DataDynamics.ActiveReports.Label();
            this.OnlineRowNo_Title = new DataDynamics.ActiveReports.Label();
            this.UoeRemark1_Title = new DataDynamics.ActiveReports.Label();
            this.UoeRemark2_Title = new DataDynamics.ActiveReports.Label();
            this.SystemDivName_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerPartsNo_Title = new DataDynamics.ActiveReports.Label();
            this.WarehouseCode_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerListPrice_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerSalesUnitCost_Title = new DataDynamics.ActiveReports.Label();
            this.UOESectOutGoodsCnt_Title = new DataDynamics.ActiveReports.Label();
            this.BOSlipNo1_Title = new DataDynamics.ActiveReports.Label();
            this.BOSlipNo2_Title = new DataDynamics.ActiveReports.Label();
            this.BOSlipNo3_Title = new DataDynamics.ActiveReports.Label();
            this.BOShipmentCnt1_Title = new DataDynamics.ActiveReports.Label();
            this.BOShipmentCnt2_Title = new DataDynamics.ActiveReports.Label();
            this.BOShipmentCnt3_Title = new DataDynamics.ActiveReports.Label();
            this.MakerFollowCnt_Title = new DataDynamics.ActiveReports.Label();
            this.EOAlwcCount_Title = new DataDynamics.ActiveReports.Label();
            this.BOManagementNo_Title = new DataDynamics.ActiveReports.Label();
            this.UOESupplierName_Title = new DataDynamics.ActiveReports.Label();
            this.CheckCnts_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerPartsName_Title = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineRowNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt1_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo1_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt2_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo2_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt3_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo3_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowCnt_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOManagementNo_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EOAlwcCount_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCnts_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNmCond_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDateCond_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.St_ReceiveDate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ed_ReceiveDate_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivNameHeader_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivNameHeader_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintCond_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintCond_TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineRowNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo2_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo3_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt1_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt2_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt3_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowCnt_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EOAlwcCount_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOManagementNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCnts_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo_TextBox,
            this.WarehouseShelfNo_TextBox,
            this.OnlineNo_TextBox,
            this.ReceiveDate_TextBox,
            this.OnlineRowNo_TextBox,
            this.UoeRemark1_TextBox,
            this.UoeRemark2_TextBox,
            this.SystemDivName_TextBox,
            this.AnswerPartsNo_TextBox,
            this.AnswerPartsName_TextBox,
            this.WarehouseCode_TextBox,
            this.ListPrice_TextBox,
            this.AnswerListPrice_TextBox,
            this.AnswerSalesUnitCost_TextBox,
            this.AcceptAnOrderCnt_TextBox,
            this.UOESectionSlipNo_TextBox,
            this.UOESectOutGoodsCnt_TextBox,
            this.BOShipmentCnt1_TextBox,
            this.BOSlipNo1_TextBox,
            this.BOShipmentCnt2_TextBox,
            this.BOSlipNo2_TextBox,
            this.BOShipmentCnt3_TextBox,
            this.BOSlipNo3_TextBox,
            this.MakerFollowCnt_TextBox,
            this.BOManagementNo_TextBox,
            this.EOAlwcCount_TextBox,
            this.CheckCnts_TextBox,
            this.UOESupplierName_TextBox,
            this.SectionGuideNm_TextBox,
            this.line5,
            this.line6});
            this.Detail.Height = 0.4166667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // GoodsNo_TextBox
            // 
            this.GoodsNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_TextBox.DataField = "GoodsNo";
            this.GoodsNo_TextBox.Height = 0.125F;
            this.GoodsNo_TextBox.Left = 2.625F;
            this.GoodsNo_TextBox.MultiLine = false;
            this.GoodsNo_TextBox.Name = "GoodsNo_TextBox";
            this.GoodsNo_TextBox.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.GoodsNo_TextBox.Text = "123456789012345678901234";
            this.GoodsNo_TextBox.Top = 0.0625F;
            this.GoodsNo_TextBox.Width = 1.375F;
            // 
            // WarehouseShelfNo_TextBox
            // 
            this.WarehouseShelfNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_TextBox.DataField = "WarehouseShelfNo";
            this.WarehouseShelfNo_TextBox.Height = 0.125F;
            this.WarehouseShelfNo_TextBox.Left = 4.5F;
            this.WarehouseShelfNo_TextBox.MultiLine = false;
            this.WarehouseShelfNo_TextBox.Name = "WarehouseShelfNo_TextBox";
            this.WarehouseShelfNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.WarehouseShelfNo_TextBox.Text = "12345678";
            this.WarehouseShelfNo_TextBox.Top = 0.0625F;
            this.WarehouseShelfNo_TextBox.Width = 0.5F;
            // 
            // OnlineNo_TextBox
            // 
            this.OnlineNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.OnlineNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.OnlineNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.OnlineNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.OnlineNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_TextBox.DataField = "OnlineNo";
            this.OnlineNo_TextBox.Height = 0.125F;
            this.OnlineNo_TextBox.Left = 0.0625F;
            this.OnlineNo_TextBox.MultiLine = false;
            this.OnlineNo_TextBox.Name = "OnlineNo_TextBox";
            this.OnlineNo_TextBox.OutputFormat = resources.GetString("OnlineNo_TextBox.OutputFormat");
            this.OnlineNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.OnlineNo_TextBox.Text = "999999";
            this.OnlineNo_TextBox.Top = 0.0625F;
            this.OnlineNo_TextBox.Width = 0.375F;
            // 
            // ReceiveDate_TextBox
            // 
            this.ReceiveDate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_TextBox.DataField = "ReceiveDate";
            this.ReceiveDate_TextBox.Height = 0.125F;
            this.ReceiveDate_TextBox.Left = 0.0625F;
            this.ReceiveDate_TextBox.MultiLine = false;
            this.ReceiveDate_TextBox.Name = "ReceiveDate_TextBox";
            this.ReceiveDate_TextBox.OutputFormat = resources.GetString("ReceiveDate_TextBox.OutputFormat");
            this.ReceiveDate_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.ReceiveDate_TextBox.Text = "99/99/99";
            this.ReceiveDate_TextBox.Top = 0.25F;
            this.ReceiveDate_TextBox.Width = 0.5F;
            // 
            // OnlineRowNo_TextBox
            // 
            this.OnlineRowNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.OnlineRowNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.OnlineRowNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.OnlineRowNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.OnlineRowNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_TextBox.DataField = "OnlineRowNo";
            this.OnlineRowNo_TextBox.Height = 0.125F;
            this.OnlineRowNo_TextBox.Left = 0.625F;
            this.OnlineRowNo_TextBox.MultiLine = false;
            this.OnlineRowNo_TextBox.Name = "OnlineRowNo_TextBox";
            this.OnlineRowNo_TextBox.OutputFormat = resources.GetString("OnlineRowNo_TextBox.OutputFormat");
            this.OnlineRowNo_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.OnlineRowNo_TextBox.Text = "ZZZ9";
            this.OnlineRowNo_TextBox.Top = 0.0625F;
            this.OnlineRowNo_TextBox.Width = 0.3125F;
            // 
            // UoeRemark1_TextBox
            // 
            this.UoeRemark1_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark1_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark1_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark1_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark1_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_TextBox.DataField = "UoeRemark1";
            this.UoeRemark1_TextBox.Height = 0.125F;
            this.UoeRemark1_TextBox.Left = 0.6875F;
            this.UoeRemark1_TextBox.MultiLine = false;
            this.UoeRemark1_TextBox.Name = "UoeRemark1_TextBox";
            this.UoeRemark1_TextBox.OutputFormat = resources.GetString("UoeRemark1_TextBox.OutputFormat");
            this.UoeRemark1_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.UoeRemark1_TextBox.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.UoeRemark1_TextBox.Top = 0.25F;
            this.UoeRemark1_TextBox.Width = 1.1875F;
            // 
            // UoeRemark2_TextBox
            // 
            this.UoeRemark2_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark2_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark2_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark2_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark2_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_TextBox.DataField = "UoeRemark2";
            this.UoeRemark2_TextBox.Height = 0.125F;
            this.UoeRemark2_TextBox.Left = 1.9375F;
            this.UoeRemark2_TextBox.MultiLine = false;
            this.UoeRemark2_TextBox.Name = "UoeRemark2_TextBox";
            this.UoeRemark2_TextBox.OutputFormat = resources.GetString("UoeRemark2_TextBox.OutputFormat");
            this.UoeRemark2_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.UoeRemark2_TextBox.Text = "XXXXXXXXXX";
            this.UoeRemark2_TextBox.Top = 0.25F;
            this.UoeRemark2_TextBox.Width = 0.625F;
            // 
            // SystemDivName_TextBox
            // 
            this.SystemDivName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_TextBox.DataField = "SystemDivName";
            this.SystemDivName_TextBox.Height = 0.125F;
            this.SystemDivName_TextBox.Left = 1.9375F;
            this.SystemDivName_TextBox.MultiLine = false;
            this.SystemDivName_TextBox.Name = "SystemDivName_TextBox";
            this.SystemDivName_TextBox.OutputFormat = resources.GetString("SystemDivName_TextBox.OutputFormat");
            this.SystemDivName_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.SystemDivName_TextBox.Text = "XXXXXXXX";
            this.SystemDivName_TextBox.Top = 0.0625F;
            this.SystemDivName_TextBox.Width = 0.625F;
            // 
            // AnswerPartsNo_TextBox
            // 
            this.AnswerPartsNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_TextBox.DataField = "AnswerPartsNo";
            this.AnswerPartsNo_TextBox.Height = 0.125F;
            this.AnswerPartsNo_TextBox.Left = 2.625F;
            this.AnswerPartsNo_TextBox.MultiLine = false;
            this.AnswerPartsNo_TextBox.Name = "AnswerPartsNo_TextBox";
            this.AnswerPartsNo_TextBox.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.AnswerPartsNo_TextBox.Text = "123456789012345678901234";
            this.AnswerPartsNo_TextBox.Top = 0.25F;
            this.AnswerPartsNo_TextBox.Width = 1.375F;
            // 
            // AnswerPartsName_TextBox
            // 
            this.AnswerPartsName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerPartsName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerPartsName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerPartsName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerPartsName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_TextBox.DataField = "AnswerPartsName";
            this.AnswerPartsName_TextBox.Height = 0.125F;
            this.AnswerPartsName_TextBox.Left = 4.0625F;
            this.AnswerPartsName_TextBox.MultiLine = false;
            this.AnswerPartsName_TextBox.Name = "AnswerPartsName_TextBox";
            this.AnswerPartsName_TextBox.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.AnswerPartsName_TextBox.Text = "あいうえおかきくけこ";
            this.AnswerPartsName_TextBox.Top = 0.25F;
            this.AnswerPartsName_TextBox.Width = 1.1875F;
            // 
            // WarehouseCode_TextBox
            // 
            this.WarehouseCode_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_TextBox.DataField = "WarehouseCode";
            this.WarehouseCode_TextBox.Height = 0.125F;
            this.WarehouseCode_TextBox.Left = 4.0625F;
            this.WarehouseCode_TextBox.MultiLine = false;
            this.WarehouseCode_TextBox.Name = "WarehouseCode_TextBox";
            this.WarehouseCode_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.WarehouseCode_TextBox.Text = "1234";
            this.WarehouseCode_TextBox.Top = 0.0625F;
            this.WarehouseCode_TextBox.Width = 0.25F;
            // 
            // ListPrice_TextBox
            // 
            this.ListPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_TextBox.DataField = "ListPrice";
            this.ListPrice_TextBox.Height = 0.125F;
            this.ListPrice_TextBox.Left = 5.25F;
            this.ListPrice_TextBox.MultiLine = false;
            this.ListPrice_TextBox.Name = "ListPrice_TextBox";
            this.ListPrice_TextBox.OutputFormat = resources.GetString("ListPrice_TextBox.OutputFormat");
            this.ListPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.ListPrice_TextBox.Text = "1,234,567";
            this.ListPrice_TextBox.Top = 0.0625F;
            this.ListPrice_TextBox.Width = 0.5625F;
            // 
            // AnswerListPrice_TextBox
            // 
            this.AnswerListPrice_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerListPrice_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerListPrice_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerListPrice_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerListPrice_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_TextBox.DataField = "AnswerListPrice";
            this.AnswerListPrice_TextBox.Height = 0.125F;
            this.AnswerListPrice_TextBox.Left = 5.25F;
            this.AnswerListPrice_TextBox.MultiLine = false;
            this.AnswerListPrice_TextBox.Name = "AnswerListPrice_TextBox";
            this.AnswerListPrice_TextBox.OutputFormat = resources.GetString("AnswerListPrice_TextBox.OutputFormat");
            this.AnswerListPrice_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.AnswerListPrice_TextBox.Text = "1,234,567";
            this.AnswerListPrice_TextBox.Top = 0.25F;
            this.AnswerListPrice_TextBox.Width = 0.5625F;
            // 
            // AnswerSalesUnitCost_TextBox
            // 
            this.AnswerSalesUnitCost_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_TextBox.DataField = "AnswerSalesUnitCost";
            this.AnswerSalesUnitCost_TextBox.Height = 0.125F;
            this.AnswerSalesUnitCost_TextBox.Left = 5.8125F;
            this.AnswerSalesUnitCost_TextBox.MultiLine = false;
            this.AnswerSalesUnitCost_TextBox.Name = "AnswerSalesUnitCost_TextBox";
            this.AnswerSalesUnitCost_TextBox.OutputFormat = resources.GetString("AnswerSalesUnitCost_TextBox.OutputFormat");
            this.AnswerSalesUnitCost_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.AnswerSalesUnitCost_TextBox.Text = "1,234,567.89";
            this.AnswerSalesUnitCost_TextBox.Top = 0.25F;
            this.AnswerSalesUnitCost_TextBox.Width = 0.75F;
            // 
            // AcceptAnOrderCnt_TextBox
            // 
            this.AcceptAnOrderCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_TextBox.DataField = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt_TextBox.Height = 0.125F;
            this.AcceptAnOrderCnt_TextBox.Left = 6.3125F;
            this.AcceptAnOrderCnt_TextBox.MultiLine = false;
            this.AcceptAnOrderCnt_TextBox.Name = "AcceptAnOrderCnt_TextBox";
            this.AcceptAnOrderCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.AcceptAnOrderCnt_TextBox.Text = "ZZ9";
            this.AcceptAnOrderCnt_TextBox.Top = 0.0625F;
            this.AcceptAnOrderCnt_TextBox.Width = 0.25F;
            // 
            // UOESectionSlipNo_TextBox
            // 
            this.UOESectionSlipNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_TextBox.DataField = "UOESectionSlipNo";
            this.UOESectionSlipNo_TextBox.Height = 0.125F;
            this.UOESectionSlipNo_TextBox.Left = 6.5625F;
            this.UOESectionSlipNo_TextBox.MultiLine = false;
            this.UOESectionSlipNo_TextBox.Name = "UOESectionSlipNo_TextBox";
            this.UOESectionSlipNo_TextBox.OutputFormat = resources.GetString("UOESectionSlipNo_TextBox.OutputFormat");
            this.UOESectionSlipNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.UOESectionSlipNo_TextBox.Text = "9999999";
            this.UOESectionSlipNo_TextBox.Top = 0.25F;
            this.UOESectionSlipNo_TextBox.Width = 0.5F;
            // 
            // UOESectOutGoodsCnt_TextBox
            // 
            this.UOESectOutGoodsCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_TextBox.DataField = "UOESectOutGoodsCnt";
            this.UOESectOutGoodsCnt_TextBox.Height = 0.125F;
            this.UOESectOutGoodsCnt_TextBox.Left = 6.8125F;
            this.UOESectOutGoodsCnt_TextBox.MultiLine = false;
            this.UOESectOutGoodsCnt_TextBox.Name = "UOESectOutGoodsCnt_TextBox";
            this.UOESectOutGoodsCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.UOESectOutGoodsCnt_TextBox.Text = "ZZ9";
            this.UOESectOutGoodsCnt_TextBox.Top = 0.0625F;
            this.UOESectOutGoodsCnt_TextBox.Width = 0.25F;
            // 
            // BOShipmentCnt1_TextBox
            // 
            this.BOShipmentCnt1_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_TextBox.DataField = "BOShipmentCnt1";
            this.BOShipmentCnt1_TextBox.Height = 0.125F;
            this.BOShipmentCnt1_TextBox.Left = 7.3125F;
            this.BOShipmentCnt1_TextBox.MultiLine = false;
            this.BOShipmentCnt1_TextBox.Name = "BOShipmentCnt1_TextBox";
            this.BOShipmentCnt1_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.BOShipmentCnt1_TextBox.Text = "ZZ9";
            this.BOShipmentCnt1_TextBox.Top = 0.0625F;
            this.BOShipmentCnt1_TextBox.Width = 0.25F;
            // 
            // BOSlipNo1_TextBox
            // 
            this.BOSlipNo1_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo1_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo1_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo1_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo1_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_TextBox.DataField = "BOSlipNo1";
            this.BOSlipNo1_TextBox.Height = 0.125F;
            this.BOSlipNo1_TextBox.Left = 7.0625F;
            this.BOSlipNo1_TextBox.MultiLine = false;
            this.BOSlipNo1_TextBox.Name = "BOSlipNo1_TextBox";
            this.BOSlipNo1_TextBox.OutputFormat = resources.GetString("BOSlipNo1_TextBox.OutputFormat");
            this.BOSlipNo1_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.BOSlipNo1_TextBox.Text = "9999999";
            this.BOSlipNo1_TextBox.Top = 0.25F;
            this.BOSlipNo1_TextBox.Width = 0.5F;
            // 
            // BOShipmentCnt2_TextBox
            // 
            this.BOShipmentCnt2_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_TextBox.DataField = "BOShipmentCnt2";
            this.BOShipmentCnt2_TextBox.Height = 0.125F;
            this.BOShipmentCnt2_TextBox.Left = 7.8125F;
            this.BOShipmentCnt2_TextBox.MultiLine = false;
            this.BOShipmentCnt2_TextBox.Name = "BOShipmentCnt2_TextBox";
            this.BOShipmentCnt2_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.BOShipmentCnt2_TextBox.Text = "ZZ9";
            this.BOShipmentCnt2_TextBox.Top = 0.0625F;
            this.BOShipmentCnt2_TextBox.Width = 0.25F;
            // 
            // BOSlipNo2_TextBox
            // 
            this.BOSlipNo2_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo2_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo2_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo2_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo2_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_TextBox.DataField = "BOSlipNo2";
            this.BOSlipNo2_TextBox.Height = 0.125F;
            this.BOSlipNo2_TextBox.Left = 7.5625F;
            this.BOSlipNo2_TextBox.MultiLine = false;
            this.BOSlipNo2_TextBox.Name = "BOSlipNo2_TextBox";
            this.BOSlipNo2_TextBox.OutputFormat = resources.GetString("BOSlipNo2_TextBox.OutputFormat");
            this.BOSlipNo2_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.BOSlipNo2_TextBox.Text = "9999999";
            this.BOSlipNo2_TextBox.Top = 0.25F;
            this.BOSlipNo2_TextBox.Width = 0.5F;
            // 
            // BOShipmentCnt3_TextBox
            // 
            this.BOShipmentCnt3_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_TextBox.DataField = "BOShipmentCnt3";
            this.BOShipmentCnt3_TextBox.Height = 0.125F;
            this.BOShipmentCnt3_TextBox.Left = 8.3125F;
            this.BOShipmentCnt3_TextBox.MultiLine = false;
            this.BOShipmentCnt3_TextBox.Name = "BOShipmentCnt3_TextBox";
            this.BOShipmentCnt3_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.BOShipmentCnt3_TextBox.Text = "ZZ9";
            this.BOShipmentCnt3_TextBox.Top = 0.0625F;
            this.BOShipmentCnt3_TextBox.Width = 0.25F;
            // 
            // BOSlipNo3_TextBox
            // 
            this.BOSlipNo3_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo3_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo3_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo3_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo3_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_TextBox.DataField = "BOSlipNo3";
            this.BOSlipNo3_TextBox.Height = 0.125F;
            this.BOSlipNo3_TextBox.Left = 8.0625F;
            this.BOSlipNo3_TextBox.MultiLine = false;
            this.BOSlipNo3_TextBox.Name = "BOSlipNo3_TextBox";
            this.BOSlipNo3_TextBox.OutputFormat = resources.GetString("BOSlipNo3_TextBox.OutputFormat");
            this.BOSlipNo3_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.BOSlipNo3_TextBox.Text = "9999999";
            this.BOSlipNo3_TextBox.Top = 0.25F;
            this.BOSlipNo3_TextBox.Width = 0.5F;
            // 
            // MakerFollowCnt_TextBox
            // 
            this.MakerFollowCnt_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_TextBox.DataField = "MakerFollowCnt";
            this.MakerFollowCnt_TextBox.Height = 0.125F;
            this.MakerFollowCnt_TextBox.Left = 8.6875F;
            this.MakerFollowCnt_TextBox.MultiLine = false;
            this.MakerFollowCnt_TextBox.Name = "MakerFollowCnt_TextBox";
            this.MakerFollowCnt_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.MakerFollowCnt_TextBox.Text = "9999";
            this.MakerFollowCnt_TextBox.Top = 0.0625F;
            this.MakerFollowCnt_TextBox.Width = 0.25F;
            // 
            // BOManagementNo_TextBox
            // 
            this.BOManagementNo_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.BOManagementNo_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.BOManagementNo_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.BOManagementNo_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.BOManagementNo_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_TextBox.DataField = "BOManagementNo";
            this.BOManagementNo_TextBox.Height = 0.125F;
            this.BOManagementNo_TextBox.Left = 8.9375F;
            this.BOManagementNo_TextBox.MultiLine = false;
            this.BOManagementNo_TextBox.Name = "BOManagementNo_TextBox";
            this.BOManagementNo_TextBox.OutputFormat = resources.GetString("BOManagementNo_TextBox.OutputFormat");
            this.BOManagementNo_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.BOManagementNo_TextBox.Text = "999999";
            this.BOManagementNo_TextBox.Top = 0.25F;
            this.BOManagementNo_TextBox.Width = 0.4375F;
            // 
            // EOAlwcCount_TextBox
            // 
            this.EOAlwcCount_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.EOAlwcCount_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.EOAlwcCount_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.EOAlwcCount_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.EOAlwcCount_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_TextBox.DataField = "EOAlwcCount";
            this.EOAlwcCount_TextBox.Height = 0.125F;
            this.EOAlwcCount_TextBox.Left = 9.3125F;
            this.EOAlwcCount_TextBox.MultiLine = false;
            this.EOAlwcCount_TextBox.Name = "EOAlwcCount_TextBox";
            this.EOAlwcCount_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; ";
            this.EOAlwcCount_TextBox.Text = "ZZ9";
            this.EOAlwcCount_TextBox.Top = 0.0625F;
            this.EOAlwcCount_TextBox.Width = 0.25F;
            // 
            // CheckCnts_TextBox
            // 
            this.CheckCnts_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckCnts_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckCnts_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.CheckCnts_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.CheckCnts_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_TextBox.DataField = "CheckCntsNm";
            this.CheckCnts_TextBox.Height = 0.125F;
            this.CheckCnts_TextBox.Left = 9.6875F;
            this.CheckCnts_TextBox.MultiLine = false;
            this.CheckCnts_TextBox.Name = "CheckCnts_TextBox";
            this.CheckCnts_TextBox.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.CheckCnts_TextBox.Text = "あいうえおかきくけこ";
            this.CheckCnts_TextBox.Top = 0.25F;
            this.CheckCnts_TextBox.Width = 1.1875F;
            // 
            // UOESupplierName_TextBox
            // 
            this.UOESupplierName_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierName_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierName_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierName_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierName_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_TextBox.DataField = "UOESupplierName";
            this.UOESupplierName_TextBox.Height = 0.125F;
            this.UOESupplierName_TextBox.Left = 9.6875F;
            this.UOESupplierName_TextBox.MultiLine = false;
            this.UOESupplierName_TextBox.Name = "UOESupplierName_TextBox";
            this.UOESupplierName_TextBox.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.UOESupplierName_TextBox.Text = "あいうえおかきくけこ";
            this.UOESupplierName_TextBox.Top = 0.0625F;
            this.UOESupplierName_TextBox.Width = 1.1875F;
            // 
            // SectionGuideNm_TextBox
            // 
            this.SectionGuideNm_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideNm_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideNm_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideNm_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideNm_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_TextBox.DataField = "SectionGuideNm";
            this.SectionGuideNm_TextBox.Height = 0.125F;
            this.SectionGuideNm_TextBox.Left = 1.125F;
            this.SectionGuideNm_TextBox.MultiLine = false;
            this.SectionGuideNm_TextBox.Name = "SectionGuideNm_TextBox";
            this.SectionGuideNm_TextBox.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; ";
            this.SectionGuideNm_TextBox.Text = "あいうえおかきくけこ";
            this.SectionGuideNm_TextBox.Top = 0.0625F;
            this.SectionGuideNm_TextBox.Visible = false;
            this.SectionGuideNm_TextBox.Width = 1.1875F;
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
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.1875F;
            this.line5.Width = 10.875F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.875F;
            this.line5.Y1 = 0.1875F;
            this.line5.Y2 = 0.1875F;
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
            this.line6.LineWeight = 3F;
            this.line6.Name = "line6";
            this.line6.Top = 0.375F;
            this.line6.Width = 10.875F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.875F;
            this.line6.Y1 = 0.375F;
            this.line6.Y2 = 0.375F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PrintDate_Title,
            this.PrintDate,
            this.PrintPage_Title,
            this.PrintPage,
            this.PrintTime,
            this.FormName,
            this.Line1});
            this.PageHeader.Height = 0.28125F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // PrintDate_Title
            // 
            this.PrintDate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate_Title.Height = 0.15625F;
            this.PrintDate_Title.HyperLink = "";
            this.PrintDate_Title.Left = 7.9375F;
            this.PrintDate_Title.MultiLine = false;
            this.PrintDate_Title.Name = "PrintDate_Title";
            this.PrintDate_Title.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate_Title.Text = "作成日付：";
            this.PrintDate_Title.Top = 0.0625F;
            this.PrintDate_Title.Width = 0.625F;
            // 
            // PrintDate
            // 
            this.PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate.CanShrink = true;
            this.PrintDate.Height = 0.15625F;
            this.PrintDate.Left = 8.5F;
            this.PrintDate.MultiLine = false;
            this.PrintDate.Name = "PrintDate";
            this.PrintDate.OutputFormat = resources.GetString("PrintDate.OutputFormat");
            this.PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintDate.Text = "平成17年11月 5日";
            this.PrintDate.Top = 0.0625F;
            this.PrintDate.Width = 0.9375F;
            // 
            // PrintPage_Title
            // 
            this.PrintPage_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PrintPage_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage_Title.Height = 0.15625F;
            this.PrintPage_Title.HyperLink = "";
            this.PrintPage_Title.Left = 9.9375F;
            this.PrintPage_Title.MultiLine = false;
            this.PrintPage_Title.Name = "PrintPage_Title";
            this.PrintPage_Title.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PrintPage_Title.Text = "ページ：";
            this.PrintPage_Title.Top = 0.0625F;
            this.PrintPage_Title.Width = 0.5F;
            // 
            // PrintPage
            // 
            this.PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintPage.CanShrink = true;
            this.PrintPage.Height = 0.15625F;
            this.PrintPage.Left = 10.4375F;
            this.PrintPage.MultiLine = false;
            this.PrintPage.Name = "PrintPage";
            this.PrintPage.OutputFormat = resources.GetString("PrintPage.OutputFormat");
            this.PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertical-" +
                "align: top; ";
            this.PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PrintPage.Text = "123";
            this.PrintPage.Top = 0.0625F;
            this.PrintPage.Width = 0.28125F;
            // 
            // PrintTime
            // 
            this.PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime.Height = 0.125F;
            this.PrintTime.Left = 9.4375F;
            this.PrintTime.Name = "PrintTime";
            this.PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.PrintTime.Text = "11時20分";
            this.PrintTime.Top = 0.0625F;
            this.PrintTime.Width = 0.5F;
            // 
            // FormName
            // 
            this.FormName.Border.BottomColor = System.Drawing.Color.Black;
            this.FormName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Border.LeftColor = System.Drawing.Color.Black;
            this.FormName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Border.RightColor = System.Drawing.Color.Black;
            this.FormName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Border.TopColor = System.Drawing.Color.Black;
            this.FormName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FormName.Height = 0.21875F;
            this.FormName.HyperLink = "";
            this.FormName.Left = 0.21875F;
            this.FormName.MultiLine = false;
            this.FormName.Name = "FormName";
            this.FormName.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.FormName.Text = "発行確認一覧表";
            this.FormName.Top = 0F;
            this.FormName.Width = 1.795F;
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
            this.Line1.Width = 10.875F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.875F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2388889F;
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
            this.SectionGuideNm_Title,
            this.SectionGuideNmCond_TextBox,
            this.line2,
            this.ReceiveDateCond_Title,
            this.St_ReceiveDate_TextBox,
            this.label1,
            this.Ed_ReceiveDate_TextBox,
            this.SystemDivNameHeader_Title,
            this.SystemDivNameHeader_TextBox,
            this.PrintCond_Title,
            this.PrintCond_TextBox});
            this.ExtraHeader.DataField = "SectionCode";
            this.ExtraHeader.Height = 0.4270833F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // SectionGuideNm_Title
            // 
            this.SectionGuideNm_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideNm_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideNm_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideNm_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideNm_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNm_Title.Height = 0.1875F;
            this.SectionGuideNm_Title.HyperLink = "";
            this.SectionGuideNm_Title.Left = 0.1875F;
            this.SectionGuideNm_Title.MultiLine = false;
            this.SectionGuideNm_Title.Name = "SectionGuideNm_Title";
            this.SectionGuideNm_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.SectionGuideNm_Title.Text = "拠点：";
            this.SectionGuideNm_Title.Top = 0F;
            this.SectionGuideNm_Title.Width = 0.375F;
            // 
            // SectionGuideNmCond_TextBox
            // 
            this.SectionGuideNmCond_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideNmCond_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNmCond_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideNmCond_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNmCond_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideNmCond_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNmCond_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideNmCond_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideNmCond_TextBox.Height = 0.1875F;
            this.SectionGuideNmCond_TextBox.Left = 0.6875F;
            this.SectionGuideNmCond_TextBox.MultiLine = false;
            this.SectionGuideNmCond_TextBox.Name = "SectionGuideNmCond_TextBox";
            this.SectionGuideNmCond_TextBox.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: bottom; ";
            this.SectionGuideNmCond_TextBox.Text = "あいうえおかきくけこ";
            this.SectionGuideNmCond_TextBox.Top = 0F;
            this.SectionGuideNmCond_TextBox.Width = 1.1875F;
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
            this.line2.LineWeight = 3F;
            this.line2.Name = "line2";
            this.line2.Top = 0.375F;
            this.line2.Width = 10.875F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.875F;
            this.line2.Y1 = 0.375F;
            this.line2.Y2 = 0.375F;
            // 
            // ReceiveDateCond_Title
            // 
            this.ReceiveDateCond_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDateCond_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDateCond_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDateCond_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDateCond_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDateCond_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDateCond_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDateCond_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDateCond_Title.Height = 0.1875F;
            this.ReceiveDateCond_Title.HyperLink = "";
            this.ReceiveDateCond_Title.Left = 0.1875F;
            this.ReceiveDateCond_Title.MultiLine = false;
            this.ReceiveDateCond_Title.Name = "ReceiveDateCond_Title";
            this.ReceiveDateCond_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.ReceiveDateCond_Title.Text = "発注日:";
            this.ReceiveDateCond_Title.Top = 0.1875F;
            this.ReceiveDateCond_Title.Width = 0.4375F;
            // 
            // St_ReceiveDate_TextBox
            // 
            this.St_ReceiveDate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.St_ReceiveDate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.St_ReceiveDate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.St_ReceiveDate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.St_ReceiveDate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.St_ReceiveDate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.St_ReceiveDate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.St_ReceiveDate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.St_ReceiveDate_TextBox.DataField = "ReceiveDate";
            this.St_ReceiveDate_TextBox.Height = 0.1875F;
            this.St_ReceiveDate_TextBox.Left = 0.6875F;
            this.St_ReceiveDate_TextBox.MultiLine = false;
            this.St_ReceiveDate_TextBox.Name = "St_ReceiveDate_TextBox";
            this.St_ReceiveDate_TextBox.OutputFormat = resources.GetString("St_ReceiveDate_TextBox.OutputFormat");
            this.St_ReceiveDate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8.25pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: bottom; ";
            this.St_ReceiveDate_TextBox.Text = "9999/99/99";
            this.St_ReceiveDate_TextBox.Top = 0.1875F;
            this.St_ReceiveDate_TextBox.Width = 0.625F;
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
            this.label1.Left = 1.375F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: left; font-weight: normal; font-size: 8.25pt; vertical-align: bottom;" +
                " ";
            this.label1.Text = "～";
            this.label1.Top = 0.1875F;
            this.label1.Width = 0.125F;
            // 
            // Ed_ReceiveDate_TextBox
            // 
            this.Ed_ReceiveDate_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.Ed_ReceiveDate_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ed_ReceiveDate_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.Ed_ReceiveDate_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ed_ReceiveDate_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.Ed_ReceiveDate_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ed_ReceiveDate_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.Ed_ReceiveDate_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Ed_ReceiveDate_TextBox.DataField = "ReceiveDate";
            this.Ed_ReceiveDate_TextBox.Height = 0.1875F;
            this.Ed_ReceiveDate_TextBox.Left = 1.5625F;
            this.Ed_ReceiveDate_TextBox.MultiLine = false;
            this.Ed_ReceiveDate_TextBox.Name = "Ed_ReceiveDate_TextBox";
            this.Ed_ReceiveDate_TextBox.OutputFormat = resources.GetString("Ed_ReceiveDate_TextBox.OutputFormat");
            this.Ed_ReceiveDate_TextBox.Style = "ddo-char-set: 128; text-align: right; font-size: 8.25pt; font-family: ＭＳ ゴシック; ve" +
                "rtical-align: bottom; ";
            this.Ed_ReceiveDate_TextBox.Text = "9999/99/99";
            this.Ed_ReceiveDate_TextBox.Top = 0.1875F;
            this.Ed_ReceiveDate_TextBox.Width = 0.625F;
            // 
            // SystemDivNameHeader_Title
            // 
            this.SystemDivNameHeader_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_Title.Height = 0.1875F;
            this.SystemDivNameHeader_Title.HyperLink = "";
            this.SystemDivNameHeader_Title.Left = 2.3125F;
            this.SystemDivNameHeader_Title.MultiLine = false;
            this.SystemDivNameHeader_Title.Name = "SystemDivNameHeader_Title";
            this.SystemDivNameHeader_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.SystemDivNameHeader_Title.Text = "システム区分:";
            this.SystemDivNameHeader_Title.Top = 0.1875F;
            this.SystemDivNameHeader_Title.Width = 0.875F;
            // 
            // SystemDivNameHeader_TextBox
            // 
            this.SystemDivNameHeader_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivNameHeader_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivNameHeader_TextBox.DataField = "SystemDivName";
            this.SystemDivNameHeader_TextBox.Height = 0.1875F;
            this.SystemDivNameHeader_TextBox.Left = 3.125F;
            this.SystemDivNameHeader_TextBox.MultiLine = false;
            this.SystemDivNameHeader_TextBox.Name = "SystemDivNameHeader_TextBox";
            this.SystemDivNameHeader_TextBox.OutputFormat = resources.GetString("SystemDivNameHeader_TextBox.OutputFormat");
            this.SystemDivNameHeader_TextBox.Style = "ddo-char-set: 128; text-align: left; font-size: 8.25pt; font-family: ＭＳ 明朝; verti" +
                "cal-align: bottom; ";
            this.SystemDivNameHeader_TextBox.Text = "XXXXXXXX";
            this.SystemDivNameHeader_TextBox.Top = 0.1875F;
            this.SystemDivNameHeader_TextBox.Width = 0.625F;
            // 
            // PrintCond_Title
            // 
            this.PrintCond_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintCond_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintCond_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_Title.Border.RightColor = System.Drawing.Color.Black;
            this.PrintCond_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_Title.Border.TopColor = System.Drawing.Color.Black;
            this.PrintCond_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_Title.Height = 0.1875F;
            this.PrintCond_Title.HyperLink = "";
            this.PrintCond_Title.Left = 3.8125F;
            this.PrintCond_Title.MultiLine = false;
            this.PrintCond_Title.Name = "PrintCond_Title";
            this.PrintCond_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.PrintCond_Title.Text = "印刷条件:";
            this.PrintCond_Title.Top = 0.1875F;
            this.PrintCond_Title.Width = 0.5625F;
            // 
            // PrintCond_TextBox
            // 
            this.PrintCond_TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintCond_TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintCond_TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.PrintCond_TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.PrintCond_TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintCond_TextBox.Height = 0.1875F;
            this.PrintCond_TextBox.Left = 4.4375F;
            this.PrintCond_TextBox.MultiLine = false;
            this.PrintCond_TextBox.Name = "PrintCond_TextBox";
            this.PrintCond_TextBox.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: bottom; ";
            this.PrintCond_TextBox.Text = "あいうえおかきくけこ";
            this.PrintCond_TextBox.Top = 0.1875F;
            this.PrintCond_TextBox.Width = 1.1875F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.UOESectionSlipNo_Title,
            this.GoodsNo_Title,
            this.OnlineNo_Title,
            this.AcceptAnOrderCnt_Title,
            this.WarehouseShelfNo_Title,
            this.ListPrice_Title,
            this.ReceiveDate_Title,
            this.OnlineRowNo_Title,
            this.UoeRemark1_Title,
            this.UoeRemark2_Title,
            this.SystemDivName_Title,
            this.AnswerPartsNo_Title,
            this.WarehouseCode_Title,
            this.AnswerListPrice_Title,
            this.AnswerSalesUnitCost_Title,
            this.UOESectOutGoodsCnt_Title,
            this.BOSlipNo1_Title,
            this.BOSlipNo2_Title,
            this.BOSlipNo3_Title,
            this.BOShipmentCnt1_Title,
            this.BOShipmentCnt2_Title,
            this.BOShipmentCnt3_Title,
            this.MakerFollowCnt_Title,
            this.EOAlwcCount_Title,
            this.BOManagementNo_Title,
            this.UOESupplierName_Title,
            this.CheckCnts_Title,
            this.AnswerPartsName_Title,
            this.line3,
            this.line4});
            this.TitleHeader.Height = 0.4374999F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // UOESectionSlipNo_Title
            // 
            this.UOESectionSlipNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo_Title.Height = 0.1875F;
            this.UOESectionSlipNo_Title.HyperLink = "";
            this.UOESectionSlipNo_Title.Left = 6.5625F;
            this.UOESectionSlipNo_Title.MultiLine = false;
            this.UOESectionSlipNo_Title.Name = "UOESectionSlipNo_Title";
            this.UOESectionSlipNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.UOESectionSlipNo_Title.Text = "伝票番号";
            this.UOESectionSlipNo_Title.Top = 0.1875F;
            this.UOESectionSlipNo_Title.Width = 0.5F;
            // 
            // GoodsNo_Title
            // 
            this.GoodsNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Height = 0.1875F;
            this.GoodsNo_Title.HyperLink = "";
            this.GoodsNo_Title.Left = 2.625F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.GoodsNo_Title.Text = "発注品番";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 0.5625F;
            // 
            // OnlineNo_Title
            // 
            this.OnlineNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.OnlineNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.OnlineNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.OnlineNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.OnlineNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineNo_Title.Height = 0.1875F;
            this.OnlineNo_Title.HyperLink = "";
            this.OnlineNo_Title.Left = 0.0625F;
            this.OnlineNo_Title.MultiLine = false;
            this.OnlineNo_Title.Name = "OnlineNo_Title";
            this.OnlineNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.OnlineNo_Title.Text = "発注番号";
            this.OnlineNo_Title.Top = 0F;
            this.OnlineNo_Title.Width = 0.5F;
            // 
            // AcceptAnOrderCnt_Title
            // 
            this.AcceptAnOrderCnt_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt_Title.Height = 0.1875F;
            this.AcceptAnOrderCnt_Title.HyperLink = "";
            this.AcceptAnOrderCnt_Title.Left = 6.125F;
            this.AcceptAnOrderCnt_Title.MultiLine = false;
            this.AcceptAnOrderCnt_Title.Name = "AcceptAnOrderCnt_Title";
            this.AcceptAnOrderCnt_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.AcceptAnOrderCnt_Title.Text = "発注数";
            this.AcceptAnOrderCnt_Title.Top = 0F;
            this.AcceptAnOrderCnt_Title.Width = 0.4375F;
            // 
            // WarehouseShelfNo_Title
            // 
            this.WarehouseShelfNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseShelfNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseShelfNo_Title.Height = 0.1875F;
            this.WarehouseShelfNo_Title.HyperLink = "";
            this.WarehouseShelfNo_Title.Left = 4.5F;
            this.WarehouseShelfNo_Title.MultiLine = false;
            this.WarehouseShelfNo_Title.Name = "WarehouseShelfNo_Title";
            this.WarehouseShelfNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.WarehouseShelfNo_Title.Text = "棚番";
            this.WarehouseShelfNo_Title.Top = 0F;
            this.WarehouseShelfNo_Title.Width = 0.375F;
            // 
            // ListPrice_Title
            // 
            this.ListPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice_Title.Height = 0.1875F;
            this.ListPrice_Title.HyperLink = "";
            this.ListPrice_Title.Left = 5.3125F;
            this.ListPrice_Title.MultiLine = false;
            this.ListPrice_Title.Name = "ListPrice_Title";
            this.ListPrice_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.ListPrice_Title.Text = "発注価格";
            this.ListPrice_Title.Top = 0F;
            this.ListPrice_Title.Width = 0.5F;
            // 
            // ReceiveDate_Title
            // 
            this.ReceiveDate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate_Title.Height = 0.1875F;
            this.ReceiveDate_Title.HyperLink = "";
            this.ReceiveDate_Title.Left = 0.0625F;
            this.ReceiveDate_Title.MultiLine = false;
            this.ReceiveDate_Title.Name = "ReceiveDate_Title";
            this.ReceiveDate_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.ReceiveDate_Title.Text = "発注日";
            this.ReceiveDate_Title.Top = 0.1875F;
            this.ReceiveDate_Title.Width = 0.4375F;
            // 
            // OnlineRowNo_Title
            // 
            this.OnlineRowNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.OnlineRowNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.OnlineRowNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.OnlineRowNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.OnlineRowNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OnlineRowNo_Title.Height = 0.1875F;
            this.OnlineRowNo_Title.HyperLink = "";
            this.OnlineRowNo_Title.Left = 0.625F;
            this.OnlineRowNo_Title.MultiLine = false;
            this.OnlineRowNo_Title.Name = "OnlineRowNo_Title";
            this.OnlineRowNo_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.OnlineRowNo_Title.Text = "行";
            this.OnlineRowNo_Title.Top = 0F;
            this.OnlineRowNo_Title.Width = 0.3125F;
            // 
            // UoeRemark1_Title
            // 
            this.UoeRemark1_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark1_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark1_Title.Height = 0.1875F;
            this.UoeRemark1_Title.HyperLink = "";
            this.UoeRemark1_Title.Left = 0.6875F;
            this.UoeRemark1_Title.MultiLine = false;
            this.UoeRemark1_Title.Name = "UoeRemark1_Title";
            this.UoeRemark1_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.UoeRemark1_Title.Text = "リマーク1";
            this.UoeRemark1_Title.Top = 0.1875F;
            this.UoeRemark1_Title.Width = 0.8125F;
            // 
            // UoeRemark2_Title
            // 
            this.UoeRemark2_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UoeRemark2_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UoeRemark2_Title.Height = 0.1875F;
            this.UoeRemark2_Title.HyperLink = "";
            this.UoeRemark2_Title.Left = 1.9375F;
            this.UoeRemark2_Title.MultiLine = false;
            this.UoeRemark2_Title.Name = "UoeRemark2_Title";
            this.UoeRemark2_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.UoeRemark2_Title.Text = "リマーク2";
            this.UoeRemark2_Title.Top = 0.1875F;
            this.UoeRemark2_Title.Width = 0.75F;
            // 
            // SystemDivName_Title
            // 
            this.SystemDivName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivName_Title.Height = 0.1875F;
            this.SystemDivName_Title.HyperLink = "";
            this.SystemDivName_Title.Left = 1.9375F;
            this.SystemDivName_Title.MultiLine = false;
            this.SystemDivName_Title.Name = "SystemDivName_Title";
            this.SystemDivName_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.SystemDivName_Title.Text = "システム区分";
            this.SystemDivName_Title.Top = 0F;
            this.SystemDivName_Title.Width = 0.75F;
            // 
            // AnswerPartsNo_Title
            // 
            this.AnswerPartsNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerPartsNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsNo_Title.Height = 0.1875F;
            this.AnswerPartsNo_Title.HyperLink = "";
            this.AnswerPartsNo_Title.Left = 2.625F;
            this.AnswerPartsNo_Title.MultiLine = false;
            this.AnswerPartsNo_Title.Name = "AnswerPartsNo_Title";
            this.AnswerPartsNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.AnswerPartsNo_Title.Text = "回答品番";
            this.AnswerPartsNo_Title.Top = 0.1875F;
            this.AnswerPartsNo_Title.Width = 0.5625F;
            // 
            // WarehouseCode_Title
            // 
            this.WarehouseCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.WarehouseCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WarehouseCode_Title.Height = 0.1875F;
            this.WarehouseCode_Title.HyperLink = "";
            this.WarehouseCode_Title.Left = 4.0625F;
            this.WarehouseCode_Title.MultiLine = false;
            this.WarehouseCode_Title.Name = "WarehouseCode_Title";
            this.WarehouseCode_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.WarehouseCode_Title.Text = "倉庫";
            this.WarehouseCode_Title.Top = 0F;
            this.WarehouseCode_Title.Width = 0.375F;
            // 
            // AnswerListPrice_Title
            // 
            this.AnswerListPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Height = 0.1875F;
            this.AnswerListPrice_Title.HyperLink = "";
            this.AnswerListPrice_Title.Left = 5.3125F;
            this.AnswerListPrice_Title.MultiLine = false;
            this.AnswerListPrice_Title.Name = "AnswerListPrice_Title";
            this.AnswerListPrice_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.AnswerListPrice_Title.Text = "回答価格";
            this.AnswerListPrice_Title.Top = 0.1875F;
            this.AnswerListPrice_Title.Width = 0.5F;
            // 
            // AnswerSalesUnitCost_Title
            // 
            this.AnswerSalesUnitCost_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Height = 0.1875F;
            this.AnswerSalesUnitCost_Title.HyperLink = "";
            this.AnswerSalesUnitCost_Title.Left = 6.0625F;
            this.AnswerSalesUnitCost_Title.MultiLine = false;
            this.AnswerSalesUnitCost_Title.Name = "AnswerSalesUnitCost_Title";
            this.AnswerSalesUnitCost_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.AnswerSalesUnitCost_Title.Text = "回答原価";
            this.AnswerSalesUnitCost_Title.Top = 0.1875F;
            this.AnswerSalesUnitCost_Title.Width = 0.5F;
            // 
            // UOESectOutGoodsCnt_Title
            // 
            this.UOESectOutGoodsCnt_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt_Title.Height = 0.1875F;
            this.UOESectOutGoodsCnt_Title.HyperLink = "";
            this.UOESectOutGoodsCnt_Title.Left = 6.5625F;
            this.UOESectOutGoodsCnt_Title.MultiLine = false;
            this.UOESectOutGoodsCnt_Title.Name = "UOESectOutGoodsCnt_Title";
            this.UOESectOutGoodsCnt_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.UOESectOutGoodsCnt_Title.Text = "拠点";
            this.UOESectOutGoodsCnt_Title.Top = 0F;
            this.UOESectOutGoodsCnt_Title.Width = 0.5F;
            // 
            // BOSlipNo1_Title
            // 
            this.BOSlipNo1_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo1_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo1_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo1_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo1_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1_Title.Height = 0.1875F;
            this.BOSlipNo1_Title.HyperLink = "";
            this.BOSlipNo1_Title.Left = 7.0625F;
            this.BOSlipNo1_Title.MultiLine = false;
            this.BOSlipNo1_Title.Name = "BOSlipNo1_Title";
            this.BOSlipNo1_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOSlipNo1_Title.Text = "伝票番号";
            this.BOSlipNo1_Title.Top = 0.1875F;
            this.BOSlipNo1_Title.Width = 0.5F;
            // 
            // BOSlipNo2_Title
            // 
            this.BOSlipNo2_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo2_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo2_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo2_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo2_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2_Title.Height = 0.1875F;
            this.BOSlipNo2_Title.HyperLink = "";
            this.BOSlipNo2_Title.Left = 7.5625F;
            this.BOSlipNo2_Title.MultiLine = false;
            this.BOSlipNo2_Title.Name = "BOSlipNo2_Title";
            this.BOSlipNo2_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOSlipNo2_Title.Text = "伝票番号";
            this.BOSlipNo2_Title.Top = 0.1875F;
            this.BOSlipNo2_Title.Width = 0.5F;
            // 
            // BOSlipNo3_Title
            // 
            this.BOSlipNo3_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo3_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo3_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo3_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo3_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3_Title.Height = 0.1875F;
            this.BOSlipNo3_Title.HyperLink = "";
            this.BOSlipNo3_Title.Left = 8.0625F;
            this.BOSlipNo3_Title.MultiLine = false;
            this.BOSlipNo3_Title.Name = "BOSlipNo3_Title";
            this.BOSlipNo3_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOSlipNo3_Title.Text = "伝票番号";
            this.BOSlipNo3_Title.Top = 0.1875F;
            this.BOSlipNo3_Title.Width = 0.5F;
            // 
            // BOShipmentCnt1_Title
            // 
            this.BOShipmentCnt1_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1_Title.Height = 0.1875F;
            this.BOShipmentCnt1_Title.HyperLink = "";
            this.BOShipmentCnt1_Title.Left = 7.0625F;
            this.BOShipmentCnt1_Title.MultiLine = false;
            this.BOShipmentCnt1_Title.Name = "BOShipmentCnt1_Title";
            this.BOShipmentCnt1_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOShipmentCnt1_Title.Text = "ﾌｫﾛｰ1";
            this.BOShipmentCnt1_Title.Top = 0F;
            this.BOShipmentCnt1_Title.Width = 0.5F;
            // 
            // BOShipmentCnt2_Title
            // 
            this.BOShipmentCnt2_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2_Title.Height = 0.1875F;
            this.BOShipmentCnt2_Title.HyperLink = "";
            this.BOShipmentCnt2_Title.Left = 7.5625F;
            this.BOShipmentCnt2_Title.MultiLine = false;
            this.BOShipmentCnt2_Title.Name = "BOShipmentCnt2_Title";
            this.BOShipmentCnt2_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOShipmentCnt2_Title.Text = "ﾌｫﾛｰ2";
            this.BOShipmentCnt2_Title.Top = 0F;
            this.BOShipmentCnt2_Title.Width = 0.5F;
            // 
            // BOShipmentCnt3_Title
            // 
            this.BOShipmentCnt3_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3_Title.Height = 0.1875F;
            this.BOShipmentCnt3_Title.HyperLink = "";
            this.BOShipmentCnt3_Title.Left = 8.0625F;
            this.BOShipmentCnt3_Title.MultiLine = false;
            this.BOShipmentCnt3_Title.Name = "BOShipmentCnt3_Title";
            this.BOShipmentCnt3_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOShipmentCnt3_Title.Text = "ﾌｫﾛｰ3";
            this.BOShipmentCnt3_Title.Top = 0F;
            this.BOShipmentCnt3_Title.Width = 0.5F;
            // 
            // MakerFollowCnt_Title
            // 
            this.MakerFollowCnt_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_Title.Border.RightColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_Title.Border.TopColor = System.Drawing.Color.Black;
            this.MakerFollowCnt_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt_Title.Height = 0.1875F;
            this.MakerFollowCnt_Title.HyperLink = "";
            this.MakerFollowCnt_Title.Left = 8.6875F;
            this.MakerFollowCnt_Title.MultiLine = false;
            this.MakerFollowCnt_Title.Name = "MakerFollowCnt_Title";
            this.MakerFollowCnt_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.MakerFollowCnt_Title.Text = "ﾒｰｶｰ";
            this.MakerFollowCnt_Title.Top = 0F;
            this.MakerFollowCnt_Title.Width = 0.3125F;
            // 
            // EOAlwcCount_Title
            // 
            this.EOAlwcCount_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.EOAlwcCount_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.EOAlwcCount_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_Title.Border.RightColor = System.Drawing.Color.Black;
            this.EOAlwcCount_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_Title.Border.TopColor = System.Drawing.Color.Black;
            this.EOAlwcCount_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount_Title.Height = 0.1875F;
            this.EOAlwcCount_Title.HyperLink = "";
            this.EOAlwcCount_Title.Left = 8.9375F;
            this.EOAlwcCount_Title.MultiLine = false;
            this.EOAlwcCount_Title.Name = "EOAlwcCount_Title";
            this.EOAlwcCount_Title.Style = "text-align: right; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.EOAlwcCount_Title.Text = "EO";
            this.EOAlwcCount_Title.Top = 0F;
            this.EOAlwcCount_Title.Width = 0.625F;
            // 
            // BOManagementNo_Title
            // 
            this.BOManagementNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BOManagementNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BOManagementNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BOManagementNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BOManagementNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo_Title.Height = 0.1875F;
            this.BOManagementNo_Title.HyperLink = "";
            this.BOManagementNo_Title.Left = 8.9375F;
            this.BOManagementNo_Title.MultiLine = false;
            this.BOManagementNo_Title.Name = "BOManagementNo_Title";
            this.BOManagementNo_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.BOManagementNo_Title.Text = "EO管理番号";
            this.BOManagementNo_Title.Top = 0.1875F;
            this.BOManagementNo_Title.Width = 0.625F;
            // 
            // UOESupplierName_Title
            // 
            this.UOESupplierName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName_Title.Height = 0.1875F;
            this.UOESupplierName_Title.HyperLink = "";
            this.UOESupplierName_Title.Left = 9.6875F;
            this.UOESupplierName_Title.MultiLine = false;
            this.UOESupplierName_Title.Name = "UOESupplierName_Title";
            this.UOESupplierName_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.UOESupplierName_Title.Text = "発注先";
            this.UOESupplierName_Title.Top = 0F;
            this.UOESupplierName_Title.Width = 0.8125F;
            // 
            // CheckCnts_Title
            // 
            this.CheckCnts_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckCnts_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckCnts_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_Title.Border.RightColor = System.Drawing.Color.Black;
            this.CheckCnts_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_Title.Border.TopColor = System.Drawing.Color.Black;
            this.CheckCnts_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CheckCnts_Title.Height = 0.1875F;
            this.CheckCnts_Title.HyperLink = "";
            this.CheckCnts_Title.Left = 9.6875F;
            this.CheckCnts_Title.MultiLine = false;
            this.CheckCnts_Title.Name = "CheckCnts_Title";
            this.CheckCnts_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.CheckCnts_Title.Text = "チェック内容";
            this.CheckCnts_Title.Top = 0.1875F;
            this.CheckCnts_Title.Width = 0.8125F;
            // 
            // AnswerPartsName_Title
            // 
            this.AnswerPartsName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerPartsName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerPartsName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerPartsName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerPartsName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerPartsName_Title.Height = 0.1875F;
            this.AnswerPartsName_Title.HyperLink = "";
            this.AnswerPartsName_Title.Left = 4.0625F;
            this.AnswerPartsName_Title.MultiLine = false;
            this.AnswerPartsName_Title.Name = "AnswerPartsName_Title";
            this.AnswerPartsName_Title.Style = "text-align: left; font-weight: bold; font-size: 8pt; vertical-align: bottom; ";
            this.AnswerPartsName_Title.Text = "品名";
            this.AnswerPartsName_Title.Top = 0.1875F;
            this.AnswerPartsName_Title.Width = 0.5625F;
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
            this.line3.Top = 0.1875F;
            this.line3.Width = 10.875F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.875F;
            this.line3.Y1 = 0.1875F;
            this.line3.Y2 = 0.1875F;
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
            this.line4.LineWeight = 3F;
            this.line4.Name = "line4";
            this.line4.Top = 0.375F;
            this.line4.Width = 10.875F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.875F;
            this.line4.Y1 = 0.375F;
            this.line4.Y2 = 0.375F;
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
            // PMUOE02044P_01A4C
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
            this.PrintWidth = 11.05F;
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
            this.PageEnd += new System.EventHandler(this.PMUOE02044P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMUOE02044P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineRowNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt1_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo1_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt2_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo2_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt3_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo3_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowCnt_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOManagementNo_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EOAlwcCount_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCnts_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNm_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideNmCond_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDateCond_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.St_ReceiveDate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ed_ReceiveDate_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivNameHeader_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivNameHeader_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintCond_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintCond_TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseShelfNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnlineRowNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoeRemark2_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo2_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo3_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt1_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt2_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt3_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowCnt_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EOAlwcCount_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOManagementNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckCnts_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerPartsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        /// <summary>
        /// SectionHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : SectionHeader_Format時の処理</br>
         /// <br>Programer	: 30009 渋谷 大輔</br>
         /// <br>Date		: 2008.12.02</br>
         /// </remarks>
        private void SectionHeader_Format(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// StockAdjustSlipNoHeader_Formatイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : StockAdjustSlipNoHeader_Format時の処理</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2008.12.02</br>
        /// </remarks>
        private void StockAdjustSlipNoHeader_Format(object sender, EventArgs e)
        {
        }

        
    }
}
