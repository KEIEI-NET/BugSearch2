//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーンマスタ印刷
// プログラム概要   : 抽出結果より出力結果イメージ表示・ＰＤＦ出力・印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/12  修正内容 : Redmine#22929 拠点コードを帳票の明細部に追加の修正
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMKHN08703P_01A4C の概要の説明です。
    /// </summary>
    /// <remarks>
    /// <br>Note         : キャンペーンマスタ（印刷）のフォームクラスです。</br>
    /// <br>Programmer   : 田建委</br>
    /// <br>Date         : 2011/04/25</br>
    /// <br>UpdateNote   : 2011/07/12 譚洪 Redmine#22929 拠点コードを帳票の明細部に追加の修正</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKHN08703P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ■ Constructor
        /// <summary>
        /// キャンペーンマスタ（印刷）フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note         : キャンペーンマスタ（印刷）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2011/04/25</br>
        /// </remarks>
        public PMKHN08703P_01A4C()
        {
            InitializeComponent();
        }
        #endregion ■ Constructor

        #region ■ Private Member
        private int _printCount;									    // 印刷件数用カウンタ

        private int                 _extraCondHeadOutDiv;			    // 抽出条件ヘッダ出力区分
        private StringCollection    _extraConditions;				    // 抽出条件
        private int                 _pageFooterOutCode;				    // フッター出力区分
        private StringCollection    _pageFooters;					    // フッターメッセージ
        private SFCMN06002C         _printInfo;						    // 印刷情報クラス
        private string              _pageHeaderTitle;				    // フォームタイトル
        private string              _pageHeaderSortOderTitle;		    // ソート順

        private CampaignMasterPrintWork _campaignMasterPrintWork;       // 抽出条件クラス

        // ヘッダーサブレポート宣言
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // フッターレポート宣言
        ListCommon_PageFooter _rptPageFooter = null;
        private TextBox Tb_DiscountRate;
        private Label Lb_DiscountRate;
        private TextBox Tb_creatDate;
        private TextBox Tb_updateDate;
        private Label Lb_creatDate;
        private Label Lb_updateDate;
        private Label Lb_SalesCode;
        private TextBox Tb_SalesCode;
        private TextBox Tb_SalesName;
        private SubReport Footer_SubReport;
        private TextBox Tb_SectionCode;

        // Disposeチェック用フラグ
        bool disposed = false;

        #endregion ■ Private Member

        #region ■ Dispose(override)
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
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
        /// その他データ
        /// </summary>
        public ArrayList OtherDataList
        {
            set { }
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
        /// ページヘッダソート順タイトル項目
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary>
        /// 帳票サブタイトル
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
        }

        /// <summary>
        /// 印刷条件
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._campaignMasterPrintWork = (CampaignMasterPrintWork)this._printInfo.jyoken;
            }
        }

        #endregion ◆ Public Property
        #endregion ■ IPrintActiveReportTypeList メンバ

        #region IPrintActiveReportTypeCommon メンバ
        #region ◆ Public Property
        /// <summary>
		/// 印刷件数カウントアップイベント
		/// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        
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
        /// <br>Note		: レポートの要素（Header、Footer、Text）の出力設定</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// <br>UpdateNote  : 2011/07/12 譚洪 Redmine#22929 拠点コードを帳票の明細部に追加の修正</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // 印字設定 --------------------------------------------------------------------------------------

            // 項目の名称をセット
            tb_ReportTitle.Text = this._pageHeaderTitle;				// サブタイトル
            // 改ページ
            if (this._campaignMasterPrintWork.PrintType == 6)
            {
                if (this._campaignMasterPrintWork.ChangePage == 0)
                {
                    this.CampaignHeader.NewPage = NewPage.Before;
                    this.Tb_CustomerCode.CanShrink = false;
                    this.Tb_CustomerName.CanShrink = false;
                }
                else
                {
                    this.CampaignHeader.NewPage = NewPage.None;
                    this.Tb_CustomerCode.CanShrink = true;
                    this.Tb_CustomerName.CanShrink = true;
                }
            }
            else
            {
                if (this._campaignMasterPrintWork.ChangePage == 1)
                {
                    this.CampaignHeader.NewPage = NewPage.None;
                }
            }

            if (this._extraConditions != null && this._extraConditions.Count == 0)
            {
                this.Line5.Visible = false;
            }
            else
            {
                this.Line5.Visible = true;
            }
            switch (this._campaignMasterPrintWork.PrintType)
            {
                case 0: // メーカー＋品番
                    // Visible
                    this.Lb_BLGoodsCode.Visible = false;
                    this.Lb_BLGroupCode.Visible = false;
                    this.Lb_SalesCode.Visible = false;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Lb_SectionCode.Visible = true;
                    this.Tb_SectionCode.Visible = true;
                    this.Lb_SectionCode.Location = new System.Drawing.PointF(3.688f, 0f);
                    this.Tb_SectionCode.Location = new System.Drawing.PointF(3.688f, 0f);
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    this.Tb_BLGoodsCode.Visible = false;
                    this.Tb_BLGoodsHalfName.Visible = false;
                    this.Tb_BLGroupCode.Visible = false;
                    this.Tb_BLGroupName.Visible = false;
                    this.Tb_SalesCode.Visible = false;
                    this.Tb_SalesName.Visible = false;

                    break;
                case 1: // メーカー＋ＢＬコード
                    this.Lb_GoodsNo.Visible = false;
                    this.Lb_GoodsName.Visible = false;
                    this.Lb_BLGroupCode.Visible = false;
                    this.Lb_PriceFl.Visible = false;
                    this.Lb_SalesCode.Visible = false;

                    this.Tb_GoodsNo.Visible = false;
                    this.Tb_GoodsName.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_BLGroupCode.Visible = false;
                    this.Tb_BLGroupName.Visible = false;
                    this.Tb_SalesCode.Visible = false;
                    this.Tb_SalesName.Visible = false;

                    // Location
                    this.Lb_BLGoodsCode.Top = 0F;
                    this.Tb_BLGoodsCode.Left = 0F;
                    this.Tb_BLGoodsCode.Top = 0F;
                    this.Tb_BLGoodsHalfName.Top = 0F;
                    this.Tb_BLGoodsHalfName.Left = 0.375F;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Lb_SectionCode.Visible = true;
                    this.Tb_SectionCode.Visible = true;
                    this.Lb_SectionCode.Location = new System.Drawing.PointF(3.688f, 0f);
                    this.Tb_SectionCode.Location = new System.Drawing.PointF(3.688f, 0f);
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    break;
                case 2: // メーカー＋グループコード
                    this.Lb_GoodsNo.Visible = false;
                    this.Lb_GoodsName.Visible = false;
                    this.Lb_BLGoodsCode.Visible = false;
                    this.Lb_PriceFl.Visible = false;
                    this.Lb_SalesCode.Visible = false;

                    this.Tb_GoodsNo.Visible = false;
                    this.Tb_GoodsName.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_BLGoodsCode.Visible = false;
                    this.Tb_BLGoodsHalfName.Visible = false;
                    this.Tb_SalesCode.Visible = false;
                    this.Tb_SalesName.Visible = false;

                    // Location
                    this.Lb_BLGroupCode.Top = 0F;
                    this.Lb_BLGroupCode.Left = 0F;
                    this.Tb_BLGroupCode.Left = 0F;
                    this.Tb_BLGroupCode.Top = 0F;
                    this.Tb_BLGroupName.Top = 0F;
                    this.Tb_BLGroupName.Left = 0.375F;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Lb_SectionCode.Visible = true;
                    this.Tb_SectionCode.Visible = true;
                    this.Lb_SectionCode.Location = new System.Drawing.PointF(3.688f, 0f);
                    this.Tb_SectionCode.Location = new System.Drawing.PointF(3.688f, 0f);
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    break;
                case 3: // メーカー
                    this.Lb_GoodsNo.Visible = false;
                    this.Lb_GoodsName.Visible = false;
                    this.Lb_BLGoodsCode.Visible = false;
                    this.Lb_BLGroupCode.Visible = false;
                    this.Lb_PriceFl.Visible = false;
                    this.Lb_SalesCode.Visible = false;

                    this.Tb_GoodsNo.Visible = false;
                    this.Tb_GoodsName.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_BLGoodsCode.Visible = false;
                    this.Tb_BLGoodsHalfName.Visible = false;
                    this.Tb_BLGroupCode.Visible = false;
                    this.Tb_BLGroupName.Visible = false;
                    this.Tb_SalesCode.Visible = false;
                    this.Tb_SalesName.Visible = false;

                    // Location
                    this.Lb_GoodsMaker.Left = 0F;
                    this.Lb_CustomerCode.Left = 2.437F;
                    this.Lb_DiscountRate.Left = 4.137F;
                    this.Lb_RateVal.Left = 5.562F;
                    this.Lb_PriceDate.Left = 7.187F;
                    this.Tb_GoodsMakerCode.Left = 0F;
                    this.Tb_MakerName.Left = 0.312F;
                    this.Tb_CustomerCode.Left = 2.437F;
                    this.Tb_CustomerName.Left = 2.937F;
                    this.Tb_DiscountRate.Left = 4.2F;
                    this.Tb_RateVal.Left = 5.625F;
                    this.Tb_PriceDate.Left = 7.187F;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Lb_SectionCode.Visible = true;
                    this.Tb_SectionCode.Visible = true;
                    this.Lb_SectionCode.Location = new System.Drawing.PointF(1.688f, 0f);
                    this.Tb_SectionCode.Location = new System.Drawing.PointF(1.688f, 0f);
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    break;
                case 4: // ＢＬコード
                    this.Lb_GoodsNo.Visible = false;
                    this.Lb_GoodsName.Visible = false;
                    this.Lb_GoodsMaker.Visible = false;
                    this.Lb_BLGroupCode.Visible = false;
                    this.Lb_PriceFl.Visible = false;
                    this.Lb_SalesCode.Visible = false;

                    this.Tb_GoodsNo.Visible = false;
                    this.Tb_GoodsName.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_GoodsMakerCode.Visible = false;
                    this.Tb_MakerName.Visible = false;
                    this.Tb_BLGroupCode.Visible = false;
                    this.Tb_BLGroupName.Visible = false;
                    this.Tb_SalesCode.Visible = false;
                    this.Tb_SalesName.Visible = false;

                    // Location
                    this.Lb_BLGoodsCode.Top = 0F;
                    this.Lb_CustomerCode.Left = 2.437F;
                    this.Lb_DiscountRate.Left = 4.137F;
                    this.Lb_RateVal.Left = 5.562F;
                    this.Lb_PriceDate.Left = 7.187F;
                    this.Tb_CustomerCode.Left = 2.437F;
                    this.Tb_CustomerName.Left = 2.937F;
                    this.Tb_DiscountRate.Left = 4.2F;
                    this.Tb_RateVal.Left = 5.625F;
                    this.Tb_PriceDate.Left = 7.187F;
                    this.Tb_BLGoodsCode.Left = 0F;
                    this.Tb_BLGoodsCode.Top = 0F;
                    this.Tb_BLGoodsHalfName.Top = 0F;
                    this.Tb_BLGoodsHalfName.Left = 0.375F;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Lb_SectionCode.Visible = true;
                    this.Tb_SectionCode.Visible = true;
                    this.Lb_SectionCode.Location = new System.Drawing.PointF(1.8f, 0f);
                    this.Tb_SectionCode.Location = new System.Drawing.PointF(1.8f, 0f);
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    break;
                case 5: // 販売区分
                    this.Lb_GoodsNo.Visible = false;
                    this.Lb_GoodsName.Visible = false;
                    this.Lb_BLGoodsCode.Visible = false;
                    this.Lb_BLGroupCode.Visible = false;
                    this.Lb_PriceFl.Visible = false;
                    this.Lb_GoodsMaker.Visible = false;
                    this.Lb_SalesCode.Top = 0;
                    this.Lb_SalesCode.Left = 0;

                    this.Tb_GoodsNo.Visible = false;
                    this.Tb_GoodsName.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_BLGoodsCode.Visible = false;
                    this.Tb_BLGoodsHalfName.Visible = false;
                    this.Tb_BLGroupCode.Visible = false;
                    this.Tb_BLGroupName.Visible = false;
                    this.Tb_GoodsMakerCode.Visible = false;
                    this.Tb_MakerName.Visible = false;

                    // Location
                    this.Tb_SalesCode.Top = 0F;
                    this.Tb_SalesCode.Left = 0F;
                    this.Tb_SalesName.Top = 0F;
                    this.Tb_SalesName.Left = 0.375F;
                    this.Lb_CustomerCode.Left = 2.437F;
                    this.Lb_DiscountRate.Left = 4.137F;
                    this.Lb_RateVal.Left = 5.562F;
                    this.Lb_PriceDate.Left = 7.187F;
                    this.Tb_CustomerCode.Left = 2.437F;
                    this.Tb_CustomerName.Left = 2.937F;
                    this.Tb_DiscountRate.Left = 4.2F;
                    this.Tb_RateVal.Left = 5.625F;
                    this.Tb_PriceDate.Left = 7.187F;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Lb_SectionCode.Visible = true;
                    this.Tb_SectionCode.Visible = true;
                    this.Lb_SectionCode.Location = new System.Drawing.PointF(1.8f, 0f);
                    this.Tb_SectionCode.Location = new System.Drawing.PointF(1.8f, 0f);
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    break;
                case 6: // マスタリスト
                    // Visible
                    this.Lb_GoodsNo.Visible = false;
                    this.Lb_GoodsName.Visible = false;
                    this.Lb_GoodsMaker.Visible = false;
                    this.Lb_BLGoodsCode.Visible = false;
                    this.Lb_BLGroupCode.Visible = false;
                    this.Lb_DiscountRate.Visible = false;
                    this.Lb_RateVal.Visible = false;
                    this.Lb_PriceFl.Visible = false;
                    this.Lb_PriceDate.Visible = false;
                    this.Lb_creatDate.Visible = false;
                    this.Lb_updateDate.Visible = false;
                    this.Lb_SalesCode.Visible = false;

                    this.Lb_CampaignCode.Visible = true;
                    this.Lb_SectionCode.Visible = true;

                    this.CH_CampaignCode.Visible = false;
                    this.TL_ApplyDate.Visible = false;
                    this.CH_SectionCode.Visible = false;

                    this.line4.Visible = false;
                    this.line2.Visible = false;
                    this.line6.Visible = true;
                    this.line7.Visible = true;
                    this.Lb_CampaignObjDiv.Visible = true;
                    this.Lb_ApplyDate.Visible = true;
                    this.Tb_CampaignObjDiv.Visible = true;
                    this.Tb_ApplyDate.Visible = true;

                    this.Tb_creatDate.Visible = false;
                    this.Tb_updateDate.Visible = false;

                    this.Tb_GoodsNo.Visible = false;
                    this.Tb_GoodsName.Visible = false;
                    this.Tb_GoodsMakerCode.Visible = false;
                    this.Tb_MakerName.Visible = false;
                    this.Tb_DiscountRate.Visible = false;
                    this.Tb_RateVal.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_PriceDate.Visible = false;

                    this.Tb_BLGoodsCode.Visible = false;
                    this.Tb_BLGoodsHalfName.Visible = false;
                    this.Tb_BLGroupCode.Visible = false;
                    this.Tb_BLGroupName.Visible = false;
                    this.Tb_SalesCode.Visible = false;
                    this.Tb_SalesName.Visible = false;

                    // Location
                    this.Lb_CampaignCode.Top = 0F;
                    this.Lb_SectionCode.Top = 0F;
                    this.Lb_SectionCode.Left = 2.8F;
                    this.Lb_CustomerCode.Top = 0.125F;
                    this.Lb_CustomerCode.Left = 0.313F;
                    this.Lb_CampaignObjDiv.Left = 4.2F;
                    this.Lb_ApplyDate.Left = 5.138F;

                    this.TL_CampaignCode.Left = 0F;
                    this.TL_CampaignName.Left = 0.43F;
                    this.TL_SectionCode.Left = 2.8F;
                    this.TL_SectionName.Left = 3F;

                    this.Tb_CampaignObjDiv.Left = 4.2F;
                    this.Tb_ApplyDate.Left = 5.138F;
                    this.Tb_CustomerCode.Left = 0.313F;
                    this.Tb_CustomerName.Left = 0.813F;

                    // ----- ADD 2011/07/12 ------- >>>>>>>>>
                    this.Tb_SectionCode.Visible = false;
                    // ----- ADD 2011/07/12 ------- <<<<<<<<<

                    break;
            }

            
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

        #region ◎ PMKHN08703P_01A4C_ReportStart Event
        /// <summary>
        /// PMKHN08703P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: レポート開始時のイベントです。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void PMKHN08703P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region ◎ PMKHN08703P_01A4C_PageEnd Event
        /// <summary>
        /// PMKHN08613P_01A4C_PageEnd Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PMKHN08703P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void PMKHN08703P_01A4C_PageEnd(object sender, EventArgs e)
        {

        }
        #endregion ◎ PMKHN08703P_01A4C_PageEnd Event

        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void pageHeader_Format(object sender, EventArgs e)
        {
            // 作成日付
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // 作成時間
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");
        }


        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: PageFooterグループのフォーマットイベント。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2011/04/25</br>
        /// </remarks>
        private void PageFooter_Format(object sender, EventArgs e)
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

        #region ◎ ExtraHeader_Format Event
        /// <summary>
        /// ExtraHeader_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ExtraHeaderグループのフォーマットイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, EventArgs e)
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
            if (this._rptExtraHeader == null)
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

        #region ◎ Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: セクションがページに描画される前に発生する。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrapプロパティで文字が中途半端なところで区切られないようにするための対応
            PrintCommonLibrary.ConvertReportString(this.detail);
        }
        #endregion

        #region ◎ detail_Format Event
        /// <summary>
        /// detail_Format Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="eArgs">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: detailグループのフォーマットイベント。</br>
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void detail_Format(object sender, EventArgs e)
        {
            if (this._campaignMasterPrintWork.PrintType != 6)
            {
                // 売価設定区分が0の場合、以下の項目が非表示
                if (this.Tb_SalesPriceSetDiv.Text == "0")
                {
                    this.Tb_CustomerCode.Visible = false;
                    this.Tb_CustomerName.Visible = false;
                    this.Tb_DiscountRate.Visible = false;
                    this.Tb_RateVal.Visible = false;
                    this.Tb_PriceFl.Visible = false;
                    this.Tb_PriceDate.Visible = false;
                }
                else
                {
                    if (this._campaignMasterPrintWork.PrintType == 0)
                    {
                        this.Tb_PriceFl.Visible = true;
                    }
                    this.Tb_CustomerCode.Visible = true;
                    this.Tb_CustomerName.Visible = true;
                    this.Tb_DiscountRate.Visible = true;
                    this.Tb_RateVal.Visible = true;
                    this.Tb_PriceDate.Visible = true;
                }
            }
            // マスタリスト
            else
            {
                // 得意先コードが空白の場合、以下の項目が非表示
                if (this.Tb_CustomerCode.Text == string.Empty)
                {
                    this.line3.Visible = false;
                }
                else
                {
                    this.line3.Visible = true;
                }
            }
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
        /// <br>Programmer	: 田建委</br>
        /// <br>Date		: 2011/04/25</br>
        /// </remarks>
        private void detail_AfterPrint(object sender, EventArgs e)
        {
            // 印刷件数カウントアップ
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }
        #endregion

        #endregion ■ Control Event
       
        #region ActiveReports Designer generated code

        private PageHeader pageHeader;
        private Detail detail;
        private PageFooter PageFooter;
        private Label tb_ReportTitle;
        private Label Label3;
        private TextBox tb_PrintDate;
        private TextBox tb_PrintTime;
        private Label Label2;
        private TextBox tb_PrintPage;
        private Line Line1;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private Label Lb_GoodsNo;
        private Label Lb_GoodsName;
        private Line line4;
        private Label Lb_GoodsMaker;
        private Label Lb_CampaignCode;
        private TextBox TL_CampaignCode;
        private TextBox TL_CampaignName;
        private Label Lb_SectionCode;
        private TextBox TL_SectionCode;
        private TextBox TL_SectionName;
        private Label Lb_BLGoodsCode;
        private Label Lb_BLGroupCode;
        private Label Lb_CustomerCode;
        private Label Lb_RateVal;
        private Label Lb_PriceFl;
        private Label Lb_PriceDate;
        private Label Lb_CampaignObjDiv;
        private Label Lb_ApplyDate;
        private TextBox Tb_GoodsNo;
        private TextBox Tb_GoodsName;
        private TextBox Tb_GoodsMakerCode;
        private TextBox Tb_MakerName;
        private TextBox Tb_BLGoodsCode;
        private TextBox Tb_BLGoodsHalfName;
        private TextBox Tb_BLGroupCode;
        private TextBox Tb_BLGroupName;
        private TextBox TL_ApplyDate;
        private TextBox Tb_CustomerCode;
        private TextBox Tb_CustomerName;
        private TextBox Tb_RateVal;
        private TextBox Tb_PriceFl;
        private TextBox Tb_PriceDate;
        private Line line3;
        private SubReport Header_SubReport;
        private Line Line5;
        private GroupHeader CampaignHeader;
        private GroupFooter CampaignFooter;
        private Label CH_CampaignCode;
        private Label CH_SectionCode;
        private Line line2;
        private Line line7;
        private TextBox Tb_CampaignObjDiv;
        private TextBox Tb_ApplyDate;
        private Line line6;
        private TextBox Tb_SalesPriceSetDiv;

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        /// <remarks>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2011/04/25</br>
        /// </remarks>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMKHN08703P_01A4C));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.Tb_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Tb_GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.Tb_GoodsMakerCode = new DataDynamics.ActiveReports.TextBox();
            this.Tb_MakerName = new DataDynamics.ActiveReports.TextBox();
            this.Tb_BLGoodsCode = new DataDynamics.ActiveReports.TextBox();
            this.Tb_BLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.Tb_BLGroupCode = new DataDynamics.ActiveReports.TextBox();
            this.Tb_BLGroupName = new DataDynamics.ActiveReports.TextBox();
            this.Tb_CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.Tb_CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.Tb_RateVal = new DataDynamics.ActiveReports.TextBox();
            this.Tb_PriceFl = new DataDynamics.ActiveReports.TextBox();
            this.Tb_PriceDate = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Tb_SalesPriceSetDiv = new DataDynamics.ActiveReports.TextBox();
            this.Tb_DiscountRate = new DataDynamics.ActiveReports.TextBox();
            this.Tb_creatDate = new DataDynamics.ActiveReports.TextBox();
            this.Tb_updateDate = new DataDynamics.ActiveReports.TextBox();
            this.Tb_SalesCode = new DataDynamics.ActiveReports.TextBox();
            this.Tb_SalesName = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.Lb_GoodsMaker = new DataDynamics.ActiveReports.Label();
            this.Lb_CampaignCode = new DataDynamics.ActiveReports.Label();
            this.Lb_SectionCode = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGoodsCode = new DataDynamics.ActiveReports.Label();
            this.Lb_BLGroupCode = new DataDynamics.ActiveReports.Label();
            this.Lb_CustomerCode = new DataDynamics.ActiveReports.Label();
            this.Lb_RateVal = new DataDynamics.ActiveReports.Label();
            this.Lb_PriceFl = new DataDynamics.ActiveReports.Label();
            this.Lb_PriceDate = new DataDynamics.ActiveReports.Label();
            this.Lb_CampaignObjDiv = new DataDynamics.ActiveReports.Label();
            this.Lb_ApplyDate = new DataDynamics.ActiveReports.Label();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.Lb_DiscountRate = new DataDynamics.ActiveReports.Label();
            this.Lb_creatDate = new DataDynamics.ActiveReports.Label();
            this.Lb_updateDate = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesCode = new DataDynamics.ActiveReports.Label();
            this.TL_CampaignCode = new DataDynamics.ActiveReports.TextBox();
            this.TL_CampaignName = new DataDynamics.ActiveReports.TextBox();
            this.TL_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.TL_SectionName = new DataDynamics.ActiveReports.TextBox();
            this.TL_ApplyDate = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.CampaignHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CH_CampaignCode = new DataDynamics.ActiveReports.Label();
            this.CH_SectionCode = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Tb_CampaignObjDiv = new DataDynamics.ActiveReports.TextBox();
            this.Tb_ApplyDate = new DataDynamics.ActiveReports.TextBox();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.CampaignFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.Tb_SectionCode = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_GoodsMakerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_RateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_PriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_PriceDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SalesPriceSetDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_DiscountRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_creatDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_updateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SalesCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SalesName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CampaignCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_RateVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PriceDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CampaignObjDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ApplyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DiscountRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_creatDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_updateDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_CampaignCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_CampaignName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_SectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_ApplyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CH_CampaignCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CH_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_CampaignObjDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_ApplyDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Label3,
            this.tb_PrintDate,
            this.tb_PrintTime,
            this.Label2,
            this.tb_PrintPage,
            this.Line1});
            this.pageHeader.Height = 0.2708333F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
            this.tb_ReportTitle.Text = "キャンペーン対象商品マスタ";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 6F;
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
            this.Line1.Top = 0.25F;
            this.Line1.Width = 10.8125F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8125F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
            // 
            // detail
            // 
            this.detail.CanShrink = true;
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Tb_GoodsNo,
            this.Tb_GoodsName,
            this.Tb_GoodsMakerCode,
            this.Tb_MakerName,
            this.Tb_BLGoodsCode,
            this.Tb_BLGoodsHalfName,
            this.Tb_BLGroupCode,
            this.Tb_BLGroupName,
            this.Tb_CustomerCode,
            this.Tb_CustomerName,
            this.Tb_RateVal,
            this.Tb_PriceFl,
            this.Tb_PriceDate,
            this.line3,
            this.Tb_SalesPriceSetDiv,
            this.Tb_DiscountRate,
            this.Tb_creatDate,
            this.Tb_updateDate,
            this.Tb_SalesCode,
            this.Tb_SalesName,
            this.Tb_SectionCode});
            this.detail.Height = 0.7395833F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            this.detail.AfterPrint += new System.EventHandler(this.detail_AfterPrint);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // Tb_GoodsNo
            // 
            this.Tb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsNo.DataField = "goodsno";
            this.Tb_GoodsNo.Height = 0.125F;
            this.Tb_GoodsNo.Left = 0F;
            this.Tb_GoodsNo.MultiLine = false;
            this.Tb_GoodsNo.Name = "Tb_GoodsNo";
            this.Tb_GoodsNo.OutputFormat = resources.GetString("Tb_GoodsNo.OutputFormat");
            this.Tb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_GoodsNo.Text = "あいうえおかきくけこあい";
            this.Tb_GoodsNo.Top = 0F;
            this.Tb_GoodsNo.Width = 1.4F;
            // 
            // Tb_GoodsName
            // 
            this.Tb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsName.DataField = "goodsname";
            this.Tb_GoodsName.Height = 0.125F;
            this.Tb_GoodsName.Left = 1.416667F;
            this.Tb_GoodsName.MultiLine = false;
            this.Tb_GoodsName.Name = "Tb_GoodsName";
            this.Tb_GoodsName.OutputFormat = resources.GetString("Tb_GoodsName.OutputFormat");
            this.Tb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_GoodsName.Text = "あいうえおかきくけこ";
            this.Tb_GoodsName.Top = 0F;
            this.Tb_GoodsName.Width = 1.2F;
            // 
            // Tb_GoodsMakerCode
            // 
            this.Tb_GoodsMakerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_GoodsMakerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsMakerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_GoodsMakerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsMakerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_GoodsMakerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsMakerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_GoodsMakerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_GoodsMakerCode.DataField = "goodsmakercd";
            this.Tb_GoodsMakerCode.Height = 0.125F;
            this.Tb_GoodsMakerCode.Left = 2.6875F;
            this.Tb_GoodsMakerCode.MultiLine = false;
            this.Tb_GoodsMakerCode.Name = "Tb_GoodsMakerCode";
            this.Tb_GoodsMakerCode.OutputFormat = resources.GetString("Tb_GoodsMakerCode.OutputFormat");
            this.Tb_GoodsMakerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_GoodsMakerCode.Text = "9999";
            this.Tb_GoodsMakerCode.Top = 0F;
            this.Tb_GoodsMakerCode.Width = 0.25F;
            // 
            // Tb_MakerName
            // 
            this.Tb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_MakerName.DataField = "makername";
            this.Tb_MakerName.Height = 0.125F;
            this.Tb_MakerName.Left = 2.9375F;
            this.Tb_MakerName.MultiLine = false;
            this.Tb_MakerName.Name = "Tb_MakerName";
            this.Tb_MakerName.OutputFormat = resources.GetString("Tb_MakerName.OutputFormat");
            this.Tb_MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_MakerName.Text = "あいうえお";
            this.Tb_MakerName.Top = 0F;
            this.Tb_MakerName.Width = 0.6F;
            // 
            // Tb_BLGoodsCode
            // 
            this.Tb_BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsCode.DataField = "blgoodscode";
            this.Tb_BLGoodsCode.Height = 0.125F;
            this.Tb_BLGoodsCode.Left = 0F;
            this.Tb_BLGoodsCode.MultiLine = false;
            this.Tb_BLGoodsCode.Name = "Tb_BLGoodsCode";
            this.Tb_BLGoodsCode.OutputFormat = resources.GetString("Tb_BLGoodsCode.OutputFormat");
            this.Tb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_BLGoodsCode.Text = "99999";
            this.Tb_BLGoodsCode.Top = 0.375F;
            this.Tb_BLGoodsCode.Width = 0.3125F;
            // 
            // Tb_BLGoodsHalfName
            // 
            this.Tb_BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGoodsHalfName.DataField = "blgoodshalfname";
            this.Tb_BLGoodsHalfName.Height = 0.125F;
            this.Tb_BLGoodsHalfName.Left = 0.375F;
            this.Tb_BLGoodsHalfName.MultiLine = false;
            this.Tb_BLGoodsHalfName.Name = "Tb_BLGoodsHalfName";
            this.Tb_BLGoodsHalfName.OutputFormat = resources.GetString("Tb_BLGoodsHalfName.OutputFormat");
            this.Tb_BLGoodsHalfName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_BLGoodsHalfName.Text = "あいうえお";
            this.Tb_BLGoodsHalfName.Top = 0.375F;
            this.Tb_BLGoodsHalfName.Width = 0.6F;
            // 
            // Tb_BLGroupCode
            // 
            this.Tb_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupCode.DataField = "blgroupcode";
            this.Tb_BLGroupCode.Height = 0.125F;
            this.Tb_BLGroupCode.Left = 1.5F;
            this.Tb_BLGroupCode.MultiLine = false;
            this.Tb_BLGroupCode.Name = "Tb_BLGroupCode";
            this.Tb_BLGroupCode.OutputFormat = resources.GetString("Tb_BLGroupCode.OutputFormat");
            this.Tb_BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_BLGroupCode.Text = "99999";
            this.Tb_BLGroupCode.Top = 0.375F;
            this.Tb_BLGroupCode.Width = 0.3125F;
            // 
            // Tb_BLGroupName
            // 
            this.Tb_BLGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_BLGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_BLGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_BLGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_BLGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_BLGroupName.DataField = "blgroupname";
            this.Tb_BLGroupName.Height = 0.125F;
            this.Tb_BLGroupName.Left = 1.875F;
            this.Tb_BLGroupName.MultiLine = false;
            this.Tb_BLGroupName.Name = "Tb_BLGroupName";
            this.Tb_BLGroupName.OutputFormat = resources.GetString("Tb_BLGroupName.OutputFormat");
            this.Tb_BLGroupName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_BLGroupName.Text = "あいうえお";
            this.Tb_BLGroupName.Top = 0.375F;
            this.Tb_BLGroupName.Width = 0.6F;
            // 
            // Tb_CustomerCode
            // 
            this.Tb_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerCode.DataField = "customercode";
            this.Tb_CustomerCode.Height = 0.125F;
            this.Tb_CustomerCode.Left = 4.09375F;
            this.Tb_CustomerCode.MultiLine = false;
            this.Tb_CustomerCode.Name = "Tb_CustomerCode";
            this.Tb_CustomerCode.OutputFormat = resources.GetString("Tb_CustomerCode.OutputFormat");
            this.Tb_CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_CustomerCode.Text = "999999988";
            this.Tb_CustomerCode.Top = 0F;
            this.Tb_CustomerCode.Width = 0.48F;
            // 
            // Tb_CustomerName
            // 
            this.Tb_CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CustomerName.DataField = "customersnm";
            this.Tb_CustomerName.Height = 0.125F;
            this.Tb_CustomerName.Left = 4.59375F;
            this.Tb_CustomerName.MultiLine = false;
            this.Tb_CustomerName.Name = "Tb_CustomerName";
            this.Tb_CustomerName.OutputFormat = resources.GetString("Tb_CustomerName.OutputFormat");
            this.Tb_CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_CustomerName.Text = "あいうえおかきくけこ";
            this.Tb_CustomerName.Top = 0F;
            this.Tb_CustomerName.Width = 1.15F;
            // 
            // Tb_RateVal
            // 
            this.Tb_RateVal.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_RateVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_RateVal.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_RateVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_RateVal.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_RateVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_RateVal.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_RateVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_RateVal.DataField = "rateval";
            this.Tb_RateVal.Height = 0.125F;
            this.Tb_RateVal.Left = 6.4375F;
            this.Tb_RateVal.MultiLine = false;
            this.Tb_RateVal.Name = "Tb_RateVal";
            this.Tb_RateVal.OutputFormat = resources.GetString("Tb_RateVal.OutputFormat");
            this.Tb_RateVal.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.Tb_RateVal.Text = "ZZ9.99";
            this.Tb_RateVal.Top = 0F;
            this.Tb_RateVal.Width = 0.375F;
            // 
            // Tb_PriceFl
            // 
            this.Tb_PriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_PriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_PriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_PriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_PriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceFl.DataField = "pricefl";
            this.Tb_PriceFl.Height = 0.125F;
            this.Tb_PriceFl.Left = 6.875F;
            this.Tb_PriceFl.MultiLine = false;
            this.Tb_PriceFl.Name = "Tb_PriceFl";
            this.Tb_PriceFl.OutputFormat = resources.GetString("Tb_PriceFl.OutputFormat");
            this.Tb_PriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.Tb_PriceFl.Text = "Z,ZZZ,ZZZ,ZZ9.99";
            this.Tb_PriceFl.Top = 0F;
            this.Tb_PriceFl.Width = 0.92F;
            // 
            // Tb_PriceDate
            // 
            this.Tb_PriceDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_PriceDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_PriceDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceDate.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_PriceDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceDate.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_PriceDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_PriceDate.DataField = "pricedate";
            this.Tb_PriceDate.Height = 0.125F;
            this.Tb_PriceDate.Left = 7.854167F;
            this.Tb_PriceDate.MultiLine = false;
            this.Tb_PriceDate.Name = "Tb_PriceDate";
            this.Tb_PriceDate.OutputFormat = resources.GetString("Tb_PriceDate.OutputFormat");
            this.Tb_PriceDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_PriceDate.Text = "9999/99/99 ～ 9999/99/99";
            this.Tb_PriceDate.Top = 0F;
            this.Tb_PriceDate.Width = 1.37F;
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
            this.line3.Top = 0.125F;
            this.line3.Width = 10.8125F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8125F;
            this.line3.Y1 = 0.125F;
            this.line3.Y2 = 0.125F;
            // 
            // Tb_SalesPriceSetDiv
            // 
            this.Tb_SalesPriceSetDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_SalesPriceSetDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesPriceSetDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_SalesPriceSetDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesPriceSetDiv.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_SalesPriceSetDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesPriceSetDiv.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_SalesPriceSetDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesPriceSetDiv.DataField = "salespricesetdiv";
            this.Tb_SalesPriceSetDiv.Height = 0.125F;
            this.Tb_SalesPriceSetDiv.Left = 6.875F;
            this.Tb_SalesPriceSetDiv.MultiLine = false;
            this.Tb_SalesPriceSetDiv.Name = "Tb_SalesPriceSetDiv";
            this.Tb_SalesPriceSetDiv.OutputFormat = resources.GetString("Tb_SalesPriceSetDiv.OutputFormat");
            this.Tb_SalesPriceSetDiv.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_SalesPriceSetDiv.Text = "99999";
            this.Tb_SalesPriceSetDiv.Top = 0.1875F;
            this.Tb_SalesPriceSetDiv.Visible = false;
            this.Tb_SalesPriceSetDiv.Width = 0.3125F;
            // 
            // Tb_DiscountRate
            // 
            this.Tb_DiscountRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_DiscountRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_DiscountRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_DiscountRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_DiscountRate.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_DiscountRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_DiscountRate.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_DiscountRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_DiscountRate.DataField = "discountrate";
            this.Tb_DiscountRate.Height = 0.125F;
            this.Tb_DiscountRate.Left = 6F;
            this.Tb_DiscountRate.MultiLine = false;
            this.Tb_DiscountRate.Name = "Tb_DiscountRate";
            this.Tb_DiscountRate.Style = "ddo-char-set: 128; text-align: right; font-size: 8pt; font-family: ＭＳ 明朝; vertica" +
                "l-align: top; ";
            this.Tb_DiscountRate.Text = "ZZ9.99";
            this.Tb_DiscountRate.Top = 0F;
            this.Tb_DiscountRate.Width = 0.375F;
            // 
            // Tb_creatDate
            // 
            this.Tb_creatDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_creatDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_creatDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_creatDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_creatDate.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_creatDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_creatDate.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_creatDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_creatDate.DataField = "createdatetime";
            this.Tb_creatDate.Height = 0.125F;
            this.Tb_creatDate.Left = 9.302083F;
            this.Tb_creatDate.MultiLine = false;
            this.Tb_creatDate.Name = "Tb_creatDate";
            this.Tb_creatDate.OutputFormat = resources.GetString("Tb_creatDate.OutputFormat");
            this.Tb_creatDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_creatDate.Text = "9999/99/99";
            this.Tb_creatDate.Top = 0F;
            this.Tb_creatDate.Width = 0.6F;
            // 
            // Tb_updateDate
            // 
            this.Tb_updateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_updateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_updateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_updateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_updateDate.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_updateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_updateDate.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_updateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_updateDate.DataField = "updatedatetime";
            this.Tb_updateDate.Height = 0.125F;
            this.Tb_updateDate.Left = 9.979167F;
            this.Tb_updateDate.MultiLine = false;
            this.Tb_updateDate.Name = "Tb_updateDate";
            this.Tb_updateDate.OutputFormat = resources.GetString("Tb_updateDate.OutputFormat");
            this.Tb_updateDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_updateDate.Text = "9999/99/99";
            this.Tb_updateDate.Top = 0F;
            this.Tb_updateDate.Width = 0.6F;
            // 
            // Tb_SalesCode
            // 
            this.Tb_SalesCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_SalesCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_SalesCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_SalesCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_SalesCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesCode.DataField = "salescode";
            this.Tb_SalesCode.Height = 0.125F;
            this.Tb_SalesCode.Left = 2.6875F;
            this.Tb_SalesCode.MultiLine = false;
            this.Tb_SalesCode.Name = "Tb_SalesCode";
            this.Tb_SalesCode.OutputFormat = resources.GetString("Tb_SalesCode.OutputFormat");
            this.Tb_SalesCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_SalesCode.Text = "9999";
            this.Tb_SalesCode.Top = 0.375F;
            this.Tb_SalesCode.Width = 0.25F;
            // 
            // Tb_SalesName
            // 
            this.Tb_SalesName.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_SalesName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesName.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_SalesName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesName.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_SalesName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesName.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_SalesName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SalesName.DataField = "guidename";
            this.Tb_SalesName.Height = 0.125F;
            this.Tb_SalesName.Left = 2.9375F;
            this.Tb_SalesName.MultiLine = false;
            this.Tb_SalesName.Name = "Tb_SalesName";
            this.Tb_SalesName.OutputFormat = resources.GetString("Tb_SalesName.OutputFormat");
            this.Tb_SalesName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_SalesName.Text = "あいうえおかきくけこ";
            this.Tb_SalesName.Top = 0.375F;
            this.Tb_SalesName.Width = 1.15F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.25F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport,
            this.Line5});
            this.ExtraHeader.Height = 0.5104167F;
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
            this.Line5.Top = 0.5F;
            this.Line5.Width = 10.8125F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8125F;
            this.Line5.Y1 = 0.5F;
            this.Line5.Y2 = 0.5F;
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
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.line4,
            this.Lb_GoodsMaker,
            this.Lb_CampaignCode,
            this.Lb_SectionCode,
            this.Lb_BLGoodsCode,
            this.Lb_BLGroupCode,
            this.Lb_CustomerCode,
            this.Lb_RateVal,
            this.Lb_PriceFl,
            this.Lb_PriceDate,
            this.Lb_CampaignObjDiv,
            this.Lb_ApplyDate,
            this.line7,
            this.Lb_DiscountRate,
            this.Lb_creatDate,
            this.Lb_updateDate,
            this.Lb_SalesCode});
            this.TitleHeader.Height = 0.5833333F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.Lb_GoodsNo.Height = 0.125F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 0F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "品番";
            this.Lb_GoodsNo.Top = 0F;
            this.Lb_GoodsNo.Width = 1.0625F;
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
            this.Lb_GoodsName.Height = 0.125F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 1.416667F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsName.Text = "品名";
            this.Lb_GoodsName.Top = 0F;
            this.Lb_GoodsName.Width = 1F;
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
            this.line4.Top = 0.1354167F;
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0.1354167F;
            this.line4.Y2 = 0.1354167F;
            // 
            // Lb_GoodsMaker
            // 
            this.Lb_GoodsMaker.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsMaker.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsMaker.Height = 0.125F;
            this.Lb_GoodsMaker.HyperLink = "";
            this.Lb_GoodsMaker.Left = 2.6875F;
            this.Lb_GoodsMaker.MultiLine = false;
            this.Lb_GoodsMaker.Name = "Lb_GoodsMaker";
            this.Lb_GoodsMaker.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_GoodsMaker.Text = "ﾒｰｶｰ";
            this.Lb_GoodsMaker.Top = 0F;
            this.Lb_GoodsMaker.Width = 0.4375F;
            // 
            // Lb_CampaignCode
            // 
            this.Lb_CampaignCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CampaignCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CampaignCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CampaignCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CampaignCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignCode.Height = 0.125F;
            this.Lb_CampaignCode.HyperLink = "";
            this.Lb_CampaignCode.Left = 0F;
            this.Lb_CampaignCode.MultiLine = false;
            this.Lb_CampaignCode.Name = "Lb_CampaignCode";
            this.Lb_CampaignCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CampaignCode.Text = "ｷｬﾝﾍﾟｰﾝ";
            this.Lb_CampaignCode.Top = 0.125F;
            this.Lb_CampaignCode.Visible = false;
            this.Lb_CampaignCode.Width = 0.5F;
            // 
            // Lb_SectionCode
            // 
            this.Lb_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SectionCode.Height = 0.125F;
            this.Lb_SectionCode.HyperLink = "";
            this.Lb_SectionCode.Left = 2.625F;
            this.Lb_SectionCode.MultiLine = false;
            this.Lb_SectionCode.Name = "Lb_SectionCode";
            this.Lb_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SectionCode.Text = "拠点";
            this.Lb_SectionCode.Top = 0.125F;
            this.Lb_SectionCode.Visible = false;
            this.Lb_SectionCode.Width = 0.3125F;
            // 
            // Lb_BLGoodsCode
            // 
            this.Lb_BLGoodsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGoodsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGoodsCode.Height = 0.125F;
            this.Lb_BLGoodsCode.HyperLink = "";
            this.Lb_BLGoodsCode.Left = 0F;
            this.Lb_BLGoodsCode.MultiLine = false;
            this.Lb_BLGoodsCode.Name = "Lb_BLGoodsCode";
            this.Lb_BLGoodsCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGoodsCode.Text = "BLｺｰﾄﾞ";
            this.Lb_BLGoodsCode.Top = 0.375F;
            this.Lb_BLGoodsCode.Width = 0.5625F;
            // 
            // Lb_BLGroupCode
            // 
            this.Lb_BLGroupCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_BLGroupCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_BLGroupCode.Height = 0.125F;
            this.Lb_BLGroupCode.HyperLink = "";
            this.Lb_BLGroupCode.Left = 0.8125F;
            this.Lb_BLGroupCode.MultiLine = false;
            this.Lb_BLGroupCode.Name = "Lb_BLGroupCode";
            this.Lb_BLGroupCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_BLGroupCode.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
            this.Lb_BLGroupCode.Top = 0.375F;
            this.Lb_BLGroupCode.Width = 0.625F;
            // 
            // Lb_CustomerCode
            // 
            this.Lb_CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CustomerCode.Height = 0.125F;
            this.Lb_CustomerCode.HyperLink = "";
            this.Lb_CustomerCode.Left = 4.09375F;
            this.Lb_CustomerCode.MultiLine = false;
            this.Lb_CustomerCode.Name = "Lb_CustomerCode";
            this.Lb_CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CustomerCode.Text = "得意先";
            this.Lb_CustomerCode.Top = 0F;
            this.Lb_CustomerCode.Width = 0.5625F;
            // 
            // Lb_RateVal
            // 
            this.Lb_RateVal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_RateVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_RateVal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_RateVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_RateVal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_RateVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_RateVal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_RateVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_RateVal.Height = 0.125F;
            this.Lb_RateVal.HyperLink = "";
            this.Lb_RateVal.Left = 6.375F;
            this.Lb_RateVal.MultiLine = false;
            this.Lb_RateVal.Name = "Lb_RateVal";
            this.Lb_RateVal.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_RateVal.Text = "売価率";
            this.Lb_RateVal.Top = 0F;
            this.Lb_RateVal.Width = 0.4375F;
            // 
            // Lb_PriceFl
            // 
            this.Lb_PriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceFl.Height = 0.125F;
            this.Lb_PriceFl.HyperLink = "";
            this.Lb_PriceFl.Left = 7.42F;
            this.Lb_PriceFl.MultiLine = false;
            this.Lb_PriceFl.Name = "Lb_PriceFl";
            this.Lb_PriceFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PriceFl.Text = "売価額";
            this.Lb_PriceFl.Top = 0F;
            this.Lb_PriceFl.Width = 0.375F;
            // 
            // Lb_PriceDate
            // 
            this.Lb_PriceDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_PriceDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_PriceDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_PriceDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_PriceDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_PriceDate.Height = 0.125F;
            this.Lb_PriceDate.HyperLink = "";
            this.Lb_PriceDate.Left = 7.854167F;
            this.Lb_PriceDate.MultiLine = false;
            this.Lb_PriceDate.Name = "Lb_PriceDate";
            this.Lb_PriceDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_PriceDate.Text = "価格日";
            this.Lb_PriceDate.Top = 0F;
            this.Lb_PriceDate.Width = 0.375F;
            // 
            // Lb_CampaignObjDiv
            // 
            this.Lb_CampaignObjDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_CampaignObjDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignObjDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_CampaignObjDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignObjDiv.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_CampaignObjDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignObjDiv.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_CampaignObjDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_CampaignObjDiv.Height = 0.125F;
            this.Lb_CampaignObjDiv.HyperLink = "";
            this.Lb_CampaignObjDiv.Left = 8.375F;
            this.Lb_CampaignObjDiv.MultiLine = false;
            this.Lb_CampaignObjDiv.Name = "Lb_CampaignObjDiv";
            this.Lb_CampaignObjDiv.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_CampaignObjDiv.Text = "対象得意先区分";
            this.Lb_CampaignObjDiv.Top = 0F;
            this.Lb_CampaignObjDiv.Visible = false;
            this.Lb_CampaignObjDiv.Width = 0.81F;
            // 
            // Lb_ApplyDate
            // 
            this.Lb_ApplyDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ApplyDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ApplyDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ApplyDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ApplyDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ApplyDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ApplyDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ApplyDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ApplyDate.Height = 0.125F;
            this.Lb_ApplyDate.HyperLink = "";
            this.Lb_ApplyDate.Left = 9.135417F;
            this.Lb_ApplyDate.MultiLine = false;
            this.Lb_ApplyDate.Name = "Lb_ApplyDate";
            this.Lb_ApplyDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_ApplyDate.Text = "適用期間";
            this.Lb_ApplyDate.Top = 0F;
            this.Lb_ApplyDate.Visible = false;
            this.Lb_ApplyDate.Width = 0.5625F;
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
            this.line7.Height = 0F;
            this.line7.Left = 0F;
            this.line7.LineWeight = 2F;
            this.line7.Name = "line7";
            this.line7.Top = 0.26F;
            this.line7.Visible = false;
            this.line7.Width = 10.8125F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8125F;
            this.line7.Y1 = 0.26F;
            this.line7.Y2 = 0.26F;
            // 
            // Lb_DiscountRate
            // 
            this.Lb_DiscountRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_DiscountRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DiscountRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_DiscountRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DiscountRate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_DiscountRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DiscountRate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_DiscountRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_DiscountRate.Height = 0.125F;
            this.Lb_DiscountRate.HyperLink = "";
            this.Lb_DiscountRate.Left = 5.9375F;
            this.Lb_DiscountRate.MultiLine = false;
            this.Lb_DiscountRate.Name = "Lb_DiscountRate";
            this.Lb_DiscountRate.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_DiscountRate.Text = "値引率";
            this.Lb_DiscountRate.Top = 0F;
            this.Lb_DiscountRate.Width = 0.4375F;
            // 
            // Lb_creatDate
            // 
            this.Lb_creatDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_creatDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_creatDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_creatDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_creatDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_creatDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_creatDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_creatDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_creatDate.Height = 0.125F;
            this.Lb_creatDate.HyperLink = "";
            this.Lb_creatDate.Left = 9.302083F;
            this.Lb_creatDate.MultiLine = false;
            this.Lb_creatDate.Name = "Lb_creatDate";
            this.Lb_creatDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_creatDate.Text = "作成日";
            this.Lb_creatDate.Top = 0F;
            this.Lb_creatDate.Width = 0.55F;
            // 
            // Lb_updateDate
            // 
            this.Lb_updateDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_updateDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_updateDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_updateDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_updateDate.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_updateDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_updateDate.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_updateDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_updateDate.Height = 0.125F;
            this.Lb_updateDate.HyperLink = "";
            this.Lb_updateDate.Left = 9.979167F;
            this.Lb_updateDate.MultiLine = false;
            this.Lb_updateDate.Name = "Lb_updateDate";
            this.Lb_updateDate.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_updateDate.Text = "更新日";
            this.Lb_updateDate.Top = 0F;
            this.Lb_updateDate.Width = 0.55F;
            // 
            // Lb_SalesCode
            // 
            this.Lb_SalesCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCode.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCode.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesCode.Height = 0.125F;
            this.Lb_SalesCode.HyperLink = "";
            this.Lb_SalesCode.Left = 1.5625F;
            this.Lb_SalesCode.MultiLine = false;
            this.Lb_SalesCode.Name = "Lb_SalesCode";
            this.Lb_SalesCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.Lb_SalesCode.Text = "販売区分";
            this.Lb_SalesCode.Top = 0.375F;
            this.Lb_SalesCode.Width = 0.625F;
            // 
            // TL_CampaignCode
            // 
            this.TL_CampaignCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TL_CampaignCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TL_CampaignCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignCode.Border.RightColor = System.Drawing.Color.Black;
            this.TL_CampaignCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignCode.Border.TopColor = System.Drawing.Color.Black;
            this.TL_CampaignCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignCode.DataField = "campaigncode";
            this.TL_CampaignCode.Height = 0.125F;
            this.TL_CampaignCode.Left = 0.84375F;
            this.TL_CampaignCode.MultiLine = false;
            this.TL_CampaignCode.Name = "TL_CampaignCode";
            this.TL_CampaignCode.OutputFormat = resources.GetString("TL_CampaignCode.OutputFormat");
            this.TL_CampaignCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.TL_CampaignCode.Text = "999999";
            this.TL_CampaignCode.Top = 0F;
            this.TL_CampaignCode.Width = 0.4375F;
            // 
            // TL_CampaignName
            // 
            this.TL_CampaignName.Border.BottomColor = System.Drawing.Color.Black;
            this.TL_CampaignName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignName.Border.LeftColor = System.Drawing.Color.Black;
            this.TL_CampaignName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignName.Border.RightColor = System.Drawing.Color.Black;
            this.TL_CampaignName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignName.Border.TopColor = System.Drawing.Color.Black;
            this.TL_CampaignName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_CampaignName.DataField = "campaignname";
            this.TL_CampaignName.Height = 0.125F;
            this.TL_CampaignName.Left = 1.322917F;
            this.TL_CampaignName.MultiLine = false;
            this.TL_CampaignName.Name = "TL_CampaignName";
            this.TL_CampaignName.OutputFormat = resources.GetString("TL_CampaignName.OutputFormat");
            this.TL_CampaignName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.TL_CampaignName.Text = "あいうえおかきくけこあいうえおかきくけこ";
            this.TL_CampaignName.Top = 0F;
            this.TL_CampaignName.Width = 2.25F;
            // 
            // TL_SectionCode
            // 
            this.TL_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TL_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TL_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.TL_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.TL_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionCode.DataField = "sectioncode";
            this.TL_SectionCode.Height = 0.125F;
            this.TL_SectionCode.Left = 5.6875F;
            this.TL_SectionCode.MultiLine = false;
            this.TL_SectionCode.Name = "TL_SectionCode";
            this.TL_SectionCode.OutputFormat = resources.GetString("TL_SectionCode.OutputFormat");
            this.TL_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.TL_SectionCode.Text = "99";
            this.TL_SectionCode.Top = 0F;
            this.TL_SectionCode.Width = 0.1875F;
            // 
            // TL_SectionName
            // 
            this.TL_SectionName.Border.BottomColor = System.Drawing.Color.Black;
            this.TL_SectionName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionName.Border.LeftColor = System.Drawing.Color.Black;
            this.TL_SectionName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionName.Border.RightColor = System.Drawing.Color.Black;
            this.TL_SectionName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionName.Border.TopColor = System.Drawing.Color.Black;
            this.TL_SectionName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_SectionName.DataField = "sectionguidesnm";
            this.TL_SectionName.Height = 0.125F;
            this.TL_SectionName.Left = 5.9375F;
            this.TL_SectionName.MultiLine = false;
            this.TL_SectionName.Name = "TL_SectionName";
            this.TL_SectionName.OutputFormat = resources.GetString("TL_SectionName.OutputFormat");
            this.TL_SectionName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.TL_SectionName.Text = "あいうえおかきくけこ";
            this.TL_SectionName.Top = 0F;
            this.TL_SectionName.Width = 1.14F;
            // 
            // TL_ApplyDate
            // 
            this.TL_ApplyDate.Border.BottomColor = System.Drawing.Color.Black;
            this.TL_ApplyDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_ApplyDate.Border.LeftColor = System.Drawing.Color.Black;
            this.TL_ApplyDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_ApplyDate.Border.RightColor = System.Drawing.Color.Black;
            this.TL_ApplyDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_ApplyDate.Border.TopColor = System.Drawing.Color.Black;
            this.TL_ApplyDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TL_ApplyDate.DataField = "applydate";
            this.TL_ApplyDate.Height = 0.125F;
            this.TL_ApplyDate.Left = 3.59375F;
            this.TL_ApplyDate.MultiLine = false;
            this.TL_ApplyDate.Name = "TL_ApplyDate";
            this.TL_ApplyDate.OutputFormat = resources.GetString("TL_ApplyDate.OutputFormat");
            this.TL_ApplyDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.TL_ApplyDate.Text = "[ 9999/99/99 ～ 9999/99/99 ]";
            this.TL_ApplyDate.Top = 0F;
            this.TL_ApplyDate.Width = 1.6F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // CampaignHeader
            // 
            this.CampaignHeader.CanShrink = true;
            this.CampaignHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.CH_CampaignCode,
            this.CH_SectionCode,
            this.line2,
            this.TL_CampaignName,
            this.TL_CampaignCode,
            this.TL_ApplyDate,
            this.TL_SectionCode,
            this.TL_SectionName,
            this.Tb_CampaignObjDiv,
            this.Tb_ApplyDate,
            this.line6});
            this.CampaignHeader.DataField = "campaigncode";
            this.CampaignHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.CampaignHeader.Height = 0.2916667F;
            this.CampaignHeader.Name = "CampaignHeader";
            this.CampaignHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.CampaignHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // CH_CampaignCode
            // 
            this.CH_CampaignCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CH_CampaignCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_CampaignCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CH_CampaignCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_CampaignCode.Border.RightColor = System.Drawing.Color.Black;
            this.CH_CampaignCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_CampaignCode.Border.TopColor = System.Drawing.Color.Black;
            this.CH_CampaignCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_CampaignCode.Height = 0.125F;
            this.CH_CampaignCode.HyperLink = "";
            this.CH_CampaignCode.Left = 0.3125F;
            this.CH_CampaignCode.MultiLine = false;
            this.CH_CampaignCode.Name = "CH_CampaignCode";
            this.CH_CampaignCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.CH_CampaignCode.Text = "ｷｬﾝﾍﾟｰﾝ";
            this.CH_CampaignCode.Top = 0F;
            this.CH_CampaignCode.Width = 0.48F;
            // 
            // CH_SectionCode
            // 
            this.CH_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CH_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CH_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.CH_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.CH_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CH_SectionCode.Height = 0.125F;
            this.CH_SectionCode.HyperLink = "";
            this.CH_SectionCode.Left = 5.3125F;
            this.CH_SectionCode.MultiLine = false;
            this.CH_SectionCode.Name = "CH_SectionCode";
            this.CH_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: ＭＳ 明朝; vertical-align: top; ";
            this.CH_SectionCode.Text = "拠点";
            this.CH_SectionCode.Top = 0F;
            this.CH_SectionCode.Width = 0.3125F;
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
            this.line2.Top = 0.125F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0.125F;
            this.line2.Y2 = 0.125F;
            // 
            // Tb_CampaignObjDiv
            // 
            this.Tb_CampaignObjDiv.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_CampaignObjDiv.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CampaignObjDiv.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_CampaignObjDiv.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CampaignObjDiv.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_CampaignObjDiv.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CampaignObjDiv.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_CampaignObjDiv.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_CampaignObjDiv.DataField = "campaignobjdiv";
            this.Tb_CampaignObjDiv.Height = 0.125F;
            this.Tb_CampaignObjDiv.Left = 8.375F;
            this.Tb_CampaignObjDiv.MultiLine = false;
            this.Tb_CampaignObjDiv.Name = "Tb_CampaignObjDiv";
            this.Tb_CampaignObjDiv.OutputFormat = resources.GetString("Tb_CampaignObjDiv.OutputFormat");
            this.Tb_CampaignObjDiv.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_CampaignObjDiv.Text = "あいうえお";
            this.Tb_CampaignObjDiv.Top = 0F;
            this.Tb_CampaignObjDiv.Visible = false;
            this.Tb_CampaignObjDiv.Width = 0.6F;
            // 
            // Tb_ApplyDate
            // 
            this.Tb_ApplyDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_ApplyDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_ApplyDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_ApplyDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_ApplyDate.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_ApplyDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_ApplyDate.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_ApplyDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_ApplyDate.DataField = "applydate";
            this.Tb_ApplyDate.Height = 0.125F;
            this.Tb_ApplyDate.Left = 9.135417F;
            this.Tb_ApplyDate.MultiLine = false;
            this.Tb_ApplyDate.Name = "Tb_ApplyDate";
            this.Tb_ApplyDate.OutputFormat = resources.GetString("Tb_ApplyDate.OutputFormat");
            this.Tb_ApplyDate.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_ApplyDate.Text = "[ 9999/99/99 ～ 9999/99/99 ]";
            this.Tb_ApplyDate.Top = 0F;
            this.Tb_ApplyDate.Visible = false;
            this.Tb_ApplyDate.Width = 1.59F;
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
            this.line6.Top = 0.125F;
            this.line6.Visible = false;
            this.line6.Width = 10.8125F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8125F;
            this.line6.Y1 = 0.125F;
            this.line6.Y2 = 0.125F;
            // 
            // CampaignFooter
            // 
            this.CampaignFooter.Height = 0F;
            this.CampaignFooter.KeepTogether = true;
            this.CampaignFooter.Name = "CampaignFooter";
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
            // Tb_SectionCode
            // 
            this.Tb_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Tb_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Tb_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.Tb_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.Tb_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tb_SectionCode.DataField = "sectioncode";
            this.Tb_SectionCode.Height = 0.125F;
            this.Tb_SectionCode.Left = 3.6875F;
            this.Tb_SectionCode.MultiLine = false;
            this.Tb_SectionCode.Name = "Tb_SectionCode";
            this.Tb_SectionCode.OutputFormat = resources.GetString("Tb_SectionCode.OutputFormat");
            this.Tb_SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; vertical" +
                "-align: top; ";
            this.Tb_SectionCode.Text = "99";
            this.Tb_SectionCode.Top = 0F;
            this.Tb_SectionCode.Width = 0.25F;
            // 
            // PMKHN08703P_01A4C
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
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.CampaignHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.CampaignFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-style: normal; text-decoration: none; font-weight: normal; font-size: 10pt; " +
                        "color: Black; font-family: MS UI Gothic; ddo-char-set: 128; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.PageEnd += new System.EventHandler(this.PMKHN08703P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN08703P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_GoodsMakerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_BLGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_RateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_PriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_PriceDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SalesPriceSetDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_DiscountRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_creatDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_updateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SalesCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SalesName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CampaignCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_BLGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_RateVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_PriceDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_CampaignObjDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ApplyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_DiscountRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_creatDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_updateDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_CampaignCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_CampaignName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_SectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TL_ApplyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CH_CampaignCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CH_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_CampaignObjDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_ApplyDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion ActiveReports Designer generated code        

        
    }
}
