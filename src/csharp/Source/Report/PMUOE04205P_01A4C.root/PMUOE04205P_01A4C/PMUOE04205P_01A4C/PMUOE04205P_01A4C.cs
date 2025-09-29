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
	/// UOE発注回答一覧表印刷フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note         : UOE発注回答一覧表のフォームクラスです。</br>
	/// <br>Programmer   : 照田 貴志</br>
	/// <br>Date         : 2008/11/10</br>
	/// <br></br>
	/// <br>UpdateNote   : 2009/01/07 照田 貴志　バグ修正、不具合対応</br>
	/// <br>             :</br>
	/// </remarks>
	public class PMUOE04205P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
        #region ■定数、変数等
        // 変数
        private int _printCount;						                // 印刷件数用カウンタ
        private int _extraCondHeadOutDiv;			                    // 抽出条件ヘッダ出力区分
        private StringCollection _extraConditions;			            // 抽出条件
        private int _pageFooterOutCode;				                    // フッター出力区分
        private StringCollection _pageFooters;				            // フッターメッセージ
        private SFCMN06002C _printInfo;						            // 印刷情報クラス
        private string _pageHeaderTitle;				                // フォームタイトル
        private UOEAnswerLedgerOrderCndtn _uoeAnswerLedgerOrderCndtn;   // 抽出条件クラス
        private string _groupSuppressItem = string.Empty;               // グループサプレス対象項目値
        private bool _disposed = false;  		                        // Disposeチェック用フラグ
        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;

        private Label Lb_UOESubstMark;
        private GroupHeader SupplierHeader;
        private GroupFooter SupplierFooter;
        private TextBox BOCode;
        private Label Lb_BOSlipNo2;
        private TextBox GoodsNo;
        private TextBox GoodsMakerCd;
        private TextBox EmployeeName;
        private TextBox UOESalesOrderRowNo;
        private TextBox CustomerSnm;
        private TextBox GoodsName;
        private TextBox SalesUnitCost;
        private TextBox AcceptAnOrderCnt;
        private TextBox BOSlipNo3;
        private Label Lb_BOManagementNo;
        private Label Lb_BOSlipNo3;
        private Label Lb_Employee;
        private Label Lb_GoodsNo;
        private Label Lb_DeliveredGoodsDiv;
        private Label Lb_ListPrice;
        private Label Lb_BOCode;
        private Label Lb_BOShipmentCnt1;
        private Label Lb_AcceptAnOrderCnt;
        private Label Lb_BOShipmentCnt2;
        private Label Lb_BOShipmentCnt3;
        private Line line10;
        private Line Line_OnMemoPrint1;
        private TextBox ReceiveTime;
        private Label Lb_ReceiveTime;
        private TextBox tb_ReportSort;
        private GroupHeader SectionHeader;
        private TextBox SectionCode;
        private GroupFooter groupFooter1;
        private TextBox SectionName;
        private TextBox UOESupplierCd;
        private TextBox UOESupplierName;
        private TextBox UOESectionSlipNo;
        private Label Lb_UOESupplier;
        private TextBox UOESectOutGoodsCnt;
        #endregion

		#region ■ Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note         : インスタンスを初期化します。</br>
		/// <br>Programmer   : 照田 貴志</br>
		/// <br>Date         : 2008/11/10</br>
		/// </remarks>
		public PMUOE04205P_01A4C()
		{
			InitializeComponent();
		}
		#endregion ■ Constructor - end

		#region ■ Dispose(override)
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
        /// <remarks>
        /// <br>Note		: サブレポートのインスタンス解放を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        protected override void Dispose(bool disposing)
		{
			if(!this._disposed)
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

					this._disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		} 
		#endregion ■ Dispose(override) - end

		#region ■IPrintActiveReportTypeList メンバ
		#region ◆ Public Property
		/// <summary> ページヘッダソート順タイトル項目　※未使用 </summary>
		public string PageHeaderSortOderTitle
		{
			set{ }
		}

		/// <summary> 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ] </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ _extraCondHeadOutDiv = value; }
		}
		
		/// <summary> 抽出条件ヘッダー項目 </summary>
		public StringCollection ExtraConditions
		{
			set{ this._extraConditions = value; }
		}

		/// <summary> フッター出力区分 </summary>
		public int PageFooterOutCode
		{
			set{ this._pageFooterOutCode = value; }
		}
		
		/// <summary> フッタ出力文 </summary>
		public StringCollection PageFooters
		{
			set{ this._pageFooters = value; }
		}

		/// <summary> 印刷条件 </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo	= value;
                this._uoeAnswerLedgerOrderCndtn = (UOEAnswerLedgerOrderCndtn)this._printInfo.jyoken;
            }
		}

		/// <summary> その他データ ※未使用 </summary>
		public ArrayList OtherDataList
		{
			set	{ }
		}

		/// <summary> 帳票タイトル </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderTitle = value;}
		}
		#endregion ◆ Public Property - end

		#region ◆ EventHandler
		/// <summary> 印刷件数カウントアップイベント </summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion ◆ EventHandler - end
        #endregion ■IPrintActiveReportTypeList メンバ - end

        #region ■IPrintActiveReportTypeCommon メンバ
        #region ◆ Public Property
        /// <summary> 背景透過設定値プロパティ　※未使用 </summary>
		public int WatermarkMode
		{
			get{ return 0; }
			set{}
		}
		#endregion ◆ Public Property
		#endregion ■IPrintActiveReportTypeCommon メンバ - end
		
        #region ■Event
        #region ▼PMUOE04205P_02A4C_ReportStart(印刷開始時)
        /// <summary>
        /// 印刷開始時　イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポートが処理を開始する前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PMUOE04205P_02A4C_ReportStart(object sender, EventArgs e)
        {
            this.SetOfReportMembersOutput();
        }
        #endregion

        #region ▼PMUOE04205P_02A4C_PageEnd(ページ終了時)
        /// <summary>
		/// ページ終了時　イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レポートが各ページの処理を完了した時に発生します。</br>
		/// <br>Programmer	: 照田 貴志</br>
		/// <br>Date		: 2008/11/10</br>
		/// </remarks>
		private void PMUOE04205P_02A4C_PageEnd(object sender, System.EventArgs eArgs)
		{
            // TODO : 前行の退避fieldをクリアする。（次回先頭行はサプレス解除する）

            // 値クリア
            this._groupSuppressItem = string.Empty;
		}
		#endregion

		#region ▼PageHeader_Format(ページヘッダーデータ連結後)
		/// <summary>
		/// ページヘッダーデータ連結後　イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 照田 貴志</br>
		/// <br>Date		: 2008/11/10</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 作成日付
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( OrderListCndtn.ct_DateFomat, DateTime.Now );
			// 作成時間
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
		}
		#endregion

		#region ▼ExtraHeader_Format(抽出条件ヘッダーデータ連結後)
		/// <summary>
		/// 抽出条件ヘッダーデータ連結後　イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントパラメータ</param>
		/// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 照田 貴志</br>
		/// <br>Date		: 2008/11/10</br>
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
				// (バインドするデータソースが同じデータであっても、一度初期化しないとうまく印刷されない為。)
				this._rptExtraHeader.DataSource = null;
			}

			// 抽出条件印字項目設定
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion

        #region ▼SupplierHeader_Format(発注先ヘッダーデータ連結後)
        /// <summary>
        /// 発注先ヘッダーデータ連結後
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void SupplierHeader_Format(object sender, EventArgs e)
        {
            // 発注先コードがALL0の場合、Emptyとする
            if (this.UOESupplierCd.Text == "000000")
            {
                this.UOESupplierCd.Text = string.Empty;
            }
        }
        #endregion

        #region ▼Detail_Format(明細データ連結後)
        /// <summary>
        /// 明細データ連結後
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 従業員(依頼者)コードがALL0の場合、Emptyとする
            if (this.EmployeeCode.Text == "0000")
            {
                this.EmployeeCode.Text = string.Empty;
            }

            // 得意先コードがALL0の場合、Emptyとする
            if (this.CustomerCode.Text == "00000000")
            {
                this.CustomerCode.Text = string.Empty;
            }

            // メーカーコードがALL0の場合、Emptyとする
            if (this.GoodsMakerCd.Text == "0000")
            {
                this.GoodsMakerCd.Text = string.Empty;
            }
            // --- ADD 2009/01/07 不具合対応[9518] ------------->>>>>
            // 拠点数量
            if (this.UOESectOutGoodsCnt.Text == "0")
            {
                this.UOESectOutGoodsCnt.Text = string.Empty;
            }
            // BO1数量
            if (this.BOShipmentCnt1.Text == "0")
            {
                this.BOShipmentCnt1.Text = string.Empty;
            }
            // BO2数量
            if (this.BOShipmentCnt2.Text == "0")
            {
                this.BOShipmentCnt2.Text = string.Empty;
            }
            // BO3数量
            if (this.BOShipmentCnt3.Text == "0")
            {
                this.BOShipmentCnt3.Text = string.Empty;
            }
            // メーカーフォロー数量
            if (this.MakerFollowCnt.Text == "0")
            {
                this.MakerFollowCnt.Text = string.Empty;
            }
            // EO数量
            if (this.EOAlwcCount.Text == "0")
            {
                this.EOAlwcCount.Text = string.Empty;
            }
            // --- ADD 2009/01/07 不具合対応[9518] -------------<<<<<
        }
        #endregion

        #region ▼PageFooter_Format(ページフッターデータ連結後)
        /// <summary>
        /// ページフッター連結後　イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
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
                    // (バインドするデータソースが同じデータであっても、一度初期化しないとうまく印刷されない為。)
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

		#region ▼Detail_BeforePrint(明細印字前)
		/// <summary>
		/// 明細印字前　イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションがページに描画される前に発生します。</br>
		/// <br>Programmer	: 照田 貴志</br>
		/// <br>Date		: 2008/11/10</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
			// グループサプレスの判断
			this.CheckGroupSuppression();

			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);
		}
		#endregion

		#region ▼Detail_AfterPrint(明細印字後)
		/// <summary>
		/// 明細印字後　イベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 照田 貴志</br>
		/// <br>Date		: 2008/11/10</br>
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
		#endregion ■Event - end

        #region ■Private
        #region ▼SetOfReportMembersOutput(レポート要素出力設定)
        /// <summary>
        /// レポート要素出力設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            // TODO : 明細部の印刷項目の有無、タイトル設定などを行う。

            // 件数初期化
            this._printCount = 0;

            // タイトル設定
            this.tb_ReportTitle.Text = this._pageHeaderTitle;

            // 改ページ設定
            this.SectionHeader.NewPage = NewPage.Before;
            this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;
            this.SupplierHeader.NewPage = NewPage.Before;
            this.SupplierHeader.RepeatStyle = RepeatStyle.OnPage;

            // 書式設定
            this.SectionCode.OutputFormat = "000000";           // 拠点コード
            this.UOESalesOrderNo.OutputFormat = "000000";       // 回答番号
            this.UOESalesOrderRowNo.OutputFormat = "##0";       // 回答行番号
            this.ListPrice.OutputFormat = "#,##0";              // 定価
            this.SalesUnitCost.OutputFormat = "#,##0.00";       // 仕切単価
            this.AcceptAnOrderCnt.OutputFormat = "##0";         // 発注数
            this.UOESectOutGoodsCnt.OutputFormat = "##0";       // 拠点
            this.BOShipmentCnt1.OutputFormat = "##0";           // フォロー1
            this.BOShipmentCnt2.OutputFormat = "##0";           // フォロー2
            this.BOShipmentCnt3.OutputFormat = "##0";           // フォロー3
            this.MakerFollowCnt.OutputFormat = "##0";           // メーカー
            this.EOAlwcCount.OutputFormat = "##0";              // EO

            // 非表示項目
            this.SectionHeader.Visible = false;                 // 拠点

        }
        #endregion

        #region ▼CheckGroupSuppression(グループサプレス判断)
        /// <summary>
        /// グループサプレス判断
        /// </summary>
        /// <remarks>
        /// <br>Note		: 前行の値と比較してグループサプレスを行うかどうか判断します。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void CheckGroupSuppression()
        {
            // TODO : グループサプレス処理を記述する。
            //        具体的な処理手順は、①ifで前行KEYと比較→②同じなら項目.Visible=falseとする。
            //        最後に、今回行のKEYを退避する。

            // グループサプレス対象項目の値
            StringBuilder groupSuppressItem = new StringBuilder();
            groupSuppressItem.Append(this.ReceiveDate.Value);           // 受信日
            groupSuppressItem.Append(this.ReceiveTime.Value);           // 受信時刻
            groupSuppressItem.Append(this.UOESalesOrderNo.Value);       // 回答番号
            groupSuppressItem.Append(this.EmployeeCode.Value);          // 依頼者
            groupSuppressItem.Append(this.CustomerCode.Value);          // 得意先

            // 値比較
            if (this._groupSuppressItem == groupSuppressItem.ToString())
            {
                this.ChangeGroupSuppressVisible(false);     // 非表示
            }
            else
            {
                this.ChangeGroupSuppressVisible(true);      // 表示
            }

            // 値退避
            this._groupSuppressItem = groupSuppressItem.ToString();

        }
        #endregion

        #region ▼ChangeGroupSuppressVisible(グループサプレス対象項目表示/非表示設定)
        /// <summary>
        /// グループサプレス対象項目表示/非表示設定
        /// </summary>
        /// <param name="flg"></param>
        /// <remarks>
        /// <br>Note		: グループサプレス対象項目の表示/非表示を行います。</br>
        /// <br>Programmer	: 照田 貴志</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void ChangeGroupSuppressVisible(bool flg)
        {
            this.ReceiveDate.Visible = flg;         // 受信日
            this.ReceiveTime.Visible = flg;         // 受信時刻
            this.UOESalesOrderNo.Visible = flg;     // 回答番号
            this.EmployeeCode.Visible = flg;        // 依頼者コード
            this.EmployeeName.Visible = flg;        // 依頼者名称
            this.CustomerCode.Visible = flg;        // 得意先コード
            this.CustomerSnm.Visible = flg;         // 得意先名称
        }
        #endregion
        #endregion ■Private - end

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
		private DataDynamics.ActiveReports.Label Lb_UOESalesOrderNo;
        private DataDynamics.ActiveReports.Label Lb_UOESalesOrderRowNo;
		private DataDynamics.ActiveReports.Label Lb_SourceShipment;
		private DataDynamics.ActiveReports.Label Lb_GoodsMakerCd;
		private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Label Lb_ReceiveDate;
        private DataDynamics.ActiveReports.Label Lb_Customer;
		private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_FollowDeliGoodsDiv;
		private DataDynamics.ActiveReports.Label Lb_SalesUnitCost;
        private DataDynamics.ActiveReports.Label Lb_UOESectOutGoodsCnt;
        private DataDynamics.ActiveReports.Label Lb_UOESectionSlipNo;
        private DataDynamics.ActiveReports.Label Lb_BOSlipNo1;
		private DataDynamics.ActiveReports.Label Lb_MakerFollowCnt;
		private DataDynamics.ActiveReports.Label Lb_UOERemark1;
		private DataDynamics.ActiveReports.Label Lb_MazdaUOEShipSectCd3;
		private DataDynamics.ActiveReports.Label Lb_PartsLayerCd;
        private DataDynamics.ActiveReports.Label Lb_UOERemark2;
		private DataDynamics.ActiveReports.Label Lb_EOAlwcCount;
		private DataDynamics.ActiveReports.Label Lb_LineErrorMessage;
		private DataDynamics.ActiveReports.Label Lb_MazdaUOEShipSectCd2;
        private DataDynamics.ActiveReports.Label Lb_MazdaUOEShipSectCd1;
        private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox UOESubstMark;
        private DataDynamics.ActiveReports.TextBox UOESalesOrderNo;
        private DataDynamics.ActiveReports.TextBox BOManagementNo;
		private DataDynamics.ActiveReports.TextBox BOSlipNo1;
		private DataDynamics.ActiveReports.TextBox ReceiveDate;
        private DataDynamics.ActiveReports.TextBox BOSlipNo2;
        private DataDynamics.ActiveReports.TextBox SourceShipment;
		private DataDynamics.ActiveReports.TextBox EmployeeCode;
		private DataDynamics.ActiveReports.TextBox CustomerCode;
        private DataDynamics.ActiveReports.TextBox FollowDeliGoodsDiv;
        private DataDynamics.ActiveReports.TextBox UOEDeliGoodsDiv;
        private DataDynamics.ActiveReports.TextBox ListPrice;
		private DataDynamics.ActiveReports.TextBox UOERemark2;
		private DataDynamics.ActiveReports.TextBox UOERemark1;
		private DataDynamics.ActiveReports.TextBox BOShipmentCnt1;
		private DataDynamics.ActiveReports.TextBox BOShipmentCnt3;
		private DataDynamics.ActiveReports.TextBox BOShipmentCnt2;
		private DataDynamics.ActiveReports.TextBox MakerFollowCnt;
		private DataDynamics.ActiveReports.TextBox PartsLayerCd;
		private DataDynamics.ActiveReports.TextBox LineErrorMessage;
		private DataDynamics.ActiveReports.TextBox MazdaUOEShipSectCd3;
		private DataDynamics.ActiveReports.TextBox MazdaUOEShipSectCd2;
		private DataDynamics.ActiveReports.TextBox MazdaUOEShipSectCd1;
        private DataDynamics.ActiveReports.TextBox EOAlwcCount;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE04205P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.UOEDeliGoodsDiv = new DataDynamics.ActiveReports.TextBox();
            this.BOShipmentCnt2 = new DataDynamics.ActiveReports.TextBox();
            this.BOShipmentCnt1 = new DataDynamics.ActiveReports.TextBox();
            this.UOESubstMark = new DataDynamics.ActiveReports.TextBox();
            this.UOESalesOrderNo = new DataDynamics.ActiveReports.TextBox();
            this.BOManagementNo = new DataDynamics.ActiveReports.TextBox();
            this.BOSlipNo1 = new DataDynamics.ActiveReports.TextBox();
            this.ReceiveDate = new DataDynamics.ActiveReports.TextBox();
            this.BOSlipNo2 = new DataDynamics.ActiveReports.TextBox();
            this.SourceShipment = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.FollowDeliGoodsDiv = new DataDynamics.ActiveReports.TextBox();
            this.ListPrice = new DataDynamics.ActiveReports.TextBox();
            this.UOERemark2 = new DataDynamics.ActiveReports.TextBox();
            this.UOERemark1 = new DataDynamics.ActiveReports.TextBox();
            this.PartsLayerCd = new DataDynamics.ActiveReports.TextBox();
            this.LineErrorMessage = new DataDynamics.ActiveReports.TextBox();
            this.MazdaUOEShipSectCd3 = new DataDynamics.ActiveReports.TextBox();
            this.MazdaUOEShipSectCd2 = new DataDynamics.ActiveReports.TextBox();
            this.MazdaUOEShipSectCd1 = new DataDynamics.ActiveReports.TextBox();
            this.BOCode = new DataDynamics.ActiveReports.TextBox();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.EmployeeName = new DataDynamics.ActiveReports.TextBox();
            this.UOESalesOrderRowNo = new DataDynamics.ActiveReports.TextBox();
            this.CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.AcceptAnOrderCnt = new DataDynamics.ActiveReports.TextBox();
            this.BOSlipNo3 = new DataDynamics.ActiveReports.TextBox();
            this.ReceiveTime = new DataDynamics.ActiveReports.TextBox();
            this.UOESectionSlipNo = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.EOAlwcCount = new DataDynamics.ActiveReports.TextBox();
            this.BOShipmentCnt3 = new DataDynamics.ActiveReports.TextBox();
            this.MakerFollowCnt = new DataDynamics.ActiveReports.TextBox();
            this.UOESectOutGoodsCnt = new DataDynamics.ActiveReports.TextBox();
            this.Line_OnMemoPrint1 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_ReportSort = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.Lb_ReceiveDate = new DataDynamics.ActiveReports.Label();
            this.Lb_Employee = new DataDynamics.ActiveReports.Label();
            this.Lb_Customer = new DataDynamics.ActiveReports.Label();
            this.Lb_ReceiveTime = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESalesOrderNo = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESalesOrderRowNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.Lb_UOERemark1 = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsMakerCd = new DataDynamics.ActiveReports.Label();
            this.Lb_UOERemark2 = new DataDynamics.ActiveReports.Label();
            this.Lb_DeliveredGoodsDiv = new DataDynamics.ActiveReports.Label();
            this.Lb_FollowDeliGoodsDiv = new DataDynamics.ActiveReports.Label();
            this.Lb_ListPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesUnitCost = new DataDynamics.ActiveReports.Label();
            this.Lb_BOCode = new DataDynamics.ActiveReports.Label();
            this.Lb_AcceptAnOrderCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESectionSlipNo = new DataDynamics.ActiveReports.Label();
            this.Lb_MazdaUOEShipSectCd1 = new DataDynamics.ActiveReports.Label();
            this.Lb_BOSlipNo1 = new DataDynamics.ActiveReports.Label();
            this.Lb_MazdaUOEShipSectCd2 = new DataDynamics.ActiveReports.Label();
            this.Lb_MazdaUOEShipSectCd3 = new DataDynamics.ActiveReports.Label();
            this.Lb_BOSlipNo2 = new DataDynamics.ActiveReports.Label();
            this.Lb_BOSlipNo3 = new DataDynamics.ActiveReports.Label();
            this.Lb_BOManagementNo = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESubstMark = new DataDynamics.ActiveReports.Label();
            this.Lb_PartsLayerCd = new DataDynamics.ActiveReports.Label();
            this.Lb_SourceShipment = new DataDynamics.ActiveReports.Label();
            this.Lb_LineErrorMessage = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESupplier = new DataDynamics.ActiveReports.Label();
            this.Lb_EOAlwcCount = new DataDynamics.ActiveReports.Label();
            this.Lb_BOShipmentCnt1 = new DataDynamics.ActiveReports.Label();
            this.Lb_BOShipmentCnt2 = new DataDynamics.ActiveReports.Label();
            this.Lb_BOShipmentCnt3 = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerFollowCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_UOESectOutGoodsCnt = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SupplierHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.UOESupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.UOESupplierName = new DataDynamics.ActiveReports.TextBox();
            this.SupplierFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionName = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.UOEDeliGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESubstMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOManagementNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourceShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowDeliGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOERemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOERemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsLayerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineErrorMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaUOEShipSectCd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaUOEShipSectCd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaUOEShipSectCd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderRowNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EOAlwcCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ReceiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ReceiveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESalesOrderRowNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOERemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOERemark2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DeliveredGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_FollowDeliGoodsDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcceptAnOrderCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectionSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MazdaUOEShipSectCd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOSlipNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MazdaUOEShipSectCd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MazdaUOEShipSectCd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOSlipNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOSlipNo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOManagementNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESubstMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsLayerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SourceShipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LineErrorMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_EOAlwcCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOShipmentCnt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOShipmentCnt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOShipmentCnt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerFollowCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectOutGoodsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanGrow = false;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.UOEDeliGoodsDiv,
            this.BOShipmentCnt2,
            this.BOShipmentCnt1,
            this.UOESubstMark,
            this.UOESalesOrderNo,
            this.BOManagementNo,
            this.BOSlipNo1,
            this.ReceiveDate,
            this.BOSlipNo2,
            this.SourceShipment,
            this.EmployeeCode,
            this.CustomerCode,
            this.FollowDeliGoodsDiv,
            this.ListPrice,
            this.UOERemark2,
            this.UOERemark1,
            this.PartsLayerCd,
            this.LineErrorMessage,
            this.MazdaUOEShipSectCd3,
            this.MazdaUOEShipSectCd2,
            this.MazdaUOEShipSectCd1,
            this.BOCode,
            this.GoodsNo,
            this.GoodsMakerCd,
            this.EmployeeName,
            this.UOESalesOrderRowNo,
            this.CustomerSnm,
            this.GoodsName,
            this.AcceptAnOrderCnt,
            this.BOSlipNo3,
            this.ReceiveTime,
            this.UOESectionSlipNo,
            this.SalesUnitCost,
            this.EOAlwcCount,
            this.BOShipmentCnt3,
            this.MakerFollowCnt,
            this.UOESectOutGoodsCnt,
            this.Line_OnMemoPrint1});
            this.Detail.Height = 0.4895833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // UOEDeliGoodsDiv
            // 
            this.UOEDeliGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.UOEDeliGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOEDeliGoodsDiv.DataField = "UOEDeliGoodsDiv";
            this.UOEDeliGoodsDiv.Height = 0.125F;
            this.UOEDeliGoodsDiv.Left = 4.625F;
            this.UOEDeliGoodsDiv.MultiLine = false;
            this.UOEDeliGoodsDiv.Name = "UOEDeliGoodsDiv";
            this.UOEDeliGoodsDiv.OutputFormat = resources.GetString("UOEDeliGoodsDiv.OutputFormat");
            this.UOEDeliGoodsDiv.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.UOEDeliGoodsDiv.Text = "X";
            this.UOEDeliGoodsDiv.Top = 0F;
            this.UOEDeliGoodsDiv.Width = 0.3125F;
            // 
            // BOShipmentCnt2
            // 
            this.BOShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt2.DataField = "BOShipmentCnt2";
            this.BOShipmentCnt2.Height = 0.125F;
            this.BOShipmentCnt2.Left = 7.5F;
            this.BOShipmentCnt2.MultiLine = false;
            this.BOShipmentCnt2.Name = "BOShipmentCnt2";
            this.BOShipmentCnt2.OutputFormat = resources.GetString("BOShipmentCnt2.OutputFormat");
            this.BOShipmentCnt2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BOShipmentCnt2.Text = "3XX";
            this.BOShipmentCnt2.Top = 0F;
            this.BOShipmentCnt2.Width = 0.5F;
            // 
            // BOShipmentCnt1
            // 
            this.BOShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt1.DataField = "BOShipmentCnt1";
            this.BOShipmentCnt1.Height = 0.125F;
            this.BOShipmentCnt1.Left = 6.9375F;
            this.BOShipmentCnt1.MultiLine = false;
            this.BOShipmentCnt1.Name = "BOShipmentCnt1";
            this.BOShipmentCnt1.OutputFormat = resources.GetString("BOShipmentCnt1.OutputFormat");
            this.BOShipmentCnt1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BOShipmentCnt1.Text = "3XX";
            this.BOShipmentCnt1.Top = 0F;
            this.BOShipmentCnt1.Width = 0.5F;
            // 
            // UOESubstMark
            // 
            this.UOESubstMark.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESubstMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESubstMark.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESubstMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESubstMark.Border.RightColor = System.Drawing.Color.Black;
            this.UOESubstMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESubstMark.Border.TopColor = System.Drawing.Color.Black;
            this.UOESubstMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESubstMark.DataField = "UOESubstMark";
            this.UOESubstMark.Height = 0.125F;
            this.UOESubstMark.Left = 9.75F;
            this.UOESubstMark.MultiLine = false;
            this.UOESubstMark.Name = "UOESubstMark";
            this.UOESubstMark.OutputFormat = resources.GetString("UOESubstMark.OutputFormat");
            this.UOESubstMark.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.UOESubstMark.Text = "2X";
            this.UOESubstMark.Top = 0F;
            this.UOESubstMark.Width = 0.3125F;
            // 
            // UOESalesOrderNo
            // 
            this.UOESalesOrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.DataField = "UOESalesOrderNo";
            this.UOESalesOrderNo.Height = 0.125F;
            this.UOESalesOrderNo.Left = 1.8125F;
            this.UOESalesOrderNo.MultiLine = false;
            this.UOESalesOrderNo.Name = "UOESalesOrderNo";
            this.UOESalesOrderNo.OutputFormat = resources.GetString("UOESalesOrderNo.OutputFormat");
            this.UOESalesOrderNo.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.UOESalesOrderNo.Text = "6XXXXX";
            this.UOESalesOrderNo.Top = 0F;
            this.UOESalesOrderNo.Width = 0.5F;
            // 
            // BOManagementNo
            // 
            this.BOManagementNo.Border.BottomColor = System.Drawing.Color.Black;
            this.BOManagementNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo.Border.LeftColor = System.Drawing.Color.Black;
            this.BOManagementNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo.Border.RightColor = System.Drawing.Color.Black;
            this.BOManagementNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo.Border.TopColor = System.Drawing.Color.Black;
            this.BOManagementNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOManagementNo.DataField = "BOManagementNo";
            this.BOManagementNo.Height = 0.125F;
            this.BOManagementNo.Left = 9.1875F;
            this.BOManagementNo.MultiLine = false;
            this.BOManagementNo.Name = "BOManagementNo";
            this.BOManagementNo.OutputFormat = resources.GetString("BOManagementNo.OutputFormat");
            this.BOManagementNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BOManagementNo.Text = "8XXXXXXX";
            this.BOManagementNo.Top = 0.125F;
            this.BOManagementNo.Width = 0.5F;
            // 
            // BOSlipNo1
            // 
            this.BOSlipNo1.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo1.DataField = "BOSlipNo1";
            this.BOSlipNo1.Height = 0.125F;
            this.BOSlipNo1.Left = 6.9375F;
            this.BOSlipNo1.MultiLine = false;
            this.BOSlipNo1.Name = "BOSlipNo1";
            this.BOSlipNo1.OutputFormat = resources.GetString("BOSlipNo1.OutputFormat");
            this.BOSlipNo1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BOSlipNo1.Text = "8XXXXXXX";
            this.BOSlipNo1.Top = 0.125F;
            this.BOSlipNo1.Width = 0.5F;
            // 
            // ReceiveDate
            // 
            this.ReceiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveDate.DataField = "ReceiveDate";
            this.ReceiveDate.Height = 0.125F;
            this.ReceiveDate.Left = 0.4375F;
            this.ReceiveDate.MultiLine = false;
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.OutputFormat = resources.GetString("ReceiveDate.OutputFormat");
            this.ReceiveDate.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.ReceiveDate.Text = "XXXX/XX/XX";
            this.ReceiveDate.Top = 0F;
            this.ReceiveDate.Width = 0.625F;
            // 
            // BOSlipNo2
            // 
            this.BOSlipNo2.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo2.DataField = "BOSlipNo2";
            this.BOSlipNo2.Height = 0.125F;
            this.BOSlipNo2.Left = 7.5F;
            this.BOSlipNo2.MultiLine = false;
            this.BOSlipNo2.Name = "BOSlipNo2";
            this.BOSlipNo2.OutputFormat = resources.GetString("BOSlipNo2.OutputFormat");
            this.BOSlipNo2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BOSlipNo2.Text = "8XXXXXXX";
            this.BOSlipNo2.Top = 0.125F;
            this.BOSlipNo2.Width = 0.5F;
            // 
            // SourceShipment
            // 
            this.SourceShipment.Border.BottomColor = System.Drawing.Color.Black;
            this.SourceShipment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SourceShipment.Border.LeftColor = System.Drawing.Color.Black;
            this.SourceShipment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SourceShipment.Border.RightColor = System.Drawing.Color.Black;
            this.SourceShipment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SourceShipment.Border.TopColor = System.Drawing.Color.Black;
            this.SourceShipment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SourceShipment.DataField = "SourceShipment";
            this.SourceShipment.Height = 0.125F;
            this.SourceShipment.Left = 10.125F;
            this.SourceShipment.MultiLine = false;
            this.SourceShipment.Name = "SourceShipment";
            this.SourceShipment.OutputFormat = resources.GetString("SourceShipment.OutputFormat");
            this.SourceShipment.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.SourceShipment.Text = "10XXXXXXXX";
            this.SourceShipment.Top = 0F;
            this.SourceShipment.Width = 0.625F;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.EmployeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeCode.DataField = "EmployeeCode";
            this.EmployeeCode.Height = 0.125F;
            this.EmployeeCode.Left = 0.6875F;
            this.EmployeeCode.MultiLine = false;
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.OutputFormat = resources.GetString("EmployeeCode.OutputFormat");
            this.EmployeeCode.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.EmployeeCode.Text = "4XXX";
            this.EmployeeCode.Top = 0.125F;
            this.EmployeeCode.Width = 0.25F;
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
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 0.4375F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.CustomerCode.Text = "8XXXXXXX";
            this.CustomerCode.Top = 0.25F;
            this.CustomerCode.Width = 0.5F;
            // 
            // FollowDeliGoodsDiv
            // 
            this.FollowDeliGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.FollowDeliGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FollowDeliGoodsDiv.DataField = "FollowDeliGoodsDiv";
            this.FollowDeliGoodsDiv.Height = 0.125F;
            this.FollowDeliGoodsDiv.Left = 4.625F;
            this.FollowDeliGoodsDiv.MultiLine = false;
            this.FollowDeliGoodsDiv.Name = "FollowDeliGoodsDiv";
            this.FollowDeliGoodsDiv.OutputFormat = resources.GetString("FollowDeliGoodsDiv.OutputFormat");
            this.FollowDeliGoodsDiv.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.FollowDeliGoodsDiv.Text = "X";
            this.FollowDeliGoodsDiv.Top = 0.125F;
            this.FollowDeliGoodsDiv.Width = 0.3125F;
            // 
            // ListPrice
            // 
            this.ListPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice.Border.RightColor = System.Drawing.Color.Black;
            this.ListPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice.Border.TopColor = System.Drawing.Color.Black;
            this.ListPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPrice.DataField = "ListPrice";
            this.ListPrice.Height = 0.125F;
            this.ListPrice.Left = 5F;
            this.ListPrice.MultiLine = false;
            this.ListPrice.Name = "ListPrice";
            this.ListPrice.OutputFormat = resources.GetString("ListPrice.OutputFormat");
            this.ListPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.ListPrice.Text = "9XX,XXX,XXX";
            this.ListPrice.Top = 0F;
            this.ListPrice.Width = 0.6875F;
            // 
            // UOERemark2
            // 
            this.UOERemark2.Border.BottomColor = System.Drawing.Color.Black;
            this.UOERemark2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark2.Border.LeftColor = System.Drawing.Color.Black;
            this.UOERemark2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark2.Border.RightColor = System.Drawing.Color.Black;
            this.UOERemark2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark2.Border.TopColor = System.Drawing.Color.Black;
            this.UOERemark2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark2.DataField = "UOERemark2";
            this.UOERemark2.Height = 0.125F;
            this.UOERemark2.Left = 4.25F;
            this.UOERemark2.MultiLine = false;
            this.UOERemark2.Name = "UOERemark2";
            this.UOERemark2.OutputFormat = resources.GetString("UOERemark2.OutputFormat");
            this.UOERemark2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOERemark2.Text = "20XXXXXXXXXXXXXXXXXX";
            this.UOERemark2.Top = 0.25F;
            this.UOERemark2.Width = 1.625F;
            // 
            // UOERemark1
            // 
            this.UOERemark1.Border.BottomColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.Border.LeftColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.Border.RightColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.Border.TopColor = System.Drawing.Color.Black;
            this.UOERemark1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOERemark1.DataField = "UOERemark1";
            this.UOERemark1.Height = 0.125F;
            this.UOERemark1.Left = 2.8125F;
            this.UOERemark1.MultiLine = false;
            this.UOERemark1.Name = "UOERemark1";
            this.UOERemark1.OutputFormat = resources.GetString("UOERemark1.OutputFormat");
            this.UOERemark1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOERemark1.Text = "20XXXXXXXXXXXXXXXXXX";
            this.UOERemark1.Top = 0.25F;
            this.UOERemark1.Width = 1.1875F;
            // 
            // PartsLayerCd
            // 
            this.PartsLayerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsLayerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsLayerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsLayerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsLayerCd.Border.RightColor = System.Drawing.Color.Black;
            this.PartsLayerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsLayerCd.Border.TopColor = System.Drawing.Color.Black;
            this.PartsLayerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsLayerCd.DataField = "PartsLayerCd";
            this.PartsLayerCd.Height = 0.125F;
            this.PartsLayerCd.Left = 9.75F;
            this.PartsLayerCd.MultiLine = false;
            this.PartsLayerCd.Name = "PartsLayerCd";
            this.PartsLayerCd.OutputFormat = resources.GetString("PartsLayerCd.OutputFormat");
            this.PartsLayerCd.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.PartsLayerCd.Text = "4XXX";
            this.PartsLayerCd.Top = 0.125F;
            this.PartsLayerCd.Width = 0.3125F;
            // 
            // LineErrorMessage
            // 
            this.LineErrorMessage.Border.BottomColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.Border.LeftColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.Border.RightColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.Border.TopColor = System.Drawing.Color.Black;
            this.LineErrorMessage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LineErrorMessage.DataField = "LineErrorMessage";
            this.LineErrorMessage.Height = 0.125F;
            this.LineErrorMessage.Left = 10.125F;
            this.LineErrorMessage.MultiLine = false;
            this.LineErrorMessage.Name = "LineErrorMessage";
            this.LineErrorMessage.OutputFormat = resources.GetString("LineErrorMessage.OutputFormat");
            this.LineErrorMessage.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.LineErrorMessage.Text = "10XXXXXXXX";
            this.LineErrorMessage.Top = 0.125F;
            this.LineErrorMessage.Width = 0.625F;
            // 
            // MazdaUOEShipSectCd3
            // 
            this.MazdaUOEShipSectCd3.Border.BottomColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd3.Border.LeftColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd3.Border.RightColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd3.Border.TopColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd3.DataField = "MazdaUOEShipSectCd3";
            this.MazdaUOEShipSectCd3.Height = 0.125F;
            this.MazdaUOEShipSectCd3.Left = 7.5F;
            this.MazdaUOEShipSectCd3.MultiLine = false;
            this.MazdaUOEShipSectCd3.Name = "MazdaUOEShipSectCd3";
            this.MazdaUOEShipSectCd3.OutputFormat = resources.GetString("MazdaUOEShipSectCd3.OutputFormat");
            this.MazdaUOEShipSectCd3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MazdaUOEShipSectCd3.Text = "3XX";
            this.MazdaUOEShipSectCd3.Top = 0.25F;
            this.MazdaUOEShipSectCd3.Width = 0.5F;
            // 
            // MazdaUOEShipSectCd2
            // 
            this.MazdaUOEShipSectCd2.Border.BottomColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd2.Border.LeftColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd2.Border.RightColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd2.Border.TopColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd2.DataField = "MazdaUOEShipSectCd2";
            this.MazdaUOEShipSectCd2.Height = 0.125F;
            this.MazdaUOEShipSectCd2.Left = 6.9375F;
            this.MazdaUOEShipSectCd2.MultiLine = false;
            this.MazdaUOEShipSectCd2.Name = "MazdaUOEShipSectCd2";
            this.MazdaUOEShipSectCd2.OutputFormat = resources.GetString("MazdaUOEShipSectCd2.OutputFormat");
            this.MazdaUOEShipSectCd2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MazdaUOEShipSectCd2.Text = "3XX";
            this.MazdaUOEShipSectCd2.Top = 0.25F;
            this.MazdaUOEShipSectCd2.Width = 0.5F;
            // 
            // MazdaUOEShipSectCd1
            // 
            this.MazdaUOEShipSectCd1.Border.BottomColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd1.Border.LeftColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd1.Border.RightColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd1.Border.TopColor = System.Drawing.Color.Black;
            this.MazdaUOEShipSectCd1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MazdaUOEShipSectCd1.DataField = "MazdaUOEShipSectCd1";
            this.MazdaUOEShipSectCd1.Height = 0.125F;
            this.MazdaUOEShipSectCd1.Left = 6.375F;
            this.MazdaUOEShipSectCd1.MultiLine = false;
            this.MazdaUOEShipSectCd1.Name = "MazdaUOEShipSectCd1";
            this.MazdaUOEShipSectCd1.OutputFormat = resources.GetString("MazdaUOEShipSectCd1.OutputFormat");
            this.MazdaUOEShipSectCd1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.MazdaUOEShipSectCd1.Text = "3XX";
            this.MazdaUOEShipSectCd1.Top = 0.25F;
            this.MazdaUOEShipSectCd1.Width = 0.5F;
            // 
            // BOCode
            // 
            this.BOCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BOCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BOCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.Border.RightColor = System.Drawing.Color.Black;
            this.BOCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.Border.TopColor = System.Drawing.Color.Black;
            this.BOCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOCode.DataField = "BOCode";
            this.BOCode.Height = 0.125F;
            this.BOCode.Left = 5.9375F;
            this.BOCode.MultiLine = false;
            this.BOCode.Name = "BOCode";
            this.BOCode.OutputFormat = resources.GetString("BOCode.OutputFormat");
            this.BOCode.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.BOCode.Text = "X";
            this.BOCode.Top = 0.125F;
            this.BOCode.Width = 0.375F;
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 2.8125F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsNo.Text = "24XXXXXXXXXXXXXXXXXXXXXX";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.375F;
            // 
            // GoodsMakerCd
            // 
            this.GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMakerCd.DataField = "GoodsMakerCd";
            this.GoodsMakerCd.Height = 0.125F;
            this.GoodsMakerCd.Left = 4.25F;
            this.GoodsMakerCd.MultiLine = false;
            this.GoodsMakerCd.Name = "GoodsMakerCd";
            this.GoodsMakerCd.OutputFormat = resources.GetString("GoodsMakerCd.OutputFormat");
            this.GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsMakerCd.Text = "4XXX";
            this.GoodsMakerCd.Top = 0F;
            this.GoodsMakerCd.Width = 0.3125F;
            // 
            // EmployeeName
            // 
            this.EmployeeName.Border.BottomColor = System.Drawing.Color.Black;
            this.EmployeeName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeName.Border.LeftColor = System.Drawing.Color.Black;
            this.EmployeeName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeName.Border.RightColor = System.Drawing.Color.Black;
            this.EmployeeName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeName.Border.TopColor = System.Drawing.Color.Black;
            this.EmployeeName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EmployeeName.DataField = "EmployeeName";
            this.EmployeeName.Height = 0.125F;
            this.EmployeeName.Left = 1F;
            this.EmployeeName.MultiLine = false;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.OutputFormat = resources.GetString("EmployeeName.OutputFormat");
            this.EmployeeName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.EmployeeName.Text = "１０ＮＮＮＮＮＮＮＮ";
            this.EmployeeName.Top = 0.125F;
            this.EmployeeName.Width = 1.1875F;
            // 
            // UOESalesOrderRowNo
            // 
            this.UOESalesOrderRowNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESalesOrderRowNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderRowNo.DataField = "UOESalesOrderRowNo";
            this.UOESalesOrderRowNo.Height = 0.125F;
            this.UOESalesOrderRowNo.Left = 2.375F;
            this.UOESalesOrderRowNo.MultiLine = false;
            this.UOESalesOrderRowNo.Name = "UOESalesOrderRowNo";
            this.UOESalesOrderRowNo.OutputFormat = resources.GetString("UOESalesOrderRowNo.OutputFormat");
            this.UOESalesOrderRowNo.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.UOESalesOrderRowNo.Text = "3XX";
            this.UOESalesOrderRowNo.Top = 0F;
            this.UOESalesOrderRowNo.Width = 0.375F;
            // 
            // CustomerSnm
            // 
            this.CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.DataField = "CustomerSnm";
            this.CustomerSnm.Height = 0.125F;
            this.CustomerSnm.Left = 1F;
            this.CustomerSnm.MultiLine = false;
            this.CustomerSnm.Name = "CustomerSnm";
            this.CustomerSnm.OutputFormat = resources.GetString("CustomerSnm.OutputFormat");
            this.CustomerSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.CustomerSnm.Text = "１０ＮＮＮＮＮＮＮＮ";
            this.CustomerSnm.Top = 0.25F;
            this.CustomerSnm.Width = 1.1875F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 2.8125F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.GoodsName.Text = "20XXXXXXXXXXXXXXXXXX";
            this.GoodsName.Top = 0.125F;
            this.GoodsName.Width = 1.1875F;
            // 
            // AcceptAnOrderCnt
            // 
            this.AcceptAnOrderCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AcceptAnOrderCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcceptAnOrderCnt.DataField = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.Height = 0.125F;
            this.AcceptAnOrderCnt.Left = 5.9375F;
            this.AcceptAnOrderCnt.MultiLine = false;
            this.AcceptAnOrderCnt.Name = "AcceptAnOrderCnt";
            this.AcceptAnOrderCnt.OutputFormat = resources.GetString("AcceptAnOrderCnt.OutputFormat");
            this.AcceptAnOrderCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.AcceptAnOrderCnt.Text = "3XX";
            this.AcceptAnOrderCnt.Top = 0F;
            this.AcceptAnOrderCnt.Width = 0.375F;
            // 
            // BOSlipNo3
            // 
            this.BOSlipNo3.Border.BottomColor = System.Drawing.Color.Black;
            this.BOSlipNo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3.Border.LeftColor = System.Drawing.Color.Black;
            this.BOSlipNo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3.Border.RightColor = System.Drawing.Color.Black;
            this.BOSlipNo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3.Border.TopColor = System.Drawing.Color.Black;
            this.BOSlipNo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOSlipNo3.DataField = "BOSlipNo3";
            this.BOSlipNo3.Height = 0.125F;
            this.BOSlipNo3.Left = 8.0625F;
            this.BOSlipNo3.MultiLine = false;
            this.BOSlipNo3.Name = "BOSlipNo3";
            this.BOSlipNo3.OutputFormat = resources.GetString("BOSlipNo3.OutputFormat");
            this.BOSlipNo3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.BOSlipNo3.Text = "8XXXXXXX";
            this.BOSlipNo3.Top = 0.125F;
            this.BOSlipNo3.Width = 0.5F;
            // 
            // ReceiveTime
            // 
            this.ReceiveTime.Border.BottomColor = System.Drawing.Color.Black;
            this.ReceiveTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveTime.Border.LeftColor = System.Drawing.Color.Black;
            this.ReceiveTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveTime.Border.RightColor = System.Drawing.Color.Black;
            this.ReceiveTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveTime.Border.TopColor = System.Drawing.Color.Black;
            this.ReceiveTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ReceiveTime.DataField = "ReceiveTime";
            this.ReceiveTime.Height = 0.125F;
            this.ReceiveTime.Left = 1.1875F;
            this.ReceiveTime.MultiLine = false;
            this.ReceiveTime.Name = "ReceiveTime";
            this.ReceiveTime.OutputFormat = resources.GetString("ReceiveTime.OutputFormat");
            this.ReceiveTime.Style = "ddo-char-set: 128; text-align: center; font-size: 8pt; font-family: ＭＳ 明朝; vertic" +
                "al-align: top; ";
            this.ReceiveTime.Text = "XX:XX:XX";
            this.ReceiveTime.Top = 0F;
            this.ReceiveTime.Width = 0.5625F;
            // 
            // UOESectionSlipNo
            // 
            this.UOESectionSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectionSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectionSlipNo.DataField = "UOESectionSlipNo";
            this.UOESectionSlipNo.Height = 0.125F;
            this.UOESectionSlipNo.Left = 6.375F;
            this.UOESectionSlipNo.MultiLine = false;
            this.UOESectionSlipNo.Name = "UOESectionSlipNo";
            this.UOESectionSlipNo.OutputFormat = resources.GetString("UOESectionSlipNo.OutputFormat");
            this.UOESectionSlipNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOESectionSlipNo.Text = "8XXXXXXX";
            this.UOESectionSlipNo.Top = 0.125F;
            this.UOESectionSlipNo.Width = 0.5F;
            // 
            // SalesUnitCost
            // 
            this.SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnitCost.DataField = "SalesUnitCost";
            this.SalesUnitCost.Height = 0.125F;
            this.SalesUnitCost.Left = 5.1F;
            this.SalesUnitCost.MultiLine = false;
            this.SalesUnitCost.Name = "SalesUnitCost";
            this.SalesUnitCost.OutputFormat = resources.GetString("SalesUnitCost.OutputFormat");
            this.SalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.SalesUnitCost.Text = "7XXX,XXX.2X";
            this.SalesUnitCost.Top = 0.125F;
            this.SalesUnitCost.Width = 0.75F;
            // 
            // EOAlwcCount
            // 
            this.EOAlwcCount.Border.BottomColor = System.Drawing.Color.Black;
            this.EOAlwcCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount.Border.LeftColor = System.Drawing.Color.Black;
            this.EOAlwcCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount.Border.RightColor = System.Drawing.Color.Black;
            this.EOAlwcCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount.Border.TopColor = System.Drawing.Color.Black;
            this.EOAlwcCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EOAlwcCount.DataField = "EOAlwcCount";
            this.EOAlwcCount.Height = 0.125F;
            this.EOAlwcCount.Left = 9.1875F;
            this.EOAlwcCount.MultiLine = false;
            this.EOAlwcCount.Name = "EOAlwcCount";
            this.EOAlwcCount.OutputFormat = resources.GetString("EOAlwcCount.OutputFormat");
            this.EOAlwcCount.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.EOAlwcCount.Text = "3XX";
            this.EOAlwcCount.Top = 0F;
            this.EOAlwcCount.Width = 0.5F;
            // 
            // BOShipmentCnt3
            // 
            this.BOShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.BOShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BOShipmentCnt3.DataField = "BOShipmentCnt3";
            this.BOShipmentCnt3.Height = 0.125F;
            this.BOShipmentCnt3.Left = 8.0625F;
            this.BOShipmentCnt3.MultiLine = false;
            this.BOShipmentCnt3.Name = "BOShipmentCnt3";
            this.BOShipmentCnt3.OutputFormat = resources.GetString("BOShipmentCnt3.OutputFormat");
            this.BOShipmentCnt3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.BOShipmentCnt3.Text = "3XX";
            this.BOShipmentCnt3.Top = 0F;
            this.BOShipmentCnt3.Width = 0.5F;
            // 
            // MakerFollowCnt
            // 
            this.MakerFollowCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerFollowCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerFollowCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt.Border.RightColor = System.Drawing.Color.Black;
            this.MakerFollowCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt.Border.TopColor = System.Drawing.Color.Black;
            this.MakerFollowCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerFollowCnt.DataField = "MakerFollowCnt";
            this.MakerFollowCnt.Height = 0.125F;
            this.MakerFollowCnt.Left = 8.625F;
            this.MakerFollowCnt.MultiLine = false;
            this.MakerFollowCnt.Name = "MakerFollowCnt";
            this.MakerFollowCnt.OutputFormat = resources.GetString("MakerFollowCnt.OutputFormat");
            this.MakerFollowCnt.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.MakerFollowCnt.Text = "3XX";
            this.MakerFollowCnt.Top = 0F;
            this.MakerFollowCnt.Width = 0.5F;
            // 
            // UOESectOutGoodsCnt
            // 
            this.UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESectOutGoodsCnt.DataField = "UOESectOutGoodsCnt";
            this.UOESectOutGoodsCnt.Height = 0.125F;
            this.UOESectOutGoodsCnt.Left = 6.375F;
            this.UOESectOutGoodsCnt.MultiLine = false;
            this.UOESectOutGoodsCnt.Name = "UOESectOutGoodsCnt";
            this.UOESectOutGoodsCnt.OutputFormat = resources.GetString("UOESectOutGoodsCnt.OutputFormat");
            this.UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.UOESectOutGoodsCnt.Text = "3XX";
            this.UOESectOutGoodsCnt.Top = 0F;
            this.UOESectOutGoodsCnt.Width = 0.5F;
            // 
            // Line_OnMemoPrint1
            // 
            this.Line_OnMemoPrint1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line_OnMemoPrint1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_OnMemoPrint1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line_OnMemoPrint1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_OnMemoPrint1.Border.RightColor = System.Drawing.Color.Black;
            this.Line_OnMemoPrint1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_OnMemoPrint1.Border.TopColor = System.Drawing.Color.Black;
            this.Line_OnMemoPrint1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line_OnMemoPrint1.Height = 0F;
            this.Line_OnMemoPrint1.Left = 0.4375F;
            this.Line_OnMemoPrint1.LineWeight = 1F;
            this.Line_OnMemoPrint1.Name = "Line_OnMemoPrint1";
            this.Line_OnMemoPrint1.Top = 0.375F;
            this.Line_OnMemoPrint1.Width = 10.375F;
            this.Line_OnMemoPrint1.X1 = 0.4375F;
            this.Line_OnMemoPrint1.X2 = 10.8125F;
            this.Line_OnMemoPrint1.Y1 = 0.375F;
            this.Line_OnMemoPrint1.Y2 = 0.375F;
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
            this.tb_ReportSort});
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "UOE発注回答一覧表";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.8125F;
            // 
            // tb_ReportSort
            // 
            this.tb_ReportSort.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportSort.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportSort.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportSort.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportSort.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportSort.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportSort.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportSort.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportSort.DataField = "tb_ReportSort";
            this.tb_ReportSort.Height = 0.15625F;
            this.tb_ReportSort.Left = 2.0625F;
            this.tb_ReportSort.MultiLine = false;
            this.tb_ReportSort.Name = "tb_ReportSort";
            this.tb_ReportSort.OutputFormat = resources.GetString("tb_ReportSort.OutputFormat");
            this.tb_ReportSort.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.tb_ReportSort.Text = null;
            this.tb_ReportSort.Top = 0.0625F;
            this.tb_ReportSort.Visible = false;
            this.tb_ReportSort.Width = 2.125F;
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
            this.Footer_SubReport.Visible = false;
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
            this.line10,
            this.Lb_ReceiveDate,
            this.Lb_Employee,
            this.Lb_Customer,
            this.Lb_ReceiveTime,
            this.Lb_UOESalesOrderNo,
            this.Lb_UOESalesOrderRowNo,
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.Lb_UOERemark1,
            this.Lb_GoodsMakerCd,
            this.Lb_UOERemark2,
            this.Lb_DeliveredGoodsDiv,
            this.Lb_FollowDeliGoodsDiv,
            this.Lb_ListPrice,
            this.Lb_SalesUnitCost,
            this.Lb_BOCode,
            this.Lb_AcceptAnOrderCnt,
            this.Lb_UOESectionSlipNo,
            this.Lb_MazdaUOEShipSectCd1,
            this.Lb_BOSlipNo1,
            this.Lb_MazdaUOEShipSectCd2,
            this.Lb_MazdaUOEShipSectCd3,
            this.Lb_BOSlipNo2,
            this.Lb_BOSlipNo3,
            this.Lb_BOManagementNo,
            this.Lb_UOESubstMark,
            this.Lb_PartsLayerCd,
            this.Lb_SourceShipment,
            this.Lb_LineErrorMessage,
            this.Lb_UOESupplier,
            this.Lb_EOAlwcCount,
            this.Lb_BOShipmentCnt1,
            this.Lb_BOShipmentCnt2,
            this.Lb_BOShipmentCnt3,
            this.Lb_MakerFollowCnt,
            this.Lb_UOESectOutGoodsCnt});
            this.TitleHeader.Height = 0.5416667F;
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
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0.51F;
            this.line10.Width = 10.8125F;
            this.line10.X1 = 0F;
            this.line10.X2 = 10.8125F;
            this.line10.Y1 = 0.51F;
            this.line10.Y2 = 0.51F;
            // 
            // Lb_ReceiveDate
            // 
            this.Lb_ReceiveDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ReceiveDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ReceiveDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ReceiveDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ReceiveDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveDate.Height = 0.15F;
            this.Lb_ReceiveDate.HyperLink = "";
            this.Lb_ReceiveDate.Left = 0.5F;
            this.Lb_ReceiveDate.MultiLine = false;
            this.Lb_ReceiveDate.Name = "Lb_ReceiveDate";
            this.Lb_ReceiveDate.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ReceiveDate.Text = "受信日";
            this.Lb_ReceiveDate.Top = 0.0625F;
            this.Lb_ReceiveDate.Width = 0.625F;
            // 
            // Lb_Employee
            // 
            this.Lb_Employee.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Employee.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Employee.Height = 0.15F;
            this.Lb_Employee.HyperLink = "";
            this.Lb_Employee.Left = 0.5F;
            this.Lb_Employee.MultiLine = false;
            this.Lb_Employee.Name = "Lb_Employee";
            this.Lb_Employee.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Employee.Text = "依頼者";
            this.Lb_Employee.Top = 0.21F;
            this.Lb_Employee.Width = 0.625F;
            // 
            // Lb_Customer
            // 
            this.Lb_Customer.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_Customer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_Customer.Height = 0.15F;
            this.Lb_Customer.HyperLink = "";
            this.Lb_Customer.Left = 0.5F;
            this.Lb_Customer.MultiLine = false;
            this.Lb_Customer.Name = "Lb_Customer";
            this.Lb_Customer.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_Customer.Text = "得意先";
            this.Lb_Customer.Top = 0.35F;
            this.Lb_Customer.Width = 0.625F;
            // 
            // Lb_ReceiveTime
            // 
            this.Lb_ReceiveTime.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ReceiveTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveTime.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ReceiveTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveTime.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ReceiveTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveTime.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ReceiveTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ReceiveTime.Height = 0.15F;
            this.Lb_ReceiveTime.HyperLink = "";
            this.Lb_ReceiveTime.Left = 1.1875F;
            this.Lb_ReceiveTime.MultiLine = false;
            this.Lb_ReceiveTime.Name = "Lb_ReceiveTime";
            this.Lb_ReceiveTime.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ReceiveTime.Text = "受信時刻";
            this.Lb_ReceiveTime.Top = 0.0625F;
            this.Lb_ReceiveTime.Width = 0.5625F;
            // 
            // Lb_UOESalesOrderNo
            // 
            this.Lb_UOESalesOrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderNo.Height = 0.15F;
            this.Lb_UOESalesOrderNo.HyperLink = "";
            this.Lb_UOESalesOrderNo.Left = 1.8125F;
            this.Lb_UOESalesOrderNo.MultiLine = false;
            this.Lb_UOESalesOrderNo.Name = "Lb_UOESalesOrderNo";
            this.Lb_UOESalesOrderNo.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESalesOrderNo.Text = "回答番号";
            this.Lb_UOESalesOrderNo.Top = 0.0625F;
            this.Lb_UOESalesOrderNo.Width = 0.5F;
            // 
            // Lb_UOESalesOrderRowNo
            // 
            this.Lb_UOESalesOrderRowNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderRowNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderRowNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderRowNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderRowNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderRowNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderRowNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESalesOrderRowNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESalesOrderRowNo.Height = 0.15F;
            this.Lb_UOESalesOrderRowNo.HyperLink = "";
            this.Lb_UOESalesOrderRowNo.Left = 2.375F;
            this.Lb_UOESalesOrderRowNo.MultiLine = false;
            this.Lb_UOESalesOrderRowNo.Name = "Lb_UOESalesOrderRowNo";
            this.Lb_UOESalesOrderRowNo.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESalesOrderRowNo.Text = "行番号";
            this.Lb_UOESalesOrderRowNo.Top = 0.0625F;
            this.Lb_UOESalesOrderRowNo.Width = 0.375F;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 2.8125F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0.0625F;
            this.Lb_GoodsNo.Width = 1.375F;
            // 
            // Lb_GoodsName
            // 
            this.Lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Height = 0.15F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 2.8125F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0.21F;
            this.Lb_GoodsName.Width = 1.375F;
            // 
            // Lb_UOERemark1
            // 
            this.Lb_UOERemark1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOERemark1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOERemark1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOERemark1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOERemark1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark1.Height = 0.15F;
            this.Lb_UOERemark1.HyperLink = "";
            this.Lb_UOERemark1.Left = 2.8125F;
            this.Lb_UOERemark1.MultiLine = false;
            this.Lb_UOERemark1.Name = "Lb_UOERemark1";
            this.Lb_UOERemark1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOERemark1.Text = "リマーク１";
            this.Lb_UOERemark1.Top = 0.35F;
            this.Lb_UOERemark1.Width = 1.375F;
            // 
            // Lb_GoodsMakerCd
            // 
            this.Lb_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMakerCd.Height = 0.15F;
            this.Lb_GoodsMakerCd.HyperLink = "";
            this.Lb_GoodsMakerCd.Left = 4.25F;
            this.Lb_GoodsMakerCd.MultiLine = false;
            this.Lb_GoodsMakerCd.Name = "Lb_GoodsMakerCd";
            this.Lb_GoodsMakerCd.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMakerCd.Text = "ﾒｰｶｰ";
            this.Lb_GoodsMakerCd.Top = 0.0625F;
            this.Lb_GoodsMakerCd.Width = 0.3125F;
            // 
            // Lb_UOERemark2
            // 
            this.Lb_UOERemark2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOERemark2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOERemark2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOERemark2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOERemark2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOERemark2.Height = 0.15F;
            this.Lb_UOERemark2.HyperLink = "";
            this.Lb_UOERemark2.Left = 4.25F;
            this.Lb_UOERemark2.MultiLine = false;
            this.Lb_UOERemark2.Name = "Lb_UOERemark2";
            this.Lb_UOERemark2.Style = "ddo-char-set: 128; text-align: justify; font-weight: bold; font-size: 8pt; font-f" +
                "amily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOERemark2.Text = "リマーク２";
            this.Lb_UOERemark2.Top = 0.35F;
            this.Lb_UOERemark2.Width = 1.4375F;
            // 
            // Lb_DeliveredGoodsDiv
            // 
            this.Lb_DeliveredGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DeliveredGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliveredGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DeliveredGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliveredGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DeliveredGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliveredGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DeliveredGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DeliveredGoodsDiv.Height = 0.15F;
            this.Lb_DeliveredGoodsDiv.HyperLink = "";
            this.Lb_DeliveredGoodsDiv.Left = 4.625F;
            this.Lb_DeliveredGoodsDiv.MultiLine = false;
            this.Lb_DeliveredGoodsDiv.Name = "Lb_DeliveredGoodsDiv";
            this.Lb_DeliveredGoodsDiv.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DeliveredGoodsDiv.Text = "納区";
            this.Lb_DeliveredGoodsDiv.Top = 0.0625F;
            this.Lb_DeliveredGoodsDiv.Width = 0.3125F;
            // 
            // Lb_FollowDeliGoodsDiv
            // 
            this.Lb_FollowDeliGoodsDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_FollowDeliGoodsDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_FollowDeliGoodsDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_FollowDeliGoodsDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_FollowDeliGoodsDiv.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_FollowDeliGoodsDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_FollowDeliGoodsDiv.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_FollowDeliGoodsDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_FollowDeliGoodsDiv.Height = 0.15F;
            this.Lb_FollowDeliGoodsDiv.HyperLink = "";
            this.Lb_FollowDeliGoodsDiv.Left = 4.625F;
            this.Lb_FollowDeliGoodsDiv.MultiLine = false;
            this.Lb_FollowDeliGoodsDiv.Name = "Lb_FollowDeliGoodsDiv";
            this.Lb_FollowDeliGoodsDiv.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_FollowDeliGoodsDiv.Text = "H納区";
            this.Lb_FollowDeliGoodsDiv.Top = 0.21F;
            this.Lb_FollowDeliGoodsDiv.Width = 0.3125F;
            // 
            // Lb_ListPrice
            // 
            this.Lb_ListPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ListPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ListPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ListPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ListPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPrice.Height = 0.15F;
            this.Lb_ListPrice.HyperLink = "";
            this.Lb_ListPrice.Left = 5F;
            this.Lb_ListPrice.MultiLine = false;
            this.Lb_ListPrice.Name = "Lb_ListPrice";
            this.Lb_ListPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ListPrice.Text = "定価";
            this.Lb_ListPrice.Top = 0.0625F;
            this.Lb_ListPrice.Width = 0.6875F;
            // 
            // Lb_SalesUnitCost
            // 
            this.Lb_SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Height = 0.15F;
            this.Lb_SalesUnitCost.HyperLink = "";
            this.Lb_SalesUnitCost.Left = 5F;
            this.Lb_SalesUnitCost.MultiLine = false;
            this.Lb_SalesUnitCost.Name = "Lb_SalesUnitCost";
            this.Lb_SalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesUnitCost.Text = "仕切単価";
            this.Lb_SalesUnitCost.Top = 0.21F;
            this.Lb_SalesUnitCost.Width = 0.6875F;
            // 
            // Lb_BOCode
            // 
            this.Lb_BOCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOCode.Height = 0.15F;
            this.Lb_BOCode.HyperLink = "";
            this.Lb_BOCode.Left = 5.9375F;
            this.Lb_BOCode.MultiLine = false;
            this.Lb_BOCode.Name = "Lb_BOCode";
            this.Lb_BOCode.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOCode.Text = "ＢＯ";
            this.Lb_BOCode.Top = 0.21F;
            this.Lb_BOCode.Width = 0.375F;
            // 
            // Lb_AcceptAnOrderCnt
            // 
            this.Lb_AcceptAnOrderCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AcceptAnOrderCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcceptAnOrderCnt.Height = 0.15F;
            this.Lb_AcceptAnOrderCnt.HyperLink = "";
            this.Lb_AcceptAnOrderCnt.Left = 5.9375F;
            this.Lb_AcceptAnOrderCnt.MultiLine = false;
            this.Lb_AcceptAnOrderCnt.Name = "Lb_AcceptAnOrderCnt";
            this.Lb_AcceptAnOrderCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_AcceptAnOrderCnt.Text = "発注数";
            this.Lb_AcceptAnOrderCnt.Top = 0.0625F;
            this.Lb_AcceptAnOrderCnt.Width = 0.375F;
            // 
            // Lb_UOESectionSlipNo
            // 
            this.Lb_UOESectionSlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESectionSlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectionSlipNo.Height = 0.15F;
            this.Lb_UOESectionSlipNo.HyperLink = "";
            this.Lb_UOESectionSlipNo.Left = 6.375F;
            this.Lb_UOESectionSlipNo.MultiLine = false;
            this.Lb_UOESectionSlipNo.Name = "Lb_UOESectionSlipNo";
            this.Lb_UOESectionSlipNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESectionSlipNo.Text = "伝票番号";
            this.Lb_UOESectionSlipNo.Top = 0.21F;
            this.Lb_UOESectionSlipNo.Width = 0.5F;
            // 
            // Lb_MazdaUOEShipSectCd1
            // 
            this.Lb_MazdaUOEShipSectCd1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd1.Height = 0.15F;
            this.Lb_MazdaUOEShipSectCd1.HyperLink = "";
            this.Lb_MazdaUOEShipSectCd1.Left = 6.375F;
            this.Lb_MazdaUOEShipSectCd1.MultiLine = false;
            this.Lb_MazdaUOEShipSectCd1.Name = "Lb_MazdaUOEShipSectCd1";
            this.Lb_MazdaUOEShipSectCd1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MazdaUOEShipSectCd1.Text = "拠点ｺｰﾄﾞ";
            this.Lb_MazdaUOEShipSectCd1.Top = 0.35F;
            this.Lb_MazdaUOEShipSectCd1.Width = 0.5F;
            // 
            // Lb_BOSlipNo1
            // 
            this.Lb_BOSlipNo1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo1.Height = 0.15F;
            this.Lb_BOSlipNo1.HyperLink = "";
            this.Lb_BOSlipNo1.Left = 6.9375F;
            this.Lb_BOSlipNo1.MultiLine = false;
            this.Lb_BOSlipNo1.Name = "Lb_BOSlipNo1";
            this.Lb_BOSlipNo1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOSlipNo1.Text = "伝票番号";
            this.Lb_BOSlipNo1.Top = 0.21F;
            this.Lb_BOSlipNo1.Width = 0.5F;
            // 
            // Lb_MazdaUOEShipSectCd2
            // 
            this.Lb_MazdaUOEShipSectCd2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd2.Height = 0.15F;
            this.Lb_MazdaUOEShipSectCd2.HyperLink = "";
            this.Lb_MazdaUOEShipSectCd2.Left = 6.9375F;
            this.Lb_MazdaUOEShipSectCd2.MultiLine = false;
            this.Lb_MazdaUOEShipSectCd2.Name = "Lb_MazdaUOEShipSectCd2";
            this.Lb_MazdaUOEShipSectCd2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MazdaUOEShipSectCd2.Text = "ﾌｫﾛｰｺｰﾄﾞ1";
            this.Lb_MazdaUOEShipSectCd2.Top = 0.35F;
            this.Lb_MazdaUOEShipSectCd2.Width = 0.5625F;
            // 
            // Lb_MazdaUOEShipSectCd3
            // 
            this.Lb_MazdaUOEShipSectCd3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MazdaUOEShipSectCd3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MazdaUOEShipSectCd3.Height = 0.15F;
            this.Lb_MazdaUOEShipSectCd3.HyperLink = "";
            this.Lb_MazdaUOEShipSectCd3.Left = 7.5F;
            this.Lb_MazdaUOEShipSectCd3.MultiLine = false;
            this.Lb_MazdaUOEShipSectCd3.Name = "Lb_MazdaUOEShipSectCd3";
            this.Lb_MazdaUOEShipSectCd3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MazdaUOEShipSectCd3.Text = "ﾌｫﾛｰｺｰﾄﾞ2";
            this.Lb_MazdaUOEShipSectCd3.Top = 0.35F;
            this.Lb_MazdaUOEShipSectCd3.Width = 0.5625F;
            // 
            // Lb_BOSlipNo2
            // 
            this.Lb_BOSlipNo2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo2.Height = 0.15F;
            this.Lb_BOSlipNo2.HyperLink = "";
            this.Lb_BOSlipNo2.Left = 7.5F;
            this.Lb_BOSlipNo2.MultiLine = false;
            this.Lb_BOSlipNo2.Name = "Lb_BOSlipNo2";
            this.Lb_BOSlipNo2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOSlipNo2.Text = "伝票番号";
            this.Lb_BOSlipNo2.Top = 0.21F;
            this.Lb_BOSlipNo2.Width = 0.5F;
            // 
            // Lb_BOSlipNo3
            // 
            this.Lb_BOSlipNo3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOSlipNo3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOSlipNo3.Height = 0.15F;
            this.Lb_BOSlipNo3.HyperLink = "";
            this.Lb_BOSlipNo3.Left = 8.0625F;
            this.Lb_BOSlipNo3.MultiLine = false;
            this.Lb_BOSlipNo3.Name = "Lb_BOSlipNo3";
            this.Lb_BOSlipNo3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOSlipNo3.Text = "伝票番号";
            this.Lb_BOSlipNo3.Top = 0.21F;
            this.Lb_BOSlipNo3.Width = 0.5F;
            // 
            // Lb_BOManagementNo
            // 
            this.Lb_BOManagementNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOManagementNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOManagementNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOManagementNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOManagementNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOManagementNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOManagementNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOManagementNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOManagementNo.Height = 0.15F;
            this.Lb_BOManagementNo.HyperLink = "";
            this.Lb_BOManagementNo.Left = 9.1875F;
            this.Lb_BOManagementNo.MultiLine = false;
            this.Lb_BOManagementNo.Name = "Lb_BOManagementNo";
            this.Lb_BOManagementNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOManagementNo.Text = "ＥＯ管理";
            this.Lb_BOManagementNo.Top = 0.21F;
            this.Lb_BOManagementNo.Width = 0.5F;
            // 
            // Lb_UOESubstMark
            // 
            this.Lb_UOESubstMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESubstMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESubstMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESubstMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESubstMark.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESubstMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESubstMark.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESubstMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESubstMark.Height = 0.15F;
            this.Lb_UOESubstMark.HyperLink = "";
            this.Lb_UOESubstMark.Left = 9.75F;
            this.Lb_UOESubstMark.MultiLine = false;
            this.Lb_UOESubstMark.Name = "Lb_UOESubstMark";
            this.Lb_UOESubstMark.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESubstMark.Text = "代替";
            this.Lb_UOESubstMark.Top = 0.0625F;
            this.Lb_UOESubstMark.Width = 0.3125F;
            // 
            // Lb_PartsLayerCd
            // 
            this.Lb_PartsLayerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PartsLayerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsLayerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PartsLayerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsLayerCd.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PartsLayerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsLayerCd.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PartsLayerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PartsLayerCd.Height = 0.15F;
            this.Lb_PartsLayerCd.HyperLink = "";
            this.Lb_PartsLayerCd.Left = 9.75F;
            this.Lb_PartsLayerCd.MultiLine = false;
            this.Lb_PartsLayerCd.Name = "Lb_PartsLayerCd";
            this.Lb_PartsLayerCd.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PartsLayerCd.Text = "層別";
            this.Lb_PartsLayerCd.Top = 0.21F;
            this.Lb_PartsLayerCd.Width = 0.3125F;
            // 
            // Lb_SourceShipment
            // 
            this.Lb_SourceShipment.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SourceShipment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SourceShipment.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SourceShipment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SourceShipment.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SourceShipment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SourceShipment.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SourceShipment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SourceShipment.Height = 0.15F;
            this.Lb_SourceShipment.HyperLink = "";
            this.Lb_SourceShipment.Left = 10.125F;
            this.Lb_SourceShipment.MultiLine = false;
            this.Lb_SourceShipment.Name = "Lb_SourceShipment";
            this.Lb_SourceShipment.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SourceShipment.Text = "出荷";
            this.Lb_SourceShipment.Top = 0.0625F;
            this.Lb_SourceShipment.Width = 0.625F;
            // 
            // Lb_LineErrorMessage
            // 
            this.Lb_LineErrorMessage.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_LineErrorMessage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_LineErrorMessage.Height = 0.15F;
            this.Lb_LineErrorMessage.HyperLink = "";
            this.Lb_LineErrorMessage.Left = 10.125F;
            this.Lb_LineErrorMessage.MultiLine = false;
            this.Lb_LineErrorMessage.Name = "Lb_LineErrorMessage";
            this.Lb_LineErrorMessage.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_LineErrorMessage.Text = "ｴﾗｰﾒｯｾｰｼﾞ";
            this.Lb_LineErrorMessage.Top = 0.21F;
            this.Lb_LineErrorMessage.Width = 0.625F;
            // 
            // Lb_UOESupplier
            // 
            this.Lb_UOESupplier.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESupplier.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESupplier.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESupplier.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESupplier.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESupplier.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESupplier.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESupplier.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESupplier.Height = 0.15F;
            this.Lb_UOESupplier.HyperLink = "";
            this.Lb_UOESupplier.Left = 0F;
            this.Lb_UOESupplier.MultiLine = false;
            this.Lb_UOESupplier.Name = "Lb_UOESupplier";
            this.Lb_UOESupplier.Style = "ddo-char-set: 128; text-align: center; font-weight: bold; font-size: 8pt; font-fa" +
                "mily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESupplier.Text = "発注先";
            this.Lb_UOESupplier.Top = 0.0625F;
            this.Lb_UOESupplier.Width = 0.4375F;
            // 
            // Lb_EOAlwcCount
            // 
            this.Lb_EOAlwcCount.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_EOAlwcCount.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EOAlwcCount.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_EOAlwcCount.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EOAlwcCount.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_EOAlwcCount.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EOAlwcCount.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_EOAlwcCount.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_EOAlwcCount.Height = 0.15F;
            this.Lb_EOAlwcCount.HyperLink = "";
            this.Lb_EOAlwcCount.Left = 9.1875F;
            this.Lb_EOAlwcCount.MultiLine = false;
            this.Lb_EOAlwcCount.Name = "Lb_EOAlwcCount";
            this.Lb_EOAlwcCount.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_EOAlwcCount.Text = "ＥＯ";
            this.Lb_EOAlwcCount.Top = 0.0625F;
            this.Lb_EOAlwcCount.Width = 0.5F;
            // 
            // Lb_BOShipmentCnt1
            // 
            this.Lb_BOShipmentCnt1.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt1.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt1.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt1.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt1.Height = 0.15F;
            this.Lb_BOShipmentCnt1.HyperLink = "";
            this.Lb_BOShipmentCnt1.Left = 6.9375F;
            this.Lb_BOShipmentCnt1.MultiLine = false;
            this.Lb_BOShipmentCnt1.Name = "Lb_BOShipmentCnt1";
            this.Lb_BOShipmentCnt1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOShipmentCnt1.Text = "ﾌｫﾛｰ1";
            this.Lb_BOShipmentCnt1.Top = 0.0625F;
            this.Lb_BOShipmentCnt1.Width = 0.5F;
            // 
            // Lb_BOShipmentCnt2
            // 
            this.Lb_BOShipmentCnt2.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt2.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt2.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt2.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt2.Height = 0.15F;
            this.Lb_BOShipmentCnt2.HyperLink = "";
            this.Lb_BOShipmentCnt2.Left = 7.5F;
            this.Lb_BOShipmentCnt2.MultiLine = false;
            this.Lb_BOShipmentCnt2.Name = "Lb_BOShipmentCnt2";
            this.Lb_BOShipmentCnt2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOShipmentCnt2.Text = "ﾌｫﾛｰ2";
            this.Lb_BOShipmentCnt2.Top = 0.0625F;
            this.Lb_BOShipmentCnt2.Width = 0.5F;
            // 
            // Lb_BOShipmentCnt3
            // 
            this.Lb_BOShipmentCnt3.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt3.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt3.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt3.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BOShipmentCnt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BOShipmentCnt3.Height = 0.15F;
            this.Lb_BOShipmentCnt3.HyperLink = "";
            this.Lb_BOShipmentCnt3.Left = 8.0625F;
            this.Lb_BOShipmentCnt3.MultiLine = false;
            this.Lb_BOShipmentCnt3.Name = "Lb_BOShipmentCnt3";
            this.Lb_BOShipmentCnt3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BOShipmentCnt3.Text = "ﾌｫﾛｰ3";
            this.Lb_BOShipmentCnt3.Top = 0.0625F;
            this.Lb_BOShipmentCnt3.Width = 0.5F;
            // 
            // Lb_MakerFollowCnt
            // 
            this.Lb_MakerFollowCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerFollowCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerFollowCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerFollowCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerFollowCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerFollowCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerFollowCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerFollowCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerFollowCnt.Height = 0.15F;
            this.Lb_MakerFollowCnt.HyperLink = "";
            this.Lb_MakerFollowCnt.Left = 8.625F;
            this.Lb_MakerFollowCnt.MultiLine = false;
            this.Lb_MakerFollowCnt.Name = "Lb_MakerFollowCnt";
            this.Lb_MakerFollowCnt.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_MakerFollowCnt.Text = "ﾒｰｶｰ";
            this.Lb_MakerFollowCnt.Top = 0.0625F;
            this.Lb_MakerFollowCnt.Width = 0.5F;
            // 
            // Lb_UOESectOutGoodsCnt
            // 
            this.Lb_UOESectOutGoodsCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_UOESectOutGoodsCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_UOESectOutGoodsCnt.Height = 0.15F;
            this.Lb_UOESectOutGoodsCnt.HyperLink = "";
            this.Lb_UOESectOutGoodsCnt.Left = 6.375F;
            this.Lb_UOESectOutGoodsCnt.MultiLine = false;
            this.Lb_UOESectOutGoodsCnt.Name = "Lb_UOESectOutGoodsCnt";
            this.Lb_UOESectOutGoodsCnt.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_UOESectOutGoodsCnt.Text = "拠点";
            this.Lb_UOESectOutGoodsCnt.Top = 0.0625F;
            this.Lb_UOESectOutGoodsCnt.Width = 0.5F;
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
            this.GrandTotalFooter.Height = 0F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // SupplierHeader
            // 
            this.SupplierHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.UOESupplierCd,
            this.UOESupplierName});
            this.SupplierHeader.DataField = "UOESupplierCd";
            this.SupplierHeader.Height = 0.1458333F;
            this.SupplierHeader.Name = "SupplierHeader";
            this.SupplierHeader.Format += new System.EventHandler(this.SupplierHeader_Format);
            // 
            // UOESupplierCd
            // 
            this.UOESupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierCd.DataField = "UOESupplierCd";
            this.UOESupplierCd.Height = 0.125F;
            this.UOESupplierCd.Left = 0F;
            this.UOESupplierCd.MultiLine = false;
            this.UOESupplierCd.Name = "UOESupplierCd";
            this.UOESupplierCd.OutputFormat = resources.GetString("UOESupplierCd.OutputFormat");
            this.UOESupplierCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOESupplierCd.Text = "6XXXXX";
            this.UOESupplierCd.Top = 0F;
            this.UOESupplierCd.Width = 0.4375F;
            // 
            // UOESupplierName
            // 
            this.UOESupplierName.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.RightColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.Border.TopColor = System.Drawing.Color.Black;
            this.UOESupplierName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESupplierName.DataField = "UOESupplierName";
            this.UOESupplierName.Height = 0.125F;
            this.UOESupplierName.Left = 0.5F;
            this.UOESupplierName.MultiLine = false;
            this.UOESupplierName.Name = "UOESupplierName";
            this.UOESupplierName.OutputFormat = resources.GetString("UOESupplierName.OutputFormat");
            this.UOESupplierName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.UOESupplierName.Text = "１０ＮＮＮＮＮＮＮＮ";
            this.UOESupplierName.Top = 0F;
            this.UOESupplierName.Width = 1.1875F;
            // 
            // SupplierFooter
            // 
            this.SupplierFooter.Height = 0F;
            this.SupplierFooter.KeepTogether = true;
            this.SupplierFooter.Name = "SupplierFooter";
            // 
            // SectionHeader
            // 
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionCode,
            this.SectionName});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.1458333F;
            this.SectionHeader.Name = "SectionHeader";
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.125F;
            this.SectionCode.Left = 0F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionCode.Text = "6XXXXX";
            this.SectionCode.Top = 0F;
            this.SectionCode.Width = 0.4375F;
            // 
            // SectionName
            // 
            this.SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionName.DataField = "SectionName";
            this.SectionName.Height = 0.125F;
            this.SectionName.Left = 0.5F;
            this.SectionName.MultiLine = false;
            this.SectionName.Name = "SectionName";
            this.SectionName.OutputFormat = resources.GetString("SectionName.OutputFormat");
            this.SectionName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.SectionName.Text = "６ＮＮＮＮＮ";
            this.SectionName.Top = 0F;
            this.SectionName.Width = 0.75F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0.01041667F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // PMUOE04205P_01A4C
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
            this.PrintWidth = 11F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.SupplierHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SupplierFooter);
            this.Sections.Add(this.groupFooter1);
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
            this.PageEnd += new System.EventHandler(this.PMUOE04205P_02A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMUOE04205P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.UOEDeliGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESubstMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOManagementNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourceShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowDeliGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOERemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOERemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsLayerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineErrorMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaUOEShipSectCd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaUOEShipSectCd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MazdaUOEShipSectCd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderRowNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOSlipNo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectionSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EOAlwcCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BOShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ReceiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ReceiveTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESalesOrderRowNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOERemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOERemark2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DeliveredGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_FollowDeliGoodsDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcceptAnOrderCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectionSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MazdaUOEShipSectCd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOSlipNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MazdaUOEShipSectCd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MazdaUOEShipSectCd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOSlipNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOSlipNo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOManagementNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESubstMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PartsLayerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SourceShipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_LineErrorMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_EOAlwcCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOShipmentCnt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOShipmentCnt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BOShipmentCnt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerFollowCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_UOESectOutGoodsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESupplierName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
    }
}
