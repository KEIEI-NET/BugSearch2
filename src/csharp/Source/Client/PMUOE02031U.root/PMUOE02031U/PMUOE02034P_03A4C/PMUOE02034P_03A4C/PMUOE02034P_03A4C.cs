//****************************************************************************//
// システム         : 送信前リスト
// プログラム名称   : 送信前リスト入力フォーム
// プログラム概要   : 送信前リスト入力フォームを実装します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/09/11  修正内容 : MAHNB02012P_03A4C：入金確認表を参考に新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;

using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 送信前リストの印刷フォームクラス
	/// </summary>
	public class PMUOE02034P_03A4C
    :   DataDynamics.ActiveReports.ActiveReport3,
        IPrintActiveReportTypeList,
        IPrintActiveReportTypeCommon
	{
        #region <Dispose(override)/>

        /// <summary>処分済みフラグ</summary>
        private bool _disposed;

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        /// <param name="disposing">マネージドオブジェクトを処分するフラグ</param>
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        // ヘッダ用サブレポート後処理実行
                        if (_rptExtraHeader != null) _rptExtraHeader.Dispose();

                        // フッタ用サブレポート後処理実行
                        if (_rptPageFooter != null) _rptPageFooter.Dispose();
                    }

                    _disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #endregion  // <Dispose(override)/>

        #region <IPrintActiveReportTypeList メンバ/>

        /// <summary>ソート順（印刷順）</summary>
        private string _pageHeaderSortOderTitle;
        /// <summary>
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary>抽出条件ヘッダ出力区分</summary>
        private int _extraCondHeadOutDiv;
        /// <summary>
        /// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary>抽出条件</summary>
        private StringCollection _extraConditions;
        /// <summary>
        /// 抽出条件ヘッダー項目
        /// </summary>
        public StringCollection ExtraConditions
        {
            set { _extraConditions = value; }
        }

        /// <summary>フッター出力区分</summary>
        private int _pageFooterOutCode;
        /// <summary>
        /// フッター出力区分
        /// </summary>
        public int PageFooterOutCode
        {
            set { _pageFooterOutCode = value; }
        }

        /// <summary>フッターメッセージ</summary>
        private StringCollection _pageFooters;
        /// <summary>
        /// フッタ出力文
        /// </summary>
        public StringCollection PageFooters
        {
            set { _pageFooters = value; }
        }

        /// <summary>印刷情報</summary>
        private SFCMN06002C _printInfo;
        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set { _printInfo = value; }
        }

        /// <summary>その他データ</summary>
        private ArrayList _otherDataList;
        private TextBox printOrderText;
        /// <summary>
        /// その他データ
        /// </summary>
        public ArrayList OtherDataList
        {
            set
            {
                _otherDataList = value;
                if (_otherDataList != null)
                {
                    if (_otherDataList.Count > 0)
                    {
                        // TODO:その他データが設定された場合の処理
                    }
                }
            }
        }

        /// <summary>フォームサブタイトル</summary>
        private string _pageHeaderSubtitle;
        /// <summary>
        /// 帳票サブタイトル
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { _pageHeaderSubtitle = value; }
        }

        /// <summary>
        /// 印刷件数カウントアップイベント
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        #endregion  // <IPrintActiveReportTypeList メンバ/>

        #region <IPrintActiveReportTypeCommon メンバ/>

        /// <summary>
        /// 背景透過設定値プロパティ
        /// </summary>
        public int WatermarkMode
        {
            // TODO:背景透過設定値プロパティのgetter
            get { return 0; }
            // TODO:背景透過設定値プロパティのsetter
            set { }
        }

        #endregion  // <IPrintActiveReportTypeCommon メンバ/>

        #region <発注先別印字/>

        /// <summary>発注先別印字用のタイトル項目のリスト</summary>
        private readonly IList<Label> _titleByUOESupplierCodeList = new List<Label>();
        /// <summary>
        /// 発注先別印字用のタイトル項目のリストを取得します。
        /// </summary>
        /// <value>発注先別印字用のタイトル項目のリスト</value>
        private IList<Label> TitleByUOESupplierCodeList { get { return _titleByUOESupplierCodeList; } }

        /// <summary>発注先別印字用の明細項目のリスト</summary>
        private readonly IList<TextBox> _detailByUOESupplierCodeList = new List<TextBox>();
        /// <summary>
        /// 発注先別印字用の明細項目のリストを取得します。
        /// </summary>
        /// <value>発注先別印字用の明細項目のリスト</value>
        private IList<TextBox> DetailByUOESupplierCodeList { get { return _detailByUOESupplierCodeList; } }

        #endregion  // <発注先別印字/>

        #region <注文番号別印字/>

        /// <summary>印字位置(Y)</summary>
        private const float PRINTING_LOCATION_Y = 0.0F;

        /// <summary>注文番号別印字用のタイトル項目のリスト</summary>
        private readonly IList<Label> _titleByOnlineNoList = new List<Label>();
        private Line line2;
        /// <summary>
        /// 注文番号別印字用のタイトル項目のリストを取得します。
        /// </summary>
        public IList<Label> TitleByOnlineNoList { get { return _titleByOnlineNoList; } }

        /// <summary>注文番号別印字用の明細項目のリスト</summary>
        private readonly IList<TextBox> _detailByOnlineNoList = new List<TextBox>();
        /// <summary>
        /// 注文番号別印字用の明細項目のリストを取得します。
        /// </summary>
        /// <value>注文番号別印字用の明細項目のリスト</value>
        private IList<TextBox> DetailByOnlineNoList { get { return _detailByOnlineNoList; } } 

        /// <summary>
        /// 印刷順が注文番号別か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :注文番号別である。<br/>
        /// <c>false</c>:注文番号別ではない。
        /// </returns>
        private bool IsPrintOrderByOnLineNo()
        {
            return (int.Parse(this.printOrderText.Text)).Equals((int)SendBeforeOrderCondition.PrintOrderType.ByOnlineNo);
        }

        #endregion  // <注文番号別印字/>

        #region <Constructor/>

        /// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public PMUOE02034P_03A4C()
        {
            #region <Designer Code/>

            InitializeComponent();

            #endregion  // <Designer Code/>

            // 発注先別印字用コントロール
            TitleByUOESupplierCodeList.Add(this.uoeSupplierCdLabel);
            TitleByUOESupplierCodeList.Add(this.onlineNoLabel);
            TitleByUOESupplierCodeList.Add(this.customerCodeLabel);
            TitleByUOESupplierCodeList.Add(this.employeeCodeLabel);

            DetailByUOESupplierCodeList.Add(this.uoeSupplierCdText);
            DetailByUOESupplierCodeList.Add(this.uoeSupplierNameText);
            DetailByUOESupplierCodeList.Add(this.onlineNoText);
            DetailByUOESupplierCodeList.Add(this.customerCodeText);
            DetailByUOESupplierCodeList.Add(this.employeeCodeText);

            // 注文番号別印字用コントロール
            TitleByOnlineNoList.Add(this.uoeSupplierCdByOnlineNoLabel);
            TitleByOnlineNoList.Add(this.onlineNoByOnlineNoLabel);
            TitleByOnlineNoList.Add(this.customerCodeByOnlineNoLabel);
            TitleByOnlineNoList.Add(this.employeeCodeByOnlineNoLabel);

            DetailByOnlineNoList.Add(this.uoeSupplierCdByOnlineNoText);
            DetailByOnlineNoList.Add(this.uoeSupplierNameByOnlineNoText);
            DetailByOnlineNoList.Add(this.onlineNoByOnlineNoText);
            DetailByOnlineNoList.Add(this.customerCodeByOnlineNoText);
            DetailByOnlineNoList.Add(this.employeeCodeByOnlineNoText);
        }

        #endregion  // <Constructor/>

        #region <帳票/>

        /// <summary>
		/// 帳票のReportStartイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントパラメータ</param>
		private void PMUOE02034P_03A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// レポート要素出力設定
			SetOfReportMembersOutput();
		}

        /// <summary>
        /// レポートの要素（Header、Footer、Text）の出力設定を行います。
        /// </summary>
        private void SetOfReportMembersOutput()
        {
            // ソート順（印刷順）
            sortOrderNameLabel.Text = _pageHeaderSortOderTitle;
        }

        #endregion  // <帳票/>

        #region <ページヘッダ/>

        /// <summary>
		/// ページヘッダのFormatイベントハンドアラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントパラメータ</param>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
            // 作成日付
            this.printDateText.Text = DateTime.Now.ToString(SendBeforeOrderCondition.PRINT_DATE_FORMAT);

			// 作成時間
            this.printTimeText.Text = DateTime.Now.ToString(SendBeforeOrderCondition.PRINT_TIME_FORMAT);
        }

        #endregion  // <ページヘッダ/>

        #region <抽出条件ヘッダ/>

        // TODO:ヘッダーサブレポート作成用？
        private ListCommon_ExtraHeader _rptExtraHeader;

        /// <summary>
		/// 抽出条件ヘッダのFormatイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントパラメータ</param>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// 抽出条件設定
			// ヘッダ出力制御
			if (_extraCondHeadOutDiv.Equals(0)) // HACK:Magic Number
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
			if (_rptExtraHeader == null)
			{
				_rptExtraHeader = new ListCommon_ExtraHeader();
			}
			else
			{
				// インスタンスが作成されていれば、データソースを初期化する
				// (バインドするデータソースが同じデータであっても、一度初期化してあげないとうまく印刷されない。
				_rptExtraHeader.DataSource = null;
			}

			// 拠点オプション有無判定
            _rptExtraHeader.SectionCondition.Text = "拠点：" + this.sectionCodeText.Text + " " + this.sectionGuideSnmText.Text;
                
			// 抽出条件印字項目設定
			_rptExtraHeader.ExtraConditions = _extraConditions;
			
			this.Header_SubReport.Report = _rptExtraHeader;
        }

        #endregion  // <抽出条件ヘッダ/>

        #region <タイトルヘッダ/>

        /// <summary>
        /// タイトルヘッダのFormatイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            // 注文番号別のフォーマット設定
            if (IsPrintOrderByOnLineNo())
            {
                // 発注先別印字用のタイトルを隠す
                foreach (Label titleLabel in TitleByUOESupplierCodeList)
                {
                    titleLabel.Visible = false;
                }
                // 注文番号別印字用のタイトルを表示
                foreach (Label titleLabel in TitleByOnlineNoList)
                {
                    titleLabel.Visible = true;
                    float x = titleLabel.Location.X;
                    titleLabel.Location = new System.Drawing.PointF(x, PRINTING_LOCATION_Y);
                }
            }
            // MEMO:フォーマットのデフォルトは発注先別にレイアウトされています。
        }

        #endregion  // <タイトルヘッダ/>

        #region <明細/>

        /// <summary>ページ数のカウンタ</summary>
        private int _printCount;

        #region <明細のGrキー/>

        /// <summary>現在の明細のGrキー</summary>
        private string _currentDetailGroupKey;
        /// <summary>
        /// 現在の明細のGrキーのアクセサ
        /// </summary>
        /// <value>現在の明細のGrキー</value>
        private string CurrentDetailGroupKey
        {
            get { return _currentDetailGroupKey; }
            set { _currentDetailGroupKey = value; }
        }

        /// <summary>
        /// 明細のGrキーを取得します。
        /// </summary>
        /// <returns>明細のGrキー</returns>
        private string GetDetailGroupKey()
        {
            StringBuilder detailGroupKey = new StringBuilder();

            detailGroupKey.Append(this.sectionCodeText.Text);   // 拠点コード
            detailGroupKey.Append(this.uoeSupplierCdText.Text); // 発注先
            detailGroupKey.Append(this.onlineNoText.Text);      // 注文番号
            detailGroupKey.Append(this.customerCodeText.Text);  // 得意先
            detailGroupKey.Append(this.employeeCodeText.Text);  // 依頼者

            return detailGroupKey.ToString();
        }

        #endregion  // <明細のGrキー/>

        /// <summary>
		/// 明細のBeforePrintイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントパラメータ</param>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
			PrintCommonLibrary.ConvertReportString(this.Detail);
		}

        /// <summary>
        /// 明細のFormatイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void Detail_Format(object sender, EventArgs e)
        {
            // 注文番号別のフォーマット設定
            if (IsPrintOrderByOnLineNo())
            {
                // 発注先別印字用の明細を隠す
                foreach (TextBox detailText in DetailByUOESupplierCodeList)
                {
                    detailText.Visible = false;
                }
                // 注文番号別印字用の明細を表示
                foreach (TextBox detailText in DetailByOnlineNoList)
                {
                    detailText.Visible = true;
                    float x = detailText.Location.X;
                    detailText.Location = new System.Drawing.PointF(x, PRINTING_LOCATION_Y);
                }
            }
            // MEMO:フォーマットのデフォルトは発注先別にレイアウトされています。

            // 重複する項目（明細のGrキーが同じ）は表示しない
            bool visible = true;
            string detailGroupKey = GetDetailGroupKey();
            if (detailGroupKey.Equals(CurrentDetailGroupKey))
            {
                visible = false;
            }

            if (IsPrintOrderByOnLineNo())
            {
                // 注文番号別印字用の明細を隠す
                foreach (TextBox detailText in DetailByOnlineNoList)
                {
                    detailText.Visible = visible;
                }
            }
            else
            {
                // 発注先別印字用の明細を隠す
                foreach (TextBox detailText in DetailByUOESupplierCodeList)
                {
                    detailText.Visible = visible;
                }
            }

            CurrentDetailGroupKey = detailGroupKey;
        }

		/// <summary>
		/// 明細のAfterPrintイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントパラメータ</param>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			_printCount++;
			
			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, _printCount);
			}
		}

		#endregion  // <明細/>

		#region <ページフッタ/>

        // TODO:フッターサブレポート作成用？
        private ListCommon_PageFooter _rptPageFooter;

        // TODO:フッタのサブレポート用？
		/// <summary>
		/// ページフッタのFormatイベントハンドラ
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="eArgs">イベントパラメータ</param>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // フッター出力する？
            if (_pageFooterOutCode.Equals(0))  // HACK:Magic Number
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
                if (_pageFooters[0] != null)
                {
                    _rptPageFooter.PrintFooter1 = _pageFooters[0];
                }
                if (_pageFooters[1] != null)
                {
                    _rptPageFooter.PrintFooter2 = _pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }

        #endregion  // <ページフッタ/>



        #region <Designer Code/>

        private TextBox sectionGuideSnmText;
        private Label uoeSupplierCdLabel;
        private Label onlineNoLabel;
        private Label customerCodeLabel;
        private Label goodsMakerCdLabel;
        private Label boCodeLabel;
        private Label uoeRemark1Label;
        private Line TitleHeader_Line2;
        private Label acceptAnOrderCntLabel;
        private Label uoeRemark2Label;
        private TextBox goodsMakerCdText;
        private TextBox boCodeText;
        private TextBox uoeRemark1Text;
        private TextBox uoeSupplierCdText;
        private TextBox onlineNoText;
        private TextBox customerCodeText;
        private TextBox acceptAnOrderCntText;
        private TextBox uoeRemark2Text;
        private TextBox MONEYKINDNAME13;
        private Label Label109;
        private TextBox uoeSupplierNameText;
        private TextBox employeeCodeText;
        private Label employeeCodeLabel;
        private TextBox goodsNoText;
        private Label goodsNolabel;
        private TextBox goodsNameText;
        private Label goodsNameLabel;
        private Label uoeDeliGoodsDivLabel;
        private TextBox uoeDeliGoodsDivText;
        private TextBox followDeliGoodsDivText;
        private Label followDeliGoodsDivLabel;
        private Label uoeResvdSectionLabel;
        private TextBox uoeResvdSectionText;
        private TextBox onlineNoByOnlineNoText;
        private Label onlineNoByOnlineNoLabel;
        private TextBox customerCodeByOnlineNoText;
        private Label customerCodeByOnlineNoLabel;
        private Label employeeCodeByOnlineNoLabel;
        private TextBox employeeCodeByOnlineNoText;
        private TextBox uoeSupplierCdByOnlineNoText;
        private TextBox uoeSupplierNameByOnlineNoText;
        private Label uoeSupplierCdByOnlineNoLabel;

        #endregion  // <Designer Code/>

        #region ActiveReports Designer generated code

        private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label reportTitleLabel;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox sortOrderNameLabel;
		private DataDynamics.ActiveReports.Label printDateTimeLabel;
		private DataDynamics.ActiveReports.TextBox printDateText;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.TextBox printTimeText;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.TextBox sectionCodeText;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.Line Line13;
        private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// コンポーネントを初期化します。
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE02034P_03A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.goodsMakerCdText = new DataDynamics.ActiveReports.TextBox();
            this.boCodeText = new DataDynamics.ActiveReports.TextBox();
            this.uoeRemark1Text = new DataDynamics.ActiveReports.TextBox();
            this.uoeSupplierCdText = new DataDynamics.ActiveReports.TextBox();
            this.onlineNoText = new DataDynamics.ActiveReports.TextBox();
            this.customerCodeText = new DataDynamics.ActiveReports.TextBox();
            this.acceptAnOrderCntText = new DataDynamics.ActiveReports.TextBox();
            this.uoeRemark2Text = new DataDynamics.ActiveReports.TextBox();
            this.uoeSupplierNameText = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.employeeCodeText = new DataDynamics.ActiveReports.TextBox();
            this.goodsNoText = new DataDynamics.ActiveReports.TextBox();
            this.goodsNameText = new DataDynamics.ActiveReports.TextBox();
            this.uoeDeliGoodsDivText = new DataDynamics.ActiveReports.TextBox();
            this.followDeliGoodsDivText = new DataDynamics.ActiveReports.TextBox();
            this.uoeResvdSectionText = new DataDynamics.ActiveReports.TextBox();
            this.onlineNoByOnlineNoText = new DataDynamics.ActiveReports.TextBox();
            this.customerCodeByOnlineNoText = new DataDynamics.ActiveReports.TextBox();
            this.employeeCodeByOnlineNoText = new DataDynamics.ActiveReports.TextBox();
            this.uoeSupplierCdByOnlineNoText = new DataDynamics.ActiveReports.TextBox();
            this.uoeSupplierNameByOnlineNoText = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.reportTitleLabel = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.sortOrderNameLabel = new DataDynamics.ActiveReports.TextBox();
            this.printDateTimeLabel = new DataDynamics.ActiveReports.Label();
            this.printDateText = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.printTimeText = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.uoeSupplierCdLabel = new DataDynamics.ActiveReports.Label();
            this.onlineNoLabel = new DataDynamics.ActiveReports.Label();
            this.customerCodeLabel = new DataDynamics.ActiveReports.Label();
            this.goodsMakerCdLabel = new DataDynamics.ActiveReports.Label();
            this.boCodeLabel = new DataDynamics.ActiveReports.Label();
            this.uoeRemark1Label = new DataDynamics.ActiveReports.Label();
            this.TitleHeader_Line2 = new DataDynamics.ActiveReports.Line();
            this.acceptAnOrderCntLabel = new DataDynamics.ActiveReports.Label();
            this.uoeRemark2Label = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.employeeCodeLabel = new DataDynamics.ActiveReports.Label();
            this.goodsNolabel = new DataDynamics.ActiveReports.Label();
            this.goodsNameLabel = new DataDynamics.ActiveReports.Label();
            this.uoeDeliGoodsDivLabel = new DataDynamics.ActiveReports.Label();
            this.followDeliGoodsDivLabel = new DataDynamics.ActiveReports.Label();
            this.uoeResvdSectionLabel = new DataDynamics.ActiveReports.Label();
            this.onlineNoByOnlineNoLabel = new DataDynamics.ActiveReports.Label();
            this.customerCodeByOnlineNoLabel = new DataDynamics.ActiveReports.Label();
            this.employeeCodeByOnlineNoLabel = new DataDynamics.ActiveReports.Label();
            this.uoeSupplierCdByOnlineNoLabel = new DataDynamics.ActiveReports.Label();
            this.printOrderText = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.sectionCodeText = new DataDynamics.ActiveReports.TextBox();
            this.sectionGuideSnmText = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.goodsMakerCdText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boCodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark1Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceptAnOrderCntText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark2Text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierNameText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNameText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeDeliGoodsDivText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDeliGoodsDivText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeResvdSectionText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoByOnlineNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeByOnlineNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeByOnlineNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdByOnlineNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierNameByOnlineNoText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportTitleLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortOrderNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printDateTimeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printDateText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printTimeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsMakerCdLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boCodeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark1Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceptAnOrderCntLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark2Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNolabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeDeliGoodsDivLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDeliGoodsDivLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeResvdSectionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoByOnlineNoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeByOnlineNoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeByOnlineNoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdByOnlineNoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printOrderText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionCodeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionGuideSnmText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line13,
            this.goodsMakerCdText,
            this.boCodeText,
            this.uoeRemark1Text,
            this.uoeSupplierCdText,
            this.onlineNoText,
            this.customerCodeText,
            this.acceptAnOrderCntText,
            this.uoeRemark2Text,
            this.uoeSupplierNameText,
            this.Line37,
            this.employeeCodeText,
            this.goodsNoText,
            this.goodsNameText,
            this.uoeDeliGoodsDivText,
            this.followDeliGoodsDivText,
            this.uoeResvdSectionText,
            this.onlineNoByOnlineNoText,
            this.customerCodeByOnlineNoText,
            this.employeeCodeByOnlineNoText,
            this.uoeSupplierCdByOnlineNoText,
            this.uoeSupplierNameByOnlineNoText});
            this.Detail.Height = 0.4791667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
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
            // goodsMakerCdText
            // 
            this.goodsMakerCdText.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsMakerCdText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdText.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsMakerCdText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdText.Border.RightColor = System.Drawing.Color.Black;
            this.goodsMakerCdText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdText.Border.TopColor = System.Drawing.Color.Black;
            this.goodsMakerCdText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdText.DataField = "GoodsMakerCd";
            this.goodsMakerCdText.Height = 0.125F;
            this.goodsMakerCdText.Left = 7F;
            this.goodsMakerCdText.MultiLine = false;
            this.goodsMakerCdText.Name = "goodsMakerCdText";
            this.goodsMakerCdText.OutputFormat = resources.GetString("goodsMakerCdText.OutputFormat");
            this.goodsMakerCdText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.goodsMakerCdText.Text = "0000";
            this.goodsMakerCdText.Top = 0F;
            this.goodsMakerCdText.Width = 0.3F;
            // 
            // boCodeText
            // 
            this.boCodeText.Border.BottomColor = System.Drawing.Color.Black;
            this.boCodeText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeText.Border.LeftColor = System.Drawing.Color.Black;
            this.boCodeText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeText.Border.RightColor = System.Drawing.Color.Black;
            this.boCodeText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeText.Border.TopColor = System.Drawing.Color.Black;
            this.boCodeText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeText.DataField = "BoCode";
            this.boCodeText.Height = 0.125F;
            this.boCodeText.Left = 7.6F;
            this.boCodeText.MultiLine = false;
            this.boCodeText.Name = "boCodeText";
            this.boCodeText.OutputFormat = resources.GetString("boCodeText.OutputFormat");
            this.boCodeText.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.boCodeText.Text = "9";
            this.boCodeText.Top = 0F;
            this.boCodeText.Width = 0.25F;
            // 
            // uoeRemark1Text
            // 
            this.uoeRemark1Text.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeRemark1Text.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Text.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeRemark1Text.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Text.Border.RightColor = System.Drawing.Color.Black;
            this.uoeRemark1Text.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Text.Border.TopColor = System.Drawing.Color.Black;
            this.uoeRemark1Text.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Text.DataField = "UoeRemark1";
            this.uoeRemark1Text.Height = 0.125F;
            this.uoeRemark1Text.Left = 8F;
            this.uoeRemark1Text.MultiLine = false;
            this.uoeRemark1Text.Name = "uoeRemark1Text";
            this.uoeRemark1Text.OutputFormat = resources.GetString("uoeRemark1Text.OutputFormat");
            this.uoeRemark1Text.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.uoeRemark1Text.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.uoeRemark1Text.Top = 0F;
            this.uoeRemark1Text.Width = 1.15F;
            // 
            // uoeSupplierCdText
            // 
            this.uoeSupplierCdText.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeSupplierCdText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdText.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeSupplierCdText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdText.Border.RightColor = System.Drawing.Color.Black;
            this.uoeSupplierCdText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdText.Border.TopColor = System.Drawing.Color.Black;
            this.uoeSupplierCdText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdText.DataField = "UOESupplierCd";
            this.uoeSupplierCdText.Height = 0.125F;
            this.uoeSupplierCdText.Left = 0F;
            this.uoeSupplierCdText.MultiLine = false;
            this.uoeSupplierCdText.Name = "uoeSupplierCdText";
            this.uoeSupplierCdText.OutputFormat = resources.GetString("uoeSupplierCdText.OutputFormat");
            this.uoeSupplierCdText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.uoeSupplierCdText.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.uoeSupplierCdText.Text = "123456";
            this.uoeSupplierCdText.Top = 0F;
            this.uoeSupplierCdText.Width = 0.4F;
            // 
            // onlineNoText
            // 
            this.onlineNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.onlineNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.onlineNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoText.Border.RightColor = System.Drawing.Color.Black;
            this.onlineNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoText.Border.TopColor = System.Drawing.Color.Black;
            this.onlineNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoText.DataField = "OnlineNo";
            this.onlineNoText.Height = 0.125F;
            this.onlineNoText.Left = 2.75F;
            this.onlineNoText.MultiLine = false;
            this.onlineNoText.Name = "onlineNoText";
            this.onlineNoText.OutputFormat = resources.GetString("onlineNoText.OutputFormat");
            this.onlineNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.onlineNoText.Text = "123456789";
            this.onlineNoText.Top = 0F;
            this.onlineNoText.Width = 0.5625F;
            // 
            // customerCodeText
            // 
            this.customerCodeText.Border.BottomColor = System.Drawing.Color.Black;
            this.customerCodeText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeText.Border.LeftColor = System.Drawing.Color.Black;
            this.customerCodeText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeText.Border.RightColor = System.Drawing.Color.Black;
            this.customerCodeText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeText.Border.TopColor = System.Drawing.Color.Black;
            this.customerCodeText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeText.DataField = "CustomerCode";
            this.customerCodeText.Height = 0.125F;
            this.customerCodeText.Left = 3.3125F;
            this.customerCodeText.MultiLine = false;
            this.customerCodeText.Name = "customerCodeText";
            this.customerCodeText.OutputFormat = resources.GetString("customerCodeText.OutputFormat");
            this.customerCodeText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.customerCodeText.Text = "12345678";
            this.customerCodeText.Top = 0F;
            this.customerCodeText.Width = 0.5F;
            // 
            // acceptAnOrderCntText
            // 
            this.acceptAnOrderCntText.Border.BottomColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntText.Border.LeftColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntText.Border.RightColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntText.Border.TopColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntText.DataField = "AcceptAnOrderCnt";
            this.acceptAnOrderCntText.Height = 0.125F;
            this.acceptAnOrderCntText.Left = 7.3F;
            this.acceptAnOrderCntText.MultiLine = false;
            this.acceptAnOrderCntText.Name = "acceptAnOrderCntText";
            this.acceptAnOrderCntText.OutputFormat = resources.GetString("acceptAnOrderCntText.OutputFormat");
            this.acceptAnOrderCntText.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.acceptAnOrderCntText.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.acceptAnOrderCntText.Text = "9999";
            this.acceptAnOrderCntText.Top = 0F;
            this.acceptAnOrderCntText.Width = 0.3125F;
            // 
            // uoeRemark2Text
            // 
            this.uoeRemark2Text.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeRemark2Text.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Text.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeRemark2Text.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Text.Border.RightColor = System.Drawing.Color.Black;
            this.uoeRemark2Text.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Text.Border.TopColor = System.Drawing.Color.Black;
            this.uoeRemark2Text.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Text.DataField = "UoeRemark2";
            this.uoeRemark2Text.Height = 0.125F;
            this.uoeRemark2Text.Left = 9.3F;
            this.uoeRemark2Text.MultiLine = false;
            this.uoeRemark2Text.Name = "uoeRemark2Text";
            this.uoeRemark2Text.OutputFormat = resources.GetString("uoeRemark2Text.OutputFormat");
            this.uoeRemark2Text.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.uoeRemark2Text.Text = "XXXXXXXXXX";
            this.uoeRemark2Text.Top = 0F;
            this.uoeRemark2Text.Width = 0.6F;
            // 
            // uoeSupplierNameText
            // 
            this.uoeSupplierNameText.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeSupplierNameText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameText.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeSupplierNameText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameText.Border.RightColor = System.Drawing.Color.Black;
            this.uoeSupplierNameText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameText.Border.TopColor = System.Drawing.Color.Black;
            this.uoeSupplierNameText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameText.DataField = "UOESupplierName";
            this.uoeSupplierNameText.Height = 0.125F;
            this.uoeSupplierNameText.Left = 0.4375F;
            this.uoeSupplierNameText.MultiLine = false;
            this.uoeSupplierNameText.Name = "uoeSupplierNameText";
            this.uoeSupplierNameText.OutputFormat = resources.GetString("uoeSupplierNameText.OutputFormat");
            this.uoeSupplierNameText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.uoeSupplierNameText.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.uoeSupplierNameText.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ";
            this.uoeSupplierNameText.Top = 0F;
            this.uoeSupplierNameText.Width = 2.3F;
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
            this.Line37.Width = 10.8125F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8125F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // employeeCodeText
            // 
            this.employeeCodeText.Border.BottomColor = System.Drawing.Color.Black;
            this.employeeCodeText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeText.Border.LeftColor = System.Drawing.Color.Black;
            this.employeeCodeText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeText.Border.RightColor = System.Drawing.Color.Black;
            this.employeeCodeText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeText.Border.TopColor = System.Drawing.Color.Black;
            this.employeeCodeText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeText.DataField = "EmployeeCode";
            this.employeeCodeText.Height = 0.125F;
            this.employeeCodeText.Left = 3.8125F;
            this.employeeCodeText.MultiLine = false;
            this.employeeCodeText.Name = "employeeCodeText";
            this.employeeCodeText.OutputFormat = resources.GetString("employeeCodeText.OutputFormat");
            this.employeeCodeText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employeeCodeText.Text = "1234";
            this.employeeCodeText.Top = 0F;
            this.employeeCodeText.Width = 0.4F;
            // 
            // goodsNoText
            // 
            this.goodsNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNoText.Border.RightColor = System.Drawing.Color.Black;
            this.goodsNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNoText.Border.TopColor = System.Drawing.Color.Black;
            this.goodsNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNoText.DataField = "GoodsNo";
            this.goodsNoText.Height = 0.125F;
            this.goodsNoText.Left = 4.3125F;
            this.goodsNoText.MultiLine = false;
            this.goodsNoText.Name = "goodsNoText";
            this.goodsNoText.OutputFormat = resources.GetString("goodsNoText.OutputFormat");
            this.goodsNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.goodsNoText.Text = "123456789012345678901234";
            this.goodsNoText.Top = 0F;
            this.goodsNoText.Width = 1.38F;
            // 
            // goodsNameText
            // 
            this.goodsNameText.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsNameText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameText.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsNameText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameText.Border.RightColor = System.Drawing.Color.Black;
            this.goodsNameText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameText.Border.TopColor = System.Drawing.Color.Black;
            this.goodsNameText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameText.DataField = "GoodsName";
            this.goodsNameText.Height = 0.125F;
            this.goodsNameText.Left = 5.8F;
            this.goodsNameText.MultiLine = false;
            this.goodsNameText.Name = "goodsNameText";
            this.goodsNameText.OutputFormat = resources.GetString("goodsNameText.OutputFormat");
            this.goodsNameText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.goodsNameText.Text = "XXXXXXXXXXXXXXXXXXXX";
            this.goodsNameText.Top = 0F;
            this.goodsNameText.Width = 1.15F;
            // 
            // uoeDeliGoodsDivText
            // 
            this.uoeDeliGoodsDivText.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivText.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivText.Border.RightColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivText.Border.TopColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivText.DataField = "UOEDeliGoodsDiv";
            this.uoeDeliGoodsDivText.Height = 0.125F;
            this.uoeDeliGoodsDivText.Left = 10F;
            this.uoeDeliGoodsDivText.MultiLine = false;
            this.uoeDeliGoodsDivText.Name = "uoeDeliGoodsDivText";
            this.uoeDeliGoodsDivText.OutputFormat = resources.GetString("uoeDeliGoodsDivText.OutputFormat");
            this.uoeDeliGoodsDivText.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.uoeDeliGoodsDivText.Text = "9";
            this.uoeDeliGoodsDivText.Top = 0F;
            this.uoeDeliGoodsDivText.Width = 0.25F;
            // 
            // followDeliGoodsDivText
            // 
            this.followDeliGoodsDivText.Border.BottomColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivText.Border.LeftColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivText.Border.RightColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivText.Border.TopColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivText.DataField = "FollowDeliGoodsDiv";
            this.followDeliGoodsDivText.Height = 0.125F;
            this.followDeliGoodsDivText.Left = 10.25F;
            this.followDeliGoodsDivText.MultiLine = false;
            this.followDeliGoodsDivText.Name = "followDeliGoodsDivText";
            this.followDeliGoodsDivText.OutputFormat = resources.GetString("followDeliGoodsDivText.OutputFormat");
            this.followDeliGoodsDivText.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.followDeliGoodsDivText.Text = "9";
            this.followDeliGoodsDivText.Top = 0F;
            this.followDeliGoodsDivText.Width = 0.25F;
            // 
            // uoeResvdSectionText
            // 
            this.uoeResvdSectionText.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeResvdSectionText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionText.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeResvdSectionText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionText.Border.RightColor = System.Drawing.Color.Black;
            this.uoeResvdSectionText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionText.Border.TopColor = System.Drawing.Color.Black;
            this.uoeResvdSectionText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionText.DataField = "UOEResvdSection";
            this.uoeResvdSectionText.Height = 0.125F;
            this.uoeResvdSectionText.Left = 10.5F;
            this.uoeResvdSectionText.MultiLine = false;
            this.uoeResvdSectionText.Name = "uoeResvdSectionText";
            this.uoeResvdSectionText.OutputFormat = resources.GetString("uoeResvdSectionText.OutputFormat");
            this.uoeResvdSectionText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.uoeResvdSectionText.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.uoeResvdSectionText.Text = "999";
            this.uoeResvdSectionText.Top = 0F;
            this.uoeResvdSectionText.Width = 0.3F;
            // 
            // onlineNoByOnlineNoText
            // 
            this.onlineNoByOnlineNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoText.Border.RightColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoText.Border.TopColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoText.DataField = "OnlineNo";
            this.onlineNoByOnlineNoText.Height = 0.125F;
            this.onlineNoByOnlineNoText.Left = 0F;
            this.onlineNoByOnlineNoText.MultiLine = false;
            this.onlineNoByOnlineNoText.Name = "onlineNoByOnlineNoText";
            this.onlineNoByOnlineNoText.OutputFormat = resources.GetString("onlineNoByOnlineNoText.OutputFormat");
            this.onlineNoByOnlineNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.onlineNoByOnlineNoText.Text = "123456789";
            this.onlineNoByOnlineNoText.Top = 0.3125F;
            this.onlineNoByOnlineNoText.Visible = false;
            this.onlineNoByOnlineNoText.Width = 0.5625F;
            // 
            // customerCodeByOnlineNoText
            // 
            this.customerCodeByOnlineNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoText.Border.RightColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoText.Border.TopColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoText.DataField = "CustomerCode";
            this.customerCodeByOnlineNoText.Height = 0.125F;
            this.customerCodeByOnlineNoText.Left = 0.5625F;
            this.customerCodeByOnlineNoText.MultiLine = false;
            this.customerCodeByOnlineNoText.Name = "customerCodeByOnlineNoText";
            this.customerCodeByOnlineNoText.OutputFormat = resources.GetString("customerCodeByOnlineNoText.OutputFormat");
            this.customerCodeByOnlineNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.customerCodeByOnlineNoText.Text = "12345678";
            this.customerCodeByOnlineNoText.Top = 0.3125F;
            this.customerCodeByOnlineNoText.Visible = false;
            this.customerCodeByOnlineNoText.Width = 0.5F;
            // 
            // employeeCodeByOnlineNoText
            // 
            this.employeeCodeByOnlineNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoText.Border.RightColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoText.Border.TopColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoText.DataField = "EmployeeCode";
            this.employeeCodeByOnlineNoText.Height = 0.125F;
            this.employeeCodeByOnlineNoText.Left = 1.0625F;
            this.employeeCodeByOnlineNoText.MultiLine = false;
            this.employeeCodeByOnlineNoText.Name = "employeeCodeByOnlineNoText";
            this.employeeCodeByOnlineNoText.OutputFormat = resources.GetString("employeeCodeByOnlineNoText.OutputFormat");
            this.employeeCodeByOnlineNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.employeeCodeByOnlineNoText.Text = "1234";
            this.employeeCodeByOnlineNoText.Top = 0.3125F;
            this.employeeCodeByOnlineNoText.Visible = false;
            this.employeeCodeByOnlineNoText.Width = 0.4F;
            // 
            // uoeSupplierCdByOnlineNoText
            // 
            this.uoeSupplierCdByOnlineNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoText.Border.RightColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoText.Border.TopColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoText.DataField = "UOESupplierCd";
            this.uoeSupplierCdByOnlineNoText.Height = 0.125F;
            this.uoeSupplierCdByOnlineNoText.Left = 1.5F;
            this.uoeSupplierCdByOnlineNoText.MultiLine = false;
            this.uoeSupplierCdByOnlineNoText.Name = "uoeSupplierCdByOnlineNoText";
            this.uoeSupplierCdByOnlineNoText.OutputFormat = resources.GetString("uoeSupplierCdByOnlineNoText.OutputFormat");
            this.uoeSupplierCdByOnlineNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; vertic" +
                "al-align: top; ";
            this.uoeSupplierCdByOnlineNoText.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.uoeSupplierCdByOnlineNoText.Text = "123456";
            this.uoeSupplierCdByOnlineNoText.Top = 0.3125F;
            this.uoeSupplierCdByOnlineNoText.Visible = false;
            this.uoeSupplierCdByOnlineNoText.Width = 0.4F;
            // 
            // uoeSupplierNameByOnlineNoText
            // 
            this.uoeSupplierNameByOnlineNoText.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeSupplierNameByOnlineNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameByOnlineNoText.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeSupplierNameByOnlineNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameByOnlineNoText.Border.RightColor = System.Drawing.Color.Black;
            this.uoeSupplierNameByOnlineNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameByOnlineNoText.Border.TopColor = System.Drawing.Color.Black;
            this.uoeSupplierNameByOnlineNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierNameByOnlineNoText.DataField = "UOESupplierName";
            this.uoeSupplierNameByOnlineNoText.Height = 0.125F;
            this.uoeSupplierNameByOnlineNoText.Left = 1.9375F;
            this.uoeSupplierNameByOnlineNoText.MultiLine = false;
            this.uoeSupplierNameByOnlineNoText.Name = "uoeSupplierNameByOnlineNoText";
            this.uoeSupplierNameByOnlineNoText.OutputFormat = resources.GetString("uoeSupplierNameByOnlineNoText.OutputFormat");
            this.uoeSupplierNameByOnlineNoText.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.uoeSupplierNameByOnlineNoText.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.uoeSupplierNameByOnlineNoText.Text = "ＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮＮ";
            this.uoeSupplierNameByOnlineNoText.Top = 0.3125F;
            this.uoeSupplierNameByOnlineNoText.Visible = false;
            this.uoeSupplierNameByOnlineNoText.Width = 2.3F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportTitleLabel,
            this.Line1,
            this.sortOrderNameLabel,
            this.printDateTimeLabel,
            this.printDateText,
            this.Label4,
            this.tb_PrintPage,
            this.printTimeText});
            this.PageHeader.Height = 0.6354167F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // reportTitleLabel
            // 
            this.reportTitleLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.reportTitleLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.reportTitleLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.reportTitleLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.reportTitleLabel.Border.RightColor = System.Drawing.Color.Black;
            this.reportTitleLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.reportTitleLabel.Border.TopColor = System.Drawing.Color.Black;
            this.reportTitleLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.reportTitleLabel.Height = 0.21875F;
            this.reportTitleLabel.HyperLink = "";
            this.reportTitleLabel.Left = 0.21875F;
            this.reportTitleLabel.MultiLine = false;
            this.reportTitleLabel.Name = "reportTitleLabel";
            this.reportTitleLabel.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: ＭＳ 明朝; vertical-align: middle; ";
            this.reportTitleLabel.Text = "送信前リスト";
            this.reportTitleLabel.Top = 0F;
            this.reportTitleLabel.Width = 2.78125F;
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
            // sortOrderNameLabel
            // 
            this.sortOrderNameLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.sortOrderNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sortOrderNameLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.sortOrderNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sortOrderNameLabel.Border.RightColor = System.Drawing.Color.Black;
            this.sortOrderNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sortOrderNameLabel.Border.TopColor = System.Drawing.Color.Black;
            this.sortOrderNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sortOrderNameLabel.CanShrink = true;
            this.sortOrderNameLabel.Height = 0.15625F;
            this.sortOrderNameLabel.Left = 3.063F;
            this.sortOrderNameLabel.MultiLine = false;
            this.sortOrderNameLabel.Name = "sortOrderNameLabel";
            this.sortOrderNameLabel.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.sortOrderNameLabel.Text = "[ソート条件]";
            this.sortOrderNameLabel.Top = 0.063F;
            this.sortOrderNameLabel.Visible = false;
            this.sortOrderNameLabel.Width = 2.1875F;
            // 
            // printDateTimeLabel
            // 
            this.printDateTimeLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.printDateTimeLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateTimeLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.printDateTimeLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateTimeLabel.Border.RightColor = System.Drawing.Color.Black;
            this.printDateTimeLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateTimeLabel.Border.TopColor = System.Drawing.Color.Black;
            this.printDateTimeLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateTimeLabel.Height = 0.15625F;
            this.printDateTimeLabel.HyperLink = "";
            this.printDateTimeLabel.Left = 7.9375F;
            this.printDateTimeLabel.MultiLine = false;
            this.printDateTimeLabel.Name = "printDateTimeLabel";
            this.printDateTimeLabel.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.printDateTimeLabel.Text = "作成日付：";
            this.printDateTimeLabel.Top = 0.0625F;
            this.printDateTimeLabel.Width = 0.625F;
            // 
            // printDateText
            // 
            this.printDateText.Border.BottomColor = System.Drawing.Color.Black;
            this.printDateText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateText.Border.LeftColor = System.Drawing.Color.Black;
            this.printDateText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateText.Border.RightColor = System.Drawing.Color.Black;
            this.printDateText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateText.Border.TopColor = System.Drawing.Color.Black;
            this.printDateText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printDateText.CanShrink = true;
            this.printDateText.Height = 0.15625F;
            this.printDateText.Left = 8.5F;
            this.printDateText.MultiLine = false;
            this.printDateText.Name = "printDateText";
            this.printDateText.OutputFormat = resources.GetString("printDateText.OutputFormat");
            this.printDateText.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.printDateText.Text = "平成17年11月 5日";
            this.printDateText.Top = 0.0625F;
            this.printDateText.Width = 0.9375F;
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
            // printTimeText
            // 
            this.printTimeText.Border.BottomColor = System.Drawing.Color.Black;
            this.printTimeText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printTimeText.Border.LeftColor = System.Drawing.Color.Black;
            this.printTimeText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printTimeText.Border.RightColor = System.Drawing.Color.Black;
            this.printTimeText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printTimeText.Border.TopColor = System.Drawing.Color.Black;
            this.printTimeText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printTimeText.Height = 0.125F;
            this.printTimeText.Left = 9.4375F;
            this.printTimeText.Name = "printTimeText";
            this.printTimeText.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.printTimeText.Text = "11時20分";
            this.printTimeText.Top = 0.0625F;
            this.printTimeText.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.01041667F;
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
            this.Footer_SubReport.Height = 0.25F;
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
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.uoeSupplierCdLabel,
            this.onlineNoLabel,
            this.customerCodeLabel,
            this.goodsMakerCdLabel,
            this.boCodeLabel,
            this.uoeRemark1Label,
            this.TitleHeader_Line2,
            this.acceptAnOrderCntLabel,
            this.uoeRemark2Label,
            this.Line42,
            this.employeeCodeLabel,
            this.goodsNolabel,
            this.goodsNameLabel,
            this.uoeDeliGoodsDivLabel,
            this.followDeliGoodsDivLabel,
            this.uoeResvdSectionLabel,
            this.onlineNoByOnlineNoLabel,
            this.customerCodeByOnlineNoLabel,
            this.employeeCodeByOnlineNoLabel,
            this.uoeSupplierCdByOnlineNoLabel,
            this.printOrderText});
            this.TitleHeader.Height = 0.4583333F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // uoeSupplierCdLabel
            // 
            this.uoeSupplierCdLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeSupplierCdLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeSupplierCdLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdLabel.Border.RightColor = System.Drawing.Color.Black;
            this.uoeSupplierCdLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdLabel.Border.TopColor = System.Drawing.Color.Black;
            this.uoeSupplierCdLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdLabel.Height = 0.125F;
            this.uoeSupplierCdLabel.HyperLink = "";
            this.uoeSupplierCdLabel.Left = 0F;
            this.uoeSupplierCdLabel.MultiLine = false;
            this.uoeSupplierCdLabel.Name = "uoeSupplierCdLabel";
            this.uoeSupplierCdLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.uoeSupplierCdLabel.Text = "発注先";
            this.uoeSupplierCdLabel.Top = 0F;
            this.uoeSupplierCdLabel.Width = 0.4F;
            // 
            // onlineNoLabel
            // 
            this.onlineNoLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.onlineNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.onlineNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoLabel.Border.RightColor = System.Drawing.Color.Black;
            this.onlineNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoLabel.Border.TopColor = System.Drawing.Color.Black;
            this.onlineNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoLabel.Height = 0.125F;
            this.onlineNoLabel.HyperLink = "";
            this.onlineNoLabel.Left = 2.75F;
            this.onlineNoLabel.MultiLine = false;
            this.onlineNoLabel.Name = "onlineNoLabel";
            this.onlineNoLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.onlineNoLabel.Text = "注文番号";
            this.onlineNoLabel.Top = 0F;
            this.onlineNoLabel.Width = 0.563F;
            // 
            // customerCodeLabel
            // 
            this.customerCodeLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.customerCodeLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.customerCodeLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeLabel.Border.RightColor = System.Drawing.Color.Black;
            this.customerCodeLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeLabel.Border.TopColor = System.Drawing.Color.Black;
            this.customerCodeLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeLabel.Height = 0.125F;
            this.customerCodeLabel.HyperLink = "";
            this.customerCodeLabel.Left = 3.313F;
            this.customerCodeLabel.MultiLine = false;
            this.customerCodeLabel.Name = "customerCodeLabel";
            this.customerCodeLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.customerCodeLabel.Text = "得意先";
            this.customerCodeLabel.Top = 0F;
            this.customerCodeLabel.Width = 0.5F;
            // 
            // goodsMakerCdLabel
            // 
            this.goodsMakerCdLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsMakerCdLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsMakerCdLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdLabel.Border.RightColor = System.Drawing.Color.Black;
            this.goodsMakerCdLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdLabel.Border.TopColor = System.Drawing.Color.Black;
            this.goodsMakerCdLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsMakerCdLabel.Height = 0.125F;
            this.goodsMakerCdLabel.HyperLink = "";
            this.goodsMakerCdLabel.Left = 7F;
            this.goodsMakerCdLabel.MultiLine = false;
            this.goodsMakerCdLabel.Name = "goodsMakerCdLabel";
            this.goodsMakerCdLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.goodsMakerCdLabel.Text = "ﾒｰｶｰ";
            this.goodsMakerCdLabel.Top = 0F;
            this.goodsMakerCdLabel.Width = 0.3F;
            // 
            // boCodeLabel
            // 
            this.boCodeLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.boCodeLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.boCodeLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeLabel.Border.RightColor = System.Drawing.Color.Black;
            this.boCodeLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeLabel.Border.TopColor = System.Drawing.Color.Black;
            this.boCodeLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.boCodeLabel.Height = 0.125F;
            this.boCodeLabel.HyperLink = "";
            this.boCodeLabel.Left = 7.6F;
            this.boCodeLabel.MultiLine = false;
            this.boCodeLabel.Name = "boCodeLabel";
            this.boCodeLabel.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.boCodeLabel.Text = "BO";
            this.boCodeLabel.Top = 0F;
            this.boCodeLabel.Width = 0.25F;
            // 
            // uoeRemark1Label
            // 
            this.uoeRemark1Label.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeRemark1Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Label.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeRemark1Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Label.Border.RightColor = System.Drawing.Color.Black;
            this.uoeRemark1Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Label.Border.TopColor = System.Drawing.Color.Black;
            this.uoeRemark1Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark1Label.Height = 0.125F;
            this.uoeRemark1Label.HyperLink = "";
            this.uoeRemark1Label.Left = 8F;
            this.uoeRemark1Label.MultiLine = false;
            this.uoeRemark1Label.Name = "uoeRemark1Label";
            this.uoeRemark1Label.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.uoeRemark1Label.Text = "リマーク１";
            this.uoeRemark1Label.Top = 0F;
            this.uoeRemark1Label.Width = 1.15F;
            // 
            // TitleHeader_Line2
            // 
            this.TitleHeader_Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Border.RightColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Border.TopColor = System.Drawing.Color.Black;
            this.TitleHeader_Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line2.Height = 0F;
            this.TitleHeader_Line2.Left = 0F;
            this.TitleHeader_Line2.LineWeight = 2F;
            this.TitleHeader_Line2.Name = "TitleHeader_Line2";
            this.TitleHeader_Line2.Top = 0.125F;
            this.TitleHeader_Line2.Width = 10.8125F;
            this.TitleHeader_Line2.X1 = 0F;
            this.TitleHeader_Line2.X2 = 10.8125F;
            this.TitleHeader_Line2.Y1 = 0.125F;
            this.TitleHeader_Line2.Y2 = 0.125F;
            // 
            // acceptAnOrderCntLabel
            // 
            this.acceptAnOrderCntLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntLabel.Border.RightColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntLabel.Border.TopColor = System.Drawing.Color.Black;
            this.acceptAnOrderCntLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.acceptAnOrderCntLabel.Height = 0.125F;
            this.acceptAnOrderCntLabel.HyperLink = "";
            this.acceptAnOrderCntLabel.Left = 7.2995F;
            this.acceptAnOrderCntLabel.MultiLine = false;
            this.acceptAnOrderCntLabel.Name = "acceptAnOrderCntLabel";
            this.acceptAnOrderCntLabel.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.acceptAnOrderCntLabel.Text = "数量";
            this.acceptAnOrderCntLabel.Top = 0F;
            this.acceptAnOrderCntLabel.Width = 0.313F;
            // 
            // uoeRemark2Label
            // 
            this.uoeRemark2Label.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeRemark2Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Label.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeRemark2Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Label.Border.RightColor = System.Drawing.Color.Black;
            this.uoeRemark2Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Label.Border.TopColor = System.Drawing.Color.Black;
            this.uoeRemark2Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeRemark2Label.Height = 0.125F;
            this.uoeRemark2Label.HyperLink = "";
            this.uoeRemark2Label.Left = 9.3F;
            this.uoeRemark2Label.MultiLine = false;
            this.uoeRemark2Label.Name = "uoeRemark2Label";
            this.uoeRemark2Label.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.uoeRemark2Label.Text = "リマーク２";
            this.uoeRemark2Label.Top = 0F;
            this.uoeRemark2Label.Width = 0.6F;
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
            // employeeCodeLabel
            // 
            this.employeeCodeLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.employeeCodeLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.employeeCodeLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeLabel.Border.RightColor = System.Drawing.Color.Black;
            this.employeeCodeLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeLabel.Border.TopColor = System.Drawing.Color.Black;
            this.employeeCodeLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeLabel.Height = 0.125F;
            this.employeeCodeLabel.HyperLink = "";
            this.employeeCodeLabel.Left = 3.8125F;
            this.employeeCodeLabel.MultiLine = false;
            this.employeeCodeLabel.Name = "employeeCodeLabel";
            this.employeeCodeLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.employeeCodeLabel.Text = "依頼者";
            this.employeeCodeLabel.Top = 0F;
            this.employeeCodeLabel.Width = 0.4F;
            // 
            // goodsNolabel
            // 
            this.goodsNolabel.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsNolabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNolabel.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsNolabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNolabel.Border.RightColor = System.Drawing.Color.Black;
            this.goodsNolabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNolabel.Border.TopColor = System.Drawing.Color.Black;
            this.goodsNolabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNolabel.Height = 0.125F;
            this.goodsNolabel.HyperLink = "";
            this.goodsNolabel.Left = 4.3125F;
            this.goodsNolabel.MultiLine = false;
            this.goodsNolabel.Name = "goodsNolabel";
            this.goodsNolabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.goodsNolabel.Text = "品番";
            this.goodsNolabel.Top = 0F;
            this.goodsNolabel.Width = 1.38F;
            // 
            // goodsNameLabel
            // 
            this.goodsNameLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.goodsNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.goodsNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameLabel.Border.RightColor = System.Drawing.Color.Black;
            this.goodsNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameLabel.Border.TopColor = System.Drawing.Color.Black;
            this.goodsNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.goodsNameLabel.Height = 0.125F;
            this.goodsNameLabel.HyperLink = "";
            this.goodsNameLabel.Left = 5.8F;
            this.goodsNameLabel.MultiLine = false;
            this.goodsNameLabel.Name = "goodsNameLabel";
            this.goodsNameLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.goodsNameLabel.Text = "品名";
            this.goodsNameLabel.Top = 0F;
            this.goodsNameLabel.Width = 1.15F;
            // 
            // uoeDeliGoodsDivLabel
            // 
            this.uoeDeliGoodsDivLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivLabel.Border.RightColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivLabel.Border.TopColor = System.Drawing.Color.Black;
            this.uoeDeliGoodsDivLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeDeliGoodsDivLabel.Height = 0.125F;
            this.uoeDeliGoodsDivLabel.HyperLink = "";
            this.uoeDeliGoodsDivLabel.Left = 10F;
            this.uoeDeliGoodsDivLabel.MultiLine = false;
            this.uoeDeliGoodsDivLabel.Name = "uoeDeliGoodsDivLabel";
            this.uoeDeliGoodsDivLabel.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.uoeDeliGoodsDivLabel.Text = "納";
            this.uoeDeliGoodsDivLabel.Top = 0F;
            this.uoeDeliGoodsDivLabel.Width = 0.25F;
            // 
            // followDeliGoodsDivLabel
            // 
            this.followDeliGoodsDivLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivLabel.Border.RightColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivLabel.Border.TopColor = System.Drawing.Color.Black;
            this.followDeliGoodsDivLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.followDeliGoodsDivLabel.Height = 0.125F;
            this.followDeliGoodsDivLabel.HyperLink = "";
            this.followDeliGoodsDivLabel.Left = 10.25F;
            this.followDeliGoodsDivLabel.MultiLine = false;
            this.followDeliGoodsDivLabel.Name = "followDeliGoodsDivLabel";
            this.followDeliGoodsDivLabel.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.followDeliGoodsDivLabel.Text = "H納";
            this.followDeliGoodsDivLabel.Top = 0F;
            this.followDeliGoodsDivLabel.Width = 0.25F;
            // 
            // uoeResvdSectionLabel
            // 
            this.uoeResvdSectionLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeResvdSectionLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeResvdSectionLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionLabel.Border.RightColor = System.Drawing.Color.Black;
            this.uoeResvdSectionLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionLabel.Border.TopColor = System.Drawing.Color.Black;
            this.uoeResvdSectionLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeResvdSectionLabel.Height = 0.125F;
            this.uoeResvdSectionLabel.HyperLink = "";
            this.uoeResvdSectionLabel.Left = 10.5F;
            this.uoeResvdSectionLabel.MultiLine = false;
            this.uoeResvdSectionLabel.Name = "uoeResvdSectionLabel";
            this.uoeResvdSectionLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.uoeResvdSectionLabel.Text = "拠点";
            this.uoeResvdSectionLabel.Top = 0F;
            this.uoeResvdSectionLabel.Width = 0.3F;
            // 
            // onlineNoByOnlineNoLabel
            // 
            this.onlineNoByOnlineNoLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoLabel.Border.RightColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoLabel.Border.TopColor = System.Drawing.Color.Black;
            this.onlineNoByOnlineNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.onlineNoByOnlineNoLabel.Height = 0.125F;
            this.onlineNoByOnlineNoLabel.HyperLink = "";
            this.onlineNoByOnlineNoLabel.Left = 0F;
            this.onlineNoByOnlineNoLabel.MultiLine = false;
            this.onlineNoByOnlineNoLabel.Name = "onlineNoByOnlineNoLabel";
            this.onlineNoByOnlineNoLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.onlineNoByOnlineNoLabel.Text = "注文番号";
            this.onlineNoByOnlineNoLabel.Top = 0.1875F;
            this.onlineNoByOnlineNoLabel.Visible = false;
            this.onlineNoByOnlineNoLabel.Width = 0.563F;
            // 
            // customerCodeByOnlineNoLabel
            // 
            this.customerCodeByOnlineNoLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoLabel.Border.RightColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoLabel.Border.TopColor = System.Drawing.Color.Black;
            this.customerCodeByOnlineNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.customerCodeByOnlineNoLabel.Height = 0.125F;
            this.customerCodeByOnlineNoLabel.HyperLink = "";
            this.customerCodeByOnlineNoLabel.Left = 0.5625F;
            this.customerCodeByOnlineNoLabel.MultiLine = false;
            this.customerCodeByOnlineNoLabel.Name = "customerCodeByOnlineNoLabel";
            this.customerCodeByOnlineNoLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.customerCodeByOnlineNoLabel.Text = "得意先";
            this.customerCodeByOnlineNoLabel.Top = 0.1875F;
            this.customerCodeByOnlineNoLabel.Visible = false;
            this.customerCodeByOnlineNoLabel.Width = 0.5F;
            // 
            // employeeCodeByOnlineNoLabel
            // 
            this.employeeCodeByOnlineNoLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoLabel.Border.RightColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoLabel.Border.TopColor = System.Drawing.Color.Black;
            this.employeeCodeByOnlineNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeeCodeByOnlineNoLabel.Height = 0.125F;
            this.employeeCodeByOnlineNoLabel.HyperLink = "";
            this.employeeCodeByOnlineNoLabel.Left = 1.0625F;
            this.employeeCodeByOnlineNoLabel.MultiLine = false;
            this.employeeCodeByOnlineNoLabel.Name = "employeeCodeByOnlineNoLabel";
            this.employeeCodeByOnlineNoLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.employeeCodeByOnlineNoLabel.Text = "依頼者";
            this.employeeCodeByOnlineNoLabel.Top = 0.1875F;
            this.employeeCodeByOnlineNoLabel.Visible = false;
            this.employeeCodeByOnlineNoLabel.Width = 0.4F;
            // 
            // uoeSupplierCdByOnlineNoLabel
            // 
            this.uoeSupplierCdByOnlineNoLabel.Border.BottomColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoLabel.Border.LeftColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoLabel.Border.RightColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoLabel.Border.TopColor = System.Drawing.Color.Black;
            this.uoeSupplierCdByOnlineNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.uoeSupplierCdByOnlineNoLabel.Height = 0.125F;
            this.uoeSupplierCdByOnlineNoLabel.HyperLink = "";
            this.uoeSupplierCdByOnlineNoLabel.Left = 1.5F;
            this.uoeSupplierCdByOnlineNoLabel.MultiLine = false;
            this.uoeSupplierCdByOnlineNoLabel.Name = "uoeSupplierCdByOnlineNoLabel";
            this.uoeSupplierCdByOnlineNoLabel.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.uoeSupplierCdByOnlineNoLabel.Text = "発注先";
            this.uoeSupplierCdByOnlineNoLabel.Top = 0.1875F;
            this.uoeSupplierCdByOnlineNoLabel.Visible = false;
            this.uoeSupplierCdByOnlineNoLabel.Width = 0.4F;
            // 
            // printOrderText
            // 
            this.printOrderText.Border.BottomColor = System.Drawing.Color.Black;
            this.printOrderText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printOrderText.Border.LeftColor = System.Drawing.Color.Black;
            this.printOrderText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printOrderText.Border.RightColor = System.Drawing.Color.Black;
            this.printOrderText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printOrderText.Border.TopColor = System.Drawing.Color.Black;
            this.printOrderText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.printOrderText.DataField = "PrintOrder";
            this.printOrderText.Height = 0.125F;
            this.printOrderText.Left = 2F;
            this.printOrderText.MultiLine = false;
            this.printOrderText.Name = "printOrderText";
            this.printOrderText.OutputFormat = resources.GetString("printOrderText.OutputFormat");
            this.printOrderText.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; verti" +
                "cal-align: top; ";
            this.printOrderText.Text = "1";
            this.printOrderText.Top = 0.1875F;
            this.printOrderText.Visible = false;
            this.printOrderText.Width = 0.25F;
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
            this.Line43});
            this.GrandTotalFooter.Height = 0.46875F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Visible = false;
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
            this.Label109.Left = 3.0625F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.sectionCodeText,
            this.sectionGuideSnmText});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.15F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // sectionCodeText
            // 
            this.sectionCodeText.Border.BottomColor = System.Drawing.Color.Black;
            this.sectionCodeText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionCodeText.Border.LeftColor = System.Drawing.Color.Black;
            this.sectionCodeText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionCodeText.Border.RightColor = System.Drawing.Color.Black;
            this.sectionCodeText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionCodeText.Border.TopColor = System.Drawing.Color.Black;
            this.sectionCodeText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionCodeText.CanShrink = true;
            this.sectionCodeText.DataField = "SectionCode";
            this.sectionCodeText.Height = 0.125F;
            this.sectionCodeText.Left = 0F;
            this.sectionCodeText.MultiLine = false;
            this.sectionCodeText.Name = "sectionCodeText";
            this.sectionCodeText.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ ゴシック; vertical-align: top; ";
            this.sectionCodeText.Text = "99";
            this.sectionCodeText.Top = 0F;
            this.sectionCodeText.Visible = false;
            this.sectionCodeText.Width = 0.25F;
            // 
            // sectionGuideSnmText
            // 
            this.sectionGuideSnmText.Border.BottomColor = System.Drawing.Color.Black;
            this.sectionGuideSnmText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionGuideSnmText.Border.LeftColor = System.Drawing.Color.Black;
            this.sectionGuideSnmText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionGuideSnmText.Border.RightColor = System.Drawing.Color.Black;
            this.sectionGuideSnmText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionGuideSnmText.Border.TopColor = System.Drawing.Color.Black;
            this.sectionGuideSnmText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.sectionGuideSnmText.CanShrink = true;
            this.sectionGuideSnmText.DataField = "SectionGuideSnm";
            this.sectionGuideSnmText.Height = 0.125F;
            this.sectionGuideSnmText.Left = 0.3125F;
            this.sectionGuideSnmText.MultiLine = false;
            this.sectionGuideSnmText.Name = "sectionGuideSnmText";
            this.sectionGuideSnmText.Style = "ddo-char-set: 128; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.sectionGuideSnmText.Text = "拠点ガイド略称ＮＮＮ";
            this.sectionGuideSnmText.Top = 0F;
            this.sectionGuideSnmText.Visible = false;
            this.sectionGuideSnmText.Width = 1.1875F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.MONEYKINDNAME13,
            this.Line45,
            this.line2});
            this.SectionFooter.Height = 0.46875F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
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
            this.MONEYKINDNAME13.Left = 3.0625F;
            this.MONEYKINDNAME13.MultiLine = false;
            this.MONEYKINDNAME13.Name = "MONEYKINDNAME13";
            this.MONEYKINDNAME13.OutputFormat = resources.GetString("MONEYKINDNAME13.OutputFormat");
            this.MONEYKINDNAME13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.MONEYKINDNAME13.Text = "拠点計";
            this.MONEYKINDNAME13.Top = 0.0625F;
            this.MONEYKINDNAME13.Visible = false;
            this.MONEYKINDNAME13.Width = 0.5625F;
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
            this.line2.Top = 0F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // PMUOE02034P_03A4C
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
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionFooter);
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
            this.ReportStart += new System.EventHandler(this.PMUOE02034P_03A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.goodsMakerCdText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boCodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark1Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceptAnOrderCntText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark2Text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierNameText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNameText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeDeliGoodsDivText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDeliGoodsDivText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeResvdSectionText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoByOnlineNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeByOnlineNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeByOnlineNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdByOnlineNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierNameByOnlineNoText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportTitleLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortOrderNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printDateTimeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printDateText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printTimeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsMakerCdLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boCodeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark1Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceptAnOrderCntLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeRemark2Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNolabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsNameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeDeliGoodsDivLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followDeliGoodsDivLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeResvdSectionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineNoByOnlineNoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCodeByOnlineNoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeCodeByOnlineNoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uoeSupplierCdByOnlineNoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printOrderText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionCodeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionGuideSnmText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion  // ActiveReports Designer generated code
    }
}
